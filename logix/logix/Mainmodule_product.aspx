<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Mainmodule_product.aspx.cs" Inherits="logix.Mainmodule_product" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>
    <link href="Styles/MainModuleNew.css" rel="stylesheet" type="text/css" />
    <link href="Styles/CompanyProfile.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/Newhome.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/product/css/custom-style.css" rel="stylesheet" />
    <link href="Theme/assets/product/css/systemtproduct.css" rel="stylesheet" />
    <link href="Theme/assets/css/agencyhome.css" rel="stylesheet" />
    <script src="Theme/assets/product/js/jquery.js"></script>
    <script src="Theme/assets/product/js/jquery_002.js"></script>
    <script src="Theme/assets/product/js/jquery_002.js"></script>
    <link rel="stylesheet" href="Theme/assets/css/fontawesome/font-awesome.min.css" />

    <link rel="stylesheet" href="Theme/assets/tab/js/main.css" />
    <script type="text/javascript" src="Theme/assets/tab/js/tabs.js"></script>
    <link rel='stylesheet' href='http://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css'>
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js" type="text/javascript"></script>--%>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <script type="text/javascript">
        $(function () {
            //----- OPEN
            $('[data-popup-open]').on('click', function (e) {
                var targeted_popup_class = jQuery(this).attr('data-popup-open');
                $('[data-popup="' + targeted_popup_class + '"]').fadeIn(350);

                e.preventDefault();
            });

            //----- CLOSE
            $('[data-popup-close]').on('click', function (e) {
                var targeted_popup_class = jQuery(this).attr('data-popup-close');
                $('[data-popup="' + targeted_popup_class + '"]').fadeOut(350);

                e.preventDefault();
            });
        });

        jQuery(document).ready(function () {
            jQuery('.tabs .tab-links a').on('click', function (e) {
                var currentAttrValue = jQuery(this).attr('href');

                // Show/Hide Tabs
                jQuery('.tabs ' + currentAttrValue).show().siblings().hide();

                // Change/remove current tab to active
                jQuery(this).parent('li').addClass('active').siblings().removeClass('active');

                e.preventDefault();
            });
        });
    </script>
    <%--   <link href="../Styles/ControlStyle2.css" rel="Stylesheet" type="text/css" />
    <script src="../ScriptsAuto/jquery.min.js" type="text/javascript"></script>
    <script src="../ScriptsAuto/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
         <link href="../Styles/chosen.css" rel="stylesheet" />
   <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>--%>

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />
    <link rel="stylesheet" href="Theme/marquee/css/marquee.css" />
    <%--  <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>--%>
    <link href="Theme/MenuToggle/drawer.minP.css" rel="stylesheet" />

    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>
    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {

            });
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>

</head>
<style type="text/css">
    .modalPopupsskpi {
        background-color: #FFFFFF;
        border: 1px solid #b1b1b1;
        /*width: 1062px;*/
        width: 39%;
        Height: 250px;
        margin-left: 0%;
        margin-top: 0%;
        margin-right: 0%;
        /*padding:1px;            
            display:none;*/
    }

    .div_txt textarea {
        height: 360px !important;
        width: 100% !important;
        margin: 0px 0px 0px 0px;
        line-height: 22px;
    }

    .DivSecPanelkpi {
        width: 20px;
        Height: 20px;
        border: 1px solid #b1b1b1;
        margin-left: 98.3%;
        margin-top: -1.5%;
        border-radius: 90px 90px 90px 90px;
    }

    .Gridpnkpi {
        width: 100%;
        Height: 220px;
    }

    .Tab_Text_Multiline1 {
        font-family: sans-serif;
        font-style: normal;
        margin-left: 0px;
        width: 100%;
        height: 425px;
        /*resize:none;*/ overflow: auto;
    }

    .Tab_Text_Multiline2 {
        font-family: sans-serif, Geneva, sans-serif !important;
        font-size: 11px;
        font-style: normal;
        margin-left: 0.5px;
        width: 100%;
        height: 150px;
        overflow: auto;
        color: #4c4c4c !important;
    }

    .Tab_Text_Multiline4 {
        font-family: sans-serif;
        font-size: 8pt;
        font-style: normal;
        border-style: solid;
        border-width: 1px;
        margin-left: 0.5px;
        border-color: Black;
        width: 100%;
        overflow: auto;
    }

    .Tab_Text_MultilineN {
        font-family: sans-serif, Geneva, sans-serif !important;
        font-size: 11px;
        font-style: normal;
        margin-left: 0.5px;
        width: 100% !important;
        height: 350px !important;
        overflow: auto !important;
        color: #4c4c4c !important;
    }

    .FormGroupContentmainmodule textarea {
        height: 300px !important;
        cursor: default !important;
        padding: 5px 5px 5px 5px;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_tab {
        background-image: none !important;
        background-color: #0077c9;
        color: #ffffff !important;
        border-top-left-radius: 3px;
        border-top-right-radius: 3px;
    }

    .Tab_Text_Multiline1 p {
        padding: 5px 5px 0 15px;
        font-size: 11px;
    }

    .Tab_Text_Multiline1 ul li {
        color: #525252 !important;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_inner {
        background-image: none !important;
        /*border-left: 1px solid #b1b1b1;*/
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_inner {
        padding-left: 0px !important;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_tab {
        padding: 5px 5px 5px 5px !important;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_outer {
        background-image: none !important;
        /*border-right: 1px solid #b1b1b1;*/
        margin: 0px 0px 0px 0px;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_outer {
        padding-right: 0px !important;
    }

    .ajax__tab_active {
        padding: 0px 0px 0px 0px !important;
    }

    #Tab_header > span {
        margin: 0 8px 0 0;
    }

    #TabContainer1_header > span {
        margin: 0 6px 0 0;
    }

    #__tab_Tab_TabPanel1 > span {
        font-size: 11px;
        padding: 10px 10px;
        margin: 0px 0px 0px 0px;
    }

    .ajax__tab_default .ajax__tab_tab {
        /*color:#ffffff;*/
    }

    .ajax__tab_default {
        color: #ffffff !important;
    }

    #__tab_Tab_TabPanel8 > span {
        /*color: #4c4c4c;*/
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    .ajax__tab_tab {
        /*color: #4e4e4c!important;*/
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    .tab-content a {
        color: #4e4e4c;
    }

    #__tab_Tab_TabPanel2 > span {
        /*color: #4c4c4c;*/
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_Tab_TabPanel3 > span {
        /*color: #4c4c4c;*/
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_Tab_TabPanel7 > span {
        /*color: #4c4c4c;*/
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_Tab_TabPanel4 > span {
        /*color: #4c4c4c;*/
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_Tab_TabPanel5 > span {
        /*color: #4c4c4c;*/
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_Tab_TabPanel6 > span {
        /*color: #4c4c4c;*/
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer1_TabPanel9 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer1_TabPanel10 > span {
        /*color: #4c4c4c;*/
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer1_TabPanel11 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer1_TabPanel12 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer1_TabPanel13 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer2_TabPanel14 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer2_TabPanel15 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer2_TabPanel16 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer2_TabPanel17 > span {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer4_TabPanel22 > span {
        /*color: #4c4c4c;*/
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #TabContainer2_header > span {
        margin: 0 5px 0 0;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_tab {
        background-image: none !important;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_inner {
        background-image: none !important;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_outer {
        background-image: none !important;
    }

    .Tab_Text_Multiline1 ul {
        margin: 0;
        padding: 0 5px 5px 29px;
    }

    .disabledbutton {
        pointer-events: none;
        opacity: 0.4;
    }

    .HomeGroup {
        width: 20%;
        float: left;
        margin: 50px 20px 36px 30px;
    }

    .TabMenu {
        float: left;
        width: 738px;
        margin: 55px 0px 36px 20px;
    }

    .tab-content {
        padding: 5px 0px 10px 0px;
        border-radius: 0px;
        box-shadow: 0px 0px 0px rgba(0,0,0,0.15);
        background: #fff;
        border: 0px solid #b1b1b1;
        height: 440px;
        margin: 0px 0px 0px 0px;
        width: 100%;
    }

    .tab-links li.active a {
        border-top: 1px solid #a6b5bf;
        border-left: 1px solid #a6b5bf;
        border-right: 1px solid #a6b5bf;
        background-color: #0077c9;
        color: #ffffff;
    }

    .div_Grid1 {
        border: 1px solid #b1b1b1;
        height: 366px;
    }

    .ajax__tab_xp .ajax__tab_body {
        font-family: verdana,tahoma,helvetica;
        /*font-size: 10pt;*/
        /*border: 1px solid #999999;*/
        border-top: 0;
        padding: 8px;
        background-color: #ffffff;
        height: 410px !important;
        overflow: auto;
        margin: 5px 0px 0px 0px;
    }

    .ajax__tab_xp .ajax__tab_body {
        border: none !important;
    }

    .div_txt_Mission {
        float: left;
        height: 150px;
        margin-bottom: 0;
        margin-left: 0;
        margin-top: 0;
        min-height: 100%;
        width: 100%;
    }

    .div_txt_Mission_MEDICLAIM {
        float: left;
        margin-bottom: 0;
        margin-left: 0;
        margin-top: 0;
        width: 100%;
    }

    .div_txt_Mission_MEDICLAIMcont {
        float: left;
        margin-bottom: 0;
        margin-left: 0;
        margin-top: 0;
        width: 100%;
        height: 60px;
    }

    .LoginLeft {
        width: 223px;
        float: left;
        height: 400px;
        margin: 55px 20px 0px 20px;
    }

    .OECSBox {
        width: 118px;
        float: left;
        background-color: #042a4c;
        min-height: 94px;
        margin: 10px 10px 0px 0px;
    }

    .OECSBox1 {
        width: 118px;
        float: left;
        background-color: #d02027;
        min-height: 94px;
        margin: 10px 0px 0px;
    }

    .BT {
        width: 118px;
        float: left;
        background-color: #433d27;
        min-height: 94px;
        margin: 10px 10px 0px 0px;
    }

    .CHA {
        width: 118px;
        float: left;
        background-color: #0a4e29;
        min-height: 94px;
        margin: 10px 10px 0px 0px;
    }

    .MIS {
        width: 118px;
        float: left;
        background-color: #185074;
        min-height: 94px;
        margin: 10px 10px 0px 0px;
    }

    .OpsAccounts {
        width: 118px;
        float: left;
        background-color: #990000;
        min-height: 94px;
        margin: 10px 0px 0px 0px;
    }

    .Hide {
        display: none;
    }

    .tab-content a {
        border-top-left-radius: 3px;
        border-top-right-radius: 3px;
    }

    .NewsMarquee {
        /*border: 1px solid #fff;*/
        color: #fff;
        top: 25%;
        margin: 0px auto;
        position: relative;
        width: 98%;
    }

    @media only screen and (max-width: 1280px) {

        .TabMenu {
            float: left;
            width: 48%;
            margin: 55px 0px 36px 20px;
        }
    }

    .modalPopupsskpi {
        background-color: #FFFFFF;
        border: 1px solid #b1b1b1;
        /* width: 1062px; */
        width: 50%;
        Height: 250px;
        margin-left: -3%;
        margin-top: 0%;
        margin-right: 0%;
    }

    .PaymentCancel {
        float: right;
        margin: -15px 15px 0px 0px;
        padding: 0px 0px 0px 0px;
    }

        .PaymentCancel a {
            color: #0077c9;
            font-weight: 200;
            vertical-align: bottom;
            font-family: 'Segoe UI';
        }

    .tab-content > .active {
        display: block;
        margin: -5px 0px 0px 0px;
    }

    .div_label {
        width: 100%;
        float: left;
        margin-top: 0.3%;
        margin-left: 0%;
        margin-bottom: 0.3%;
        padding-bottom: 2px;
        border-bottom: 1px dotted #b1b1b1;
        font-weight: normal;
    }

    .ajax__tab_xp .ajax__tab_header {
        font-family: verdana,tahoma,helvetica;
        font-size: 11px;
        background-repeat: repeat-x;
        background-image: none !important;
        background-position: bottom;
        height: 29px;
        border-bottom: 1px solid #c8c8c8;
    }

    #__tab_TabContainer1_TabPanel14 > span {
        /*color: #4c4c4c;*/
        font-size: 11px;
        margin: 0;
        padding: 2px;
    }

    #__tab_TabContainer1_TabPanel15 > span {
        /*color: #4c4c4c;*/
        font-size: 11px;
        margin: 0;
        padding: 2px;
    }

    #__tab_TabContainer1_TabPanel16 > span {
        /*color: #4c4c4c;*/
        font-size: 11px;
        margin: 0;
        padding: 2px;
    }

    #__tab_TabContainer1_TabPanel17 > span {
        /*color: #4c4c4c;*/
        font-size: 11px;
        margin: 0;
        padding: 2px;
    }

    #__tab_TabContainer2_TabPanel23 > span {
        font-size: 11px;
        margin: 0;
        padding: 2px;
    }

    #__tab_TabContainer3_TabPanel18 > span {
        /*color: #4c4c4c;*/
        font-size: 11px;
        margin: 0;
        padding: 2px;
    }

    #__tab_TabContainer3_TabPanel19 > span {
        /*color: #4c4c4c;*/
        font-size: 11px;
        margin: 0;
        padding: 2px;
    }

    #__tab_TabContainer4_TabPanel20 > span {
        /*color: #4c4c4c;*/
        font-size: 11px;
        margin: 0;
        padding: 2px;
    }

    #__tab_TabContainer4_TabPanel21 > span {
        /*color: #4c4c4c;*/
        font-size: 11px;
        margin: 0;
        padding: 2px;
    }

    .div_labelPF {
        width: 100%;
        float: left;
        margin-top: 0%;
        margin-left: 0%;
        margin-bottom: 0.5%;
        padding-bottom: 2px;
        border-bottom: 1px dotted #b1b1b1;
        font-weight: bold;
    }

    .div_txt_Mission1 {
        float: left;
        width: 100%;
        margin-left: 0%;
        margin-top: 0%;
        margin-bottom: 0%;
        min-height: 100%;
        height: 48px;
    }

    .div_txt_MissionESI {
        float: left;
        width: 100%;
        margin-left: 0%;
        margin-top: 0%;
        margin-bottom: 0%;
        min-height: 100%;
        height: 55px;
        /*overflow-x:hidden;
    overflow-y:auto;*/
    }

    .div_txt_MissionRE {
        float: left;
        width: 100%;
        margin-left: 0%;
        margin-top: 0%;
        margin-bottom: 0%;
        min-height: 100%;
        height: 87px;
        overflow-x: hidden;
        overflow-y: hidden;
    }

    .div_txt_MissionESI textarea {
        height: auto !important;
    }

    .div_txt_MissionRE textarea {
        height: 100px !important;
    }

    .div_txtN1 {
        float: left;
        width: 100%;
        margin-left: 0%;
        margin-top: 0%;
        margin-bottom: 0%;
        min-height: 100%;
        /*height: 90px;*/
    }

    .popup-inner h3 {
        background: rgba(0, 0, 0, 0) url("Theme/assets/img/arrow.png") no-repeat scroll left 12px;
        color: #df2b2b;
        font-family: sans-serif,Geneva,sans-serif;
        font-size: 14px;
        line-height: 17px;
        margin: 5px;
        padding: 4px 5px 5px 10px;
    }

    .Tab_Text_MultilineIns {
        font-family: sans-serif, Geneva, sans-serif !important;
        font-size: 11px;
        font-style: normal;
        margin-left: 0.5px;
        width: 100%;
        height: 480px;
        overflow: hidden;
        color: #4c4c4c !important;
        line-height: 22px;
    }

    .FinancialAc a:hover {
        text-decoration: none !important;
    }

    marquee {
        float: left;
    }

    .ProductBG {
        width: 100%;
        margin: 10px auto 0px auto;
        height: 100vh;
        /*background: #f8f9fc !important;*/
        display: flex;
    }

    .BlueOuterDiv {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #4e73df !important;
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
        margin: 0px 0px 25px 15px;
        float: left;
        color: #4e73df !important;
    }

    .BlueRightSideDown {
        color: #4e73df !important;
        font-family: 'OpenSansSemibold';
        margin: 0px 10px 0px 0px;
        float: right;
        text-align: right;
        width: 75%;
        font-size: 22px;
    }

    .GreenOuterDiv {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #1cc88a !important;
        float: left;
        background-color: #fff;
        height: 110px;
        padding: 15px 0px 5px 0px;
        width: 185px;
        margin: 5px 8px 0px 10px;
    }

    a#CRM {
        display: none;
    }

    .GreenOuterDiv:hover {
        box-shadow: 1px 4px 20px grey;
        -webkit-transition: box-shadow .3s ease-in;
    }

    .GreenText {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 8px 15px;
        float: left;
        color: #1cc88a !important;
    }

    .LiteBlueOuter {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #36b9cc !important;
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

    .LiteBlueText {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 25px 15px;
        float: left;
        color: #36b9cc !important;
    }

    .YellowOuterDiv {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #f6c23e !important;
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

    .YellowText {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 25px 15px;
        float: left;
        color: #f6c23e !important;
    }

    .GreenOuterDiv2 {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #1cc88a !important;
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

    .GreenText2 {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 25px 15px;
        float: left;
        color: #1cc88a !important;
    }

    .BlueOuterDiv2 {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #4e73df !important;
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

    .Blue2Text {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 30px 15px;
        float: left;
        color: #4e73df !important;
    }

    .RedOuterDiv {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #e74a3b !important;
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

    .RedText {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 25px 15px;
        float: left;
        color: #e74a3b !important;
    }

    select#ddl_FAYear {
        height: 24px;
        width: 64px !important;
        background-color: #f8f9fc;
        margin: 0px 0px 0px 48px;
    }

    /*Small Card Css*/

    .SmallLiteBlueOuter1 {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #36b9cc !important;
        float: left;
        background-color: #fff;
        height: 80px;
        padding: 15px 0px 5px 0px;
        width: 185px;
        margin: 5px 8px 0px 10px;
    }

        .SmallLiteBlueOuter1:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }

    .SmallLiteBlueText1 {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 0px 15px;
        float: left;
        color: #36b9cc !important;
    }

    .SmallLiteBlueOuter2 {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #36b9cc !important;
        float: left;
        background-color: #fff;
        height: 80px;
        padding: 15px 0px 5px 0px;
        width: 185px;
        margin: 5px 8px 0px 0px;
    }

        .SmallLiteBlueOuter2:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }

    .SmallLiteBlueText2 {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 0px 15px;
        float: left;
        color: #36b9cc !important;
    }

    .SmallLiteBlueOuter3 {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #36b9cc !important;
        float: left;
        background-color: #fff;
        height: 80px;
        padding: 15px 0px 5px 0px;
        width: 185px;
        margin: 5px 8px 0px 0px;
    }

        .SmallLiteBlueOuter3:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }

    .SmallLiteBlueText3 {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 0px 15px;
        float: left;
        color: #36b9cc !important;
    }

    .SmallLiteBlueOuter4 {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #36b9cc !important;
        float: left;
        background-color: #fff;
        height: 80px;
        padding: 15px 0px 5px 0px;
        width: 185px;
        margin: 5px 8px 0px 0px;
    }

        .SmallLiteBlueOuter4:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }

    .SmallLiteBlueText4 {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 0px 15px;
        float: left;
        color: #36b9cc !important;
    }

    .SmallLiteBlueOuter5 {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #36b9cc !important;
        float: left;
        background-color: #fff;
        height: 80px;
        padding: 15px 0px 5px 0px;
        width: 185px;
        margin: 5px 8px 0px 0px;
    }

        .SmallLiteBlueOuter5:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }

    .SmallLiteBlueText5 {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 0px 15px;
        float: left;
        color: #36b9cc !important;
    }

    .SmallLiteBlueOuter6 {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #36b9cc !important;
        float: left;
        background-color: #fff;
        height: 80px;
        padding: 15px 0px 5px 0px;
        width: 185px;
        margin: 5px 8px 0px 0px;
    }

        .SmallLiteBlueOuter6:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }

    .SmallLiteBlueText6 {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 0px 15px;
        float: left;
        color: #36b9cc !important;
    }

    .SmallYellowOuterDiv1 {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #f6c23e !important;
        float: left;
        background-color: #fff;
        height: 80px;
        padding: 15px 0px 5px 0px;
        width: 185px;
        margin: 5px 8px 0px 12px;
    }

        .SmallYellowOuterDiv1:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }

    .SmallYellowText1 {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 0px 15px;
        float: left;
        color: #f6c23e !important;
    }

    .SmallYellowOuterDiv2 {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #f6c23e !important;
        float: left;
        background-color: #fff;
        height: 80px;
        padding: 15px 0px 5px 0px;
        width: 185px;
        margin: 5px 8px 0px 0px;
    }

        .SmallYellowOuterDiv2:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }

    .SmallYellowText2 {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 0px 15px;
        float: left;
        color: #f6c23e !important;
    }

    .SmallYellowOuterDiv3 {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #f6c23e !important;
        float: left;
        background-color: #fff;
        height: 80px;
        padding: 15px 0px 5px 0px;
        width: 185px;
        margin: 5px 8px 0px 0px;
    }

        .SmallYellowOuterDiv3:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }

    .SmallYellowText3 {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 0px 15px;
        float: left;
        color: #f6c23e !important;
    }

    .SmallYellowOuterDiv4 {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #f6c23e !important;
        float: left;
        background-color: #fff;
        height: 80px;
        padding: 15px 0px 5px 0px;
        width: 185px;
        margin: 5px 8px 0px 0px;
    }

        .SmallYellowOuterDiv4:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }

    .SmallYellowText4 {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 0px 15px;
        float: left;
        color: #f6c23e !important;
    }

    .SmallYellowOuterDiv5 {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #f6c23e !important;
        float: left;
        background-color: #fff;
        height: 80px;
        padding: 15px 0px 5px 0px;
        width: 185px;
        margin: 5px 8px 0px 0px;
    }

        .SmallYellowOuterDiv5:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }

    .SmallYellowText5 {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 0px 15px;
        float: left;
        color: #f6c23e !important;
    }

    .SmallYellowOuterDiv6 {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #f6c23e !important;
        float: left;
        background-color: #fff;
        height: 80px;
        padding: 15px 0px 5px 0px;
        width: 185px;
        margin: 5px 8px 0px 0px;
    }

        .SmallYellowOuterDiv6:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }

    .SmallYellowText6 {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 0px 15px;
        float: left;
        color: #f6c23e !important;
    }

    .RedRightSideDown {
        color: #e74a3b !important;
        margin: 0px 13px 0px 0px;
        font-family: 'OpenSansSemibold';
        float: right;
        font-size: 22px;
        width: 75%;
        text-align: right;
    }

    .LtBlueRightSideDown {
        color: #36b9cc !important;
        margin: 0px 17px 0px 0px;
        font-family: 'OpenSansSemibold';
        float: right;
        font-size: 22px;
        width: 75%;
        text-align: right;
    }

    .YellowRightSideDown {
        color: #f6c23e !important;
        margin: 0px 10px 0px 0px;
        font-family: 'OpenSansSemibold';
        float: right;
        font-size: 22px;
        width: 75%;
        text-align: right;
        /*transform: rotate(-179deg);*/
    }

    .GreenRightSideDown {
        color: #1cc88a !important;
        margin: 0px 18px 0px 0px;
        font-family: 'OpenSansSemibold';
        float: right;
        font-size: 22px;
        width: 75%;
        text-align: right;
    }

    .Blue2RightSideDown {
        color: #4e73df !important;
        font-family: 'OpenSansSemibold';
        margin: 0px 14px 0px 0px;
        float: right;
        font-size: 22px;
        width: 75%;
        text-align: right;
    }

    .SmallLtBlueRightSideDown1 {
        color: #36b9cc !important;
        margin: 9px 6px 0px 0px;
        font-family: 'OpenSansSemibold';
        float: right;
        font-size: 22px;
        width: 75%;
        text-align: right;
    }

    .SmallLtBlueRightSideDown6 {
        color: #36b9cc !important;
        margin: 6px 8px 0px 0px;
        font-family: 'OpenSansSemibold';
        float: right;
        font-size: 22px;
        width: 50%;
        text-align: right;
    }

    .SmallLtBlueRightSideDown2 {
        color: #36b9cc !important;
        margin: 9px 13px 0px 0px;
        font-family: 'OpenSansSemibold';
        float: right;
        font-size: 22px;
        width: 75%;
        text-align: right;
    }

    .SmallLtBlueRightSideDown3 {
        color: #36b9cc !important;
        margin: 5px 8px 0px 0px;
        font-family: 'OpenSansSemibold';
        float: right;
        font-size: 22px;
        transform: rotate( -39deg );
        width: 34%;
        text-align: right;
    }

    .SmallLtBlueRightSideDown4 {
        color: #36b9cc !important;
        margin: -2px -1px 0px 0px;
        font-family: 'OpenSansSemibold';
        float: right;
        font-size: 22px;
        transform: rotate( 144deg );
        width: 34%;
        text-align: right;
    }

    .SmallYellowRightSideDown1 {
        color: #f6c23e !important;
        margin: 9px 6px 0px 0px;
        font-family: 'OpenSansSemibold';
        float: right;
        font-size: 22px;
        width: 75%;
        text-align: right;
    }

    .SmallYellowRightSideDown6 {
        color: #f6c23e !important;
        margin: 6px 8px 0px 0px;
        font-family: 'OpenSansSemibold';
        float: right;
        font-size: 22px;
        width: 50%;
        text-align: right;
    }

    .SmallYellowRightSideDown2 {
        color: #f6c23e !important;
        margin: 9px 12px 0px 0px;
        font-family: 'OpenSansSemibold';
        float: right;
        font-size: 22px;
        width: 75%;
        text-align: right;
    }

    .SmallYellowRightSideDown3 {
        color: #f6c23e !important;
        margin: 1px 6px 0px 0px;
        font-family: 'OpenSansSemibold';
        float: right;
        font-size: 22px;
        transform: rotate( -39deg );
        width: 34%;
        text-align: right;
    }

    .SmallYellowRightSideDown4 {
        color: #f6c23e !important;
        margin: -2px -0px 0px 0px;
        font-family: 'OpenSansSemibold';
        float: right;
        font-size: 22px;
        transform: rotate(144deg);
        width: 34%;
        text-align: right;
    }

    .AgencyHomeBox {
        width: 100%;
        float: left;
        margin: 35px 0px 0px 0px;
    }

    .PendingTblGrid th {
        border: 1px solid #b1b1b1;
        text-align: center;
        color: #fff;
        font-size: 11px;
        font-family: sans-serif, Geneva, sans-serif;
        background-color: #4a9cce;
        padding: 2px 2px 2px 3px;
        margin: 0px;
    }

    .mid_div {
        float: right;
        margin: 0px 0px 0px 0px;
    }

    .PendingRightnewLRightNew1 {
        float: left;
        width: 70%;
        margin: 0px 5px 0px 12px;
        background-color: var(--white);
        position: relative;
    }

    .lineChart {
        width: 100%;
        font-size: 11px;
        font-family: sans-serif;
        color: darkslategray;
        height: 42px;
        padding: 0.75rem 1.25rem;
        margin-bottom: 0;
        background-color: #fff;
    }

    .PendingRightnewChart {
        float: left;
        margin: 0px 5px 0px 0px;
        width: 30%;
        background-color: var(--white);
        position: relative;
    }

    .piechart {
        width: 350px;
        height: 42px;
        font-family: sans-serif;
        padding: 0.75rem 1.25rem;
        margin-bottom: 0;
        background-color: #fff;
        font-size: 11px;
        color: darkslategrey;
    }

    .Unclosed {
        float: left;
        margin: 0px 7px 0px 0px;
        width: 210px;
    }

        .Unclosed h3 {
            font-family: sans-serif;
            color: darkslategray;
            font-size: 11px;
            padding: 5px 0px 0px 0px;
            margin: 5px 0px 0px 0px;
        }
    /*.PendingTbl2 {
    width: 185px;
    float: left;
    margin: 5px 0px 0px 10px;
    max-height: 188px!important;
    min-height: 313px!important;
    overflow: auto;
}*/
    .PendingTbl2 {
        width: 100%;
        float: left;
        margin: 5px 0px 0px 5px;
        max-height: 450px;
        min-height: 450px;
        overflow: auto;
    }

    body {
        font-family: 'OpenSansRegular', "Helvetica Neue", Helvetica, Arial, sans-serif !important;
        color: #000 !important;
        font-size: 13px !important;
    }

    a#OperatingAccounts {
        display: none;
    }

    table#Gridexrate td:nth-child(2), td:nth-child(3) {
        text-align: right;
    }
</style>
<link rel="stylesheet" href="https://kit.fontawesome.com/169cce9a93.css" crossorigin="anonymous" />

<script src="https://kit.fontawesome.com/169cce9a93.js" crossorigin="anonymous"></script>
<style>
    /*left_menu Design Styles*/
    .left_menu {
        display: flex;
        float: left;
        position: relative;
    }

    .left_menu_1 {
        width: 50px;
        /* background-color: #f8f9fc; */
        height: 100vh;
    }

    .left_menu_icon {
        padding: 10px;
    }

        .left_menu_icon i {
            width: 30px;
            height: 30px;
            background-color: var(--navbarcolor);
            color: white;
            text-align: center;
            line-height: 30px;
            border-radius: 3px;
            display: flex;
            justify-content: center;
            align-items: center;
        }

    .left_menu_2 {
        width: 135px;
        height: 100vh;
        background-color: #fff;
        margin-left: 0px;
        position: absolute;
        top: 0;
        left: 50px;
        z-index: 3;
    }

    .left_menu_content {
        padding: 10px 10px 10px 0;
    }

        .left_menu_content a {
            text-decoration: none;
            color: var(--navbarcolor);
            height: 30px;
            line-height: 30px;
            border: 1px solid var(--navbarcolor);
            display: block;
            padding: 0 10px;
            border-radius: 3px;
            display: flex;
            align-items: center;
        }

        .left_menu_content span {
            font-size: 13px;
            margin-left: 5px;
        }

        .left_menu_content a:hover {
            color: #fff;
            background-color: var(--navbarcolor);
        }

        .left_menu_content a i {
            font-size: 15px;
        }

        .left_menu_content a span {
            font-size: 10px !important;
        }

    .show {
        display: block !important;
    }
</style>

<script>
    function left_menu() {
        $(".left_menu_2").hide();

        $(".left_menu_1").mouseover(function () {
            $(".left_menu_2").show();
        });
        $(".left_menu_2").mouseleave(function () {
            $(".left_menu_2").hide();
        });
    }
</script>

<body class="drawer drawer--left">

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600">
        </asp:ScriptManager>
        <div id="container">
            <!-- New Product Style Start -->
            <div class="ProductBG">
                <button type="button" class="drawer-toggle drawer-hamburger" title="Toggle Navigation" style="display: none;">
                    <span class="sr-only">toggle navigation</span>
                    <span class="drawer-hamburger-icon"></span>
                </button>
                <nav class="drawer-nav" role="navigation">
                    <!--=== Navigation Starts ===-->
                    <ul id="nav" class="drawer-menu">
                       
                         <li><a class="btn ComapnyIc" data-popup-open="popup-1" href="#">Company Profile</a></li>
        <li><a href="#" class="btn ITPolicyIc" data-popup-open="popup-2">IT Policy</a></li>
        <li><a href="#" class="btn EBIC" data-popup-open="popup-3">Employee Benefits</a></li>
        <li><a href="#" class="btn ITIC" data-popup-open="popup-4">Income Tax</a></li>
        <li><a href="#" class="btn AppraisalIc" data-popup-open="popup-5">Appraisal</a></li>
        <li><a href="#" class="btn OtherIC" data-popup-open="popup-6">Other Policies</a></li>      

                    </ul>
              
</nav>

                <div class="AgencyHomeBox custom-d-flex custom-mt-05 hide ">
                    <div class="hide ">
                        <a id="CRM" runat="server" href="#" style="pointer-events: none; cursor: pointer;">
                            <div class=" shadow_box Blue">

                                <p class="title">CRM</p>

                                <img src="Theme/assets/img/homeimg/CRM.ico" alt="" width="40px">
                            </div>
                        </a>
                    </div>

                    <div class="custom-col custom-mr-05 hide">
                        <a id="OE_CS" runat="server" href="#">
                            <div class="shadow_box SkyBlue">
                                <p class="title">Customer Support</p>
                                <i class="fa fa-users" style="font-size: 32px"></i>
                            </div>
                        </a>
                    </div>

                    <div class="custom-col custom-mr-05">
                    </div>
                    <div class="custom-col custom-mr-05 hide">
                        <a href="#" id="OperatingAccounts" runat="server">
                            <div class="shadow_box Blue">
                                <p class="title">Operating Accounts</p>

                                <img src="Theme/assets/img/homeimg/OperatingAcicon.ico" alt="" width="40px">
                            </div>
                        </a>

                    </div>
                    <div class="custom-col custom-mr-05">

                        <div style="width: 108px; float: right; margin: 5px 23px 0px 0px;">
                            <asp:DropDownList ID="ddl_FAYear" runat="server" Width="109px" dataplaceholder="Financial Year" TabIndex="2" CssClass="chzn-select">
                                <asp:ListItem Value="0">Financial Year</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>

                    <div id="demo" runat="server" style="float: left; margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px;" visible="false">
                        <a id="OE_CSs" runat="server" href="#" class="SmallLiteBlueOuter1">

                            <div class="SmallLiteBlueText1">
                                Ocean Exports
                            </div>

                            <div class="SmallLtBlueRightSideDown1">
                                <img src="Theme/assets/img/homeimg/shipicon_Blue.ico" alt="" width="55px">
                            </div>

                        </a><a id="OI_CSs" runat="server" href="#" class="SmallLiteBlueOuter2">

                            <div class="SmallLiteBlueText2">
                                Ocean Imports
                            </div>
                            <div class="SmallLtBlueRightSideDown2">
                                <i class="fa fa-ship"></i>
                            </div>

                        </a>

                        <a id="AE_CS" runat="server" href="#" class="SmallLiteBlueOuter3">

                            <div class="SmallLiteBlueText3">
                                Air Exports
                            </div>
                            <div class="SmallLtBlueRightSideDown3">
                                <img src="Theme/assets/img/homeimg/AirExportsIcon.ico" alt="" width="55px">
                            </div>

                        </a><a id="AI_cs" runat="server" href="#" class="SmallLiteBlueOuter4">

                            <div class="SmallLiteBlueText4">
                                Air Imports
                            </div>
                            <div class="SmallLtBlueRightSideDown4">
                                <img src="Theme/assets/img/homeimg/AirExportsIcon.ico" alt="" width="55px">
                            </div>

                        </a>

                        <div class="BTBox1" style="display: none;">
                            <div class="CSIconBT">
                                <img src="Theme/assets/img/homeimg/customersupport_ic1.png" />
                            </div>
                            <p>Bonded Trucking</p>
                        </div>

                        <div class="SmallLiteBlueOuter5">
                            <div class="SmallLiteBlueText2">
                                CHA
                            </div>
                            <div class="SmallLtBlueRightSideDown2">
                                <img src="Theme/assets/img/homeimg/CHA_Blue.ico" alt="" width="50px">
                            </div>
                        </div>

                    </div>
                    <div class="Clear"></div>
                    <div id="demo1" runat="server" style="float: left; margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px;" visible="false">
                        <a id="OI_CS" runat="server" href="#" class="SmallYellowOuterDiv1">
                            <div class="SmallYellowText1">
                                Ocean Exports
                            </div>
                            <div class="SmallYellowRightSideDown1">
                                <img src="Theme/assets/img/homeimg/shipicon_Yellow.ico" alt="" width="55px">
                            </div>

                        </a>
                     <%--   <a id="OI_ops" runat="server" href="#" class="SmallYellowOuterDiv2">

                            <div class="SmallYellowText2">
                                Ocean Imports
                            </div>
                            <div class="SmallYellowRightSideDown2">
                                <i class="fa fa-ship" style="font-size: 34px"></i>
                            </div>

                        </a>

                        <a id="AE_ops" runat="server" class="SmallYellowOuterDiv3">

                            <div class="SmallYellowText3">
                                Air Exports
                            </div>
                            <div class="SmallYellowRightSideDown3">
                                <img src="Theme/assets/img/homeimg/AirExportsYellowIcon.ico" alt="" width="55px">
                            </div>

                        </a>

                        <a id="AI_ops" runat="server" href="#" class="SmallYellowOuterDiv4">

                            <div class="SmallYellowText4">
                                Air Imports
                            </div>
                            <div class="SmallYellowRightSideDown4">
                                <img src="Theme/assets/img/homeimg/AirExportsYellowIcon.ico" alt="" width="55px">
                            </div>

                        </a>--%>
                        <a id="BondedTrucking" runat="server" href="#" style="display: none;">
                            <div class="BTBox2">
                                <div class="CSIconBT">
                                    <img src="Theme/assets/img/homeimg/opsanddocs_ic1.png" />
                                </div>
                                <p>Bonded Trucking</p>
                            </div>
                        </a>
                        <a id="CHA" runat="server" href="#" class="SmallYellowOuterDiv5">
                            <div class="SmallYellowText2">
                                CHA
                            </div>
                            <div class="SmallYellowRightSideDown2">
                                <img src="Theme/assets/img/homeimg/CHA_Yellow.ico" alt="" width="50px">
                            </div>

                        </a>
                    </div>
                    <div class="Clear"></div>

                </div>

                <div class="left_menu">
                    <div class="left_menu_1">
                        <div class="left_menu_icon"><i class="fa-solid fa-universal-access" aria-hidden="true"></i></div>
                        <div class="left_menu_icon"><i class="fa-duotone fa-sailboat"></i></div>
                        <div class="left_menu_icon"><i class="fa-thin fa-ship"></i></div>
                        <div class="left_menu_icon"><i class="fa-solid fa-plane-departure"></i></div>
                        <div class="left_menu_icon"><i class="fa-solid fa-plane-arrival"></i></div>

                        <div class="left_menu_icon"><i class="fa-solid fa-chart-column" aria-hidden="true"></i></div>
                        <div class="left_menu_icon"><i class="fa-solid fa-file-invoice-dollar" aria-hidden="true"></i></div>

                    </div>

                    <div class="left_menu_2">

                        <div class="left_menu_content">

                            <a id="Sales" runat="server" href="#">
                                <i class="fa-solid fa-universal-access"></i><span>Sales</span>
                            </a>

                        </div>

                        <div class="left_menu_content">
                            <a id="OE_ops" runat="server" href="#">
                                <i class="fa-duotone fa-sailboat"></i><span>Ocean Exports</span>
                            </a>
                        </div>

                         <div class="left_menu_content">
                            <a id="OI_ops" runat="server" href="#">
                                <i class="fa-thin fa-ship"></i><span>Ocean Imports</span>
                            </a>
                        </div>
                         <div class="left_menu_content">
                            <a id="AE_ops" runat="server" href="#">
                                <i class="fa-solid fa-plane-departure"></i><span>Air Exports</span>
                            </a>
                        </div>
                         <div class="left_menu_content">
                            <a id="AI_ops" runat="server" href="#">
                                <i class="fa-solid fa-plane-arrival"></i><span>Air Imports</span>
                            </a>
                        </div>
                       
                        <div class="left_menu_content">
                            <a id="MIS" runat="server" href="#">
                                <i class="fa-solid fa-chart-column"></i><span>MIS & Analytics</span>
                            </a>

                        </div>

                        <div class="left_menu_content">
                            <a href="#" id="FAccounts" runat="server">
                                <i class="fa-solid fa-file-invoice-dollar"></i><span>Financial Accounts</span>
                            </a>

                        </div>

                    </div>
                </div>
                <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
                <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/iScroll/5.2.0/iscroll.js"></script>
                <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/js/bootstrap.min.js"></script>

                <script type="text/javascript" src="Theme/MenuToggle/drawer.min.js"></script>
                <script type="text/javascript">
                    $(document).ready(function () {
                        $('.drawer').drawer();
                    });
                </script>
                <div class="NewsMarquee hide">

                    <marquee><li id="news" runat="server" style="list-style:none;"></li></marquee>
                    <div class="simple-marquee-container">

                        <div class="marquee">

                            <ul class="marquee-content-items">
                                <%--<li id="" runat="server" style="list-style:none;"></li>--%>
                                <%--  <li>
						At vero eos et accusamus et iusto odio dignissimos,  
					</li>
            <li>At vero eos et accusamus et iusto odio dignissimos,</li>
            <li>At vero eos et accusamus et iusto odio dignissimos</li>--%>
                            </ul>
                        </div>
                    </div>
                </div>

                <script type="text/javascript" src="Theme/marquee/js/marquee.js"></script>
                <script>
                    $(function () {

                        $('.simple-marquee-container').SimpleMarquee();

                    });

                </script>

                <div class="mid_div custom-col">
                    <div class="Unclosed" id="Exrate" runat="server" visible="false">
                        <div>
                            <h3>
                                <%-- <img src="../Theme/assets/img/exrate_ic.png" />--%>
                                <span>Ex Rate</span></h3>
                        </div>
                        <%-- 22062021 --%>
                        <%--<div class="btn btn-excel1 MT10" >
                          <asp:Button ID="btn_exp1" runat="server" ToolTip="Export Excel" OnClick="btn_exp1_Click"/>
                          </div>--%>
                        <div class="">
                            <asp:Panel ID="Panelexrate" runat="server" CssClass="panel_15" Visible="false">
                                <asp:GridView ID="Gridexrate" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true" OnPreRender="Gridexrate_PreRender">
                                    <Columns>
                                        <asp:BoundField DataField="excurr" HeaderText="Curr">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                            <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="Justify" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="localexrate" HeaderText="Local">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                            <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="osexrate" HeaderText="OS">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                            <ItemStyle Font-Bold="false" Wrap="true" HorizontalAlign="right" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>

                        </div>
                    </div>

                    <div runat="server" id="div6" class="PendingRightnewChart" visible="false">

                        <div class="piechart">Unclosed Jobs </div>
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        <div id="chartdiv" runat="server">
                        </div>
                    </div>
                    <div id="div_bar" runat="server" class="PendingRightnewLRightNew1" visible="false">

                        <div class="lineChart">Job Status</div>
                        <asp:Literal ID="lts" runat="server"></asp:Literal>
                        <div id="chart_divbar"></div>

                    </div>
                </div>
                <div class="NewsBg" style="display: none;">
                    <asp:Panel ID="panel" runat="server" CssClass="div_Grid1">
                        <asp:GridView ID="grd" runat="server" CssClass="GridTD" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" DataKeyNames="news" Width="100%" OnRowDataBound="grd_RowDataBound" OnSelectedIndexChanged="grd_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField HeaderText="News #" DataField="newsid">
                                    <HeaderStyle Wrap="false" Width="40px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left" Width="40px"></ItemStyle>
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Title">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 350px">
                                            <asp:Label ID="title" runat="server" Text='<%# Bind("title") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="false" Width="350px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="empname" DataField="empname" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"></asp:BoundField>
                                <asp:BoundField HeaderText="news" DataField="news" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"></asp:BoundField>
                            </Columns>

                            <AlternatingRowStyle CssClass="GrdRowStyle" />
                            <HeaderStyle CssClass="GridviewScrollHeader" />
                            <RowStyle CssClass="GridviewScrollItem" />
                            <PagerStyle CssClass="GridviewScrollPager" />
                        </asp:GridView>
                        <div class="div_Break"></div>
                        <%--</div>--%>
                    </asp:Panel>

                </div>

            </div>
            <div style="display:none">
            <div class="popup" data-popup="popup-1">
                <div class="popup-inner">

                    <div class="Clear"></div>
                    <div class="tab-content">
                        <asp:TabContainer ID="Tab" runat="server" Width="100%" ActiveTabIndex="8">

                            <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Our Profile" TabIndex="0">
                                <ContentTemplate>
                                    <div class="div_break"></div>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Profile" runat="server" Text="Corporate Profile"></asp:Label>
                                    </div>
                                    <div class="div_break"></div>
                                    <div class="div_txt">
                                        <asp:TextBox ID="txt_Profile" runat="server" ReadOnly="true" Style="resize: none;" Rows="5" TextMode="MultiLine" CssClass="Tab_Text_Multiline2"></asp:TextBox>
                                    </div>
                                </ContentTemplate>
                            </asp:TabPanel>

                            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Our Mission">
                                <ContentTemplate>
                                    <div class="div_break"></div>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Mission" runat="server" Text="Our Mission"></asp:Label>
                                    </div>
                                    <div class="div_break"></div>
                                    <div class="div_txt_Mission">
                                        <asp:TextBox ID="txt_Mission" runat="server" Style="resize: none;" Rows="5" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <div class="div_break"></div>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Achieve" runat="server" Text="How do we plan to achieve our mission ?"></asp:Label>
                                    </div>
                                    <div class="div_break"></div>
                                    <div class="div_txt_Mission">
                                        <asp:TextBox ID="txt_Achieve" runat="server" ReadOnly="true" Style="resize: none;" Rows="5" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </ContentTemplate>
                            </asp:TabPanel>

                            <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Our Philosophy & Beliefs">
                                <ContentTemplate>
                                    <div class="div_break"></div>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Philosophy" runat="server" Text="Our Philosophy"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt_Mission">
                                        <asp:TextBox ID="txt_Philosophy" runat="server" ReadOnly="true" Style="resize: none;" Rows="5" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Beleifs" runat="server" Text="Our Beleifs"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt_Mission">
                                        <asp:TextBox ID="txt_Beleifs" runat="server" ReadOnly="true" Style="resize: none;" Rows="5" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </ContentTemplate>
                            </asp:TabPanel>

                            <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="Working Hours">
                                <ContentTemplate>
                                    <div class="div_break"></div>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Hours" runat="server" Text="WORKING HOURS"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt">
                                        <asp:TextBox ID="txt_Hours" runat="server" ReadOnly="true" Style="resize: none;" Rows="5" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </ContentTemplate>
                            </asp:TabPanel>

                            <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="Dress Code">
                                <ContentTemplate>
                                    <div class="div_break"></div>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_DressCode" runat="server" Text="DRESS CODE"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt">
                                        <asp:TextBox ID="txt_DressCode" runat="server" ReadOnly="true" Style="resize: none;" Rows="5" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </ContentTemplate>
                            </asp:TabPanel>

                            <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="Salary Structure">
                                <ContentTemplate>
                                    <div class="div_break"></div>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Salary" runat="server" Text="SALARY STRUCTURE"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt">
                                        <asp:TextBox ID="txt_Salary" runat="server" ReadOnly="true" Style="resize: none;" Rows="5" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </ContentTemplate>
                            </asp:TabPanel>

                            <asp:TabPanel ID="TabPanel7" runat="server" HeaderText="Leave">
                                <ContentTemplate>
                                    <div class="div_break"></div>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Leave" runat="server" Text="LEAVE"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt">
                                        <asp:TextBox ID="txt_Leave" runat="server" ReadOnly="true" Style="resize: none;" Rows="5" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </ContentTemplate>
                            </asp:TabPanel>

                            <asp:TabPanel ID="TabPanel8" runat="server" HeaderText="Probationers">
                                <ContentTemplate>
                                    <div class="div_break"></div>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Probation" runat="server" Text="PROBATIONERS"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt">
                                        <asp:TextBox ID="txt_Probation" runat="server" ReadOnly="true" Style="resize: none;" Rows="5" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </ContentTemplate>
                            </asp:TabPanel>

                        </asp:TabContainer>
                    </div>

                    <a class="popup-close" data-popup-close="popup-1" href="#">x</a>
                </div>
            </div>

            <div class="popup" data-popup="popup-2">
                <div class="popup-inner">
                    <div class="Clear"></div>
                    <div class="tab-content">
                        <div class="Tab_Text_Multiline1">

                            <h3>Objectives</h3>
                            <p>The purpose of this policy is to ensure the proper use of  Demo ’s IT & eMail system and make users aware of what Demo ’s acceptable and unacceptable use of its IT & eMail system. The Demo  reserves the right to amend this policy at its discretion. In case of amendments, users will be informed appropriately.</p>
                            <div class="bordertopHome"></div>
                            <h3>IT</h3>
                            <p>File Store / Desktop / Screensaver All documents to be saved in d:\Mydocs folder i.e. documents should not be stored where the OS is residing. User are allowed our ISO quality policy  as Desktop theme to display.  Users are not allowed to set screen savers in their system.</p>
                            <p>Users have no rights to delete the mails from their system while relieving the organization.</p>
                            <div class="bordertopHome"></div>
                            <h3>eMail </h3>
                            <p>Please refer eMail policy.</p>
                            <div class="bordertopHome"></div>
                            <h3>Internet & Games </h3>
                            <p>Users are allowed to browse Shipping / Banking related sites.   Employees are allowed to browse few public portals / sites related to our industry prior approval by their supervisor (BM / RM / COO).  Playing online games & Surfing pornography, sports, entertainment and job portals are strictly prohibited.</p>
                            <div class="bordertopHome"></div>
                            <h3>Accessing Others System</h3>
                            <p>Users are not allowed to access others system without their permission, however RM / BM / COO can access.</p>
                            <div class="bordertopHome"></div>
                            <h3>Hardware & Peripherals</h3>
                            <p>Systems, Printers, Other peripherals and UPS to be relocated by AMC service provider only.</p>
                            <p>Systems should be shut down properly and the power to be switched off one leaves the office (even one leaves the office on duty for few hours) Dept. Head / Accounts Head would be responsible for misuse of Laser printer by their team members.</p>
                            <div class="bordertopHome"></div>
                            <h3>Hardware & Software purchase</h3>
                            <p>All Hardware & Software to be purchased as per Capex. System Department will suggest the configuration and price.</p>
                            <p>If you receive any calls from Software Vendors like Microsoft, Please redirect to Systems Dept / COO</p>
                            <div class="bordertopHome"></div>
                            <h3>Backup [Individual Systems]</h3>
                            <p>Backup (Mails & My Documents) to be done on monthly basis without fail.</p>
                            <div class="bordertopHome"></div>
                            <h3>eMail</h3>
                            <h3>LEGAL RISK</h3>
                            <p>Email is a business communication tool and users are obliged to use this tool in a responsible, effective and lawful manner. Although by its nature email seems to be less formal than other written communication, the same laws apply. Therefore, it is important that users are aware of the legal risks of email:</p>
                            <h3>GUIDELINES</h3>
                            <p>The following rules are to be strictly adhered to. It is prohibited to:</p>
                            <p>
                                <ul style="font-size: 10pt">
                                    <li>Send or forward emails containing libelous, defamatory, offensive, racist or obscene remarks. If you receive an email of this nature, you must promptly notify your supervisor. </li>
                                    <li>Forward a message without acquiring permission from the sender first. </li>
                                    <li>Send unsolicited email messages. </li>
                                    <li>Forge or attempt to forge email messages. </li>
                                    <li>Disguise or attempt to disguise your identity when sending mail. </li>
                                    <li>Send email messages using another person’s email account. </li>
                                    <li>Copy a message or attachment belonging to another user without permission of the originator. </li>
                                    <li>Send an attachment that contains a virus </li>
                                </ul>
                            </p>
                            <h3>BEST PRACTICES</h3>
                            <p>
                                Demo  considers email as an important means of communication and recognizes the importance of proper email content and speedy replies in conveying a professional image and delivering good customer service. Users should take the same care in drafting an email as they would for any other communication.  Therefore Demo  wishes users to adhere to the following guidelines:
                            </p>
                            <div class="bordertopHome"></div>
                            <h3>*     Writing emails: </h3>
                            <p>
                                <ul style="font-size: 10pt">
                                    <li>Write well-structured emails and use short, descriptive subjects.</li>
                                    <li>Demo ’s email style is informal. This means that sentences can be short and to the point. You can start your email with ‘Hi’, or ‘Dear’, and the name of the person. Messages can be ended with ‘Best Regards’. The use of 	       Internet abbreviations and characters such as smileys however, is 	       not encouraged.</li>
                                    <li>Signatures must include your name, job title and company name. A disclaimer will be added underneath your signature (see Disclaimer) </li>
                                    <li>Users must spell check all mails prior to transmission. </li>
                                    <li>Do not send unnecessary attachments. Compress attachments larger than 2048K before sending them. </li>
                                    <li>Do not write emails in capitals.  </li>
                                    <li>Do not use cc: or bcc: fields unless the cc: or bcc: recipient is aware that you will be copying a mail to him/her and knows what action, if any, to take. </li>
                                    <li>If you forward mails, state clearly what action you expect the recipient to take. </li>
                                    <li>Only send emails of which the content could be displayed on a public notice board. If they cannot be displayed publicly in their current state,consider rephrasing the email, using other means of communication, or protecting information by using a password (see confidential). </li>
                                    <li>Only mark emails as important if they really are important. </li>
                                </ul>

                            </p>
                            <h3>*      Replying to emails: </h3>
                            <p>
                                <ul style="font-size: 10pt">
                                    <li>Emails should be answered within at least 8 working hours, but users must endeavor to answer priority emails within 4 hours.</li>
                                    <li>Priority emails are emails from existing customers and business partners.</li>

                                </ul>

                            </p>
                            <h3>*      Newsgroups: </h3>
                            <p>
                                <ul style="font-size: 10pt">
                                    <li>Users need to request permission from their supervisor before subscribing to a newsletter or news group.</li>

                                </ul>

                            </p>
                            <div class="bordertopHome"></div>
                            <h3>PERSONAL USE</h3>
                            <p>It is strictly forbidden to use Demo ’s email system for anything other than legitimate business purposes. Therefore, the sending of personal emails, chain letters, junk mail, jokes and executables is prohibited. All messages distributed via the company’s email system are Demo ’s property.</p>
                            <div class="bordertopHome"></div>
                            <h3>CONFIDENTIAL INFORMATION</h3>
                            <p>
                                Never send any confidential information via email. If you are in doubt as to whether to send certain information via email, check this with your supervisor first. 
                            </p>
                            <div class="bordertopHome"></div>
                            <h3>PASSWORDS</h3>
                            <p>
                                All passwords must be made known to the company. The use of passwords to gain access to the computer system or to secure specific files does not provide users with an expectation of privacy in the respective system or document.
                            </p>
                            <div class="bordertopHome"></div>
                            <h3>ENCRYPTION</h3>
                            <p>Users may not encrypt any emails without obtaining written permission from their supervisor. If approved, the encryption key(s) must be made known to the company.</p>
                            <div class="bordertopHome"></div>
                            <h3>EMAIL RETENTION</h3>
                            <p>Inbox should have last 60 days mails only. User has to move the incoming mails to appropriate folder for archiving once the job is over. </p>
                            <div class="bordertopHome"></div>
                            <h3>EMAIL ACCOUNTS</h3>
                            <p>All email accounts maintained on our email systems are property of Demo . Passwords should not be given to other people.</p>
                            <div class="bordertopHome"></div>
                            <h3>SYSTEM MONITORING</h3>
                            <p>
                                Documents could be created, stored, sent & received on the company’s computers by the users.  If there is evidence that users have not adhering to the guidelines set out in this policy,  Demo  reserves the right to take disciplinary action, 
including termination and/or legal action.
                            </p>
                            <div class="bordertopHome"></div>
                            <h3>DISCLAIMER</h3>
                            <p>
                                The following disclaimer will be added to each outgoing email:
‘This email and any files transmitted with it are confidential and intended solely for the use of the individual or entity to 
whom they are addressed. If you have received this email in error please notify the system manager. Please note that 
any views or opinions presented in this email are solely those of the author and do not necessarily represent those of
 the company. Finally, the recipient should check this email and any attachments for the presence of viruses. The 
company accepts no liability for any damage caused by any virus transmitted by this email.’
                            </p>
                            <div class="bordertopHome"></div>
                            <h3>EMAIL CLIENT</h3>
                            <p>
                                Users should use Mozilla Thunderbird as mail client to send and receive mails in their system.  System Department will 
inform Regional Heads / Branch Heads / System Personnel if there any change in the version or software.  Users should not use Outlook & Outlook express for emails
                            </p>
                            <div class="bordertopHome"></div>
                            <%-- <div style="float: left; margin-left: 1%;">Prepared by : IT Dept   </div>
                                        <div style="float: right; margin-right: 1%;">Approved by : Chief Operating Officer</div>--%>
                        </div>
                    </div>
                    <a class="popup-close" data-popup-close="popup-2" href="#">x</a>
                </div>
            </div>
            <div class="popup" data-popup="popup-3">
                <div class="popup-inner">
                    <div class="Clear"></div>
                    <div class="tab-content">
                        <asp:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="0">
                            <asp:TabPanel ID="TabPanel9" runat="server" HeaderText="STATUTORY" TabIndex="0">
                                <ContentTemplate>

                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_PF" runat="server" Text="PF"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt_MissionESI">
                                        <asp:TextBox ID="txt_PF" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="Label2" runat="server" Text="ESI"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt_MissionESI">
                                        <asp:TextBox ID="txt_Employee" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>

                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Gratutity" runat="server" Text="GRATUITY"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt_MissionESI">
                                        <asp:TextBox ID="txt_Gratutity" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Bonus" runat="server" Text="Bonus"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt_MissionESI">
                                        <asp:TextBox ID="txt_Bonus" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>

                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="TabPanel10" runat="server" HeaderText="REIMBURSEMENTS">
                                <ContentTemplate>

                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Lunch" runat="server" Text="SODEXO"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt_MissionRE">
                                        <asp:TextBox ID="txt_Lunch" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <div class="div_break">
                                    </div>

                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Driver" runat="server" Text="DRIVER REIMBURSEMENTS"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt_MissionRE">
                                        <asp:TextBox ID="txt_Driver" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Entertain" runat="server" Text="ENTERTAINMENT REIMBURSEMENTS"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt_MissionRE">
                                        <asp:TextBox ID="txt_Entertain" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="Label10" runat="server" Text="VEHICLE MAINTENANCE REIMBURSEMENTS"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt_MissionRE">
                                        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <div class="div_break">
                                    </div>

                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Travel" runat="server" Text="TRAVEL"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt_MissionRE">
                                        <asp:TextBox ID="txt_Travel" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>

                                    <div class="div_break">
                                    </div>

                                </ContentTemplate>
                            </asp:TabPanel>

                            <asp:TabPanel ID="TabPanel14" runat="server" HeaderText="Insurance" TabIndex="0">
                                <ContentTemplate>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Group" runat="server" Text="GROUP PERSONAL ACCIDENT INSURANCE COVER"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt_Mission_MEDICLAIMcont">
                                        <asp:TextBox ID="txt_Group" runat="server" ReadOnly="true" CssClass="Tab_Text_MultilineIns" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Employee" runat="server" Text="GROUP TERM LIFE INSURANCE"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt_Mission_MEDICLAIMcont">
                                        <asp:TextBox ID="txt_grplifeins" runat="server" ReadOnly="true" CssClass="Tab_Text_MultilineIns" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Medical" runat="server" Text="GROUP MEDICLAIM POLICY"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt_Mission_MEDICLAIMcont">
                                        <asp:TextBox ID="txt_Medical" runat="server" ReadOnly="true" CssClass="Tab_Text_MultilineIns" TextMode="MultiLine"></asp:TextBox>
                                    </div>

                                    <div class="div_break">
                                    </div>

                                    <div class="div_txt_Mission_MEDICLAIM">
                                        <asp:TextBox ID="TextBox2" runat="server" ReadOnly="true" CssClass="Tab_Text_MultilineIns" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="TabPanel15" runat="server" HeaderText="Earn Leave Encashment">
                                <ContentTemplate>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="Label1" runat="server" Text="Earn Leave Encashment"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt_Mission">
                                        <asp:TextBox ID="txt_Leaveemployee" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>

                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="TabPanel16" runat="server" HeaderText="Employee Wedding">
                                <ContentTemplate>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Wedding" runat="server" Text="EMPLOYEE WEDDING"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt">
                                        <asp:TextBox ID="txt_Wedding" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>

                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="TabPanel17" runat="server" HeaderText="Employee Referral">
                                <ContentTemplate>
                                    <div class="div_label" style="color: #df2b2b;">
                                        <asp:Label ID="lbl_Referral" runat="server" Text="EMPLOYEE REFERRAL"></asp:Label>
                                    </div>
                                    <div class="div_break">
                                    </div>
                                    <div class="div_txt">
                                        <asp:TextBox ID="txt_Referral" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                    </div>

                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </div>

                    <a class="popup-close" data-popup-close="popup-3" href="#">x</a>
                </div>
            </div>
            <div class="popup" data-popup="popup-4">
                <div class="popup-inner">

                    <div class="Clear"></div>
                    <div class="tab-content">
                        <div id="tab1" class="tab active">
                            <asp:TabContainer ID="TabContainer2" runat="server" Width="100%" ActiveTabIndex="1">
                                <asp:TabPanel ID="TabPanel23" runat="server" HeaderText="Income Tax">
                                    <ContentTemplate>
                                        <div class="div_label" style="color: #df2b2b;">
                                            <asp:Label ID="Label9" runat="server" Text="Income Tax"></asp:Label>
                                        </div>
                                        <div class="div_break">
                                        </div>
                                        <div class="div_txt">
                                            <asp:TextBox ID="Txt_IncomeTax" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                        </div>

                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </div>

                    </div>

                    <a class="popup-close" data-popup-close="popup-4" href="#">x</a>
                </div>
            </div>
            <div class="popup" data-popup="popup-5">
                <div class="popup-inner">

                    <div class="Clear"></div>
                    <div class="tab-content">
                        <div id="tab1" class="tab active">
                            <asp:TabContainer ID="TabContainer3" runat="server" Width="100%" ActiveTabIndex="1">
                                <asp:TabPanel ID="TabPanel18" runat="server" HeaderText="Probation Apprasial">
                                    <ContentTemplate>
                                        <div class="div_label" style="color: #df2b2b;">
                                            <asp:Label ID="Label4" runat="server" Text="Probation Apprasial"></asp:Label>
                                        </div>
                                        <div class="div_break">
                                        </div>
                                        <div class="div_txt">
                                            <asp:TextBox ID="Txt_ProAppr" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                        </div>

                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel19" runat="server" HeaderText="Annual Performance Appraisal">
                                    <ContentTemplate>
                                        <div class="div_label" style="color: #df2b2b;">
                                            <asp:Label ID="Label5" runat="server" Text="Annual Performance Appraisal"></asp:Label>
                                        </div>
                                        <div class="div_break">
                                        </div>
                                        <div class="div_txt">
                                            <asp:TextBox ID="Txt_Annu" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                        </div>

                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>

                        </div>

                    </div>

                    <a class="popup-close" data-popup-close="popup-5" href="#">x</a>
                </div>
            </div>
            <div class="popup" data-popup="popup-6">
                <div class="popup-inner">

                    <div class="Clear"></div>
                    <div class="tab-content">
                        <div id="tab1" class="tab active">
                            <asp:TabContainer ID="TabContainer4" runat="server" Width="100%" ActiveTabIndex="1">
                                <asp:TabPanel ID="TabPanel20" runat="server" HeaderText="Suggestion  Policy">
                                    <ContentTemplate>
                                        <div class="div_label" style="color: #df2b2b;">
                                            <asp:Label ID="Label6" runat="server" Text="Suggestion Policy"></asp:Label>
                                        </div>
                                        <div class="div_break">
                                        </div>
                                        <div class="div_txt">
                                            <asp:TextBox ID="Txt_Sug" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                        </div>

                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel21" runat="server" HeaderText="Incentive Policy">
                                    <ContentTemplate>
                                        <div class="div_label" style="color: #df2b2b;">
                                            <asp:Label ID="Label7" runat="server" Text="Incentive Policy"></asp:Label>
                                        </div>
                                        <div class="div_break">
                                        </div>
                                        <div class="div_txt">
                                            <asp:TextBox ID="Txt_IncPoli" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                        </div>

                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel22" runat="server" HeaderText="Grievance Policy">
                                    <ContentTemplate>
                                        <div class="div_label" style="color: #df2b2b;">
                                            <asp:Label ID="Label8" runat="server" Text="Grievance Policy"></asp:Label>
                                        </div>
                                        <div class="div_break">
                                        </div>
                                        <div class="div_txt">
                                            <asp:TextBox ID="Txt_GrivPoli" runat="server" ReadOnly="true" CssClass="Tab_Text_Multiline2" TextMode="MultiLine"></asp:TextBox>
                                        </div>

                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </div>

                    </div>

                    <a class="popup-close" data-popup-close="popup-6" href="#">x</a>
                </div>
            </div>
</div>
            <!-- New Product Style End -->

            <!-- /Sidebar -->

            <div class="HomeGroup">

                <div class="HR" style="display: none;">
                    <a href="#" id="Hr" runat="server">
                        <div class="HRIC"></div>
                        Human Resources</a>
                </div>

                <div class="Maitenance" style="display: none;">
                    <a href="#" id="Maintenance" runat="server">
                        <div class="MainIC"></div>
                        Maintenance</a>
                </div>

                <%--<a id="Maintenance" runat="server" href="#">
                            <div class="MenuME">
                                <img src="Theme/assets/img/maintenance.png" width="52" height="52">
                                <h3>Maintenance</h3>
                            </div>
                        </a>--%>
                <%--<a id="Hr" runat="server" href="#" class="disabled">
                            <div class="MenuHR">
                                <img src="Theme/assets/img/hr_ic.png" width="73" height="53">
                                <h3>Human Resources</h3>
                            </div>
                        </a>--%>
            </div>

            <div class="FormGroupContent4">
                <asp:Panel ID="pln_KPI" runat="server" CssClass="modalPopupkpi" Style="display: none;">
                    <div class="DivSecPanelkpi">
                        <asp:Image ID="Close_KPI" runat="server" Width="100%" Height="100%" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" />
                    </div>
                    <div class="div_Break">
                    </div>
                    <div class="Gridpnkpi">
                        <div class="FormGroupContent">
                            <div style="width: 96%; margin: 0px 0px 0px 10px; float: left;">
                                <asp:TextBox ID="txttitle" Enabled="false" runat="server" CssClass="form-control" Style="width: 100%; color: #0077c9;" AutoPostBack="True" placeholder="Title" ToolTip="Title"></asp:TextBox>

                            </div>
                        </div>
                        <div class="div_txt">
                            <asp:TextBox ID="txtNews" runat="server" ReadOnly="true" placeholder="News" ToolTip="News" CssClass="Tab_Text_MultilineN" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="FormGroupContent">
                            <div style="position: absolute; z-index: 999999999; top: 95%; margin: -30px 0px 0px 10px;">
                                <asp:TextBox ID="txtpost" runat="server" CssClass="form-control" AutoPostBack="True" Style="width: 100%; color: brown;" placeholder="Posted By" ToolTip="Posted By"></asp:TextBox>
                            </div>
                        </div>
                        <%--<iframe id="iframeKPI" runat="server" src="" frameborder="0" class="frameskpi" style="background-color: #FFFFFF"></iframe>--%>
                    </div>
                </asp:Panel>
            </div>

            <asp:ModalPopupExtender runat="server" ID="popup_KPI"
                PopupControlID="pln_KPI" CancelControlID="Close_KPI" TargetControlID="Label3" DropShadow="false">
            </asp:ModalPopupExtender>
            <asp:Label ID="Label3" runat="server"></asp:Label>

            <div class="box" style="display: none;">
                <a id="Agencyexports" runat="server" data-tooltip="Agency Exports" href="#" class="tooltip-bottom">
                    <asp:Image ID="Image11" runat="server" Width="100%" Height="100%" CssClass="round-box" ImageUrl="~/images/Agencyexports.jpg" />
                </a>
            </div>
            <div class="box" style="display: none;">
                <a id="AgencyImports" runat="server" data-tooltip="Agency Imports" href="#" class="tooltip-bottom">
                    <asp:Image ID="Image12" runat="server" Width="100%" Height="100%" CssClass="round-box" ImageUrl="~/images/agencyImports.jpg" /></a>
            </div>
        </div>
    </form>
</body>
</html>
