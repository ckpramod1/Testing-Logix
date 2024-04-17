<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ChequeRequestApproval.aspx.cs"
    Inherits="logix.FAForm.ChequeRequestApproval" %>

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
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <!--=== JavaScript ===-->

    <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <%--    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>--%>
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

    <link href="../Styles/CreditRequestApproval.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>

    <style type="text/css">
        /*.modalBackground { 
            background-color:#333333; 
            filter:alpha(opacity=70); 
            opacity:0.7; 
        }*/
        .DivSecPanel {
            width: 20px;
            Height: 20px;
            /*border:2px solid white;*/
            margin-left: 98.3%;
            margin-top: -1.5%;
            border-radius: 90px 90px 90px 90px;
        }

        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }
        .PandingPay {
    width: 1.5%;
    float: right;
    margin: 0px;
    text-align: right;
}
        .hide {
            display: none;
        }


        #logix_CPH_popup_favour_foregroundElement {
            top: 240px !important;
            width: 650px !important;
            left: 344px !important;
        }

        #logix_CPH_popup_cheque_foregroundElement {
            top: 45px !important;
        }

        .div_close {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98%;
            margin-top: -4%;
            /* margin-top: -7.5%; */
            border-radius: 90px 90px 90px 90px;
        }

        .GridC {
            width: 100%;
            border: 1px solid #b1b1b1;
            height: 315px;
            margin: 0px 0px 0px 0px;
            overflow-x: hidden !important;
            overflow-y: auto !important;
        }

        .div_close img {
            height: 5%;
            width: 5%;
            float: right;
        }

        .Pnlfav {
            width: 86% !important;
            height: 150px !important;
        }

        .CompanyBranch1 {
            float: left;
            margin: 0 0.5% 0 0;
            width: 8%;
        }

        .CreditNoteOper {
            width: 14%;
            float: left;
            margin: 5px 0.5% 0px 0px;
        }

        .TotalLabel2 {
            width: fit-content;
            float: left;
            margin: 16px 0.5% 0px 692px;
        }

        #logix_CPH_pln_Grg_foregroundElement {
            left: 3px !important;
            top: 54px !important;
        }

        #logix_CPH_pln_cheque {
            top: 69px !important;
        }

        .MBLCost {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .frames {
            width: 100%;
            Height: 481px;
        }

        .MTRct {
            margin-top: 10px !important;
            margin-right: 15px !important;
        }

        .row {
            clear: both;
            width: 100%;
            height: 587px !important;
            overflow-x: hidden;
            overflow-y: auto;
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
            .CreditNoteOper label {
    display: inline-block;
    float: left;
    width: 140px !important;
    margin: 3px 5px 5px;
}
            .CreditNoteRad label {
    display: inline-block;
    margin: 3px 5px 5px!important;
}
            .CHKRApproval label {
    width: 140px !important;
    margin: 3px 5px 5px!important;
}
            .CHKRApproval {
    width: 19%;
    float: left;
    margin: 5px 0.5% 0px 0px;
}
         
            .ApproveCal {
    width: 8%;
    position: relative;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        
            .Approvetxt {
    width: 5.5%;
    float: left;
    margin: 20px 0.5% 0px 0px;
}
            .widget.box{
    position: relative;
    top: -8px;
}
.chzn-disabled {
    opacity: 1 !important;
}
.CreditNoteRad {
    width: 12%;
    float: left;
    margin-top: 5px;
}
.gridpnl {
    /*height: calc(100vh - 263px);*/
    overflow: auto;
}
 div#logix_CPH_ddl_Sorting_chzn {
    width: 100% !important;
}
.widget.box .widget-content {
    top: 0px !important;
    padding-top: 60px !important;
}
 .div_lbl_remark {
    width: 71%;
    float: left;
    margin-left: 0px;
    margin-top: 0.5%;
}
    </style>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {

            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>

    <%--<script type="text/javascript" language="javascript">
        xAddEventListener(window, 'load',
       function () { new xTableHeaderFixed('gvTheGrid', 'table-container', 0); }, false);

        function TxtFocus() {
            var el = $("#<%=txt_Search.ClientID %>").get(0);
              var elemLen = el.value.length;
              el.selectionStart = elemLen;
              el.selectionEnd = elemLen;
              el.focus();
          }

          function GetDetail() {
              $.ajax({
                  type: "POST",
                  url: "ChequeRequestApproval.aspx/GetVouNo",
                  data: '{Prefix: "' + $("#<%=txt_Search.ClientID %>").val() + '" }',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: OnSuccess,
                 failure: function (response)
                 {
                     //alertify.alert(response.d);
                 }
             });
         }

        function OnSuccess(response) {
             $("#<%=btn_search.ClientID %>").click();
            }

         </script>--%>

    <style type="text/css">
  
        .Gridpnl {
    width: 99% !important;
    height: 85% !important;
    border: 1px solid var(--lightgrey) !important;
    margin: 0 auto !important;
    overflow-y: scroll !important;
    overflow-x: auto !important;
}
        .Appamount {
            width: 9%;
            float: left;
            margin: 0px 0.1% 0px 0px;
        }

        .AppAmount1 {
            width: 9%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

      

        .FormGroupContent4 label {
            /*color: #000080;*/
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        div#logix_CPH_ddl_company_chzn, div#logix_CPH_ddl_branch_chzn {
    opacity: 1 !important;
}
      
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <!-- Breadcrumbs line -->
    <%-- <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
             <li><a href="#" id="labelid" runat="server"></a></li>
              <li><a href="#" title="">Approval</a> </li>
              <li class="current"><a href="#" title="">Cheque Request Approval</a> </li>
            </ul>
      </div>--%>
    <!-- /Breadcrumbs line -->

       <!-- Breadcrumbs line -->
  
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">

                <div class="widget-header">
                    <div>
                    <h4><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text="Cheque Request Approval"></asp:Label></h4>
                      <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">Approval</a> </li>
            <li><a href="#" title="">Payment Request Approval </a></li>
            <li>
                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>

        </ul>
    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                    <div class="FixedButtons" >
       <div class="left_btn">
        
        <div class="btn ico-approved-items-list">
            <asp:Button ID="btn_approve" runat="server" Text="Approved List" ToolTip="Approved List" OnClick="btn_approve_Click" />
        </div>
        <div class="btn ico-decline">
            <asp:Button ID="btn_decline" runat="server" Text="Decline" ToolTip="Decline" OnClick="btn_decline_Click" />
        </div>
    </div>
    <div class="right_btn">
        <div class="btn ico-update">
            <asp:Button ID="btn_update" runat="server" Text="Update" ToolTip="Update" OnClick="btn_update_Click" />
        </div>
        <div class="btn ico-print">
            <asp:Button ID="btn_print" runat="server" Text="Print" ToolTip="Print" OnClick="btn_print_Click" />
        </div>

        <div class="btn ico-excel">
            <asp:Button ID="btn_export1" runat="server" Text="Export To Excel" ToolTip="Export To Excel" OnClick="btn_export1_Click" />
        </div>

        <div class="btn ico-cancel" id="btn_back1" runat="server">
            <asp:Button ID="btn_back" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_back_Click" />
        </div>
    </div> 
</div>
                </div>
                <div class="widget-content">
                    
                    <div class="FormGroupContent4 boxmodal">

                        <div class="CreditNoteOper">
                            <asp:RadioButton ID="rbt_CNOP" runat="server" AutoPostBack="True" GroupName="rbt" OnCheckedChanged="rbt_CNOP_CheckedChanged" /><label>Purchase Invoice</label>
                        </div>
                        <div class="CreditNoteRad">
                            <asp:RadioButton ID="rbt_CN" runat="server" AutoPostBack="True" GroupName="rbt" OnCheckedChanged="rbt_CN_CheckedChanged" /><label>Credit Note</label>
                        </div>
                        <div class="CHKRApproval" id="div_radiobtn" runat="server">
                            <asp:RadioButton ID="rbt_CNAdmin" runat="server" AutoPostBack="True" GroupName="rbt" Text="Admin Purchase Invoice" OnCheckedChanged="rbt_CNAdmin_CheckedChanged" />
                        </div>
                        <div class="PandingPay">
                            <asp:LinkButton ID="Lnk_Pending" runat="server" ForeColor="Red" OnClick="Lnk_Pending_Click" CssClass="anc ico-find-sm"></asp:LinkButton>
                        </div>
                        <div class="TDSLabel" style="display: none;">
                            <asp:Label ID="lbl_tds" runat="server" Text="TDS" CssClass="LabelValue"></asp:Label>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="CompanyList">
                            <asp:Label ID="Label7" runat="server" Text="Company"> </asp:Label>
                            <asp:DropDownList ID="ddl_company" Height="23" runat="server" CssClass="chzn-select" ToolTip="Company" Placeholder="Company">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="CompanyBranch1">
                            <asp:Label ID="Label8" runat="server" Text="Branch"> </asp:Label>
                            <asp:DropDownList ID="ddl_branch" Height="23" runat="server" CssClass="chzn-select" AutoPostBack="true" ToolTip="Branch" Placeholder="Branch" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="CompanyBranch1 fit-content">
                            <asp:Label ID="Label9" runat="server" Text="Sort By"> </asp:Label>
                            <asp:DropDownList ID="ddl_Sorting" runat="server" CssClass="chzn-select" ToolTip="Sort By" Height="23" PlaceHolder="Sorte By" OnSelectedIndexChanged="ddl_Sorting_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">Sort By</asp:ListItem>
                                <asp:ListItem Value="Vouno">Vou #</asp:ListItem>
                                <asp:ListItem Value="VouDate">Vou Date</asp:ListItem>
                                <asp:ListItem Value="Vendor">Vendor</asp:ListItem>
                                <asp:ListItem Value="PAAmount">VouAmt</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4">
                        <asp:Panel ID="grd_panel" runat="server" ScrollBars="Auto" CssClass="gridpnl MB0">
                            <asp:GridView ID="Grd_Cheque" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader" Width="100%"
                                ShowHeaderWhenEmpty="True" DataKeyNames="vouyear,bid,blno,trantype,jobno,requestedby,vouno,pmtRemarks"
                                OnRowDataBound="Grd_Cheque_RowDataBound" OnSelectedIndexChanged="Grd_Cheque_SelectedIndexChanged" OnPreRender="Grd_Cheque_PreRender">

                                <%-- AllowPaging="false" PageSize="15" OnPageIndexChanging="Grd_Cheque_PageIndexChanging"--%>
                                <Columns>
                                    <asp:BoundField DataField="branch" HeaderText="Branch">
                                        <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="PI #">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Lnk_Vouno" runat="server" CommandName="select" ForeColor="Red" ToolTip='<%#Eval("vouno")%>'><%#Eval("vouno")%></asp:LinkButton>
                                        </ItemTemplate>
                                         <HeaderStyle  Width="100px"  />
                                        <ItemStyle  Width="100px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="voudate" HeaderText="Date" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                                    <asp:BoundField DataField="duedate" HeaderText="Due Date"  HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                                    <asp:TemplateField HeaderText="Job #">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Lnk_Jobno" runat="server" ForeColor="Red" Text='<%#Eval("jobno")%>' ToolTip='<%#Eval("jobno")%>' OnClick="lnkjob_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                         <HeaderStyle  Width="100px"  />
                                        <ItemStyle  Width="100px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="chqreqon" HeaderText="Requested On" HeaderStyle-Width="80px" ItemStyle-Width="80px" />

                                    <%--  <asp:BoundField DataField="custname" HeaderText="Vendore" />--%>
                                    <asp:TemplateField HeaderText="Vendor" HeaderStyle-ForeColor="White" >
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                                <asp:Label ID="custname" runat="server" Text='<%# Bind("custname")%>' ToolTip='<%# Bind("custname")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="160px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="160px"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--   <asp:TemplateField HeaderText="Favouring">
                        <ItemTemplate>
                            <div class="div_Column">
                                <%# Eval("favourname")%>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Favouring">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                                <asp:LinkButton ID="Lnk_favour" runat="server" ForeColor="Red" Text='<%# Bind("favourname") %>' ToolTip='<%# Bind("favourname") %>' OnClick="lnkCheque_Click"></asp:LinkButton>
                                                <%--<asp:Label ID="lbl_favour" runat="server" Text='<%# Bind("favourname") %>' ToolTip='<%# Bind("favourname") %>'></asp:Label>--%>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="160px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="160px"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="approvedby" HeaderText="ApprovedBy"  />--%>
                                    <asp:TemplateField HeaderText="Approved By" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                <asp:Label ID="approvedby" runat="server" Text='<%# Bind("approvedby")%>' ToolTip='<%# Bind("approvedby")%>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" Width="110px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="110px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="paamt" HeaderText="Vou Amt" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" Width="120px" />
                                        <HeaderStyle Width="120px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="tdsamt" HeaderText="TDS Amount" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" Width="120px" />
                                        <HeaderStyle Width="120px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pmtmode" HeaderText="Mode" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Chk_Select" runat="server" AutoPostBack="True" OnCheckedChanged="Chkselect_Click" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                                        <HeaderStyle Width="40px" />
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="vouyear" HeaderText="Vouyear" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"/>
                <asp:BoundField DataField="bid" HeaderText="Branchid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"/>--%>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <PagerStyle CssClass="GridviewScrollPager" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>

                    <div class="FormGroupContent4 ">

                        <div class="ApproveCal DateB">
                            <asp:Label ID="lbl_approve" runat="server" Text="Approved On"></asp:Label>
                            <asp:TextBox ID="txt_approve" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="TotalLabel2">
                            <asp:Label ID="lbl_total" runat="server" Text="Total Amount" Font-Bold="True"></asp:Label>
                        </div>
                        <div class="Appamount">
                            <span>PA Amount</span>
                            <asp:TextBox ID="txt_PAamount" runat="server" CssClass="form-control" Style="text-align: right;"></asp:TextBox>
                        </div>
                        <div class="AppAmount1">
                            <span>TDS Amount</span>
                            <asp:TextBox ID="txt_TDSamount" runat="server" CssClass="form-control" Style="text-align: right;"></asp:TextBox>
                        </div>

                    </div>
                        </div>
                   

                </div>
            </div>
        </div>
    </div>

    <div class="div_Break"></div>
    <asp:Panel ID="pln_popup" runat="server" CssClass="modalPopup" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <%--<asp:Panel ID="pln_popup" runat="server" CssClass="div_frame" Style="display: none;">--%>
            <%--  <div class="div_close"><asp:Image ID="close" runat="server" ImageAlign="Baseline" ImageUrl="~/images/GrdClose.gif" /> </div>--%>
            <div class="div_Break"></div>
            <%--  <div class="div_Grd_popup">--%>
            <asp:Panel ID="Panel3" runat="server" CssClass=" Gridpnl">
                <asp:GridView ID="Grd_Payment" runat="server" AutoGenerateColumns="False" Width="100%"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="10" BackColor="White" AllowPaging="false" OnPageIndexChanging="Grd_Payment_PageIndexChanging" OnRowDataBound="Grd_Payment_RowDataBound"
                    CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true" DataKeyNames="vouyear,remarks,bid,blno,jobno,trantype,favourname,approvedby,mode" OnPreRender="Grd_Payment_PreRender">
                    <Columns>
                        <asp:BoundField DataField="vouno" HeaderText="CNOps#" />
                        <asp:BoundField DataField="voudate" HeaderText="Date" />
                        <asp:TemplateField HeaderText="Vendor">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                    <asp:LinkButton ID="Lnk" runat="server" Text='<%#Eval("custname")%>' ToolTip='<%# Bind("custname") %>' ForeColor="Red" OnClick="lnkdetail_Click"></asp:LinkButton>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="vouamt" HeaderText="VouAmt" DataFormatString="{0:0.00}">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tdsamt" HeaderText="TDSAmount" DataFormatString="{0:0.00}">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="Shipper" HeaderText="Shipper Name" />--%>
                        <asp:TemplateField HeaderText="Shipper Name">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                    <%# Eval("shipper")%>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
                        </asp:TemplateField>
                        <%-- <asp:BoundField DataField="chqreqon" HeaderText="RequestedOn" />
                    <asp:BoundField DataField="brappon" HeaderText="BR AppOn" />
                     <asp:BoundField DataField="coappon" HeaderText="CO AppOn" />
                        --%>
                        <asp:TemplateField HeaderText="RequestedOn" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                    <asp:Label ID="chqreqon" runat="server" Text='<%# Bind("chqreqon")%>' ToolTip='<%# Bind("chqreqon")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AppOn" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                    <asp:Label ID="brappon" runat="server" Text='<%# Bind("brappon")%>' ToolTip='<%# Bind("brappon")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CO AppOn" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                    <asp:Label ID="coappon" runat="server" Text='<%# Bind("coappon")%>' ToolTip='<%# Bind("coappon")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>
            </asp:Panel>
            <div class="Clear"></div>
            <div class="right_btn MTRct">
                <div class="btn ico-excel">
                    <asp:Button ID="btn_export" runat="server" ToolTip="Export to Excel" OnClick="btn_export_Click" />
                </div>
            </div>
        </div>

        <div class="div_Break"></div>
    </asp:Panel>

    <div class="div_Break"></div>
    <asp:Panel ID="pln_detail" runat="server" CssClass=" modalPopup" Style="display: none;">

        <div class="divRoated">
        <div class="DivSecPanel">
            <asp:Image ID="img_detail" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
        </div>
        <div class="div_Break"></div>
       
        <div class="div_Break"></div>
        <div class="div_lbl">
            <asp:Label ID="lbl_favour" runat="server" Text="Favouring"></asp:Label>
            <asp:TextBox ID="txt_favouring" runat="server" ReadOnly="true" BorderColor="#999997" placeholder="Favouring" ToolTip="Favouring"></asp:TextBox>
        </div>

        <div class="div_lbl_mode">
            <asp:Label ID="lbl_mode" runat="server" Text="Mode"></asp:Label>
            <asp:TextBox ID="txt_mode" runat="server" ReadOnly="true" BorderColor="#999997" placeholder="Mode" ToolTip="Mode"></asp:TextBox>
        </div>
        <div class="div_lbl_remark">
            <asp:Label ID="lbl_remark" runat="server" Text="Remark"></asp:Label>
            <asp:TextBox ID="txt_remark" runat="server" ReadOnly="true" BorderColor="#999997" placeholder="Remark" ToolTip="Remark"></asp:TextBox>
        </div>
            </div>
    </asp:Panel>
    <div class="div_Break"></div>
    <asp:Panel ID="pln_favour" runat="server" CssClass=" modalPopup" Style="display: none;">
        <div class="divRoated">
        <div class="DivSecPanel">
            <asp:Image ID="img_favour" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
        </div>
        <div class="div_Break"></div>
        <div class="div_lbl">
            <asp:Label ID="lbl_favour_cheque" runat="server" Text="Favouring"></asp:Label>
        </div>
        <div class="div_Break"></div>
        <div class="div_lbl">
            <span>Favouring</span>
            <asp:TextBox ID="txt_favour_cheque" runat="server" ReadOnly="true" BorderColor="#999997" placeholder="Favouring" ToolTip="Favouring"></asp:TextBox>
        </div>
        <div class="div_Break"></div>
       
        <div class="div_Break"></div>
        <div class="div_lbl">
            <asp:Label ID="lbl_remark_cheque" runat="server" ReadOnly="true" Text="Remark"></asp:Label>
            <asp:TextBox ID="txt_remark_cheque" runat="server" ReadOnly="true" BorderColor="#999997" placeholder="Remark" ToolTip="Remark"></asp:TextBox>
        </div>
            </div>
    </asp:Panel>
    <div class="div_Break"></div>

    <asp:Panel ID="pln_cheque" runat="server" CssClass="modalPopup" Style="display: none;">

        <div class="DivSecPanel" style="margin-top: 0%;">
            <asp:Image ID="Close_Cheque" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
        </div>

        <%--<asp:Panel ID="Panel2" runat="server" class="Gridpnl1" ScrollBars="None">--%>
        <iframe id="iframecost" runat="server" src="" frameborder="0" class="frames"></iframe>
        <%--  </asp:Panel>--%>
        <div class="div_Break"></div>

    </asp:Panel>
    <asp:ModalPopupExtender ID="pln_Grg" runat="server" PopupControlID="pln_popup" TargetControlID="Label1" CancelControlID="close">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="popup_detail" runat="server" PopupControlID="pln_detail" TargetControlID="Label2" CancelControlID="img_detail">
    </asp:ModalPopupExtender>

    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_approve"
        Format="dd/MM/yyyy"></asp:CalendarExtender>
    <asp:ModalPopupExtender ID="popup_favour" runat="server" PopupControlID="pln_favour"
        TargetControlID="Label3" CancelControlID="img_favour">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="popup_cheque" runat="server" PopupControlID="pln_cheque"
        TargetControlID="Label4" CancelControlID="Close_Cheque">
    </asp:ModalPopupExtender>

    <div class="div_Break"></div>
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <asp:Label ID="Label3" runat="server"></asp:Label>
    <asp:Label ID="Label4" runat="server"></asp:Label>
    <asp:Label ID="Label5" runat="server"></asp:Label>
    <asp:HiddenField ID="hid" runat="server" />
    <asp:HiddenField ID="hid_detail" runat="server" />
    <asp:HiddenField ID="hid_confirm" runat="server" />
    <asp:HiddenField ID="hid_row" runat="server" />
    <asp:HiddenField ID="hid_favour" runat="server" />
    <asp:HiddenField ID="hid_cheque" runat="server" />
    <asp:HiddenField ID="hidpageload" runat="server" />

    <asp:HiddenField ID="hid_Amount" runat="server" />
    <asp:HiddenField ID="hid_TDSAmount" runat="server" />
    <asp:GridView ID="Gridtemp" runat="server" AutoGenerateColumns="false" Visible="false" OnPreRender="Gridtemp_PreRender">
        <Columns>
            <asp:BoundField DataField="vouno" HeaderText="CNOps#" />
            <asp:BoundField DataField="voudate" HeaderText="Date" />
            <asp:TemplateField HeaderText="Vendor">
                <ItemTemplate>
                    <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                        <asp:LinkButton ID="link_custname" runat="server" Text='<%#Eval("custname")%>' ToolTip='<%# Bind("custname") %>' ForeColor="Red" OnClick="lnkdetail_Click"></asp:LinkButton>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
            </asp:TemplateField>
            <asp:BoundField DataField="vouamt" HeaderText="VouAmt" DataFormatString="{0:0.00}">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="tdsamt" HeaderText="TDSAmount" DataFormatString="{0:0.00}">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <%--<asp:BoundField DataField="Shipper" HeaderText="Shipper Name" />--%>
            <asp:TemplateField HeaderText="Shipper Name">
                <ItemTemplate>
                    <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">

                        <asp:Label ID="lbl_shipper" runat="server" Text='<%# Bind("shipper")%>' ToolTip='<%# Bind("shipper")%>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
            </asp:TemplateField>
            <%-- <asp:BoundField DataField="chqreqon" HeaderText="RequestedOn" />
                    <asp:BoundField DataField="brappon" HeaderText="BR AppOn" />
                     <asp:BoundField DataField="coappon" HeaderText="CO AppOn" /> <%# Eval("shipper")%> 
            --%>
            <asp:TemplateField HeaderText="RequestedOn" HeaderStyle-ForeColor="White">
                <ItemTemplate>
                    <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                        <asp:Label ID="lbl_chqreqon" runat="server" Text='<%# Bind("chqreqon")%>' ToolTip='<%# Bind("chqreqon")%>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AppOn" HeaderStyle-ForeColor="White">
                <ItemTemplate>
                    <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                        <asp:Label ID="lbl_brappon" runat="server" Text='<%# Bind("brappon")%>' ToolTip='<%# Bind("brappon")%>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CO AppOn" HeaderStyle-ForeColor="White">
                <ItemTemplate>
                    <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                        <asp:Label ID="lbl_coappon" runat="server" Text='<%# Bind("coappon")%>' ToolTip='<%# Bind("coappon")%>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
            </asp:TemplateField>
        </Columns>
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
        <HeaderStyle CssClass="GridHeader" />
        <AlternatingRowStyle CssClass="GrdAltRow" />
        <PagerStyle CssClass="GridviewScrollPager" />
    </asp:GridView>
    <%-- <asp:Button ID="btn_search" runat="server" Text="" Style="display: none;" OnClick="btn_search_Click" />--%>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>ChequeRequest Approval #</label>

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
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="10"
                    BackColor="White" OnPreRender="GridViewlog_PreRender">
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

    <asp:Label ID="Label6" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label6" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

</asp:Content>
