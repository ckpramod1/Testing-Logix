<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MasterChargesNew.aspx.cs" Inherits="logix.Maintenance.MasterChargesNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">
     <link href="../Theme/assets/css/system.css" rel="stylesheet" />
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
    <script src="../js/helper.js"></script>
    <script src="../js/TextField.js"></script>
      <script type="text/javascript">
          function generateLableAutomatically() {
              $("input[type='text'],textarea").each(function () {
                  if ($(".chzn-search input")) {
                      $(".chzn-search input").attr("placeholder", "");
                  }
              });

              $("input[type='text'],textarea").each(function () {
                  if ($(this).attr("placeholder")) {
                      var placeholder = $(this).attr("placeholder");
                      $(this).before("<span style='color:#000080;font-size:12px'>" + placeholder + "</span>");
                      $(this).removeAttr("placeholder");
                  }
              });

              $("select").each(function () {
                  if ($(this).attr("placeholder")) {
                      var placeholder = $(this).attr("placeholder");
                      $(this).before("<span style='color:#000080;font-size:12px'>" + placeholder + "</span>");
                      $(this).removeAttr("placeholder");
                  }
                  //else if ($(this).attr("data-placeholder")) {
                  //    var dataplaceholder = $(this).attr("data-placeholder");
                  //    $(this).before("<span style='color:#000080;font-size:12px'>" + dataplaceholder + "</span>");
                  //}
                  //else if ($(this).attr("title")) {
                  //    var tooltip = $(this).attr("title");
                  //    $(this).before("<span style='color:#000080;font-size:12px'>" + tooltip + "</span>");
                  //}
              });

              $("input[type = 'submit'],input[type = 'button']").each(function () {
                  if ($(this).attr("value")) {
                      var value = $(this).attr("value");
                      $(this).attr("title", value);
                      $(this).attr("value", "");
                  }
              });

            
              $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
          }
    </script>
    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>
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

    <style type="text/css">
        .Shipper1 {
            width: 24.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Consignee3 {
            width: 24.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Shipper2 {
            width: 8.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        div#logix_CPH_ddl_reimbursement_chzn {
    width: 100% !important;
}
        .Consignee4 {
            width: 4.5%;
            margin: 0px 0.5% 0px 0px;
            float: left;
        }

        .Amount6 input {
            text-align: right;
        }

        .TypeDrop {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ChargesInput1 {
            width: 58%;
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
                font-size: 12px;
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
                font-size: 12px;
                color: #4e4c4c !important;
            }

            .GridNew td {
                border-right: 1px solid #dddddd;
                font-size: 12px;
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
            width: auto;
            white-space: nowrap;
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
                font-family: Tahoma;
                color: #4e4e4c;
            }

    

        .Subgroup1 {
            float: left;
            width: 23.5%;
            margin: 0px 0px 5px;
        }

        .GroupName1 {
            float: left;
            width: 50%;
            margin: 0px 0.5% 0px 0px;
        }

        .GroupType {
            float: left;
            width: 49.5%;
            margin: 0px 0% 0px 0px;
        }

        form {
            /* margin: 0 5px;*/
height: 100vh !important;
            overflow: hidden;
            width: 1366px;
            margin: 0px auto;
        }

               .row {
            height: 570px !important;
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

        .Reimbursement {
    width: 11%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        span#logix_CPH_Label9 {
    white-space: nowrap;
}
        
        .search {
            width: 100%;
            float: left;
            margin: 0px 0.5% 5px 0px;
        }
        .right_btn {
    float: right !important;
    margin-top: 8px !important;
}
  
       div#logix_CPH_div_iframe .widget-content {
    top: 0px !important;
    padding-top: 65px !important;
}
    </style>






    <link href="../Styles/MasterChargesnew.css" rel="stylesheet" />

    <link href="../Scripts/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>

    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function chkind() {
            var dropdown1 = document.getElementById('ddl_cmbChargeType');
            var textbox = document.getElementById('textbox');
            var a = dropdown1.selectedIndex;

            if (a == 0) {
                textbox.text = "hi";
            } else if (a == 1) {
                textbox.value = "bye";
            }
        }
    </script>
    <script type="text/javascript">

        function pageLoad(sender, args) {
            //$(document).ready(function () {
            //    $("#ddl_cmbChargeType").focus();
            //});
          <%--  $(document).ready(function () {
                $('#<%=grd.ClientID%>').gridviewScroll({
                    width: 579,
                    height: 270,
                    arrowsize: 30,

                    varrowtopimg: "../images/arrowvt.png",
                    varrowbottomimg: "../images/arrowvb.png",
                    harrowleftimg: "../images/arrowhl.png",
                    harrowrightimg: "../images/arrowhr.png"
                });
            });--%>
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            $(document).ready(function () {

                $("#<%=txt_Charges.ClientID %>").autocomplete({

                    source: function (request, response) {

                        $.ajax({
                            url: "../Maintenance/MasterchargesNew.aspx/Getcustomer",
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
                        $("#<%=hf_chargeid.ClientID %>").val(i.item.val);
                        $("#<%=txt_Charges.ClientID %>").change();

                    },

                    focus: function (event, i) {
                        $("#<%=txt_Charges.ClientID %>").val(i.item.value);
                    },

                    minLength: 1
                });
            });


                $(document).ready(function () {

                    $("#<%=txt_Curr.ClientID %>").autocomplete({

                        source: function (request, response) {
                            $("#<%=hf_curid.ClientID %>").val(0);
                            $.ajax({
                                url: "../Maintenance/MasterchargesNew.aspx/GetCurr",
                                data: "{ 'prefix': '" + document.getElementById('logix_CPH_txt_Curr').value + "'}",
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

                        select: function (event, i) {
                            $("#<%=hf_curid.ClientID %>").val(i.item.val);
                            $("#<%=txt_Curr.ClientID %>").change();

                        },

                        focus: function (event, i) {
                            $("#<%=txt_Curr.ClientID %>").val(i.item.value);
                        },
                        minLength: 1
                    });
                });
                    $(document).ready(function () {

                        $("#<%=txt_subgroup.ClientID %>").autocomplete({
                            source: function (request, response) {
                                $("#<%=hid_SubGroupid.ClientID %>").val(0);
                                $.ajax({
                                    url: "../Maintenance/MasterchargesNew.aspx/GetSubgroupname",
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
                      <%--select: function (event, i) {
                          $("#<%=hid_SubGroupid.ClientID %>").val(i.item.val);
                      },
                      focus: function (event, i) {
                          $("#<%=hid_SubGroupid.ClientID %>").val(i.item.val);
                      },
                      minLength: 1--%>

                            select: function (event, i) {
                                $("#<%=txt_subgroup.ClientID %>").val(i.item.label);
                        $("#<%=txt_subgroup.ClientID %>").change();
                        $("#<%=hid_SubGroupid.ClientID %>").val(i.item.val);
                    },
                            focus: function (event, i) {
                                $("#<%=txt_subgroup.ClientID %>").val(i.item.label);
                        $("#<%=hid_SubGroupid.ClientID %>").val(i.item.val);
                    },
                            close: function (e, i) {
                                var result = $("#<%=txt_subgroup.ClientID %>").val().toString().split[','];
                        var res = result.substring(0, result.lastIndexOf(' ,'));
                        var out = res.substring(0, res.lastIndexOf(' ,'));
                        if (out != "") {
                            $("#<%=txt_subgroup.ClientID %>").val($.trim(out));
                          } else {
                              $("#<%=txt_subgroup.ClientID %>").val($.trim(res));
                          }
                    },
                            minLength: 1
                        });
                    });
          }

    </script>
    <script type="text/javascript">
        function TxtFocus() {

            var el = $("#<%=txt_Search.ClientID %>").get(0);
            var elemLen = el.value.length;
            el.selectionStart = elemLen;
            el.selectionEnd = elemLen;
            el.focus();
        }

        function GetDetail() {
            $.ajax({
                type: "POST",
                url: "../Maintenance/MasterchargesNew.aspx/GetEmpName",
                data: '{Prefix: "' + $("#<%=txt_Search.ClientID %>").val() + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    //alertify.alert(response.d);
                }
            });
        }

        function OnSuccess(response) {
            $("#<%=btn_search.ClientID %>").click();
        }



    </script>
    <script type="text/javascript">
        function validateDropList() {

            if (document.getElementById("<%=ddl_cmbChargeType.ClientID%>").value == "") {
                return false;
            }
            else
                return true;
        }
        function submitForm() {

            if (!validateDropList()) {
                alertify.alert("Please do select a Chargetype.");
                var textbox = document.getElementById("ddl_cmbChargeType");
                textbox.focus();

                return false; //do not submit form
            }
            else
                return true;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div>
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lblheader" runat="server" Text="Charges"></asp:Label></h4>
                            <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Maintenance</a> </li>
            <li class="current"><a href="#" title="">Charges</a> </li>
        </ul>
    </div>
    <!-- Breadcrumbs line End -->
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>


                                        <div class="FixedButtons ">

    
        <div class="right_btn">
    <div class="btn ico-save" id="btn_save1" runat="server">
        <asp:Button ID="btn_save" runat="server" Text="Save" ToolTip="Save" OnClick="btn_save_Click" TabIndex="6" />
    </div>
    <div class="btn ico-view">
        <asp:Button ID="btn_view" runat="server" Text="View" ToolTip="View" OnClick="btn_view_Click" TabIndex="7" />
    </div>
    <div class="btn  btn-cancel1" id="btn_back1" runat="server">
        <asp:Button ID="btn_back" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_back_Click" TabIndex="8" />
    </div>
    <asp:Button ID="btn_search" runat="server" Text="" Style="display: none;" OnClick="btn_search_Click" />
</div>
</div>


                </div>
                <div class="widget-content">

                      

                    <div class="FormGroupContent4 boxmodal">
                        <div class="TypeDrop">
                            <asp:Label ID="Label6" runat="server" Text="Country"> </asp:Label>
                            <asp:DropDownList ID="ddl_Branch" Data-Placeholder="Country" ToolTip="Country" AutoPostBack="true" runat="server" CssClass="form-control chzn-select" TabIndex="6" OnSelectedIndexChanged="ddl_Branch_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="TypeDrop">
                            <asp:Label ID="Label1" runat="server" Text="Charge Type"> </asp:Label>
                            <asp:DropDownList ID="ddl_cmbChargeType" Data-Placeholder="Charge Type" ToolTip="Type" AutoPostBack="true" runat="server" CssClass="chzn-select" OnSelectedIndexChanged="ddl_cmbChargeType_SelectedIndexChanged" TabIndex="1">
                            </asp:DropDownList>
                        </div>
                        <div class="ChargesInput1">
                            <asp:Label ID="Label2" runat="server" Text="Charge"> </asp:Label>
                            <asp:TextBox ID="txt_Charges" runat="server" CssClass="form-control" onkeyup="submitForm()" onkeypress="submitForm()" ToolTip="Charge" placeholder="" AutoPostBack="True" OnTextChanged="txt_Charges_TextChanged" TabIndex="2"></asp:TextBox>
                        </div>
                        <div class="Shipper2">
                            <asp:Label ID="Label3" runat="server" Text="SACCode"> </asp:Label>
                            <asp:TextBox ID="txt_saccode" runat="server" CssClass="form-control" MaxLength="6" ToolTip="SACCode" placeholder="" TabIndex="4"></asp:TextBox>
                        </div>

                        <div class="Consignee4">
                            <asp:Label ID="Label7" runat="server" Text="VAT%"> </asp:Label>
                            <asp:TextBox ID="txt_vat" runat="server" CssClass="form-control" MaxLength="2" ToolTip="VAt%" placeholder="" TabIndex="7" onkeyup="CheckTextLength(this,2);"></asp:TextBox>
                        </div>

                        <div class="Consignee4">
                            <asp:Label ID="Label5" runat="server" Text="GST%"> </asp:Label>
                            <asp:TextBox ID="txt_gstp" runat="server" CssClass="form-control" MaxLength="2" ToolTip="GST%" placeholder="" TabIndex="5" onkeyup="CheckTextLength(this,2);"></asp:TextBox>
                        </div>
                        <div class="Reimbursement">
                            <asp:Label ID="Label8" runat="server" Text="Reimbursement"> </asp:Label>

                                <asp:DropDownList ID="ddl_reimbursement"  runat="server" CssClass="chzn-select form-control"  Data-Placeholder="Reimbursement" ToolTip="reimbursement">
                                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                                    <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                    <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                </asp:DropDownList></div>



                     <%--   ----NIVETHA 06102022-----%>
                           <div class="Reimbursement"  id="Label9_id"  runat="server" >
                            
                            <asp:Label ID="Label9" runat="server" Text="Freight Component" Visible="False"> </asp:Label>

                                <asp:DropDownList ID="ddl_newinvoiceno"  runat="server" CssClass="chzn-select form-control"  Data-Placeholder="" ToolTip="Freight Component" Visible="False">
                                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                                    <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                    <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                </asp:DropDownList></div>
                        <%------NIVETHA 06102022-----%>


                        <div id="AdminCharges" runat="server">

                            <div class="Subgroup1">
                                <span>Sub  Group Name</span>
                                <asp:TextBox ID="txt_subgroup" runat="server" CssClass="form-control" MaxLength="5" TabIndex="6" ToolTip="SubGroupName" placeholder="SubGroupName" AutoPostBack="true" OnTextChanged="txt_subgroup_TextChanged"></asp:TextBox>
                            </div>


                            <div class="Clear"></div>
                            <div class="GroupName1">
                                <span>Group Name</span>
                                <asp:TextBox ID="txt_group" runat="server" CssClass="form-control" MaxLength="5" ToolTip="GroupName" placeholder="GroupName" TabIndex="5"></asp:TextBox>
                            </div>
                            <div class="GroupType">
                                <span>Group Type</span>
                                <asp:TextBox ID="txt_type" runat="server" CssClass="form-control" MaxLength="5" ToolTip="Type" placeholder="Type" TabIndex="5"></asp:TextBox>
                            </div>
                        </div>
                     


                    </div>
                    <div class="FormGroupContent4" style="display: none;">
                        <div class="CurrencyInput">
                            <asp:TextBox ID="txt_Curr" runat="server" CssClass="form-control" MaxLength="3" ToolTip="Currency" placeholder="Currency"></asp:TextBox>
                        </div>
                        <div class="Amount6">
                            <asp:TextBox ID="txt_Amt" runat="server" CssClass="form-control" MaxLength="10" ToolTip="Amount" placeholder="Amount"></asp:TextBox>
                        </div>
                        <div class="STInput">
                            <asp:TextBox ID="txt_Percent" runat="server" CssClass="form-control" MaxLength="5" ToolTip="Currency" placeholder="ST %"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4" style="display: none;">
                        <div class="Shipper1">
                            <asp:TextBox ID="txtsbcess" runat="server" CssClass="form-control" MaxLength="10" ToolTip="SB. Cess %" placeholder="SB. Cess %"></asp:TextBox>
                        </div>
                        <div class="Consignee3">
                            <asp:TextBox ID="txtkkcess" runat="server" CssClass="form-control" MaxLength="5" ToolTip="KK. Cess %" placeholder="KK. Cess %"></asp:TextBox>
                        </div>

                    </div>
                    <div class="div_break"></div>

          
                    <div class="FormGroupContent4 boxmodal">
                        <div class="search">
                              <asp:Label ID="Label10" runat="server" Text="Search"></asp:Label>
                                        <asp:TextBox ID="txt_Search" runat="server" CssClass="form-control" 
                            OnTextChanged="txt_Search_TextChanged" MaxLength="100" Placeholder="Search" AutoPostBack="true"
                             onkeyup="GetDetail();" TabIndex="11"></asp:TextBox>
                        </div>
            
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="gridpnl">
                            <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader"
                                BorderStyle="None" ShowHeaderWhenEmpty="True" OnPageIndexChanging="grd_PageIndexChanging">
                                <%--AllowPaging="false" PageSize="12"--%>
                                <Columns>
                                    <asp:BoundField DataField="chargename" HeaderText="Charges" />
                                    <%-- <asp:BoundField DataField="currency" HeaderText="Curr" ItemStyle-HorizontalAlign="Left">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <HeaderStyle />
                </asp:BoundField>--%>
                                    <%--  <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}"
                    ItemStyle-HorizontalAlign="Right">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="percentage" HeaderText="%" ItemStyle-HorizontalAlign="left">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="stcode" HeaderText="stcode" ItemStyle-HorizontalAlign="Right"
                    Visible="false">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="chargeid" HeaderText="chargeid" ItemStyle-HorizontalAlign="Right"
                    Visible="false">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>--%>
                                    <asp:BoundField DataField="chargetype" HeaderText="Charge Type" DataFormatString="{0:#,##0.00}"
                                        ItemStyle-HorizontalAlign="Right">
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SACCode" HeaderText="SACCode" DataFormatString="{0:#,##0.00}"
                                        ItemStyle-HorizontalAlign="Right">
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GSTP" HeaderText="GSTP" DataFormatString="{0:#,##0.00}"
                                        ItemStyle-HorizontalAlign="Right">
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridviewScrollHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <asp:HiddenField ID="hf_chargeid" runat="server" />
                        <asp:HiddenField ID="hf_curid" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div id="PanelLog1" runat="server">
        <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
            <div class="divRoated">
                <div class="LogHeadLbl">
                    <div class="LogHeadJob">
                        <label id="lbl" runat="server">Charge Name:</label>

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

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image3" BehaviorID="Test1">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="hid_SubGroupid" runat="server" />
    <asp:HiddenField ID="hid_GroupID" runat="server" />
    <asp:HiddenField ID="hid_newinvoce" runat="server" />
    <asp:HiddenField ID="hidledgid" runat="server" />
    <asp:HiddenField ID="hidgst" runat="server" />
        <asp:HiddenField ID="hidgst1" runat="server" />
        <asp:HiddenField ID="hidvat" runat="server" />

</asp:Content>
