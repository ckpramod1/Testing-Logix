<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuickView.aspx.cs" Inherits="logix.QuickView" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>logix</title>
    <link href="Theme/assets/css/cscss.css" rel="stylesheet" />
    
     <link href="Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Theme/bootstrap/css/bootstrap-select.css">

    <link href="Theme/assets/css/buttonicon.css" rel="stylesheet" />

    <link href="Style/GrdHead.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/Calendar.js"></script>
    <!-- Bootstrap -->
    <link href="Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Theme/bootstrap/css/bootstrap-select.css">
    <link rel="icon" type="image/png" sizes="36x21" href="Theme/assets/img/favicon.png">
    <link href="Theme/assets/css/new_style.css" rel="stylesheet" />
    <link href="Tabstyle/css/demo.css" rel="stylesheet" />
    <link href="Tabstyle/css/normalize.css" rel="stylesheet" />
    <!-- Theme -->
    <link href="Tabstyle/css/tabs.css" rel="stylesheet" />
    <link href="Tabstyle/css/tabstyles.css" rel="stylesheet" />
    <link href="Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="Theme/assets/css/fontawesome/font-awesome.min.css">
    
    <link href="Theme/assets/css/cscss.css" rel="stylesheet" />
    <!--=== JavaScript ===-->
    <script src="Tabstyle/js/cbpFWTabs.js"></script>
    <script src="Tabstyle/js/modernizr.custom.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <style type="text/css">
        body {
            font-size: 13px;
            font-family: 'Segoe UI';
        }

        .ContainerPopupdiv {
            /*height: 241px;
            border-collapse: collapse;
            overflow: auto;*/
            border: 1px solid #b1b1b1;
            margin: 187px 0px 0px 337px;
            width: 633px;
            background-color: #fff;
            height: 233px;
            padding: 0px 5px 5px;
        }

            .ContainerPopupdiv h4 {
                color: brown;
                font-size: 13px;
                font-family: 'Segoe UI';
                padding: 3px 3px 3px 3px;
                margin: 0px 0px 0px 0px;
                width: 20%;
                float: left;
            }

            .ContainerPopupdiv label {
                color: brown;
                display: inline-block;
                font-size: 13px;
                font-family: 'Segoe UI';
                padding: 3px 3px 3px 3px;
                margin: 0px 0px 0px 0px;
                width: 31%;
                float: left;
            }

                .ContainerPopupdiv label.lblDate {
                    color: brown;
                    display: inline-block;
                    font-size: 13px;
                    font-family: 'Segoe UI';
                    padding: 3px 3px 3px 3px;
                    margin: 0px 0px 0px 0px;
                    width: auto;
                    float: left;
                }


            .ContainerPopupdiv span#SpanBookingNo {
                display: inline-block;
                float: left;
                width: 23%;
                padding: 3px 3px 3px 3px;
                margin: 0px 0px 0px 0px;
                color: #4e4e4c;
                font-size: 13px;
            }

            .ContainerPopupdiv span#SpanDate {
                display: inline-block;
                float: left;
                width: 18%;
                padding: 3px 3px 3px 3px;
                margin: 0px 0px 0px 0px;
                color: #4e4e4c;
                font-size: 13px;
            }

            .ContainerPopupdiv span {
                display: inline-block;
                float: left;
                width: 32%;
                padding: 3px 3px 3px 3px;
                margin: 0px 0px 0px 0px;
                color: #4e4e4c;
                font-size: 13px;
            }

        .XLIcon {
            float: right;
            margin: 0px -3px 4px 0px;
        }

        .XLIcon1 {
            float: right;
            margin: 0px -3px 1px 0px;
            width: 4%;
        }

        .breadcrumb {
            padding: 0px 15px 0px 0px;
        }

        .crumbs {
            background-color: transparent !important;
            /*border-top: 1px solid #d9d9d9;*/
            border-bottom: 0px solid #fff;
            height: 20px;
        }

        .row {
            background-color: transparent !important;
            height: 390px !important;
            overflow-y: hidden !important;
            overflow-x: hidden !important;
            width:1030px;
        }

        .breadcrumb > li + li::before {
            color: #fff;
        }

        .crumbs .breadcrumb li i {
            color: #fff;
        }

        .widget.box .widget-content {
            background-color: transparent;
        }


        body {
            background-color: transparent !important;
            color: #fff !important;
        }

        .GridViewTbln1 {
            width: 28%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .GridViewTbl1 {
            width: 71.5%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .widget.box {
            height: 373px;
            overflow-y:auto;
            overflow-x:hidden;
        }

        .LblHead {
            font-size: 13px;
            color: #000;
            padding: 2px 0px 2px 0px;
            float: left;
            font-weight: bold;
            margin: 0px 0px 0px 5px;
            font-family: "Open Sans", "Helvetica Neue", Helvetica, Arial, sans-serif;
            width: 50%;
        }

        .DivGrid {
            float: left;
            height: 425px;
            overflow: auto;
            border: 1px solid #fff;
            width:100%;
        }

        div#DivGrdInfo {
            float: left;
            height: 360px;
            overflow: auto;
            margin: 3px 0px 0px 0px;
            width: 100%;
        }

        .Hiden1 {
            display: none !important;
        }

        #Div_NoOf_Container {
            left: 337px !important;
            top: 96px !important;
        }

        .modalPopupss1 {
            background-color: rgba(0,0,0,0.5);
            width: 1062px;
            width: 100%;
            height: 570px;
            margin-left: 0%;
            margin-top: -0.9%;
            border-left:0px solid #000;
        }


        tr.GrdRow {
    background-color: #f2efef;
}
        .Grid td {
            padding:5px;
        }
        .Grid th {
            padding:5px;
        }
        .modalPopupss {
            background-color: #FFFFFF;
            /*border-width: 1px;
    border-style: solid;
    border-color: #CCCCCC;*/
            width: 1062px;
            width: 99%;
            height: 570px;
            margin-left: 0%;
            margin-top: -0.9%;
            /*padding: 1px;
    display: none;*/
        }

div#Divbooking {
    width: 100%;
    height: 326px;
    overflow: auto;
    padding-top: 3px;
}

.BookingTxtBox1 {
            width: 50%;
            float: left;
            margin: 0px 0px 0px 0px;
        }



.Textlinkc1 {
    left: -22%;
    top: 139px;
    position: absolute;
    width: 17%;
    height: 17px;
}

.Textlinkc1 span {
    color: #000;
    font-family: "Open Sans", "Helvetica Neue", Helvetica, Arial, sans-serif;
    font-size: 13px;
    display: block;
    margin: 0px 5% 0px 5%;
    font-weight: normal;
    width: auto;
}

.Textlinkc1 label {
    color: #0000ff;
    font-family: "Open Sans", "Helvetica Neue", Helvetica, Arial, sans-serif;
    font-size: 13px;
    display: block;
    margin: 0px 5% 0px 6px;
    font-weight: normal;
}


.TxtLbl {
    left: 129%;
    top: 48px;
    position: absolute;
    content: '';
    width: 150px;
}

.TxtLbl1 {
    left: 163%;
    top: -41px;
    position: absolute;
    content: "";
    width: 100px;
    text-align: center;
}
.TxtLbl2 {
    left: 199%;
    top: 48px;
    position: absolute;
    content: '';
    width: 130px;
}

.TxtLbl3 {
    left: 238%;
    top: -41px;
    position: absolute;
    content: '';
    width: 122px;
    text-align: center;
}

.TxtLbl4 {
    left: 274%;
    top: 48px;
    position: absolute;
    content: '';
    width: 100px;
    text-align:center;
}

.TxtLbl5 {
    left: 324%;
    top: -41px;
    position: absolute;
    content: '';
    width: 100px;
    text-align: center;
}

.TxtLbl6 {
    left: 357%;
    top: 48px;
    position: absolute;
    content: '';
    width: 100px;
    text-align:center;
}

.TxtLbl7 {
    left: 408%;
    top: -41px;
    position: absolute;
    content: '';
    width: 100px;
    text-align: center;
}

.TxtLbl8 {
    left: 437%;
    top: 48px;
    position: absolute;
    content: '';
    width: 100px;
    text-align: center;
}

.TxtLbl9 {
    left: 483%;
    top: -41px;
    position: absolute;
    content: '';
    width: 100px;
    text-align: center;
}

.TxtLbl10 {
    left: 523%;
    top: 48px;
    position: absolute;
    content: '';
    width: 100px;
    text-align:center;
}

.TxtLbl11 {
    left: 570%;
    top: -41px;
    position: absolute;
    content: '';
    width: 100px;
    text-align: center;
}

.TxtLbl12 {
    left: 609%;
    top: 48px;
    position: absolute;
    content: '';
    width: 100px;
    text-align: center;
}

.RoundHeightn1 {
    width: 717px;
    left: 2%;
    top: 161px;
    position: absolute;
    min-height: 2px;
    border-bottom: 2px dotted #000;
    
}
.RoundHeight1 {
    width: 777px;
    left: 2%;
    top: 161px;
    position: absolute;
    min-height: 2px;
    border-bottom: 2px dotted #000;
    
}

.RoundHeight {
     width: 777px;
    left: 2%;
    top: 161px;
    position: absolute;
    min-height: 2px;
    border-bottom: 2px dotted #000;
}



.Roundcolor {
    background-color: #0000ff;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 1.6%;
    top: 154px;
    position: absolute;
}


.Round {
	background-color: #000;
	border-radius: 25px;
	width: 15px;
	height: 15px;
	left: 1.6%;
	top: 154px;
	position: absolute;
}





.Roundcolor1 {
    background-color: #0000ff;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 10.6%;
    top: 154px;
    position: absolute;
}
.Round1 {
    background-color: #000;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 8.6%;
    top: 154px;
    position: absolute;
}

.Roundcolor2 {
    background-color: #0000ff;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 20.6%;
    top: 154px;
    position: absolute;
}
.Round2 {
    background-color: #000;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 15.6%;
    top: 154px;
    position: absolute;
}


.Roundcolor3 {
    background-color: #0000ff;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 22.6%;
    top: 154px;
    position: absolute;
}

.Round3 {
    background-color: #000;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 22.6%;
    top: 154px;
    position: absolute;
}
.Roundcolor4 {
    background-color: #0000ff;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 29.6%;
    top: 154px;
    position: absolute;
}

.Round4 {
    background-color: #000;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 29.6%;
    top: 154px;
    position: absolute;
}


.Roundcolor5 {
    background-color: #0000ff;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 36.6%;
    top: 154px;
    position: absolute;
}

.Round5 {
    background-color: #000;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 36.6%;
    top: 154px;
    position: absolute;
}



.Roundcolor6 {
    background-color: #0000ff;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 43.6%;
    top: 154px;
    position: absolute;
}

.Round6 {
    background-color: #000;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 43.6%;
    top: 154px;
    position: absolute;
}


.Roundcolor7 {
    background-color: #0000ff;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 50.6%;
    top: 154px;
    position: absolute;
}
.Round7 {
    background-color: #000;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 50.6%;
    top: 154px;
    position: absolute;
}




.Roundcolor8 {
    background-color: #0000ff;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 57.6%;
    top: 154px;
    position: absolute;
}

.Round8 {
    background-color: #000;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 57.6%;
    top: 154px;
    position: absolute;
}
.Roundcolor9 {
    background-color: #0000ff;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 64.6%;
    top: 154px;
    position: absolute;
}
.Round9 {
    background-color: #000;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 64.6%;
    top: 154px;
    position: absolute;
}


.Roundcolor10 {
    background-color: #0000ff;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 71.6%;
    top: 154px;
    position: absolute;
}

.Round10 {
    background-color: #000;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 71.6%;
    top: 154px;
    position: absolute;
}




.Roundcolor11 {
    background-color: #0000ff;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 78.6%;
    top: 154px;
    position: absolute;
}


.Round11 {
    background-color: #000;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 78.6%;
    top: 154px;
    position: absolute;
}
.Round12 {
    background-color: #000;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 84.6%;
    top: 154px;
    position: absolute;
}
.Roundcolor12 {
    background-color: #0000ff;
    border-radius: 25px;
    width: 15px;
    height: 15px;
    left: 84.6%;
    top: 154px;
    position: absolute;
}

.bordertopNew {
    float: left;
    min-height: 1px;
    margin: -40px 0px 5px 0px;
    border-top: 2px dotted #807f7f;
    width: 100%;
}
       .FromLeft {
    float: left;
    width: 100%;
    margin: 5px 0px 5px 10px;
    padding: 0px 0px 0px 0px;
    color: #4e4e4c;
    text-align: left;
    font-family: 'OpenSansRegular', "Helvetica Neue", Helvetica, Arial, sans-serif;
    font-size: 13px;
}
       .FromLeftn1{
    float: left;
    width: 100%;
    margin: 5px 0px 5px 10px;
    padding: 0px 0px 0px 0px;
    color: #4e4e4c;
    text-align: left;
    font-family: 'OpenSansRegular', "Helvetica Neue", Helvetica, Arial, sans-serif;
    font-size: 13px;
}




        .FromTxtbox {
            clear:left;
            width:30%;
            margin:5px 0px 5px 10px;
            padding:0px 0px 0px 0px;

        }

        .FromTxtbox1 {
            clear:left;
            width:86%;
            margin:5px 0px 5px 10px;
            padding:0px 0px 0px 0px;

        }

        .FormLeft1 {
            width:35%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
        .FormLeft2{
            width:35%;
            float:left;
            margin:0px 0% 0px 0px;
        }

        .FromTxtboxTxt {
    clear: left;
    width: 66%;
    margin: 5px 0px 5px 10px;
    padding: 0px 0px 0px 0px;
}


         .FromTxtboxTxt1 {
    clear: left;
    width: 100%;
    height:40%;
    margin: 5px 0px 5px 10px;
    padding: 0px 0px 0px 0px;
}

        .GoodsDetail {
            float:left;
            width:100%;
            margin:10px 0px 10px 0px;
        }
        .Head1 {
            width:33%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
            border-top:1px solid #3b505d;
            border-left:1px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
            color:#fff;
            font-weight:bold;
            background-color:#476b82;
            font-size:13px;
            font-family:sans-serif;

        }
         .Head2 {
            width:22%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
             border-top:1px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
            color:#fff;
             font-weight:bold;
              background-color:#476b82;
              font-size:13px;
               font-family:sans-serif;
        }
          .Head3 {
            width:22%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
             border-top:1px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
            color:#fff;
             font-weight:bold;
              background-color:#476b82;
              font-size:13px;
               font-family:sans-serif;
        }

          .Head4 {
            width:22%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
             border-top:1px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
            color:#fff;
             font-weight:bold;
              background-color:#476b82;
              font-size:13px;
               font-family:sans-serif;
        }

          .Head1a {
            width:55%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
            border-top:0px solid #3b505d;
            border-left:1px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
            color:#fff;
            font-weight:bold;
             background-color:#476b82;
             font-size:13px;
              font-family:sans-serif;

        }


          .Head1aN {
            width:33%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
            border-top:0px solid #3b505d;
            border-left:1px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
            color:#fff;
            font-weight:bold;
             background-color:#476b82;
             font-size:13px;
              font-family:sans-serif;

        }



           .Head1a1 {
            width:33%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
            border-top:0px solid #3b505d;
            border-left:1px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
            color:#fff;
            font-weight:bold;
             background-color:#476b82;
             font-size:13px;
              font-family:sans-serif;

        }



         .Head2b {
            width:44%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
             border-top:0px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
            color:#fff;
             font-weight:bold;
              background-color:#476b82;
              font-size:13px;
               font-family:sans-serif;
        }



          .Head2b2 {
            width:33%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
             border-top:0px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
            color:#fff;
             font-weight:bold;
              background-color:#476b82;
              font-size:13px;
               font-family:sans-serif;
        }






           .Head2b1 {
            width:66%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
             border-top:0px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
            color:#fff;
             font-weight:bold;
              background-color:#476b82;
              font-size:13px;
               font-family:sans-serif;
        }

            .Head2b1C {
            width:66%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
             border-top:0px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
            color:#fff;
             font-weight:bold;
              background-color:#476b82;
              font-size:13px;
               font-family:sans-serif;
        }



          .Head3c {
            width:33%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
             border-top:0px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
            color:#fff;
             font-weight:bold;
              background-color:#476b82;
              font-size:13px;
               font-family:sans-serif;
        }
           .Head3c3 {
            width:33%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
             border-top:0px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
            color:#fff;
             font-weight:bold;
              background-color:#476b82;
              font-size:13px;
               font-family:sans-serif;
        }



           .Content1a {
            width:55%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
            color:#000;
             border-top:0px solid #3b505d;
            border-left:1px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
            min-height:30px;
            font-size:13px;
             font-family:sans-serif;
           
         

        }





              .Content1aN {
            width:33%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
            color:#000;
             border-top:0px solid #3b505d;
            border-left:1px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
            min-height:30px;
            font-size:13px;
             font-family:sans-serif;
           
         

        }







          .Content2b {
            width:44%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
            color:#000;
             border-top:0px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
             min-height:30px;
             font-size:13px;
              font-family:sans-serif;
           
        }



            .Content1a1 {
            width:33%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
            color:#000;
             border-top:0px solid #3b505d;
            border-left:1px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
            min-height:30px;
            font-size:13px;
             font-family:sans-serif;
           
         

        }
          .Content2b2 {
            width:33%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
            color:#000;
             border-top:0px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
             min-height:30px;
             font-size:13px;
              font-family:sans-serif;
           
        }

            .Content3c3 {
            width:33%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
            color:#000;
             border-top:0px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
             min-height:30px;
             font-size:13px;
              font-family:sans-serif;
            
        }






          .Content2b1 {
            width:66%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
            color:#000;
             border-top:0px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
             min-height:30px;
             font-size:13px;
              font-family:sans-serif;
           
        }
            .Content2b1C {
            width:66%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
            color:#000;
             border-top:0px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
             min-height:30px;
             font-size:13px;
              font-family:sans-serif;
           
        }


          .Content3c {
            width:33%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
            color:#000;
             border-top:0px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
             min-height:30px;
             font-size:13px;
              font-family:sans-serif;
            
        }










        .Content1 {
            width:33%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
            color:#000;
             border-top:0px solid #3b505d;
            border-left:1px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
             min-height:30px;
             font-size:13px;
              font-family:sans-serif;
           
        }
          .Content2 {
            width:22%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
            color:#000;
             border-top:0px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
             min-height:30px;
             font-size:13px;
              font-family:sans-serif;
           
        }
          .Content3 {
            width:22%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
            color:#000;
             border-top:0px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
             min-height:30px;
             font-size:13px;
              font-family:sans-serif;
           
        }




             .Content4 {
            width:22%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:2px;
            color:#000;
             border-top:0px solid #3b505d;
            border-right:1px solid #3b505d;
            border-bottom:1px solid #3b505d;
             min-height:30px;
             font-size:13px;
              font-family:sans-serif;
           
        }







        .SectionC {
            width:100%;
            border-bottom:0px solid #b1b1b1;
            padding:5px;
            font-size:13px;
            font-family:'Segoe UI';
            color:#000;
            text-align:left;
            float:left;
        }

        .SectionL{
            width:75%;
            border-bottom:1px solid #b1b1b1;
            padding:5px;
            font-size:13px;
            font-family:'Segoe UI';
            margin:0px 0% 0px 0px;
            float:left;
             color:#000;
              text-align:left;
              font-weight:600;
             min-height:30px;
        }
        .SectiorR{
            width:22%;
            border-bottom:1px solid #b1b1b1;
            padding:5px;
            font-size:13px;
            font-family:'Segoe UI';
            margin:0px 0% 0px 0px;
            float:left;
             color:#000;
             min-height:30px;
              text-align:right;
              font-weight:bold;
        }

        .BookinNo {
            font-size:13px;
            color:brown;
            width:46%;
            float:left;
            margin:0px 2.5% 0px 0px;
            text-align:right;
        }


       
.tabs-style-bar li a.icon1 {
   
    background-image: url(Tabstyle/img/updates_icon.png)!important;
    background-repeat: no-repeat!important;
    background-position: 55px 15px!important;
    padding: 3px 0px 5px 25px!important;
}

.tabs-style-bar li a.icon2 {
    
    background-image: url(Tabstyle/img/details_icon.png)!important;
    background-repeat: no-repeat!important;
    background-position: 55px 15px!important;
    padding: 3px 0px 5px 25px!important;
}

.tabs-style-bar li a.icon3 {
   
    background-image: url(Tabstyle/img/documents_icon.png)!important;
    background-repeat: no-repeat!important;
    background-position: 55px 15px!important;
    padding: 3px 0px 5px 45px!important;
}
.tabs-style-bar li a.icon4{
    
    background-image: url(Tabstyle/img/specialnotes_icon.png)!important;
    background-repeat: no-repeat!important;
    background-position: 55px 15px!important;
    padding: 3px 0px 5px 60px!important;
}
.tabs-style-bar li a.icon5{
   
    background-image: url(Tabstyle/img/cleareance_icon.png)!important;
    background-repeat: no-repeat!important;
    background-position: 55px 15px!important;
    padding: 3px 0px 5px 36px!important;
}
        #grpupdload input {
            width:24px;
            height:24px;
        } 



        .FromTxtboxTxt1 textarea {
    line-height: 36px;
    padding:10px 0px 5px 20px!important;
    border:none;
    

}

        .Grid th {
    background-color: #476b82 !important;
    border-right: 1px solid #003166;
    border-top: 1px solid #003166;
    border-bottom: 1px solid #003166;
    border-left: 1px solid #003166;
    font-family: tahoma;
    padding: 2px 5px 2px 5px;
    font-size: 13px;
    color: #ffffff !important;
}
        .Grid td {
    border-right: 1px solid #003166;
    border-top: 1px solid #003166;
    border-left: 1px solid #003166;
    font-size: 11px;
    text-align: left;
    font-family: tahoma;
    padding: 5px 5px 2px 5px!important;
    margin: 0px;
    color: #4e4c4c;
    border-bottom: 1px solid #003166;
}
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="crumbs">
            <ul id="breadcrumbs" class="breadcrumb">
                <%--   <li><i class="icon-home"></i>Home </li>

                        <li>Shipment Details </li>--%>
                <li class="current" id="lbl" runat="server">Quick View </li>
            </ul>
        </div>
        <div >
            <div class="col-md-12  maindiv">

                <div class="widget box">

                    <div class="widget-header" style="display: none;">
                        <h4><i class="icon-umbrella"></i>
                            <asp:Label ID="LBLTitle" runat="server"></asp:Label></h4>
                    </div>
                    <div class="widget-content">
                        <div class="FormGroupContent4">
                            <div class="right_btn MT0">
                                <div class="BookinNo"><asp:label Text="Booking #" ID="BookingNo1" runat="server"></asp:label></div>
                            <div class="BookingTxtBox1">
                <asp:TextBox ID="txt_bookingno" runat="server" ToolTip="Booking #" placeholder="Booking #"
                    CssClass="form-control" ></asp:TextBox> <%-- OnTextChanged="txt_bookingno_TextChanged"--%>
            </div>


          
                                </div>
</div>
<div id="img1" style="float:left; margin:80px 0px 0px 0px; position:absolute;">
    <img src="Tabstyle/img/shipicon_ic.png" id="Shipic" runat="server" visible="false" />
    <img src="Tabstyle/img/airicon_ic.png" id="Airic" runat="server" visible="false"  />
</div>

<div style="width:924px; float:left; height:246px; overflow-x:auto; left:7%; position:relative; top:-80px;">


            <div class="RoundHeight" id="RoundHeight1" runat="server"></div>
            <div class="Round" id="RBooking" runat="server"></div>
            <div class="Round1" id="RStuffing" runat="server"></div>
            <div class="Round2" id="RSailling" runat="server"></div>
            <div class="Round3" id="RTranshipment" runat="server"></div>
            <div class="Round4" id="RDOReq" runat="server"></div>
            <div class="Round5" id="RDOCofirm" runat="server"></div>


           <div class="Round6" id="Originaldocsenton" runat="server"></div>

            <div class="Round7" id="releasedon" runat="server"></div>

            <div class="Round8" id="jodate1" runat="server"></div>

            <div class="Round9" id="Div1" runat="server"></div>
             <div class="Round10" id="Div2" runat="server"></div>
            <div class="Round11" id="Div3" runat="server"></div>
            <div class="Round12" id="Div4" runat="server"></div>
            <div class="Textlinkc1">

                 <div class="TxtLbl">
                       <span id ="lblbk" runat="server">Booking</span>
                    <label id="LblBookingDate" runat="server"></label>
                  
                </div>
                 <div class="TxtLbl1">
                     <span id ="lblsail" runat="server">Sailed</span>
                    <label id="LblSailingDate" runat="server"></label>
                </div>
                 <div class="TxtLbl2">
                   <span id ="lblstuf" runat="server">Stuffing</span>
                    <label id="LblStuffingDate" runat="server"></label>
                </div>                      
               
               
                <div class="TxtLbl3" id="lblClear1" runat="server" visible="false">


                     <span id="lblClear" runat="server">Clearance Pro On</span>
                    <label id="lblCleardate" runat="server"></label>


                </div>
                <div class="TxtLbl4" id="lbltran1" runat="server" visible="false">
                      <span id ="lbltran" runat="server">Transhipped</span>
                    <label id="LblTranshipmentDate" runat="server"></label>
                    
                </div>
                <div class="TxtLbl5" id="lblcargo1" runat="server" visible="false">
                     <span id="lblcargo" runat="server">Cargo Air On</span>
                    <label id="lblcargodate" runat="server"></label>
                </div>



                   <div class="TxtLbl6" id="lblOrig" runat="server" visible="false">
                        <span id ="lblDocon" runat="server">DO Confirm Request</span>
                    <label id="LblDOConfirmReqDate" runat="server"></label>
                   
                </div>

                     <div class="TxtLbl7" id="lblrel" runat="server" visible="false">
                          <span id="lblarr" runat="server">Arrival On</span>
                    <label id="lblarrdate" runat="server"></label>
                </div>

                 <div class="TxtLbl8" id="lbljob" runat="server" visible="false">
                       <span id ="lblOriginaldocsenton" runat="server"></span>
                    <label id="LblOriginaldocsentonDate" runat="server"></label>
                     
                </div>

                <div class="TxtLbl9" id="lbldel1" runat="server" visible="false">
                   
                    <span id="lbldel" runat="server">Delivery Update On</span>
                    <label id="lbldeldate" runat="server"></label>
                </div>
                 <div class="TxtLbl10" id="lblDoconfirmed1" runat="server" visible="false">
                       <span id ="lblDoconfirmed" runat="server">DO Confirmed</span>
                    <label id="LblDOConfirmedDate" runat="server"></label>
                  
                                      
                  
                </div>
                  <div class="TxtLbl11" id="lblreleasedonon1" runat="server" visible="false">
                       <span id ="lblreleasedonon" runat="server"></span>
                    <label id="lblreleasedondate" runat="server"></label>
                   
                </div>
                <div class="TxtLbl12" id="lbljobon1" runat="server" visible="false">

                     <span id ="lbljobon" runat="server"></span>
                    <label id="lbljobDte" runat="server"></label>
                </div>
                </div>
            </div>
                         <div class="Clear"></div>
             <div class="bordertopNew"></div>
                        <div class="Clear"></div>
				<div class="tabs tabs-style-bar">
					<nav>
						<ul>
							<li><a href="#section-bar-1" class="icon1"><span>UPDATES</span></a></li>
							<li><a href="#section-bar-2" class="icon2"><span>DETAILS</span></a></li>
							<li><a href="#section-bar-3" class="icon3"><span>DOUCUMENTS</span></a></li>
							<li><a href="#section-bar-4" class="icon4"><span>SPECIAL NOTES</span></a></li>
							<li><a href="#section-bar-5" class="icon5"><span>CLEARANCE</span></a></li>
						</ul>
					</nav>
					<div class="content-wrap">
						<section id="section-bar-1">
                            <p>Updates</p>
                           <%-- <div class="SectionC">
                            <div class="SectionL">Please be advised that the shipment has arrived as mentioned above.</div>
                            <div class="SectiorR"><asp:Label ID="lbl_Arrivalon" runat="server"></asp:Label></div>
                            </div>


                             <div class="SectionC">
                            <div class="SectionL">Kindly note that the DO has been issued for your Shipment,below details</div>
                            <div class="SectiorR"><asp:Label ID="lbl_doon" runat="server"></asp:Label></div>
                            </div>
                              <div class="SectionC">
                            <div class="SectionL">We are pleased to inform you that your shipment has been departed on the carrier details as Below</div>
                            <div class="SectiorR"><asp:Label ID="lbl_pickupon" runat="server"></asp:Label></div>
                            </div>
                             <div class="SectionC">
                            <div class="SectionL">Cargo Received for Loading</div>
                            <div class="SectiorR"><asp:Label ID="lbl_cargoloadon" runat="server"></asp:Label></div>
                            </div>
                             <div class="SectionC">
                            <div class="SectionL">Dear sir/madam Please find the attachment Pre Alert Documents for the subject shipment for your kind perusal</div>
                            <div class="SectiorR"><asp:Label ID="lbl_prealert" runat="server"></asp:Label></div>
                            </div>
                               <div class="SectionC">
                            <div class="SectionL">Shipment Status</div>
                            <div class="SectiorR"><asp:Label ID="lbl_shipment" runat="server"></asp:Label></div>
                            </div>--%>


                              <div class="FromTxtboxTxt1"><asp:TextBox ID="txt_status" runat="server"  placeholder="" CssClass="form-control" ToolTip="Status"  Style="resize: none;" Rows="20" TextMode="MultiLine" TabIndex="4" ></asp:TextBox> </div>
                            
						</section>
						<section id="section-bar-2">
                            <p>Goods Details</p>


                            <div class="GoodsDetail">


                                <div class="Head1">Booking #</div>
                                <div class="Head2">Booking Date</div>
                                <div class="Head3">HBL #</div>
                                
                                 <div class="Head4">Vessel /Voy</div>
                                <div class="Content1"><asp:Label ID="lbl_bkg" runat="server"></asp:Label></div>

                                <div class="Content2"><asp:Label ID="lbl_bkgdate" runat="server"></asp:Label></div>
                                <div class="Content3"><asp:Label ID="lbl_hbl" runat="server"></asp:Label></div>
                                <div class="Content4"><asp:Label ID="lbl_vslvou" runat="server"></asp:Label></div>

                                  <div class="Head1a">Shipper Name</div>
                                <div class="Head2b">Consignee Name</div>
                               

                                 <div class="Content1a"><asp:Label ID="lbl_shipper" runat="server"></asp:Label></div>

                                <div class="Content2b"><asp:Label ID="lbl_conginee" runat="server"></asp:Label></div>
                                

                                 <div class="Head1a1">POL</div>
                                <div class="Head2b2">POD</div>
                                <div class="Head3c3">FD</div>

                                 <div class="Content1a1"> <asp:Label ID="lbl_POL" runat="server"></asp:Label></div>

                                <div class="Content2b2"><asp:Label ID="lbl_POD" runat="server"></asp:Label></div>
                                <div class="Content3c3"><asp:Label ID="lbl_FD" runat="server"></asp:Label></div>


                                <div class="Head1a1">CBM</div>
                                <div class="Head2b2">Gross weight</div>
                                <div class="Head3c3">Net Weight</div>
                                 

                                 <div class="Content1a1"> <asp:Label ID="lbl_cbm" runat="server"></asp:Label></div>

                                <div class="Content2b2"><asp:Label ID="lbl_grwt" runat="server"></asp:Label></div>
                                <div class="Content3c3"><asp:Label ID="lbl_ntwt" runat="server"></asp:Label></div>


                                <div class="Head1aN">No of Pkgs</div>
                                <div class="Head2b1C">Container No's</div>                              
                                 

                                 <div class="Content1aN"> <asp:Label ID="lbl_noofpkg" runat="server"></asp:Label></div>

                                <div class="Content2b1C"><asp:Label ID="lbl_cont" runat="server"></asp:Label></div>
                               
                              


                            </div>






                          
                           
                            <div class="Clear"></div>

                          
						</section>
						<section id="section-bar-3">
                            <p>Documents</p>

                                    <asp:GridView ID="grpupdload" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader"  ForeColor="Black" OnRowDataBound="grpupdload_RowDataBound" OnSelectedIndexChanged="grpupdload_SelectedIndexChanged" ShowHeaderWhenEmpty="true" Width="100%">
                     <Columns>
                         <asp:BoundField DataField="docname" HeaderText="Doc Type">
                         <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                         <ItemStyle HorizontalAlign="Left" Width="15%" />
                         </asp:BoundField>
                         <asp:BoundField DataField="remarks" HeaderText="Remarks">
                         <HeaderStyle HorizontalAlign="Left" Wrap="true" Width="370px" />
                         <ItemStyle HorizontalAlign="Left" Width="370px" />
                         </asp:BoundField>
                         <asp:BoundField ControlStyle-CssClass="hide" DataField="doctype" HeaderText="docid">
                         <HeaderStyle CssClass="hide" HorizontalAlign="Left" Wrap="true" />
                         <ItemStyle CssClass="hide" HorizontalAlign="Left" Width="15%" />
                         </asp:BoundField>
                         <asp:BoundField DataField="docid" HeaderText="dcmtid">
                         <HeaderStyle CssClass="hide" HorizontalAlign="Left" Wrap="true" Width="350px" />
                         <ItemStyle CssClass="hide" HorizontalAlign="Left" Width="350px" />
                         </asp:BoundField>
                         <asp:BoundField DataField="fileloc" HeaderText="FileNameLoc"> 
                         <HeaderStyle  HorizontalAlign="Left" Wrap="true" Width="350px" /> <%-- CssClass="hide"--%>
                         <ItemStyle  HorizontalAlign="Left" Width="350px" /> <%--  CssClass="hide"--%>
                         </asp:BoundField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="PDF">
                        <ItemTemplate>
                           <asp:ImageButton ID="img_pdf" runat="server"  CommandName="select" ImageUrl="~/images/PDF.jpg"  />
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" HorizontalAlign="right" Width="20px" Height="20px"  />
                            <ItemStyle Font-Bold="false" Width="20px"  Height="20px" HorizontalAlign="Justify"/>
                        </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="">--%>
                       <%-- <ItemTemplate>
                        <asp:ImageButton ID="Img_Delete" runat="server" CommandName="Delete" 
                            ImageUrl="~/images/delete.jpg" />
                    </ItemTemplate>--%>
                   <%-- <HeaderStyle Wrap="false" HorizontalAlign="right" Width="20px"  />
                     <ItemStyle Font-Bold="false" Width="20px" HorizontalAlign="Justify"/>
                   
                </asp:TemplateField>--%>
                     </Columns>
                     <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                     <HeaderStyle CssClass="" />
                     <AlternatingRowStyle CssClass="GrdRow" />
                 </asp:GridView>

						</section>
						<section id="section-bar-4">
                               <p>SPECIAL NOTES</p>
                            <div class="FromLeft"><asp:Label Text="From" ID="fromLbl" runat="server"></asp:Label> </div>
                            <div class="FromTxtbox"><asp:TextBox ID="txt_from" runat="server"  CssClass="form-control" ToolTip="From" TabIndex="1" ></asp:TextBox></div>
                            <div class="Clear"></div>
                            <div class="FormLeft1">
                                <div class="FromLeftn1"><asp:Label Text="To" ID="Label1" runat="server"></asp:Label></div>
                               <div class="FromTxtbox1">  <asp:TextBox ID="txt_to" runat="server"  placeholder="" CssClass="form-control" ToolTip="To" TabIndex="2" ></asp:TextBox> </div>
                            </div>
                             <div class="FormLeft2">
                                  <div class="FromLeftn1"><asp:Label Text="CC" ID="Label2" runat="server"></asp:Label></div>
                               <div class="FromTxtbox1">  <asp:TextBox ID="txt_cc" runat="server"  placeholder="" CssClass="form-control" ToolTip="CC" TabIndex="3" ></asp:TextBox> </div>
                                 </div>
                             
                            <div class="FromLeft"><asp:Label Text="Special Notes/instructions" ID="Label3" runat="server"></asp:Label> </div>
                           
                            <div class="FromTxtboxTxt">
                                       <asp:TextBox ID="txt_note" runat="server"  placeholder="" CssClass="form-control" ToolTip="Special Notes"  Style="resize: none;" Rows="7" TextMode="MultiLine" TabIndex="4" >

                                </asp:TextBox> 

                            </div>

                            <div style="float:left; margin:0px 0px 0px 10px;">

                                 <div class="btn ico-send"> <asp:Button ID="btnsend" runat="server" ToolTip="Send"  TabIndex="16" OnClick="btnsend_Click" /></div>
                            </div>
                          <div class="Clear"></div>
						</section>
						<section id="section-bar-5">
                             <p>Clearance</p>
                              <div id="DivCount" runat="server" class="DivGrid">
                                        <asp:GridView ID="Grd" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader"  Width="100%" ShowHeaderWhenEmpty="true">
                                            <Columns>
                                                <asp:BoundField DataField="Clearance" HeaderText="Clearance ">
                                                    <HeaderStyle Width="420px" />
                                                    <ItemStyle Width="420px" Wrap="True"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Status" HeaderText="Status">
                                                    <HeaderStyle Width="80px" />
                                                    <ItemStyle Wrap="True" Width="100px"></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                            <RowStyle CssClass="GrdRow" />
                                            <HeaderStyle CssClass="GrdHeader " />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                        </asp:GridView>

                                    </div>
                             <div class="Clear"></div>
						</section>
					</div><!-- /content -->
				</div><!-- /tabs -->
			           
                        
                    </div>
                </div>
            </div>


             <asp:HiddenField ID="hid_poddownload" runat="server" />
              <asp:HiddenField ID="hid_branchid" runat="server" />

            
        </div>




        <script src="js/cbpFWTabs.js"></script>
		<script>
		    (function () {

		        [].slice.call(document.querySelectorAll('.tabs')).forEach(function (el) {
		            new CBPFWTabs(el);
		        });

		    })();
		</script>

        <script>
            

            function imagemove1FE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '50px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove2FE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '110px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }

            function imagemove3FE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '190px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }

            function imagemove4FE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '230px',

                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove5FE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '330px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove6FE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '390px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove7FE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '440px',   //done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove8FE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '500px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove9FE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '580px', //done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }

            function imagemove10FE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '630px',//done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }

            function imagemove11FE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '700px', //done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove12FE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '770px',//done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }
            function imagemove13FE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '815px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }





            function imagemove1FI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '50px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove2FI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '110px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }

            function imagemove3FI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '190px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }

            function imagemove4FI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '230px',

                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove5FI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '330px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove6FI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '390px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove7FI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '440px',   //done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove8FI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '500px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove9FI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '580px', //done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }

            function imagemove10FI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '630px',//done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }

            function imagemove11FI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '700px', //done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove12FI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '770px',//done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }
            function imagemove13FI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '820px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove14FI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '870px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }



            function imagemove1AE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '50px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove2AE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '110px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }

            function imagemove3AE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '190px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }

            function imagemove4AE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '230px',

                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove5AE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '330px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove6AE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '390px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove7AE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '440px',   //done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove8AE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '500px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove9AE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '580px', //done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }

            function imagemove10AE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '630px',//done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }

            function imagemove11AE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '700px', //done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove12AE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '770px',//done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }
            function imagemove13AE() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '815px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }










            function imagemove1AI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '50px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove2AI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '110px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }

            function imagemove3AI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '190px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }

            function imagemove4AI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '230px',                           

                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove5AI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '330px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove6AI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '390px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove7AI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '440px',   //done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove8AI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '500px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove9AI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '580px', //done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }

            function imagemove10AI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '630px',//done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }

            function imagemove11AI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '700px', //done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }


            function imagemove12AI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '770px',//done
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }
            function imagemove13AI() {
                $(document).ready(function () {


                    $("#img1").animate(
                        {
                            left: '815px',
                            height: '150px',
                            width: '150px'
                        }, 5500

                        );

                });
            }

        </script>


    </form>
</body>
</html>
