﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="TDSRemoval.aspx.cs" Inherits="logix.FAForms.TDSRemoval" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
     <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> 
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
    <link href="../Styles/TDSRemoval.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {
                $(".Text").blur(function () {
                    $("Text").change();
                });
            });
        }

    </script>

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {

            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
      </script>


  <link href="../Styles/Chosenlogin.css" rel="stylesheet" />


  <style type="text/css">

.VoucherDrop {
    width: 13%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.VoucherCNO {
    width: 5.5%;
    float: right;
    margin: 0px 0.5% 0px 0px;
}
.VoucherCustomer {
    width: 15%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.CustomerAmount{
    width: 7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.VoucherNo {
    width: 7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
        white-space: nowrap;
}
.TDSAmount
{
    width: 8%;
    float: left;
    margin: 0px 0.5% 0px 0px;

}
.VocherTypeIV {
    width: 6%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.TdsPercentage{
    width: 9.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;

}
 .TdsExisting {
          width: 11.5%;
          float: left;
          margin: 0px 0% 0px 0px;
      }


      .TdsExisting1 {
           width: 7.5%;
          float: left;
          margin: 0px 0.5% 0px 0px;
      }



 .TdsCurrent {
          width: 4%;
          float: left;
          margin: 0px 0.5% 0px 0px;
      }
 .TAmount {
          width: 7.5%;
          float: left;
          margin: 0px 0.5% 0px 0px;
      }
 .Amount{
          width: 6%;
          float: right;
          margin: 0px 0% 0px 0px;
      }
 .VoucherDate {
    width: 5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
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
             }    .MT15{
            margin:15px 0px 0px 0px;
           }
       .FormGroupContent4 span {
                       color: #000080;
                       font-size: 11px;
                       }
         .FormGroupContent4 label {
            color: #000080;
            font-size: 11px;
        }
        .chzn-drop {
                   height: 180px!important;
                   }
        .chzn-container-single .chzn-single span{
                   color:#000!important;
                   }
        .widget.box{
    position: relative;
    top: -8px;
}
.widget.box .widget-content {
    top: 0px !important;
    padding-top: 65px !important;
}
  </style>
</asp:Content>
        <asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">    
        

    <div >
        <div class="col-md-12  maindiv">     
        <div class="widget box" runat ="server">
        <div class="widget-header">
            <div>
        <h4 class="hide"><i class="icon-umbrella"></i>
           <asp:Label ID="lbl_Header" runat="server" Text="TDS Removal"></asp:Label>
            </h4>
            <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#">Home</a> </li>
            <li><a href="#">Utility</a> </li>
              <li><a href="#" title=""> TDS Removal </a> </li>
               <li><asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
            </ul>
         </div>
             <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>

             <div class="FixedButtons">
       <div class="right_btn">
         <div class="btn ico-update"><asp:Button ID="btn_update" Text="Update" runat="server" ToolTip="Update" OnClick="btn_update_Click"/></div>
       <div class="btn ico-cancel" id="btn_back1" runat="server"> <asp:Button ID="btn_back" Text="Cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click"/></div>
        </div>            
    </div>


            </div>

             <div class="widget-content" >
                 
             <div class="FormGroupContent4 boxmodal">        

       <div class="VoucherDrop"> 
             <asp:Label ID="lbl_voucher" runat="server" Text="Voucher Type"></asp:Label>
                <asp:DropDownList ID="ddl_voucher" CssClass="chzn-select" data-placeholder="Voucher Type"  runat="server"  AutoPostBack="True" onselectedindexchanged="ddl_voucher_SelectedIndexChanged">                                
                 <asp:ListItem Value="A" Text=""></asp:ListItem>
                  <asp:ListItem Value="E">Credit Note</asp:ListItem>
                  <asp:ListItem Value="S">Admin Purchase Invoice</asp:ListItem>
                  <asp:ListItem Value="P">Purchase Invoice</asp:ListItem>
                  </asp:DropDownList></div> 
                 
                 <div class="VoucherNo">
                           <asp:Label ID="lbl_VoucherNo" runat="server" Text="Vou #"></asp:Label>
                             <asp:TextBox ID="txt_VoucherNo" runat="server" CssClass="form-control"  ToolTip="Vou No #" placeholder=""  AutoPostBack="True" 
                               OnTextChanged="txt_VoucherNo_TextChanged" ></asp:TextBox>
                        </div>

                  <div class="VoucherDate">
                      <asp:Label ID="Label1" runat="server" Text="Date"> </asp:Label>
                      <asp:TextBox ID="txt_year" runat="server" CssClass="form-control"></asp:TextBox></div>

                 <div class="VoucherCustomer">
                            <asp:Label ID="lbl_Customer" runat="server" Text="Customer"></asp:Label>
                            <asp:TextBox ID="txt_Customer" runat="server" ReadOnly="True" CssClass="form-control"  ToolTip="Customer" placeholder="" ></asp:TextBox>
                        </div> 

                 <div class="TdsExisting1">
                            <asp:Label ID="lbl_Actamount" runat="server" Text="Act Amount"></asp:Label>
                            <asp:TextBox ID="txt_Actamount" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Actamount" placeholder="" Style="text-align: right"></asp:TextBox>
                        </div>  
                 
                 <div class="CustomerAmount">
                           <asp:Label ID="lbl_amount" runat="server" Text="Amount"></asp:Label>
                            <asp:TextBox ID="txt_Amount" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Amount" placeholder="" Style="text-align: right"></asp:TextBox>
                        </div> 
                 <div class="TdsPercentage">
                            <asp:Label ID="lbl_TdsPercentage" runat="server" Text="Tds Percentage"></asp:Label>
                            <asp:TextBox ID="Txt_TdsPercentage" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="TdsPer" placeholder="" Style="text-align: right"></asp:TextBox>
                        </div>  
                  <div class="TDSAmount">
                            <asp:Label ID="lbl_tdsamount" runat="server" Text="Tds Amount"></asp:Label>
                            <asp:TextBox ID="txt_tdsamount" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="TdsAmount" placeholder="" Style="text-align: right"></asp:TextBox>
                        </div> 
                   <div class="TdsCurrent">
                     <asp:Label ID="lbl_tdscurrent" runat="server" Text="Tds"></asp:Label>
                     <asp:TextBox ID="txt_tds" runat="server" CssClass="form-control" ToolTip="Tds" placeholder="" Style="text-align:right" OnTextChanged="txt_tds_TextChanged" AutoPostBack="true" ></asp:TextBox>
                         </div>  
                 
                 <div class="TAmount">
                           <asp:Label ID="lbl_amount1" runat="server" Text="TAmount"></asp:Label>
                            <asp:TextBox ID="txt_Tamount" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="TAmount" placeholder="" Style="text-align: right"></asp:TextBox>
                        </div>   
                   
                 <div class="TdsExisting">
                            <asp:Label ID="lbl_Cstamount" runat="server" Text="Customer Amount"></asp:Label>
                            <asp:TextBox ID="txt_cstamt" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Customer Amount" placeholder="" Style="text-align: right"></asp:TextBox>
                        </div>                     
                 </div>                       

                                          
                 </div>
                           
                 <div class="FormGroupContent4">
                    <%-- <div class="Amount">
                            <div class="DISNone"><asp:Label ID="lbl_Amount1" runat="server" Text="Amount"></asp:Label></div>
                            <asp:TextBox ID="txt_amount" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="Amount" placeholder="Amount" Style="text-align: right"></asp:TextBox>
                        </div>--%>

                     <%--<div class="TdsCurrent">
                            <div class="DISNone"><asp:Label ID="lbl_tds" runat="server" Text="Tds"></asp:Label></div>
                            <asp:TextBox ID="txt_tds" runat="server" ReadOnly="True" CssClass="form-control" ToolTip="TdsCurrent" placeholder="TdsCurrent"  ontextchanged="txt_tdscurrent_TextChanged" ></asp:TextBox>
                        </div>--%>                                  
                     </div>
                
                 </div>
                </div>
            </div>
   
             <asp:HiddenField ID="hid_Customerid" runat="server" />

             <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>TDSRemoval #</label>

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


    <asp:Label ID="Label6" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label6" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>
 </asp:Content>
