<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Mastercfs.aspx.cs" EnableEventValidation="false" Inherits="logix.Maintenance.Mastercfs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
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
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css">
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/lodash.compat.min.js"></script>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/cookie/jquery.cookie.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- Page specific plugins -->
    <!-- Charts -->
    <!-- Forms -->
    <!-- AutoComplete -->
    <script type="text/javascript" src="../Theme/Content/plugins/inputlimiter/jquery.inputlimiter.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/uniform/jquery.uniform.min.js"></script>
    <!-- Styled radio and checkboxes -->
    <!-- Styled select boxes -->

    <!-- Globalize -->

    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
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

    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />


    <link href="../Styles/BuyingRates.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Calendar.js" type="text/javascript"></script>
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js"></script>

     <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />

    <script type="text/javascript">
        function pageLoad(sender, args) {

            $(document).ready(function () {
                $("#<%=txt_Cfs.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdnCarrier.ClientID %>").val(0);
                        $.ajax({
                            url: "Mastercfs.aspx/GetLikeCustomer",
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
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }
                        });
                    },

                    select: function (e, i) {
                        $("#<%=hdnCarrier.ClientID %>").val(i.item.val);
                        $("#<%=txt_Cfs.ClientID %>").val(i.item.text);
                        $("#<%=txt_Cfs.ClientID %>").val($.trim(i.item.label));
                        $("#<%=txtaddress.ClientID %>").val(i.item.address);
                        $("#<%=txt_Cfs.ClientID %>").change();
                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=hdnCarrier.ClientID %>").val(i.item.val);
                            $("#<%=txt_Cfs.ClientID %>").val(i.item.text);
                            $("#<%=txtaddress.ClientID %>").val(i.item.address);
                            $("#<%=txt_Cfs.ClientID %>").val($.trim(i.item.label));
                        }
                    },
                    focus: function (e, i) {
                        $("#<%=hdnCarrier.ClientID %>").val(i.item.val);
                        $("#<%=txt_Cfs.ClientID %>").val(i.item.text);
                        $("#<%=txtaddress.ClientID %>").val(i.item.address);

                        var result = $("#<%=txt_Cfs.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (out != "") {
                            $("#<%=txt_Cfs.ClientID %>").val($.trim(out));
                        }
                        else {
                            $("#<%=txt_Cfs.ClientID %>").val($.trim(res));
                        }
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_Cfs.ClientID %>").val().toString();
                        var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (out != "") {
                            $("#<%=txt_Cfs.ClientID %>").val($.trim(out));
                        }
                        else {
                            $("#<%=txt_Cfs.ClientID %>").val($.trim(res));
                        }
                        $("#<%=txtaddress.ClientID %>").val(i.item.address);
                    },

                    minLength: 1
                });
            });




            $(document).ready(function () {
                $("#<%=txtCharges.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdnChargeid.ClientID %>").val(0);
                         $.ajax({
                             url: "Mastercfs.aspx/GetCharges",
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
                         $("#<%=txtCharges.ClientID %>").val(i.item.label);
                          $("#<%=txtCharges.ClientID %>").change();
                          $("#<%=hdnChargeid.ClientID %>").val(i.item.val);
                      },
                    focus: function (event, i) {
                        $("#<%=txtCharges.ClientID %>").val(i.item.label);
                         $("#<%=hdnChargeid.ClientID %>").val(i.item.val);
                     },
                    close: function (event, i) {
                        $("#<%=txtCharges.ClientID %>").val(i.item.label);
                         $("#<%=hdnChargeid.ClientID %>").val(i.item.val);
                     },
                    minLength: 1
                });
            });

             $(document).ready(function () {
                 $("#<%=txtCurr.ClientID %>").autocomplete({
                      source: function (request, response) {
                          $("#<%=hdnCurrid.ClientID %>").val(0);
                        $.ajax({
                            url: "Mastercfs.aspx/GetLikeCurrency",
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
                        $("#<%=txtCurr.ClientID %>").val(i.item.label);
                        $("#<%=txtCurr.ClientID %>").change();
                        $("#<%=hdnCurrid.ClientID %>").val(i.item.val);

                    },
                      focus: function (event, i) {
                          $("#<%=txtCurr.ClientID %>").val(i.item.label);
                        $("#<%=hdnCurrid.ClientID %>").val(i.item.val);

                    },
                      close: function (event, i) {
                          $("#<%=txtCurr.ClientID %>").val(i.item.label);
                        $("#<%=hdnCurrid.ClientID %>").val(i.item.val);

                    },
                      minLength: 1
                  });
              });



            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });




        }

    </script>
    <script type="text/javascript">
        function ConfirmationBox() {
            var result = confirm('Do you Want to delete the Detail?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <style type="text/css">
        .CalendarBG input {
            background: none !important;
        }

        .CalendarBG {
    background: none;
    font-size: 11px;
    color: #313131;
    padding: 0px 0px 0px 0px;
    float: left;
    width: 87px;
    margin: 0px 0.5% 0px 0px;
}
        .Remarks {
            float: left;
            width: 100%;
        }
        div#logix_CPH_btn_add1 {
    margin: 16px 0px 0px;
}
        .Date {
    float: left;
    width: 11%;
        margin-right: 0.5%;

}.CFS {
    float: left;
    width: 11%;
}
 .gridpnl {
    height: calc(100vh - 338px);
}
 .Address {
    float: left;
    width: 76.5%;
    margin-right: 0.5%;
}
 .Base {
    float: left;
    width: 11%;
    margin: 0px 0.5% 0px 0.5%;
}.panel_style {
    /* width: 63%; */
    width: 100%;
    /* border: 1px solid black; */
    margin-top: 0%;
}
 .FreightDrop {
    width: 12%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
 .widget-content {
    width: 64%;
}
 .FormCurrRateInput {
    width: 7%;
}
 .Customer {
    float: left;
    width: 61%;
    margin: 0px 0.5% 0px 0px;
}
 .FormChargesInput {
    float: left;
    width: 66%;
    margin: 0px 0.5% 0px 0px;
}
 div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top:15px !important;
}
 textarea#logix_CPH_txtaddress {
    height: 45px !important;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div>
        <asp:Panel ID="Panel1" runat="server" class="panel_style">

            <div class="col-md-12  maindiv">

                <div class="widget box" runat="server" id="div_iframe">

                    <div class="widget-header">
                        <div>
                        <div style="float: left; margin: 0px 0.5% 0px 0px;">
                            <h4><i class="icon-umbrella"></i>
                                <asp:Label ID="lbl_plnmaster" runat="server" Text="Customer CFS Charges"></asp:Label></h4>
                            <!-- Breadcrumbs line -->
                            <div class="crumbs">
                                <ul id="breadcrumbs" class="breadcrumb">
                                    <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                    <li id="lb_head" runat="server" visible="false"><a href="#" title="" id="header1" runat="server">Maintenance</a> </li>
                                    <li><a href="#" title="">Master</a> </li>
                                    <li class="current"><a href="#" title="">Customer CFS Charges</a> </li>
                                </ul>
                            </div>
                        </div>

                        <%-- <div style="float: right; margin: 0px -0.5% 0px 0px; height: 9px;" class="log ico-log-sm" >
                            <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                        </div>--%>

                            </div>
                    </div>
                    <div class="widget-content">
                        <%--<div class="FormGroupContent4 custom-pt-1">
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">RateID</asp:LinkButton>
                            </div>--%>

                        <div class="FormGroupContent4 boxmodal">

                            <%--<div class="FormCarrier blueheighlight">
                                <asp:Label ID="Label2" runat="server" Text="Carrier"></asp:Label>
                                <asp:TextBox ID="txt_Cfs" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="" TabIndex="1" ToolTip="Carrier" ></asp:TextBox>
                            </div>
                             <div class="cusAddrss blueheighlight">
                                        <span>Address</span>
                                        <asp:TextBox ID="txtaddress" runat="server" ToolTip="Address" placeholder="" TextMode="MultiLine" Rows="1" Style="resize: none;" ReadOnly="true" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                                    </div>--%>


                            <%-- <asp:Label ID="Label1" runat="server" Text="Valid From"></asp:Label>--%>
                            
                              <div class="FormGroupContent4">

                             <div class="FreightDrop" >
                            <asp:Label ID="Label6" runat="server" Text="Type"></asp:Label>
                            <asp:DropDownList ID="ddltype" ToolTip="Type" data-placeholder="Type" runat="server" TabIndex="1" CssClass="chzn-select">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                                 <asp:ListItem Text="Customer" Value="1"></asp:ListItem>
                                 <asp:ListItem Text="CFS" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                                <asp:LinkButton ID="LinkButton1" CssClass="anc ico-find-sm" runat="server" OnClick="LinkButton1_Click"></asp:LinkButton>

                                     <div class="Customer">
                                    <asp:Label ID="Label29" runat="server" Text="Customer"></asp:Label>
                                    <asp:TextBox ID="txt_Cfs" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="2" OnTextChanged="txt_Cfs_TextChanged" placeholder="" ToolTip="CFS"></asp:TextBox>
                                </div>
                                <div class="Date">
                                    <asp:Label ID="Label9" runat="server" Text="Date"></asp:Label>
                                    <asp:TextBox ID="txt_date" runat="server" CssClass="form-control"
                                        AutoPostBack="True" ></asp:TextBox>

                                    <ajaxtoolkit:CalendarExtender ID="dtdateval" runat="server" TargetControlID="txt_date" Format="dd/MM/yyyy" />
                                </div>
                                <div class="CFS">
                                    <asp:Label ID="Label1" runat="server" Text="CFS ID"></asp:Label>
                                    <asp:TextBox ID="txtcfsid" runat="server" CssClass="form-control" AutoPostBack="True"  OnTextChanged="cfsid_TextChanged" placeholder="" ToolTip="CFS ID"></asp:TextBox>
                                </div>
                                  </div>
                           
                            <div class="FormGroupContent4">

                            <div class="Address">
                                <asp:Label ID="Label31" runat="server" Text="Address"> </asp:Label>
                                <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="" ToolTip="Address"></asp:TextBox>
                            </div>
                                 <div class="CalendarBG">
                                    <span>Valid From</span>
                                    <asp:TextBox ID="txtvalidfrom" runat="server" CssClass="form-control" ToolTip="Valid From" TabIndex="3"></asp:TextBox>
                                    <ajaxtoolkit:CalendarExtender ID="Calendarextender2" runat="server" Format="dd/MM/yyyy"  TargetControlID="txtvalidfrom"></ajaxtoolkit:CalendarExtender>
                                </div>
                                <%-- <asp:Label ID="lblValidTill" runat="server" Text="Valid Till"></asp:Label>--%>

                                <div class="CalendarBG">
                                    <span>Valid Till</span>
                                    <asp:TextBox ID="txtValidTill" runat="server" CssClass="form-control" ToolTip="Valid Till" TabIndex="4"></asp:TextBox>
                                    <ajaxtoolkit:CalendarExtender ID="Calendarextender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtValidTill"></ajaxtoolkit:CalendarExtender>
                                </div>
                                </div>
                            
                            <div class="Remarks ">
                                <asp:Label ID="Label21" runat="server" Text="Remarks"></asp:Label>

                                <asp:TextBox ID="txtRemarks" runat="server" Style="resize: none;" Width="100%" TabIndex="5" ToolTip="REMARKS" PlaceHolder=" " CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="bordertopNew"></div>

                            <div class="FormGroupContent4">
                                <div class="right_btn">
                                <div class="btn btn-save1 WidthcrtlN1" id="btn_save" runat="server">
                                    <asp:Button ID="btnsave" runat="server" ToolTip="Save" TabIndex="6" OnClick="btnsave_Click" />
                                </div>
                                <div class="btn ico-cancel" id="btn_cancel" runat="server">
                                    <asp:Button ID="btncancel" runat="server" ToolTip="Cancel" TabIndex="7" OnClick="btncancel_Click" />
                                </div>
</div>
                                </div>
                                <div class="bordertopNew"></div>

                                <div class="FormGroupContent4 ">
                                    <div class="FormChargesInput blueheighlight">
                                        <asp:Label ID="Label16" runat="server" Text="Charges"></asp:Label>
                                        <asp:TextBox ID="txtCharges" runat="server"
                                            CssClass="form-control" AutoPostBack="True" TabIndex="8" OnTextChanged="txtCharges_TextChanged" placeholder="" ToolTip="Charges"></asp:TextBox>


                                    </div>
                                    <div class="FormCurrRateInput blueheighlight">
                                        <asp:Label ID="Label17" runat="server" Text="Curr"></asp:Label>
                                        <asp:TextBox ID="txtCurr" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="9" MaxLength="3" placeholder="" ToolTip="Currency" OnTextChanged="txtCurr_TextChanged"></asp:TextBox>

                                    </div>
                                    <div class="FormRateInputNew1 blueheighlight">
                                        <asp:Label ID="Label18" runat="server" Text="Rate"></asp:Label>
                                        <asp:TextBox ID="txtRate" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="10" placeholder="" ToolTip="Rate"></asp:TextBox>
                                    </div>
                                    <div class="Base blueheighlight">
                                        <asp:Label ID="Label19" runat="server" Text="Base / Unit"></asp:Label>
                                        <asp:DropDownList ID="ddlBase" runat="server" TabIndex="11" CssClass="chzn-select" ToolTip="Base / Unit"
                                            data-placeholder="Base / Unit" AutoPostBack="True">
                                            <asp:ListItem Text="Base / Unit" Value="0"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <div class="btn ico-add" id="btn_add1" runat="server">
                                        <asp:Button ID="btnAdd" runat="server" ToolTip="Add"
                                            TabIndex="12" OnClick="btnAdd_Click" />
                                    </div>
                                </div>

                                <div class="FormGroupContent4 boxmodal">
                                    <asp:Panel ID="BuyingPanel" runat="server" CssClass="gridpnl">

                                        <asp:GridView ID="grd" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                                            OnRowCommand="grd_RowCommand" CssClass="Grid FixedHeader" OnSelectedIndexChanged="grd_SelectedIndexChanged"
                                            OnRowDataBound="grd_RowDataBound" OnPreRender="grd_PreRender">
                                            <Columns>
                                                <asp:BoundField DataField="chargename" HeaderText="Charges">
                                                    <ControlStyle />
                                                    <HeaderStyle />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="curr" HeaderText="Curr">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="base" HeaderText="Base/Unit">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>

                                                        <asp:ImageButton ID="Img_Delete" runat="server" CommandName="Delete" ImageUrl="~/images/delete.jpg" />

                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />

                                                </asp:TemplateField>


                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" />
                                        </asp:GridView>
                                    </asp:Panel>


                                </div>




                             <asp:Label ID="lblAI" runat="server"></asp:Label>


                <ajaxtoolkit:ModalPopupExtender ID="popupBuying" runat="server" TargetControlID="lblAI" BehaviorID="programmaticModalPopupBehavior1"
                    PopupControlID="pnlJobAE" DropShadow="false"
                    CancelControlID="imgfgok">
                </ajaxtoolkit:ModalPopupExtender>

                <asp:Panel ID="pnlJobAE" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                    <div class="divRoated">
                        <div class="DivSecPanel">
                            <asp:Image ID="imgfgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                        </div>

                        <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

                            <asp:GridView ID="grdmain" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False"
                                Width="100%" ForeColor="Black" EmptyDataText="No Record Found" AllowPaging="false" PageSize="20"
                                CssClass="Grid FixedHeader" Visible="False" OnRowDataBound="grdmain_RowDataBound"
                                OnSelectedIndexChanged="grdmain_SelectedIndexChanged">
                                <Columns>



                                    <asp:BoundField DataField="cfsid" HeaderText="CFS Id">



                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Customer">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                                <asp:Label ID="review" runat="server" Text='<%# Bind("customer") %>' ToolTip='<%#Bind("customer")%>'></asp:Label>
                                            </div>

                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" />

                                    </asp:TemplateField>





                                    <asp:TemplateField HeaderText="Valid Till">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                                <asp:Label ID="review" runat="server" Text='<%# Bind("validtill") %>' ToolTip='<%#Bind("validtill")%>'></asp:Label>
                                            </div>

                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="true" />

                                    </asp:TemplateField>


                                    

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <PagerStyle CssClass="GridviewScrollPager" />
                                <RowStyle Font-Italic="False" />
                            </asp:GridView>

                        </asp:Panel>
                        </div>
                    </asp:Panel>


                            </div>
                        </div>
                    </div>
                </div>
        </asp:Panel>
    </div>

    <asp:HiddenField ID="hdnChargeid" runat="server" />
    <asp:HiddenField ID="hdnCurrid" runat="server" />
    <asp:HiddenField ID="hdnCarrier" runat="server" />
    <asp:HiddenField ID="hdncfsid" runat="server" />

</asp:Content>


