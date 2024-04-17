<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="RevPage1.aspx.cs" Inherits="logix.Home.RevPage1" %>

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

    <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

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

    <style type="text/css">
        .div_grd {
            width: 100%;
            margin-top: 0%;
            margin-bottom: 1%;
            height: 200px;
            margin-left: 0%;
            border: 1px solid gray;
        }

            .div_grd input {
                width: 98%;
            }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopupss {
            background-color: #B3E5FC;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 140px;
            display: inline-block;
        }

        .widget.box .widget-header {
            background: #dbdbdb;
            border-bottom-color: #d9d9d9;
            line-height: 35px;
            padding: 7px 12px;
            margin-bottom: 0;
            color: #2F3C4D;
            font-size: 14px;
            font-family: 'OpenSansSemibold';
        }

        .brdernone {
            border: 0px solid #f00 !important;
        }

        .FooterCont {
            top: 592px !important;
        }
        .row {
    height: 570px !important;
     margin: 0px 5px 0px -15px;
    clear: both;
    overflow-x: hidden !important;
    overflow-y: auto !important;
    width: 100%;
}
    </style>

    <script type="text/javascript">
        function ValidateText(i) {
            if (i.value.length > 0) {
                i.value = i.value.replace(/[^\d]+/g, '');
            }
        }
    </script>

    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                //return false;
            {
                alertify.alert("Enter Numeric Value !");
                return false;
            }
            else {
                return true;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <div >
        <div class="col-md-12  maindiv">
            <div class="widget box brdernone" runat="server">
                <div class="widget-content">

                    <div style="float:left; height:470px;">
                    <div class="FormGroupContent4 bgclrNew">

                        <div class="PageHeaderNew">
                            <i class="icon-umbrella"></i>
                            <asp:Label ID="lbl_Header" runat="server" Text="Appraisal Page - 1"></asp:Label>
                        </div>


                        <div class="ProEmpcodeApp">
                            <asp:TextBox ID="txtempcode" runat="server" ReadOnly="true" ToolTip="Employee Code" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="PronameApp">
                            <asp:TextBox ID="txtempname" runat="server" ReadOnly="true" ToolTip="Employee Name" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>

                        <div class="DesiApp">
                            <asp:TextBox ID="txtdesig" runat="server" ReadOnly="true" ToolTip="Designation" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="GradeApp">
                            <asp:TextBox ID="txtgrade" runat="server" ReadOnly="true" ToolTip="Grade" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="DeptApp">
                            <asp:TextBox ID="txtdept" runat="server" ReadOnly="true" ToolTip="Department" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="DojApp">
                            <asp:TextBox ID="txtdoj" ToolTip="Date of Joining" runat="server" ReadOnly="true" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="DoCApp">
                            <asp:TextBox ID="txtdoc" ToolTip="Date of Confirmation" runat="server" ReadOnly="true" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>

                    </div>



                    <div class="FormGroupContent4">

                        <div class="LocationApp" style="display: none;">
                            <asp:TextBox ID="txtlocation" runat="server" ToolTip="Branch" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="CTCCtrl">
                            <div class="GrossMonthly">Gross Monthly</div>
                            <div class="GrossApp">
                                <asp:TextBox ID="txtgrossmon" runat="server" ToolTip="Gross Monthly" CssClass="form-control TxtAlign1" MaxLength="100"></asp:TextBox>
                            </div>
                            <div class="CtcMonthly1">CTC Monthly</div>
                            <div class="EmpCodeApp" style="float: left">
                                <asp:TextBox ID="txtctcmon" runat="server" ToolTip="CTC Monthly" CssClass="form-control TxtAlign1" MaxLength="100"></asp:TextBox>
                            </div>
                            <div class="CtcAnnual1">CTC Annually</div>
                            <div class="CTCanApp">
                                <asp:TextBox ID="txtctcann" runat="server" ToolTip="CTC Annually" CssClass="form-control TxtAlign1" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <%-- <div class="InstructionApp">
                            <asp:CheckBox ID="chkagree" Text=" " TextAlign="Left" runat="server" ToolTip="Access" />
                            <asp:Label ID="Label23" runat="server">I have read the<asp:LinkButton ID="Button2" OnClick='btn_instr_Click' runat="server"> Instructions </asp:LinkButton>
                                and agree to the Terms and Conditions</asp:Label>
                        </div>--%>
                    </div>

                    <div class="FormGroupContent4">

                        <%-- <div class="right_btn MT0 MB10">
                                <div class="btn btn-save"><asp:Button ID="Button2" runat="server"  Text="Instructions"   /></div>
                                
                            </div>--%>
                    </div>
                    <div class="bordertopNew1"></div>
                    <div style="height: 358px; float: left; width: 100%;">
                        <asp:Panel ID="pnlgrid" runat="server" Width="100%" CssClass="div_GridAPP"
                            ScrollBars="Vertical">
                            <asp:GridView ID="grd_user" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" 
                                ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="S#" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsno" runat="server" Text='<% #Container.DataItemIndex + 1%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="20px" />
                                        <ItemStyle Width="20px" Font-Size="small" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Please List Your KRA'S / KPI'S & Rate Your Performance">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("kpi")  %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Center" Wrap="true" Font-Size="Small" Width="70%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Weightage Points">
                                        <ItemTemplate>
                                            <asp:Label ID="lblweightage" runat="server" Text='<%# Eval("weightage")  %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        <ItemStyle Wrap="false" Font-Size="Small" Width="10%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Emp Rating">
                                        <ItemTemplate>
                                            <asp:Label ID="lblemprating" runat="server" Text='<%# Eval("selfrating")  %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        <ItemStyle Wrap="false" Font-Size="Small" Width="10%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField>

                                        <HeaderTemplate>
                                            <asp:Label ID="lblctcann" runat="server" Text="Appraiser Ratings"></asp:Label>
                                        </HeaderTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" />
                                        <ItemStyle Wrap="false" Width="10%" />
                                        <ItemTemplate>
                                             <asp:Label ID="lblapprating" runat="server" Text='<%# Eval("appraiserrating")  %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="kpiid" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblkpiid" runat="server" Text='<%# Eval("kpiid")  %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        <ItemStyle Wrap="false" Font-Size="Small" Width="10%" />
                                    </asp:TemplateField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="right_btn MT0 MB10">
                            <div class="btn btn-nextB1">
                                <asp:Button ID="btnnext" runat="server" Text="Next"  OnClick="btnnext_Click" />
                            </div>
                            <div class="btn ico-back">
                                <asp:Button ID="btnback" Enabled="false" runat="server" Text="Previous"  />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
