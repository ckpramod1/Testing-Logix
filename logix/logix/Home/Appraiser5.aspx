<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Appraiser5.aspx.cs" Inherits="logix.Home.Appraiser5" %>

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
            width: 10%;
            margin: 0px 0.5% 0px 0px;
        }

        .Self2 {
            float: left;
            width: 15%;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_ddlgrade_chzn {
            width:100%!important;
        }


        .Selfappraisal1 {
            float: left;
            width: 19%;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_ddlmode_chzn {
            width:100%!important;
            margin:0px 0.5% 0px 0px;
        }


        #logix_CPH_ddlredesig_chzn {
            width:100%!important;
        }
        logix_CPH_ddlgrade_chzn {
            width:100%!important;
        }

        .Selfappraisal2 {
            float: left;
            width: 48.5%;
            margin: 0px 1.5% 0px 0px;
        }

        .RatingN {
            width: 47%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .RatingN1 {
            width: 47%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .SelfappraisalN {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .SelfappraisalGood {
            width: 50%;
            float: left;
            margin: 0px 0.5% 0px 0px;
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

        #logix_CPH_ddlsal_chzn {
            width: 100% !important;
        }

        #logix_CPH_ddldesignation_chzn {
            width: 100% !important;
        }

        #logix_CPH_ddlgradestatus_chzn {
            width: 100% !important;
        }

        .SelfappraisalRemarks {
            width: 26%;
            float: left;
            margin: 0px 0px 0px 0%;
        }

        .row {
            height: 525px !important;
            margin: 0px 5px 0px -15px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: hidden !important;
            /* width: 100%; */
        }
        .RatingNA {
    width: 26%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .Self2T {
            width:14%;
            float:left;
            margin:0px 0.5%  0px 0px;
        }

        .SelfN2 {
             width:29.2%;
            float:left;
            margin:0px 0.5%  0px 0px;
        }
          .SelfappraisalN input {
            background-color:#c7e5f1;
            color:#000000;
        }
        .ApraserApraisalN input {
            background-color:#e0c1c1;
            color:#000;
        }
        .chzn-drop {
    height: 150px !important;
    overflow: auto;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <div >
        <div class="col-md-12  maindiv">
            <div class="widget box brdernone" runat="server">

                <div class="widget-content">

                    <div class="FormGroupContent4 bgclrNew">

                        <div class="PageHeaderNew">
                            <i class="icon-umbrella"></i>
                            <asp:Label ID="lbl_Header" runat="server" Text="Appraisal Page - 5"></asp:Label>
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
                        <div style="float: left; width: 49.5%; margin: 0px 0.5% 0px 0px;">
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

                                  <div class="FormGroupContent4 MB10">
                                <asp:Panel ID="Panel1" runat="server" Width="100%" ScrollBars="Auto">
                                    <div class="RatingN">
                                        <asp:Label ID="lblkeyappsee" runat="server" Text="Key [Values from Appraisee]"  Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
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
                                        <div class="SelfappraisalGood">
                                            <asp:Label ID="lblkeyvalue" runat="server" Width="100%" Font-Bold="True" Visible="False" ForeColor="Red" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                        </div>
                                    </asp:Panel>
                                </div>

                                

                            </asp:Panel>

                        </div>
                        <div style="float:left; width:50%;">
                            <div class="FormGroupContent4">

                                    <div class="RatingNA">
                                        <asp:Label ID="Label6" runat="server" Text="Appraisal Remarks " Font-Bold="true"></asp:Label>
                                    </div>
                                    <div class="SelfappraisalGood">
                                        <asp:TextBox ID="txtappremarks" runat="server" Width="100%" Height="50px" TextMode="MultiLine" CssClass="form-control" MaxLength="1000"></asp:TextBox>
                                    </div>
                                </div>



                        </div>
                        <div class="Clear"></div>
                        <div style="float: left; width: 49.5%; margin: 0px 0%  0px 0px;">
                            <div class="Rating Fontwt">
                                <asp:Label ID="Label8" runat="server" Text="Recommendations" Font-Bold="true"></asp:Label>
                            </div>

                            <div class="FormGroupContent4">



                                <div class="RatingN1">
                                    <asp:Label ID="lblkey" runat="server" Text="Salary Revision" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>

                                </div>
                                <div class="Selfappraisal1">
                                    <asp:DropDownList ID="ddlsal" runat="server" OnSelectedIndexChanged="ddlsal_SelectedIndexChanged" AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="No Change" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Revise" Value="2"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                <div style="float:left; width:10px; margin:0px 5px 0px 0px;">
                                    <asp:Label ID="in" runat="server" Text="in"></asp:Label>

                                </div>
                                <div class="Self1" style="display:none">
                                    <asp:Label ID="Label9" runat="server" Text="If Revise" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                </div>
                                <div class="Self2">
                                    <asp:DropDownList ID="ddlmode" runat="server" Width="80px" Enabled="false"  AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="%" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Rs." Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="Self2T">
                                    <asp:TextBox ID="txtsalrev" Width="75px" runat="server" Enabled="false" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                </div>

                            </div>
                            <div class="FormGroupContent4">
                                <div class="RatingN1">
                                    <asp:Label ID="Label11" runat="server" Text="Re-Designate as " Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                </div>
                                <div class="Selfappraisal1">
                                    <asp:DropDownList ID="ddlredesig" runat="server" OnSelectedIndexChanged="ddlredesig_SelectedIndexChanged"  AppendDataBoundItems="True" data-placeholder="Section" CssClass="chzn-select" AutoPostBack="true">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="No Change" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Redesignate" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                   
                                </div>
                                 <div class="Self1" style="display:none">
                                    <asp:Label ID="Label20" runat="server" Text="If Yes" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label></div>
                                <div class="SelfN2">
                                     <asp:DropDownList ID="ddldesignation" runat="server" Width="100%" Enabled="false" AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="RatingN1">
                                    <asp:Label ID="Label13" runat="server" Text="Change in Grade" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                </div>
                                <div class="Selfappraisal1">
                                    <asp:DropDownList ID="ddlgradestatus" runat="server" OnSelectedIndexChanged="ddlgradestatus_SelectedIndexChanged" AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="No Change" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Change" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="Self1" style="display:none">
                                    <asp:Label ID="Label15" runat="server" Text="If Yes" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                </div>
                                <div class="Self2">
                                    <asp:DropDownList ID="ddlgrade" runat="server" Enabled="false" Width="100%" AppendDataBoundItems="True" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>


                            <div class="FormGroupContent4">
                                <div class="RatingN1">
                                    <asp:Label ID="Label17" runat="server" Text="Special remarks" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                </div>
                                <div class="Selfappraisal2">
                                    <asp:TextBox ID="txtspecialremarks" runat="server" Width="100%" Height="50px" TextMode="MultiLine" CssClass="form-control" MaxLength="1000"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>






                    <div class="FormGroupContent4">
                        <div class="right_btn MT0 MB05">
                            <div class="btn ico-view">
                                <asp:Button ID="btnprint" runat="server" Text="Print" OnClick="btnprint_Click" />
                            </div>
                            <div class="btn ico-save">
                                <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
                            </div>
                            <div class="btn btn-nextB1">
                                <asp:Button ID="btnnext" runat="server" Text="Next" />
                            </div>
                            <div class="btn ico-back">
                                <asp:Button ID="btnprevious1" runat="server" Text="Previous" OnClick="btnprevious1_Click" />
                            </div>

                            <div class="btn ico-cancel">
                                <asp:Button ID="btncancel" runat="server" Text="Cancel" Visible="false" OnClick="btncancel_Click" />
                            </div>

                        </div>



                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
