<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="FIFC.aspx.cs" Inherits="logix.FI.FIFC" %>

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


    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>
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



    <style type="text/css">
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
        .Vessel {
    float: left;
    width: 100%;
    margin-right: 0.5%;
}
        .Pol {
    width: 100%;
    float: left;
    margin: 0px 0px 0px 0px;
}
        .BLDATEN {
    width: 18%;
    float: left;
    margin: 0px 0.5% 0 0;
}
        .BLNO1 {
    width: 24%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        div#UpdatePanel1 {
    /* height: 100vh; */
    height: 88vh;
    overflow-x: hidden;
    overflow-y: auto;
}
        .divleft
        {
            width:40%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }

         .divright
        {
            width:59.5%;
            float:left;
            margin:0px 0px 0px 0px;
        }
        table#logix_CPH_grd_fifc tbody td:nth-child(1) {
            width: 10% !important;
        }
 

 
div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 45px !important;
}
   .gridpnl {
    border-top: 1px solid var(--inputborder) !important;
    margin: 5px 0px !important;
    overflow: auto !important;
    height: calc(100vh - 422px);
}
   table#logix_CPH_grd_fifc th:nth-child(4) {
    width: 49px !important;
}
    
    </style>



    <link href="../Styles/FIFC.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txt_blno.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_BL.ClientID %>").val(0);
                        $.ajax({
                            url: "../FI/FIFC.aspx/GetBL",
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
                                alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                alertify.alert(response.responseText);
                            }


                        });
                    },

                    select: function (e, i) {
                        $("#<%=hf_BL.ClientID %>").val(i.item.val);
                     $("#<%=txt_blno.ClientID %>").change();
                 },
                    change: function (e, i) {
                        $("#<%=hf_BL.ClientID %>").val(i.item.val);
                        $("#<%=txt_blno.ClientID %>").val(i.item.label);
                    },
                    focus: function (e, i) {
                        $("#<%=hf_BL.ClientID %>").val(i.item.val);
                        $("#<%=txt_blno.ClientID %>").val(i.item.label);
                    },
                    close: function (e, i) {
                        $("#<%=hf_BL.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            }
    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    
    <!-- Breadcrumbs line End -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_hdr" runat="server" Text="Freight Certificate"></asp:Label>
    
                    </h4>
                                        <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Customer Support</a> </li>
            <li><a href="#" title="" id="lblHead" runat="server"></a></li>
            <li class="current"><a href="#" title="">Freight Certificate</a> </li>
        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

                         </div>

                     <div class="FixedButtons">
      <div class="right_btn">
     <div class="btn ico-freight-certiciate ">
         <asp:Button ID="btn_frghtcertfcte" runat="server" Text="Freight Certificate" ToolTip="Freight Certificate" OnClick="btn_frghtcertfcte_Click" TabIndex="2" />
     </div>
     <div class="btn ico-cancel" id="btn_cancel1" runat="server">
         <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" TabIndex="3" />
     </div>
 </div>
 </div>


                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4">
                       
                    <div class="divleft">
                    <div class="FormGroupContent4 boxmodal">
                        <div class="BLNO1">
                            <asp:Label ID="Label1" runat="server" Text="BL #"> </asp:Label>
                            <asp:TextBox ID="txt_blno" runat="server" OnTextChanged="txt_blno_TextChanged" AutoPostBack="True" CssClass="form-control" placeholder="BL #" ToolTip="Bill of Lading Number" TabIndex="1"></asp:TextBox>
                        </div>

                        <div class="BLDATEN">
                            <asp:Label ID="Label2" runat="server" Text="BL Date"> </asp:Label>
                            <asp:TextBox ID="txt_date" runat="server" CssClass="form-control" placeholder="BL Date" ToolTip="Bill of Lading Date"></asp:TextBox>
                        </div>

                       
                    </div>

                        <div class="FormGroupContent4">
                             <div class="Vessel">
                            <asp:Label ID="Label3" runat="server" Text="Vessel"> </asp:Label>
                            <asp:TextBox ID="txt_vessel" runat="server" CssClass="form-control" ReadOnly="true" placeholder="Vessel" ToolTip="Vessel"></asp:TextBox>
                        </div>

                        </div>
                        <div class="FormGroupContent4">
                        <div class="Pol">
                            <asp:Label ID="Label5" runat="server" Text="POL"> </asp:Label>
                            <asp:TextBox ID="txt_pol" runat="server" CssClass="form-control" placeholder="POL" ReadOnly="true" ToolTip="Port of Loading"></asp:TextBox>
                        </div>

                        </div>
                    <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4">
                        <asp:Label ID="Label6" runat="server" Text="Shipper"> </asp:Label>
                        <asp:TextBox ID="txt_shipper" runat="server" CssClass="form-control" ReadOnly="true" placeholder="Shipper" ToolTip="Shipper"></asp:TextBox>
                    </div>

                    <div class="FormGroupContent4">
                        <asp:Label ID="Label7" runat="server" Text="Consignee"> </asp:Label>
                        <asp:TextBox ID="txt_consignee" runat="server" ReadOnly="true" CssClass="form-control" placeholder="Consignee" ToolTip="Consignee"></asp:TextBox>
                    </div>
                        </div>
                     <div class="FormGroupContent4 boxmodal">
                        <div class="gridpnl">
                             <asp:GridView ID="grd_fifc" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" Width="100%" OnRowDataBound="grd_fifc_RowDataBound"
                            OnSelectedIndexChanged="grd_fifc_SelectedIndexChanged" ShowHeaderWhenEmpty="true" OnPreRender="grd_fifc_PreRender">
                            <Columns>
                                <asp:BoundField DataField="invno" HeaderText="Inv #">
                                    <HeaderStyle Width="150px" />
                                    <ItemStyle  Width="150px"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="charges" HeaderText="Charges">
                                    <HeaderStyle />

                                </asp:BoundField>
                                <asp:BoundField DataField="amount" HeaderText="Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"  DataFormatString="{0:F2}">
                                    <HeaderStyle Width="150px"/>
                                    <ItemStyle Width="150px"/>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Print BL">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk_select" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                        </div>
                        </div>
                    </div>

                     
                        </div>

                </div>
            </div>
        </div>
    </div>


    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>BL # :</label>

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

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>


    <div class="">
        <asp:HiddenField ID="hf_BL" runat="server" />
        <asp:HiddenField ID="hf_jobno" runat="server" />
        <asp:HiddenField ID="hf_vouyear" runat="server" />
        <asp:HiddenField ID="hf_invno" runat="server" />
    </div>

</asp:Content>
