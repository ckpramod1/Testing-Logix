<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="logix.FAForm.Statistics" 
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/VoucherRegister.css" rel="stylesheet" />
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

    <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>


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
    
    <link rel="Stylesheet" href="../Styles/TrialBalance.css" type="text/css" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Styles/ControlStyle.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <link href="../Styles/statistics.css" rel="stylesheet" />

    <style type="text/css">
        .GridS {
    width: 50%;
    height: 100%;
    margin: 0px 0px 0px 0px;
    overflow-x: hidden !important;
    overflow-y: auto !important;
}

         .div_frame {
            border-left: 0px solid black;
border-right: 0px solid black;
        }

         
         .modalBackground {
            background-color: #ffffff;
            filter: alpha(opacity=100);
        }


         .GridS {
    width: 100%;
    max-height: 447px;
    margin: 0px 0px 0px 0px;
    overflow-x: hidden !important;
    overflow-y: auto !important;
}


 .DivSecPanel
        {
            width:20px; 
            Height:20px; 
            border:2px solid white;
            margin-left:98.5%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }
   .div_frame {
    width: 1360px;
    Height: 582px;
    float: left;
    text-align: center;
    /* overflow-y: scroll; */
}

    


.row {
    clear: both;
    width: 100%;
    height: 580px!important;
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
             div#logix_CPH_Panel1 {
    height: fit-content;
}
             .widget.box{
    position: relative;
        width: 60%;
}
             .widget.box .widget-content {
    top: 0px !important;
    padding-top: 55px !important;
}
             .FixedButtonsss {
    position: fixed;
    top: 30px;
    left: 0;
    background: #fff;
    z-index: 10;
    box-shadow: 0px 0px 20px rgb(0 0 0 / 10%);
    width: calc(100vw - 521px) !important;
    border-bottom: 0.5px solid #00000010;
    padding: 1px 0 5px 10px;
}
div#logix_CPH_grd_panel {
    height: calc(100vh - 115px);
}


    </style>



    <script type="text/javascript">




        $(document).keydown(function (e) {

            if (e.keyCode == 27) {

                $("#<%=btnback.ClientID%>").click();

            }
        });


    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
     

    <div >
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lblheader" runat="server"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs1" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">Reports</a> </li>
              <li><a href="#" title="">Statistics</a> </li>
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
            <asp:Button runat="server" ID="btnexcel"  Text="Export To Excel" ToolTip="Export To Excel" OnClick="btnexcel_Click" />
        </div>
        <div class="btn ico-cancel" id="btn_cancel1" runat="server">
            <asp:Button runat="server" ID="btncancel"  Text="Cancel" ToolTip="Cancel" OnClick="btncancel_Click" />
        </div>
    </div>
</div>

                </div>

                <div class="widget-content">
                     
                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel ID="grd_panel" runat="server" ScrollBars="Auto" CssClass="gridpnl
                            ">

                            <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" Width="100%" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found" 
                                CssClass="Grid FixedHeader" OnRowDataBound="grd_RowDataBound" DataKeyNames="voutypeid" OnSelectedIndexChanged="grd_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField HeaderText="Types Of Vouchers" DataField="voutypename">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Total" DataField="total">
                                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                        <ItemStyle HorizontalAlign="Right" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Cancelled" DataField="cancelled">
                                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>


                                   <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" CssClass="">
                            <asp:GridView ID="GRDREG" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="pbid,grdvouno,osvtype" ShowHeaderWhenEmpty="True" 
                                EmptyDataText="No Record Found" CssClass="Grid FixedHeader" Visible="False" OnRowDataBound="GRDREG_RowDataBound" 
                                OnSelectedIndexChanged="GRDREG_SelectedIndexChanged" OnRowCancelingEdit="GRDREG_RowCancelingEdit">
                                <Columns>
                                    <asp:BoundField HeaderText="Vou Date" DataField="voudate">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Vou #" DataField="vouno">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Customer" DataField="customername">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Amount" DataField="ledgeramount">
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Left" Width="150px"/>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Status" DataField="status">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>

                        <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" CssClass="">
                            <asp:GridView ID="grdmonth" runat="server" AutoGenerateColumns="False" Width="100%" ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found" CssClass="Grid FixedHeader" Visible="False" OnRowDataBound="grdmonth_RowDataBound" DataKeyNames="vmonth" OnSelectedIndexChanged="grdmonth_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField HeaderText="Month" DataField="strmonth">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Total" DataField="total">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Cancelled" DataField="cancelled">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>

                        </asp:Panel>
                        </asp:Panel>
                 
                  
                    </div>

                </div>
            </div>
        </div>
    </div>

    <div class="stat_grd">

        <%--<a href="javascript:__doPostBack('GRDREG','Cancel$0')">Cancel</a>--%>
    </div>
    <div class="btnexcel">
    </div>

    <asp:HiddenField ID="hidvoutypeid" runat="server" />
    <asp:HiddenField ID="hidvoutype" runat="server" />
    <asp:HiddenField ID="hidfdate" runat="server" />
    <asp:HiddenField ID="hidtdate" runat="server" />
    <asp:Button runat="server" ID="btnback" Style="display: none" Text="Back" OnClick="btnback_Click" />

    <%--<----------------------------- For Modal Pop-------------------------------->--%>

    <div class="FormGroupContent4">
            <asp:HiddenField ID="hid" runat="server" />
            <asp:Panel ID="pln_Trialbalance" runat="server" class=" modalPopup" BackColor="White" Style="display:none;">
                <div class="divRoated">
                <div class="DivSecPanel">
                        <asp:Image ID="Close_Trialbalance" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                    </div>

          
            <div class="">
                <iframe id="iframecost" runat="server" src="" frameborder="0" class="div_frmdisplay">
                </iframe>
            </div>
                    </div>
            </asp:Panel>
        </div>

        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pln_Trialbalance"
        TargetControlID="lbl_hid" CancelControlID="Close_Trialbalance" >
       
        </asp:ModalPopupExtender>
    <asp:Label ID="lbl_hid" runat="server" />



      <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Statistics#</label>

                                </div>
                                <div class="LogHeadJobInput">

                                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                                </div>

                            </div>
                            <div class="DivSecPanel">
                                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>

                            <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

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

