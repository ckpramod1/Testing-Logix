<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="CooApproval.aspx.cs" Inherits="logix.Home.CooApproval" %>

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
    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            });





        }


    </script>






    <style type="text/css">
        .brdernone {
            border: 0px solid #f00 !important;
        }

        .Fontwt {
            margin: 5px 0px 0px 0px !important;
        }

            .Fontwt span {
                font-size: 14px;
                color: maroon;
                font-weight: bold;
            }

        .Self1 {
            float: left;
            width: 11%;
            margin: 0px 0.5% 0px 0px;
        }

        .Self2 {
            float: left;
            width: 15%;
            margin: 0px 0% 0px 0px;
        }

        .Self2G {
            float: left;
            width: 11.9%;
            margin: 0px 0% 0px 0px;
        }

        .SelfN2 {
            float: left;
            width: 13.5%;
            margin: 0px 0% 0px 0px;
        }

        .Selfappraisal1 {
            float: left;
            width: 20%;
            margin: 0px 1.5% 0px 0px;
        }

        .SelfappraisalCOO1 {
            float: left;
            width: 20%;
            margin: 0px 1.5% 0px 0px;
        }

        .Selfappraisal2 {
            float: left;
            width: 45.5%;
            margin: 0px 1.5% 0px 0px;
        }

        .RatingN {
            width: 47%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .RatingN1 {
            width: 38%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .RatingN2 {
            width: 47%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .SelfappraisalGood {
            width: 63%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .SelfappraisalN {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .SelfappraisalNeed {
            width: 22%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .row {
            height: 525px !important;
            margin: 0px 5px 0px -15px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: hidden !important;
            /* width: 100%; */
        }


        .SelfappraisalN input {
            text-align: right;
        }

        .ApraserApraisalN {
            width: 13%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

            .ApraserApraisalN input {
                text-align: right;
            }

        #logix_CPH_ddlcoodesig_chzn {
            width: 200% !important;
        }

        #logix_CPH_ddlsal_chzn {
            width: 100% !important;
        }

        #logix_CPH_ddldesignation_chzn {
            width: 100% !important;
        }

        #logix_CPH_ddlgradestatus_chzn {
            width: 100% !important;
        }

        #logix_CPH_ddlcoosalary_chzn {
            width: 100% !important;
        }

        #logix_CPH_ddlcooregrade_chzn {
            width: 100% !important;
        }

        .AppraisalRight {
            width: 566px;
            float: left;
            margin: 0px 0px 0px -4px;
        }

        #logix_CPH_ddlcooredesig_chzn {
            width: 100% !Important;
        }




        .RatingNA {
            width: 34%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .SelfappraisalCOO1D {
            float: left;
            width: 33.5%;
            margin: 0px 1.5% 0px 0px;
        }

        .Self2Sal {
            float: left;
            width: 13%;
            margin: 0px 0% 0px 0px;
        }

        .Self2D {
            float: left;
            width: 13%;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_ddlmode_chzn {
            width: 100% !important;
        }

        .Self2Am {
            float: left;
            width: 9%;
            margin: 0px 1% 0px 0px;
        }

        .Self2Txt {
            float: left;
            width: 10.5%;
            margin: 0px 0% 0px 0px;
        }

        .SelfappraisalN input {
            background-color: #c7e5f1;
            color: #000000;
        }

        .ApraserApraisalN input {
            background-color: #e0c1c1;
            color: #000;
        }

        .Selfappraisal2Sp {
            float: left;
            width: 48.3%;
            margin: 0px 1.5% 0px 0px;
        }

        .chzn-drop {
            height: 150px !important;
            overflow: auto;
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

        .div_GridAPP1 {
            border: 1px solid #b1b1b1;
            float: left;
            height: 411px;
            margin-top: 0.5%;
            margin-bottom: 0.5%;
            overflow: auto;
            width: 50%;
        }

        .div_GridAPP2 {
            border: 0px solid #b1b1b1;
            float: left;
            height: 320px;
            margin: 0%;
            overflow: auto;
            width: 50%;
        }

        .div_GridAPP {
            border: 1px solid #b1b1b1;
            float: left;
            height: 428px;
            margin-bottom: 0.5%;
            margin-left: auto;
            margin-top: 0.5%;
            margin-right: auto;
            overflow: auto;
            width: 100%;
        }

        #logix_CPH_Panel3 {
            height: 98% !important;
            left: 10px !important;
            top: 11px !important;
            width: 98% !important;
        }

        .div_GridAPP1 span {
            color: #212121;
        }

        .div_GridAPP span {
            color: #212121;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <div >
        <div class="col-md-12  maindiv">
            <div class="widget box brdernone" runat="server">

                <div class="widget-content">
                    <div style="float: left; height: 500px;">
                        <div class="FormGroupContent4 bgclrNew">

                            <div class="PageHeaderNew">
                                <i class="icon-umbrella"></i>
                                <asp:Label ID="lbl_Header" runat="server" Text="Appraisal Page - 5"></asp:Label>
                            </div>
                            <div class="ProEmpcodeApp">
                                <asp:TextBox ID="txtempcode" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                            </div>
                            <div class="PronameApp">
                                <asp:TextBox ID="txtempname" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                            </div>

                            <div class="DesiApp">
                                <asp:TextBox ID="txtdesig" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                            </div>
                            <div class="GradeApp">
                                <asp:TextBox ID="txtgrade" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                            </div>
                            <div class="DeptApp">
                                <asp:TextBox ID="txtdept" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                            </div>
                            <div class="DojApp">
                                <asp:TextBox ID="txtdoj" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                            </div>
                            <div class="DoCApp">
                                <asp:TextBox ID="txtdoc" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                            </div>

                        </div>





                        <div class="FormGroupContent4">

                            <div class="LocationApp" style="display: none;">
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

                        <%-- <div class="FormGroupContent4">
            <div class="InstructionApp">
                <asp:CheckBox ID="CheckBox2" Text=" " TextAlign="Left" runat="server" ToolTip="Access" />
                <asp:Label ID="Label12" runat="server">I have read the<asp:LinkButton ID="Button2" OnClick='btn_instr_Click' runat="server"> Instructions </asp:LinkButton>
                    and agree to the Terms and Conditions</asp:Label>
            </div>
          <div class="right_btn MT0 MB10">
                                <div class="btn btn-save"><asp:Button ID="Button2" runat="server"  Text="Instructions"   /></div>
                                
                            </div>
        </div>--%>



                        <div class="bordertopNew1"></div>
                        <div style="height: 438px;">
                            <div style="float: left; width: 665px; margin: 0px 0.5% 0px 0px;">
                                <asp:Panel ID="pnlpage3" runat="server" Width="100%" ScrollBars="Auto">
                                    <div class="FormGroupContent4">
                                        <div class="RatingN">
                                            <asp:Label ID="Label3" runat="server" Text="Rating Details" Font-Bold="true" ForeColor="Maroon"></asp:Label>
                                        </div>
                                        <div class="SelfappraisalN">
                                            <asp:Label ID="Label4" runat="server" Text="Self " Font-Bold="true" ForeColor="Maroon"></asp:Label>
                                        </div>
                                        <div class="ApraserApraisalN">
                                            <asp:Label ID="Label5" runat="server" Text="Appraiser" Font-Bold="true" ForeColor="Maroon"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="FormGroupContent4">
                                        <div class="RatingN">
                                            <asp:Label ID="Label23" runat="server" Text="Total Rating on KPI" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div class="SelfappraisalN">
                                            <asp:TextBox ID="txtselfkpi" runat="server" ReadOnly="true" CssClass="form-control" MaxLength="1000"></asp:TextBox>
                                        </div>
                                        <div class="ApraserApraisalN">
                                            <asp:TextBox ID="txtappkpi" runat="server" ReadOnly="true" CssClass="form-control" Width="100%" MaxLength="1000"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="FormGroupContent4">
                                        <div class="RatingN">
                                            <asp:Label ID="Label1" runat="server" Text="Total Rating on Competencies" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div class="SelfappraisalN">
                                            <asp:TextBox ID="txtselfcomp" runat="server" ReadOnly="true" CssClass="form-control" Width="100%" MaxLength="1000"></asp:TextBox>
                                        </div>
                                        <div class="ApraserApraisalN">
                                            <asp:TextBox ID="txtappcomp" runat="server" ReadOnly="true" CssClass="form-control" Width="100%" MaxLength="1000"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="FormGroupContent4">

                                        <div class="RatingN">
                                            <asp:Label ID="Label2" runat="server" Text="Actual Performance rating of an Individual " Font-Bold="true"></asp:Label>
                                        </div>
                                        <div class="SelfappraisalN">
                                            <asp:TextBox ID="totself" runat="server" ReadOnly="true" CssClass="form-control" MaxLength="1000"></asp:TextBox>
                                        </div>
                                        <div class="ApraserApraisalN">
                                            <asp:TextBox ID="totalapp" runat="server" ReadOnly="true" CssClass="form-control" MaxLength="1000"></asp:TextBox>
                                        </div>
                                    </div>



                                </asp:Panel>

                                <div class="FormGroupContent4 MB10">
                                    <asp:Panel ID="Panel1" runat="server" Width="100%" ScrollBars="Auto">
                                        <div class="RatingN">
                                            <asp:Label ID="Label21" runat="server" Text="Key [Values from Appraisee]" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                        </div>
                                        <div class="SelfappraisalNeed">
                                            <asp:Label ID="lblkeyappraisee" runat="server" Font-Bold="true" ForeColor="Red" Visible="false" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                        </div>

                                    </asp:Panel>
                                </div>
                                <div class="FormGroupContent4 MB10">
                                    <asp:Panel ID="Panel2" runat="server" Width="100%" ScrollBars="Auto">
                                        <div class="RatingN">
                                            <asp:Label ID="lblkeylabel" runat="server" Text="Key [Values from Appraiser]" Visible="false" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                        </div>
                                        <div class="SelfappraisalNeed">
                                            <asp:Label ID="lblkeyvalue" runat="server" Font-Bold="true" ForeColor="Red" Visible="false" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                        </div>

                                    </asp:Panel>
                                </div>
                            </div>
                            <div class="AppraisalRight">

                                <div class="FormGroupContent4">

                                    <div class="RatingNA">
                                        <asp:Label ID="Label19" runat="server" Text="Appraisal Remarks " Font-Bold="true"></asp:Label>
                                    </div>
                                    <div class="SelfappraisalGood">
                                        <asp:TextBox ID="txtappremarks" runat="server" Width="100%" Enabled="false" Height="50px" TextMode="MultiLine" CssClass="form-control" MaxLength="1000"></asp:TextBox>
                                    </div>
                                </div>


                            </div>
                            <div class="Clear"></div>
                            <div style="float: left; width: 665px; margin: 0px 0% 0px 0px;">
                                <div class="Rating Fontwt">
                                    <asp:Label ID="Label8" runat="server" Text="Recommendations" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="FormGroupContent4">



                                    <div class="RatingN2">
                                        <asp:Label ID="lblkey" runat="server" Text="Salary Revision" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>

                                    </div>
                                    <div class="Selfappraisal1">
                                        <asp:DropDownList ID="ddlsal" Enabled="false" runat="server" OnSelectedIndexChanged="ddlsal_SelectedIndexChanged" AppendDataBoundItems="True" data-placeholder="Section" CssClass="chzn-select" AutoPostBack="true">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="No Change" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Revised" Value="2"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <div style="float: left; width: 10px; margin: 0px 1.5% 0px 0px;">
                                        <asp:Label ID="INS" runat="server">in</asp:Label>


                                    </div>
                                    <div class="Self1" style="display: none">
                                        <asp:Label ID="Label9" runat="server" Text="If Increase" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                    </div>
                                    <div class="Self2Am">
                                        <asp:DropDownList ID="ddlmode" runat="server" Width="80px" Enabled="false" AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="%" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Rs." Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="Self2Sal">
                                        <asp:TextBox ID="txtsalrev" Width="75px" runat="server" Enabled="false" CssClass="form-control" MaxLength="1000"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="FormGroupContent4">
                                    <div class="RatingN2">
                                        <asp:Label ID="Label11" runat="server" Text="Re-Designate as " Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                    </div>
                                    <div class="SelfappraisalCOO1D">
                                        <asp:DropDownList ID="ddlredesig" Enabled="false" Width="133px" Visible="false" runat="server"  AppendDataBoundItems="True" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="No Change" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Redesig" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddldesignation" Width="200px" Enabled="false" runat="server" AppendDataBoundItems="True" data-placeholder="Section" CssClass="chzn-select" AutoPostBack="true">
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                <div class="FormGroupContent4">
                                    <div class="RatingN2">
                                        <asp:Label ID="Label13" runat="server" Text="Change in Grade" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                    </div>
                                    <div class="Selfappraisal1">
                                        <asp:DropDownList ID="ddlgradestatus" Enabled="false" runat="server" OnSelectedIndexChanged="ddlgradestatus_SelectedIndexChanged" AppendDataBoundItems="True" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="No Change" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Regrade" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="Self1" style="display: none">
                                        <asp:Label ID="Label15" runat="server" Text="If Yes" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                    </div>
                                    <div class="Self2G">
                                        <asp:DropDownList ID="ddlgrade" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True" data-placeholder="Section" CssClass="chzn-select" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>


                                <div class="FormGroupContent4">
                                    <div class="RatingN2">
                                        <asp:Label ID="Label17" runat="server" Text="Special remarks" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                    </div>
                                    <div class="Selfappraisal2">
                                        <asp:TextBox ID="txtspecialremarks" Enabled="false" runat="server" Width="100%" Height="50px" ReadOnly="true" TextMode="MultiLine" CssClass="form-control" MaxLength="1000"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                            <div style="float: left; width: 632px; margin: 0px 0%  0px 0px;">
                                <div class="Rating Fontwt">
                                    <asp:Label ID="Label6" runat="server" Text="Corporate Approval" Font-Bold="true"></asp:Label>
                                </div>

                                <div class="FormGroupContent4">



                                    <div class="RatingN1">
                                        <asp:Label ID="Label7" runat="server" Text="Salary Revision" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>

                                    </div>
                                    <div class="Selfappraisal1">
                                        <asp:DropDownList ID="ddlcoosalary" runat="server" OnSelectedIndexChanged="ddlcoosalary_SelectedIndexChanged" AppendDataBoundItems="True" data-placeholder="Section" CssClass="chzn-select" AutoPostBack="true">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="No Change" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Revised" Value="2"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <div style="float: left; width: 10px; margin: 0px 1.5% 0px 0px;">
                                        <asp:Label ID="Label22" runat="server">in</asp:Label>


                                    </div>
                                    <div class="Self1" style="display: none">
                                        <asp:Label ID="Label10" runat="server" Text="If Increase" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                    </div>
                                    <div class="Self2D">
                                        <asp:DropDownList ID="ddlcoomode" runat="server" Width="80px" Enabled="false" AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="%" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Rs." Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="Self2Txt">
                                        <asp:TextBox ID="txtcoosalary" Enabled="false" runat="server" CssClass="form-control" MaxLength="1000"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="FormGroupContent4">
                                    <div class="RatingN1">
                                        <asp:Label ID="Label12" runat="server" Text="Designation " Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                    </div>
                                    <div class="SelfappraisalCOO1">
                                        <asp:DropDownList ID="ddlcooredesig" runat="server" OnSelectedIndexChanged="ddlcooredesig_SelectedIndexChanged" AppendDataBoundItems="True" data-placeholder="Section" CssClass="chzn-select" AutoPostBack="true">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="No Change" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Redesignate" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="Self1" style="display: none">
                                        <asp:Label ID="Label20" runat="server" Text="If Yes" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                    </div>
                                    <div class="SelfN2">
                                        <asp:DropDownList ID="ddlcoodesig" runat="server" AppendDataBoundItems="True" Enabled="false" CssClass="chzn-select" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="FormGroupContent4">
                                        <div class="RatingN1">
                                            <asp:Label ID="Label14" runat="server" Text="Change in Grade" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                        </div>
                                        <div class="Selfappraisal1">
                                            <asp:DropDownList ID="ddlcooregrade" runat="server" OnSelectedIndexChanged="ddlcooregrade_SelectedIndexChanged" AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="No Change" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="ReGrade" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="Self1" style="display: none">
                                            <asp:Label ID="Label16" runat="server" Text="If Yes" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                        </div>
                                        <div class="Self2">
                                            <asp:DropDownList ID="ddlcoograde" Enabled="false" runat="server" Width="100%" AppendDataBoundItems="True" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>


                                    <div class="FormGroupContent4">
                                        <div class="RatingN1">
                                            <asp:Label ID="Label18" runat="server" Text="Special remarks" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                        </div>
                                        <div class="Selfappraisal2Sp">
                                            <asp:TextBox ID="txtcoospremarks" runat="server" Width="100%" Height="50px" TextMode="MultiLine" CssClass="form-control" MaxLength="1000"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>



                        </div>


                        <div class="FormGroupContent4">
                            <div class="right_btn MT0 MB05">
                                <div class="btn ico-delete">
                                    <asp:Button ID="btnhome" runat="server" Text="Back To Home" OnClick="btnhome_Click" />
                                </div>
                                <div class="btn ico-view">
                                    <asp:Button ID="btnprint" runat="server" Text="View" OnClick="btnprint_Click" />
                                </div>
                                <div class="btn ico-send">
                                    <asp:Button ID="btnprevious1" runat="server" Text="Previous" OnClick="btnprevious1_Click" />
                                </div>
                                <div class="btn ico-save">
                                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
                                </div>
                                <div class="btn ico-cancel">
                                    <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                                </div>

                            </div>



                        </div>
                    </div>





                </div>
            </div>
        </div>

        <asp:Label ID="Label24" runat="server" Style="display: none"></asp:Label>
        <asp:Label ID="Label25" runat="server" Style="display: none"></asp:Label>

        <ajax1:ModalPopupExtender ID="mpthank" runat="server" PopupControlID="Panel3" TargetControlID="Label24"
            CancelControlID="Label25" BackgroundCssClass="modalBackground">
        </ajax1:ModalPopupExtender>
        <asp:Panel ID="Panel3" runat="server" align="center" CssClass="div_GridAPP2" Width="75%" Height="76%">
            <div class="FormGroupContent4">
            </div>
            <div class="FormGroupContent4">

                <asp:Panel ID="Panel4" runat="server" align="center" CssClass="div_GridAPP">
                    <%-- <asp:Label ID="Label26" runat="server"  Font-Bold="true" Text="Current Salary"></asp:Label>--%>
                    <asp:GridView ID="grd_user" runat="server" ShowHeader="false" OnRowCreated="grd_user_RowCreated" OnRowDataBound="grd_user_RowDataBound" AutoGenerateColumns="false" Width="100%">
                        <HeaderStyle HorizontalAlign="Center" />
                        <AlternatingRowStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Top" BorderColor="Black" />
                        <Columns>
                            <asp:TemplateField HeaderText="Salary Break-Up">
                                <ItemTemplate>
                                    <asp:Label ID="lblsno" runat="server" Text='<%# Eval("SB")  %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="350px" Font-Size="small" ForeColor="Black" HorizontalAlign="Left" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Monthly">
                                <ItemTemplate>
                                    <asp:Label ID="lbldetails1" runat="server" Text='<%# Eval("curmonth")  %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                <ItemStyle Wrap="true" Font-Size="Small" ForeColor="Black" Width="100px" CssClass="TxtAlign1" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Annual">
                                <ItemTemplate>
                                    <asp:Label ID="lbldetails2" runat="server" Text='<%# Eval("curannual")  %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                <ItemStyle Wrap="true" Font-Size="Small" ForeColor="Black" Width="100px" CssClass="TxtAlign1" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Monthly">
                                <ItemTemplate>
                                    <asp:Label ID="lbldetails3" runat="server" Text='<%# Eval("revmonth")  %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                <ItemStyle Wrap="true" Font-Size="Small" ForeColor="Black" Width="100px" CssClass="TxtAlign1" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Annual">
                                <ItemTemplate>
                                    <asp:Label ID="lbldetails4" runat="server" Text='<%# Eval("revannual")  %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                <ItemStyle Wrap="true" Font-Size="Small" ForeColor="Black" Width="100px" CssClass="TxtAlign1" />
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <%-- <asp:Panel ID="Panel5" runat="server" align="center" CssClass="div_GridAPP1">
                     <asp:Label ID="Label27" runat="server" Font-Bold="true" Text="Revised Salary"></asp:Label>
                    <asp:GridView ID="grdrevised" runat="server" ShowHeader="true" AutoGenerateColumns="false" Width="100%" CssClass="Grid FixedHeader" >
                        <Columns>
                            <asp:TemplateField HeaderText="Salary Break-Up">
                                <ItemTemplate>
                                    <asp:Label ID="lblsno" runat="server" Text='<%# Eval("SB")  %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="350px" Font-Size="small" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Monthly">
                                <ItemTemplate>
                                    <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("Monthly")  %>' ></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                <ItemStyle Wrap="true" Font-Size="Small" Width="100px" CssClass="TxtAlign1" />

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Annual">
                                <ItemTemplate>
                                    <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("Annual")  %>' ></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle HorizontalAlign="Center" Wrap="false"  />
                                <ItemStyle Wrap="true" Font-Size="Small" Width="100px" CssClass="TxtAlign1" />

                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>--%>
            </div>
            <div class="btn btn-approve1">
                <asp:Button ID="Button1" runat="server" Text="Confirm" OnClick="Button1_Click" />
            </div>
            <div class="btn ico-cancel">
                <asp:Button ID="btnclose" runat="server" Text="Cancel" OnClick="btnclose_Click" />
            </div>

        </asp:Panel>
</asp:Content>
