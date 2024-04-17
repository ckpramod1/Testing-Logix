<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="FIEvenTrucking.aspx.cs" Inherits="logix.FI.FIEvenTrucking" %>

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

    <link href="../Styles/FIEventTrucking.css" rel="stylesheet" />

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txtCustomer.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "FIEvenTrucking.aspx/Getcusname",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        address: item.split('~')[2]
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
                        $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtCustomer.ClientID %>").val(i.item.address);
                        $("#<%=txtCustomer.ClientID %>").change();
                        $("#<%=hf_customerid.ClientID %>").val(i.item.val);

                    },
                    focus: function (event, i) {
                        $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtCustomer.ClientID %>").val(i.item.address);
                        $("#<%=hf_customerid.ClientID %>").val(i.item.val);

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_customerid.ClientID %>").val(i.item.val);
                            $("#<%=txtCustomer.ClientID %>").val(i.item.address);
                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtCustomer.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtCustomer.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });
        }
    </script>

    <style type="text/css">
        .crumbslbl {
            display: none;
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

            .LogHeadJobInput label {
                font-size: 11px;
                font-family: sans-serif;
                color: #4e4e4c;
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
 
       

/*New Design - Buttons*/


div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
.CusCal1 {
    width: 7.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.CusCal2 {
    width: 7.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
div#logix_CPH_Panel1 {
    height: calc(100vh - 178px);
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <asp:HiddenField ID="hf_customerid" runat="server" />
    <asp:HiddenField ID="hdf_cus" runat="server" />

    <!-- Breadcrumbs line End -->
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_header" runat="server" Text="Event Tracking"></asp:Label>
                    </h4>
                     <!-- Breadcrumbs line -->
    <div class="crumbs" id="crumbslbl" runat="server">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Customer Support</a> </li>
            <li><a href="#" title="">Ocean Imports</a> </li>
            <li class="current"><a href="#" title="">Event Tracking</a> </li>
        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4 FixedButtons">
                          <div class="right_btn">
                               <div class="btn ico-find ">
                            <asp:Button ID="btnfind" ToolTip="Find" runat="server" Text="Find" UseSubmitBehavior="False" OnClick="btnfind_Click" />
                        </div>
                        <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                            <asp:Button ID="btnclear" ToolTip="Cancel" runat="server"  Text="Cancel" UseSubmitBehavior="False" OnClick="btnclear_Click" />
                        </div>
                            <div class="btn ico-excel">
                                <asp:Button ID="btnexport" Text="Export To Excel" ToolTip="Export To Excel" runat="server" UseSubmitBehavior="False" OnClick="btnexport_Click" />
                            </div>

                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="JboInput1">
                           
                            <asp:Label ID="Label1" runat="server" Text=" Job #"> </asp:Label>
                            <asp:TextBox ID="txtJobno" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip=" Job #" OnTextChanged="txtJobno_TextChanged"></asp:TextBox>
                        </div>
                        <div class="CusName">
                            <asp:Label ID="Label2" runat="server" Text="Customer Name"> </asp:Label>
                            <asp:TextBox ID="txtCustomer" runat="server" CssClass="form-control" AutoPostBack="true" placeholder=" " ToolTip=" Customer Name" OnTextChanged="txtCustomer_TextChanged"></asp:TextBox>
                        </div>
                        <div class="CusCal1">
                            <asp:Label ID="Label3" runat="server" Text="From"> </asp:Label>
                            <asp:TextBox ID="dtFrom" runat="server" CssClass="form-control" placeholder="" ToolTip="From" AutoPostBack="true" OnTextChanged="dtFrom_TextChanged"></asp:TextBox>
                        </div>
                        <div class="CusCal2">
                            <asp:Label ID="Label5" runat="server" Text="To"> </asp:Label>
                            <asp:TextBox ID="dtTo" runat="server" CssClass="form-control" placeholder="" ToolTip="To" AutoPostBack="true" OnTextChanged="dtTo_TextChanged"></asp:TextBox>
                        </div>
                       
                    </div>
                    <div class="FormGroupContent4 boxmodal">

                        <asp:Panel ID="Panel1" CssClass="gridpnl" runat="server">
                            <asp:GridView ID="grd" runat="server" CssClass="Grid1 FixedHeader" Width="1500px" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" OnPreRender="grd_PreRender">
                                <Columns>
                                    <asp:BoundField HeaderText="Job #" DataField="jobno">
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="BL #" DataField="blno">
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Vsl & Voy" DataField="vessel">
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Covering Letter Sent on" DataField="coveringsenton">
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Prealert Sent on" DataField="prealertsenton">
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="CAN/INV Sent on" DataField="caninvsenton">
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="PA 2 Accts " DataField="pa2accsenton">
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Cheque Recd on" DataField="chqrecon">
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Line DO  Recd on" DataField="linedorecon">
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="Destuffed on" DataField="destuffedon">
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="Devanning Recd on" DataField="devanningrecon">
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="Refund  Recd on" DataField="refundrecon">
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                   
                </div>
            </div>
        </div>
    </div>

    <div>
        <asp:CalendarExtender ID="cal_from" runat="server" TargetControlID="dtFrom" Format="dd/MM/yyyy"></asp:CalendarExtender>
        <asp:CalendarExtender ID="cal_to" runat="server" TargetControlID="dtTo" Format="dd/MM/yyyy"></asp:CalendarExtender>

    </div>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Job # :</label>

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

