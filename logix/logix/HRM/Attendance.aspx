<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="true" CodeBehind="Attendance.aspx.cs" Inherits="logix.HRM.Attendance" %>
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
        <link href="../Theme/newTheme/css/systemnewdeign.css" rel="stylesheet" />

    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
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



    <link href="../Styles/Attendance.css" rel="stylesheet" />   
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {           
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    <style type="text/css">
        .AttendanceCal {
    float: right;
    margin: 0;
    width: 7%;
}

        .AttendanceComDrop {
    float: left;
    width: 26%;
    margin: 0px 0.5% 0px 0px;
}
        .AttendanceBraDrop {
    float: left;
    width: 13%;
    margin: 0px 0.5% 0px 0px;
}
        .DepartmentDrop {
    float: left;
    width: 18%;
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
              <li class="current">Attendance</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->

     <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/attendance_ic.png" /> <asp:Label ID="lblAttendance" runat="server" Text="Attendance"></asp:Label>
        
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">  
              <div class="FormGroupContent4">
                  <div class="AttendanceCal">
                      <div class="LabelWidth">Attendance Date</div>
                      <div class="FieldInput"><asp:TextBox ID="txtAttendanceDate" runat="server" CssClass="form-control" placeholder="" AutoPostBack="true" ToolTip="Attendance Date" OnTextChanged="txtAttendanceDate_TextChanged"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtAttendanceDate"></asp:CalendarExtender></div>
                      </div>
              </div>
             <div class="FormGroupContent4">
                 
                 <div class="AttendanceComDrop"> 
                     <div class="LabelWidth">Company</div>
                     <div class="FieldInput"><asp:DropDownList ID="ddlCompany" runat="server" data-placeholder="" ToolTip="Company" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged">
                <asp:ListItem Text="Company" Value="0" ></asp:ListItem>
            </asp:DropDownList></div>
                     </div>
                 <div class="AttendanceBraDrop">
                     <div class="LabelWidth">Branch</div>
                     <div class="FieldInput"><asp:DropDownList ID="ddlbranch" runat="server" data-placeholder="" ToolTip="Branch" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlbranch_SelectedIndexChanged">
                 <asp:ListItem Text="Branch" Value="0" ></asp:ListItem>
            </asp:DropDownList></div>
                     </div>
                 <div class="DepartmentDrop"> 
                     <div class="LabelWidth">Department</div>
                     <div class="FieldInput"> <asp:DropDownList ID="ddlDepartment" runat="server" data-placeholder="" ToolTip="Department" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                 <asp:ListItem Value="0" Text="Department" ></asp:ListItem>
            </asp:DropDownList></div>
                     
                    </div>
                                 </div>
             <div class="FormGroupContent4">
                    <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl1" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Do you want to change the job?</b></div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btn_GRD" runat="server" Text="Yes" CssClass="Button" OnClick="btn_GRD_Click" />
            <asp:Button ID="btn_GRD_No" runat="server" Text="No" CssClass="Button" OnClick="btn_GRD_No_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>
              </div>

              <div class="FormGroupContent4">
                   <asp:ModalPopupExtender  ID="PopUpService" runat="server" BackgroundCssClass=""
        PopupControlID="Panel_Service" TargetControlID="Label1" ></asp:ModalPopupExtender>
       <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>
        <div class="div_Break"></div>
        <div class="div_grd">
            <asp:GridView ID="grd" runat="server" Width="100%" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" CssClass="Grid FixedHeader"  OnRowDataBound="grd_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="Code" HeaderText="Code" >
                        <HeaderStyle Wrap="false" Width="50px" />
                        <ItemStyle Width="50px" HorizontalAlign="Right" Wrap="false" />
                        </asp:BoundField >
                    <asp:BoundField DataField="Name" HeaderText="Name" >
                         <HeaderStyle Wrap="false"  Width="300px" />
                        <ItemStyle Width="300px" HorizontalAlign="Right" Wrap="false" />
                        </asp:BoundField >
                    <asp:BoundField DataField="Department" HeaderText="Department" >
                         <HeaderStyle Wrap="false" Width="150px" />
                        <ItemStyle Width="150px" HorizontalAlign="Right" Wrap="false" />
                        </asp:BoundField >
                    <asp:BoundField DataField="Designation" HeaderText="Designation" >
                         <HeaderStyle Wrap="false"  Width="125px" />
                        <ItemStyle Width="125px" HorizontalAlign="Right" Wrap="false" />
                        </asp:BoundField >
                    <asp:BoundField DataField="D.O.J" HeaderText="D.O.J">
                          <HeaderStyle Wrap="false" Width="100px" />
                        <ItemStyle Width="100px" HorizontalAlign="Right" Wrap="false" />
                        </asp:BoundField >
                    <%--<asp:BoundField DataField="FN" HeaderText="FN" >
                        <as
                    </asp:BoundField >--%>
                    <asp:TemplateField  HeaderText="FN"  > 
                        <ItemTemplate >
                            <asp:DropDownList ID="ddlFn" runat="server"  CssClass="chzn-select"  > 
                                <asp:ListItem Value="0">Present</asp:ListItem>
                                 <asp:ListItem Value="1" >Absent</asp:ListItem>
                                 <asp:ListItem Value="2">CL</asp:ListItem>
                                 <asp:ListItem Value="3">SL</asp:ListItem>
                                 <asp:ListItem Value="4">EL</asp:ListItem>
                                <asp:ListItem Value="5">LTA</asp:ListItem>
                                <asp:ListItem Value="6">OD</asp:ListItem>
                                <asp:ListItem Value="7">OFF</asp:ListItem>
                                <asp:ListItem Value="8">LOP</asp:ListItem>
                            </asp:DropDownList>                       
                        </ItemTemplate >
                         <HeaderStyle Wrap="false" Width="100px" />
                        <ItemStyle Width="100px" HorizontalAlign="Right" Wrap="false" />
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="AN" HeaderText="AN" />--%>
                    <asp:TemplateField  HeaderText="AN" > 
                        <ItemTemplate  >
                            <asp:DropDownList ID="ddlAn" runat="server" CssClass="chzn-select" >
                                 <asp:ListItem Value="0">Present</asp:ListItem>
                                 <asp:ListItem Value="1">Absent</asp:ListItem>
                                 <asp:ListItem Value="2">CL</asp:ListItem>
                                 <asp:ListItem Value="3">SL</asp:ListItem>
                                 <asp:ListItem Value="4">EL</asp:ListItem>
                                <asp:ListItem Value="5">LTA</asp:ListItem>
                                <asp:ListItem Value="6">OD</asp:ListItem>
                                <asp:ListItem Value="7">OFF</asp:ListItem>
                                <asp:ListItem Value="8">LOP</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                         <HeaderStyle Wrap="false" Width="100px" />
                        <ItemStyle Width="100px" HorizontalAlign="Right" Wrap="false" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
        </div>
              </div>
              <div class="FormGroupContent4">
                  <div class="right_btn MT0 MB05">
                      <div class="btn ico-update">  <asp:Button ID="btnUpdate" runat="server" ToolTip="Update" OnClick="btnUpdate_Click" /></div>
                  <div class="btn ico-cancel" id="btn_cancel1" runat="server"><asp:Button ID="btnCancel" runat="server" ToolTip="Cancel" OnClick="btnCancel_Click" /></div>
                 </div>
                  
            
              </div>


            </div>
         </div>




    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Attendance #</label>

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
   











   
</asp:Content>
