<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="true" CodeBehind="Salary Revision.aspx.cs" Inherits="logix.HRM.Salary_Revision" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
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
    <script type="text/javascript">
        function TxtFocus() {

            var el = $("#<%=txtCompany.ClientID %>").get(0);
            var elemLen = el.value.length;
            el.selectionStart = elemLen;
            el.selectionEnd = elemLen;
            el.focus();

            var el1 = $("#<%=txtBranch.ClientID %>").get(0);
            var elemLen1 = el1.value.length;
            el1.selectionStart = elemLen1;
            el1.selectionEnd = elemLen1;
            el1.focus();

            var el2 = $("#<%=txtGrade.ClientID %>").get(0);
            var elemLen2 = el2.value.length;
            el2.selectionStart = elemLen2;
            el2.selectionEnd = elemLen2;
            el2.focus();

        }

        function GetDetail() {
            $.ajax({
                type: "POST",
                url: "../HRM/Salary Revision.aspx/GetCompanyName",
                data: '{ Prefix: "' + $("#<%=txtCompany.ClientID %>").val() + '",Prefix1:"' + $("#<%=txtBranch.ClientID %>").val() + '",Prefix2:"' + $("#<%=txtGrade.ClientID %>").val() + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    //alertify.alert(response.d);
                }
            });
        }

        function OnSuccess(response) {
            $("#<%=btn_search.ClientID %>").click();
         }

    </script>



    <link href="../Styles/Salary%20Revision.css" rel="stylesheet" />
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
        .hide {
            display: none;
        }

        modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .modalPopupss {
            background-color: #FFFFFF;
            /*border-width:1px;*/
            border-style: solid;
            border-color: #CCCCCC;
            width: 1042px;
            Height: 555px;
            margin-left: -2%;
            margin-top: -2.5%;
            /*padding:1px;            
            display:none;*/
        }

        .Gridpnl {
            width: 1024px;
            Height: 560px;
        }

        .Pnl1 {
            padding: 15px 15px 15px 15px;
            background-color: #dbdbdb;
            border: 1px solid #b1b1b1;
        }

        #logix_CPH_Panel_Service {
            left: 350px !important;
            top: 220px !important;
            text-align: center;
        }
        .RevisionCal1 {
    float: left;
    margin: 0 0.5% 0 0;
    width: 6%;
}
        .RevisionComp {
    width: 27%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .RevisionBranch {
    width: 14%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .RevisionCode {
    width: 10%;
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

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
            <li><a href="#" title="">HRM</a> </li>
            <li class="current">Salary Revision</li>
        </ul>
    </div>
    <!-- Breadcrumbs line End -->

    

        <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/salaryrevision_ic.png" /> <asp:Label ID="lblsalaryRevision" runat="server" Text="Salary Revision"></asp:Label>
        
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg"> 
             <div class="FormGroupContent4">
                        <div class="RevisionCal1">
                            <div class="LabelWidth">From</div>
                            <div class="FieldInput"><asp:TextBox ID="txtfrom" runat="server" placeholder="" ToolTip="From" CssClass="form-control"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtfrom"></asp:CalendarExtender></div>
                            
                        </div>
                        <div class="RevisionCal1">
                            <div class="LabelWidth">To</div>
                            <div class="FieldInput"><asp:TextBox ID="txtTo" runat="server" placeholder="" ToolTip="To" CssClass="form-control"></asp:TextBox></div>
                            

                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtTo"></asp:CalendarExtender>
                        </div>
                        <div class="right_btn MTCtrl6">
                            <div class="btn ico-get">
                                <asp:Button ID="btnGet" runat="server" ToolTip="Get" OnClick="btnGet_Click" />
                            </div>
                            <div class="btn ico-clear">
                                <asp:Button ID="btnClear" runat="server" ToolTip="Clear" OnClick="btnClear_Click" />
                            </div>
                        </div>
                    </div>
                    
            <div class="FormGroupContent4">
                        <div class="RevisionComp">
                            <div class="LabelWidth">Company</div>
                            <div class="FieldInput"><asp:TextBox ID="txtCompany" runat="server" placeholder="" ToolTip="Company" onkeyup="GetDetail();" CssClass="form-control"></asp:TextBox></div>
                            
                        </div>
                        <div class="RevisionBranch">
                            <div class="LabelWidth">Branch</div>
                            <div class="FieldInput"><asp:TextBox ID="txtBranch" runat="server" placeholder="" ToolTip="Branch" onkeyup="GetDetail();" AutoPostBack="true" CssClass="form-control"></asp:TextBox></div>
                            
                        </div>
                        <div class="RevisionCode">
                            <div class="LabelWidth">Grade</div>
                            <div class="FieldInput"><asp:TextBox ID="txtGrade" runat="server" placeholder="" ToolTip="Grade" onkeyup="GetDetail();" AutoPostBack="true" CssClass="form-control"></asp:TextBox></div>
                            
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="right_btn MT0 MB05">
                            <div class="btn ico-update" id="btnSave1" runat="server">
                                <asp:Button ID="btnSave" runat="server" ToolTip="Update" OnClick="btnSave_Click" />
                            </div>
                            <div class="btn ico-view">
                                <asp:Button ID="btnView" runat="server" ToolTip="View" OnClick="btnView_Click" />
                            </div>
                            <div class="btn ico-cancel" id="btnCancel1" runat="server">
                                <asp:Button ID="btnCancel" runat="server" ToolTip="Cancel" OnClick="btnCancel_Click" />
                               
                            </div>
                             <div><asp:Button ID="btn_search" runat="server" ToolTip="" Style="display: none;" OnClick="btn_search_Click" /></div>
                        </div>
                    </div>
            <div class="FormGroupContent4">
                    <asp:Panel runat="server" ScrollBars="Vertical" class="div_grd">
                        <asp:GridView ID="grd" runat="server" CssClass="NewThemeTbl" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" Width="100%"
                            OnPageIndexChanging="grd_PageIndexChanging" OnRowDataBound="grd_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="employeeid" HeaderText="Employeeid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                <asp:BoundField DataField="empcode" HeaderText="Code">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" Width="52px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="empname" HeaderText="Name">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" Width="180px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="gross" HeaderText="Gross" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" Width="52px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="grade" HeaderText="Grade">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" Width="52px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Proposed Grade">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="pgrade" runat="server" CssClass="chzn-select"  data-placeholder="Proposed Grade">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                            <asp:ListItem>C1</asp:ListItem>
                                            <asp:ListItem>C2</asp:ListItem>
                                            <asp:ListItem>E1</asp:ListItem>
                                            <asp:ListItem>E2</asp:ListItem>
                                            <asp:ListItem>E3</asp:ListItem>
                                            <asp:ListItem>M</asp:ListItem>
                                            <asp:ListItem>M1A</asp:ListItem>
                                            <asp:ListItem>M1B</asp:ListItem>
                                            <asp:ListItem>M2</asp:ListItem>
                                            <asp:ListItem>M3</asp:ListItem>
                                            <asp:ListItem>M4</asp:ListItem>
                                            <asp:ListItem>M5</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="false"  Width="20%" />
                                    <ItemStyle Wrap="false" Width="20%"></ItemStyle>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="incentive" HeaderText="Increment" />--%>
                                <%--Text='<%#Bind("txtIncrement") %>' AutoPostBack="true"--%>
                                <asp:TemplateField HeaderText="Increment" ItemStyle-CssClass="TxtAlign1">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtIncrement" BorderColor="#999997" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="false"  />
                                    <ItemStyle Wrap="false" Width="20%" />

                                </asp:TemplateField>
                                <asp:BoundField DataField="divisname" HeaderText="Division" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                <asp:BoundField DataField="branchname" HeaderText="Branch" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="GridHeader" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                    </asp:Panel>

                </div>
            </div>
            
            </div>




    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">
                <div class="widget-header">
                    <h4><i class="icon-umbrella"></i>
                        </h4>
                </div>
                <div class="widget-content">
                   

                </div>
                
            </div>
        </div>
    </div>





    <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl1" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Its not Financial Year, Do You Want to Process ?</b></div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btn_yes" runat="server" Text="OK" CssClass="Button" OnClick="btn_yes_Click" />
            <asp:Button ID="btn_no" runat="server" Text="Cancel" CssClass="Button" OnClick="btn_no_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>

    <asp:ModalPopupExtender ID="PopUpService" runat="server" BackgroundCssClass=""
        PopupControlID="Panel_Service" TargetControlID="Label1">
    </asp:ModalPopupExtender>
    <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>


    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Salary Revision #</label>

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

    <asp:HiddenField ID="hid_confirm" runat="server" />
</asp:Content>
