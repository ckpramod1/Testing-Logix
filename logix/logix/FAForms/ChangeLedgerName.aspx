<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="ChangeLedgerName.aspx.cs" Inherits="logix.FAForm.ChangeLedgerName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />

    <!--=== JavaScript ===-->

    <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>
 

      <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>

    <!-- App -->

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


    <link href="../CSS/Finance.css" rel="stylesheet" />






    <link href="../Styles/ChangeLedgerName.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

      <script type="text/javascript">
          function dropdownButton() {
              $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
          }
    </script>
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txt_customer.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_custid.ClientID %>").val(0);
                        $.ajax({
                            url: "../FAForms/OutStanding.aspx/Getcustomer",
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

                    select: function (e, i) {
                        $("#<%=hid_custid.ClientID %>").val(i.item.val);
                        $("#<%=txt_customer.ClientID %>").change();
                    },
                    change: function (e, i) {
                        $("#<%=hid_custid.ClientID %>").val(i.item.val);
                        var result = (i.item.label).toString().split(',')[0];
                        $("#<%=txt_customer.ClientID %>").val($.trim(result));
                    },
                    focus: function (e, i) {
                        $("#<%=hid_custid.ClientID %>").val(i.item.val);
                        var result = (i.item.label).toString().split(',')[0];
                        $("#<%=txt_customer.ClientID %>").val($.trim(result));
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_customer.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_customer.ClientID %>").val($.trim(result));

                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_location.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_cityid.ClientID %>").val(0);
                        $.ajax({
                            url: "../AutoCompleteClass/AutoCompleteClass.aspx/GetPort",
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

                    select: function (e, i) {
                        $("#<%=hid_cityid.ClientID %>").val(i.item.val);
                        $("#<%=txt_location.ClientID %>").change();
                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=hid_cityid.ClientID %>").val(i.item.val);
                            $("#<%=txt_location.ClientID %>").val(i.item.label);
                        }
                    },
                    focus: function (e, i) {
                        $("#<%=hid_cityid.ClientID %>").val(i.item.val);
                        $("#<%=txt_location.ClientID %>").val(i.item.label);
                    },
                    close: function (e, i) {
                        if (i.item) {
                            $("#<%=hid_cityid.ClientID %>").val(i.item.val);
                            $("#<%=txt_location.ClientID %>").val(i.item.label);
                        }
                    },
                    minLength: 1
                });
            });


        }

    </script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

<%--    <script type="text/javascript" language="javascript" >
         function pageLoad(sender, args) {
             $(document).ready(function () {
                 
             });

         }
      </script>--%>
       

   
    <style>
        .Address {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;
        }
        .Customer{
      width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

   
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">

                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text="Change LedgerName"></asp:Label></h4>
                   
      <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#">Home</a> </li>
            <li><a href="#">Utility</a> </li>
            <li><a href="#" title="">Change LedgerName</a> </li>
            <li>
                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
        </ul>
    </div>
                        </div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4">
                        <div class="Customer">
                            <asp:Label ID="lbl_customer" runat="server" Text="Customer Name"></asp:Label>


                            <asp:TextBox ID="txt_customer" runat="server" placeholder="Customer Name" ToolTip="Customer Name" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_customer_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">

                        <div class="ChangeCusDrop">
                            <asp:Label ID="lbl_type" runat="server" Text="Customer Type"></asp:Label>

                            <asp:DropDownList ID="ddl_type" Height="23px" runat="server" CssClass="chzn-select" placeholder="Customer Type" ToolTip="Customer Type">
                                <asp:ListItem>Customer Type</asp:ListItem>
                                <asp:ListItem Value="P">Agent / Principal</asp:ListItem>
                                <asp:ListItem Value="C">Customer</asp:ListItem>
                                <%--<asp:ListItem Value="C">Carrier / Airliner / MLO / Freight Forwarder</asp:ListItem>
                        <asp:ListItem Value="C">Counter Part</asp:ListItem>
                        <asp:ListItem Value="C">Consignee</asp:ListItem>
                        <asp:ListItem Value="C">CFS</asp:ListItem>
                        <asp:ListItem Value="C">CHA / CNF</asp:ListItem>
                        <asp:ListItem Value="C">Notify Party</asp:ListItem>
                        <asp:ListItem Value="C">Shipper</asp:ListItem>
                        <asp:ListItem Value="C">Transporter</asp:ListItem>
                        <asp:ListItem Value="C">Warehouse</asp:ListItem>
                        <asp:ListItem Value="C">Others</asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>

                        <div class="ChangeCusLocation">
                            <asp:Label ID="lbl_location" runat="server" Text="Location"></asp:Label>
                            <asp:TextBox ID="txt_location" runat="server" CssClass="form-control" placeholder="Location" ToolTip="Location" AutoPostBack="True"
                                OnTextChanged="txt_location_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Address">
                            <asp:Label ID="lbl_address" runat="server" Text="Address"></asp:Label>


                            <asp:TextBox ID="txt_address" runat="server" TextMode="MultiLine" Height="40px" Width="100%" CssClass="form-control" placeholder="" ToolTip="Address"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                      
                        <div class="CusCity">
                            <asp:Label ID="lbl_city" runat="server" Text="City"></asp:Label>
                            <asp:TextBox ID="txt_city" runat="server" ReadOnly="True" placeholder="City" ToolTip="City" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="CusCountry">
                            <asp:Label ID="Label1" runat="server" Text="Country"></asp:Label>

                            <asp:TextBox ID="txt_country" runat="server" ReadOnly="True" placeholder="Country" ToolTip="Country" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="CusZip">
                                <asp:Label ID="lbl_zip" runat="server" Text="Zip"></asp:Label>
                          
                            <asp:TextBox ID="txt_zip" runat="server" placeholder="Zip" ToolTip="Zip" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                     
                        <div class="CusPhone1">
                            <asp:Label ID="lbl_phone" runat="server" Text="Phone #"></asp:Label>
                            <asp:TextBox ID="txt_phone" runat="server" ReadOnly="True" Placeholder="Phone #" ToolTip="Phone #" CssClass="form-control"></asp:TextBox>
                        </div>
                      
                        <div class="CusFax">
                            <asp:Label ID="lbl_fax" runat="server" Text="Fax"></asp:Label>
                            <asp:TextBox ID="txt_fax" runat="server" ReadOnly="True" placeholder="Fax" ToolTip="Fax" CssClass="form-control"></asp:TextBox>
                        </div>
                      
                        <div class="CusLedger">
                            <asp:Label ID="lbl_ledgername" runat="server" Text="LedgerName"></asp:Label>
                            <asp:TextBox ID="txt_ledgername" runat="server" placeholder="Ledger Name" ToolTip="Ledger Name" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="btn-ctrl1">
                            <div class="btn ico-update">
                                <asp:Button ID="btn_Update" runat="server" ToolTip="Update" OnClick="btn_Update_Click" Enabled="False" />
                            </div>
                            <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                <asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>




    <asp:HiddenField ID="hid_custid" runat="server" />
    <asp:HiddenField ID="hid_cityid" runat="server" />
    <asp:HiddenField ID="hid_ledgername" runat="server" />
</asp:Content>
