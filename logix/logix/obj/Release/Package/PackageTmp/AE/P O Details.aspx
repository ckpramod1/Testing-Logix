<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="P O Details.aspx.cs" Inherits="logix.AE.P_O_Details" %>

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












    <link href="../Styles/PODetails.css" rel="Stylesheet" type="text/css" />

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />

    <style type="text/css">
        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        /*.divRoated
        {
           width:853px; 
            Height:303px;            
            border:3px solid black;
            margin-left:-0.5%;
            margin-top:-0.5%;
        }*/

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }


        .GridHeader1 {
            background-color: navy;
            color: White;
            font-family: sans-serif;
            font-size: 11px;
            margin-left: -0.17%;
            margin-top: -1.7%;
            position: absolute;
            width: 1026px;
        }

        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        #logix_CPH_Grd_buying_popup_foregroundElement {
            left: 0px !important;
            top: 50px !important;
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


        .modalPopupLog {
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

        .BookingInput {
            float: left;
            width: 8.5%;
            margin: 0px 0.5% 0px 0%;
        }
        
        .PONo1 {
    width: 14.7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .StyleSku {
    width: 12%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .Pieces {
    width: 11.7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .Cartons {
    width: 12%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .WeightInput1 {
    width: 10%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .Dimensions {
    width: 18%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .InvoiceInput1 {
    width: 10%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .InvoiceCal1 {
    width: 8%;
    float: left;
    margin: 0px 0px 0px 0px;
}
        div#logix_CPH_div_iframe {
    position: relative;
    top: -1px !important;
}
        div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 55px !important;
}
        .CustomerInput8 {
    width: 88.7%;
    float: left;
    margin: 0px 0px 0px 5px;
}
    </style>


    
    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>


    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {
                $("#<%=txt_pono.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_ponoid.ClientID %>").val(0);
                        $.ajax({
                            url: "P O Details.aspx/Getsagentid",
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
                    select: function (e, i) {
                        $("#<%=hf_ponoid.ClientID %>").val(i.item.val);
                        $("#<%=txt_pono.ClientID %>").change();
                    },
                    change: function (e, i) {
                        $("#<%=txt_pono.ClientID %>").val(i.item.val);
                    },
                    focus: function (e, i) {
                        $("#<%=txt_pono.ClientID %>").val(i.item.label);
                        $("#<%=txt_pono.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        $("#<%=txt_pono.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });



            }



    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
  
    <!-- Breadcrumbs line End -->
    <div >
        <div class="">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lblheader" Text="PO Details" runat="server"></asp:Label></h4>
                          <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Customer Support</a> </li>
            <li><a href="#" id="HeaderLabel1" runat="server"></a></li>
            <li class="current"><a href="#" title="">PO Details</a> </li>
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
                                <asp:Button ID="btn_save" Text="Save" runat="server" ToolTip="Save" OnClick="btn_save_Click" />
                            </div>
                            <div class="btn ico-view">
                                <asp:Button ID="btn_view" runat="server" Text="View" ToolTip="View" OnClick="btn_view_Click" />
                            </div>
                            <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                <asp:Button ID="btn_back" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_back_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="BookingInput">
                       <span>Booking #</span>
                         
                            <asp:TextBox ID="txt_bookno" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_bookno_TextChanged" placeholder="Booking #" ToolTip="Booking Number"></asp:TextBox>
                        </div>
                            <asp:LinkButton ID="lbl_lnkrate" CssClass="anc ico-find-sm" runat="server" Text="" ForeColor="red" Style="text-decoration: none;" OnClick="lbl_lnkrate_Click"></asp:LinkButton>

                        <div class="CustomerInput8">
                            <asp:Label ID="Label1" runat="server" Text="Customer"> </asp:Label>
                            <asp:TextBox ID="txt_custname" runat="server" CssClass="form-control" placeholder="" ToolTip="Customer"></asp:TextBox>
                        </div>
                    </div>

                    <div class="FormGroupContent4 boxmodal">

                    <div class="FormGroupContent4">
                        <div class="PONo1">
                            <asp:Label ID="Label2" runat="server" Text="PO #" > </asp:Label>
                            <asp:TextBox ID="txt_pono" runat="server" CssClass="form-control" placeholder="PO Number" ToolTip="PO Number" AutoPostBack="true" OnTextChanged="txt_pono_TextChanged"></asp:TextBox>
                        </div>
                        <div class="StyleSku">
                            <asp:Label ID="Label3" runat="server" Text="Style/SKU#" > </asp:Label>
                            <asp:TextBox ID="txt_style" runat="server" CssClass="form-control" placeholder="Style/SKU" ToolTip="Style/SKU Number"></asp:TextBox>
                        </div>
                        <div class="Pieces">

                            <asp:Label ID="Label4" runat="server" Text="Pieces" > </asp:Label>
                            <asp:TextBox ID="txt_pieces" runat="server" CssClass="form-control" placeholder="Pieces" ToolTip="Pieces"></asp:TextBox>
                        </div>
                        <div class="Cartons">
                            <asp:Label ID="Label6" runat="server" Text="Cartons" > </asp:Label>
                            <asp:TextBox ID="txt_cartons" runat="server" CssClass="form-control" placeholder="Cartons" ToolTip="Cartons"></asp:TextBox>
                        </div>
                        <div class="WeightInput1">
                            <asp:Label ID="Label7" runat="server" Text="Weight" > </asp:Label>
                            <asp:TextBox ID="txt_weight" runat="server" CssClass="form-control" placeholder="Weight" ToolTip="Weight"></asp:TextBox>
                        </div>
                        <div class="Dimensions">
                            <asp:Label ID="Label8" runat="server" Text="Dimensions" > </asp:Label>
                            <asp:TextBox ID="txt_dimension" runat="server" CssClass="form-control" placeholder="Dimensions" ToolTip="Dimensions"></asp:TextBox>
                        </div>
                        <div class="InvoiceInput1">
                            <asp:Label ID="Label9" runat="server" Text="Invoice #" > </asp:Label>
                            <asp:TextBox ID="txt_invno" runat="server" CssClass="form-control" placeholder="Invoice" ToolTip="Invoice Number"></asp:TextBox>
                        </div>
                        <div class="InvoiceCal1 DateR">
                            <asp:Label ID="Label10" runat="server" Text="Inv.Date" > </asp:Label>
                            <asp:TextBox ID="txt_dtinvdate" runat="server" CssClass="form-control" placeholder="" ToolTip="Inv Date"></asp:TextBox>
                            <asp:CalendarExtender ID="dtvalidity" runat="server" TargetControlID="txt_dtinvdate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>
                    </div>
                   
                        </div>
                    


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

                            <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

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









    <%-- POPUP --%>

    <asp:Panel ID="pnl_Buying" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
        <div class="DivSecPanel">
            <asp:Image ID="Close_voucher" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
        </div>

        <asp:Panel ID="pnl_grd1" runat="server"  ScrollBars="Auto" CssClass="Gridpnl">

            <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" Width="100%"
                HorizontalAlign="Left" CssClass="Grid FixedHeader"  AllowPaging="false" PageSize="20"
                OnSelectedIndexChanged="grd_SelectedIndexChanged" OnPageIndexChanging="grd_PageIndexChanging" OnRowDataBound="grd_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="bookingno" HeaderText="Booking#">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="bookingdate" HeaderText="Date">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="customername" HeaderText="Customer">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="pol" HeaderText="POL">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="pod" HeaderText="POD">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                    <%-- <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="link_select" runat="server" CommandName="select" Font-Underline="false"
                                        CssClass="Arrow">⇛</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <PagerStyle CssClass="GridviewScrollPager" />
            </asp:GridView>
            
        </asp:Panel>

        <div class="pobreak_break"></div>
         </div>
    </asp:Panel>



    <%--<div class="div_popup1">
        <asp:Panel ID="pnl_Buying" runat="server" Width="100%" Height="90%" BackColor="White" ScrollBars="Vertical">
           <div class="DivSecPanel"><asp:Image ID="Close_voucher" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="2%" Height="2%"/> </div>
             
            <div class="byrat_break"></div>
            <div class="div_grdrat">
                <asp:Panel ID="pnl_grd1" runat="server" Width="90%" Height="100%" ScrollBars="Vertical">
                    <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" Width="100%"
                        HorizontalAlign="Left" CssClass="Grid FixedHeader"  
                        onselectedindexchanged="grd_SelectedIndexChanged" >
                        <Columns>
                            <asp:BoundField DataField="bookingno" HeaderText="Booking#">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="bookingdate" HeaderText="Date" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="customername" HeaderText="Customer" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="pol" HeaderText="POL" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="pod" HeaderText="POD" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>

                         

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="link_select" runat="server" CommandName="select" Font-Underline="false"
                                        CssClass="Arrow">⇛</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                    </asp:GridView>
                </asp:Panel>
            </div>
        </asp:Panel>
        
        </div>--%>

    <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="Image1" BehaviorID="Test1">
    </asp:ModalPopupExtender>


    <asp:ModalPopupExtender ID="Grd_buying_popup" runat="server" PopupControlID="pnl_Buying"
        TargetControlID="hid" CancelControlID="Close_voucher" DropShadow="false">
    </asp:ModalPopupExtender>
    <div>
        <asp:HiddenField ID="hf_hidid1" runat="server" />
        <asp:HiddenField ID="hf_ponoid" runat="server" />
        <asp:Label ID="hid" runat="server" />
    </div>

</asp:Content>
