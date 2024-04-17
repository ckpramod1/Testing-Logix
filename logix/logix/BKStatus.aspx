<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BKStatus.aspx.cs" Inherits="logix.BKStatus" EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Booking Status</title>
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


     <!-- Demo JS -->

    
  

    <link href="Styles/chosen.css" rel="stylesheet" />
    <script src="Scripts/chosen.jquery.js" type="text/javascript"></script>


     <link href="Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
   
    <script type="text/javascript">

        function pageLoad(sender, args) {
          
           
           
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            
        }
            </script>

    <link href="Style/Booking.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/Calendar.js"></script>
    <script type="tezzzzzxt/javascript" src="Scripts/Validation.js"></script>





 

    

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
        #ddl_module_chzn {
            width:100%!important;
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

         .Hiden {
            display:none;
        }
         

          .GridBorder1 {
            width:100%;
            border:0px solid #003166;
            height:165px;
            overflow:auto;
            margin-top:5px;
        }
          .FileUpload {
    width: 57%;
    float: left;
    margin: 0px 1.5% 0px 0px;
}

        .Grid th {
            white-space:nowrap;
        }

          .Grid td {
            white-space:nowrap;
        }

        .DDModuleDrop {
            width:13%;
            float:right;
            margin:0px 0px 0px 0px;
        }
        .SrcFilter{
            width:15%;
            float:right;
            margin:0px 0.5% 0px 0%;
        }


        table#chkproducts {
    width: 133px;
    background-color: #fff;
    padding: 5px;
    border: 1px solid #b1b1b1;
}



    </style>

   <%-- <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>--%>

    
   



   


</head>
<body>
    <form id="form1" runat="server">

         


        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="360000">
        </asp:ScriptManager>

       <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/green_indicator.gif"></asp:Image>Loading....
            Please wait...
            </ProgressTemplate>
        </asp:UpdateProgress>
  <%--      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>

                <!-- Breadcrumbs line -->
                <div class="crumbs">
       <%--             <ul id="breadcrumbs" class="breadcrumb">
                        <li><i class="icon-home"></i>Home </li>

                        <li>Shipment Details </li>--%>
                        <li class="current" id="lbl" runat="server">Booking Status</li>
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
                                     <div class="DDModuleDrop">

                                       <%--   <asp:DropDownList ID="ddl_module" runat="server" CssClass="chzn-select" placeholder="--Status--" ToolTip="Status" AutoPostBack="true" OnSelectedIndexChanged="ddl_module_SelectedIndexChanged">
                                                 <asp:ListItem Value="A">ALL</asp:ListItem>
                                                     <asp:ListItem Value="B">Booked</asp:ListItem>
                                                <asp:ListItem  Value="T">Transit</asp:ListItem>
                                                 <asp:ListItem  Value="C">Closed</asp:ListItem>
                                                
                                            </asp:DropDownList>--%>
                                           <div class="FieldInput">
                                            <%--   <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                       <ContentTemplate>--%>
                                             <asp:TextBox ID="txt_workprocess" ToolTip="Status"  placeholder="Status" runat="server" ReadOnly="true" CssClass="form-control"  Width="101.5%" ></asp:TextBox>
                                         <asp:Panel ID="PnlCust" runat="server" CssClass="PnlDesign">
                                        <asp:CheckBoxList ID="chkproducts" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_module_SelectedIndexChanged">
                                        <asp:ListItem>All</asp:ListItem>
                                        <asp:ListItem >Booked</asp:ListItem>
                                         <asp:ListItem >Transit</asp:ListItem>
                                         <asp:ListItem >Closed</asp:ListItem>                                        
                                           </asp:CheckBoxList>
                                       </asp:Panel>
                                                <ajaxtoolkit:PopupControlExtender ID="PceSelectCustomer" runat="server" TargetControlID="txt_workprocess"
                                           PopupControlID="PnlCust" Position="Bottom">
                                          </ajaxtoolkit:PopupControlExtender>
                                             <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                                          <%--    </ContentTemplate>
                                          </asp:UpdatePanel> --%>
                                   </div>


                                     </div>
                                          <div class="SrcFilter"><asp:TextBox ID="txtSrc" runat="server" placeholder="Booking # - Filter" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtSrc_TextChanged"></asp:TextBox></div>      


                                      <div class="btn btn-excel1">
                                            <asp:Button ID="btnExcel" runat="server" ToolTip="ToExcel" OnClick="btnExcel_Click"/>
                                        </div>
                                     </div>
                                <div class="FormGroupContent4">
                                   
               
                                     <div class="GridBorder1">
                 
                                <asp:GridView ID="GrdDetails" TabIndex="13" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="false" PageSize="3" Width="100%" ForeColor="Black" AllowPaging="false" CssClass="Grid FixedHeader"  OnRowDataBound="GrdDetails_RowDataBound" OnSelectedIndexChanged="GrdDetails_SelectedIndexChanged">
                <Columns>


                 <%--     <asp:BoundField DataField="SI" HeaderText="SI #">   
                        <HeaderStyle Wrap="false"  />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="S #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="true" Width="30px" />
                                                    <HeaderStyle Wrap="true" Width="30px" />
                                                </asp:TemplateField>

                      <asp:BoundField DataField="type" HeaderText="Status">   
                        <HeaderStyle  />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                      <%-- <asp:BoundField DataField="status" HeaderText="Status">   
                        <HeaderStyle Wrap="false"  />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>--%>
                   <asp:BoundField DataField="Service" HeaderText="Service">   
                        <HeaderStyle  />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                      <asp:BoundField DataField="Bookingno" HeaderText="Booking #">   
                        <HeaderStyle  />                                             
                        <ItemStyle HorizontalAlign="Left" Width="140px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="bookingdate" HeaderText="Booking Date">   
                        <HeaderStyle  />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Origin" HeaderText="Origin">   
                        <HeaderStyle  />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                     <asp:BoundField DataField="Destination" HeaderText="Destination">   
                        <HeaderStyle />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                      <asp:BoundField DataField="ETAOrigin" HeaderText="ETA Origin">   
                        <HeaderStyle />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:BoundField DataField="ETDDestintation" HeaderText="ETD Destintation">   
                        <HeaderStyle />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                       <asp:BoundField DataField="blno" HeaderText="BL #">   
                        <HeaderStyle />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                       <asp:BoundField DataField="Shipper" HeaderText="Shipper Name">   
                        <HeaderStyle />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                    <asp:BoundField DataField="consignee" HeaderText="consignee Name">   
                        <HeaderStyle />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="notify" HeaderText="Notify Name">   
                        <HeaderStyle />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                      <asp:BoundField DataField="job" HeaderText="job">   
                        <HeaderStyle  CssClass="Hiden" />                                             
                        <ItemStyle HorizontalAlign="Left" CssClass="Hiden" />
                    </asp:BoundField>
                     <asp:BoundField DataField="bid" HeaderText="bid">   
                        <HeaderStyle  CssClass="Hiden" />                                             
                        <ItemStyle HorizontalAlign="Left" CssClass="Hiden" />
                    </asp:BoundField>
                    <asp:BoundField DataField="trantype" HeaderText="trantype">   
                        <HeaderStyle  CssClass="Hiden" />                                             
                        <ItemStyle HorizontalAlign="Left" CssClass="Hiden" />
                    </asp:BoundField>

                     <asp:BoundField DataField="flight" HeaderText="flight">   
                        <HeaderStyle  CssClass="Hiden" />                                             
                        <ItemStyle HorizontalAlign="Left" CssClass="Hiden" />
                    </asp:BoundField>
                    <asp:BoundField DataField="shipmentstatus" HeaderText="Shipment Status">   
                        <HeaderStyle />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>


                        <asp:TemplateField HeaderText="View"><%--11--%>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="Lnk_job" runat="server" CommandName="select" Font-Underline="false"
                                                                CssClass="Arrow">⇛</asp:LinkButton>
                                                            <br />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>

                    
                                   <%-- <asp:TemplateField HeaderText="Mode">
                                        <HeaderStyle Width="60px" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddl_module" runat="server" CssClass="chzn-select" placeholder="--MODE--" ToolTip="MODE" AutoPostBack="true" OnSelectedIndexChanged="ddl_module_SelectedIndexChanged">
                                                <asp:ListItem Value="B">Booking</asp:ListItem>
                                                <asp:ListItem  Value="T">Transit</asp:ListItem>
                                                 <asp:ListItem  Value="C">Closed</asp:ListItem>
                                                
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>


                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <RowStyle Font-Italic="False" />
            </asp:GridView>
                        

                            </div>
                                  
                     
                                    <asp:Label ID="lblcrm" runat="server"></asp:Label>
                                    <ajaxtoolkit:ModalPopupExtender ID="PopupBL" runat="server" TargetControlID="lblcrm" BehaviorID="programmaticModalPopupBehavior3"
                                        PopupControlID="popupfro" Drag="true"
                                        BackgroundCssClass="modalBackground" > <%-- CancelControlID="imgcrok"--%>
                                    </ajaxtoolkit:ModalPopupExtender>

                                    <asp:Panel ID="popupfro" runat="server"  CssClass="modalPopup1" Style="display: none;">
                                        <div class="divRoated">
                                            <div class="DivSecPanel">
                                               <%-- <asp:LinkButton ID="LinkButton1"   runat="server"  OnClick="LinkButton1_Click">--%>
                                                <asp:Image ID="imgcrok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                                    <%--</asp:LinkButton>--%>
                                            </div>

                                            <asp:Panel ID="Panel31" runat="server" CssClass="Gridpnl">

                                                <iframe id="iframecost" runat="server" frameborder="0" src="" visible="true" class="frames" style="background-color: #FFFFF"></iframe>

                                            </asp:Panel>
                                            <div class="divBk"></div>
                                        </div>
                                    </asp:Panel>
                                    <%-- <div class="CalImg"><asp:Image ID="ImgTo" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/Calender.jpg"/></div>--%>
                                </div>
                                 
                                 <div id="upload" runat="server" visible="false" class="GridBorder1">
                                             <div class="FormGroupContent4">

       <div class="BookingTxtBox"> 
                 
                      
                      <asp:TextBox ID="txt_booking" runat="server"  placeholder="BL#" CssClass="form-control" ToolTip="BL #" TabIndex="1" ></asp:TextBox>


                  </div>
                                                 <div style="float:right;">
                                             <div style="color:maroon; float:left; margin:0px 1% 0px 0px;"><asp:Label ID="lbl_DispMsg" runat="server" Text="Upload status : "></asp:Label></div>
               <div class="btn ico-upload"> <asp:Button ID="btnSave" runat="server" ToolTip="Upload"  TabIndex="16" OnClick="btnSave_Click" /></div>
                                                     
          
 <div class="FileUpload">
                                <asp:FileUpload ID="upd_document" runat="server" TabIndex="3" Width="100%" ></asp:FileUpload>
                            </div>
                                                     </div>


                                                 </div>
                                             <div class="GridHeader1">
                                             
         <asp:GridView ID="grpupdload" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader"  ForeColor="Black" OnRowDataBound="grpupdload_RowDataBound" OnSelectedIndexChanged="grpupdload_SelectedIndexChanged" ShowHeaderWhenEmpty="true" Width="100%" onrowcommand="grpupdload_RowCommand" onrowdeleting="grpupdload_RowDeleting">
                     <Columns>
                         <asp:BoundField DataField="docname" HeaderText="Doc Type">
                         <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                         <ItemStyle HorizontalAlign="Left" Width="15%" />
                         </asp:BoundField>
                         <asp:BoundField DataField="remarks" HeaderText="Remarks">
                         <HeaderStyle HorizontalAlign="Left" Wrap="true" Width="370px" />
                         <ItemStyle HorizontalAlign="Left" Width="370px" />
                         </asp:BoundField>
                         <asp:BoundField ControlStyle-CssClass="hide" DataField="doctype" HeaderText="docid">
                         <HeaderStyle CssClass="hide" HorizontalAlign="Left" Wrap="true" />
                         <ItemStyle CssClass="hide" HorizontalAlign="Left" Width="15%" />
                         </asp:BoundField>
                         <asp:BoundField DataField="docid" HeaderText="dcmtid">
                         <HeaderStyle CssClass="hide" HorizontalAlign="Left" Wrap="true" Width="350px" />
                         <ItemStyle CssClass="hide" HorizontalAlign="Left" Width="350px" />
                         </asp:BoundField>
                         <asp:BoundField DataField="fileloc" HeaderText="FileNameLoc"> 
                         <HeaderStyle  HorizontalAlign="Left" Wrap="true" Width="350px" /> <%-- CssClass="hide"--%>
                         <ItemStyle  HorizontalAlign="Left" Width="350px" /> <%--  CssClass="hide"--%>
                         </asp:BoundField>
                            <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                        <asp:ImageButton ID="Img_Delete" runat="server" CommandName="Delete" 
                            ImageUrl="~/images/delete.jpg" />
                    </ItemTemplate>
                    <HeaderStyle Wrap="false" HorizontalAlign="right" Width="20px"  />
                     <ItemStyle Font-Bold="false" Width="20px" HorizontalAlign="Justify"/>
                   
                </asp:TemplateField>
                     </Columns>
                     <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                     <HeaderStyle CssClass="" />
                     <AlternatingRowStyle CssClass="GrdAltRow" />
                 </asp:GridView>
                                             </div>
                        
                                             </div>
                              
                              
                            </div>
                        </div>
                    </div>
                </div>
     <%--    </ContentTemplate>
        </asp:UpdatePanel>--%>
                  <asp:HiddenField ID="hid_blno" runat="server" />
                              
                               <asp:HiddenField ID="hid_bid" runat="server" />
                                 <asp:HiddenField ID="hid_poddownload" runat="server" />
                                <asp:HiddenField ID="hid_trantype1" runat="server" />
          
    </form>
</body>
</html>
