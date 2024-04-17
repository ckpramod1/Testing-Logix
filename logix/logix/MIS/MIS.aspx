<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="MIS.aspx.cs" EnableEventValidation="false" Inherits="logix.MIS.MIS" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />


    <!-- Theme -->
    <%--<link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />--%>
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <link href="../Styles/VoucherRegister.css" rel="stylesheet" />
    <!--=== JavaScript ===-->


    <!-- App -->
    <%-- <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>--%>

    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

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




    <link href="../Styles/MIS.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <style type="text/css">
        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -0.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .ddl_graph {
            width: 13%;
            float: left;
            margin-top: 1%;
            margin-left: 0%;
            text-align: center;
        }

            .ddl_graph input, select {
                width: 100%;
            }

        .ddl_graph1 {
            width: 13.5%;
            float: left;
            margin-top: 1%;
            margin-left: 0%;
            text-align: center;
        }

            .ddl_graph1 input, select {
                width: 100%;
            }

        .DivAllChart2 {
            Width: 24%;
            height: 170px;
            float: left;
            /*border:1px solid red;*/
            margin-left: 1%;
        }

        .DivAllChart3 {
            Width: 24%;
            height: 170px;
            float: left;
            /*border:1px solid red;*/
            margin-left: 1%;
        }

        .DivAllChart4 {
            Width: 23%;
            height: 170px;
            float: left;
            /*border:1px solid red;*/
            margin-left: 1%;
        }

        .DivAllChart5 {
            Width: 24%;
            height: 170px;
            float: left;
            /*border:1px solid red;*/
            margin-top: 2%;
            margin-left: 1%;
        }

        .DivAllChart6 {
            Width: 24%;
            height: 170px;
            float: left;
            /*border:1px solid red;*/
            margin-left: 1%;
            margin-top: 2%;
        }


        .DivAllChart7 {
            Width: 24%;
            height: 170px;
            float: left;
            /*border:1px solid red;*/
            margin-left: 1%;
            margin-top: 2%;
        }

        .DivAllChart8 {
            Width: 23%;
            height: 170px;
            float: left;
            /*border:1px solid red;*/
            margin-left: 1%;
            margin-top: 2%;
        }

        .Break {
            clear: both;
        }

        .cal {
            width: 6.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .fil {
            width: 35.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

            .fil input {
                cursor: default !important;
            }

        .chzn-drop {
            height: 275px !important;
        }

        #IMGDIV {
            top: 300px !important;
            position: absolute;
            z-index: 9999999;
        }

        div#UpdatePanel1 {
            width: 100%;
        }








        .row {
            height: 560px !important;
            margin: 0px 5px 0px 0px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            /* width: 100%; */
        }

       

        .FromLabel4 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 2.5%;
        }

        .ToLabel4 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 1%;
        }

        /*-----log*/
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




            .LogHeadJobInput label {
                font-size: 11px;
                font-family: sans-serif;
                color: #4e4e4c;
            }


        logix_CPH_PanelLog {
            top: 200px !important;
        }
    </style>
    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {

                $("#<%=txt_Filter.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hidId.ClientID %>").val(0);
                        $.ajax({
                            url: "../MIS/MIS.aspx/GetCustomers",
                            data: "{ 'prefix': '" + request.term + "','FType':'" + $("#<%=hid_text.ClientID %>").val() + "'}",
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
                        $("#<%=txt_Filter.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_Filter.ClientID %>").change();
                        $("#<%=hidId.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_Filter.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hidId.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_Filter.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hidId.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txt_Filter.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hidId.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }



    </script>

    <script type="text/javascript">
        function DoAction(Text) {
            $("#<%=hd_op.ClientID %>").val('');
            $("#<%=hd_op.ClientID %>").val(Text);
            $("#<%=btn_show.ClientID %>").click();
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $(".grd_operProfit_AC > tbody > tr:not(:has(table, th))")
                .css("cursor", "pointer")
                .click(function (e) {
                    $(".grd_operProfit_AC td").removeClass("highlite");
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

    </script>
    <style type="text/css">
        .Gridpnl {
            width: 100%;
            Height: 552px;
            margin-left: 0.2%;
            /* margin-top: -0.5%; */
        }

        .modalPopupss {
            background-color: #FFFFFF;
            /* border-width: 1px; */
            border-style: solid;
            border-color: #CCCCCC;
            /* width: 1062px; */
            width: 99.5%;
            Height: 577px;
            margin-left: 0%;
            margin-top: -2.9%;
            overflow: hidden;
        }

        #logix_CPH_panelSerch {
            top: 40px !important;
        }

        #logix_CPH_pnlcncl {
            top: 70px !important;
        }


        .VoyageInputN4New {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            color: #000080;
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }
        span#logix_CPH_lbl_graph1 {
    float: left;
}

        .FixedHeader thead{
            position:sticky;
            top:-1px;
        }
        .FixedHeader td {
    border-bottom: 1px solid #aaaaaa !important;
    border-right: 1px solid #aaaaaa !important;
}

        .div_GridNew3 {
    width: 100%;
    margin-left: 0%;
    margin-bottom: 1%;
    margin-top: 0.1%;
    height: 317px;
    Border: 1px solid #b1b1b1;
    float: left;
    overflow: auto;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


    <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <%-- <li id="Hlbl1" runat="server"><a href="#" title="" id="HeaderLabel1" runat="server">Ocean Exports</a> </li>
            <li id="Hlbl2" runat="server"><a href="#" title="">MIS</a> </li>--%>
            <li class="current"><a href="#" title="">MIS</a> </li>
        </ul>
    </div>
    <!-- /Breadcrumbs line -->
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <h4><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text="MIS"></asp:Label>
                    </h4>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4">
                        <div class="VoyageInputN4New">
                            <asp:Label ID="Label1" runat="server" Text="Product"> </asp:Label>
                            <asp:DropDownList ID="ddl_product" AutoPostBack="true" runat="server" Width="100%" OnSelectedIndexChanged="ddl_product_SelectedIndexChanged" AppendDataBoundItems="True" CssClass="chzn-select" ToolTip="Product" data-placeholder="Product">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="ReportBranch">
                            <asp:Label ID="Label3" runat="server" Text="Report"> </asp:Label>
                            <asp:DropDownList ID="ddl_Report" runat="server" ToolTip="Report" data-placeholder="Report"
                                OnSelectedIndexChanged="ddl_Report_SelectedIndexChanged" AutoPostBack="True" CssClass="chzn-select">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <%--<div class="FromCal5">--%>
                        <div class="cal">
                            <asp:Label ID="lbl_From" runat="server" Text="From"></asp:Label>
                            <asp:TextBox ID="txt_From" runat="server" CssClass="form-control Text" TabIndex="4"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_From"
                                Format="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>

                        <%--<div class="ToCal5">--%>
                        <div class="cal">
                            <asp:Label ID="lbl_To" runat="server" Text="To"></asp:Label>
                            <asp:TextBox ID="txt_To" runat="server" CssClass="form-control Text" TabIndex="4"></asp:TextBox>
                            <asp:CalendarExtender ID="dt_validity" runat="server" TargetControlID="txt_To"
                                Format="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>
                        <div class="fil">
                            <asp:Label ID="lbl_Filter" runat="server" Text="Agent"> </asp:Label>
                            <asp:TextBox ID="txt_Filter" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="right_btn MT15">
                            <div class="btn ico-get">
                                <asp:Button ID="btn_Get" runat="server" ToolTip="Get" OnClick="btn_Get_Click" />
                            </div>
                        </div>
                        <div class="Break"></div>

                        <div class="ddl_graph">
                            <asp:Label ID="lbl_graph1" runat="server" Text="Report Type"> </asp:Label>

                            <asp:DropDownList ID="ddl_graph1" runat="server" CssClass="chzn-select" ToolTip="Report Type" AutoPostBack="True" data-placeholder="Report Type" Width="100%" OnSelectedIndexChanged="ddl_graph1_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                                <asp:ListItem Value="1">Data</asp:ListItem>
                                <asp:ListItem Value="2">Graph</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="ddl_graph1">
                            <asp:Label ID="lbl_graph2" runat="server" Text="Graph" visible="false"> </asp:Label>

                            <asp:DropDownList ID="ddl_graph2" runat="server" CssClass="chzn-select" data-placeholder="Graph" ToolTip="Graph" AutoPostBack="True" Visible="false" Width="100%" OnSelectedIndexChanged="ddl_graph2_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                                <asp:ListItem Value="1">Line</asp:ListItem>
                                <asp:ListItem Value="2">Bar</asp:ListItem>
                                <asp:ListItem Value="3">Pie</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="bordertopNew1"></div>
                    <div class="FormGroupContent">
                        <asp:Panel ID="Pnl_total_grid" CssClass="panel_15" runat="server" ScrollBars="auto">
                            <asp:GridView CssClass="Grid FixedHeader" ID="grd_Agent" runat="server" Width="100%" ForeColor="Black"
                                AutoGenerateColumns="False" DataKeyNames="agentid"
                                OnSelectedIndexChanged="grd_Agent_SelectedIndexChanged"
                                OnRowDataBound="grd_Agent_RowDataBound" OnPreRender="grd_Agent_PreRender" >
                                <Columns>
                                    <asp:TemplateField HeaderText="Agent">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 200px">
                                                <asp:Label ID="Agent" runat="server" Text='<%# Bind("Agent") %>' ToolTip='<%# Bind("Agent") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="200px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="GrWt" HeaderText="GR.WT(Kgs)" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="CBM" HeaderText="CBM" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cont20" HeaderText="Cont20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cont40" HeaderText="Cont40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="expense" HeaderText="Expenses" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>


                            <asp:GridView CssClass="Grid FixedHeader" ID="grd_Shipper" runat="server" Width="100%" ForeColor="Black"
                                AutoGenerateColumns="False" DataKeyNames="ShipperId"
                                OnSelectedIndexChanged="grd_Shipper_SelectedIndexChanged" OnRowDataBound="grd_Shipper_RowDataBound"  OnPreRender="grd_Shipper_PreRender" >
                                <Columns>

                                    <asp:TemplateField HeaderText="Shipper">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 200px">
                                                <asp:Label ID="Shipper" runat="server" Text='<%# Bind("Shipper") %>' ToolTip='<%# Bind("Shipper") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="200px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Grwt" HeaderText="GR.WT(Kgs)" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CBM" HeaderText="CBM" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cont20" HeaderText="Cont20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cont40" HeaderText="Cont40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="expense" HeaderText="Expenses" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>

                            <asp:Label ID="Label2" runat="server"></asp:Label>
                            <asp:ModalPopupExtender ID="popup" runat="server" PopupControlID="panelSerch"
                                TargetControlID="Label2" DropShadow="false" CancelControlID="close" BehaviorID="Test">
                            </asp:ModalPopupExtender>
                            <asp:Panel ID="panelSerch" runat="server"  CssClass="modalPopup" BorderStyle="Solid"
                                BorderWidth="1px" Style="display: none;">
                                <div class="divRoated">
                                    <div class="DivSecPanel">
                                        <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                    </div>


                                    <div style="float: left; width: 99%; margin: 10px 5px 10px 5px; padding: 0px;">

                                        <div style="float: left; width: 40%; margin: 0px 5px 0px 0px;">

                                            <asp:Panel ID="Panel1" runat="server" CssClass="Grid FixedHeader" >
                                                <asp:GridView CssClass="Grid FixedHeader" ID="grdshipteusdtls" runat="server" Width="100%"
                                                    AutoGenerateColumns="False" OnPreRender="grdshipteusdtls_PreRender">
                                                    <Columns>
                                                        <asp:BoundField DataField="shortname" HeaderText="Branch">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Height="20px" />
                                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="m3" HeaderText="CBM" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="50px" Height="20px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="teus" HeaderText="Teus" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="50px" Height="20px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="weight" HeaderText="Weight (in kgs)" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="75px" Height="20px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="retention" HeaderText="Retention" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="75px" Height="20px" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="GridviewScrollHeader" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                </asp:GridView>
                                            </asp:Panel>

                                            <div class="Break"></div>


                                            <%-- <div class="chart">
            <ul class="bar-chart" data-bars="[4,2],[4,5],[8,3],[4,2],[4,2]" data-max="10" data-unit="k" data-width="24"></ul>
        </div>--%>
                                        </div>
                                        <div style="width: 59%; float: left;">

                                            <asp:Panel ID="Panel2" runat="server" CssClass="Grid FixedHeader" >
                                                <asp:GridView CssClass="Grid FixedHeader" ID="grdyear" runat="server" Width="99%"
                                                    AutoGenerateColumns="False" ShowHeader="false" OnRowCreated="grdyear_RowCreated" OnPreRender="grdyear_PreRender">
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Month">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgrdmonth" runat="SERVER" Text='<%# Eval("month")  %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="branch" ControlStyle-Width="70">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgrdbranch" runat="SERVER" Text='<%# Eval("branch")  %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="vol1" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgrdvol1" runat="SERVER" Text='<%# Eval("vol1")  %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="teus1" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgrdteus1" runat="SERVER" Text='<%# Eval("teus1")  %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="chwt1" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgrdchwt1" runat="SERVER" Text='<%# Eval("weight1")  %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="retention1" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgrdretention1" runat="SERVER" Text='<%# Eval("retention1")  %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="vol2" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgrdvol2" runat="SERVER" Text='<%# Eval("vol2")  %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="teus2" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgrdteus2" runat="SERVER" Text='<%# Eval("teus2")  %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="chwt2" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgrdchwt2" runat="SERVER" Text='<%# Eval("weight2")  %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="retention2" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgrdretention2" runat="SERVER" Text='<%# Eval("retention2")  %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="left" Font-Size="9pt" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="GridviewScrollHeader" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>

                                    </div>


                                    <div class="Break"></div>
                                </div>
                            </asp:Panel>

                            <asp:GridView CssClass="Grid FixedHeader" ID="grd_Consignee" runat="server" AutoGenerateColumns="False"
                                Width="100%" ForeColor="Black"
                                DataKeyNames="Consigneeid"
                                OnSelectedIndexChanged="grd_Consignee_SelectedIndexChanged"
                                OnRowDataBound="grd_Consignee_RowDataBound" OnPreRender="grd_Consignee_PreRender">
                                <Columns>

                                    <asp:TemplateField HeaderText="Consignee">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 200px">
                                                <asp:Label ID="Consignee" runat="server" Text='<%# Bind("Consignee") %>' ToolTip='<%# Bind("Consignee") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="200px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Grwt" HeaderText="Gr.wt(Kgs)" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CBM" HeaderText="CBM" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cont20" HeaderText="Cont20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cont40" HeaderText="Cont40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Income" HeaderText="Income" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="expense" HeaderText="Expenses" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>


                            <asp:GridView CssClass="Grid FixedHeader" ID="grd_Shipment" runat="server" AutoGenerateColumns="False"
                                Width="100%" ForeColor="Black"
                                OnRowDataBound="grd_Shipment_RowDataBound" DataKeyNames="trantype,branchid" OnSelectedIndexChanged="grd_Shipment_SelectedIndexChanged" OnPreRender="grd_Shipment_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="trantype" HeaderText="Product">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="jobno" HeaderText="Job #">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nomination" HeaderText="Nomination">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TypeJob" HeaderText="JobType" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Volume" HeaderText="Volume" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cont20" HeaderText="Cont20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cont40" HeaderText="Cont40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="expense" HeaderText="Expenses" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>


                            <asp:GridView CssClass="Grid FixedHeader" ID="grd_JobwiseCosting" runat="server" Width="100%"
                                ForeColor="Black" AutoGenerateColumns="False"
                                OnRowDataBound="grd_JobwiseCosting_RowDataBound" OnSelectedIndexChanged="grd_JobwiseCosting_SelectedIndexChanged"
                                DataKeyNames="branchid" OnPreRender="grd_JobwiseCosting_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="trantype" HeaderText="Product" />
                                    <asp:BoundField DataField="Branch" HeaderText="Branch" Visible="False" />
                                    <asp:BoundField DataField="JobNo" HeaderText="Job #" />
                                    <asp:BoundField DataField="jobopenon" HeaderText="Job Open On" />
                                    <asp:BoundField DataField="jobcloseddate" HeaderText="Job Closed On" />

                                    <asp:TemplateField HeaderText="Agent">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 200px">
                                                <asp:Label ID="agent1" runat="server" Text='<%# Bind("agent") %>' ToolTip='<%# Bind("agent") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="200px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="expense" HeaderText="Expenses" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="branchid" HeaderText="branchid">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <HeaderStyle CssClass="Hide" />
                                        <ItemStyle CssClass="Hide" />
                                    </asp:BoundField>
                                    <%-- <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Lnk_job" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                        <br />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                                </Columns>

                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" Wrap="false" />
                                <HeaderStyle Wrap="false" />
                            </asp:GridView>


                            <asp:GridView CssClass="Grid FixedHeader" ID="grd_lossjob" runat="server" AutoGenerateColumns="False"
                                Width="100%" ForeColor="Black"
                                OnRowDataBound="grd_lossjob_RowDataBound"
                                OnSelectedIndexChanged="grd_lossjob_SelectedIndexChanged" OnPreRender="grd_lossjob_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="trantype" HeaderText="Product" />
                                    <%--<asp:BoundField DataField="Branch" HeaderText="Branch" />--%>
                                    <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                    <asp:BoundField DataField="jobopenon" HeaderText="Job Open On" />
                                    <asp:BoundField DataField="jobcloseddate" HeaderText="Job Closed On" />
                                    <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="expense" HeaderText="Expenses" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>


                            <asp:GridView CssClass="Grid FixedHeader" ID="grd_nomvafree" runat="server" AutoGenerateColumns="False"
                                Width="100%" ForeColor="Black" OnPreRender="grd_nomvafree_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="pyear" HeaderText="Product">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pmonth" HeaderText="Unit">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pmonth" HeaderText="A Volume/Tues">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pmonth" HeaderText="A Retention">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pfcl" HeaderText="A Per Unit">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="afcl" HeaderText="O Volume/Tues">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="fcl" HeaderText="O Retention">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>


                            <asp:GridView CssClass="Grid FixedHeader" ID="grd_operProfit" runat="server" Width="100%" ForeColor="Black"
                                OnRowDataBound="grd_operProfit_RowDataBound"
                                OnRowCreated="grd_operProfit_RowCreated" OnSelectedIndexChanged="grd_operProfit_SelectedIndexChanged" OnPreRender="grd_operProfit_PreRender">
                                <Columns>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>


                            <asp:GridView CssClass="Grid FixedHeader" ID="grd_operProfit_AC" runat="server" Width="100%" ForeColor="Black"
                                OnRowDataBound="grd_operProfit_AC_RowDataBound" OnRowCommand="grd_operProfit_AC_RowCommand" AutoGenerateColumns="false"
                                OnSelectedIndexChanged="grd_operProfit_AC_SelectedIndexChanged" OnRowCreated="grd_operProfit_AC_RowCreated" OnPreRender="grd_operProfit_AC_PreRender">
                                <Columns>
                                    <asp:ButtonField CommandName="ColumnClickNew" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
                                    <asp:BoundField DataField="Branch" HeaderText="Branch"></asp:BoundField>
                                    <asp:BoundField DataField="AE" HeaderText="AE" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Width="10%" Wrap="True" />
                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AI" HeaderText="AI" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Width="10%" Wrap="True" />
                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BT" HeaderText="BT" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Width="10%" Wrap="True" />
                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CH" HeaderText="CH" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Width="10%" Wrap="True" />
                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FC" HeaderText="FC" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Width="10%" Wrap="True" />
                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OE" HeaderText="OE" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Width="10%" Wrap="True" />
                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OI" HeaderText="OI" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Width="10%" Wrap="True" />
                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Width="10%" Wrap="True" />
                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                    </asp:BoundField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>


                            <asp:GridView CssClass="Grid FixedHeader" ID="grd_POL" runat="server" AutoGenerateColumns="False"
                                Width="100%" ForeColor="Black" DataKeyNames="polid" OnRowDataBound="grd_POL_RowDataBound"
                                OnSelectedIndexChanged="grd_POL_SelectedIndexChanged" OnPreRender="grd_POL_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="pol" HeaderText="PoL">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Grwt" HeaderText="Gr.wt(Kgs)" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="volume" HeaderText="CBM" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cont20" HeaderText="Cont20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cont40" HeaderText="Cont40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="expense" HeaderText="Expenses" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>


                            <asp:GridView ID="grd_POD" runat="server" AutoGenerateColumns="False" Width="100%"
                                ForeColor="Black" DataKeyNames="podid"
                                CssClass="Grid FixedHeader" OnRowDataBound="grd_POD_RowDataBound" OnSelectedIndexChanged="grd_POD_SelectedIndexChanged" OnPreRender="grd_POD_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="pod" HeaderText="PoD">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Grwt" HeaderText="Gr.wt(Kgs)" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="volume" HeaderText="CBM" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cont20" HeaderText="Cont 20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cont40" HeaderText="cont 40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="expense" HeaderText="Expense" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>


                            <asp:GridView ID="grd_salesperson" runat="server" AutoGenerateColumns="False" Width="100%"
                                ForeColor="Black" DataKeyNames="salesid"
                                CssClass="Grid FixedHeader" OnRowDataBound="grd_salesperson_RowDataBound" OnSelectedIndexChanged="grd_salesperson_SelectedIndexChanged" OnPreRender="grd_salesperson_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="person" HeaderText="Sales Person">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Grwt" HeaderText="Gr.Wt(Kgs)" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="volume" HeaderText="CBM" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cont20" HeaderText="Cont20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cont40" HeaderText="Cont40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="expense" HeaderText="Expenses" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>

                            <asp:GridView ID="Gridliner" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="false" Font-Bold="false"
                                Width="100%" ForeColor="Black" DataKeyNames="trantype,branchid" OnRowDataBound="Gridliner_RowDataBound"
                                Visible="false" OnSelectedIndexChanged="Gridliner_SelectedIndexChanged" OnPreRender="Gridliner_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="trantype" HeaderText="Product">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="jobno" HeaderText="Job #">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="linername" HeaderText="Liner">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nomination" HeaderText="Nomination" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Volume" HeaderText="CBM/Kgs" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cont20" HeaderText="Cont20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cont40" HeaderText="Cont40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="expense" HeaderText="Expenses" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" Wrap="false" />
                                <HeaderStyle Wrap="false" />

                            </asp:GridView>


                            <asp:GridView ID="GRD_CANREPORT" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="true" Font-Bold="false"
                                Width="100%" ForeColor="Black" Visible="false" OnPreRender="GRD_CANREPORT_PreRender">
                                <Columns>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" Wrap="false" />
                                <HeaderStyle Wrap="false" />
                            </asp:GridView>

                            <asp:GridView ID="GRD_canreportAI" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="true" Font-Bold="false"
                                Width="100%" ForeColor="Black" Visible="false" OnPreRender="GRD_canreportAI_PreRender">
                                <Columns>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" Wrap="false" />
                                <HeaderStyle Wrap="false" />
                            </asp:GridView>

                            <asp:GridView ID="GRD_RegisterReport" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="true" Font-Bold="false"
                                Width="100%" ForeColor="Black" Visible="false" OnPreRender="GRD_RegisterReport_PreRender">
                                <Columns>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" Wrap="false" />
                                <HeaderStyle Wrap="false" />
                            </asp:GridView>


                            <asp:GridView ID="GRD_DoRegister" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="true" Font-Bold="false"
                                Width="100%" ForeColor="Black" Visible="false" OnRowDataBound="GRD_DoRegister_RowDataBound" OnSelectedIndexChanged="GRD_DoRegister_SelectedIndexChanged" OnPreRender="GRD_DoRegister_PreRender">
                                <Columns>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" Wrap="false" />
                                <HeaderStyle Wrap="false" />
                            </asp:GridView>


                            <asp:GridView ID="GRD_Forward" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="true" Font-Bold="false" Width="100%" ForeColor="Black"
                                Visible="false" OnRowDataBound="GRD_Forward_RowDataBound" OnSelectedIndexChanged="GRD_Forward_SelectedIndexChanged" OnPreRender="GRD_Forward_PreRender">
                                <Columns>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" Wrap="false" />
                                <HeaderStyle Wrap="false" />
                            </asp:GridView>


                            <asp:GridView ID="GRD_Revenue" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="true" Font-Bold="false" Width="100%" ForeColor="Black"
                                Visible="false" OnRowDataBound="GRD_Revenue_RowDataBound" OnPreRender="GRD_Revenue_PreRender">
                                <Columns>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" Wrap="false" />
                                <HeaderStyle Wrap="false" />
                            </asp:GridView>


                            <asp:GridView ID="Grd_freeVsnomi" runat="server" AutoGenerateColumns="False" Width="100%"
                                ForeColor="Black" CssClass="Grid FixedHeader" OnRowDataBound="Grd_freeVsnomi_RowDataBound" OnSelectedIndexChanged="Grd_freeVsnomi_SelectedIndexChanged" OnPreRender="Grd_freeVsnomi_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="product" HeaderText="Product">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="unit" HeaderText="Unit" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Fvolume" HeaderText="A Volume" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Fretn" HeaderText="A Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FRtnPUnit" HeaderText="A Per Unit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Nvolume" HeaderText="O Volume" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Nretn" HeaderText="O Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NRtnPUnit" HeaderText="O Per Unit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>


                            <asp:GridView ID="Grd_nomination" runat="server" AutoGenerateColumns="False" Width="100%"
                                ForeColor="Black" CssClass="Grid FixedHeader"
                                OnRowDataBound="Grd_nomination_RowDataBound" OnSelectedIndexChanged="Grd_nomination_SelectedIndexChanged" OnPreRender="Grd_nomination_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="trantype" HeaderText="Product">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="jobno" HeaderText="Job #">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nomination" HeaderText="Nomination">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="volume" HeaderText="CBM/Kgs" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cont20" HeaderText="Cont20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cont40" HeaderText="Cont40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="expense" HeaderText="Expense" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>


                            <asp:GridView CssClass="Grid FixedHeader" ID="Grd_shiperconsignee" runat="server" Width="100%"
                                ForeColor="Black" AutoGenerateColumns="false"
                                OnRowDataBound="Grd_shiperconsignee_RowDataBound" OnSelectedIndexChanged="Grd_shiperconsignee_SelectedIndexChanged" OnPreRender="Grd_shiperconsignee_PreRender">
                                <Columns>
                                    <%--   <asp:BoundField DataField="Customer" HeaderText="Customer" />
                                    <asp:BoundField DataField="Retention" HeaderText="Retention" />--%>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" Wrap="false" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" Wrap="false" />
                            </asp:GridView>


                            <asp:GridView CssClass="Grid FixedHeader" ID="Grd_shiperconsigneeProduct" runat="server" Width="100%"
                                ForeColor="Black" AutoGenerateColumns="true"
                                OnRowDataBound="Grd_shiperconsigneeProduct_RowDataBound" OnSelectedIndexChanged="Grd_shiperconsigneeProduct_SelectedIndexChanged" OnPreRender="Grd_shiperconsigneeProduct_PreRender">
                                <Columns>
                                    <%--   <asp:BoundField DataField="Customer" HeaderText="Customer" />
                                    <asp:BoundField DataField="Retention" HeaderText="Retention" />--%>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" Wrap="false" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" Wrap="false" />
                            </asp:GridView>


                            <asp:GridView CssClass="Grid FixedHeader" ID="grd_YearMIS" runat="server" Width="100%" ForeColor="Black"
                                AutoGenerateColumns="true" OnRowDataBound="grd_YearMIS_RowDataBound" OnPreRender="grd_YearMIS_PreRender">
                                <Columns>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" Wrap="false" />
                                <RowStyle Font-Italic="False" Wrap="false" />
                            </asp:GridView>


                            <asp:GridView ID="Grd_trendcustomer" runat="server" CssClass="Grid FixedHeader" Width="100%" OnRowDataBound="Grd_trendcustomer_RowDataBound"
                                ForeColor="Black" AutoGenerateColumns="False" OnPreRender="Grd_trendcustomer_PreRender">
                                <Columns>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" Wrap="false" />
                                <RowStyle Font-Italic="False" Wrap="false" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>


                            <asp:GridView ID="Grd_trendcustomervolume" runat="server" CssClass="Grid FixedHeader" Width="100%" OnRowDataBound="Grd_trendcustomervolume_RowDataBound"
                                ForeColor="Black" OnPreRender="Grd_trendcustomervolume_PreRender">
                                <Columns>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" Wrap="false" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" Wrap="false" />
                            </asp:GridView>


                            <asp:GridView ID="Grd_Retention" runat="server" CssClass="Grid FixedHeader" Width="100%"
                                ForeColor="Black" AutoGenerateColumns="true"
                                ShowHeader="False" OnRowDataBound="Grd_Retention_RowDataBound" OnPreRender="Grd_Retention_PreRender">
                                <Columns>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" Wrap="false" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" Wrap="false" />
                            </asp:GridView>



                            <asp:GridView CssClass="Grid FixedHeader" ID="grd_op" runat="server" AutoGenerateColumns="False"
                                Width="100%" BackColor="White" Visible="false" OnRowDataBound="grd_op_RowDataBound"
                                OnSelectedIndexChanged="grd_op_SelectedIndexChanged" OnPreRender="grd_op_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="TranTypeFull" HeaderText="Product">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="jobno" HeaderText="Job #">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nomination" HeaderText="Nomination">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Volume" HeaderText="Volume" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cont20" HeaderText="Cont20" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cont40" HeaderText="Cont40" DataFormatString="{0:#,##0}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="expense" HeaderText="Expense" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>




                            <asp:GridView ID="GRD_Common" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="true" Font-Bold="false"
                                Width="100%" ForeColor="Black" DataKeyNames="TranType" OnRowCreated="GRD_Common_RowCreated" OnRowDataBound="GRD_Common_RowDataBound"
                                Visible="false" OnSelectedIndexChanged="GRD_Common_SelectedIndexChanged" OnPreRender="GRD_Common_PreRender">
                                <Columns>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" Wrap="false" />
                                <HeaderStyle Wrap="false" />

                            </asp:GridView>

                            <asp:GridView ID="Gridtemp" runat="server" CssClass="Grid GrdRow FixedHeader" Width="100%" ShowHeaderWhenEmpty="true" ShowHeader="true" ForeColor="Black" AutoGenerateColumns="true" OnPreRender="Gridtemp_PreRender">
                                <Columns>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                            <%--<asp:Panel ID="pnl_GRD_Common" runat="server" ScrollBars="Horizontal">
                  </asp:Panel> --%>





                            <asp:Panel ID="Pln_MIS" runat="server" Visible="false">
                                <asp:Label ID="lbl_MISA" runat="server" Text="Jobs Opened,Sailed / Arrived  & Closed during  the Given  Period - A"
                                    ForeColor="Red" CssClass="LabelValue"></asp:Label>
                                <br />
                                <asp:Panel ID="pnl_MISA" runat="server" Height="120px" ScrollBars="auto">
                                    <asp:GridView ID="Grd_MISA" runat="server" CssClass="Grid FixedHeader" Width="100%" ForeColor="Black"
                                        ShowHeaderWhenEmpty="true" ShowHeader="true" AutoGenerateColumns="False" OnPreRender="Grd_MISA_PreRender">
                                        <Columns>
                                            <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                            <asp:BoundField DataField="jobdate" HeaderText="Opened On" />
                                            <asp:BoundField DataField="vesselname" HeaderText="Vessel/Flight" />
                                            <asp:BoundField DataField="vesseldate" HeaderText="Sailed/Arrived" />
                                            <asp:BoundField DataField="jobclosedate" HeaderText="Closed On" />
                                            <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                            <asp:BoundField DataField="expense" HeaderText="Expanse" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                            <asp:BoundField DataField="Retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridviewScrollHeader" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>

                                <br />
                                <asp:Label ID="lbl_MISB" runat="server" Text="Jobs Opened,Sailed / Arrived  & Closed in Previous Months but voucher Generated during the given Period - B"
                                    ForeColor="Red" CssClass="LabelValue"></asp:Label>
                                <br />
                                <asp:Panel ID="pnl_MISB" runat="server" ScrollBars="auto" Height="120px">
                                    <asp:GridView ID="Grd_MISB" runat="server" CssClass="Grid GrdRow FixedHeader" Width="100%" ShowHeaderWhenEmpty="true" ShowHeader="true" ForeColor="Black" AutoGenerateColumns="False" OnPreRender="Grd_MISB_PreRender">
                                        <Columns>
                                            <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                            <asp:BoundField DataField="jobdate" HeaderText="Opened On" />
                                            <asp:BoundField DataField="vesselname" HeaderText="Vessel/Flight" />
                                            <asp:BoundField DataField="vesseldate" HeaderText="Sailed/Arrived" />
                                            <asp:BoundField DataField="jobclosedate" HeaderText="Closed On" />
                                            <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                            <asp:BoundField DataField="expense" HeaderText="Expanse" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                            <asp:BoundField DataField="Retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridviewScrollHeader" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>
                                <br />
                                <asp:Label ID="lbl_MISC" runat="server" Text="Jobs Opened but not Sailed / Arrived  during the given Period &  Unclosed - C"
                                    ForeColor="Red" CssClass="LabelValue"></asp:Label>
                                <br />
                                <asp:Panel ID="Panel_MISC" runat="server" ScrollBars="auto" Height="120px">
                                    <asp:GridView ID="Grd_MISC" runat="server" CssClass="Grid GrdRow FixedHeader" Width="100%" ShowHeaderWhenEmpty="true" ShowHeader="true" ForeColor="Black" AutoGenerateColumns="False" OnPreRender="Grd_MISC_PreRender">
                                        <Columns>
                                            <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                            <asp:BoundField DataField="jobdate" HeaderText="Opened On" />
                                            <asp:BoundField DataField="vesselname" HeaderText="Vessel/Flight" />
                                            <asp:BoundField DataField="vesseldate" HeaderText="Sailed/Arrived" />
                                            <asp:BoundField DataField="jobclosedate" HeaderText="Closed On" />
                                            <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                            <asp:BoundField DataField="expense" HeaderText="Expanse" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                            <asp:BoundField DataField="Retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridviewScrollHeader" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>

                                <%--<br />--%>
                                <div class="div_Break"></div>
                                <asp:Label ID="lbl_MISD" runat="server" Text="Jobs Opened,Sailed / Arrived  During the given Period but Unclosed  - D"
                                    ForeColor="Red" CssClass="LabelValue"></asp:Label>
                                <br />
                                <asp:Panel ID="Panel_MISD" runat="server" ScrollBars="auto" Height="120px">
                                    <asp:GridView ID="Grd_MISD" runat="server" CssClass="Grid GrdRow FixedHeader" Width="100%" ShowHeaderWhenEmpty="true" ShowHeader="true" ForeColor="Black" AutoGenerateColumns="False" OnPreRender="Grd_MISD_PreRender">
                                        <Columns>
                                            <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                            <asp:BoundField DataField="jobdate" HeaderText="Opened On" />
                                            <asp:BoundField DataField="vesselname" HeaderText="Vessel/Flight" />
                                            <asp:BoundField DataField="vesseldate" HeaderText="Sailed/Arrived" />
                                            <asp:BoundField DataField="jobclosedate" HeaderText="Closed On" />
                                            <asp:BoundField DataField="income" HeaderText="Income" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="expense" HeaderText="Expanse" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridviewScrollHeader" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>

                                <br />
                                <asp:Label ID="lbl_retention" runat="server" Text="" ForeColor="Red" CssClass="LabelValue"></asp:Label>
                            </asp:Panel>


                            <div class="div_Break"></div>

                            <div runat="server" id="div_op_char" class="div_chat">
                                <asp:Chart ID="chartoperProfit" runat="server" Width="800px" EnableViewState="True" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                    <Series>
                                        <asp:Series Name="Series1" Color="#0000ff">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>

                            </div>

                            <div runat="server" id="div3" class="div_chat">
                                <asp:Chart ID="chartoperProfit1" runat="server" Width="800px" EnableViewState="false" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="false" Palette="Bright" ViewStateMode="Disabled">
                                    <Series>
                                        <asp:Series Name="Series1" Color="#0000ff">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>

                                <%--Chart using Ajax--%>
                                <%--<asp:BarChart ID="chartoperProfit1" runat="server" ChartHeight="300" ChartWidth="450" ChartType="Column" 
                                    ChartTitle="United States versus European Widget Production" 
                                    ChartTitleColor="#0E426C" CategoryAxisLineColor="#D08AD9" ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
                                    <Series>
                                        <asp:BarChartSeries Name="Series1" />
                                    </Series>
                                </asp:BarChart>--%>
                                <%--Chart using Ajax--%>
                            </div>

                            <div runat="server" id="div2" class="div_chat">
                                <asp:Chart ID="piechart" runat="server" Width="800px" EnableViewState="True" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                    <Series>
                                        <asp:Series Name="Series1" Color="#ffcc00">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>

                            </div>

                            <div runat="server" id="div1" class="div_chat">
                                <asp:Chart ID="PODCHARTVIEW" runat="server" Width="800px" EnableViewState="True" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                    <Series>
                                        <asp:Series Name="Series1" Color="#cc6600">
                                        </asp:Series>
                                    </Series>
                                    <Series>
                                        <asp:Series Name="Series2" Color="#3333ff">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>

                            </div>

                            <div id="DivAllCahrtnew" visible="false" class="DivAllChart" runat="server">

                                <div class="DivAllChart2">
                                    <asp:Chart ID="Chart1" runat="server" EnableViewState="True" Height="150px" Width="200px" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                        <Series>
                                            <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </div>

                                <div class="DivAllChart3">
                                    <asp:Chart ID="Chart2" runat="server" EnableViewState="True" Height="150px" Width="200px" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                        <Series>
                                            <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </div>

                                <div class="DivAllChart4">
                                    <asp:Chart ID="Chart3" runat="server" EnableViewState="True" Height="150px" Width="200px" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                        <Series>
                                            <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </div>

                                <div class="DivAllChartFriest">
                                    <asp:Chart ID="Chart4" runat="server" EnableViewState="True" Height="150px" Width="200px" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                        <Series>
                                            <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </div>

                                <div class="Break"></div>
                                <div class="Break"></div>
                                <div class="DivAllChart5">
                                    <asp:Chart ID="Chart5" runat="server" Height="150px" Width="200px" EnableViewState="True" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                        <Series>
                                            <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </div>

                                <div class="DivAllChart6">
                                    <asp:Chart ID="Chart6" runat="server" EnableViewState="True" Height="150px" Width="200px" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                        <Series>
                                            <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </div>

                                <div class="DivAllChart7">
                                    <asp:Chart ID="Chart7" runat="server" EnableViewState="True" Height="150px" Width="200px" Visible="False" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                        <Series>
                                            <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </div>

                                <div class="DivAllChart8">
                                    <asp:Chart ID="Chart8" runat="server" EnableViewState="True" Visible="False" Height="150px" Width="200px" BorderlineWidth="0" IsMapAreaAttributesEncoded="True" Palette="Bright" ViewStateMode="Enabled">
                                        <Series>
                                            <asp:Series Name="Series1" Color="#ffcc00"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </div>

                                <div class="div_Break"></div>
                            </div>
                        </asp:Panel>
                    </div>

                    <div class="div_Break"></div>



                </div>

                <div class="FormGroupContent">
                    <div class="right_btn MB10" style="margin-right: 15px;">

                        <div class="btn ico-print">
                            <asp:Button ID="btn_Print" runat="server" ToolTip="Print" OnClick="btn_Print_Click" />
                        </div>
                        <div class="btn ico-excel">
                            <asp:Button ID="btn_Export" runat="server" ToolTip="Export To Excel" OnClick="btn_Export_Click" />
                        </div>
                        <div class="btn ico-excel">
                            <asp:Button ID="btn_Export_Details" runat="server" ToolTip="Export To Excel With Details" OnClick="btn_Export_Details_Click" />
                        </div>
                        <div class="btn ico-cancel" id="bnt_cancel1" runat="server">
                            <asp:Button ID="bnt_cancel" runat="server" ToolTip="Back" OnClick="bnt_cancel_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:Label ID="LblCncl" runat="server"></asp:Label>
    <asp:ModalPopupExtender ID="popuprate" runat="server" TargetControlID="LblCncl"
        BehaviorID="frgtydfdfdf"
        PopupControlID="pnlcncl" CancelControlID="imgcls" DropShadow="false">
    </asp:ModalPopupExtender>



    <asp:Panel ID="pnlcncl" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="imgcls" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel3" runat="server"  CssClass="Gridpnl">
                <iframe id="iframe_buyratequery" width="100%" height="100%" runat="server" src="../Accounts/RetentionPerunit.aspx" frameborder="0"></iframe>

            </asp:Panel>

            <div class="Break"></div>
            <div class="Break"></div>
            <div class="Break"></div>
        </div>
        <div class="Break"></div>
        <div class="Break"></div>
        <div class="Break"></div>
    </asp:Panel>



    <asp:Button ID="btn_show" runat="server" OnClick="btn_show_Click" Style="display: none;" />
    <asp:HiddenField ID="hid" runat="server" />
    <asp:HiddenField ID="hid_vou" runat="server" />
    <asp:HiddenField ID="hidId" runat="server" Value="" />
    <asp:HiddenField ID="hid_text" runat="server" Value="Y" />
    <asp:HiddenField ID="hf_agent" runat="server" />
    <asp:HiddenField ID="hf_tran" runat="server" />
    <asp:HiddenField ID="hf_date" runat="server" />
    <asp:HiddenField ID="hd_op" runat="server" />
    <asp:GridView ID="grdexcel" runat="server"></asp:GridView>

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

            <asp:Panel ID="Panel4" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridViewlog" CssClass="GridNew FixedHeader" runat="server" AutoGenerateColumns="true"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="20"
                    BackColor="White" OnPreRender="GridViewlog_PreRender">
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
    <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="Image1" BehaviorID="Test1">
    </asp:ModalPopupExtender>

</asp:Content>







