<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="AppraNew5.aspx.cs" Inherits="logix.Home.AppraNew5" %>

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
        function pageLoad(sender, args) {

            $(document).ready(function () {



                $('.selectpicker').selectpicker();

                "use strict";

                App.init(); // Init layout and core plugins
                Plugins.init(); // Init all plugins
                FormComponents.init(); // Init all form-specific plugins

                //$('select.styled').customSelect();

            });





            function fn_test()
            { alertify.alert('success'); }
        }

    </script>
    <style type="text/css">
        .brdernone {
            border: 0px solid #f00 !important;
        }

        .ApraserApraisalGood {
            width: 12%;
            float: left;
            color: #ff0000;
        }

        .SelfappraisalGood {
            width: 40%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .RatingN {
            width: 25%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        .row {
    height: 580px !important;
    margin: 0px 5px 0px -15px;
    clear: both;
    overflow-x: hidden !important;
    overflow-y: auto !important;
    width: 100%;
}
    </style>

    <%--<script type="text/javascript">
        function getData() {
            $.ajax({
                url: "../FormMain.aspx",
                type: "post",
                success: function (data) {
                    alertify.alert("success");
                }
            });
        }
    </script>--%>
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
                            <asp:Label ID="lbl_Header" runat="server" ReadOnly="true" Text="Appraisal Page - 5"></asp:Label>
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
                        <asp:Panel ID="pnlpage3" runat="server" Width="100%" ScrollBars="Auto">
                            <div class="FormGroupContent4">
                                <div class="Rating">
                                    <asp:Label ID="Label3" runat="server" Text="Rating Details" Font-Bold="true" ForeColor="Maroon"></asp:Label>
                                </div>
                                <div class="Selfappraisal">
                                    <asp:Label ID="Label4" runat="server" Text="Self " Font-Bold="true" ForeColor="Maroon"></asp:Label>
                                </div>
                                <div class="ApraserApraisal">
                                    <asp:Label ID="Label5" runat="server" Text="Appraiser" Font-Bold="true" ForeColor="Maroon"></asp:Label>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="Rating">
                                    <asp:Label ID="Label23" runat="server" Text="Total Rating on KPI" Font-Bold="true"></asp:Label>
                                </div>
                                <div class="Selfappraisal">
                                    <asp:TextBox ID="txtselfkpi" runat="server" ReadOnly="true" CssClass="form-control" MaxLength="1000"></asp:TextBox>
                                </div>
                                <div class="ApraserApraisal">
                                    <asp:TextBox ID="txtappkpi" runat="server" ReadOnly="true" CssClass="form-control" Width="100%" MaxLength="1000"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="Rating">
                                    <asp:Label ID="Label1" runat="server" Text="Total Rating on Competencies" Font-Bold="true"></asp:Label>
                                </div>
                                <div class="Selfappraisal">
                                    <asp:TextBox ID="txtselfcomp" runat="server" ReadOnly="true" CssClass="form-control" Width="100%" MaxLength="1000"></asp:TextBox>
                                </div>
                                <div class="ApraserApraisal">
                                    <asp:TextBox ID="txtappcomp" runat="server" ReadOnly="true" CssClass="form-control" Width="100%" MaxLength="1000"></asp:TextBox>
                                </div>

                            </div>
                            <div class="FormGroupContent4">

                                <div class="Rating">
                                    <asp:Label ID="Label2" runat="server" Text="Actual Performance rating of an Individual " Font-Bold="true"></asp:Label>
                                </div>
                                <div class="Selfappraisal">
                                    <asp:TextBox ID="totself" runat="server" ReadOnly="true" CssClass="form-control" MaxLength="1000"></asp:TextBox>
                                </div>
                                <div class="ApraserApraisal">
                                    <asp:TextBox ID="totalapp" runat="server" ReadOnly="true" CssClass="form-control" MaxLength="1000"></asp:TextBox>
                                </div>
                            </div>

                            <div class="FormGroupContent4 MB10">
                                <div class="Rating">
                                    <asp:Label ID="Label7" runat="server" Text="Key [Values from Appraisee]"  Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                </div>
                                <div class="ApraserApraisalGood">
                                    <asp:Label ID="lblkeyappraisee" runat="server" Font-Bold="true" Visible="false" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                </div>
                            </div>

                            <div class="FormGroupContent4 MB10">
                                <div class="Rating">
                                    <asp:Label ID="lblkeylabel" runat="server" Text="Key [Values from Appraiser]" Visible="false" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                </div>
                                <div class="ApraserApraisalGood">
                                    <asp:Label ID="lblkeyvalue" runat="server" Font-Bold="true" Visible="false" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                </div>
                            </div>
                            <div class="FormGroupContent4">

                                <div class="RatingN">
                                    <asp:Label ID="Label6" runat="server" Text="Appraisal Remarks " Font-Bold="true"></asp:Label>
                                </div>
                                <div class="SelfappraisalGood">
                                    <asp:TextBox ID="txtappremarks" runat="server" Width="100%" Height="50px" TextMode="MultiLine" CssClass="form-control" MaxLength="1000"></asp:TextBox>
                                </div>
                            </div>

                        </asp:Panel>

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
                                <asp:Button ID="btnnext" runat="server" Text="Next" Enabled="false" />
                            </div>
                            <div class="btn ico-back">
                                <asp:Button ID="btnprevious1" runat="server" Text="Previous" OnClick="btnprevious1_Click" />
                            </div>
                            <div class="btn ico-cancel">
                                <asp:Button ID="btncancel" runat="server" Visible="false" Text="Cancel" OnClick="btncancel_Click" />
                            </div>

                        </div>



                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
