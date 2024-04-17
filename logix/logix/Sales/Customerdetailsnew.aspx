<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Customerdetailsnew.aspx.cs" EnableEventValidation="false" Inherits="logix.Sales.Customerdetailsnew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
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
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

    <!-- Smartphone Touch Events -->

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

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {

                $("#<%=txt_bl.ClientID %>").autocomplete({

                   source: function (request, response) {
                       $("#<%=hf_blno.ClientID %>").val(0);

                                $.ajax({
                                    url: "../Sales/Customerdetailsnew.aspx/Getblno",

                                    data: "{ 'prefix': '" + request.term + "'}",
                                    dataType: "json",
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    success: function (data) {

                                        response($.map(data.d, function (item) {

                                            return {
                                                label: item

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

                            select: function (event, i) {
                                $("#<%=txt_bl.ClientID %>").val(i.item.label);
                            $("#<%=txt_bl.ClientID %>").change();
                            $("#<%=hf_blno.ClientID %>").val(i.item.val);
                        },
                   focus: function (event, i) {
                       $("#<%=txt_bl.ClientID %>").val(i.item.label);
                            $("#<%=hf_blno.ClientID %>").val(i.item.val);
                        },
                   change: function (event, i) {
                       $("#<%=txt_bl.ClientID %>").val(i.item.label);
                            $("#<%=hf_blno.ClientID %>").val(i.item.val);

                        },
                   close: function (event, i) {
                       $("#<%=txt_bl.ClientID %>").val(i.item.label);
                            $("#<%=hf_blno.ClientID %>").val(i.item.val);
                        },
                   minLength: 1
               });
           });

                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            }

    </script>

    <style type="text/css">
        .div_main {
            width: 100%;
            float: left;
        }

        .div_drop {
            width: 20%;
            float: left;
            margin-left: 1%;
            margin-top: 1%;
        }

        .div_drop1 {
            width: 20%;
            float: left;
            margin-left: 1%;
            margin-top: 1%;
        }

        .txt1 {
            width: 20%;
            float: left;
            margin-left: 1%;
            margin-top: 1%;
        }

        .txt2 {
            width: 20%;
            float: left;
            margin-left: 1%;
            margin-top: 1%;
        }

        .btn {
            /*width:10%;
             float:left;
             margin-left:1%;*/
        }

        .Product {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Branch {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .JobTxtBox {
            width: 21%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .SalesPerson {
            width: 21%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .div_confirm {
            /*Border:1px solid red;*/
            width: 100%;
            float: left;
            margin-top: 0%;
        }

        .Pnl {
            background-color: #fff;
            border-color: #b1b1b1;
            border-style: solid;
            border-width: 1px;
            text-align: center;
            font-size: 11px;
            padding: 5px;
        }

        .BranchModule {
            width: 17%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .AirDrop {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BOENo {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .JobInput18 {
            width: 4.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MawblCal {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VtypeTxt {
            width: 46%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VtypeDrop {
            width: 52%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VouNo {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .JobTxtBox {
            width: 8.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PickedTxtBox {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PickedTxtBox2 {
            width: 8.5%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .PickedTxtBox1 {
            width: 7.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .chk1 {
            float: left;
            width: 4%;
            margin: 0px 0.3% 0px 0px;
        }

        .chk2 {
            float: left;
            width: 4%;
            margin: 0px 0.3% 0px 0px;
        }

        .chk3 {
            float: left;
            width: 4%;
            margin: 0px 0.3% 0px 0px;
        }

        .chk4 {
            float: left;
            width: 4%;
            margin: 0px 0.3% 0px 0px;
        }

        .chk5 {
            float: left;
            width: 4%;
            margin: 0px 0.3% 0px 0px;
        }

        .chk6 {
            float: left;
            width: 4%;
            margin: 0px 0.3% 0px 0px;
        }

        .chk7 {
            float: left;
            width: 4%;
            margin: 0px 0.3% 0px 0px;
        }

        .BranchCost {
            width: 17.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .InvoiceCurr {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Blnumber {
            width: 15.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .InvoiceAmt {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .DutyAmt {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .InvoiceAmt input {
            text-align: right;
        }

        .DutyAmt input {
            text-align: right;
        }

        .CustomsCLRP {
            width: 14.6%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .widget.box {
            height: 550px;
        }

        .BlNumbern1 {
            width: 35%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BoENon1 {
            width: 26%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            color: #000080;
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important; 
        }
        .widget.box{
    position: relative;
    top: -8px;
}
        

 
.widget.box .widget-content {
    top: 0px !important;
    padding-top: 45px !important;
}
 
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- /Breadcrumbs line -->
    <div >
        <div class="col-md-12 maindiv">

            <div class="widget box" runat="server">

                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="headerlbl" runat="server" Text="Customs Details"></asp:Label></h4>
                     <!-- Breadcrumbs line -->
    <div class="crumbs" id="crumbsid" runat="server">
        <ul id="breadcrumbs" class="breadcrumb" runat="server">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="" id="headerlabel2" runat="server">Documentation</a> </li>
            <li><a href="#" title="" runat="server" id="HeaderLabel1"></a></li>
            <li class="current"><a href="#" title="">Customs Details</a> </li>
        </ul>
    </div>
                        </div>


                     <div class="FixedButtons">
      <div class="right_btn">

         <div class="btn ico-save" id="btn_save1" runat="server">
             <asp:Button ID="btn_save" runat="server" Text="Save" ToolTip="Save" OnClick="btn_save_Click" />
         </div>
         <div class="btn ico-cancel" id="lbl_back" runat="server">
             <asp:Button ID="btn_back" runat="server" ToolTip="Cancel" Text="Cancel" OnClick="btn_back_Click" />
         </div>

     </div>
 </div>

                </div>
                <div class="widget-content">
                   
                    <div class="FormGroupContent4 boxmodal">
                        <div class="BranchCost Hide">
                            <asp:Label ID="lbl_branch" runat="server" Text="Branch"></asp:Label>
                            <asp:DropDownList ID="ddl_branch" CssClass="chzn-select" Height="23px" runat="server" data-placeholder="Branch"
                                AppendDataBoundItems="True"
                                OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged"
                                AutoPostBack="True" TabIndex="1">
                            </asp:DropDownList>

                        </div>
                        <div class="BranchModule hide">

                            <asp:Label ID="lbl_module" runat="server" Text="Product"></asp:Label>
                            <asp:DropDownList ID="ddl_module" CssClass="chzn-select" Height="23px" runat="server" AutoPostBack="True" data-placeholder="Product"
                                OnSelectedIndexChanged="ddl_module_SelectedIndexChanged" TabIndex="2">
                                <asp:ListItem></asp:ListItem>

                                <asp:ListItem Value="AI">Air Imports</asp:ListItem>
                                <asp:ListItem Value="CH">Custom House Agent</asp:ListItem>
                                <asp:ListItem Value="FI">Ocean Imports</asp:ListItem>
                            </asp:DropDownList>

                        </div>

                        <div class="AirDrop" id="ddtype1" runat="server" visible="false">
                            <asp:Label ID="Label11" runat="server" Text="Job Type"></asp:Label>
                            <asp:DropDownList ID="ddlJobType" runat="server" CssClass="chzn-select" data-placeholder="Job Type" ToolTip="Job Type" TabIndex="5" OnSelectedIndexChanged="ddlJobType_SelectedIndexChanged">
                                <asp:ListItem Text="" Value="0" />
                                <asp:ListItem Value="AI">Air Import</asp:ListItem>
                                <asp:ListItem Value="RI">Road Import</asp:ListItem>
                                <asp:ListItem Value="SI">Sea Import</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="FormGroupContent4">

                       <div class="Blnumber" id="BlNumbern1" runat="server">
                            <asp:Label ID="Label1" runat="server" Text="BL Number"></asp:Label>
                            <asp:TextBox ID="txt_bl" runat="server" CssClass="form-control" ToolTip="BL #" placeholder="" TabIndex="3" AutoPostBack="true" OnTextChanged="txt_bl_TextChanged">
                            </asp:TextBox>
                        </div>
                        </div>
                    <div class="FormGroupContent4">

                        <div class="BOENo" id="BoENon1" runat="server">
                            <asp:Label ID="Label2" runat="server" Text="BOE Number"></asp:Label>
                            <asp:TextBox ID="txt_BOEno" runat="server" CssClass="form-control" ToolTip="BOE #" placeholder="" TabIndex="3">
                            </asp:TextBox>
                        </div>

                        <div class="JobTxtBox">
                            <asp:Label ID="Label3" runat="server" Text="BOE Date"></asp:Label>
                            <asp:TextBox ID="txtPickedon1" runat="server" CssClass="form-control" placeholder="" ToolTip="BOE Date" TabIndex="4"></asp:TextBox>
                        </div>

                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtPickedon1"></ajaxtoolkit:CalendarExtender>
                       
                    </div>
                    <div class="FormGroupContent4">
                         <div class="InvoiceCurr">
                            <asp:Label ID="Label4" runat="server" Text="Curr"></asp:Label>
                            <asp:TextBox ID="txt_curr" runat="server" CssClass="form-control" ToolTip="Invoice Currency" placeholder="" TabIndex="5">
                            </asp:TextBox>
                        </div>
                        <div class="InvoiceAmt">
                            <asp:Label ID="Label5" runat="server" Text="Invoice Amount"></asp:Label>
                            <asp:TextBox ID="txt_invamt" runat="server" CssClass="form-control" ToolTip="Invoice Amount" placeholder="" TabIndex="6">
                            </asp:TextBox>
                        </div>
                        <div class="DutyAmt">
                            <asp:Label ID="Label6" runat="server" Text="DUTY Amount"></asp:Label>
                            <asp:TextBox ID="txt_Dutyamt" runat="server" CssClass="form-control" ToolTip="DUTY Amount" placeholder="" TabIndex="7">
                            </asp:TextBox>
                        </div>

                        <div class="PickedTxtBox2 DateR">
                            <asp:Label ID="Label7" runat="server" Text="DUTY PAID On"></asp:Label>
                            <asp:TextBox ID="txt_dutyDate" runat="server" CssClass="form-control" placeholder="" ToolTip="DUTY PAID Date" TabIndex="8"></asp:TextBox>
                        </div>

                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_dutyDate"></ajaxtoolkit:CalendarExtender>

                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="PickedTxtBox">
                            <asp:Label ID="Label8" runat="server" Text="Customs Released On"></asp:Label>
                            <asp:TextBox ID="txt_custreldate" runat="server" CssClass="form-control" placeholder="" ToolTip="Customs Release Date" TabIndex="9"></asp:TextBox>
                        </div>

                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_custreldate"></ajaxtoolkit:CalendarExtender>

                        <div class="PickedTxtBox1">
                            <asp:Label ID="Label9" runat="server" Text="Delivered On "></asp:Label>
                            <asp:TextBox ID="txt_DeliveryDate" runat="server" CssClass="form-control" placeholder="" ToolTip="Delivery Date" TabIndex="10"></asp:TextBox>
                        </div>

                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_DeliveryDate"></ajaxtoolkit:CalendarExtender>
                        <div class="CustomsCLRP">
                            <asp:Label ID="Label10" runat="server" Text="Customs CLR Note"></asp:Label>
                            <asp:TextBox ID="txt_cusclrnote" runat="server" CssClass="form-control" ToolTip="Customs CLR Note" placeholder="" TabIndex="11">
                            </asp:TextBox>
                        </div>

                        <%--<div class="SalesPerson"><asp:TextBox  ID="txt_blno"  runat="server"  CssClass="form-control" ToolTip="Booking#"  placeholder="Booking#"></asp:TextBox></div>--%>
                    </div>

                   
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hid_trantype" runat="server" />
    <asp:HiddenField ID="hid_trantype1" runat="server" />

    <asp:HiddenField ID="hf_blno" runat="server" />

</asp:Content>
