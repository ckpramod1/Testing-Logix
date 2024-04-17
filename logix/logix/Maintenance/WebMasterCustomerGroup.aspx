<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="WebMasterCustomerGroup.aspx.cs" Inherits="logix.Maintenance.WebMasterCustomerGroup" %>

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
    <link href="../Styles/Webmastercustomergroup.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txt_company.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_webgroupid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Maintenance/WebMasterCustomerGroup.aspx/Getcusname",
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
                        $("#<%=hf_webgroupid.ClientID %>").val(i.item.val);
                        $("#<%=txt_company.ClientID %>").change();
                    },

                    focus: function (event, i) {
                        $("#<%=txt_company.ClientID %>").val(i.item.value);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_company.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_company.ClientID %>").val($.trim(result));

                    },

                    minLength: 1
                });
            });

            $(document).ready(function () {

                $("#<%=txt_city.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $.ajax({
                            url: "../Maintenance/WebMasterCustomerGroup.aspx/Getponame",
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
                        $("#<%=hf_portid.ClientID %>").val(i.item.val);
                        $("#<%=txt_city.ClientID %>").change();

                    },

                    focus: function (event, i) {
                        $("#<%=txt_city.ClientID %>").val(i.item.value);
                    },

                    minLength: 1
                });
            });




          <%--  $(document).ready(function () {
                $('#<%=grd_Web .ClientID%>').gridviewScroll({
                    width: 540,
                    height: 120,
                    arrowsize: 30,
                    "scrollX": false,

                    varrowtopimg: "../images/arrowvt.png",
                    varrowbottomimg: "../images/arrowvb.png",
                    harrowleftimg: "../images/arrowhl.png",
                    harrowrightimg: "../images/arrowhr.png"
                });
            });--%>




        }
    </script>


    <script type="text/javascript">
        function TxtFocus() {

            var el = $("#<%=txt_Search.ClientID %>").get(0);
             var elemLen = el.value.length;
             el.selectionStart = elemLen;
             el.selectionEnd = elemLen;
             el.focus();
         }

         function GetDetail() {
             $.ajax({
                 type: "POST",
                 url: "../Maintenance/WebMasterCustomerGroup.aspx/GetBanName",
                 data: '{Prefix: "' + $("#<%=txt_Search.ClientID %>").val() + '" }',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: OnSuccess,
                 failure: function (response) {
                     //alertify.alert(response.d);
                 }
             });
         }


         function OnSuccess(response) {
             $("#<%=btn_search.ClientID %>").click();

         }

    </script>

    <style type="text/css">
        .Hide {
            display: none;
        }
    </style>
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

        logix_CPH_PanelLog {
            top: 155px !important;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }
    </style>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


    <!-- Breadcrumbs line End -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lblheader" runat="server" Text="Web Master Customer Group"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
                        <div class="crumbs">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <li><a href="#" title="">Maintenance</a> </li>
                                <li class="current"><a href="#" title="">Web Master Customer Group </a></li>
                            </ul>
                        </div>
                    </div>

                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4 boxmodal">
                        <div class="FormGroupContent4">

                            <asp:TextBox ID="txt_company" runat="server" CssClass="form-control" AutoPostBack="True" placeholder=" Company" ToolTip="Company"
                                OnTextChanged="txt_company_TextChanged" MaxLength="100" TabIndex="1"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4">

                        <asp:TextBox ID="txt_address" runat="server" CssClass="form-control" Style="resize: none;" placeholder=" Address" ToolTip="Address"
                            Height="40px" TextMode="MultiLine" MaxLength="250" TabIndex="2"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="ServiceTax1">
                            <asp:TextBox ID="txt_city" runat="server" CssClass="form-control" placeholder=" City" ToolTip="City"
                                OnTextChanged="txt_city_TextChanged" MaxLength="50" TabIndex="3"></asp:TextBox>
                        </div>
                        <div class="ServiceTax2">
                            <asp:TextBox ID="txt_zip" runat="server" CssClass="form-control" MaxLength="15" placeholder=" Zip" ToolTip="Zip" TabIndex="4"></asp:TextBox></div>
                        <div class="ServiceTax4">
                            <asp:TextBox ID="txt_contact" runat="server" CssClass="form-control" MaxLength="50" placeholder=" Contact Person" ToolTip="Contact Person" TabIndex="5"></asp:TextBox></div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="ServiceTax1">
                            <asp:TextBox ID="txt_phone" runat="server" CssClass="form-control" MaxLength="50" placeholder=" Phone #" ToolTip="Phone #" onkeyup="CheckTextLength(this,10);" onkeypress="return isNumberKey (event)" TabIndex="6"></asp:TextBox>
                        </div>
                        <div class="ServiceTax2">
                            <asp:TextBox ID="txt_fax" runat="server" CssClass="form-control" MaxLength="50" placeholder=" Fax #" ToolTip="Fax #" TabIndex="7" onkeyup="CheckTextLength(this,10);" onkeypress="return isNumberKey (event)"></asp:TextBox></div>
                        <div class="ServiceTax3"></div>
                        <div class="ServiceTax4">
                            <asp:TextBox ID="txt_email" runat="server" CssClass="form-control" MaxLength="50" placeholder=" E-Mail" ToolTip="E-Mail" onblur="javascript:ValidateEmail(this)" TabIndex="8"></asp:TextBox></div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="right_btn">
                            <div class="btn ico-save" id="btn_save1" runat="server">
                                <asp:Button ID="btn_save" runat="server" ToolTip="Save" OnClick="btn_save_Click" TabIndex="9" /></div>
                            <div class="btn ico-view" style="display: none">
                                <asp:Button ID="btn_view" runat="server" ToolTip="View" TabIndex="10" /></div>
                            <div class="btn ico-cancel" id="btn_back1" runat="server">
                                <asp:Button ID="btn_back" runat="server" ToolTip="Cancel" OnClick="btn_back_Click" TabIndex="11" />
                                <asp:Button ID="btn_search" runat="server" Text="" CssClass="btn" Style="display: none;" OnClick="btn_search_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">

                    <div class="FormGroupContent4">
                        <asp:TextBox ID="txt_Search" runat="server" CssClass="form-control" MaxLength="100" onkeyup="GetDetail();" placeholder=" Search" ToolTip="Search" TabIndex="12"></asp:TextBox>
                    </div>
                    <div class="FormGroupContent4">
                        <asp:Panel ID="pnl_grd" runat="server" CssClass="panel_07 MB0" Height="150px" ScrollBars="Vertical">
                            <asp:GridView ID="grd_Web" runat="server" AutoGenerateColumns="False" Width="100%"
                                HorizontalAlign="Left" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true"
                                DataKeyNames="customerid" OnSelectedIndexChanged="grd_Web_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="customerid" HeaderText="customerid" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide"><%--  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"--%> 
                
  
                                    </asp:BoundField>
                                    <asp:BoundField DataField="customername" HeaderText="Customer">
                                        <HeaderStyle HorizontalAlign="Justify" Width="600px" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="portname" HeaderText="City">
                                        <HeaderStyle HorizontalAlign="Justify" Width="300px" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Select">
                                        <HeaderStyle HorizontalAlign="Justify" Width="110px" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="grdblselect" runat="server" AutoPostBack="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                                <%--<PagerSettings Mode="NumericFirstLast" />
            
             <AlternatingRowStyle CssClass="GrdRowStyle" /> 
                <HeaderStyle CssClass="GridviewScrollHeader" /> 
            <RowStyle CssClass="GridviewScrollItem" /> --%>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                        </div>
                    <div class="FormGroupContent4">
                        <div class="right_btn">
                            <div class="btn ico-update">
                                <asp:Button ID="btn_update" runat="server" ToolTip="Update" OnClick="btn_update_Click" TabIndex="13" /></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div>
        <asp:HiddenField ID="hf_webgroupid" runat="server" />
        <asp:HiddenField ID="hf_cityid" runat="server" />
        <asp:HiddenField ID="hf_portid" runat="server" />
        <asp:HiddenField ID="hf_customerid" runat="server" />
    </div>
    <div id="PanelLog1" runat="server">
        <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
            <div class="divRoated">
                <div class="LogHeadLbl">
                    <div class="LogHeadJob">
                        <label id="lbl" runat="server">Customer Name :</label>

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


        </asp:Panel>
    </div>
    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image3" BehaviorID="Test1">
    </asp:ModalPopupExtender>
</asp:Content>

