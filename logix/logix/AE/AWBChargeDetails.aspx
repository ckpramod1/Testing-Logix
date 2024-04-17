<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="AWBChargeDetails.aspx.cs" Inherits="logix.AE.AWBChargeDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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







    <link href="../Styles/AWBChargeDetails.css" rel="stylesheet" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            });
            $(document).ready(function () {

                $("#<%=txt_hawb.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "AWBChargeDetails.aspx/GetAIEBLDetails",
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
                        $("#<%=txt_hawb.ClientID %>").val(i.item.label);
                        $("#<%=txt_hawb.ClientID %>").change();
                        $("#<%=hd_hawl.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_hawb.ClientID %>").val(i.item.label);
                        $("#<%=hd_hawl.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_hawb.ClientID %>").val(i.item.label);
                        $("#<%=hd_hawl.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

        }

        function getConfirmationValue() {

            if (confirm(' Are you sure you want to delete the details?')) {
                $('#<%=hfWasConfirmed.ClientID%>').val('true')
        }
        else {
            $('#<%=hfWasConfirmed.ClientID%>').val('false')
        }

        return true;
    }



    </script>
    <style type="text/css">
        .btn-UpdateAdd2 {
            z-index: 2;
            border-radius: 0px;
        }

            .btn-UpdateAdd2 input {
                border: medium none;
                line-height: normal;
                color: #4e4e4c !important;
                padding: 5px 0px 6px 28px;
                background: url(../Theme/assets/img/buttonIcon/updateadd_ic.png) no-repeat left top;
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
            /*color: #000080;*/
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }
        div#logix_CPH_btn_addn1 {
    margin: 7px 0 0 5px;
}
   .Hawbtxt {
    width: 15%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
   .BLDate1 {
    width: 7.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
   .JobInput19 {
    width: 6%;
    float: left;
    margin: 0px 0px 0px 0px;
}
   .Amount5 {
    width: 10%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
   .gridpnl {
    height: calc(100vh - 320px);
}
        div#logix_CPH_div_iframe .widget-content {
            top: 0 !important;
            padding-top: 55px !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

   
    <!-- Breadcrumbs line End -->
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lbl_head" runat="server" Text="AWB Charge Details"></asp:Label></h4>
                         <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Documentation</a> </li>
            <li><a href="#" id="HeaderLabel1" runat="server"></a></li>

            <li class="current"><a href="#" title="">AWB Charge Details</a> </li>
        </ul>
    </div>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4 FixedButtons">
                        <div class="right_btn">
                            <div class="btn ico-save" id="btn_save1" runat="server">
                                <asp:Button ID="btn_save" runat="server" Text="Save" ToolTip="Save" OnClick="btn_save_Click" />
                            </div>
                            <div class="btn ico-cancel" id="btn_back1" runat="server">
                                <asp:Button ID="btn_back" runat="server" Text="Back" ToolTip="Back" OnClick="btn_back_Click" />
                            </div>

                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="Hawbtxt">
                            <asp:Label ID="Label1" runat="server" Text="HAWB #"> </asp:Label>
                            <asp:TextBox ID="txt_hawb" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="HAWB Number" OnTextChanged="txt_hawb_TextChanged"></asp:TextBox>
                        </div>
                        <div class="BLDate1">
                            <asp:Label ID="Label2" runat="server" Text="BL Date"> </asp:Label>
                            <asp:TextBox ID="txt_bldate" runat="server" CssClass="form-control" placeholder="" ToolTip="BL Date" Enabled="false"></asp:TextBox>
                            <cc1:CalendarExtender ID="txt_bldate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txt_bldate" />
                        </div>
                        <div class="JobInput19">
                            <asp:Label ID="Label7" runat="server" Text="Job #"> </asp:Label>
                            <asp:TextBox ID="txt_job" runat="server" CssClass="form-control" onkeypress="return isNumberKey(event,'JobNo');" placeholder="" ToolTip="Job Number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4">

                        <asp:Label ID="Label3" runat="server" Text="Accounting Information"> </asp:Label>
                        <asp:TextBox ID="txt_acc" runat="server" TextMode="MultiLine" Rows="2" Columns="20" Style="resize: none;" CssClass="form-control"
                            placeholder="" ToolTip="Accounting Information"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="ChargesDrop">
                            <asp:Label ID="Label4" runat="server" Text="Charges Head"> </asp:Label>
                            <asp:DropDownList ID="ddl_charge" runat="server" CssClass="chzn-select" Width="100%" data-placeholder="Charges Head" ToolTip="Charges Head">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="Amount5">
                            <asp:Label ID="Label5" runat="server" Text="Amount"> </asp:Label>
                            <asp:TextBox ID="txt_amt" runat="server" placeholder="" ToolTip="Amount" CssClass="form-control" Style="text-align: right"></asp:TextBox>
                        </div>
                        <div class="PPDrop">
                            <asp:Label ID="Label6" runat="server" Text="PP/CC"> </asp:Label>
                            <asp:DropDownList ID="ddl_pc" runat="server" CssClass="chzn-select" Width="100%" data-placeholder="PP/CC" ToolTip="PP/CC">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="btn ico-add" id="btn_addn1" runat="server">
                            <asp:Button ID="btn_add" runat="server" Text="Add" ToolTip="Add" OnClick="btn_add_Click" />
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel ID="panel_grd" runat="server" CssClass="gridpnl MB0">
                            <asp:GridView ID="Grd_Charge" AutoGenerateColumns="False" runat="server" CssClass="Grid FixedHeader"  Width="100%" DataKeyNames="chargeid"
                                OnRowDataBound="Grd_Charge_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="charges" HeaderText="Charges" />
                                    <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ppcc" HeaderText="PP/CC" />
                                    <asp:BoundField DataField="chargeid" HeaderText="Chargeid">
                                        <HeaderStyle CssClass="Hide" />
                                        <ItemStyle CssClass="Hide" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgdelete" runat="server"
                                                ImageUrl="~/images/delete.jpg" OnClick="imgdelete_Click" Height="16px" OnClientClick="getConfirmationValue()" />
                                            <%-- <cc1:ConfirmButtonExtender ID="confirmBtExt" runat="server" TargetControlID="imgdelete" 
                                        ConfirmText="Are you sure about deleting this record?" />--%>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                </Columns>

                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle CssClass="GrdRow" />
                            </asp:GridView>
                            <div class="div_Break"></div>
                        </asp:Panel>
                    </div>
                    

                    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label id="lbl_no" runat="server">HAWB #:</label>

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
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <cc1:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="imglog" BehaviorID="Test1">
    </cc1:ModalPopupExtender>

    <asp:HiddenField ID="hd_hawl" runat="server" />
    <asp:HiddenField ID="hfWasConfirmed" runat="server" />
</asp:Content>
