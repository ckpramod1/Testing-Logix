<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="MasterCustomerDetails.aspx.cs" Inherits="logix.Maintenance.MasterCustomerDetails" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css" />
    <!--=== JavaScript ===-->

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

    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>

    <script type="text/javascript" src="../js/helper.js"></script>

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
    <link href="../Styles/Mastercompany1.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <link href="../Styles/ControlStyle2.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/button1.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <style type="text/css">
        input#logix_CPH_txt_creditamount {
            text-align: right !important;
        }

        .Limit {
            width: 17.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .empfrom {
            width: 16%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }


        .empto {
            width: 15.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .certno {
            width: 24.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .tds_exp {
            width: 24%;
            margin: 0px;
            float: left;
        }

        div#logix_CPH_Pl_Proof {
            width: 100%;
            height: 130px;
            float: left;
            margin: 0px;
            overflow: auto;
            border: 1px solid #b1b1b1;
        }

        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-left: 98.3%;
            margin-top: -1.9%;
            border-radius: 90px 90px 90px 90px;
        }

        modalPopup {
            background-color: #FFFFFF;
            /*border-width:1px;*/
            border-style: solid;
            border-color: #CCCCCC;
            width: 1042px;
            Height: 555px;
            margin-left: 0%;
            margin-top: 0%;
            /*padding:1px;            
            display:none;*/
        }

        Gridpnl {
            width: 1038px;
            Height: 560px;
        }

        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        .hide {
            display: none;
        }

        .MRDropdown {
            width: 14%;
            float: left;
            margin: 0px 0.5% 0px 0%;
        }

        #logix_CPH_popup_Grd_foregroundElement {
            left: 0px !important;
            top: 33px !important;
        }

        .TDS3 {
            width: 17.7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FormGroupContent4 label {
            display: inline-block;
            margin: 2px 6px 0px 4px;
            vertical-align: top;
        }

        .fileUpload {
            position: relative;
            overflow: hidden;
            display: block;
            width: 97%;
            /*height:21px;*/
            height: 20px;
            border: 1px solid #999997;
            background-color: blue;
            background: #D0D0C9;
            background: -moz-linear-gradient(top, #D0D0C9 0%, #D0D0C9 44%, #D0D0C9 100%);
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#D0D0C9), color-stop(44%,#D0D0C9), color-stop(100%,#D0D0C9));
            background: -webkit-linear-gradient(top, #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
            background: -o-linear-gradient(top, #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
            background: -ms-linear-gradient(top, #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
            background: linear-gradient(top, #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
            font-size: small;
            display: inline;
            /*position: absolute;*/
            /*overflow: hidden;*/
            cursor: pointer;
            -webkit-appearance: push-button;
            margin-top: 0.1%;
            /*margin-top:3%;*/
            margin-left: 1%;
            margin-bottom: 0%;
            /*margin-top :1%;*/
            text-align: center;
        }

            .fileUpload input.upload {
                position: absolute;
                top: 0px;
                margin: 0px 0 0 0;
                padding: 0;
                font-size: 13px;
                cursor: pointer;
                opacity: 0;
                filter: alpha(opacity=4);
                left: 0px;
                width: 304px;
            }

        .logoimg {
            height: 106px;
            width: 97%;
            margin-left: 1%;
            color: aliceblue;
            /*float:right;*/
            left: 10%;
            /*margin-top:-11.5%;*/
            /*margin-top:1%;*/
            margin-top: 0%;
            margin-right: 1%;
        }

        div.file_upload {
            /*width: 10.5%;*/
            width: 110px;
            height: 18px;
            /*background: #D0D0C9;*/
            background-color: aliceblue;
            /*background: -moz-linear-gradient(top,  #D0D0C9 0%, #D0D0C9 44%, #D0D0C9 100%);
background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#D0D0C9), color-stop(44%,#D0D0C9), color-stop(100%,#D0D0C9));
background: -webkit-linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
background: -o-linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
background: -ms-linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
background: linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);*/
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#D0D0C9', endColorstr='#D0D0C9',GradientType=0 );
            font-size: small;
            display: inline;
            position: absolute;
            overflow: hidden;
            cursor: pointer;
            margin-top: 0.1%;
            /*margin-left:0.9%;*/
            /*margin-bottom:3%;*/
            /*-webkit-border-top-right-radius: 5px;
-webkit-border-bottom-right-radius: 5px;
-moz-border-radius-topright: 5px;
-moz-border-radius-bottomright: 5px;
border-top-right-radius: 5px;
border-bottom-right-radius: 5px;*/
            font-weight: bold;
            /*color: Black;*/
            text-align: center;
            padding-top: 3px;
            padding-bottom: 0.2%;
        }

            div.file_upload:before {
                content: 'UPLOAD';
                color: Black;
                margin-bottom: 3%;
                position: absolute;
                left: 0;
                right: 0;
                text-align: center;
                cursor: pointer;
            }

            div.file_upload input {
                position: relative;
                height: 30px;
                width: 100%;
                display: inline;
                cursor: pointer;
                opacity: 0;
                top: 0px;
                left: 0px;
            }

        .Mobile1 {
            width: 30.5%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .Email1 {
            width: 42.7%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .STD1.divllstd {
            width: 7.5%;
        }

        .GST_ddl_2 {
            margin: 0px 0.5% 0px 0px;
            width: 23%;
        }



        .FixedHeader1 th {
            position: sticky;
            top: -1px;
        }



            .FixedHeader1 th:nth-child(3) {
                width: 300px !important;
                max-width: 300px;
            }

        .FixedHeader1 td:nth-child(3) {
            text-overflow: ellipsis;
            overflow: hidden;
            white-space: nowrap;
            width: 300px !important;
            max-width: 300px;
            display: inline-block;
            border-top: 0px solid #b1b1b1;
            border-right: 0px solid #b1b1b1 !important;
            border-left: 0px solid #b1b1b1;
            border-bottom: 1px solid #b1b1b1 !important;
            margin: 0px 0px 0px 0px;
        }

        .BankName {
            float: left;
            width: 25%;
            margin: 0px 0.5% 0px 0px;
        }

        .BankName {
            float: left;
            width: 100% !important;
            margin: -13px 0.5% 0px 0px !important;
        }

        .right {
            float: right;
            width: 49.5%;
        }

        .AccountNumber {
            float: left;
            width: 50%;
            margin: 0px 0.5% 0px 0px;
        }



        .IFSCCode {
            float: left;
            width: 50%;
            margin: 0px 0.5% 0px 0px;
        }

        .btns {
            width: 10%;
            float: left;
            margin: 18px 0.5% 0px 0px;
        }

        .AccountType .chzn-drop {
            top: -180px !important;
            border-radius: 5px;
            border: 1px solid #b1b1b1;
        }

        .btn-save {
            z-index: 2;
            border-radius: 0px;
            margin: 0px 0.5% 0px 0px;
            float: left;
        }

        .lbl_btn {
            width: 100%;
        }

        .btns {
            display: flex;
            margin: 0px 0.5% 0px 0px;
            margin-top: 15px;
            float: right;
            margin-right: -255px;
        }

        .UIN_input {
            width: 100%;
        }


        span#logix_CPH_card {
            white-space: nowrap;
            color: black;
            margin: 0px 0px 0px 15px;
        }

        .FixedHeader th {
            position: sticky;
            top: -1px;
        }




        .customer_inputSP {
            width: 38%;
        }

        .State_code_input {
            width: 100%;
            float: left;
        }

        .GST_ddl_3 {
            width: 24%;
        }

        .Bank_name_input, .IFSC_code_input, .Account_number_input {
            float: left;
            width: 100%;
        }

        .GSTIN {
            width: 29%;
            margin: 0px 0.5% 0px 0px;
        }

        .State_code {
            float: left;
            width: 24%;
            margin: 0 0% 0 0;
        }

        .cin_input {
            width: 100%;
        }

        .panel_12 {
            height: 265px !important;
        }

        .Branch_input {
            width: 100%;
            margin-right: 0.5%;
        }

        .GST_ddl_01 {
            width: 33%;
            margin: 0 0.5% 0 0;
        }

        .UIN {
            margin-right: 0.5%;
        }

        .TxtExemptions {
            width: 15% !important;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .DayPerAnnual {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .OvedueInput {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VolumeTypeInput input {
            text-align: right;
        }

        .Exemption {
            width: 27%;
        }



        .panel_08 {
            height: 186px !important;
        }

        .left_btn {
            display: flex;
        }

        .Gridpnl {
            width: 99% !important;
            height: auto !important;
            border: 1px solid var(--lightgrey) !important;
            margin: 0 auto !important;
            overflow: hidden !important;
        }

        div#logix_CPH_plblan {
            margin: -10px 0px 15px 605px;
            float: left;
        }

        .CustomerName12 {
            position: relative;
            float: left;
            margin: -10px 0.5% 0px 0px;
            z-index: 9999;
        }

        span.headingName {
            font-weight: bold !important;
        }

        .CustomerName12 span, div#logix_CPH_plblan span {
            font-size: 13px;
        }

        span#logix_CPH_lblpanno {
            font-weight: normal !important;
        }
        /*.modalPopup {
    position: fixed !important;*/
        /* background-color: rgba(0, 0, 0, 0.75) !important; */
        /*background-color: white !important;
    width: 100% !important;
    height: 71% !important;
    margin-left: 0% !important;
    margin-top: 29px !important;
    border: 1px solid var(--lightgrey) !important;
    display: flex;
    justify-content: center;
    align-items: center;
    top: 0px !important;
}
        .divRoated {
    width: 99% !important;
    height: 100% !important;
    overflow: hidden !important;
    background: var(--white);
    border-radius: 3px;
    margin: 0px !important;
}*/
    </style>
    <script type="text/javascript">
        function ShowpImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    //  $('#img_flag').attr('src', e.target.result);
                    $('#<%= Img_Emp.ClientID %>').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }


        function ShowpImagePreview1(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    //  $('#img_flag').attr('src', e.target.result);
                    $('#<%= Img_Emp1.ClientID %>').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
        function ShowpImagePreview2(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    //  $('#img_flag').attr('src', e.target.result);
                    $('#<%= Img_Emp2.ClientID %>').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
        function ShowpImagePreview3(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    //  $('#img_flag').attr('src', e.target.result);
                    $('#<%= Img_Emp3.ClientID %>').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
        function ShowpImagePreview4(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    //  $('#img_flag').attr('src', e.target.result);
                    $('#<%= Img_Emp4.ClientID %>').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }

    </script>

    <script type="text/javascript">

        function validateAddress() {
            var TCode = document.getElementById('address').value;

            if (/[^a-zA-Z0-9\-\/]/.test(TCode)) {
                alertify.alert('Input is not alphanumeric');
                return false;
            }

            return true;
        }


        function pageLoad(sender, args) {

<%--            $(document).ready(function () {
                debugger;
                $("#<%=txtUpload.ClientID%>").click(function (result) {

                    $("#<%=FileUpd_logo5.ClientID%>").click();

                          $("#logix_CPH_FileUpd_logo5")[0].files[0];
                         var File = $("#logix_CPH_FileUpd_logo5")[0].files[0].name;
                         $("#<%=txtUpload.ClientID%>").val(File);                                    
                });              
                $("#<%=btnBack.ClientID%>").click(function () {

                    $("#<%=txtUpload.ClientID%>").val(null);
                });;

            });--%>

            $(document).ready(function () {
                $("#<%=txtlocation.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "MasterCustomernew.aspx/GetLocation",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        address: item.split('~')[2]
                                    }
                                }))

                            },

                            error: function (response) {

                            },
                            failure: function (response) {

                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txtlocation.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        // $("#<%=txtcity.ClientID %>").val(i.item.address);
                        $("#<%=txtlocation.ClientID %>").change();
                        $("#<%=hf_locationid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtlocation.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        // $("#<%=txtcity.ClientID %>").val(i.item.address);
                        $("#<%=hf_locationid.ClientID %>").val(i.item.val);
                        // $("#<%=txtlocation.ClientID %>").val($.trim(result));

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtlocation.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            //  $("#<%=txtcity.ClientID %>").val(i.item.address);
                            $("#<%=hf_locationid.ClientID %>").val(i.item.val);
                            // $("#<%=txtlocation.ClientID %>").change();
                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtlocation.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtlocation.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });



            $(document).ready(function () {
                $("#<%= txtPanNo.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_pan.ClientID %>").val(0);
                        $.ajax({
                            url: "MasterCustomernew.aspx/Getlikepanno",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        add: item.split('~')[2]
                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                // alertify.alert(response.responseText);
                            }


                        });
                    },
                    select: function (event, i) {
                        $("#<%=txtPanNo.ClientID %>").val(i.item.label);
                        $("#<%=txtPanNo.ClientID %>").change();


                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtPanNo.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hid_pan.ClientID %>").val(i.item.val);

                        }
                    },

                    focus: function (event, i) {
                        $("#<%=txtPanNo.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));

                        $("#<%=hid_pan.ClientID %>").val(i.item.val);
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtPanNo.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtPanNo.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });


            $(document).ready(function () {
                $("#<%= txtcustomer.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_customerid.ClientID %>").val(0);
                        //  var data= $("#<%=ddlfacategory.ClientID%>").val();// new 
                        $.ajax({
                            url: "MasterCustomernew.aspx/GetCustomer",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        add: item.split('~')[2]
                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                // alertify.alert(response.responseText);
                            }


                        });
                    },
                    select: function (event, i) {
                        $("#<%=txtcustomer.ClientID %>").val(i.item.label);
                        $("#<%=txtcustomer.ClientID %>").change();


                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtcustomer.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hf_customerid.ClientID %>").val(i.item.val);

                        }
                    },

                    focus: function (event, i) {
                        $("#<%=txtcustomer.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));

                        $("#<%=hf_customerid.ClientID %>").val(i.item.val);
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtcustomer.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtcustomer.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%= txtpancust.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_customerid.ClientID %>").val(0);
                        $.ajax({
                            url: "MasterCustomernew.aspx/GetCustomer",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        add: item.split('~')[2]
                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                // alertify.alert(response.responseText);
                            }


                        });
                    },
                    select: function (event, i) {
                        $("#<%=txtpancust.ClientID %>").val(i.item.label);
                        $("#<%=txtpancust.ClientID %>").change();


                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtpancust.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hf_customerid.ClientID %>").val(i.item.val);

                        }
                    },

                    focus: function (event, i) {
                        $("#<%=txtpancust.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));

                        $("#<%=hf_customerid.ClientID %>").val(i.item.val);
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtpancust.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtpancust.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });


            $(document).ready(function () {
                $("#<%=txtcity  .ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "MasterCustomernew.aspx/GetPortName",
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
                        $("#<%=txtcity.ClientID %>").val(i.item.label);
                        $("#<%=txtcity.ClientID %>").change();
                        $("#<%=hf_portid .ClientID %>").val(i.item.val);


                    },
                    focus: function (event, i) {
                        $("#<%=txtcity.ClientID %>").val(i.item.label);
                        $("#<%=hf_portid.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtcity.ClientID %>").val(i.item.label);
                        $("#<%=hf_portid.ClientID %>").val(i.item.val);

                    },
                    minLength: 1
                });
            });



            $(document).ready(function () {
                $("#<%=txtbankid.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "MasterCustomernew.aspx/GetBankNameDetails",
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
                        $("#<%=txtbankid.ClientID %>").val(i.item.label);
                        $("#<%=txtbankid.ClientID %>").change();
                    },
                    focus: function (event, i) {
                        $("#<%=txtbankid.ClientID %>").val(i.item.label);
                        $("#<%=hid_bankid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtbankid.ClientID %>").val(i.item.label);
                        $("#<%=hid_bankid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });







            $(document).ready(function () {
                $("#<%=txtpincode .ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "MasterCustomernew.aspx/GetPincode",
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
                        $("#<%=txtpincode .ClientID %>").val(i.item.value);
                        $("#<%=txtpincode.ClientID %>").change();
                        $("#<%=hdf_pinlocation .ClientID %>").val(i.item.val);

                    },
                    change: function (event, i) {
                        $("#<%=txtpincode.ClientID %>").val(i.item.value);

                    },
                    focus: function (event, i) {
                        $("#<%=txtpincode.ClientID %>").val(i.item.value);
                        $("#<%=hdf_pinlocation .ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtpincode .ClientID %>").val(i.item.value);
                        $("#<%=hdf_pinlocation .ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            //kalai



<%--            $(document).ready(function () {
                $("#<%=txt_Salesperson.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_employeeid.ClientID %>").val(0);
                        $.ajax({
                            url: "Customer_List.aspx/GetEmployeename",
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
                                alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                alertify.alert(response.responseText);
                            }


                        });
                    },

                    select: function (e, i) {
                        $("#<%=hf_employeeid.ClientID %>").val(i.item.val);
                        $("#<%=txt_Salesperson.ClientID %>").change();
                    },

                    focus: function (event, i) {
                        $("#<%=txt_Salesperson.ClientID %>").val(i.item.value);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_Salesperson.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_Salesperson.ClientID %>").val($.trim(result));

                    },

                    minLength: 1
                });
            });--%>



            $(document).ready(function () {
                $("#<%= txt_Salesperson.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_employeeid.ClientID %>").val(0);
                        debugger;;
                        $.ajax({
                            url: "MasterCustomernew.aspx/GetEmployeenames",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        add: item.split('~')[2]
                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                // alertify.alert(response.responseText);
                            }


                        });
                    },
                    select: function (event, i) {
                        $("#<%=txt_Salesperson.ClientID %>").val(i.item.label);
                        $("#<%=txt_Salesperson.ClientID %>").change();


                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_Salesperson.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hf_employeeid.ClientID %>").val(i.item.val);

                        }
                    },

                    focus: function (event, i) {
                        $("#<%=txt_Salesperson.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));

                        $("#<%=hf_employeeid.ClientID %>").val(i.item.val);
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_Salesperson.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txt_Salesperson.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });







            //Elengo
            $(document).ready(function () {
                $("#<%= txt_gstin.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_customerid.ClientID %>").val(0);
                        $.ajax({
                            url: "MasterCustomernew.aspx/GetCustomerbygstin",
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
                                // alertify.alert(response.responseText);
                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txt_gstin.ClientID %>").val(i.item.label);
                        $("#<%=txt_gstin.ClientID %>").change();


                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_gstin.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hf_customerid.ClientID %>").val(i.item.val);

                        }
                    },
                    focus: function (event, i) {
                        $("#<%=txt_gstin.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));

                        $("#<%=hf_customerid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        var result = $("#<%=txt_gstin.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txt_gstin.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });


            $(".dropdown img.flag").addClass("flag visibility");

            $(".dropdown dt a").click(function () {
                $(".dropdown dd ul").toggle();
            });

            $(".dropdown dd ul li a").click(function () {
                var text = $(this).html();
                $(".dropdown dt a span").html(text);
                $(".dropdown dd ul").hide();
                $("#result").html("Selected value is: " + getSelectedValue("sample"));
            });

            function getSelectedValue(id) {
                return $("#" + id).find("dt a span.value").html();
            }

            $(document).bind('click', function (e) {
                var $clicked = $(e.target);
                if (!$clicked.parents().hasClass("dropdown"))
                    $(".dropdown dd ul").hide();
            });


            $("#flag Switcher").click(function () {
                $(".dropdown img.flag").toggleClass("flag visibility");
            });
        }

    </script>

    <script type="text/javascript">
        //Function to disable Cntrl key/right click
        function DisableControlKey(e) {
            // Message to display
            var message = "Copy Paste not  allowed";
            // Condition to check mouse right click / Ctrl key press
            if (e.which == 17 || e.button == 2) {
                alertify.alert(message);
                return false;
            }



        }

        function disableSpace() {
            if (event.keyCode == 32) {
                alertify.alert("Space not allowed")
                return false;
            }
        }





        function RestrictCommaSemicolon(e) {
            var theEvent = e || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /[^,;']+$/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) {
                    theEvent.preventDefault();
                }
            }
        }
    </script>

    <style type="text/css">
        #logix_CPH_pln_popup {
            left: 25px !important;
            top: 44px !important;
        }

        modalPopup1 {
            background-color: #FFFFFF;
            /* border-width: 1px; */
            border-style: solid;
            border-color: #CCCCCC;
            width: 100%;
            Height: 555px;
            margin-left: 0%;
            margin-top: 0%;
        }

        input#logix_CPH_txtCreditAboveamt {
            text-align: right;
        }

        input#logix_CPH_txt_creditdays {
            text-align: right;
        }

        .leftdiv {
            width: 50%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .rightdiv {
            width: 49.5%;
            float: left;
        }

        .widget-header {
            display: none;
        }

        div#UpdatePanel1 {
            /* height: 100vh; */
            /* height: 100% !important; */
            overflow-x: hidden !important;
            overflow-y: auto !important;
            /*height: calc(100vh - 100px) !important;*/
        }
    </style>

    <style type="text/css">
        /*.Mandatory input:focus {
                border:1px solid #b1b1b1!important;
            }

             .Mandatory input:visited {
                border:1px solid #b1b1b1!important;
            }*/






        .Mandatory select {
            border: 1px solid #f95700 !important;
        }

        .Mandatory .chzn-container {
            border-radius: 6px;
        }

        .Mandatory .chzn-container-single .chzn-single {
            border: 1px solid #b0aeae !important;
        }

        .State2 {
            width: 5.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Country2 {
            width: 30.4%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .TDS1 {
            width: 3%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }



        .Shipper1 {
            width: 12.8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .tancs {
            width: 12.2%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .cincs {
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ServiceTax {
            width: 7.8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TDS2 {
            width: 17%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Zip1 {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Consignee3 {
            width: 50.4%;
            margin: 0px 0% 0px 0px;
            float: left;
        }



        .District1 {
            width: 43%;
            float: left;
            margin: 0px 0.5% 0px 0px;
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
                padding: 5px 0px 10px 28px;
                background: url(../Theme/assets/img/buttonIcon/log_ic1.png) no-repeat left 0px;
                margin: 0px 0px 2px 10px;
                font-size: 11px;
            }


        modalPopupLog {
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
            font-family: Tahoma;
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
                font-size: 11px;
            }



        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LogHeadJobInput label {
            font-size: 11px;
        }


        .LogHeadJobInput {
            width: auto;
            white-space: nowrap;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 11px;
                margin: 4px 0px 0px 0px;
            }




            .LogHeadJobInput label {
                font-size: 11px;
                font-family: Tahoma;
                color: #4e4e4c;
            }

        logix_CPH_PanelLog {
            top: 155px !important;
        }

        .MGMT2 {
            width: 81.2%;
            float: left;
            margin: 0px 0.5% 0px 79px;
        }

        .MGMT1 {
            width: 81.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Image1Txt {
            width: 12.5%;
            float: left;
            margin: 0px 1.5% 5px 0px;
        }

        .Image1Txt1 {
            width: 12.5%;
            float: left;
            margin: 0px 1.5% 5px 0px;
        }

        .Image1Txt2 {
            width: 12.5%;
            float: left;
            margin: 0px 1.5% 5px 0px;
        }

        .Image1Txt3 {
            width: 12.5%;
            float: left;
            margin: 0px 1.5% 5px 0px;
        }

        .Image1Txt4 {
            width: 12.5%;
            float: left;
            margin: 0px 1.5% 0px 0px;
        }

        .BrowseFileUpload {
            width: 59%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .PDFLeft {
            float: left;
            width: 35%;
            margin: 0px 0.5% 0px 0px;
        }

        .PDFRight {
            float: left;
            width: 64.5%;
            margin: 0px 0px 0px 0px;
        }



        .CustomerTxtBox {
            width: 68%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .CustomerTypetxtBox {
            width: 49.5%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .TitleTxtBox {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .NameTxtBox {
            width: 78%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .MRDropN1 {
            width: 98%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        #logix_CPH_ddl_Option_chzn {
            width: 100% !important;
        }

        .LandLine2 {
            width: 25.3%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ISD1 {
            width: 5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .STD1 {
            width: 9.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Fax1 {
            width: 17.3%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ISD2 {
            width: 7.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_ddlposition_chzn {
            width: 100% !important;
        }

        #logix_CPH_DropDownList5_chzn {
            width: 100% !important;
        }

        .MRDropD {
            width: 19%;
            float: left;
            margin: 0px 1% 0px 0px;
        }

        .BuildingName {
            width: 31.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .UnitsInput1 {
            width: 8.3%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .StreetInput1 {
            width: 50.3%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .Shipper3 {
            width: 38.5%;
            margin: 0px 0.5% 0px 0px;
            float: left;
        }

        .State1 {
            width: 24%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .div_confirm {
            margin-left: 0%;
        }

        .Pnl1 {
            background-color: #fff;
            border-color: #b1b1b1;
            border-style: solid;
            border-width: 1px;
            width: 300px;
            height: 80px;
            margin-right: 0%;
            text-align: center;
        }

        #logix_CPH_Panel_Customer {
            top: 160px !important;
        }

        .ContainerPopupdiv {
            /*height: 241px;
            border-collapse: collapse;
            overflow: auto;*/
            border: 1px solid #b1b1b1;
            margin: 10px 0px 0px 0px;
            width: 1335px;
            background-color: #fff;
        }

        /*POPUP CSS*/
        modalPopup {
            background-color: #FFFFFF;
            /* border-width: 1px; */
            border-style: solid;
            border-color: #CCCCCC;
            /* width: 1062px; */
            width: 98.5%;
            height: 566px;
            margin-left: 1%;
            margin-top: -0.9%;
        }

        .DivSecPanelLog img {
            float: right;
            width: 16px !important;
            height: 16px !important;
        }

        #logix_CPH_Div_NoOf_Customer {
            top: 83px !important;
            left: 13px !important;
        }

        .BookingLabel {
            float: left;
            width: 15%;
            text-align: left;
            font-size: 11px;
            margin: 0.2% .2% 0px 0px;
        }

        .FloatLeftSy {
            float: left;
            width: 69.5%;
            margin: 0px 0px 0px 0px;
            padding: 0px 0.5% 0px 0px;
            border-right: 1px dotted #b1b1b1;
        }

        .FloatRightSy {
            float: right;
            width: 30%;
            margin: 0px 0px 0px 0px;
            padding: 0px 0% 0px 0px;
            border-right: 0px dotted #b1b1b1;
        }

        .STD1n {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        #logix_CPH_ddlTitle_chzn {
            width: 100% !important;
        }

        .TDSLabel {
            font-size: 11px;
            color: brown;
            float: left;
            width: 15%;
            margin: 5px 0px 0px 8px;
        }

        .BillDrop2 .chzn-drop {
            top: -180px !important;
            border-radius: 5px;
            border: 1px solid #b1b1b1;
        }

        .CardLbl {
            font-size: 11px;
            color: brown;
            float: left;
            width: 100%;
            margin-top: 5px;
        }

        .TDSDescription {
            float: left;
            margin: 0px 0.5% 0px 0%;
            width: 34%;
            height: 21px;
        }

        .CusTypeDrop3 {
            float: left;
            margin: 0px 0.5% 0px 0px;
            width: 15.5%;
        }

        .CusDrop1 {
            float: left;
            margin: 0px 0.5% 0px 0px;
            width: 24.5%;
        }

        .CusPerDrop {
            float: left;
            margin: 0px 0.5% 0px 0px;
            width: 24%;
            height: 21px;
        }

        .DISNone {
            display: none;
        }

        .Request1 {
            width: 20%;
            float: left;
            margin: 0px 0px 0px 8px;
        }

        .Request2 {
            width: 60%;
            float: left;
            margin: 10px 0px 0px 8px;
        }

        span#logix_CPH_lblxmlstatus {
            color: #FF3300;
            text-decoration: none;
            font-size: 11px;
        }

        .row {
            margin: 0px 5px 0px -15px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            width: 100%;
        }


        .DivNew_gr2 {
            height: 363px !important;
            float: left;
            margin-top: 1.5%;
            /* Height:100%;*/
            /*width:65%;*/
            /*width:255px;*/
            width: 100%;
            float: left;
            overflow: auto;
            background-color: #F8F8F8;
            -webkit-box-shadow: 8px 8px 8px rgba(0,0,0,.15);
            -moz-box-shadow: 8px 8px 8px rgba(0,0,0,.15);
            box-shadow: 8px 8px 8px rgba(0,0,0,.15);
        }

        .input#logix_CPH_FileUpd_logo5 {
            margin: 0px !important;
            width: 89% !important;
        }

        .gridview1 {
            float: left;
            width: 100%;
            overflow: auto;
            height: 130px;
            margin: 0px;
            border: 1px solid #b1b1b1;
        }



        .CreditRight {
            float: left;
            width: 49.5%;
            margin: 0px;
        }

        #logix_CPH_Book2 {
            height: 113px;
            overflow: auto !important;
            border: 1px solid #b1b1b1;
        }




        .DesiGrid {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
            border: 1px solid #b1b1b1;
        }

            .DesiGrid thead {
                position: relative;
                display: block;
                width: 100%;
                overflow: visible;
            }

            .DesiGrid tbody {
                position: relative;
                display: block; /*seperates the tbody from the header*/
                width: 100%;
                height: 132px;
                overflow-x: hidden;
                overflow-y: auto;
            }

            .DesiGrid th {
                min-width: 45px;
            }

            .DesiGrid td {
                min-width: 45px;
            }


            .DesiGrid th:nth-child(3) {
                min-width: 180px;
            }

            .DesiGrid td:nth-child(3) {
                min-width: 180px;
            }

            .DesiGrid th:nth-child(4) {
                min-width: 200px;
            }

            .DesiGrid td:nth-child(4) {
                min-width: 200px;
            }

            .DesiGrid th:nth-child(5) {
                min-width: 190px;
            }

            .DesiGrid td:nth-child(5) {
                min-width: 190px;
            }

            .DesiGrid th:nth-child(6) {
                min-width: 45px;
            }

            .DesiGrid td:nth-child(6) {
                min-width: 45px;
            }






        .ShipperGrid {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
            border: 1px solid #b1b1b1;
        }

            .ShipperGrid thead {
                position: relative;
                display: block;
                width: 100%;
                overflow: visible;
            }

            .ShipperGrid tbody {
                position: relative;
                display: block; /*seperates the tbody from the header*/
                width: 100%;
                height: 109px;
                overflow-x: hidden;
                overflow-y: auto;
            }

            .ShipperGrid th {
                min-width: 45px;
            }

            .ShipperGrid td {
                min-width: 45px;
            }

            .ShipperGrid th:nth-child(1) {
                min-width: 380px;
            }

            .ShipperGrid td:nth-child(1) {
                min-width: 380px;
            }

            .ShipperGrid th:nth-child(2) {
                min-width: 242px;
            }

            .ShipperGrid td:nth-child(2) {
                min-width: 242px;
            }

        input[type=file] {
            height: 36px;
            padding: 8px;
        }



        .ddlposition {
            margin: 0px 0.5% 0px 0px;
            width: 25%;
        }
        .email {
    float: left;
    width: 25%;
}
    </style>

    <script type="text/javascript">
        function disableBtn(btnID, newText) {
            //initialize to avoid 'Page_IsValid is undefined' JavaScript error
            Page_IsValid = null;
            //check if the page request any validation
            // if yes, check if the page was valid
            if (typeof (Page_ClientValidate) == 'function') {
                Page_ClientValidate();
                //you can pass in the validation group name also
            }
            //variables
            var btn = document.getElementById(btnID);
            var isValidationOk = Page_IsValid;
            /********NEW UPDATE************************************/
            //if not IE then enable the button on unload before redirecting/ rendering
            if (navigator.appName !== 'Microsoft Internet Explorer') {
                EnableOnUnload(btnID, btn.value);
            }
            /***********END UPDATE ****************************/
            // isValidationOk is not null
            if (isValidationOk !== null) {
                //page was valid
                if (isValidationOk) {
                    btn.disabled = true;
                    btn.value = newText;
                    btn.style.background = 'url(~/images/ajax-loader.gif)';
                }
                else {//page was not valid
                    btn.disabled = false;
                }
            }
            else {//the page don't have any validation request
                setTimeout("setImage('" + btnID + "')", 10);
                btn.disabled = true;
                btn.value = newText;
            }
        }

        //set the background image of the button
        function setImage(btnID) {
            var btn = document.getElementById(btnID);
            btn.style.background = 'url(images/Loading.gif)';
        }

        //enable the button and restore the original text value
        function EnableOnUnload(btnID, btnText) {
            window.onunload = function () {
                var btn = document.getElementById(btnID);
                btn.disabled = false;
                btn.value = btnText;
            }
        }
    </script>


    <style type="text/css">
        /*.row {
            height: 641px !important;
        }*/

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .MT23 {
            margin: 23px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            /*color: #000080;*/
            font-size: 11px;
        }

        .FormGroupContent4 label {
            /*color: #000080;*/
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .ChkCoload {
            float: left;
            width: 13.5%;
            margin: 17px 0px 0px;
        }

        .Coload_Remarks {
            float: left;
            width: 25.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .Coloader_Code {
            float: left;
            width: 17.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .upload_pnl {
            width: 70%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .BillDrop2 {
            width: 10% !important;
            float: left;
            margin: 0px 0.5% 0px 0.8%;
        }

        .CreditRight {
            float: left;
            width: 50%;
            margin: 0px 0px 0px 0px;
        }

        div#logix_CPH_Div2 {
            margin: 15px 0px 0px 2px;
        }

        .txtUpload.Mandatory.MT05 {
            width: 90%;
            float: left;
        }

        .btn-add1 {
            z-index: 2;
            border-radius: 0px;
        }

        .btn-save input {
            padding: 5px 0px 6px 28px !important;
        }

        .right {
            float: right;
            width: 49.5%;
        }

        input#logix_CPH_btn_Upload {
            margin: -3px 0px 0px 1px;
        }
    </style>
    <style type="text/css">
        .d-flex {
            display: flex;
            align-items: center;
            flex-wrap: wrap;
        }



        .Left_container {
            width: 100%;
            float: left;
            margin: 8px 0.5% 0px 0px;
        }

        .Right_container {
            width: 100%;
            float: left;
        }

        .FormGroupContent4 {
            margin: 5px 0px 0px 0px;
        }

        span#logix_CPH_Label19 {
            width: 60px;
        }

        span#logix_CPH_Label6 {
            width: 60px;
        }

        .customer_input {
            width: 100%;
        }

            .customer_input SP {
                width: 90%;
            }

        span#logix_CPH_Label20 {
            width: 60px;
        }


        .Tan_input {
            width: 100%;
            margin: 0px 0.5% 0px 0px;
        }

        span#logix_CPH_Label21 {
            width: 50px;
            margin: 0px 0px 0px 0px;
        }



        span#logix_CPH_Label22 {
            width: 40px;
        }

        .email_inputs {
            width: 35.5%;
            margin: 0px 0.5% 0px 0px;
        }


        .Pan_input {
            width: 18%;
            margin: 0px 0.5% 0px 0%;
        }

        .GST_ddl_1 {
            width: 22%;
            margin: 0px 0.5% 0px 0px;
        }

        span#logix_CPH_Label5 {
            width: 60px;
        }



        .GST_input {
            width: 100%;
            margin: 0px 0px 0px 0px;
            float: left;
        }

        span#logix_CPH_customer_label {
            width: 60px;
        }

        .Unit.Mandatory {
            width: 15%;
            margin: 0px 0.5% 0px 0px;
        }

        .Door.Mandatory {
            width: 15.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .Buildingname.Mandatory {
            width: 68.5%;
            margin: 0px 0% 0px 0px;
        }

        .Street.Mandatory {
            width: 49%;
        }

        .City.Mandatory {
            width: 30%;
            margin: 0px 0.5% 0px 0px;
        }

        .pincode.Mandatory {
            width: 14%;
            margin: 0px 0.5% 0px 0px;
        }

        .Location {
            width: 55%;
            margin: 0px 0 0px 0px;
            float: left
        }

        .District {
            width: 30%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .State {
            width: 15.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .Country {
            width: 17%;
            margin: 0px;
        }

        .ISD {
            width: 9.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .STD.divllstd {
            width: 9.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .LandLine {
            width: 20%;
            /* float: left; */
            margin: 0px 0.5% 0px 0px;
        }

        .Fax {
            width: 24.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .Mobile {
            width: 34.5%;
            margin: 0px 0% 0px 0px;
        }

        .Email {
            width: 33%;
        }

        .GST_ddl {
            width: 100%;
        }

        .GSTType {
            width: 31%;
            margin: 0px 0.5% 0px 0px;
        }



        span#logix_CPH_Label3 {
            width: 50px;
        }

        .btn-add input, .btn-view input {
            padding: 7px 0px 6px 28px;
        }

        .btn-cancel input {
            padding: 7px 5px 6px 28px;
        }

        span#logix_CPH_Label17 {
            width: 65px;
        }





        span#logix_CPH_Label45 {
            width: 70px;
        }

        span#logix_CPH_Label37 {
            width: 28px;
            margin-left: 5px;
        }

        span#logix_CPH_Label32 {
            width: 38px;
            margin-left: 5px;
        }

        .ddlposition_input {
            width: 100%;
            margin: 0px 0.5% 0px 0px;
        }

        .ddl_title_input {
            width: 100%;
        }

        .name_inputs {
            width: 100%;
        }

        .Bank {
            margin: 0px 0.5% 0px 0px;
            width: 27%;
        }

        .IFSC_Code {
            width: 20%;
            margin: 0px 0.5% 0px 0px;
        }

        .Accountnumber {
            width: 26%;
            margin: 0px 0.5% 0px 0px;
        }

        .AccountType {
            margin: 0px 0.5% 0px 0px;
            width: 16.5%;
        }

        .btn-add.add_button {
            margin: 19px 0px 0px;
        }

        .pnl_gridview1 {
            height: 208px;
            border: 1px solid #b1b1b1;
        }

        .pnl_GRID_2 {
            height: 120px;
            overflow: auto;
            border: 1px solid #b1b1b1;
        }

        .row {
            height: 570px !important;
        }

        .e_invoice {
            float: left;
            margin: 10px 0px 0px 1%;
        }

        .customer_input1 {
            width: 78%;
            margin: 0px 0.5% 0px 0px;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }

        .ddltitle {
            margin-right: 0.5%;
            width: 10%;
        }

        .Name {
            width: 64%;
        }

        .btn.btn-add1 {
            margin: 14px 0px 0px 0px;
        }

        input#logix_CPH_txt_limit {
            text-align: right !important;
        }

        input#logix_CPH_txt_tds_exp {
            text-align: right !important;
        }

        input#logix_CPH_txtGSTCode {
            text-align: right;
        }

        .MBLchk {
            width: 15.8%;
            float: left;
            margin: 0px;
            max-width: 17%;
        }

        .pantxt {
            width: 18%;
            float: left;
        }

        span.chktext {
            font-weight: 500 !important;
            margin: 11px 0 0 5px !important;
            padding: 0px 0px 4px 0px;
            font-size: 13px !important;
            width: 100%;
        }

        input#logix_CPH_txt_creditday {
            text-align: right;
        }

        .ClientType {
            width: 30.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        div#logix_CPH_ddlProductType_chzn {
            width: 100%;
        }

        .VolumeTypeInput {
            width: 18.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VolumeTypeDrop {
            width: 14%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .RevenueInput {
            width: 18.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .panel_06 {
            height: 147px !important;
        }

        .creditAmt {
            width: 30.5%;
            float: left;
        }

        .creadit {
            float: left;
            width: 16%;
            margin: 0px 0px 0px 0px;
        }

        .panel_07 {
            height: 156px !important;
        }

        div#logix_CPH_Div1.btn.btn-update1 {
            margin: 15px 0px 0px 0px;
        }

        .TextField .chzn-container .chzn-drop {
            top: 45px !important;
            width: 100% !important;
            height: auto !important;
        }

        div#logix_CPH_Div1 {
            margin-left: 8px;
        }

        .CustomerName12 span:nth-child(2) {
            font-weight: normal !important;
        }

        .CustomerName12 span {
            font-size: 13px;
        }

        div#UpdatePanel1 {
            /* height: 100vh; */
            height: 100vh;
            overflow-x: hidden;
            overflow-y: auto;
        }

        .gridpnl {
            height: 534px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <asp:Panel runat="server">

        <!-- Breadcrumbs line End -->
        <div>
            <div class="col-md-12"  class="maindiv">

                <div class="widget box" runat="server" id="div_iframe">
                    <div class="widget-header">
                        <div>
                        <div style="float: left; margin: 0px 0.5% 0px 0px;">
                            <h4 class="hide"><i class="icon-umbrella"></i>
                                <asp:Label ID="lbl_Header" runat="server" Text="Customer New"></asp:Label></h4>

                            <!-- Breadcrumbs line -->
                            <div class="crumbs">
                                <ul id="breadcrumbs" class="breadcrumb">
                                    <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                    <li><a href="#" title="">Maintenance</a> </li>
                                    <li class="current"><a href="#" title="">Customer New</a> </li>
                                </ul>
                            </div>
                        </div>

                        <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm">
                            <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                        </div>
                            </div>




                    </div>
                    <div class="widget-content">
                        <div class="FormGroupContent4 ">
                            <div class="CustomerName12">
                                <span class="headingName">CUSTOMER NAME : </span>
                                <asp:Label ID="LBLcustomername" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div class="panno12" id="plblan" runat="server">
                                <span class="headingName">PAN # : </span>
                                <asp:Label ID="lblpanno" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="bordertopNew" style="float: right; min-height: 1px; width: 100%; box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;"></div>
                        <div class="FormGroupContent4">
                            <div class="Left_container">
                                <div class="FormGroupContent4 hide">
                                    <div class="FormGroupContent4 ">
                                        <div class="FormGroupContent4">
                                            <div class="PanNo d-flex" style="display: none">
                                                <asp:Label ID="Label19" CssClass="hide" runat="server" Text="PAN #"> </asp:Label>
                                                <div class="GST_ddl_2">
                                                    <asp:DropDownList ID="ddlcategory" runat="server" TabIndex="1" Width="100%" CssClass="chzn-select form-control" ToolTip="Category" data-placeholder="Category" AutoPostBack="true" OnTextChanged="ddlcategory_TextChanged">
                                                        <asp:ListItem Value="0" Text=""></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Liner"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Transporters"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Vendors"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="Customer"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="Agent"></asp:ListItem>
                                                        <asp:ListItem Value="6" Text="OtherCountry"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>

                                                <%--<asp:Label ID="Label47" runat="server" CssClass="hide" Text="Type"> </asp:Label>--%>
                                                <div class="GST_ddl_1">
                                                    <asp:DropDownList ID="ddllegaltype" runat="server" TabIndex="2" Width="100%" CssClass="chzn-select form-control" ToolTip="Type" data-placeholder="Type" AutoPostBack="true">
                                                        <asp:ListItem Value="0" Text=""></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Public Limited"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Private Limited"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="LLP"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="Partnership"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="Propreitors"></asp:ListItem>
                                                        <asp:ListItem Value="6" Text="Others"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="Pan_input">
                                                    <asp:TextBox ID="txtPanNo" placeholder="PAN #" ToolTip="PAN #" runat="server" TabIndex="3" CssClass="form-control" OnTextChanged="txtPanNo_TextChanged" onkeyup="CheckTextLength(this,10);" AutoPostBack="true"></asp:TextBox>
                                                </div>

                                                <div class="GST_ddl_3">
                                                    <asp:DropDownList ID="ddlfacategory" runat="server" TabIndex="4" Width="100%" CssClass="chzn-select form-control" ToolTip="FA Category" data-placeholder="FA Category" AutoPostBack="true" OnTextChanged="ddlfacategory_TextChanged">
                                                        <asp:ListItem Value="0" Text=""></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Bill To - Supply To"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Export Consignee"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Import Shipper"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="Agent"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="OtherCountry"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="e_invoice">
                                                    <asp:CheckBox ID="chkeinvoice" runat="server" AutoPostBack="True" />&nbsp;&nbsp;
                          <asp:Label ID="Label47" runat="server" Text="E-Invoice"></asp:Label>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="FormGroupContent4">
                                            <div class="customer Mandatory d-flex">
                                                <asp:Label ID="Label6" runat="server" CssClass="hide" Text="Customer"> </asp:Label>
                                                <div class="customer_input">
                                                    <asp:TextBox ID="txtpancust" ToolTip="Customer" CssClass="form-control" placeholder="Customer" OnTextChanged="txtpancust_TextChanged" runat="server" TabIndex="5" AutoPostBack="True" onkeyup="CheckTextLength(this,200);" onKeyDown="return DisableControlKey(event)" onMouseDown="return DisableControlKey(event)" onkeypress="return RestrictCommaSemicolon(event);"></asp:TextBox>
                                                </div>
                                            </div>


                                            <%--<div class="Salesperson">
                                                <div class="SalesTxtBox">
                           
                                                   
                        </div>
                                        <asp:Label ID="Label48" runat="server" Text="Sales Person"> </asp:Label>
                                        <div class="customer_input">
                                            <asp:TextBox ID="txtsales" ToolTip="Sales Person" CssClass="form-control" placeholder="" runat="server" TabIndex="2" AutoPostBack="True" onkeyup="CheckTextLength(this,200);" onKeyDown="return DisableControlKey(event)" onMouseDown="return DisableControlKey(event)" onkeypress="return RestrictCommaSemicolon(event);"></asp:TextBox>
                                        </div>
                                           </div>--%>
                                        </div>

                                        <div class="FormGroupContent4 d-flex">


                                            <div class="custom-col custom-mr-05">

                                                <asp:TextBox ID="txttanno" placeholder="TAN #" ToolTip="TAN #" runat="server" TabIndex="6" CssClass="form-control" onkeyup="CheckTextLength(this,30);"></asp:TextBox>

                                            </div>

                                            <div class="cincs d-flex custom-col">
                                                <asp:Label ID="Label21" runat="server" CssClass="hide" Text="CIN #"> </asp:Label>
                                                <div class="cin_input">
                                                    <asp:TextBox ID="txtcinno" placeholder="CIN #" ToolTip="CIN #" runat="server" TabIndex="7" CssClass="form-control" onkeyup="CheckTextLength(this,30);"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="UIN d-flex custom-col">
                                                <asp:Label ID="Label22" runat="server" CssClass="hide" Text="UIN#"> </asp:Label>
                                                <div class="UIN_input">
                                                    <asp:TextBox ID="txt_uinno" runat="server" placeholder="UIN #" ToolTip="UIN #" CssClass="form-control" TabIndex="8" AutoPostBack="true" OnTextChanged="txt_uinno_TextChanged" onkeyup="CheckTextLength(this,15);"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="FormGroupContent4">
                                            <asp:Label ID="Label49" runat="server" CssClass="hide" Text="Sales person"> </asp:Label>
                                            <asp:TextBox ID="txt_Salesperson" ToolTip="Sales Person" CssClass="form-control" placeholder="Sales person" runat="server" TabIndex="9" AutoPostBack="True" OnTextChanged="txt_Salesperson_TextChanged"></asp:TextBox>
                                        </div>
                                        <%--onkeyup="CheckTextLength(this,200);" --%><%--onKeyDown="return DisableControlKey(event)" onMouseDown="return DisableControlKey(event)" onkeypress="return RestrictCommaSemicolon(event);"--%>
                                    </div>
                                    <div class="FormGroupContent4  hide">
                                        <div class="CardLbl">
                                            <asp:Label ID="Label54" runat="server">TDS Details </asp:Label>
                                        </div>

                                        <div class="FormGroupContent4">

                                            <div class="TDSDescription">
                                                <asp:Label ID="Label33" runat="server" CssClass="hide" Text="Description"> </asp:Label>
                                                <asp:DropDownList ID="ddl_description" Height="23px" CssClass="chzn-select" TabIndex="47" data-placeholder="Description" ToolTip="Descripttion" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddl_description_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="CusTypeDrop3">
                                                <asp:Label ID="Label34" runat="server" CssClass="hide" Text="Type"> </asp:Label>
                                                <asp:DropDownList ID="ddl_type" runat="server" Height="23px" CssClass="chzn-select" TabIndex="48" data-placeholder="Type" AutoPostBack="True" ToolTip="Type" OnSelectedIndexChanged="ddl_type_SelectedIndexChanged" AppendDataBoundItems="true">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="CusDrop1">
                                                <asp:Label ID="Label35" runat="server" CssClass="hide" Text="Slab"> </asp:Label>
                                                <asp:DropDownList ID="ddl_slab" Height="23px" runat="server" CssClass="chzn-select" TabIndex="49" data-placeholder="Slab" ToolTip="Slab" AutoPostBack="True" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_slab_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="CusPerDrop">
                                                <asp:Label ID="Label36" runat="server" CssClass="hide" Text="Percentage"> </asp:Label>
                                                <asp:DropDownList ID="ddl_percentage" Height="23px" CssClass="chzn-select" TabIndex="50" data-placeholder="Percentage" ToolTip="Percentage" runat="server" AppendDataBoundItems="true">
                                                </asp:DropDownList>
                                            </div>



                                        </div>

                                        <div class="FormGroupContent4">
                                            <div class="Limit">
                                                <asp:Label ID="Label40" runat="server" CssClass="hide" Text="LIMIT"> </asp:Label>
                                                <asp:TextBox ID="txt_limit" runat="server" placeholder="LIMIT" ToolTip="LIMIT" TabIndex="51" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                                            </div>
                                            <div class="empfrom">
                                                <asp:Label ID="Label41" runat="server" CssClass="hide" Text="Exemption From"> </asp:Label>
                                                <asp:TextBox ID="txt_empfrom" runat="server" CssClass="form-control" TabIndex="52" placeholder="Exemption From" ToolTip="Exemption From" AutoPostBack="True"></asp:TextBox>

                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txt_empfrom" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                            </div>
                                            <div class="empto">
                                                <asp:Label ID="Label42" runat="server" CssClass="hide" Text="Exemption To"> </asp:Label>
                                                <asp:TextBox ID="txt_empto" runat="server" CssClass="form-control" TabIndex="53" placeholder="Exemption To" ToolTip="Exemption To" AutoPostBack="True"></asp:TextBox>

                                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txt_empto" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                            </div>

                                            <div class="certno">
                                                <asp:Label ID="Label43" runat="server" CssClass="hide" Text="Certificate #"> </asp:Label>
                                                <asp:TextBox ID="txt_certno" runat="server" placeholder="Certificate #" TabIndex="54" ToolTip="Certificate Number" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                                            </div>

                                            <div class="tds_exp">
                                                <asp:Label ID="Label44" runat="server" CssClass="hide" Text="TDS Exemption"> </asp:Label>
                                                <asp:TextBox ID="txt_tds_exp" runat="server" CssClass="form-control" placeholder="TDS Exemption" TabIndex="55" ToolTip="TDS Exemption" AutoPostBack="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="bordertopNew"></div>
                                    <div class="right_btn">
                                        <div class="btn ico-save" id="btnpanadd1" runat="server">
                                            <asp:Button ID="btnpanadd" runat="server" ToolTip="Save" OnClick="btnpanadd_Click" TabIndex="56" />
                                        </div>

                                        <div class=" btn-view" style="display: none">
                                            <asp:Button runat="server" ToolTip="View" TabIndex="57" />
                                        </div>

                                        <div class="btn ico-cancel" id="btnBack1" runat="server">
                                            <asp:Button ID="btnpancancel" runat="server" ToolTip="Cancel" OnClick="btnpancancel_Click" TabIndex="58" />
                                        </div>

                                    </div>

                                    <div class="bordertopNew"></div>

                                    <div class="FormGroupContent4  hide">

                                        <div class="CardLbl">
                                            <asp:Label ID="Label56" runat="server">Credit Details </asp:Label>
                                        </div>
                                        <div class="FormGroupContent4">
                                            <div class="ClientType">

                                                <asp:Label ID="Label20" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList ID="ddlProductType" runat="server" data-PlaceHolder="ProductType" ToolTip="ProductType" Width="100%" CssClass="chzn-select form-control" TabIndex="41">
                                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                    <%--<asp:ListItem Text="All" Value="1"></asp:ListItem>--%>
                                                    <asp:ListItem Text="Ocean Export-FCL" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Ocean Export-LCL" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Ocean Import-FCL" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="Ocean Import-LCL" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="Air Export" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="Air Import" Value="7"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="VolumeTypeInput">
                                                <asp:Label ID="Label48" runat="server" Text="Expected Volume" CssClass="hide"></asp:Label>
                                                <asp:TextBox ID="txt_vol" runat="server" PlaceHolder="Expected Volume" ToolTip="Expected Volume" CssClass="form-control" Width="100%" TabIndex="42" onkeypress="return validateFloatKeyPress(this,event,'Volume');"></asp:TextBox>
                                            </div>
                                            <div class="VolumeTypeDrop">
                                                <asp:Label ID="Label50" runat="server" Text="Type"></asp:Label>
                                                <asp:DropDownList ID="ddlvolumetype" data-PlaceHolder="Type" ToolTip="Type" runat="server" Width="100%" CssClass="chzn-select" TabIndex="43">
                                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                            <div class="RevenueInput">
                                                <asp:Label ID="Label51" runat="server" Text="Revenue" CssClass="hide"></asp:Label>
                                                <asp:TextBox ID="txt_revenue" runat="server" PlaceHolder="Revenue" ToolTip="Expected Revenue" CssClass="form-control" Width="100%" TabIndex="44" onkeypress="return validateFloatKeyPress(this,event,'Revenue');"></asp:TextBox>
                                            </div>

                                            <div class="creadit custom-mr-05">
                                                <asp:Label ID="Label52" runat="server" Text="Credit Days" CssClass="hide"></asp:Label>
                                                <asp:TextBox ID="txt_creditdays" runat="server" PlaceHolder="Credit Days" ToolTip="Required Credit Days" CssClass="form-control" Width="100%" onkeypress="return isNumberKey(event,'Request Credit Days');" TabIndex="45"></asp:TextBox>
                                            </div>



                                            <div class="CreditDaysInput hide">
                                                <asp:TextBox ID="txt_creditday" runat="server" placeholder="Creditdays" ToolTip="CreditDays" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                                            </div>
                                            <div class="CreditAmountInput hide">
                                                <asp:TextBox ID="txt_creditamount" runat="server" placeholder="CreditAmount" ToolTip="CreditAmount" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                                            </div>


                                            <%--<asp:Panel ID="pnlcreditreq" runat="server" CssClass="panel_13" Visible="true" >--%>
                                            <%--</asp:Panel>--%>
                                            <asp:Label ID="lbl_crmt" runat="server" Style="font-weight: bold!important; color: #b50000!important; text-decoration: none;"></asp:Label>
                                        </div>

                                        <div class=" FormGroupContent4">
                                            <div class="creditAmt custom-mr-05">

                                                <asp:Label ID="Label53" runat="server" Text="Credit Amount" CssClass="hide"></asp:Label>
                                                <asp:TextBox ID="txtCreditAboveamt" runat="server" PlaceHolder="Credit Amount" ToolTip="Required Credit Amount" CssClass="form-control" Width="100%" onkeypress="return validateFloatKeyPress(this,event,'Currency');" TabIndex="46"></asp:TextBox>
                                            </div>
                                            <div class="custom-d-flex">
                                                <div class="Exemption custom-mr-05">
                                                    <asp:TextBox ID="txt_exemptions" runat="server" ToolTip="No. of Exemptions" AutoPostBack="true" Style="text-align: right;" placeholder="No. of Exemptions" CssClass="form-control"></asp:TextBox>

                                                </div>

                                                <div class="custom-col custom-mr-05 ">
                                                    <asp:DropDownList ID="ddl_per" runat="server" ToolTip="Per" data-placeholder="Per" Width="100%" CssClass="chzn-select" BorderColor="#999997">
                                                        <asp:ListItem Text=""></asp:ListItem>
                                                        <asp:ListItem Text="Annual"></asp:ListItem>
                                                        <asp:ListItem Text="Month"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="custom-col ">
                                                    <asp:TextBox ID="txt_overdue" Width="100%" runat="server" ToolTip="Allowed Overdue" Style="text-align: right;" placeholder="Allowed Overdue %" CssClass="form-control" OnTextChanged="txt_overdue_TextChanged"></asp:TextBox>
                                                </div>
                                                <div class="btn ico-add" id="Div1" runat="server">
                                                    <asp:Button ID="btnCreditRequestAdd" runat="server" ToolTip="ADD" TabIndex="47" OnClick="btnCreditRequestAdd_Click" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="FormGroupContent4">
                                            <div class="panel_06" id="pnlcreditreq" runat="server" visible="true">
                                                <asp:GridView ID="Gridcreditreq" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false"
                                                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="20" ShowHeaderWhenEmpty="True" Visible="true"
                                                    BackColor="White" OnSelectedIndexChanged="Gridcreditreq_SelectedIndexChanged" OnRowDataBound="Gridcreditreq_RowDataBound">
                                                    <Columns>

                                                        <asp:BoundField DataField="Customer" HeaderText="Customer" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                        <asp:BoundField DataField="Product" HeaderText="Product" ItemStyle-Width="300px" HeaderStyle-Width="300px" />
                                                        <asp:BoundField DataField="Volume" HeaderText="Expected Volume" />
                                                        <asp:BoundField DataField="VolumeType" HeaderText="Expected Volume Type" />
                                                        <asp:BoundField DataField="Revenue" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" />
                                                        <asp:BoundField DataField="Creditdays" HeaderText="Credit Days" ItemStyle-CssClass="TxtAlign1" />
                                                        <asp:BoundField DataField="CreditAmount" HeaderText="Credit Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" />
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="Imgsb" runat="server" CausesValidation="false" CommandName="Delete"
                                                                    ImageUrl="~/images/delete.jpg" Height="16px" OnClick="Imgsb_Click" />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="crid" HeaderText="crid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                    </Columns>
                                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                    <HeaderStyle CssClass="myGridHeader" />
                                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                                    <PagerStyle CssClass="GridviewScrollPager" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="FormGroupContent4">
                                    <div class="FormGroupContent4 d-flex">
                                        <div class="GST_ddl_01 hide">
                                            <asp:DropDownList ID="ddl_branch" runat="server" Width="100%" CssClass="chzn-select form-control" ToolTip="Credit" data-placeholder="FA Category" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                        <asp:Label ID="lblcreditdays" runat="server" CssClass="hide" Text="CreditDays"> </asp:Label>
                                        <asp:Label ID="lbl_creditamount" runat="server" CssClass="hide" Text="CreditAmount"> </asp:Label>
                                    </div>
                                </div>


                                <div class="FormGroupContent4 hide">

                                    <div class="FormGroupContent4 ">
                                        <div class="CardLbl">
                                            <asp:Label ID="Label46" runat="server">Contact Details </asp:Label>
                                            <asp:Label ID="card" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="FormGroupContent4 d-flex">
                                        <div class="ddlposition Mandatory d-flex">
                                            <asp:Label ID="Label45" runat="server" CssClass="hide" Text="Department"> </asp:Label>

                                            <div class="ddlposition_input">
                                                <asp:DropDownList ID="ddlposition" data-placeholder="Department" runat="server" TabIndex="29" Width="100%" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlposition_SelectedIndexChanged">
                                                    <asp:ListItem Value="">Department</asp:ListItem>
                                                    <asp:ListItem Value="MH">MANAGEMENT</asp:ListItem>
                                                    <asp:ListItem Value="CH">COMMERCIAL</asp:ListItem>
                                                    <asp:ListItem Value="EH">EXPORT</asp:ListItem>
                                                    <asp:ListItem Value="IH">IMPORT</asp:ListItem>
                                                    <asp:ListItem Value="FH">FINANCE</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="ddltitle d-flex" style="margin-right: 0.5%;">
                                            <asp:Label ID="Label37" runat="server" CssClass="hide" Text="Title"> </asp:Label>

                                            <div class="ddl_title_input">
                                                <asp:DropDownList ID="ddlTitle" runat="server" data-placeholder="Title" TabIndex="30" Width="100%" CssClass="chzn-select">
                                                    <asp:ListItem>Mr</asp:ListItem>
                                                    <asp:ListItem>Ms</asp:ListItem>
                                                    <asp:ListItem>Mrs</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                        </div>

                                        <div class="Name Mandatory d-flex">
                                            <asp:Label ID="Label32" runat="server" CssClass="hide" Text="Name"> </asp:Label>
                                            <div class="name_inputs">
                                                <asp:TextBox ID="txtName" placeholder="Name" ToolTip="Name" runat="server" TabIndex="31" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="FormGroupContent4 d-flex">
                                        <asp:Label ID="lbl_email" runat="server" CssClass="hide" Text="Email"> </asp:Label>
                                        <div class="email_inputs">
                                            <asp:TextBox ID="txt_email" placeholder="Email" ToolTip="Email" runat="server" TabIndex="31" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="BrowseFileUpload">
                                            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
                                                <ContentTemplate>
                                                    <span style="display: block; color: #fff; background-color: #5ba701; color: black; width: 121px; font-size: 11px; padding: 0px 0px 0px 0px;"></span>
                                                    <asp:FileUpload ID="FileUpd_logo5" CssClass="bt" runat="server" onchange="ShowpImagePreview(this);" ToolTip="Upload Business Card" />
                                                    <div class="div_btn">
                                                        <asp:Button ID="Button6" runat="server" Text="Upload" Width="100%" CssClass="Button" Visible="false" />
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="btnSave" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="right_btn d-flex">
                                            <div class="btn ico-add">
                                                <asp:Button ID="btn_Upload" runat="server" ToolTip="Add" TabIndex="32" OnClick="btn_Upload_Click" />
                                            </div>
                                            <div class="btn ico-view" style="display: none">
                                                <asp:Button runat="server" ToolTip="View" TabIndex="33" />
                                            </div>
                                            <%-- <div class="btn ico-cancel">
                                            <asp:Button runat="server" ToolTip="Cancel" TabIndex="34" />
                                        </div>--%>
                                        </div>

                                    </div>


                                    <div class="FormGroupContent4">
                                        <div class="panel_05 MB0">

                                            <asp:GridView ID="grdBusinesscard" runat="server" Width="100%" ShowHeaderWhenEmpty="True" CssClass="Grid FixedHeader" AutoGenerateColumns="false"
                                                OnRowDataBound="grdBusinesscard_RowDataBound" OnSelectedIndexChanged="grdBusinesscard_SelectedIndexChanged" EmptyDataText="No Record Found"
                                                OnRowCommand="grdBusinesscard_RowCommand" OnRowDeleting="grdBusinesscard_RowDeleting" OnPreRender="grdBusinesscard_PreRender">
                                                <Columns>
                                                    <asp:BoundField DataField="MCUploadinfo" HeaderText="MCUploadinfo" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:BoundField>
                                                    <%-- 0 --%>
                                                    <asp:BoundField DataField="CustomerId" HeaderText="CustomerId" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:BoundField>
                                                    <%-- 1 --%>
                                                    <asp:BoundField DataField="Role" HeaderText="DESIGNATION">
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:BoundField>
                                                    <%-- 2 --%>
                                                    <asp:BoundField DataField="Name" HeaderText="NAME">
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="email" HeaderText="E-mail">
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:BoundField>
                                                    <%-- 3 --%>
                                                    <asp:BoundField DataField="CardFileName" HeaderText="BUSINESSCARD">
                                                        <HeaderStyle Wrap="false" />
                                                        <ItemStyle Wrap="false" />
                                                    </asp:BoundField>
                                                    <%-- 4 --%>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Img_Delete" runat="server" CommandName="Delete" ImageUrl="~/images/delete.jpg" OnClientClick="return confirm('Are you sure you want delete');" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="false" HorizontalAlign="right" Width="20px" />
                                                        <ItemStyle Font-Bold="false" Width="20px" HorizontalAlign="Justify" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="" Wrap="false" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                                <RowStyle Font-Italic="False" />
                                            </asp:GridView>
                                        </div>

                                    </div>
                                </div>


                                <div class="Right_container">

                                    <div class="FormGroupContent4 ">
                                        <div class="FormGroupContent4">
                                            <div class="leftdiv">

                                                <div class="FormGroupContent4" style="display: flex">
                                                    <div class="GSTType">
                                                        <asp:Label ID="Label5" runat="server" CssClass="hide" Text="GST Type"> </asp:Label>
                                                        <div class="GST_ddl">
                                                            <asp:DropDownList ID="ddl_Option" runat="server" TabIndex="22" Width="100%" CssClass="chzn-select form-control" ToolTip="GST Type" data-placeholder="GST Type" AutoPostBack="true" OnTextChanged="ddl_Option_TextChanged">
                                                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="">GST Exemption</asp:ListItem>
                                                                <asp:ListItem Value="1" Text="">RCM</asp:ListItem>
                                                                <asp:ListItem Value="5" Text="">Registered</asp:ListItem>
                                                                <asp:ListItem Value="4" Text="">SEZ</asp:ListItem>
                                                                <asp:ListItem Value="6" Text="">SEZ Exemption</asp:ListItem>
                                                                <asp:ListItem Value="2" Text="">UnRegistered</asp:ListItem>
                                                                <asp:ListItem Value="7" Text="">Not Applicable</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="MBLchk">
                                                        <span class="chktext">USD Invoice</span>
                                                        <center>
                                                            <label class="switch">
                                                                <asp:CheckBox ID="chkusd" runat="server" AutoPostBack="true" TabIndex="2" />

                                                            </label>
                                                        </center>

                                                    </div>
                                                    <div class="pantxt">

                                                        <span class="chktext">PAN Required</span>
                                                        <center>
                                                            <label class="switch">
                                                                <asp:CheckBox ID="chkPAN" runat="server" TabIndex="3" />

                                                            </label>
                                                        </center>

                                                    </div>
                                                </div>
                                                <div class="FormGroupContent4">





                                                    <div class="GSTIN ">
                                                        <asp:Label ID="Label3" runat="server" CssClass="hide" Text="GSTIN"> </asp:Label>
                                                        <div class="GST_input">
                                                            <asp:TextBox ID="txt_gstin" runat="server" placeholder="GSTIN" ToolTip="GSTIN" TabIndex="23" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_gstin_TextChanged" onkeyup="CheckTextLength(this,15);"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="State_code ">
                                                        <asp:Label ID="Label17" runat="server" CssClass="hide" Text="State Code"> </asp:Label>
                                                        <div class="State_code_input">
                                                            <asp:TextBox ID="txtGSTCode" runat="server" placeholder="State Code" CssClass="form-control" ToolTip="State Code" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="FormGroupContent4 d-flex">
                                                    <div class="Unit Mandatory">
                                                        <asp:Label ID="Label7" runat="server" CssClass="hide" Text="Unit #"> </asp:Label>
                                                        <asp:TextBox ID="txtunit" runat="server" ToolTip="Unit #" CssClass="form-control" placeholder="Unit #" TabIndex="25" onkeyup="CheckTextLength(this,10);"></asp:TextBox>
                                                    </div>

                                                    <div class="Door Mandatory">
                                                        <asp:Label ID="Label9" runat="server" CssClass="hide" Text="Door #"> </asp:Label>
                                                        <asp:TextBox ID="txtdoor" runat="server" ToolTip="Door#" placeholder="Door #" CssClass="form-control" TabIndex="26" onkeyup="CheckTextLength(this,10);"></asp:TextBox>
                                                    </div>

                                                    <div class="Buildingname Mandatory">
                                                        <asp:Label ID="Label10" runat="server" CssClass="hide" Text="BuildingName"> </asp:Label>
                                                        <asp:TextBox ID="txtbuildingname" ToolTip="BuildingName" CssClass="form-control" placeholder="BuildingName" runat="server" TabIndex="27" onkeyup="CheckTextLength(this,50);"></asp:TextBox>
                                                    </div>



                                                </div>
                                                <div class=" FormGroupContent4 ">
                                                    <asp:Label ID="Label11" runat="server" CssClass="hide" Text="Street"> </asp:Label>
                                                    <asp:TextBox ID="txtstreet" ToolTip="Street" placeholder="Street" runat="server" CssClass="form-control" TabIndex="28" onkeyup="CheckTextLength(this,100);"></asp:TextBox>
                                                </div>
                                                <div class="FormGroupContent4 d-flex">
                                                    <div class="City Mandatory">
                                                        <asp:Label ID="Label12" runat="server" CssClass="hide" Text="City"> </asp:Label>
                                                        <asp:TextBox ID="txtcity" runat="server" placeholder="City" ToolTip="City" CssClass="form-control" TabIndex="29" AutoPostBack="True" OnTextChanged="txtcity_TextChanged"></asp:TextBox>
                                                    </div>

                                                    <div class="pincode Mandatory">
                                                        <asp:Label ID="Label13" runat="server" CssClass="hide" Text="Pincode"> </asp:Label>
                                                        <asp:TextBox ID="txtpincode" runat="server" AutoPostBack="true" BorderColor="#999997" CssClass="form-control" TabIndex="30" placeholder="PIN /ZIP " ToolTip="Pincode" OnTextChanged="txtpincode_TextChanged"></asp:TextBox>
                                                    </div>
                                                    <div class="Location">
                                                        <asp:Label ID="Label14" runat="server" CssClass="hide" Text="Location"> </asp:Label>
                                                        <asp:TextBox ID="txtlocation" runat="server" CssClass="form-control" placeholder="Location" ToolTip="Location"
                                                            AutoPostBack="True" TabIndex="18" OnTextChanged="txtlocation_TextChanged1" onkeyup="CheckTextLength(this,60);"></asp:TextBox>
                                                        <asp:DropDownList ID="ddllocation" runat="server" ToolTip="Location" Data-Placeholder="Location" AutoPostBack="true" CssClass="chzn-select" Visible="false" Width="100%" OnSelectedIndexChanged="ddllocation_SelectedIndexChanged">
                                                            <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                </div>

                                                <div class="FormGroupContent4">
                                                    <div class=" District">
                                                        <asp:Label ID="Label15" runat="server" CssClass="hide" Text="District"> </asp:Label>
                                                        <asp:TextBox ID="txtdistrict" runat="server" placeholder="District" CssClass="form-control" ToolTip="District" Enabled="False"></asp:TextBox>
                                                    </div>

                                          


                                                    <div class="custom-col custom-mr-05" style="float: left;" >
                                                        <asp:Label ID="Label16" runat="server" CssClass="hide" Text="State"> </asp:Label>
                                                        <asp:TextBox ID="txtstate" runat="server" placeholder="State" CssClass="form-control" ToolTip="State" Enabled="False"></asp:TextBox>
                                                    </div>

                                                    <div class="custom-col" style="float: left;">
                                                        <asp:Label ID="Label18" runat="server" CssClass="hide" Text="Country"> </asp:Label>
                                                        <asp:TextBox ID="txtcountry" runat="server" placeholder="Country" ToolTip="Country" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                    </div>

                                                </div>

                                                <div class="FormGroupContent4 d-flex">
                                                    <div class="ISD">
                                                        <asp:Label ID="Label24" runat="server" CssClass="hide" Text="ISD"> </asp:Label>
                                                        <asp:TextBox ID="txtllisd" runat="server" placeholder="ISD" CssClass="form-control" TabIndex="31" ToolTip="ISD" Enabled="true" OnTextChanged="txtllisd_TextChanged"></asp:TextBox>
                                                    </div>

                                                    <div class="STD divllstd">
                                                        <asp:Label ID="Label25" runat="server" CssClass="hide" Text="STD"> </asp:Label>
                                                        <asp:TextBox ID="txtllstd" runat="server" placeholder="STD" CssClass="form-control" ToolTip="STD" TabIndex="32" Enabled="False" AutoPostBack="true" OnTextChanged="txtllstd_TextChanged"></asp:TextBox>
                                                    </div>

                                                    <div class="LandLine">
                                                        <asp:Label ID="Label26" runat="server" CssClass="hide" Text="Landline"> </asp:Label>
                                                        <asp:TextBox ID="txtlandline" CssClass="form-control" placeholder="Landline" ToolTip="Landline" runat="server" TabIndex="33" onkeyup="CheckTextLength(this,10);" onkeypress="return isNumberKey (event)"></asp:TextBox>
                                                    </div>

                                                    <div class="Fax hide">
                                                        <asp:Label ID="Label29" runat="server" CssClass="hide" Text="Fax"> </asp:Label>
                                                        <asp:TextBox ID="txtfax" placeholder="Fax" CssClass="form-control" ToolTip="Fax" runat="server" TabIndex="34" onkeypress="return isNumberKey (event)"></asp:TextBox>
                                                    </div>
                                                    <div class="Mobile">
                                                        <asp:Label ID="Label31" runat="server" CssClass="hide" Text="Mobile"> </asp:Label>
                                                        <asp:TextBox ID="txtMobile" placeholder="Mobile" CssClass="form-control" ToolTip="Mobile" runat="server" TabIndex="35" onkeyup="CheckTextLength(this,10);" onkeypress="return isNumberKey (event)"></asp:TextBox>
                                                    </div>
                                                    <div>
                                                        

                                                    <asp:Label ID="Label23" runat="server" CssClass="hide" Text="Email"> </asp:Label>
                                                    <asp:TextBox ID="txtemail" placeholder="Email" CssClass="form-control" ToolTip="eMail" runat="server" TabIndex="36" OnTextChanged="txtemail_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                              
                                                <%--  <div class="bordertopNew"></div>--%>
                                                <div class="FormGroupContent4 ">

                                                    <div class="left_btn ">


                                                        <div class="left_btn hide">
                                                            <div class=" btn-add1">
                                                                <asp:Button ID="btn_mastercustomerdetails" runat="server" Text="Customer" ToolTip="Customer" TabIndex="38" OnClick="btn_mastercustomerdetails_Click" />
                                                            </div>
                                                            <div class=" btn-add1">
                                                                <asp:Button ID="btntds" runat="server" Text="TDS" ToolTip="TDS" TabIndex="38" OnClick="btntds_Click" />
                                                            </div>

                                                            <div class="btn-add1">
                                                                <asp:Button ID="btncredit" runat="server" Text="CREDIT" ToolTip="CREDIT" TabIndex="39" OnClick="btncredit_Click" />
                                                            </div>

                                                            <div class=" btn-add1">
                                                                <asp:Button ID="btn_kyc" runat="server" Text="KYC" ToolTip="KYC" TabIndex="38" OnClick="btn_kyc_Click" />
                                                            </div>

                                                            <div class="btn-add1">
                                                                <asp:Button ID="btn_bank" runat="server" Text="BANK" ToolTip="BANK" TabIndex="39" OnClick="btn_bank_Click" />
                                                            </div>

                                                            <div class=" btn-add1">
                                                                <asp:Button ID="btn_contact" runat="server" Text="CONTACT" ToolTip="CONTACT" TabIndex="38" OnClick="btn_contact_Click" />
                                                            </div>

                                                        </div>
                                                    </div>

                                                    <div class="right_btn custom-d-flex">

                                                        <div class="btn ico-save" id="btnSave1" runat="server">
                                                            <asp:Button ID="btnSave" runat="server" ToolTip="Save" OnClick="btnSave_Click" TabIndex="37" OnClientClick="disableBtn(this.id, 'Loading...')" UseSubmitBehavior="False" />
                                                        </div>

                                                        <div class="btn ico-view">
                                                            <asp:Button ID="btncustview" runat="server" Text="View" ToolTip="View" TabIndex="38" OnClick="btncustview_Click" />
                                                        </div>

                                                        <div class="btn ico-cancel">
                                                            <asp:Button ID="btnBack" runat="server" Text="Cancel" ToolTip="Cancel" TabIndex="39" OnClick="btnBack_Click" />
                                                        </div>

                                                    </div>
                                                </div>

                                            </div>
                                            <div class="rightdiv">
                                                <div class="FormGroupContent4 ">
                                                    <div class="gridpnl">

                                                        <asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True"
                                                            EmptyDataText="No Record Found" EnableTheming="False" OnSelectedIndexChanged="grd_SelectedIndexChanged" OnRowDataBound="grd_RowDataBound">
                                                            <Columns>
                                                                <asp:BoundField DataField="sno" HeaderText="S.No" />
                                                                <asp:BoundField DataField="gstin" HeaderText="GSTIN" />
                                                                <asp:BoundField DataField="address" HeaderText="Customer Address" />
                                                                <asp:BoundField DataField="city" HeaderText="City" />
                                                                <asp:BoundField DataField="customerid" HeaderText="customerid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                                <%--<asp:BoundField DataField="sno" HeaderText="S.No" />
                                                <asp:BoundField DataField="customername" HeaderText="Customer Name" />
                                                <asp:BoundField DataField="unit#" HeaderText="Unit#" />
                                                <asp:BoundField DataField="buildingname" HeaderText="Building Name " />

                                                <asp:BoundField DataField="street" HeaderText="Street " />
                                                <asp:BoundField DataField="locationname" HeaderText="Location" />
                                                <asp:BoundField DataField="portname" HeaderText="City" />
                                                <asp:BoundField DataField="districtname" HeaderText="District" />
                                                <asp:BoundField DataField="statename" HeaderText="State" />
                                                <asp:BoundField DataField="countryname" HeaderText="Country" />
                                                <asp:BoundField DataField="pincode" HeaderText="Pincode" />
                                                <asp:BoundField DataField="mobile" HeaderText="Mobile" />
                                                <asp:BoundField DataField="email" HeaderText="E Mail" />
                                                <asp:BoundField DataField="custtype" HeaderText="Customer Type" />--%>
                                                            </Columns>
                                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                            <HeaderStyle CssClass="" />
                                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                                            <RowStyle CssClass="GrdRow" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="FormGroupContent4 ">

                                            <div class="FormGroupContent4">

                                                <div class="FormGroupContent4">
                                                    <div class="customer Mandatory d-flex">
                                                        <div class=" FormGroupContent4">
                                                            <asp:Label ID="customer_label" runat="server" CssClass="hide" Text="Customer"> </asp:Label>
                                                            <asp:TextBox ID="txtcustomer" ToolTip="Customer" CssClass="form-control" placeholder="Customer" runat="server" Enabled="false" TabIndex="24" AutoPostBack="True" OnTextChanged="txtcustomer_TextChanged" onkeyup="CheckTextLength(this,200);" onKeyDown="return DisableControlKey(event)" onMouseDown="return DisableControlKey(event)" onkeypress="return RestrictCommaSemicolon(event);" Visible="false"></asp:TextBox>
                                                        </div>


                                                    </div>

                                                    <%--  <div class="customer Mandatory d-flex">
                                        <asp:Label ID="Label49" runat="server" Text="Sales person"> </asp:Label>
                                        <div class="customer_input SP">
                                            <asp:TextBox ID="TextBox2" ToolTip="Sales Person" CssClass="form-control" placeholder="" runat="server"  TabIndex="11" AutoPostBack="True" OnTextChanged="txtcustomer_TextChanged" onkeyup="CheckTextLength(this,200);" onKeyDown="return DisableControlKey(event)" onMouseDown="return DisableControlKey(event)" onkeypress="return RestrictCommaSemicolon(event);"></asp:TextBox>
                                        </div>
                                    </div>--%>
                                                </div>
                                            </div>
                                            <div class="FormGroupContent4">
                                            </div>
                                        </div>


                                        <div class="FormGroupContent4  hide">
                                            <div class="CardLbl">
                                                <asp:Label ID="Label58" runat="server">KYC Details </asp:Label>
                                            </div>
                                            <div class="FormGroupContent4">
                                                <div class="BillDrop">
                                                    <asp:Label Text="KYC Details" ID="lbl_KYC" CssClass="hide" runat="server"></asp:Label>
                                                    <asp:DropDownList ID="ddlIDProof" runat="server" AppendDataBoundItems="True" TabIndex="40" CssClass=" form-control chzn-select"
                                                        ToolTip="KYC Details" data-placeholder="KYC Details">
                                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>

                                                <div class="upload_pnl">
                                                    <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Always" runat="server">
                                                        <ContentTemplate>
                                                            <span style="display: block; color: #fff; background-color: #5ba701; color: black; width: 121px; font-size: 11px; padding: 0px 0px 0px 0px;"></span>
                                                            <asp:FileUpload ID="KycUpload" CssClass="bt" runat="server" />
                                                            <div class="div_btn">
                                                                <asp:Button ID="Button7" runat="server" Text="Upload" Width="100%" CssClass="Button" Visible="false" />
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btnkyc" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>

                                                <div class="btn ico-upload" id="Div2" runat="server">
                                                    <asp:Button ID="btnkyc" runat="server" ToolTip="KYC Update" OnClick="btnkyc_Click" TabIndex="41" />
                                                    <asp:GridView ID="GridView11" CssClass="FixedHeader" runat="server">
                                                    </asp:GridView>
                                                </div>
                                            </div>

                                            <div class="FormGroupContent4">
                                                <div id="Pl_Proof" runat="server" class="panel_05 MB0">
                                                    <asp:GridView ID="GrdProofkyc" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="True"
                                                        EmptyDataText="No Record Found" OnSelectedIndexChanged="GrdProof_SelectedIndexChanged" Visible="true" OnRowDataBound="GrdProof_RowDataBound"
                                                        OnRowCommand="GrdProofkyc_RowCommand" OnRowDeleting="GrdProofkyc_RowDeleting">

                                                        <Columns>
                                                            <asp:BoundField DataField="proof" HeaderText="KYC Proof" />
                                                            <asp:BoundField DataField="filename" HeaderText="FileName" />
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="Img_Delete" runat="server" CommandName="Delete" ImageUrl="~/images/delete.jpg" OnClientClick="return confirm('Are you sure you want delete');" />
                                                                </ItemTemplate>
                                                                <HeaderStyle Wrap="false" HorizontalAlign="right" Width="20px" />
                                                                <ItemStyle Font-Bold="false" Width="20px" HorizontalAlign="Justify" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                        <HeaderStyle CssClass="" />
                                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                                        <RowStyle CssClass="GrdRow" />
                                                    </asp:GridView>
                                                </div>
                                                <div class="CreditRight" style="display: none;">
                                                    <asp:Panel ID="Book2" runat="server" Visible="true">
                                                        <asp:GridView ID="test" runat="server" CssClass="Grid FixedHeader" Width="100%" OnRowDataBound="test_RowDataBound" OnPreRender="test_PreRender">
                                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                            <HeaderStyle CssClass="" />
                                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                                            <RowStyle Font-Italic="False" />
                                                        </asp:GridView>
                                                        <div class="div_Break"></div>
                                                    </asp:Panel>
                                                </div>


                                                <div class="FormGroupContent4 hide">
                                                    <div class="lbl_btn">

                                                        <div class="btns">
                                                            <div class="btn-save">
                                                                <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" ToolTip="Save" />
                                                            </div>
                                                            <div class="btn-cancel">
                                                                <asp:Button ID="btnCancel" runat="server" ToolTip="Cancel" />
                                                                <%-- OnClick="btnCancel_Click" --%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>



                                            </div>
                                        </div>
                                        <div class="FormGroupContent4  hide">
                                            <div class="CardLbl">
                                                <asp:Label ID="Label59" runat="server">Bank Details </asp:Label>

                                            </div>
                                            <div class="FormGroupContent4 d-flex">
                                                <div class="Bank">
                                                    <asp:Label ID="lblbankname" runat="server" CssClass="hide" Text="Bank"> </asp:Label>
                                                    <div class="Bank_name_input">
                                                        <asp:TextBox ID="txtbankid" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="Bank" ToolTip="Bank Name" TabIndex="42" onkeypress="return disableSpace()"></asp:TextBox>

                                                    </div>
                                                </div>

                                                <div class="IFSC_Code ">
                                                    <asp:Label ID="lblifsc" runat="server" CssClass="hide" Text="IFSC Code"> </asp:Label>
                                                    <div class="IFSC_code_input">
                                                        <asp:TextBox ID="txtifsc" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="IFSC Code" ToolTip="IFSC Code" TabIndex="43" onkeypress="return disableSpace()"></asp:TextBox>

                                                    </div>
                                                </div>

                                                <div class="Accountnumber ">
                                                    <asp:Label ID="lblaccountno" runat="server" CssClass="hide" Text="Account #"> </asp:Label>
                                                    <div class="Account_number_input">
                                                        <asp:TextBox ID="txtaccountno" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="Account #" ToolTip="Account Number" TabIndex="44" OnTextChanged="txtaccountno_TextChanged" onkeypress="return disableSpace()"></asp:TextBox>

                                                    </div>

                                                </div>

                                                <div class="AccountType ">
                                                    <asp:Label ID="lblaccount" runat="server" CssClass="hide" Text="Type"> </asp:Label>
                                                    <%-- <asp:TextBox ID="txtaccount" runat="server" CssClass="form-control" AutoPostBack="True" Visible="false" placeholder="" ToolTip="Branch " Text='<%#Bind("txtaccount")%>'></asp:TextBox>--%>

                                                    <div class="Account_type_input">
                                                        <asp:DropDownList ID="DropDownList5" runat="server" Height="23" CssClass="chzn-select"
                                                            ToolTip="Account Type" data-placeholder="Account Type" Width="100%" AutoPostBack="true" TabIndex="45" AppendDataBoundItems="False">

                                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                                            <asp:ListItem Text="CURRENT" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="SAVINGS" Value="2"></asp:ListItem>

                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                                <%-- <div class="btn-add add_button">
                                        <asp:Button runat="server" ToolTip="Add" />
                                    </div>--%>
                                                <div class="btns">
                                                    <div class="btn-add">
                                                        <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" ToolTip="Save" TabIndex="46" />
                                                    </div>
                                                    <div class="btn-cancel">
                                                        <asp:Button ID="btnbankcancel" runat="server" OnClick="btnbankcancel_Click" ToolTip="Cancel" TabIndex="47" />
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="FormGroupContent4">
                                                <asp:Panel runat="server" class="panel_05 MB0">

                                                    <asp:GridView ID="GridView1" CssClass="Grid FixedHeader" runat="server" Visible="true" AutoGenerateColumns="false" EmptyDataText="No Record Found"
                                                        ShowHeaderWhenEmpty="true" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" OnPreRender="GridView1_PreRender">
                                                        <Columns>

                                                            <asp:BoundField DataField="Customerid" HeaderText="CUSTOMERID" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                            <asp:BoundField DataField="Bankid" HeaderText="BANKID" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                            <%--  <asp:BoundField DataField="Portid" HeaderText="PORTID"  ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"  />--%>
                                                            <asp:BoundField DataField="CustomerName" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" HeaderText="CUSTOMER NAME" Visible="false" />
                                                            <asp:BoundField DataField="LedgerName" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" HeaderText="LEDGER NAME" Visible="false" />
                                                            <asp:BoundField DataField="Address" HeaderText="Address" Visible="false" />
                                                            <asp:BoundField DataField="BankName" HeaderText="BANK NAME" />
                                                            <%-- <asp:BoundField DataField="Branch" HeaderText="BRANCH" />--%>
                                                            <asp:BoundField DataField="AccountNumber" HeaderText="ACCOUNT NUMBER" />
                                                            <asp:BoundField DataField="Account" HeaderText="ACCOUNT TYPE" />

                                                            <asp:BoundField DataField="IFSCCode" HeaderText="IFSC CODE" />
                                                            <asp:BoundField DataField="gstin" HeaderText="GST #" />
                                                            <%-- <asp:BoundField DataField="SWIFTCode" HeaderText="SWIFTCODE" />--%>
                                                        </Columns>

                                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                        <HeaderStyle CssClass="" />
                                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                                        <RowStyle CssClass="GrdRow" />

                                                    </asp:GridView>
                                                </asp:Panel>


                                            </div>
                                        </div>


                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="FloatLeftSy hide">
                            <div class="ForoGroupContent4">
                                <div class="BookingLabel">
                                    <asp:LinkButton ID="lnkCustomer" runat="server" OnClick="lnkCustomer_Click">Customer List</asp:LinkButton>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="CustomerTypetxtBox" style="display: none;">
                                    <asp:DropDownList ID="ddlCType" CssClass="chzn-select" runat="server" data-placeholder="CUSTOMER TYPE" TabIndex="4" Enabled="false">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="CHA / Shipper / Consignee / Notify Party / Carrier / Airliner/ MLO / Freight Forwarder / Warehouse / Transporter / Others" Value="C"></asp:ListItem>
                                        <asp:ListItem Text="Agent / Principal / Counter Part" Value="P"></asp:ListItem>
                                        <asp:ListItem Text="Depo" Value="W"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                            </div>
                            <div class="FormGroupContent4">
                                <div class="ServiceTax" style="display: none;">
                                    <asp:TextBox ID="txtServiceTaxNo" placeholder="Service Tax#" ToolTip="Service Tax#" runat="server" TabIndex="19" CssClass="form-control" onkeyup="CheckTextLength(this,25);"></asp:TextBox>

                                </div>
                                <div class="TDS1" style="display: none;">
                                    <asp:TextBox ID="txttds" runat="server" placeholder="TDS" ToolTip="TDS" CssClass="form-control" TabIndex="20" onkeypress="return isNumberKey (event)" onkeyup="CheckTextLength(this,2);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4 hide">
                                <div class="ISD2">
                                    <asp:Label ID="Label27" runat="server" Text="ISD"> </asp:Label>
                                    <asp:TextBox ID="txtfaxisd" runat="server" placeholder="" CssClass="form-control" ToolTip="ISD" Enabled="False"></asp:TextBox>
                                </div>
                                <div class="STD1">
                                    <asp:Label ID="Label28" runat="server" Text="STD"> </asp:Label>
                                    <asp:TextBox ID="txtfaxstd" runat="server" placeholder="" CssClass="form-control" ToolTip="STD" Enabled="false"></asp:TextBox>
                                </div>

                                <div class="ISD1">
                                    <asp:Label ID="Label30" runat="server" Text="ISD"> </asp:Label>
                                    <asp:TextBox ID="txtmblisd" placeholder="" ToolTip="ISD" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4" style="display: none">
                                <div class="ChkCoload">
                                    <asp:CheckBox ID="ChkCoload" runat="server" OnCheckedChanged="ChkCoload_CheckedChanged" AutoPostBack="true" /><label>ISCoload</label>
                                </div>
                                <div class="Coload_Remarks">
                                    <asp:Label ID="Label38" runat="server" Text="Coload Remarks"> </asp:Label>
                                    <asp:TextBox ID="txt_ColoadRemarks" placeholder="" CssClass="form-control" ToolTip="Coload Remarks" runat="server"></asp:TextBox>
                                </div>
                                <div class="Coloader_Code">
                                    <asp:Label ID="Label39" runat="server" Text="Supplier/Coloader Code"> </asp:Label>
                                    <asp:TextBox ID="txt_Coloadercode" placeholder="" CssClass="form-control" ToolTip="Coloader Code" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="FloatRightSy hide">
                        <div class="FormGroupContent4 ">
                        </div>
                        <div class="FormGroupContent4 ">
                        </div>
                    </div>
                    <%-- Elengo --%>
                    <div class="Clear"></div>

                    <div class="FormGroupContent4 hide">
                        <div class="TDSLabel">
                            <asp:Label ID="lbltds" runat="server"> TDS Details</asp:Label>
                        </div>
                    </div>

                    <div class="FormGroupContent4 ">



                        <div class="right_btn" style="display: none">
                            <asp:CheckBox ID="txt_RCM" runat="server" /><label>RCM</label>
                            <asp:CheckBox ID="txt_unregistered" runat="server" /><label>UnRegistered</label>
                            <asp:CheckBox ID="txt_gstexi" runat="server" /><label>GST Exemption</label>

                        </div>
                    </div>


                    <div class="PDFLeft" style="display: none;">

                        <div class="FormGroupContent4">
                            <div class="MRDropN1">
                                <asp:DropDownList ID="ddl_MR" runat="server" TabIndex="22" Width="100%" CssClass="chzn-select">
                                    <asp:ListItem>Mr</asp:ListItem>
                                    <asp:ListItem>Ms</asp:ListItem>
                                    <asp:ListItem>Mrs</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="MGMT1">
                                <asp:TextBox ID="txtmanagptc" runat="server" placeholder="MANAGEMENT HEAD NAME" ToolTip="MANAGEMENT HEAD NAME" CssClass="form-control" TabIndex="23"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="MGMT2">
                                <asp:TextBox ID="txtmailmanag" runat="server" placeholder="MANAGEMENT HEAD MAIL ID" ToolTip="MANAGEMENT HEAD MAIL ID" CssClass="form-control " TabIndex="24" AutoPostBack="true" OnTextChanged="txtmailmanag_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="MRDropN1">
                                <asp:DropDownList ID="DropDownList1" runat="server" TabIndex="24" Width="100%" CssClass="chzn-select">
                                    <asp:ListItem>Mr</asp:ListItem>
                                    <asp:ListItem>Ms</asp:ListItem>
                                    <asp:ListItem>Mrs</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                            <div class="MGMT1">
                                <asp:TextBox ID="txtcomptc" runat="server" placeholder="COMMERCIAL HEAD NAME" ToolTip="COMMERCIAL HEAD NAME" CssClass="form-control " TabIndex="25" AutoPostBack="true"></asp:TextBox>
                            </div>

                        </div>
                        <div class="FormGroupContent4">

                            <div class="MGMT2">
                                <asp:TextBox ID="txtmailcom" runat="server" placeholder="COMMERCIAL HEAD MAIL ID" ToolTip="COMMERCIAL HEAD MAIL ID" CssClass="form-control " TabIndex="26" AutoPostBack="true" OnTextChanged="txtmailcom_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="MRDropN1">
                                <asp:DropDownList ID="DropDownList2" runat="server" TabIndex="27" Width="100%" CssClass="chzn-select">
                                    <asp:ListItem>Mr</asp:ListItem>
                                    <asp:ListItem>Ms</asp:ListItem>
                                    <asp:ListItem>Mrs</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="MGMT1">
                                <asp:TextBox ID="txtexpptc" runat="server" placeholder="EXPORT HEAD NAME" ToolTip="EXPORT HEAD NAME" CssClass="form-control" AutoPostBack="true" TabIndex="28"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="MGMT2">
                                <asp:TextBox ID="txtmailexport" runat="server" placeholder="EXPORT HEAD MAIL ID" ToolTip="EXPORT HEAD MAIL ID" CssClass="form-control" TabIndex="29" AutoPostBack="true" OnTextChanged="txtmailexport_TextChanged"></asp:TextBox>
                            </div>

                        </div>
                        <div class="FormGroupContent4">

                            <div class="MRDropN1">
                                <asp:DropDownList ID="DropDownList3" runat="server" TabIndex="30" Width="100%" CssClass="chzn-select">
                                    <asp:ListItem>Mr</asp:ListItem>
                                    <asp:ListItem>Ms</asp:ListItem>
                                    <asp:ListItem>Mrs</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="MGMT1">
                                <asp:TextBox ID="txtimpptc" runat="server" placeholder="IMPORT HEAD NAME" ToolTip="IMPORT HEAD NAME" CssClass="form-control" AutoPostBack="true" TabIndex="31"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="MGMT2">
                                <asp:TextBox ID="txtmailimp" runat="server" placeholder="IMPORT HEAD MAIL ID" ToolTip="IMPORT HEAD MAIL ID" CssClass="form-control" AutoPostBack="true" TabIndex="32" OnTextChanged="txtmailimp_TextChanged"></asp:TextBox>
                            </div>


                        </div>
                        <div class="FormGroupContent4">
                            <div class="MRDropN1">
                                <asp:DropDownList ID="DropDownList4" runat="server" TabIndex="33" Width="100%" CssClass="chzn-select">
                                    <asp:ListItem>Mr</asp:ListItem>
                                    <asp:ListItem>Ms</asp:ListItem>
                                    <asp:ListItem>Mrs</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="MGMT1">
                                <asp:TextBox ID="txtfinptc" runat="server" Width="100%" placeholder="FINANCIAL HEAD NAME" ToolTip="FINANCIAL HEAD NAME" CssClass="form-control" TabIndex="34" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="MGMT2">
                                <asp:TextBox ID="txtmailfin" runat="server" placeholder="FINANCIAL HEAD MAIL ID" Width="100%" ToolTip="FINANCIAL HEAD MAIL ID" CssClass="form-control" TabIndex="35" AutoPostBack="true" OnTextChanged="txtmailfin_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="PDFRight" style="display: none;">
                        <div class="FormGroupContent4">
                            <%--    <div class="logoimg">
                             <asp:Image ID="ImgLogo" runat="server"  ToolTip="IMAGE"  Height="116px" Width="108px" placeholder="IMAGE"/>      </div>
                              <div class="FileUpload4 fileUpload">
                          <  <span style=" margin-top :0%; display :block; color:#fff; background-color:#5ba701; color:black; width:121px; font-size:12px; padding:0px 0px 0px 0px; height:25px;">UPLOAD</span>
                           <asp:FileUpload ID="FileUpd_logo" runat="server" TabIndex="35" class="upload" onchange="ShowpImagePreview(this);" />
                                  <div class="div_btn">
                                                <asp:Button ID="Button1" runat="server" Text="Upload" Width="5%" CssClass="Button" Visible="false" />
                                            </div>
                       </div>--%>
                            <div class="Image1Txt">
                                <asp:Image ID="Img_Emp" runat="server" Height="46px" Width="108px" BorderStyle="Solid" BorderWidth="1px" ImageUrl="~/images/visitingcard_img.jpg" />
                            </div>
                            <div class="BrowseFileUpload">
                                <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Always" runat="server">
                                    <ContentTemplate>
                                        <span style="display: block; color: #fff; background-color: #5ba701; color: black; width: 121px; font-size: 11px; padding: 0px 0px 0px 0px;"></span>
                                        <asp:FileUpload ID="FileUpd_logo" CssClass="bt" runat="server" onchange="ShowpImagePreview(this);" />
                                        <div class="div_btn">
                                            <asp:Button ID="Button1" runat="server" Text="Upload" Width="100%" CssClass="Button" Visible="false" />
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnSave" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>






                            <%--<div class="BrowseFileUpload" >
                                    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always"  runat="server" >
                                        <ContentTemplate>
                                                                                 
                                          
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnSave" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>--%>
                        </div>

                        <div class="FormGroupContent4">

                            <div class="Image1Txt1">

                                <asp:Image ID="Img_Emp1" runat="server" Height="46px" Width="108px" BorderStyle="Solid" BorderWidth="1px" ImageUrl="~/images/visitingcard_img.jpg" />
                            </div>
                            <div class="BrowseFileUpload">
                                <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Always" runat="server">
                                    <ContentTemplate>
                                        <span style="display: block; color: #fff; background-color: #5ba701; color: black; width: 121px; font-size: 11px; padding: 0px 0px 0px 0px;"></span>
                                        <asp:FileUpload ID="FileUpd_logo1" CssClass="bt" runat="server" onchange="ShowpImagePreview1(this);" />
                                        <div class="div_btn">
                                            <asp:Button ID="Button2" runat="server" Text="Upload" Width="100%" CssClass="Button" Visible="false" />
                                        </div>

                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnSave" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                        <div class="FormGroupContent4">
                            <div class="Image1Txt2">

                                <asp:Image ID="Img_Emp2" runat="server" Height="46px" Width="108px" BorderStyle="Solid" BorderWidth="1px" ImageUrl="~/images/visitingcard_img.jpg" />
                            </div>
                            <div class="BrowseFileUpload">
                                <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Always" runat="server">
                                    <ContentTemplate>
                                        <span style="display: block; color: #fff; background-color: #5ba701; color: black; width: 121px; font-size: 11px; padding: 0px 0px 0px 0px;"></span>
                                        <asp:FileUpload ID="FileUpd_logo2" CssClass="bt" runat="server" onchange="ShowpImagePreview2(this);" />
                                        <div class="div_btn">
                                            <asp:Button ID="Button3" runat="server" Text="Upload" Width="100%" CssClass="Button" Visible="false" />
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnSave" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                        <div class="FormGroupContent4">
                            <div class="Image1Txt3">
                                <asp:Image ID="Img_Emp3" runat="server" Height="46px" Width="108px" BorderStyle="Solid" BorderWidth="1px" ImageUrl="~/images/visitingcard_img.jpg" />
                            </div>

                            <div class="BrowseFileUpload">
                                <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Always" runat="server">
                                    <ContentTemplate>

                                        <span style="display: block; color: #fff; background-color: #5ba701; color: black; width: 121px; font-size: 11px; padding: 0px 0px 0px 0px;"></span>
                                        <asp:FileUpload ID="FileUpd_logo3" CssClass="bt" runat="server" onchange="ShowpImagePreview3(this);" />
                                        <div class="div_btn">
                                            <asp:Button ID="Button4" runat="server" Text="Upload" Width="100%" CssClass="Button" Visible="false" />
                                        </div>

                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnSave" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>


                        <div class="FormGroupContent4">
                            <div class="Image1Txt4">
                                <asp:Image ID="Img_Emp4" runat="server" Height="46px" Width="108px" BorderStyle="Solid" BorderWidth="1px" ImageUrl="~/images/visitingcard_img.jpg" />
                            </div>
                            <div class="BrowseFileUpload">
                                <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Always" runat="server">
                                    <ContentTemplate>
                                        <span style="display: block; color: #fff; background-color: #5ba701; color: black; width: 121px; font-size: 11px; padding: 0px 0px 0px 0px;"></span>
                                        <asp:FileUpload ID="FileUpd_logo4" CssClass="bt" runat="server" onchange="ShowpImagePreview4(this);" />
                                        <div class="div_btn">
                                            <asp:Button ID="Button5" runat="server" Text="Upload" Width="100%" CssClass="Button" Visible="false" />
                                        </div>

                                    </ContentTemplate>

                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnSave" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>


                    <div class="FormGroupContent4 hide">
                        <div class="Request1" style="display: none">
                            <asp:LinkButton ID="lnk_RCL" runat="server" ForeColor="#FF3300" TabIndex="36" Style="text-decoration: none" OnClick="lnk_RCL_Click">Request Customer List</asp:LinkButton>
                        </div>
                        <div class="div_Break"></div>
                        <div class="Request2">
                            <asp:Label ID="lblxmlstatus" runat="server" Text="XML Upload Status : "></asp:Label>
                        </div>

                        <div class="right_btn">
                            <%--<div class="btn ico-save" id="btnSave1" runat="server">
                                <asp:Button ID="btnSave" runat="server" ToolTip="Save" OnClick="btnSave_Click" TabIndex="37" OnClientClick="disableBtn(this.id, 'Loading...')" UseSubmitBehavior="False" />
                            </div>--%>
                            <div class="btn btn-pending1" id="btndelete1" runat="server">
                                <asp:Button ID="btndelete" runat="server" ToolTip="Reject" TabIndex="38" OnClick="btndelete_Click" />
                            </div>
                            <div class="btn ico-view">
                                <asp:Button ID="btnview" runat="server" ToolTip="View" TabIndex="39" OnClick="btnview_Click1" />
                                <div class="btn ico-send">
                                    <asp:Button ID="btn_xml" runat="server" ToolTip="XML"
                                        OnClick="btn_xml_Click" />
                                </div>
                            </div>
                            <%--<div class="btn ico-cancel" id="btnBack1" runat="server">
                                <asp:Button ID="btnBack" runat="server" ToolTip="Cancel" TabIndex="40" OnClick="btnBack_Click" />
                            </div>--%>
                        </div>
                    </div>








                    <div class="FormGroupContent4 hide ">
                        <asp:ListBox ID="lstlocation" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstlocation_SelectedIndexChanged"></asp:ListBox>
                    </div>
                    <div class="FormGroupContent4">
                        <%--DataKeyNames="districtid,stateid,countryid,portid,locationid,customerid"--%>
                    </div>
                    <div class="FormGroupContent4">

                        <asp:Panel ID="pln_popup" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                            <div class="divRoated">
                                <div class="DivSecPanel">
                                    <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                </div>

                                <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">


                                    <asp:GridView ID="Grd_Job" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="true" ShowHeaderWhenEmpty="true"
                                        ForeColor="Black" EmptyDataText="No Record Found" PageSize="26" BackColor="White" OnRowDataBound="Grd_Job_RowDataBound" OnPageIndexChanging="Grd_Job_PageIndexChanging" OnSelectedIndexChanged="Grd_Job_SelectedIndexChanged">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Customer Name">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Customer Type">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                        <asp:Label ID="customertype" runat="server" Text='<%# Bind("customertype") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="61px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Address">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                        <asp:Label ID="address" runat="server" Text='<%# Bind("address") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="61px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="City">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                                        <asp:Label ID="portname" runat="server" Text='<%# Bind("portname") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="61px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:BoundField ControlStyle-CssClass="hide" HeaderText="CustomerId" DataField="customerid">
                                                <HeaderStyle Wrap="false" Width="250px" CssClass="hide" HorizontalAlign="Center" />
                                                <ItemStyle Font-Bold="false" HorizontalAlign="Justify" CssClass="hide" Width="250px" />
                                            </asp:BoundField>

                                            <%-- <asp:TemplateField HeaderText ="Job">
                <ItemTemplate>  
                    <div style="overflow:hidden;text-overflow:ellipsis;width:60px">
                       <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="61px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText ="JobType">
                <ItemTemplate>  
                    <div style="overflow:hidden;text-overflow:ellipsis;width:60px">
                       <asp:Label ID="JobType" runat="server" Text='<%# Bind("JobType") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="60px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                     <asp:TemplateField HeaderText ="Vessel">
                <ItemTemplate>  
                    <div style="overflow:hidden;text-overflow:ellipsis;width:150px">
                       <asp:Label ID="Vessel" runat="server" Text='<%# Bind("vessel") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="151px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                 
                    <asp:TemplateField HeaderText ="Voyage">
                <ItemTemplate>  
                    <div style="overflow:hidden;text-overflow:ellipsis;width:75px">
                       <asp:Label ID="Voyage" runat="server" Text='<%# Bind("voyage") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="75px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
         
                    <asp:TemplateField HeaderText ="MBL">
                <ItemTemplate>  
                    <div style="overflow:hidden;text-overflow:ellipsis;width:145px">
                       <asp:Label ID="MBL" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="146px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText ="ETD">
                <ItemTemplate>  
                    <div style="overflow:hidden;text-overflow:ellipsis;width:80px">
                       <asp:Label ID="ETD" runat="server" Text='<%# Bind("etd") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="80px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText ="Destination">
                <ItemTemplate>  
                    <div style="overflow:hidden;text-overflow:ellipsis;width:120px">
                       <asp:Label ID="Destination" runat="server" Text='<%# Bind("sd") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="121px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText ="ETA">
                <ItemTemplate>  
                    <div style="overflow:hidden;text-overflow:ellipsis;width:80px">
                       <asp:Label ID="ETA" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="81px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                   <asp:TemplateField HeaderText ="MLO">
                <ItemTemplate>  
                    <div style="overflow:hidden;text-overflow:ellipsis;width:220px">
                       <asp:Label ID="MLO" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" width="222px"  HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>--%>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <PagerStyle CssClass="GridviewScrollPager" />
                                    </asp:GridView>
                                    <div class="div_Break"></div>

                                </asp:Panel>
                            </div>
                            <div class="div_Break"></div>

                        </asp:Panel>

                    </div>

                </div>
            </div>


            <%--</div>--%>





            <div class="FormGroupContent4">
                <asp:Label ID="Label2" runat="server"></asp:Label>
                <asp:ModalPopupExtender ID="popup_Grd" runat="server" PopupControlID="pln_popup"
                    DropShadow="false" TargetControlID="Label2" CancelControlID="close">
                </asp:ModalPopupExtender>
                <div runat="server" id="signup" visible="false" style="width: 10%; float: right; margin-right: 1%; margin-top: 0.1%;">
                    <dl id="sample" class="dropdown">
                        <dt><a href="#"><span>Export To </span></a></dt>
                        <dd>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Excelfunforserver_Click">Excel</asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="pdffunforserver_Click">PDF</asp:LinkButton></li>

                            </ul>
                        </dd>
                    </dl>
                </div>
            </div>
    </asp:Panel>




    <div id="PanelLog1" runat="server">
        <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
            <div class="divRoated">
                <div class="LogHeadLbl">
                    <div class="LogHeadJob">
                        <label id="lbl" runat="server">Customer Name:</label>

                    </div>
                    <div class="LogHeadJobInput">

                        <asp:Label ID="JobInput" runat="server"></asp:Label>

                    </div>

                </div>
                <div class="DivSecPanel">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>

                <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl">

                    <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                        ForeColor="Black" EmptyDataText="No Record Found" PageSize="10"
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
    </div>

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image3" BehaviorID="Test1">
    </asp:ModalPopupExtender>

    <div class="FormGroupContent4">
        <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl1" Style="display: none;">
            <br />
            <div style="font-size: 10pt; margin-left: 3%"><b>Do You Want to Delete</b></div>
            <br />
            <div class="div_confirm">
                <asp:Button ID="btn_yes" runat="server" Text="Yes" CssClass="Button" OnClick="btn_yes_Click" />
                <asp:Button ID="btn_No" runat="server" Text="No" CssClass="Button" />
            </div>
            <br />
            <div class="div_Break"></div>
        </asp:Panel>
        <div class="div_Break"></div>
        <div class="div_Break"></div>
        <asp:ModalPopupExtender ID="PopUpService" runat="server" BackgroundCssClass=""
            PopupControlID="Panel_Service" TargetControlID="Label1">
        </asp:ModalPopupExtender>
        <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>
        <div class="div_Break"></div>

        <%-- Elengo PopUp --%>
        <asp:Label ID="Label8" runat="server" Text="Label" Style="display: none;"></asp:Label>
        <asp:ModalPopupExtender ID="PopUpCustomer" runat="server" BackgroundCssClass="" PopupControlID="Panel_Customer" TargetControlID="Label8">
        </asp:ModalPopupExtender>

        <div class="FormGroupContent4">
            <asp:Panel runat="Server" ID="Panel_Customer" CssClass="Pnl1" Style="display: none;">
                <br />
                <div style="font-size: 10pt"><b>Customer already exists.Do you want to add one more address?</b></div>
                <br />
                <div class="div_confirm">
                    <asp:Button ID="btn_CL_Yes" runat="server" Text="Yes" CssClass="Button" OnClick="btn_CL_Yes_Click" />
                    <asp:Button ID="btn_CL_No" runat="server" Text="No" CssClass="Button" OnClick="btn_CL_No_Click" />
                </div>
                <br />
                <div class="div_Break"></div>
            </asp:Panel>
        </div>

        <asp:Label ID="lblcrm" runat="server"></asp:Label>
        <ajaxtoolkit:ModalPopupExtender ID="PopupBL" runat="server" TargetControlID="lblcrm" BehaviorID="programmaticModalPopupBehavior3"
            PopupControlID="popupfro" Drag="true"
            BackgroundCssClass="modalBackground" CancelControlID="imgcrok">
        </ajaxtoolkit:ModalPopupExtender>

        <asp:Panel ID="popupfro" runat="server" BorderColor="ActiveBorder" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
            <div class="divRoated">
                <div class="DivSecPanel">
                    <asp:Image ID="imgcrok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>
                <asp:Panel ID="Panel31" runat="server" CssClass="">
                    <iframe id="iframecost" runat="server" frameborder="0" src="" visible="true" style="background-color: #FFFFF"></iframe>
                </asp:Panel>
                <div class="divBk"></div>
            </div>
        </asp:Panel>


        <%-- <asp:Label ID="Label55" runat="server"></asp:Label>
        <ajaxtoolkit:ModalPopupExtender ID="popuptds" runat="server" TargetControlID="lblcrm" BehaviorID="programmaticModalPopupBehavior3"
            PopupControlID="popupfromTds" Drag="true"
            BackgroundCssClass="modalBackground" CancelControlID="Image1">
        </ajaxtoolkit:ModalPopupExtender>

        <asp:Panel ID="popupfromTds" runat="server" BorderColor="ActiveBorder" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
            <div class="divRoateds">
                <div class="DivSecPanel">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>

                <asp:Panel ID="Panel4" runat="server" CssClass="">

                    <iframe id="iframe1" runat="server" frameborder="0" src="" visible="true" style="background-color: #FFFFF"></iframe>

                </asp:Panel>
                <div class="divBk"></div>
            </div>
        </asp:Panel>--%>


        <%--POPUP--%>
        <asp:Label ID="lblAI" runat="server"></asp:Label>
        <asp:ModalPopupExtender ID="NoOfCustomerpopup" runat="server" TargetControlID="lblAI" BehaviorID="programmaticModalPopupBehavior1"
            PopupControlID="Div_NoOf_Customer" CancelControlID="imgfgok">
        </asp:ModalPopupExtender>

        <div id="Div_NoOf_Customer" runat="server" class="ContainerPopupdiv hide">
            <div class="DivSecPanel">
                <asp:Image ID="imgfgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="150%" />
            </div>
            <asp:Panel ID="panel_ConDet" runat="server" CssClass="modalPopup1" ScrollBars="Auto" Height="243px">
                <asp:GridView ID="grd_Noof_customer" runat="server" Width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found" class="Grid FixedHeader"
                    OnRowDataBound="grd_Noof_customer_RowDataBound" OnSelectedIndexChanged="grd_Noof_customer_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="S#">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CustomerId" HeaderText="CustomerId" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CustomerName" HeaderText="CUSTOMERNAME">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle CssClass="TxtAlignLeft" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Address" HeaderText="ADDRESS">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle CssClass="TxtAlignLeft" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Location" HeaderText="LOCATION">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle CssClass="TxtAlignLeft" />
                        </asp:BoundField>
                        <asp:BoundField DataField="City" HeaderText="CITY">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle CssClass="TxtAlignLeft" />
                        </asp:BoundField>
                        <asp:BoundField DataField="State" HeaderText="STATE">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle CssClass="TxtAlignLeft" />
                        </asp:BoundField>
                        <asp:BoundField DataField="gstin" HeaderText="GSTNO">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle CssClass="TxtAlignLeft" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GSTType" HeaderText="GSTType">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle CssClass="TxtAlignLeft" />
                        </asp:BoundField>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                </asp:GridView>
            </asp:Panel>
            <div class="right_btn">
                <div class="btn ico-add" id="btn_add1" runat="server">
                    <asp:Button ID="btn_add" runat="server" ToolTip="AddNewCustomer" OnClick="btn_add_Click" />
                </div>
            </div>
        </div>

        <asp:HiddenField ID="hf_employeeid" runat="server" />
        <asp:HiddenField ID="hf_locationid" runat="server" />
        <asp:HiddenField ID="hf_portid" runat="server" />
        <asp:HiddenField ID="hf_districtid" runat="server" />
        <asp:HiddenField ID="hf_stateid" runat="server" />
        <asp:HiddenField ID="hf_countryid" runat="server" />
        <asp:HiddenField ID="hf_customerid" runat="server" />
        <asp:HiddenField ID="hf_email" runat="server" />
        <asp:HiddenField ID="hfWasConfirmed" runat="server" />
        <asp:HiddenField ID="hdf_pinlocation" runat="server" />
        <asp:HiddenField ID="hid_gstcode" runat="server" />
        <asp:HiddenField ID="hdn_Flag" runat="server" />
        <asp:HiddenField ID="hdn_oldgstcode" runat="server" />
        <asp:HiddenField ID="hid_type" runat="server" />
        <asp:HiddenField ID="Hid_ServerUsername" runat="server" Value="ifrtAdmin" />
        <asp:HiddenField ID="Hid_ServerPWD" runat="server" Value="05Jun!(&%" />

        <asp:HiddenField ID="Hidden_shippercode" runat="server" />
        <asp:HiddenField ID="Hidden_fullname" runat="server" />
        <asp:HiddenField ID="Hidden_Add1" runat="server" />
        <asp:HiddenField ID="Hidden_Add2" runat="server" />
        <asp:HiddenField ID="Hidden_city" runat="server" />
        <asp:HiddenField ID="Hidden_country" runat="server" />
        <asp:HiddenField ID="Hidden_offcode" runat="server" />
        <asp:HiddenField ID="Hidden_createdby" runat="server" />
        <asp:HiddenField ID="Hidden_createdon" runat="server" />
        <asp:HiddenField ID="Hidden_status" runat="server" />
        <asp:HiddenField ID="Hidden_email" runat="server" />
        <asp:HiddenField ID="Hidden_ph" runat="server" />
        <asp:HiddenField ID="Hidden_zip" runat="server" />
        <asp:HiddenField ID="Hidden_state" runat="server" />

        <asp:HiddenField ID="hid_pan" runat="server" />
        <asp:HiddenField ID="hid_crid" runat="server" />
        <asp:HiddenField ID="hdn_add" runat="server" />
        <asp:HiddenField ID="hid_panno" runat="server" />
        <asp:HiddenField ID="hidpaninput" runat="server" />
        <asp:HiddenField ID="hid_bankid" runat="server" />
        <asp:HiddenField ID="hid_gst" runat="server" />
        <asp:HiddenField ID="hid_einvoice" runat="server" />
        <asp:HiddenField ID="Hidden_cityname" runat="server" />
        <asp:HiddenField ID="hid_coloadlink" runat="server" Value="https://insight.cargoemotion.com/prsapi/party/in-shipper" />
    </div>

</asp:Content>
