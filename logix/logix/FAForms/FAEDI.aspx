<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="FAEDI.aspx.cs" Inherits="logix.FAForm.FAEDI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

    <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->



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


    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Styles/TallyEDI.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {

            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    <style type="text/css">
        .FAFrom1 {
            width: 3%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FATo1 {
            width: 2%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FAMonth {
            width: 4%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .row {
            height: 550px !important;
            margin: 0px 5px 0px -15px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

        .FAReference {
            width: 9%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            color: #000080;
            font-size: 11px;
        }

        .FormGroupContent4 label {
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
    padding-top: 65px !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">

                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_head" runat="server"></asp:Label></h4>
                    <!-- /Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#">Home</a> </li>
            <li><a href="#">Utility</a> </li>
            <li><a href="#" title="">FA Edi</a> </li>
            <li>
                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
        </ul>
    </div>
                        </div>


                    <div class="FixedButtons">
     <div class="right_btn">
        <div class="btn ico-transfer-to-fa">
            <asp:Button ID="btn_get" runat="server" Text="Transfer To FA" ToolTip="Transfer to FA" OnClick="btn_get_Click" />
        </div>
        <div class="btn ico-cancel" id="btn_exportexcel1" runat="server">
            <asp:Button ID="btn_exportexcel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_exportexcel_Click" />
        </div>


    </div>
</div>

                </div>
                <div class="widget-content">
                    
                    <div class="FormGroupContent4 boxmodal">
                        <div class="FAVoucher">

                            <asp:Label ID="lbl_voutyper" runat="server" Text="VoucherType"></asp:Label>


                            <asp:DropDownList ID="ddl_voucher" CssClass="chzn-select" runat="server" data-placeholder="Voucher Type" Height="23px" OnSelectedIndexChanged="ddl_voucher_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">Voucher Type</asp:ListItem>
                            </asp:DropDownList>

                        </div>

                        <div class="FAFrom2">
                            <asp:Label ID="lbl_from" runat="server" Text="From"></asp:Label>
                            <asp:TextBox ID="txt_from" runat="server" AutoPostBack="true" CssClass="form-control" ToolTip="From" placeholder=""></asp:TextBox>
                        </div>

                        <div class="FATo2">
                            <asp:Label ID="Label1" runat="server" Text="To"></asp:Label>
                            <asp:TextBox ID="txt_to" runat="server" AutoPostBack="true" CssClass="form-control" ToolTip="To" placeholder=""></asp:TextBox>
                        </div>

                        <div class="FAMonth1">
                            <asp:Label ID="lbl_month" runat="server" Text="Month"></asp:Label>
                            <asp:TextBox ID="txt_month" runat="server" AutoPostBack="true" CssClass="form-control" ToolTip="Month" placeholder=""></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="FANarration1">
                            <asp:Label ID="lbl_narration" runat="server" Text="Narration"></asp:Label>

                            <asp:DropDownList ID="ddl_narration" CssClass="chzn-select" runat="server" Height="23px" data-placeholder="Narration" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">Narration</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="FAReference">
                            <asp:Label ID="lbl_recep" runat="server" Text="Reference #"></asp:Label>

                            <asp:DropDownList ID="ddl_referen" CssClass="chzn-select" runat="server" Height="23px" data-placeholder="Referance #" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">Reference #</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                       
                    </div>

                </div>
            </div>
        </div>
    </div>








    <%-- <div class="div_Main">
        
    </div>
    <div class="div_Break"></div>
    <div class="div_lbl">
        
    </div>
    <div class="div_drop">
       
    </div>
    <div class="div_Break"></div>
    <div class="div_lbl1">
         
    </div>
    <div class="div_drop1">
         
    </div>
     <div class="div_lbl2">
        
    </div>
    <div class="div_drop2">
         
    </div>
    <div class="div_Break"></div>
    <div class="div_lbl1">
        
    </div>
    <div class="div_drop1">
        
    </div>
    <div class="div_Break"></div>
    <div class="div_lbl">
        
    </div>
    <div class="div_drop">
        
    </div>
     <div class="div_Break"></div>
    <div class="div_lbl">
        
    </div>
    <div class="div_drop">
        
    </div>
    <div class="div_Break"></div>
    <div class="div_btn">
        
        
    </div>--%>
</asp:Content>
