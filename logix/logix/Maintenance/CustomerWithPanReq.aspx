<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="true" CodeBehind="CustomerWithPanReq.aspx.cs" Inherits="logix.Maintenance.CustomerWithPanReq" %>

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
    <script type="text/javascript" src="../js/helper.js"></script>

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










    <link href="../Styles/CustomerWithPanReq.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {

                $(document).ready(function () {
                    $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
                });
                $("#<%=txtcustomer.ClientID %>").autocomplete({

                     source: function (request, response) {
                         $("#<%=hf_cusid.ClientID %>").val(0);
                         $.ajax({
                             url: "../Maintenance/CustomerWithPanReq.aspx/Getcusname",
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
                     <%-- select: function (event, i) {
                        $("#<%=hf_cusid.ClientID %>").val(i.item.val);
                        $("#<%=txtcustomer.ClientID %>").change();
                    },
                    change: function (event, i) {

                        $("#<%=hf_cusid.ClientID %>").val(i.item.val);
                        $("#<%=txtcustomer.ClientID %>").val(i.item.value);
                    },
                    focus: function (event, i) {
                        $("#<%=txtcustomer.ClientID %>").val(i.item.value);
                    },--%>

                     select: function (event, i) {
                         $("#<%=txtcustomer.ClientID %>").val(i.item.label);
                         $("#<%=txtcustomer.ClientID %>").change();


                     },
                     change: function (event, i) {
                         if (i.item) {
                             $("#<%=txtcustomer.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                             $("#<%=hf_cusid.ClientID %>").val(i.item.val);

                         }
                     },

                     focus: function (event, i) {
                         $("#<%=txtcustomer.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));

                         $("#<%=hf_cusid.ClientID %>").val(i.item.val);


                     },

                     close: function (event, i) {
                         var result = $("#<%=txtcustomer.ClientID %>").val().toString().split(' ,')[0];
                         $("#<%=txtcustomer.ClientID %>").val($.trim(result));
                     },

                     minLength: 1
                 });
             });
         }

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
                font-size: 12px;
            }



        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LogHeadJobInput label {
            font-size: 12px;
        }


        .LogHeadJobInput {
            width: auto;
            white-space: nowrap;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 12px;
                margin: 4px 0px 0px 0px;
            }




            .LogHeadJobInput label {
                font-size: 12px;
                font-family: sans-serif;
                color: #4e4e4c;
            }

 

        .widget.box{
    position: relative;
    top: -8px;
}
        .widget.box .widget-content {
    top: 0px !important;
    padding-top:65px !important;
}
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    
    <!-- Breadcrumbs line End -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div>
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:label id="lbl_head" runat="server" text="PAN Card Details"></asp:label>
                        </h4>
                        <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Maintenance</a> </li>
            <li class="current"><a href="#" title="">PAN Card Details </a></li>
        </ul>
    </div>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:linkbutton id="logdetails" runat="server" tooltip="Log" style="text-decoration: none" onclick="logdetails_Click"></asp:linkbutton>
                    </div>
                        </div>

                                       <div class="FixedButtons" >
                        <div class="right_btn ">
    <div class="btn ico-update">
        <asp:button id="btnupdate" runat="server" Text="Update"  tabindex="3" tooltip="Update" onclick="btnupdate_Click" />
    </div>
    <div class="btn ico-cancel" id="btncancel1" runat="server">
        <asp:button id="btncancel" runat="server" Text="Cancel" tabindex="4" tooltip="Cancel" onclick="btncancel_Click" />
    </div>

</div>
                   </div>



                </div>
                <div class="widget-content">
                   
                    <div class="FormGroupContent4 boxmodal">
                        <div class="FormGroupContent4">

                            <asp:textbox id="txtcustomer" runat="server" tabindex="1" CssClass="form-control" placeholder="Customer Name" tooltip="Customer Name" autopostback="true" ontextchanged="txtcustomer_TextChanged"></asp:textbox>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="Drop1">
                            <asp:dropdownlist id="cmbpanreq" runat="server" CssClass="chzn-select" tabindex="2" width="100%" tooltip="PAN Required">    
            <asp:ListItem Text="" Value="0"></asp:ListItem>          
              </asp:dropdownlist>
                        </div>
                        <script src="../Scripts/Validation.js" type="text/javascript"></script>
                        <link href="../Styles/chosen.css" rel="stylesheet" />
                        <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
                        <script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
                        <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
                       

                    </div>

                </div>
            </div>
        </div>
    </div>

    <asp:hiddenfield id="hf_cusid" runat="server" />

    <div id="PanelLog1" runat="server">
        <asp:panel id="PanelLog" runat="server" cssclass="modalPopup" borderstyle="Solid" borderwidth="2px" style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label id="lbl" runat="server">Customer Name:</label>

                                </div>
                                <div class="LogHeadJobInput">

                                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                                </div>

                            </div>
                            <div class="DivSecPanel">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
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


                    </asp:panel>
    </div>
    <asp:label id="Label4" runat="server"></asp:label>

    <asp:modalpopupextender id="ModalPopupExtenderlog" runat="server" popupcontrolid="PanelLog"
        dropshadow="false" targetcontrolid="Label4" cancelcontrolid="Image3" behaviorid="Test1">
    </asp:modalpopupextender>
</asp:Content>
