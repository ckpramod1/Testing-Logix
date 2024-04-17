<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AEJobInfo.aspx.cs" Inherits="logix.AE.AEJobInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

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
    <link href="../Styles/VoucherRegister.css" rel="stylesheet" />
    <!--=== JavaScript ===-->

    <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>
    <!-- Smartphone Touch Events -->
    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>


    <!-- App -->
    
    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
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


    <link href="../Styles/AEJobInfo.css" rel="stylesheet" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
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

       

        .ChkBox {
            width: 15%;
            float: left;
            margin: 4px 0px -4px 1%;
        }

        .Grid {
            font-family: sans-serif;
            font-size: 10pt;
            color: Black;
            margin-top: 0px;
        }

        .Gridpnl {
            width: 99%;
            margin: 0 auto;
            border: 1px solid #b1b1b1;
            overflow-y: scroll;
            overflow-x: auto;
            height: 91%;
        }
               .JobGridRight {
    float: left;
    width: 100%;
    margin: 16px 0 0 0;
}
               /*div#logix_CPH_Book2 {
       margin: 10px 0 0 0 !important;
           overflow: hidden !important;
}*/
               div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    width: 100%;
    float: left;
}
               span.chktext {
    margin: 0!important;
}
    </style>

    <style type="text/css"> 
        .TblGridtable {
            border-collapse: collapse;
        }

            .TblGridtable td {
                border: 1px solid #000;
                padding: 2px;
            }
    </style>

    <%--<script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>--%>

    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }


        .Hide {
            display: none;
        }
    </style>
    <style type="text/css">
        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
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

        #Test_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        .FloatLeft {
            width: 40%;
            float: left;
        }


        #logix_CPH_pnl_grd1 {
            width: 100%;
            /*border:1px solid #b1b1b1;*/
            overflow: auto;
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
            width: 11%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LogHeadJobInput label {
            font-size: 12px;
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
        /*.blueheighlight {
            border:1px solid #4286f4!important;
        }*/

        div#logix_CPH_div_body {
            top: -100px;
            margin-top: -432px;
            margin-left: 329px;
            z-index: 999999;
            position: relative;
            background-color: #ffff;
            font-size: 11px;
            width: 100%;
        }

 
        .JobLeftN1 {
            float: left;
            width: 80%;
            margin: 0px 0.5% 0px 0px;
        }

        .JobInput18 {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .JobCal2 {
            width: 13.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .MawblCal {
            width: 13.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .MawblCala {
            width: 13.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .MawblCal2 {
            width: 14.5%;
            float: left;
            margin: 0px 0px 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .AirlineName {
            width: 31.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .BookingGrid {
            height: 100px !important;
            overflow-y: auto !important;
            overflow-x: hidden !important;
        }

        .MawblFNo {
            width: 12%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }


        .Mawbl {
            width: 42.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }
        div#UpdatePanel1 {
    /* height: 100vh; */
    height: 88vh;
    overflow-x: hidden;
    overflow-y: auto;
}

        div#logix_CPH_pnl_grd1 {
    height: calc(100vh - 350px) !important;
    width: 51.6% !important;
}
        .Search {
            font-size: 11px;
            color: #000080;
            width: 100%;
            margin-top: 48px !important;
        }


      

        .JobAgent {
            width: 41.6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .FromInput1 {
            width: 34%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }


        .JobHandling {
            width: 57.9%;
            float: left;
            margin: 0px 0% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .StatusDrop2 {
            width: 21.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .IataInputnew {
            width: 14%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .ToPortInput {
            width: 30%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
            color: #000080;
        }

        .Cargo {
            float: left;
            width: 100%;
            font-size: 11px;
            color: #000080;
        }


        .Grid {
            font-family: sans-serif;
            font-size: 10pt;
            color: Black;
            margin-top: 0px;
        }


        /* {
  position: relative;
  width: 100%;
  overflow: hidden;
  border-collapse: collapse;
}
 thead {
  position: relative;
  display: block;
  width: 100%;
  overflow: visible;
}

 tbody {
  position: relative;
  display: block; 
  width: 100%;
  height: 110px;
  overflow: auto;
}
 tbody tr:nth-child(1){
    border-top:1px solid #b1b1b1;
}




      
 th:nth-child(1) {
  min-width: 50px;
}
 td:nth-child(1) { 
  min-width: 50px;
}


 th:nth-child(2) {
  min-width: 120px;
}
 td:nth-child(2) { 
  min-width: 120px;
}

 th:nth-child(3) {
  min-width: 215px;
}
 td:nth-child(3) { 
    min-width: 214px;
    white-space: nowrap;
    width: 214px!important;
    text-overflow: ellipsis;
    overflow: hidden;
    display: inline-block;
    border-top: 0px solid #b1b1b1;
    border-right: 0px solid #b1b1b1;
    border-left: 0px solid #b1b1b1;
    border-bottom: 1px solid #b1b1b1;
    margin: 0px 0px 0px 0px;
    position: relative;
    height: 22px;

}

 th:nth-child(4) {
  min-width: 225px;
}
 td:nth-child(4) { 
  min-width: 225px;
}

 th:nth-child(5) {
  min-width: 165px;
}
 td:nth-child(5) { 
  min-width: 165px;
}

 th:nth-child(6) {
  min-width: 50px;
}
 td:nth-child(6) { 
  min-width: 50px;
}


 th:nth-child(7) {
  min-width: 50px;
}
 td:nth-child(7) { 
  min-width: 50px;
}

 th:nth-child(8) {
  min-width: 50px;
}
 td:nth-child(8) { 
  min-width: 50px;
}
  
 th:nth-child(9) {
  min-width: 50px;
}
 td:nth-child(9) { 
  min-width: 50px;
}


 th:nth-child(10) {
  min-width: 80px;
}
 td:nth-child(10) { 
  min-width: 80px;
}

 th:nth-child(11) {
  min-width: 100px;
}
 td:nth-child(11) { 
  min-width: 100px;
}

 th:nth-child(12) {
  min-width: 70px;
}
 td:nth-child(12) { 
  min-width: 70px;
}

 th:nth-child(13) {
  min-width: 65px;
}
 td:nth-child(13) { 
  min-width: 65px;
}*/


        /*FixedHedaer2*/


        2 {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
        }

            2 thead {
                position: relative;
                display: block;
                width: 100%;
                overflow: visible;
            }

            2 tbody {
                position: relative;
                display: block;
                width: 100%;
                height: 150px;
                overflow: auto;
            }





            2 th:nth-child(2) {
                min-width: 120px;
            }

            2 td:nth-child(2) {
                min-width: 120px;
            }

            2 th:nth-child(3) {
                min-width: 75px;
            }

            2 td:nth-child(3) {
                min-width: 75px;
            }

            2 th:nth-child(4) {
                min-width: 30px;
            }

            2 td:nth-child(4) {
                min-width: 30px;
            }

        .modalPopup {
            background-color: rgba(0, 0, 0, 0.75);
            width: 100%;
            height: 90%;
            margin-left: 0%;
            margin-top: -1%;
            border: 1px solid #b1b1b1;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .DivSecPanel {
            width: 20px;
            height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: 0%;
            border-radius: 90px 90px 90px 90px;
        }

        .divRoated {
            width: 90%;
            height: 75vh;
            overflow: hidden;
            background: #fff;
            border-radius: 3px;
        }
        input#logix_CPH_txt_search {
    width: 100%;
}
      .boxmodalLink_box {
    float: left;
    margin: 0px !important;
}
      .divleft{
          width:51.5%;
          float:left;
          margin:0px 0.5% 0px 0px
      }
      .divright{
          width:51.5%;
          float:left;
          margin:-49px 0.5% 0px 0px
      }
      .gridpnl {
    height: calc(100vh - 545px);
    border-top: 1px solid var(--inputborder) !important;
    margin: 5px 0px !important;
    overflow: auto !important;
}
        div#logix_CPH_div_iframe .widget-content {
            top: 0 !important;
            padding-top: 45px !important;
        }
        
        .FixedButtons {
    position: fixed;
    top: 30px;
    left: 0;
    background: #fff;
    z-index: 10;
    box-shadow: 0px 0px 20px rgb(0 0 0 / 10%);
    width: calc(100vw - 5px);
    border-bottom: 0.5px solid #00000010;
    padding: 1px 0 5px 0px;
}
      
      
        .left_btn {
    float: left;
    margin: 5px 0px 0px 5px;
}
    </style>


    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            });
            $(document).ready(function () {

                $("#<%=txt_search.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../AE/AEJobInfo.aspx/FE_GetBookingNo",
                            data: "{ 'prefix': '" + request.term + "','job':'" + $("#<%=txt_jobno.ClientID %>").val() + "'}",
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
                            //alert(response.responseText);
                        },
                        failure: function (response) {
                            //alert(response.responseText);
                        }
                    });
                },

                select: function (event, i) {
                    $("#<%=txt_search.ClientID %>").val(i.item.label);
                      $("#<%=txt_search.ClientID %>").change();
                  },
                focus: function (event, i) {
                    $("#<%=txt_search.ClientID %>").val(i.item.label);
                  },
                  change: function (event, i) {
                      $("#<%=txt_search.ClientID %>").val(i.item.label);
                    },
                    close: function (event, i) {
                        $("#<%=txt_search.ClientID %>").val(i.item.label);
                    },
                    minLength: 1
            });
            });



                $(document).ready(function () {


                    $("#<%=txt_airline.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_airlineid.ClientID %>").val(0);
                        $.ajax({
                            url: "../AE/AEJobInfo.aspx/Getcusname",
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
                                //alert(response.responseText);
                            },
                            failure: function (response) {
                                //alert(response.responseText);
                            }

                        });
                    },
                    select: function (event, i) {
                        $("#<%=hf_airlineid.ClientID %>").val(i.item.val);
                        $("#<%=txt_airline.ClientID %>").change();
                    },
                    change: function (event, i) {

                        $("#<%=hf_airlineid.ClientID %>").val(i.item.val);
                        $("#<%=txt_airline.ClientID %>").val(i.item.value);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_airline.ClientID %>").val(i.item.value);
                    },

                    minLength: 1
                });
            });

                $(document).ready(function () {

                    $("#<%=txt_agent.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_agentid.ClientID %>").val(0);
                        $.ajax({
                            url: "../AE/AEJobInfo.aspx/Getagentname",
                            data: "{ 'prefix': '" + request.term + "','strcustype':'P'}",
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
                                //alert(response.responseText);
                            },
                            failure: function (response) {
                                //alert(response.responseText);
                            }

                        });
                    },


                    <%--  select: function (event, i) {
                        $("#<%=txt_agent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hf_agentid.ClientID %>").val(i.item.val);
                        $("#<%=txt_agent.ClientID %>").change();
                        $("#<%=txt_agent.ClientID %>").val(i.item.address);

                    },
                    focus: function (event, i) {
                        $("#<%=txt_agent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hf_agentid.ClientID %>").val(i.item.val);
                        $("#<%=txt_agent.ClientID %>").val($.trim(result));
                        $("#<%=txt_agent.ClientID %>").val(i.item.address);


                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_agent.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_agentid.ClientID %>").val(i.item.val);
                            $("#<%=txt_agent.ClientID %>").val(i.item.address);
                        }

                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_agent.ClientID %>").val().toString();
                         var res = result.substring(0, result.lastIndexOf(' ,'));
                         var out = res.substring(0, res.lastIndexOf(' ,'));
                         if (out != "") {
                             $("#<%=txt_agent.ClientID %>").val($.trim(out));
                        } else {
                            $("#<%=txt_agent.ClientID %>").val($.trim(res));
                        }
                     },--%>
                    select: function (event, i) {
                        $("#<%=txt_agent.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                        $("#<%=txt_agent.ClientID %>").change();
                        $("#<%=hf_agentid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_agent.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                        $("#<%=hf_agentid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_agent.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hf_agentid.ClientID %>").val(i.item.val);
                        }

                    },
                    close: function (event, i) {
                        var result = $("#<%=txt_agent.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txt_agent.ClientID %>").val($.trim(result));
                    },

                    minLength: 1
                });
            });



            $(document).ready(function () {

                $("#<%=txt_from.ClientID %>").autocomplete({

                            source: function (request, response) {
                                $("#<%=hf_intfromid.ClientID %>").val(0);
                                $.ajax({
                                    url: "../AE/AEJobInfo.aspx/Getportname",
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
                                        //alert(response.responseText);
                                    },
                                    failure: function (response) {
                                        //alert(response.responseText);
                                    }

                                });
                            },
                            <%--  select: function (event, i) {
                            $("#<%=hf_intfromid.ClientID %>").val(i.item.val);
                            $("#<%=txt_from.ClientID %>").change();

                        },
                        change: function (event, i) {
                            $("#<%=txt_from.ClientID %>").val(i.item.value);
                        },
                        focus: function (event, i) {

                            $("#<%=txt_from.ClientID %>").val(i.item.value);
                        },--%>


                            select: function (event, i) {
                                $("#<%=txt_from.ClientID %>").val(i.item.label);
                                $("#<%=txt_from.ClientID %>").change();
                                $("#<%=hf_intfromid.ClientID %>").val(i.item.val);
                            },
                            focus: function (event, i) {
                                $("#<%=txt_from.ClientID %>").val(i.item.label);
                                $("#<%=hf_intfromid.ClientID %>").val(i.item.val);
                            },
                            change: function (event, i) {
                                $("#<%=txt_from.ClientID %>").val(i.item.label);
                                $("#<%=hf_intfromid.ClientID %>").val(i.item.val);
                            },
                            close: function (event, i) {
                                $("#<%=txt_from.ClientID %>").val(i.item.label);
                                $("#<%=hf_intfromid.ClientID %>").val(i.item.val);
                            },

                            minLength: 1
                        });
                    });


                    $(document).ready(function () {

                        $("#<%=txt_to.ClientID %>").autocomplete({

                            source: function (request, response) {
                                $("#<%=hf_inttoid.ClientID %>").val(0);
                                $.ajax({
                                    url: "../AE/AEJobInfo.aspx/Getportname",
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
                                        //alert(response.responseText);
                                    },
                                    failure: function (response) {
                                        //alert(response.responseText);
                                    }

                                });
                            },
                            <%-- select: function (event, i) {
                            $("#<%=hf_inttoid.ClientID %>").val(i.item.val);
                            $("#<%=txt_to.ClientID %>").change();

                        },
                        change: function (event, i) {
                            $("#<%=txt_to.ClientID %>").val(i.item.value);
                        },
                        focus: function (event, i) {

                            $("#<%=txt_to.ClientID %>").val(i.item.value);
                        },--%>



                            select: function (event, i) {
                                $("#<%=txt_to.ClientID %>").val(i.item.label);
                                $("#<%=txt_to.ClientID %>").change();
                                $("#<%=hf_inttoid.ClientID %>").val(i.item.val);
                            },
                            focus: function (event, i) {
                                $("#<%=txt_to.ClientID %>").val(i.item.label);
                                $("#<%=hf_inttoid.ClientID %>").val(i.item.val);
                            },
                            change: function (event, i) {
                                $("#<%=txt_to.ClientID %>").val(i.item.label);
                                $("#<%=hf_inttoid.ClientID %>").val(i.item.val);
                            },
                            close: function (event, i) {
                                $("#<%=txt_to.ClientID %>").val(i.item.label);
                                $("#<%=hf_inttoid.ClientID %>").val(i.item.val);
                            },

                            minLength: 1
                        });
                    });
                    $(document).ready(function () {
                        $('input:text:first').focus();
                    });

                }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


    <!-- Breadcrumbs line End -->
    <div>
        <div class="col-md-12">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lblheader" runat="server" Text="Job #"></asp:Label></h4>
                        
    <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Ops & Docs</a> </li>
            <li><a href="#" id="HeaderLabel1" runat="server"></a></li>
            <li class="current"><a href="#" title="">Job Info</a> </li>
        </ul>
    </div>
                    </div>

                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm"> 
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4 FixedButtons">
                        <div class="right_btn">
                            <div class="btn ico-proforma-sales-invoice">
                            <asp:Button ID="Proinvoic" runat="server" Text="Profoma Sales Invoice" ToolTip="Profoma Sales Invoice" TabIndex="22" OnClick="Proinvoic_Click" />
                        </div>
                        <div class="btn ico-proforma-purchase-invoice">
                            <asp:Button ID="procrednote" runat="server" Text="Profoma Purchase Invoice" ToolTip="Profoma Purchase Invoice" TabIndex="23" OnClick="procrednote_Click" />
                        </div>

                        <div class="btn ico-proforma-oscndn">
                            <asp:Button ID="Proosdncn" runat="server" Text="Proforma OSDN/CN" ToolTip="Proforma OSDN/CN" TabIndex="24" OnClick="Proosdncn_Click" />
                        </div>
                                   
         
                    
                        <div class="btn ico-airline-booking">
                            <asp:Button ID="btn_agentbooking" runat="server" Text="Air Line Booking" ToolTip="Air Line Booking" TabIndex="19" OnClick="btn_agentbooking_Click" />
                        </div>
                        <div class="btn ico-awb-send" id="agentid" runat="server" visible="false" >
                            <asp:Button ID="btn_agentbooking1" runat="server" Text="Air Line Booking send" ToolTip="Air Line Booking send" TabIndex="20" OnClick="btn_agentbooking1_Click" Visible="false" />
                        </div>
                        <div class="btn ico-MAWB-Report">
                            <asp:Button ID="btn_mbl" runat="server" Text="MAWB Report" ToolTip="MAWB Report" TabIndex="21" OnClick="btn_mbl_Click" />
                        </div>
                        <div class="btn ico-awb-Manifest">
                            <asp:Button ID="btn_manifest" runat="server" Text="Manifest" ToolTip="Manifest" TabIndex="21" OnClick="btn_manifest_Click" />
                        </div>
                               <div class="btn ico-reuse">
       <asp:Button ID="Btn_reuse" runat="server" Text="Reuse" ToolTip="Reuse" OnClick="Btn_reuse_Click" />
   </div>
   <div class="btn ico-save" runat="server" id="btn_save1">
       <asp:Button ID="btn_save" runat="server" Text="Save" ToolTip="Save" OnClick="btn_save_Click" TabIndex="16" />
   </div>
   <div class="btn ico-view">
       <asp:Button ID="btn_view" runat="server" Text="View" ToolTip="View" OnClick="btn_view_Click" TabIndex="17" />
   </div>
   <div class="btn ico-cancel" id="btn_back1" runat="server">
       <asp:Button ID="btn_back" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_back_Click" TabIndex="18" />
   </div>
                        </div>
                    
                   
                          </div>
                    <div class="FormGroupContent4">

                        <div class="divleft" >
                    <div class="FormGroupContent4" >
                        <div class="JobInput18"> 
                                <span>Job #</span>
                                <asp:TextBox ID="txt_jobno" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txt_jobno_TextChanged" placeholder="" ToolTip="Job Number" TabIndex="1"></asp:TextBox>
                            </div>
                        
                     <asp:LinkButton ID="lbl_lnkrate" CssClass="anc ico-find-sm" runat="server" Text="" ForeColor="Red" OnClick="lbl_lnkrate_Click" TabIndex="1"></asp:LinkButton>
                           
                            <div class="JobCal2">
                                <asp:Label ID="Label1" runat="server" Text="Job Date"></asp:Label>
                                <asp:TextBox ID="txt_dtjobdate" runat="server" CssClass="form-control" placeholder="" ToolTip="Job Date" Enabled="false" TabIndex="2"></asp:TextBox>
                            </div>
                           
                            <div class="MawblCal hide">
                                <asp:Label ID="Label5" runat="server" Text="Date"></asp:Label>
                                <asp:TextBox ID="txt_dtdate" runat="server" CssClass="form-control" placeholder="" ToolTip="Date" TabIndex="4"></asp:TextBox>
                            </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="IataInputnew">
                                <asp:Label ID="Label14" runat="server" Text="IATA Carrier"></asp:Label>
                                <asp:TextBox ID="txt_iatacarrier" runat="server" CssClass="form-control" placeholder="" ToolTip="IATA Carrier" TabIndex="12"></asp:TextBox>
                            </div>
                         <div class="AirlineName blueheighlight">
                                <asp:Label ID="Label6" runat="server" Text="Air Line Name"></asp:Label>
                                <asp:TextBox ID="txt_airline" runat="server" CssClass="form-control" placeholder="" ToolTip="Air Line Name" TabIndex="5" AutoPostBack="true" OnTextChanged="txt_airline_TextChanged"></asp:TextBox>
                            </div>
                          <div class="MawblFNo blueheighlight">
                                <asp:Label ID="Label7" runat="server" Text="Flight #"></asp:Label>
                                <asp:TextBox ID="txt_flightno" runat="server" CssClass="form-control" placeholder="" ToolTip="Flight Number" TabIndex="6"></asp:TextBox>
                            </div>
                            <div class="MawblCala">
                                <asp:Label ID="Label8" runat="server" Text="Date"></asp:Label>
                                <asp:TextBox ID="txt_dtfdate" runat="server" CssClass="form-control" placeholder="" ToolTip="Flight Date" TabIndex="7"></asp:TextBox>
                            </div>
                            <div class="MawblFNo blueheighlight">
                                <asp:Label ID="Label9" runat="server" Text="Flight # 2"></asp:Label>
                                <asp:TextBox ID="txt_flightno2" runat="server" CssClass="form-control" placeholder="" ToolTip="Flight # 2" TabIndex="8"></asp:TextBox>
                            </div>
                            <div class="MawblCal2">
                                <asp:Label ID="Label10" runat="server" Text="Date"></asp:Label>
                                <asp:TextBox ID="txt_dtfdate2" runat="server" CssClass="form-control" placeholder="" ToolTip="Flight Date 2" TabIndex="9"></asp:TextBox>
                            </div>
                    </div>
                    <div class="FormGroupContent4">
                         <div class="FromInput1 blueheighlight">
                                <asp:Label ID="Label15" runat="server" Text="From"></asp:Label>
                                <asp:TextBox ID="txt_from" runat="server" CssClass="form-control" placeholder="" ToolTip="From Port" TabIndex="12" AutoPostBack="true" OnTextChanged="txt_from_TextChanged"></asp:TextBox>
                            </div>
                            <div class="ToPortInput blueheighlight">
                                <asp:Label ID="Label16" runat="server" Text="To"></asp:Label>
                                <asp:TextBox ID="txt_to" runat="server" CssClass="form-control" placeholder="" ToolTip="To Port" TabIndex="13" AutoPostBack="true" OnTextChanged="txt_to_TextChanged"></asp:TextBox>
                            </div>
                         <div class="Mawbl" style="width:21%" >
                                <asp:Label ID="Label17" runat="server" Text="ManiFest #"></asp:Label>
                                <asp:TextBox ID="txt_manifestno" runat="server" CssClass="form-control" placeholder="" ToolTip="ManiFest Number" TabIndex="14"></asp:TextBox>
                            </div>
                         <div class="MawblCala" style="margin-right:0px" >
                                <asp:Label ID="Label18" runat="server" Text="Date"  ></asp:Label>
                                <asp:TextBox ID="txt_dtmfdate" runat="server" CssClass="form-control" placeholder="" ToolTip="Date" TabIndex="15"></asp:TextBox>
                            </div>
                    </div>
                    <div class="FormGroupContent4">
                          <div class="Mawbl blueheighlight">
                                <asp:Label ID="Label3" runat="server" Text="MAWB #"></asp:Label>
                                <asp:TextBox ID="txt_mawbno" runat="server" CssClass="form-control" placeholder="" ToolTip="MAWB Number" TabIndex="3" AutoPostBack="true" OnTextChanged="txt_mawbno_TextChanged" onkeypress="if (event.keyCode==39 ||event.keyCode==34) event.returnValue = false;"></asp:TextBox>
                            </div>
                        <div class="StatusDrop2 blueheighlight">
                                <asp:Label ID="Label13" runat="server" Text="Status"></asp:Label>
                                <asp:DropDownList data-placeholder="Status" ID="ddl_cmbstatus" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="chzn-select" ToolTip="Status" placeholder="Status" TabIndex="10">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    <asp:ListItem Value="P">Prepaid</asp:ListItem>
                                    <asp:ListItem Value="T">Collect</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                          <div class="ChkBox" style="margin: 4px 0px 0px 0px;" >
                                  <span>Profit Share Job</span>                                
                                    <asp:CheckBox ID="CHk_DropAIR" runat="server"/>                                                  
                            </div>
                            <%--  AutoPostBack="True" --%>
                        <div class="ChkBox" style="width:11%;"  >
                                  <span>Direct AWB</span>                         
                                     <asp:CheckBox ID="chk_directbl" runat="server"/>                                   
                                                            
                            </div>
                            <div class="ChkBox" style="width:7%;">
                                  <span>Notify</span>                         
                                    <asp:CheckBox ID="chk_notify" runat="server" />                            
                                                         
                            </div>

                    </div>
                    <div class="FormGroupContent4">
                         <div class="JobAgent blueheighlight">
                                <asp:Label ID="Label11" runat="server" Text="Agent"></asp:Label>
                                <asp:TextBox ID="txt_agent" runat="server" CssClass="form-control" placeholder="" ToolTip="Agent" TabIndex="8" OnTextChanged="txt_agent_TextChanged"></asp:TextBox>
                            </div>
                        <div class="JobHandling">
                                <asp:Label ID="Label12" runat="server" Text="Handling Info"></asp:Label>
                                <asp:TextBox ID="txt_handlinginfo" runat="server" CssClass="form-control" placeholder="" ToolTip="Handling Info" TabIndex="9"></asp:TextBox>
                            </div>
                    </div>

                    <div class="FormGroupContent4">

                         <div class="Cargo">
                                <asp:Label ID="Label19" runat="server" Text="Cargo Description"></asp:Label>

                                <asp:TextBox ID="txt_cargodesc" MaxLength="500" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="" ToolTip="Cargo Description"></asp:TextBox>
                                <%--  AutoPostBack="True" --%>
                            </div>
                              </div>
                    
                    <div class="JobLeftN1">
                        

 

                        <div class="FormGroupContent4 boxmodal">
                            
                            <div class="ContractDrop" style="display: none;">
                                <asp:DropDownList ID="ddl_DropAE" runat="server" data-placeholder="Job profit Share" CssClass="chzn-select" ToolTip="Job profit Share" TabIndex="11">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    <asp:ListItem Value="O">Our Job</asp:ListItem>
                                    <asp:ListItem Value="P">Profit Share</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            
                           
                           
                           
                          
                        </div>
                        
                    </div>
                            </div>



                          </div>
                 
                        
                              

                     


                        <div class="btn ico-upload" style="display: none;">
                            <asp:Button ID="uploaddoc" runat="server" Text="Upload Document" ToolTip="Upload Document" OnClick="uploaddoc_Click" />
                        </div>

                  

                    

                    <div class="FormGroupContent4" >
                                                <div class="divright">
                      <div class="JobGridRight boxmodal">
                    <div class="FormGroupContent4 blueheighlight">

                        <asp:Button ID="btn_search" runat="server" Text="" Style="display: none;" OnClick="btn_search_Click" />

                        <div class="Search">
                            <asp:Label ID="Label20" runat="server" Text="Search"></asp:Label>
                            <asp:TextBox ID="txt_search" placeholder="" runat="server" ToolTip="Search" AutoPostBack="True" CssClass="" OnTextChanged="txt_search_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel ID="Book2" runat="server" CssClass="panel_05 MB0" Height="100px">
                            <asp:GridView ID="grdBookJob" runat="server" AutoGenerateColumns="false" CssClass="Grid FixedHeader" Height="100%" ShowHeaderWhenEmpty="true" Width="100%" OnPreRender="grdBookJob_PreRender">
                                <Columns>


                                    <asp:BoundField ControlStyle-CssClass="hide" DataField="bookingno" HeaderText="booking #">
                                        <HeaderStyle CssClass="hide" />
                                        <ItemStyle CssClass="hide" />
                                    </asp:BoundField>

                                    <%-- <asp:TemplateField SortExpression="shiprefno">
                                    <HeaderTemplate>
                                        <asp:Label ID="lbItem" runat="server" Text="Booking #" CommandName="Sort" CommandArgument="shiprefno"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="txt_search" placeholder="Search" runat="server" ToolTip="Search" CssClass="form-control" AutoPostBack="true"  onkeyup="GetDetail();" ></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#Eval("shiprefno") %>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                                    <asp:BoundField runat="server" DataField="shiprefno" HeaderText="Booking #">
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" />
                                    </asp:BoundField>



                                    <asp:BoundField runat="server" DataField="bookingdate" HeaderText="Date">
                                        <HeaderStyle />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="">
                                        <HeaderStyle />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkMail" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:BoundField runat="server" DataField="bl#" HeaderText="BL #">
                                        <HeaderStyle />
                                        <ItemStyle Font-Bold="false" HorizontalAlign="Left" />
                                    </asp:BoundField>

                                </Columns>
                                <AlternatingRowStyle CssClass="GrdRowStyle" />
                                <HeaderStyle CssClass="" />
                                <RowStyle CssClass="GridviewScrollItem" />
                            </asp:GridView>


                        </asp:Panel>

                    </div>

                </div>
                            </div>
                    </div>

                <div class="FormGroupContent4 boxmodal">
                    <asp:Panel ID="pnl_grd1" runat="server" Width="100%"  CssClass="gridpnl MB0">
                        <asp:GridView ID="grd" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Grid FixedHeader"
                            OnRowDataBound="grd_RowDataBound"
                            OnSelectedIndexChanged="grd_SelectedIndexChanged" OnPreRender="grd_PreRender">
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <HeaderStyle CssClass="" />
                            <AlternatingRowStyle CssClass="GrdAltRow" />
                        </asp:GridView>
                    </asp:Panel>

                </div>

               
                <div class="FormGroupContent4">               

                    <div class="FormGroupContent4">
                        <%---------------------POP UP JOB----------------------------%>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                        <div class="div_Break"></div>
                        <ajaxtoolkit:ModalPopupExtender ID="programmaticModalCancelCredit" runat="server" PopupControlID="pln_popup" TargetControlID="Label2" CancelControlID="close" BehaviorID="Test" DropShadow="false">
                        </ajaxtoolkit:ModalPopupExtender>

                        <asp:Panel ID="pln_popup" runat="server" CssClass="modalPopup" Style="display: none;">
                            <div class="divRoated">
                                <div class="DivSecPanel">
                                    <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                </div>

                                <asp:Panel ID="Panel3" runat="server" Visible="false" CssClass=" Gridpnl">

                                    <asp:GridView ID="grd_airline" runat="server" AutoGenerateColumns="False" Width="100%"
                                        OnRowDataBound="grd_airline_RowDataBound" AllowPaging="false" PageSize="19" OnPageIndexChanging="grd_airline_PageIndexChanging"
                                        HorizontalAlign="Left" CssClass="Grid FixedHeader" OnSelectedIndexChanged="grd_airline_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="jobno" HeaderText="Job #">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="airline" HeaderText="AirLine">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="mawblno" HeaderText="MAWB #">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="flightdate" HeaderText="Flight">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="agentname" HeaderText="Agent" Visible="false">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>

                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <PagerStyle CssClass="GridviewScrollPager" />
                                    </asp:GridView>

                                </asp:Panel>




                                <asp:Panel ID="Panelreuse" runat="server" Visible="false" CssClass="Gridpnl">

                                    <asp:GridView ID="Grd_reuse" runat="server" AutoGenerateColumns="False" Width="100%"
                                        OnRowDataBound="Grd_reuse_RowDataBound" AllowPaging="false" PageSize="19" OnPageIndexChanging="Grd_reuse_PageIndexChanging"
                                        HorizontalAlign="Left" CssClass="Grid FixedHeader" OnSelectedIndexChanged="Grd_reuse_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="jobno" HeaderText="Job #">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="airline" HeaderText="AirLine">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="mawblno" HeaderText="MAWB #">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="flightdate" HeaderText="Flight">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="agentname" HeaderText="Agent" Visible="false">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>

                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <PagerStyle CssClass="GridviewScrollPager" />
                                    </asp:GridView>

                                </asp:Panel>



                            </div>
                        </asp:Panel>
                        <div class="div_Break"></div>

                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_dtdate" Format="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>
                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_dtfdate" Format="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>
                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_dtmfdate" Format="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>
                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_dtjobdate" Format="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>
                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_dtfdate2" Format="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>
                    </div>


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
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
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
                </div>
            </div>
                </div>

        </div>

    </div>



    <div runat="server" id="div_body" style="display: none;"></div>
    <%--style="display:none;"--%>


    <asp:Label ID="Label4" runat="server"></asp:Label>

    <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image1" BehaviorID="Test1">
    </ajaxtoolkit:ModalPopupExtender>




    <asp:HiddenField ID="hf_agentid" runat="server" />
    <asp:HiddenField ID="hf_airlineid" runat="server" />
    <asp:HiddenField ID="hf_intfromid" runat="server" />
    <asp:HiddenField ID="hf_inttoid" runat="server" />
    <asp:HiddenField ID="hf_jobno" runat="server" />
    <asp:HiddenField ID="hf_custid" runat="server" />
    <asp:HiddenField ID="hf_portid" runat="server" />
    <asp:HiddenField ID="hf_blnMBL" runat="server" />
    <asp:HiddenField ID="hidbooking" runat="server" />
</asp:Content>
