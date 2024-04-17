<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Voucher.aspx.cs" Inherits="logix.FAForms.Voucher" %>
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
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" />
    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <link href="../CSS/Finance.css" rel="stylesheet" />
    <!-- App -->
    <script src="../../js/helper.js"></script>

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

        $(document).keyup(function (e) {
            if (e.keyCode == 27) {

                $("#<%=btnback.ClientID%>").click();

            }
         });

    </script>
    <style type="text/css">
        .Grid4 {
            border: 1px solid #b1b1b1;
            height: 271px;
            margin: 0;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }

        .widget.box {
            border: 1px solid #d9d9d9;
            float: left;
            width: 100%;
            margin-left: 0px;
            height: 100%;
        }
        body {
            overflow:hidden;
        }
        /*<----log details--->*/
       .ConsigneeInput1 {
    float: left;
    width: 97%;
    margin:9px 0px 0px 0px;
}
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



        logix_CPH_PanelLog {
            top:205px!important;
        }

        .PreparedTxt {
            width:18%;
            float:left;margin:0px 0.5% 0px 0px;
            font-size:13px;
            font-family:sans-serif;
            font-weight:bold;
            color:#4e4e4c;


        }
        .PrepareValue {
            width:60%;
            float:left;
            margin:0px 0.5% 0px 0px;
            font-size:13px;
            font-family:sans-serif;

        }
            .PrepareValue span {
                font-family:sans-serif;
            }
        .ApprovedByTxt {
            width:18%;
            float:left;
            margin:0px 0.5% 0px 0px;
            font-size:13px;
             font-family:sans-serif;
             font-weight:bold;
             color:#4e4e4c;
        }
        .ApprovedValue {
            width:40%;
            float:left;
            margin:0px 0px 0px 0px;
            font-size:13px;
             font-family:sans-serif;
        }
            .ApprovedValue span {
                font-size:13px;
                font-family:sans-serif;
            }

             .row {
    height: 560px !important;
    margin: 0px 5px 0px -15px;
    clear: both;
    overflow-x: hidden !important;
    overflow-y: auto !important;
    width: 98%;
} 
              .widget.box {
            position: relative;
            top: -8px;
        }
.ShipperLeft {
    width: 83.5%;
    float: left;
    margin: 0px 0% 0px 0px;
}
.ShipperLeft {
    margin-right: 0.5% !important;
}
div#logix_CPH_pln_Trialbalance {
    display: block;
    top: 30px !important;
}
  div#logix_CPH_lbl_txt {
    width: 50%;
    float: left;
    position: relative;
    top: 5px;
}
  select#logix_CPH_lstvol {
    overflow: hidden;
    height: 153px !important;
    border: 1px solid var(--inputborder);
}
  div#UpdatePanel1 {
    /* height: 100vh; */
    height: 100vh;
    overflow-x: hidden;
    overflow-y: auto;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

     


    <div >
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lblheader" runat="server" Text="Credit Note - Operations"></asp:Label>
                    </h4>
                    <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">Vouchers</a> </li>              
              <li><a href="#" title="" id="lblHead" runat="server"></a> </li>
                        <li><asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>

              
            </ul>
      </div>
                      <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" ><asp:LinkButton ID="logdetails" runat="server" ToolTip="Log"  Style="text-decoration: none" OnClick="logdetails_Click" ></asp:LinkButton></div>
                </div>

                <div class="widget-content">
                    <div class="ShipperLeft">
                        <div class="FormGroupContent4 boxmodal">
                            <div class="VoucherInput">
                                <%--<asp:Label ID="lblvoc" runat="server" Text="Voucher #" CssClass="LabelValue"></asp:Label>--%>
                                <asp:TextBox ID="txtVoucherno" runat="server" CssClass="form-control" OnTextChanged="txtVoucherno_TextChanged" ToolTip="Voucher Number" placeholder="Voucher #" AutoPostBack="True"></asp:TextBox>

                            </div>
                            <div class="DateInput ">
                                <%--<asp:Label ID="lbldate" runat="server" Text="Date" CssClass="LabelValue"></asp:Label>--%>
                                <asp:TextBox ID="txtvoudate" runat="server" CssClass="form-control" ToolTip="Date" placeholder="Date"></asp:TextBox>
                            </div>
                            <div class="VesselInput1 ">
                                <asp:TextBox ID="txtModule" runat="server" ToolTip="Product" placeholder="Product" CssClass="form-control"></asp:TextBox></div>
                            <div class="JobInput1 ">
                                <%--<asp:Label ID="lbljobno" runat="server" Text="Job #" CssClass="LabelValue"> </asp:Label>--%>
                                <asp:TextBox ID="txtjobno" runat="server" CssClass="form-control" ToolTip="Job #" placeholder="Job #"></asp:TextBox>
                            </div>
                            <div class="BLinput1 ">

                                <%--<asp:Label ID="lblBLrAwblrDoc" runat="server" Text="BL # / AWBL # / DOC #" CssClass="LabelValue"></asp:Label>--%>
                                <asp:TextBox ID="txtblno" runat="server" CssClass="form-control" ToolTip="BL # / AWBL # / DOC #" placeholder="BL # / AWBL # / DOC #"></asp:TextBox>

                            </div>
                            <div class="VesselInput ">
                                <%--<asp:Label ID="lblvsslrflgt" runat="server" Text="Vessel / Flight #"></asp:Label>--%>

                                <asp:TextBox ID="txtvessel" runat="server" CssClass="form-control" ToolTip="Vessel / Flight #" placeholder="Vessel / Flight #"></asp:TextBox>
                            </div>

                        </div>
                        <div class="FormGroupContent4" style="display: none;">


                            <div class="VesselInput2">
                                <asp:ListBox ID="lstcon" runat="server" Width="100%" Height="24"></asp:ListBox></div>
                        </div>


                        <div class="FormGroupContent4 boxmodal">
                        <div class="FormGroupContent4">
                            <div class="ShipperInput">
                                <%--<asp:Label ID="lblshipper" runat="server" Text="Shipper" CssClass="LabelValue"></asp:Label>--%>
                                <asp:TextBox ID="txtshipper" runat="server" CssClass="form-control" ToolTip="Shipper" placeholder="Shipper"></asp:TextBox>

                            </div>
                            <div class="ConsigneeInput ">
                                <%--<asp:Label ID="lblconsignee" runat="server" Text="Consignee" CssClass="LabelValue"></asp:Label>--%>

                                <asp:TextBox ID="txtconsignee" runat="server" CssClass="form-control" ToolTip="Consignee" placeholder="Consignee"></asp:TextBox>
                            </div>
                        </div>

                        <div class="FormGroupContent">
                            <div class="NotifyInput">
                                <%--<asp:Label ID="lblnotifypty" runat="server" Text="Notify Party" CssClass="LabelValue"></asp:Label>--%>
                                <asp:TextBox ID="txtnotify" runat="server" CssClass="form-control" ToolTip="Notify Party" placeholder="Notify Party"></asp:TextBox>
                            </div>
                            <div class="RemarksInput">
                                <%--<asp:Label ID="lblremarks" runat="server" Text="Remarks" CssClass="LabelValue"></asp:Label>--%>
                                <asp:TextBox ID="txtremarks" runat="server" CssClass="form-control" ToolTip="Remarks" placeholder="Remarks"></asp:TextBox>

                            </div>
                        </div>
                        </div>
                    </div>

                    <div class="ShipperRight boxmodal">
                        <div class="FormGroupContent4">
                            <div class="ConsigneeInput1 TextField">
                                <asp:ListBox ID="lstvol" runat="server" Width="100%" Height="129px"></asp:ListBox></div>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="panel_06 MB0">
                            <asp:GridView ID="grd" runat="server" CssClass="Grid FixedHeader" Width="100%" AutoGenerateColumns="False" OnRowDataBound="grd_RowDataBound" DataKeyNames="LedgerType" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found">
                                <Columns>
                                    <asp:BoundField DataField="ledgername" HeaderText="Particulars">
                                        <HeaderStyle HorizontalAlign="Left" Width="300px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ledgeramount" HeaderText="Debit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TXTAlign1" HeaderStyle-CssClass="TXTAlign1">
                                        <HeaderStyle HorizontalAlign="right" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ledgeramount" HeaderText="Credit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TXTAlign1" HeaderStyle-CssClass="TXTAlign1">
                                        <HeaderStyle HorizontalAlign="right" Width="150px" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </div>

                    </div>
 


                    <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4">

                        <div id="lbl_txt" runat="server" visible="false"> 
                            <div style="float: left;width: 100%;">
                        <div class="PreparedTxt">Prepared By:</div>
                        <div class="PrepareValue"><asp:Label ID="lbl_prepare" runat="server" Text=""></asp:Label></div>
                                </div>
                            <div style="float: left;width: 100%;">

                        <div class="ApprovedByTxt">Approved By:</div>
                        <div class="ApprovedValue"><asp:Label ID="lbl_Approve" runat="server" Text=""></asp:Label></div>
                                </div>
                        </div>

                        <div style="float:left;margin:1px 1px 1px 1px;color:red;"><asp:Label ID="lbl_against" runat="server" Text=""></asp:Label></div>
                        </div>
                    <div class="FormGroupContent4">

                        <div class="right_btn">
                            <div class="btn ico-back">
                                <asp:Button ID="btnprvs" runat="server" Text="Previous" ToolTip="Previous" OnClick="btnprvs_Click" TabIndex="5" /></div>
                            <div class="btn ico-view">
                                <asp:Button ID="btnview" runat="server" Text="View" ToolTip="View" OnClick="btnview_Click" /></div>
                            <div class="btn ico-next">
                                <asp:Button ID="btnnext" runat="server" Text="Next" ToolTip="Next" OnClick="btnnext_Click" /></div>
                            <div class="btn ico-cancel" id="btnback1" runat="server">
                                <asp:Button ID="btnback" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btnback_Click" /></div>

                        </div>
                        </div>
                    </div>

                </div>
















            </div>
        </div>
    </div>


     <asp:Panel ID="PanelLog" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label id="lbl_title" runat="server"></label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:label ID="JobInput" runat="server"></asp:label>

                </div>

            </div>
        <div class="DivSecPanel"> <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="16px" Height="16px"/>  </div>
             
     <asp:Panel ID="Panel3" runat="server"   CssClass="Gridpnl">  

          <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                ForeColor="Black" EmptyDataText="No Record Found" PageSize="20"  
                BackColor="White" >
                <Columns>

                    </Columns>
              <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="myGridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <PagerStyle CssClass="GridviewScrollPager" />
              </asp:GridView>

         </asp:Panel>
              <div class="Break"> </div>
        </div>
     

    </asp:Panel>
    <asp:Label ID="Label4" runat="server"></asp:Label>
         <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog" 
       DropShadow="false" TargetControlID="Label4" CancelControlID="Image1" BehaviorID="Test1">
    </asp:ModalPopupExtender>


    <asp:HiddenField ID="hf_LogBr_ID" runat="server" />
    <asp:HiddenField ID="Hid_trantype" runat="server" />
    <asp:HiddenField ID="hf_flag" runat="server" />
    <asp:HiddenField ID="hf_vid" runat="server" />

    <asp:HiddenField ID="hidfdate" runat="server" />

    <asp:HiddenField ID="hidtdate" runat="server" />

    <asp:HiddenField ID="hidvoutype" runat="server" />

    <asp:HiddenField ID="hf_OSV_Type" runat="server" />
    <br />
    <asp:HiddenField ID="hf_PBranchid" runat="server" />

    <asp:HiddenField ID="hid_BoolValue" runat="server" />
    <asp:HiddenField ID="hid_hmbl" runat="server" />
</asp:Content>
