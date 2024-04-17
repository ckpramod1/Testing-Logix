<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="PerformaOsVouchers_Afterjobclose.aspx.cs" EnableEventValidation="false" Inherits="logix.FAForms.PerformaOsVouchers_Afterjobclose" %>

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
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css" />
    <!--=== JavaScript ===-->


    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>


    <!-- App -->

    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
    
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

    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>


    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <link href="../Styles/ProfomaInvoice.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>


    <script src="../Scripts/ScrollableGridPlugin.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />



    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txtcharge.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdnChargid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Accounts/PerformaOsVouchers.aspx/GetCharges",
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
                        $("#<%=txtcharge.ClientID %>").val(i.item.label);
                        $("#<%=txtcharge.ClientID %>").change();
                        $("#<%=hdnChargid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtcharge.ClientID %>").val(i.item.label);
                        $("#<%=hdnChargid.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtcharge.ClientID %>").val(i.item.label);
                        $("#<%=hdnChargid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

            $(document).ready(function () {
                $("#<%=txtcurr.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdncurrid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Accounts/PerformaOsVouchers.aspx/GetLikeCurrency",
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
                        $("#<%=txtcurr.ClientID %>").val(i.item.label);
                        $("#<%=txtcurr.ClientID %>").change();
                        $("#<%=hdncurrid.ClientID %>").val(i.item.val);

                    },
                    focus: function (event, i) {
                        $("#<%=txtcurr.ClientID %>").val(i.item.label);
                        $("#<%=hdncurrid.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtcurr.ClientID %>").val(i.item.label);
                        $("#<%=hdncurrid.ClientID %>").val(i.item.val);

                    },
                    minLength: 1
                });
            });


            $(document).ready(function () {
                $("#<%=txtsupplyto.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_SupplyTo.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCustomer_DNCN",
                            data: "{ 'prefix': '" + request.term + "','ChkType':'P'}",
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
                        $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                        $("#<%=txtsupplyto.ClientID %>").change();
                        $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                        $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                        }
                    },
                    close: function (event, i) {
                        var result = $("#<%=txtsupplyto.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtsupplyto.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });





            $(document).ready(function () {
                $("#<%=txt_Agent.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_intagent.ClientID %>").val(0);
                      $.ajax({
                          url: "../Autocomplete/Autocomplete.aspx/GetCustomer_DNCN",
                          data: "{ 'prefix': '" + request.term + "','ChkType':'P'}",
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
                      $("#<%=txt_Agent.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                        $("#<%=txt_Agent.ClientID %>").change();
                        $("#<%=hid_intagent.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_Agent.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                         $("#<%=hid_intagent.ClientID %>").val(i.item.val);
                     },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_Agent.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                             $("#<%=hid_intagent.ClientID %>").val(i.item.val);
                         }
                     },
                    close: function (event, i) {
                        var result = $("#<%=txt_Agent.ClientID %>").val().toString().split(' ,')[0];
                         $("#<%=txt_Agent.ClientID %>").val($.trim(result));
                     },
                    minLength: 1
                });
            });
         }

    </script>





    <link href="../Styles/OSDCNPro.css" rel="stylesheet" />
    <style type="text/css">
        .modalPopupss {
            background-color: #FFFFFF;
            /* border-width: 1px; */
            border-style: solid;
            border-color: #CCCCCC;
            /* width: 1062px; */
            width: 98.7%;
            height: 570px;
            margin-left: 1%;
            margin-top: -0.9%;
            overflow: auto;
        }

        .DivSecPanel {
            padding: 2px 2px 2px 2px;
            margin: -1px 0px 5px 0px;
        }

        .row {
            height: 588px !important;
            margin: 0px 5px 0px 0px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            /* width: 100%; */
        }

        .BLDropInputNew {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .JobNoInputNForNew {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ChargeInputN11New {
            width: 30.2%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .RemarkInput4new {
            width: 80.5%;
            float: left;
        }

        .AgentTextareaNew {
            width: 40%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ShipmentTextareaNew {
            width: 35%;
            float: left;
            margin: 0px;
        }

        .BLRightNew {
            width: 24%;
            float: left;
                position: relative;
        }

        .BLDropInputNewForNew {
            width: 11%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }


        .lst_cont {
            height: auto;
            margin-left: 1.5%;
            
        }

        .chkapp {
            width: 8%;
            float: left;
            margin-left: 0.5%;
        }

        /*.RemarkInput4new {
            width: 75%;
            float: left;
        }*/
        .ToInputOther7 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 40%;
        }
        div#logix_CPH_ddlDebiteOrCredite_chzn {
    width: 100% !important;
}
        .div_agent {
            float: left;
            margin: 0 0.5% 0 0;
            width: 40%;
        }


        .div_agent1 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 10%;
        }

        .TotalInputosdn {
            width: 11.5%;
            float: right;
            margin: 0px 0px 0px 0px;
            color: #000080;
            font-size: 11px;
        }

        .TotalInputosdnFcamt {
            width: 10%;
            float: right;
            margin: 0px 0.5% 0px 0px;
            color: #000080;
            font-size: 11px;
        }

        .TotalInputosdnFcamt1 {
            width: 10%;
            float: right;
            margin: 0px 0.5% 0px 5px;
        }


        .TotalInputosdn1 {
            width: 11.3%;
            float: right;
            margin: 0px 0px 0px 0px;
        }

        .TotalInputosdn4 {
            width: 8.5%;
            float: right;
            margin: 20px 0px 0px 0px;
        }

        .TotalInputosdn2 {
            width: 43%;
            float: right;
            margin: 0px 0.5% 0px 0px;
            text-align: right;
        }

        .TotalInputosdn3 {
            width: 11.3%;
            float: right;
            margin: 0px 0% 0px 0px;
        }

        .TotalInputosdn5 {
            width: 12%;
            float: right;
            margin: 23px 7px 0px 0px;
            text-align: right;
        }

        .CurrInput2New {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BLDrop2New {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .AmountN67 {
            width: 9.5%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .txt_SupplyTobl {
            width: 20%;
            float: left;
            margin-left: 0.5%;
            margin-top: 0.5%;
        }

        .btn-print {
            z-index: 2;
            border-radius: 0px;
            top: 0px;
            left: 0px;
            height: 28px;
            width: 61px;
        }

        .VendorRefInput2 {
            width: 35%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .lblmsg {
            width: 25%;
            float: left;
            font-size: 13px;
            margin: 0px 0% 0px 0px;
        }

        #Test_foregroundElement {
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


        .FormGroupContent4 span {
            /*color: #000080;*/
            font-size: 11px;
        }

        a {
            font-size: 11px;
        }

        .LogHeadJobInput label {
            font-size: 11px;
            font-family: sans-serif;
            color: #4e4e4c;
        }

        .LabelValue {
            font-family: sans-serif;
            font-size: 11px;
            color: #b1b1b1 !important;
            font-weight: normal;
            text-align: right;
        }

        .MT10 {
            margin: 13px 0px 0px 0px !important;
        }
 
 
        .YearBox {
    width: 5%;
    float: left;
    margin: 0px 0px 0px 0px;
}
        .JobNoInputN {
    width: 7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.REFNo {
       width: 6%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
div#UpdatePanel1 {
    /* height: 100vh; */
    height: 88vh;
    overflow-x: hidden;
    overflow-y: auto;
}
.VendorRef {
        width: 50%;
    float: left;
    margin: 0px 1.5% 0px 0px;
}
span#logix_CPH_Label1, span#logix_CPH_Label5, span#logix_CPH_Label4,span#logix_CPH_lblCredit {
    color: #4d4d4d !important;
}
.TextArea span {
    position: absolute !important;
    top: 10px !important;
    z-index: 1 !important;
    left: 5px !important;
    font-size: 9px !important;
    background: white;
    padding: 0px 5px !important;
    margin-left: 0px !important;
}
.btn.btn-view1, .btn.btn-print1, .btn.btn-cancel1, .btn.btn-save1 {
    margin: 10px 0 0 0;
}
.ajax__calendar {
    top: -175px !important;
}
span#logix_CPH_Label34 {
        color: rgb(6, 82, 156);
    font-weight: 500 !important;
    font-size: 13px !important;
}
select#logix_CPH_lstcon {
    border-radius: 0px;
}
.btn.ico-add {
    margin-top: 9px;
}
 
div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 55px !important;
}
div#logix_CPH_ddlTypes_chzn {
    width: 100% !important;
}
 
 
    </style>
    <script type="text/jscript">
        function RestrictSpace() {
            //var message = "Cntrl key/ Right Click Option disabled";
            //// check mouse right click or Ctrl key press
            //var kCode = event.keyCode || e.charCode;
            ////FF and Safari use e.charCode, while IE use e.keyCode
            //if (kCode == 17 || kCode == 118) {
            //alertify.alert(message);
            //    return false;
            //}
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <asp:Panel ID="Panel1" runat="server">

        <!-- /Breadcrumbs line -->
        <div>
            <div class="col-md-12  maindiv">

                <div class="widget box" runat="server" id="div_iframe">

                    <div class="widget-header">
                        <div style="float: left; margin: 0px 0.5% 0px 0px;">
                            <h4 class="hide"><i class="icon-umbrella"></i>
                                <asp:Label ID="lbl_Header" runat="server" Text="Proforma OSDN/CN"> </asp:Label></h4>
                            <!-- Breadcrumbs line -->
                            <div class="crumbs">
                                <ul id="breadcrumbs" class="breadcrumb">
                                    <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                    <li><a href="#"></a>Documentation</li>
                                    <li><a href="#" title="" id="headerlable1" runat="server">Ocean Exports</a> </li>
                                    <li><a href="#" title="">Accounts</a> </li>
                                    <li class="current"><a href="#" title="">Proforma OS Vouchers</a> </li>
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
                                <div class="btn ico-view">
                                    <asp:Button ID="btnprint" runat="server"  Text="View" ToolTip="View" OnClick="btnprint_Click" TabIndex="22" Enabled="true" />
                                </div>
                                <div class="btn ico-print">
                                    <asp:Button ID="btnview" runat="server" Text="Print" ToolTip="Print" OnClick="btnview_Click" TabIndex="23" />
                                </div>
                                <div class="btn ico-cancel">
                                    <asp:Button ID="btnback" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btnback_Click" TabIndex="24" />
                                </div>
                            </div>

                        </div>
                        <div class="FormGroupContent4 boxmodal">

                                 <div class="LblTextpro hide">

                                <asp:Label ID="lbl" runat="server" Text="" Style="text-align: center; color: Red; float: left; margin-left: 38%;"> </asp:Label>
                            </div>
                             <div class="BLDropInputNewForNew">
                                <asp:Label ID="Labelp" runat="server" Text="Product"> </asp:Label>
                                <asp:DropDownList ID="ddl_product" AutoPostBack="true" runat="server" Width="100%" AppendDataBoundItems="True" CssClass="chzn-select" ToolTip="Product" data-placeholder="Product" OnSelectedIndexChanged="ddl_product_SelectedIndexChanged">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    <asp:ListItem Value="AE" Text="Air Exports"></asp:ListItem>
                                    <asp:ListItem Value="AI" Text="Air Imports"></asp:ListItem>
                                  <%--  <asp:ListItem Value="CH" Text="Custom House Agent"></asp:ListItem>--%>
                                    <asp:ListItem Value="FE" Text="Ocean Exports"></asp:ListItem>
                                    <asp:ListItem Value="FI" Text="Ocean Imports"></asp:ListItem>

                                    <%-- <asp:ListItem Value="BT" Text="Bonded Trucking"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                             <div class="BLDropInputNewForNew">
                                <asp:Label ID="Label13" runat="server" Text="Type"></asp:Label>
                                <asp:DropDownList ID="ddlTypes" runat="server" ToolTip="Type" AutoPostBack="True" OnSelectedIndexChanged="ddlTypes_SelectedIndexChanged" Width="100%" data-placeholder="Type" TabIndex="2" CssClass="chzn-select">
                                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                                    <asp:ListItem Value="5" Text="">OSDN</asp:ListItem>
                                    <asp:ListItem Value="6" Text="">OSCN</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                            <div class="JobNoInputN">
                                <asp:Label ID="Label10" runat="server" Text="Job #" CssClass="hide"></asp:Label>
                                <asp:TextBox ID="txtJobno" placeholder="" ToolTip="Job Number" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="1" OnTextChanged="txtJobno_TextChanged1"></asp:TextBox>
                            </div>
                              <div class="REFNo">
                                <asp:Label ID="Label12" runat="server" Text="Ref #"></asp:Label>
                                <asp:TextBox ID="txtdcn" placeholder="" ToolTip=" Ref Number" runat="server" TabIndex="3" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtdcn_TextChanged" onkeypress="return isNumberKey(event,'Ref #');"></asp:TextBox>
                            </div>
                           
                       
                            <div class="YearBox">
                                <asp:Label ID="Label11" runat="server" Text="Year"></asp:Label>
                                <asp:TextBox ID="txtyear" runat="server" placeholder="" ToolTip="Year" CssClass="form-control" TabIndex="4" AutoPostBack="True"></asp:TextBox>
                            </div>

                          

                        </div>
                        <div class="FormGroupContent4 boxmodal">
                            <div class="div_agent">
                                <asp:Label ID="Label14" runat="server" Text="Agent"></asp:Label>
                                <asp:TextBox ID="txt_Agent" runat="server" ToolTip="Agent" placeholder="" CssClass="form-control" AutoPostBack="True" TabIndex="5" OnTextChanged="txt_Agent_TextChanged"></asp:TextBox>
                            </div>
                            <div class="div_agent1">
                                <asp:Label ID="Label15" runat="server" Text="Origin"></asp:Label>
                                <asp:TextBox ID="txt_origin" runat="server" ToolTip="Origin" placeholder="" CssClass="form-control" AutoPostBack="True" TabIndex="6"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4 boxmodal">
                            <div class="AgentTextareaNew">
                                <asp:Label ID="Label16" runat="server" Text="Agent Details"></asp:Label>
                                <asp:TextBox ID="txtcustomer" placeholder="" ToolTip="Agent Details" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="7" TextMode="MultiLine" Width="100%" Style="resize: none;" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="ShipmentTextareaNew">
                                <asp:Label ID="Label17" runat="server" Text="Shipment Details"></asp:Label>
                                <asp:TextBox ID="txtshipment" placeholder=" " ToolTip="Shipment Details" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="8" TextMode="MultiLine" Width="100%" Style="resize: none;" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="BLRightNew TextArea">
                                <div class="FormGroupContent4">
                                <asp:Label ID="Label34" runat="server" Text="Container / Volume / Weight Details"></asp:Label>                                   
                                    <asp:Panel ID="pnlContlist" runat="server" CssClass="lst_cont TextArea" >
                                        <asp:ListBox ID="lstcon" runat="server" Width="100%" Height="63px"></asp:ListBox>
                                    </asp:Panel>
                                </div>

                            </div>

                        </div>
                        <div class="FormGroupContent4 boxmodal">
                            <div class="ToInputOther7">
                                <asp:Label ID="Label18" runat="server" Text="Supply To"></asp:Label>
                                <asp:TextBox ID="txtsupplyto" runat="server" ToolTip="Supply To" placeholder="" CssClass="form-control" AutoPostBack="True" TabIndex="9" OnTextChanged="txtsupplyto_TextChanged"></asp:TextBox>
                            </div>

                        </div>

                        <div class="FormGroupContent4 boxmodal">
                            <div class="BLDropInputNew">
                                <asp:Label ID="Label19" runat="server" Text="Receivable/Payable"></asp:Label>
                                <asp:DropDownList ID="ddlDebiteOrCredite" runat="server" ToolTip="Receivable/Payable" AutoPostBack="True" Width="100%" data-placeholder="Receivable/Payable" TabIndex="10" CssClass="chzn-select">
                                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                                    <asp:ListItem Value="5" Text="">Receivable from agent</asp:ListItem>
                                    <asp:ListItem Value="6" Text="">Payable to agent</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="JobNoInputNForNew">
                                <asp:Label ID="Label20" runat="server" Text="BL/MBL"></asp:Label>
                                <asp:DropDownList ID="cmbbl" runat="server" ToolTip="BL/MBL" AutoPostBack="True" TabIndex="11" Width="100%" data-placeholder="BL/MBL" CssClass="chzn-select" OnSelectedIndexChanged="cmbbl_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="ChargeInputN11New">
                                <asp:Label ID="Label21" runat="server" Text="Charge Description"></asp:Label>
                                <asp:TextBox ID="txtcharge" runat="server" ToolTip="Charge Description" TabIndex="12" placeholder="" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtcharge_TextChanged"></asp:TextBox>
                            </div>
                            <div class="CurrInput2New">
                                <asp:Label ID="Label22" runat="server" Text="Curr"></asp:Label>
                                <asp:TextBox ID="txtcurr" runat="server" ToolTip="Curr" placeholder="" TabIndex="13" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtcurr_TextChanged"></asp:TextBox>
                            </div>
                            <div class="CurrInput2New">
                                <asp:Label ID="Label23" runat="server" Text="Rate"></asp:Label>
                                <asp:TextBox ID="txtrate" runat="server" ToolTip="Rate" Style="text-align: right" TabIndex="14" placeholder="" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtrate_TextChanged"></asp:TextBox>
                            </div>
                            <div class="CurrInput2New">
                                <asp:Label ID="Label24" runat="server" Text="Ex Rate"></asp:Label>
                                <asp:TextBox ID="txtexrate" runat="server" ToolTip="Ex Rate" placeholder="" TabIndex="15" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtexrate_TextChanged"></asp:TextBox>
                            </div>
                            <div class="BLDrop2New">
                                <asp:Label ID="Label25" runat="server" Text="Base/Unit"></asp:Label>
                                <asp:DropDownList ID="cmbbase" runat="server" ToolTip="Base/Unit" Data-placeholder="Base/Unit" TabIndex="16" Width="100%" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="cmbbase_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="AmountN67">
                                <asp:Label ID="Label26" runat="server" Text="Amount"></asp:Label>
                                <asp:TextBox ID="txtamount" Style="text-align: right" runat="server" ToolTip="Amount" TabIndex="17" placeholder="" CssClass="form-control"></asp:TextBox>
                            </div>
                             <div class="btn ico-add">
                                    <asp:Button ID="btnAdd" runat="server" Style="text-align: center" Text="Add" TabIndex="19" OnClick="btnAdd_Click" />
                                </div>

                            <%-- <div class="BLRight">
                        <div class="FormGroupContent4">
                             <asp:Panel id="pnlContlist" runat="server" cssClass="lst_cont" ScrollBars="Auto">
                    <asp:ListBox ID="lstcon" runat="server" Width ="100%" Height="79px"></asp:ListBox>
                </asp:Panel>
                            </div>

                    </div>--%>
                        </div>
                        <div class="FormGroupContent4">

                            <div class="RemarkInput4new" style="display: none;">
                                <asp:Label ID="Label27" runat="server" Text="Remarks"></asp:Label>
                                <asp:TextBox ID="txtremarks" runat="server" TabIndex="18" CssClass="form-control" ToolTip="Remarks" placeholder="" Enabled="false"></asp:TextBox>
                                <%--Enabled="false"--%>
                            </div>
                            <div class="chkapp" style="display: none;">
                                <asp:CheckBox ID="chk_GstApp" runat="server" Text="GST Applicable" />
                            </div>


                            <div class="right_btn ">
                               

                            </div>

                        </div>
                        <div class="FormGroupContent4 boxmodal" id="debitgrd" runat="server">
                            <div class="DebitAdvise">
                                <asp:Label ID="Label4" runat="server" Text="Receivable from Agent" CssClass="LabelValue"></asp:Label>
                            </div>
                            <asp:Panel ID="pnlCCharge" runat="server" CssClass="gridpnl" ScrollBars="Auto">
                                <asp:GridView ID="grddebit" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" CssClass="Grid FixedHeader" OnRowDataBound="grddebit_RowDataBound" OnSelectedIndexChanged="grddebit_SelectedIndexChanged" OnPreRender="grddebit_PreRender">
                                    <Columns>
                                          <asp:TemplateField HeaderText="Sl #">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="blno" HeaderText="HBL/ MBL #">
                                            <HeaderStyle Wrap="false" />
                                            <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="chargename" HeaderText="Charges">
                                            <HeaderStyle Wrap="false" />
                                            <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="curr" HeaderText="Curr">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="rate" HeaderText="Rate" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%--DataFormatString="{0:F2}"--%>
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="exrate" HeaderText="Exrate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="bASe" HeaderText="Base/Unit">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="withoutgstAmt" HeaderText="Amount" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="stgst" HeaderText="GST" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="amount" HeaderText="Total Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="right" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="chargeid" HeaderText="chargeid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"></asp:BoundField>
                                        <asp:BoundField DataField="GSTCHK" HeaderText="GSTCHK" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                        <asp:BoundField DataField="provouno" HeaderText="pro Dn" />
                                        <asp:BoundField DataField="vouno" HeaderText="dnno" />
                                        <asp:BoundField DataField="vouyear" HeaderText="vouyear" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                        <asp:BoundField DataField="fcamt" HeaderText="fcamt" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="Img_Edudelete" runat="server" CommandName="select" CssClass="Grid_Edit_Img"
                                                    ImageUrl="~/images/delete.jpg" OnClientClick="javascript:IsConfirm('Do You Want Delete','hid_confirm');" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:TemplateField>

                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle Font-Italic="False" />
                                </asp:GridView>

                            </asp:Panel>

                            
                        <div class="btn ico-debit-advice" style="float: left; margin: 15px 0px 0px 0px;">
                            <asp:Button ID="btn_debitadvise" runat="server" Text="Debit Advise" ToolTip="DebitAdvise" OnClick="btn_debitadvise_Click" />
                        </div>

                        <div class="TotalInputosdn">
                            <asp:Label ID="Label32" runat="server" Text="Total"></asp:Label>
                            <asp:TextBox ID="txtDebit" runat="server" Style="text-align: right" CssClass="form-control" ReadOnly="True" placeholder="" ToolTip="Total"></asp:TextBox>
                        </div>
                        <div class="TotalInputosdnFcamt">
                            <asp:Label ID="Label33" runat="server" Text="FCAmount"></asp:Label>
                            <asp:TextBox ID="txt_FcDebitamt" runat="server" Style="text-align: right" CssClass="form-control" ReadOnly="True" placeholder="" ToolTip="FCAmount"></asp:TextBox>

                        </div>
                        <div class="TotalInputosdn5">
                            <asp:Label ID="Label1" runat="server" Text="Receivable from Total:" CssClass="LabelValue"></asp:Label>
                        </div>
                        </div>

                        <div class="FormGroupContent4 boxmodal" id="creditgrd" runat="server">
                            <div class="DebitAdvise">
                                <asp:Label ID="Label5" runat="server" Text="Payable to Agent" CssClass="LabelValue"></asp:Label>
                            </div>
                            <asp:Panel ID="Panel2" runat="server" CssClass="gridpnl" ScrollBars="Auto">
                                <asp:GridView ID="grdcredit" TabIndex="20" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" CssClass="Grid FixedHeader " OnRowDataBound="grdcredit_RowDataBound" OnSelectedIndexChanged="grdcredit_SelectedIndexChanged" OnPreRender="grdcredit_PreRender">
                                    <Columns>
                                        <%--0--%>
                                          <asp:TemplateField HeaderText="Sl #">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                         <%--1--%>
                                        <asp:BoundField DataField="blno" HeaderText="HBL/ MBL #">
                                            <HeaderStyle Wrap="false" />
                                            <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                        </asp:BoundField>
                                         <%--2--%>
                                        <asp:BoundField DataField="chargename" HeaderText="Charges">
                                            <HeaderStyle Wrap="false" />
                                            <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                        </asp:BoundField>
                                         <%--3--%>
                                        <asp:BoundField DataField="curr" HeaderText="Curr">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                         <%--4--%>
                                        <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                         <%--5--%>
                                        <asp:BoundField DataField="exrate" HeaderText="Exrate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                         <%--6--%>
                                        <asp:BoundField DataField="bASe" HeaderText="Base/Unit">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                        </asp:BoundField>
                                         <%--7--%>
                                        <asp:BoundField DataField="withoutgstAmt" HeaderText="Amount" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                         <%--8--%>
                                        <asp:BoundField DataField="stgst" HeaderText="GST" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                         <%--9--%>
                                        <asp:BoundField DataField="amount" HeaderText="Total Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="right" />
                                        </asp:BoundField>
                                         <%--10--%>
                                        <asp:BoundField DataField="chargeid" HeaderText="chargeid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"></asp:BoundField>
                                        <asp:BoundField DataField="GSTCHK" HeaderText="GSTCHK" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                        <asp:BoundField DataField="provouno" HeaderText="Pro Cn" />
                                        <asp:BoundField DataField="vouno" HeaderText="cnno" />
                                        <asp:BoundField DataField="vouyear" HeaderText="vouyear" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                        <asp:BoundField DataField="fcamt" HeaderText="fcamt" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="Img_Edudelete" runat="server" CommandName="select" CssClass="Grid_Edit_Img"
                                                    ImageUrl="~/images/delete.jpg" OnClientClick="javascript:IsConfirm('Do You Want Delete','hid_confirm');" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        </asp:TemplateField>

                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle Font-Italic="False" />
                                </asp:GridView>

                            </asp:Panel>

                            <div class="btn ico-credit-advice" style="float: left; margin: 15px 0px 0px 0px;">
                                <asp:Button ID="btn_creditadvise" runat="server" Text="Credit Advise" ToolTip="CreditAdvise" OnClick="btn_creditadvise_Click" />
                            </div>

                            <div class="TotalInputosdn1">
                                <asp:Label ID="Label28" runat="server" Text="Total"></asp:Label>
                                <asp:TextBox ID="txtCredit" runat="server" Style="text-align: right" CssClass="form-control" ReadOnly="True" placeholder="" ToolTip="Total"></asp:TextBox>

                            </div>
                            <div class="TotalInputosdnFcamt1">
                                <asp:Label ID="Label29" runat="server" Text="FCAmount"></asp:Label>
                                <asp:TextBox ID="txt_FcCramt" runat="server" Style="text-align: right" CssClass="form-control" ReadOnly="True" placeholder="" ToolTip="FCAmount"></asp:TextBox>

                            </div>
                            <div class="TotalInputosdn4">
                                <asp:Label ID="lblCredit" runat="server" Text="Payable to Total:" CssClass="LabelValue"></asp:Label>
                            </div>
                            <%--<div class="TotalLabel1"><asp:Label ID="Label24" runat="server" Text="Total " CssClass="LabelValue"></asp:Label></div>--%>
                        </div>

                        <div class="FormGroupContent4 boxmodal" style="width: 26%;">
                            <div class="FormGroupContent4">
                            <div class="VendorRef">
                                <asp:Label ID="Label30" runat="server" Text="Vendor Ref #"></asp:Label>
                                <asp:TextBox ID="txtVendorRefno" runat="server" ToolTip="Vendor Ref Number" placeholder="" TabIndex="21" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                            </div>
                            <div class="VendorRefInput2">
                                <asp:Label ID="Label31" runat="server" Text="Vendor Ref Date"></asp:Label>
                                <asp:TextBox ID="txtVendorRefnodate" runat="server" onkeypress="return RestrictSpace()" CssClass="form-control" placeholder="" ToolTip="Vendor Ref Date"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txtVendorRefnodate" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                            </div>

                            <div class="TotalInputosdn3" style="display: none">
                                <asp:TextBox ID="txttotal" runat="server" Style="text-align: right" CssClass="form-control" ReadOnly="True" placeholder="Total" ToolTip="Total"></asp:TextBox>

                            </div>
                            <div class="TotalInputosdn2" style="display: none">
                                <asp:Label ID="lblGross" runat="server" Text="Grand Total:" CssClass="LabelValue"></asp:Label>
                            </div>
                                </div>
                        </div>
                        <div>
                           
                        </div>
                        <%--  <div class="lblmsg">
                                
                                <asp:Label ID="lbl_msg" runat="server" ForeColor="Red" Text="Unclosed Jobs  Pro-OSDN/CN will Displayed Below"></asp:Label></div>--%>
                    </div>
                </div>
            </div>
        </div>

    </asp:Panel>

    <%--     <asp:Panel ID="pln_popup" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" style="display:none;">
        <div class="divRoated">
        <div class="DivSecPanel"> <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%"/>  </div>
             
     <asp:Panel ID="Panel3" runat="server"   CssClass="Gridpnl">   
            <asp:GridView ID="Grd_Job" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="False" Width="100%" 
                AllowPaging="false"   OnRowDataBound="Grd_Job_RowDataBound"
                ForeColor="Black" EmptyDataText="No Record Found" PageSize="20" BackColor="White" OnSelectedIndexChanged="Grd_Job_SelectedIndexChanged"
                >
                <Columns>
                    
                    <asp:TemplateField HeaderText ="Job #">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:40px">
                       <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="41px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText ="JobType">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:40px">
                       <asp:Label ID="JobType" runat="server" Text='<%# Bind("JobType") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="40px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                     <asp:TemplateField HeaderText ="Vessel">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:120px">
                       <asp:Label ID="Vessel" runat="server" Text='<%# Bind("vessel") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="120px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                  
                    <asp:TemplateField HeaderText ="Voyage">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:65px">
                       <asp:Label ID="Voyage" runat="server" Text='<%# Bind("voyage") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="65px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
         
                    <asp:TemplateField HeaderText ="MBL">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:125px">
                       <asp:Label ID="MBL" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="126px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText ="ETD">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:70px">
                       <asp:Label ID="ETD" runat="server" Text='<%# Bind("etd") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="70px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText ="Destination">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:100px">
                       <asp:Label ID="Destination" runat="server" Text='<%# Bind("sd") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="100px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText ="ETA">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:70px">
                       <asp:Label ID="ETA" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="70px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                   <asp:TemplateField HeaderText ="MLO">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:195px">
                       <asp:Label ID="MLO" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="195px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                    
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <PagerStyle CssClass="GridviewScrollPager" />
            </asp:GridView>
         </asp:Panel>
              <div class="Break"> </div>
        </div>
              <div class="div_Break"></div>
          </asp:Panel>


    <asp:Label ID="Label2" runat="server"></asp:Label>
    <asp:ModalPopupExtender ID="popup_Grd" runat="server" PopupControlID="pln_popup" 
       DropShadow="false" TargetControlID="Label2" CancelControlID="close" BehaviorID="Test">
    </asp:ModalPopupExtender>--%>
    <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Do You Want Add  One are More Voucher </b></div>
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
    <asp:ModalPopupExtender ID="PopUpService" runat="server" PopupControlID="Panel_Service" TargetControlID="Label1">
    </asp:ModalPopupExtender>
    <asp:Label ID="Label2" runat="server" Text="Label" Style="display: none;"></asp:Label>








    <asp:Panel runat="Server" ID="Panel3" CssClass="Pnl" Style="display: none;">
        <br />
        <div style="font-size: 10pt">
            <b>

                <asp:Label ID="lbl_pop" runat="server"></asp:Label>

            </b>
        </div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btn_Yes_1" runat="server" Text="Yes" CssClass="Button" OnClick="btn_Yes_1_Click" />
            <asp:Button ID="btn_No_1" runat="server" Text="No" CssClass="Button" OnClick="btn_No_1_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>
    <div class="div_Break"></div>
    <div class="div_Break"></div>
    <asp:ModalPopupExtender ID="pop_upforAgent" runat="server" PopupControlID="Panel3" TargetControlID="Label3">
    </asp:ModalPopupExtender>
    <asp:Label ID="Label3" runat="server" Text="Label" Style="display: none;"></asp:Label>


    <%-- POPUP JOB --%>

    <asp:Panel ID="pln_popup" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel4" runat="server" CssClass="Gridpnl">
                <div class="FormGroupContent4">
                    <asp:GridView ID="Grd_Details" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="False" Width="100%"
                        ForeColor="Black" EmptyDataText="No Record Found"
                        BackColor="White" OnRowDataBound="Grd_Details_RowDataBound" OnSelectedIndexChanged="Grd_Details_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="dnno" HeaderText="DN/CN #">
                                <HeaderStyle Width="155px" />
                                <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="100px" />

                            </asp:BoundField>
                            <asp:BoundField DataField="jobno" HeaderText="Job #">
                                <HeaderStyle Width="48px" />
                                <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="35px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="agent" HeaderText="Agent">
                                <HeaderStyle Width="100px" />
                                <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />

                            </asp:BoundField>
                            <asp:BoundField DataField="debitcredit" HeaderText="debitcredit" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                                <HeaderStyle Width="100px" />
                                <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />

                            </asp:BoundField>
                            <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:F2}">
                                <HeaderStyle Width="100px" />
                                <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />

                            </asp:BoundField>
                        </Columns>
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="myGridHeader" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                        <PagerStyle CssClass="GridviewScrollPager" />
                    </asp:GridView>
                </div>
                <div class="Break"></div>

                <div class="FormGroupContent4">
                    <asp:Panel ID="Book2" runat="server" CssClass="panel_10" ScrollBars="Vertical" Height="400px">
                        <asp:GridView ID="grd_prodetails" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="False" Width="100%"
                            ForeColor="Black" EmptyDataText="No Record Found"
                            BackColor="White" OnRowDataBound="grd_prodetails_RowDataBound" OnSelectedIndexChanged="grd_prodetails_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="dnno" HeaderText="Pro DN/CN">
                                    <HeaderStyle Width="155px" />
                                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="100px" />

                                </asp:BoundField>
                                <asp:BoundField DataField="jobno" HeaderText="Job #">
                                    <HeaderStyle Width="48px" />
                                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="35px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="agent" HeaderText="Agent">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />

                                </asp:BoundField>
                                <asp:BoundField DataField="debitcredit" HeaderText="debitcredit" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />

                                </asp:BoundField>
                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:F2}">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="25px" />

                                </asp:BoundField>
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="myGridHeader" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                            <PagerStyle CssClass="GridviewScrollPager" />
                        </asp:GridView>
                    </asp:Panel>
                </div>




                <div class="FormGroupContent4">
                    <div class="right_btn">
                        <div class="btn ico-add">
                            <asp:Button ID="btnAdd_OneOrMore" runat="server" Text="Add One are More OSDN/CN" OnClick="btnAdd_OneOrMore_Click" />
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div class="Break"></div>
        </div>


    </asp:Panel>


    <asp:Label ID="Label6" runat="server"></asp:Label>
    <asp:ModalPopupExtender ID="popup_Grd" runat="server" PopupControlID="pln_popup"
        DropShadow="false" TargetControlID="Label6" CancelControlID="close" BehaviorID="Test">
    </asp:ModalPopupExtender>


    <asp:Panel runat="Server" ID="pnl_MoreCust" CssClass="Pnl" Style="display: none;">
        <br />
        <div style="font-size: 10pt">
            <b>

                <asp:Label ID="lbl_addMorAgent" runat="server"></asp:Label>

            </b>
        </div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btn_MoreCust_Yes" runat="server" Text="Yes" CssClass="Button" OnClick="btn_MoreCust_Yes_Click" />
            <asp:Button ID="btn_MoreCust_No" runat="server" Text="No" CssClass="Button" OnClick="btn_MoreCust_No_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>
    <div class="div_Break"></div>
    <div class="div_Break"></div>
    <asp:ModalPopupExtender ID="popup_MoreAgent" runat="server" PopupControlID="pnl_MoreCust" TargetControlID="Label8">
    </asp:ModalPopupExtender>
    <asp:Label ID="Label8" runat="server" Text="Label" Style="display: none;"></asp:Label>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>ProfomaOsDNCNPro:</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel5" runat="server" CssClass="Gridpnl">

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
    <asp:Label ID="Label7" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image2" BehaviorID="Test1">
    </asp:ModalPopupExtender>
    <asp:Panel runat="Server" ID="pnl_Popup" CssClass="Pnl" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Do You Want GST For This Charge </b></div>
        <%--<div style="font-size: 10pt"><b>Do You Want Service Tax Applicable For This Charge </b></div>--%>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btn_serviceyes" runat="server" Text="Yes" CssClass="Button" OnClick="btn_serviceyes_Click" />
            <asp:Button ID="btn_serviceno" runat="server" Text="No" CssClass="Button" OnClick="btn_serviceno_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>
    <div class="div_Break"></div>
    <div class="div_Break"></div>
    <asp:ModalPopupExtender ID="model_Servicetax" runat="server" PopupControlID="pnl_Popup" TargetControlID="Label9">
    </asp:ModalPopupExtender>
    <asp:Label ID="Label9" runat="server" Text="Label" Style="display: none;"></asp:Label>

    <asp:HiddenField ID="hf_branchid" runat="server" />
    <asp:HiddenField ID="hf_divisionid" runat="server" />
    <asp:HiddenField ID="hf_jobno" runat="server" />
    <asp:HiddenField ID="hf_intdnno" runat="server" />
    <asp:HiddenField ID="hdncurrid" runat="server" />
    <asp:HiddenField ID="hdnChargid" runat="server" />
    <asp:HiddenField ID="hid_confirm" runat="server" />
    <asp:HiddenField ID="hid_intagent" runat="server" />
    <asp:HiddenField ID="hid_douvolume" runat="server" />
    <asp:HiddenField ID="hid_fd" runat="server" />
    <asp:HiddenField ID="hid_SupplyTo" runat="server" />
    <asp:HiddenField ID="hid_jobtype" runat="server" />
    <asp:HiddenField ID="hid_creditDnno" runat="server" />
    <asp:HiddenField ID="hid_debitDnno" runat="server" />
    <asp:HiddenField ID="hid_DebitCredit" runat="server" />
    <asp:HiddenField ID="hid_yes" runat="server" />
    <asp:HiddenField ID="hid_No" runat="server" />
    <asp:HiddenField ID="hid_MoreOne" runat="server" />
    <asp:HiddenField ID="hid_yesno" runat="server" />

    <asp:HiddenField ID="hid_agentold" runat="server" />
    <asp:HiddenField ID="hid_supplytoold" runat="server" />

</asp:Content>
