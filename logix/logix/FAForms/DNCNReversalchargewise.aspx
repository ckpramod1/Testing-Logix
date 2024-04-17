<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="DNCNReversalchargewise.aspx.cs" Inherits="logix.FAForm.DNCNReversalchargewise" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/adjustmentlegerwise.css" rel="stylesheet" />
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />

    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />  
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- App -->
        <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
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
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />

    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {

            });
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

        //function addCommas(clientID) {
        //    var nStr = document.getElementById(clientID.id).value;
        //    nStr += '';
        //    x = nStr.split('.');
        //    if (!x[0]) {
        //        x[0] = "0";
        //    }
        //    x1 = x[0];
        //    if (!x[1]) {
        //        x[1] = "00";
        //    }
        //    x2 = x.length > 1 ? '.' + x[1] : '';
        //    var rgx = /(\d+)(\d{3})/;
        //    while (rgx.test(x1)) {
        //        x1 = x1.replace(rgx, '$1' + ',' + '$2');
        //    }

        //    document.getElementById(clientID.id).value = x1 + x2;
        //    return true;
        //}

    </script>
    <%--  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id*=chkHeader]').click(function () {
                $("[id*='chkChild']").attr('checked', this.checked);
            });
        });
               </script>--%>

    <%--<script type="text/javascript" language="javascript"> functionCheckall(Checkbox) { var Grd_Charge = document.getElementById("<%=Grd_Charge.ClientID %>"); 
     for (i = 1; i < Grd_Charge.rows.length; i++) { Grd_Charge.rows[i].cells[3].getElementsByTagName( "INPUT")[0].checked=Checkbox.checked; } } 
    </script> --%>

    <script type="text/javascript">
        function disableBtn(btnID, newText) {
            //initialize to avoid 'Page_IsValid is undefined' JavaScript error
            Page_IsValid = null;
            //check if the page request any validation
            // if yes, check if the page was valid
            if (typeof (Page_ClientValidate) == 'function') {
                Page_ClientValidate();
                //you can pass in the validation group name also
            }
            //variables
            var btn = document.getElementById(btnID);
            var isValidationOk = Page_IsValid;
            /********NEW UPDATE************************************/
            //if not IE then enable the button on unload before redirecting/ rendering
            if (navigator.appName !== 'Microsoft Internet Explorer') {
                EnableOnUnload(btnID, btn.value);
            }
            /***********END UPDATE ****************************/
            // isValidationOk is not null
            if (isValidationOk !== null) {
                //page was valid
                if (isValidationOk) {
                    btn.disabled = true;
                    btn.value = newText;
                    btn.style.background = 'url(~/images/ajax-loader.gif)';
                }
                else {//page was not valid
                    btn.disabled = false;
                }
            }
            else {//the page don't have any validation request
                setTimeout("setImage('" + btnID + "')", 10);
                btn.disabled = true;
                btn.value = newText;
            }
        }

        //set the background image of the button
        function setImage(btnID) {
            var btn = document.getElementById(btnID);
            btn.style.background = 'url(images/Loading.gif)';
        }

        //enable the button and restore the original text value
        function EnableOnUnload(btnID, btnText) {
            window.onunload = function () {
                var btn = document.getElementById(btnID);
                btn.disabled = false;
                btn.value = btnText;
            }
        }
    </script>

    <link href="../Styles/CNInvAdjustmentOSDN.css" rel="stylesheet" />
    <style type="text/css">
        .Hide {
            display: none;
        }

        .InvDateLbl {
            width: 2.5%;
            margin: 0px 0px 0px 0px;
            float: left;
            font-size: 11px;
        }

        .Pnl {
            height: 15% !important;
            border: 1px solid #b1b1b1 !important;
            background-color: #fff;
            padding: 5px 5px 5px 5px;
        }

        .div_confirm {
            /*Border:1px solid red;*/
            width: 100%;
            float: left;
            margin-left: 1%;
            margin-top: 0%;
            text-align: center;
        }

        .INVLbl {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .InvLbl1 {
            width: 8%;
            float: left;
            margin: 0px 0.5%  0px 0px;
        }

        .VoucherDrop1 {
            width: 14.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .INVLblTran {
            width: 11.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Save-btn {
            margin: 0px 5px 5px 0px;
            float: left;
        }

            .Save-btn input {
                background-color: #99c794;
                border: none;
                float: left;
                padding: 5px 10px 5px 10px;
                color: #ffffff;
                font-size: 11px;
            }

        .Cancel-btn input {
            background-color: #d02027;
            border: none;
            padding: 5px 10px 5px 10px;
            font-size: 11px;
            color: #ffffff;
        }

        .INVNoinput {
            width: 27%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .InvNo {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .INVNoinput1 {
            width: 27%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FormGroupContent4 .InvShipper textarea {
            height: 80px !important;
        }

        .FormGroupContent4 .InvCustomer textarea {
            height: 80px !important;
        }

        .INVYear {
            width: 6.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_ddl_base_chzn {
            width: 100% !important;
        }

        .Curr4 {
            width: 4%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Rate6 {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ExRate7 {
            width: 4.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Base1 {
            width: 4%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .chzn-search input {
            width: 100% !important;
        }

        .Amount11R1 {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Amount11R {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .row {
            height: 576px !important;
            /* margin: 0px 5px 0px -15px; */
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

        .ChargeDes {
            width: 17.9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Amount11D {
            width: 5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Amount11 {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Amount12 {
            width: 6.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .widget {
            margin-top: 0px;
            margin-bottom: 5px;
            padding: 0px;
        }

        .TotalInputN2 {
            width: 8%;
            float: left;
                margin: 0 0.2% 0 0;

        }

        .TotalInputNUnit {
            width: 6.2%;
            float: left;
                margin: 0 0.2% 0 0;
        }

        .TotalInputN1 {
            width: 2.5%;
            float: right;
            margin: 0px 0.5% 0px 0px 0px;
        }

        .AmountTxtBox {
            width: 6%;
            float: left;
            margin: 0px 0.2% 0px 0px;
        }

        .GstTxtBox {
            width: 7.5%;
            float: left;
            margin: 0px 0.2% 0px 0px;
        }

        .NetTxtBox {
            width: 8%;
            float: left;
            margin: 0px 0.2% 0px 0px;
        }

        .RevTxtBox {
            width: 7.5%;
            float: left;
            margin: 0px 0.2% 0px 0px;
        }

        .RevAmountTxtBox {
            width: 8.5%;
            float: left;
            margin: 0px 0.2% 0px 0px;
        }

        .RevGstTxtBox {
            width: 7.5%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .RevNetTxtBox {
            width: 6.8%;
            float: left;
            margin: 0px 0.2% 0px 0px;
        }

        .DiffTxtBox {
            width: 8.5%;
            float: left;
            margin: 0px 0.2% 0px 0px;
        }

        .DiffGstTxtBox {
            width: 6.8%;
            float: left;
            margin: 0px 0.2% 0px 0px;
        }

        .DivSecPanelLog {
            float: right;
            margin: 0px 0px 0px 0px;
        }

        .modalPopupssLog {
            width: 96.8%;
            background-color: #fff;
            border: 1px solid #b1b1b1;
            height: 450px;
        }

        .modalPopupssLogn1 {
            width: 96.8%;
            background-color: #fff;
            border: 1px solid #b1b1b1;
            height: 495px;
        }

        .LogHeadJob {
            font-size: 13px;
            color: #d02027;
            font-weight: bold;
            margin: 4px 5px 0px 5px;
            float: left;
            width: 110px;
        }

            .LogHeadJob label {
                width: 110px !important;
                font-weight: bold;
            }

        .LogHeadJobInput {
            color: #4e4e4c;
            font-size: 13px;
            margin: 4px 0px 0px 4px;
            width: 250px;
            float: left;
        }

        .TblFixed {
            table-layout: fixed;
        }

        .Amount11D1 {
            width: 5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Amount11D2 {
            width: 5.3%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .Unit1 {
            width: 4.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Amount11Gst {
            width: 5.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Grid2 {
            overflow-x: auto !important;
        }

        .DivSecPanelLog {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-right: 0%;
            margin-top: 0.3%;
            border-radius: 90px 90px 90px 90px;
            z-index: 999999;
            position: relative;
            float: right;
        }

        #logix_CPH_Panel2 {
            top: 82px !important;
            left: 19px !important;
        }

        .JournalTxt {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .JournalDate {
            float: right;
            width: 6%;
            margin: 0px 0% 0px 0px;
        }

        .TotalJInput {
            float: right;
            width: 20%;
            margin: 0px 0% 0px 0px;
        }

        .GridJournal {
            width: 100%;
            height: 263px;
            border: 1px solid #b1b1b1;
            overflow: auto;
        }

        .FormGroupContent4 select {
            border: 1px solid #b1b1b1;
            color: #4e4e4c;
        }

        label, input, button, select, textarea {
            font-size: 11px;
            font-family: sans-serif;
        }

        select, option {
            color: #4e4e4c;
            font-size: 11px;
            font-family: sans-serif;
        }

        .FormGroupContent4 #logix_CPH_Panel2 span {
            font-size: 14px;
        }

        .JouJobNo {
            float: left;
            width: 15%;
            margin: 0px 0.5% 6px 0px;
        }

        .DivSecPanelLogn1 {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-right: 0.5%;
            margin-top: -2%;
            border-radius: 90px 90px 90px 90px;
            z-index: 999999;
            position: relative;
            float: right;
        }
        /*CSS*/

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
            margin-left: 0% !important;
            margin-top: -16.9% !important;
            overflow: auto;
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
            white-space: nowrap;
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

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            /*color: #000080;*/
            font-size: 11px;
        }

        .FormGroupContent4 label {
            /*color: #000080;*/
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .LogHeadJobInput label {
            font-size: 11px;
            font-family: sans-serif;
            color: #4e4e4c;
        }
        .widget.box{
    position: relative;
    top: -8px;
}
/*.gridpnl {
    height: calc(100vh - 385px);
}*/
.widget.box .widget-content {
    top: 0px !important;
    padding-top: 65px !important;
}
div#UpdatePanel1 {
    height: 88vh;
    overflow-x: hidden;
    overflow-y: auto;
}
div#logix_CPH_btn_add1 {
    margin: 0px 0px 0px 4px;
}


    </style>
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <%-- <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {
               
            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

        }

    </script>--%>

    <link href="../Styles/DNCNReversal.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
   
    <div >
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text="Chargewise Reversal"></asp:Label>
                    </h4>
                     <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#">Home</a> </li>
            <li><a href="#">Utility</a> </li>
            <li><a href="#" title="">Chargewise Reversal</a> </li>
            <li>
                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>


                    <div class="FixedButtons">

      <div class="right_btn">
          <div class="btn ico-delete" id="del_id" runat="server" Visible="false">
              <asp:Button ID="btn_VouCancel" Text="Vou Cancel" runat="server" Visible="false" ToolTip="Vou Cancel" OnClick="btn_VouCancel_Click" />
          </div>
          <div class="btn ico-reverse-charge">
              <asp:Button ID="btn_reverse" runat="server" Text="Reverse" ToolTip="Reverse" OnClick="btn_reverse_Click" OnClientClick="disableBtn(this.id, 'Loading...')" UseSubmitBehavior="False" />
          </div>
          <div class="btn ico-cancel" id="btn_cancel1" runat="server">
              <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
          </div>
      </div>

  </div>


                </div>

                <div class="widget-content">
                      
                    <div class="FormGroupContent4 boxmodal">

                        <div class="VoucherDrop1 fit-content">
                            <asp:Label ID="lbl_voucher" runat="server" Text="Voucher Type"></asp:Label>
                            <asp:DropDownList ID="ddl_voucher" CssClass="chzn-select" data-placeholder="Voucher Type" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddl_voucher_SelectedIndexChanged" Height="23px">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                                <%--<asp:ListItem Value="1">Invoice</asp:ListItem>
                                <asp:ListItem Value="2">Credit Note Operations</asp:ListItem>
                                <asp:ListItem Value="3">BOS</asp:ListItem>
                                <asp:ListItem Value="4">OSDN</asp:ListItem>
                                <asp:ListItem Value="5">OSCN</asp:ListItem>
                                <asp:ListItem Value="6">Debit Note</asp:ListItem>
                                <asp:ListItem Value="7">Credit Note</asp:ListItem>
                                <asp:ListItem Value="8">DN-Admin</asp:ListItem>
                                <asp:ListItem Value="9">CN-Admin</asp:ListItem>
                                <asp:ListItem Value="10">Journal</asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                        <div class="INVLbl">

                            <asp:Label ID="lbl_receipt" runat="server" Text="Inv #"></asp:Label>

                            <asp:TextBox ID="txt_receipt" runat="server" AutoPostBack="True" Enabled="false" CssClass="form-control" ToolTip="Vou #" placeholder="" OnTextChanged="txt_receipt_TextChanged"></asp:TextBox>

                        </div>

                        <div class="InvLbl1">
                            <asp:Label ID="lbl_date" runat="server" Text="Date"></asp:Label>
                            <asp:TextBox ID="txt_date" runat="server" CssClass="form-control" placeholder=" " ToolTip="Vou Date"></asp:TextBox>
                        </div>

                        <div class="INVLblTran">
                            <asp:Label ID="Label7" runat="server" Text="Product"></asp:Label>

                            <asp:TextBox ID="txt_trantype" runat="server" CssClass="form-control" ToolTip="Product" placeholder="" ReadOnly="false"></asp:TextBox>
                        </div>
                        <div class="INVYear">
                            <asp:Label ID="Label8" runat="server" Text="Vou Year"> </asp:Label>
                            <asp:TextBox ID="txt_year" runat="server" AutoPostBack="True" CssClass="form-control" placeholder="" ToolTip="Vou Year" OnTextChanged="txt_year_TextChanged"></asp:TextBox>
                        </div>

                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="InvCustomer">

                            <asp:Label ID="lbl_receivedfrom" runat="server" Text="Customer Name"></asp:Label>

                            <asp:TextBox ID="txt_received" runat="server" ToolTip="Customer Name" placeholder="" ReadOnly="True" CssClass="form-control"
                                TextMode="MultiLine" Width="100%" Height="40px"></asp:TextBox>

                        </div>
                        <div class="InvShipper">

                            <asp:Label ID="lbl_detail" runat="server" Text="Shipper Details"></asp:Label>

                            <asp:TextBox ID="txt_detail" runat="server" ReadOnly="True" ToolTip="Shipper Details" placeholder="" TextMode="MultiLine"
                                Width="100%" CssClass="form-control" Height="40px"></asp:TextBox>

                        </div>

                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="ChargeDes">
                            <asp:Label ID="Label9" runat="server" Text="Charge Description"> </asp:Label>
                            <asp:TextBox ID="txt_charge" runat="server" ReadOnly="True" placeholder="" CssClass="form-control" ToolTip="Charge Description" TabIndex="9"></asp:TextBox>
                        </div>
                        <div class="Curr4">
                            <asp:Label ID="Label10" runat="server" Text="Curr"> </asp:Label>
                            <asp:TextBox ID="txt_curr" runat="server" ReadOnly="True" placeholder="" ToolTip="Curr" CssClass="form-control" TabIndex="10"></asp:TextBox>
                        </div>
                        <div class="Rate6">
                            <asp:Label ID="Label11" runat="server" Text="Rate"> </asp:Label>
                            <asp:TextBox ID="txt_rate" runat="server" ReadOnly="True" placeholder="" ToolTip="Rate" CssClass="form-control" TabIndex="11"></asp:TextBox>
                        </div>
                        <div class="ExRate7">
                            <asp:Label ID="Label12" runat="server" Text="ExRate"> </asp:Label>
                            <asp:TextBox ID="txt_exrate" runat="server" ReadOnly="True" placeholder="" CssClass="form-control" ToolTip="Ex.Rate" TabIndex="12"></asp:TextBox>
                        </div>
                        <div class="Base1">
                            <asp:Label ID="Label13" runat="server" Text="Base"> </asp:Label>
                            <asp:TextBox ID="txt_base" runat="server" ReadOnly="True" placeholder="" CssClass="form-control" ToolTip="Base" TabIndex="13"></asp:TextBox>
                        </div>
                        <%--<div class="Base1">  <asp:DropDownList ID="ddl_base" runat="server" ReadOnly="True" AppendDataBoundItems="True" CssClass="chzn-select" BorderColor="#999997"  ToolTip="Base/Unit" TabIndex="13" data-placeholder="Base/Unit">
       <asp:ListItem Value="0" Text=""></asp:ListItem>
             </asp:DropDownList></div>--%>
                        <div class="Amount11">
                            <asp:Label ID="Label14" runat="server" Text="Amount"> </asp:Label>
                            <asp:TextBox ID="txt_amount" runat="server" ReadOnly="True" placeholder="" CssClass="form-control" Style="text-align: right" ToolTip="Amount" TabIndex="14"></asp:TextBox>
                        </div>
                        <div class="Amount11Gst">
                            <asp:Label ID="Label15" runat="server" Text="GST"> </asp:Label>
                            <asp:TextBox ID="txt_GST" runat="server" ReadOnly="True" placeholder="" CssClass="form-control" Style="text-align: right" ToolTip="GST" TabIndex="15"></asp:TextBox>
                        </div>
                        <div class="Amount12">
                            <asp:Label ID="Label16" runat="server" Text="NET"> </asp:Label>
                            <asp:TextBox ID="txt_NET" runat="server" ReadOnly="True" placeholder="" CssClass="form-control" Style="text-align: right" ToolTip="NET" TabIndex="16"></asp:TextBox>
                        </div>
                        <div class="Amount11R1">
                            <asp:Label ID="Label17" runat="server" Text="Rev.Rate"> </asp:Label>
                            <asp:TextBox ID="txt_USDRate" runat="server" Enabled="false" placeholder="" CssClass="form-control" Style="text-align: right" ToolTip="Rate" TabIndex="17" AutoPostBack="true" OnTextChanged="txt_USDRate_TextChanged"></asp:TextBox>
                        </div>
                        <div class="Amount11R">
                            <asp:Label ID="Label18" runat="server" Text="Rev.Amt"> </asp:Label>
                            <asp:TextBox ID="txt_reversal" runat="server" ReadOnly="True" placeholder="" CssClass="form-control" Style="text-align: right" ToolTip="Rev.Amt" TabIndex="18" AutoPostBack="true" OnTextChanged="txt_reversal_TextChanged"></asp:TextBox>
                        </div>
                        <div class="Amount11D">
                            <asp:Label ID="Label19" runat="server" Text="Diff"> </asp:Label>
                            <asp:TextBox ID="txt_Diff" runat="server" ReadOnly="True" placeholder="" CssClass="form-control" Style="text-align: right" ToolTip="Difference" TabIndex="19"></asp:TextBox>
                        </div>
                        <div class="Unit1">
                            <asp:Label ID="Label20" runat="server" Text="Unit"> </asp:Label>
                            <asp:TextBox ID="txt_Unit" runat="server" ReadOnly="True" placeholder="" CssClass="form-control" Style="text-align: right" ToolTip="Unit" TabIndex="20"></asp:TextBox>
                        </div>
                        <div class="Amount11D1">
                            <asp:Label ID="Label21" runat="server" Text="DiffRRate"> </asp:Label>
                            <asp:TextBox ID="txt_DiffRevRate" runat="server" ReadOnly="True" placeholder="" CssClass="form-control" Style="text-align: right" ToolTip="DiffRevRate" TabIndex="21"></asp:TextBox>
                        </div>
                        <div class="Amount11D2">
                            <asp:Label ID="Label22" runat="server" Text="DiffFcamt"> </asp:Label>
                            <asp:TextBox ID="txt_DiffFcamt" runat="server" ReadOnly="True" placeholder="" CssClass="form-control" Style="text-align: right" ToolTip="DiffFcamt" TabIndex="22"></asp:TextBox>
                        </div>
                        <div class="right_btn custom-mt-2">
                            <div class="btn ico-update" id="btn_add1" runat="server">
                                <asp:Button ID="btn_add" runat="server" Text="Update" ToolTip="Update" OnClick="btn_add_Click" />
                            </div>
                        </div>
                    </div>
                        
                        <%--<div class="btn ico-add" id="btn_add1" runat="server"> <asp:Button ID="btn_add" runat="server" ToolTip="Add"   TabIndex="16"/></div>

                    </div>--%>
                        <div class="FormGroupContent4 boxmodal">

                        <div class="FormGroupContent4">
                            <asp:Panel ID="panel_details" runat="server" ScrollBars="Auto" CssClass="gridpnl MB0 ">
                                <asp:GridView ID="Grd_Charge" runat="server" AutoGenerateColumns="False" Width="100%"
                                    ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found" OnRowDataBound="Grd_Charge_RowDataBound" CssClass="Grid FixedHeader" OnSelectedIndexChanged="Grd_Charge_SelectedIndexChanged">
                                    <%--OnSelectedIndexChanged="Grd_Charge_SelectedIndexChanged"--%>
                                    <Columns>
                                        <asp:BoundField DataField="charge" HeaderText="Charges"><%--0--%>
                                            <HeaderStyle Width="550px" CssClass="TblFixed" />
                                            <ItemStyle Width="550px" CssClass="TblFixed" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="curr" HeaderText="Curr"><%--1--%>
                                            <HeaderStyle Width="60px" CssClass="TblFixed" />
                                            <ItemStyle Width="60px" CssClass="TblFixed" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:#,##0.00}"
                                            ItemStyle-HorizontalAlign="Right"><%--2--%>
                                            <HeaderStyle Width="110px" CssClass="TblFixed" />
                                            <ItemStyle HorizontalAlign="Right" CssClass="TxtAlign1 TblFixed" Width="110px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="exrate" HeaderText="ExRate" ItemStyle-CssClass="TxtAlign1"><%--3--%>
                                            <HeaderStyle Width="70px" CssClass="TblFixed" />
                                            <ItemStyle HorizontalAlign="Right" Width="70px" CssClass="TblFixed TxtAlign1" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="base" HeaderText="Base" />
                                        <%--4--%>
                                        <asp:BoundField DataField="withoutgstAmt" HeaderText="Amount" DataFormatString="{0:#,##0.00}"
                                            ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="TxtAlign1"><%--5--%>
                                            <HeaderStyle Width="110px" CssClass="TblFixed" />
                                            <ItemStyle HorizontalAlign="Right" Width="110px" CssClass="TblFixed TxtAlign1"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="stgst" HeaderText="GST" DataFormatString="{0:#,##0.00}"
                                            ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="TxtAlign1"><%--6--%>
                                            <HeaderStyle Width="110px" CssClass="TblFixed" />
                                            <ItemStyle HorizontalAlign="Right" Width="110px" CssClass="TblFixed TxtAlign1"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="amount" HeaderText="NET" DataFormatString="{0:#,##0.00}"
                                            ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="TxtAlign1"><%--7--%>
                                            <HeaderStyle Width="110px" CssClass="TblFixed" />
                                            <ItemStyle HorizontalAlign="Right" Width="110px" CssClass="TblFixed TxtAlign1"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="" HeaderText="Rev.Rate" DataFormatString="{0:#,##0.00}"
                                            ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="TxtAlign1"><%--8--%>
                                            <HeaderStyle Width="110px" CssClass="TblFixed" />
                                            <ItemStyle HorizontalAlign="Right" Width="110px" CssClass="TblFixed TxtAlign1"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="" HeaderText="Rev.Amount" DataFormatString="{0:N0}"
                                            ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="TxtAlign1"><%--9--%>
                                            <HeaderStyle Width="120px" CssClass="TblFixed" />
                                            <ItemStyle HorizontalAlign="Right" Width="120px" CssClass="TblFixed TxtAlign1"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="" HeaderText="Rev.GST" DataFormatString="{0:#,##0.00}"
                                            ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="TxtAlign1"><%--10--%>
                                            <HeaderStyle Width="120px" CssClass="TblFixed" />
                                            <ItemStyle HorizontalAlign="Right" Width="120px" CssClass="TblFixed TxtAlign1"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="" HeaderText="Rev.NET" DataFormatString="{0:#,##0.00}"
                                            ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="TxtAlign1"><%--11--%>
                                            <HeaderStyle Width="120px" CssClass="TblFixed" />
                                            <ItemStyle HorizontalAlign="Right" Width="120px" CssClass="TblFixed TxtAlign1"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="" HeaderText="Difference" DataFormatString="{0:#,##0.00}"
                                            ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="TxtAlign1"><%--12--%>
                                            <HeaderStyle Width="120px" CssClass="TblFixed" />
                                            <ItemStyle HorizontalAlign="Right" Width="120px" CssClass="TblFixed TxtAlign1"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="" HeaderText="Diff.GST" DataFormatString="{0:#,##0.00}"
                                            ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="TxtAlign1"><%--13--%>
                                            <HeaderStyle Width="120px" CssClass="TblFixed" />
                                            <ItemStyle HorizontalAlign="Right" Width="120px" CssClass="TblFixed TxtAlign1"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="" HeaderText="Diff.NET" DataFormatString="{0:#,##0.00}"
                                            ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="TxtAlign1"><%--14--%>
                                            <HeaderStyle Width="120px" CssClass="TblFixed" />
                                            <ItemStyle HorizontalAlign="Right" Width="120px" CssClass="TblFixed TxtAlign1"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="GSTP" HeaderText="Percentage" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                        <%--15--%>
                                        <%--<ItemStyle CssClass="hidden" />
                    </asp:BoundField>--%>
                                        <asp:BoundField DataField="chargeid" HeaderText="Chargeid" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                        <%--16--%>

                                        <%--<ItemStyle CssClass="hidden" />
                    </asp:BoundField>--%>
                                        <%--<asp:TemplateField HeaderText="Revised" >  
                    <ItemTemplate>  
                        <asp:CheckBox ID="Chk_Revised" runat="server" ></asp:CheckBox>  
                    </ItemTemplate>    
                </asp:TemplateField>--%>
                                        <asp:BoundField DataField="" HeaderText="check" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                        <%--17--%>
                                        <asp:BoundField DataField="" HeaderText="Unit" />
                                        <%--18--%>
                                        <asp:BoundField DataField="" HeaderText="Diff.RevRate" DataFormatString="{0:#,##0.00}"
                                            ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="TxtAlign1"><%--19--%>
                                            <HeaderStyle Width="120px" CssClass="TblFixed" />
                                            <ItemStyle HorizontalAlign="Right" Width="120px" CssClass="TblFixed TxtAlign1"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="" HeaderText="Diff.Fcamt" DataFormatString="{0:#,##0.00}"
                                            ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="TxtAlign1"><%--20--%>
                                            <HeaderStyle Width="120px" CssClass="TblFixed" />
                                            <ItemStyle HorizontalAlign="Right" Width="120px" CssClass="TblFixed TxtAlign1"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="unit" HeaderText="Unit" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                        <%--21--%>
                                        <asp:BoundField DataField="blno" HeaderText="BL #" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                        <%--22--%>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkHeader" runat="server" OnCheckedChanged="chkHeader_CheckedChanged" AutoPostBack="true" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkChild" runat="server" OnCheckedChanged="chkChild_CheckedChanged" AutoPostBack="true" />
                                                <%--Enabled="false"--%>
                                                <%--23--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="fcamt" HeaderText="Fcamt" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                        <%--24--%>
                                        <asp:BoundField DataField="HorM" HeaderText="horm" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                        <%--25--%>
                                    </Columns>
                                    <%--<selectedrowstyle backcolor="LightCyan" forecolor="DarkBlue" font-bold="true"/>--%>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                        <div class="FormGroupContent4">

                            <div style="float: left;">

                                <%--  <div class="InvNo"><asp:Label ID="lbl_rvoucher" runat="server" display="none" Text="Inv #"></asp:Label></div>
                       <div class="INVNoinput"> <asp:TextBox ID="txt_rvouno" runat="server" display="none" CssClass="form-control"></asp:TextBox></div>
                        <div class="INVNoinput1"><asp:TextBox ID="txt_ryear" runat="server" display="none" CssClass="form-control"></asp:TextBox></div>--%>
                            </div>

                            <%--<div class="TotalInputN1"> <asp:Label ID="lbl_total" runat="server" Text="Total"></asp:Label></div>--%>

                            <div style="float: right; width: 74.5%; margin: 0px 0px 0px 0px;">

                                <div class="AmountTxtBox">
                                    <asp:Label ID="Label23" runat="server" Text="Amount"> </asp:Label>
                                    <asp:TextBox ID="txt_AmountTot" runat="server" placeholder="" ReadOnly="true" Style="text-align: right" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="GstTxtBox">
                                    <asp:Label ID="Label24" runat="server" Text="GST"> </asp:Label>
                                    <asp:TextBox ID="txt_GstTot" runat="server" placeholder="" ReadOnly="true" Style="text-align: right" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="NetTxtBox">
                                    <asp:Label ID="Label25" runat="server" Text="NET"> </asp:Label>
                                    <asp:TextBox ID="txt_NetTot" runat="server" placeholder="" ReadOnly="true" Style="text-align: right" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="RevTxtBox">
                                    <asp:Label ID="Label26" runat="server" Text="Rev.Rate"> </asp:Label>
                                    <asp:TextBox ID="txt_RevRateTot" runat="server" placeholder="" ReadOnly="true" Style="text-align: right" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="RevAmountTxtBox">
                                    <asp:Label ID="Label27" runat="server" Text="Rev.Amount"> </asp:Label>
                                    <asp:TextBox ID="txt_RevAmtTot" runat="server" placeholder="" ReadOnly="true" Style="text-align: right" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="RevGstTxtBox">
                                    <asp:Label ID="Label28" runat="server" Text="Rev.GST"> </asp:Label>
                                    <asp:TextBox ID="txt_RevGstTot" runat="server" placeholder="" ReadOnly="true" Style="text-align: right" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="RevNetTxtBox">
                                    <asp:Label ID="Label29" runat="server" Text="Rev.Net"> </asp:Label>
                                    <asp:TextBox ID="txt_RevNetTot" runat="server" placeholder="" ReadOnly="true" Style="text-align: right" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="DiffTxtBox">
                                    <asp:Label ID="Label30" runat="server" Text="Difference"> </asp:Label>
                                    <asp:TextBox ID="txt_DiffAmtTot" runat="server" placeholder="" ReadOnly="true" Style="text-align: right" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="DiffGstTxtBox">
                                    <asp:Label ID="Label31" runat="server" Text="Diff.GST"> </asp:Label>
                                    <asp:TextBox ID="txt_DiffGstTot" runat="server" placeholder="" ReadOnly="true" Style="text-align: right" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="TotalInputN2">
                                    <asp:Label ID="Label32" runat="server" Text="Diff.Net"> </asp:Label>
                                    <asp:TextBox ID="txt_DiffNetTot" runat="server" placeholder="" ReadOnly="true" Style="text-align: right" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="TotalInputNUnit">
                                    <asp:Label ID="Label33" runat="server" Text="Unit.Tot"> </asp:Label>
                                    <asp:TextBox ID="txt_UnitTot" runat="server" placeholder="" ReadOnly="true" Style="text-align: right" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="TotalInputN2">
                                    <asp:Label ID="Label34" runat="server" Text="DiffRevRate"> </asp:Label>
                                    <asp:TextBox ID="txt_DiffRevRateTot" runat="server" placeholder="" ReadOnly="true" Style="text-align: right" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="TotalInputN2">
                                    <asp:Label ID="Label35" runat="server" Text="DiffFcamt"> </asp:Label>
                                    <asp:TextBox ID="txt_DiffFcamtTot" runat="server" placeholder="" ReadOnly="true" Style="text-align: right" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                            </div>
                        <%--Reversal Grid Journal--%>
                        <asp:Label ID="Label6" runat="server"></asp:Label>
                        <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="Panel2"
                            DropShadow="false" TargetControlID="Label6" CancelControlID="Image2" BehaviorID="Test2">
                        </ajaxtoolkit:ModalPopupExtender>

                        <div class="FormGroupContent4">
                            <asp:Panel ID="Panel2" runat="server" CssClass="modalPopupLogn1" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">

                                <div >
                                    <div class="col-md-12  maindiv">
                                        <div class="widget box" runat="server">
                                            <div class="widget-header">
                                                <h4><i class="icon-umbrella"></i>
                                                    <asp:Label ID="Label5" runat="server" Text="Reversal - Journal"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="DivSecPanelLogn1">
                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                            </div>

                                            <div class="widget-content">

                                                <div class="FormGroupContent4">
                                                    <div class="JournalTxt">
                                                        <div style="display: none;">
                                                            <asp:Label ID="lbljnlno" runat="server" Text="Journal #"></asp:Label>
                                                        </div>
                                                        <asp:TextBox ID="txtjnlno" runat="server" AutoPostBack="true" CssClass="form-control" ToolTip="Journal #" placeholder="Journal #" OnTextChanged="txtjnlno_TextChanged"></asp:TextBox>
                                                    </div>

                                                    <div class="JournalDate">
                                                        <asp:TextBox ID="txtdate" runat="server" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtdate_TextChanged" TabIndex="1"></asp:TextBox>

                                                    </div>
                                                    <div class="JournalLBL" style="display: none;">
                                                        <asp:Label ID="lbldate" runat="server" Text="Date"></asp:Label>
                                                    </div>

                                                </div>
                                                <div class="FormGroupContent4">
                                                    <div class="GridJournal">
                                                        <asp:GridView ID="grd_journal" runat="server" CssClass="Grid FixedHeader" Width="100%" AutoGenerateColumns="False"
                                                            OnRowDataBound="grd_journal_RowDataBound" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found">
                                                            <Columns>
                                                                <asp:BoundField DataField="ledgertype">
                                                                    <HeaderStyle Width="30" />
                                                                    <ItemStyle Width="30" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ledgername" HeaderText="Ledger">
                                                                    <HeaderStyle Width="900" />
                                                                    <ItemStyle Width="900" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Debit" HeaderText="Debit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:BoundField>
                                                                <asp:BoundField DataField="Credit" HeaderText="Credit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                            <HeaderStyle CssClass="GridHeader" />
                                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div class="FormGroupContent4">
                                                    <div class="btnctrl1">
                                                        <div class="TotalJInput">
                                                            <asp:TextBox ID="txtCrAmnt" runat="server" TabIndex="8" CssClass="form-control" ToolTip="Credit Amount" Placeholder="Credit Amount" Style="text-align: right"></asp:TextBox>

                                                        </div>
                                                        <div class="TotalJInput1">
                                                            <asp:TextBox ID="txtDbtAmnt" runat="server" TabIndex="7" CssClass="form-control" ToolTip="Debit Amount" placeholder="Debit Amount" Style="text-align: right"></asp:TextBox>

                                                        </div>
                                                        <div class="TotalJLBL">
                                                            <asp:Label ID="Label2" runat="server" Text="Total"></asp:Label>

                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="FormGroupContent4">
                                                    <div class="TotalNarr">
                                                        <div style="display: none;">
                                                            <asp:Label ID="lblnarration" runat="server" Text="Narration"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <asp:TextBox ID="txtnarration" runat="server" TabIndex="9" CssClass="form-control" ToolTip="Narration" placeholder="Narration"></asp:TextBox>

                                                </div>

                                                <div class="FormGroupContent4">
                                                    <div class="JouJobNo">
                                                        <div style="display: none;">
                                                            <asp:Label ID="Label3" runat="server" Text="Journal #"></asp:Label>
                                                        </div>
                                                        <asp:TextBox ID="txtjobno" CssClass="form-control" ToolTip="Job #" placeholder="Job #" runat="server" TabIndex="10"></asp:TextBox>
                                                    </div>
                                                    <div class="JouReference">
                                                        <div style="display: none;">
                                                            <asp:Label ID="lblref" runat="server" Text="Referance No"></asp:Label>
                                                        </div>
                                                        <asp:TextBox ID="txtref" runat="server" CssClass="form-control" ToolTip="Ref. #" placeholder="Ref. #" TabIndex="11"></asp:TextBox>
                                                    </div>
                                                    <div class="right_btn">
                                                        <div class="btn ico-delete">
                                                            <asp:Button ID="Button1" runat="server" Visible="false" ToolTip="Vou Cancel" />
                                                        </div>
                                                        <div class="btn ico-reverse-charge">
                                                            <asp:Button ID="btn_RevJV" runat="server" ToolTip="Reverse" OnClick="btn_RevJV_Click" OnClientClick="disableBtn(this.id, 'Loading...')" UseSubmitBehavior="False" />
                                                        </div>
                                                        <div class="btn ico-cancel" id="Div1" runat="server">
                                                            <asp:Button ID="btn_CancelJVpopup" runat="server" ToolTip="Cancel" OnClick="btn_CancelJVpopup_Click" />
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </asp:Panel>

                        </div>

                      
                </div>
            </div>
        </div>
    </div>

    <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl" Style="display: none;">

        <div style="font-size: 10pt"><b>Do You Want to Proceed the Vou Cancel Operation? </b></div>
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

    <%-- <%-- Revised Charges --%>
    <asp:Panel ID="PanelReviesd" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">

            <div class="LogHeadJob">

                <label id="lbl_title" runat="server"></label>

            </div>
            <div class="LogHeadJobInput">

                <asp:Label ID="receiptno" runat="server"></asp:Label>

            </div>

            <div class="DivSecPanel">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="16px" Height="16px" />
            </div>

            <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridCharges" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="true"
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

    <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtenderCharges" runat="server" PopupControlID="PanelReviesd"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image1" BehaviorID="Test1">
    </ajaxtoolkit:ModalPopupExtender>

    <asp:Label ID="Label1" runat="server" />
    <asp:HiddenField ID="hid_trantype" runat="server" />
    <asp:HiddenField ID="hid_type" runat="server" />
    <asp:HiddenField ID="hid_job" runat="server" Value="0" />
    <asp:HiddenField ID="hid_Custtype" runat="server" />
    <asp:HiddenField ID="hid_blno" runat="server" />
    <asp:HiddenField ID="Hid_voutype" runat="server" />
    <asp:HiddenField ID="hid_custid" runat="server" />
    <asp:HiddenField ID="hid_customername" runat="server" />
    <asp:HiddenField ID="hid_GSTpercentage" runat="server" />
    <asp:HiddenField ID="hid_Chargeid" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hid_Chk_Mbl" runat="server" />
    <asp:HiddenField ID="hid_fcamount" runat="server" />
    <asp:HiddenField ID="hid_unit" runat="server" />
    <asp:HiddenField ID="hid_Mbl" runat="server" />
    <asp:HiddenField ID="hid_Vouyear" runat="server" />
    <asp:HiddenField ID="txtmont" runat="server" />
    <asp:HiddenField ID="hid_VouID" runat="server" />
    <asp:HiddenField ID="hid_txtyear" runat="server" />
    <asp:HiddenField ID="hid_divisionid" runat="server" />
    <ajaxtoolkit:CalendarExtender ID="Calendarextender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtdate"></ajaxtoolkit:CalendarExtender>
    <%--<ajaxtoolkit:CalendarExtender ID="ce_voudate1" runat="server" TargetControlID="" Format="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>--%>

    <%--         <asp:Panel ID="PanelLog1" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Chargewise Reversal #</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Pnl2" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridViewlog1" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
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

    <asp:Label ID="Label7" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="PanelLog1"
        DropShadow="false" TargetControlID="Label7" CancelControlID="imglog1" BehaviorID="Test2">
    </asp:ModalPopupExtender>--%>

    <asp:Panel ID="PanelLog11" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label id="Label36" runat="server"></label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="Label37" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog111" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel111" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridViewlog11" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
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

    <asp:Label ID="lbllog11" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtender111" runat="server" PopupControlID="PanelLog11"
        DropShadow="false" TargetControlID="lbllog11" CancelControlID="imglog111" BehaviorID="Test211">
    </asp:ModalPopupExtender>

</asp:Content>
