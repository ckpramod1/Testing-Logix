<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Journal.aspx.cs" Inherits="logix.FAForm.Journal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link rel="Stylesheet" href="../Styles/MasterGroup.css" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> <link href="../Theme/assets/css/system.css" rel="stylesheet" />

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <link href="../CSS/Finance.css" rel="stylesheet" />
    <!-- App -->
    
    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
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

    <link href="../Styles/journal.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).keydown(function (e) {

            if (e.keyCode == 27) {

                $("#<%=btncancel.ClientID%>").click();

            }
        });

    </script>
    <style type="text/css">
        .JournalDate {
            float: right;
            width: 7%;
            margin: 0px 0% 0px 0px;
        }

        .Grid2 {
            border: 1px solid #b1b1b1;
            height: 306px;
            margin: 0;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

        .TotalJInput1 {
            float: right;
            width: 118px;
            margin: 0px 0.5% 0px 0px;
        }

        .TotalJInput {
            float: right;
            width: 118px;
            margin: 0px 8px 0px 0px;
        }

        .JouJobNo {
            float: left;
            width: 7%;
            margin: 0px 0.5% 0px 0px;
        }

        body {
            overflow: hidden;
        }

        .row {
            height: 580px !important;
            /* margin: 0px 5px 0px -15px; */
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

        .JournalTxt {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TotalJLBL {
            float: right;
            width: 2%;
            margin: 6px 0.5% 0px 0px;
        }

        /*CSS*/

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
            margin-left: 0% !important;
            margin-top: -16.9% !important;
            overflow: auto;
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
            width: 65%;
            float: left;
            margin: 2px 0px 3px 4px;
        }

            .LogHeadLbl label {
                color: #af2b1a;
                font-weight: bold;
                font-size: 11px;
            }

        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
            white-space: nowrap;
        }

        .LogHeadJobInput label {
            font-size: 11px;
        }

        .LogHeadJobInput {
            width: 15%;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 11px;
                margin: 4px 0px 0px 0px;
            }

            .LogHeadJobInput label {
                font-size: 11px;
                font-family: sans-serif;
                color: #4e4e4c;
            }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            color: #000080;
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .widget.box{
    position: relative;
    top: -8px;
}
.JouReference {
    float: left;
    width: 12%;
    margin: 0px 0% 0px 0px;
}
form#form1 {
    width: 100%;
}
.widget.box .widget-content {
    top: 0px !important;
    padding-top: 50px !important;
}
 .TotalJInput1.TextField span,.TotalJInput.TextField span {
    text-align: right;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div>
        <div class="col-md-12  maindiv">
            <div class="widget box " runat="server">
                <div class="widget-header">
                    <div>
                    <h4><i class="icon-umbrella"></i>
                        <asp:Label ID="lblheader" runat="server"></asp:Label></h4>
                   <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#">Home</a> </li>
            <li><a href="#">Vouchers</a> </li>
            <li><a href="#" title="">Journal</a> </li>
            <li>
                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>


                    <div class="FixedButtons" >
      <div class="right_btn">
        <div class="btn ico-delete" id="btndelete1" runat="server">
            <asp:Button ID="btndelete" runat="server" Text="Delete" ToolTip="Delete" OnClick="btndelete_Click" />
        </div>
        <div class="btn ico-view">
            <asp:Button ID="btnview" runat="server" Text="View" ToolTip="View" OnClick="btnview_Click" Enabled="false"/>
        </div>
        <div class="btn ico-cancel" id="btncancel1" runat="server">
            <asp:Button ID="btncancel" runat="server"  Text="Cancel" ToolTip="Cancel" OnClick="btncancel_Click" />
        </div>
    </div>
</div>

                </div>

                <div class="widget-content">
                    
                    <div class="FormGroupContent4 boxmodal">
                        <div class="JournalTxt">
                            <asp:Label ID="lbljnlno" runat="server" Text="Journal #"></asp:Label>
                            <asp:TextBox ID="txtjnlno" runat="server" AutoPostBack="true" CssClass="form-control" ToolTip="Journal #" placeholder="" OnTextChanged="txtjnlno_TextChanged"></asp:TextBox>
                        </div>

                        <div class="JournalDate DateR">
                            <asp:Label ID="Label3" runat="server" Text="Date"> </asp:Label>
                            <asp:TextBox ID="txtdate" runat="server" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtdate_TextChanged" TabIndex="1"></asp:TextBox>
                        </div>

                        <div class="JouJobNo">
                            <asp:Label ID="Label2" runat="server" Text="Job #"></asp:Label>
                            <asp:TextBox ID="txtjobno" CssClass="form-control" ToolTip="Job #" placeholder="" runat="server" TabIndex="10"></asp:TextBox>
                        </div>
                        <div class="JouReference">

                            <asp:Label ID="lblref" runat="server" Text="Referance #"></asp:Label>
                            <asp:TextBox ID="txtref" runat="server" CssClass="form-control" ToolTip="Ref. #" placeholder="" TabIndex="11"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">

                    <div class="FormGroupContent4">
                        <asp:Panel ID="Panel2" runat="server" CssClass="gridpnl" ScrollBars="Auto">
                            <asp:GridView ID="grd_journal" runat="server" CssClass="Grid FixedHeader" Width="100%" AutoGenerateColumns="False"
                                OnSelectedIndexChanged="grd_journal_SelectedIndexChanged" OnRowDataBound="grd_journal_RowDataBound" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found" OnPreRender="grd_journal_PreRender"    >
                                <Columns>
                                    <asp:BoundField DataField="ledgertype">
                                        <HeaderStyle Width="100px"  />
                                        <ItemStyle  Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ledgername" HeaderText="Ledger">
                                        <HeaderStyle  />
                                        <ItemStyle  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Debit" HeaderText="Debit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px" ></asp:BoundField>
                                    <asp:BoundField DataField="Credit" HeaderText="Credit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" HeaderStyle-Width="150px" ItemStyle-Width="150px" >
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField DataField="vousubid" HeaderText="Vousubid" />
                <asp:BoundField DataField="opstype" HeaderText="Opstype" />
                <asp:BoundField DataField="ledgerid" HeaderText="Ledgerid" />
                  <asp:TemplateField>
                    <ItemTemplate>                        
                        <asp:LinkButton ID="link_Contra" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                    </ItemTemplate>                    
                    <ItemStyle Width="2%" />
                </asp:TemplateField>--%>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>                        
                    </div>
                    <div class="FormGroupContent4">
                        <div class="btnctrl1">
                            <div class="TotalJInput">
                                <asp:Label ID="Label5" runat="server" CssClass="hide"  Text="Cr Amount"> </asp:Label>
                                <asp:TextBox ID="txtCrAmnt" runat="server" TabIndex="8" CssClass="form-control" ToolTip="Credit Amount" Placeholder="" Style="text-align: right"></asp:TextBox>

                            </div>
                            <div class="TotalJInput1">
                                <asp:Label ID="Label6" runat="server" CssClass="hide" Text="Dr Amount"> </asp:Label>
                                <asp:TextBox ID="txtDbtAmnt" runat="server" TabIndex="7" CssClass="form-control" ToolTip="Debit Amount" placeholder="" Style="text-align: right"></asp:TextBox>

                            </div>
                            <div class="TotalJLBL hide">
                                <asp:Label ID="Label1" runat="server" Text="Total"></asp:Label>

                            </div>
                        </div>

                    </div>
                        </div>

                    <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4">

                        <asp:Label ID="lblnarration" runat="server" Text="Narration"></asp:Label>
                        <asp:TextBox ID="txtnarration" runat="server" TabIndex="9" CssClass="form-control" ToolTip="Narration" placeholder=""></asp:TextBox>
                        </div>
                    </div>

                    <div class="FormGroupContent4">
                        <asp:Label ID="lbl_name" runat="server" Text="Name" CssClass="hide"></asp:Label>
                   
                      
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Jnl_jnltxt">
                            <asp:TextBox ID="txtmonth" runat="server" Visible="False"></asp:TextBox>
                        </div>
                        <div class="Jnl_jnltxt">
                            <asp:TextBox ID="txtvouyear" runat="server" Visible="False"></asp:TextBox>
                        </div>
                        <div class="Jnl_jnltxt">
                            <asp:TextBox ID="ttdate" runat="server" Visible="False"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <asp:HiddenField ID="hf_Date" runat="server" />
    <asp:HiddenField ID="txtmont" runat="server" />
    <asp:CalendarExtender ID="ce_voudate1" runat="server" TargetControlID="txtdate" Format="dd/MM/yyyy"></asp:CalendarExtender>
    <div class="Jnl_break"></div>

    <asp:HiddenField ID="hf_flag" runat="server" />
    <asp:HiddenField ID="hf_vid" runat="server" />
    <asp:HiddenField ID="hidfdate" runat="server" />
    <asp:HiddenField ID="hidvoutype" runat="server" />
    <asp:HiddenField ID="hidtdate" runat="server" />
    <asp:HiddenField ID="hid_PBranchID" runat="server" />
    <asp:HiddenField ID="hid_VouID" runat="server" />
    <asp:HiddenField ID="hid_Vouyear" runat="server" />
    <asp:HiddenField ID="hid_BranchID" runat="server" />

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Journal #</label>

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

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

</asp:Content>
