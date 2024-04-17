<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="DayBook.aspx.cs" Inherits="logix.FAForm.DayBook" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="KRI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/MasterSubGroup.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link rel="Stylesheet" href="../Styles/TrialBalance.css" type="text/css" />
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />

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

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/Daybook.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {
                $("#<%=txt_Refno.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../FAForms/DayBook.aspx/GetRefNo",
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

                            },
                            failure: function (response) {

                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txt_Refno.ClientID %>").val(i.item.label);
                        $("#<%=txt_Refno.ClientID %>").change();
                        $("#<%=hid_RefID.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_Refno.ClientID %>").val(i.item.label);
                        $("#<%=hid_RefID.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        var result = $("#<%=txt_Refno.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_Refno.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>

    <style type="text/css">
      

        .modalBackground {
            background-color: #ffffff;
            filter: alpha(opacity=100);
        }

        .div_frame {
            width: 1360px;
            Height: 582px;
            float: left;
            text-align: center;
            /* overflow-y: scroll; */
        }

        .DayForm {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .widget-content {
            padding: 0 10px !important;
        }

        .DayFormInput {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0.5% 0px;
        }

        .DayTO {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_ddl_VouType_chzn {
            width: 100% !important;
        }

        #logix_CPH_ddl_AmtType_chzn {
            width: 100% !important;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.5%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        iframe#logix_CPH_iframecost {
            width: 1360px;
            height: 498px;
        }

        .row {
            height: 575px !important;
            /* margin: 0px 5px 0px -15px; */
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
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
 
        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .DayRefInput {
            width: 5.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VouType {
            width: 16.5%;
            float: left;
            margin: 0px 0.5% 0px 0%;
        }

        .btn-ctrl1 {
            float: right;
        }

        .VouValue {
            width: 8.5%;
            float: left;
            margin: 0px 0.5% 0px 0%;
        }

        .VouInput1 {
            width: 8.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }

        .btn.btn-view1 {
            margin-top: 10px;
        }
 
        .widget.box .widget-content {
    top: 0px !important;
    padding-top: 47px !important;
}
        .left_btn {
    float: left;
    margin: 8px 0px 0px 0px;
}
        div#logix_CPH_ddl_VouType_chzn .chzn-drop {
    height: 436px !important;
}
        .custom-mt-2 {
    margin-top: 12px !important;
}
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="Server">

    <div>
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_header" runat="server" Text="Day Book"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs1" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li><a href="#">Approval</a> </li>
                            <li><a href="#" title="">Day Book</a> </li>
                            <li>
                                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
                        </ul>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>


                       <div class="FixedButtons">
    <div class="right_btn">
        <div class="btn ico-excel">
            <asp:Button ID="Btn_Export" Text="Export Excel" runat="server" ToolTip="Export Excel" OnClick="Btn_Export_Click" />
        </div>
        <div class="btn ico-cancel" id="btn_cancel1" runat="server">
            <asp:Button ID="btn_cancel" runat="server" Text="Back" ToolTip="Back" OnClick="btn_cancel_Click" />
        </div>
    </div>
</div>

                </div>

                <div class="widget-content">
                      
                    <div class="FormGroupContent4 boxmodal">
                        <div class="DayForm">
                            <asp:Label ID="lbl_from" runat="server" Text="From" CssClass="LabelValue"></asp:Label>

                            <asp:TextBox ID="txt_from" runat="server" CssClass="form-control" OnTextChanged="txt_from_TextChanged"></asp:TextBox>
                            <KRI:CalendarExtender ID="cal_dtfrom" runat="server" TargetControlID="txt_from" DaysModeTitleFormat="MMMM,yyyy" Format="dd/MM/yyyy" TodaysDateFormat="MMMM,d,yyyy"></KRI:CalendarExtender>
                        </div>
                        <div class="DayTO">
                            <asp:Label ID="lbl_to" runat="server" Text="To" CssClass="LabelValue"></asp:Label>

                            <asp:TextBox ID="txt_to" runat="server" CssClass="form-control" OnTextChanged="txt_to_TextChanged"></asp:TextBox>
                            <KRI:CalendarExtender ID="cal_dtto" runat="server" TargetControlID="txt_to" Format="dd/MM/yyyy"></KRI:CalendarExtender>
                        </div>
                        <div class="left_btn custom-mt-2">
                            <div class="btn ico-get">
                                <asp:Button ID="btn_view" runat="server" Text="View" ToolTip="Get" OnClick="btnview_Click" OnClientClick="timediff();" />

                            </div>
                        </div>

                        <div>
                        </div>

                    </div>

                    <div class="bordertopNew"></div>
                    <div class="FormGroupContent4">

                        <div class="VouType">

                            <asp:Label ID="lbl_voutype" runat="server" Text="Vou Type" CssClass="LabelValue"></asp:Label>

                            <asp:DropDownList ID="ddl_VouType" CssClass="chzn-select" runat="server" Height="23px" ToolTip="Ref Number" placeholder="" AppendDataBoundItems="True"
                                DataTextField="voutypename" DataValueField="voutypeid" OnSelectedIndexChanged="ddl_VouType_SelectedIndexChanged">
                                <asp:ListItem Value="0"  Text=""></asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="DayRefInput">

                            <asp:Label ID="lbl_ref" runat="server" Text="Ref #" CssClass="LabelValue"></asp:Label>
                            <asp:TextBox ID="txt_Refno" runat="server" ToolTip="Ref Number" placeholder="" CssClass="form-control" OnTextChanged="txt_Refno_TextChanged"
                                AutoPostBack="True"></asp:TextBox>
                        </div>
                        <div class="VouValue">

                            <asp:Label ID="lbl_value" runat="server" Text="Value" CssClass="LabelValue"></asp:Label>

                            <asp:TextBox ID="txt_Amt" runat="server" ToolTip="Value" placeholder="" OnTextChanged="txt_Amt_TextChanged" AutoPostBack="True"
                                CssClass="form-control"></asp:TextBox>

                        </div>
                        <div class="VouInput1">
                            <asp:Label ID="Label1" runat="server" Text="Amt Type"> </asp:Label>
                            <asp:DropDownList ID="ddl_AmtType" data-placeholder="Amt Type" CssClass="chzn-select" Height="23px" runat="server" OnSelectedIndexChanged="ddl_AmtType_SelectedIndexChanged"
                                AutoPostBack="True">
                                 <asp:ListItem Value="0" Text=""></asp:ListItem>
                                <asp:ListItem Value="1">Equals</asp:ListItem>
                                <asp:ListItem Value="2">Greater</asp:ListItem>
                                <asp:ListItem Value="3">Less</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                    <div class="bordertopNew"></div>

                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel ID="grdpanel" runat="server" ScrollBars="Vertical" class="gridpnl">
                            <asp:GridView ID="grd_DayBook" runat="server" AutoGenerateColumns="False" OnRowCommand="grd_DayBook_RowCommand" OnSelectedIndexChanged="grd_DayBook_SelectedIndexChanged"
                                OnRowDataBound="grd_DayBook_RowDataBound" DataKeyNames="PBid,OSVType,Vouno,LedgerType" CssClass="Grid  FixedHeader" EmptyDataText="No Records Found" OnPreRender="grd_DayBook_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="voudate" HeaderText="Vou Date" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:BoundField DataField="voutypename" HeaderText="Vou Type" ItemStyle-Wrap="false" >
                                    <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="newvouno" HeaderText="Vou #" ItemStyle-Wrap="false" >
                                    <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="parti" HeaderText="Particulars" ItemStyle-Wrap="false">
                                        <HeaderStyle HorizontalAlign="Center" Width="250px" Wrap="false" />
                                        <ItemStyle HorizontalAlign="Right" Width="250px" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="shortname" HeaderText="Branch" ItemStyle-Wrap="false" >
                                    <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ladr" HeaderText="Debit" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" CssClass="TxtAlign1" />
                                        <ItemStyle HorizontalAlign="Right" CssClass="TxtAlign1" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="lacr" HeaderText="Credit" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" CssClass="TxtAlign1" />
                                        <ItemStyle HorizontalAlign="Right" CssClass="TxtAlign1" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Narration">
                                      
                                        <ItemTemplate>
                                            <div class="wrap250">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Parti") %>'></asp:Label>
                                                </div>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="255" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Right" Width="255" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="chequeno" HeaderText="Cheque #">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        <ItemStyle HorizontalAlign="Right" Width="30px" Wrap="false" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                 
                </div>

            </div>
        </div>
    </div>

    <asp:HiddenField ID="hid_from" runat="server" />
    <asp:HiddenField ID="hid_to" runat="server" />
    <asp:HiddenField ID="hid_RefID" runat="server" />
    <asp:HiddenField ID="Hid_Amount" runat="server" />
    <asp:HiddenField ID="Hid_ddlVoutype" runat="server" />
    <asp:HiddenField ID="Hid_ddl_AmtType" runat="server" />

    <%-- <div class="FormGroupContent4">
            <asp:HiddenField ID="hidId" runat="server" />
            <asp:Panel ID="pln_Trialbalance" runat="server" class="div_frame">
            <div class="div_Trialbalance">
                <table>
                <tr>
                <td>&nbsp;</td>
                <td>                        
                <img id="Close_Trialbalance" class="div_close_Trialbalance" src="../images/GrdClose.gif"/>
                </td>
                </tr>
                </table>
            </div>
            <div class="div_frame">
                <iframe id="iframecost" runat="server" src="" frameborder="0" class="div_frmdisplay">
                </iframe>
            </div>
            </asp:Panel>
        </div>

        <KRI:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pln_Trialbalance"
        TargetControlID="hidId" BackgroundCssClass="modalBackground_FA" CancelControlID="Close_Trialbalance" >
        <Animations>
        <OnShown>
            <FadeIn Duration="1.5" Fps="40" />                
        </OnShown>
        </Animations>
        </KRI:ModalPopupExtender> --%>

    <div class="FormGroupContent4">
        <asp:HiddenField ID="hid" runat="server" />
        <asp:Panel ID="pln_Trialbalance" runat="server" CssClass=" modalPopup" BackColor="White">
            <div class="divRoated">
                <div class="DivSecPanel">
                    <asp:Image ID="Close_Trialbalance" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>

                <div class="">
                    <iframe id="iframecost" runat="server" src="" frameborder="0" class=""></iframe>
                </div>
            </div>
        </asp:Panel>
    </div>

    <KRI:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pln_Trialbalance" TargetControlID="lbl_hid" CancelControlID="Close_Trialbalance">
        <Animations>
        <OnShown>
            <FadeIn Duration="1.5" Fps="40" />                
        </OnShown>
        </Animations>
    </KRI:ModalPopupExtender>
    <asp:Label ID="lbl_hid" runat="server" />
    <asp:HiddenField ID="hidId" runat="server" />

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>DayBook #</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl">

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
