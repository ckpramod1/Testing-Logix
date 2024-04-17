<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="LWFGrade.aspx.cs" Inherits="logix.HRM.LWFGrade" %>

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












    <link href="../Styles/LWFGrade.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txt_Branch.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_bid.ClientID %>").val(0);
                        $("#<%=hid_portid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/Get_GradeBranch",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        port: item.split('~')[2]

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

                        $("#<%=hid_bid.ClientID %>").val(i.item.val);
                        $("#<%=hid_portid.ClientID %>").val(i.item.port);
                        $("#<%=txt_Branch.ClientID %>").change();

                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=hid_bid.ClientID %>").val(i.item.val);
                            $("#<%=hid_portid.ClientID %>").val(i.item.port);
                            $("#<%=txt_Branch.ClientID %>").val(i.item.label);
                        }
                        else {
                            $("#<%=hid_bid.ClientID %>").val(0);
                        }
                    },
                    focus: function (e, i) {
                        $("#<%=hid_bid.ClientID %>").val(i.item.val);
                        $("#<%=hid_portid.ClientID %>").val(i.item.port);
                        $("#<%=txt_Branch.ClientID %>").val(i.item.label);
                    },
                    close: function (e, i) {
                        if (i.item) {
                            $("#<%=hid_bid.ClientID %>").val(i.item.val);
                            $("#<%=hid_portid.ClientID %>").val(i.item.port);
                            $("#<%=txt_Branch.ClientID %>").val(i.item.label);
                        }
                    },
                    minLength: 1
                });

                $("#<%=txt_Grade.ClientID %>").autocomplete({
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
                        $("#<%=txt_Grade.ClientID %>").val(i.item.label);
                    },
                    minLength: 1
                });
            });
        }
    </script>
    <style type="text/css">
        .toUpper {
            text-transform: uppercase;
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
            <li><a href="#" title="">IT Workings</a> </li>
            <li class="current"><a href="#" title="" id="HeaderLabel" runat="server">LWF Grade </a></li>
        </ul>
    </div>
    <!-- Breadcrumbs line End -->

      <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/lwfgrade_ic.png" /><asp:Label ID="lbl_Header" runat="server" Text="LWF Grade"></asp:Label>
       
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">
             <div class="FormGroupContent4">
                        <div class="LwfBranch">
                            <div class="LabelWidth">Branch</div>
                            <div class="FieldInput"><asp:TextBox ID="txt_Branch" TabIndex="1" runat="server" AutoPostBack="True" OnTextChanged="txt_Branch_TextChanged" CssClass="form-control" placeholder="" ToolTip="Branch"></asp:TextBox></div>
                            
                        </div>
                        <div class="Lwfgrade">
                            <div class="LabelWidth">Grade</div>
                            <div class="FieldInput"><asp:TextBox ID="txt_Grade" TabIndex="2" runat="server" CssClass="form-control" placeholder="" ToolTip="Grade"></asp:TextBox></div>
                            </div>

                    </div>
                    <div class="bordertopNew"></div>
                    <div class="FormGroupContent4">
                        <div class="right_btn MT0 MB05">
                            <div class="btn ico-save" id="btn_save1" runat="server">
                                <asp:Button ID="btn_Save" TabIndex="3" runat="server" ToolTip="Save" OnClick="btn_Save_Click" /></div>
                            <div class="btn ico-view">
                                <asp:Button ID="btn_view" TabIndex="4" runat="server" ToolTip="View" OnClick="btn_view_Click" /></div>
                            <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                <asp:Button ID="btn_Clear" TabIndex="5" runat="server" ToolTip="Cancel" OnClick="btn_Clear_Click" /></div>
                        </div>
                    </div>
                    <div class="bordertopNew"></div>
            <div class="FormGroupContent4">
                        <div class="div_Grid">
                            <asp:GridView ID="Grd_LWF" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl"
                                Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="True" OnRowDataBound="Grd_LWF_RowDataBound"
                                DataKeyNames="lgid" OnSelectedIndexChanged="Grd_LWF_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Branch">
                                        <ItemTemplate>
                                            <div class="div_BranchColumn">
                                                <asp:Label ID="lbl" runat="server" Text='<%# Bind("branch")%>' ToolTip='<%# Bind("branch")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="portname" HeaderText="Location" />
                                    <asp:BoundField DataField="grade" HeaderText="Grade">
                                        <ItemStyle CssClass="toUpper" />
                                     </asp:BoundField >
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

     <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>LWF Grade #</label>

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



    <asp:HiddenField ID="hid" runat="server" />
    <asp:HiddenField ID="hid_bid" runat="server" />
    <asp:HiddenField ID="hid_portid" runat="server" />
    <asp:HiddenField ID="hid_Lg" runat="server" />
    <asp:HiddenField ID="hid_confirm" runat="server" />
</asp:Content>
