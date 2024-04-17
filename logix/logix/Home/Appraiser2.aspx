<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Appraiser2.aspx.cs" Inherits="logix.Home.Appraiser2" %>

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

    <link href="../Styles_Date/jquery1-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Script_Date/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script_Date/jquery-ui.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            });





        }


    </script>


    <style type="text/css">
        .div_grd {
            width: 100%;
            margin-top: 0%;
            margin-bottom: 1%;
            height: 264px;
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
        }

        .brdernone {
            border: 0px solid #f00 !important;
        }

        .FooterCont {
            top: 592px !important;
        }

        .Grid {
            width: 100%;
            border: 1px solid #b1b1b1;
            margin: 0px 0px 0px 0px;
            overflow-x: hidden !important;
            overflow-y: hidden !important;
        }

            .Grid th {
                background-color: #dbdbdb !important;
                border-right: 1px solid #51789d;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                font-size: 11px;
                color: #4e4c4c !important;
            }

            .Grid td {
                border-right: 1px solid #dddddd;
                font-size: 11px;
                text-align: left;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                margin: 0px;
                color: #4e4c4c;
                border-bottom: 1px solid #dddddd;
            }

            .Grid tr:last-child {
                color: #ab1e1e !important;
            }

        #logix_CPH_Panel1 {
            height: 362px;
        }

        .div_GridAPP {
            width: 99%;
            margin-left: 0.5%;
            margin-bottom: 0.5%;
            margin-top: 0.5%;
            height: 408px;
            Border: 1px solid #b1b1b1;
            float: left;
            overflow: auto;
        }
        .row {
    height: 574px !important;
    margin: 0px 5px 0px -15px;
    clear: both;
    overflow-x: hidden !important;
    overflow-y: hidden !important;
    /* width: 100%; */
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <div >
        <div class="col-md-12  maindiv">
            <div class="widget box brdernone" runat="server">

                <div class="widget-content">
                    <div style="float:left; height:500px;">
                    <div class="FormGroupContent4 bgclrNew">

                        <div class="PageHeaderNew">
                            <i class="icon-umbrella"></i>
                            <asp:Label ID="lbl_Header" runat="server" Text="Appraisal Page - 2"></asp:Label>

                        </div>


                        <div class="ProEmpcodeApp">
                            <asp:TextBox ID="txtempcode" runat="server" ToolTip="Employee Code" ReadOnly="true" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="PronameApp">
                            <asp:TextBox ID="txtempname" runat="server" ToolTip="Employee Name" ReadOnly="true" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>

                        <div class="DesiApp">
                            <asp:TextBox ID="txtdesig" runat="server" ToolTip="Designation" ReadOnly="true" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="GradeApp">
                            <asp:TextBox ID="txtgrade" runat="server" ToolTip="Grade" ReadOnly="true" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="DeptApp">
                            <asp:TextBox ID="txtdept" runat="server" ToolTip="Department" ReadOnly="true" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="DojApp">
                            <asp:TextBox ID="txtdoj" runat="server" ToolTip="Date of Joining" ReadOnly="true" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="DoCApp">
                            <asp:TextBox ID="txtdoc" runat="server" ToolTip="Date of Confirmation" ReadOnly="true" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>

                    </div>



                    <div class="FormGroupContent4">

                        <div class="LocationApp" style="display: none;">
                            <asp:TextBox ID="txtlocation" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
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
                    </div>
                    <div class="bordertopNew1"></div>
                    <%-- <div class="FormGroupContent4">
                            <div class="InstructionApp">
                                <asp:CheckBox ID="CheckBox2" Text=" " TextAlign="Left" runat="server" ToolTip="Access" />
                                <asp:Label ID="Label23" runat="server">I have read the<asp:LinkButton ID="Button2" OnClick='btn_instr_Click' runat="server"> Instructions </asp:LinkButton>
                                    and agree to the Terms and Conditions</asp:Label>
                            </div>
                            <div class="right_btn MT0 MB10">
                                <div class="btn btn-save"><asp:Button ID="Button2" runat="server"  Text="Instructions"   /></div>
                                
                            </div>
                        </div>--%>

                    <div style="height: 374px;">
                        <asp:Panel ID="pnlview2" runat="server" CssClass="div_GridAPP">
                            <div class="FormGroupContent4">
                                <asp:Label ID="lblapp2" runat="server" Text="Score your capability or knowledge in the following areas in terms of your current role requirements.(Please mention the appropriate rating)" CssClass="LabelValue"></asp:Label>
                            </div>
                            <div class="FormGroupContent4">
                                <asp:Panel ID="Panel1" runat="server" Width="100%" CssClass="div_grd"
                                    ScrollBars="Vertical">
                                    <asp:GridView ID="gvcomp" runat="server" AutoGenerateColumns="False" Height="100%" Width="100%" CssClass="Grid FixedHeader" 
                                        DataKeyNames="qid" ShowHeaderWhenEmpty="true">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S#">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsno" runat="server" Text='<% #Container.DataItemIndex + 1%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="5%" Font-Size="small" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Personal Competencies">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("Details")  %>' ToolTip='<%# Eval("Details")  %>'></asp:Label>
                                                </ItemTemplate>

                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                <ItemStyle Wrap="true" Font-Size="Small" Width="55%" />

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Ratings">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblselfratings" runat="server" Text='<%# Eval("selfratings")  %>' ToolTip='<%# Eval("selfremarks")  %>'></asp:Label>
                                                </ItemTemplate>

                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                <ItemStyle Wrap="true" Font-Size="Small" Width="7%" />

                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Employee Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblremarks" runat="server" Text='<%# Eval("selfremarks")  %>' ToolTip='<%# Eval("selfremarks")  %>'></asp:Label>
                                                </ItemTemplate>

                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                <ItemStyle Wrap="true" Font-Size="Small" Width="10%" />

                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Appraiser ratings">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlself" runat="server" Width="100%"  CssClass="" AutoPostBack="true">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Average" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Above Average" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Good" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Very Good" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Excellent" Value="5"></asp:ListItem>


                                                    </asp:DropDownList></div>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                <ItemStyle Wrap="true" Font-Size="Small" Width="10%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Appraiser Remarks">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtcomremarks" Text='<%# Eval("app1remarks")  %>' runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                                </ItemTemplate>

                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                <ItemStyle Wrap="true" Font-Size="Small" Width="15%" />

                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="qid" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldetails1" runat="server" Text='<%# Eval("qid")  %>'></asp:Label>
                                                </ItemTemplate>

                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                <ItemStyle Wrap="false" Font-Size="Small" />

                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>
                            </div>

                        </asp:Panel>
                    </div>

                        </div>


                    <div class="FormGroupContent4">
                        <div class="right_btn MT0 MB05">
                            <div class="btn btn-nextB1">
                                <asp:Button ID="btnnext" runat="server" Text="Next" OnClick="btnnext_Click" />
                            </div>
                            <div class="btn ico-back">
                                <asp:Button ID="btnprevious" runat="server" Text="Previous" OnClick="btnprevious_Click" />
                            </div>
                            <div class="btn ico-save">
                                <asp:Button ID="btnsavepage2" runat="server" Visible="false" OnClick="btnsavepage2_Click" Text="Save" />
                            </div>
                            <div class="btn ico-cancel">
                                <asp:Button ID="btncancelpage2" runat="server" Visible="false" Text="Cancel" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
