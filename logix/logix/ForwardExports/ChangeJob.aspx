<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ChangeJob.aspx.cs" Inherits="logix.ForwardExports.ChangeJob" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
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



















    <link href="../Styles/ChangeJob.css" rel="Stylesheet" type="text/css" />

    <%--<script src="../Scripts/Gridviewscroll.js"></script>--%>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js"></script>

    <script type="text/javascript">
        function pageLoad() {

            <%--  $(document).ready(function () {
            $('#<%=grdjobno.ClientID%>').gridviewScroll({
                width: 1003,
                height: 400,
                arrowsize: 30,

                varrowtopimg: "../images/arrowvt.png",
                varrowbottomimg: "../images/arrowvb.png",
                harrowleftimg: "../images/arrowhl.png",
                harrowrightimg: "../images/arrowhr.png"
            });
        });--%>
    <%--    $(document).ready(function () {
            $('#<%=grdAIEJob.ClientID%>').gridviewScroll({
                width: 1003,
                height: 400,
                arrowsize: 30,

                varrowtopimg: "../images/arrowvt.png",
                varrowbottomimg: "../images/arrowvb.png",
                harrowleftimg: "../images/arrowhl.png",
                harrowrightimg: "../images/arrowhr.png"
            });
        });--%>
        }
    </script>
    <script type="text/javascript">
        function ConfirmationBox() {
            var result = confirm('Do you want to change the job?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <style type="text/css">
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
        div#logix_CPH_Panel4 {
    margin: 0px 0px 0px -13px;
}
  
        div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <asp:HiddenField ID="hid_confirm" runat="server" />

  
    <!-- /Breadcrumbs line -->
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                   <div style="float: left; margin: 0px 0.5% 0px 0px;"> <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="Label2" runat="server" Text="ChangeJob"></asp:Label>
                    </h4>
                         <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li style="display:none"><i class="icon-home"></i><a href="#"></a>Home </li>           
            <li style="display:none"><a href="#" title="">Documentation</a> </li>
             <li style="display:none"><a href="#" title="" id="HeaderLabel1" runat="server">Ocean Exports</a> </li>
            <li class="current"><a href="#" title="">Change Job</a> </li>
        </ul>
    </div>
                   </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" ><asp:LinkButton ID="logdetails" runat="server" ToolTip="Log"  Style="text-decoration: none" OnClick="logdetails_Click" ></asp:LinkButton></div>
                </div>
                <div class="widget-content">
                    <div class="FixedButtons">
                         <div class="right_btn ">
                            <div class="btn ico-Select-Destination-Job">
                                <asp:Button ID="btnDestJob" runat="server" Text="Select Destination Job #" ToolTip="Select Destination Job #" OnClick="btnDestJob_Click" />
                            </div>
                            <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                <asp:Button ID="btnCancel" runat="server"  Text="Cancel" ToolTip="Cancel/Back" OnClick="btnCancel_Click" />
                            </div>

                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <asp:Panel ID="Panel1" runat="server" CssClass="gridpnl">
                            <asp:GridView ID="grdBL" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" Width="100%" PageSize="15" AllowPaging="false"
                                OnSelectedIndexChanged="grdBL_SelectedIndexChanged" OnPageIndexChanging="Grd_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="jobno" HeaderText="Cur Job" />
                                    <asp:BoundField DataField="blno" HeaderText="BL #" />
                                    <asp:BoundField DataField="bldate" HeaderText="BL Date" />
                                    <asp:BoundField DataField="consignee" HeaderText="Consignee" />
                                    <asp:TemplateField HeaderText="Select BL">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbSelect" runat="server" AutoPostBack="true"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle CssClass="GrdRow" />
                            </asp:GridView>
                            <div class="div_Break "></div>
                            <asp:GridView ID="grdjobno" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" Width="100%" PageSize="15" AllowPaging="false" OnSelectedIndexChanged="grdjobno_SelectedIndexChanged" OnPageIndexChanging="grdjobno_PageIndexChanging" OnRowDataBound="grdjobno_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="jobno" HeaderText="Job #">
                                        <HeaderStyle Wrap="true" Width="50px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="JobType" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 50px">
                                                <asp:Label ID="jobtype" runat="server" Text='<%# Bind("jobtype") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="50px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Vessel" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                <asp:Label ID="vessel" runat="server" Text='<%# Bind("vessel") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="eta" HeaderText="ETA">
                                        <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="60px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="etb" HeaderText="ETD">
                                        <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="60px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="mblno" HeaderText="MBL #">
                                        <HeaderStyle Wrap="true" Width="70px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="70px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Agent" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 130px">
                                                <asp:Label ID="agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="130px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="MLO" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 130px">
                                                <asp:Label ID="mlo" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="130px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="pol" HeaderText="P O L">
                                        <HeaderStyle Wrap="true" Width="50px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="pod" HeaderText="P O D">
                                        <HeaderStyle Wrap="true" Width="50px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>

                                </Columns>

                                <AlternatingRowStyle CssClass="GrdRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <RowStyle CssClass="GridviewScrollItem" />
                                <PagerStyle CssClass="GridviewScrollPager" />
                            </asp:GridView>

                            <div class="div_Break "></div>
                            <asp:GridView ID="grdAIEJob" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" AllowPaging="false" Width="100%" PageSize="15" OnRowDataBound="grdAIEJob_RowDataBound" OnSelectedIndexChanged="grdAIEJob_SelectedIndexChanged" OnPageIndexChanging="grdAIEJob_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                    <asp:BoundField DataField="flightno" HeaderText="Flight #" />
                                    <asp:BoundField DataField="eta" HeaderText="Flight Date" />
                                    <asp:BoundField DataField="mawblno" HeaderText="MAWBL #" />
                                    <asp:TemplateField HeaderText="AirLine" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 200px">
                                                <asp:Label ID="airline" runat="server" Text='<%# Bind("airline") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="10px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="airline" HeaderText="AirLine" />--%>
                                    <asp:TemplateField HeaderText="Agent" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                                <asp:Label ID="agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="10px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="agent" HeaderText="Agent" />--%>
                                    <asp:BoundField DataField="pol" HeaderText="From Port" />
                                    <asp:BoundField DataField="pod" HeaderText="To Port" />
                                </Columns>
                                <%-- <AlternatingRowStyle CssClass="GrdRowStyle" /> 
                <HeaderStyle CssClass="GridviewScrollHeader" /> 
            <RowStyle CssClass="GridviewScrollItem" /> --%>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle CssClass="GrdRow" />
                                <PagerStyle CssClass="GridviewScrollPager" />
                            </asp:GridView>
                            <div class="div_Break "></div>
                        </asp:Panel>

                    </div>
                     
                    <div class="FormGroupContent4">

                        <%-- <asp:Panel ID="pnl_msg1" runat="server">
          
                        <asp:Label ID="lbl_msg1" runat="server" Text="Do you want to change the job ?"></asp:Label>
                  
                     
                            <asp:Button ID="btn_yes1" runat="server" CssClass="btn" Text="Yes" Width="32%" 
                                 />
                            <asp:Button ID="btn_no1" runat="server" CssClass="btn"  Text="No" Width="32%"  
                                />
                     
        </asp:Panel>
      <asp:ModalPopupExtender ID="mdl_msg1" runat="server" BackgroundCssClass="modalBackground" CancelControlID=""
        PopupControlID="pnl_msg1" TargetControlID="hf_msg1">
        </asp:ModalPopupExtender>
       <asp:HiddenField ID="hf_msg1" runat="server" />--%>









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
                    <div class="FormGroupContent">
                    </div>
                </div>
            </div>
        </div>
    </div>



      <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Job # :</label>

                                </div>
                                <div class="LogHeadJobInput">

                                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                                </div>

                            </div>
                            <div class="DivSecPanel">
                                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>

                            <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">

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

       <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

    <asp:ModalPopupExtender ID="PopUpService" runat="server" BackgroundCssClass=""
        PopupControlID="Panel_Service" TargetControlID="Label1">
    </asp:ModalPopupExtender>
    <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>
    <div class="div_Break"></div>
    <asp:HiddenField ID="hfbranchid" runat="server" />
    <asp:HiddenField ID="hfdivisionid" runat="server" />
    <asp:HiddenField ID="hfhidid1" runat="server" />
    <asp:HiddenField ID="hfdisjobno" runat="server" />
    <asp:HiddenField ID="hfsourcejobno" runat="server" />
    <asp:HiddenField ID="hfDCjobno" runat="server" />
    <asp:HiddenField ID="hfCCjobno" runat="server" />
    <asp:HiddenField ID="hfintdnno" runat="server" />
    <asp:HiddenField ID="hfdnno" runat="server" />
    <asp:HiddenField ID="hfblndest" runat="server" />
    <asp:HiddenField ID="hfintresult" runat="server" />

</asp:Content>
