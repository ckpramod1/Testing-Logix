<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Apppage4.aspx.cs" Inherits="logix.HRM.Apppage4" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax1" %>

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
    <link href="../Styles_Date/jquery1-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Script_Date/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script_Date/jquery-ui.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">s
        
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
            height: 200px;
            margin-left: 0%;
            border: 1px solid gray;
        }

            .div_grd input {
                width: 98%;
            }

        .modalBackground {
            background-color: #ffffff;
            filter: alpha(opacity=90);
            opacity: 1.5;
        }


        .Grid {
            width: 100%;
            border: 1px solid #b1b1b1;
            margin: 0px 0px 0px 0px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            background-color: #ffffff;
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
        .div_GridAPP {
            width: 99%;
            margin-left: 0.5%;
            margin-bottom: 0.5%;
            margin-top: 0.5%;
            height: 320px;
            Border: 1px solid #b1b1b1;
            float: left;
            overflow: hidden;
        }

        #logix_CPH_grdims_ddlrating1_1_chzn {
            width: 100% !important;
        }

        #logix_CPH_grdims_ddlrating1_2_chzn {
            width: 100% !important;
        }

        #logix_CPH_grdims_ddlrating1_3_chzn {
            width: 100% !important;
        }

        #logix_CPH_grdims_ddlrating1_4_chzn {
            width: 100% !important;
        }

        #logix_CPH_grdims_ddlrating1_5_chzn {
            width: 100% !important;
        }

        #logix_CPH_grdims_ddlrating1_6_chzn {
            width: 100% !important;
        }

        #logix_CPH_grdims_ddlrating1_7_chzn {
            width: 100% !important;
        }

        #logix_CPH_grdims_ddlrating1_8_chzn {
            width: 100% !important;
        }

        #logix_CPH_grdims_ddlrating1_9_chzn {
            width: 100% !important;
        }

        #logix_CPH_grdsub_ddlrating_0_chzn {
            width: 100% !important;
        }

        #logix_CPH_grdims_ddlrating1_0_chzn {
            width: 100% !important;
        }

        #logix_CPH_grdsub_ddlrating_1_chzn {
            width: 100% !important;
        }

        #logix_CPH_grdsub_ddlrating_2_chzn {
            width: 100% !important;
        }

        #logix_CPH_grdsub_ddlrating_3_chzn {
            width: 100% !important;
        }

        #logix_CPH_grdsub_ddlrating_4_chzn {
            width: 100% !important;
        }

        .brdernone {
            border: 0px solid #f00 !important;
        }

        .FooterCont {
            top: 592px !important;
        }
        .row {
    height: 585px !important;
    margin: 0px 5px 0px -15px;
    clear: both;
    overflow-x: hidden !important;
    overflow-y: auto !important;
    width: 100%;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

      <div >
        <div class="col-md-12  maindiv">
            <div class="widget box brdernone" runat="server">
                
                <div class="widget-content">
                    <div style="float:left; height:490px;">
                    <div class="FormGroupContent4 bgclrNew">
                        <div class="PageHeaderNew">
                        <i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text="Appraisal Page - 4"></asp:Label>
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
                      <%--  <div style="float: left">
                            <div class="btn btn-save">
                                <asp:Button ID="btnconfirmedon" runat="server" Text="Comparision" />
                            </div>
                        </div>--%>

                        <div class="LocationApp" style="display:none;">
                            <asp:TextBox ID="txtlocation" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                         <div class="CTCCtrl">
                              <div class="GrossMonthly">Gross Monthly</div>
                        <div class="EmpCodeApp" style="float: left">
                            <asp:TextBox ID="txtgrossmon" runat="server" CssClass="form-control TxtAlign1" MaxLength="100"></asp:TextBox>
                        </div>
                             <div class="CtcMonthly1">CTC Monthly</div>
                        <div class="GrossApp">
                            <asp:TextBox ID="txtctcmon" runat="server" CssClass="form-control TxtAlign1" MaxLength="100"></asp:TextBox>
                        </div>
                             <div class="CtcAnnual1">CTC Annually</div>
                        <div class="CTCanApp">
                            <asp:TextBox ID="txtctcann" runat="server" CssClass="form-control TxtAlign1" MaxLength="100"></asp:TextBox>
                        </div>
                             </div>
                    </div>
                     <div class="bordertopNew1"></div>
                    <%--  <div class="FormGroupContent4">
                        <div class="InstructionApp">
                            <asp:CheckBox ID="CheckBox2" Text=" " TextAlign="Left" runat="server" ToolTip="Access" />
                            <asp:Label ID="Label12" runat="server">I have read the<asp:LinkButton ID="Button2" OnClick='btn_instr_Click' runat="server"> Instructions </asp:LinkButton>
                                and agree to the Terms and Conditions</asp:Label>
                        </div>
                        <div class="right_btn MT0 MB10">
                                <div class="btn btn-save"><asp:Button ID="Button2" runat="server"  Text="Instructions"   /></div>
                                
                            </div>
                    </div>--%>
                    <div style="height:370px;">
                   
                    <div class="FormGroupContent4 MB10">

                        <div style="float: left; width: 49.5%; margin: 0px 0.5% 0px 0px;">
                             <div class="FormGroupContent4">
                        <asp:Label ID="lblapp2" runat="server" ForeColor="Black" Text="How far have you been a Role Model to your sub-ordinates?  Please mention the appropriate rating" CssClass="LabelValue"></asp:Label>
                    </div>
                            <asp:Panel ID="pnlgrid" runat="server" Width="100%" CssClass="div_GridAPP">
                            <asp:GridView ID="grdsub" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader"  Width="100%"
                                ForeColor="Black" ShowHeaderWhenEmpty="True">
                                <Columns>
                                  <asp:TemplateField HeaderText="S#">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsno1" runat="server" Text='<% #Container.DataItemIndex + 1%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Width="10%" Font-Size="small" />
                                    </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Traits">
                                        <ItemTemplate>
                                            <asp:Label ID="lblqhead1" runat="server" Text='<%# Eval("qhead")  %>' ToolTip='<%# Eval("qhead")  %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Width="65%" Font-Size="small" Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rating" >
                                        <ItemTemplate >
                                            <asp:DropDownList ID="ddlrating" runat="server" Width="100%"  CssClass="">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Average" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Very Good" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                         <ItemStyle Width="15%" Font-Size="small" Wrap="false" />
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Qid" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblqid1" runat="server" Text='<%# Eval("qid")  %>' ToolTip='<%# Eval("qid")  %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Width="10%" Font-Size="small" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                                </asp:Panel>
                        </div>

                        <div style="float: left; width: 49.5%; margin: 0px 0% 0px 0px;">
                             <div class="FormGroupContent4">
                            <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="Kindly evaluate your immediate superior on the below " CssClass="LabelValue"></asp:Label>
                        </div>
                             <asp:Panel ID="Panel1" runat="server" Width="100%" CssClass="div_GridAPP">
                            <asp:GridView ID="grdims" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader"  Width="100%"
                                ForeColor="Black" ShowHeaderWhenEmpty="True">
                                <Columns>
                                  <asp:TemplateField HeaderText="S#">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsno" runat="server" Text='<% #Container.DataItemIndex + 1%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Width="10%" Font-Size="small" />
                                    </asp:TemplateField>
                                   
                                     <asp:TemplateField HeaderText="Traits">
                                        <ItemTemplate >
                                            <asp:Label ID="lblqhead" runat="server" Text='<%# Eval("qhead")  %>' ToolTip='<%# Eval("qhead")  %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Width="65%" Font-Size="small"  Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rating">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlrating1" runat="server" Width="100%"  CssClass="">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Average" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Good" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Very Good" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle Width="15%" Font-Size="small" Wrap="false" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Qid" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblqid" runat="server" Text='<%# Eval("qid")  %>' ToolTip='<%# Eval("qid")  %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Width="10%" Font-Size="small" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                                 </asp:Panel>
                        </div>
                    </div>
                        </div>
                        </div>
                    <div class="FormGroupContent4">
                          <div style="float: left">
                             <div class="btn ico-view">
                                <asp:Button ID="btncompare" runat="server" Text="Comparision" OnClick="btncompare_Click" />
                            </div>
                        </div>

                        <div class="right_btn MT0 MB10">
                            <div class="btn btn-nextB1">
                                <asp:Button ID="btnnext" runat="server" Text="Next" OnClick="btnnext_Click" />
                            </div>

                            <div class="btn ico-back">
                                <asp:Button ID="btnprevious" runat="server" Text="Previous" OnClick="btnprevious_Click" />
                            </div>
                            <div class="btn ico-save">
                                <asp:Button ID="btnsavepage2" runat="server" Text="Save" Visible="false" OnClick="btnsavepage2_Click" />
                            </div>
                            <div class="btn ico-cancel">
                                <asp:Button ID="btncancelpage2" runat="server" Text="Cancel" Visible="false" OnClick="btncancelpage2_Click" />
                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </div>
    </div>

     <asp:Label ID="Label10" runat="server" Style="display: none"></asp:Label>
        <asp:Label ID="Label7" runat="server" Style="display: none"></asp:Label>

        <ajax1:ModalPopupExtender ID="mpthank" runat="server" PopupControlID="Panel2" TargetControlID="Label10"
            CancelControlID="Label7" BackgroundCssClass="modalBackground">
        </ajax1:ModalPopupExtender>
        <asp:Panel ID="Panel2" runat="server" align="center" CssClass="div_GridAPP" Width="75%" Height="76%">
            <div class="FormGroupContent4">
                <asp:Label ID="Label11" runat="server" ForeColor="Black" Font-Bold="true" Text="Comparision"></asp:Label>
            </div>
            <div class="FormGroupContent4">
                <asp:Panel ID="Panel3" runat="server" align="center" CssClass="div_GridAPP" ScrollBars="Vertical">
                    <asp:GridView ID="grd_user" runat="server" AutoGenerateColumns="True" Width="100%" CssClass="Grid FixedHeader" 
                        ShowHeaderWhenEmpty="true">
                       
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                    </asp:GridView>
                </asp:Panel>
            </div>

            <div class="btn ico-cancel" style="text-align: center; width: 100%; margin: 2px auto 0px;">
                <asp:Button ID="btnclose" runat="server" Text="Close" OnClick="btnclose_Click" />
            </div>

        </asp:Panel>


</asp:Content>
