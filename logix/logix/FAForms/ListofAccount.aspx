<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ListofAccount.aspx.cs" Inherits="logix.FAForm.ListofAccount" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />

     <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> <link href="../Theme/assets/css/system.css" rel="stylesheet" />

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
    
    <link rel="Stylesheet" href="../Styles/ListofAccount.css" />

    <script language="javascript" type="text/javascript">

        function divexpandcollapse(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);

            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "../images/minus.gif";
            } else {
                div.style.display = "none";
                img.src = "../images/plus.gif";
            }

        }

        function divbranch(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);

            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "../images/minus.gif";
            } else {
                div.style.display = "none";
                img.src = "../images/plus.gif";
            }
        }

    </script>

    <style type="text/css">
        .Grid3 {
    border: 1px solid #b1b1b1;
    height: 100%;
    margin: 0;
    overflow-x: hidden !important;
    overflow-y: auto !important;
    width: 100%;
}

                .Grid4 {
    border: 1px solid #b1b1b1;
    height: 456px;
    margin: 0;
    overflow-x: hidden !important;
    overflow-y: auto !important;
    width: 100%;
}
              table div table td {
    border-right: 0!important;
    width: 100%;
}

table div table {
    border: 0px!important;
    width: 100%!important;
}
        .row {
            width:100%;
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
             white-space:nowrap;
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
.GrdAltRow {
    background: #fff;
}

.StickyHeader td {
    padding: 1px 5px 0px!important;
    border-bottom: 0.5px solid #b1b1b1!important;
}

.StickyHeader th:nth-child(3),
 .StickyHeader td:nth-child(3) {
    display: none!important;
}
 .StickyHeader tr:last-child {
    border-bottom: 0px solid #AAA !important;
}

  /*.FixedHeader tr {
    background-color: var(--white) !important;
}
 .FixedHeader tr:nth-child(3n+1) {
    background-color: var(--tablerowcolor) !important;
}*/
  .widget.box{
    position: relative;
    top: -8px;
}
  .gridpnl {
    height: calc(100vh - 120px);
    overflow: auto;
}
.widget.box .widget-content {
    top: 0px !important;
    padding-top: 55px !important;
}
/*table#logix_CPH_Grd_Account tr {
    background: white !important;
    border: white !important;
}*/
div#logix_CPH_grdpanel {
    overflow-x: hidden !important;
    width: 50% !important;
}
.FixedButtonsss {
    position: fixed;
    top: 35px !important;
    left: 0;
    background: #fff;
    z-index: 10;
    box-shadow: 0px 0px 20px rgb(0 0 0 / 10%);
    width: calc(100vw - 642px) !important;
    border-bottom: 0.5px solid #00000010;
    padding: 1px 0 5px 10px;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

       <div >
        <div class="col-md-12  maindiv">     
        <div class="widget box" runat ="server">
        <div class="widget-header">
            <div>
        <h4><i class="icon-umbrella"></i>
             <asp:Label ID="lbl_Header" runat="server"></asp:Label>
            </h4>
           <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#">Home</a> </li>
            <li><a href="#">Account Info</a> </li>
              <li><a href="#" title="">List of Accounts</a> </li>
               <li><asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
            </ul>
      </div>
             <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>

               <div class="FixedButtons">
       <div class="right_btn">

    <div class="btn ico-excel">
        <asp:Button ID="btn_Export" runat="server"  Text="Export Excel" ToolTip="Export Excel" OnClick="btn_Export_Click" />
    </div>

    <div class="btn ico-view">
        <asp:Button ID="btn_View" runat="server" Text="View" ToolTip="View"  onclick="btn_View_Click" />
    </div>

</div>
   </div>


            </div>
           <div class="widget-content" >
               
                 <div  class="FormGroupContent4 boxmodal">

                     <asp:Panel ID="grdpanel" runat="server" ScrollBars="auto">    
            <asp:GridView ID="Grd_Account" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" ForeColor="Black" EmptyDataText="No Record Found" 
                DataKeyNames="groupid" OnRowDataBound="Grd_Account_RowDataBound"  OnPreRender="Grd_Account_PreRender"  >
                <Columns>
                    <asp:TemplateField ItemStyle-Width="20px">
                        <ItemTemplate>
                            <a href="JavaScript:divexpandcollapse('div<%# Eval("groupid") %>');">
                                <img id="imgdiv<%# Eval("groupid") %>" width="9px" border="0" src="../images/plus.gif" />
                            </a>
                        </ItemTemplate>
                        <%--<ItemStyle Width="20px"></ItemStyle>--%>
                        <ItemStyle Width="20px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="groupname" HeaderText="GroupName">
                        <HeaderStyle HorizontalAlign="Left" Wrap="true" CssClass="Grd_RightTemplate" />
                        <ItemStyle HorizontalAlign="Left" CssClass="Grd_RightTemplate" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderStyle-CssClass="Grd_LeftTemplate" ItemStyle-CssClass="Grd_LeftTemplate">
                        <ItemTemplate>
                            <tr>
                                <td colspan="3">
                                    <div id="div<%# Eval("groupid") %>" style="display: none; position: relative; left: 25px; overflow: auto">
                                        <asp:GridView ID="gvChildGrid" runat="server"  CssClass="Grid StickyHeader" AutoGenerateColumns="False" ShowHeader="false" Width="90%"
                                            DataKeyNames="subgroupid,groupid" OnRowDataBound="gvChildGrid_RowDataBound"  BorderStyle="None">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <a href="JavaScript:divbranch('divbranch<%# Eval("subgroupid") %>');"> <img id="imgdivbranch<%# Eval("subgroupid") %>" width="9px" border="0" src="../images/plus.gif" />
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="subgroupname" HeaderText="SubGroupName">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="Grd_RightTemplate" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="Grd_RightTemplate" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderStyle-CssClass="Grd_LeftTemplate" ItemStyle-CssClass="Grd_LeftTemplate">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td colspan="2">
                                                                <div id="divbranch<%# Eval("subgroupid") %>" style="display: none; position: relative;
                                                                    left: 35px; overflow: auto;">
                                                                    <asp:GridView ID="Grdbranch" runat="server" AutoGenerateColumns="false" Width="80%"  CssClass="Grid StickyHeader" DataKeyNames="ledgerid" ShowHeader="false">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="ledgername" HeaderText="LedgerName">
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:BoundField>
                                                                        </Columns>
                                                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                   <HeaderStyle CssClass="Grd_LeftTemplate"></HeaderStyle>
                        <ItemStyle Wrap="True" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
        </asp:Panel>
                     </div>

      

   </div>

            </div>
            </div>
           </div>

     <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>List Of Account #</label>

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

    <asp:Label ID="Label5" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label5" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

</asp:Content>
