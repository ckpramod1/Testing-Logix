<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="EventTracking.aspx.cs" EnableEventValidation="false" Inherits="logix.CRM.EventTracking" %>

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
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css">
    <link href="../Theme/assets/css/systemcrm.css" rel="stylesheet" type="text/css">
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

    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>


    <link href="../Styles/FEEvent Tracking.css" type="text/css" rel="Stylesheet" />
    <!-- <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script> -->
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <%--<link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />--%>
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />

    <%--<script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>--%>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />

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

      

      
        .formLeft{
        width: 79.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
         }
        .formright{
            width:20%;
            float:left;
            margin:0px 0px 0px 0px;
        }
        .Stuffed {
    width: 8.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .Liner {
    width: 28%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .BLNOInput1 {
    width: 31.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.Agent {
    float: left;
    width: 30%;
    margin: 0px 0.5% 0px 0px;
}       .FormGroupContent4 textarea {
    height: 23px!important;
}
        .MBLInputN4 {
    width: 22%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .POLInput5 {
    width: 21.5%;
    float: left;
    margin: 0px 0.5% 0px 0%;
}

        .MBLInput4 {
    width: 22%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .Job_Remarks {
    float: left;
    width: 100%;
    margin: 0px 0.5% 0px 0px;
    /* -webkit-text-stroke-width: thin; */
}
  
        .EMDateInputN1 {
    width: 8.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .EMDateInput {
    width: 8.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        textarea#logix_CPH_txt_jobremarks {
    height: 39px !important;
}
        div#logix_CPH_btn_evntclear1 {
    margin: 0 !important;
}
         
        table#logix_CPH_grd_evnttrack td:nth-child(14) {
    max-width: 150px;
    overflow: hidden;
        text-overflow: ellipsis;
}
.Grid th {
    border-right: 1px solid #fff !important;
}table#logix_CPH_grd_evnttrack, table#logix_CPH_grd_pndngevents {
    border: none;
}
 select#logix_CPH_lstbx_cntnrnocl {
    border: none !important;
    border-bottom: 1px solid var(--inputborder) !important;
}
 .BLNOInput {
    width: 10%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
 .VesselInput4 {
    width: 25%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
 .ContNo option {
        padding-top: 5px;
    color: var(--labelblack);
    font-size: 14px;
}
 div#UpdatePanel1 {
    height: 89vh;
    overflow-x: hidden;
    overflow-y: auto;
}
    </style>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txt_blno.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_blno.ClientID %>").val(0);
                        $.ajax({
                            url: "../CRM/EventTracking.aspx/Getblno",
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
                        $("#<%=hf_blno.ClientID %>").val(i.item.val);
                        $("#<%=hf_blno.ClientID %>").change();
                    },
                    change: function (e, i) {
                        $("#<%=hf_blno.ClientID %>").val(i.item.val);
                    },
                    focus: function (e, i) {
                        $("#<%=hf_blno.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        $("#<%=hf_blno.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

            <%--$(document).ready(function () {
                $('#<%=grd_evnttrack.ClientID%>').gridviewScroll({
                    width: 1239,
                    height: 445,
                    arrowsize: 30,

                    varrowtopimg: "../images/arrowvt.png",
                    varrowbottomimg: "../images/arrowvb.png",
                    harrowleftimg: "../images/arrowhl.png",
                    harrowrightimg: "../images/arrowhr.png"
                });
            });--%>
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

        .GridHeader1 {
            background-color: navy;
            color: White;
            font-family: sans-serif;
            font-size: 11px;
            margin-left: -0.1%;
            margin-top: -1.7%;
            position: absolute;
            width: 1026px;
        }

        .Hide {
            display: none;
        }

        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        .crumbslbl {
            display: none;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            /*color: #000080;*/
            font-size: 14px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .JobNoInput1 {
            width: 9.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MBLInputN5 {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .MBLInputN4 {
            width: 55.2%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .ContNo {
            width: 98.5%;
            float: left;
            margin: 0px 0px 0px 1.5%;
        }

        a#logix_CPH_lbtn_jobno {
            font-size: 11px;
        }
        .lbl_NextDateDrop {
    float: left;
    width: 32%;
    margin: 5px 0px 0px 0px;
}
        .drop_NextFollowUpDate {
    float: left;
    width: 41%;
    margin: 0px 0px 0px 0px;
}
    /*New design - Buttons*/
   
div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
.panel_05 {
    height: 306px !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


    

    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_hdr" runat="server" Text="Event Tracking"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
    <div class="crumbs" id="crumbslbl" runat="server">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Customer Support</a> </li>
            <li><a href="#" title="">Ocean Exports</a> </li>
            <li class="current"><a href="#" title="">Event Tracking</a> </li>
        </ul>
    </div>
                </div>
                <div class="widget-content">
                        
                    <div class="FixedButtons">
                        <div class="right_btn">
                         <div class="btn ico-excel" id="btn_exprtexcel1" runat="server">
                                <asp:Button ID="btn_exprtexcel" Text="Export To Excel" runat="server" ToolTip="Export To Excel" OnClick="btn_exprtexcel_Click" />
                            </div>
                            <div class="btn ico-cancel" id="btn_clear1" runat="server">
                                <asp:Button ID="btn_clear" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_clear_Click" />
                            </div>
                            </div>
                    </div>
                   <div class="formLeft" >
                        <div class="FormGroupContent4 boxmodal">
                        <div class="JobNoInput1">
                            <span>Job #</span>
                            <asp:TextBox ID="txt_jobno" runat="server" OnTextChanged="txt_jobno_TextChanged" AutoPostBack="True" placeholder="" TabIndex="1" ToolTip="Job Number" CssClass="form-control" onkeypress="return isNumberKey(event,'Job');"></asp:TextBox>
                        </div>
                            <div class="boxmodalLink_box">
                            <asp:LinkButton ID="lbtn_jobno" runat="server" OnClick="lbtn_jobno_Click" CssClass="anc ico-find-sm"></asp:LinkButton>
                            </div>
                        <div class="VesselInput4">
                            <asp:Label ID="Label1" runat="server" Text="Vessel"> </asp:Label>
                            <asp:TextBox ID="txt_vessel" runat="server" placeholder="" ToolTip="Vessel" TabIndex="2" CssClass="form-control"></asp:TextBox>
                        </div>
                             <div class="MBLInput4">
                            <asp:Label ID="Label10" runat="server" Text="MBL #"> </asp:Label>
                            <asp:TextBox ID="txt_MBLstatus" runat="server" placeholder="" ToolTip="MBL" TabIndex="3" CssClass="form-control"></asp:TextBox>
                        </div>
                                <div class="Agent">
                            <asp:Label ID="Label11" runat="server" Text="Agent"> </asp:Label>
                            <asp:TextBox ID="txt_agent" runat="server" placeholder="" ToolTip="Agent" TabIndex="4" CssClass="form-control"></asp:TextBox>
                        </div>
                       <div class="EMDateInput">
                            <asp:Label ID="Label2" runat="server" Text="EM / Date"> </asp:Label>
                            <asp:TextBox ID="txt_emnodate" runat="server" placeholder="" ToolTip="EM Number/Date" CssClass="form-control" TabIndex="5"></asp:TextBox>
                        </div>
                    </div>

                       <div class="FormGroupContent4">
                            
                        <div class="BLNOInput hide">
                            <asp:Label ID="Label3" runat="server" Text="HBL #"> </asp:Label>
                            <asp:TextBox ID="txt_blno" runat="server" AutoPostBack="True" OnTextChanged="txt_blno_TextChanged" placeholder="" ToolTip="BL Number" CssClass="form-control" TabIndex="6"></asp:TextBox>
                        </div>
                        <div class="POLInput5">
                            <asp:Label ID="Label4" runat="server" Text="PoL"> </asp:Label>
                            <asp:TextBox ID="txt_pol" runat="server" placeholder="" ToolTip="PoL" CssClass="form-control" TabIndex="7"></asp:TextBox>
                        </div>
                        <div class="EMDateInput">
                            <asp:Label ID="Label6" runat="server" Text="ETD"> </asp:Label>
                            <asp:TextBox ID="txt_etdsailed" CssClass="form-control" runat="server" placeholder="" ToolTip="ETD" TabIndex="8"></asp:TextBox>
                        </div>
                        <div class="POLInput5">
                            <asp:Label ID="Label5" runat="server" Text="PoD"> </asp:Label>
                            <asp:TextBox ID="txt_pod" runat="server" placeholder="" ToolTip="PoD" CssClass="form-control" TabIndex="9"></asp:TextBox>
                        </div>
                        <div class="EMDateInputN1">
                            <asp:Label ID="Label7" runat="server" Text="ETA"> </asp:Label>
                            <asp:TextBox ID="txt_etaarrvd" runat="server" placeholder="" ToolTip="ETA" CssClass="form-control" TabIndex="10"></asp:TextBox>
                        </div>
                            <div class="Liner">
                            <asp:Label ID="Label8" runat="server" Text="Liner"> </asp:Label>
                            <asp:TextBox ID="txt_liner" runat="server" placeholder="" ToolTip="Liner" CssClass="form-control" TabIndex="11"></asp:TextBox>
                        </div>
                               <div class="Stuffed">
                            <asp:Label ID="Label9" runat="server" Text="Stuffed On"> </asp:Label>
                            <asp:TextBox ID="txt_stuffon" runat="server" placeholder="" ToolTip="Stuffed On" CssClass="form-control" TabIndex="12"></asp:TextBox>
                        </div>

                       </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="Job_Remarks">
                            <asp:Label ID="Label12" runat="server" Text="Job Remarks"> </asp:Label>
                            <asp:TextBox ID="txt_jobremarks" runat="server" Rows="2" TextMode="MultiLine" Width="100%" placeholder="" ToolTip="Job Remarks" CssClass="form-control" TabIndex="13"></asp:TextBox>
                        </div>
                       
                    </div>
                   </div>
                  <div class="formright">
                    <div class="FormGroupContent4 boxmodal">
                        <div class="ContNo TextArea">
                            <asp:Label ID="lbl_cntnrnocl" runat="server" Text=" Container  # / Seal"></asp:Label>
                            <asp:ListBox ID="lstbx_cntnrnocl" runat="server" Height="147px" Width="100%" CssClass="form-control" ToolTip="Container Number / Seal"></asp:ListBox>
                        </div>
                    </div>

                  </div>

                    <div class="FormGroupContent4 boxmodal">
                        <div class="panel_08 MB0">

                            <asp:Panel ID="pnl_grdevnttrack" runat="server">

                                <asp:GridView ID="grd_evnttrack" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="Grid FixedHeader"
                                    OnSelectedIndexChanged="grd_evnttrack_SelectedIndexChanged" ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found"
                                    OnRowCommand="grd_evnttrack_RowCommand">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server"
                                                    ImageUrl="~/images/login_but.gif" Width="15px" CommandName="Select" Height="15px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="shiprefno" HeaderText="Booking #" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="blno" HeaderText="BL Number" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="sbno" HeaderText="Shiping Bill #" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="customername" HeaderText="Customer" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="pod" HeaderText="PoD" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="nextfollowup" HeaderText="Next Follow-up Date" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="remarks" HeaderText="Remarks" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="hblstatus" HeaderText="HBL Status" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="vslvoy" HeaderText="M Vsl/Voy" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="metd" HeaderText="M.V ETD" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="meta" HeaderText="M.V ETA" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="shipper" HeaderText="Shipper" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="consignee" HeaderText="Consignee" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="pkgs" HeaderText="Packages" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="grweight" HeaderText="Gross Wt" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="Tues" HeaderText="Volume / Teus" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="stuffsenton" HeaderText="Stuff Sent On" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="sailingsenton" HeaderText="Sailing Confm Sent On" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="prealertsenton" HeaderText="PreAlert Sent On" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="prealertack" HeaderText="PreAlert Ack On" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="invplrecon" HeaderText="Inv / PL Recd On" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="tssenton" HeaderText="T/S Sent On" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="hblack" HeaderText="HBL Ack On" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="mblack" HeaderText="MBL Ack On" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="docssenton" HeaderText="Docs Sent On" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="tsconfbyagent" HeaderText="T/S Confirmed By Agent" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="dnsenton" HeaderText="Debit Note Sent On" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="dnack" HeaderText="Debit Note  Ack On" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="drsenton" HeaderText="DO Confir Req On" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="pfdorcd" HeaderText=" DO Confir  Recd On" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="dssenton" HeaderText="DO Confir Sent On" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" />
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>

                    </div>


                    <div class="FormGroupContent4 boxmodal">
                        <div class="NextDateDrop">
                           <div class="drop_NextFollowUpDate">
                            <asp:Label ID="lbl_nxtflwupdate" runat="server" Text="Next FollowUp Date"></asp:Label>
                                <asp:DropDownList ID="ddl_nxtflwupdate" runat="server" AutoPostBack="True" CssClass="chzn-select" data-placeholder="NextFollowUpDate" ToolTip="NextFollowUpDate"
                                OnSelectedIndexChanged="ddl_nxtflwupdate_SelectedIndexChanged">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                           </div>
                        </div>

                       
                    </div>

                  
                    <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4">
                        <div class="PendingDetails">
                            <asp:Label ID="lbl_pndngdtls" runat="server" Text="Pending Details"></asp:Label>
                        </div>
                    </div>
                        <div class="FormGroupContent4">
                            <asp:Panel ID="Panel1" runat="server" CssClass="panel_05 MB0"  Width="100%" ScrollBars="Both">
                                <asp:GridView ID="grd_pndngevents" runat="server" AutoGenerateColumns="False"
                                    Width="100%" OnSelectedIndexChanged="grd_pndngevents_SelectedIndexChanged" ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found" CssClass="Grid FixedHeader" OnPreRender="grd_pndngevents_PreRender">
                                    <Columns>
                                        <asp:BoundField DataField="jobno" HeaderText="Job No">
                                            <HeaderStyle Width="150px" />
                                            <ItemStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="shiprefno" HeaderText="Booking No">
                                            <HeaderStyle Width="150px" />
                                            <ItemStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="blno" HeaderText="BL Number">
                                            <HeaderStyle Width="150px" />
                                            <ItemStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="remarks" HeaderText="Remarks">
                                            <HeaderStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FollowedBy" HeaderText="FollowedBy">
                                            <HeaderStyle />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                        </div>
                    <div class="right_btn">
                        <div class="btn ico-clear custom-mt-5" id="btn_evntclear1" runat="server">
                            <asp:Button ID="btn_evntclear" runat="server" Text="Clear" ToolTip="Clear" OnClick="btn_evntclear_Click" />

                        </div>

                    </div>


                </div>
            </div>
        </div>
    </div>

    <%-- PopUP --%>
    <asp:Panel ID="pnl_job" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="1px" Style="display: none;">
        <div class="divRoated">
        <div class="DivSecPanel">
            <asp:Image ID="Close_voucher" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
        </div>
        <asp:Panel ID="Panel2" runat="server"  CssClass="Gridpnl">
            <asp:GridView ID="grd_job" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader"  Width="100%" ForeColor="Black" OnRowDataBound="grd_job_RowDataBound"
                EmptyDataText="No Record Found" PageSize="20" AllowPaging="false" OnPageIndexChanging="grd_job_PageIndexChanging" BackColor="White" OnSelectedIndexChanged="grd_job_SelectedIndexChanged1" >
                <Columns>

                    <asp:TemplateField HeaderText="Job">
                        <ItemTemplate>
                            <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="60px"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="JobType">
                        <ItemTemplate>
                            <div style="overflow: hidden; text-overflow: ellipsis; width: 50px">
                                <asp:Label ID="JobType" runat="server" Text='<%# Bind("JobType") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle Wrap="true" Width="53px" HorizontalAlign="Center" />
                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Vessel">
                        <ItemTemplate>
                            <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                <asp:Label ID="Vessel" runat="server" Text='<%# Bind("vslvoy") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="MBL">
                        <ItemTemplate>
                            <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                <asp:Label ID="MBL" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle Wrap="true" Width="87px" HorizontalAlign="Center" />
                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ETA">
                        <ItemTemplate>
                            <div style="overflow: hidden; text-overflow: ellipsis; width: 75px">
                                <asp:Label ID="ETA" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="POL">
                        <ItemTemplate>
                            <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                <asp:Label ID="POL" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle Wrap="true" Width="77px" HorizontalAlign="Center" />
                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="POD">
                        <ItemTemplate>
                            <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                <asp:Label ID="POD" runat="server" Text='<%# Bind("pod") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle Wrap="true" Width="88px" HorizontalAlign="Center" />
                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="FD">
                        <ItemTemplate>
                            <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                <asp:Label ID="FD" runat="server" Text='<%# Bind("SD") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle Wrap="true" Width="108px" HorizontalAlign="Center" />
                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="MLO">
                        <ItemTemplate>
                            <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                <asp:Label ID="MLO" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle Wrap="true" Width="180px" HorizontalAlign="Center" />
                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="180px"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Sailingsenton">
                        <ItemTemplate>
                            <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                <asp:Label ID="Sailingsenton" runat="server" Text='<%# Bind("Sailingsenton") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle Wrap="true" Width="108px" HorizontalAlign="Center" />
                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>

                    <%--<asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="Arrow" CommandName="select"
                                        Font-Underline="false">⇛</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>--%>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <PagerStyle CssClass="GridviewScrollPager" />


            </asp:GridView>
        </asp:Panel>
        <div class="div_Break"></div>
        </div>
    </asp:Panel>


    <div class="div_Break"></div>

    <div>
        <asp:ModalPopupExtender ID="Mdl_grdjob" runat="server" CancelControlID="Close_voucher" PopupControlID="pnl_job"
            DropShadow="false" TargetControlID="hfmdljob">
        </asp:ModalPopupExtender>
        <asp:HiddenField ID="hf_mdljob" runat="server" />
    </div>

    <div>
        <asp:HiddenField ID="hf_grdjob_index" runat="server" />
        <asp:HiddenField ID="hf_grdevnttrack_index" runat="server" />
        <asp:HiddenField ID="hf_grdpndngevents_index" runat="server" />
        <asp:HiddenField ID="hf_blno" runat="server" />
        <asp:Label ID="hfmdljob" runat="server" />
    </div>
</asp:Content>
