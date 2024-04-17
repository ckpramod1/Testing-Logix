<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation="false" AutoEventWireup="true"
    CodeBehind="ClaimDetail.aspx.cs" Inherits="logix.HRM.ClaimDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    <link href="../Theme/newTheme/css/systemnewdeign.css" rel="stylesheet" />
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/lodash.compat.min.js"></script>

    <!-- Smartphone Touch Events -->
    <script type="text/javascript" src="../Theme/Content/plugins/touchpunch/jquery.ui.touch-punch.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/event.swipe/jquery.event.move.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/event.swipe/jquery.event.swipe.js"></script>

    <!-- General -->
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/breakpoints.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/respond/respond.min.js"></script>
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/cookie/jquery.cookie.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- Page specific plugins -->
    <!-- Charts -->
    <script type="text/javascript" src="../Theme/Content/plugins/sparkline/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/blockui/jquery.blockUI.min.js"></script>

    <!-- Forms -->
    <script type="text/javascript" src="../Theme/Content/plugins/typeahead/typeahead.min.js"></script>
    <!-- AutoComplete -->
    <script type="text/javascript" src="../Theme/Content/plugins/autosize/jquery.autosize.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/inputlimiter/jquery.inputlimiter.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/uniform/jquery.uniform.min.js"></script>
    <!-- Styled radio and checkboxes -->
    <script type="text/javascript" src="../Theme/Content/plugins/tagsinput/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/select2/select2.min.js"></script>
    <!-- Styled select boxes -->
    <script type="text/javascript" src="../Theme/Content/plugins/fileinput/fileinput.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/duallistbox/jquery.duallistbox.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-inputmask/jquery.inputmask.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-wysihtml5/wysihtml5.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-multiselect/bootstrap-multiselect.min.js"></script>

    <!-- Globalize -->
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/globalize.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/cultures/globalize.culture.de-DE.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/cultures/globalize.culture.ja-JP.js"></script>

    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>
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

 <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>







    <link href="../Styles/ClaimDetail.css" rel="stylesheet" type="text/css" />
        <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    <style type="text/css">
        .Claimdate {
    float: left;
    margin: 0 0.5% 0 0;
    width: 6%;
}
        .ClaimChk {
    float: left;
    margin: 0 0.5% 0 0;
    width: 5%;
}

            .ClaimChk label {
                display:inline-block; margin:1px 0px 0px 5px;
            }

.ClaimEmp {
    width: 8%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.ClaimEmpName {
    width: 24.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.Division {
    width: 30%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.Branch {
    width: 12.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.ClaimDrop {
    width: 23%;
    float: left;
    margin: 0px 0% 0px 0px;
}

.ClaimAmount {
    width: 14.4%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

.ClaimNon {
    width: 13.5%;
    float: left;
    margin: 0px 0% 0px 0px;
}

/*LOG DETAILS CSS*/


        .btn-logic1 {
            z-index: 2;
            border-radius: 0px;
        }

            .btn-logic1 a {
                border: medium none;
                line-height: normal;
                color: #4e4e4c !important;
                padding: 5px 0px 10px 28px;
                background: url(../Theme/assets/img/buttonIcon/log_ic1.png) no-repeat left 0px;
                margin: 0px 0px 2px 10px;
                font-size: 11px;
            }


        .modalPopupssLog {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 48.5%;
            height: 232px;
            margin-left: 1%;
            margin-top: -0.9%;
            overflow: auto;
        }

        .GridpnlLog {
            width: 100%;
        }

        .DivSecPanelLog {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-right: 0%;
            margin-top: 0.5%;
            border-radius: 90px 90px 90px 90px;
            z-index: 999999;
            position: relative;
            float: right;
        }


            .DivSecPanelLog img {
                float: right;
                width: 16px !important;
                height: 16px !important;
            }


        .GridNew {
            font-family: sans-serif;
            font-size: 10pt;
            color: Black;
            margin-top: 0px;
            width: 100%;
        }

            .GridNew th {
                background-color: #dbdbdb !important;
                border-right: 1px solid #51789d;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                font-size: 11px;
                color: #4e4c4c !important;
            }

            .GridNew td {
                border-right: 1px solid #dddddd;
                font-size: 11px;
                text-align: left;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                margin: 0px;
                color: #4e4c4c;
                border-bottom: 1px solid #dddddd;
            }

             .LogHeadLbl {
             width:65%;
             float:left;
             margin:2px 0px 3px 4px;

         }

         .LogHeadLbl label
         {
             color:#af2b1a;
             font-weight:bold;
             font-size:12px;
         }



         .LogHeadJob {
             width:auto;
             float:left;
             margin:0px 0.5% 0px 0px;
         }

         .LogHeadJobInput label {
             font-size:12px;             
            
         }


           .LogHeadJobInput {
             width:15%;
             float:left;
             margin:1px 0.5% 0px 0px;
         }

             .LogHeadJobInput span {
                 color:#1a65af;
                 font-size:12px;
                 margin:4px 0px 0px 0px;
             }




             .LogHeadJobInput label {
                 font-size:12px;
                 font-family:sans-serif;
                 color:#4e4e4c;
             }

             logix_CPH_PanelLog {
             border-width: 2px;
             border-style: solid;
             position: fixed;
             z-index: 100001;
             left: 352px;
             top: 187px !important;
         }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">HRM</a> </li>
              <li class="current"> Employee Claim </li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
     <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/claimdetails_ic.png" /> <asp:Label ID="lbl_Header" runat="server" Text="Employee Claim"></asp:Label>
        
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">  
            
              <div class="FormGroupContent4">
                  <div class="ClaimEmp">
                      <div class="LabelWidth">Emp Code</div>
                      <div class="FieldInput"><asp:TextBox ID="txt_Empcode" runat="server" placeholder="" ToolTip="EmpCode" CssClass="form-control"  AutoPostBack="True" OnTextChanged="txt_Empcode_TextChanged" TabIndex="1" MaxLength="4"></asp:TextBox></div>
                      
                      </div>
                 <div class="ClaimEmpName">
                     <div class="LabelWidth">Emp Name</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_EmpName" runat="server" placeholder="" ToolTip="EmpName" CssClass="form-control" ReadOnly="True" TabIndex="2"></asp:TextBox></div>
                     </div>
                   <div class="Division"> 
                       <div class="LabelWidth">Division</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_division" runat="server" placeholder="" ToolTip="Division" CssClass="form-control" TabIndex="3"></asp:TextBox></div>
                       </div>
                  <div class="Branch">
                       
                       <div class="LabelWidth">Branch</div>
                       <div class="FieldInput"> <asp:TextBox ID="txt_branch" runat="server" placeholder="" ToolTip="Branch" CssClass="form-control" TabIndex="4"></asp:TextBox></div>
                      </div>
                  <div class="ClaimDrop"> 
                       <div class="LabelWidth">Branch</div>
                       <div class="FieldInput"><asp:DropDownList ID="ddl_claim" runat="server" CssClass="chzn-select" AutoPostBack="true" data-placeholder="Branch" ToolTip="Branch" OnSelectedIndexChanged="ddl_claim_SelectedIndexChanged" TabIndex="5">
                <asp:ListItem Value="0"> Claim Details </asp:ListItem>
                <asp:ListItem Value="AE">Entertainment Allowance</asp:ListItem>
                <asp:ListItem Value="T">Leave Encashment</asp:ListItem>
                <asp:ListItem Value="LT">LTA</asp:ListItem>
                <asp:ListItem Value="M">Medical</asp:ListItem>
                <asp:ListItem Value="OT">Other Income</asp:ListItem>
                <asp:ListItem Value="PE">Previous Employer Income</asp:ListItem>
            </asp:DropDownList></div>
                       </div>
                  </div>
            <div class="FormGroupContent4">
                   
                   <div class="Claimdate">
                       <div class="LabelWidth">Claim On</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_claim" runat="server" placeholder="" ToolTip="Claim On" CssClass="form-control" TabIndex="6"></asp:TextBox></div>
                       </div>
                   <div class="Claimdate">
                       <div class="LabelWidth">Settled On</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_settled" runat="server" placeholder="Settled On" ToolTip="Settled On" CssClass="form-control" TabIndex="7"></asp:TextBox></div>
                       </div>
                   <div class="ClaimChk MTCtrl6"><asp:CheckBox ID="Chk_IT" runat="server" Text="Chk_IT" AutoPostBack="true" OnCheckedChanged="Chk_IT_CheckedChanged" TabIndex="8"  /></div>
                   <div class="ClaimAmount" > 
                       <div class="LabelWidth">Claim Amount</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_amount" runat="server" style="text-align:right"  placeholder="" ToolTip="Claim Amount" CssClass="form-control" TabIndex="9"></asp:TextBox></div>
                       </div>
                   <div class="ClaimTax">
                       <div class="LabelWidth">Taxable Amount</div>
                       <div class="FieldInput"><asp:TextBox ID="txtTaxableAmount" runat="server" style="text-align:right" placeholder="" AutoPostBack="true" ToolTip="Taxable Amount" CssClass="form-control" OnTextChanged="txtTaxableAmount_TextChanged" TabIndex="10"></asp:TextBox></div>
                       </div>
                   <div class="ClaimNon">
                       <div class="LabelWidth">Non-Taxable Amount</div>
                       <div class="FieldInput"><asp:TextBox ID="txtNonTaxableAmount" runat="server" style="text-align:right" placeholder="" ToolTip="Non-Taxable Amt" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtNonTaxableAmount_TextChanged" TabIndex="11"></asp:TextBox></div>
                       </div>
                <div class="right_btn MTCtrl6">
                      <div class="btn ico-save" id="btn_save1" runat="server"><asp:Button ID="btn_save" runat="server" ToolTip="Save" OnClick="btn_save_Click" TabIndex="12" /></div>
                      <div class="btn ico-view"><asp:Button ID="btn_view" runat="server" ToolTip="View"  OnClick="btn_view_Click" TabIndex="13" /></div>
                      <div class="btn ico-cancel" id="btn_cancel1" runat="server"><asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click" TabIndex="14" /></div>


                  </div>
 
                   </div>
            
               <div class="FormGroupContent4">
                   <div class="div_Grid">
            <asp:GridView ID="Grd_Claim" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl"
                DataKeyNames="clchk,ctype" Width="100%" ForeColor="Black" 
                ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="Grd_Claim_SelectedIndexChanged" OnRowDeleting="Grd_Claim_RowDeleting" OnRowDataBound="Grd_Claim_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="claimtype" HeaderText="Claim Type" />
                    <asp:BoundField DataField="cdate" HeaderText="Date" />
                    <asp:BoundField DataField="claimamt" HeaderText="Amount" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" >
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="seton" HeaderText="Settled On">
                        <HeaderStyle Width="650px" />
                        <ItemStyle Width="650px" />
                        </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="Img_Edudelete" runat="server" CommandName="select" CssClass="Grid_Edit_Img"
                                ImageUrl="~/images/delete.jpg" OnClientClick="javascript:IsConfirm('Do U Want Delete','hid_confirm');" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
        </div>

                   </div>
            </div>
         </div>

      

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>ClaimDetail #</label>

                                </div>
                                <div class="LogHeadJobInput">

                                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                                </div>

                            </div>
                            <div class="DivSecPanel">
                                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>

                            <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl">

                                <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="20"
                                    BackColor="White">
                                    <Columns>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="myGridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <PagerStyle CssClass="GridviewScrollPager" />
                                </asp:GridView>

                            </asp:Panel>
                            <div class="Break"></div>
                        </div>


                    </asp:Panel>
                   


     <asp:Label ID="Label3" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label3" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>    


  
    
        
        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_claim"></asp:CalendarExtender>
        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_settled"></asp:CalendarExtender>
        <div class="div_break">
        </div>
    
    <asp:HiddenField ID="hid_confirm" runat="server" />
    <asp:HiddenField ID="hid_ctype" runat="server" />
     <asp:HiddenField ID="hid_ctypes" runat="server" />
    <asp:HiddenField ID="hid_date" runat="server" />
    <asp:HiddenField ID="hid_amount" runat="server" />
</asp:Content>
