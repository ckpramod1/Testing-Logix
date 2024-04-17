<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation="false" AutoEventWireup="true" 
    CodeBehind="FALedgerViewPG.aspx.cs" Inherits="logix.FAForms.FALedgerViewPG" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />

    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css" />
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

    <link href="../CSS/Finance.css" rel="stylesheet" />

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    
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

    <script type="text/javascript">
        function filterColumn(txtFilter, columnIndex) {
            var filterText = txtFilter.value.toLowerCase();
            var gridView = document.getElementById('<%= GRD_PAN.ClientID %>');

            // Loop through rows (excluding header)
            for (var i = 1; i < gridView.rows.length; i++) {
                var row = gridView.rows[i];
                var cellText = row.cells[columnIndex].textContent.toLowerCase().trim();

                // If the cell text contains the filter text, display the row; otherwise, hide it
                if (cellText.indexOf(filterText) > -1) {
                    row.style.display = "";
                } else {
                    row.style.display = "none";
                }
            }
        }
    </script>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            $(document).ready(function () {

                $("#<%=TXTPANO.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../FAForms/FALedgerViewPG.aspx/GetCustomerPano",
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
                        $("#<%=TXTPANO.ClientID %>").val(i.item.label);
                        $("#<%=TXTPANO.ClientID %>").change();                       
                    },
                    focus: function (event, i) {
                        $("#<%=TXTPANO.ClientID %>").val(i.item.label);
                    },
                    close: function (e, i) {
                        var result = $("#<%=TXTPANO.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=TXTPANO.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });
            $(document).ready(function () {
                $("#<%=TXTGST.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../FAForms/FALedgerViewPG.aspx/GetCustomergst",
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

                            },
                            failure: function (response) {

                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=TXTGST.ClientID %>").val(i.item.label);
                        $("#<%=TXTGST.ClientID %>").change();
                        <%--$("#<%=Hid_Receivedfrom.ClientID %>").val(i.item.val);--%>
                    },
                    focus: function (event, i) {
                        $("#<%=TXTGST.ClientID %>").val(i.item.label);
                        <%--$("#<%=Hid_Receivedfrom.ClientID %>").val(i.item.val);--%>
                    },
                    close: function (e, i) {
                        var result = $("#<%=TXTGST.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=TXTGST.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtLedgerName.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hidId.ClientID %>").val(0);
                        $.ajax({
                            url: "../AutoCompleteClass/AutoCompleteClass.aspx/GetLikeLedgerName",
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
                        $("#<%=txtLedgerName.ClientID %>").val(i.item.label);
                        $("#<%=txtLedgerName.ClientID %>").change();
                        $("#<%=hidId.ClientID %>").val(i.item.val);
                        $("#<%=hf_custid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtLedgerName.ClientID %>").val(i.item.label);
                        $("#<%=hidId.ClientID %>").val(i.item.val);
                        $("#<%=hf_custid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtLedgerName.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hidId.ClientID %>").val(i.item.val);
                            $("#<%=hf_custid.ClientID %>").val(i.item.val);
                        }
                    },
                    close: function (event, i) {
                        var result = $("#<%=txtLedgerName.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtLedgerName.ClientID %>").val($.trim(result));
                    },

                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=TXT_custn.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hidId.ClientID %>").val(0);
                        $.ajax({
                            url: "../AutoCompleteClass/AutoCompleteClass.aspx/GetLikeLedgerName",
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
                        $("#<%=TXT_custn.ClientID %>").val(i.item.label);
                        $("#<%=TXT_custn.ClientID %>").change();
                        $("#<%=hidId.ClientID %>").val(i.item.val);
                        $("#<%=hf_custid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=TXT_custn.ClientID %>").val(i.item.label);
                        $("#<%=hidId.ClientID %>").val(i.item.val);
                        $("#<%=hf_custid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=TXT_custn.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hidId.ClientID %>").val(i.item.val);
                            $("#<%=hf_custid.ClientID %>").val(i.item.val);
                        }
                    },
                    close: function (event, i) {
                        var result = $("#<%=TXT_custn.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=TXT_custn.ClientID %>").val($.trim(result));
                    },

                    minLength: 1
                });
            });

            function Set_id() {
                document.getElementById('logix_CPH_hidId').value = 0;
            }
              
        }
    </script>

    <%--
  <script type="text/javascript" language="javascript">
      function pageLoad(sender, args) 
      {

<%--            $(document).ready(function () {
                $("#<%=TXTPANO.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../FAForms/FALedgerViewPG.aspx/GetCustomerPano",
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

                            },
                            failure: function (response) {

                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=TXTPANO.ClientID %>").val(i.item.label);
                        $("#<%=TXTPANO.ClientID %>").change();
                        <%--$("#<%=Hid_Receivedfrom.ClientID %>").val(i.item.val);--%><%--
                    },
                    focus: function (event, i) {
                        $("#<%=TXTPANO.ClientID %>").val(i.item.label);
                        <%--$("#<%=Hid_Receivedfrom.ClientID %>").val(i.item.val);--%><%--
                    },
                    close: function (e, i) {
                        var result = $("#<%=TXTPANO.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=TXTPANO.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });--%><%--


              $(document).ready(function () {
                  $("#<%=TXTGST.ClientID %>").autocomplete({
                      source: function (request, response) {
                          $.ajax({
                              url: "../FAForms/FALedgerViewPG.aspx/GetCustomergst",
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

                              },
                              failure: function (response) {

                              }
                          });
                      },
                      select: function (event, i) {
                          $("#<%=TXTGST.ClientID %>").val(i.item.label);
                          $("#<%=TXTGST.ClientID %>").change();
                          <%--$("#<%=Hid_Receivedfrom.ClientID %>").val(i.item.val);--%><%--
                      },
                      focus: function (event, i) {
                          $("#<%=TXTGST.ClientID %>").val(i.item.label);
                          <%--$("#<%=Hid_Receivedfrom.ClientID %>").val(i.item.val);--%><%--
                      },
                      close: function (e, i) {
                          var result = $("#<%=TXTGST.ClientID %>").val().toString().split(' ,')[0];
                          $("#<%=TXTGST.ClientID %>").val($.trim(result));
                      },
                      minLength: 1
                  });
              });
              
      }
  </script>
    <script type="text/javascript">


       

        function pageLoad(sender, args) {
            $(document).ready(function () {

                $("#<%=txtLedgerName.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hidId.ClientID %>").val(0);
                        $.ajax({
                            url: "../AutoCompleteClass/AutoCompleteClass.aspx/GetLikeLedgerName",
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

                    <%--     select: function (event, i) {
                        $("#<%=txtLedgerName.ClientID %>").val(i.item.label);
                        $("#<%=txtLedgerName.ClientID %>").change();
                        $("#<%=hidId.ClientID %>").val(i.item.val);
                        $("#<%=hf_custid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtLedgerName.ClientID %>").val(i.item.label);
                        $("#<%=hidId.ClientID %>").val(i.item.val);
                        $("#<%=hf_custid.ClientID %>").val(i.item.val);
                    },

                    close: function (e, i) {
                        var result = $("#<%=txtLedgerName.ClientID %>").val().toString(); //.split(' ,')[0]
                         <%--var res = result.substring(0, result.lastIndexOf(' ,'));
                         var out = res.substring(0, res.lastIndexOf(' ,'));
                         if (out != "") {
                             $("#<%=txtLedgerName.ClientID %>").val($.trim(out));
                         } else {
                             
                         }
                        $("#<%=txtLedgerName.ClientID %>").val($.trim(result));
                    },--%><%--

                    select: function (event, i) {
                        $("#<%=txtLedgerName.ClientID %>").val(i.item.label);
                        $("#<%=txtLedgerName.ClientID %>").change();
                        $("#<%=hidId.ClientID %>").val(i.item.val);
                        $("#<%=hf_custid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtLedgerName.ClientID %>").val(i.item.label);
                        $("#<%=hidId.ClientID %>").val(i.item.val);
                        $("#<%=hf_custid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtLedgerName.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hidId.ClientID %>").val(i.item.val);
                            $("#<%=hf_custid.ClientID %>").val(i.item.val);
                        }
                    },
                    close: function (event, i) {
                        var result = $("#<%=txtLedgerName.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtLedgerName.ClientID %>").val($.trim(result));
                    },

                    minLength: 1
                });
            });
            function Set_id() {
                document.getElementById('logix_CPH_hidId').value = 0;
            }
        }

    </script>--%>

    <style type="text/css">
        .div_frame {
            border-left: 0px solid black;
            border-right: 0px solid black;
        }

        input[type="checkbox"] + label {
            margin: -2px 5px 0px !important;
        }

        .modalBackground {
            background-color: #ffffff;
            filter: alpha(opacity=100);
        }

        .row {
            height: 553px !important;
            margin: 0px 5px 0px -15px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: hidden !important;
            width: 100%;
        }

        .lgview_Grid1 {
            width: 100%;
            margin-left: 0%;
            margin-top: 1%;
            overflow: auto;
            height: 355px;
            border: 1px solid #b1b1b1;
        }

        .lgview_Grid {
            width: 100%;
            margin-left: 0%;
            margin-top: 1%;
            overflow: auto;
            height: 353px;
        }

        .MonthWiseGrid {
            width: 100%;
            height: 360px;
            overflow: auto;
            border: 1px solid #b1b1b1;
        }

        .DayWiseGrid {
            width: 100%;
            height: 360px;
            overflow: auto;
            border: 1px solid #b1b1b1;
        }

        iframe#logix_CPH_iframecost {
            width: 100%;
            height: 650px;
            float: left;
            border: 1px solid #b1b1b1;
            margin-left: 7px;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.5%;
            margin-top: -0.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .div_frame_out {
            width: 100%;
            Height: 510px;
            float: left;
            text-align: center;
            overflow: hidden;
            /* overflow-y: scroll; */
        }

        iframe#logix_CPH_iframe_outstd {
            overflow: hidden;
            height: 715px !important;
        }

        .MTminus {
            margin-top: 113px !important;
        }

        .btn.btn-export1 {
            width: 30%;
        }

        .widget-content {
            padding: 0 10px !important;
        }

        table#logix_CPH_grd td:nth-child(14) {
            max-width: 175px !important;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        table#logix_CPH_grd td:nth-child(15) {
            max-width: 175px !important;
            overflow: hidden;
            text-overflow: ellipsis;
        }
        .Consolidated {
    width: 6%;
    float: left;
    margin: 11px 0% 0px 0px;
}
    </style>

    <style type="text/css">
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
            border-width: 2px;
            border-style: solid;
            position: fixed;
            z-index: 100001;
            left: 352px;
            top: 187px !important;
        }

        .LedgerInput1 {
            width: 19%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LedgerInput2 {
            width: 20%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        .WithDetails {
    width: 6%;
    float: left;
    margin: 12px 0.5% 0px 0px;
}
        span.chktext {
    font-weight: normal !important;
    display: inline-block;
    margin-bottom: 3px!important;
}
        .LedgerInput {
            width: 29%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
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
 
        .gridpnl {
    
    border-top: 1px solid var(--inputborder) !important;
    margin: 5px 0px !important;
    overflow: auto !important;
}
        .widget.box .widget-content {
    top: 0px !important;
    padding-top: 55px !important;
}
        .LedToInput {
    width: 7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        div#logix_CPH_ddl_Gst_chzn {
    width: 100% !important;
}
        div#logix_CPH_ddl_lk_chzn {
    width: 100% !important;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">

                <div class="widget-header">
                    <div>
                    <h4><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_head" runat="server" Text="Ledger"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs1" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li><a href="#">Reports</a> </li>
                            <li><a href="#" title="">Ledger</a> </li>

                            <li>
                                <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>

                        </ul>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                   <div class="FixedButtons">
                           <div class="right_btn">
       <div class="btn ico-get">
           <asp:Button ID="btnview" runat="server" ToolTip="View" OnClick="btnview_Click" Visible="false" />
           <asp:Button ID="BTNPANo" runat="server" ToolTip="Get" OnClick="BTNPANo_Click" />
       </div>
   </div>
                    </div>


                </div>
                <div class="widget-content">
                    
                    <div class="FormGroupContent4 boxmodal">
                                    <div class="LedgerInput" style="width: 14%;" >
    <asp:Label ID="Label9" runat="server" Text="OurBranch"></asp:Label>

   <asp:DropDownList ID="ddl_branch" runat="server" AutoPostBack="True" Data-placeholder="Branch" ToolTip="Branch" CssClass="chzn-select" OnTextChanged="ddl_branch_TextChanged">
    <asp:ListItem Value="0" Text="All"></asp:ListItem>
</asp:DropDownList>
</div>
                        <div class="LedFromInput">
                            <asp:Label ID="lbl_from" runat="server" Text="From"></asp:Label>
                            <asp:TextBox ID="dtfrom" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:CalendarExtender ID="cal_dtfr" runat="server" TargetControlID="dtfrom" Format="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>

                        <div class="LedToInput DateR">
                            <asp:Label ID="lbl_to" runat="server" Text="To"></asp:Label>
                            <asp:TextBox ID="dtto" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:CalendarExtender ID="ca_to" runat="server" TargetControlID="dtto" Format="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>
                        <div class="LedgerInput">

                            <asp:Label ID="lbl_Esc" runat="server" Text="Ledger Name" Visible="false"></asp:Label>

                            <asp:TextBox ID="txtLedgerName" runat="server" CssClass="form-control" AutoPostBack="true" Visible="false" ToolTip="Ledger Name" placeholder="" OnTextChanged="txtLedgerName_TextChanged"></asp:TextBox>
                        </div>

                        <div class="LedgerInput" runat="server" id="CUST" style="width: 25%;" >

    <asp:Label ID="Lbl_custn" runat="server" Text="Ledger Name"></asp:Label>

    <asp:TextBox ID="TXT_custn" runat="server" CssClass="form-control" AutoPostBack="true" ToolTip="Ledger Name" placeholder=""   OnTextChanged="TXT_custn_TextChanged"></asp:TextBox> <%--OnTextChanged="PANO_TextChanged"--%>
</div>
                        <div class="LedgerInput"  style="width:9%" >

                            <asp:Label ID="Label3" runat="server" Text="PANO"></asp:Label>

                            <asp:TextBox ID="TXTPANO" runat="server" CssClass="form-control" AutoPostBack="true" ToolTip="PANO" placeholder="" OnTextChanged="TXTPANO_TextChanged"></asp:TextBox> <%--OnTextChanged="PANO_TextChanged"--%>
                        </div>


                        <div class="LedgerInput" style="width: 13%;" >

                            <asp:Label ID="Label5" runat="server" Text="GST" Visible="false"></asp:Label>

                            <asp:TextBox ID="TXTGST" runat="server" CssClass="form-control" Visible="false" AutoPostBack="true" ToolTip="GST" placeholder="" ></asp:TextBox> <%--OnTextChanged="PANO_TextChanged"--%>
                        </div>
                        <div class="LedgerInput" style="width: 19%;" >
                            <asp:DynamicFilter ID="DynamicFilter1" runat="server"></asp:DynamicFilter>
    <asp:Label ID="Label6" runat="server" Text="GST"></asp:Label>

   <asp:DropDownList ID="ddl_Gst" runat="server" AutoPostBack="True" Data-placeholder="GST" ToolTip="GST" CssClass="chzn-select" OnTextChanged="ddl_Gst_TextChanged">
    <asp:ListItem Value="0" Text="All"></asp:ListItem>
</asp:DropDownList>
</div>
                        <div class="LedgerInput" style="width: 13%;" >

    <asp:Label ID="Label7" runat="server" Text="GST Location" Visible="false"></asp:Label>

    <asp:TextBox ID="txt_gstl" runat="server" CssClass="form-control"   Visible="false" AutoPostBack="true" ToolTip="GST" placeholder="" ></asp:TextBox> <%--OnTextChanged="PANO_TextChanged"--%>
</div>
                                                <div class="LedgerInput" style="width: 14%;" >
                            <asp:DynamicFilter ID="DynamicFilter2" runat="server"></asp:DynamicFilter>
    <asp:Label ID="Label8" runat="server" Text="Branch"></asp:Label>

   <asp:DropDownList ID="ddl_lk" runat="server" AutoPostBack="True" Data-placeholder="GST" ToolTip="GST LK" CssClass="chzn-select" OnTextChanged="ddl_lk_TextChanged">
    <asp:ListItem Value="0" Text="All"></asp:ListItem>
</asp:DropDownList>
</div>


                        <div class="LedgerInput1">

                            <asp:Label ID="Label1" runat="server" Text="SubGroup" Visible="false"></asp:Label>
                            <asp:TextBox ID="Txt_subname" ReadOnly="true" runat="server" CssClass="form-control" ToolTip="SubGroup" placeholder="" Visible="false"></asp:TextBox>
                        </div>
                        <div class="LedgerInput2">
                            <asp:Label ID="Label2" runat="server" Text="Group Name" Visible="false"> </asp:Label>
                            <asp:TextBox ID="Txt_Groupname" ReadOnly="true" runat="server" CssClass="form-control" ToolTip="Group Name" placeholder="" Visible="false"></asp:TextBox>
                        </div>
                        <div class="WithDetails" runat="server" id="dvWithDetails">
                            <span class="chktext"> Detailed </span>
                            <center>
                                <label class="switch">
                                    <asp:CheckBox ID="chkwithdtls" runat="server" />
                                   
                                </label>
                            </center>

                        </div>
                          <div class="Consolidated" id="Consolidated" runat="server">
                                <span>All Branches</span>
                            <center>
                                
                                <label class="switch">

                                    <asp:CheckBox ID="chkConsolidate" runat="server" />

                                 

                                </label>

                            </center>
                          
                        </div>
                        
                     

                    </div>
                    <div class="FormGroupContent4">
                    </div>
                    <div class=" hide">
                        <div class="AliasName1">
                            <center>

                                <label class="switch">

                                    <asp:CheckBox ID="chk_alias" runat="server" />

                                    <span class="slider round"></span>

                                </label>

                            </center>
                            <span>Alias Name</span>
                        </div>
                        <div class="Monthwise">
                            <center>

                                <label class="switch">

                                    <asp:CheckBox ID="chk_MonthWise" runat="server" />

                                    <span class="slider round"></span>

                                </label>

                            </center>
                            <span>MonthWise</span>
                        </div>
                        <div class="Daywise">
                            <center>

                                <label class="switch">

                                    <asp:CheckBox ID="chkDayWise" runat="server" />

                                    <span class="slider round"></span>

                                </label>

                            </center>
                            <span>DayWise</span>

                        </div>

                      

                    </div>

                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel ID="pnlgrd" runat="server" CssClass="gridpnl">



                            <div runat="server" id="div1">

    <asp:GridView ID="GRD_PAN" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true"  AllowFiltering="true" AllowPaging="false"
        EmptyDataText="No Records Found" CssClass="Grid FixedHeader" ForeColor="Black" OnSelectedIndexChanged="GRD_PAN_SelectedIndexChanged"
        DataKeyNames="ltype,vouno,branchid,osvtype" OnRowDataBound="GRD_PAN_RowDataBound" Width="100%" Visible="false">
         <%--<FilterSettings FilterType="Excel" />--%>
        <Columns>
            <asp:BoundField DataField="voudate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"><%-- 0--%>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="2.5%" Wrap="false" />
            </asp:BoundField>
            <asp:BoundField DataField="voutypename" HeaderText="Vou Type"><%--1--%>
                <HeaderStyle HorizontalAlign="Left" Width="8%" Wrap="false" />
                <ItemStyle Width="3%" Wrap="false" />
            </asp:BoundField>
             <asp:BoundField DataField="VNDet" HeaderText="Vou #"><%--2--%>
     <HeaderStyle HorizontalAlign="Left" Wrap="false" />
     <ItemStyle Wrap="False" Width="3%" />
 </asp:BoundField>

            <asp:BoundField DataField="Branch" HeaderText="Branch"><%-- 3--%>
                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                <ItemStyle Width="2.5%" Wrap="false" />
            </asp:BoundField>
            <asp:BoundField DataField="product" HeaderText="Product"><%-- 4--%>
    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
    <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
</asp:BoundField>
            <asp:BoundField DataField="jobno" HeaderText="Job #"><%-- 5--%>
    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
    <ItemStyle Width="2.5%" Wrap="false" />
</asp:BoundField>
           
            <asp:TemplateField HeaderText="Particulars"><%--6--%>
                <ItemTemplate>
                    <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 250px">
                        <asp:Label ID="lblprti" runat="server" Text='<%# Bind("prti") %>' ToolTip='<%#Bind("prti")%>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="75px" />
                <ItemStyle HorizontalAlign="Left" Width="100%" />
            </asp:TemplateField>
            <asp:BoundField DataField="amount" HeaderText="Debit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 7--%>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Right" Width="4%" Wrap="false" />
            </asp:BoundField>
            <asp:BoundField DataField="amountcr" HeaderText="Credit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 8--%>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Right" Width="4%" Wrap="false" />
            </asp:BoundField>
            <asp:BoundField DataField="amount" HeaderText="Balance" ItemStyle-Wrap="False" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%--9--%>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Wrap="False" HorizontalAlign="Right" Width="5%" />
            </asp:BoundField>
                <asp:BoundField DataField="fcur" HeaderText="Cur"><%--10--%>
        <HeaderStyle HorizontalAlign="Left" />
        <ItemStyle Width="2%" Wrap="false" />
    </asp:BoundField>
    <asp:BoundField DataField="famt" HeaderText="Dr.Amt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 11--%>
        <HeaderStyle HorizontalAlign="Left" />
        <ItemStyle HorizontalAlign="Right" Width="4%" Wrap="false" />
    </asp:BoundField>
    <asp:BoundField DataField="famtcr" HeaderText="Cr.Amt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 12--%>
        <HeaderStyle HorizontalAlign="Left" />
        <ItemStyle HorizontalAlign="Right" Width="4%" Wrap="false" />
    </asp:BoundField>
    <asp:BoundField DataField="fexrate" HeaderText="Ex-Rate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 13--%>
        <HeaderStyle HorizontalAlign="Left" Wrap="false" />
        <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
    </asp:BoundField>
            <asp:BoundField DataField="ClearedOn" HeaderText="Cleared On"><%-- 14--%>
                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Vender Ref #"><%--15--%>
                <ItemTemplate>
                    <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 200px">
                        <asp:Label ID="lblvendorrefno" runat="server" Text='<%# Bind("vendorrefno") %>' ToolTip='<%#Bind("vendorrefno")%>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="75px" />
                <ItemStyle HorizontalAlign="Left" Width="100%" />
            </asp:TemplateField>
            

            <asp:BoundField DataField="mbl" HeaderText="MBL"><%-- 16--%>
                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
            </asp:BoundField>
            <asp:BoundField DataField="refno" HeaderText="HBL"><%-- 17--%>
                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
            </asp:BoundField>
            <asp:BoundField DataField="shipper" HeaderText="Shipper"><%-- 18--%>
                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
            </asp:BoundField>
            <asp:BoundField DataField="consignee" HeaderText="Consignee"><%-- 19--%>
                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
            </asp:BoundField>
            <asp:BoundField DataField="pol" HeaderText="POL"><%-- 20--%>
                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
            </asp:BoundField>
            <asp:BoundField DataField="pod" HeaderText="POD"><%-- 21--%>
                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Narration"><%--22--%>
                <ItemTemplate>
                    <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 400px">
                        <asp:Label ID="lblnarration" runat="server" Text='<%# Bind("narration") %>' ToolTip='<%#Bind("narration")%>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="75px" />
                <ItemStyle HorizontalAlign="Left" Width="100%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Container #"><%-- 23--%>
                <ItemTemplate>
                    <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 200px">
                        <asp:Label ID="lblcontainerno" runat="server" Text='<%# Bind("containerno") %>' ToolTip='<%#Bind("containerno")%>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="75px" />
                <ItemStyle HorizontalAlign="Left" Width="100%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Ref #"><%--24--%>
                <ItemTemplate>
                    <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 200px">
                        <asp:Label ID="lblrefno" runat="server" Text='<%# Bind("refno") %>' ToolTip='<%#Bind("refno")%>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="75px" />
                <ItemStyle HorizontalAlign="Left" Width="100%" />
            </asp:TemplateField>
       
                         <asp:BoundField DataField="GSTCODE" HeaderText="GSTCODE #"><%-- 25--%>
                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
            </asp:BoundField>

            <asp:BoundField DataField="chequ" HeaderText="Cheque #"><%-- 26--%>
                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
            </asp:BoundField>


            <asp:BoundField DataField="NetAmt" HeaderText="GrossAmountWithoutTAX" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="TaxAmt" HeaderText="TaxAmount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="GrossAmt" HeaderText="GrossAmount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="TDSAmt" HeaderText="TDSAmount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

        </Columns>
        <HeaderStyle CssClass="GridHeader" />
        <AlternatingRowStyle CssClass="GrdAltRow" />
    </asp:GridView>

</div>





                            <div runat="server" id="divgrd">

                                <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found" CssClass="Grid FixedHeader" ForeColor="Black" OnSelectedIndexChanged="grd_SelectedIndexChanged"
                                    DataKeyNames="ltype,vouno,branchid,osvtype" OnRowDataBound="grd_RowDataBound" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="voudate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"><%-- 0--%>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="2.5%" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="voutypename" HeaderText="Vou Type"><%--1--%>
                                            <HeaderStyle HorizontalAlign="Left" Width="8%" Wrap="false" />
                                            <ItemStyle Width="3%" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="jobno" HeaderText="Job #"><%-- 2--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="2.5%" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="VNDet" HeaderText="Vou #"><%--3--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Wrap="False" Width="3%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Particulars"><%--4--%>
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 250px">
                                                    <asp:Label ID="lblprti" runat="server" Text='<%# Bind("prti") %>' ToolTip='<%#Bind("prti")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="75px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="amount" HeaderText="Debit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 5--%>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" Width="4%" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="amountcr" HeaderText="Credit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 6--%>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" Width="4%" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="amount" HeaderText="Balance" ItemStyle-Wrap="False" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%--7--%>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Right" Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ClearedOn" HeaderText="Cleared On"><%-- 9--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Vender Ref #"><%--10--%>
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 200px">
                                                    <asp:Label ID="lblvendorrefno" runat="server" Text='<%# Bind("vendorrefno") %>' ToolTip='<%#Bind("vendorrefno")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="75px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="product" HeaderText="Product"><%-- 11--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="mbl" HeaderText="MBL"><%-- 12--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="refno" HeaderText="HBL"><%-- 13--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="shipper" HeaderText="Shipper"><%-- 14--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="consignee" HeaderText="Consignee"><%-- 15--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="pol" HeaderText="POL"><%-- 16--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="pod" HeaderText="POD"><%-- 17--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Narration"><%--18--%>
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 400px">
                                                    <asp:Label ID="lblnarration" runat="server" Text='<%# Bind("narration") %>' ToolTip='<%#Bind("narration")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="75px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Container #"><%-- 19--%>
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 200px">
                                                    <asp:Label ID="lblcontainerno" runat="server" Text='<%# Bind("containerno") %>' ToolTip='<%#Bind("containerno")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="75px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Ref #"><%--20--%>
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 200px">
                                                    <asp:Label ID="lblrefno" runat="server" Text='<%# Bind("refno") %>' ToolTip='<%#Bind("refno")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="75px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="fcur" HeaderText="Cur"><%--21--%>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="2%" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="famt" HeaderText="Dr.Amt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 22--%>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Right" Width="4%" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="famtcr" HeaderText="Cr.Amt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 23--%>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Right" Width="4%" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="fexrate" HeaderText="Ex-Rate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 24--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="GSTIN" HeaderText="GSTIN"><%-- 25--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="chequ" HeaderText="Cheque #"><%-- 26--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="GSTCODE" HeaderText="GSTCODE #"><%-- 27--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="NetAmt" HeaderText="GrossAmountWithoutTAX" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="TaxAmt" HeaderText="TaxAmount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="GrossAmt" HeaderText="GrossAmount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="TDSAmt" HeaderText="TDSAmount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>

                            </div>

                            <div id="grd_consol_div" runat="server" visible="true">

                                <asp:GridView ID="grdconsol" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" ForeColor="Black"
                                    DataKeyNames="ltype,vouno,voutype,branchid,osvtype" Width="100%" OnRowDataBound="grdconsol_RowDataBound" OnSelectedIndexChanged="grdconsol_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="voudate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"><%-- 0 --%>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="2.5%" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="voutypename" HeaderText="Vou Type"><%-- 1 --%>
                                            <HeaderStyle HorizontalAlign="Left" Width="8%" Wrap="false" />
                                            <ItemStyle Width="3%" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="jobno" HeaderText="Job #"><%-- 2 --%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="2.5%" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="VNDet" HeaderText="Vou #"><%-- 3 --%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Wrap="False" Width="3%" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Particulars"><%--4--%>
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 250px">
                                                    <asp:Label ID="lblprti" runat="server" Text='<%# Bind("prti") %>' ToolTip='<%#Bind("prti")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="75px" />
                                            <ItemStyle HorizontalAlign="Left" Width="75px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="amount" HeaderText="Debit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 5 --%>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" Width="4%" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="amountcr" HeaderText="Credit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 6 --%>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" Width="4%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="amount" HeaderText="Balance" ItemStyle-Wrap="False" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 7 --%>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Wrap="False" HorizontalAlign="Right" Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ClearedOn" HeaderText="Cleared On"><%-- 8 --%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Vender Ref #"><%--9--%>
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 200px">
                                                    <asp:Label ID="lblvendorrefno" runat="server" Text='<%# Bind("vendorrefno") %>' ToolTip='<%#Bind("vendorrefno")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="75px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100%" />
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="product" HeaderText="Product"><%-- 10 --%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="mbl" HeaderText="MBL"><%-- 11 --%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="refno" HeaderText="HBL"><%-- 12 --%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="shipper" HeaderText="Shipper"><%-- 13--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="consignee" HeaderText="Consignee"><%-- 14--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="pol" HeaderText="POL"><%-- 13 --%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="pod" HeaderText="POD"><%-- 14 --%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Narration"><%--15--%>
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 400px">
                                                    <asp:Label ID="lblnarration" runat="server" Text='<%# Bind("narration") %>' ToolTip='<%#Bind("narration")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="175px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Container #"><%-- 16--%>
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 200px">
                                                    <asp:Label ID="lblcontainerno" runat="server" Text='<%# Bind("containerno") %>' ToolTip='<%#Bind("containerno")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="75px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Ref #"><%--17--%>
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 200px">
                                                    <asp:Label ID="lblrefno" runat="server" Text='<%# Bind("refno") %>' ToolTip='<%#Bind("refno")%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="75px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="fcur" HeaderText="Cur"><%-- 18 --%>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="2%" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="famt" HeaderText="Dr.Amt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 19 --%>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Right" Width="4%" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="famtcr" HeaderText="Cr.Amt" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 20 --%>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Right" Width="4%" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="fexrate" HeaderText="Ex-Rate" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1"><%-- 21 --%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="GSTIN" HeaderText="GSTIN"><%-- 22--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="chequ" HeaderText="Cheque #"><%-- 22--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="pbid" HeaderText="PBID"><%-- 22--%>
                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="hidden" />
                                            <ItemStyle Width="4%" HorizontalAlign="Right" Wrap="false" CssClass="hidden" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="NetAmt" HeaderText="GrossAmountWithoutTAX" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="TaxAmt" HeaderText="TaxAmount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="GrossAmt" HeaderText="GrossAmount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="TDSAmt" HeaderText="TDSAmount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>

                            </div>

                            <div id="Monthwise" runat="server" visible="false">
                                <asp:GridView ID="grd_Monthwise" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" ForeColor="Black"
                                    Width="100%" DataKeyNames="VoucherMonth" OnRowDataBound="grd_Monthwise_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="VoucherYear" HeaderText="Year">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MonthName" HeaderText="Month">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MonthDebit" HeaderText="Debit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MonthCredit" HeaderText="Credit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </div>

                            <div id="Daywise" runat="server" visible="false">
                                <asp:GridView ID="grd_DayWise" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" ForeColor="Black" OnRowDataBound="grd_DayWise_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="LDay" HeaderText="Date">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="27%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DayDebit" HeaderText="Debit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" Width="35%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DayCredit" HeaderText="Credit" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <ItemStyle HorizontalAlign="Right" Width="35%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </div>

                            <asp:GridView ID="grdPendingRef" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" ForeColor="Black" OnSelectedIndexChanged="grdPendingRef_SelectedIndexChanged"
                                OnRowDataBound="grdPendingRef_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="grdref" HeaderText="Ref #">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="job" HeaderText="Job #">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="grdopbal" HeaderText="OpeningBalance">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="grdpenamt" HeaderText="PendingAmount">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="grdtypevalue" HeaderText="TypeValue">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>

                            <asp:GridView ID="grdPendingBills" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" ForeColor="Black">
                                <Columns>
                                    <asp:BoundField DataField="DataGridViewTextBoxColumn1" HeaderText="Date">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DataGridViewTextBoxColumn3" HeaderText="Vou #">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DataGridViewTextBoxColumn4" HeaderText="OpeningBalance">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DataGridViewTextBoxColumn5" HeaderText="PendingAmount">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>

                            <asp:GridView ID="grdard" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" ForeColor="Black" Width="97%">
                                <Columns>
                                    <asp:BoundField DataField="DType" HeaderText="DType" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Branch" HeaderText="Branch">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                        <ControlStyle Width="70px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Voucher#" HeaderText="Voucher #">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="false" />
                                        <ControlStyle Width="70px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Voucher Type" HeaderText="Voucher Type">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Date" HeaderText="Date">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="false" />
                                        <ControlStyle Width="70px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="VouAmt" HeaderText="Vou Amount">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Adjust Type" HeaderText="Adjust Type">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Adjust Ref #" HeaderText="Adjust Ref#">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AdjustAmt" HeaderText="Adjust Amount">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OutStanding" HeaderText="OutStanding">
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Tranid" HeaderText="Tran id">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>

                        </asp:Panel>
                    </div>

                    <div class="FormGroupContent4">
                        <div class="right_btn">
                            
                        </div>
                        <div class="right_btn">
                            <div class="btn ico-branch">
    <asp:Button ID="btnagref" runat="server" Text="" AccessKey="R" ToolTip="Agref" OnClick="btnagref_Click" />
</div>
                            <div class="btn ico-print">
                                <asp:Button ID="btnprint" runat="server" Text="" ToolTip="Print" AccessKey="P" OnClick="btnprint_Click" />
                            </div>
                            <div class="btn ico-acd" id="div_outstd" runat="server" visible="false">
                                <asp:Button ID="btn_outstd" runat="server" ToolTip="Outstanding" OnClick="btn_outstd_Click" />
                            </div>

                            <div class="btn ico-excel">
                                <asp:Button ID="btnexcel" runat="server" Text="" ToolTip="Excel" AccessKey="E" OnClick="btnexcel_Click" />
                            </div>
                            <div class="btn ico-pending" id="btnpendbills1" runat="server" visible="false" >
                                <asp:Button ID="btnpendbills" runat="server" Text="" ToolTip="Pend Bills" Visible="false" AccessKey="n" OnClick="btnpendbills_Click" CssClass="btn" />
                            </div>
                            <div class="btn ico-log" id="btnallbills1" runat="server" visible="false" >
                                <asp:Button ID="btnallbills" runat="server" ToolTip="All Bills" Visible="false" AccessKey="A" OnClick="btnallbills_Click" />
                            </div>
                            <div class="btn ico-cancel">
                                <asp:Button ID="btncancel" runat="server" Text="" AccessKey="C" ToolTip="Cancel" OnClick="btncancel_Click" />
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hidId" runat="server" />

    <div class="FormGroupContent4">

        <asp:Panel ID="pln_Trialbalance" runat="server" CssClass=" modalPopup" BackColor="White">

            <div class="divRoated">
                <div class="DivSecPanel">
                    <asp:Image ID="Close_Trialbalance" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>

                <div class="">
                    <iframe id="iframecost" runat="server" src="" frameborder="0"></iframe>
                </div>
            </div>
        </asp:Panel>
    </div>

    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pln_Trialbalance" TargetControlID="lbl_hid" CancelControlID="Close_Trialbalance">
        <Animations>
        <OnShown>
            <FadeIn Duration="1.5" Fps="40" />                
        </OnShown>
        </Animations>
    </asp:ModalPopupExtender>

    <div class="FormGroupContent4">

        <asp:Panel ID="Panel_outstd" runat="server" class="modalPopup" BackColor="White">

            <div class="divRoated">
                <div class="DivSecPanel">
                    <asp:Image ID="Close_outstd" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                </div>

                <div class="">
                    <iframe id="iframe_outstd" runat="server" src="" frameborder="0"></iframe>
                </div>
            </div>
        </asp:Panel>
    </div>

    <asp:ModalPopupExtender ID="MOdal_popup_outstd" runat="server" PopupControlID="Panel_outstd" TargetControlID="lbl_outstd" CancelControlID="Close_outstd">
        <Animations>
        <OnShown>
            <FadeIn Duration="1.5" Fps="40" />                
        </OnShown>
        </Animations>
    </asp:ModalPopupExtender>

    <%--<asp:Panel ID="pln_cheque" runat="server"  CssClass="modalPopup"  style="display:none;">
       
        <div class="DivSecPanel"> <asp:Image ID="Close_Cheque" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%"/>  </div>             
   
         <iframe id="iframecost" runat="server" src="" frameborder="0" class="frames">
            </iframe>
                  
             <div class="div_Break"></div>
      
    </asp:Panel>

     <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pln_popup" TargetControlID="Label1" CancelControlID="close" DropShadow="true">
    </asp:ModalPopupExtender>

     <asp:Label ID="Label1" runat="server"></asp:Label>--%>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Ledger #</label>

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

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

    <asp:HiddenField ID="hid" runat="server" />
    <asp:HiddenField ID="hf_custid" runat="server" />
    <asp:Label ID="lbl_hid" runat="server"></asp:Label>
    <asp:Label ID="lbl_outstd" runat="server"></asp:Label>
</asp:Content>
