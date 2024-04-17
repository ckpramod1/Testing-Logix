<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FIEBLInfo.aspx.cs" Inherits="logix.FIEBLInfo" EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>logix</title>
    <link href="Style/GrdHead.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/Calendar.js"></script>
    <!-- Bootstrap -->
    <link href="Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Theme/bootstrap/css/bootstrap-select.css">
    <link rel="icon" type="image/png" sizes="36x21" href="Theme/assets/img/favicon.png">
    <link href="Theme/assets/css/new_style.css" rel="stylesheet" />
        <link href="Theme/assets/css/buttonicon.css" rel="stylesheet" />

    <!-- Theme -->

    <link href="Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="Theme/assets/css/fontawesome/font-awesome.min.css">
    
    <link href="Theme/assets/css/cscss.css" rel="stylesheet" />
    <link href="Styles/ControlStyle2.css" rel="stylesheet" />
    <!--=== JavaScript ===-->

   <script type="text/javascript" src="Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>



       <!--=== JavaScript ===-->

    <script type="text/javascript" src="Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/libs/lodash.compat.min.js"></script>

    <!-- Smartphone Touch Events -->
    <script type="text/javascript" src="Theme/Content/plugins/touchpunch/jquery.ui.touch-punch.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/event.swipe/jquery.event.move.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/event.swipe/jquery.event.swipe.js"></script>

    <!-- General -->
    <script type="text/javascript" src="Theme/Content/assets/js/libs/breakpoints.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/respond/respond.min.js"></script>
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="Theme/Content/plugins/cookie/jquery.cookie.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- Page specific plugins -->
    <!-- Charts -->
    <script type="text/javascript" src="Theme/Content/plugins/sparkline/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/blockui/jquery.blockUI.min.js"></script>

    <!-- Forms -->
    <script type="text/javascript" src="Theme/Content/plugins/typeahead/typeahead.min.js"></script>
    <!-- AutoComplete -->
    <script type="text/javascript" src="Theme/Content/plugins/autosize/jquery.autosize.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/inputlimiter/jquery.inputlimiter.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/uniform/jquery.uniform.min.js"></script>
    <!-- Styled radio and checkboxes -->
    <script type="text/javascript" src="Theme/Content/plugins/tagsinput/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/select2/select2.min.js"></script>
    <!-- Styled select boxes -->
    <script type="text/javascript" src="Theme/Content/plugins/fileinput/fileinput.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/duallistbox/jquery.duallistbox.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-inputmask/jquery.inputmask.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-wysihtml5/wysihtml5.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-multiselect/bootstrap-multiselect.min.js"></script>

    <!-- Globalize -->
    <script type="text/javascript" src="Theme/Content/plugins/globalize/globalize.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/globalize/cultures/globalize.culture.de-DE.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/globalize/cultures/globalize.culture.ja-JP.js"></script>

    <!-- App -->
    <script type="text/javascript" src="Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/plugins.form-components.js"></script>

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

    
  




     <link href="Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
   


    <link href="Style/Booking.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/Calendar.js"></script>
    <script type="text/javascript" src="Scripts/Validation.js"></script>







    

    <%-- <script type="text/javascript">
             function pageLoad(sender, args) {
               
                
                 $(document).ready(function () {
                     debugger;
                     $("#<%#txt_customer.ClientID %>").autocomplete({
                        
                     source: function (request, response) {
                      
                         $("#<%#Hiddenshipper.ClientID %>").val(0);
                         debugger;
                          $.ajax({
                              url: "FIEBLInfo.aspx/GetCustomer",
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
                          $("#<%#txt_customer.ClientID %>").val(i.item.label);
                          $("#<%#txt_customer.ClientID%>").change();


                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%#txt_customer.ClientID%>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%#Hiddenshipper.ClientID%>").val(i.item.val);

                    }
                },

                    focus: function (event, i) {
                        $("#<%#txt_customer.ClientID%>").val($.trim(i.item.label.split(' ,')[0]));

                        $("#<%#Hiddenshipper.ClientID%>").val(i.item.val);


                },

                    close: function (event, i) {
                        var result = $("#<%#txt_customer.ClientID%>").val().toString().split(' ,')[0];
                        $("#<%#txt_customer.ClientID%>").val($.trim(result));
                },
                    minLength: 1
                });
            });


    }


    </script>--%>
   



    <style type="text/css">
        .divframe {
            border-left: 1px solid black;
            border-right: 1px solid black;
            width: 100%;
            height: 100%;
            float: left;
        }

        .div_BLPrint {
            float: right;
            margin-left: 48%;
        }

        .div_close_voucher {
            cursor: pointer;
            float: right;
        }


        .modalBackground {
            background-color: transparent;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .modalPopupss {
            background-color: #FFFFFF;
            /*border-width:1px;*/
            /*border-style:solid; 
            border-color:#CCCCCC;*/
            width: 1334px;
            Height: 533px;
            margin-top: -2.5%;
            margin-left: -0.2%;
            /*padding:1px;
            margin-left:-4%;
            display:none;*/
        }
        /*.divRoated
        {
           width: 1042px;
            Height:303px;            
            border:3px solid black;
            margin-left:-0.5%;
            margin-top:-0.5%;
        }*/
        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-left: 96.3%;
            margin-top: -1%;
            /*border:1px solid blue;*/
            border-radius: 90px 90px 90px 90px;
        }

        .Gridpnl {
            width: 1284px;
            Height: 402px;
            margin-bottom: 0.5%;
            margin-left: 0%;
            /*margin-left:0.2%;
            overflow-y :scroll;*/
            overflow: auto;
        }

        .frames {
            width: 99.5%;
            height: 100%;
        }




        .btn-excel1 {
            /* background-color: #445266;
    color: #ffffff;*/
            z-index: 2;
            border-radius: 0px;
        }



        #popupfro {
            left: 8px !important;
            top: 57px !important;
        }

        #Pln_OFE {
            width: 1003px;
            overflow: auto;
            height: 308px;
            margin-bottom: 5px;
            background-color:#fff;
        }

        #pnlOIE {
            width: 1003px;
            overflow: auto;
            height: 278px;
            margin-bottom: 5px;
        }

        #pnlAIE {
            width: 1003px;
            overflow: auto;
            height: 310px;
            margin-bottom: 5px;
        }




        body {
            background-color: transparent !important;
            color: #000 !important;
        }

        .breadcrumb {
            padding: 0px 15px 0px 0px;
        }

        .crumbs {
            background-color: transparent !important;
            border-top: 0px solid #d9d9d9;
            border-bottom: 0px solid #fff;
            height: 20px;
        }

            .crumbs li {
                list-style:none;
            }


        .row {
            background-color: transparent !important;
        }

        .breadcrumb > li + li::before {
            color: #fff;
        }

        .crumbs .breadcrumb li i {
            color: #fff;
        }

        .widget.box .widget-content {
            background-color: transparent;
        }








        .widget.box {
            height: 384px;
        }


        .div_Column {
            width: 114px;
            overflow: hidden;
            white-space: nowrap;
            text-overflow: ellipsis;
        }

        .div_ColumnBL {
            width: 76px;
            overflow: hidden;
            white-space: nowrap;
            text-overflow: ellipsis;
        }

        .div_ColumnBL1 {
            width: 58px;
            overflow: hidden;
            white-space: nowrap;
            text-overflow: ellipsis;
        }

        .div_ColumnBLP {
            width: 114px;
            overflow: hidden;
            white-space: nowrap;
            text-overflow: ellipsis;
        }


        .div_ColumnS {
            width: 190px;
            overflow: hidden;
            white-space: nowrap;
            text-overflow: ellipsis;
        }

        .div_ColumnC {
            width: 35px;
            overflow: hidden;
            white-space: nowrap;
            text-overflow: ellipsis;
        }
        .row {
            height:393px!important;
            overflow:hidden!important;
        }

        .SearchTxtbox1 {width:25%; float:left; margin:0px 0.5% 0px 0px;
}
    </style>

   <%-- <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>--%>

    
   



   


</head>
<body>
    <form id="form1" runat="server">

             <script type="text/javascript">
                 function pageLoad(sender, args) {
               
                     $(document).ready(function () {

                         $("#<%= txt_customer.ClientID %>").autocomplete({
                             
                             source: function (request, response) {
                                 $("#<%=Hiddenshipper.ClientID %>").val(0);
                                 $.ajax({
                                     url: "FIEBLInfo.aspx/GetCustomer",
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
                                     $("#<%=Hiddenshipper.ClientID %>").val(i.item.val);

                                 }
                             },

                             focus: function (event, i) {
                                 $("#<%=txt_customer.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));

                                 $("#<%=Hiddenshipper.ClientID %>").val(i.item.val);


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


        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="360000">
        </asp:ScriptManager>

       <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/green_indicator.gif"></asp:Image>Loading....
            Please wait...
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <!-- Breadcrumbs line -->
                <div class="crumbs">
       <%--             <ul id="breadcrumbs" class="breadcrumb">
                        <li><i class="icon-home"></i>Home </li>

                        <li>Shipment Details </li>--%>
                        <li class="current" id="lbl" runat="server">Ocean Exports </li>
                    </ul>
                </div>

                <div >
                    <div class="col-md-12  maindiv">

                        <div class="widget box">

                            <div class="widget-header" style="display: none;">
                                <h4><i class="icon-umbrella"></i>
                                    <asp:Label ID="LBLTitle" runat="server"></asp:Label></h4>
                            </div>
                            <div class="widget-content">
                                <div class="FormGroupContent4">
                                    <div class="SearchByTxt">
                                        <asp:Label ID="Label4" runat="server" Text="Search By"></asp:Label>
                                    </div>
                                    <div class="SearchDrop">
                                        <asp:DropDownList ID="ddl_find" runat="server" CssClass="chzn-select" Height="24px" AutoPostBack="true" OnSelectedIndexChanged="ddl_find_SelectedIndexChanged" > <%--AutoPostBack="true" OnSelectedIndexChanged="ddl_find_SelectedIndexChanged"--%>
                                            <asp:ListItem>BL #</asp:ListItem>
                                            <asp:ListItem>Booking #</asp:ListItem>
                                            <asp:ListItem>Commercial Invoice</asp:ListItem>
                                               <asp:ListItem>Shipper</asp:ListItem>
                                            <asp:ListItem>Consignee</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <div class="SearchTxtbox">
                                        <asp:TextBox ID="txtBLNo" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                       <div class="SearchTxtbox1">
                                        

                                           <asp:TextBox ID="txt_customer" runat="server" CssClass="form-control" AutoPostBack="true" TabIndex="10" placeholder="Shipper" OnTextChanged="txt_customer_TextChanged" Visible="false">

                                           </asp:TextBox>
                                    </div>
                                    <div class="FromTxt">
                                        <asp:Label ID="Label1" runat="server" Text="From"></asp:Label>
                                    </div>
                                    <div class="FromDate">
                                        <asp:TextBox ID="dtFrom" runat="server" CssClass="form-control"></asp:TextBox>
                                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtFrom"
                                            Format="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>
                                    </div>
                                    <%-- <div class="CalImg"><asp:Image ID="ImgFrm" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/Calender.jpg" /></div>--%>
                                    <div class="ToTxt">
                                        <asp:Label ID="Label2" runat="server" Text="To"></asp:Label>
                                    </div>
                                    <div class="Todate">
                                        <asp:TextBox ID="dtTo" runat="server" CssClass="form-control"></asp:TextBox>
                                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtTo"
                                            Format="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>
                                    </div>
                                    <div class="right_btn MT0">
                                        <div class="btn btn-find">
                                            <asp:Button ID="BtnSelect" runat="server" ToolTip="Find" OnClick="BtnSelect_Click" />
                                        </div>
                                        <div class="btn btn-excel1">
                                            <asp:Button ID="btnExcel" runat="server" ToolTip="ToExcel" OnClick="btnExcel_Click" Enabled="False" />
                                        </div>

                                         <div class="btn ico-view" style="display:none;">
                                            <asp:Button ID="btnview" runat="server" ToolTip="View" OnClick="btnview_Click" />
                                        </div>
                                        <div class="btn ico-cancel">
                                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" ToolTip="Cancel" Visible="false" />
                                        </div>
                                    </div>


                                    <%-- <div class="CalImg"><asp:Image ID="ImgTo" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/Calender.jpg"/></div>--%>
                                </div>
                                <div class="Bordertop"></div>
                                <div class="FormGroupContent4">
                                </div>
                                <div class="FormGroupContent4">
                                    <asp:Label ID="lblMsg" runat="server" CssClass="Error"></asp:Label>
                                    <asp:Panel ID="Pnl_FEGrd" runat="server" Visible="false">
                                        <%--          <asp:Panel ID="Pnl_FE" runat="server" ScrollBars="None" Width="1330px" Visible="false">
                                            <div style="width: 100%;">
                                                <div class="div_GrdInvoice GrdHeader">
                                                    Invoice #
                                                </div>
                                                <div class="div_GrdBranch GrdHeader">
                                                    Booking Office
                                                </div>
                                                <div class="div_GrdBL GrdHeader">
                                                    BL#
                                                </div>
                                                <div class="div_GrdPOL_FE GrdHeader">
                                                    POL
                                                </div>
                                                <div class="div_GrdPOD_FE GrdHeader">
                                                    POD
                                                </div>
                                                <div class="div_GrdCargodate GrdHeader">
                                                    Pickup Date
                                                </div>
                                                <div class="div_GrdReceiveddate  GrdHeader">
                                                    Received Date
                                                </div>
                                                <div class="div_GrdReceiveddate GrdHeader">
                                                    Inspected Date
                                                </div>
                                                <div class="div_GrdCargodate GrdHeader">
                                                    Stuffing Date
                                                </div>
                                                <div class="div_GrdCustomdate GrdHeader">
                                                    Custom Cleard Date
                                                </div>
                                                <div class="div_GrdCargodate GrdHeader">
                                                    Railout Date
                                                </div>
                                                <div class="div_GrdETD GrdHeader">
                                                    ETD
                                                </div>
                                                <div class="div_GrdETD GrdHeader">
                                                    ETA
                                                </div>
                                            </div>
                                        </asp:Panel>--%>



                                        <asp:Panel ID="Pln_OFE" runat="server">
                                            <asp:GridView ID="GrdFEBL" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader"  ShowHeader="True"
                                                OnSelectedIndexChanged="GrdFEBL_SelectedIndexChanged" ShowHeaderWhenEmpty="true"
                                                Width="100%" OnRowDataBound="GrdFEBL_RowDataBound" DataKeyNames="blno,bid">
                                                <Columns>
                                                    <asp:CommandField SelectImageUrl="~/Images/select.gif" ButtonType="Image" ShowSelectButton="true"
                                                        ItemStyle-Width="20px" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                                                        <ItemStyle Width="20px" />
                                                    </asp:CommandField>

                                                    <asp:TemplateField HeaderText="Booking #">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("shiprefno")%>'>
                                                                <%--class="div_Column"--%>
                                                                <%#Eval("shiprefno")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" Width="200px" />
                                                        <ItemStyle Wrap="false" Width="200px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("bookingdate")%>'>
                                                                <%--class="div_ColumnBL"--%>
                                                                <%#Eval("bookingdate")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>

                                           	<asp:TemplateField HeaderText="PO #">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("pono")%>'>
                                                                <%--class="div_ColumnDate"--%>
                                                                <%#Eval("pono")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="SO #">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("So")%>'>
                                                                <%--class="div_ColumnBL1"--%>
                                                                <%#Eval("So")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("SoDate")%>'>
                                                                <%--class="div_ColumnBL"--%>
                                                                <%#Eval("SoDate")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
             

                                                    <asp:TemplateField HeaderText="HBL #">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("blno")%>'>
                                                                <%--class="div_ColumnBLP"--%>
                                                                <%#Eval("blno")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("bldate")%>'>
                                                                <%--class="div_ColumnBL"--%>
                                                                <%#Eval("bldate")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Shipper">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("Shipper")%>'>
                                                                <%--class="div_ColumnS" --%>
                                                                <%#Eval("Shipper")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Consignee">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("Consignee")%>'>
                                                                <%--class="div_ColumnS"--%>
                                                                <%#Eval("Consignee")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>

                           
                                                    <asp:TemplateField HeaderText="Cartons">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("Carton")%>'>
                                                                <%--class="div_ColumnS"--%>
                                                                <%#Eval("Carton")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="M3">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("CBM")%>'>
                                                                <%--class="div_ColumnC"--%>
                                                                <%#Eval("CBM")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Cont 20">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("cont20")%>'>
                                                                <%--class="div_ColumnC"--%>
                                                                <%#Eval("cont20")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Cont 40">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("cont40")%>'>
                                                                <%--class="div_ColumnC"--%>
                                                                <%#Eval("cont40")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="POL">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("pol")%>'>
                                                                <%--class="div_ColumnS"--%>
                                                                <%#Eval("pol")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="POD">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("pod")%>'>
                                                                <%--class="div_ColumnS"--%>
                                                                <%#Eval("pod")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Final Destination">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("FD")%>'>
                                                                <%--class="div_ColumnS"--%>
                                                                <%#Eval("FD")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Vessel Voy">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("vessel")%>'>
                                                                <%--class="div_ColumnS"--%>
                                                                <%#Eval("vessel")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="ETD">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("etd")%>'>
                                                                <%--class="div_ColumnEDate"--%>
                                                                <%#Eval("etd")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="T/Vessel Voy">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("TVessel")%>'>
                                                                <%--class="div_ColumnS"--%>
                                                                <%#Eval("TVessel")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="T/ETD">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("TVETD")%>'>
                                                                <%--class="div_ColumnEDate"--%>
                                                                <%#Eval("TVETD")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="ETA">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("eta")%>'>
                                                                <%--class="div_ColumnEDate"--%>
                                                                <%#Eval("eta")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Shipment Status">
                                                        <ItemTemplate>
                                                            <div title='<%#Eval("shipmentstatus") %>'>
                                                                <%--class="div_ColumnS"--%>
                                                                <%#Eval("shipmentstatus")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>

                                                </Columns>
                                                <RowStyle CssClass="GrdRow" />
                                                <HeaderStyle CssClass="GrdHeader " />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                            </asp:GridView>
                                        </asp:Panel>
                                    </asp:Panel>




                                    <%--<asp:Panel ID="Pnl_FI" runat="server" Height="75%" ScrollBars="None" Width="100%"
                                        Visible="false">
                                        <div style="width: 100%;">
                                            <div class="div_GrdBranchFI GrdHeader">
                                                <asp:Label ID="lbl_FIBranch" runat="server" Text="Branch"></asp:Label>
                                            </div>
                                            <div class="div_GrdBLFI GrdHeader">
                                                <asp:Label ID="lbl_FIBL" runat="server" Text="BL#"></asp:Label>
                                            </div>
                                            <div class="div_GrdBLdateFI GrdHeader">
                                                <asp:Label ID="lbl_FIBLDate" runat="server" Text="BL Date"></asp:Label>
                                            </div>
                                            <div class="div_GrdFeederFI GrdHeader">
                                                <asp:Label ID="lbl_FIFeeder" runat="server" Text="Vessel"></asp:Label>
                                            </div>
                                            <div class="div_GrdPOLFI GrdHeader">
                                                <asp:Label ID="lbl_FIPOL" runat="server" Text="POL"></asp:Label>
                                            </div>
                                            <div class="div_GrdETAFI GrdHeader">
                                                <asp:Label ID="lbl_FIETD" runat="server" Text="ETD"></asp:Label>
                                            </div>
                                            <div class="div_GrdPOLFI GrdHeader">
                                                <asp:Label ID="lbl_FIPOD" runat="server" Text="POD"></asp:Label>
                                            </div>
                                            <div class="div_GrdETAFI GrdHeader">
                                                <asp:Label ID="lbl_FIETA" runat="server" Text="ETA"></asp:Label>
                                            </div>
                                        </div>
                                    </asp:Panel>--%>
                                    <asp:Panel ID="pnlOIE" runat="server">
                                        <asp:GridView ID="GrdFEIBL" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader"  OnSelectedIndexChanged="GrdFEIBL_SelectedIndexChanged"
                                            ShowHeader="true" Width="100%" OnRowDataBound="GrdFEIBL_RowDataBound" DataKeyNames="blno,bid">
                                            <Columns>
                                                <asp:CommandField SelectImageUrl="~/Images/select.gif" ButtonType="Image" ShowSelectButton="True"
                                                    HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                                                    <ItemStyle Width="2%" Height="10px" HorizontalAlign="Center"></ItemStyle>
                                                </asp:CommandField>
                                                <asp:BoundField DataField="shiprefno" HeaderText="Booking #">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="BookingDate" HeaderText="Date">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                <%-- 		 <asp:BoundField DataField="pono" HeaderText="PO #">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="So" HeaderText="SO #">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SODate" HeaderText="Date">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>--%>
                                                <asp:BoundField DataField="blno" HeaderText="HBL #">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="bldate" HeaderText="Date">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Shipper" HeaderText="Shipper">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Consignee" HeaderText="Consignee">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Carton" HeaderText="Cartons">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CBM" HeaderText="CBM">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="Cont 20">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont40" HeaderText="Cont 40">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="pol" HeaderText="POL">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="pod" HeaderText="POD">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FD" HeaderText="Final Destination">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="vessel" HeaderText="Vessel Voy">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="etd" HeaderText="ETD">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TVessel" HeaderText="T/Vessel Voy">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TVETD" HeaderText="T/ETD">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="eta" HeaderText="ETA">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="shipmentstatus" HeaderText="Shipment Status">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                            <RowStyle CssClass="GrdRow" />
                                            <HeaderStyle CssClass="GrdHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </asp:Panel>

                                    <asp:Panel ID="pnlAIE" runat="server">
                                        <asp:GridView ID="grdAIEBLInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="bid,blno" OnRowDataBound="grdAIEBLInfo_RowDataBound"
                                            OnSelectedIndexChanged="grdAIEBLInfo_SelectedIndexChanged" CssClass="Grid FixedHeader"  CellPadding="2" CellSpacing="1">
                                            <Columns>
                                                <asp:CommandField SelectImageUrl="~/Images/select.gif" ButtonType="Image" ShowSelectButton="True" HeaderStyle-CssClass="hide"
                                                    ItemStyle-CssClass="hide"></asp:CommandField>
                                                <asp:BoundField DataField="shiprefno" HeaderText="Booking #">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="bookingdate" HeaderText="Date">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                    				<%--<asp:BoundField DataField="pono" HeaderText="PO #">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="So" HeaderText="SO #">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SoDate" HeaderText="Date">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>--%>
    
                                                <asp:BoundField DataField="blno" HeaderText="HBL #">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="bldate" HeaderText="Date">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Shipper" HeaderText="Shipper">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Consignee" HeaderText="Consignee">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                        
                                                <asp:BoundField DataField="Carton" HeaderText="Cartons">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cbm" HeaderText="M3">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont20" HeaderText="Cont 20">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cont40" HeaderText="Cont 40">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="pol" HeaderText="POL">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="pod" HeaderText="POD">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="fd" HeaderText="Final Destination">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="vessel" HeaderText="Vessel Voy">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="etd" HeaderText="ETD">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TVessel" HeaderText="T/Vessel Voy">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TVETD" HeaderText="ETD">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="eta" HeaderText="ETA">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="shipmentstatus" HeaderText="Shipment Status">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false"></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                            <RowStyle CssClass="GrdRow" />
                                            <HeaderStyle CssClass="GrdHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </div>

                                <div class="FormGroupcontent4">
                                    <div style="display: none;">

                                        <asp:GridView ID="Grd_FETemp" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader"  Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="False">
                                            <Columns>
                                                <asp:CommandField SelectImageUrl="~/Images/select.gif" ButtonType="Image" ShowSelectButton="True">
                                                    <ItemStyle Width="1%" Height="10px" HorizontalAlign="Left"></ItemStyle>
                                                </asp:CommandField>
                                                <%--                         <asp:BoundField DataField="invoiceno" HeaderText="Invoice #">
                                                    <ItemStyle Width="5%" Wrap="True"></ItemStyle>
                                                </asp:BoundField>--%>
                                                <asp:BoundField DataField="Bokking" HeaderText="Booking ">
                                                    <ItemStyle Width="7%" Wrap="True"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="bookinfdate" HeaderText="BL #">
                                                    <ItemStyle Wrap="True" Width="7%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="pol" HeaderText="POL">
                                                    <ItemStyle Wrap="True" Width="8%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="pod" HeaderText="POD">
                                                    <ItemStyle Wrap="True" Width="8%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cargoreceivedon" HeaderText="Pickup Date">
                                                    <ItemStyle Wrap="True" Width="5%"></ItemStyle>
                                                </asp:BoundField>
                                                <%--<asp:BoundField DataField="receivedon" HeaderText="receivedon">
                                                    <ItemStyle Wrap="True" Width="5%"></ItemStyle>
                                                </asp:BoundField>--%>
                                                <%--<asp:BoundField DataField="inspectedon" HeaderText="inspectedon">
                                                    <ItemStyle Wrap="True" Width="10%"></ItemStyle>
                                                </asp:BoundField>--%>
                                                <asp:BoundField DataField="stuffedon" HeaderText="Stuffing Date">
                                                    <ItemStyle Wrap="True" Width="5%"></ItemStyle>
                                                </asp:BoundField>

                                                <%--<asp:BoundField DataField="customdate" HeaderText="customdate">
                                                    <ItemStyle Wrap="True" Width="8%"></ItemStyle>
                                                </asp:BoundField>--%>
                                                <asp:BoundField DataField="railoutdate" HeaderText="Railout Date">
                                                    <ItemStyle Wrap="True" Width="6%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="etd" HeaderText="ETD">
                                                    <ItemStyle Wrap="True" Width="5%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="eta" HeaderText="ETA">
                                                    <ItemStyle Wrap="True" Width="5%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="eta" Visible="False">
                                                    <ControlStyle BorderStyle="None"></ControlStyle>
                                                    <ItemStyle BackColor="AliceBlue" BorderStyle="None" Width="1px" ForeColor="AliceBlue"
                                                        Wrap="True"></ItemStyle>
                                                    <HeaderStyle BackColor="AliceBlue" BorderStyle="None" ForeColor="AliceBlue"></HeaderStyle>
                                                    <FooterStyle BorderStyle="None"></FooterStyle>
                                                </asp:BoundField>


                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                    <asp:Label ID="lblcrm" runat="server"></asp:Label>
                                    <ajaxtoolkit:ModalPopupExtender ID="PopupBL" runat="server" TargetControlID="lblcrm" BehaviorID="programmaticModalPopupBehavior3"
                                        PopupControlID="popupfro" Drag="true"
                                        BackgroundCssClass="modalBackground" CancelControlID="imgcrok">
                                    </ajaxtoolkit:ModalPopupExtender>

                                    <asp:Panel ID="popupfro" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                        <div class="divRoated">
                                            <div class="DivSecPanel">
                                                <asp:Image ID="imgcrok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                            </div>

                                            <asp:Panel ID="Panel31" runat="server" CssClass="Gridpnl">

                                                <iframe id="iframecost" runat="server" frameborder="0" src="" visible="true" class="frames" style="background-color: #FFFFF"></iframe>

                                            </asp:Panel>
                                            <div class="divBk"></div>
                                        </div>
                                    </asp:Panel>

                                     <asp:HiddenField ID="Hiddenshipper" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
