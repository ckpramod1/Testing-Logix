<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ShipmentStatus.aspx.cs" Inherits="logix.CRM.ShipmentStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
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
    <link href="../Theme/assets/css/systemcrm.css" rel="stylesheet" type="text/css" />
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

    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>












    <%--<link rel="Stylesheet" href="../Styles/ControlStyle.css" />--%>
    <script type="text/javascript" src="../Scripts/Validation.js"></script>
    <link href="../Styles/ShipmentStatus.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {

                $("#<%=txt_imailid.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_imailid.ClientID %>").val(0);
                        $.ajax({
                            url: "../CRM/ShipmentStatus.aspx/IMailID",
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
                        $("#<%=hf_imailid.ClientID %>").val(i.item.val);
                        $("#<%=hf_imailname.ClientID %>").val(i.item.label);
                        $("#<%=txt_imailid.ClientID %>").change();
                    },
                    change: function (e, i) {
                        $("#<%=hf_imailid.ClientID %>").val(i.item.val);
                        $("#<%=hf_imailname.ClientID %>").val(i.item.label);
                    },
                    focus: function (e, i) {
                        $("#<%=hf_imailid.ClientID %>").val(i.item.val);
                        $("#<%=hf_imailname.ClientID %>").val(i.item.label);
                    },
                    close: function (e, i) {
                        $("#<%=hf_imailid.ClientID %>").val(i.item.val);
                        $("#<%=hf_imailname.ClientID %>").val(i.item.label);
                    },
                    minLength: 1
                });
            });



            $(document).ready(function () {

                $("#<%=txt_cmailid.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_cmailid.ClientID %>").val(0);

                        $.ajax({
                            url: "../CRM/ShipmentStatus.aspx/CMailID",
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
                        $("#<%=hf_cmailid.ClientID %>").val(i.item.val);
                        $("#<%=hf_cmailname.ClientID %>").val(i.item.label);
                    },

                    minLength: 1
                });
            });
        }
    </script>
    <style type="text/css">
        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .GridHeader1 {
            background-color: navy;
            color: White;
            font-family: sans-serif;
            font-size: 11px;
            margin-left: -0.3%;
            margin-top: -1.7%;
            position: absolute;
            width: 1027px;
        }

        .Hide {
            display: none;
        }

      

        #logix_CPH_Mdl_grdjob_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }



        .modalPopupss {
            background-color: #FFFFFF;
            border-width: 1px;
            border-style: solid;
            border-color: #CCCCCC;
            width: 1062px;
            width: 98%;
            height: 496px;
            margin-left: 0%;
            margin-top: -0.9%;
            padding: 1px;
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

        .JobInput2 {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BookingInput3 {
            width: 12.6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .AddbuttonNew {
            float: left;
            margin: 18px 0px 0px 0px;
            width: 8%;
        }

        .BorderCont {
           
            width: 100%;
            min-height: 188px;
            overflow: auto;
            float: left;
        }

       


        {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
        }
        /*thead {
  position: relative;
  display: block;
  width: 100%;
  overflow: visible;
}

 tbody {
  position: relative;
  display: block; 
  width: 100%;
  height: 100px;
  overflow: auto;
}*/


        /*th:nth-child(1) {
  min-width: 615px;
}
 td:nth-child(1) { 
  min-width: 615px;
}*/

        /*FixedHeader2*/

        /*2 {
  position: relative;
  width: 100%;
  overflow: hidden;
  border-collapse: collapse;
}
2 thead {
  position: relative;
  display: block;
  width: 100%;
  overflow: visible;
}

2 tbody {
  position: relative;
  display: block; 
  width: 100%;
  height: 100px;
  overflow: auto;
}

      
2 th:nth-child(1) {
  min-width: 615px;
}
2 td:nth-child(1) { 
  min-width: 615px;
}*/
        a#logix_CPH_lbl_booking {
            font-size: 11px;
            font-family: sans-serif;
        }

        a#logix_CPH_lbl_job {
            font-size: 11px;
            font-family: sans-serif;
        }

        .btn.btn-add-icon-blue {
            margin: 12px 0 0 5px;
            padding-top: 3px;
        }

        a#logix_CPH_lbl_job {
            color: var(--labelblack);
            display: inline-block;
        }

        .widget-content a {
            color: #ee3926;
        }
        .BorderCont.TextField.TextArea {
    border: 0;
}
        .BorderCont.TextArea {
    position: relative;
    background: white;
   
}
  .Left1 {
    float: left;
    width: 48.5%;
    position: relative;
    border: 0px solid var(--inputborder);
    border-radius: 0px;
    margin-right: 1%!important;
    height: 161px;
        margin-top: 10px !important;
        border-bottom: 1px solid var(--inputborder);
}
        input[type="file"] {
    height: 36px;
    padding: 8px;
    background: white;
    border: 1px solid #b0aeae !important;
}
    
     
        .Attachmentlbl {
    width: 14%;
    float: left;
    margin: 20px 5px 0px 8px;
}
        .GroupLeft1 {
    margin-right: 0.5% !important;
}
    
        .CustomerLeft {
    width: 50%;
    float: left;
    margin-right: 0.5% !important;

}
        .BrowseBtn {
    width: 39%;
    float: left;
}
     span#logix_CPH_lbl_attachment {
    color: rgb(6, 82, 156);
    font-size: 14px;
}
     span#logix_CPH_lbl_containers {
       position: absolute !important;
    top: 0px !important;
    color: rgb(6, 82, 156);
    font-weight: 500 !important;
    font-size: 14px !important;
}
     input#logix_CPH_fu_attach {
    border: none !important;
    border-bottom: 1px solid var(--inputborder) !important;
}
        .CustomerLeft {
    width: 50%;
    float: left;
    margin-right: 0.5%!important;
}
      
        .Left1 table {
    background: white;
    border-radius: 3px;
}
        .btn.btn-send1 {
    margin-top: 10px;
}
        .PolInput6 {
    width: 14%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .BLNoInput2 {
    width: 10.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}
        .StuffedInput {
    width: 13.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .MVesselInputN1 {
    width: 34.9%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .Agent {
    float: left;
    width: 50.5%;
    margin: 0px;
}
        .Shipper {
    width: 49%;
}
        .FormGroupContent4.TextArea {
    height: 89%!important;
    background: white;
    margin: 10px 0px 0px!important;
    border-radius: 0px;
    padding: 20px 5px 0;
}
        #logix_CPH_lst_sbdate {
    height: 130px !important;
    border: none !important;
}
        span#logix_CPH_lbl_sbdate {
    top: -4px !important;
}
        .FormGroupContent4.TextArea.TextField {
    border-bottom: 1px solid var(--inputborder) !important;
}
        .TxtboxN1 {
    float: left;
    margin: 0px 0.5% 0px 0px;
    width: 93%;
}
  
            table#logix_CPH_grd_cmail {
    border: none;
}
            .VesselVoy {
    width: 18%;
    float: left;
    margin: 0px 5px 0px 0px;
}

/*New Design - Buttons*/


div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        </asp:UpdatePanel>
    </div>


    <!-- /Breadcrumbs line -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_header" runat="server" Text="Shipment Status"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li><a href="#" title="">Customer Support</a> </li>
                            <li id="lblHead1" runat="server"><a href="#" title="" id="headerlable1" runat="server"></a></li>

                            <li class="current"><a href="#" title="">Shipment Status</a> </li>
                        </ul>
                    </div>
                        </div>

                    <div class="FixedButtons">
     <div class="right_btn">
    <div class="btn ico-save" id="btn_save1" runat="server">
        <asp:Button ID="btn_save" runat="server" ToolTip="Save" Text="Save"  OnClick="btn_save_Click" TabIndex="4" />
    </div>
    <div class="btn ico-back" id="btn_back1" runat="server">
        <asp:Button ID="btn_back" runat="server" ToolTip="Cancel/Back" Text="Back" OnClick="btn_back_Click" TabIndex="5" />
    </div>

    <div class="btn ico-send-mail">
        <asp:Button ID="btn_send" runat="server" ToolTip="Send Mail" Text="Send Mail" TabIndex="12" OnClick="btn_send_Click" />
    </div>
</div>
</div>

                </div>
                <div class="widget-content">
                    

                    <div class="FormGroupContent4 boxmodal">

                        <div class="JobInput2">
                              <span>Job #</span>
                  
                            <asp:TextBox ID="txt_job" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txt_job_TextChanged" TabIndex="1" placeholder="Job #" ToolTip="Job #"></asp:TextBox>
                        </div>
                            <asp:LinkButton ID="lbl_job" runat="server" CssClass="anc ico-find-sm" OnClick="lbl_job_Click"></asp:LinkButton>

                        <div class="VesselVoy">
                            <asp:Label ID="lbl_vvoy" runat="server" Text="Vessel & Voy"> </asp:Label>
                            <asp:TextBox ID="txt_vvoy" runat="server" CssClass="form-control" Enabled="false" placeholder="" ToolTip="Vessel & Voy"></asp:TextBox>
                        </div>
                        <div class="PolInput6">
                            <asp:Label ID="Label2" runat="server" Text="PoL"> </asp:Label>
                            <asp:TextBox ID="txt_pol" runat="server" CssClass="form-control" placeholder="" Enabled="false" ToolTip="Port of Loading"></asp:TextBox>
                        </div>
                        <div class="ETDInput2">
                            <asp:Label ID="Label3" runat="server" Text="ETD"> </asp:Label>
                            <asp:TextBox ID="txt_etd" runat="server" CssClass="form-control" placeholder="" Enabled="false" ToolTip="Estimated Time of Departure"></asp:TextBox>
                        </div>
                        <div class="PODInput5">
                            <asp:Label ID="Label4" runat="server" Text="PoD"> </asp:Label>
                            <asp:TextBox ID="txt_pod" runat="server" CssClass="form-control" placeholder="" Enabled="false" ToolTip="Port of Discharge"></asp:TextBox>
                        </div>
                        <div class="ETAInput2">
                            <asp:Label ID="Label5" runat="server" Text="ETA"> </asp:Label>
                            <asp:TextBox ID="txt_eta" runat="server" CssClass="form-control" placeholder="" Enabled="false" ToolTip="Estimated Time of Arrival"></asp:TextBox>
                        </div>

                        <div class="BookingInput3 LinkButton">
                    <span>Booking #</span>

                            <asp:TextBox ID="txt_booking" runat="server" TabIndex="2" CssClass="form-control" placeholder="Booking #" ToolTip="Booking #" Enabled="false"></asp:TextBox>
                        </div>
                            <asp:LinkButton ID="lbl_booking" CssClass="anc ico-find-sm" runat="server" ForeColor="red" OnClick="lbl_booking_Click"></asp:LinkButton>

                         <div class="BLNoInput2">
                            <asp:Label ID="Label8" runat="server" Text="BL #"> </asp:Label>
                            <asp:TextBox ID="txt_bl" runat="server" CssClass="form-control" Enabled="false" placeholder="" ToolTip="BL #"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="GroupLeft1 boxmodal">
                    <div class="FormGroupContent4">                       
                        <div class="StuffedInput">
                            <asp:Label ID="Label9" runat="server" Text="Stuffed on"> </asp:Label>
                            <asp:TextBox ID="txt_stuffedon" runat="server" CssClass="form-control" Enabled="false" placeholder="" ToolTip="Stuffed on"></asp:TextBox>
                        </div>
                        <div class="MVesselInputN1">
                            <asp:Label ID="lbl_mvessel" runat="server" Text="Vessel & Voy "> </asp:Label>
                            <asp:TextBox ID="txt_mvessel" runat="server" CssClass="form-control" Enabled="false" placeholder="" ToolTip="Vessel"></asp:TextBox>
                        </div>
                          <div class="Agent">
                                <asp:Label ID="Label13" runat="server" Text="Agent"> </asp:Label>
                                <asp:TextBox ID="txt_agent" runat="server" CssClass="form-control" Enabled="false" Placeholder="" ToolTip="Agent"></asp:TextBox>
                            </div>                          
                    </div>
                          <div class=" FormGroupContent custom-d-flex">
                              <div class="Shipper custom-mr-05">
                                <asp:Label ID="Label11" runat="server" Text="Shipper"> </asp:Label>
                                <asp:TextBox ID="txt_shipper" runat="server" CssClass="form-control" Enabled="false" placeholder="" ToolTip="Shipper"></asp:TextBox>
                                  </div>
                            <div class="custom-col">
                                <asp:Label ID="Label12" runat="server" Text="Consignee"> </asp:Label>
                                <asp:TextBox ID="txt_consignee" runat="server" Enabled="false" CssClass="form-control" placeholder="" ToolTip="Consignee"></asp:TextBox>
                            </div>
                            </div>
                          
                             <div class="FormGroupContent4">
                        <asp:Label ID="Label14" runat="server" Text="Status"> </asp:Label>
                        <asp:TextBox ID="txt_status" runat="server" CssClass="form-control" TextMode="MultiLine" Style="resize: none;" TabIndex="3" Rows="2" Height="60px" placeholder="" ToolTip="Status"></asp:TextBox>
                    </div>
                        </div>
                        <div class="GroupRright1 ">
                            <div class="Left1 boxmodal custom-mr-05">
                                <div class="FormGroupContent4 TextArea">
                                <asp:Label ID="lbl_containers" runat="server" Text="Container #"></asp:Label>
                                    <asp:CheckBoxList ID="chk_containers" runat="server" Width="100%" ToolTip="Containers">
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                            <div class="Right1 boxmodal">
                                <div class="FormGroupContent4 TextArea">
                                <asp:Label ID="lbl_sbdate" runat="server" Text="SB # / SB Date"></asp:Label>
                                    <asp:ListBox ID="lst_sbdate" runat="server" Width="99%" Height="100%" Style="border: none;"></asp:ListBox>
                                </div>
                            </div>

                        </div>

                    </div>
                   

                    <div class="FormGroupContent4">
                        <div class="CustomerLeft boxmodal">
                        <div class="Attachmentlbl">
                            <asp:Label ID="lbl_attachment" runat="server" Text="Attachment"></asp:Label>
                        </div>
                        <div class="BrowseBtn">
                            <asp:FileUpload ID="fu_attach" runat="server" Width="99%" TabIndex="11" />
                        </div>
                    </div>
                   
                    </div>

                    <div class="FormGroupContent4 hide">
                        <div class="CustomerLeft boxmodal">
                            <div class="TxtboxN1">
                                <asp:Label ID="Label15" runat="server" Text="Customer Mail-ID's"> </asp:Label>
                                <asp:TextBox ID="txt_cmailid" TabIndex="6" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="" ToolTip="Customer Mail-ID's" OnTextChanged="txt_cmailid_TextChanged"></asp:TextBox>
                            </div>
                            <div class="btn ico-add custom-mt-2">
                                <asp:Button ID="btn_plus" runat="server" Text="" TabIndex="7" CssClass="Button" OnClick="btn_plus_Click" />
                            </div>
                            <div class="FormGroupContent4">

                                <div class="panel_06 MB0">
                                    <asp:Panel ID="pnl_cmail" runat="server">
                                        <asp:GridView ID="grd_cmail" runat="server" CssClass="Grid FixedHeader" TabIndex="9" AutoGenerateColumns="False"
                                            Width="100%" ShowHeaderWhenEmpty="true" OnPreRender="grd_cmail_PreRender">
                                            <Columns>
                                                <asp:BoundField DataField="mailid" HeaderText="Customer's Mail - ID">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                        <div class="CustomerRight boxmodal">
                            <div class="TxtboxN2">
                                <asp:Label ID="Label16" runat="server" Text="Internal Mail-ID's"> </asp:Label>
                                <asp:TextBox ID="txt_imailid" runat="server" TabIndex="8" CssClass="form-control" AutoPostBack="True" placeholder="" ToolTip="Internal Mail-ID's"
                                    OnTextChanged="txt_imailid_TextChanged"></asp:TextBox>
                            </div>

                            <div class="FormGroupContent4">

                                <div class="panel_06 MB0">
                                    <asp:Panel ID="pnl_imail" runat="server">
                                        <asp:GridView ID="grd_imail" runat="server" CssClass="Grid FixedHeader" TabIndex="10" AutoGenerateColumns="False"
                                            Width="100%" ShowHeaderWhenEmpty="true" OnPreRender="grd_imail_PreRender">
                                            <Columns>
                                                <asp:BoundField DataField="mailid" HeaderText="Internal's Mail - ID">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
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
                    
                    <div class="FormGroupContent4">
                        <asp:Panel ID="pnl_job_popup" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                            <div class="divRoated">
                                <div class="DivSecPanel">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                </div>

                                <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">
                                    <asp:GridView ID="grd_job" runat="server" CssClass="Grid FixedHeader" OnRowDataBound="grd_job_RowDataBound" Width="100%"
                                        AutoGenerateColumns="False" PageSize="18" AllowPaging="false" OnPageIndexChanging="grd_job_PageIndexChanging"
                                        OnSelectedIndexChanged="grd_job_SelectedIndexChanged">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Job">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 55px">
                                                        <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="55px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="VesselName">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 130px">
                                                        <asp:Label ID="VesselName" runat="server" Text='<%# Bind("vessel") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="130px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Voyage">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 50px">
                                                        <asp:Label ID="Voyage" runat="server" Text='<%# Bind("voyage") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="50px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="MBL">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 130px">
                                                        <asp:Label ID="MBL" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="130px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ETD">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                                        <asp:Label ID="ETD" runat="server" Text='<%# Bind("etd") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="70px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Destination">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                        <asp:Label ID="Destination" runat="server" Text='<%# Bind("sd") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="120px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ETA">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 90px">
                                                        <asp:Label ID="ETA" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="90px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="MLO">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 193px">
                                                        <asp:Label ID="MLO" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="193px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>


                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <RowStyle Font-Italic="False" />
                                        <PagerStyle CssClass="GridviewScrollPager" />
                                    </asp:GridView>
                                </asp:Panel>
                            </div>
                        </asp:Panel>

                        <div class="">
                            <asp:Panel ID="pnl_book_popup" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                <div class="divRoated">
                                    <div class="DivSecPanel">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                    </div>

                                    <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">
                                        <asp:GridView ID="grd_book" runat="server" AutoGenerateColumns="False" OnRowDataBound="grd_book_RowDataBound"
                                            CssClass="Grid FixedHeader" AllowPaging="false" PageSize="18" OnPageIndexChanging="grd_book_PageIndexChanging"
                                            Width="100%" OnSelectedIndexChanged="grd_book_SelectedIndexChanged">
                                            <Columns>

                                                <asp:TemplateField HeaderText="Booking">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 115px">
                                                            <asp:Label ID="Booking" runat="server" Text='<%# Bind("bookingno") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="162px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Customer">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 225px">
                                                            <asp:Label ID="Customer" runat="server" Text='<%# Bind("customername") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="312px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="POL">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                                            <asp:Label ID="POL" runat="server" Text='<%# Bind("POL") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="209px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="POD">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 145px">
                                                            <asp:Label ID="POD" runat="server" Text='<%# Bind("POD") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="202px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Booking Date">
                                                    <ItemTemplate>
                                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 90px">
                                                            <asp:Label ID="Booking_Date" runat="server" Text='<%# Bind("bookingdate") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="true" Width="125px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>



                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle Font-Italic="False" />
                                            <PagerStyle CssClass="GridviewScrollPager" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </div>
                                <div class="div_Break"></div>

                            </asp:Panel>
                        </div>
                        <div class="div_Break"></div>
                        <asp:HiddenField ID="hf_cmailid" runat="server" />
                        <asp:HiddenField ID="hf_imailid" runat="server" />
                        <asp:HiddenField ID="hf_imailname" runat="server" />
                        <asp:HiddenField ID="hf_cmailname" runat="server" />
                        <div>
                            <%--<asp:Button ID="Button2" runat="server" Text="Button" style="display:none;" />--%>
                            <asp:ModalPopupExtender ID="Mdl_grdjob" runat="server" DropShadow="false"
                                CancelControlID="Image1" PopupControlID="pnl_job_popup" TargetControlID="lbljob" BehaviorID="Test">
                            </asp:ModalPopupExtender>
                            <asp:HiddenField ID="hf_job" runat="server" />

                            <asp:Label ID="lbljob" runat="server"></asp:Label>
                            <asp:HiddenField ID="hf_jobno" runat="server" />
                        </div>
                        <div class="div_Break"></div>
                        <div>
                            <asp:ModalPopupExtender ID="Mdl_grdbook" runat="server"
                                CancelControlID="Image2" PopupControlID="pnl_book_popup" TargetControlID="hidbook">
                            </asp:ModalPopupExtender>
                            <asp:HiddenField ID="hf_book" runat="server" />
                            <asp:HiddenField ID="hf_bookno" runat="server" />
                            <asp:Label ID="hidjob" runat="server" />
                            <asp:Label ID="hidbook" runat="server" />
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
