<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="GradeDetails.aspx.cs" Inherits="logix.HRM.GradeDetails" %>

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
    <link href="../Styles/VoucherRegister.css" rel="stylesheet" />
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <link href="../Theme/newTheme/css/systemnewdeign.css" rel="stylesheet" />
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
    <style>
          #logix_CPH_pnldebit {
            left: 350px !important;
            top: 220px !important;
            text-align: center;
        }
          .GradeCal {
    float: left;
    margin: 0 0.5% 0 0;
    width: 6.5%;
}
          .GraddeEntertain {
    float: left;
    margin: 0 0 0 0;
    width: 23%;
}


.GradeName {
    width: 10%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

.GradeMedical {
    width: 10%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.GradeDriver {
    width: 12%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.GraddeEntertain {
    float: left;
    margin: 0 0 0 0;
    width: 10%;
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

    <link href="../Styles/GradeDetails.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txt_GradeName.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetGradeName",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1]

                                    }
                                }))
                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }
                        });
                    },
                    select: function (e, i) {
                        $("#<%=hid.ClientID %>").val(i.item.val);
                        $("#<%=txt_GradeName.ClientID %>").change();
                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=hid.ClientID %>").val(i.item.val);
                            $("#<%=txt_GradeName.ClientID %>").val(i.item.label);
                        }
                    },
                    focus: function (e, i) {
                        $("#<%=hid.ClientID %>").val(i.item.val);
                        $("#<%=txt_GradeName.ClientID %>").val(i.item.label);
                    },
                    close: function (e, i) {
                        if (i.item) {
                            $("#<%=hid.ClientID %>").val(i.item.val);
                            $("#<%=txt_GradeName.ClientID %>").val(i.item.label);
                        }
                    },
                    minLength: 1
                });
            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">



      <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">HRM</a> </li>
              <li class="current">Grade Details</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->

      <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/gradedetails_ic.png" /> <asp:Label ID="lbl_Header" runat="server" Text="Grade Details"></asp:Label>
        
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg"> 
            <div class="FormGroupContent4">
                 <div class="GradeName">
                     <div class="LabelWidth">Grade Name</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_GradeName" runat="server" AutoPostBack="True" placeholder="" ToolTip="Grade Name" CssClass="form-control" OnTextChanged="txt_GradeName_TextChanged" TabIndex="1"></asp:TextBox></div>
                     </div>
                 <div class="GradeCal">
                     <div class="LabelWidth">Valid From</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_From" runat="server" placeholder="" ToolTip="Valid From" CssClass="form-control" TabIndex="2"></asp:TextBox></div>
                     </div>
                 <div class="GradeCal">
                     
                     <div class="LabelWidth">Valid To </div>
                     <div class="FieldInput"><asp:TextBox ID="txt_to" runat="server" placeholder="" ToolTip="Valid To" CssClass="form-control" TabIndex="3"></asp:TextBox></div>
                     </div>
                 <div class="GradeMedical">
                     <div class="LabelWidth">Medical</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_medical" runat="server" style="text-align:right" placeholder="" ToolTip="Medical" CssClass="form-control" TabIndex="4"></asp:TextBox></div>
                     </div>
                 <div class="GradeDriver">
                     <div class="LabelWidth">Driver Wages</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_driverwages" runat="server" style="text-align:right" placeholder="" ToolTip="Driver Wages" CssClass="form-control" TabIndex="5"></asp:TextBox></div>
                     </div>
                 <div class="GraddeEntertain">
                     <div class="LabelWidth">Entertain Allowance</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_entertain" runat="server" style="text-align:right" placeholder="" ToolTip="Entertain Allowance" CssClass="form-control" TabIndex="6"></asp:TextBox></div>
                     </div>
                 </div>
             <div class="FormGroupContent4">
                <div class="bordertopNew"></div>
            </div>
             <div class="FormGroupContent4">
                   <div class="right_btn">
                       <div class="btn ico-save" id="btn_save1" runat="server"> <asp:Button ID="btn_save" runat="server" ToolTip="Save" OnClick="btn_save_Click" TabIndex="7" /></div>
                       <div class="btn ico-view"><asp:Button ID="btn_view" runat="server" ToolTip="View"  OnClick="btn_view_Click" TabIndex="8" /></div>
                       <div class="btn ico-cancel" id="btn_cancel1" runat="server"><asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click" TabIndex="9" /></div>
                   </div>

                   </div>
            <div class="FormGroupContent4">
                <div class="bordertopNew"></div>
            </div>
              <div class="FormGroupContent4">
                  <div class="div_Grid">
            <asp:GridView ID="Grd_Grade" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl"
                Width="100%" ForeColor="Black"  ShowHeaderWhenEmpty="True"
                DataKeyNames="gradeid"
                OnSelectedIndexChanged="Grd_Grade_SelectedIndexChanged" OnRowDataBound="Grd_Grade_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="validfrom" HeaderText="Valid From" />
                    <asp:BoundField DataField="validto" HeaderText="Valid To" />
                    <asp:BoundField DataField="medical" HeaderText="Medical" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1"    >
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="driverall" HeaderText="Driver Wages" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1"   >
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ea" HeaderText="Entertain Allowan"  DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1"   >
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="Img_Edudelete" runat="server" CommandName="select" CssClass="Grid_Edit_Img"
                                ImageUrl="~/images/delete.jpg" OnClientClick="javascript:IsConfirm('Do you want to Delete this record','hid_confirm');" />
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















     <asp:Panel runat="Server" ID="pnldebit" CssClass="Pnl" Style="display: none;">
            <br />
            Its not Financial Year, Do You Want to Process ?
        <br />
            <br />
            <div class="div_confirm">
                <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="btn"
                    OnClick="btnYes_Click" />
                <asp:Button ID="btnNo" runat="server" Text="No" CssClass="btn"
                    OnClick="btnNo_Click" />
            </div>
        </asp:Panel>
    <asp:ModalPopupExtender ID="Confirmdialog" runat="server" TargetControlID="Label1"
        PopupControlID="pnldebit" BackgroundCssClass="modalBackground" />

     <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Grade Details #</label>

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

    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_from"></asp:CalendarExtender>
    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_to"></asp:CalendarExtender>
    <asp:HiddenField ID="hid" runat="server" />
    <asp:HiddenField ID="hid_Gid" runat="server" />
    <asp:HiddenField ID="hid_pln" runat="server" />
    <asp:HiddenField ID="hid_confirm" runat="server" />
    <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>
</asp:Content>
