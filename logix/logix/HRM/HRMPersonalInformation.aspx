<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="HRMPersonalInformation.aspx.cs" Inherits="logix.HRM.HRMPersonalInformation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <link href="../Theme/newTheme/css/systemnewdeign.css" rel="stylesheet" />
    <!--=== JavaScript ===-->

    <%-- <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- App -->
    <script type="text/javascript" src="../js/helper.js"></script>


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

    <link href="../Styles/Personalinfo.css" rel="stylesheet" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />

    <%--//$(document).ready(function () {
             //    //            $('#Img_Signupload').bind('click', function () {
             //    //                $('#sign_upload').click();
             //    //            });
             //    $('#sign_upload').change(function () {
             //        $('#btn_sign').click();
             //    });
             //});
             //window.ondragstart = function () { return false; }
    --%>

    <style type="text/css">
        .QualiDivision {
            width: 25.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .QualiBranch {
            width: 28.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Qualidate {
            width: 20%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Qualidesi1 {
            width: 41.5%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .Qualidesi2 {
            width: 17.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .SignatureImg {
            width: 100%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .div_workproc {
            width: 40%;
            float: left;
            padding: 0px 1% 0px 0px;
            margin: 0px 1% 0px 0px;
            position: relative;
        }

        .QualiDepart {
            width: 29%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .EmpLbltxtboxN {
            width: 71%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .MobileInput1 {
            width: 19%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .modalPopup {
            /*background-color:#FFFFFF; 
            border-width:1px; 
            border-style:solid; 
            border-color:#CCCCCC; 
            margin-left:20%;
            margin-right:17.1%;
            padding:1px; 
            width:62%; 
            Height:336px; 
            display:none;*/
        }

        .divRoated {
            /*width:853px; 
            Height:403px;
            width:100%; 
            Height:100%;
            border:3px solid black;
            margin-left:-0.5%;
            margin-top:-0.5%;*/
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98%;
            margin-top: -2.5%;
            border-radius: 90px 90px 90px 90px;
        }

        .div_txtReport {
            width: 18%;
            float: left;
        }

            .div_txtReport input, Text {
                width: 100%;
            }

        .div_admin {
            margin-left: 0.5%;
            width: 13.8%;
            float: left;
        }

            .div_admin input, text {
                width: 100%;
            }

        .div_function {
            width: 14.5%;
            float: left;
        }

            .div_function input, text {
                width: 100%;
            }

        .div_appraised {
            margin-left: 0.5%;
            width: 15%;
            float: left;
        }

            .div_appraised input, text {
                width: 100%;
            }

        .div_reviewed {
            margin-left: 0.5%;
            width: 11.5%;
            float: left;
        }

            .div_reviewed input, text {
                width: 100%;
            }

        .div_workprocess {
            margin-left: 0.5%;
            width: 22%;
            float: left;
        }

        .FormGroupContent4 {
            width: 100%;
            float: left;
            padding: 0px 0px 0px 0px;
            margin: 5px 0px 0px 0px;
        }

        .div_workprocess input, text {
            width: 100%;
        }

        .EmailTxtInput1 {
            width: 22%;
            float: left;
            margin: 0px 0.5% 0px 0%;
        }

        .PanNoPersonal1 {
            width: 8.4%;
            float: left;
            margin: 0px 0.5% 0px 0%;
        }

        .PnlDesign {
            border: solid 1px #999997;
            height: 150px;
            width: 100%;
            overflow-y: scroll;
            background-color: #fff;
            font-size: 11px;
            font-family: tahoma;
            margin-top: 0.04%;
            position: absolute !important;
            z-index: 999999 !important;
            top: 48px !important;
        }

        .QualiMailIDnew {
            width: 60%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .OffQualinew {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .OffExtnnew {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .EmrgencyInputnew {
            width: 26%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PFInputnew {
            width: 17%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LanDESInew {
            width: 15.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LanDESInew1 {
            width: 17%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .LanDESInew2 {
            width: 26%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .div_qual {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_PnlCust {
        }

        #logix_CPH_pln_popup {
            left: 5px !important;
            top: 48px !important;
        }

        .EduNamenew1 {
            width: 42.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .QualificationTxtNew {
            width: 21%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Qualiyearnew {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .QualificationOrgnew {
            width: 17%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .QualiDrop1new {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Qualiyear1new {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_ddl_function_chzn {
            width: 100% !important;
        }

        .EmpRight {
            width: 14%;
            float: left;
            margin: 10px 1% 0px 0px;
        }

        div#logix_CPH_Pln_Personal {
            width: 91%;
        }

        .EmpLeft {
            width: 97.5%;
            float: left;
            margin: 0px 1% 0px 0px !important;
            text-transform: none !important;
        }

        .OffLeft {
            width: 90.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .OffRight {
            width: 111%;
            float: left;
            margin: 10px 0px 0px 0px;
        }

        .EmpLbltxtbox {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        DateyrMonthP {
            width: 7.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BGroupTxtBoxP {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FatherNamePA {
            width: 50%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .SpousenamePA {
            width: 49.5%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .FatherName {
            width: 25%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Spousename {
            width: 24%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .DateyrMonthP {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .OffExp {
            width: 8.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .EMPMr {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .EduLink1 {
            float: left;
            width: 5%;
            margin: 0px 0.5% 0px 0.5%;
        }

            .EduLink1 a {
                font-size: 12px;
            }

        /*LOG DETAILS CSS*/

        .btn-logic1 {
            z-index: 2;
            border-radius: 0px;
        }

            .btn-logic1 a {
                border: medium none;
                line-height: normal;
                color: #4e4e4c !important;
                padding: 0px 0px 10px 28px;
                background: url(../Theme/assets/img/buttonIcon/log_ic1.png) no-repeat left 0px;
                margin: 0px 0px 2px 10px;
                font-size: 11px;
            }

        .crumbs {
            margin: 0px -20px 0px 10px;
            height: 27px;
            line-height: 22px;
            pointer-events: none !important;
            background: #fff;
            border-bottom: 0px solid #d9d9d9;
            position: sticky;
            top: 0;
            z-index: 10;
        }

        .modalPopupLog {
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
            width: 65%;
            float: left;
            margin: 2px 0px 3px 4px;
        }

            .LogHeadLbl label {
                color: #af2b1a;
                font-weight: bold;
                font-size: 12px;
            }

        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LogHeadJobInput label {
            font-size: 12px;
        }

        .LogHeadJobInput {
            width: 15%;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 12px;
                margin: 4px 0px 0px 0px;
            }

            .LogHeadJobInput label {
                font-size: 12px;
                font-family: sans-serif;
                color: #4e4e4c;
            }

        logix_CPH_PanelLog {
            border-width: 2px;
            border-style: solid;
            position: fixed;
            z-index: 100001;
            left: 352px;
            top: 187px !important;
        }

        .DateyrMonthPP {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

            .DateyrMonthPP span {
                font-size: 9px;
                color: maroon;
                margin: 33px 0 0;
                display: inline-block;
            }

        div#logix_CPH_UpdatePanel2 {
            margin: 3px 0px 0px;
        }

        .FieldInput {
            width: 100%;
            float: left;
            margin: 0px 0px 1px 0px;
        }

        .OffFileUpload input {
            width: 79% !important;
            padding: 8px;
        }

        .BrowseFileUpload input {
            padding: 8px;
            width: 88% !important;
        }

        .FormGroupRow {
            width: 100%;
            float: left;
            margin: 5px 0px 1px 0px;
        }

        .main_page {
            border: 1px solid var(--inputborder);
            height: 210px;
            padding: 10px;
        }

        .chzn-drop {
            height: 229px !important;
        }
    </style>

    <script type="text/javascript">

        function ShowpImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%= Img_Emp.ClientID %>').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
                document.getElementById('<%= btn_imgupload.ClientID %>').click();
            }
        }

        function ShowpImagePreview1(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%= Img_Sign.ClientID %>').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
                document.getElementById('<%= btn_signupload.ClientID %>').click();
            }
        }

    </script>

    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {
                $('input:text:first').focus();
            });
            $(document).ready(function () {
                $("#<%=txt_name.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_empname.ClientID %>").val(0);
                        $.ajax({
                            url: "../HRM/HRMPersonalInformation.aspx/getempname",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1]

                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }

                        });
                    },

                    select: function (event, i) {
                        $("#<%=txt_name.ClientID %>").val(i.item.label);
                        $("#<%=txt_name.ClientID %>").change();
                        $("#<%=hid_empname.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_name.ClientID %>").val(i.item.label);
                        $("#<%=hid_empname.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_name.ClientID %>").val(i.item.label);
                        $("#<%=hid_empname.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txt_name.ClientID %>").val(i.item.label);
                        $("#<%=hid_empname.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_Adminreport.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_adminreport.ClientID %>").val(0);
                        $.ajax({
                            url: "../HRM/HRMPersonalInformation.aspx/getreviewedname",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1]

                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }

                        });
                    },

                    select: function (event, i) {
                        $("#<%=txt_Adminreport.ClientID %>").val(i.item.label);
                        $("#<%=txt_Adminreport.ClientID %>").change();
                        $("#<%=hid_adminreport.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_Adminreport.ClientID %>").val(i.item.label);
                        $("#<%=hid_adminreport.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_Adminreport.ClientID %>").val(i.item.label);
                        $("#<%=hid_adminreport.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txt_Adminreport.ClientID %>").val(i.item.label);
                        $("#<%=hid_adminreport.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%= txt_Function.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_functionalreport.ClientID %>").val(0);
                        $.ajax({
                            url: "../HRM/HRMPersonalInformation.aspx/getreviewedname",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1]

                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }

                        });
                    },

                    select: function (event, i) {
                        $("#<%=txt_Function.ClientID %>").val(i.item.label);
                        $("#<%=txt_Function.ClientID %>").change();
                        $("#<%=hid_functionalreport.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_Function.ClientID %>").val(i.item.label);
                        $("#<%=hid_functionalreport.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_Function.ClientID %>").val(i.item.label);
                        $("#<%=hid_functionalreport.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txt_Function.ClientID %>").val(i.item.label);
                        $("#<%=hid_functionalreport.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });
            $(document).ready(function () {
                $("#<%= txt_reviewedby.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_reviewedby.ClientID %>").val(0);
                        $.ajax({
                            url: "../HRM/HRMPersonalInformation.aspx/getreviewedname",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1]

                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }

                        });
                    },

                    select: function (event, i) {
                        $("#<%=txt_reviewedby.ClientID %>").val(i.item.label);
                        $("#<%=txt_reviewedby.ClientID %>").change();
                        $("#<%=hid_reviewedby.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_reviewedby.ClientID %>").val(i.item.label);
                        $("#<%=hid_reviewedby.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_reviewedby.ClientID %>").val(i.item.label);
                        $("#<%=hid_reviewedby.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txt_reviewedby.ClientID %>").val(i.item.label);
                        $("#<%=hid_reviewedby.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });
            $(document).ready(function () {
                $("#<%= txt_Appraisal.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_appraisal.ClientID %>").val(0);
                        $.ajax({
                            url: "../HRM/HRMPersonalInformation.aspx/getreviewedname",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1]

                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }

                        });
                    },

                    select: function (event, i) {
                        $("#<%=txt_Appraisal.ClientID %>").val(i.item.label);
                        $("#<%=txt_Appraisal.ClientID %>").change();
                        $("#<%=hid_appraisal.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_Appraisal.ClientID %>").val(i.item.label);
                        $("#<%=hid_appraisal.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_Appraisal.ClientID %>").val(i.item.label);
                        $("#<%=hid_appraisal.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txt_Appraisal.ClientID %>").val(i.item.label);
                        $("#<%=hid_appraisal.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            <%-- $(document).ready(function () {
                $("#<%= ddl_workproces.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%= hid_workprocess.ClientID %>").val(0);
                        $.ajax({
                            url: "../HRM/HRMPersonalInformation.aspx/getprocessname",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1]

                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }

                        });
                    },

                    select: function (event, i) {
                        $("#<%=ddl_workproces.ClientID %>").val(i.item.label);
                        $("#<%=ddl_workproces.ClientID %>").change();
                        $("#<%=hid_workprocess.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=ddl_workproces.ClientID %>").val(i.item.label);
                        $("#<%=hid_workprocess.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=ddl_workproces.ClientID %>").val(i.item.label);
                        $("#<%=hid_workprocess.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=ddl_workproces.ClientID %>").val(i.item.label);
                        $("#<%=hid_workprocess.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });--%>
            <%-- $(document).ready(function () {
                $("#<%=txtReportingto.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_Report.ClientID %>").val(0);
                        $.ajax({
                            url: "../HRM/HRMPersonalInformation.aspx/getReport",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1]

                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }

                        });
                    },

                    select: function (event, i) {
                        $("#<%=txtReportingto.ClientID %>").val(i.item.label);
                        $("#<%=txtReportingto.ClientID %>").change();
                        $("#<%=hid_Report.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtReportingto.ClientID %>").val(i.item.label);
                        $("#<%=hid_Report.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txtReportingto.ClientID %>").val(i.item.label);
                        $("#<%=hid_Report.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtReportingto.ClientID %>").val(i.item.label);
                        $("#<%=hid_Report.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });--%>

         <%--   $(document).ready(function () {
                $("#<%=txt_empcode.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail_Allowance();
                    }
                    else {
                        alertify.alert("Please Enter Numeric Values");
                        var strval = $(this).val();
                        var strText = strval.substr(0, strval.length - 1)
                        $(this).val(strText);
                        return false;
                    }
                });
            });--%>

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

        }
    </script>
    <script type="text/javascript">
        function ConfirmationBox() {
            var result = confirm('Do you Want to delete this Details?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <style>
        .widget-header h3 {
            margin: 0;
            font-size: 13px;
            float: left;
        }

            .widget-header h3 img {
                width: 23px;
                margin: 0;
            }


        .widget-header .breadcrumb {
            padding: 0px 20px !important;
        }

        .widget-content {
            width: 65%;
        }

        .EmpCode {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_PnlCust tr, #logix_CPH_PnlCust td {
            background: white;
            padding: 3px 5px !important;
        }

        .widget.box .widget-content {
            top: 0px !important;
            padding-top: 65px !important;
        }

        div#UpdatePanel1 {
            /* height: 100vh; */
            height: 92vh;
            overflow-x: hidden;
            overflow-y: hidden;
        }

        .role {
            width: 99%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        .DropReason {
    width: 40%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .ReasonDate {
    width: 20%;
    float: left;
    margin: 0px 0% 0px 0px;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- Breadcrumbs line End -->
    <div class="maindiv">
    <div class="widget box">
        <div class=" widget-header">
            <div>
            <h3 class="hide">
                <img src="../Theme/newTheme/img/personalinfo_ic.png" />
                <asp:Label ID="lbl_header" runat="server" Text="Personal Info"></asp:Label>
            </h3>
            <div class="crumbs">
                <ul id="breadcrumbs" class="breadcrumb">
                    <li><i class="icon-home"></i><a href="#"></a>Home </li>
                    <li><a href="#">HRM</a></li>
                    <li><a href="#" title="">HRM</a> </li>
                    <li class="current">Personal Info</li>
                </ul>
            </div>
            <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm">
                <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
            </div>
                </div>

            <div class="FixedButtons">
  <div style="float: left;" class="left_btn">
                <asp:LinkButton ID="link_cust" runat="server" OnClick="link_cust_Click">
                               <%-- <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />--%>
                    <img src="../Theme/assets/img/buttonIcon/active/excel.png" title="Export to Excel" />
                </asp:LinkButton>

                <div style="clear: both;"></div>
            </div>

    <div class="right_btn">
        <div class="btn ico-save" id="btn_save1" runat="server">
            <asp:Button ID="btn_save" runat="server" Text="Save" ToolTip="Save" OnClick="btn_save_Click" />
        </div>
        <div class="btn ico-view">
            <asp:Button ID="btn_view" runat="server" Text="View" ToolTip="View" OnClick="btn_view_Click" />
        </div>
        <div class="btn ico-cancel" id="btn_cancel1" runat="server">
            <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
        </div>
    </div>
</div>



        </div>
        <div class="widget-content">
            
            <div class="FormGroupRow">
                <div class="EmpRight">
                    <asp:Image ID="Img_Emp" runat="server" Height="106px" Width="100px" BorderStyle="Solid" BorderWidth="1px" ImageUrl="~/images/UT.jpg" />
                    <div class="BrowseFileUpload">
                        <%--<asp:FileUpload ID="img_upload" CssClass="bt" runat="server" onchange="ShowpImagePreview(this);" />--%>

                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
                            <ContentTemplate>
                                <span style="display: block; color: #fff; background-color: #5ba701; color: black; width: 121px; font-size: 12px; padding: 0px 0px 0px 0px;"></span>
                                <asp:FileUpload ID="img_upload" CssClass="bt" runat="server" onchange="ShowpImagePreview(this);" />
                                <div class="div_btn">
                                    <asp:Button ID="Button1" runat="server" Text="Upload" Width="100%" CssClass="Button" Visible="false" />
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btn_imgupload" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>

                </div>

                <asp:Panel ID="Pln_Personal" runat="server" Visible="true">
                    <div class="custom-d-flex">
                        <div class="EmpLeft">
                            <div class="FormGroupContent4">
                                <asp:Label ID="lbl_EduEmpcode" CssClass="hide" runat="server" Text="Emp Code"></asp:Label>
                                <div class="EmpCode">


                                    <asp:TextBox ID="txt_empcode" runat="server" placeholder="Emp Code" ToolTip="Emp Code" AutoPostBack="True" CssClass="form-control" OnTextChanged="txt_empcode_TextChanged" MaxLength="4"></asp:TextBox>
                                </div>




                                <div class="EMPMr">


                                    <asp:DropDownList ID="ddl_name" runat="server" placeholder="Title" AppendDataBoundItems="True" Width="100%" CssClass="chzn-select">
                                        <asp:ListItem>Mr</asp:ListItem>
                                        <asp:ListItem>Ms</asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                <div class="EmpLbltxtboxN">
                                    <div class="FieldInput">
                                        <asp:TextBox ID="txt_name" runat="server" CssClass="form-control" placeholder="Name" AutoPostBack="true" ToolTip="Name" OnTextChanged="txt_name_TextChanged"></asp:TextBox>
                                    </div>

                                </div>
                            </div>
                            <div class="FormGroupContent4">

                                <div class="QualiBranch">
                                    <div class="FieldInput">
                                        <asp:DropDownList ID="ddl_branch" runat="server" placeholder="Branch" AppendDataBoundItems="True" CssClass="chzn-select"
                                            ToolTip="Branch" data-placeholder="Branch">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                </div>
                                <div class="QualiDepart">
                                    <div class="FieldInput">
                                        <asp:DropDownList ID="ddl_department" runat="server" placeholder="Department" CssClass="chzn-select" AppendDataBoundItems="True"
                                            ToolTip="DEPARTMENT" data-placeholder="DEPARTMENT">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                </div>
                                <div class="Qualidesi1">
                                    <div class="FieldInput">
                                        <asp:DropDownList ID="ddl_designation" placeholder="Designation" ToolTip="DESIGNATION" data-placeholder="DESIGNATION" runat="server" Font-Size="8.8pt" CssClass="chzn-select" AppendDataBoundItems="True" Height="20px" ForeColor="Black" Style="border: 1px solid black;">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                </div>

                            </div>
                            <div class="FormGroupContent4">
                                <div class="Qualidate">
                                    <div class="FieldInput">
                                        <asp:TextBox ID="txt_doj" runat="server" placeholder="D O J" AutoPostBack="true" ToolTip="D O J" CssClass="form-control"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="MobileInput1">
                                    <div class="FieldInput">
                                        <asp:TextBox ID="txt_mobile" runat="server" placeholder="Mobile" ToolTip="Mobile" MaxLength="13" CssClass="form-control"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="QualiMailIDnew">
                                    <div class="FieldInput">
                                        <asp:TextBox ID="txt_mailid" runat="server" placeholder="Mail ID" ToolTip="Mail ID" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_mailid_TextChanged"></asp:TextBox>
                                    </div>

                                </div>










                                <div class="div_workproc">





                                    <asp:DropDownList ID="ddl_process" runat="server" placeholder="Work Process" AppendDataBoundItems="True" CssClass="chzn-select" OnSelectedIndexChanged="ddl_process_SelectedIndexChanged"
                                        ToolTip="Work Process" data-placeholder="Work Process">
                                        <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        <asp:ListItem Value="9" Text="Air Exports"></asp:ListItem>
                                        <asp:ListItem Value="10" Text="Air Imports"></asp:ListItem>
                                        <asp:ListItem Value="21" Text="Financial Accounts"></asp:ListItem>
                                        <asp:ListItem Value="18" Text="MIS & Analytics"></asp:ListItem>
                                        <asp:ListItem Value="19" Text="Maintenance"></asp:ListItem>
                                        <asp:ListItem Value="7" Text="Ocean Exports"></asp:ListItem>
                                        <asp:ListItem Value="8" Text="Ocean Imports"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Sales"></asp:ListItem>


                                    </asp:DropDownList>

                                </div>


                                <%--<ContentTemplate>--%>
                                <div class="FormGroupContent4">
                                    <div class="role">
                                        <asp:TextBox ID="txt_workprocess" ToolTip="Role" placeholder="Role" runat="server" ReadOnly="true" CssClass="form-control" Width="101.5%" TabIndex="33"></asp:TextBox>
                                    </div>

                                    <asp:Panel ID="PnlCust" runat="server" CssClass="">
                                        <asp:CheckBoxList ID="chkproducts" runat="server" AutoPostBack="true" Width="70%" OnSelectedIndexChanged="chkproducts_SelectedIndexChanged">
                                            <%--<asp:ListItem>Select All</asp:ListItem>--%>
                                            <%-- <asp:ListItem>CRM</asp:ListItem>
                                                    <asp:ListItem>Sales / Sales Support</asp:ListItem>
                                                    <asp:ListItem>Customer Suport - Ocean Exports</asp:ListItem>
                                                    <asp:ListItem>Customer Suport - Ocean Imports</asp:ListItem>
                                                    <asp:ListItem>Customer Support - Air Exports</asp:ListItem>
                                                    <asp:ListItem>Customer Support - Air Imports</asp:ListItem>
                                                    <asp:ListItem>Ops & Docs - Ocean Exports</asp:ListItem>
                                                    <asp:ListItem>Ops & Docs - Ocean Imports</asp:ListItem>
                                                    <asp:ListItem>Ops & Docs - Air Exports</asp:ListItem>
                                                    <asp:ListItem>Ops & Docs - Air Imports</asp:ListItem>
                                                    <asp:ListItem>CHA</asp:ListItem>
                                                    <asp:ListItem>Bonded Trucking</asp:ListItem>
                                                    <asp:ListItem>Human Resources - Recruitment & Appraisal</asp:ListItem>
                                                    <asp:ListItem>Human Resources - Payroll</asp:ListItem>
                                                    <asp:ListItem>IT - System Admin & Networking</asp:ListItem>
                                                    <asp:ListItem>IT - DBA</asp:ListItem>
                                                    <asp:ListItem>IT - Development</asp:ListItem>
                                                    <asp:ListItem>MIS & Analytics</asp:ListItem>
                                                    <asp:ListItem>Corporate</asp:ListItem>
                                                    <asp:ListItem>Operating Accounts</asp:ListItem>
                                                    <asp:ListItem>Financial Accounts</asp:ListItem>--%>
                                        </asp:CheckBoxList>
                                    </asp:Panel>
                                </div>
                                <ajaxtol:PopupControlExtender ID="PceSelectCustomer" runat="server" TargetControlID="txt_workprocess"
                                    PopupControlID="PnlCust" Position="Bottom">
                                </ajaxtol:PopupControlExtender>
                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                                <%--  </ContentTemplate>--%>


                                <%-- </div>--%>

                                <div class="DateyrMonthPP">
                                    <asp:Label ID="lbl_PWD" runat="server" placeholder="Password" CssClass="password1" Visible="false"></asp:Label>
                                </div>
                            </div>
                    <div class="FormGroupContent4">



                        <div class="DropReason">
                            <div class="LabelWidth hide">Relieving Reason</div>

                            <div class="FieldInput">
                                <asp:DropDownList ID="ddl_reason" runat="server" CssClass="chzn-select" data-placeholder="Relieving Reason" ToolTip="Relieving Reason" TabIndex="34">
                                    <asp:ListItem></asp:ListItem>
                                      <asp:ListItem Value="0" Text=""></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Better Opportunity"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Poor Performance"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Termination"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="Retrenchment"></asp:ListItem>
                                    <asp:ListItem Value="5" Text="Medical Treatment"></asp:ListItem>
                                    <asp:ListItem Value="6" Text="Relocation"></asp:ListItem>
                                    <asp:ListItem Value="7" Text="Others"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>

                        <div class="ReasonDate">
                            <div class="LabelWidth hide">DOL</div>
                            <div class="FieldInput DateR">
                                <asp:TextBox ID="txt_dol" CssClass="form-control" runat="server" placeholder="DOL" ToolTip="DOL" Enabled="False" TabIndex="35"></asp:TextBox>
                            </div>
                            <ajaxtol:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_dol"></ajaxtol:CalendarExtender>
                            <asp:HiddenField ID="hid_date" runat="server" />
                        </div>
                                  <div class="btn ico-save" id="Div1" runat="server">
              <asp:Button ID="btn_add" runat="server" ToolTip="Save" Text="Save"  OnClick="btn_add_Click" /></div>

                    </div>

                        </div>

                        <div class="FormGroupContent4" style="width: 20%;">

                            <div class="OffRight">

                                <div class="SignatureImg">
                                    <asp:Image ID="Img_Sign" runat="server" ToolTip="BL Speciman Signature" ImageUrl="~/images/signature.JPG" Height="52px"
                                        Width="118px" BorderStyle="Solid" BorderWidth="1px" />
                                </div>
                                <div class="FormGroupContent4" style="width: 100%">
                                    <div class="OffFileUpload">
                                        <%--<asp:FileUpload ID="sign_upload" runat="server" Width="150px" onchange="ShowpImagePreview1(this);" />--%>

                                        <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Always" runat="server">
                                            <ContentTemplate>
                                                <asp:FileUpload ID="sign_upload" runat="server" Width="150px" onchange="ShowpImagePreview1(this);" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btn_signupload" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <div class="QualiUpload">
                                            <asp:Button ID="btn_sign" runat="server" Text="Upload" Width="100%" Visible="false" />
                                        </div>

                                    </div>



                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="EmpLeft_oldDesign hide">

                        <%--Hide Down Fields--%>
                        <div class="FormGroupContent4">

                            <div class="DateyrMonthP">
                                <div class="LabelWidth">DOB</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_dob" runat="server" placeholder="" CssClass="form-control" ToolTip="DOB"></asp:TextBox>
                                </div>

                            </div>
                            <div class="BGroupTxtBoxP">
                                <div class="LabelWidth">B.Group</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_group" runat="server" placeholder="" CssClass="form-control" ToolTip="B.Group"></asp:TextBox>
                                </div>

                            </div>
                            <div class="FatherName">
                                <div class="LabelWidth">Father's Name</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_fathername" placeholder="" CssClass="form-control" ToolTip="Father Name" runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <div class="Spousename">
                                <div class="LabelWidth">Spouse Name</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_spousename" placeholder="" CssClass="form-control" ToolTip="Spouse Name" runat="server"></asp:TextBox>
                                </div>

                            </div>

                        </div>


                        <div class="FormGroupContent4">

                            <div class="FatherNamePA">
                                <div class="LabelWidth">Permanent Address</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_permanentaddress" runat="server" TextMode="MultiLine" placeholder="" CssClass="form-control" Style="resize: none; padding-top: 3px!important;" ToolTip="Permanent Address"></asp:TextBox>
                                </div>

                            </div>
                            <div class="SpousenamePA">
                                <div class="LabelWidth">Present Address</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_presentaddress" runat="server" TextMode="MultiLine" Style="resize: none; padding-top: 3px!important;" CssClass="form-control" placeholder="" ToolTip="Present Address"></asp:TextBox>
                                </div>

                            </div>
                        </div>

                        <div class="FormGroupContent4">
                            <div class="MobileInput1">
                                <div class="LabelWidth">Emergency.Cont</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_emergency" runat="server" placeholder="" ToolTip="Emergency.Cont" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>
                            <div class="MobileInput1">
                                <div class="LabelWidth">Land Line</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_land" runat="server" placeholder="" ToolTip="Land line" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>
                            <div class="EmailTxtInput1">
                                <div class="LabelWidth">Email</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_email" runat="server" placeholder="" ToolTip="Email" AutoPostBack="true" CssClass="form-control" OnTextChanged="txt_email_TextChanged"></asp:TextBox>
                                </div>

                            </div>
                            <div class="PanNoPersonal1">
                                <div class="LabelWidth">PAN #</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_pan" runat="server" placeholder="" ToolTip="PAN #" MaxLength="10" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>
                            <div class="OffQualinew">
                                <div class="LabelWidth">Qualification</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_offqualification" runat="server" placeholder="" ToolTip="Qualification" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>
                            <div class="OffExp">
                                <div class="LabelWidth">Experience</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_offexp" runat="server" placeholder="" ToolTip="Experience" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>
                            <div class="LanDESInew1">
                                <div class="LabelWidth">Adhar No #</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_adhartno" runat="server" MaxLength="16" placeholder="" ToolTip="AdharNo #" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>
                            <%--<div class="div_txtReport">
                                        <asp:TextBox ID="txtReportingto" runat="server" placeholder="ReportingTo" CssClass="form-control" ToolTip="ReportingTo" Visible="false" OnTextChanged="txtReportingto_TextChanged"></asp:TextBox>
                                    </div>--%>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="QualiDivision">
                                <div class="LabelWidth">Company</div>
                                <div class="FieldInput">
                                    <asp:DropDownList ID="ddl_division" runat="server" AppendDataBoundItems="True" CssClass="chzn-select"
                                        ForeColor="Black" ToolTip="Company"
                                        data-placeholder="Company" AutoPostBack="True" OnSelectedIndexChanged="ddl_division_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text=""></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                            </div>

                        </div>
                    </div>


                    <div class="OffLeft hide">
                        <div class="FormGroupContent4">

                            <div class="QualiGrade">
                                <div class="LabelWidth">Grade</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_grade" runat="server" MaxLength="3" placeholder="" ToolTip="Grade" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>

                            <div class="OffExtnnew">
                                <div class="LabelWidth">Extn. #</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_extn" runat="server" placeholder="" ToolTip="Extn. #" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>
                            <div class="EmrgencyInputnew">
                                <div class="LabelWidth">ACC #</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_scb" runat="server" placeholder="" ToolTip=" Acc #" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>
                            <div class="PFInputnew">
                                <div class="LabelWidth">PF #</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_pf" runat="server" placeholder="" ToolTip="PF #" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>
                            <div class="LanDESInew">
                                <div class="LabelWidth">E S I #</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_esi" runat="server" placeholder=" " ToolTip="E S I #" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>
                            <div class="LanDESInew2">
                                <div class="LabelWidth">UAN #</div>
                                <div class="FieldInput">
                                    <asp:TextBox ID="txt_uanno" runat="server" placeholder="" ToolTip="UAN #" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>

                        </div>

                    </div>
                    <div class="FormGroupContent4 hide">
                        <%--<div class="OffPwd">
                                        <asp:TextBox ID="txt_pwd" runat="server" placeholder=" PWD" ToolTip="Password" CssClass="form-control"></asp:TextBox>
                                    </div>--%>

                        <div class="Qualidesi2">
                            <div class="LabelWidth">Function</div>
                            <div class="FieldInput">
                                <asp:DropDownList ID="ddl_function" ToolTip="FUNCTION" data-placeholder="FUNCTION" runat="server" Font-Size="8.8pt" CssClass="chzn-select" AppendDataBoundItems="True" Height="20px" AutoPostBack="true" ForeColor="Black" Style="border: 1px solid black;" OnSelectedIndexChanged="ddl_function_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>

                        <%--<div class="FormGroupContent4">--%>

                        <div class="div_function">
                            <div class="LabelWidth">Functional Reporting</div>
                            <div class="FieldInput">
                                <asp:TextBox ID="txt_Function" runat="server" placeholder="" AutoPostBack="true" ToolTip="Functional Reporting" CssClass="form-control" OnTextChanged="txt_Function_TextChanged"></asp:TextBox>
                            </div>

                        </div>
                        <div class="div_admin">
                            <div class="LabelWidth">Admin Report</div>
                            <div class="FieldInput">
                                <asp:TextBox ID="txt_Adminreport" runat="server" placeholder="" AutoPostBack="true" ToolTip="Admin Report" CssClass="form-control" OnTextChanged="txt_Adminreport_TextChanged"></asp:TextBox>
                            </div>

                        </div>
                        <div class="div_appraised">
                            <div class="LabelWidth">Appraised By</div>
                            <div class="FieldInput">
                                <asp:TextBox ID="txt_Appraisal" runat="server" placeholder="" AutoPostBack="true" ToolTip="Appraised By" CssClass="form-control" OnTextChanged="txt_Appraisal_TextChanged"></asp:TextBox>
                            </div>

                        </div>
                        <div class="div_reviewed">
                            <div class="LabelWidth">Reviewed By</div>
                            <div class="FieldInput">
                                <asp:TextBox ID="txt_reviewedby" runat="server" placeholder="" AutoPostBack="true" ToolTip="Reviewed By" CssClass="form-control" OnTextChanged="txt_reviewedby_TextChanged"></asp:TextBox>
                            </div>

                        </div>

                        <div class="div_break "></div>

                    </div>

                    <div class="FormGroupContent4 hide">

                        <div class="EduLink MTCtrl6">
                            <asp:LinkButton ID="LinkEdu1" runat="server" OnClick="LinkEdu1_Click">Educational</asp:LinkButton>
                        </div>
                        <div class="EduNamenew1" style="display: none;">
                            <asp:TextBox ID="txt_educa" runat="server" CssClass="form-control" placeholder="Name" ToolTip="Name"></asp:TextBox>
                        </div>
                        <div class="QualificationTxtNew">
                            <div class="LabelWidth">Qualification</div>
                            <div class="FieldInput">
                                <asp:TextBox ID="txt_Eduqualification" runat="server" CssClass="form-control" placeholder="" ToolTip="Qualification"></asp:TextBox>
                            </div>

                        </div>
                        <div class="MonthQualiDrop">
                            <%-- <asp:DropDownList ID="ddl_EduMonrh" runat="server" data-placeholder="Month" ToolTip="Month" CssClass="chzn-select" Height="20px">
                                        <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        <asp:ListItem Value="1">JANUARY</asp:ListItem>
                                        <asp:ListItem Value="2">FEBRUARY</asp:ListItem>
                                        <asp:ListItem Value="3">MARCH</asp:ListItem>
                                        <asp:ListItem Value="4">APRIL</asp:ListItem>
                                        <asp:ListItem Value="5">MAY</asp:ListItem>
                                        <asp:ListItem Value="6">JUNE</asp:ListItem>
                                        <asp:ListItem Value="7">JULY</asp:ListItem>
                                        <asp:ListItem Value="8">AUGUST</asp:ListItem>
                                        <asp:ListItem Value="9">SEPTEMBER</asp:ListItem>
                                        <asp:ListItem Value="10">OCTOBER</asp:ListItem>
                                        <asp:ListItem Value="11">NOVEMBER</asp:ListItem>
                                        <asp:ListItem Value="12">DECEMBER</asp:ListItem>
                                    </asp:DropDownList>--%>
                        </div>
                        <div class="Qualiyearnew">
                            <div class="LabelWidth">Date</div>
                            <div class="FieldInput">
                                <asp:TextBox ID="txt_EduYear" runat="server" placeholder="" ToolTip="Date" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <div class="QualiPer">
                            <div class="LabelWidth">Percentage</div>
                            <div class="FieldInput">
                                <asp:TextBox ID="txt_EduPrecentage" runat="server" placeholder="" CssClass="form-control" ToolTip="Percentage"></asp:TextBox>
                            </div>

                        </div>

                        <div class="btn btn-add1 MTCtrl6" id="btn_add1" runat="server" style="float: left;">
                            <asp:Button ID="btn_EduAdd" runat="server" ToolTip="Add" OnClick="btn_EduAdd_Click" />
                        </div>
                        <%-- <div class="btn btn-add ADDPad">
                                    <asp:Button ID="btnedu_delete" runat="server" Text="Delete" OnClick="btnedu_delete_Click" />
                                </div>--%>
                        <div class="EduLink1 MTCtrl6">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Experience</asp:LinkButton>
                        </div>
                        <%--<div class="EduName1"><asp:TextBox ID="TxtBoxid5" runat="server" CssClass="form-control" placeholder=" EmpCode" Visible="false" ToolTip="Empcode"></asp:TextBox></div>--%>
                        <div class="EduNamenew1" style="display: none;">
                            <asp:TextBox ID="txt_exper" runat="server" CssClass="form-control" placeholder="" ToolTip="Name"></asp:TextBox>
                        </div>
                        <div class="QualificationOrgnew">
                            <div class="LabelWidth">Organisation</div>
                            <div class="FieldInput">
                                <asp:TextBox ID="txt_organisation" runat="server" placeholder="" ToolTip="Organisation" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <div class="QualiDesi">
                            <div class="LabelWidth">Designation</div>
                            <div class="FieldInput">
                                <asp:TextBox ID="txt_designation" runat="server" placeholder="" ToolTip="Designation" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <div class="QualiDrop1new">

                            <div class="LabelWidth">Year</div>
                            <div class="FieldInput">
                                <asp:TextBox ID="txt_fromyear" runat="server" placeholder="" ToolTip="Year" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="QualiDrop1" style="display: none;">
                            <%-- <asp:DropDownList ID="ddl_Expto" runat="server" Height="20px" data-placeholder="To Month" ToolTip="To Month" CssClass="chzn-select">
                                        <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        <asp:ListItem Value="1">JANUARY</asp:ListItem>
                                        <asp:ListItem Value="2">FEBRUARY</asp:ListItem>
                                        <asp:ListItem Value="3">MARCH</asp:ListItem>
                                        <asp:ListItem Value="4">APRIL</asp:ListItem>
                                        <asp:ListItem Value="5">MAY</asp:ListItem>
                                        <asp:ListItem Value="6">JUNE</asp:ListItem>
                                        <asp:ListItem Value="7">JULY</asp:ListItem>
                                        <asp:ListItem Value="8">AUGUST</asp:ListItem>
                                        <asp:ListItem Value="9">SEPTEMBER</asp:ListItem>
                                        <asp:ListItem Value="10">OCTOBER</asp:ListItem>
                                        <asp:ListItem Value="11">NOVEMBER</asp:ListItem>
                                        <asp:ListItem Value="12">DECEMBER</asp:ListItem>
                                    </asp:DropDownList>--%>
                        </div>
                        <div class="Qualiyear1new">
                            <div class="LabelWidth">Year</div>
                            <div class="FieldInput">
                                <asp:TextBox ID="txt_toyear" runat="server" placeholder="" ToolTip="Year" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <div class="btn btn-add1 MTCtrl6 left_btn" id="btn_add2" runat="server" style="float: left;">

                            <asp:Button ID="btn_ExpAdd" runat="server" ToolTip="Add" OnClick="btn_ExpAdd_Click" />
                        </div>
                        <%--<div class="btn btn-add ADDPad">
                                    <asp:Button ID="btn_delete" runat="server"  Text="Delete" OnClick="btn_delete_Click" />
                                </div>--%>
                    </div>


                    <%--EDIT--%>
                    <div class="bordertopNew"></div>
                    <div class="FormGroupContent4">
                        <div class="right_btn MT0 MB05">
                            <div class="btn ico-update" id="btn_update_id" runat="server" visible="false">
                                <asp:Button ID="btn_update" runat="server" ToolTip="Update" Visible="false" OnClick="btn_update_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="btn ico-upload hide">
                        <asp:Button ID="btn_imgupload" runat="server" Text="Image Upload" ToolTip="Image Upload" OnClick="btn_imgupload_Click" />
                    </div>
                    <div class="btn ico-upload hide">
                        <asp:Button ID="btn_signupload" runat="server" Text="Image Upload" ToolTip="Image Upload" OnClick="btn_signupload_Click" />
                    </div>
                </asp:Panel>




                <div class="FormGroupRow">
                    <asp:Panel ID="pln_Education" runat="server" Visible="false" class="Div_Tab1">

                        <div class="FormGroupContent4">
                            <div class="EmpLbl">Emp Code</div>
                            <div class="EmpLbltxtbox">
                                <asp:TextBox ID="txtcode1" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="EMPMr">
                                <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" Width="100%" CssClass="chzn-select">
                                    <asp:ListItem>Mr</asp:ListItem>
                                    <asp:ListItem>Ms</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="EmpLbltxtboxEN">
                                <asp:TextBox ID="txtname1" runat="server" CssClass="form-control" placeholder=" Name" AutoPostBack="true" ToolTip="Name"></asp:TextBox>
                            </div>
                            <div class="DateyrMonthEP">
                                <asp:TextBox ID="txtmondob1" runat="server" ReadOnly="True" placeholder=" DOB" CssClass="form-control" ToolTip="DOB"></asp:TextBox>
                            </div>
                            <div class="BGroupTxtBoxP">
                                <asp:TextBox ID="txtgurop" runat="server" placeholder="B.Group" CssClass="form-control" ToolTip="B.Group"></asp:TextBox>
                            </div>
                            <%--<div class="EDULabel"><asp:Label ID="lbl_Educode" runat="server" Text="Code-"></asp:Label></div>
                                            <div class="EduCodeIn"><asp:Label ID="lbl_EduEmpcode" runat="server" Text=""></asp:Label></div>
                                            <div class="EDULabel"><asp:Label ID="lbl_Eduname" runat="server" Text="Name-"></asp:Label></div>
                                            <div class="EduNametxt"><asp:Label ID="lbl_EduEmpname" runat="server" Text=""></asp:Label></div>--%>
                        </div>
                        <div class="ExpAddCtrl">
                        </div>

                        <div class="FormGroupContent4">

                            <%--<div class="div_EduGrid" style="height:280px;overflow-y:scroll; border-left:1px solid #b1b1b1;border-bottom:1px solid #b1b1b1;">
            <asp:GridView ID="Grd_Edu" CssClass="GridEdu" runat="server" AutoGenerateColumns="False" 
                Width="100%" ForeColor="Black"  ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="Grd_Edu_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="certificate" HeaderText="Qualification">
                        <HeaderStyle Width="350px" />
                        </asp:BoundField>
                    <asp:BoundField DataField="yop" HeaderText="Year of passing">
                         <HeaderStyle Width="150px" />
                        </asp:BoundField>
                    <asp:BoundField DataField="percentage" HeaderText="Percentage">
                         <HeaderStyle Width="250px" />
                        </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="Img_Edudelete" runat="server" CommandName="select" CssClass="Grid_Edit_Img"
                                ImageUrl="~/images/delete.jpg" OnClientClick="javascript:IsConfirm('Do U Want Delete','hid_confirm');" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
        </div>--%>
                        </div>
                    </asp:Panel>
                </div>
                <div class="FormGroupRow">

                    <asp:Panel ID="pln_popup" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="DivSecPanel">
                                <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>

                            <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">
                                <asp:GridView ID="Grd_Edu" CssClass="GridEdu" runat="server" Visible="false" AutoGenerateColumns="False"
                                    Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="True" OnRowCommand="Grd_Edu_RowCommand" OnRowDataBound="Grd_Edu_RowDataBound" OnRowDeleting="Grd_Edu_RowDeleting" OnSelectedIndexChanged="Grd_Edu_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="certificate" HeaderText="Qualification">
                                            <HeaderStyle Width="350px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="yop" HeaderText="Year of passing">
                                            <HeaderStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="percentage" HeaderText="Percentage">
                                            <HeaderStyle Width="250px" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="Img_Edudelete" runat="server" CommandName="Delete" CssClass="Grid_Edit_Img"
                                                    ImageUrl="~/images/delete.jpg" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>

                                <div class="div_Break"></div>

                                <asp:GridView ID="Grd_Exp" CssClass="GridEdu" runat="server" Visible="false" AutoGenerateColumns="False"
                                    Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="True" DataKeyNames="orgname" OnRowCommand="Grd_Exp_RowCommand" OnRowDataBound="Grd_Exp_RowDataBound" OnRowDeleting="Grd_Exp_RowDeleting" OnSelectedIndexChanged="Grd_Exp_SelectedIndexChanged1">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Organisation">
                                            <HeaderStyle Width="350px" />
                                            <ItemTemplate>
                                                <div class="div_EmpOrg">
                                                    <asp:Label ID="lbl_org" runat="server" Text='<%#Eval("orgname")%>' ToolTip='<%#Eval("orgname")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="exfrom" HeaderText="From">
                                            <HeaderStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="exto" HeaderText="To">
                                            <HeaderStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="designation" HeaderText="Designation" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="Img_Expdelete" runat="server" CommandName="Delete" CssClass="Grid_Edit_Img"
                                                    ImageUrl="~/images/delete.jpg" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                            <div class="Break"></div>
                        </div>

                    </asp:Panel>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <ajaxtol:ModalPopupExtender ID="popup_Grd" runat="server" PopupControlID="pln_popup"
                        DropShadow="false" TargetControlID="Label1" CancelControlID="close" BehaviorID="Test">
                    </ajaxtol:ModalPopupExtender>
                </div>
                <div class="FormGroupRow">

                    <asp:Panel ID="Pln_Experience" runat="server" Visible="false" class="Div_Tab1">

                        <div class="FormGroupContent4">
                            <div class="EmpLbl">
                                <asp:Label ID="Label2" runat="server" Text="Emp Code"></asp:Label>
                            </div>
                            <div class="EmpLbltxtbox">
                                <asp:TextBox ID="txtempcode2" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="EMPMr">
                                <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="True" Width="100%" CssClass="chzn-select">
                                    <asp:ListItem>Mr</asp:ListItem>
                                    <asp:ListItem>Ms</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="EmpLbltxtboxEN">
                                <asp:TextBox ID="txtname2" runat="server" CssClass="form-control" placeholder=" Name" AutoPostBack="true" ToolTip="Name"></asp:TextBox>
                            </div>
                            <div class="DateyrMonthEP">
                                <asp:TextBox ID="txtmondob" runat="server" ReadOnly="True" placeholder=" DOB" CssClass="form-control" ToolTip="DOB"></asp:TextBox>
                            </div>
                            <div class="BGroupTxtBoxP">
                                <asp:TextBox ID="txtbg2" runat="server" placeholder="B.Group" CssClass="form-control" ToolTip="B.Group"></asp:TextBox>
                            </div>
                            <%--<div class="EDULabel"><asp:Label ID="lbl_Educode" runat="server" Text="Code-"></asp:Label></div>
                                            <div class="EduCodeIn"><asp:Label ID="lbl_EduEmpcode" runat="server" Text=""></asp:Label></div>
                                            <div class="EDULabel"><asp:Label ID="lbl_Eduname" runat="server" Text="Name-"></asp:Label></div>
                                            <div class="EduNametxt"><asp:Label ID="lbl_EduEmpname" runat="server" Text=""></asp:Label></div>--%>
                        </div>

                        <%-- <div class="FormGroupContent4">

                                             <div class="EDULabel"><asp:Label ID="lbl_Expcode" runat="server" Text="Code-"></asp:Label></div>
                                             <div class="EduCodeIn"><asp:Label ID="lbl_ExpEmpcode" runat="server" Text=""></asp:Label></div>
                                             <div class="EDULabel"><asp:Label ID="lbl_ExpName" runat="server" Text="Name-"></asp:Label></div>
                                             <div class="EduNametxt"><asp:Label ID="lbl_ExpEmpName" runat="server" Text=""></asp:Label></div>

                                         </div>--%>

                        <div class="ExpAddCtrl" style="display: none;">
                            <div class="FormGroupContent4">
                                <div class="right_btn MT0">
                                </div>
                            </div>
                        </div>

                        <div class="div_EduGrid" style="height: 240px; overflow-y: scroll; border-left: 1px solid #b1b1b1; border-bottom: 1px solid #b1b1b1;">
                            <%--<asp:GridView ID="Grd_Edu" CssClass="GridEdu" runat="server" AutoGenerateColumns="False" 
                Width="100%" ForeColor="Black"  ShowHeaderWhenEmpty="True" DataKeyNames="orgname" OnSelectedIndexChanged="Grd_Exp_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Organisation">
                        <HeaderStyle Width="350px" />
                        <ItemTemplate>
                            <div class="div_EmpOrg">
                                <asp:Label ID="lbl_org" runat="server" Text='<%#Eval("orgname")%>' ToolTip='<%#Eval("orgname")%>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="exfrom" HeaderText="From">
                        <HeaderStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="exto" HeaderText="To">
                         <HeaderStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="designation" HeaderText="Designation" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="Img_Expdelete" runat="server" CommandName="select" CssClass="Grid_Edit_Img"
                                ImageUrl="~/images/delete.jpg" OnClientClick="javascript:IsConfirm('Do U Want Delete','hid_confirm_Exp');" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>--%>
                        </div>
                    </asp:Panel>

                </div>
                <div class="FormGroupRow">
                    <asp:Panel ID="Pln_Official" runat="server" Visible="false" class="Div_Tab1">
                        <div class="FormGroupContent4">

                            <div class="EmpLbl">
                                <asp:Label ID="lbl_OffEmpcode" runat="server" Text="Emp Code"></asp:Label>
                            </div>
                            <div class="EmpLbltxtbox">
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="EMPMr">
                                <asp:DropDownList ID="DropDownList3" runat="server" AppendDataBoundItems="True" Width="100%" CssClass="chzn-select">
                                    <asp:ListItem>Mr</asp:ListItem>
                                    <asp:ListItem>Ms</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="EmpLbltxtboxEN">
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder=" Name" AutoPostBack="true" ToolTip="Name"></asp:TextBox>
                            </div>
                            <div class="DateyrMonthEP">
                                <asp:TextBox ID="txt_bob" runat="server" ReadOnly="True" placeholder=" DOB" CssClass="form-control" ToolTip="DOB"></asp:TextBox>
                            </div>
                            <div class="BGroupTxtBoxP">
                                <asp:TextBox ID="txt_grou" runat="server" placeholder="B.Group" CssClass="form-control" ToolTip="B.Group"></asp:TextBox>
                            </div>

                            <%-- <div class="EDULabel"><asp:Label ID="lbl_Offcode" runat="server" Text="Code-"></asp:Label></div>
                                            <div class="EduCodeIn"><asp:Label ID="lbl_OffEmpcode" runat="server" Text=""></asp:Label></div>
                                             <div class="EDULabel"><asp:Label ID="lbl_OffName" runat="server" Text="Name-"></asp:Label></div>
                                            <div class="EduNametxt"><asp:Label ID="lbl_OffEmpname" runat="server" Text=""></asp:Label></div>--%>
                        </div>

                    </asp:Panel>

                    <asp:Label ID="LblCncl" runat="server"></asp:Label>

                </div>

            </div>
        </div>
    </div>

    </div>

    <%--  <div class="FormGroupContent4">
                <div class="div_Tab" id="div_personal" runat="server"> <asp:LinkButton ID="lnk_personal" runat="server" ForeColor="White" CssClass="LabelValue" OnClick="lnk_personal_Click" >Personal Info</asp:LinkButton> </div>
     <div class="div_Tab" id="div_education" runat="server"> <asp:LinkButton ID="lnk_education" runat="server"  CssClass="LabelValue"  ForeColor="White" OnClick="lnk_education_Click">Educational</asp:LinkButton> </div>
     <div class="div_Tab" id="div_experience" runat="server"> <asp:LinkButton ID="lnk_experience" runat="server"  CssClass="LabelValue" ForeColor="White" OnClick="lnk_experience_Click">Experience</asp:LinkButton> </div>
     <div class="div_Tab" id="div_official" runat="server"> <asp:LinkButton ID="lnk_official" runat="server"  CssClass="LabelValue" ForeColor="White" OnClick="lnk_official_Click">Official</asp:LinkButton>  </div>

                 </div>--%>

    <%--    <div class="FormGroupContent4">
                                                <div class="EmrgencyInput"><asp:TextBox ID="txt_scb" runat="server" placeholder=" SB Acc #" ToolTip="SB Acc #" CssClass="form-control"></asp:TextBox></div>
                                               
                                               </div>
                                         <div class="FormGroupContent4">
                                             <div class="PFInput"> <asp:TextBox ID="txt_pf" runat="server" placeholder=" PF #" ToolTip="PF #" CssClass="form-control"></asp:TextBox> </div>
                                             <div class="LandLineInput"><asp:TextBox ID="txt_esi" runat="server" placeholder=" E S I #" ToolTip="E S I #" CssClass="form-control"></asp:TextBox></div>
                                             </div>--%>

    <%--EDIT--%>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Personal Info #</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl">

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

    <asp:Label ID="Label3" runat="server"></asp:Label>

    <ajaxtol:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label3" CancelControlID="imglog" BehaviorID="Test1">
    </ajaxtol:ModalPopupExtender>

    <ajaxtol:CalendarExtender ID="ce_voudate" runat="server" TargetControlID="txt_dob"
        Format="dd/MM/yyyy"></ajaxtol:CalendarExtender>
    <ajaxtol:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_doj"
        Format="dd/MM/yyyy"></ajaxtol:CalendarExtender>
    <ajaxtol:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_EduYear"
        Format="dd/MM/yyyy"></ajaxtol:CalendarExtender>
    <ajaxtol:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_fromyear"
        Format="dd/MM/yyyy"></ajaxtol:CalendarExtender>
    <ajaxtol:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_toyear"
        Format="dd/MM/yyyy"></ajaxtol:CalendarExtender>

    <asp:HiddenField ID="hid_empid" runat="server" />
    <asp:HiddenField ID="hid_Report" runat="server" />
    <asp:HiddenField ID="hid_empname" runat="server" />
    <asp:HiddenField ID="hid_confirm" runat="server" />
    <asp:HiddenField ID="hid_certificate" runat="server" />
    <asp:HiddenField ID="hid_confirm_Exp" runat="server" />
    <asp:HiddenField ID="hid_organisation" runat="server" />
    <asp:HiddenField ID="hid_adminreport" runat="server" />
    <asp:HiddenField ID="hid_functionalreport" runat="server" />
    <asp:HiddenField ID="hid_appraisal" runat="server" />
    <asp:HiddenField ID="hid_workprocess" runat="server" />
    <asp:HiddenField ID="hid_reviewedby" runat="server" />
    <asp:HiddenField ID="hid_functionid" runat="server" />
    <asp:HiddenField ID="functionid" runat="server" />
    <script type="text/javascript">
        function dropdownButton() {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>
</asp:Content>
