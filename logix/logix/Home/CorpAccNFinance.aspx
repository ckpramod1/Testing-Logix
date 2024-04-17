<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorpAccNFinance.aspx.cs" EnableEventValidation="false" Inherits="logix.Home.CorpAccNFinance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css"/>

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css"/>
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css"/>
    <link href="../Theme/assets/css/systemhomedesign.css" rel="stylesheet" type="text/css" media="all"/>
    <link href="../Styles/Depositdetails.css" rel="stylesheet" />
    <!--=== JavaScript ===-->
    <%--<script src="../js/jsapi.js"></script>--%>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/lodash.compat.min.js"></script>

    <!-- Smartphone Touch Events -->
    <script type="text/javascript" src="../Theme/Content/plugins/touchpunch/jquery.ui.touch-punch.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/event.swipe/jquery.event.move.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/event.swipe/jquery.event.swipe.js"></script>
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
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
    <%--<script src="http://code.jquery.com/jquery-1.8.2.js"></script>

    <script src="http://www.google.com/jsapi" type="text/javascript"></script>--%>

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
    <style type="text/css">

        .BandTop {
    background-color: #656464;
    float: left;
    min-height: 32px;
    padding: 2px 2px 2px 5px;
    width: 100%;
}

.BandTop h3 a {
    color: #ffffff;
    font-family: sans-serif;
    font-size: 11px;
    margin: 0;
    padding: 2px 0;
}

.BandTop h3 {
    color: #ffffff;
    padding: 0px 5px 0px 5px;
    margin: 0px 0px 0px 0px;
}
.PaymentBox {

        width: 14.3%;
        min-height: 117px;
        background-color: #c4d79b;
        margin: 0px 0px 0px 0px;
        float: left;
      }


.PaymentBox h3 {
            color: #000000;
            padding: 5px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

.PaymentBox span {
            color: #000000;
            display: block;
            float: right;
            margin: 18px 10px 0px 0px;
            text-align: right;
            padding: 0px 0px 15px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }
.PaymentApprovalBox {

        width: 14.3%;
        min-height: 117px;
        background-color: #b1a0c7;
        margin: 0px 0px 0px 0px;
        float: left;
      }

.PaymentApprovalBox h3 {
            color: #000000;
            padding: 5px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }
.PaymentApprovalBox span {
            color: #000000;
            display: block;
            float: right;
            margin: 0px 10px 0px 0px;
            text-align: right;
            padding: 0px 0px 15px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }



.PaymentRequestBox {

        width: 14.3%;
        min-height: 117px;
        background-color: #92cddc;
        margin: 0px 0px 0px 0px;
        float: left;
      }


.PaymentRequestBox h3 {
            color: #000000;
            padding: 5px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

.PaymentRequestBox span {
            color: #000000;
            display: block;
            float: right;
            margin: 42px 10px 0px 0px;
            text-align: right;
            padding: 0px 0px 15px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }

.Grid {
    border: 1px solid #b1b1b1;
    border-collapse: collapse;
}

.Grid th {
    background-color: #003a65!important;
    border-right: 1px solid #edf8ff!important;
    border-top:1px solid #003a65!important;
    color: #ffffff!important;
    font-family: sans-serif!important;
    font-size: 12px!important;
    padding: 2px 5px!important;
}
        .Grid th:first-child {
            border-left:1px solid #003a65;

        }

   .Grid th:last-child {
            border-right:1px solid #003a65;

        }



.GrdAltRow {
    background-color: #cee9fd;
    color: Black;
    font-family: sans-serif;
    font-size: 8pt;
    margin-bottom: 0;
    margin-left: 4px;
}
.ApprovalBox {

        width: 14.3%;
        min-height: 117px;
        background-color: #fabf8f;
        margin: 0px 0px 0px 0px;
        float: left;
      }

.ApprovalBox h3 {
            color: #000000;
            padding: 5px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

.ApprovalBox span {
            color: #000000;
            display: block;
            float: right;
            margin: 42px 10px 0px 0px;
            text-align: right;
            padding: 0px 0px 15px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }


.CNAdminTDBox {

        width: 14.3%;
        min-height: 117px;
        background-color: #da9694;
        margin: 0px 0px 0px 0px;
        float: left;
      }


.CNAdminTDBox h3 {
            color: #000000;
            padding: 5px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

.CNAdminTDBox span {
            color: #000000;
            display: block;
            float: right;
            margin: 42px 10px 0px 0px;
            text-align: right;
            padding: 0px 0px 15px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }



        .BankBalanceBox {
            width: 14.3%;
        min-height: 117px;
        background-color: #948a54;
        margin: 0px 0px 0px 0px;
        float: left;

        }


.BankBalanceBox h3 {
            color: #000000;
            padding: 5px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

.BankBalanceBox span {
            color: #000000;
            display: block;
            float: right;
            margin: 42px 10px 0px 0px;
            text-align: right;
            padding: 0px 0px 15px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }







.PettycashBox {
            width: 14.1%;
        min-height: 117px;
        background-color: #bfbfbf;
        margin: 0px 0px 0px 0px;
        float: left;

        }
.PettycashBox h3 {
            color: #000000;
            padding: 5px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

.PettycashBox span {
            color: #000000;
            display: block;
            float: right;
            margin: 42px 10px 0px 0px;
            text-align: right;
            padding: 0px 0px 15px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
        }
        .PaymentCancel {
            width:130px;
            float:left;
            
        }
        .NovOverCheque {
            width:140px;
            float:left;
        }
           .VoucherRegister {
            width:140px;
            float:left;
        }

.SinceAudit {
            width:103px;
            float:left;
        }
.CustomerTDS {
            width:120px;
            float:left;
        }
.CostSheet {
            width:110px;
            float:left;
        }
        .CNOPS {
            width:72px;
            float:left;
            margin:5px 0px 0px 9px;
            color:#000000;
        }

        .CN {
            width:22px;
            float:left;
            margin:5px 0px 0px 0px;
            color:#000000;
        }
        .CNAdmin {
            width:67px;
            float:right;
            text-align:right;
            margin:5px 5px 0px 0px;
            color:#000000;
        }

           .CNApproval {
            width:22px;
            float:left;
            margin:5px 0px 0px 10px;
            color:#000000;
        }



        .CN1 {
            float:left;
            width:40px;
            margin:5px 0px 0px 5px;
            color:#000000;
        }
        .DN1 {
            float:right;
            width:40px;
            margin:5px 5px 0px 0px;
            color:#000000;
        }

        .CNopsCount1 {
            float:left;
            width:50px;
            margin:5px 0px 0px 10px;
        }

            .CNopsCount1 a {
                color:#000000!important;
                font-size:24px!important;
            }

            
        .CNopsBank2{
            float:right;         
            margin:12px 4px 0px 10px;
        }

            .CNopsBank2 a {
                color:#000000!important;
                font-size:24px!important;
            }


                    .CNopsBank1{
            float:right;
           margin:28px 8px 0px 10px;
        }

            .CNopsBank1 a {
                color:#000000!important;
                font-size:24px!important;
            }




        .CNopsCount2 {
            float:left;
            width:50px;
            margin:5px 0px 0px 10px;
            text-align:center;
        }

         .CNopsCount2 a {
                color:#000000!important;
                font-size:24px!important;
            }

        .CNopsCount3 {
              float:left;
            width:50px;
            margin:5px 0px 0px 10px;
            text-align:right;
        }

         .CNopsCount3 a {
                color:#000000!important;
                font-size:24px!important;
            }

                 .CNopsCount4 {
            float:left;
            width:50px;
            margin:5px 0px 0px 10px;
            text-align:center;
        }

         .CNopsCount4 a {
                color:#000000!important;
                font-size:24px!important;
            }

         
        .CNopsACount {
              float:right;
            width:50px;
            margin:5px 10px 0px 10px;
            text-align:right;
        }

         .CNopsACount a {
                color:#000000!important;
                font-size:24px!important;
            }






        .CNPetyCash {
             float:right;
            margin:12px 5px 0px 10px;
            width:134px;
            text-align:right;
        }
        .CNPetyCash a {
              color:#000000!important;
                font-size:24px!important;

        }



        .CNRequest {
            float:right;
            margin:29px 0px 0px 10px;
            width:50px;
        }

            .CNRequest a {
                color:#000000!important;
                font-size:24px!important;
            }


        .PadCtrlN {
            padding:10px 10px 10px 10px;
        }

                .div_Gridnew {
    width: 100%;
    margin-left: 0%;
    margin-bottom: 1%;
    margin-top: 0.1%;
    height: 356px;
    /*Border: 1px solid #b1b1b1;*/
    float: left;
    overflow: auto;
   
}
        .MB13 {
            margin:-4px 0px 0px 0px!important;

        }
        .CorpAccDate {
            width:16%;
            float:left;
            margin:0px 0.5% 0px 6px;
        }


.div_Grid {
    float: left;
    width: 44%;
    margin-left: 1%;
    margin-top: 0.5%;
     height:250px;
}

        .div_Grid1 {
            float: left;
    width: 50%;
    margin-left: 1%;
    margin-top: 0.5%;
    height:250px;
    overflow:auto;

        }

        .div_Left {
            float:left;
            width:49.5%;
            margin:0px 0.5% 0px 0px;

        }

        .div_Right {
            float:right;
            width:100%;

        }
        .DivRightC {
            float:right;
            width:35%;
            margin:0px;
        }
            .DivRightC h3 {
    color: #005b9a;
    font-family: sans-serif;
    font-size: 11px;
    font-weight: bold;
    margin: 0 0 10px 4px;}

        .MTR {
            margin:0px 27px 0px 0px;
        }
       
        .ChartCtrl {
            float:left;
            width:65%;
        }


        .Approval {
            float:left;
            width:50%;
            margin:0px;
        }
            .Approval h3 {
    color: #005b9a;
    font-family: sans-serif;
    font-size: 11px;
    font-weight: bold;
    margin: 15px 0 0px 15px;}








        .BankBalancetitle {
            width:300px;
            float:left;

        }


        .BankBalancetitle h3 {
             color: #005b9a;
    font-family: sans-serif;
    font-size: 11px;
    font-weight: bold;
    padding-left:0px;
    margin:0px;
        }

        .INRSympol {
            float:right;
            margin:-11px 10px 0px 0px;
            width:24px;
        }

        .div_GridA {
    float: left;
    width: 98.5%;
    margin-left: 1%;
    margin-top: 0.5%;
    height: 250px;
}


        .MRCtrl {
            margin-top:-10px;
            margin-right:8px;
        }

        .CNOPSnew {
            width:20px;
            float:left;
            margin:22px 0px 0px 22px;
            color:#000000;
        }
         .CNOPSnew1 {
            width:22px;
            float:left;
            margin:36px 0px 0px 21px;
            color:#000000;
        }
    </style>
    




    
</head>
<body>
    <form id="form1" runat="server">

         <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600">
        </asp:ScriptManager>
 <div class="BandMiddle"><div class="BreadLabel" id="OptionDoc" runat="server">Accounts And Finance</div></div>
        <div class="BandTop">
            <div class="PaymentCancel">
               <h3>
                    <img src="../Theme/assets/corporate/PaymentCancel_ic.png" />
                    <asp:LinkButton ID="link_button" runat="server" Text="Payment Cancel" OnClick="link_button_Click"></asp:LinkButton></h3>

            </div>
            <div class="NovOverCheque">
                <h3>
                    <img src="../Theme/assets/corporate/overcheque_ic.png" />
                    <asp:LinkButton ID="LinkButton4" runat="server" Text="Not Over Cheque" OnClick="LinkButton4_Click"></asp:LinkButton></h3>

            </div>
            <div class="VoucherRegister">
                <h3>
                    <img src="../Theme/assets/corporate/voucherregister.png" />
                  
                      <asp:LinkButton ID="LinkButton5" runat="server" Text="Voucher Register" OnClick="LinkButton5_Click"></asp:LinkButton></h3>
                


            </div>
            <div class="SinceAudit">

                <h3>

                    <img src="../Theme/assets/corporate/sinceaudit_ic.png" />
                 
                   <asp:LinkButton ID="LinkButton6" runat="server" Text="Since Audit" OnClick="LinkButton6_Click"></asp:LinkButton></h3>
            </div>

            <div class="CustomerTDS">
                <h3>
                    <img src="../Theme/assets/corporate/customer_Profile.png" />
                  
                <asp:LinkButton ID="LinkButton7" runat="server" Text="Customer TDS" OnClick="LinkButton7_Click"></asp:LinkButton></h3>

            </div>
            <div class="CostSheet">
                <h3>
                    <img src="../Theme/assets/corporate/exemptionlisits.png" />
                 
                  <asp:LinkButton ID="LinkButton8" runat="server" Text="Cost Sheet" OnClick="LinkButton8_Click"></asp:LinkButton></h3>
            </div>
        </div>
        
        
        <div class="HomeMenuBox">
           
              <div class="PaymentBox">
                 
                <asp:LinkButton ID="link_payment" runat="server">
                <h3>
                    <img src="../Theme/assets/corporate/payment_ic.png" /> Payments</h3>
                     
                   <div class="Clear"></div>                        
              
                <%--<span id="span_cnops1" runat="server" class="cnops">58</span>
                 <span id="span_cn1" runat="server" class="cn">58</span>
                 <span id="span_cnadmin1" runat="server" class="cnadmin">58</span>--%>
                     <div class="CNOPS">CN Ops</div>
                        <div class="CN">CN</div>
                         <div class="CNAdmin"> CN Admin</div>
                    <div class="Clear"></div>
                <div class="CNopsCount1"><asp:LinkButton ID="link_CNOP" runat="server"  OnClick="link_CNOP_Click">CN Ops</asp:LinkButton></div>
                <div class="CNopsCount2"><asp:LinkButton ID="link_cnn" runat="server"  OnClick="link_cnn_Click">CN</asp:LinkButton></div>
                <div class="CNopsCount3"><asp:LinkButton ID="link_cnadmins" runat="server" OnClick="link_cnadmins_Click">CN Admin</asp:LinkButton></div>
                    <div class="Clear"></div>
                      
                </asp:LinkButton>
            </div>   



            <%--<div class="PaymentBox">
                 
                
                <h3>Payments</h3>
                     
                   <div class="Clear"></div>                        
                <div class="CNOPS"><asp:LinkButton ID="lnl_CkCnopsRq" runat="server" OnClick="lnl_CkCnopsRq_Click">CN Ops</asp:LinkButton></div>
                <div class="CN"><asp:LinkButton ID="lnk_ChCnRq" runat="server" OnClick="lnk_ChCnRq_Click">CN</asp:LinkButton></div>
                <div class="CNAdmin"><asp:LinkButton ID="lnk_ChCnRqadmin" runat="server" OnClick="lnk_ChCnRqadmin_Click">CN Admin</asp:LinkButton></div>
               <span id="span_cnops1" runat="server"  class="cnops"></span>
                 <span id="span_cn1" runat="server" class="cn"></span>
                 <span id="span_cnadmin1" runat="server" class="cnadmin"></span>
                    <div class="Clear"></div>

             
                  

            </div>--%>
             
               
         
            <div class="PaymentApprovalBox" runat="server">
                <asp:LinkButton ID="lnkpaymentapproval" runat="server">
                 <h3>
                     <img src="../Theme/assets/corporate/paymentapproval_ic.png" /> Payment Approval</h3>
               <%--  <span id="span_cnops" runat="server"  class="cnops"></span>
                 <span id="span_cn" runat="server" class="cn"></span>
                 <span id="span_cnadmin" runat="server" class="cnadmin"></span>--%>
                       <div class="CNOPS">CN Ops</div>
                        <div class="CN">CN</div>
                         <div class="CNAdmin">CN Admin</div>
                    <div class="Clear"></div>
                <div class="CNopsCount1"><asp:LinkButton ID="Link_CNOPS" runat="server" OnClick="Link_CNOPS_Click">CN Ops</asp:LinkButton></div>
                <div class="CNopsCount2"><asp:LinkButton ID="Link_CN" runat="server" OnClick="Link_CN_Click">CN</asp:LinkButton></div>
                <div class="CNopsCount3"><asp:LinkButton ID="link_CNADmin" runat="server" OnClick="link_CNADmin_Click">CN Admin</asp:LinkButton></div>
                </asp:LinkButton>


            </div>
             
            <a href="#">
            <div class="PaymentRequestBox">
                <asp:LinkButton ID="Lnk_payment" runat="server">
                 <h3>
                     <img src="../Theme/assets/corporate/paymentrequest_ic.png" /> Payment Request</h3>
                     <div class="CNOPS">CN Ops</div>
                        <div class="CNAdmin">CN</div>
                       <div class="Clear"></div>
                      <div class="CNopsCount1"><asp:LinkButton ID="link_CNADminreq" runat="server" OnClick="link_CNADminreq_Click" >CN Ops</asp:LinkButton></div>
                      <div class="CNopsACount"><asp:LinkButton ID="link_cnpayreq" runat="server" OnClick="link_cnpayreq_Click" >CN</asp:LinkButton></div>
                     
                  <div class="CNRequest" style="display:none;"><asp:LinkButton ID="Lnk_paymentreq" runat="server" OnClick="Lnk_paymentreq_Click"></asp:LinkButton></div>
              <%--  <span>65</span>--%>
                    </asp:LinkButton>

            </div>
                </a>
            <a href="#">
           <div class="ApprovalBox">
                <asp:LinkButton ID="link_approval" runat="server">
                 <h3>
                     <img src="../Theme/assets/corporate/approval_ic.png" /> Approval</h3>
                 <%--<div class="CN1">CN</div>
                <div class="DN1">DN</div>--%>
               <%-- <span>78</span>--%>
                  <div class="CNApproval">CN</div>
                   <div class="CNAdmin">CN Admin</div>
                    <div class="Clear"></div>
                <div class="CNopsCount1"><asp:LinkButton ID="Link_approvalDN" runat="server" OnClick="Link_approvalDN_Click" >CN Ops</asp:LinkButton></div>
                <div class="CNopsACount"><asp:LinkButton ID="Link_ApprovalCN" runat="server" OnClick="Link_ApprovalCN_Click" >CN</asp:LinkButton></div>

                </asp:LinkButton>
            </div>
                </a>
             <a href="#">
            <div class="CNAdminTDBox">
                <asp:LinkButton ID="Lltds" runat="server">
                <h3>
                    <img src="../Theme/assets/corporate/admin_tds.png" /> CN Admin TDS</h3>
                              <div class="CNopsBank1"><asp:LinkButton ID="lbltds" runat="server" OnClick="lbltds_Click">CN Admin TDS</asp:LinkButton></div>

               </asp:LinkButton>

            </div>
                 </a>
            <a href="#">
            <div class="BankBalanceBox">
                <asp:LinkButton ID="Lnk_BankBal1" runat="server">
                  
                 <h3> <img src="../Theme/assets/corporate/bankbalance.png" /> Bank Balance</h3>
                    <div class="INRSympol">
                    <img src="../Theme/assets/img/rupees_ic.png" /></div>
                    <div class="Clear"></div>
                      <div class="CNOPSnew" id="id_bnk" runat="server"></div>
              <div class="CNopsBank2"><asp:LinkButton ID="Lnk_BankBal" runat="server" OnClick="Lnk_BankBal_Click">Bank Balance</asp:LinkButton></div>

               </asp:LinkButton>

            </div>
                
                </a>
            <a href="#">
            <div class="PettycashBox">
                <asp:LinkButton ID="lnk_PCBal1" runat="server">
                <h3>
                    <img src="../Theme/assets/corporate/pettycash_balance.png" /> Petty Cash Balance</h3>
                     <div class="INRSympol">
                    <img src="../Theme/assets/img/rupees_ic.png" /></div>
                     <div class="CNOPSnew1" id="lbl_pcb" runat="server"></div>
                 <div class="CNPetyCash"><asp:LinkButton ID="lnk_PCBal" runat="server" OnClick="lnk_PCBal_Click">Petty Cash Balance</asp:LinkButton></div>
                 
                    </asp:LinkButton>
            </div>
                </a>
        </div>

        <div runat="server" id="div_DnCnApp" visible="false">

                            <div class="Approval">
                                <h3>
                                    <asp:Label ID="lblHead" runat="server" Text=""></asp:Label></h3>
                            </div>
                            <div class="widget-content">
                                
                                <div class="FormGroupContent4">
                                    <div class="div_GridA">
                                        <asp:GridView ID="Grd_Admin" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader" 
                                            Width="100%" ForeColor="Black"  OnRowDataBound="Grd_Admin_RowDataBound"
                                            DataKeyNames="vouyear,vouno" ShowHeaderWhenEmpty="True">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S#">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="vouno" HeaderText="ProRef #" />
                                                <asp:BoundField DataField="refno" HeaderText="Ref #" />
                                                <asp:BoundField DataField="customer" HeaderText="Customer" />
                                                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="preparedby" HeaderText="Prepared by" />
                                                <asp:TemplateField HeaderText="Approve">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Chk_Approval" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <%-- <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="Lnk_Approval" runat="server" CommandName="select" Font-Underline="false"
                        CssClass="Arrow">?</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </div>

                                </div>
                                <div class="FormGroupContent4">
                                    <div class="right_btn MRCtrl">
                                        <div class="btn btn-approve1">
                                            <asp:Button ID="btn_Approve" runat="server" ToolTip="Approve" OnClick="btn_Approve_Click" />
                                        </div>
                                        <div class="btn ico-cancel" id="btn_cancel11" runat="server">
                                            <asp:Button ID="btn_cancel1" runat="server" ToolTip="Cancel" OnClick="btn_cancel1_Click"  />
                                        </div>
                                    </div>


                                </div>
                            </div>

                        </div>



                                 <div class="FormGroupContent4">
                                     <div class="PadCtrlN" runat="server" id="Bankbalancetitle">
                                         <div class="BankBalancetitle"><h3>Bank Balance</h3></div>
                                           <div class="right_btn MB13 MBC2">
                                     <asp:LinkButton ID="lnk_Grid_bankbalance" runat="server" OnClick="lnk_Grid_bankbalance_Click"  Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                                     </asp:LinkButton>                         
                                    <div style="clear:both;"></div>
                                </div>
                                     <div class="div_Gridnew" runat="server" id="GridbankBNL">
                                        <asp:GridView ID="Grid_bankbalance" runat="server" AutoGenerateColumns="true" CssClass="Grid FixedHeader" 
                                            Width="100%" ForeColor="Black"  ShowHeaderWhenEmpty="True" OnRowDataBound="Grid_bankbalance_RowDataBound">
                                            <Columns>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                  
                                       
                                    </div>
                                         </div>
            </div>

        <div class="FormGroupContent4">
            <div class="PadCtrlN" runat="server" id="PettyCash">
                                         <div class="BankBalancetitle"><h3>Petty Cash Balance</h3></div>
                 <div class="right_btn MB13 MBC2">
                                     <asp:LinkButton ID="lnk_Grid_cashbalance" runat="server" OnClick="lnk_Grid_cashbalance_Click"  Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                                     </asp:LinkButton>                         
                                    <div style="clear:both;"></div>
                                </div>

                 <div class="div_Gridnew" runat="server" id="PettyCashBalance">
             <asp:GridView ID="Grid_cashbalance" runat="server" AutoGenerateColumns="true" CssClass="Grid FixedHeader" 
                                            Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="True" OnRowDataBound="Grid_cashbalance_RowDataBound">
                                            <Columns>
                                               
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
            </div>
                </div>
            </div>


        <div class="DivRightC" id="frmdeopositdetails" runat="server">


    
                  <h3><asp:Label ID="lbl_Header" runat="server" Text="Deposit Details" CssClass="lbl_Header"></asp:Label></h3>
        
            
                <div class="FormGroupContent4">
                    
                    <div class="div_Right">
                        <div style="display:none;">
                     <asp:Label ID="lbl_date" runat="server" Text="Date" CssClass="LabelValue"></asp:Label>

                 </div>
                 <div class="CorpAccDate">
                     <asp:TextBox ID="txt_date" runat="server" CssClass="form-control" ToolTip="Date" BorderColor="#999997"></asp:TextBox>
                     <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_date"
                                Format="dd/MM/yyyy"></asp:CalendarExtender>


                 </div>
                 <div class="btn ico-get">
                     <asp:Button ID="btn_Get" runat="server" ToolTip="Get" onclick="btn_Get_Click" />
                 </div>
                       <div class="Clear"></div>
                    <div class="div_Grid">
        <asp:GridView CssClass="Grid FixedHeader"  ID="Grd_Deposit" runat="server" Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="true"
            PageSize="15" EmptyDataText="No Record Found"
        AutoGenerateColumns="False" DataKeyNames="id" 
        onrowdatabound="Grd_Deposit_RowDataBound" 
        onselectedindexchanged="Grd_Deposit_SelectedIndexChanged">
            <Columns>
           
               <%-- <asp:TemplateField HeaderText="S.No">
                <ItemTemplate>
                <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
                
                </asp:TemplateField>--%>
           
                <asp:BoundField DataField="branch" HeaderText="Branch">
                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="amount" HeaderText="Amount" 
                    DataFormatString="{0:#,##0.00}"  NullDisplayText="0.00" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
               <%-- <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Lnk_Deposit" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                        <br />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
        </asp:GridView>
  
        </div>
                    <div class="div_Grid1" id="grdViewDetails" runat="server"  visible="false">
        <asp:GridView CssClass="Grid FixedHeader"  ID="Grd_detail" runat="server" Width="100%" ForeColor="Black" Visible="false"
            PageSize="15" ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found"
        AutoGenerateColumns="False" DataKeyNames="slipid,branchid" 
        onrowdatabound="Grd_detail_RowDataBound">
            <Columns>
           
                <asp:TemplateField HeaderText="S.No">
                <ItemTemplate>
                <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
                
                </asp:TemplateField>
           
                <asp:BoundField DataField="slipno" HeaderText="Slip#">
                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                 <asp:BoundField DataField="chequeno" HeaderText="Cheque#">
                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" itemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
               
            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
        </asp:GridView>
    
        </div>
                        </div>
                    </div>
              <div class="FormGroupContent4">
                  <div class="right_btn MT0 MTR">
                      <div class="btn ico-cancel" id="btn_cancelid1" runat="server"><asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" onclick="btn_cancel_Click" visible="false"/></div>
                      

                  </div>

              </div>
              
           
            </div>
        <div class="ChartCtrl" id="chart1" runat="server">
        <asp:Literal ID="lt" runat="server"></asp:Literal>
            <div id="Liner_chart_div"></div>
            </div>

        <asp:HiddenField ID="hid_type" runat="server" />

    </form>
</body>
</html>
