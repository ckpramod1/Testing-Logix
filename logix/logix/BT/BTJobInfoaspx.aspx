<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="BTJobInfoaspx.aspx.cs" Inherits="logix.BT.BTJobInfoaspx" %>

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

<%--    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

  
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











    <link href="../Styles/BTJobInfo.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
       <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
       <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {

            $(document).ready(function () {
                $("#<%=txtToPort.ClientID %>").autocomplete({

                source: function (request, response) {
                    $("#<%=hid_toPort.ClientID %>").val(0);
                    $.ajax({
                        url: "../BT/BTJobInfoaspx.aspx/GetToPort",
                        data: "{ 'prefix': '" + request.term + "','Ftype':'C'}",
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
                    $("#<%=txtToPort.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtToPort.ClientID %>").change();
                        $("#<%=hid_toPort.ClientID %>").val(i.item.val);
                    },
                focus: function (event, i) {
                    $("#<%=txtToPort.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_toPort.ClientID %>").val(i.item.val);
                    },
                change: function (event, i) {
                    if (i.item) {
                        $("#<%=txtToPort.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_toPort.ClientID %>").val(i.item.val);

                        }

                    },
                close: function (event, i) {
                    var result = $("#<%=txtToPort.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtToPort.ClientID %>").val($.trim(result));

                    },
                minLength: 1
            });
        });


            $(document).ready(function () {
                $("#<%=txtCustomerName.ClientID %>").autocomplete({

                source: function (request, response) {
                    $("#<%=hid_Customer.ClientID %>").val(0);
                    $.ajax({
                        url: "../BT/BTJobInfoaspx.aspx/GetCustomer",
                        data: "{ 'prefix': '" + request.term + "','Ftype':'C'}",
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
                    $("#<%=txtCustomerName.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                    $("#<%=txtCustomerName.ClientID %>").change();
                    $("#<%=hid_Customer.ClientID %>").val(i.item.val);
                },
                focus: function (event, i) {
                    $("#<%=txtCustomerName.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                    $("#<%=hid_Customer.ClientID %>").val(i.item.val);
                },
                change: function (event, i) {
                    if (i.item) {
                        $("#<%=txtCustomerName.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_Customer.ClientID %>").val(i.item.val);

                    }

                },
                close: function (event, i) {
                    var result = $("#<%=txtCustomerName.ClientID %>").val().toString().split(',')[0];
                    $("#<%=txtCustomerName.ClientID %>").val($.trim(result));

                },
                minLength: 1
            });
        });

           




        $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
    }
    </script>

     <script type="text/javascript">
         function ConfirmationBox() {
             var result = confirm('Do you Want to delete this Details?');
             if (result) {
                 return true;
             }
             else {
                 return false;
             }
         }
    </script>

  <style type="text/css">
     

        modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .DivSecPanel
        {
            width:20px; 
            Height:20px; 
            border:2px solid white;
            margin-left:98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

      #programmaticModalPopupBehavior1_foregroundElement {left:0px!important; top:50px!important;
      }
      #logix_CPH_pnlJobAE {top:45px!important; left:0px!important;
      }

      
        .btn-UpdateAdd2 {
   
    z-index: 2;
    border-radius: 0px;
}

    .btn-UpdateAdd2 input {
       
        border: medium none;
        line-height: normal;
        color: #4e4e4c!important;
        padding: 5px 0px 6px 28px;
        background:url(../Theme/assets/img/buttonIcon/updateadd_ic.png) no-repeat left top;
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
             width:65%;
             float:left;
             margin:2px 0px 3px 4px;

         }

         .LogHeadLbl label
         {
             color:#af2b1a;
             font-weight:bold;
             font-size:12px;
         }



         .LogHeadJob {
             width:auto;
             float:left;
             margin:0px 0.5% 0px 0px;
         }

         .LogHeadJobInput label {
             font-size:12px;
             
            
         }


           .LogHeadJobInput {
             width:15%;
             float:left;
             margin:1px 0.5% 0px 0px;
         }

             .LogHeadJobInput span {
                 color:#1a65af;
                 font-size:12px;
                 margin:4px 0px 0px 0px;
             }




             .LogHeadJobInput label {
                 font-size:12px;
                 font-family:sans-serif;
                 color:#4e4e4c;
             }

               logix_CPH_PanelLog
             {
                 top:155px!important;
             }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


       <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
              <li><a href="#" title="">Bonded Trucking</a> </li>
              <li><a href="#" title="">Job Details</a> </li>
              <li class="current"><a href="#" title="">BT Job Info</a> </li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                <div style="float: left; margin: 0px 0.5% 0px 0px;">  <h4><i class="icon-umbrella"></i><asp:Label ID="lblJobinfo" runat="server" Text="BTJob Info"></asp:Label></h4></div>

         <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
          <div class="widget-content">
             <div class="FormGroupContent4">
                 <div class="JobLabel1"><asp:LinkButton ID="lnkJob" runat="server" CssClass="Link"  style="text-decoration:none" OnClick="lnkJob_Click"> Job #</asp:LinkButton></div>
                 <div class="JobInput2"><asp:TextBox ID="txtJob" runat="server" ToolTip="Job #" placeholder="Job #" AutoPostBack="true" CssClass="form-control"  OnTextChanged="txtJob_TextChanged" TabIndex="1"></asp:TextBox></div>
                 </div>
              <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                   <div class="TruckInput"><asp:TextBox ID="txtTruck" runat="server" ToolTip="Truck #" AutoPostBack="true" placeholder="Truck #" CssClass="form-control"  OnTextChanged="txtTruck_TextChanged" TabIndex="2"></asp:TextBox></div>
                   <div class="TruckInput"><asp:TextBox ID="txtFromPort" runat="server" ToolTip="From Port" placeholder="From Port" Enabled="false" CssClass="form-control" OnTextChanged="txtFromPort_TextChanged" TabIndex="3"></asp:TextBox></div>
                   <div class="TruckInput"><asp:TextBox ID="txtToPort" runat="server" ToolTip="To Port" placeholder="To Port" CssClass="form-control" TabIndex="4" AutoPostBack="true" OnTextChanged="txtToPort_TextChanged"></asp:TextBox></div>
                   <div class="TruckCal1"> <asp:TextBox ID="txtEtd" runat="server" CssClass="form-control" TabIndex="5"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtEtd"></asp:CalendarExtender></div>
                   <div class="TruckCal2"><asp:TextBox ID="txtEta" runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtEta"></asp:CalendarExtender></div>
                   </div>
              <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                   <div class="right_btn MT0 MB10">
                       <div class="btn btn-pending1"><asp:Button ID="btnPendingTranper" runat="server" ToolTip="Pending Transfer" OnClick="btnPendingTranper_Click" TabIndex="7" /></div>
                       <div class="btn ico-save" id="btn_save1" runat="server"><asp:Button ID="btnSave" runat="server" ToolTip="Save" OnClick="btnSave_Click" TabIndex="8" /></div>
                       <div class="btn ico-view"><asp:Button ID="btnView" runat="server" ToolTip="View"  OnClick="btnView_Click" TabIndex="9" /></div>
                       <div class="btn ico-cancel" id="btn_cancel1" runat="server"><asp:Button ID="btnCancel" runat="server" ToolTip="Cancel" OnClick="btnCancel_Click" TabIndex="10" /></div>
                   </div>
                   </div>
              <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                   <div class="ShippInput1"> <asp:TextBox ID="txtShippingBill" runat="server" ToolTip="Shipping Bill Number" placeholder="Shipping Bill #" CssClass="form-control" TabIndex="11"></asp:TextBox></div>
                   <div class="ShippInput2"><asp:TextBox ID="txtCustomerName" runat="server" ToolTip="Customer Name" placeholder="Customer Name" CssClass="form-control" TabIndex="12"></asp:TextBox></div>
                   <div class="NoofPkg"> <asp:TextBox ID="txtNoofPackages" runat="server" ToolTip="Number of Packages" placeholder="No.of Pkgs" CssClass="form-control" TabIndex="13"></asp:TextBox></div>
                   <div class="BagDrop1"><asp:DropDownList ID="ddlPageType" runat="server" CssClass="chzn-select" data-placeholder="PackageType" ToolTip="PackageType" TabIndex="14"></asp:DropDownList></div>
                   <div class="Weight1"><asp:TextBox ID="txtWeight" runat="server" ToolTip="Weight" placeholder="Weight" CssClass="form-control" TabIndex="15"></asp:TextBox></div>
                   <div class="CBM1"><asp:TextBox ID="txtCBM" runat="server" ToolTip="CBM" placeholder="CBM" CssClass="form-control" TabIndex="16"></asp:TextBox></div>
                   <div class="btn ico-add" id="btn_add1" runat="server"><asp:Button ID="btnAdd" runat="server" ToolTip="Add" OnClick="btnAdd_Click" TabIndex="17" /></div>
                   </div>
            
               <div class="FormGroupContent4">
                     <div class="div_border">
                   <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="true" CssClass="Grid FixedHeader" 
                ShowHeader="true" OnSelectedIndexChanged="grdView_SelectedIndexChanged" EmptyDataSet="No Record Found" OnRowDataBound="grdView_RowDataBound" OnRowCommand="grdView_RowCommand" OnRowDeleting="grdView_RowDeleting" >
                <Columns>
                     <asp:BoundField DataField="Grdsbno" HeaderText="Ship. Bill #" />
                    <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                    <asp:BoundField DataField="NoOfPackages" HeaderText="No.of Pkgs" />
                    <asp:BoundField DataField="PackageType" HeaderText="PkgType" />
                    <asp:BoundField DataField="Weight" HeaderText="Weight" />
                    <asp:BoundField DataField="CBM" HeaderText="CBM" />
                    <asp:BoundField DataField="CustId" HeaderText="customerid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"/>
                     <asp:TemplateField HeaderText="" >
                    <ItemTemplate>
                             <asp:ImageButton ID="Img_Delete" runat="server" CommandName="Delete" 
                            ImageUrl="~/images/delete.jpg" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <PagerStyle CssClass="GridviewScrollPager" />
                <RowStyle Font-Italic="False" />
            </asp:GridView>
                         </div>
                   </div>
              <div class="FormGroupContent4">
                     <asp:ModalPopupExtender ID="popupBuying" runat="server" TargetControlID="Label1" BehaviorID="programmaticModalPopupBehavior1"
            PopupControlID="pnlJobAE" DropShadow="false"
            CancelControlID="close">
        </asp:ModalPopupExtender>

       <%-- <asp:Panel ID="pnlJobAE" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" style="display:none;">

            <div class="DivSecPanel">
                <asp:Image ID="imgfgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel3" runat="server"  CssClass="Gridpnl">--%>
        <asp:Panel ID="pnlJobAE" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" style="display:none;">
        <div class="divRoated">
        <div class="DivSecPanel"> <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%"/>  </div>
             
     <asp:Panel ID="Panel3" runat="server"   CssClass="Gridpnl">
             
           <asp:GridView ID="grdJob" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="true"
                    Width="100%" ForeColor="Black" EmptyDataText="No Record Found" AllowPaging="false" PageSize="18" OnRowDataBound="grdJob_RowDataBound" OnSelectedIndexChanged="grdJob_SelectedIndexChanged" CssClass="Grid FixedHeader" >
                <Columns>
                   
                </Columns>
                    
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <PagerStyle CssClass="GridviewScrollPager" />
            </asp:GridView>
         </asp:Panel>
        </div>
     

    </asp:Panel>

              </div>
              </div>

           <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label id="lbl_no" runat="server"></label>

                                </div>
                                <div class="LogHeadJobInput">

                                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                                </div>

                            </div>
                            <div class="DivSecPanel">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
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
         </div>
            </div>
           </div>


    
      <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="Image1" BehaviorID="Test1">
    </asp:ModalPopupExtender>
     <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>
        <asp:HiddenField ID="hid_date" runat="server" />
        <asp:HiddenField ID="hid_Customer" runat="server" />
        <asp:HiddenField ID="hid_toPort" runat="server" />
    <asp:HiddenField ID="hid_fromport" runat="server" />
</asp:Content>
