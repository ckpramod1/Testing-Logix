<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CostingDetails.aspx.cs" Inherits="logix.ForwardExports.CostingDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
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
    <script type="text/javascript" src="../js/TextField.js"></script>

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

    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>

    <link rel="Stylesheet" href="../Styles/Costingdetails.css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <style type="text/css">
        a img {
            border: none;
        }

        ol li {
            list-style: decimal outside;
        }

        div#container {
            width: 780px;
            margin: 0 auto;
            padding: 1em 0;
        }

        div.side-by-side {
            width: 100%;
            margin-bottom: 1em;
        }

            div.side-by-side > div {
                float: left;
                width: 50%;
            }

                div.side-by-side > div > em {
                    margin-bottom: 10px;
                    display: block;
                }

        .clearfix:after {
            content: "\0020";
            display: block;
            height: 0;
            clear: both;
            overflow: hidden;
            visibility: hidden;
        }

        #Test_foregroundElement {
            left: 1px !important;
            top: 50px !important;
        }

        th {
            position: sticky;
            top: -1px;
        }
    </style>
    <style type="text/css">
        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .GridHeader1 {
            background-color: navy;
            color: White;
            font-family: sans-serif;
            font-size: 11px;
            margin-left: -0.17%;
            margin-top: -1.7%;
            position: absolute;
            width: 1026px;
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

        #logix_CPH_ddl_job_chzn {
            width: 155px !important;
        }

        .row {
            height: 588px !important;
            width: 99% !important;
            overflow: hidden;
        }

        .dropdownproduct {
            width: 50%;
            float: left;
            margin: 0px 1.5% 0px 0px;
        }

        .JobInput10 {
            float: left;
            width: 6.7%;
            margin-left: 79.2%;
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

        .btn-close1 {
            border-radius: 0px;
        }

            .btn-close1 input {
                background: url(../Theme/assets/img/buttonIcon/jobclose_ic.png) no-repeat left top;
                border: medium none;
                line-height: normal;
                color: #4e4e4c !important;
                padding: 5px 0px 6px 28px;
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
            top: 155px !important;
        }

        .Pnl1 {
            background-color: #fff;
            border-color: #b1b1b1;
            border-style: solid;
            border-width: 1px;
            width: 250px;
            height: 100px;
            margin-right: 1%;
            text-align: center;
            top: 21% !important;
        }

        .GridviewScrollHeader th input {
            display: block;
            text-align: center;
            margin: -9px 0px 0px 34px;
        }

        .GridviewScrollHeader th label {
            margin: 0px 0px 0px 0px;
            display: block;
            line-height: 11px;
        }

        .GridviewScrollItem td input {
            margin: 0px 0px 0px 34px;
        }

        .Grid td input {
            margin: 0px 0px 0px 34px;
        }

        .div_Grid1 {
            width: 100%;
            float: left;
            margin-left: 0%;
            border: 0px solid grey !important;
            height: 126px;
            margin-top: 0.5%;
            overflow: auto;
        }

        .div_Grid3 {
            width: 100%;
            float: left;
            margin-left: 0%;
            border: 0px solid grey !important;
            height: 120px;
            margin-top: 0.5%;
            overflow: auto;
        }

        .div_Grid2 {
            width: 100%;
            float: left;
            margin-left: 0%;
            border: 0px solid grey !important;
            height: 90px;
            margin-top: 0.5%;
            overflow: auto;
        }

        .row {
            height: 622px !important;
            width: 99.5% !important;
            overflow: hidden !important;
        }

        .modalPopupssLog1 {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 55.5%;
            height: 246px;
            margin-left: 0%;
            margin-top: -0.9%;
            overflow: auto;
        }

        .DivSecPanelLog1 {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-right: -2%;
            margin-top: 0.5%;
            border-radius: 90px 90px 90px 90px;
            z-index: 999999;
            position: relative;
            float: right;
        }

        .LogHeadLbl1 {
            width: 65%;
            float: left;
            margin: 2px 0px 3px 4px;
            color: #cc0b04 !important;
            font-size: 13px;
            /*color: #af2b1a;*/
        }

        .LogHeadJob1 {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 8px;
        }

        .GridpnlLog1 {
            width: 100%;
        }

        .GridNew1 {
            font-family: sans-serif;
            font-size: 10pt;
            color: Black;
            margin-top: 0px;
            width: 100%;
            margin-left: 11px;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }

        table#logix_CPH_grdclsjob label {
            color: maroon;
        }

        .btn.btn-view1, .btn.btn-confirm1 {
            margin-top: 10px !important;
        }

        table#logix_CPH_grdclsjob th {
            border-right: 0.5px solid #fff;
        }

        input#logix_CPH_grdclsjob_vol_head, input#logix_CPH_grdclsjob_inc_head, input#logix_CPH_grdclsjob_exp_head, input#logix_CPH_grdclsjob_blrelease_head, input#logix_CPH_grdclsjob_port_head {
            display: none;
        }

        div#logix_CPH_hr2 {
            margin-bottom: 5px !important;
        }

        div#UpdatePanel1 {
            /* height: 100vh; */
            height: 88vh;
            overflow-x: hidden;
            overflow-y: auto;
        }
    </style>

    <script type="text/javascript">
        var TotalChkBx;
        var Counter;

        window.onload = function () {
            //Get total no. of CheckBoxes in side the GridView.
            TotalChkBx = parseInt('<%= this.grdclsjob.Rows.Count %>');

            //Get total no. of checked CheckBoxes in side the GridView.
            Counter = 0;
        }

        function vol_head(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
                document.getElementById('<%= this.grdclsjob.ClientID %>');
            var TargetChildControl = "vol";

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

        function inc_head(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
                document.getElementById('<%= this.grdclsjob.ClientID %>');
            var TargetChildControl = "inc";

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
        function exp_head(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
                document.getElementById('<%= this.grdclsjob.ClientID %>');
            var TargetChildControl = "exp";

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
        function blrelease_head(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
                document.getElementById('<%= this.grdclsjob.ClientID %>');
            var TargetChildControl = "blrelease";

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
        function port_head(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
                document.getElementById('<%= this.grdclsjob.ClientID %>');
            var TargetChildControl = "port";

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
        function pageLoad() {

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

     <%--  $(document).ready(function () {
           $('#<%=Grdcost.ClientID%>').gridviewScroll({
                 width: ,
                 height: 70,
                 arrowsize: 30,

                 varrowtopimg: "../images/arrowvt.png",
                 varrowbottomimg: "../images/arrowvb.png",
                 harrowleftimg: "../images/arrowhl.png",
                 harrowrightimg: "../images/arrowhr.png"
             });
         });
       $(document).ready(function () {

            $('#<%=Grd_job.ClientID%>').gridviewScroll({
                width: ,
                height: 150,
                arrowsize: 30,

                varrowtopimg: "../images/arrowvt.png",
                varrowbottomimg: "../images/arrowvb.png",
                harrowleftimg: "../images/arrowhl.png",
                harrowrightimg: "../images/arrowhr.png"
            });
        });
        $(document).ready(function () {
            $('#<%=Grd_FEFI.ClientID%>').gridviewScroll({
                width: ,
                height: 150,
                arrowsize: 30,

                varrowtopimg: "../images/arrowvt.png",
                varrowbottomimg: "../images/arrowvb.png",
                harrowleftimg: "../images/arrowhl.png",
                harrowrightimg: "../images/arrowhr.png"
            });
        });
        $(document).ready(function () {
            $('#<%=Grd_AEAI.ClientID%>').gridviewScroll({
                width: ,
                height: 150,
                arrowsize: 30,

                varrowtopimg: "../images/arrowvt.png",
                varrowbottomimg: "../images/arrowvb.png",
                harrowleftimg: "../images/arrowhl.png",
                harrowrightimg: "../images/arrowhr.png"
            });
        });
        $(document).ready(function () {
            $('#<%=Grd_CH.ClientID%>').gridviewScroll({
                width: ,
                height: 165,
                arrowsize: 30,

                varrowtopimg: "../images/arrowvt.png",
                varrowbottomimg: "../images/arrowvb.png",
                harrowleftimg: "../images/arrowhl.png",
                harrowrightimg: "../images/arrowhr.png"
            });
        });
        $(document).ready(function () {
            $('#<%=Grd_BT.ClientID%>').gridviewScroll({
                width: ,
                height: 165,
                arrowsize: 30,

                varrowtopimg: "../images/arrowvt.png",
                varrowbottomimg: "../images/arrowvb.png",
                harrowleftimg: "../images/arrowhl.png",
                harrowrightimg: "../images/arrowhr.png"
            });
        });
        $(document).ready(function () {
            $('#<%=Grd_POL.ClientID%>').gridviewScroll({
                width: ,
                height: 165,
                arrowsize: 30,

                varrowtopimg: "../images/arrowvt.png",
                varrowbottomimg: "../images/arrowvb.png",
                harrowleftimg: "../images/arrowhl.png",
                harrowrightimg: "../images/arrowhr.png"
            });
        });
        $(document).ready(function () {
            $('#<%=Grd_ICD.ClientID%>').gridviewScroll({
                width: 100%,
                height: 165,
                arrowsize: 30,

                varrowtopimg: "../images/arrowvt.png",
                varrowbottomimg: "../images/arrowvb.png",
                harrowleftimg: "../images/arrowhl.png",
                harrowrightimg: "../images/arrowhr.png"
            });
        });
        $(document).ready(function () {
            $('#<%=grdclsjob.ClientID%>').gridviewScroll({
                width:,
                height: 165,
                //freezesize: 5,
                arrowsize: 30,

                varrowtopimg: "../images/arrowvt.png",
                varrowbottomimg: "../images/arrowvb.png",
                harrowleftimg: "../images/arrowhl.png",
                harrowrightimg: "../images/arrowhr.png"
            });
        });--%>

        }
    </script>

    <style type="text/css">
        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .bordertopNew_1 {
            float: left;
            min-height: 1px;
            margin: 0px 0px 0px 0px;
            border-top: 1px dotted #807f7f;
            width: 100%;
        }

        .Unclosed2 {
            float: left;
            width: 185px;
            margin: 0px 0 0 0px;
        }

        .Unclosed1 {
            float: left;
            width: 5%;
        }

        .div_Grid_2 {
            width: 100%;
            float: left;
            margin-left: 0%;
            border: 0px solid grey !important;
            height: 154px;
            margin-top: 0.5%;
            overflow: auto;
        }

        .JobNo4 span {
            color: #d33a35 !important;
            font-size: 10px;
            margin: 8px 0px 0px 0px;
            display: inline-block;
            font-weight: 600;
        }
        /*New Design - Buttons*/

        div#logix_CPH_div_iframe .widget-content {
            top: 0 !important;
            padding-top: 65px !important;
        }

        .DateCal10 {
            float: right;
            width: 46%;
            margin: 0px;
        }

        .JobNo4 {
            float: right;
            margin: 15px 16px 0px 0px;
        }

        .closedimg {
            float: right;
            width: 2%;
            margin-top: 16px;
        }

        .modalPopupss iframe {
            width: 100% !important;
            height: 90vh !important;
            overflow: auto !important;
            bottom: 0px !important;
            margin: 0 !important;
            border: 0 !important;
        }

        .divleft {
            width: 79%;
            float: left;
            margin: 15px 0.5% 0px 0px;
        }

        .divright {
            width: 20.5%;
            float: left;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            margin: 15px 0px 6px 0px;
        }

        .AgentInput10 {
            width: 100%;
            margin: 0px !important;
        }

        .MLOInputN1 {
            float: left;
            width: 100%;
        }

        .VesselInput6 {
            float: left;
            width: 100%;
            margin: 0px 0px 0px 0px;
        }

        .MBLInput5 {
            float: left;
            width: 100%;
            margin: 0px 0px 0px 0px;
        }

        .ETAInput4 {
            float: left;
            width: 100%;
            margin: 0px 0px 0px 0px;
        }

        .POLInput8 {
            float: left;
            width: 100%;
            margin: 0px 0px 0px 0px;
        }

        .PODInputN1 {
            float: left;
            width: 100%;
            margin: 0px 0px 0px 0px;
        }

        .TextField .inputcolor, .TextField .inputcolor:focus {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
            font-weight: normal !important;
        }

        .divright span {
            background: #80808000 !important;
        }

        input#logix_CPH_txt_mlo, input#logix_CPH_txt_agent, input#logix_CPH_txt_pod, input#logix_CPH_txt_pol, input#logix_CPH_txt_eta, input#logix_CPH_txt_mbl, input#logix_CPH_txt_vsl {
            border: none !important;
        }

        .divright .FormGroupContent4 {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
        }

        .FormGroupContent4 .divright .TextField .chzn-container-single .chzn-single {
            -webkit-box-shadow: 0 0 0 30px #d3d3d336 inset !important;
            border: none;
        }

        .FormGroupContent4 .divright .TextField .chzn-container-single .chzn-single {
            border-bottom: white !important
        }

        input#logix_CPH_txt_date {
            border: none !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- /Breadcrumbs line -->
    <div>

        <div class="col-md-12 maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header" id="labelid" runat="server">
                   
                        <div style="float: left; margin: 0px 0.5% 0px 0px;">
                            <h4 class="hide">
                                <asp:Label ID="lbl_Header" runat="server"></asp:Label>
                            </h4>
                            <div class="crumbs" id="crumbsid" runat="server">
                                <ul id="breadcrumbs" class="breadcrumb">
                                    <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                    <%--<li><a href="#" title="" id="headerlable1" runat="server">Ocean Exports</a> </li>
                                        <li><a href="#" title="" id="headerlabel2" runat="server">Utility</a> </li>--%>
                                    <li class="current"><a href="#" title="" id="HeaderLabel" runat="server">Job P & L / MIS</a> </li>
                                </ul>
                            </div>

                            <!-- Breadcrumbs line -->
                            <%--<div class="crumbs" runat="server">
                            <ul class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                              
                                <li class="current"><a href="#" title="" id="A1" runat="server">Job Closing</a> </li>
                            </ul>
                        </div>--%>
                        </div>

                        <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm">
                            <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                        </div>
                   
                        <div class="FixedButtons">
        <div class="right_btn " id="div_remark" runat="server">

            <div class="btn ico-excel" id="divExport" runat="server">
                <asp:Button ID="btn_Export" runat="server" Text="Export To Excel" ToolTip="Export To Excel" OnClick="btn_Export_Click" />
            </div>
            <div class="btn ico-job-close" id="divupdate" runat="server">
                <asp:Button ID="btn_update" runat="server" Text="Update" ToolTip="Update" OnClick="btn_update_Click" />
            </div>

            <div class="btn btn-reclose1" id="divreclose" runat="server" style="display: none;">
                <asp:Button ID="btn_reclose" runat="server" Text="Reclose" ToolTip="Reclose" OnClick="btn_reclose_Click" Visible="false" />
            </div>
            <div class="btn ico-excel" id="div1" runat="server">
                <asp:Button ID="Button1" runat="server" Text="Export To Excel" ToolTip="Export To Excel" OnClick="btn_Export_Click1" />
            </div>
            <div class="btn ico-view">
                <asp:Button ID="btn_print" runat="server" Text="View" TabIndex="13" ToolTip="View"
                    OnClick="btn_print_Click" />
            </div>


            <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click" />
            </div>
        </div>
    </div>


                </div>
                <div class="widget-content">

                

                    <div class="FormGroupContent4">

                        <div class="closedimg">
                            <asp:Image ID="Image3" runat="server" Width="111%" Height="2%" Visible="false" />
                        </div>
                        <div class="JobNo4">
                            <asp:Label ID="lbl" runat="server"></asp:Label>
                        </div>
                        <div class="JobInput10">
                            <asp:Label ID="Label16" runat="server" Text="Job #"> </asp:Label>

                            <asp:TextBox ID="txt_job" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txt_job_TextChanged" placeholder="" ToolTip="Job #"></asp:TextBox>



                        </div>
                        <asp:LinkButton ID="lnk_job" runat="server" CssClass="anc ico-find-sm" TabIndex="28" OnClick="lnk_job_Click"></asp:LinkButton>


                    </div>
                    <div class="bordertopNew" style="float: right; min-height: 1px; width: 20.7%; box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;"></div>


                    <div class="FormGroupContent4">
                        <div class="divleft">
                            <div class="FormGroupContent4 boxmodal">
                                <asp:Panel ID="pabel_grd" runat="server" CssClass="gridpnl" ScrollBars="auto">
                                    <asp:GridView CssClass="Grid FixedHeader" ID="Grdcost" runat="server" AutoGenerateColumns="False"
                                        Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="true" DataKeyNames="vyear"
                                        OnSelectedIndexChanged="Grdcost_SelectedIndexChanged" OnRowDataBound="Grdcost_RowDataBound" OnPreRender="Grdcost_PreRender">
                                        <Columns>
                                            <asp:BoundField DataField="vtype" HeaderText="Voucher" />
                                            <asp:BoundField DataField="vno" HeaderText="Vou #">
                                                <ItemStyle Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="vdate" HeaderText="Date" />
                                            <asp:BoundField DataField="status" HeaderText="Status" />
                                            <asp:BoundField DataField="blno" HeaderText="BL #" />
                                            <asp:TemplateField HeaderText="Customer / Vendor">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 150px; white-space: nowrap;">
                                                        <asp:Label ID="cname" runat="server" Text='<%# Bind("cname") %>' ToolTip='<%# Bind("cname") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="150px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Against Refno #">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 247px; white-space: nowrap;">
                                                        <asp:Label ID="cname1" runat="server" Text='<%# Bind("AgainstRefno") %>' ToolTip='<%# Bind("AgainstRefno") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Width="100px" Height="25px" />
                                                <ItemStyle Wrap="False" Width="100px" Height="25px" />
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <HeaderStyle Width="150px" />
                                                <ItemStyle HorizontalAlign="Right" Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Custid" HeaderText="Custid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>
                            </div>
                            <div class="FormGroupContent4">
                                <asp:Label ID="Label14" runat="server" Text="Remarks"> </asp:Label>
                                <asp:TextBox ID="txt_remark" runat="server" CssClass="form-control" placeholder="" ToolTip="Remarks"></asp:TextBox>
                            </div>
                            <div class="FormGroupContent4 boxmodal">
                                <asp:Panel ID="P8" runat="server" CssClass="gridpnl" ScrollBars="Vertical" Visible="false">
                                    <asp:GridView CssClass="Grid FixedHeader" ID="grdclsjob" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdclsjob_RowDataBound"
                                        Width="100%" ForeColor="Black" DataKeyNames="jobno,blno" Visible="false" ShowHeaderWhenEmpty="true" OnRowCreated="grdclsjob_RowCreated">
                                        <Columns>
                                            <asp:BoundField DataField="jobno" HeaderText="Job #">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bookingno" HeaderText="Booking #">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="blno" HeaderText="BL #">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="empname" HeaderText="Sales Person">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Vol. Chkd" Visible="false">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="vol_head" Text="Vol. Chkd" runat="server" onclick="javascript:vol_head(this);" />
                                                </HeaderTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="vol" runat="server" AutoPostBack="false" Style="text-align: center;"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Inc. Bkd" Visible="false">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="inc_head" Text="Inc. Bkd" runat="server" onclick="javascript:inc_head(this);" />
                                                </HeaderTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="inc" runat="server" AutoPostBack="false" Style="text-align: center;"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Exp. Bkd" Visible="false">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="exp_head" Text="Exp. Bkd" runat="server" onclick="javascript:exp_head(this);" />
                                                </HeaderTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="exp" runat="server" AutoPostBack="false" Style="text-align: center;"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="BL Released" Visible="false">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="blrelease_head" Text="BL Released" runat="server" onclick="javascript:blrelease_head(this);" />
                                                </HeaderTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="blrelease" runat="server" AutoPostBack="false" Style="text-align: center;"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Port. Conf" Visible="false">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="port_head" Text="Port. Conf" runat="server" onclick="javascript:port_head(this);" />
                                                </HeaderTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="port" runat="server" AutoPostBack="false" Style="text-align: center;"></asp:CheckBox>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Income" HeaderText="Income" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Expense" HeaderText="Expense" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Retention" HeaderText="Retention" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="GridviewScrollHeader" />
                                        <RowStyle CssClass="GridviewScrollItem" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>

                            </div>
                            <div class="FormGroupContent4">
                                <asp:Panel ID="P1" runat="server" CssClass="gridpnl" Visible="false">
                                    <asp:GridView CssClass="Grid FixedHeader" BorderStyle="Solid" ID="Grd_job" runat="server" AutoGenerateColumns="False" OnRowDataBound="Grd_job_RowDataBound" OnSelectedIndexChanged="Grd_job_SelectedIndexChanged"
                                        Width="100%" ForeColor="Black" EmptyDataText="No Record Found">
                                        <Columns>
                                            <asp:BoundField DataField="blno" HeaderText="BL #" />
                                            <asp:BoundField DataField="shipper" HeaderText="Shipper" />
                                            <asp:BoundField DataField="consignee" HeaderText="Consignee" />
                                            <asp:BoundField DataField="income" HeaderText="Billing" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="expense" HeaderText="Cost" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="retention" HeaderText="Revenue" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                    </asp:GridView>
                                </asp:Panel>
                            </div>
                        </div>
                        <div class="divright">

                            <div class="FormGroupContent4">
                                <div class="dropdownproduct fit-content">
                                    <asp:Label ID="Label5" runat="server" Text="Product"> </asp:Label>
                                    <asp:DropDownList ID="ddl_product" AutoPostBack="true" runat="server" Width="100%" AppendDataBoundItems="True" CssClass="chzn-select inputcolor" ToolTip="Product" data-placeholder="Product" OnSelectedIndexChanged="ddl_product_SelectedIndexChanged">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <%--<div class="JobNo4">
      <asp:Label ID="lbl" runat="server"></asp:Label>
  </div>--%>

                                <div class="DateCal10 DateR">
                                    <asp:Label ID="Label6" runat="server" Text="Closed on"> </asp:Label>
                                    <asp:TextBox ID="txt_date" runat="server" CssClass="form-control inputcolor" placeholder="" ToolTip="Closing Date" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="VesselInput6" id="div_vsl" runat="server">
                                    <asp:Label ID="Label7" runat="server" Text="Vessel"> </asp:Label>
                                    <asp:TextBox ID="txt_vsl" runat="server" ReadOnly="True" CssClass="form-control inputcolor" placeholder="" ToolTip="Vessel"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="MBLInput5">
                                    <asp:Label ID="Label8" runat="server" Text="MBL"> </asp:Label>
                                    <asp:TextBox ID="txt_mbl" runat="server" ReadOnly="True" CssClass="form-control inputcolor" placeholder="" ToolTip="MBL"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="ETAInput4">
                                    <asp:Label ID="Label9" runat="server" Text="ETA"> </asp:Label>
                                    <asp:TextBox ID="txt_eta" runat="server" ReadOnly="True" CssClass="form-control inputcolor" placeholder="" ToolTip="ETA"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="POLInput8">
                                    <asp:Label ID="Label10" runat="server" Text="PoL"> </asp:Label>
                                    <asp:TextBox ID="txt_pol" runat="server" ReadOnly="True" CssClass="form-control inputcolor" placeholder="" ToolTip="PoL"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="PODInputN1">
                                    <asp:Label ID="Label11" runat="server" Text="PoD"> </asp:Label>
                                    <asp:TextBox ID="txt_pod" runat="server" ReadOnly="True" CssClass="form-control inputcolor" placeholder="" ToolTip="PoD"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="AgentInput10">
                                    <asp:Label ID="Label12" runat="server" Text="Agent"> </asp:Label>
                                    <asp:TextBox ID="txt_agent" runat="server" ReadOnly="True" CssClass="form-control inputcolor" placeholder="" ToolTip="Agent"></asp:TextBox>
                                </div>
                            </div>
                            <div class="FormGroupContent4">
                                <div class="MLOInputN1">
                                    <asp:Label ID="Label13" runat="server" Text="MLO"> </asp:Label>
                                    <asp:TextBox ID="txt_mlo" runat="server" ReadOnly="True" CssClass="form-control inputcolor" placeholder="" ToolTip="MLO"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>




                    <asp:GridView ID="GridView3" runat="server"></asp:GridView>
                    <div class="bordertopNew hide" id="hr4" runat="server"></div>
                    <div class="FormGroupContent4 boxmodal">
                    </div>
                    <div class="bordertopNew hide" id="hr3" runat="server"></div>
                    <div class="bordertopNew hide " id="hr1" runat="server"></div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="FormGroupContent4 hide">
                            <div class="Unclosed2 DropTop">
                                <asp:Label ID="Label15" runat="server" Text="Job Type"> </asp:Label>
                                <asp:DropDownList ID="ddl_job" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddl_job_SelectedIndexChanged" AutoPostBack="True" CssClass="chzn-select" ToolTip="JOB TYPE" data-placeholder="JOB TYPE">
                                    <%--  <asp:ListItem Text="" Value="0"></asp:ListItem>--%>
                                    <asp:ListItem>Open Jobs</asp:ListItem>
                                    <asp:ListItem>Closed Jobs</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="right_btn">
                                <div class="btn ico-confirm" id="idconfirm" runat="server" style="display: none">
                                    <asp:Button ID="btn_confirm" runat="server" Text="Confirm" ToolTip="Confirm" OnClick="btn_confirm_Click" />
                                </div>
                                <div class="btn ico-view custom-mt-2" id="btn_job_id" runat="server">
                                    <asp:Button ID="btn_job" runat="server" Text="View Unclosed Jobs" ToolTip="View Open Jobs" OnClick="btn_job_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="bordertopNew hide" id="hr2" runat="server"></div>

                    </div>

                    <asp:Panel ID="P2" runat="server" CssClass="panel_05 MB0 hide" ScrollBars="Vertical" Visible="false">
                        <asp:GridView CssClass="Grid FixedHeader" ID="Grd_FEFI" runat="server" AutoGenerateColumns="False"
                            Width="100%" ForeColor="Black" EmptyDataText="No Record Found"
                            Visible="false" ShowHeaderWhenEmpty="true" OnRowDataBound="Grd_FEFI_RowDataBound"
                            OnSelectedIndexChanged="Grd_FEFI_SelectedIndexChanged">
                            <HeaderStyle CssClass="FrozenHeader" />
                            <Columns>
                                <asp:BoundField DataField="jobno" HeaderText="Job #">
                                    <HeaderStyle Width="40px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="JOBTYPENAME" HeaderText="JOB TYPE">
                                    <HeaderStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="vesselname" HeaderText="Vessel">
                                    <HeaderStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="voyage" HeaderText="Voyage">
                                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Agent">
                                    <ItemTemplate>
                                        <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                            <asp:Label ID="customername" runat="server" Text='<%# Bind("customername") %>' ToolTip='<%# Bind("customername") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="true" Width="81px" HorizontalAlign="Center" />
                                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="closedDate" HeaderText="ClosedDate">
                                    <HeaderStyle Width="80px" />
                                </asp:BoundField>

                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="GridHeaderN" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />

                        </asp:GridView>
                    </asp:Panel>

                    <asp:Panel ID="P3" runat="server" CssClass="panel_05" ScrollBars="Vertical" Visible="false">
                        <asp:GridView CssClass="Grid FixedHeader" ID="Grd_AEAI" BorderStyle="Solid" runat="server" AutoGenerateColumns="False"
                            Width="100%" ForeColor="Black" EmptyDataText="No Record Found"
                            Visible="false" ShowHeaderWhenEmpty="true" OnRowDataBound="Grd_AEAI_RowDataBound"
                            OnSelectedIndexChanged="Grd_AEAI_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                <asp:BoundField DataField="flight" HeaderText="Flight" />
                                <asp:BoundField DataField="flightno" HeaderText="Flight #" />
                                <asp:BoundField DataField="customername" HeaderText="Agent" />
                                <asp:BoundField DataField="closedDate" HeaderText="ClosedDate" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                    </asp:Panel>

                    <asp:Panel ID="P4" runat="server" CssClass="panel_05" ScrollBars="Vertical" Visible="false">
                        <asp:GridView CssClass="Grid FixedHeader" ID="Grd_CH" runat="server" AutoGenerateColumns="False"
                            Width="100%" ForeColor="Black" EmptyDataText="No Record Found" OnRowDataBound="Grd_CH_RowDataBound"
                            Visible="false" ShowHeaderWhenEmpty="true"
                            OnSelectedIndexChanged="Grd_CH_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="jobno" HeaderText="Job" />
                                <asp:BoundField DataField="mode" HeaderText="Mode" />
                                <asp:BoundField DataField="principal" HeaderText="Agent" />
                                <asp:BoundField DataField="closedDate" HeaderText="ClosedDate" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                    </asp:Panel>

                    <asp:Panel ID="P5" runat="server" CssClass=" panel_05" ScrollBars="Vertical" Visible="false">
                        <asp:GridView CssClass="Grid FixedHeader" ID="Grd_BT" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"
                            Visible="false" ShowHeaderWhenEmpty="true" OnRowDataBound="Grd_BT_RowDataBound"
                            OnSelectedIndexChanged="Grd_BT_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="jobno" HeaderText="Job" />
                                <asp:BoundField DataField="truckno" HeaderText="Truck" />
                                <asp:BoundField DataField="fromport" HeaderText="From" />
                                <asp:BoundField DataField="toport" HeaderText="To" />
                                <asp:BoundField DataField="etd" HeaderText="ETD" />
                                <asp:BoundField DataField="eta" HeaderText="ETA" />
                                <asp:BoundField DataField="closedDate" HeaderText="ClosedDate" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="GridHeader" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                    </asp:Panel>

                    <asp:Panel ID="P6" runat="server" CssClass="panel_05" ScrollBars="Vertical" Visible="false">
                        <asp:GridView CssClass="Grid FixedHeader" ID="Grd_POL" runat="server" AutoGenerateColumns="False"
                            Width="100%" ForeColor="Black" EmptyDataText="No Record Found"
                            Visible="false" ShowHeaderWhenEmpty="true">
                            <Columns>
                                <asp:BoundField DataField="Vou" HeaderText="Vou" />
                                <asp:BoundField DataField="Type" HeaderText="Type" />
                                <asp:BoundField DataField="BL" HeaderText="BL" />
                                <asp:BoundField DataField="Amount" HeaderText="Amount" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                    </asp:Panel>

                    <asp:Panel ID="P7" runat="server" CssClass="panel_05" ScrollBars="Vertical" Visible="false">
                        <asp:GridView CssClass="Grid FixedHeader" ID="Grd_ICD" runat="server" AutoGenerateColumns="False"
                            Width="100%" ForeColor="Black" EmptyDataText="No Record Found"
                            Visible="false" ShowHeaderWhenEmpty="true">
                            <Columns>
                                <asp:BoundField DataField="Vou" HeaderText="Vou" />
                                <asp:BoundField DataField="Type" HeaderText="Type" />
                                <asp:BoundField DataField="BL" HeaderText="BL" />
                                <asp:BoundField DataField="Amount" HeaderText="Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1" />

                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="GridHeader" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                    </asp:Panel>

                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_date" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>

                    <div class="FormGroupContent4">
                        <asp:Panel ID="pln_popup" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                            <div class="divRoated">
                                <div class="DivSecPanel">
                                    <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                </div>

                                <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="Grd_RowDataBound"
                                        ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" AllowPaging="false" PageSize="16"
                                        OnSelectedIndexChanged="Grd_SelectedIndexChanged" OnPageIndexChanging="Grd_PageIndexChanging" CssClass="Grid FixedHeader">
                                        <Columns>
                                            <asp:BoundField DataField="jobno" HeaderText="Job #">
                                                <HeaderStyle Width="52px" />
                                                <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="52px" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Vessel">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                                        <asp:Label ID="vslvoy" runat="server" Text='<%# Bind("vslvoy") %>' ToolTip='<%# Bind("vslvoy") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="151px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ETA">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                                        <asp:Label ID="ETA" runat="server" Text='<%# Bind("eta") %>' ToolTip='<%# Bind("eta") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="81px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="mblno" HeaderText="MBL">
                                                <HeaderStyle Width="52px" />
                                                <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="52px" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Agent">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                                        <asp:Label ID="agent" runat="server" Text='<%# Bind("agent") %>' ToolTip='<%# Bind("agent") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="121px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="MLO">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 180px">
                                                        <asp:Label ID="MLO" runat="server" Text='<%# Bind("mlo") %>' ToolTip='<%# Bind("mlo") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="180px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="POL">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 105px">
                                                        <asp:Label ID="pol" runat="server" Text='<%# Bind("pol") %>' ToolTip='<%# Bind("pol") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="105px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <RowStyle Font-Italic="False" />
                                        <PagerStyle CssClass="GridviewScrollPager" />
                                    </asp:GridView>

                                    <div class="div_Break"></div>
                                    <asp:GridView ID="CHGrid" runat="server" AllowPaging="false" AutoGenerateColumns="false" Width="100%" OnRowDataBound="CHGrid_RowDataBound"
                                        ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" PageSize="16"
                                        OnSelectedIndexChanged="CHGrid_SelectedIndexChanged" OnPageIndexChanging="CHGrid_PageIndexChanging" CssClass="Grid FixedHeader">
                                        <Columns>
                                            <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                            <asp:BoundField DataField="docno" HeaderText="Doc #" />
                                            <asp:BoundField DataField="docdate" HeaderText="Date" />
                                            <asp:BoundField DataField="mdocno" HeaderText="MDoc #" />
                                            <asp:TemplateField HeaderText="Shipper">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 150px; white-space: nowrap;">
                                                        <asp:Label ID="shipper" runat="server" Text='<%# Bind("shipper") %>' ToolTip='<%# Bind("shipper") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="150px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Consignee">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 150px; white-space: nowrap;">
                                                        <asp:Label ID="consignee" runat="server" Text='<%# Bind("consignee") %>' ToolTip='<%# Bind("consignee") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="150px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="pol" HeaderText="POL" />
                                            <asp:BoundField DataField="pod" HeaderText="POD" />
                                        </Columns>
                                    </asp:GridView>
                                    <div class="div_Break"></div>
                                    <asp:GridView ID="BTGrid" runat="server" AllowPaging="false" AutoGenerateColumns="false" Width="100%" OnRowDataBound="BTGrid_RowDataBound"
                                        ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" PageSize="16"
                                        OnSelectedIndexChanged="BTGrid_SelectedIndexChanged" OnPageIndexChanging="BTGrid_PageIndexChanging" CssClass="Grid FixedHeader">
                                        <Columns>
                                            <asp:BoundField DataField="jobno" HeaderText="Job #" />
                                            <asp:BoundField DataField="truckno" HeaderText="Truck #" />
                                            <asp:BoundField DataField="fromport" HeaderText="From" />
                                            <asp:BoundField DataField="toport" HeaderText="To" />
                                            <asp:BoundField DataField="etd" HeaderText="ETD" />
                                            <asp:BoundField DataField="eta" HeaderText="ETA" />
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </div>
                        </asp:Panel>
                        <div class="div_Break"></div>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                        <asp:ModalPopupExtender ID="popup_Grd" runat="server" PopupControlID="pln_popup" TargetControlID="Label2"
                            CancelControlID="close" BehaviorID="Test" DropShadow="false">
                        </asp:ModalPopupExtender>

                    </div>

                    <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl1" Style="display: none;">
                        <br />
                        <div style="font-size: 10pt"><b>Do you want to close a job?</b></div>
                        <br />
                        <div class="div_confirm1">
                            <asp:Button ID="btn_jobclose" runat="server" Text="Yes" CssClass="Button" OnClick="btn_jobclose_Click" />
                            <asp:Button ID="btn_no" runat="server" Text="No" CssClass="Button" OnClick="btn_no_Click" />
                        </div>
                        <br />
                    </asp:Panel>

                    <asp:ModalPopupExtender ID="PopUpService" runat="server" BackgroundCssClass=""
                        PopupControlID="Panel_Service" TargetControlID="Label1">
                    </asp:ModalPopupExtender>
                    <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>

                    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Job # :</label>

                                </div>
                                <div class="LogHeadJobInput">

                                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                                </div>

                            </div>
                            <div class="DivSecPanel">
                                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>

                            <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">

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

                    <asp:Label ID="Label4" runat="server"></asp:Label>

                    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">

                        <div class="divRoated">
                            <div class="LogHeadLblR header" id="MyHeader8">
                                <div class="DivSecPanel">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                </div>
                                <div class="LogHeadLbl1">
                                    <div class="LogHeadJob1">
                                        <%-- <label>Unclosed job</label>--%>
                                        <asp:Label ID="lblname" runat="server"></asp:Label>

                                    </div>
                                    <div class="LogHeadJobInput">

                                        <asp:Label ID="Label3" runat="server"></asp:Label>

                                    </div>

                                </div>

                                <asp:Panel ID="Panel4" runat="server" CssClass=" Gridpnl">
                                    <%--<div style="width: 103%; height: 6px; overflow: auto;"></div>--%>
                                    <asp:GridView ID="GridView2" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="false"
                                        ForeColor="Black" EmptyDataText="No Record Found" PageSize="20"
                                        BackColor="White">
                                        <Columns>
                                            <asp:BoundField DataField="Voutype" HeaderText="Voutype">
                                                <HeaderStyle Width="100px" Height="25px" />
                                                <ItemStyle Wrap="False" Width="100px" Height="25px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Vouno" HeaderText="Vou#">
                                                <HeaderStyle Width="160px" Height="25px" />
                                                <ItemStyle Wrap="False" Width="160px" Height="25px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Horm" HeaderText="Horm">
                                                <HeaderStyle Width="100px" Height="25px" />
                                                <ItemStyle Wrap="False" Width="100px" Height="25px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="blno" HeaderText="BL #">
                                                <HeaderStyle Width="164px" Height="25px" />
                                                <ItemStyle Wrap="False" Width="164px" Height="25px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Customer Name">
                                                <ItemTemplate>
                                                    <div style="overflow: hidden; text-overflow: ellipsis; width: 195px; white-space: nowrap;">
                                                        <asp:Label ID="Customername" runat="server" Text='<%# Bind("Customername") %>' ToolTip='<%# Bind("Customername") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="true" Width="200px" Height="25px" HorizontalAlign="Center" />
                                                <ItemStyle Wrap="false" HorizontalAlign="Left" Width="200px" Height="25px"></ItemStyle>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Customername" HeaderText="Customername" >                                                                                     
                                            <HeaderStyle  Width="164px" Height="25px"  />
                                            <ItemStyle Wrap="False" Width="164px" Height="25px"  />
                                        </asp:BoundField>--%>
                                            <asp:BoundField DataField="Income" HeaderText="Income" DataFormatString="{0:0.00}">
                                                <HeaderStyle Width="100px" Height="25px" />
                                                <ItemStyle Wrap="False" Width="100px" Height="25px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Expence" HeaderText="Expense" DataFormatString="{0:0.00}">
                                                <HeaderStyle Width="100px" Height="25px" />
                                                <ItemStyle Wrap="False" Width="100px" Height="25px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Retension" HeaderText="Retention" DataFormatString="{0:0.00}">
                                                <HeaderStyle Width="150px" Height="25px" />
                                                <ItemStyle Wrap="False" Width="150px" Height="25px" />
                                            </asp:BoundField>

                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="myGridHeader" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <PagerStyle CssClass="GridviewScrollPager" />
                                    </asp:GridView>
                                </asp:Panel>

                                <div class="Break"></div>
                            </div>
                        </div>

                    </asp:Panel>
                    <div class="Break"></div>

                    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
                        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
                    </asp:ModalPopupExtender>

                    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1"
                        DropShadow="false" TargetControlID="Label3" CancelControlID="image1" BehaviorID="Test2">
                    </asp:ModalPopupExtender>

                </div>
            </div>
        </div>
    </div>
   

    <asp:HiddenField ID="hid_customerid" runat="server" />
    <asp:HiddenField ID="Hid_trantype" runat="server" />
    <asp:HiddenField ID="hid_mblchk" runat="server" Value="N" />
</asp:Content>
