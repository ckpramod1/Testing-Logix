<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Customer_List.aspx.cs" Inherits="logix.Maintenance.Customer_List" %>

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

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

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

    <link href="../Styles/Customerlist.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function pageLoad(sender, args) {

            <%--$(document).ready(function () {
                $('#<%=grd.ClientID%>').gridviewScroll({
                       width: 729,
                       height: 400,
                       arrowsize: 30,

                       varrowtopimg: "../images/arrowvt.png",
                       varrowbottomimg: "../images/arrowvb.png",
                       harrowleftimg: "../images/arrowhl.png",
                       harrowrightimg: "../images/arrowhr.png"
                   });
               });--%>


            $(document).ready(function () {
                $("#<%=txt_Salesperson.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_employeeid.ClientID %>").val(0);
                        $.ajax({
                            url: "Customer_List.aspx/GetEmployeename",
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
                        $("#<%=hf_employeeid.ClientID %>").val(i.item.val);
                        $("#<%=txt_Salesperson.ClientID %>").change();
                    },

                    focus: function (event, i) {
                        $("#<%=txt_Salesperson.ClientID %>").val(i.item.value);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_Salesperson.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_Salesperson.ClientID %>").val($.trim(result));

                    },

                    minLength: 1
                });
            });
        }
    </script>
    <script type="text/javascript">
        function TxtFocus() {

            var el = $("#<%=txt_Customer.ClientID %>").get(0);
             var elemLen = el.value.length;
             el.selectionStart = elemLen;
             el.selectionEnd = elemLen;
             el.focus();
         }

         function GetDetail() {
             $.ajax({
                 type: "POST",
                 url: "../Maintenance/Customer_List.aspx/GetBanName",
                 data: '{Prefix: "' + $("#<%=txt_Customer.ClientID %>").val() + '" }',
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
        .SalesTxtBox {
            width: 49.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CustomerTxtBox {
            width: 50%;
            float: left;
            margin: 0px 0px 0px 0px;
        }
        .widget.box{
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
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lblheader" runat="server" Text="Customer List"></asp:Label></h4>

                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li><a href="#" title="">Maintenance</a> </li>
                            <li class="current"><a href="#" title="">Customer List</a> </li>
                        </ul>
                    </div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4 boxmodal">
                        <div class="SalesTxtBox">
                            <asp:TextBox ID="txt_Salesperson" runat="server" CssClass="form-control" ToolTip="Sales Person" placeholder=" Sales Person" AutoPostBack="true" BorderColor="#999997"
                                MaxLength="50" OnTextChanged="txt_Salesperson_TextChanged" TabIndex="1"></asp:TextBox>
                        </div>

                        <div class="CustomerTxtBox">
                            <asp:TextBox ID="txt_Customer" runat="server" ToolTip="Customer" placeholder=" Customer" CssClass="form-control" onkeyup="GetDetail();" MaxLength="100" TabIndex="2"></asp:TextBox></div>
                    </div>

                    <div class="FormGroupContent4">
                        <div class="right_btn">
                            <div class="btn ico-update">
                                <asp:Button ID="btn_update" runat="server" ToolTip="Update" OnClick="btn_update_Click" TabIndex="3" /></div>
                            <div class="btn ico-cancel" id="btn_back1" runat="server">
                                <asp:Button ID="btn_back" runat="server" ToolTip="Cancel" OnClick="btn_back_Click" TabIndex="4" />
                                <asp:Button ID="btn_search" runat="server" Text="" Style="display: none;" OnClick="btn_search_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel ID="pnl_grd" runat="server" CssClass="panel_20 MB0" ScrollBars="Vertical">
                            <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader"
                                DataKeyNames="customerid" OnSelectedIndexChanged="grd_SelectedIndexChanged" ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:BoundField DataField="customerid" HeaderText="customerid" Visible="false" />
                                    <asp:BoundField DataField="customername" HeaderText="Customer" />
                                    <asp:BoundField DataField="address" HeaderText="Address" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                                    <asp:BoundField DataField="portname" HeaderText="City" />
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="grdblselect" runat="server" Width="60px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>

                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <asp:HiddenField ID="hf_employeeid" runat="server" />

</asp:Content>
