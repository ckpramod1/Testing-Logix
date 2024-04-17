<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorpBudgetHome.aspx.cs" Inherits="logix.Home.CorpBudgetHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">

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

    <!--=== JavaScript ===-->
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
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
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


        .OEBox1 {
            width: 14.3%;
            min-height: 117px;
            background-color: #c4d79b;
            margin: 0px 0px 0px 0px;
            float: left;
        }


            .OEBox1 h3 {
                color: #000000;
                padding: 10px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

     


            .FCL {
                color: #000000;
                margin: 10px 0px 0px 10px;
                font-size:14px;
                font-family:'Segoe UI';
                float:left;
            }

        .LeftValue {
            float:left;
            margin:18px 0px 0px 10px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
            color:#000000;
        }



            .LeftValue a {
                color:#000000;
                text-decoration:none;
            }







        .RightValue {
            float:right;
            margin:18px 10px 0px 0px;
            font-family: "Segoe UI";
            font-size: 24px;
            font-weight: bold;
            color:#000000;
        }

            .RightValue a {
                color:#000000;
                text-decoration:none;
            }






        
            .FCL1 {
                color: #000000;
                margin: 10px 0px 0px 10px;
                font-size:14px;
                font-family:'Segoe UI';
                float:left;
            }

                   .LCL1 {
                color: #000000;
                margin: 10px 0px 0px 10px;
                font-size:14px;
                font-family:'Segoe UI';
                float:left;
            }


        .OEBox2 {
            width: 14.3%;
            min-height: 117px;
            background-color: #b1a0c7;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .OEBox2 h3 {
                color: #000000;
                padding: 10px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

       



                  .LCL {
                color: #000000;
                margin: 10px 0px 0px 10px;
                font-size:14px;
                font-family:'Segoe UI';
                float:left;
            }


        .Weight1 {
            color: #000000;
                margin: 10px 0px 0px 10px;
                font-size:14px;
                font-family:'Segoe UI';
                float:left;
        }

        .Weight2 {
            color: #000000;
                margin: 10px 0px 0px 10px;
                font-size:14px;
                font-family:'Segoe UI';
                float:left;
        }

        
         .Shipments {
            color: #000000;
                margin: 10px 0px 0px 10px;
                font-size:14px;
                font-family:'Segoe UI';
                float:left;
        }


        .OIBox1 {
            width: 14.3%;
            min-height: 117px;
            background-color: #92cddc;
            margin: 0px 0px 0px 0px;
            float: left;
        }


            .OIBox1 h3 {
                color: #000000;
                padding: 10px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .OIBox1 span {
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






        .OIBox2 {
            width: 14.3%;
            min-height: 117px;
            background-color: #fabf8f;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .OIBox2 h3 {
                color: #000000;
                padding: 10px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .OIBox2 span {
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


        .AEBox {
            width: 14.3%;
            min-height: 117px;
            background-color: #da9694;
            margin: 0px 0px 0px 0px;
            float: left;
        }


            .AEBox h3 {
                color: #000000;
                padding: 10px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .AEBox span {
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







        .AIBox {
            width: 14.3%;
            min-height: 117px;
            background-color: #948a54;
            margin: 0px 0px 0px 0px;
            float: left;
        }


            .AIBox h3 {
                color: #000000;
                padding: 10px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .AIBox span {
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







        .CHABox {
            width: 14.2%;
            min-height: 117px;
            background-color: #bfbfbf;
            margin: 0px 0px 0px 0px;
            float: left;
        }

            .CHABox h3 {
                color: #000000;
                padding: 10px 0px 0px 9px;
                margin: 0px;
                font-family: "Segoe UI";
                font-size: 14px;
                font-weight: normal;
            }

            .CHABox span {
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
            width: 135px;
            float: left;
        }

        .NovOverCheque {
            width: 195px;
            float: left;
        }

        .VoucherRegister {
            width: 177px;
            float: left;
        }

        .SinceAudit {
            width: 148px;
            float: left;
        }

        .CustomerTDS {
            width: 145px;
            float: left;
        }

        .CostSheet {
            width: 170px;
            float: left;
        }

        .MT35 {
            margin-top:44px!important;
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
    margin: 0px 0px 5px 15px;
    float: left;
        color: #4e73df !important;
        
    }

               .LeftNumValue
{
    color: #4e73df !important;
    margin: 5px 0px 0px 14px;
    float: left;
    width: 20%;
    font-size: 21px;
    font-family: 'OpenSansSemibold';
    text-align: left;
}

.RightNumValue
{
   color: #4e73df !important;
    margin: 5px 10px 0px 0px;
    float: right;
    width: 66%;
    font-size: 21px;
    font-family: 'OpenSansSemibold';
    text-align: right;
}


               .LeftNumValue1
{
    color: #1cc88a !important;
    margin: 5px 0px 0px 14px;
    float: left;
    width: 20%;
    font-size: 21px;
    font-family: 'OpenSansSemibold';
    text-align: left;
}

.RightNumValue1
{
   color: #1cc88a !important;
    margin: 5px 10px 0px 0px;
    float: right;
    width: 66%;
    font-size: 21px;
    font-family: 'OpenSansSemibold';
    text-align: right;
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
    margin: 0px 0px 5px 15px;
    float: left;
    color: #1cc88a !important;
     }

     .GreenRightSideDown {

    color: #1cc88a!important;
    margin: 5px 10px 0px 0px;
    font-family: 'OpenSansSemibold';
    float: right;
    font-size: 21px;
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
        margin: 0px 0px 5px 15px;
        float: left;
        color: #36b9cc !important;
 }

       .LtBlueRightSideDown
 {
     color: #36b9cc!important;
    margin: 5px 10px 0px 0px;
    font-family: 'OpenSansSemibold';
    float: right;
    font-size: 21px;
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
    margin: 0px 0px 5px 15px;
    float: left;
    color: #f6c23e !important;
    }


         
 .YellowRightSideDown
 {
      color: #f6c23e!important;
    margin: 5px 10px 0px 0px;
    font-family: 'OpenSansSemibold';
    float: right;
    font-size: 21px;
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
        margin: 0px 0px 5px 15px;
        float: left;
        color: #1cc88a!important;
        }


         .GreenRightSideDown2
 {
     color: #1cc88a!important;
    margin: 5px 10px 0px 0px;
    float: right;
    font-family: 'OpenSansSemibold';
    font-size: 21px;
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
        margin: 0px 0px 5px 15px;
        float: left;
        color: #4e73df !important;
        }

                
         .Blue2RightSideDown
 {
     color: #4e73df!important;
     font-family: 'OpenSansSemibold';
    margin: 5px 10px 0px 0px;
    float: right;
    font-size: 21px;
    width: 75%;
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
        margin: 0px 0px 5px 15px;
        float: left;
        color: #e74a3b !important;
        }



 .RedRightSideDown
 {
          color: #e74a3b!important;
    margin: 5px 10px 0px 0px;
    font-family: 'OpenSansSemibold';
    float: right;
    font-size: 21px;
    width: 75%;
    text-align: right;
 }

 form#form1 {
    background: #f8f9fc !important;
}

 .chart {
    height: 320px;
    z-index: 90;
    width: 100%;
    overflow: hidden;
    margin: 0px 0px 0px 30px;
}

 .HomeMenuBox {
    width: 100%;
    float: left;
    margin: 0px 0px 35px 0px;
}
    </style>


    <style type="text/css">

            @media only screen and (max-width: 1280px) {








                .OIBox1 h3 {
                    padding:10px 0px 0px 7px;

                }



  



    }




           
    </style>



</head>
<body>
    <form id="form1" runat="server">
        <div class="BandMiddle"><div class="BreadLabel" id="OptionDoc" runat="server">Budget</div></div>
        <div class="BandTop">
            <div class="PaymentCancel">
               <h3>
                   <img src="../Theme/assets/budget/Budgetactual_1.png" />
                    <asp:LinkButton ID="formpaymentcancel" runat="server" Text="Budget Vs Actuals" OnClick="formpaymentcancel_Click"></asp:LinkButton></h3>

            </div>
            <div class="NovOverCheque">
                <h3>
                    <img src="../Theme/assets/budget/performanceanalysis_1.png" />
                    <asp:LinkButton ID="formnotover" runat="server" Text="Performance Analysis - N vs F" OnClick="formnotover_Click"></asp:LinkButton></h3>

            </div>
            <div class="VoucherRegister">
                <h3>
                   
                    <img src="../Theme/assets/budget/performace_1.png" />
                      <asp:LinkButton ID="formvoureg" runat="server" Text="Performance Comparision" OnClick="formvoureg_Click"></asp:LinkButton></h3>
                


            </div>
            <div class="SinceAudit">

                <h3>

                    <img src="../Theme/assets/budget/revenue_1.png" />
                 
                   <asp:LinkButton ID="formsince" runat="server" Text="Revenue Projections" OnClick="formsince_Click"></asp:LinkButton></h3>
            </div>

            <div class="CustomerTDS">
                <h3>
                   
                    <img src="../Theme/assets/budget/volumeprojections_1.png" />
                <asp:LinkButton ID="formtds" runat="server" Text="Volume projections" OnClick="formtds_Click"></asp:LinkButton></h3>

            </div>
            <div class="CostSheet">
                <h3>
                   
                    <img src="../Theme/assets/budget/masterbudget_1.png" />
                  <asp:LinkButton ID="formcost" runat="server" Text="Master Budget - Branch" OnClick="formcost_Click"></asp:LinkButton></h3>
            </div>
        </div>

        <div class="HomeMenuBox">
            <%--<a href="#">
                <div class="OEBox1">
                    <h3>Ocean Exports</h3>
                    <div class="FCL">FCL Reus</div>
                        <div class="Clear"></div>
                    <span class="LeftValue">98</span>
                    <span class="RightValue">180</span>

                </div>
            </a>--%>
           
             <div class="BlueOuterDiv" runat="server">
             
                    <div class="BlueText"> Ocean Exports &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FCL</div>
                 <div class="BlueText">Teus</div>            
                    
                    <div class="Clear"></div>
                <asp:LinkButton ID="Link_Budget" CssClass="LeftNumValue"  runat="server" OnClick="Link_Budget_Click"></asp:LinkButton>
               <asp:LinkButton ID="Link_Actual" CssClass="RightNumValue" runat="server" OnClick="Link_Actual_Click"></asp:LinkButton>
              
            </div>
                
          <%--  <a href="#">--%>
                <div class="GreenOuterDiv">
                  
                    <div class="GreenText"> Ocean Exports &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; LCL</div>
                 <div class="GreenText"> M3</div>
           
                    <div class="Clear"></div>
                <asp:LinkButton ID="LinkFCL" runat="server"  CssClass="LeftNumValue1"   OnClick="LinkFCL_Click"></asp:LinkButton>
               <asp:LinkButton ID="LinkFCLmp3" runat="server"  CssClass="RightNumValue1" OnClick="LinkFCLmp3_Click"></asp:LinkButton>         

                    

                </div>
          <%--  </a>--%>
           <%-- <a href="#">--%>
                <div class="LiteBlueOuter">
                   
                     <div class="LiteBlueText"> Ocean Imports &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; FCL</div>
                    <div class="LiteBlueText">Teus</div>
                    
                
               <asp:LinkButton ID="lnkFCl" runat="server"  CssClass="LtBlueRightSideDown"  OnClick="lnkFCl_Click"></asp:LinkButton>         
                    
                </div>
       
                <div class="YellowOuterDiv">
                   
                    <div class="YellowText"> Ocean Imports &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; LCL</div>
                    <div class="YellowText">M3</div>

                    <div class="Clear"></div>
              <asp:LinkButton ID="lnkm3"  CssClass="YellowRightSideDown"  runat="server" OnClick="lnkm3_Click"></asp:LinkButton> 


                </div>
         
                <div class="GreenOuterDiv2">
                    
                   <div class="GreenText2"> Air Exports</div>
                    <div class="GreenText2">Weight</div>
                   <div class="Clear"></div>
                
                <asp:LinkButton ID="lnkweight" runat="server" CssClass="GreenRightSideDown2"  OnClick="lnkweight_Click"></asp:LinkButton>

                </div>
       
                <div class="BlueOuterDiv2">
                    
                   
                    <div class="Blue2Text"> Air Imports</div>
                    <div class="Blue2Text">Weight</div>
                    <div class="Clear"></div>
                
               <asp:LinkButton ID="lnkAIweight" CssClass="Blue2RightSideDown" runat="server" OnClick="lnkAIweight_Click"></asp:LinkButton> 
                   
                </div>
        
                <div class="RedOuterDiv">
                   
                   <div class="RedText"> CHA</div>
                    <div class="RedText">No. of Shipments</div>
                  <div class="Clear"></div>
                
                <asp:LinkButton ID="lnkCHA" runat="server"  CssClass="RedRightSideDown" OnClick="lnkCHA_Click"></asp:LinkButton> 

                </div>
      
        </div>


         <div class="chart">
        <asp:Literal ID="lts" runat="server"></asp:Literal>
                            <div id="chart_divbar" runat="server"></div>
            </div>


    </form>
</body>
</html>
