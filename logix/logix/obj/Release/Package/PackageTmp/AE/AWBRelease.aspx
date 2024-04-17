<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AWBRelease.aspx.cs" Inherits="logix.AE.AWBRelease" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
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





   
    <link href="../Styles/AWBRelease.css" rel="stylesheet" />
     <link href ="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />  
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>   

<script type="text/javascript" language="javascript" >
    function pageLoad(sender, args) {
        $(document).ready(function () {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        });
        $(document).ready(function () {
            $("#<%=txt_hawb.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "AWBRelease.aspx/GetAIEBLDetails",
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
                            //alert(response.responseText);
                        },
                        failure: function (response) {
                            //alert(response.responseText);
                        }
                    });
                },
                select: function (event, i) {
                    $("#<%=txt_hawb.ClientID %>").val(i.item.label);
                    $("#<%=txt_hawb.ClientID %>").change();
                    $("#<%=hd_hawl.ClientID %>").val(i.item.val);
                },
                focus: function (event, i) {
                    $("#<%=txt_hawb.ClientID %>").val(i.item.label);
                    $("#<%=hd_hawl.ClientID %>").val(i.item.val);
                },
                close: function (event, i) {
                    $("#<%=txt_hawb.ClientID %>").val(i.item.label);
                    $("#<%=hd_hawl.ClientID %>").val(i.item.val);
                },
                minLength: 1
            });
        });

    }</script>

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

        .modalPopup { 
            background-color:#FFFFFF; 
            /*border-width:1px;*/ 
            border-style:solid; 
            border-color:#CCCCCC;             
            width: 1042px;
            Height:555px; 
            margin-left:-2%;
            margin-top:-2.5%;
          /*padding:1px;            
            display:none;*/
        }

       .Gridpnl   
         {            
            width: 1024px;
            Height:560px;      
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


        .modalPopupLog {
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

    </style>
     <style type="text/css">
        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -0.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .modalPopup {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 87%;
            Height: 469px;
            margin-left: 0.5%;
            margin-top: 1.1%;
            overflow: hidden;
        }

.BackView {
    float: right;
    margin: 2px 0% 0px 0px;
    width: 8.5%;
    font-size: small;
}

            .BackView a {
                color: #034aa6;
            }

        .OutStandingLbl1 {
            float: left;
            width: 10%;
        }

            .OutStandingLbl1 h3 {
                font-size: 14px;
                color: #034aa6;
                padding: 5px 0px 5px 3px;
                margin: 0px 0px 0px 0px;
                font-family: 'OpenSansRegular';
                font-weight: normal;
            }

        .OutStandingLbl2 {
            float: left;
            width: 65%;
            padding: 3px 0px 5px 0px;
            margin: 0px 0px 0px 0px;
            font-weight: bold;
            color: #4e4e4c;
        }
            .OutStandingLbl2 span {
                font-size: 11px;
                color: brown;
                font-family: sans-serif;
                display: inline-block;
                color: Brown;
                font-weight: normal;
                padding: 3px 0px 5px 0px;
                margin: 0px 0px 0px 0px;
            }


        .BLPrint table {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
        }

        .BLPrint thead {
            position: relative;
            display: block;
            width: 100%;
            overflow: visible;
        }

            .BLPrint thead th {
                min-width: 182px;
            }

        .BLPrint tbody td {
            min-width: 182px;
        }

        .BLPrint tbody {
            position: relative;
            display: block; /*seperates the tbody from the header*/
            width: 100%;
            height: 410px;
            overflow: auto;
        }
        .BLDate2 {
    width: 7%;
    float: left;
    margin: 0px 0px 0px 0px;
}

          .FormGroupContent4 span {
              /*color:#000080;*/
              font-size:12px;
          }

        

         span#logix_CPH_Label4 {
              color: maroon;
    font-weight: bold;
}
         .Hawbtxt1 {
    width: 12%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
logix_CPH_
         span#logix_CPH_Label5 {
              color: maroon;
    font-weight: bold;
}

         span#logix_CPH_Label6 {
              color: maroon;
    font-weight: bold;
}

         span#logix_CPH_Label7 {
    color: maroon;
    font-weight: bold;
}   
              textarea#logix_CPH_txt_saddress,textarea#logix_CPH_txt_naddress {
    width: 100%;
}
              .Shipper1 {
    margin-right: 0.5% !important;
}
              .ChargeWeigh {
    width: 14.1%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
              .Commodity2 {
    width: 49.3%;
    float: left;
    margin: 0px 0px 0px 0px;
}
              div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 45px !important;
}
              .TextField textarea.form-control {
    padding: 6px 7px 0px !important;
    /* padding: 5px 7px 0px !important; */
    margin: 10px 0px 0px 0px !important;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12"> 
    
     <div class="widget box" runat ="server" id="div_iframe">
     <div class="widget-header">
                   <div style="float: left; margin: 0px 0.5% 0px 0px;"><h4 class="hide"><i class="icon-umbrella"></i><asp:Label ID="lbl_head" runat="server" Text="AWBLRelease"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
          <div class="crumbs">
            <ul id="breadcrumbs" class="breadcrumb">
                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                  <li><a href="#" title="">Ops & Docs</a> </li>
                <li><a href="#" id="HeaderLabel1" runat="server"></a></li>              
                <li class="current"><a href="#" title="">AWBL Release</a> </li>
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
                      <div class="btn ico-awb-Draft"><asp:Button ID="btn_draft" runat="server" Text="Draft" ToolTip="Draft"  OnClick="btn_draft_Click" /></div>
                      <div class="btn ico-awb-Original"><asp:Button ID="btn_original" runat="server" Text="Original" ToolTip="Original"  OnClick="btn_original_Click" /></div>
                      <div class="btn ico-cancel" id="btn_cancel1" runat="server"><asp:Button ID="btn_cancel" Text="Cancel" runat="server" ToolTip="Cancel"  OnClick="btn_cancel_Click"  /></div>
                  </div>
              </div>
               <div class="FormGroupContent4 boxmodal">
                   <div class="Hawbtxt1">
                        <asp:Label ID="Label2" runat="server" Text="HAWB #"></asp:Label>
                       <asp:TextBox ID="txt_hawb" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_hawb_TextChanged" 
                              placeholder="" ToolTip="HAWB Number"></asp:TextBox></div>
                   <div class="BLDate2">
                        <asp:Label ID="Label3" runat="server" Text="BL Date"></asp:Label>
                       <asp:TextBox ID="txt_bldate" runat="server" CssClass="form-control" placeholder="" ToolTip="BL Date"></asp:TextBox></div>
                           <div class="BackView">
        	<asp:LinkButton ID="lnk_Creditdet" runat="server" OnClick="lnk_Creditdet_Click" Visible="false">View OutStanding</asp:LinkButton>
        </div>
                   </div>

                      <div class="FormGroupContent4">
                  <div class="Shipper1 boxmodal">
              <div class="FormGroupContent4">
                       <asp:Label ID="Label4" runat="server" Text="Shipper"></asp:Label>
                      <asp:TextBox ID="txt_ship" runat="server" CssClass="form-control" placeholder="Shipper" ToolTip="Shipper"></asp:TextBox>
                  </div>

                      <div class="FormGroupContent4">
                      <span>Shipper Address</span>
                      <asp:TextBox ID="txt_saddress" runat="server" TextMode="MultiLine" Rows="2" Columns="20" style="resize:none;" CssClass="form-control"
            placeholder=" " ToolTip="Shipper Address"></asp:TextBox>
                  </div>

                  </div>

                  <div class="Consignee5 boxmodal">
               <div class="FormGroupContent4">
              
                       <asp:Label ID="Label5" runat="server" Text="Consignee"></asp:Label>
                      <asp:TextBox ID="txt_consignee" runat="server" CssClass="form-control" placeholder="Consignee" ToolTip="Consignee"></asp:TextBox>
                  </div>

                  <div class="FormGroupContent4">
                      <span>Consignee Address</span>
                      <asp:TextBox ID="txt_caddress" runat="server" TextMode="MultiLine" Rows="2" Columns="20" style="resize:none;" CssClass="form-control"
            placeholder=" " ToolTip="Consignee Address"></asp:TextBox>

                  </div>
                  </div>
                          </div>

                   <div class="FormGroupContent4">

                  <div class="Shipper1 boxmodal">
               <div class="FormGroupContent4">
                       <asp:Label ID="Label6" runat="server" Text="Notify Party I"></asp:Label>
                      <asp:TextBox ID="txt_notify" runat="server" CssClass="form-control" placeholder="Notify Party I" ToolTip="Notify Party I"></asp:TextBox></div>

                   <div class="FormGroupContent4">
                      <span>Notify Party I Address</span>
                      <asp:TextBox ID="txt_naddress" runat="server" TextMode="MultiLine" Rows="2" Columns="20" style="resize:none;"  CssClass="form-control"
            placeholder="" ToolTip="Notify Party I Address"></asp:TextBox>

                  </div>               
                  </div>

                     <div class="Consignee5 boxmodal">
               <div class="FormGroupContent4">
                       <asp:Label ID="Label7" runat="server" Text="Notify Party II"></asp:Label>
                      <asp:TextBox ID="txt_agent" runat="server" CssClass="form-control" placeholder="Notify Party II" ToolTip="Notify Party II"></asp:TextBox></div>

                  <div class="FormGroupContent4">
                      <span>Notify Party II Address</span>
                      <asp:TextBox ID="txt_aaddress" runat="server" TextMode="MultiLine" Rows="2" Columns="20" style="resize:none;"  CssClass="form-control"
            placeholder="" ToolTip="Notify Party II Address" Width="100%"></asp:TextBox>

                  </div>
                  </div>
                       </div>

               <div class="FormGroupContent4 boxmodal">
                  <div class="Shipper1">
                       <asp:Label ID="Label8" runat="server" Text="From Port"></asp:Label>
                      <asp:TextBox ID="txt_fromport" runat="server" CssClass="form-control" placeholder="" ToolTip="From Port"></asp:TextBox></div>
                  <div class="Consignee5">
                       <asp:Label ID="Label9" runat="server" Text="To Port"></asp:Label>
                      <asp:TextBox ID="txt_toport" runat="server" CssClass="form-control" placeholder="" ToolTip="To Port"></asp:TextBox></div>
                  </div>

                <div class="FormGroupContent4 boxmodal">
                    <div class="GrossWeight1">
                        <asp:Label ID="Label10" runat="server" Text="Gross Weight"></asp:Label>
                        <asp:TextBox ID="txt_gross" runat="server" CssClass="form-control" placeholder="" ToolTip="Gross Weight"></asp:TextBox></div>
                    <div class="WeighDrop">
                        <asp:Label ID="Label11" runat="server" Text="Weight"></asp:Label>
                        <asp:DropDownList ID="ddl_cmbwttype" runat="server" CssClass="chzn-select" ToolTip="Weight" data-placeholder="Weight" Width="100%">               
             <asp:ListItem Value="0" Text=""></asp:ListItem>
                                </asp:DropDownList></div>
                    <div class="ChargeWeigh">
                         <asp:Label ID="Label12" runat="server" Text="Charge Weight"></asp:Label>
                        <asp:TextBox ID="txt_charge" runat="server" CssClass="form-control" placeholder="" ToolTip="Charge Weight"></asp:TextBox> </div>
                    <div class="Commodity2">
                         <asp:Label ID="Label13" runat="server" Text="Commodity"></asp:Label>
                        <asp:TextBox ID="txt_commodity" runat="server" CssClass="form-control" placeholder="" ToolTip="Commodity"></asp:TextBox></div>
              <div class="FormGroupContent4 DropTop">
                       <asp:Label ID="Label14" runat="server" Text="AWB Stationery"></asp:Label>
                  <asp:DropDownList data-placeholder="AWB Stationery" ID="ddl_awb" runat="server" CssClass="chzn-select" ToolTip="AWB Stationery" Width="100%">
             <asp:ListItem Text="" Value="0"></asp:ListItem>
                             </asp:DropDownList>
                  </div>
                    </div>
              <div class="FormGroupContent4 boxmodal">
             
              <div class="FormGroupContent4 custom-py-3">
                  <div class="Agree"><asp:RadioButton ID="rdb_agreed" runat="server" Text="Agreed" GroupName="radio" /></div>
                  <div class="Rate3"><asp:RadioButton ID="rdb_rate" runat="server" Text="Rate" GroupName="radio"/></div>
                  <div class="Without">
                        <span class="chktext">WithOut Notify Party 1</span>
                                    <asp:CheckBox ID="chk_notify" runat="server" />

                  </div>
                  
                  <div class="Without">
                        <span class="chktext">WithOut Notify Party 2</span>
                                    <asp:CheckBox ID="chk_notify2" runat="server" />
                                </div>
                 
                  </div>
                  </div>
               

              <div class="FormGroupContent4">
                  <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl1" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Do you want Send Pdf Format ?</b></div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btn_yes" runat="server" Text="OK" CssClass="Button" OnClick="btn_yes_Click" />
            <asp:Button ID="btn_no" runat="server" Text="Cancel" CssClass="Button" OnClick="btn_no_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>
              </div>

                <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label id="lbl_no" runat="server">HAWB #:</label>

                                </div>
                                <div class="LogHeadJobInput">

                                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                                </div>

                            </div>
                            <div class="DivSecPanel">
                                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>

                            <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl">

                                <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false"
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
           </div>

         <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="PopUpService" runat="server" BackgroundCssClass=""
        PopupControlID="Panel_Service" TargetControlID="Label1">
    </asp:ModalPopupExtender>
    <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>

     <%-- Elengo --%>
    <asp:Label ID="LblCncl" runat="server"></asp:Label>
    <asp:ModalPopupExtender ID="PopCreditdet" runat="server" TargetControlID="LblCncl"
        BehaviorID="frgtydfdfdf" PopupControlID="pnlCreditdet" CancelControlID="imgcls" DropShadow="false">
    </asp:ModalPopupExtender>

    <asp:Panel ID="pnlCreditdet" runat="server" CssClass="modalPopup" Style="display: none;">
        <div class="OutStandingLbl1">
            <h3>Out Standing</h3>
        </div>
        <div class="OutStandingLbl2">Credit Customerwise OutStanding - <span id="CustomerLbl1" runat="server"></span></div>
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="imgcls" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:GridView ID="grdCridtDet" runat="server" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False"
                OnRowDataBound="grdCridtDet_RowDataBound" OnPreRender="grdCridtDet_PreRender">
                <Columns>
                    <asp:BoundField DataField="shortname" HeaderText="Branch">
                        <HeaderStyle />
                    </asp:BoundField>
                    <%-- 0 --%>
                    <asp:BoundField DataField="customername" HeaderText="Individual Customer  Names">
                        <HeaderStyle Width="250px" />
                        <ItemStyle Width="250px" />
                    </asp:BoundField>
                    <%-- 1 --%>
                    <asp:BoundField DataField="invoiceno" HeaderText="Vou #">
                        <HeaderStyle />
                    </asp:BoundField>
                    <%-- 2 --%>
                    <asp:BoundField DataField="invdate" HeaderText="Date">
                        <HeaderStyle />
                    </asp:BoundField>
                    <%-- 3 --%>
                    <asp:BoundField DataField="days" HeaderText="O/S Days">
                        <HeaderStyle />
                    </asp:BoundField>
                    <%-- 4 --%>
                    <asp:BoundField DataField="osamount" HeaderText="O/S Amt" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                        <HeaderStyle />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <%-- 5 --%>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <RowStyle Font-Italic="False" />
            </asp:GridView>
            <div class="Break"></div>
        </div>
        <div class="Break"></div>
    </asp:Panel>

    <asp:HiddenField ID="hd_hawl" runat="server" /> 
        <asp:HiddenField ID="hid_WCP" runat="server" />    
     <asp:HiddenField ID="hid_WCC" runat="server" />        
    <asp:HiddenField ID="hid_TOCDAP" runat="server" />
    <asp:HiddenField ID="hid_TOCDCP" runat="server" />
        <asp:HiddenField ID="hid_TOCDAC" runat="server" />
    <asp:HiddenField ID="hid_TOCDCC" runat="server" />
        <asp:HiddenField ID="hid_CustomerId" runat="server" />
    <asp:HiddenField ID="hid_CustomerName" runat="server" />
</asp:Content>
