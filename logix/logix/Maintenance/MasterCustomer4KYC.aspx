<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="MasterCustomer4KYC.aspx.cs" Inherits="logix.Maintenance.MasterCustomer4KYC" %>
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

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

  
    <!-- App -->
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







    <link href="../Styles/MasterCustomer4KYC.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />  

    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>
      
    <link href ="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />  
    <style type="text/css" > 
        a img{border: none;}
		ol li{list-style: decimal outside;}
		div#container{width: 780px;margin: 0 auto;padding: 1em 0;}
		div.side-by-side{width: 100%;margin-bottom: 1em;}
		div.side-by-side > div{float: left;width: 50%;}
		div.side-by-side > div > em{margin-bottom: 10px;display: block;}
		.clearfix:after{content: "\0020";display: block;height: 0;clear: both;overflow: hidden;visibility: hidden;}
    </style> 
    
    <%--EDIT--%>

    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {

                $("#<%=txtCustomer.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_customerid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Maintenance/MasterCustomer4KYC.aspx/GetCustomer",
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
                        if (i.item) {
                            $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=txtCustomer.ClientID %>").change();
                            $("#<%=hid_customerid.ClientID %>").val(i.item.val);
                        }
                    },
                    focus: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));                            
                            $("#<%=hid_customerid.ClientID %>").val(i.item.val);
                        }
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_customerid.ClientID %>").val(i.item.val);
                        }
                    },
                    close: function (event, i) {
                        if (i.item) {
                            $("#<%=txtCustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_customerid.ClientID %>").val(i.item.val);
                        }
                    },
                    minLength: 1
                });
            });
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            }
    </script>
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
             width:auto;
             white-space:nowrap;
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
              <li><a href="#" title="">Maintenance</a> </li>
              <li class="current"><a href="#" title="">KYC Proof for Customer</a> </li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                 <div style="float: left; margin: 0px 0.5% 0px 0px;"> <h4><i class="icon-umbrella"></i><asp:Label ID="lbl_Header" runat="server" Text="KYC Proof for Customer"></asp:Label></h4></div>
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
          <div class="widget-content">
             <div class="FormGroupContent4">
                 <asp:TextBox ID="txtCustomer" runat="server" Cssclass="form-control" AutoPostBack="True" placeholder="Customer" ToolTip="Customer" 
             TabIndex="1" OnTextChanged="txtCustomer_TextChanged" ></asp:TextBox>

                 </div>
               <div class="FormGroupContent4">
                   <div class="BillDrop2"><asp:DropDownList ID="ddlIDProof" runat="server" AppendDataBoundItems="True" TabIndex="2" CssClass="chzn-select" 
            ToolTip="IDProof" data-placeholder="IDProof" OnSelectedIndexChanged="ddlIDProof_SelectedIndexChanged">   
            <asp:ListItem Text="" Value="0"></asp:ListItem>     
            </asp:DropDownList></div>
                   <div class="FileUpload2"><asp:FileUpload ID="fuIDDoc" runat="server" TabIndex="3" width="100%"></asp:FileUpload></div>
                   </div>
               <div class="FormGroupContent4">
                   <div class="BillDrop2"><asp:DropDownList ID="ddlAddProof" runat="server" AppendDataBoundItems="True" TabIndex="4" CssClass="chzn-select" 
            ToolTip="AddrProof" data-placeholder="AddrProof" OnSelectedIndexChanged="ddlAddProof_SelectedIndexChanged">
                <asp:ListItem Text="" Value="0"></asp:ListItem>
            </asp:DropDownList></div>
                   <div class="FileUpload2"><asp:FileUpload ID="fuAddrProof" runat="server" TabIndex="5"></asp:FileUpload></div>
                   </div>
              <div class="FormGroupContent4">
                  <asp:TextBox ID="txtIECDoc" runat="server" Cssclass="form-control" placeholder="IECDoc" ToolTip="IECDoc" 
             TabIndex="6"></asp:TextBox>
                  </div>
              <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                   <div class="right_btn MT0 MB10">
                       <div class="btn ico-save" id="btnSave1" runat="server"> <asp:Button ID="btnSave" runat="server" ToolTip="Save"  OnClick="btnSave_Click" TabIndex="7" />
            </div>
                       <div class="btn ico-view">  <asp:Button ID="btnView" runat="server" ToolTip="View" OnClick="btnView_Click" TabIndex="8" />         
            </div>
                       <div class="btn ico-cancel" id="btnCancel1" runat="server"> <asp:Button ID="btnCancel" runat="server" ToolTip="Cancel" OnClick="btnCancel_Click" TabIndex="9" /></div>
                   </div>
                   </div>
              </div>
         </div>
            </div>
           </div>

     <asp:HiddenField ID="hid_customerid" runat="server" />
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
    
    <asp:modalpopupextender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image3" BehaviorID="Test1">
    </asp:modalpopupextender>
        </asp:Content>
