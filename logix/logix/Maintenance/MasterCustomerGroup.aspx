<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="MasterCustomerGroup.aspx.cs" Inherits="logix.Maintenance.MasterCustomerGroup" %>

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
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

    <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

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

    <link href="../Styles/MasterCustomerGroup.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/button1.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>


    <style type="text/css">
        .Hide {
            display: none;
        }
    </style>


    <script type="text/javascript">

        function pageLoad(sender, args) {

            <%--$(document).ready(function () {
                  $('#<%=CustGroup_grid.ClientID%>').gridviewScroll({
                        width: 583,
                        height: 220,
                        arrowsize: 30,

                        varrowtopimg: "../images/arrowvt.png",
                        varrowbottomimg: "../images/arrowvb.png",
                        harrowleftimg: "../images/arrowhl.png",
                        harrowrightimg: "../images/arrowhr.png"
                    });
              });--%>

             <%-- $(document).ready(function () {
                  $("#<%=txtname.ClientID %>").autocomplete({
                      source: function (request, response) {
                          $.ajax({
                              url: "MasterCustomerGroup.aspx/GetCustomer",
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
                                  alertify.alert(response.responseText);
                              },
                              failure: function (response) {
                                  alertify.alert(response.responseText);
                              }
                          });
                      },
                      select: function (event, i) {
                          $("#<%=txtname.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                        $("#<%=txtname.ClientID %>").val(i.item.address);
                        $("#<%=hdn_cus.ClientID %>").val(i.item.val);
                        $("#<%=txtname.ClientID %>").change();
                    },
                      focus: function (event, i) {
                          $("#<%=txtname.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
               
                        $("#<%=hdn_cus.ClientID %>").val(i.item.val);
                        $("#<%=txtname.ClientID %>").val($.trim(result));

                    },
                      change: function (event, i) {
                          if (i.item) {
                              $("#<%=txtname.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=txtname.ClientID %>").val(i.item.address);
                            $("#<%=hdn_cus.ClientID %>").val(i.item.val);
                            $("#<%=txtname.ClientID %>").change();
                        }
                    },

                      close: function (event, i) {
                          var result = $("#<%=txtname.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtname.ClientID %>").val($.trim(result));
                    },
                      minLength: 1

                  });
              });--%>



            $(document).ready(function () {
                $("#<%=txtname.ClientID %>").autocomplete({
                      source: function (request, response) {
                          $.ajax({
                              url: "MasterCustomerGroup.aspx/GetCustomer",
                              data: "{ 'prefix': '" + request.term + "'}",
                              dataType: "json",
                              type: "POST",
                              contentType: "application/json; charset=utf-8",
                              success: function (data) {

                                  response($.map(data.d, function (item) {

                                      return {
                                          label: item.split('~')[0],
                                          val: item.split('~')[1],
                                          custid: item.split('~')[2],
                                          address: item.split('~')[3]
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
                          $("#<%=txtname.ClientID %>").val(i.item.label);
                          $("#<%=txtname.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                          $("#<%=hdn_cus.ClientID %>").val(i.item.val);
                          $("#<%=hid_custid.ClientID %>").val(i.item.custid);
                          $("#<%=txtname.ClientID %>").change();
                      },
                      focus: function (event, i) {
                          $("#<%=txtname.ClientID %>").val(i.item.label);
                          $("#<%=txtname.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                          $("#<%=hid_custid.ClientID %>").val(i.item.custid);
                          $("#<%=hdn_cus.ClientID %>").val(i.item.val);
                      },
                      change: function (event, i) {
                          if (i.item) {
                              $("#<%=txtname.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                             <%-- $("#<%=txtname.ClientID %>").val(i.item.label);--%>
                              $("#<%=hid_custid.ClientID %>").val(i.item.custid);
                              $("#<%=hdn_cus.ClientID %>").val(i.item.val);
                              <%--$("#<%=txtname.ClientID %>").change();--%>
                          }
                      },

                      close: function (event, i) {
                          var result = $("#<%=txtname.ClientID %>").val().toString().split(' ,')[0];
                          $("#<%=txtname.ClientID %>").val($.trim(result));
                      },
                      minLength: 1

                  });
              });




            //            -----------------------------------------------------------------------------------

            <%--   $(document).ready(function () {
                $("#<%=txt_person.ClientID %>").autocomplete({
                      source: function (request, response) {
                          $.ajax({
                              url: "MasterCustomerGroup.aspx/GetPTC",
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
                          $("#<%=txt_person.ClientID %>").val(i.item.label);
                        $("#<%=txt_person.ClientID %>").change();
                        $("#<%=hdn_emp.ClientID %>").val(i.item.val);
                    },
                      focus: function (event, i) {
                          $("#<%=txt_person.ClientID %>").val(i.item.label);
                    $("#<%=hdn_emp.ClientID %>").val(i.item.val);
                },
                      close: function (event, i) {
                          $("#<%=txt_person.ClientID %>").val(i.item.label);
                    $("#<%=hdn_emp.ClientID %>").val(i.item.val);
                },
                      minLength: 1
                  });
              });--%>


       <%-- $(document).ready(function () {
                 $("#<%=txt_search.ClientID %>").autocomplete({
                   source: function (request, response) {
                        $.ajax({
                               url: "MasterCustomerGroup.aspx/GetCustomerSearch",
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
                                   alertify.alert(response.responseText);
                               },
                               failure: function (response) {
                                   alertify.alert(response.responseText);
                               }
                           });
                       },
                       select: function (event, i) {
                           $("#<%=txt_search.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                          $("#<%=txt_search.ClientID %>").val(i.item.address);
                          $("#<%=hdnSearch.ClientID %>").val(i.item.val);
                          $("#<%=txt_search.ClientID %>").change();
                      },
                      focus: function (event, i) {
                          $("#<%=txt_search.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                          $("#<%=txt_search.ClientID %>").val(i.item.address);
                          $("#<%=hdnSearch.ClientID %>").val(i.item.val);
                          $("#<%=txt_search.ClientID %>").val($.trim(result));
                          $("#<%=txt_search.ClientID %>").change();

                      },
                      change: function (event, i) {
                          if (i.item) {
                              $("#<%=txt_search.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                              $("#<%=txt_search.ClientID %>").val(i.item.address);
                              $("#<%=hdnSearch.ClientID %>").val(i.item.val);
                              $("#<%=txt_search.ClientID %>").change();
                          }
                      },

                      close: function (event, i) {
                          var result = $("#<%=txtname.ClientID %>").val().toString().split(',')[0];
                          $("#<%=txt_search.ClientID %>").val($.trim(result));
                      },
                      minLength: 1

                  });
               })--%>

            $(document).ready(function () {
                $("#<%=txtlocation.ClientID %>").autocomplete({
                      source: function (request, response) {
                          $.ajax({
                              url: "MasterLocation.aspx/GetLocation",
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
                                  alertify.alert(response.responseText);
                              },
                              failure: function (response) {
                                  alertify.alert(response.responseText);
                              }
                          });
                      },
                      select: function (event, i) {
                          $("#<%=txtlocation.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                          $("#<%=txtcity.ClientID %>").val(i.item.address);
                          $("#<%=hf_locationid.ClientID %>").val(i.item.val);
                          $("#<%=txtlocation.ClientID %>").change();
                      },
                      focus: function (event, i) {
                          $("#<%=txtlocation.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                          $("#<%=txtcity.ClientID %>").val(i.item.address);
                          $("#<%=hf_locationid.ClientID %>").val(i.item.val);
                          $("#<%=txtlocation.ClientID %>").val($.trim(result));
                          $("#<%=txtlocation.ClientID %>").change();

                      },
                      change: function (event, i) {
                          if (i.item) {
                              $("#<%=txtlocation.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                              $("#<%=txtcity.ClientID %>").val(i.item.address);
                              $("#<%=hf_locationid.ClientID %>").val(i.item.val);
                              $("#<%=txtlocation.ClientID %>").change();
                          }
                      },

                      close: function (event, i) {
                          var result = $("#<%=txtlocation.ClientID %>").val().toString().split(',')[0];
                          $("#<%=txtlocation.ClientID %>").val($.trim(result));
                      },
                      minLength: 1

                  });
              });

         <%--     $(document).ready(function () {
                  $('#<%=CustGroup_grid  .ClientID%>').gridviewScroll({
                           width: 540,
                           height: 120,
                           arrowsize: 30,
                           "scrollX": false,

                           varrowtopimg: "../images/arrowvt.png",
                           varrowbottomimg: "../images/arrowvb.png",
                           harrowleftimg: "../images/arrowhl.png",
                           harrowrightimg: "../images/arrowhr.png"
                       });
                   });--%>



        }

    </script>


    <script type="text/javascript">
        function TxtFocus() {

            var el = $("#<%=txt_search.ClientID %>").get(0);
            var elemLen = el.value.length;
            el.selectionStart = elemLen;
            el.selectionEnd = elemLen;
            el.focus();
        }

        function GetDetail() {
            $.ajax({
                type: "POST",
                url: "../Maintenance/MasterCustomerGroup.aspx/GetBanName",
                data: '{Prefix: "' + $("#<%=txt_search.ClientID %>").val() + '" }',
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
                font-family: sans-serif;
                color: #4e4e4c;
            }

        logix_CPH_PanelLog {
            top: 155px !important;
        }


        .CustomerLeft {
            width: 55%;
            float: left;
            margin: 5px 0.5% 0px 0px;
        }

        #logix_CPH_Book2 {
            height: 403px;
            overflow-y: auto !important;
            overflow-x: hidden;
        }


        .CustomerRight {
            width: 44.5%;
            float: left;
            margin: 10px 0px 0px 0px !important;
        }
        .widget.box{
    position: relative;
    top: -8px;
}
        .panel_24 {
    height: 500px !important;
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


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">



    <!-- Breadcrumbs line End -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="Label1" runat="server" Text="Customer Group"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
                        <div class="crumbs">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <li><a href="#" title="">Maintenance</a> </li>
                                <li class="current"><a href="#" title="">Customer Group </a></li>
                            </ul>
                        </div>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
                <div class="widget-content">
                    <div class="CustomerLeft">
                        <div class="FormGroupContent4 boxmodal">
                        <div class="FormGroupContent4">

                            <asp:TextBox ID="txtname" runat="server" CssClass="form-control" ToolTip="COMPANY" PlaceHolder=" COMPANY" AutoPostBack="true" TabIndex="1" OnTextChanged="txtname_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4 boxmodal">
                        <div class="FormGroupContent4">

                            <asp:TextBox ID="txtaddress" Style="resize: none;" Rows="2" runat="server" CssClass="form-control" ToolTip="ADDRESS" PlaceHolder=" ADDRESS" TextMode="MultiLine" TabIndex="2"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4 boxmodal">

                        <div class="FormGroupContent4">
                            <div class="ServiceTax1">
                                <asp:TextBox ID="txtlocation" runat="server" CssClass="form-control" ToolTip="LOCATION" PlaceHolder=" LOCATION" AutoPostBack="true" TabIndex="3" OnTextChanged="txtlocation_TextChanged"></asp:TextBox>
                            </div>
                            <div class="ServiceTax2">
                                <asp:TextBox ID="txtcity" runat="server" CssClass="form-control" ToolTip="CITY" PlaceHolder=" CITY" TabIndex="4"></asp:TextBox>
                            </div>
                            <div class="ServiceTax4">
                                <asp:TextBox ID="txtzip" runat="server" CssClass="form-control" ToolTip="ZIP" PlaceHolder=" ZIP" TabIndex="5" onkeypress="return isNumberKey (event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="ServiceTax1">
                                <asp:TextBox ID="txtphone" runat="server" CssClass="form-control" ToolTip="#PHONE" PlaceHolder=" PHONE Number" TabIndex="6" onkeyup="CheckTextLength(this,10);" onkeypress="return isNumberKey (event)"></asp:TextBox>
                            </div>
                            <div class="ServiceTax2">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ToolTip="EMAIL" PlaceHolder=" EMAIL" AutoPostBack="true" TabIndex="7" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
                            </div>
                            <div class="ServiceTax4">
                                <asp:TextBox ID="txtfax" runat="server" CssClass="form-control" ToolTip="#FAX" PlaceHolder=" FAX Number" TabIndex="8" onkeypress="return isNumberKey (event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <asp:TextBox ID="txt_person" runat="server" CssClass="form-control" ToolTip="CONTACTPERSON" PlaceHolder=" CONTACTPERSON" TabIndex="9"></asp:TextBox>
                        </div>
                            </div>
                        <div class="FormGroupContent4">
                            <div class="right_btn">
                                <div class="btn ico-save">
                                    <asp:Button ID="btnsave" runat="server" Text="Save" TabIndex="10" OnClick="Button_save_Click" OnClientClick="disableBtn(this.id, 'Loading...')" UseSubmitBehavior="False" />
                                </div>
                                <div class="btn ico-view" style="display: none">
                                    <asp:Button ID="btnview" runat="server" Text="View" TabIndex="11" />
                                </div>
                                <div class="btn ico-cancel">
                                    <asp:Button ID="btncancel" runat="server" Text="Cancel" TabIndex="12" OnClick="btncancel_Click" />
                                </div>
                            </div>
                        </div>

                        <div class="FormGroupContent4 boxmodal">

                        <div class="FormGroupContent4">
                            <asp:TextBox ID="txt_search" runat="server" CssClass="form-control" ToolTip="SEARCH" PlaceHolder=" SEARCH" TabIndex="13" OnTextChanged="txt_search_TextChanged" onkeyup="GetDetail();"></asp:TextBox>
                        </div>
                        <div class="FormGroupContent4">
                            <asp:Panel ID="job" runat="server" Style="margin-left: 0%;" CssClass="panel_05 MB0" ScrollBars="Vertical">
                                <asp:GridView ID="CustGroup_grid" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader"
                                    Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="true">
                                    <Columns>

                                        <%--<asp:TemplateField HeaderText="SNo">
                    <ItemTemplate>
                    <asp:Label ID="lblSerial" runat="server"></asp:Label>
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>--%>
                                        <%--<asp:BoundField DataField="sno" HeaderText="S#">  
        <HeaderStyle />
        <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  />          
        </asp:BoundField>--%>
                                        <asp:BoundField DataField="customername" HeaderText="Customer">
                                            <HeaderStyle />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Justify" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="portname" HeaderText=" City ">
                                            <HeaderStyle />
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Justify" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="customerid" HeaderText="customerid"><%--  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"--%>
                                            <HeaderStyle CssClass="Hide"></HeaderStyle>
                                            <ItemStyle CssClass="Hide"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRow" AutoPostBack="true" runat="server" />
                                            </ItemTemplate>

                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="groupid" HeaderText="groupid" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                            <HeaderStyle CssClass="Hide"></HeaderStyle>

                                            <ItemStyle CssClass="Hide"></ItemStyle>
                                        </asp:BoundField>
                                    </Columns>

                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <PagerStyle CssClass="GridviewScrollPager" />


                                </asp:GridView>
                            </asp:Panel>
                        </div>
                            </div>
                        <div class="FormGroupContent4">
                            <div class="right_btn">
                                <div class="btn ico-update">
                                    <asp:Button ID="btnGrdUpdate" runat="server" Text="Update" TabIndex="14" OnClick="btnGrdUpdate_Click" OnClientClick="disableBtn(this.id, 'Loading...')" UseSubmitBehavior="False" />

                                    <asp:Button ID="btn_search" runat="server" Text="" CssClass="btn" Style="display: none;"
                                        Width="15%" OnClick="btn_search_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="CustomerRight boxmodal">
                        <asp:Panel ID="Book2" runat="server" CssClass="panel_24 MB0 " Visible="true">
                            <asp:GridView ID="test" runat="server" CssClass="Grid FixedHeader" ShowHeaderWhenEmpty="true">
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" />
                            </asp:GridView>


                            <div class="div_Break"></div>
                        </asp:Panel>
                    </div>





                </div>
            </div>
        </div>
    </div>


    <asp:HiddenField ID="hf_locationid" runat="server" />
    <asp:HiddenField ID="hdn_cus" runat="server" />
    <asp:HiddenField ID="hdn_emp" runat="server" />
    <asp:HiddenField ID="hdnSearch" runat="server" />
    <asp:HiddenField ID="hdf_cusid" runat="server" />
    <asp:HiddenField ID="hid_sal" runat="server" />
    <asp:HiddenField ID="hid_own" runat="server" />

    <asp:HiddenField ID="hid_custid" runat="server" />

    <div id="PanelLog1" runat="server">
        <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
            <div class="divRoated">
                <div class="LogHeadLbl">
                    <div class="LogHeadJob">
                        <label id="lbl" runat="server">Customer Name :</label>

                    </div>
                    <div class="LogHeadJobInput">

                        <asp:Label ID="JobInput" runat="server"></asp:Label>

                    </div>

                </div>
                <div class="DivSecPanel">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
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
    </div>
    <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image3" BehaviorID="Test1">
    </asp:ModalPopupExtender>
</asp:Content>


