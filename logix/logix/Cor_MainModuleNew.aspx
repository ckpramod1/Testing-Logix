<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cor_MainModuleNew.aspx.cs" Inherits="logix.Cor_MainModule" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/MainModuleNew.css" rel="stylesheet" type="text/css" />
    <link href="Styles/CompanyProfile.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/system.css" rel="stylesheet" type="text/css">
    <link href="Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/Newhome.css" rel="stylesheet" type="text/css">
    <link href="Theme/assets/product/css/custom-style.css" rel="stylesheet" />
    <link href="Theme/assets/product/css/systemtproduct.css" rel="stylesheet" />
    <script src="Theme/assets/product/js/jquery.js"></script>
    <script src="Theme/assets/product/js/jquery_002.js"></script>

    <link rel='stylesheet' href='http://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css'>
    <link rel="stylesheet" href="Theme/assets/css/fontawesome/font-awesome.min.css">
    <link rel="stylesheet" href="Theme/assets/tab/js/main.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <script type="text/javascript" src="Theme/assets/tab/js/jquery.js"></script>
    <script type="text/javascript" src="Theme/assets/tab/js/tabs.js"></script>
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
</head>
<style type="text/css">
    .Tab_Text_Multiline1 {
        font-family: sans-serif;
        font-style: normal;
        margin-left: 0px;
        width: 100%;
        height: 440px;
        /*resize:none;*/ overflow: auto;
    }
    a#FAccounts, a#MIS_and_Analysis {
    display: none;
}
    a#Maintenances {
    width: 200px;
    margin-left: 7px;
}
    .Tab_Text_Multiline2 {
        font-family: sans-serif, Geneva, sans-serif !important;
        font-size: 11px;
        font-style: normal;
        margin-left: 0.5px;
        width: 100%;
        height: 370px;
        overflow: auto;
        color: #4c4c4c !important;
        line-height: 22px;
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

    .FormGroupContentmainmodule textarea {
        height: 302px !important;
        cursor: default !important;
        padding-bottom: 10px;
        margin: 5px 0px 0px 0px;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_tab {
        background-image: none !important;
        background-color: #0077c9;
        border-top-left-radius: 3px;
        border-top-right-radius: 3px;
        color: #ffffff;
        /*border-top: 2px solid #0077c9;*/
    }


    .Tab_Text_Multiline1 p {
        padding: 5px 5px 0 15px;
        font-size: 12px;
    }



    .ajax__tab_xp .ajax__tab_header .ajax__tab_inner {
        padding-left: 0px !important;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_tab {
        padding: 0px !important;
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


    #__tab_Tab_TabPanel8 > span {
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    .ajax__tab_tab {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_Tab_TabPanel2 > span {
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }



    #__tab_Tab_TabPanel7 > span {
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }





    #__tab_Tab_TabPanel6 > span {
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
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer1_TabPanel11 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer1_TabPanel12 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer1_TabPanel13 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer2_TabPanel14 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer2_TabPanel15 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer2_TabPanel16 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer2_TabPanel17 > span {
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



    .ajax__tab_xp .ajax__tab_header {
        background-position: center bottom;
        background-repeat: repeat-x;
        font-family: verdana,tahoma,helvetica;
        background-image: none !important;
        font-size: 11px;
        height: 27px !important;
        border-bottom: 1px solid #c8c8c8;
    }

    .ajax__tab_default {
        color: #ffffff !important;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_outer {
        padding: 0px 0px 0px 0px;
        background-image: none;
    }

    #__tab_TabContainer2_TabPanel23 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer3_TabPanel18 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer3_TabPanel19 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer4_TabPanel20 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer4_TabPanel21 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer4_TabPanel22 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
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


    .Tab_Text_Multiline1 p {
        padding: 5px 5px 0 15px;
    }


    .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_inner {
        background-image: none !important; /*border-left:1px solid #b1b1b1;*/
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_inner {
        padding-left: 0px !important;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_outer {
        background-image: none !important;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_outer {
        padding-right: 0px !important;
    }

    .ajax__tab_active {
        padding: 0px 0px 0px 0px !important;
    }

    #TabContainer1_header > span {
        margin: 0 6px 0 0;
    }

    #__tab_Tab_TabPanel1 > span {
        font-size: 11px;
        padding: 10px 10px;
        margin: 0px 0px 0px 0px;
    }


    .ajax__tab_tab {
        color: #4c4c4c;
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_Tab_TabPanel3 > span {
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_Tab_TabPanel4 > span {
        font-size: 11px;
        padding: 2px 5px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_Tab_TabPanel5 > span {
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
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer1_TabPanel11 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer1_TabPanel12 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer1_TabPanel13 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer2_TabPanel14 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer2_TabPanel15 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer2_TabPanel16 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #__tab_TabContainer2_TabPanel17 > span {
        font-size: 11px;
        padding: 2px 2px;
        margin: 0px 0px 0px 0px;
    }

    #TabContainer2_header > span {
        margin: 0 5px 0 0;
    }

    .ajax__tab_xp .ajax__tab_header .ajax__tab_tab {
        background-image: none !important;
        padding: 5px !important;
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

    .ajax__tab_xp .ajax__tab_body {
        -moz-border-bottom-colors: none;
        -moz-border-left-colors: none;
        -moz-border-right-colors: none;
        -moz-border-top-colors: none;
        background-color: #ffffff;
        border: none !important;
        font-family: verdana,tahoma,helvetica;
        font-size: 10pt;
        height: 410px !important;
        padding: 8px;
        overflow: auto;
    }



    .HomeGroup {
        width: 20%;
        float: left;
        margin: 50px 20px 36px 30px;
    }

    .TabMenu {
        float: left;
        width: 54%;
        margin: 55px 0px 36px 20px;
    }

    .tab-content {
        padding: 10px 0px;
        border-radius: 0px;
        box-shadow: 0px 0px 0px rgba(0,0,0,0.15);
        background: #fff;
        border: 0px solid #b1b1b1;
        min-height: 419px;
        margin: -10px 0px 0px 0px;
    }

    .HomeGroupCS {
        width: 258px;
        float: left;
        margin: 56px 20px 36px 20px;
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









    .tab-links li.active a {
        border-top: 1px solid #a6b5bf;
        border-left: 1px solid #a6b5bf;
        border-right: 1px solid #a6b5bf;
        background-color: #0077c9;
        color: #ffffff;
    }

    .div_Grid1 {
        border: 1px solid #b1b1b1;
        height: 352px;
    }

    .LoginLeft {
        width: 223px;
        float: left;
        height: 400px;
        margin: 65px 20px 0px 20px;
    }

    .MenuAE {
        background-color: #433d27;
        width: 118px;
        height: 94px;
        float: left;
        text-align: center;
        padding: 6px 0px 0px 0px;
        margin: 10px 10px 1px 0px;
    }

    .MenuAI {
        background-color: #413b61;
        width: 118px;
        height: 94px;
        float: left;
        text-align: center;
        padding: 6px 0px 0px 0px;
        margin: 10px 10px 1px 0px;
    }

    .MenuAI {
        background-color: #413b61;
        width: 118px;
        height: 94px;
        float: left;
        text-align: center;
        padding: 6px 0px 0px 0px;
        margin: 10px 10px 1px 0px;
    }

    .MenuME {
        background-color: #d02027;
        width: 118px;
        height: 94px;
        float: left;
        text-align: center;
        padding: 6px 0px 0px 0px;
        margin: 10px 10px 1px 0px;
    }

    .HR {
        width: 118px;
        height: 94px;
        float: left;
        text-align: center;
        background-color: #413b61;
        min-height: 94px;
        margin: 10px 10px 1px 0px;
    }

    .HomeGroupCS .MenuAI h3 {
        font-size: 14px;
        font-family: sans-serif, Geneva, sans-serif;
        padding: 19px 0px 0px 0px;
        margin: 0px 0px 0px 0px;
        text-align: center;
        color: #ffffff;
    }

    .tab-content a {
        border-top-left-radius: 3px;
        border-top-right-radius: 3px;
        color: #4c4c4c;
    }



    #__tab_TabContainer1_TabPanel14 > span {
        font-size: 11px;
        margin: 0;
        padding: 2px;
    }


    #__tab_TabContainer1_TabPanel15 > span {
        font-size: 11px;
        margin: 0;
        padding: 2px;
    }

    #__tab_TabContainer1_TabPanel16 > span {
        font-size: 11px;
        margin: 0;
        padding: 2px;
    }

    #__tab_TabContainer1_TabPanel17 > span {
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
        height: 75px;
        overflow-x: hidden;
        overflow-y: auto;
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
        height: 90px;
    }

    .div_txtN1_AC {
        float: left;
        width: 100%;
        margin-left: 0%;
        margin-top: 0%;
        margin-bottom: 0%;
    }

    .div_label {
        width: 100%;
        float: left;
        margin-top: 0%;
        margin-left: 0%;
        margin-bottom: 0.5%;
        padding-bottom: 2px;
        border-bottom: 1px dotted #b1b1b1;
        font-weight: normal;
    }

    .div_label_ins {
        width: 100%;
        float: left;
        margin-top: 0.3%;
        margin-left: 0%;
        margin-bottom: 0.3%;
        padding-bottom: 2px;
        border-bottom: 1px dotted #b1b1b1;
        font-weight: normal;
    }

    .NewsMarquee {
        /*border: 1px solid #fff;*/
        color: #fff;
        top: 25%;
        margin: 0px auto;
        position: relative;
        width: 98%;
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


    .div_txt_Mission_life {
        float: left;
        width: 100%;
        margin-left: 0%;
        margin-top: 0%;
        margin-bottom: 0%;
    }

    .div_txt_Mission_lifeCon {
        float: left;
        width: 100%;
        margin-left: 0%;
        margin-top: 0%;
        margin-bottom: 0%;
        height: 60px;
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
        margin: 5px 5px 0px 5px;
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
        margin: 5px 10px 0px 0px;
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
        margin: 5px 5px 0px 0px;
    }


        .GreenOuterDiv:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }

    .GreenText {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 35px 15px;
        float: left;
        color: #1cc88a !important;
    }

    .GreenRightSideDown {
        color: #1cc88a !important;
        margin: 0px 10px 0px 0px;
        font-family: 'OpenSansSemibold';
        float: right;
        font-size: 22px;
        width: 75%;
        text-align: right;
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
        margin: 5px 5px 0px 0px;
    }


        .LiteBlueOuter:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }

    .LiteBlueText {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 30px 15px;
        float: left;
        color: #36b9cc !important;
    }

    .LtBlueRightSideDown {
        color: #36b9cc !important;
        margin: 0px 10px 0px 0px;
        font-family: 'OpenSansSemibold';
        float: right;
        font-size: 22px;
        width: 75%;
        text-align: right;
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
        margin: 5px 5px 0px 0px;
    }

        .YellowOuterDiv:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }

    .YellowText {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 35px 15px;
        float: left;
        color: #f6c23e !important;
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
        margin: 5px 5px 0px 0px;
    }

        .GreenOuterDiv2:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }

    .GreenText2 {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 33px 15px;
        float: left;
        color: #1cc88a !important;
    }


    .GreenRightSideDown2 {
        color: #1cc88a !important;
        margin: 0px 10px 0px 0px;
        float: right;
        font-family: 'OpenSansSemibold';
        font-size: 22px;
        width: 75%;
        text-align: right;
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
        margin: 5px 5px 0px 0px;
    }


        .BlueOuterDiv2:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }


    .Blue2Text {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 20px 15px;
        float: left;
        color: #4e73df !important;
    }


    .Blue2RightSideDown {
        color: #4e73df !important;
        font-family: 'OpenSansSemibold';
        margin: 0px 10px 0px 0px;
        float: right;
        font-size: 22px;
        width: 75%;
        text-align: right;
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
        margin: 5px 5px 0px 0px;
    }

        .RedOuterDiv:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }



    .RedText {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 32px 15px;
        float: left;
        color: #e74a3b !important;
    }



    .RedRightSideDown {
        color: #e74a3b !important;
        margin: 0px 15px 0px 0px;
        font-family: 'OpenSansSemibold';
        float: right;
        font-size: 22px;
        width: 75%;
        text-align: right;
    }

    .LiteBlueOuter2 {
        color: #fff;
        border-radius: 5px;
        border: 1px solid #e3e6f0;
        border-left: .25rem solid #36b9cc !important;
        float: left;
        background-color: #fff;
        height: 110px;
        padding: 15px 0px 5px 0px;
        width: 185px;
        margin: 5px 0px 0px 0px;
    }


        .LiteBlueOuter2:hover {
            box-shadow: 1px 4px 20px grey;
            -webkit-transition: box-shadow .3s ease-in;
        }

    .LiteBlueText2 {
        width: 90%;
        font-size: 14px;
        font-family: 'OpenSansSemibold';
        margin: 0px 0px 25px 15px;
        float: left;
        color: #36b9cc !important;
    }

    .LtBlueRightSideDown2 {
        color: #36b9cc !important;
        margin: 0px 10px 0px 0px;
        font-family: 'OpenSansSemibold';
        float: right;
        font-size: 22px;
        width: 75%;
        text-align: right;
    }

    .ProductBG {
        width: 100%;
        margin: 10px auto 0px auto;
        height: auto;
    }

    .ModuleBox {
        width: 45%;
        float: left;
        margin: 5px 0px 0px 0px;
    }

    select#ddl_FAYear {
        height: 24px;
        width: 64px !important;
        background-color: #f8f9fc;
        margin: 0px 0px 0px 48px;
    }

    .AccountsBox a {
        color: #fff !important;
    }

        .AccountsBox a:hover {
            text-decoration: none;
        }

    .mid_div {
        float: left;
        margin: 0px 0px 0px 0px;
        width: 100%;
        display:none;
    }



    .lineChart {
        width: 760px;
        font-size: 13px;
        font-family: 'OpenSansSemibold';
        height: 42px;
        padding: .75rem 1.25rem;
        margin-bottom: 0;
        background-color: #fff;
    }



    .piechart {
        width: 350px;
        height: 42px;
        font-family: 'OpenSansSemibold';
        padding: .75rem 1.25rem;
        margin-bottom: 0;
        background-color: #fff;
    }

    .Unclosed {
        margin: -16px 0px 0px 20px;
        width: 15%;
    }

    .PendingTbl2 {
        width: 185px;
        float: left;
        margin: 0px 0px 0px 0px;
        overflow: hidden;
    }

    .PendingRightnewLRightNew1 {
        float: left;
        width: 716px;
        margin: 0px 5px 0px 7px;
        overflow: hidden;
        background: #fff;
    }

    .PendingRightnewChart {
        float: left;
        margin: 0px 0px 0px 0px;
        width: 26%;
        background: #fff;
    }



    .Unclosed h3 {
        font-family: 'OpenSansSemibold';
        color: #184684;
        font-size: 14px;
        padding: 10px 0px 10px 5px;
        margin: 0px 0px 0px 6px;
    }

    thead {
        position: sticky;
        top: -1px;
    }

    body {
        font-family: 'OpenSansRegular', "Helvetica Neue", Helvetica, Arial, sans-serif !important;
        color: #000 !important;
        font-size: 13px !important;
    }


    table#Gridexrate td:nth-child(2), td:nth-child(3) {
        text-align: right;
    }
    .shadow_box:hover {
    box-shadow: 1px 4px 20px grey;
    -webkit-transition: box-shadow .3s ease-in;
}
</style>
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
<body class="drawer drawer--left">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600">
        </asp:ScriptManager>
        <div id="container">

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



                <div class="ModuleBox custom-d-flex custom-mt-05">
                    <a href="#" id="FAccounts" runat="server" class="custom-col custom-mr-05 custom-ml-05">
                        <div class=" shadow_box Blue">
                            <span class="title">Financial Accounts</span>

                            <div class="Amount">
                                <asp:DropDownList ID="ddl_FAYear" runat="server" Width="109px" dataplaceholder="Financial Year" TabIndex="2" CssClass="chzn-select">
                                    <asp:ListItem Value="0">Financial Year</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>
                    </a>

                <div style="display: none;">
                    <a id="Accounts_and_finanace" runat="server" href="#">
                        <div class="AccountsBox">

                            <p>Accounts and Finance</p>
                        </div>
                    </a>
                </div>
                <a id="Credit_Control" runat="server" href="#">
                    <div class="GreenOuterDiv" style="display: none">
                        <span class="GreenText">Credit Control</span>

                        <div class="GreenRightSideDown">
                            <i class="fa fa-line-chart" style="font-size: 29px; color: #1cc88a;"></i>
                        </div>

                    </div>
                </a>
                <a id="Budget" runat="server" href="#">
                    <div class="LiteBlueOuter" style="display: none">
                        <span class="LiteBlueText">Budget</span>
                        <div class="LtBlueRightSideDown">
                            <img src="Theme/assets/img/homeimg/Budget.ico" alt="" width="35px" height="38px">
                        </div>
                    </div>
                </a>
                <a id="MIS_and_Analysis" runat="server" href="#"  class="custom-col custom-mr-05">
                    <div class=" shadow_box Yellow">

                        <span class=" title">MIS & Analytics</span>
                            <i class="fa fa-bar-chart Amount" style="font-size: 25px !important; color: #f6c23e;"></i>
                    </div>
                </a>

                <a id="Utility" runat="server" href="#">
                    <div class="GreenOuterDiv2" style="display: none">

                        <span class="GreenText2">Utility</span>
                        <div class="GreenRightSideDown2">
                            <img src="Theme/assets/img/homeimg/UtilityIcon.ico" alt="" width="42px" height="35px">
                        </div>
                    </div>
                </a>
                <a id="CRM" runat="server" href="#">
                    <div class="CRMBox1" style="display: none;">
                        <p>CRM</p>
                    </div>
                </a>

                <a id="Maintenances" runat="server" href="#" class="">
                    <div class=" shadow_box Red">
                        <span class=" title">Maintenance</span>
                            <i class="fa fa-cogs Amount" style="font-size: 25px !important; color: #e74a3b;"></i>
                    </div>
                </a>
                <a id="HRM" runat="server" href="#" style="display: none;">
                    <div class="HumanBox">
                        <p>Human Resources</p>
                    </div>
                </a>
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
            <div class="NewsMarquee">

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


            <div class="mid_div">

                <div id="div_bar" runat="server" class="PendingRightnewLRightNew1">


                    <div class="lineChart">Job Status</div>
                    <asp:Literal ID="lts" runat="server"></asp:Literal>
                    <div id="chart_divbar"></div>

                </div>


                <div runat="server" id="div6" class="PendingRightnewChart">

                    <div class="piechart">Unclosed Jobs </div>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    <div id="chartdiv" runat="server">
                    </div>
                </div>


                <div class="Unclosed" id="Exrate" runat="server">
                    <div>
                        <h3>
                            <%-- <img src="../Theme/assets/img/exrate_ic.png" />--%>
                            <span>Ex Rate</span></h3>
                    </div>
                    <%-- 22062021 --%>
                    <%--<div class="btn btn-excel1 MT10" >
                          <asp:Button ID="btn_exp1" runat="server" ToolTip="Export Excel" OnClick="btn_exp1_Click"/>
                          </div>--%>
                    <div class="PendingTbl2">
                        <asp:Panel ID="Panelexrate" runat="server" CssClass="panel_13" Visible="true">
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
            </div>
            <div class="NewsBg" style="display: none;">
                <asp:Panel ID="panel" runat="server" CssClass="div_Grid1">
                    <asp:GridView ID="grd1" runat="server" CssClass="GridTD" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" DataKeyNames="news" Width="100%">
                        <Columns>
                            <asp:BoundField HeaderText="News #" DataField="newsid">
                                <HeaderStyle Wrap="false" Width="40px" HorizontalAlign="Center" />
                                <ItemStyle Wrap="false" HorizontalAlign="Left" Width="40px"></ItemStyle>
                            </asp:BoundField>
                            <%--<asp:BoundField HeaderText="Title" DataField="title">
                            <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Title">
                                <ItemTemplate>
                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 350px">
                                        <asp:Label ID="title" runat="server" Text='<%# Bind("title") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle Wrap="false" Width="350px" HorizontalAlign="Center" />
                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <%--   <asp:BoundField HeaderText="By" DataField="empname">
                            <HeaderStyle Wrap="true" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>--%>
                            <%-- <asp:TemplateField HeaderText ="By">
                        <ItemTemplate>   
                         <div style="overflow:hidden;text-overflow:ellipsis;width:150px">
                         <asp:Label ID="empname" runat="server" Text='<%# Bind("empname") %>'></asp:Label>
                         </div>
                       </ItemTemplate>
                       <HeaderStyle Wrap="false" Width="150px"  HorizontalAlign="Center"  />
                       <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                       </asp:TemplateField>--%>
                            <%--  <asp:TemplateField HeaderText="Select">
                                <HeaderStyle HorizontalAlign="Center" Wrap="true" width="12px"/>
                                <ItemStyle HorizontalAlign="Center" Wrap="true" width="12px"/>
                                <ItemTemplate>
                                <asp:LinkButton ID="lnl_Select" runat="server" CommandName="Select" Font-Underline="false" CssClass="Arrow">⇛</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                        <%--<EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />--%>
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



        <!-- Popup Content -->

        <div class="popup" data-popup="popup-1" style="display:none">
            <div class="popup-inner">



                <div class="tab-content">
                    <div id="tab1" class="tab active">

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


                </div>

                <a class="popup-close" data-popup-close="popup-1" href="#">x</a>
            </div>
        </div>

        <div class="popup" data-popup="popup-2"  style="display:none">
            <div class="popup-inner">

                <div class="Tab_Text_Multiline1">


                    <h3>Objectives</h3>
                    <p>The purpose of this policy is to ensure the proper use of  Demo’s IT & eMail system and make users aware of what Demo ’s acceptable and unacceptable use of its IT & eMail system. The Demo  reserves the right to amend this policy at its discretion. In case of amendments, users will be informed appropriately.</p>
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
                    <%--   <div style="float:left;margin-left:1%;">Prepared by : IT Dept   </div>    
                                          <div style="float:right;margin-right:1%;"> Approved by : Chief Operating Officer</div>--%>
                </div>

                <a class="popup-close" data-popup-close="popup-2" href="#">x</a>
            </div>
        </div>
        <div class="popup" data-popup="popup-3"  style="display:none">
            <div class="popup-inner">
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
                            <div class="div_txt_Mission_lifeCon">
                                <asp:TextBox ID="txt_Group" runat="server" ReadOnly="true" CssClass="Tab_Text_MultilineIns" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="div_break">
                            </div>
                            <div class="div_label" style="color: #df2b2b;">
                                <asp:Label ID="lbl_Employee" runat="server" Text="GROUP TERM LIFE INSURANCE"></asp:Label>
                            </div>
                            <div class="div_break">
                            </div>
                            <div class="div_txt_Mission_lifeCon">
                                <asp:TextBox ID="txt_grplifeins" runat="server" ReadOnly="true" CssClass="Tab_Text_MultilineIns" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="div_break">
                            </div>
                            <div class="div_label" style="color: #df2b2b;">
                                <asp:Label ID="lbl_Medical" runat="server" Text="GROUP MEDICLAIM POLICY"></asp:Label>
                            </div>
                            <div class="div_break">
                            </div>
                            <div class="div_txt_Mission_lifeCon">
                                <asp:TextBox ID="txt_Medical" runat="server" ReadOnly="true" CssClass="Tab_Text_MultilineIns" TextMode="MultiLine"></asp:TextBox>
                            </div>

                            <div class="div_break">
                            </div>
                            <div class="div_txt_Mission_life">
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
                <a class="popup-close" data-popup-close="popup-3" href="#">x</a>
            </div>
       
        <div class="popup" data-popup="popup-4">
            <div class="popup-inner">
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
                <a class="popup-close" data-popup-close="popup-4" href="#">x</a>
            </div>
        </div>
        <div class="popup" data-popup="popup-5">
            <div class="popup-inner">
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
                <a class="popup-close" data-popup-close="popup-5" href="#">x</a>
            </div>
        </div>
        <div class="popup" data-popup="popup-6">
            <div class="popup-inner">
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
                <a class="popup-close" data-popup-close="popup-6" href="#">x</a>
            </div>
        </div>

 </div>



        <!-- Popup Content End -->





        <!-- /Sidebar -->

        <div class="Padtop">
            <div class="Homecontainer">
                <!-- Breadcrumbs line -->
                <%--<div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li class="current"><i class="icon-home"></i><a href="#"></a>Home </li>
             
            </ul>
      </div>--%>
                <!-- /Breadcrumbs line -->
                <div class="LoginLeft hide">
                    <img src="Theme/assets/img/light_house.jpg" width="223" height="400">
                </div>




                <div class="TabMenu hide">

                    <div class="tabs animated-fade">
                        <ul class="tab-links">
                            <li class="active"><a href="#tab11">News</a></li>
                            <li><a href="#tab22">Company Profile</a></li>
                            <li><a href="#tab33">IT Policy</a></li>
                            <li><a href="#tab34">Employee Benefits</a></li>
                            <li><a href="#tab35">Income Tax</a></li>
                            <li><a href="#tab36">Appraisal</a></li>
                            <li><a href="#tab37">Other Policies</a></li>
                            <%-- <li><a href="#tab35">Welfare Measures</a></li>--%>
                        </ul>

                        <div class="tab-contentN1">
                            <div id="tab11" class="tab active">

                                <div class="FormGroupContent">
                                </div>
                            </div>

                            <div id="tab22" class="tab">

                                <%-- <div class="div_Head">--%>
                                <div class="FormGroupContentmainmodule">
                                </div>

                            </div>

                            <div id="tab33" class="tab">
                            </div>


                            <div id="tab34" class="tab">
                                <%--<h3>Ten Years Service Awards</h3>
						<p>Happy To Inform That This Year We have 12 0f Our Employees Who have Completed or Will be Completing 10 Years of Service With us. Wish to Congratulate each one of you for a Decade of Meritorious Service With Us.<a href="#">more...</a></p>
                         <div class="bordertopHome"></div>--%>
                                <%--   <div class="div_Head">--%>
                                <div class="FormGroupContentmainmodule">
                                </div>

                            </div>

                            <div id="tab35" class="tab">
                                <%--<h3>Ten Years Service Awards</h3>
						<p>Happy To Inform That This Year We have 12 0f Our Employees Who have Completed or Will be Completing 10 Years of Service With us. Wish to Congratulate each one of you for a Decade of Meritorious Service With Us.<a href="#">more...</a></p> <div class="bordertopHome"></div>--%>
                                <%-- <div class="div_Head">--%>
                                <div class="FormGroupContentmainmodule">
                                </div>
                            </div>



                            <div id="tab36" class="tab">

                                <div class="FormGroupContentmainmodule">
                                </div>
                            </div>
                            <div id="tab37" class="tab">

                                <div class="FormGroupContentmainmodule">
                                </div>
                            </div>
                        </div>

                    </div>









                </div>

                <div class="HomeGroupCS hide">

                    <a>
                        <div class="MenuOE">
                            <img src="Theme/assets/img/icons/accounts_ic.png">
                            <h3>Accounts and Finance</h3>
                        </div>
                    </a>

                    <a>
                        <div class="MenuOI">
                            <img src="Theme/assets/img/icons/creditcontrol_ic.png">
                            <h3>Credit Control</h3>
                        </div>
                    </a>

                    <a>
                        <div class="MenuAE">
                            <img src="Theme/assets/img/icons/budjet_ic.png">
                            <h3>Budget</h3>
                        </div>
                    </a>

                    <a>
                        <div class="MenuAI">
                            <img src="Theme/assets/img/icons/misanalytics_ic.png">
                            <h3>MIS and Analysis</h3>
                        </div>
                    </a>

                    <a>
                        <div class="MenuOE" style="margin: 10px 10px 0px 0px;">
                            <img src="Theme/assets/img/icons/utility_ic.png">
                            <h3>Utility</h3>
                        </div>
                    </a>
                    <a>
                        <div class="MenuAI">
                            <img src="Theme/assets/img/icons/crm_ic.png">
                            <h3>CRM</h3>
                        </div>
                    </a>

                    <a>
                        <div class="MenuME">
                            <img src="Theme/assets/img/icons/maintenance_ic.png">
                            <h3>Maintenance</h3>
                        </div>
                    </a>
                    <a>
                        <div class="HR">
                            <div class="HRIC"></div>
                            <h3>Human Resources</h3>
                        </div>
                    </a>
                </div>


            </div>
        </div>
        </div>


    </form>
</body>
</html>
