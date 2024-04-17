<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="JobCloseandVoucherdateExtension.aspx.cs" Inherits="logix.Maintenance.JobCloseandVoucherdateExtension" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtol" %>

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
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/lodash.compat.min.js"></script>











    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>
    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>


    <!-- App -->
    <script type="text/javascript" src="../js/helper.js"></script>

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
      
        a {
            font-size: 12px;
        }


        .CompanytxtBox {
            width: 100%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        
        .BranchTxtBox {
            width: 100%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .JobTxtBox {
            width: 42%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VoucherTxtBox {
            width: 57%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .DivGrid {
            width: 100%;
            float: left;
            height: 425px;
            overflow: auto;
            border: 1px solid #b1b1b1;
            margin: 5px 0px 0px 0px;
        }
 
        .widget.box{
    position: relative;
    top: -8px;
}
        .btn.btn-update1, .btn.btn-cancel1 {
    margin: 12px 0px 0px 0px;
}
        .divleft{
            width:30%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }

        
        .divright{
            width:69%;
            float:left;
            margin:0px 0px 0px 0px;
        }
        .gridpnl {
    height: calc(100vh - 75px);
}
        .widget.box .widget-content {
    top: 0px !important;
    padding-top:15px !important;
}
    </style>





</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">









    <!-- Breadcrumbs line End -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lblAccountantMail" runat="server" Text="Job Close and Voucher Date Extension"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li><a href="#">Maintenance</a></li>
                            <li><a href="#" title="">Master</a> </li>
                            <li class="current">Job Close and Voucher Date Extension </li>
                        </ul>
                    </div>
                        </div>





                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4">
                        <div class="divleft">
                            <div class="FormGroupContent4">
                                    <div class="CompanytxtBox">

                            <asp:Label ID="Label1" runat="server" CssClass="hide" Text="Company"></asp:Label>
                            <asp:DropDownList ID="ddl_company" runat="server" placeholder="Company" ToolTip="ddl_company" CssClass="chzn-select" Enabled="false" OnSelectedIndexChanged="ddl_company_SelectedIndexChanged">
                            </asp:DropDownList>

                        </div>
                            </div>
                            <div class="FormGroupContent4">
                                  <div class="BranchTxtBox">
                            <asp:Label ID="Label2" runat="server" CssClass="hide" Text="Branch"></asp:Label>
                            <asp:DropDownList ID="ddl_branch" runat="server" placeholder="Branch" ToolTip="ddl_branch" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged" data-placeholder="Branch">
                                <%--<asp:ListItem Text="" Value="0"></asp:ListItem>--%>
                            </asp:DropDownList>

                        </div>
                            </div>
                            <div class="FormGroupContent4">
                                  <div class="JobTxtBox">
                            <asp:Label ID="Label3" runat="server" CssClass="hide" Text="Job Closing Days"></asp:Label>
                            <asp:TextBox ID="Text_jobclose" AutoPostBack="false" placeholder="Job Closing Days" runat="server" ToolTip="Text_jobclose" CssClass="form-control"></asp:TextBox>

                        </div>
                           
                                  <div class="VoucherTxtBox">
                            <asp:Label ID="Label4" runat="server" CssClass="hide" Text="Voucher Back Date Days"></asp:Label>
                            <asp:TextBox ID="Text_voucherdate" AutoPostBack="false" placeholder="Voucher Back Date Days" runat="server" ToolTip="Text_voucherdate" CssClass="form-control"></asp:TextBox>
                        </div>
                            </div>
                              <div class="FormGroupContent4 boxmodal">
                    
                      
                      
                      

                        <div class="right_btn">
                            <div class="btn ico-update">
                                <asp:Button ID="Update" runat="server" Text="Update" OnClick="Update_Click" /></div>
                            <div class="btn ico-cancel">
                                <asp:Button ID="Cancel" runat="server" Text="cancel" OnClick="Cancel_Click" /></div>

                        </div>

                    </div>

                        </div>
                        <div class="divright">
                    <div class="FormGroupContent4 boxmodal">
                        <div class="gridpnl">

                            <asp:HiddenField ID="HF_BranchId" runat="server" />

                            <asp:GridView ID="Grid_jobvoucher" AutoGenerateColumns="false" runat="server" CssClass="Grid FixedHeader">
                                <Columns>
                                    <asp:BoundField DataField="portname" HeaderText="Branch" />
                                    <asp:BoundField DataField="closingdays" HeaderText="Closing Days" />
                                    <asp:BoundField DataField="backdatedays" HeaderText="Back Date Days" />
                                </Columns>

                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />

                            </asp:GridView>
                        </div>

                    </div>

                        </div>
                    </div>
                  




                </div>
            </div>
        </div>
    </div>






















</asp:Content>
