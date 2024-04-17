<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="EventDetails.aspx.cs" Inherits="logix.CHA.EventDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

    <%-- <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>


    <!-- App -->

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









    <link href="../Styles/Eventdetails.css" rel="stylesheet" />
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
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }
        /*.modalPopupss { 
            background-color:#FFFFFF; 
            /*border-width:1px;
            border-style:solid; 
            border-color:#CCCCCC;             
            width: 882px;
            Height:485px; 
            margin-left:0%;
            margin-top:-1.5%;
          /*padding:1px;            
            display:none;
        }
     .Gridpnl   
         {            
            width: 878px;
            Height:472px;      
         }*/
        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        .hide {
            display: none;
        }

        #Test_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        .modalPopupss {
            background-color: #FFFFFF;
            /* border-width: 1px; */
            border-style: solid;
            border-color: #CCCCCC;
            /* width: 1062px; */
            width: 98.5%;
            Height: 525px;
            margin-left: 1%;
            margin-top: -0.9%;
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

        logix_CPH_PanelLog {
            top: 155px !important;
        }

        .JobInput20 {
            width: 13.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FormGroupContent4 span {
            color: #000080;
            font-size: 11px;
        }

        .FormGroupContent4 label {
            color: #000080;
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }
    </style>

    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txt_event.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_event.ClientID %>").val(0);
                        $.ajax({
                            url: "../CHA/EventDetails.aspx/Get_event",
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
                        $("#<%=txt_event.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_event.ClientID %>").change();
                        $("#<%=hid_event.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_event.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_event.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_event.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_event.ClientID %>").val(i.item.val);

                        }

                    },
                    close: function (event, i) {
                        var result = $("#<%=txt_event.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_event.ClientID %>").val($.trim(result));

                    },
                    minLength: 1
                });
            });

        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Custom Home Agent</a> </li>
            <li><a href="#" title="">Shipment Details</a> </li>
            <li class="current"><a href="#" title="">Event Details</a> </li>
        </ul>
    </div>
    <!-- Breadcrumbs line End -->
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4><i class="icon-umbrella"></i>
                            <asp:Label ID="Lbl_head" runat="server" Text="Event Details"></asp:Label></h4>
                    </div>

                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4">

                        <div class="JobInput20">
                            <asp:LinkButton ID="lnk_job" runat="server" Text="Job #" ForeColor="Red" Style="text-decoration: none;" OnClick="lnk_job_Click"></asp:LinkButton>
                            <asp:TextBox ID="txt_job" runat="server" CssClass="form-control" placeholder="" ToolTip="Job #" AutoPostBack="true" OnTextChanged="txt_job_TextChanged"></asp:TextBox>
                        </div>
                        <div class="JobType1">
                            <asp:Label ID="Label3" runat="server" Text="Job Type"> </asp:Label>
                            <asp:TextBox ID="txt_jobtype" runat="server" ToolTip="Job Type" Enabled="false" placeholder="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="JobType1">
                            <asp:Label ID="Label4" runat="server" Text="Doc #"> </asp:Label>
                            <asp:TextBox ID="txt_doc" runat="server" ToolTip="Doc #" placeholder="" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="JobType2">
                            <asp:Label ID="Label5" runat="server" Text="MDoc #"> </asp:Label>
                            <asp:TextBox ID="txt_mdoc" runat="server" ToolTip="MDoc #" placeholder="" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:Label ID="Label6" runat="server" Text="Customer"> </asp:Label>
                            <asp:TextBox ID="txt_customer" runat="server" ToolTip="Customer" placeholder="" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="Consignee5">
                            <asp:Label ID="Label7" runat="server" Text="Principal"> </asp:Label>
                            <asp:TextBox ID="txt_principal" runat="server" ToolTip="Principal" placeholder="" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:Label ID="Label8" runat="server" Text="Shipper"> </asp:Label>
                            <asp:TextBox ID="txt_shipper" runat="server" ToolTip="Shipper" placeholder="" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="Consignee5">
                            <asp:Label ID="Label24" runat="server" Text="Notify Party"> </asp:Label>

                            <asp:TextBox ID="txt_notify" runat="server" ToolTip="Notify Party" placeholder="" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:Label ID="Label9" runat="server" Text="Consignee"> </asp:Label>
                            <asp:TextBox ID="txt_consignee" runat="server" ToolTip="Consignee" placeholder="" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="Consignee5">
                            <asp:Label ID="Label10" runat="server" Text="PIC"> </asp:Label>
                            <asp:TextBox ID="txt_pic" runat="server" ToolTip="PIC" placeholder="" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:Label ID="Label11" runat="server" Text="Mode"> </asp:Label>
                            <asp:TextBox ID="txt_mode" runat="server" ToolTip="Mode" placeholder="" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="Consignee5">
                            <asp:Label ID="Label12" runat="server" Text="Documents"> </asp:Label>
                            <asp:TextBox ID="txt_documents" runat="server" ToolTip="Documents" placeholder="" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:Label ID="Label13" runat="server" Text="Cargo"> </asp:Label>
                            <asp:TextBox ID="txt_cargo" runat="server" ToolTip="Cargo" placeholder="" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="Consignee5">
                            <asp:Label ID="Label14" runat="server" Text="Volume"> </asp:Label>
                            <asp:TextBox ID="txt_volume" runat="server" ToolTip="Volume" placeholder="" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="POL3">
                            <asp:Label ID="Label15" runat="server" Text="PoL"> </asp:Label>
                            <asp:TextBox ID="txt_pol" runat="server" ToolTip="PoL" placeholder="" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="POL4">
                            <asp:Label ID="Label16" runat="server" Text="PoD"> </asp:Label>
                            <asp:TextBox ID="txt_pod" runat="server" ToolTip="PoD" placeholder="" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="POL5">
                            <asp:Label ID="Label17" runat="server" Text="FD"> </asp:Label>
                            <asp:TextBox ID="txt_fd" runat="server" ToolTip="FD" placeholder="" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="POL6">
                            <asp:Label ID="Label18" runat="server" Text="Packages"> </asp:Label>
                            <asp:TextBox ID="txt_packages" runat="server" ToolTip="Packages" placeholder="" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="POL7">
                            <asp:Label ID="Label19" runat="server" Text="Net Weight"> </asp:Label>
                            <asp:TextBox ID="txt_netWeight" runat="server" ToolTip="Net Weight" placeholder="" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="POL8">
                            <asp:Label ID="Label20" runat="server" Text="Gross Weight"> </asp:Label>
                            <asp:TextBox ID="txt_Grossweight" runat="server" ToolTip="Gross Weight" placeholder="" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="EventInput">
                            <asp:Label ID="Label21" runat="server" Text="Event Details"> </asp:Label>
                            <asp:TextBox ID="txt_event" runat="server" ToolTip="Event Details" placeholder="" AutoPostBack="true" OnTextChanged="txt_event_TextChanged" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="DateCal">
                            <asp:Label ID="Label22" runat="server" Text="Event Date"> </asp:Label>
                            <asp:TextBox ID="txt_eventDate" runat="server" ToolTip="Event Date" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <asp:Label ID="Label23" runat="server" Text="Remarks"> </asp:Label>
                        <asp:TextBox ID="txt_remarks" runat="server" ToolTip="Remarks" placeholder="" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="bordertopNew"></div>
                    <div class="FormGroupContent4">
                        <asp:Panel ID="panelgrd" runat="server" ScrollBars="Vertical" CssClass="panel_10">
                            <asp:GridView ID="grdevent" runat="server" CssClass="Grid FixedHeader"  Width="100%" AutoGenerateColumns="false"
                                OnSelectedIndexChanged="grdevent_SelectedIndexChanged" ShowHeaderWhenEmpty="true"
                                OnRowDataBound="grdevent_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="eventname" HeaderText="Event Name" />
                                    <asp:BoundField DataField="eventdate" HeaderText="Event Date" />
                                    <asp:BoundField DataField="remarks" HeaderText="Remarks" />
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                    <div class="bordertopNew"></div>
                    <div class="FormGroupContent">
                        <div class="right_btn MB05">
                            <div class="btn ico-save" id="btn_save1" runat="server">
                                <asp:Button ID="btn_save" runat="server" ToolTip="Save" OnClick="btn_save_Click" />
                            </div>
                            <div class="btn ico-view">
                                <asp:Button ID="btn_view" runat="server" ToolTip="View" OnClick="btn_view_Click" />
                            </div>
                            <div class="btn ico-cancel" id="btn_cancel1" runat="server">

                                <asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click" />
                            </div>
                        </div>
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
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
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


    <asp:Panel ID="pln_popup" runat="server" CssClass="modalPopup" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>
            <%-- PageSize="26" AllowPaging="false" OnPageIndexChanging="Grd_JOb_PageIndexChanging"--%>
            <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl" ScrollBars="Vertical">
                <asp:GridView ID="Grd_JOb" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="False" Width="100%"
                    ForeColor="Black" OnRowDataBound="Grd_JOb_RowDataBound" AllowPaging="false" PageSize="20" OnPageIndexChanging="Grd_JOb_PageIndexChanging"
                    BackColor="White" OnSelectedIndexChanged="Grd_JOb_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Job #" HeaderText="Job #" />
                        <asp:BoundField DataField="Job Type" HeaderText="Job Type" />
                        <asp:BoundField DataField="Doc #" HeaderText="Doc #" />
                        <asp:BoundField DataField="Doc Date" HeaderText="Doc Date" />
                        <asp:BoundField DataField="Mode" HeaderText="Mode" />
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>
            </asp:Panel>
        </div>


    </asp:Panel>

    <asp:Label ID="Label2" runat="server"></asp:Label>
    <asp:ModalPopupExtender ID="popup_Grd" runat="server" PopupControlID="pln_popup"
        DropShadow="false" TargetControlID="Label2" CancelControlID="close" BehaviorID="Test">
    </asp:ModalPopupExtender>

    <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl1" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>CH EventDetails With EventWise</b></div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btn_yes" runat="server" Text="Yes" CssClass="Button" OnClick="btn_yes_Click" />
            <asp:Button ID="btn_no" runat="server" Text="No" CssClass="Button" OnClick="btn_no_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>
    <div class="div_Break"></div>
    <div class="div_Break"></div>
    <asp:ModalPopupExtender ID="PopUpService" runat="server" BackgroundCssClass=""
        PopupControlID="Panel_Service" TargetControlID="Label1">
    </asp:ModalPopupExtender>
    <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>
    <asp:CalendarExtender ID="CalendarExtender7" runat="server" DaysModeTitleFormat="dd/MM/yyyy"
        Format="dd/MM/yyyy" TargetControlID="txt_eventDate" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>


    <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="Image1" BehaviorID="Test1">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="hid_date" runat="server" />
    <asp:HiddenField ID="hid_event" runat="server" />
</asp:Content>
