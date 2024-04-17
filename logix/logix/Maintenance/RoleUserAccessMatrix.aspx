<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="RoleUserAccessMatrix.aspx.cs" EnableEventValidation="false" Inherits="logix.Maintenance.RoleUserAccessMatrix" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/CORPORATEHOME.css" rel="stylesheet" />
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/Newhome.css" rel="stylesheet" />
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>
    <link href="../Styles/UserPermission.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/helper.js"></script>

    <style type="text/css">
        .HomeGroup {
            width: 275px;
            float: left;
            margin: 0px 20px 36px 10px;
            height: 436px;
            overflow: auto;
        }

        .HomeGroupCOR {
            width: 150px;
            float: left;
            margin: 0px 5px 36px 1px;
            height: 456px;
            overflow-x: hidden;
            overflow-y: auto;
            border: 1px solid #b1b1b1;
        }

        th span label {
            position: relative;
            left: 5px;
        }

        th span {
            display: flex;
            flex-direction: row-reverse;
            justify-content: start;
        }

        .HomeGroupCOR h3 {
            font-size: 14px;
            font-family: sans-serif, Geneva, sans-serif;
            padding: 5px 0px 0px 0px;
            margin: 0px 0px 0px 0px;
            text-align: center;
            color: #ffffff;
        }

        .div_grd {
            height: 393px !important;
            overflow: auto;
        }

        .lbl_process {
            float: left;
            margin-left: 0px;
            margin-top: -20px;
            font-weight: bold;
            width: 90%;
            color: #04559a;
        }

        .UserMenu {
            width: 32.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .UserPerEmp {
            width: 91%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .div_grd {
            width: 100%;
            float: left;
            border: 1px solid #b1b1b1;
            height: 424px;
            margin: 0px 0px 0px 10px;
            padding: 0px;
            overflow: auto;
        }

            .div_grd input {
                width: 98%;
            }

        .div_grd1 {
            width: 100%;
            float: left;
            border: 1px solid #b1b1b1;
            height: 386px;
            margin: 1px 15px 0px 5px;
            padding: 0px;
            overflow: auto;
        }

            .div_grd1 input {
                width: 98%;
            }

        .UserBox1 {
            width: 30%;
            float: left;
            margin: 5px 5px 0px 0px;
        }

        .UserBox2 {
            width: 194px;
            float: left;
            margin: 5px 5px 0px 0px;
        }

        .UserBoxC2 {
            width: 11.5%;
            float: left;
            margin: 10px 5px 0px 0px;
        }

        .UserBoxC3 {
            width: 72%;
            float: left;
            margin: 4px 5px 0px 0px;
        }

        .UserBox3 {
               width: 69%;
    float: left;
    margin: 37px 4px 0px 0px;
        }

        .HomeGroupCS {
            width: 22%;
            float: left;
            margin: 18px 20px 36px 10px;
            height: 600px;
            overflow: auto;
        }

        .GridHeightN1 {
            width: 222px !important;
            float: left !important;
            background-color: #2b4e86;
            overflow: auto !important;
            height: 459px !important;
            margin-top: 0%;
            margin-left: 2%;
        }

            .GridHeightN1 img {
                width: 190px;
                height: 94px;
            }

        .CRMBox a {
            color: #fffffc;
            font-size: 14px;
            font-family: "Segoe UI";
            display: block;
            text-align: center;
            text-decoration: none;
            padding: 60px 0px 0px 0px;
        }

        .SalesBox a {
            color: #fffffc;
            font-size: 14px;
            font-family: "Segoe UI";
            display: block;
            text-align: center;
            text-decoration: none;
            padding: 60px 0px 0px 0px;
        }

        .OECSBox a {
            color: #ffffff;
            font-size: 14px;
            font-family: "Segoe UI";
            display: block;
            text-align: center;
            text-decoration: none;
            padding: 0px 0px 0px 0px;
        }

        .OECSBox1 a {
            color: #ffffff;
            font-size: 14px;
            font-family: "Segoe UI";
            display: block;
            text-align: center;
            text-decoration: none;
            padding: 0px 0px 0px 0px;
        }

        .BT a {
            color: #fffffc;
            font-size: 14px;
            line-height: 16px;
            font-family: "Segoe UI";
            display: block;
            text-align: center;
            text-decoration: none;
            height: 77px;
            padding: 51px 0px 0px;
        }

        .CHA a {
            color: #fffffc;
            font-size: 14px;
            font-family: "Segoe UI";
            display: block;
            text-align: center;
            text-decoration: none;
            padding: 61px 0px 0px 0px;
        }

        .MIS a {
            color: #fffffc;
            font-size: 14px;
            font-family: "Segoe UI";
            display: block;
            text-align: center;
            text-decoration: none;
            padding: 50px 0px 0px 0px;
            line-height: 16px;
        }

        .OpsAccounts a {
            color: #fffffc;
            font-size: 14px;
            font-family: "Segoe UI";
            display: block;
            text-align: center;
            text-decoration: none;
            padding: 52px 0px 0px 0px;
            line-height: 16px;
        }

        .OpsFinance {
            width: 118px;
            float: left;
            background-color: #913d12;
            min-height: 94px;
            margin: 1px 0px 0px 0px;
        }

            .OpsFinance a {
                color: #fffffc;
                font-size: 14px;
                font-family: "Segoe UI";
                display: block;
                text-align: center;
                text-decoration: none;
                padding: 52px 0px 0px 0px;
                line-height: 16px;
            }

        .BranchHead {
            color: var(--labelblack);
            font-size: 11px;
            margin: 5px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            width: 170px;
            float: left;
        }

        .ProcessHead {
            color: #04559a;
            font-weight: bold;
            font-size: 11px;
            margin: -21px 0px 5px 0px;
            padding: 0px 0px 0px 0px;
            width: 200px;
            float: left;
        }

        .Grid1 th {
            display: none;
        }

        .MLN5 {
            margin: 5px 0px 5px 5px;
        }

        .UserPerInput {
            width: 29.3%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

      

        .row {
            height: 567px !important;
            margin: 0px 5px 0px 0px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: hidden !important;
            width: 98.5%;
        }

        .div_process {
            width: 10%;
            margin-left: 1%;
            float: 1%;
        }

        #sidebar ul#nav ul.sub-menu ul.sub-menu > li {
            border-left: 0px solid #ffffff;
        }
 div#logix_CPH_div_iframe .widget-content {
    top: 50px !important;
}



        .ToggleBtn a {
            display: inline-block;
            padding: 5px;
            margin: 5px 10px 0px 0px;
            width: auto;
            float: left !important;
        }

            .ToggleBtn a.OExport {
                background: #0077c9 url(../Theme/assets/img/icons/oe_ic.png) no-repeat 5% 7px;
                font-family: 'Segoe UI';
                float: left;
                font-size: 11px;
                padding: 10px 5px 5px 33px;
                text-align: center;
                width: 118px;
                height: 40px;
                color: #fff;
            }

            .ToggleBtn a.OImport {
                background: #042b4c url(../Theme/assets/img/icons/oi_ic.png) no-repeat 5% 9px;
                font-family: 'Segoe UI';
                float: left;
                font-size: 11px;
                padding: 10px 0px 5px 33px;
                text-align: center;
                width: 118px;
                height: 40px;
                color: #fff;
            }

            .ToggleBtn a.AExport {
                background: #413b61 url(../Theme/assets/img/icons/ae_ic.png) no-repeat 5% 6px;
                float: left;
                font-family: 'Segoe UI';
                font-size: 11px;
                padding: 10px 5px 5px 31px;
                text-align: center;
                width: 118px;
                height: 40px;
                color: #fff;
            }

            .ToggleBtn a.AImport {
                background: #433d27 url(../Theme/assets/img/icons/ai_ic.png) no-repeat 5% 6px;
                float: left;
                font-family: 'Segoe UI';
                font-size: 11px;
                padding: 10px 5px 5px 31px;
                text-align: center;
                width: 118px;
                height: 40px;
                color: #fff;
            }

        .div_btn {
            float: left;
            width: 10%;
            margin-left: 3.5%;
            margin-top: 0.8%;
        }

        .Grid1 td {
            border-right: 1px solid #dddddd;
            font-size: 11px;
            text-align: left;
            padding: 10px 5px 10px 5px;
            margin: 0px;
            color: #4e4c4c;
            border-bottom: 1px solid #dddddd;
        }

        .MenuFCA {
            background-color: #37383c;
            width: 237px;
            height: 94px;
            float: left;
            text-align: center;
            padding: 6px 0px 0px 0px;
            margin: 0px 10px 1px 0px;
        }

        .MenuAE {
            background-color: #433d27;
            width: 118px;
            height: 94px;
            float: left;
            text-align: center;
            padding: 6px 0px 0px 0px;
            margin: 15px 1px 1px 0px;
        }

        .MenuAI {
            background-color: #413b61;
            width: 118px;
            height: 94px;
            float: left;
            text-align: center;
            padding: 6px 0px 0px 0px;
            margin: 0px 0px 1px 0px;
        }

        .MenuCRM {
            background-color: #413b61;
            width: 118px;
            height: 108px;
            float: left;
            text-align: center;
            padding: 6px 0px 0px 0px;
            margin: 0px 10px 1px 0px;
        }

        .MenuME {
            background-color: #d02027;
            width: 118px;
            height: 95px;
            float: left;
            text-align: center;
            padding: 6px 0px 0px 0px;
            margin: 0px 1px 1px 0px;
        }

        .HR {
            width: 118px;
            height: 95px;
            float: left;
            text-align: center;
            background-color: #413b61;
            min-height: 94px;
            margin: 0px 10px 1px 0px;
        }

        .MenuOE {
            background-color: #042a4c;
            width: 100%;
            height: 92px;
            float: left;
            text-align: center;
            padding: 6px 0px 0px 0px;
            margin: 0px 1px 1px 0px;
        }

        .MenuAI img {
            margin-bottom: 10px;
        }

        .MenuCRM img {
            margin-bottom: 7px;
            margin-top: 12px;
        }

        .HRIC {
            width: 52px;
            height: 47px;
        }

        .MenuAcc {
            background-color: #042a4c;
            width: 118px;
            height: 94px;
            float: left;
            text-align: center;
            padding: 6px 0px 0px 0px;
            margin: 0px 1px 1px 0px;
        }

        .btn-allright1 {
            z-index: 2;
        }

            .btn-allright1 input {
                border-style: none;
                border-color: inherit;
                border-width: medium;
                background: url(../Theme/assets/img/buttonIcon/allrights_ic.png ) no-repeat left top;
                line-height: normal;
                color: #4e4e4c !important;
                padding: 5px 0px 6px 28px;
            }
        /*-----log*/
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
            width: 15%;
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
                font-family: sans-serif;
                color: #4e4e4c;
            }

        logix_CPH_PanelLog {
            top: 200px !important;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            color: #000080;
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }

        .FormGroupContent4 label {
            font-size: 11px;
            color: var(--labelorange) !important;
            font-weight: 500 !important;
        }

        img#logix_CPH_grd_images_Image1_0, img#logix_CPH_grd_images_Image1_4 {
            width: 182px;
            height: 125px;
        }

        div#logix_CPH_corporate a > div {
            width: 100%;
        }

        .MenuOI {
            margin: 8px 0px 1px 0px !important;
            width: 100%;
        }

        table#logix_CPH_grd_user span {
            display: flex;
        }

        span#logix_CPH_lbl_branchname, span#logix_CPH_lbl_processname {
            font-weight: normal !important;
        }
        div#logix_CPH_ddl_process_chzn {
    width: 100% !important;
}
        .branch{
            width:15%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
         .process{
            width:16%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
         div#logix_CPH_Panel1 {
    height: calc(100vh - 260px);
}
    </style>
    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txt_user.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_employeeid.ClientID %>").val(0);

                        $.ajax({
                            url: "../Maintenance/RoleUserAccessMatrix.aspx/GetEmployeename",
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

                        $("#<%=txt_user.ClientID %>").change();
                    },

                    focus: function (event, i) {
                        $("#<%=txt_user.ClientID %>").val(i.item.value);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_user.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_user.ClientID %>").val($.trim(result));

                    },

                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_userto.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_employeeidto.ClientID %>").val(0);

                        $.ajax({
                            url: "../Maintenance/RoleUserAccessMatrix.aspx/GetEmployeename",
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
                        $("#<%=hf_employeeidto.ClientID %>").val(i.item.val);

                        $("#<%=txt_userto.ClientID %>").change();
                    },

                    focus: function (event, i) {
                        $("#<%=txt_userto.ClientID %>").val(i.item.value);
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_userto.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_userto.ClientID %>").val($.trim(result));

                    },

                    minLength: 1
                });
            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    <script type="text/javascript">
        var TotalChkBx;
        var Counter;

        window.onload = function () {
            //Get total no. of CheckBoxes in side the GridView.
            TotalChkBx = parseInt('<%= this.grd_user.Rows.Count %>');

            //Get total no. of checked CheckBoxes in side the GridView.
            Counter = 0;
        }

        function chk_access1(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
                document.getElementById('<%= this.grd_user.ClientID %>');
            var TargetChildControl = "chk_access1";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                          Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;

            //Reset Counter
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }

        function chk_save1(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
                document.getElementById('<%= this.grd_user.ClientID %>');
            var TargetChildControl = "chk_save1";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                          Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;

            //Reset Counter
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }
        function chk_view1(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
                document.getElementById('<%= this.grd_user.ClientID %>');
           var TargetChildControl = "chk_view1";

           //Get all the control of the type INPUT in the base control.
           var Inputs = TargetBaseControl.getElementsByTagName("input");

           //Checked/Unchecked all the checkBoxes in side the GridView.
           for (var n = 0; n < Inputs.length; ++n)
               if (Inputs[n].type == 'checkbox' &&
                         Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                   Inputs[n].checked = CheckBox.checked;

           //Reset Counter
           Counter = CheckBox.checked ? TotalChkBx : 0;
       }
       function chk_delete1(CheckBox) {
           //Get target base & child control.
           var TargetBaseControl =
               document.getElementById('<%= this.grd_user.ClientID %>');
            var TargetChildControl = "chk_delete1";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                          Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;

            //Reset Counter
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }
        function chk_upd1(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
                document.getElementById('<%= this.grd_user.ClientID %>');
           var TargetChildControl = "chk_upd1";

           //Get all the control of the type INPUT in the base control.
           var Inputs = TargetBaseControl.getElementsByTagName("input");

           //Checked/Unchecked all the checkBoxes in side the GridView.
           for (var n = 0; n < Inputs.length; ++n)
               if (Inputs[n].type == 'checkbox' &&
                         Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                   Inputs[n].checked = CheckBox.checked;

           //Reset Counter
           Counter = CheckBox.checked ? TotalChkBx : 0;
       }

       function ChildClick(CheckBox, HCheckBox) {
           //get target control.
           var HeaderCheckBox = document.getElementById(HCheckBox);

           //Modifiy Counter; 
           if (CheckBox.checked && Counter < TotalChkBx)
               Counter++;
           else if (Counter > 0)
               Counter--;

           //Change state of the header CheckBox.
           if (Counter < TotalChkBx)
               HeaderCheckBox.checked = false;
           else if (Counter == TotalChkBx)
               HeaderCheckBox.checked = false;
       }
    </script>

    <script type="text/javascript">
        var TotalChkBx1;
        var Counter1;

        window.onload = function () {
            //Get total no. of CheckBoxes in side the GridView.
            TotalChkBx1 = parseInt('<%= this.Gridbranch.Rows.Count %>');

            //Get total no. of checked CheckBoxes in side the GridView.
            Counter1 = 0;
        }

        function chk_access(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
                document.getElementById('<%= this.Gridbranch.ClientID %>');
            var TargetChildControl = "chk_access";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                          Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;

            //Reset Counter
            Counter1 = CheckBox.checked ? TotalChkBx1 : 0;
        }

        function chk_save(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
                document.getElementById('<%= this.Gridbranch.ClientID %>');
            var TargetChildControl = "chk_save";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                          Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;

            //Reset Counter
            Counter1 = CheckBox.checked ? TotalChkBx1 : 0;
        }
        function chk_view(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
                document.getElementById('<%= this.Gridbranch.ClientID %>');
            var TargetChildControl = "chk_view";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                          Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;

            //Reset Counter
            Counter1 = CheckBox.checked ? TotalChkBx1 : 0;
        }
        function chk_delete(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
                document.getElementById('<%= this.Gridbranch.ClientID %>');
           var TargetChildControl = "chk_delete";

           //Get all the control of the type INPUT in the base control.
           var Inputs = TargetBaseControl.getElementsByTagName("input");

           //Checked/Unchecked all the checkBoxes in side the GridView.
           for (var n = 0; n < Inputs.length; ++n)
               if (Inputs[n].type == 'checkbox' &&
                         Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                   Inputs[n].checked = CheckBox.checked;

           //Reset Counter
           Counter1 = CheckBox.checked ? TotalChkBx1 : 0;
       }
       function chk_upd(CheckBox) {
           //Get target base & child control.
           var TargetBaseControl =
               document.getElementById('<%= this.Gridbranch.ClientID %>');
            var TargetChildControl = "chk_upd";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                          Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;

            //Reset Counter
            Counter1 = CheckBox.checked ? TotalChkBx1 : 0;
        }

        function ChildClick(CheckBox, HCheckBox) {
            //get target control.
            var HeaderCheckBox = document.getElementById(HCheckBox);

            //Modifiy Counter; 
            if (CheckBox.checked && Counter1 < TotalChkBx1)
                Counter1++;
            else if (Counter1 > 0)
                Counter1--;

            //Change state of the header CheckBox.
            if (Counter1 < TotalChkBx1)
                HeaderCheckBox.checked = false;
            else if (Counter1 == TotalChkBx1)
                HeaderCheckBox.checked = false;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div>
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header1" runat="server"></asp:Label></h4>
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </li>
                            <li><a href="#" title=""></a>
                                <asp:Label ID="lbl_header" runat="server"></asp:Label>
                            </li>
                            <li class="current"><a href="#" title=""></a></li>
                        </ul>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                                   <div class="FixedButtons" >
                                           <div class="btn ico-add" id="btnadd1" runat="server" style="margin-top: 11px; margin-left:3px;">
                       <asp:button id="btnadd" runat="server" Text="Add" tooltip="Add" tabindex="18" onclick="btnadd_Click" />
                   </div>
                        <div class="right_btn" id="btnsavec">
    <div class="btn ico-save" id="btn_save_id" runat="server" >
        <asp:Button ID="btn_save" Text="Save" runat="server" ToolTip="Save" OnClick="btn_save_Click" />
    </div>

    <div class="btn ico-view" id="btn_view_id" runat="server" >
        <asp:Button ID="btn_view" runat="server" Text="View" ToolTip="View" OnClick="btn_view_Click" />
    </div>
    <div class="btn ico-cancel" id="btn_back1" runat="server">
        <asp:Button ID="btn_back" runat="server"  Text="Cancel" ToolTip="Cancel" OnClick="btn_back_Click" />
    </div>
</div>
               </div>


                </div>

                <div class="widget-content">
                    
                    <div class="FormGroupContent4 boxmodal">
                        <div class="UserPerInput">
                            <asp:Label ID="Label2" runat="server" CssClass="hide" Text="Role Name"> </asp:Label>
                            <asp:TextBox ID="txt_user" runat="server" CssClass="form-control" MaxLength="100" placeholder="Role Name" ToolTip="Role Name" AutoPostBack="true" OnTextChanged="txt_user_TextChanged"></asp:TextBox>
                        </div>
                        <div class="UserMenu ">
                            <asp:Label ID="Label3" runat="server" CssClass="hide" Text="Emp Details"> </asp:Label>
                            <asp:TextBox ID="txt_details" runat="server" CssClass="form-control" MaxLength="100" placeholder="Role Details" ToolTip="Role Details"></asp:TextBox>
                        </div>
                       
                        <div class="branch">
                        <asp:DropDownList ID="ddl_branch" runat="server" placeholder="Branch" AppendDataBoundItems="True" CssClass="chzn-select" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged" AutoPostBack="true"
                                            ToolTip="Branch" data-placeholder="Branch">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        </asp:DropDownList>

                        </div>
                        <div class="process">
                            
                        <asp:DropDownList ID="ddl_process" runat="server" placeholder="Process" AppendDataBoundItems="True" CssClass="chzn-select" OnSelectedIndexChanged="ddl_process_SelectedIndexChanged" AutoPostBack="true"
                                            ToolTip="Process" data-placeholder="Process">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        </asp:DropDownList>
                        </div>
                    </div>

                    <div class="BranchHead"></div>
                    <div class="Clear"></div>
                    <div class="UserBox1">
                        <div class=" FormGroupContent4 hide">
                            


                            <asp:Panel ID="panel_service" runat="server" CssClass="panel_16 MB0">

                                <asp:GridView runat="server" ID="grd_images" AutoGenerateColumns="false" Width="30%" Height="50%" CssClass="Grid FixedHeader" DataKeyNames="branchid" OnSelectedIndexChanged="grd_images_SelectedIndexChanged" OnRowDataBound="grd_images_RowDataBound">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Branch">

                                            <ItemTemplate>

                                                <asp:Image ID="Image1" runat="server" HeaderText="Branch" ImageUrl='<%# GetImage( Eval("touchclogo")) %>' />

                                            </ItemTemplate>

                                        </asp:TemplateField>

                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="" />
                                    <RowStyle Font-Italic="False" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                         <div class="UserPerEmp hide">
                            <asp:Label ID="Label4" runat="server" CssClass="hide" Text="Alternative Emp Name"> </asp:Label>
                            <asp:TextBox ID="txt_userto" runat="server" CssClass="form-control" MaxLength="100" placeholder="Copy From" ToolTip="Copy From" AutoPostBack="true" OnTextChanged="txt_userto_TextChanged"></asp:TextBox>
                        </div>

                        <div class="btn ico-all-rights hide">
                            <asp:Button ID="btn_all" runat="server" Text="All Rights" ToolTip="ALL Rights" OnClick="btn_all_Click" />
                        </div>
                    </div>

                    <div class="hide">
                           <div class="ProcessHead" id="Process" runat="server">
                            <asp:Label ID="lbl_branchname" runat="server"  ></asp:Label>
                        </div>   

                    </div> 
                    <div class="UserBox2" id="branch" runat="server">

                      

                        <div style="clear: both;"></div>


                        <div class="FormGroupContent4 hide" id="div_grds" runat="server">
                            <asp:Panel ID="panel_servic" runat="server" CssClass="panel_16 MB0">

                                <asp:GridView runat="server" ID="Grid_homeimage" AutoGenerateColumns="false" Height="50%" CssClass="Grid FixedHeader" DataKeyNames="Processid" OnSelectedIndexChanged="Grid_homeimage_SelectedIndexChanged" OnRowDataBound="Grid_homeimage_RowDataBound">
                                    <Columns>

                                        <asp:TemplateField HeaderText="ProcessUI">

                                            <ItemTemplate>

                                                <asp:Image ID="Image1" runat="server" HeaderText="Branch" ImageUrl='<%# GetImage( Eval("touchclogo")) %>' />

                                            </ItemTemplate>

                                        </asp:TemplateField>

                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle Font-Italic="False" />
                                </asp:GridView>

                            </asp:Panel>
                        </div>

                        <div class="HomeGroup" id="homeid" runat="server">

                            <div class="CRMBox">
                                <asp:LinkButton ID="link_crm" runat="server" CssClass="CRMIC" OnClick="link_crm_Click">CRM</asp:LinkButton>
                                <%--<a id="CRM" runat="server" href="#">
                                <div class="CRMIC"></div>
                                CRM</a>--%>
                            </div>

                            <div class="SalesBox">
                                <asp:LinkButton ID="link_sales" runat="server" CssClass="SalesIC" OnClick="link_sales_Click">Sales</asp:LinkButton>
                                <%--<a id="Sales" runat="server" href="#">
                                <div class="SalesIC"></div>
                                Sales</a>--%>
                            </div>

                            <div class="Clear"></div>
                            <div class="OECSBox">

                                <asp:LinkButton ID="link_customersupport" runat="server" OnClick="link_customersupport_Click">
                                 <div class="IConbox1" ></div>
                                Customer Support</asp:LinkButton>
                            </div>
                            <div class="OECSBox1">

                                <asp:LinkButton ID="link_OpsDocks" runat="server" OnClick="link_OpsDocks_Click">
                                <div class="IConBox4"></div>
                                Ops & Docs</asp:LinkButton>
                            </div>

                            <div id="Div1" class="ToggleBtn" runat="server" style="float: left; margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px;" visible="false">
                                <asp:LinkButton ID="link_cusOE" runat="server" CssClass="OExport" OnClick="link_cusOE_Click">Ocean Exports</asp:LinkButton>
                                <%--<a id="A2" runat="server" href="#" class="OExport">--%><%--Ocean Exports--%><%--</a>--%>
                                <asp:LinkButton ID="link_cusOI" runat="server" CssClass="OImport" OnClick="link_cusOI_Click"> Ocean Imports</asp:LinkButton>
                                <div class="Clear"></div>
                                <asp:LinkButton ID="link_cusAE" runat="server" CssClass="AExport" OnClick="link_cusAE_Click">Air Exports</asp:LinkButton>
                                <asp:LinkButton ID="link_cusAI" runat="server" CssClass="AImport" OnClick="link_cusAI_Click">Air Imports</asp:LinkButton>

                            </div>
                            <div id="Div2" class="ToggleBtn" runat="server" style="float: left; margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px;" visible="false">
                                <asp:LinkButton ID="link_OpsDockOE" runat="server" CssClass="OExport" OnClick="link_OpsDockOE_Click">Ocean Exports</asp:LinkButton>
                                <%--<a id="A2" runat="server" href="#" class="OExport">--%><%--Ocean Exports--%><%--</a>--%>
                                <asp:LinkButton ID="link_OpsDockOI" runat="server" CssClass="OImport" OnClick="link_OpsDockOI_Click"> Ocean Imports</asp:LinkButton>
                                <div class="Clear"></div>
                                <asp:LinkButton ID="link_OpsDockAE" runat="server" CssClass="AExport" OnClick="link_OpsDockAE_Click">Air Exports</asp:LinkButton>
                                <asp:LinkButton ID="link_OpsDockAI" runat="server" CssClass="AImport" OnClick="link_OpsDockAI_Click">Air Imports</asp:LinkButton>

                            </div>
                            <%-- <a id="OE_CS" runat="server" href="#"> --%>           <%--data-toggle="collapse" data-target="#demo"--%>

                            <%-- <div class="IConbox1"></div>
                                Customer Support 
                            </a>--%>

                            <div class="Clear"></div>

                            <div id="demo" class="ToggleBtn" runat="server" style="float: left; margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px;" visible="false">
                                <a id="OE_CSs" runat="server" href="#" class="OExport">Ocean Exports</a> <a id="OI_CSs" runat="server" href="#" class="OImport">Ocean Imports</a>
                                <div class="Clear"></div>
                                <a id="AE_CS" runat="server" href="#" class="AExport">Air Exports</a>  <a id="AI_cs" runat="server" href="#" class="AImport">Air Imports</a>

                            </div>
                            <div id="demo1" class="ToggleBtn" runat="server" style="float: left; margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px;" visible="false">
                                <a id="OE_ops" runat="server" href="#" class="OExport">Ocean Exports</a> <a id="OI_ops" runat="server" href="#" class="OImport">Ocean Imports</a>
                                <div class="Clear"></div>
                                <a id="AE_ops" runat="server" class="AExport">Air Exports</a>  <a id="AI_ops" runat="server" href="#" class="AImport">Air Imports</a>
                            </div>
                            <div class="Clear"></div>
                            <div class="BT">
                                <asp:LinkButton ID="link_BoundedTrucking" runat="server" CssClass="BTIC" OnClick="link_BoundedTrucking_Click"> Bonded Trucking

                                </asp:LinkButton>
                                <%--<a id="BondedTrucking" runat="server" href="#">
                                <div class="BTIC"></div>
                                Bonded Trucking</a>--%>
                            </div>
                            <div class="CHA">
                                <asp:LinkButton ID="link_CHA" runat="server" CssClass="CHAIC" OnClick="link_CHA_Click">CHA</asp:LinkButton>
                                <%--  <a id="CHA" runat="server" href="#">
                                <div class="CHAIC"></div>
                                CHA</a>--%>
                            </div>
                            <div class="Clear"></div>
                            <div class="MIS">
                                <asp:LinkButton ID="link_mis" runat="server" CssClass="MISIC" OnClick="link_mis_Click">  MIS & Analytics</asp:LinkButton>
                                <%-- <a id="MIS" runat="server" href="#">
                                <div class="MISIC"></div>
                                MIS & Analytics</a>--%>
                            </div>

                            <div class="HR" style="display: none;">
                                <a href="#" id="Hr" runat="server">
                                    <div class="HRIC"></div>
                                    Human Resources</a>
                            </div>

                            <div class="OpsAccounts">
                                <asp:LinkButton ID="link_OperatingAccount" runat="server" CssClass="OpsAcc" OnClick="link_OperatingAccount_Click">Operating Accounts</asp:LinkButton>
                                <%-- <a href="#" id="OperatingAccounts" runat="server">
                                <div class="OpsAcc">
                                </div>
                                Operating Accounts
                            </a>--%>
                            </div>
                            <div class="OpsFinance">
                                <asp:LinkButton ID="link_finan" runat="server" CssClass="OpsAcc" OnClick="link_finan_Click">Financial Accounts</asp:LinkButton>
                                <%-- <a href="#" id="OperatingAccounts" runat="server">
                                <div class="OpsAcc">
                                </div>
                                Operating Accounts
                            </a>--%>
                            </div>

                            <div class="Clear"></div>

                            <div class="OECSBox2" style="display: none;">
                                <a href="#">
                                    <div class="IConbox5">Air Exports </div>
                                    <div class="IConBox6">Customer Support </div>
                                </a>
                            </div>
                            <div class="OECSBox3" style="display: none;">
                                <a href="#">
                                    <div class="IConbox7">Air Imports </div>
                                    <div class="IConBox8">Customer Support </div>
                                </a>
                            </div>
                            <div class="Clear"></div>
                            <div class="OECSBox4" style="display: none;">
                                <a href="#">
                                    <div class="IConbox9">Ocean Exports   </div>
                                    <div class="IConBox10">Ops & Docs </div>
                                </a>
                            </div>
                            <div class="OECSBox5" style="display: none;">
                                <a href="#">
                                    <div class="IConbox11">Ocean Imports</div>
                                    <div class="IConBox12">Ops & Docs </div>
                                </a>
                            </div>

                            <div class="Clear"></div>
                            <div class="OECSBox6" style="display: none;">
                                <a href="#">
                                    <div class="IConbox13">Air Exports</div>
                                    <div class="IConBox14">Documentation</div>
                                </a>
                            </div>
                            <div class="OECSBox7" style="display: none;">
                                <a href="#">
                                    <div class="IConbox15">Air Imports </div>
                                    <div class="IConBox16">Ops & Docs </div>
                                </a>
                            </div>

                            <div class="Clear"></div>

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
                        <div class="HomeGroupCOR" id="corporate" runat="server" style="display:none">
                            <asp:LinkButton ID="link_AccountFinance" runat="server" CssClass="MenuOE" OnClick="link_AccountFinance_Click">
                  <%--  <a id="Accounts_and_finanace" runat="server" href="#">--%>
                            <div class="MenuAcc">
                                <img src="../Theme/assets/img/icons/accounts_ic.png">
                                <h3>Accounts and Finance</h3>
                            </div>
                            </asp:LinkButton>
                            <%--  </a>--%>
                            <asp:LinkButton ID="link_credit" runat="server" CssClass="MenuOI" OnClick="link_credit_Click">
                       <%-- <a id="Credit_Control" runat="server" href="#">--%>
                            <div class="MenuOI">
                                <img src="../Theme/assets/img/icons/creditcontrol_ic.png">
                               <h3>Credit Control</h3>
                            </div>
                            </asp:LinkButton>
                            <%-- </a>--%>
                            <div class="Clear"></div>
                            <asp:LinkButton ID="link_Budget" runat="server" OnClick="link_Budget_Click">
                         <%--  <a id="Budget" runat="server" href="#">--%>
                            <div class="MenuAE">
                                <img src="../Theme/assets/img/icons/budjet_ic.png">
                                <h3>Budget</h3>
                            </div>
                        <%--</a>--%>
                            </asp:LinkButton>
                            <asp:LinkButton ID="link_misanalysis" runat="server" OnClick="link_misanalysis_Click">
                      <%--   <a id="MIS_and_Analysis" runat="server" href="#">--%>
                            <div class="MenuAI">
                                <img src="../Theme/assets/img/icons/misanalytics_ic.png">
                                <h3>MIS and Analysis</h3>
                            </div>
                       <%-- </a>--%>
                            </asp:LinkButton>
                            <asp:LinkButton ID="link_Utility" runat="server" CssClass="MenuOE" OnClick="link_Utility_Click">
                       <%--<a id="" runat="server" href="#">--%>
                            <div class="MenuOE" style="margin:10px 1px 0px 0px;">
                                <img src="../Theme/assets/img/icons/utility_ic.png">
                                <h3>Utility</h3>
                            </div>
                       <%-- </a>--%>
                            </asp:LinkButton>
                            <asp:LinkButton ID="link_CRMCOR" runat="server" OnClick="link_CRMCOR_Click">
                        <%--  <a id="CRM" runat="server" href="#">--%>
                            <div class="MenuCRM">
                                 <img src="../Theme/assets/img/icons/crm_ic.png">
                                <h3>CRM</h3>
                            </div>
                      <%--  </a>--%>
                            </asp:LinkButton>
                            <asp:LinkButton ID="link_maintenance" runat="server" OnClick="link_maintenance_Click">
                        <%--  <a id="Maintenances" runat="server" href="#">--%>
                            <div class="MenuME">
                                <img src="../Theme/assets/img/icons/maintenance_ic.png">
                               <h3>Maintenance</h3>
                            </div>
                      <%--  </a>--%>
                            </asp:LinkButton>
                            <asp:LinkButton ID="link_HRM" runat="server" OnClick="link_HRM_Click"> 
                        <%--  <a id="HRM" runat="server" href="#">--%>
                        <div class="HR"> 
      <div class="HRIC"></div>
     <h3> Human Resources</h3> </div>
                             <%--</a>--%>
                            </asp:LinkButton>
                            <div class="Clear"></div>
                            <asp:LinkButton ID="link_financorporate" runat="server" OnClick="link_financorporate_Click"> 
                      <div class="MenuFCA">
                <img src="../Theme/assets/img/icons/finance_ac1.png" />
                          <h3>Financial Accounts Corporate</h3>
                         </div>
                            </asp:LinkButton>
                        </div>

                    </div>
                    <div class="UserBox3" id="branchUserBoxC3" runat="server">
                        <div class="lbl_process">
                            <asp:Label ID="lbl_processname" runat="server"></asp:Label>
                        </div>
                        <div class="Clear"></div>
                        <div class=" FormGroupContent4 boxmodal">

                            <asp:Panel ID="Panel1" runat="server" CssClass="gridpnl">
                                <asp:GridView ID="grd_user" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" DataKeyNames="menuname,modulename" OnRowDataBound="grd_user_RowDataBound" OnRowCreated="grd_user_RowCreated">
                                    <Columns>

                                        <asp:BoundField DataField="uicaption" HeaderText="Screen" />
                                        <asp:BoundField DataField="menuname" HeaderText="menuname" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />

                                        <asp:BoundField DataField="modulename" HeaderText="Product" />
                                        <%-- ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" --%>

                                        <asp:TemplateField>

                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chk_accessAll1" Text="Access" TextAlign="Left" runat="server" ToolTip="Access" onclick="javascript:chk_access1(this);" />
                                            </HeaderTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_access1" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chk_saveAll1" Text="Save" TextAlign="Left" runat="server" ToolTip="Save" onclick="javascript:chk_save1(this);" />
                                            </HeaderTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_save1" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chk_viewAll1" Text="View" TextAlign="Left" runat="server" ToolTip="View" onclick="javascript:chk_view1(this);" />
                                            </HeaderTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_view1" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chk_deleteAll1" Text="Delete" TextAlign="Left" ToolTip="Delete" runat="server" onclick="javascript:chk_delete1(this);" />
                                            </HeaderTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_delete1" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chk_updAll1" Text="Update" TextAlign="Left" ToolTip="Update" runat="server" onclick="javascript:chk_upd1(this);" />
                                            </HeaderTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_upd1" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />

                                </asp:GridView>
                                <%-- <asp:GridView ID="Grid_corpora" runat="server" AutoGenerateColumns="False"  Width="100%" CssClass="Grid FixedHeader"  DataKeyNames="menuname,modulename"  >
            <Columns>
               
                <asp:BoundField DataField="uicaption" HeaderText="Screen" />
                <asp:BoundField DataField="menuname" HeaderText="menuname"  ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                
                  <asp:BoundField DataField="modulename" HeaderText="Branch" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"  />
             
                <asp:TemplateField >
                   
                        <HeaderTemplate >
                            <asp:CheckBox ID="chk_accessAll"  Text="Access" TextAlign="Left" runat="server"  ToolTip="Access" onclick="javascript:chk_access(this);"/>
                        </HeaderTemplate>
                     <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chk_access" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField >
                        <HeaderTemplate>
                            <asp:CheckBox ID="chk_saveAll" Text="Save" TextAlign="Left" runat="server" ToolTip="Save" onclick="javascript:chk_save(this);"/>
                        </HeaderTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chk_save" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField >
                        <HeaderTemplate>
                            <asp:CheckBox ID="chk_viewAll" Text="View" TextAlign="Left" runat="server" ToolTip="View" onclick="javascript:chk_view(this);"/>
                        </HeaderTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chk_view" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField >
                        <HeaderTemplate>
                            <asp:CheckBox ID="chk_deleteAll" Text="Delete" TextAlign="Left" ToolTip="Delete" runat="server" onclick="javascript:chk_delete(this);"/>
                        </HeaderTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chk_delete" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField >
                        <HeaderTemplate>
                            <asp:CheckBox ID="chk_updAll" Text="Update" TextAlign="Left" ToolTip="Update" runat="server" onclick="javascript:chk_upd(this);"/>
                        </HeaderTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chk_upd" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
        </asp:GridView>--%>

                                <asp:GridView ID="Gridbranch" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader" DataKeyNames="menuname,modulename" OnRowDataBound="Gridbranch_RowDataBound" OnRowCreated="Gridbranch_RowCreated">
                                    <Columns>

                                        <asp:BoundField DataField="uicaption" HeaderText="Screen" />
                                        <asp:BoundField DataField="menuname" HeaderText="menuname" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />

                                        <asp:BoundField DataField="modulename" HeaderText="Branch" />

                                        <asp:TemplateField>

                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chk_accessAll" Text="Access" TextAlign="Left" runat="server" ToolTip="Access" onclick="javascript:chk_access(this);" />
                                            </HeaderTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_access" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chk_saveAll" Text="Save" TextAlign="Left" runat="server" ToolTip="Save" onclick="javascript:chk_save(this);" />
                                            </HeaderTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_save" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chk_viewAll" Text="View" TextAlign="Left" runat="server" ToolTip="View" onclick="javascript:chk_view(this);" />
                                            </HeaderTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_view" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chk_deleteAll" Text="Delete" TextAlign="Left" ToolTip="Delete" runat="server" onclick="javascript:chk_delete(this);" />
                                            </HeaderTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_delete" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chk_updAll" Text="Update" TextAlign="Left" ToolTip="Update" runat="server" onclick="javascript:chk_upd(this);" />
                                            </HeaderTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_upd" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />

                                    <%--<AlternatingRowStyle CssClass="GrdRowStyle" /> 
                <HeaderStyle CssClass="GridviewScrollHeader" /> 
            <RowStyle CssClass="GridviewScrollItem" /> --%>
                                </asp:GridView>

                            </asp:Panel>
                        </div>
                    </div>

               
                </div>

            </div>

        </div>
    </div>
    <asp:HiddenField ID="hf_branchid" runat="server" />
    <asp:HiddenField ID="hf_employeeid" runat="server" />
    <asp:HiddenField ID="hf_employeeid1" runat="server" />
    <asp:HiddenField ID="hf_employeeid2" runat="server" />
    <asp:HiddenField ID="hid_processid" runat="server" />
    <asp:HiddenField ID="hf_uiid" runat="server" />
    <asp:HiddenField ID="hf_trantype" runat="server" />
    <asp:HiddenField ID="hid_processname" runat="server" />
    <asp:HiddenField ID="hf_employeeidto" runat="server" />
    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label id="lbl_no" runat="server"></label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false"
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
    <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="Image1" BehaviorID="Test1">
    </asp:ModalPopupExtender>


<%--            <asp:label id="lblcrm" runat="server"></asp:label>
        <asp:modalpopupextender id="PopupBL" runat="server" targetcontrolid="lblcrm" behaviorid="programmaticModalPopupBehavior3"
            popupcontrolid="popupfro" drag="true"
            backgroundcssclass="modalBackground" cancelcontrolid="imgcroks">
        </asp:modalpopupextender>

        <asp:panel id="popupfro" runat="server" bordercolor="ActiveBorder" cssclass="modalPopup" borderstyle="Solid" borderwidth="2px" style="display: none;">
            <div class="divRoated">
                <div class="FormGroupContent4">
                    
                </div>
                <div class="DivSecPanel ico-close-sm">

                        <asp:Button ID="imgcroks" runat="server"  UseSubmitBehavior="FALSE" Style="height: 100%; width: 100%;" OnClick="imgcroks_Click" />

                </div>

                <asp:Panel ID="Panel31" runat="server" CssClass=" ">
                    <iframe id="iframecost" runat="server" frameborder="0" src="" visible="true" style="background-color: #FFFFF"></iframe>

                </asp:Panel>
                <div class="divBk"></div>
            </div>
        </asp:panel>--%>
</asp:Content>
