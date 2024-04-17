<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="AppPage1.aspx.cs" EnableEventValidation="false" Inherits="logix.Home.AppPage1" %>

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
            background-color: #ffffff;
            filter: alpha(opacity=90);
            opacity: 0.5;
        }


        .Grid {
    width: 100%;
    border: 1px solid #b1b1b1;
    margin: 0px 0px 0px 0px;
    overflow-x: hidden!important;
    overflow-y: auto!important;
    background-color:#ffffff;
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
        .btnAlign span {text-align:center; display:block;
        }
        .btnAlign input {text-align:center; display:block;
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
    <style type="text/css">
        .row {
    height: 575px !important;
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
                            <asp:TextBox ID="txtdoj" ToolTip="Date of Joining" ReadOnly="true" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="DoCApp">
                            <asp:TextBox ID="txtdoc" ToolTip="Date of Confirmation" ReadOnly="true" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>

                    </div>



                    <div class="FormGroupContent4">

                        <div class="LocationApp" style="display: none;">
                            <asp:TextBox ID="txtlocation" runat="server" ReadOnly="true" ToolTip="Branch" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="CTCCtrl">
                            <div class="GrossMonthly">Gross Monthly</div>
                            <div class="GrossApp">
                                <asp:TextBox ID="txtgrossmon" runat="server" ReadOnly="true" ToolTip="Gross Monthly" CssClass="form-control TxtAlign1" MaxLength="100"></asp:TextBox>
                            </div>
                            <div class="CtcMonthly1">CTC Monthly</div>
                            <div class="EmpCodeApp" style="float: left">
                                <asp:TextBox ID="txtctcmon" runat="server" ReadOnly="true" ToolTip="CTC Monthly" CssClass="form-control TxtAlign1" MaxLength="100"></asp:TextBox>
                            </div>
                            <div class="CtcAnnual1">CTC Annually</div>
                            <div class="CTCanApp">
                                <asp:TextBox ID="txtctcann" runat="server" ReadOnly="true" ToolTip="CTC Annually" CssClass="form-control TxtAlign1" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="InstructionApp">
                            <asp:CheckBox ID="chkagree" Text=" " TextAlign="Left" runat="server" ToolTip="Access" />
                            <asp:Label ID="Label23" ForeColor="Black" runat="server">I have read the<asp:LinkButton ID="Button2" OnClick='btn_instr_Click' runat="server"> Instructions </asp:LinkButton>
                                </asp:Label>
                        </div>
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
                                            <asp:Label ID="lblweightage" runat="server" Text='<%# Eval("Weightage")  %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        <ItemStyle Wrap="false" Font-Size="Small" Width="10%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField>

                                        <HeaderTemplate>
                                            <asp:Label ID="lblctcann" runat="server" Text="Self Ratings"></asp:Label>
                                        </HeaderTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" />
                                        <ItemStyle Wrap="false" Width="10%" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtselfrating" runat="server" Text='<%# Eval("selfrating")  %>' CssClass="form-control" MaxLength="2" onkeypress="return isNumberKey(event)"></asp:TextBox>
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
                        <div style="float: left">
                            <div class="btn ico-save">
                                <asp:Button ID="btnconfirmedon" runat="server" Text="Confirm" OnClick="btnconfirmedon_Click" />
                            </div>
                             <div class="btn ico-view" style="display:none;">
                                <asp:Button ID="btnprint" runat="server" Text="View"  Visible="false" OnClick="btnprint_Click" />
                            </div>
                        </div>
                        <div class="right_btn MT0 MB10">
                            <div class="btn btn-nextB1">
                                <asp:Button ID="btnnext" runat="server" Text="Next" OnClick="btnnext_Click" />
                            </div>
                            <div class="btn ico-back">
                                <asp:Button ID="btnback" Enabled="false" runat="server" Text="Previous" OnClick="btnback_Click" />
                            </div>
                            <div class="btn ico-save">
                                <asp:Button ID="btnsave" runat="server" Visible="false" Text="Save" OnClick="btnsave_Click" />
                            </div>
                            <div class="btn ico-cancel">
                                <asp:Button ID="btncancel" runat="server" Visible="false" Text="Cancel" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>




        </div>
    </div>


    <asp:Label ID="Label10" runat="server" Style="display: none"></asp:Label>

    <ajax1:ModalPopupExtender ID="mpthank" runat="server" PopupControlID="Panel2" TargetControlID="Label10"
        CancelControlID="btnclose" BackgroundCssClass="modalBackground">
    </ajax1:ModalPopupExtender>
    <asp:Panel ID="Panel2" runat="server" align="center" CssClass="Grid FixedHeader"  Width="75%" Height="50%">
        <table>
            <tr>
                <td align="center" class="btnAlign">
                    <asp:Label ID="Label11" runat="server"  Text="Instructions"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server"  Text="1. Carefully evaluate your work experience in relation to the Key performance areas and  Key performance Indicators."></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="2. If you don't understand the questions ask for help either from your immediate Superior/ Branch Head or HR."></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server"  Text="3. Pages 2-4 relates to Appraisee (Employee) with an ear-marked tab for Appraiser. Page 5-6 is to be used when Appraisee is appraised by appraiser."></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server"  Text="4. After Appraisee fills her / his self-ratings he/she hands it over to Appraiser. "></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="5. Appraiser than should schedule a time with Appraisee for a joint evaluation wherein Appraiser validates/approve self-Appraisal rating jointly with Appraisee and fills his/her final rating."></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server"  Text="6. Appraiser should send quality time with Appraisee."></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="7. Rating of Appraiser will be final and will be vetted by Appraisers superior.The highest score is 70 points for the key Result Areas (KRA) / Key Performance Indicator (KPI) and remaining 30 points for Personal Competencies."></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server"  Text="8. If there are more than 8 KPI's choose the significant ones and try to club 2 or more which are linked."></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server"  Text="9. Comments should be specific (including examples) and explanatory. If your evaluation and recommendations cannot be adequately covered in the space provided, you should prepare an attachment to this appraisal form."></asp:Label></td>
            </tr>
            
        </table>
         <div class="btn ico-cancel" style="text-align:center; width:100%; margin:2px auto 0px;">
                    <asp:Button ID="btnclose" runat="server" Text="Close"  />
                        </div>

    </asp:Panel>
</asp:Content>
