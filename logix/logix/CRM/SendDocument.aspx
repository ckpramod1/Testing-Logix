<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="SendDocument.aspx.cs" Inherits="logix.CRM.SendDocument" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemcrm.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css" />
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

    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>

    <link rel="Stylesheet" href="../Styles/ControlStyle.css" />
    <link rel="stylesheet" href="../Styles/ControlStyle2.css" />
    <script type="text/javascript" src="../Scripts/Validation.js"></script>
    <link href="../Styles/senddocuments.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {

                $("#<%=txt_imailid.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_imailid.ClientID %>").val(0);
                        $.ajax({
                            url: "../CRM/SendDocument.aspx/IMailID",
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
                        $("#<%=hf_imailid.ClientID %>").val(i.item.val);
                        $("#<%=hf_imailname.ClientID %>").val(i.item.label);
                        $("#<%=txt_imailid.ClientID %>").val(i.item.label);
                        $("#<%=txt_imailid.ClientID %>").change();
                    },
                    <%--change: function (e, i) {
                        $("#<%=txt_imailid.ClientID %>").val(i.item.label);
                        $("#<%=hf_imailid.ClientID %>").val(i.item.val);
                        $("#<%=hf_imailname.ClientID %>").val(i.item.label);                        
                    },--%>
                    focus: function (e, i) {
                        $("#<%=txt_imailid.ClientID %>").val(i.item.label);
                        $("#<%=hf_imailid.ClientID %>").val(i.item.val);
                        $("#<%=hf_imailname.ClientID %>").val(i.item.label);
                    },
                    close: function (e, i) {
                        $("#<%=txt_imailid.ClientID %>").val(i.item.label);
                        $("#<%=hf_imailid.ClientID %>").val(i.item.val);
                        $("#<%=hf_imailname.ClientID %>").val(i.item.label);
                        $("#<%=txt_imailid.ClientID %>").change();
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txt_cmailid.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_cmailid.ClientID %>").val(0);

                        $.ajax({
                            url: "../CRM/SendDocument.aspx/CMailID",
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
                        $("#<%=hf_cmailid.ClientID %>").val(i.item.val);
                        $("#<%=hf_cmailname.ClientID %>").val(i.item.label);
                        $("#<%=txt_cmailid.ClientID %>").change();
                    },
                    change: function (e, i) {
                        $("#<%=hf_cmailid.ClientID %>").val(i.item.val);
                        $("#<%=hf_cmailname.ClientID %>").val(i.item.label);
                    },
                    focus: function (e, i) {
                        $("#<%=hf_cmailid.ClientID %>").val(i.item.val);
                        $("#<%=hf_cmailname.ClientID %>").val(i.item.label);
                    },
                    close: function (e, i) {
                        $("#<%=hf_cmailid.ClientID %>").val(i.item.val);
                        $("#<%=hf_cmailname.ClientID %>").val(i.item.label);
                    },

                    minLength: 1
                });
            });
        }
    </script>
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
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .Hide {
            display: none;
        }

        #logix_CPH_Mdl_grdjob_foregroundElement {
            top: 50px !important;
            left: 0px !important;
        }

        .modalPopupss {
            width: 98%;
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

        .VoyInputN3 {
            float: left;
            width: 26.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .ETDInput3 {
            float: left;
            width: 16.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .AddbuttonNew1 {
            float: left;
            width: 1%;
            margin: 18px 0px 10px 0.8%;
        }

        .BLNumber1, .BLNumber2, .BLNumber3 {
    border: none;
        margin-right: 0.5% !important;

}
.btn.btn-add-icon-blue {
    margin: 15px 0 0 0px;
}
     .InternalMail {
    float: left;
    width: 91.7%;    
    margin: 0 0.5% 0 0px;
}
    div#UpdatePanel1 {
    height: 89vh;
    overflow-x: hidden;
    overflow-y: auto;
} 
     input[type=file] {
    height: 36px;
    padding: 8px;
}
     .BLNumber3 {
    margin: 0px 0 0 !important;
}
     .CustomerMailID {
    width: 50%;
    margin: 0px 0.5% 0px 0px;
}
     .CustomerMailID.boxmodal {
    margin-right: 0.5% !important;
} 
     .InternalMailID {
    float: left;
    width: 49.5%;
    margin: 0px;
}
     .attachment.boxmodal {
    width: 20%;
        float: left;
}
     .CUSMailID1 {
    float: left;
    width: 91.7%;
    margin: 0px 0.5% 0px 0px;
}
   
     .Grid th {
    border-right:1px solid #fff;
}
     table#logix_CPH_grd_cmail, table#logix_CPH_grd_imail {
    border: none;
}
     input#logix_CPH_fu_attach {
    border: 0px solid var(--inputborder) !important;
    border-radius: 3px !important;
        border-bottom: 0px solid var(--inputborder) !important;
}
     .attachment {
    float: left;
}
     .TextArea {
    position: relative;
}
     .TextArea span {
    position: absolute;
    color: var(--labelblue)!important;
    top: 10px!important;
    font-weight: 500 !important;
    font-size: 13px !important;
}
     .TextArea select, .TextArea textarea {
    margin: 10px 0px 0px !important;
    padding: 24px 5px 0px 7px !important;
    overflow: auto !important;
    font-size: 14px !important;
    border: 0px solid var(--inputborder) !important;
    border-bottom: 1px solid var(--inputborder) !important;
    border-radius: 0px;
}
/*New Design - Buttons*/

div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- /Breadcrumbs line -->
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_header" runat="server" Text="Send Document"></asp:Label>
                    </h4>
                    <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Customer Support</a> </li>
            <li><a href="#" title="">Ocean Exports</a> </li>
            <li class="current"><a href="#" title="">Send Document</a> </li>
        </ul>
    </div>
                </div>
                <div class="widget-content">

                    <div class="FormGroupContent4 FixedButtons">
                          <div class="right_btn">
                        <div class="btn ico-send"  runat="server" id="btn_send_id" >
                            <asp:Button ID="btn_send" runat="server" Text="Send" ToolTip="Send" OnClick="btn_send_Click" />
                        </div>
                        <div class="btn ico-back" id="btn_back1" runat="server">
                            <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
                        </div>
                    </div>
                    </div>
                  
                    <div class="FormGroupContent4 custom-d-flex">

                        <div class="JobInput3">
                            <span>Job #</span>
                            <asp:TextBox ID="txt_job" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="" ToolTip="Job #" OnTextChanged="txt_job_TextChanged" TabIndex="1"></asp:TextBox>
                        </div>
                         <asp:LinkButton ID="lbl_job" runat="server" ForeColor="Red" OnClick="lbl_job_Click" CssClass="anc ico-find-sm"></asp:LinkButton>
                        <div class="custom-col custom-mr-05">
                            <asp:Label ID="Label1" runat="server" Text="Vessel & Voy"> </asp:Label>
                            <asp:TextBox ID="txt_vvoy" runat="server" CssClass="form-control" placeholder="" ToolTip="Vessel & Voy" TabIndex="2"></asp:TextBox>
                        </div>
                        <div class="POLInput7">
                            <asp:Label ID="Label2" runat="server" Text="PoL"> </asp:Label>
                            <asp:TextBox ID="txt_pol" runat="server" CssClass="form-control" placeholder="" ToolTip="Port of Loading" TabIndex="3"></asp:TextBox>
                        </div>
                        <div class="ETDInput3">
                            <asp:Label ID="Label3" runat="server" Text="ETD"> </asp:Label>
                            <asp:TextBox ID="txt_etd" runat="server" CssClass="form-control" placeholder="" ToolTip="Estimated Time of Departure" TabIndex="4"></asp:TextBox>
                        </div>
                        <div class="PODINput6">
                            <asp:Label ID="Label4" runat="server" Text="PoD"> </asp:Label>
                            <asp:TextBox ID="txt_pod" runat="server" CssClass="form-control" placeholder="" ToolTip="PORT of Dischrage" TabIndex="5"></asp:TextBox>
                        </div>
                        <div class="ETAInput3">
                            <asp:Label ID="Label5" runat="server" Text="ETA"> </asp:Label>
                            <asp:TextBox ID="txt_eta" runat="server" CssClass="form-control" placeholder="" ToolTip="Estimated Time of Arrival" TabIndex="6"></asp:TextBox>
                        </div>
                        <div class="StuffedInput1 DateR">
                            <asp:Label ID="Label6" runat="server" Text="Stuffed On"> </asp:Label>
                            <asp:TextBox ID="txt_stuffedon" runat="server" CssClass="form-control" placeholder="" ToolTip="Stuffed On" TabIndex="7"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="BLNumber1 TextArea boxmodal">
                            <span>BL#/BL Date</span>
                    <div class="FormGroupContent4">
                            <asp:ListBox ID="lstbox_bldate" runat="server" Width="100%" Height="100px" Style="border: none;" placeholder="BL#/BL Date" ToolTip="BL #/BL Date" TabIndex="8"></asp:ListBox>
                        </div>
                        </div>

                        <div class="BLNumber2 TextArea boxmodal">
                            <span>Containers</span>
                    <div class="FormGroupContent4">
                            <asp:ListBox ID="chk_containers" runat="server" Width="100%" Height="100px" Style="border: none;" placeholder="Containers" ToolTip="Containers" TabIndex="9"></asp:ListBox>
                        </div>
                        </div>

                        <div class="BLNumber3 TextArea boxmodal">
                            <span>SB #/SB Date</span>
                    <div class="FormGroupContent4">
                            <asp:ListBox ID="lst_sbdate" runat="server" Width="100%" Height="100px" Style="border: none;" placeholder="SB #/SB Date" ToolTip="SB #/SB Date" TabIndex="10" OnSelectedIndexChanged="lst_sbdate_SelectedIndexChanged"></asp:ListBox>
                        </div>
                        </div>
                    </div>
                    <div class="FormGroupContent4">

                    <div class="CustomerMailID boxmodal">
                    <div class="FormGroupContent4">
                        <div class="CUSMailID1">
                            <asp:Label ID="Label7" runat="server" Text="Customer Mail-ID's"> </asp:Label>
                            <asp:TextBox ID="txt_cmailid" runat="server" CssClass="form-control" placeholder="" ToolTip="Customer Mail-ID's" TabIndex="11"></asp:TextBox>
                        </div>
                        <div class="btn ico-add-icon-blue custom-mt-2">
                            <asp:Button ID="btn_plus" runat="server" Text="Add" CssClass="Button" OnClick="btn_plus_Click" />
                        </div>
                    </div>

                    <div class="FormGroupContent4">
                        <div class="">
                            <asp:Panel ID="pnl_cmail" runat="server" Height="100px"  CssClass="panel_06 MB0">
                                <%--<asp:GridView ID="grd_cmail" runat="server" CssClass="Grid FixedHeader"  AutoGenerateColumns="False" Width="100%" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:BoundField DataField="mailid" HeaderText="Customer's Mail - ID">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>--%>
                                <asp:GridView ID="grd_cmail" runat="server" CssClass=" Grid FixedHeader" AutoGenerateColumns="False" OnSelectedIndexChanged="grd_cmail_SelectedIndexChanged" OnRowDataBound="grd_cmail_RowDataBound" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" Width="100%" BorderColor="#999997">
                                    <Columns>

                                        <asp:BoundField DataField="mailid" HeaderText="Customer's Mail-ID" />
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" CommandName="Delete"
                                                    ImageUrl="~/images/delete.jpg" Width="15px" Height="16px" OnClick="ImageButton2_Click" />
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                    </Columns>

                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />

                                </asp:GridView>
                            </asp:Panel>
                        </div>

                    </div>

                        </div>
                    <div class="InternalMailID boxmodal">
                    <div class="FormGroupContent4">
                        <div class="InternalMail">
                            <asp:Label ID="Label9" runat="server" Text="Internal Mail-ID's"> </asp:Label>
                            <asp:TextBox ID="txt_imailid" runat="server" CssClass="form-control" placeholder="" ToolTip="Internal Mail-ID's" TabIndex="12"></asp:TextBox>
                        </div>

                        <div class="btn ico-add-icon-blue custom-mt-2">
                            <asp:Button ID="btn_cmail" runat="server" Text="Add" CssClass="Button" OnClick="btn_cmail_Click" />
                        </div>
                        </div>

                         <div class="FormGroupContent4">
                            <asp:Panel ID="pnl_imail" runat="server" Height="100px" CssClass="panel_06 MB0" >
                                <asp:GridView ID="grd_imail" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="grd_imail_RowDataBound" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" CssClass="Grid FixedHeader" BorderColor="#999997">
                                    <Columns>

                                        <asp:BoundField DataField="offmailid" HeaderText="Internal's Mail-ID" />
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton" runat="server" CausesValidation="false" CommandName="Delete"
                                                    ImageUrl="~/images/delete.jpg" Width="15px" Height="16px" OnClick="ImageButton_Click" />
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />

                                </asp:GridView>
                            </asp:Panel>

                        </div>
                        </div>
                        </div>

                    <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4">
                        <asp:Label ID="Label10" runat="server" Text="Subject"> </asp:Label>
                        <asp:TextBox ID="txt_subject" runat="server" CssClass="form-control" Height="25" placeholder="" ToolTip="Subject" TabIndex="13"></asp:TextBox>
                    </div>
                    <div class="FormGroupContent4">
                        <asp:Label ID="Label11" runat="server" Text="Body"> </asp:Label>
                        <asp:TextBox ID="txt_body" runat="server" CssClass="form-control" TextMode="MultiLine" Style="resize: none;" Rows="2" Height="70px" placeholder="" TabIndex="14" ToolTip="Body"></asp:TextBox>
                    </div>
                        </div>

                    <div class="FormGroupContent4 ">
                    <div class="attachment ">
                        <asp:FileUpload ID="fu_attach" runat="server" Width="100%" placeholder="Attachment" ToolTip="Attachment" />
                        </div>
                       
                    </div>

                    <%--  <div class="FormGroupContent4">--%>
                    <asp:Panel ID="pnl_job_popup" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">

                        <div class="DivSecPanel">
                            <asp:Image ID="img_grd_job" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                        </div>

                        <asp:Panel ID="Panel5" runat="server" CssClass="Gridpnl">

                            <asp:GridView ID="grd_job" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" 
                                OnRowDataBound="grd_job_RowDataBound" EmptyDataText="No Record Found" PageSize="20" AllowPaging="false" OnPageIndexChanging="grd_job_PageIndexChanging"
                                DataKeyNames="jobno" OnSelectedIndexChanged="grd_job_SelectedIndexChanged">
                                <Columns>

                                    <asp:TemplateField HeaderText="Job">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 50px">
                                                <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="50px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="VesselName">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 110px">
                                                <asp:Label ID="VesselName" runat="server" Text='<%# Bind("vessel") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="110px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Voyage">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                <asp:Label ID="Voyage" runat="server" Text='<%# Bind("voyage") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="MBL">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                <asp:Label ID="MBL" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="120px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="JobType">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                <asp:Label ID="JobType" runat="server" Text='<%# Bind("JobType") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Destination">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                <asp:Label ID="Destination" runat="server" Text='<%# Bind("sd") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="120px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="ETD">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                <asp:Label ID="ETD" runat="server" Text='<%# Bind("etd") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="70px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="MLO">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 170px">
                                                <asp:Label ID="MLO" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="170px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="ETA">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                <asp:Label ID="ETA" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <%--<asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnk_grdjob" runat="server" CssClass="Arrow" CommandName="select"
                                    Font-Underline="false">⇛</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>--%>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle CssClass="GrdRow" />
                                <PagerStyle CssClass="GridviewScrollPager" />
                            </asp:GridView>
                        </asp:Panel>
                            
                        </div>
                        <%--</div>--%>
                    </asp:Panel>

                    <div class="div_Break"></div>
                    <asp:HiddenField ID="hf_cmailid" runat="server" />
                    <asp:HiddenField ID="hf_imailid" runat="server" />
                    <asp:HiddenField ID="hf_imailname" runat="server" />
                    <asp:HiddenField ID="hf_cmailname" runat="server" />
                    <div>
                        <asp:ModalPopupExtender ID="Mdl_grdjob" runat="server" CancelControlID="img_grd_job" PopupControlID="pnl_job_popup"
                            TargetControlID="hidjob" DropShadow="false">
                        </asp:ModalPopupExtender>
                        <asp:HiddenField ID="hf_job" runat="server" />
                        <asp:HiddenField ID="hf_jobno" runat="server" />
                    </div>
                    <div class="div_Break"></div>
                    <div>

                        <asp:HiddenField ID="hf_book" runat="server" />
                        <asp:HiddenField ID="hf_bookno" runat="server" />
                        <asp:Label ID="hidjob" runat="server" />
                        <asp:Label ID="hidbook" runat="server" />
                    </div>

                    <%--</div>--%>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
