<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="AppPage3.aspx.cs" Inherits="logix.Home.AppPage3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>


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
        .Manpower1 {
    width: 81.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
 
        .ManPower1a {width:90px; float:left; margin:0px 5px 0px 0px;
        }
        .MANDrop1a {
    width: 15.5%;
    float: left;
    margin: 0px 0% 0px 0px;
}
        .MANDrop2a {
    width: 82.5%;
    float: left;
    margin: 0px 0% 0px 0px;

        }

  .row {
    height: 630px !important;
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
                            <asp:Label ID="lbl_Header" runat="server" Text="Appraisal Page - 3"></asp:Label>
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
                  


                        <asp:Panel ID="pnlpage3" runat="server" Width="100%">
                            <div class="AppLeft">

                                <div class="FormGroupContent4">
                                    <asp:Label ID="Label23" runat="server" Text="Performance : Mention your notable achievements [Non KPI related]" Font-Bold="true" Font-Size="12px"></asp:Label>


                                </div>
                                <div class="FormGroupContent4">
                                    <div class="DISNone">
                                        <asp:Label ID="Label25" runat="server" Text="Mention your notable achievements [Non KPI related]"></asp:Label>
                                    </div>
                                    <asp:TextBox ID="txt1ques" runat="server" CssClass="form-control" ToolTip="Mention your notable achievements [Non KPI related]" TextMode="MultiLine" Width="94%" Height="50px" MaxLength="1000"></asp:TextBox>
                                </div>
                                <div class="FormGroupContent4">

                                    <asp:Label ID="Label26" runat="server" Text="Work Environment : Rate the below based on your last one year experience" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                </div>
                                <div class="FormGroupContent4">
                                    <div class="DISNone">
                                        <asp:Label ID="Label27" runat="server" Text=""></asp:Label>


                                        <asp:Label ID="Label28" runat="server" Text="Rate the below based on your last one year experience"></asp:Label>
                                    </div>
                                </div>
                                <div class="FormGroupContent4 BGAltclr1">
                                    <div class="DISNone">
                                        <asp:Label ID="Label39" runat="server" Text="a."></asp:Label>
                                    </div>
                                    <div class="Manpower4">
                                        <asp:Label ID="Label40" runat="server" Text="Manpower"></asp:Label>



                                    </div>
                                    <div class="MANDrop">
                                        <asp:DropDownList ID="ddl2aques" runat="server"  Width="100%" AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Poor" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Average" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Good" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Excellent" Value="4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                </div>
                                <div class="FormGroupContent4 BGAltclr2">
                                    <div class="DISNone">
                                        <asp:Label ID="Label41" runat="server" Text="b."></asp:Label>

                                    </div>
                                    <div class="Manpower4">
                                        <asp:Label ID="Label42" runat="server" Text="Systems[Hardware]"></asp:Label>
                                    </div>
                                    <div class="MANDrop">
                                        <asp:DropDownList ID="ddl2bques" runat="server" Width="100%" AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Poor" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Average" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Good" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Excellent" Value="4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="FormGroupContent4 BGAltclr1">
                                    <div class="DISNone">
                                        <asp:Label ID="Label43" runat="server" Text="c."></asp:Label>
                                    </div>
                                    <div class="Manpower4">
                                        <asp:Label ID="Label44" runat="server" Text="Work Environment"></asp:Label>
                                    </div>
                                    <div class="MANDrop">
                                        <asp:DropDownList ID="ddl2cques" runat="server" Width="100%" AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Poor" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Average" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Good" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Excellent" Value="4"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>

                                </div>
                                <div class="FormGroupContent4 BGAltclr2">
                                    <div class="DISNone">
                                        <asp:Label ID="Label45" runat="server" Text="d."></asp:Label>
                                    </div>
                                    <div class="Manpower4">
                                        <asp:Label ID="Label46" runat="server" Text="Communications"></asp:Label>
                                    </div>
                                    <div class="MANDrop">
                                        <asp:DropDownList ID="ddl2dques" runat="server" Width="100%" AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Poor" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Average" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Good" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Excellent" Value="4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="FormGroupContent4 BGAltclr1">
                                    <div class="DISNone">
                                        <asp:Label ID="Label47" runat="server" Text="e."></asp:Label>
                                    </div>
                                    <div class="Manpower4">
                                        <asp:Label ID="Label48" runat="server" Text="Leadership and Guidance"></asp:Label>
                                    </div>
                                    <div class="MANDrop">
                                        <asp:DropDownList ID="ddl2eques" runat="server" Width="100%" AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Poor" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Average" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Good" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Excellent" Value="4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                </div>
                                <div class="FormGroupContent4 BGAltclr2">
                                    <div class="DISNone">
                                        <asp:Label ID="Label49" runat="server" Text="f."></asp:Label>
                                    </div>
                                    <div class="Manpower4">
                                        <asp:Label ID="Label50" runat="server" Text="Training"></asp:Label>
                                    </div>
                                    <div class="MANDrop">
                                        <asp:DropDownList ID="ddl2fques" runat="server" Width="100%" AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Poor" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Average" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Good" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Excellent" Value="4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>


                                </div>
                                <div class="FormGroupContent4 BGAltclr1">
                                    <div class="DISNone">
                                        <asp:Label ID="Label51" runat="server" Text="g."></asp:Label>
                                    </div>
                                    <div class="Manpower4">
                                        <asp:Label ID="Label52" runat="server" Text="Recognition and Appreciation "></asp:Label>
                                    </div>
                                    <div class="MANDrop">
                                        <asp:DropDownList ID="ddl2gans" runat="server" Width="100%" AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="true">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Poor" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Average" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Good" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Excellent" Value="4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                </div>
                                <div class="FormGroupContent4">
                                    <asp:Label ID="Label14" runat="server" Text="If Recognition and Appreciation received, Please mention "></asp:Label>
                               
                                <asp:TextBox ID="txt2gques" runat="server" CssClass="form-control" TextMode="MultiLine" Width="93.5%" Height="30px" MaxLength="250"></asp:TextBox>
                                     </div>
                            </div>
                            
                    
                    <div class="AppRight">

                        <div class="FormGroupContent4">
                            <asp:Label ID="Label29" runat="server" Text="Self Enhancement and Training" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="Manpower1">
                                <asp:Label ID="Label55" runat="server" Text="Have you obtained additional certification or upgraded your educational qualification during the review period. "></asp:Label>
                            </div>
                            <div class="MANDrop1a">
                                <asp:DropDownList ID="ddl3aques" runat="server" AppendDataBoundItems="True" Width="70px" data-placeholder="Select" OnSelectedIndexChanged="ddl3aques_SelectedIndexChanged1" CssClass="chzn-select" AutoPostBack="true">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>
                        <div class="FormGroupContent4">
                            <div class="ManPower1a">
                                <asp:Label ID="Label70" runat="server" Text="If Yes .. Specify "></asp:Label>
                            </div>
                            <div class="MANDrop2a">
                                <asp:TextBox ID="txtSpecify" runat="server" Enabled="false"  CssClass="form-control" MaxLength="500"></asp:TextBox>
                                </div>
                            <div style="clear:both;"></div>
                            Kindly list training needs/ learning opportunities that you require to help you perform better next year
                        </div>
                        <div class="FormGroupContent4">
                            <div class="Manpower2">
                                <asp:Label ID="Label63" runat="server" Text="Technical "></asp:Label>
                            </div>
                            <div class="MANDrop2">
                                <asp:TextBox ID="txt3aTQues" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                            </div>

                        </div>
                        <div class="FormGroupContent4">
                            <div class="Manpower2">
                                <asp:Label ID="Label66" runat="server" Text="Functional "></asp:Label>
                            </div>
                            <div class="MANDrop2">
                                <asp:TextBox ID="txt3aFQues" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="Manpower2">
                                <asp:Label ID="Label69" runat="server" Text="Softskill "></asp:Label>
                            </div>
                            <div class="MANDrop2">
                                <asp:TextBox ID="txt3aSQues" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                            </div>

                        </div>


                        <div class="FormGroupContent4">
                            <div class="Manpower3">
                                <div>
                                    <asp:Label ID="Label12" runat="server" Text="What are the areas for improvement identified and was it successfully accomplished"></asp:Label>
                                </div>
                                <asp:TextBox ID="txt4aQues" runat="server" ToolTip="What are the areas for improvement identified and was it successfully accomplished" CssClass="form-control" TextMode="MultiLine" Width="100%" Height="30px" MaxLength="500"></asp:TextBox>
                            </div>

                        </div>
                        <div class="FormGroupContent4">
                            <asp:Label ID="Label32" runat="server" Text="Future Objectives" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="Manpower3">
                                <div>
                                    <asp:Label ID="Label13" runat="server" Text="Mention Future objectives that you plan to achieve by the next review"></asp:Label>
                                </div>
                                <asp:TextBox ID="txt4bQues" runat="server" CssClass="form-control" TextMode="MultiLine" ToolTip="Mention Future objectives that you plan to achieve by the next review" Width="100%" Height="30px" MaxLength="500"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                             </asp:Panel>
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
  

   <%-- <asp:Label ID="Label10" runat="server" Style="display: none"></asp:Label>

    <ajax:ModalPopupExtender ID="mpthank" runat="server" PopupControlID="Panel2" TargetControlID="Label10"
        CancelControlID="btnclose" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    <asp:Panel ID="Panel2" runat="server" align="center" Width="75%" Height="50%">
        <table>
            <tr>
                <td align="center">
                    <asp:Label ID="Label11" runat="server" Font-Bold="true" ForeColor="White" BackColor="Black" Font-Size="Large" Text="Instructions"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="true" ForeColor="Black" Font-Size="Medium" Text="1. Carefully evaluate your work experience in relation to the Key performance areas and  Key performance Indicators."></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Bold="true" ForeColor="Black" Font-Size="Medium" Text="2. If you don't understand the questions ask for help either from your immediate Superior/ Branch Head or HR."></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Font-Bold="true" ForeColor="Black" Font-Size="Medium" Text="3. Pages 2-4 relates to Appraisee (Employee) with an ear-marked tab for Appraiser. Page 5-6 is to be used when Appraisee is appraised by appraiser."></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Font-Bold="true" ForeColor="Black" Font-Size="Medium" Text="4. After Appraisee fills her / his self-ratings he/she hands it over to Appraiser. "></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Font-Bold="true" ForeColor="Black" Font-Size="Medium" Text="5. Appraiser than should schedule a time with Appraisee for a joint evaluation wherein Appraiser validates/approve self-Appraisal rating jointly with Appraisee and fills his/her final rating."></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Bold="true" ForeColor="Black" Font-Size="Medium" Text="6. Appraiser should send quality time with Appraisee."></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Font-Bold="true" ForeColor="Black" Font-Size="Medium" Text="7. Rating of Appraiser will be final and will be vetted by Appraisers superior.The highest score is 70 points for the key Result Areas (KRA) / Key Performance Indicator (KPI) and remaining 30 points for Personal Competencies."></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Font-Bold="true" ForeColor="Black" Font-Size="Medium" Text="8. If there are more than 8 KPI's choose the significant ones and try to club 2 or more which are linked."></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Font-Bold="true" ForeColor="Black" Font-Size="Medium" Text="9. Comments should be specific (including examples) and explanatory. If your evaluation and recommendations cannot be adequately covered in the space provided, you should prepare an attachment to this appraisal form."></asp:Label></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnclose" runat="server" Text="Close" /></td>
            </tr>
        </table>

    </asp:Panel>--%>
</asp:Content>
