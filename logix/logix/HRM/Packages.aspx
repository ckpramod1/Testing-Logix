<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="Packages.aspx.cs" Inherits="logix.HRM.Packages" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
     <link href="../Theme/newTheme/css/systemnewdeign.css" rel="stylesheet" />
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">

    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>



    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>
    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>





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



    <link href="../Styles/Packages.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {

                $("#<%=txt_basic.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        return;
                    }
                });
                $("#<%=txt_hra.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        return;
                    }
                });
                $("#<%=txt_loyality.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        return;
                    }
                });
                $("#<%=txt_lunchallow.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        return;
                    }
                });
                $("#<%=txt_conveyance.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        return;
                    }
                });
                $("#<%=txt_entertain.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        return;
                    }
                });
                $("#<%=txt_otherallow.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        return;
                    }
                });
                $("#<%=txt_others.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        return;
                    }
                });
                $("#<%=txt_driverallow.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        return;
                    }
                });
                $("#<%=txt_medical.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        return;
                    }
                });


                $("#<%=txt_bonus.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail_Com();
                    }
                    else {
                        alertify.alert("Please Enter Numeric Values");
                        var strval = $("#<%=txt_bonus.ClientID %>").val();
                        var strText = strval.substr(0, strval.length - 1)
                        $("#<%=txt_bonus.ClientID %>").val(strText);
                        return false;
                    }
                });
                $("#<%=txt_ComOthers.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail_Com();
                    }
                    else {
                        alertify.alert("Please Enter Numeric Values");
                        var strval = $("#<%=txt_ComOthers.ClientID %>").val();
                        var strText = strval.substr(0, strval.length - 1)
                        $("#<%=txt_ComOthers.ClientID %>").val(strText);
                        return false;
                    }
                });

                $("#<%=txt_petrol.ClientID %>").keyup(function () {
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
                $("#<%=txt_datacard.ClientID %>").keyup(function () {
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
                $("#<%=txt_driverwage.ClientID %>").keyup(function () {
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

                $("#<%=txt_Allowmobile.ClientID %>").keyup(function () {
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
                $("#<%=txt_phonesres.ClientID %>").keyup(function () {
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
                $("#<%=txt_vma.ClientID %>").keyup(function () {
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
                $("#<%=txt_Allowothers.ClientID %>").keyup(function () {
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
                $("#<%=txt_car.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        if ((parseInt($(this).val(), 10) <= 1600)) {
                            $("#<%=txt_AllowAmount.ClientID %>").val(21600);
                        }
                        else if ((parseInt($(this).val(), 10) > 1600)) {
                            $("#<%=txt_AllowAmount.ClientID %>").val(32200);
                        }
                        else {
                            $("#<%=txt_AllowAmount.ClientID %>").val(0);
                        }
                }
                else {
                    alertify.alert("Please Enter Numeric Values");
                    var strval = $(this).val();
                    var strText = strval.substr(0, strval.length - 1)
                    $(this).val(strText);
                    return false;
                }
                });

            });
        $(document).ready(function () {
            function GetDetail() {
                SValue = new Array();
                SValue[0] = $("#<%=txt_basic.ClientID %>").val();
                SValue[1] = $("#<%=txt_hra.ClientID %>").val();
                SValue[2] = $("#<%=txt_loyality.ClientID %>").val();
                SValue[3] = $("#<%=txt_lunchallow.ClientID %>").val();
                SValue[4] = $("#<%=txt_conveyance.ClientID %>").val();
                SValue[5] = $("#<%=txt_entertain.ClientID %>").val();
                SValue[6] = $("#<%=txt_otherallow.ClientID %>").val();
                SValue[7] = $("#<%=txt_others.ClientID %>").val();
                SValue[8] = $("#<%=txt_driverallow.ClientID %>").val();
                SValue[9] = $("#<%=txt_medical.ClientID %>").val();
                $.ajax({
                    type: "POST",
                    url: "../HRM/Packages.aspx/GetTotal",
                    data: '{Prefix: "' + SValue + '" }',
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (response) {
                        $("#<%=txt_totalsalary.ClientID %>").val(response.d);
                        },
                        failure: function (response) {
                            alertify.alert(response.d);
                        }
                    });
                    }
        });
                $(document).ready(function () {
                    function GetDetail_Allowance() {
                        SValue = new Array();
                        SValue[0] = $("#<%=txt_petrol.ClientID %>").val();
                    SValue[1] = $("#<%=txt_datacard.ClientID %>").val();
                    SValue[2] = $("#<%=txt_driverwage.ClientID %>").val();
                    SValue[3] = $("#<%=txt_Allowmobile.ClientID %>").val();
                    SValue[4] = $("#<%=txt_phonesres.ClientID %>").val();
                    SValue[5] = $("#<%=txt_vma.ClientID %>").val();
                    SValue[6] = $("#<%=txt_Allowothers.ClientID %>").val();

                    $.ajax({
                        type: "POST",
                        url: "../HRM/Packages.aspx/GetTotal",
                        data: '{Prefix: "' + SValue + '" }',
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function (response) {
                            $("#<%=Txt_AllowTotal.ClientID %>").val(response.d);
                        },
                        failure: function (response) {
                            alertify.alert(response.d);
                        }
                    });
                    }
            });
                $(document).ready(function () {
                    function GetDetail_Com() {
                        SValue = new Array();
                        SValue[0] = $("#<%=txt_bonus.ClientID %>").val();
                    SValue[1] = $("#<%=txt_ComOthers.ClientID %>").val();
                    $.ajax({
                        type: "POST",
                        url: "../HRM/Packages.aspx/GetTotal",
                        data: '{Prefix: "' + SValue + '" }',
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function (response) {
                            $("#<%=txt_ComTotal.ClientID %>").val(response.d);
                        },
                        failure: function (response) {
                            alertify.alert(response.d);
                        }
                    });
                    }
            });

            }

    </script>

    <style type="text/css">
        .hide {
            display: none;
        }

        .uppercase {
            text-transform: uppercase;
        }

        .Div_Tab1 {
            border: 0px solid #b1b1b1;
            float: left;
            height: 400px;
            margin: -1px 0 0;
            padding: 10px 0px;
            width: 100%;
        }


        .div_Grid {
            border: 1px solid #b1b1b1;
            float: left;
            height: 247px;
            margin-bottom: 1%;
            margin-left: 0;
            margin-top: 1%;
            overflow: auto;
            width: 100%;
        }

        .div_AllowGrid {
            float: left;
            height: 267px;
            margin-left: 0;
            margin-top: 0;
            overflow: auto;
            width: 100%;
        }

        .PackToCal {
    float: right;
    margin: 0 0 0 0;
    width: 7.5%;
}

            .PackToCal input {
                text-align:left!important;
            }






        .PackFromCal {
    float: left;
    margin: 0 0.5% 0 0;
    width: 6.5%;
}

        .PackFromCalF {
    float: right;
    margin: 0 0.5% 0 0;
    width: 6.5%;
}


        .PackFromCalF1 {
    float: right;
    margin: 0 0.5% 0 0;
    width: 6.5%;
}
.PackFromCalA1{
    float: right;
    margin: 0 0.5% 0 0;
    width: 6.5%;
}

        .PackName {
    float: left;
    margin: 0 0.5% 0 0;
    width: 28%;
}
        .PackNameE {
             float: left;
    margin: 0 0.5% 0 0;
    width: 27.5%;

        }
        .PackFromCal1 {
    float: left;
    margin: 0 0 0 0;
    width: 6.5%;
}

              .PackFromCalT1 {
    float: right;
    margin: 0 0 0 0;
    width: 6.5%;
}
.PackTotal {
    width: 13.3%;
    float: right;
    margin: 0px 0% 0px 0px;
}

.PackFromCalT11 {
    float: right;
    margin: 0 0 0 0;
    width: 6.5%;
}


        .div_Tab a:hover {
            background-color:#0077c9;
            color:#ffffff!important;
        }
        .PackMedicalI {
    float: left;
    margin: 0 0.5% 0 0;
    width: 6.5%;
}

        .PackMedicalFI{
    float: right;
    margin: 0 0.5% 0 0;
    width: 6.5%;
}




        .PackOthers1 {
    float: left;
    margin: 0 0 0 0;
    width: 6.5%;
}

        .PackOthersF1{
    float: right;
    margin: 0 0 0 0;
    width: 6.5%;
}








        .PackPF {
    float: left;
    margin: 0 0.5% 0 0;
    width: 25%;
}

.div_TabClick {
    padding: 3px 4px;
    border-left: 0px solid #b1b1b1;
    border-top: 0px solid #b1b1b1;
    border-right: 0px solid #b1b1b1;   
    background-color: #ffffff;
    border-bottom: none;
    width: 6%;
    float: left;
    z-index: 9999;
    position: relative;
}
        .div_TabClick a {
            border-bottom:2px solid #f9be0a;
            padding-bottom:3px;
        }


        .div_Tab {   
        border: 0px solid #b1b1b1;
        border-bottom-width: 0px;
        border-bottom-style: solid;
        border-bottom-color: rgb(177, 177, 177);
        border-bottom: none;
        width: auto;
        float: left;
        padding: 5px 30px 0px 0px;
}

        .div_TabClick {
    padding: 5px 30px 0px 0px;
    border-left: 0px solid #b1b1b1;
    border-top: 0px solid #b1b1b1;
    border-right: 0px solid #b1b1b1;
    background-color: #ffffff;
    border-bottom: none;
    width: auto;
    float: left;
    z-index: 9999;
    position: relative;
}

        .div_Tab:hover {
           
            background:transparent;
        }


       .div_Tab a:hover {
    background-color:transparent;
    color: #4e4e4c !important;
     border-bottom:2px solid #f9be0a;
     padding-bottom:3px;
}


.PackArrearLbl {
    width: 32%;
    float: right;
    margin: 22px 0.5% 0px 0%;
}


.div_CompGrid {
    width: 100%;
    float: left;
    margin-left: 0%;
    margin-top: 0%;
    margin-bottom: 0%;
    overflow: auto;
    height: 365px;
    border: 1px solid #9fa7b5;
}

.div_ConGrid {
    width: 100%;
    float: left;
    margin-left: 0%;
    margin-top: 0%;
    margin-bottom: 0%;
    overflow: auto;
    height: 365px;
    border: 1px solid #9fa7b5;
}


.div_AllowGrid {
    float: left;
    height: 330px;
    margin-left: 0;
    margin-top: 0;
    overflow: auto;
    width: 100%;
    border: 1px solid #9fa7b5;
}

.div_LoanGrid {
    width: 100%;
    float: left;
    margin-left: 0%;
    margin-top: 0%;
    overflow: auto;
    height: 320px;
    border: 1px solid #9fa7b5;
}


.PackArearCal {
    width: 24%;
    float: right;
    margin: 0px 0% 0px 5px;
}

        .PackArearCal input {
            text-align:left!important;
        }


.PackOpen {
    width: 15%;
    float: left;
    margin: 20px 0px 0px 4px;
}

.PackMedicalCall {
    width: 21%;
    float: right;
    margin: 0px 0.5% 0px 0px;
}
        .PackMedicalCall input {
            text-align:left!important;
        }

.PackNameLoan {
    float: left;
    margin: 0 0.5% 0 0;
    width: 34%;
}
.PackFromCalLoan{
    float: right;
    margin: 0 0% 0 0;
    width: 6.5%;
}

.PackNameA {
    float: left;
    margin: 0 0.5% 0 0;
    width: 28.8%;
}

.PackFromCalA {
    float: left;
    margin: 0 0.5% 0 0;
    width: 6.5%;
}


.PackEmpCode {
    width: 5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.PackFromCal21 {
    float: right;
    margin: 0 0.5% 0 0%;
    width: 7.5%;
}
.PackNameC {
    float: left;
    margin: 0 0.5% 0 0;
    width: 26.5%;
}

.PackPetrol {
    width: 9.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.PackDataCard {
    width: 9.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.PackDriver {
    width: 9.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.PackBasic {
    width: 9.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.PackPhone {
    width: 9.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.PackLoyallty {
    width: 9.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.PackAmount {
    width: 9.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .PackBasic1 {
            width:9.5%;
            float:left;
            margin:0px 0.5% 0px 0px;

        }
            .PackBasic1 input {
                text-align:left;
            }

            .PackHRA {
    width: 10.6%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
            .PackMedical {
    width: 15.5%;
    float: left;
    margin: 0px 0% 0px 0px;
}

        .MT11 {
            margin-top:11px!important;
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
             width:65%;
             float:left;
             margin:2px 0px 3px 4px;

         }

         .LogHeadLbl label
         {
             color:#af2b1a;
             font-weight:bold;
             font-size:12px;
         }



         .LogHeadJob {
             width:auto;
             float:left;
             margin:0px 0.5% 0px 0px;
         }

         .LogHeadJobInput label {
             font-size:12px;             
            
         }


           .LogHeadJobInput {
             width:15%;
             float:left;
             margin:1px 0.5% 0px 0px;
         }

             .LogHeadJobInput span {
                 color:#1a65af;
                 font-size:12px;
                 margin:4px 0px 0px 0px;
             }




             .LogHeadJobInput label {
                 font-size:12px;
                 font-family:sans-serif;
                 color:#4e4e4c;
             }

             logix_CPH_PanelLog {
             border-width: 2px;
             border-style: solid;
             position: fixed;
             z-index: 100001;
             left: 352px;
             top: 187px !important;
         }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
            <li><a href="#" title="">HRM</a> </li>
            <li class="current">Packages</li>
        </ul>
    </div>
    <!-- Breadcrumbs line End -->

     <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/packages_ic.png" />  <asp:Label ID="lbl_header" runat="server" Text="Packages"></asp:Label>
        
           <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">             
               <div class="FormGroupContent4">
                        <div class="div_Tab" id="div_salary" runat="server">
                            <asp:LinkButton ID="lnk_salary" runat="server" OnClick="lnk_salary_Click">Salary</asp:LinkButton>
                        </div>
                        <div class="div_Tab" id="div_compensation" runat="server">
                            <asp:LinkButton ID="lnk_compensation" runat="server" OnClick="lnk_compensation_Click">Compensation</asp:LinkButton>
                        </div>
                        <div class="div_Tab" id="div_contribution" runat="server">
                            <asp:LinkButton ID="lnk_contribution" runat="server" OnClick="lnk_contribution_Click">Contribution</asp:LinkButton>
                        </div>
                        <div class="div_Tab" id="div_allowance" runat="server">
                            <asp:LinkButton ID="lnk_allowance" runat="server" OnClick="lnk_allowance_Click">Allowances</asp:LinkButton>
                        </div>
                        <div class="div_Tab" id="div_loan" runat="server">
                            <asp:LinkButton ID="lnk_loan" runat="server" OnClick="lnk_loan_Click">Loans & Advances</asp:LinkButton>
                        </div>

                    </div>

                    <asp:Panel ID="Pln_salary" runat="server" CssClass="Div_Tab1" Visible="false">

                        <div class="FormGroupContent4">
                            <div class="PackEmpCode">
                                <div class="LabelWidth">Emp Code</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_empcode" runat="server" placeholder="" ToolTip="Emp Code" AutoPostBack="True" CssClass="form-control" OnTextChanged="txt_empcode_TextChanged" MaxLength="4"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackNameE">
                                <div class="LabelWidth">Name</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_Empname" runat="server" placeholder="" ToolTip="Name" CssClass="form-control"></asp:TextBox></div>
                                
                            </div>
                          
                            <div class="PackToCal">
                                <div class="LabelWidth">Packages To</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_to" runat="server" placeholder="" ToolTip="Packages To" AutoPostBack="True" CssClass="form-control" OnTextChanged="txt_to_TextChanged"></asp:TextBox></div>
                                
                            </div>
                              <div class="PackFromCal21">
                                <div class="LabelWidth">Packages From</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_from" runat="server" AutoPostBack="True" placeholder="" ToolTip="Packages From" CssClass="form-control" OnTextChanged="txt_from_TextChanged"></asp:TextBox></div>
                                
                            </div>
                        </div>
                        <div class="FormGroupContent4">

                            <div class="PackBasic">
                                <div class="LabelWidth">Basic</div>
                                <div class="FieldInput"> <asp:TextBox ID="txt_basic" runat="server" placeholder="" ToolTip="Basic" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_basic_TextChanged"></asp:TextBox></div>
                               
                            </div>
                            <div class="PackHRA">
                                <div class="LabelWidth">HRA</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_hra" runat="server" placeholder="" ToolTip="HRA" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_hra_TextChanged"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackLoyallty" style="display: none;">
                                <asp:TextBox ID="txt_loyality" runat="server" placeholder="" ToolTip="Loyality" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_loyality_TextChanged"></asp:TextBox>
                            </div>
                            <div class="PackBasic">
                                <div class="LabelWidth">Lunch Allow</div>
                                <div class="FieldInput"> <asp:TextBox ID="txt_lunchallow" runat="server" placeholder="" ToolTip="Lunch Allow" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_lunchallow_TextChanged"></asp:TextBox></div>
                               
                            </div>
                            <div class="PackConvey">
                                <div class="LabelWidth">Conveyance</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_conveyance" runat="server" Style="text-align: right;" placeholder="" ToolTip="Conveyance" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_conveyance_TextChanged"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackEntertain">
                                <div class="LabelWidth">Entertain Allow</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_entertain" runat="server" placeholder="" ToolTip="Entertain Allow" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_entertain_TextChanged"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackBasic">
                                <div class="LabelWidth">Other Allow</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_otherallow" runat="server" placeholder="" ToolTip="Other Allow" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_otherallow_TextChanged"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackHRA">
                                <div class="LabelWidth">Others</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_others" runat="server" placeholder="" ToolTip="Others" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_others_TextChanged"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackLoyallty">
                                <div class="LabelWidth">Driver Allow</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_driverallow" runat="server" placeholder="" ToolTip="Driver Allow" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_driverallow_TextChanged"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackMedical">
                                <div class="LabelWidth">Medical</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_medical" runat="server" placeholder="" ToolTip="Medical" CssClass="form-control" OnTextChanged="txt_medical_TextChanged" AutoPostBack="true"></asp:TextBox></div>
                                
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="right_btn MT0">
                                <div class="PackArearCal">
                                    <div class="LabelWidth">Arrear Take On</div>
                                    <asp:TextBox ID="txt_arreartaken" runat="server" placeholder="" ToolTip="Arrear Take On" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="PackMedicalCall">
                                    <div class="LabelWidth">Effect From</div>
                                    <div class="FieldInput"><asp:TextBox ID="txt_effectivefrom" runat="server" placeholder="" ToolTip="Effect From" CssClass="form-control"></asp:TextBox></div>
                                    
                                </div>

                                <div class="PackArrearLbl">
                                    <asp:CheckBox ID="Chk_Arrear" runat="server" Checked="true" Text="Arrear Taken Yes/No" />
                                </div>


                            </div>
                        </div>


                        <div class="FormGroupContent4">
                            <div class="PackTotalsal">
                                <div class="LabelWidth">Total Salary</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_totalsalary" runat="server" Style="text-align: right;" placeholder="" ToolTip="Total Salary" CssClass="form-control" OnTextChanged="txt_totalsalary_TextChanged"></asp:TextBox></div>
                                
                            </div>                         
                            <div class="right_btn MT11">
                                <div class="btn btn-appointment1">
                                    <asp:Button ID="btn_appointment" runat="server" ToolTip="Appointment Letter" OnClick="btn_appointment_Click" />
                                </div>
                                <div class="btn ico-save" id="btn_save1" runat="server">
                                    <asp:Button ID="btn_save" runat="server" ToolTip="Save" Enabled="False" OnClick="btn_save_Click" />
                                </div>
                                <div class="btn ico-view">
                                    <asp:Button ID="btn_view" runat="server" ToolTip="View" OnClick="btn_view_Click" Enabled="False" />
                                </div>
                                <div class="btn ico-delete">
                                    <asp:Button ID="btn_delete" runat="server" ToolTip="Delete" Enabled="False" OnClick="btn_delete_Click" />
                                </div>
                                <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                    <asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click" />
                                </div>

                            </div>
                           
                           
                              
                        </div>



                        <asp:Panel ID="grd_pack" runat="server" class="div_Grid">
                            <asp:GridView ID="Grd_Package" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl"
                                Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="True"
                                OnSelectedIndexChanged="Grd_Package_SelectedIndexChanged" OnRowDataBound="Grd_Package_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="sfrom" HeaderText="From" />
                                    <asp:BoundField DataField="sto" HeaderText="To" />

                                    <asp:BoundField DataField="basic" HeaderText="Basic" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="hra" HeaderText="HRA" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="sallowence" HeaderText="OtherAll" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="lallowence" HeaderText="LAllow" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="conveyance" HeaderText="Convey" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="loyality" HeaderText="Loyality" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="entertainallow" HeaderText="En.Allow" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="driverallow" HeaderText="DriverAll" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="others" HeaderText="Others" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="medical" HeaderText="Medical" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="efrom" HeaderText="Eff.From" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                    <asp:BoundField DataField="arrtakeon" HeaderText="Arr.TakeOn" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                    <asp:BoundField DataField="archeck" HeaderText="Arr.Take" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Lnk_Select" runat="server" CommandName="select" Font-Underline="false"
                                                CssClass="Arrow">⇛</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>
                    </asp:Panel>



                    <asp:Panel ID="pln_compensation" runat="server" CssClass="Div_Tab1" Visible="false">

                        <div class="FormGroupContent4">
                            <div class="PackEmpCode">
                                <div class="LabelWidth">Emp Code</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_ComEmpCode" runat="server" placeholder="" ToolTip="Emp Code" ReadOnly="True" CssClass="form-control"></asp:TextBox></div>
                                

                            </div>
                            <div class="PackNameC">
                                <div class="LabelWidth">Name</div>
                                <div class="FieldInput"> <asp:TextBox ID="txt_ComEmpName" runat="server" placeholder="" ToolTip="Name" ReadOnly="True" CssClass="form-control"></asp:TextBox></div>
                               

                            </div>

                            
                            <div class="PackFromCalT1">
                                <div class="LabelWidth">To</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_ComTo" runat="server" placeholder="" ToolTip="To" Enabled="False" CssClass="form-control"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackFromCalF1">
                                <div class="LabelWidth">From</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_ComFrom" runat="server" placeholder="" ToolTip="From" Enabled="False" CssClass="form-control"></asp:TextBox></div>
                                
                            </div>
                        </div>

                        <div class="FormGroupContent4">
                            <div class="PackBonus">
                                <div class="LabelWidth">Bonus</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_bonus" runat="server" Style="text-align: right;" placeholder="" ToolTip="Bonus" CssClass="form-control" OnTextChanged="txt_bonus_TextChanged" AutoPostBack="true"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackLTA">
                                <div class="LabelWidth">LTA</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_lta" runat="server" Style="text-align: right;" placeholder="" ToolTip="LTA" ReadOnly="True" AutoPostBack="true" CssClass="form-control" OnTextChanged="txt_lta_TextChanged"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackMedicalI">
                                <div class="LabelWidth">Medical</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_ComMedical" runat="server" Style="text-align: right;" placeholder="" ToolTip="Medical" ReadOnly="True" CssClass="form-control" OnTextChanged="txt_ComMedical_TextChanged" AutoPostBack="true"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackOthers">
                                <div class="LabelWidth">Others</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_ComOthers" runat="server" Style="text-align: right;" placeholder="" ToolTip="Others" CssClass="form-control" OnTextChanged="txt_ComOthers_TextChanged" AutoPostBack="true"></asp:TextBox></div>
                                
                            </div>

                            <div class="PackLoyallty">
                                <div class="LabelWidth">Loyality</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_comloyality" runat="server" placeholder="" ToolTip="Loyality" Enabled="False" CssClass="form-control" OnTextChanged="txt_comloyality_TextChanged" AutoPostBack="true"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackTotal">
                                <div class="LabelWidth">Total</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_ComTotal" runat="server" placeholder="" ToolTip="Total" CssClass="form-control"></asp:TextBox></div>
                                
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="div_CompGrid">
                                <asp:GridView ID="Grd_Compensation" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl"
                                    Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="True" OnRowDataBound="Grd_Compensation_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="acfrom" HeaderText="From" />
                                        <asp:BoundField DataField="acto" HeaderText="To" />
                                        <asp:BoundField DataField="lta" HeaderText="LTA" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="medical" HeaderText="Medical" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="bonus" HeaderText="Bonus" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="others" HeaderText="Others" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </div>


                        </div>


                    </asp:Panel>



                    <asp:Panel ID="Pln_contribution" runat="server" CssClass="Div_Tab1" Visible="false">



                        <div class="FormGroupContent4">
                            <div class="PackEmpCode">
                                <div class="LabelWidth">Emp Code</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_ConEmpCode" runat="server" placeholder="" ReadOnly="True" ToolTip="Emp Code" CssClass="form-control"></asp:TextBox></div>
                                

                            </div>

                            <div class="PackName">
                                <div class="LabelWidth">Name</div>
                                <div class="FieldInput"> <asp:TextBox ID="txt_ConEmpname" runat="server" placeholder="" ToolTip="Name" ReadOnly="True" CssClass="form-control"></asp:TextBox></div>
                               

                            </div>
                             <div class="PackOthersF1">
                                <div class="LabelWidth">To</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_ConTo" runat="server" placeholder="" ToolTip="To" Enabled="False" CssClass="form-control"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackMedicalFI">
                                <div class="LabelWidth">From</div>

                                <div class="FieldInput"><asp:TextBox ID="txt_ConFrom" runat="server" placeholder="" ToolTip="From" Enabled="False" CssClass="form-control"></asp:TextBox></div>
                                
                            </div>
                           
                        </div>
                        <div class="FormGroupContent4">
                            <div class="PackPF">
                                <div class="LabelWidth">PF</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_pf" runat="server" placeholder="" Style="text-align: right;" ToolTip="PF" ReadOnly="True" CssClass="form-control"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackBonus">
                                <div class="LabelWidth">ESI</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_esi" runat="server" placeholder="" Style="text-align: right;" ToolTip="ESI" ReadOnly="True" CssClass="form-control"></asp:TextBox></div>
                                
                            </div>



                        </div>

                        <div class="FormGroupContent4">
                            <div class="div_ConGrid">
                                <asp:GridView ID="Grd_Contribution" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl"
                                    Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="True" OnRowDataBound="Grd_Contribution_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="cfrom" HeaderText="From" />
                                        <asp:BoundField DataField="cto" HeaderText="To" />
                                        <asp:BoundField DataField="pf" HeaderText="PF" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="esi" HeaderText="E S I" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </div>

                        </div>


                    </asp:Panel>


                    <asp:Panel ID="Pln_allowance" runat="server" CssClass="Div_Tab1" Visible="false">


                        <div class="FormGroupContent4">
                            <div class="PackEmpCode">
                                <div class="LabelWidth">Emp Code</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_AllowEmpcode" runat="server" placeholder="" ToolTip="Emp Code" CssClass="form-control"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackNameA">
                                <div class="LabelWidth">Name</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_AllowEmpname" runat="server" placeholder="" ToolTip="Name" CssClass="form-control"></asp:TextBox></div>
                                
                            </div>
                             <div class="PackFromCalT11">
                                <div class="LabelWidth">To</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_Allowto" runat="server" Style="text-align: right;" placeholder="" ToolTip="To" Enabled="False" CssClass="form-control"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackFromCalA1">
                                <div class="LabelWidth">From</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_Allowfrom" runat="server" Style="text-align: right;" placeholder="" ToolTip="From" Enabled="False" CssClass="form-control"></asp:TextBox></div>
                                
                            </div>
                           
                        </div>

                        <div class="FormGroupContent4">
                            <div class="PackPetrol">
                                <div class="LabelWidth">Petrol</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_petrol" runat="server" Style="text-align: right;" placeholder="" ToolTip="Petrol" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_petrol_TextChanged"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackDataCard">
                                <div class="LabelWidth">Datacard</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_datacard" runat="server" Style="text-align: right;" placeholder="" ToolTip="Datacard" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_datacard_TextChanged"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackDriver">
                                <div class="LabelWidth">Driver Wages</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_driverwage" runat="server" Style="text-align: right;" placeholder="" ToolTip="Driver Wages" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_driverwage_TextChanged"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackBasic1">
                                <div class="LabelWidth">Mobile</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_Allowmobile" runat="server" placeholder="" ToolTip="Mobile" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_Allowmobile_TextChanged"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackPhone">
                                <div class="LabelWidth">PhoneRes</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_phonesres" runat="server" Style="text-align: right;" placeholder="" ToolTip="PhoneRes" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_phonesres_TextChanged"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackLoyallty">
                                <div class="LabelWidth">VMA</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_vma" runat="server" Style="text-align: right;" placeholder="" ToolTip="VMA" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_vma_TextChanged"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackBasic">
                                <div class="LabelWidth">Others</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_Allowothers" runat="server" Style="text-align: right;" placeholder="" ToolTip="Others" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_Allowothers_TextChanged"></asp:TextBox></div>
                                
                            </div>

                            <div class="PackBasic">
                                <div class="LabelWidth">CarCC</div>
                                <div class="FieldInput"> <asp:TextBox ID="txt_car" runat="server" placeholder="" Style="text-align: right;" ToolTip="CarCC" MaxLength="5" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_car_TextChanged"></asp:TextBox></div>
                               
                            </div>
                            <div class="PackAmount">
                                <div class="LabelWidth">Amount</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_AllowAmount" runat="server" placeholder="" Style="text-align: right;" ToolTip="Amount" ReadOnly="True" CssClass="form-control"></asp:TextBox></div>
                                
                            </div>
                            <div class="AlowanceTotal">
                                <div class="LabelWidth">Total</div>
                                <div class="FieldInput"><asp:TextBox ID="Txt_AllowTotal" runat="server" placeholder="" Style="text-align: right;" ToolTip="Total" ReadOnly="True" CssClass="form-control" OnTextChanged="Txt_AllowTotal_TextChanged"></asp:TextBox></div>
                                
                            </div>
                        </div>


                        <div class="FormGroupContent4">
                            <div class="right_btn MT0 MB05">
                                <div class="btn ico-save" id="btn_AllowanceSave1" runat="server">
                                    <asp:Button ID="btn_AllowanceSave" runat="server" ToolTip="Save" Enabled="False" OnClick="btn_AllowanceSave_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="FormGroupContent4">

                            <div class="div_AllowGrid">
                                <asp:GridView ID="Grd_Allowance" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl"
                                    Width="100%" ForeColor="Black" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="True"
                                    DataKeyNames="mcamt">
                                    <Columns>
                                        <asp:BoundField DataField="afrom" HeaderText="From" />
                                        <asp:BoundField DataField="ato" HeaderText="To" />
                                        <asp:BoundField DataField="petrol" HeaderText="Petrol" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="mobile" HeaderText="Mobile" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="phoner" HeaderText="Phone" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="datacard" HeaderText="DataCard" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="vma" HeaderText="VMA" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="driverwages" HeaderText="D.Wages" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="mc" HeaderText="MotorCar" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="mcamt" HeaderText="DriverAll" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="others" HeaderText="Others" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </div>
                        </div>


                    </asp:Panel>


                    <asp:Panel ID="Pln_loan" runat="server" CssClass="Div_Tab1" Visible="false">

                        <div class="FormGroupContent4">
                            <div class="PackEmpCode">
                                <div class="LabelWidth">Emp Code</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_LoanEmpcode" runat="server" placeholder="" ToolTip="Emp Code" CssClass="form-control"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackNameLoan">
                                <div class="LabelWidth">Name</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_LoanEmpName" runat="server" placeholder="" ToolTip="Name" ReadOnly="True" CssClass="form-control"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackFromCalLoan">
                                <div class="LabelWidth">Taken On</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_takenon" runat="server" placeholder="" ToolTip="Taken On" CssClass="form-control"></asp:TextBox></div>
                                

                            </div>
                        </div>

                        <div class="FormGroupContent4">
                            <div class="PackLoan">
                                <div class="LabelWidth">Loan Amount</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_loanamount" runat="server" Style="text-align: right;" placeholder="" ToolTip="Loan Amount" CssClass="form-control"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackTenure">
                                <div class="LabelWidth">Tenure</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_Tenure" runat="server" Style="text-align: right;" placeholder="" ToolTip="Tenure" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_Tenure_TextChanged"></asp:TextBox></div>
                                
                            </div>

                            <div class="PackRemark">
                                <div class="LabelWidth">Remark</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_remark" runat="server" placeholder="" ToolTip="Remark" CssClass="form-control"></asp:TextBox></div>
                                
                            </div>
                        </div>

                        <div class="FormGroupContent4">
                            <div class="PackEmpCode">
                                <div class="LabelWidth">Total</div>
                                <div class="FieldInput"><asp:TextBox ID="txt_loantotal" runat="server" Style="text-align: right;" ReadOnly="true" placeholder="" ToolTip="Total" CssClass="form-control"></asp:TextBox></div>
                                
                            </div>
                            <div class="PackOpen">
                                <asp:CheckBox ID="cboxClose" runat="server" Checked="true" Text="Open" AutoPostBack="true" OnCheckedChanged="cboxClose_CheckedChanged" />
                            </div>
                            <div class="right_btn MT0 MB05">

                                <div class="btn ico-save">
                                    <asp:Button ID="btn_loanSave" runat="server" ToolTip="Save" OnClick="btn_loanSave_Click" />
                                </div>
                                <div class="btn ico-view">
                                    <asp:Button ID="btn_loanView" runat="server" ToolTip="View" Visible="false" />
                                </div>
                                <div class="btn ico-delete">
                                    <asp:Button ID="btn_loanDelete" runat="server" ToolTip="Delete" OnClick="btn_loanDelete_Click" />
                                </div>
                                <div class="btn ico-cancel">
                                    <asp:Button ID="btn_loanCancel" runat="server" ToolTip="Cancel" OnClick="btn_loanCancel_Click" />
                                </div>
                            </div>




                        </div>
                        <div class="FormGroupContent4">

                            <div class="div_LoanGrid">
                                <asp:GridView ID="Grd_Loan" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl"
                                    Width="100%" ForeColor="Black" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="True"
                                    OnSelectedIndexChanged="Grd_Loan_SelectedIndexChanged" OnRowDataBound="Grd_Loan_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="loanamount" HeaderText="Amount" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="tenure" HeaderText="Tenure" ItemStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="takenon" HeaderText="Taken On" />
                                        <asp:BoundField DataField="remarks" HeaderText="Remarks" ItemStyle-CssClass="uppercase" />
                                        <asp:BoundField DataField="LoanStatus" HeaderText="Status" />
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Lnk_LoanSelect" runat="server" CommandName="select" Font-Underline="false"
                                                    CssClass="Arrow">⇛</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </div>
                        </div>




                    </asp:Panel>
            </div>
         </div>


    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Packages #</label>

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

    
    

    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_from"
        Format="dd/MM/yyyy"></asp:CalendarExtender>
    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_to"
        Format="dd/MM/yyyy"></asp:CalendarExtender>
    <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_effectivefrom"
        Format="dd/MM/yyyy"></asp:CalendarExtender>
    <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_arreartaken"
        Format="dd/MM/yyyy"></asp:CalendarExtender>
    <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_takenon"
        Format="dd/MM/yyyy"></asp:CalendarExtender>

    <asp:HiddenField ID="hid_empid" runat="server" />

     <asp:Label ID="Label3" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label3" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>


</asp:Content>
