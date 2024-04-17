<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorpCreditControl.aspx.cs" EnableEventValidation="false" Inherits="logix.Home.CorpCreditControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css"/>
    <link href="../Styles/PlotOut.css" rel="stylesheet" />
       <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
       <script src="../Scripts/Validation.js" type="text/javascript"></script>
        <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
        <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />

        <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css">
    <link href="../Theme/assets/css/systemhomedesign.css" rel="stylesheet" type="text/css" media="all" />
      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <!--=== JavaScript ===-->
    <script type="text/javascript" src="https://www.google.com/jsapi"></script> 
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap.min.js"></script>
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>
    
    <!-- Page specific plugins -->
    <!-- Charts -->

    <!-- Forms -->
    <!-- AutoComplete -->
    <!-- Styled radio and checkboxes -->
    <!-- Styled select boxes -->

    <!-- Globalize -->

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

  <%--   <script type="text/javascript" language="javascript" >
         function pageLoad(sender, args) {
             $(document).ready(function () {
                 $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
             });
         }
     </script>--%>
      <script type="text/javascript" language="javascript">
          xAddEventListener(window, 'load',
         function () { new xTableHeaderFixed('gvTheGrid', 'table-container', 0); }, false);


          function TxtFocus() {
              var el = $("#<%=txtbname.ClientID %>").get(0);
              var elemLen = el.value.length;
              el.selectionStart = elemLen;
              el.selectionEnd = elemLen;
              el.focus();
          }

          function GetDetail() {
              $.ajax({
                  type: "POST",
                  url: "CorpCreditControl.aspx/GetEmpName",
                  data: '{Prefix: "' + $("#<%=txtbname.ClientID %>").val() + '" }',
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


    <script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script> 




   <style type="text/css">
   
        .BandTop {
    background-color: #656464;
    float: left;
    min-height: 32px;
    padding: 2px 2px 2px 5px;
    width: 100%;
}

           .BandTop h3 {
               margin:5px 0px 5px 0px;
               padding:0px 0px 0px 0px;
           }




.BandTop h3 a {
    color: #ffffff;
    font-family: sans-serif;
    font-size: 11px;
    margin: 0;
    padding: 2px 0;
}


.CreditBox {

        width: 14.3%;
        min-height: 117px;
        background-color: #c4d79b;
        margin: 0px 0px 0px 0px;
        float: left;
      }


.CreditBox h3 {
            color: #000000;
            padding: 5px 0px 0px 4px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

.CreditBox span {
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
.DSOBox {

        width: 14.3%;
        min-height: 117px;
        background-color: #b1a0c7;
        margin: 0px 0px 0px 0px;
        float: left;
      }

.DSOBox h3 {
            color: #000000;
            padding: 10px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }
.DSOBox span {
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



.CreditALBox {

        width: 14.3%;
        min-height: 117px;
        background-color: #92cddc;
        margin: 0px 0px 0px 0px;
        float: left;
      }


.CreditALBox h3 {
            color: #000000;
            padding: 10px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

.CreditALBox span {
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


.ExemptionBox {

        width: 14.3%;
        min-height: 117px;
        background-color: #fabf8f;
        margin: 0px 0px 0px 0px;
        float: left;
      }

.ExemptionBox h3 {
            color: #000000;
            padding: 10px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

.ExemptionBox span {
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


.CustomerBox {

        width: 14.3%;
        min-height: 117px;
        background-color: #da9694;
        margin: 0px 0px 0px 0px;
        float: left;
      }


.CustomerBox h3 {
            color: #000000;
            padding: 10px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

.CustomerBox span {
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

        .OutBox {
            width: 14.3%;
        min-height: 117px;
        background-color: #948a54;
        margin: 0px 0px 0px 0px;
        float: left;

        }


.OutBox h3 {
            color: #000000;
            padding: 10px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

.OutBox span {
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
.OverBox {
            width: 14.2%;
        min-height: 117px;
        background-color: #bfbfbf;
        margin: 0px 0px 0px 0px;
        float: left;

        }
.OverBox h3 {
            color: #000000;
            padding: 10px 0px 0px 9px;
            margin: 0px;
            font-family: "Segoe UI";
            font-size: 14px;
            font-weight: normal;
        }

.OverBox span {
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
            width:152px;
            float:left;
            
        }
        .NovOverCheque {
            width:90px;           
            float:left;
        }
           .VoucherRegister {
            width:120px;           
            float:left;
        }

.SinceAudit {
            width:202px;
            float:left;
        }
.CustomerTDS {
            width:236px;
           float:left;
        }
.CostSheet {
            width:167px;             
            float:left;
        }
           .PendingTblGridNewOutW1 {
            border: 1px solid #b1b1b1;
            border-collapse: collapse;
            width:100%!important;
                        
        }

        

            .PendingTblGridNewOutW1 th {
                text-align: left;
                color: #ffffff;
                font-size: 11px;
                font-family: sans-serif, Geneva, sans-serif;
                background-color: #003a65;
                padding: 5px 2px 5px 3px;
                margin: 0px;
                border-right:1px solid #edf8ff;
                border-top:1px solid #003a65;
            }

            .PendingTblGridNewOutW1 th:last-child {border-right:1px solid #003a65;

            }

             .PendingTblGridNewOutW1 th:first-child {border-left:1px solid #003a65;

            }

            .PendingTblGridNewOutW1 td {
                font-size:12px;
                color:#4e4e4c;


            }

     .CreditRequestTbl {
          border: 1px solid #003a65;
            border-collapse: collapse;
            width:100%!important;
            margin:10px 0px 0px 0px;
            height:376px;
            overflow:auto;
     }

           .CreditRequestTbl th {
                text-align: center;
                color: #ffffff;
                font-size: 11px;
                font-family: sans-serif, Geneva, sans-serif;
                background-color: #003a65;
                padding: 5px 2px 5px 3px;
                margin: 0px;
                border-right:1px solid #edf8ff;
                border-left:1px solid #edf8ff;
                border-top:1px solid #003a65;
            }
          .GrdAltRow
{
    background-color:#cee9fd;
   font-family:sans-serif;
    font-size:10pt;
     color:Black;
    margin-left: 4px;
    margin-bottom: 0px;
    
}

 .CNOPS {
    color: #000000;
    float: right;
    margin: 35px 5px 0px 9px;
    width: auto;
}    
 
 .CNOPS a {
    color: #000000;
    font-size: 24px;
}

     .CNDSO {
         color: #000000;
    float: left;
    margin: 8px  0 0 9px;
    width: -1px;
     }
     .CNDSO a {
    color: #000000;
    font-size: 11px;
}
         .CNDSO a img {
             padding:0px 2px 0px 0px;
         }



     .INRSympol {
         float:right;
         margin:0px 12px 0px 0px;
     }


.CNLink {
    color: #000000;
    float: right;
    margin: 9px 10px 0 0px;
   
     }

     .CNLink a {
    color: #000000;
    font-size: 24px;
}
     .CNExemption {
    color: #000000;
    float: right;
    margin: 30px 10px 0 0px;

     }
     .CNExemption a {
    color: #000000;
    font-size: 24px;
}

     .CNPro {
    color: #000000;
    float: right;
    margin: 9px  32px 0 0px;

     }
     .CNPro a {
    color: #000000;
    font-size: 13px;
}

     .CNOutstanding {
    color: #000000;
    float: right;
    margin: 7px 10px 0 0px;
     }
          .CNOutstanding a {
    color: #000000;
    font-size: 22px;
}

     .CNOverDue {
         color: #000000;
    float: right;
    margin: 7px 10px 0 0px;
     }

      .CNOverDue a {
    color: #000000;
    font-size: 22px;
}
     .PanelPadCtrl {
         padding:10px;
         float:left;
         width:100%;
     }
     .PanelPadCtrloverdue {
         padding:10px;
         float:left;
         width:100%;
     }
     .widget.box {
    border: 1px solid #d9d9d9;
    float: left;
    margin-left: 0;
    padding: 10px;
    width: 100%;
}
     #table-container {
         width:100%;
         height:276px;
         overflow:auto;
     }
     #Panel4 {
         width:99%;
         float:left;
         height:382px;
         overflow:auto;
     }

     .MB13 {
         margin-bottom:2px;
     }



     #Panel3 {
          width:99%;
         float:left;        
         height:351px;
         overflow:auto;
     }

     #Panel2 {
          width:99%;
         float:left;        
         height:333px;
         overflow:auto;
     }

   
     .CreditReqLBL {
    color: #4e4c4c;
    font-family: sans-serif;
    font-size: 11px;
    font-weight: bold;
    float:left;
    width:350px;
    margin:8px 0px 0px 0px;
}

     .DSODaysLBL {
         color:#4e4c4c;
         font-family:sans-serif;
         font-size:12px;
         font-weight:bold;
     }

     .PendingTblGridNewOutW1 td {
         border:1px solid #b1b1b1;

     }


     .chart
     {
       margin-top: 215px;
    width: 96%;
    margin-left: 32px;
    height: 310px;
     }

     .GridDSO th {
    background-color: #003a65;
    border-right: 1px solid #51789d;
    color: #ffffff;
    font-family: tahoma;
    font-size: 11px;
    padding: 2px 5px;
}

     .GridDSO th a {
         color:#ffffff;
     }


     .GridDSO td {
         font-size:12px;
     }
     .MBctrl {
         margin:0px 0px 5px 0px;
     }

     #div_dsoday11 {
         width:100%;
         padding:10px;
         float:left;
     }
     .GrdAltRow {
         color:#4e4c4c;
         border:1px solid #b1b1b1;
         
     }

     .CreditRequestTbl td {
         border:1px solid #b1b1b1;
     }
     .GridDSO td {
         border:1px solid #b1b1b1;
     }


      .BlueOuterDiv {
    color: #fff;
    border-radius: 5px;
    border: 1px solid #e3e6f0;
    border-left: .25rem solid #4e73df!important;
    float: left;
    background-color: #fff;
    height: 110px;
    padding: 15px 0px 5px 0px;
    width: 185px;
    margin: 5px 8px 0px 12px;
}

            .BlueOuterDiv:hover {
    box-shadow: 1px 4px 20px grey;
    -webkit-transition: box-shadow .3s ease-in;
}


               .BlueText {
    width: 90%;
    font-size: 14px;
    font-family: 'OpenSansSemibold';
    margin: 0px 0px 30px 15px;
    float: left;
        color: #4e73df !important;
        
    }

.BlueRightSideDown {
    color: #4e73df !important;
    font-family: 'OpenSansSemibold';
    margin: 5px 10px 0px 0px;
    float: right;
    text-align: right;
    width: 75%;
    font-size: 22px!important;
}


.GreenOuterDiv
{
    color: #fff;
    border-radius: 5px;
    border: 1px solid #e3e6f0;
    border-left: .25rem solid #1cc88a!important;
    float: left;
    background-color: #fff;
    height: 110px;
    padding: 15px 0px 5px 0px;
    width: 185px;
    margin: 5px 8px 0px 0px;
}


     .GreenOuterDiv:hover {
     box-shadow: 1px 4px 20px grey;
    -webkit-transition: box-shadow .3s ease-in;
}
     .GreenText
     {
             width:90%;
    font-size: 14px;
    font-family: 'OpenSansSemibold';
    margin: 0px 0px 35px 15px;
    float: left;
    color: #1cc88a !important;
     }

     .GreenRightSideDown {

    color: #1cc88a!important;
    margin: 0px 10px 0px 0px;
    font-family: 'OpenSansSemibold';
    float: right;
    font-size: 22px!important;
    width: 75%;
    text-align: right;
}

     .LiteBlueOuter
{
    color: #fff;
    border-radius: 5px;
    border: 1px solid #e3e6f0;
    border-left: .25rem solid #36b9cc!important;
    float: left;
    background-color: #fff;
    height: 110px;
    padding: 15px 0px 5px 0px;
    width: 185px;
    margin: 5px 8px 0px 0px;
}


     .LiteBlueOuter:hover {
     box-shadow: 1px 4px 20px grey;
    -webkit-transition: box-shadow .3s ease-in;
}

      .LiteBlueText
 {
        width:90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 35px 15px;
        float: left;
        color: #36b9cc !important;
 }

       .LtBlueRightSideDown
 {
     color: #36b9cc!important;
    margin: 0px 10px 0px 0px;
    font-family: 'OpenSansSemibold';
    float: right;
    font-size: 22px!important;
    width: 75%;
    text-align: right;
 }

       .YellowOuterDiv
{
    color: #fff;
    border-radius: 5px;
    border: 1px solid #e3e6f0;
    border-left: .25rem solid #f6c23e!important;
    float: left;
    background-color: #fff;
    height: 110px;
    padding: 15px 0px 5px 0px;
    width: 185px;
    margin: 5px 8px 0px 0px;
}

     .YellowOuterDiv:hover {
     box-shadow: 1px 4px 20px grey;
    -webkit-transition: box-shadow .3s ease-in;
}

         .YellowText
    {
    width:90%;
    font-size: 14px;
    font-family: 'OpenSansSemibold';
    margin: 0px 0px 35px 15px;
    float: left;
    color: #f6c23e !important;
    }


         
 .YellowRightSideDown
 {
      color: #f6c23e!important;
    margin: 0px 10px 0px 0px;
    font-family: 'OpenSansSemibold';
    float: right;
    font-size: 22px!important;
    width: 75%;
    text-align: right;
    /*transform: rotate(-179deg);*/
 }

 .GreenOuterDiv2
{
    color: #fff;
    border-radius: 5px;
    border: 1px solid #e3e6f0;
    border-left: .25rem solid #1cc88a!important;
    float: left;
    background-color: #fff;
    height: 110px;
    padding: 15px 0px 5px 0px;
    width: 185px;
    margin: 5px 8px 0px 0px;
}

    .GreenOuterDiv2:hover {
    box-shadow: 1px 4px 20px grey;
    -webkit-transition: box-shadow .3s ease-in;
}

        .GreenText2
        {
        width:90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 35px 15px;
        float: left;
        color: #1cc88a!important;
        }


         .GreenRightSideDown2
 {
     color: #1cc88a!important;
    margin: 0px 10px 0px 0px;
    float: right;
    font-family: 'OpenSansSemibold';
    font-size: 22px!important;
    width: 75%;
    text-align: right;
 }


         .BlueOuterDiv2
{
    color: #fff;
    border-radius: 5px;
    border: 1px solid #e3e6f0;
    border-left: .25rem solid #4e73df!important;
    float: left;
    background-color: #fff;
    height: 110px;
    padding: 15px 0px 5px 0px;
    width: 185px;
    margin: 5px 8px 0px 0px;
}


        .BlueOuterDiv2:hover {
     box-shadow: 1px 4px 20px grey;
    -webkit-transition: box-shadow .3s ease-in;
}


                .Blue2Text
        {
        width:90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 30px 15px;
        float: left;
        color: #4e73df !important;
        }

                
         .Blue2RightSideDown
 {
     color: #4e73df!important;
     font-family: 'OpenSansSemibold';
    margin: 0px 10px 0px 0px;
    float: right;
    font-size: 22px!important;
    width: 90%;
    text-align: right;
 }

         .RedOuterDiv
{
     color: #fff;
    border-radius: 5px;
    border: 1px solid #e3e6f0;
    border-left: .25rem solid #e74a3b!important;
    float: left;
    background-color: #fff;
    height: 110px;
    padding: 15px 0px 5px 0px;
    width: 185px;
    margin: 5px 8px 0px 0px;
}

        .RedOuterDiv:hover {
    box-shadow: 1px 4px 20px grey;
    -webkit-transition: box-shadow .3s ease-in;
}



        .RedText
        {
        width:90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 30px 15px;
        float: left;
        color: #e74a3b !important;
        }



 .RedRightSideDown
 {
          color: #e74a3b!important;
    margin: 0px 10px 0px 0px;
    font-family: 'OpenSansSemibold';
    float: right;
    font-size: 22px!important;
    width: 90%;
    text-align: right;
 }


 form#form1 {
    background: #f8f9fc !important;
}

 .Divimg {
    float: right;
    width: 12%;
    margin: 0px 0px 0px 10px;
}
    </style> 


</head>
<body>
    
    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600">
        </asp:ScriptManager>--%>
    <form id="form1" runat="server">
   
           

    <div class="BandMiddle"><div class="BreadLabel" id="OptionDoc" runat="server">Credit Control</div></div>
        <div class="BandTop">
            <div class="PaymentCancel">
               <h3>
                    <img src="../Theme/assets/corporate/PaymentCancel_ic.png" />
                    <asp:LinkButton ID="formpaymentcancel" runat="server" Text="Credit Approval limits" OnClick="formpaymentcancel_Click"></asp:LinkButton></h3>

            </div>
            <div class="NovOverCheque">
                <h3>
                    <img src="../Theme/assets/corporate/overcheque_ic.png" />
                    <asp:LinkButton ID="formnotover" runat="server" Text="DSO Days" OnClick="formnotover_Click"></asp:LinkButton></h3>

            </div>
            <div class="VoucherRegister">
                <h3>
                    <img src="../Theme/assets/corporate/voucherregister.png" />
                  
                      <asp:LinkButton ID="formvoureg" runat="server" Text="Credit Approval" OnClick="formvoureg_Click"></asp:LinkButton></h3>
                


            </div>
            <div class="SinceAudit">

                <h3>

                    <img src="../Theme/assets/corporate/sinceaudit_ic.png" />
                 
                   <asp:LinkButton ID="formsince" runat="server" Text="Credit Exemption Limit - Branch" OnClick="formsince_Click"></asp:LinkButton></h3>
            </div>

            <div class="CustomerTDS">
                <h3>
                    <img src="../Theme/assets/corporate/customer_Profile.png" />
                  
                <asp:LinkButton ID="formtds" runat="server" Text="Master Rating - Billing/Profit/Payment" OnClick="formtds_Click"></asp:LinkButton></h3>

            </div>
            <div class="CostSheet">
                <h3>
                    <img src="../Theme/assets/corporate/exemptionlisits.png" />
                 
                  <asp:LinkButton ID="formcost" runat="server" Text="Master Credit Exemption" OnClick="formcost_Click"></asp:LinkButton></h3>
            </div>
            <div class="CostSheet">
                <h3>
                    <img src="../Theme/assets/corporate/exemptionlisits.png" />
                 
                  <asp:LinkButton ID="CustomerRating" runat="server" Text="Customer Rating" OnClick="CustomerRating_Click"></asp:LinkButton></h3>
            </div>
        </div>
        <div class="HomeMenuBox">
            <a href="#">
            <div class="BlueOuterDiv">


                <asp:LinkButton ID="Lnk_Credit1" runat="server" OnClick="Lnk_Credit_Click">            
                  <div class="BlueText"> Credit Request</div>
                      
                  <asp:LinkButton ID="Lnk_Credit" runat="server"  CssClass="BlueRightSideDown" OnClick="Lnk_Credit_Click">Credit Request</asp:LinkButton>
           
                    </asp:LinkButton>
              

            </div>
                </a>
            <a href="#">
            <div class="GreenOuterDiv">
                
                <asp:LinkButton ID="Link_dso1" runat="server">
              
                      <asp:LinkButton ID="Link_dso" runat="server" CssClass="GreenText" OnClick="Link_dso_Click"> DSODays</asp:LinkButton>
           
                    </asp:LinkButton>

              <%--  <a href="../Corporate/CreditApprovelLimits.aspx">../Corporate/CreditApprovelLimits.aspx</a>--%>
            </div> </a>
               
            <a href="#">
            <div class="LiteBlueOuter">

                <asp:LinkButton ID="LinkCAlimit1" runat="server"  OnClick="LinkCAlimit1_Click">   
                <div class="LiteBlueText">Credit Approval</div>
                      <div class="INRSympol" style="display:none;">
                    <img src="../Theme/assets/img/rupees_ic2.png" /></div>
                    <div class="Clear"></div>
                  <div class="CNLink" style="display:none;"><asp:LinkButton ID="LinkCAlimit" runat="server"  OnClick="LinkCAlimit_Click">Credit Approval</asp:LinkButton></div>
           
                    </asp:LinkButton>
                
                <%--<span>65</span>--%>

            </div>
                </a>
            <a href="#">
            <div class="YellowOuterDiv">
                
                 <asp:LinkButton ID="link_exce"  runat="server" OnClick="Linkexcemption_Click">
                   <div class="YellowText">  Exemption</div>
               <asp:LinkButton ID="Linkexcemption" CssClass="YellowRightSideDown" runat="server" OnClick="Linkexcemption_Click">Exemption</asp:LinkButton>
        
                </asp:LinkButton>

            </div>
                </a>
             <a href="#">
            <div class="GreenOuterDiv2">
             
                
                      <asp:LinkButton ID="Linkcuspro" runat="server"  CssClass="GreenText2" OnClick="Linkcuspro_Click">Customer Profile</asp:LinkButton>
             
            </div>
                 </a>
            <a href="#">
            <div class="BlueOuterDiv2">


                 <asp:LinkButton ID="LinkOutstanding1" runat="server" OnClick="LinkOutstanding_Click">    
                    <div class="Blue2Text">

                   Sales Outstanding
                       <div class="Divimg"> <i class="fa fa-inr"  style="font-size: 25px;color:#4e73df;"></i></div>

                   </div>
              <asp:LinkButton ID="LinkOutstanding"  CssClass="Blue2RightSideDown" runat="server" OnClick="LinkOutstanding_Click">Outstanding</asp:LinkButton>
               </asp:LinkButton>
              
              

            </div>
                </a>
            <a href="#">
            <div class="RedOuterDiv">
               

                 <asp:LinkButton ID="LinkOverdue1" runat="server" OnClick="LinkOverdue_Click"> 
                    <div class="RedText"> Sales Overdue

                    <div class="Divimg"> <i class="fa fa-inr"  style="font-size: 25px;color:#e74a3b ;"></i></div>

                </div>  
                     
            <asp:LinkButton ID="LinkOverdue" CssClass="RedRightSideDown" runat="server" OnClick="LinkOverdue_Click"></asp:LinkButton>
               </asp:LinkButton>
               <%-- <span>9,999,999</span>--%>

            </div>
                </a>
        </div> 
        

          
    
     <div id="div_dsoday11" runat ="server">
   
     <div class="CreditReqLBL"  runat="server" >
                  <asp:Label ID="lbal_Header" runat="server" Text="DSO Days"></asp:Label>
                </div>
            <div  id="div_dsoday" class="widget-content" runat="server" >
                <div class="FormGroupContent4">
                   <%-- <div class="DSOCN"><asp:Label ID="lbl_vsl" runat="server" Text="Company Name"></asp:Label></div>--%>
                    <div class="DSOComBranch"><asp:DropDownList ID="cmbbranch" runat="server" AutoPostBack="True"  CssClass="chzn-select"  Width="100%"  Enabled ="false"  TabIndex="1" OnSelectedIndexChanged="cmbbranch_SelectedIndexChanged" >
         </asp:DropDownList></div>
                    <div class="DSOBranch"><asp:TextBox ID="txtbname" runat="server" CssClass="form-control" placeholder="Branch Name" ToolTip="Branch Name" onkeyup="GetDetail();"></asp:TextBox></div>
                    </div>
                <div class="bordertopNew"></div>
                 <div class="FormGroupContent4">
                     <div id='table-container'>
    <asp:GridView ID="grd" runat="server" CssClass="GridDSO" Width="100%"  AutoGenerateColumns="False"  ShowHeaderWhenEmpty="true" OnSorting="grd_Sorting"
     AllowSorting="true" OnRowDataBound="grd_RowDataBound" OnPreRender="grd_PreRender" style=" font-family: sans-serif; font-size: 12px;color: Black;">
           <Columns>
               <asp:BoundField HeaderText="S#"  >
                <HeaderStyle Width ="30px" />
               <ItemStyle Width ="30px" />
               </asp:BoundField>
               <asp:TemplateField HeaderText ="Branch Name" SortExpression="divsname">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:98% ;">
                       <asp:Label ID="lbldivsname" runat="server" Text='<%# Bind("divsname") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="false" Width="100px"  Height="5px" />
                <ItemStyle Wrap="false" Width="100px" >
                </ItemStyle>
             </asp:TemplateField>

             
               <asp:TemplateField HeaderText ="Branch Manager" SortExpression="bm">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:98% ;">
                       <asp:Label ID="lblbm" runat="server" Text='<%# Bind("bm") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="false" Width="130px"  Height="5px" />
                <ItemStyle Wrap="false" Width="130px" >
                </ItemStyle>
             </asp:TemplateField>

             <asp:TemplateField HeaderText ="Regional Manager" SortExpression="rm">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:98% ;">
                       <asp:Label ID="lblrm" runat="server" Text='<%# Bind("rm") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="false" Width="90px"  Height="5px" />
                <ItemStyle Wrap="false" Width="90px" >
                </ItemStyle>
             </asp:TemplateField>

               <asp:TemplateField HeaderText ="Dso Days" SortExpression="dsodays">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:100% ;" >
                       <%--<asp:Label ID="lbldsodays" runat="server" Text='<%# Bind("dsodays") %>'></asp:Label>--%>
                        <asp:TextBox ID="lbldsodays"  BorderStyle ="None"  Width ="100%" runat="server"  Text='<%# Bind("dsodays") %>' ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"></asp:TextBox>

                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="false" Width="20px"  Height="5px" />
                <ItemStyle Wrap="false" Width="20px" >
                </ItemStyle>
             </asp:TemplateField>

              <%-- <asp:BoundField DataField="branchid" HeaderText="branchid" >
                <HeaderStyle CssClass="hiderow" />
               <ItemStyle CssClass="hiderow" />
               </asp:BoundField>
               <asp:BoundField DataField="portname" HeaderText="portname">
               <HeaderStyle CssClass="hiderow" />
               <ItemStyle CssClass="hiderow" />
               </asp:BoundField>--%>
              
           </Columns>            
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
       </asp:GridView>
     </div>

                     </div>

                <div class="FormGroupContent4">
                    <div class="right_btn MT0 MB05">

                        <div class="btn ico-update"> <asp:Button ID="btnupdate" runat="server" ToolTip="Update"  TabIndex="5" OnClick="btnupdate_Click"  /></div>
                        <div class="btn ico-back"> <asp:Button ID="btnback" runat="server" ToolTip="Back"   TabIndex="6"  OnClick="btnback_Click" /></div>
                        <div class="btn ico-send"> <asp:Button ID="btn_search" runat="server" Text="" Style="display: none;"  OnClick="btn_search_Click" /></div>
                    </div>
                     
         
         
                </div>
                <asp:HiddenField ID="hdndivid" runat="server" />
                </div>
         </div>

 
        <div class="PanelPadCtrl" id="OutstandingGrid" runat="server">
            <div class="CreditReqLBL">Outstanding</div>
             <div class="right_btn MB13 MBC2">
                                     <asp:LinkButton ID="Link_ousta" runat="server" OnClick="Link_ousta_Click"  Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                                     </asp:LinkButton>                         
                                    <div style="clear:both;"></div>
                                </div>
                                  <asp:Panel ID="Panel2" runat="server" CssClass="PendingTblGridNewOutW1">
                                        <asp:GridView ID="grdOutStanding"  runat="server" AutoGenerateColumns="false" Width="100%"  Height="80%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" OnSelectedIndexChanged="grdOutStanding_SelectedIndexChanged" OnRowDataBound="grdOutStanding_RowDataBound" ShowHeaderWhenEmpty="true">
                                            <Columns>
                                                <%--<asp:TemplateField HeaderText="S #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" Width="30px" />
                                                    <HeaderStyle Wrap="false" Width="30px" />
                                                </asp:TemplateField>--%>
                                                <asp:BoundField DataField="SI" HeaderText="S#">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left">
                                                        </ItemStyle>
                                                    </asp:BoundField>
                                                <asp:BoundField DataField="ledgername" HeaderText="Ledgername" >
                                                    <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false"  HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="customerid" HeaderText="Customerid">
                                                    <HeaderStyle Wrap="false"  HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false"  HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="subgroupid" HeaderText="subgroupid">
                                                    <HeaderStyle Wrap="false"  HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false"  HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="subgroupname" HeaderText="subgroupname">
                                                    <HeaderStyle Wrap="false"  HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false"  HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>
                                                  <asp:BoundField DataField="amount" HeaderText="Amount">
                                                    <HeaderStyle Wrap="false"  HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false"  HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                                </asp:BoundField>

                                               
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeaderN" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </asp:Panel>
                                     </div>
                                    <div class="div_ddl"  style="display:none">
                                        <asp:TextBox ID="txt_date" runat="server" OnTextChanged="txt_date_TextChanged"></asp:TextBox>
                                    </div>

        <div class="PanelPadCtrl" id="grid_Creditrequest1" runat="server" >
            <div class="CreditReqLBL">Credit Request</div>
            <div class="right_btn MT0 MBctrl">
                                     <asp:LinkButton ID="Link_request" runat="server" OnClick="Link_request_Click"  Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                                     </asp:LinkButton>                         
                                    <div style="clear:both;"></div>
                                </div>
                                     <asp:Panel ID="Panel1" runat="server" CssClass="CreditRequestTbl">
                                        <asp:GridView ID="grid_Creditrequest"  runat="server" AutoGenerateColumns="false" Width="100%"  Height="80%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White"  OnSelectedIndexChanged="grid_Creditrequest_SelectedIndexChanged"  OnRowDataBound="grid_Creditrequest_RowDataBound" ShowHeaderWhenEmpty="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" Width="30px" />
                                                    <HeaderStyle Wrap="false" Width="30px" />
                                                </asp:TemplateField>
                                             
                                               <%-- <asp:BoundField DataField="groupid" HeaderText="Groupid" >
                                                    <HeaderStyle Wrap="true" Width="50px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="true" Width="50px" HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>--%>

                                                <asp:BoundField DataField="groupname" HeaderText="Customer">
                                                    <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="gname" HeaderText="CustomerAdderss">
                                                    <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ptc" HeaderText="PTC">
                                                    <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>
                                                  <asp:BoundField DataField="phone" HeaderText="Phone">
                                                    <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>
                                                  <asp:BoundField DataField="email" HeaderText="Email">
                                                    <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeaderN" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </asp:Panel>
            </div>

        <div class="PanelPadCtrl" id="Pannectrl" runat="server" >
            <div class="CreditReqLBL">Exemption List</div>
               <div class="right_btn MB13 MBC2">
                                     <asp:LinkButton ID="Link_excep" runat="server" OnClick="Link_excep_Click"  Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                                     </asp:LinkButton>                         
                                    <div style="clear:both;"></div>
                                </div>
                                    <asp:Panel ID="Panel3" runat="server" CssClass="PendingTblGridNewOutW1">
                                        <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="false" Width="100%"  Height="80%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" ShowHeaderWhenEmpty="true" OnPageIndexChanging="GridView1_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" Width="30px" />
                                                    <HeaderStyle Wrap="false" Width="30px" />
                                                </asp:TemplateField>
                                                   
                                                 <asp:BoundField DataField="Branch" HeaderText="Branch" >
                                                    <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Docno" HeaderText="Docno">
                                                    <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Product" HeaderText="Product">
                                                    <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Customer" HeaderText="Customer">
                                                    <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Creditamt" HeaderText="Creditamt">
                                                    <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Date" HeaderText="Date">
                                                    <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>

                                                 <asp:BoundField DataField="ExemptedBy" HeaderText="ExemptedBy">
                                                    <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Creditdays" HeaderText="Creditdays">
                                                    <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Right" ></ItemStyle>
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                                    <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="customerid" HeaderText="customerid" >
                                                    <HeaderStyle CssClass="hide" />
                                                    <ItemStyle CssClass="hide"/>
                                                </asp:BoundField>

                                                
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeaderN" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </asp:Panel>
            </div>

        <div class="PanelPadCtrl" id="pnlcreditapprovallimit" runat="server" >
        <div class="CreditReqLBL">Credit Approval Limits</div>
             <div class="right_btn MB13 MBC2">
                                     <asp:LinkButton ID="lnk_creditrequest" runat="server" OnClick="lnk_creditrequest_Click"  Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                                     </asp:LinkButton>                         
                                    <div style="clear:both;"></div>
                                </div>
                            <asp:Panel ID="Panel4" runat="server" CssClass="PendingTblGridNewOutW1">
                                        <asp:GridView ID="Grid_creditapprovallimit"  runat="server" AutoGenerateColumns="false" Width="100%"  Height="80%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" OnSelectedIndexChanged="Grid_creditapprovallimit_SelectedIndexChanged" OnRowDataBound="Grid_creditapprovallimit_RowDataBound" ShowHeaderWhenEmpty="true">
                                            <Columns>
                                           
                                                <asp:BoundField DataField="SI" HeaderText="S#">
                                                        <HeaderStyle Wrap="false" Width="30px" HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="false" Width="30px" HorizontalAlign="Left">
                                                        </ItemStyle>
                                                    </asp:BoundField>
                                                <asp:BoundField DataField="empname" HeaderText="Empname" >
                                                    <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="branch" HeaderText="Branch">
                                                    <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="amountlmt" HeaderText="Amountlimit">
                                                    <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="daylmt" HeaderText="Daylimit">
                                                    <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="excemlmt" HeaderText="Excemlimit">
                                                    <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false" Width="80px" HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeaderN" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </asp:Panel>
            </div>
            <div class="PanelPadCtrloverdue" id="div_overdue" runat="server">
                 <div class="CreditReqLBL">Overdue</div>
             <div class="right_btn MB13 MBC2">
                                     <asp:LinkButton ID="Link_overdue" runat="server" OnClick="Link_overdue_Click" Visible="false">
                                            <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                                     </asp:LinkButton>                         
                                    <div style="clear:both;"></div>
                                </div>
             <asp:Panel ID="Panel5" runat="server" CssClass="PendingTblGridNewOutW1" style="height:345px; overflow:auto;">
                                        <asp:GridView ID="Grid_overdue"  runat="server" AutoGenerateColumns="false" Width="100%"  Height="80%" ForeColor="Black" EmptyDataText="No Record Found"  OnSelectedIndexChanged="Grid_overdue_SelectedIndexChanged"  OnRowDataBound="Grid_overdue_RowDataBound" BackColor="White" ShowHeaderWhenEmpty="true">
                                            <Columns>
                                           
                                               <asp:TemplateField HeaderText="S #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" Width="30px" />
                                                    <HeaderStyle Wrap="false" Width="30px" />
                                                </asp:TemplateField>
                                                
                                                <asp:BoundField DataField="customername" HeaderText="Ledgername" >
                                                    <HeaderStyle Wrap="false"  HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false"  HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="customerid" HeaderText="Customerid">
                                                    <HeaderStyle Wrap="false"  HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false"  HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="subgroupid" HeaderText="subgroupid">
                                                    <HeaderStyle Wrap="false"  HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false"  HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="subgroupname" HeaderText="subgroupname">
                                                    <HeaderStyle Wrap="false"  HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false"  HorizontalAlign="Left" ></ItemStyle>
                                                </asp:BoundField>
                                                  <asp:BoundField DataField="amount" HeaderText="Amount">
                                                    <HeaderStyle Wrap="false"  HorizontalAlign="Center" />
                                                    <ItemStyle Wrap="false"  HorizontalAlign="Left" CssClass="TxtAlign1"></ItemStyle>
                                                </asp:BoundField>


                                               
                                                  
                                                 
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="GridHeaderN" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>
                                    </asp:Panel>
                </div>
        

        <div class="chart">
        <asp:Literal ID="lts" runat="server"></asp:Literal>
                            <div id="chart_divbar" runat="server"></div>
            </div>
    </form>
</body>
</html>
