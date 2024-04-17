<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Salespersonchanged.aspx.cs" EnableEventValidation="false" Inherits="logix.Sales.Salespersonchanged" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
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
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

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

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {


            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }


    </script>



    <style type="text/css">
        .div_main {
            width: 100%;
            float: left;
        }

        .div_drop {
            width: 20%;
            float: left;
            margin-left: 1%;
            margin-top: 1%;
        }

        .div_drop1 {
            width: 20%;
            float: left;
            margin-left: 1%;
            margin-top: 1%;
        }

        .txt1 {
            width: 20%;
            float: left;
            margin-left: 1%;
            margin-top: 1%;
        }

        .txt2 {
            width: 20%;
            float: left;
            margin-left: 1%;
            margin-top: 1%;
        }

        .btn {
            /*width:10%;
             float:left;
             margin-left:1%;*/
        }

        .Product {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Branch {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .JobTxtBox {
            width: 30%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .SalesPerson {
            width:29%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .div_confirm {
            /*Border:1px solid red;*/
            width: 100%;
            float: left;
            margin-left: 1%;
            margin-top: 0%;
        }

        .Pnl {
            background-color: #fff;
            border-color: #b1b1b1;
            border-style: solid;
            border-width: 1px;
            text-align: center;
            font-size: 12px;
            padding: 5px;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }
  
         
/*New Design - Buttons*/


 
.widget.box .widget-content {
    top: 0px !important;
    padding-top: 65px !important;
} 
 .SalesPerson1 {
    float: left;
    width: 38%;
    margin: 0px 0px 0px 0px;
}
 .FixedButtonsss {
    width: 99%!important;
}
    </style>
    <script type="text/javascript">
        function pageLoad() {
            $(document).ready(function () {
                $("#<%=txt_salesperson.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../Sales/Salespersonchanged.aspx/GetSalesPerson",
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
                                // alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //  alertify.alert(response.responseText);
                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txt_salesperson.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_salesperson.ClientID %>").val(i.item.address);
                        $("#<%=hdn_salesid.ClientID %>").val(i.item.val);
                        $("#<%=txt_salesperson.ClientID %>").change();
                    },
                    focus: function (event, i) {
                        $("#<%=txt_salesperson.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txt_salesperson.ClientID %>").val(i.item.address);
                        $("#<%=hdn_salesid.ClientID %>").val(i.item.val);
                        $("#<%=txt_salesperson.ClientID %>").val($.trim(result));
                        $("#<%=txt_salesperson.ClientID %>").change();

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_salesperson.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=txt_salesperson.ClientID %>").val(i.item.address);
                            $("#<%=hdn_salesid.ClientID %>").val(i.item.val);
                            $("#<%=txt_salesperson.ClientID %>").change();
                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_salesperson.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_salesperson.ClientID %>").val($.trim(result));
                    },
                    minLength: 1

                });
            });
            $(document).ready(function () {

                $("#<%=txt_blno.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $.ajax({
                            url: "../Sales/Salespersonchanged.aspx/getlikebl",
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
                        $("#<%=txt_blno.ClientID %>").val(i.item.label);
                        $("#<%=txt_blno.ClientID %>").change();
                        $("#<%=hiddenid.ClientID %>").val(i.item.val);

                    },
                    change: function (event, i) {
                        $("#<%=txt_blno.ClientID %>").val(i.item.value);
                        $("#<%=hiddenid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_blno.ClientID %>").val(i.item.value);
                        $("#<%=hiddenid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_blno.ClientID %>").val(i.item.value);
                        $("#<%=hiddenid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


    <!-- /Breadcrumbs line -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">

                <div class="widget-header">
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="headerlbl" runat="server" Text="AmendSalesPerson"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs" id="crumbsid" runat="server">
                        <ul id="breadcrumbs" class="breadcrumb" runat="server">
                            <li style="display:none"><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li style="display:none"><a href="#" title="" id="headerlabel2" runat="server">Documentation</a> </li>
                            <li style="display:none"><a href="#" title="" runat="server" id="HeaderLabel1">Ocean Exports</a> </li>
                            <li class="current"><a href="#" title="">AmendSalesPerson</a> </li>
                        </ul>
                    </div>
                </div>
                <div class="widget-content">
                    <div class="FixedButtons">
                         <div class="right_btn">

                            <div class="btn ico-update">
                                <asp:Button ID="btn_save" runat="server" ToolTip="Update" OnClick="btn_save_Click" />
                            </div>
                            <div class="btn ico-cancel" id="lbl_back" runat="server">
                                <asp:Button ID="btn_back" runat="server" ToolTip="Cancel"  OnClick="btn_back_Click" />
                            </div>

                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">

                        <div class="Product" style="display: none">
                            <asp:DropDownList ID="ddl_product" CssClass="chzn-select" AutoPostBack="true" runat="server" ToolTip="Product" data-placeholder="Product">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="Branch" style="display: none">
                            <asp:DropDownList ID="ddl_branch" CssClass="chzn-select" runat="server" ToolTip="Branch" data-placeholder="Branch">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="FormGroupContent4">
                        <div class="SalesPerson" >
                            <asp:TextBox ID="txt_blno" runat="server" CssClass="form-control" ToolTip="Booking #" placeholder="Booking #" AutoPostBack="true" OnTextChanged="txt_blno_TextChanged"></asp:TextBox></div>
                            
                        <div class="JobTxtBox">
                            <asp:TextBox ID="txt_oldsalesperson" CssClass="form-control" runat="server" ToolTip="Old Sales Person Name" placeholder="Old Sales Person Name"></asp:TextBox></div>
                        <div class="SalesPerson1">
                            <asp:TextBox ID="txt_salesperson" runat="server" CssClass="form-control" ToolTip="Salesperson" placeholder="Sales Person"></asp:TextBox></div>
                        <%--<div class="SalesPerson"><asp:TextBox  ID="txt_blno"  runat="server"  CssClass="form-control" ToolTip="Booking#"  placeholder="Booking#"></asp:TextBox></div>--%>
                            </div> 
                       
                    <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl" Style="display: none;">
                        <br />
                        <div style="font-size: 10pt"><b>Do You Want Change  Salesperson </b></div>
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
                    <ajaxtoolkit:ModalPopupExtender ID="PopUpService" runat="server" PopupControlID="Panel_Service" TargetControlID="Label1">
                    </ajaxtoolkit:ModalPopupExtender>
                    <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>

                </div>
            </div>
        </div>
    </div>




    <asp:HiddenField ID="hdn_salesid" runat="server" />
    <asp:HiddenField ID="hiddenid" runat="server" />

    <div class="div_main">
        <div class="div_drop">
        </div>
        <div class="div_drop1">
        </div>
        <div class="txt1">
        </div>
        <div class="txt1">
        </div>

    </div>
</asp:Content>
