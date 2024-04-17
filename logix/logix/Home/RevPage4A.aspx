<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="RevPage4A.aspx.cs" Inherits="logix.Home.RevPage4A" %>

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

    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>


    <!-- App -->

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

        .FormGroupContent4 textarea {
            height: 48px !important;
        }

        #logix_CPH_ddl3aques_chzn {
            width: 100% !important;
        }

        .row {
            height: 525px !important;
            margin: 0px 5px 0px -15px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: hidden !important;
            width: 100%;
        }

        .brdernone {
            border: 0px solid #f00 !important;
        }

        .FooterCont {
            top: 592px !important;
        }

        .TableGrid1 {
            height: 369px;
            overflow-x: hidden;
            overflow-y: scroll;
            border: 1px solid #b1b1b1;
        }

        .TableGrid2 {
            height: 167px;
            overflow-x: hidden;
            overflow-y: scroll;
            border: 1px solid #b1b1b1;
        }

        .TableGrid3 {
            height: 167px;
            overflow-x: hidden;
            overflow-y: scroll;
            border: 1px solid #b1b1b1;
            margin: 0px 0px 0px 5px;
        }

        .TableGrid4 {
            height: 180px;
        }
        .row {
    height: 575px !important;
    margin: 0px 5px 0px -15px;
    clear: both;
    overflow-x: hidden !important;
    overflow-y: hidden !important;
    width: 100%;
}
        .PageHeaderNew {
    float: left;
    width: 12%;
    font-weight: bold;
    margin: 0px 0.5% 0px 0px;
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
                            <asp:Label ID="lbl_Header" runat="server" Text="Appraisar Comments "></asp:Label>
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
                            <asp:TextBox ID="txtlocation" runat="server" ReadOnly="true" CssClass="form-control" MaxLength="100"></asp:TextBox>
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







                    <div style="height: 370px;">

                        <div style="float: left; width: 100%; margin: 10px 5px 0px;">
                            <asp:Panel ID="Panel5" runat="server" Width="100%" CssClass="TableGrid1">
                                <asp:GridView ID="grdall" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" 
                                    ShowHeaderWhenEmpty="true" DataKeyNames="compid" OnRowDataBound="grdall_RowDataBound" >
                                    <Columns>
                                        <asp:BoundField DataField="Competency" HeaderText="Competencies">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Height="30px" Width="200px" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtcompetency" runat="server" Enabled="false" ForeColor="Black" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="300px" Font-Size="small" Wrap="false" />
                                        </asp:TemplateField>

                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>

                        <div style="display: none">
                            <div style="float: left; width: 640px; margin: 10px 5px 10px;">
                                <asp:Panel ID="pnlgrd" runat="server" Width="100%" CssClass="TableGrid1">
                                    <asp:GridView ID="grdfunc" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" 
                                        ShowHeaderWhenEmpty="true" DataKeyNames="funccompid">
                                        <Columns>
                                            <asp:BoundField DataField="Functional" HeaderText="Functional Competencies">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle Height="30px" Width="200px" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtFunctional" runat="server" Enabled="false" ForeColor="Black" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="300px" Font-Size="small" Wrap="false" />
                                            </asp:TemplateField>

                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>
                            </div>
                            <div style="float: left; width: 640px; margin: 10px 5px 10px;">
                                <asp:Panel ID="Panel3" runat="server" Width="100%" CssClass="TableGrid2">
                                    <asp:GridView ID="grdpers" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" 
                                        ShowHeaderWhenEmpty="true" DataKeyNames="Perscompid">
                                        <Columns>
                                            <asp:BoundField DataField="Personal" HeaderText="Personal Competencies">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle Height="30px" Width="200px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtpersonal" runat="server" Enabled="false" ForeColor="Black" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="300px" Font-Size="small" Wrap="false" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>
                            </div>

                            <div class="Clear"></div>
                            <div style="float: left; width: 640px;">
                                <asp:Panel ID="Panel4" runat="server" Width="100%" CssClass="TableGrid3">
                                    <asp:GridView ID="grdMan" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" 
                                        ShowHeaderWhenEmpty="true" DataKeyNames="mancompid">
                                        <Columns>
                                            <asp:BoundField DataField="Managerial" HeaderText="Managerial Competencies">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle Height="30px" Width="200px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtmangerial" runat="server" Enabled="false" ForeColor="Black" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="300px" Font-Size="small" Wrap="false" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>
                            </div>
                        </div>
                        <div class="Clear"></div>
                        <div style="float: left; width: 100%;">
                            <asp:Panel ID="pnlpage3" runat="server" Width="100%" CssClass="TableGrid4">
                                <div class="AppLeft" style="display: none;">

                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label23" runat="server" Text="Mention Strengths of the employee " Font-Bold="true" Font-Size="12px"></asp:Label>


                                    </div>
                                    <div class="FormGroupContent4">
                                        <div class="DISNone">
                                            <asp:Label ID="Label25" runat="server" Text="Mention Strength of the employee "></asp:Label>
                                        </div>
                                        <asp:TextBox ID="txtstrength" runat="server" CssClass="form-control" ToolTip="Mention your notable achievements [Non KPI related]" TextMode="MultiLine" Width="94%" Height="70px" MaxLength="1000"></asp:TextBox>
                                    </div>


                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label1" runat="server" Text="Mention areas of improvement identified for the employee.  " Font-Bold="true" Font-Size="12px"></asp:Label>


                                    </div>
                                    <div class="FormGroupContent4">
                                        <div class="DISNone">
                                            <asp:Label ID="Label2" runat="server" Text="Mention areas of improvement identified for the employee. "></asp:Label>
                                        </div>
                                        <asp:TextBox ID="txtimprovement" runat="server" CssClass="form-control" ToolTip="Mention areas of improvement identified for the employee." TextMode="MultiLine" Width="94%" Height="70px" MaxLength="1000"></asp:TextBox>
                                    </div>


                                    <div class="FormGroupContent4">
                                        <div style="float: left; width: 45%">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="true" Font-Size="12px">Mention Training needs for the employee if any :    </asp:Label>
                                        </div>

                                        <div style="float: left; width: 20%; margin: 4px 0px 0px 0px;">
                                            <asp:DropDownList ID="ddlyesNo" runat="server" Width="100%"  AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="2"></asp:ListItem>

                                            </asp:DropDownList>

                                        </div>
                                        <div class="FormGroupContent4">
                                            <div class="DISNone">
                                                <asp:Label ID="Label9" runat="server" Text="Mention Effectiveness of Training Attended "></asp:Label>
                                            </div>
                                            <asp:TextBox ID="txttrainneed" runat="server" CssClass="form-control" ToolTip="Mention Effectiveness of Training Attended " TextMode="MultiLine" Width="94%" Height="70px" MaxLength="1000"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label4" runat="server" Text="Details of Training Needed   " Font-Bold="true" Font-Size="12px"></asp:Label>
                                        <asp:TextBox ID="txttraining" runat="server" CssClass="form-control" ToolTip="Mention Training needs for the employee if any " TextMode="MultiLine" Width="94%" Height="70px" MaxLength="1000"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="AppRight" style="display: none;">

                                    <div class="FormGroupContent4">
                                        <asp:Label ID="Label5" runat="server" Text="Mention Effectiveness of Training Attended " Font-Bold="true" Font-Size="12px"></asp:Label>


                                    </div>
                                    <div class="FormGroupContent4">
                                        <div class="DISNone">
                                            <asp:Label ID="Label6" runat="server" Text="Mention Effectiveness of Training Attended "></asp:Label>
                                        </div>
                                        <asp:TextBox ID="txteffective" runat="server" CssClass="form-control" ToolTip="Mention Effectiveness of Training Attended " TextMode="MultiLine" Width="94%" Height="70px" MaxLength="1000"></asp:TextBox>
                                    </div>



                                    <div class="FormGroupContent4">
                                        <%--<asp:Label ID="Label7" runat="server" Text="Gaps in Competency " Font-Bold="true" Font-Size="12px"></asp:Label>--%>
                                        <asp:Label ID="Label12" runat="server">Gaps in<asp:LinkButton ID="Button2" runat="server"> Competencies  </asp:LinkButton>
                                        </asp:Label>
                                    </div>

                                    <div class="FormGroupContent4">
                                        <div class="DISNone">
                                            <asp:Label ID="Label8" runat="server" Text="Gaps in Competency "></asp:Label>
                                        </div>
                                        <asp:TextBox ID="txtgaps" runat="server" CssClass="form-control" ToolTip="Gaps in Competency " TextMode="MultiLine" Width="94%" Height="70px" MaxLength="1000"></asp:TextBox>
                                    </div>

                                </div>


                                
                            </asp:Panel>


                            
                        </div>
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
                                            <asp:Button ID="btnsavepage2" runat="server" Text="Save" Visible="false" />
                                        </div>
                                        <div class="btn ico-cancel">
                                            <asp:Button ID="btncancelpage2" runat="server" Text="Cancel" Visible="false" />
                                        </div>
                                    </div>

                                </div>
                   
                </div>
            </div>
        </div>


        <asp:Label ID="Label10" runat="server" Style="display: none"></asp:Label>
        <asp:Label ID="Label7" runat="server" Style="display: none"></asp:Label>

        <div style="display: none">


            <ajax1:ModalPopupExtender ID="mpthank" runat="server" PopupControlID="Panel2" TargetControlID="Label10"
                CancelControlID="Label7" BackgroundCssClass="modalBackground">
            </ajax1:ModalPopupExtender>
            <asp:Panel ID="Panel2" runat="server" align="center" CssClass="div_GridAPP" Width="75%" Height="76%">
                <div class="FormGroupContent4">
                    <asp:Label ID="Label11" runat="server" ForeColor="Black" Font-Bold="true" Text="Gaps in Competencies"></asp:Label>
                </div>
                <div class="FormGroupContent4">
                    <asp:Panel ID="Panel1" runat="server" align="center" CssClass="div_GridAPP" ScrollBars="Vertical">
                        <asp:GridView ID="grd_user" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" 
                            ShowHeaderWhenEmpty="true">
                            <Columns>
                                <asp:BoundField DataField="Functional" HeaderText="Functional Competencies">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Height="30px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Personal" HeaderText="Personal Competencies">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Height="30px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Managerial" HeaderText="Managerial Competencies">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Height="30px" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                    </asp:Panel>
                </div>
                <div class="FormGroupContent4">
                    <asp:TextBox ID="txtpopgaps" runat="server" CssClass="form-control" placeholder="Gaps in Competencies" ToolTip="Gaps in Competency " TextMode="MultiLine" Width="50%" Height="70px" MaxLength="1000"></asp:TextBox>
                </div>
                <div class="btn ico-cancel" style="text-align: center; width: 100%; margin: 2px auto 0px;">
                    <asp:Button ID="btnclose" runat="server" Text="Close" />
                </div>

            </asp:Panel>
        </div>
</asp:Content>