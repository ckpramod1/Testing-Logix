<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Customersupport4AllTask.aspx.cs" Inherits="logix.CRM.Customersupport4AllTask" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
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
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
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



    <script type="text/javascript" language="javascript">
        function pageLoad(sender, args) {

            $(document).ready(function () {
                $("#<%=txt_booking.ClientID %>").autocomplete({
                   source: function (request, response) {
                        <%-- $("#<%=hdn_bookno.ClientID %>").val(0);--%>
                       $.ajax({
                           url: "Customersupport4AllTask.aspx/GetBookingPending",
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
                       $("#<%=txt_booking.ClientID %>").val(i.item.label);
                        $("#<%=txt_booking.ClientID %>").change();
                      <%--  $("#<%=hdn_bookno.ClientID %>").val(i.item.val);--%>

                   },
                   focus: function (event, i) {
                       $("#<%=txt_booking.ClientID %>").val(i.item.label);
                       <%-- $("#<%=hdn_bookno.ClientID %>").val(i.item.val);--%>

                   },
                   close: function (event, i) {
                       $("#<%=txt_booking.ClientID %>").val(i.item.label);
                     <%--   $("#<%=hdn_bookno.ClientID %>").val(i.item.val);--%>

                   },
                   minLength: 1
               });
           });

           $(document).ready(function () {
               $("#<%= txt_customer.ClientID %>").autocomplete({
                   source: function (request, response) {
                       $("#<%=hf_customerid.ClientID %>").val(0);
                       debugger;
                       $.ajax({
                           url: "../Autocomplete/Autocomplete.aspx/GetCustomer",
                           data: "{ 'prefix': '" + request.term + "'}",
                           dataType: "json",
                           type: "POST",
                           contentType: "application/json; charset=utf-8",
                           success: function (data) {

                               response($.map(data.d, function (item) {

                                   return {
                                       label: item.split('~')[0],
                                       val: item.split('~')[1],
                                       add: item.split('~')[2]
                                   }
                               }))

                           },

                           error: function (response) {
                               //alertify.alert(response.responseText);
                           },
                           failure: function (response) {
                               // alertify.alert(response.responseText);
                           }


                       });
                   },
                   select: function (event, i) {
                       $("#<%=txt_customer.ClientID %>").val(i.item.label);
                        $("#<%=txt_customer.ClientID %>").change();


                   },
                   change: function (event, i) {
                       if (i.item) {
                           $("#<%=txt_customer.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hf_customerid.ClientID %>").val(i.item.val);

                       }
                   },

                   focus: function (event, i) {
                       $("#<%=txt_customer.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));

                        $("#<%=hf_customerid.ClientID %>").val(i.item.val);
                   },

                   close: function (event, i) {
                       var result = $("#<%=txt_customer.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txt_customer.ClientID %>").val($.trim(result));
                   },
                   minLength: 1
               });
           });


        }
    </script>








    <link href="../Styles/FIEvents.css" rel="stylesheet" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });


        }
    </script>
    <style type="text/css">
        .hide {
            display: none;
        }

        #logix_CPH_ddlEvents_chzn {
            width: 100% !important;
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


        .EventsDrop {
            width: 19%;
            float: left;
            margin: 0px;
        }

        .LogHeadJobInput label {
            font-size: 11px;
            font-family: sans-serif;
            color: #4e4e4c;
        }

        .MawblCal {
            width: 6%;
            float: right;
            margin: 0px 0% 0px 0px;
        }

        span#logix_CPH_mailcontent {
            width: 1044px;
            margin: 0px auto;
            padding: 10px;
            border: 1px solid #000;
            background-color: #fff;
            z-index: 9999;
            position: absolute;
            left: 14%;
            overflow: auto;
            top: 1%;
            height: 549px;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }


        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        table#logix_CPH_grd {
            margin: 0.5% 0px;
        }

        .Product {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Job {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Booking {
            width: 18%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .event {
            width: 22%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        div#logix_CPH_ddlevent_chzn .chzn-drop {
            height: 500px !important;
        }

        div#logix_CPH_txt_container_chzn {
            width: 100% !important;
        }

        div#logix_CPH_txt_customer_chzn {
            width: 100% !important;
        }

            div#logix_CPH_txt_customer_chzn .chzn-drop {
                height: 639px !important;
            }

        .Container {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Customer {
            width: 28.5%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        div#logix_CPH_txt_booking_chzn .chzn-drop {
            height: 600px !important;
        }

        .ajax__calendar_container {
            padding: 4px;
            cursor: default;
            width: 201px !important;
            font-size: 11px;
            text-align: center;
            font-family: tahoma,verdana,helvetica;
        }

        .ajax__calendar_body {
            height: 165px !important;
            width: 196px !important;
            position: relative;
            overflow: hidden;
            margin: auto;
        }

        .Grid tr:last-child {
            position: relative;
            z-index: 30;
        }

        /*New Design - Buttons*/


        table input[type="submit"], table input[type="button"] {
            padding: 0px 5px !important;
            border: 1px solid #b1b1b1 !important;
            font-weight: 400 !important;
            border-radius: 3px !important;
        }

        div#logix_CPH_ddlevent_chzn {
            width: 100% !important;
        }

        div#logix_CPH_txt_booking_chzn {
            width: 100% !important;
        }

        table#logix_CPH_grd tbody td:nth-child(8) {
            width: 350px !important;
        }

        .ajax__calendar_body {
            height: 209px !important;
            width: 100% !important;
            position: relative;
            overflow: hidden;
            margin: 0px !important;
            margin: auto;
        }

        .ajax__calendar_days, .ajax__calendar_months, .ajax__calendar_years {
            top: 0px;
            left: 0px;
            height: 212px;
            width: 100% !important;
            position: absolute;
            text-align: center;
            margin: auto;
        }

        table#logix_CPH_grd_dt_date2_2_daysTable tbody td {
            background-color: white !important;
            border: 1px solid #fff !important;
        }

        div#logix_CPH_grd_dt_date2_1_container {
            left: -2px !important;
        }

        .ajax__calendar_container TD {
            padding: 0px;
            margin: 0px;
            font-size: 11px;
            background-color: white !important;
        }

        .ajax__calendar_body {
            height: 209px !important;
            width: 100% !important;
            position: relative;
            overflow: hidden;
            margin: 0px !important;
            margin: auto;
        }

        .ajax__calendar_container {
            padding: 4px;
            cursor: default;
            width: 230px !important;
            font-size: 11px;
            text-align: center;
            font-family: tahoma,verdana,helvetica;
        }

        div#logix_CPH_div_iframe .widget-content {
            top: 0 !important;
            padding-top: 10px !important;
        }

        span#logix_CPH_Label5 {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
            
        }

       .Product  .chzn-container .TextField .chzn-container-single .chzn-single {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
            
        }
        .event .chzn-container  .TextField .chzn-container-single .chzn-single {
      -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
      
  }
         .grid button td input .TextField .chzn-container-single .chzn-single {
     -webkit-box-shadow: white !important;
     
 }
         div#logix_CPH_ddl_product_chzn a {
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
    
}

div#logix_CPH_ddlevent_chzn a{
    -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;

}
         .chzn-container {
    font-size: 11px;
    position: relative;
    display: inline-block;
    zoom: 1;
    width: 100% !important;
}
        span#logix_CPH_Label6 {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
            
        }

        input#logix_CPH_txt_job {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
            
        }

        span.normalsize {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
            
        }

        span#logix_CPH_Label2 {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
            
        }

        span#logix_CPH_Label3 {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
            
        }

        span#logix_CPH_Label1 {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
            
        }

        table#logix_CPH_grd thead tr th:nth-child(8) {
            width: 39px !important;
        }

        table#logix_CPH_grd tbody tr td:nth-child(8) {
            width: 39px !important;
        }

        table#logix_CPH_grd thead tr th:nth-child(5) {
            width: 100px !important;
        }

        table#logix_CPH_grd tbody tr td:nth-child(5) {
            width: 100px !important;
        }

      .gridpnl {
    height: 674px !important;
}

        table#logix_CPH_grd th:nth-child(1) {
            width: 20px !important;
        }
        table#logix_CPH_grd tbody tr td:nth-child(5) input {
    width: 100% !important;
}

table#logix_CPH_grd tbody tr td:nth-child(5) {
    width: 290px !important;
}




table#logix_CPH_grd tbody tr td:nth-child(8) input {
    width: 100% !important;
}

table#logix_CPH_grd tbody tr td:nth-child(8) {
    width: 160px !important;
}
 table .TextField .chzn-container-single .chzn-single {
    background: white !important;
    box-shadow: none !important;
    height: 32px !important;
    line-height: 9px !important;
    /* margin: 10px 0px 0px 0px !important; */
    margin: -10px 0px 0px 0px !important;
}
 table.chzn-container {
    font-size: 11px;
    position: relative;
    display: inline-block;
    zoom: 1;
    height: 33px;
    display: inline;
}
 table.TextField .chzn-container .chzn-drop {
    top: 24px !important;
    width: 100% !important;
}




 table .TextField .chzn-container-single .chzn-single span {
    font-size: 14px !important;
    padding: 12px 0 0;
    font-weight: 400 !important;
    color: #000;
    height: 34px;
}

 table .TextField .chzn-container .chzn-drop {
    top: 23px !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


    <!-- Breadcrumbs line End -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">

                    <div>
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lbl_Header" runat="server" Text="Events"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
                        <div class="crumbs">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <li><a href="#" title="">Customer Support</a> </li>
                                <%-- <li><a href="#" id="HeaderLabel1" runat="server"></a></li>--%>
                                <li class="current"><a href="#" title="">Events</a> </li>
                            </ul>
                        </div>
                    </div>

                  </div>
                </div>
                <div class="widget-content">

                    <%-- <div class="btn ico-update">
                            <asp:Button ID="btnUpdate" runat="server" ToolTip="Update" OnClick="btnUpdate_Click" />
                        </div>--%>



                    <div class="FormGroupContent4" style="-webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;  margin-bottom: 12px !important;border-radius: 12px;">
                        <div class="Product">
                            <asp:Label ID="Label5" runat="server" Text="Product"></asp:Label>
                            <asp:DropDownList ID="ddl_product" runat="server" data-placeholder="Product" ToolTip="Product" AutoPostBack="true" Enabled="false" CssClass="chzn-select" OnSelectedIndexChanged="ddl_product_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                                <asp:ListItem Value="AE" Text="AIR EXPORTS"></asp:ListItem>
                                <asp:ListItem Value="AI" Text="AIR IMPORTS"></asp:ListItem>
                                <asp:ListItem Value="FE" Text="OCEAN EXPORTS"></asp:ListItem>
                                <asp:ListItem Value="FI" Text="OCEAN IMPORTS"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="event">
                            <asp:Label ID="Label6" runat="server" Text="Task"></asp:Label>
                            <asp:DropDownList ID="ddlevent" runat="server" data-placeholder="Event" ToolTip="Event" AutoPostBack="true" CssClass="chzn-select" OnSelectedIndexChanged="ddlevent_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="Job">
                            <asp:Label ID="Label32" runat="server" Text="Job #"></asp:Label>
                            <asp:TextBox ID="txt_job" runat="server" CssClass="form-control" ToolTip="Job #" OnTextChanged="txt_job_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div class="Booking">
                            <asp:Label ID="Label2" runat="server" Text="Booking #" Visible="false"></asp:Label>

                            <asp:DropDownList ID="txt_booking" runat="server" CssClass="chzn-select" ToolTip="Booking #" AutoPostBack="true" Visible="false" OnSelectedIndexChanged="txt_booking_TextChanged">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>

                            </asp:DropDownList>
                        </div>
                        <div class="Container">
                            <asp:Label ID="Label3" runat="server" Text="Container #" Visible="false"></asp:Label>
                            <asp:DropDownList ID="txt_container" runat="server" CssClass="chzn-select" ToolTip="Container #" AutoPostBack="true" Visible="false" OnSelectedIndexChanged="txt_bl_TextChanged">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>

                            </asp:DropDownList>
                        </div>
                        <div class="Customer">
                            <asp:Label ID="Label1" runat="server" Text="Customer" Visible="false"></asp:Label>
                            <asp:DropDownList ID="txt_customer" runat="server" CssClass="chzn-select" ToolTip="Customer" AutoPostBack="true" Visible="false" OnSelectedIndexChanged="txt_customer_TextChanged">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>

                            </asp:DropDownList>
                        </div>

                        <div class="">
                            <div class="right_btn">
                                <%--<div class="btn ico-update" id="visblehid">
                                <asp:Button ID="btn_update" runat="server" ToolTip="Update" OnClick="btn_update_Click" />
                            </div>--%>
                                <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" ToolTip="Cancel/Back" Visible="false" OnClick="btn_Cancel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="gridpnl">
                            <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader" Width="100%"
                                ShowHeaderWhenEmpty="True" EnableTheming="False" OnPreRender="grd_PreRender">


                                <Columns>
                                    <asp:TemplateField HeaderText="Sl #">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <HeaderStyle Wrap="false" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="bookingno" HeaderText="Booking #">
                                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="blno" HeaderText="BL #">
                                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="containerno" HeaderText="Container #" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="jobno" HeaderText="Job #">
                                        <ItemStyle HorizontalAlign="Center" Width="25px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Last Event">
                                        <HeaderStyle Wrap="false" />
                                        <ItemTemplate>

                                            <asp:TextBox ID="ddl_LastEvent" runat="server" AutoPostBack="true" Text='<%#Eval("lastevent")%>' ToolTip='<%#Eval("lastevent")%>'></asp:TextBox>


                                        </ItemTemplate>
                                        <ItemStyle Width="100px" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="lasteventupdatedon" HeaderText="Updated On" DataFormatString="{0:dd/MM/yyyy}">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Current Event">
                                        <HeaderStyle Wrap="false" />
                                       
                                        <ItemTemplate>
                                             
                                            <asp:DropDownList ID="ddl_NextEvent" runat="server" CssClass="chzn-select"  data-placeholder="Current Event" ToolTip="Next Event" AutoPostBack="true" OnCellContentClick="Grd_TDS_CellContentClick" OnSelectedIndexChanged="ddl_NextEvent_SelectedIndexChanged">

                                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                                                <%-- <asp:ListItem Value="1" Text="Booking"></asp:ListItem>
                                                 <asp:ListItem Value="2" Text="Container Gate Out"></asp:ListItem>
                                                 <asp:ListItem Value="3" Text="Stuffing"></asp:ListItem>
                                                 <asp:ListItem Value="4" Text="Container Port In"></asp:ListItem>
                                                 <asp:ListItem Value="5" Text="Sailing"></asp:ListItem>
                                                   <asp:ListItem Value="6" Text="BL Released On"></asp:ListItem>
                                                 
                                                 <asp:ListItem Value="7" Text="T/S (If Any)"></asp:ListItem>
                                                   <asp:ListItem Value="8" Text="CAN Sent On"></asp:ListItem>
                                                 <asp:ListItem Value="9" Text="Arrival"></asp:ListItem>
                                                 <asp:ListItem Value="10" Text="Container Port Out"></asp:ListItem>
                                                 <asp:ListItem Value="11" Text="Destuffing"></asp:ListItem>
                                                   <asp:ListItem Value="12" Text="DO Issued On"></asp:ListItem>
                                                 <asp:ListItem Value="13" Text="Container Gate In"></asp:ListItem>
                                                --%>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle Width="150px" />
                                    </asp:TemplateField>



                                    <asp:TemplateField HeaderText="Occured On">
                                        <ItemTemplate>
                                            <asp:TextBox ID="updateddt" runat="server" AutoPostBack="true" Text='<%#Eval("occuredon")%>' ToolTip='<%#Eval("occuredon")%>'></asp:TextBox>
                                            <asp:CalendarExtender ID="dt_date2" runat="server" TargetControlID="updateddt"
                                                Format="dd/MM/yyyy"></asp:CalendarExtender>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" HorizontalAlign="Right" Width="100px" />
                                    </asp:TemplateField>



                                    <asp:TemplateField HeaderText="">
                                        <HeaderStyle Width="20px" />
                                        <ItemTemplate>
                                            <div class="btn ico-update" id="btn_send1" runat="server">
                                                <asp:Button ID="btn_send" runat="server" Text="Send" ToolTip="Update" TabIndex="41" OnClick="btnSave_Click" />
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <HeaderStyle Width="20px" />
                                        <ItemTemplate>
                                            <div class="btn ico-send-mail" id="btn_sendMail" runat="server">
                                                <asp:Button ID="btn_mail" runat="server" Text="Send" ToolTip="mail" TabIndex="41" OnClick="btn_mail_Click" />
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>



                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle CssClass="GrdRow" />
                            </asp:GridView>

                        </div>
                    </div>




                    <div class="FormGroupContent" style="display: none;">
                        <asp:GridView ID="grdStuff" runat="server" AutoGenerateColumns="False" Width="100%" HorizontalAlign="Left" ShowHeaderWhenEmpty="true"
                            CssClass="Grid FixedHeader">
                            <Columns>

                                <asp:BoundField DataField="containerno" HeaderText="Container#">
                                    <ItemStyle HorizontalAlign="Center" Width="250px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="sizetype" HeaderText="Size">
                                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="sealno" HeaderText="Seal #">
                                    <ItemStyle HorizontalAlign="Center" Width="250px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="destuff" HeaderText="Destuff" DataFormatString="{0:dd/MM/yyyy}">
                                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                                </asp:BoundField>

                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                            <PagerStyle CssClass="GridviewScrollPager" />
                        </asp:GridView>
                    </div>


                    <div class="FormGroupContent4" style="display: none;">
                        <div class="CargoPick">
                            <asp:TextBox ID="txtCargopickedon" runat="server" placeholder="CarcoPickedOn" ToolTip="CarcoPickedOn" CssClass="form-control"></asp:TextBox>
                            <asp:CalendarExtender ID="dtvalidity" runat="server" TargetControlID="txtCargopickedon" Format="dd/MM/yyyy"></asp:CalendarExtender>

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
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
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
                    <asp:Label ID="Label4" runat="server"></asp:Label>

                    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
                        DropShadow="false" TargetControlID="Label4" CancelControlID="Image2" BehaviorID="Test1">
                    </asp:ModalPopupExtender>
                </div>
            </div>
            <%--  <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_dtdate" Format="dd/MM/yyyy"></asp:CalendarExtender>--%>
        </div>
    </div>

    <asp:Label ID="mailcontent" runat="server" Visible="false"></asp:Label>
    <div>
        <asp:HiddenField ID="hf_jobno" runat="server" />
        <asp:HiddenField ID="hf_blno" runat="server" />
        <asp:HiddenField ID="hf_cfs" runat="server" />
        <asp:HiddenField ID="hf_docno" runat="server" />
        <asp:HiddenField ID="hf_customerid" runat="server" />

        <asp:HiddenField ID="hid_date" runat="server" />
        <asp:HiddenField ID="hid_send" runat="server" />
        <asp:HiddenField ID="hid_task" runat="server" />
        <asp:HiddenField ID="hid_taskid" runat="server" />
    </div>

</asp:Content>
