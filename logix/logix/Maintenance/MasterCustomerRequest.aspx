<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="MasterCustomerRequest.aspx.cs" EnableEventValidation="false" Inherits="logix.Maintenance.MasterCustomerRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">

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
         <script src="../js/helper.js"></script>
     <script src="../js/TextField.js"></script>

     <script type="text/javascript">
         function dropdownButton() {
             $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
         }

    </script>



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
            margin-top: -1.9%;
            border-radius: 90px 90px 90px 90px;
        }

        .modalPopupss {
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

        .Gridpnl {
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
    width: 13%;
    float: left;
    margin: 0px  0px 0px 0.5%;
}
        #logix_CPH_popup_Grd_foregroundElement {
            left: 0px !important;
            top: 33px !important;
        }


        .TDS2 {
            width: 50%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TDS3 {
            width: 13%;
            float: left;
            margin: 0px 0% 0px 0px;
        }
         .VendorRef {
    width: 12%;
    float: left;
    margin: 0px 0% 0px 0px;
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
height:20px;
border :1px solid #999997;
background-color:blue;
	background: #D0D0C9;
    background: -moz-linear-gradient(top,  #D0D0C9 0%, #D0D0C9 44%, #D0D0C9 100%);
	background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#D0D0C9), color-stop(44%,#D0D0C9), color-stop(100%,#D0D0C9));
	background: -webkit-linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
	background: -o-linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
	background: -ms-linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
	background: linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
  
    font-size:small;
	display: inline;
	/*position: absolute;*/
	/*overflow: hidden;*/
	cursor: pointer;
-webkit-appearance:push-button;
margin-top:0.1%;
/*margin-top:3%;*/
margin-left:1%;
 margin-bottom:0%;
 /*margin-top :1%;*/
 text-align:center;

}
.fileUpload input.upload {
    position: absolute;
    top: 0px;
    margin: 0px 0 0 0;
    padding: 0;
    font-size:13px;
    cursor: pointer;
    opacity: 0;
    filter: alpha(opacity=4);
         left: 0px;
         width: 304px;
     }
.logoimg
{
    height:106px;
    width:97%;
    margin-left :1%;
    color:aliceblue;
    /*float:right;*/
    left:10%;
    /*margin-top:-11.5%;*/
    /*margin-top:1%;*/
    margin-top:0%;
    margin-right:1%;
        
}

     div.file_upload {
	/*width: 10.5%;*/
    width:110px;
	height: 18px;
	/*background: #D0D0C9;*/
    background-color:aliceblue;
	/*background: -moz-linear-gradient(top,  #D0D0C9 0%, #D0D0C9 44%, #D0D0C9 100%);
	background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#D0D0C9), color-stop(44%,#D0D0C9), color-stop(100%,#D0D0C9));
	background: -webkit-linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
	background: -o-linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
	background: -ms-linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
	background: linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);*/
	filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#D0D0C9', endColorstr='#D0D0C9',GradientType=0 ); 
    font-size:small;
	display: inline;
	position: absolute;
	overflow: hidden;
	cursor: pointer;
	margin-top:0.1%;
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
	padding-bottom:0.2%;
}
div.file_upload:before {
	content: 'UPLOAD';
	color:Black;
    margin-bottom:3%;
	position: absolute;
	left: 0; right: 0;
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

.BurateCal {
    float: left;
    width: 17.5%;
    margin: 0px 0.5% 0px 0%;
}

        .KycCustomerHead span {
            font-size:12px;
            color:##2F0D8F;
        }
        #logix_CPH_ddlIDProof_chzn {
            width:100%!important;
        }
        .BillDrop2 {
    width: 10%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .FileUpload2 {
    width: 23.5%;
    float: left;
}
        a.chzn-single.chzn-default {
    margin: 0 !important;
}
        .chzn-search span {
    display: none;
}
        input[type=file] {
    height: 36px !important;
    padding: 8px;
}
        div#logix_CPH_Div2 {
    margin: 15px 0 0 7px;
}
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
            $(document).ready(function () {
                $("#<%=txtlocation.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "MasterCustomerRequest.aspx/GetLocation",
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

            $("#<%= txtcustomer.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hf_customerid.ClientID %>").val(0);
                    $.ajax({
                        url: "MasterCustomerRequest.aspx/GetCustomer",
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
            $("#<%=txtcity  .ClientID %>").autocomplete({
                     source: function (request, response) {

                         $.ajax({
                             url: "MasterCustomerRequest.aspx/GetPortName",
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
            $("#<%=txtpincode .ClientID %>").autocomplete({
                source: function (request, response) {

                    $.ajax({
                        url: "MasterCustomerRequest.aspx/GetPincode",
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


            $(document).ready(function () {
                $("#<%=txt_Salesperson.ClientID %>").autocomplete({
                       source: function (request, response) {
                           $("#<%=hf_employeeid.ClientID %>").val(0);
                          $.ajax({
                              url: "MasterCustomerRequest.aspx/GetEmployeename",
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
                      select: function (event, i) {
                          $("#<%=txt_Salesperson.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                         $("#<%=txt_Salesperson.ClientID %>").change();
                         $("#<%=hf_employeeid.ClientID %>").val(i.item.val);
                     },
                    focus: function (event, i) {
                        $("#<%=txt_Salesperson.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hf_employeeid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_Salesperson.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hf_employeeid.ClientID %>").val(i.item.val);
                        }
                    },
                    close: function (event, i) {
                        var result = $("#<%=txt_Salesperson.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_Salesperson.ClientID %>").val($.trim(result));
                        $("#<%=hf_employeeid.ClientID %>").val(i.item.val);
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

        .modalPopupss {
            background-color: #FFFFFF;
            /* border-width: 1px; */
            border-style: solid;
            border-color: #CCCCCC;
            width: 97%;
            Height: 555px;
            margin-left: 0%;
            margin-top: 0%;
        }
    </style>

    <style type="text/css">
        .Mandatory input {
            border: 1px solid #f95700 !important;
        }

        .Mandatory select {
            border: 1px solid #f95700 !important;
        }

        .Mandatory .chzn-container {
            border: 1px solid #f95700 !important;
            border-radius: 6px;
        }

        .Mandatory .chzn-container-single .chzn-single {
            border: 0px solid #FF0000 !important;
        }

        .State2 {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Country2 {
            width: 16%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TDS1 {
            width: 9%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }



        .Shipper1 {
            width: 21%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .ServiceTax {
            width: 10.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TDS2 {
            width: 13%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Zip1 {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .Consignee3 {
            width: 41%;
            margin: 0px 0px 0px 0px;
            float: left;
        }

        .Country2 {
            width: 41%;
            float: left;
            margin: 0px 0% 0px 0px;
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
                font-family: sans-serif;
                color: #4e4e4c;
            }

        logix_CPH_PanelLog {
            top: 155px !important;
        }
        .MGMT2 {
    width: 81.2%;
    float: left;
    margin: 0px 0.5% 0px 82px;
}
        .MGMT1 {
    width: 81.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .Image1Txt {
            width:12.5%;
            float:left;
            margin:10px 1.5% 5px 0px;
        }
          .Image1Txt1 {
            width:12.5%;
            float:left;
            margin:0px 1.5% 5px 0px;
        }
            .Image1Txt2 {
            width:12.5%;
            float:left;
            margin:0px 1.5% 5px 0px;
        }
  .Image1Txt3 {
            width:12.5%;
            float:left;
            margin:0px 1.5% 5px 0px;
        }
  .Image1Txt4 {
            width:12.5%;
            float:left;
            margin:0px 1.5% 0px 0px;
        }
  .BrowseFileUpload {
    width: 85.5%;
    float: left;
        margin: 0;
}
        .PDFLeft {
            float:left;
            width:35%;
            margin:5px 0.5% 0px 0px !important;
        }
        .PDFRight {
            float:left;
            width:64.5%;
            margin:0px 0px 0px 0px;
        }
        .MRDropN1 {
    width: 16%;
    float: left;
    margin: 0px 1.5% 0px 0px;
}

        .Email1 {
    width: 24.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .div_salesperson {
    float: left;
    width: 24.5%;
    margin: 0px 0px 0px 0px;
}

        .LimitTxtBox {
              float: left;
    width: 21%;
    margin: 0px 0.5% 0px 0px;
        }

        .ExemptionTxt {
              float: left;
    width: 10.5%;
    margin: 0px 0.5% 0px 0px;
        }
        .Exemption2{
              float: left;
    width: 10%;
    margin: 0px 0.5% 0px 0px;
        }
        .Certificate1{
              float: left;
    width: 7%;
    margin: 0px 0.5% 0px 0px;
        }
        .Certificate1 span {
    white-space: nowrap;
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
    <asp:Panel runat="server">

        <!-- Breadcrumbs line End -->
        <div >
            <div class="col-md-12  maindiv">

                <div class="widget box" runat="server" id="div_iframe">
                    <div class="widget-header">
                        <div style="float: left; margin: 0px 0.5% 0px 0px;">
                            <h4 class="hide"><i class="icon-umbrella"></i>
                                <asp:Label ID="lbl_Header" runat="server" Text="New RequestCustomer"></asp:Label></h4>
                            
        <!-- Breadcrumbs line -->
        <div class="crumbs">
            <ul id="breadcrumbs" class="breadcrumb">
                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                <li><a href="#" title="">Maintenance</a> </li>
                <li class="current"><a href="#" title="">New RequestCustomer</a> </li>
            </ul>
        </div>
                        </div>

                        <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                            <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                        </div>
                    </div>
                    <div class="widget-content">
                        <div class="FormGroupContent4 Mandatory boxmodal">
                        <div class="FormGroupContent4">

                            <span>Customer</span>
                            <asp:TextBox ID="txtcustomer" ToolTip="Customer" CssClass="form-control" placeholder="Customer" runat="server" TabIndex="1" AutoPostBack="True" OnTextChanged="txtcustomer_TextChanged" onkeyup="CheckTextLength(this,200);" onKeyDown="return DisableControlKey(event)"  onMouseDown="return DisableControlKey(event)" onkeypress="return RestrictCommaSemicolon(event);" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4 boxmodal">
                        <div class="FormGroupContent4">

                            <span>CUSTOMER TYPE</span>
                            <asp:DropDownList ID="ddlCType" CssClass="chzn-select form-control" runat="server" data-placeholder="CUSTOMER TYPE" TabIndex="2">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                                <asp:ListItem Text="CHA / Shipper / Consignee / Notify Party / Carrier / Airliner/ MLO / Freight Forwarder / Warehouse / Transporter / Others" Value="C"></asp:ListItem>
                                <asp:ListItem Text="Agent / Principal / Counter Part" Value="P"></asp:ListItem>
                               <%-- <asp:ListItem Text="Depo" Value="W"></asp:ListItem>--%>
                            </asp:DropDownList>
                            </div>
                        </div>
                        <div class="FormGroupContent4 boxmodal">

                        <div class="FormGroupContent4 Mandatory">
                            <div class="UnitsInput1">
                                <span>Unit #</span>
                                <asp:TextBox ID="txtunit" runat="server" ToolTip="Unit#" CssClass="form-control" placeholder="Unit#" TabIndex="3" onkeyup="CheckTextLength(this,10);"></asp:TextBox>
                            </div>
                            <div class="BuildingName">
                                <span>BuildingName</span>
                                <asp:TextBox ID="txtbuildingname" ToolTip="BuildingName" CssClass="form-control" placeholder="BuildingName" runat="server" TabIndex="4" onkeyup="CheckTextLength(this,50);" ></asp:TextBox>
                            </div>
                            <div class="UnitsInput1">
                                <span>Door #</span>
                                <asp:TextBox ID="txtdoor" runat="server" ToolTip="Door#" placeholder="Door#" CssClass="form-control" TabIndex="5" onkeyup="CheckTextLength(this,10);"></asp:TextBox>
                            </div>
                            <div class="StreetInput1">
                                <span>Street</span>
                                <asp:TextBox ID="txtstreet" ToolTip="Street" placeholder="Street" runat="server" CssClass="form-control" TabIndex="6" onkeyup="CheckTextLength(this,100);"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="Shipper3 Mandatory">
                                <span>City</span>
                                <asp:TextBox ID="txtcity" runat="server" placeholder="City" ToolTip="City" CssClass="form-control" TabIndex="6" AutoPostBack="True" OnTextChanged="txtcity_TextChanged"></asp:TextBox>
                            </div>
                            <div class="Zip1 Mandatory">
                                <span>ZIP/Pincode</span>
                                <asp:TextBox ID="txtpincode" runat="server" AutoPostBack="true" BorderColor="#999997" CssClass="form-control" TabIndex="7" placeholder="ZIP/Pincode" ToolTip="Pincode" OnTextChanged="txtpincode_TextChanged"></asp:TextBox>
                            </div>

                            <div class="Consignee3">
                                <span>Location</span>
                                <asp:TextBox ID="txtlocation" runat="server" CssClass="form-control" placeholder="Location" ToolTip="Location"
                                    AutoPostBack="True" TabIndex="8" OnTextChanged="txtlocation_TextChanged1" onkeyup="CheckTextLength(this,60);"></asp:TextBox>
                                <asp:DropDownList ID="ddllocation" runat="server" ToolTip="Location" Data-Placeholder="Location" AutoPostBack="true" CssClass="chzn-select form-control" Visible="false" Width="100%" OnSelectedIndexChanged="ddllocation_SelectedIndexChanged">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                            </div>
                        <div class="FormGroupContent4 boxmodal">

                        <div class="FormGroupContent4">
                            <div class="District1">
                                <span>District</span>
                                <asp:TextBox ID="txtdistrict" runat="server" placeholder="District" CssClass="form-control" ToolTip="District" Enabled="False"></asp:TextBox>
                            </div>
                            <div class="State1">
                                <span>State</span>
                                <asp:TextBox ID="txtstate" runat="server" placeholder="State" CssClass="form-control" ToolTip="State" Enabled="False"></asp:TextBox>
                            </div>
                            <div class="State2">
                                <span>State GST Code</span>
                                <asp:TextBox ID="txtGSTCode" runat="server" placeholder="State GST Code" CssClass="form-control" ToolTip="State GST Code" Enabled="False"></asp:TextBox>
                            </div>
                            <div class="Country2">
                                <span>Country</span>
                                <asp:TextBox ID="txtcountry" runat="server" placeholder="Country" ToolTip="Country" CssClass="form-control" Enabled="False"></asp:TextBox>
                            </div>


                        </div>
                        <div class="FormGroupContent4">
                            <div class="ISD1">
                                <span>ISD</span>
                                <asp:TextBox ID="txtllisd" runat="server" placeholder="ISD" CssClass="form-control" TabIndex="9" ToolTip="ISD" Enabled="true" OnTextChanged="txtllisd_TextChanged"></asp:TextBox>
                            </div>
                            <div class="STD1">
                                <span>STD</span>
                                <asp:TextBox ID="txtllstd" runat="server" placeholder="STD" CssClass="form-control" ToolTip="STD" TabIndex="10" Enabled="False" AutoPostBack="true" OnTextChanged="txtllstd_TextChanged"></asp:TextBox>
                            </div>
                            <div class="LandLine2">
                                <span>Landline</span>
                                <asp:TextBox ID="txtlandline" CssClass="form-control" placeholder="Landline" ToolTip="Landline" runat="server" TabIndex="11" onkeyup="CheckTextLength(this,10);" onkeypress="return isNumberKey (event)"></asp:TextBox>
                            </div>
                            <div class="ISD1">
                                <span>ISD</span>
                                <asp:TextBox ID="txtfaxisd" runat="server" placeholder="ISD" CssClass="form-control" ToolTip="ISD" Enabled="False"></asp:TextBox>
                            </div>
                            <div class="STD1">
                                <span>STD</span>
                                <asp:TextBox ID="txtfaxstd" runat="server" placeholder="STD" CssClass="form-control" ToolTip="STD" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="Fax1">
                                <span>Fax</span>
                                <asp:TextBox ID="txtfax" placeholder="Fax" CssClass="form-control" ToolTip="Fax" runat="server" TabIndex="12" onkeypress="return isNumberKey (event)"></asp:TextBox>
                            </div>
                        </div>
                            </div>
                        <div class="FormGroupContent4 boxmodal">

                        <div class="FormGroupContent4">
                            <div class="ISD1">
                                <span>ISD</span>
                                <asp:TextBox ID="txtmblisd" placeholder="ISD" ToolTip="ISD" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                            </div>
                            <div class="Mobile1">
                                <span>Mobile</span>
                                <asp:TextBox ID="txtMobile" placeholder="Mobile" CssClass="form-control" ToolTip="Mobile" runat="server" TabIndex="13" onkeyup="CheckTextLength(this,10);" onkeypress="return isNumberKey (event)"></asp:TextBox>
                            </div>
                            <div class="Email1">
                                <span>Email</span>
                                <asp:TextBox ID="txtemail" placeholder="eMail" CssClass="form-control" ToolTip="eMail" runat="server" TabIndex="14" OnTextChanged="txtemail_TextChanged"></asp:TextBox>
                            </div>
                             <div class="div_salesperson">
                                <span>Sales Person</span>
                                <asp:TextBox ID="txt_Salesperson" runat="server" CssClass="form-control" ToolTip="Sales Person" placeholder="Sales Person" AutoPostBack="true" OnTextChanged="txt_Salesperson_TextChanged" BorderColor="#999997" TabIndex="15"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="Shipper1">
                                <span>PAN #</span>
                                <asp:TextBox ID="txtPanNo" placeholder="PAN #" ToolTip="PAN #" runat="server" TabIndex="15" CssClass="form-control" OnTextChanged="txtPanNo_TextChanged" onkeyup="CheckTextLength(this,25);"></asp:TextBox>
                            </div>
                            <div class="ServiceTax">
                                <span>Service Tax #</span>
                                <asp:TextBox ID="txtServiceTaxNo" placeholder="Service Tax #" ToolTip="Service Tax #" runat="server" TabIndex="16" CssClass="form-control" onkeyup="CheckTextLength(this,25);"></asp:TextBox>

                            </div>
                                <div class="BurateCal">
                                <span>Created ON</span>
                         <asp:TextBox ID="dtpValidity" runat="server" CssClass="form-control"  placeholder="Created ON" ToolTip="Created ON"  AutoPostBack="True" TabIndex="2" Enabled="false"></asp:TextBox>

                <%--<asp:CalendarExtender ID="dtdateval" runat="server" TargetControlID="dtpValidity" Format="dd/MM/yyyy" />--%>
                        </div>
                            <div class="TDS1">
                                <span>TDS</span>
                                <asp:TextBox ID="txttds" runat="server" placeholder="TDS" ToolTip="TDS" Enabled="false" CssClass="form-control" TabIndex="17" onkeypress="return isNumberKey (event)"></asp:TextBox>
                            </div>
                            <div class="TDS2">
                                <span>GSTIN</span>
                                <asp:TextBox ID="txt_gstin" runat="server" placeholder="GSTIN" ToolTip="GSTIN" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_gstin_TextChanged"></asp:TextBox>
                            </div>
                            <div class="TDS3">
                                <span>UINNO</span>
                                <asp:TextBox ID="txt_uinno" runat="server" placeholder="UINNO" ToolTip="UINNO" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_uinno_TextChanged"></asp:TextBox>
                            </div>


                            <div class="MRDropdown">
                                <span>Gst Type</span>
                                <asp:DropDownList ID="ddl_Option" runat="server" TabIndex="18" Width="100%" CssClass="chzn-select form-control" ToolTip="Gst Type" data-placeholder="Gst Type">
                                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                                    <asp:ListItem Value="1" Text="">RCM</asp:ListItem>
                                    <asp:ListItem Value="2" Text="">UnRegistered</asp:ListItem>
                                    <asp:ListItem Value="3" Text="">GST Exemption</asp:ListItem>
                                    <asp:ListItem Value="4" Text="">SEZ Exemption</asp:ListItem>
                                    <asp:ListItem Value="5" Text="">Register</asp:ListItem>
                                    <asp:ListItem Value="6" Text="">SEZ</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="right_btn " style="display: none">
                                <asp:CheckBox ID="txt_RCM" runat="server" /><label>RCM</label>
                                <asp:CheckBox ID="txt_unregistered" runat="server" /><label>UnRegistered</label>
                                <asp:CheckBox ID="txt_gstexi" runat="server" /><label>GST Exemption</label>
                            </div>
                        </div>
                            </div>
                       <div class="FormGroupContent4 boxmodal">
                           
                            <div class="LimitTxtBox">
                                <span>LIMIT</span>
                                <asp:TextBox ID="txt_limit" runat="server" placeholder="LIMIT" ToolTip="LIMIT" CssClass="form-control" AutoPostBack="true" ></asp:TextBox>
                            </div>
                                       <div class="ExemptionTxt">
                                <span>Exemption Period From</span>
                         <asp:TextBox ID="txt_empfrom" runat="server" CssClass="form-control"  placeholder="Exemption Period From" ToolTip="Exemption Period From"  AutoPostBack="True" TabIndex="2"></asp:TextBox>

                 <asp:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txt_empfrom" TodaysDateFormat="dd/MM/yyyy">
                                  </asp:CalendarExtender>
                        </div>
                            <div class="Exemption2">
                                <span>Exemption Period To</span>
                         <asp:TextBox ID="txt_empto" runat="server" CssClass="form-control"  placeholder="Exemption Period To" ToolTip="Exemption Period To"  AutoPostBack="True" TabIndex="2" ></asp:TextBox>

                 <asp:CalendarExtender ID="CalendarExtender2" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txt_empto" TodaysDateFormat="dd/MM/yyyy">
                                  </asp:CalendarExtender>
                        </div>

                              <div class="Certificate1">
                                <span>Certificate #</span>
                                <asp:TextBox ID="txt_certno" runat="server" placeholder="Certificate #" ToolTip="Certificate Number" CssClass="form-control" AutoPostBack="true" ></asp:TextBox>
                            </div>

                            <div class="Certificate1">
                                <span>TDS Exemption</span>
                                <asp:TextBox ID="txt_tds_exp" runat="server" placeholder="TDS Exemption" ToolTip="TDS Exemption" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                            </div>
                       </div>
                        <div class="FormGroupContent4">
                        <div class="PDFLeft boxmodal">

                            <div class="FormGroupContent4">
                                 <div class="MRDropN1">
                                <asp:DropDownList ID="ddl_MR" runat="server" TabIndex="18" Width="100%" CssClass="chzn-select form-control">
                                    <asp:ListItem>Mr</asp:ListItem>
                                    <asp:ListItem>Ms</asp:ListItem>
                                    <asp:ListItem>Mrs</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="MGMT1">
                                <span>MANAGEMENT HEAD NAME</span>
                                <asp:TextBox ID="txtmanagptc" runat="server" placeholder="MANAGEMENT HEAD NAME" ToolTip="MANAGEMENT HEAD NAME" CssClass="form-control" TabIndex="19"></asp:TextBox>
                            </div>
                            </div>
                             <div class="FormGroupContent4">
                             <div class="MGMT2">
                                <span>MANAGEMENT HEAD MAIL ID</span>
                                <asp:TextBox ID="txtmailmanag" runat="server" placeholder="MANAGEMENT HEAD MAIL ID" ToolTip="MANAGEMENT HEAD MAIL ID" CssClass="form-control " TabIndex="20" AutoPostBack="true" OnTextChanged="txtmailmanag_TextChanged" ViewStateMode="Enabled"></asp:TextBox>
                            </div>
                                 </div>
                                 <div class="FormGroupContent4">
                                     <div class="MRDropN1">
                                <asp:DropDownList ID="DropDownList1" runat="server" TabIndex="21" Width="100%" CssClass="chzn-select form-control">
                                    <asp:ListItem>Mr</asp:ListItem>
                                    <asp:ListItem>Ms</asp:ListItem>
                                    <asp:ListItem>Mrs</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                            <div class="MGMT1">
                                <span>COMMERCIAL HEAD NAME</span>
                                <asp:TextBox ID="txtcomptc" runat="server" placeholder="COMMERCIAL HEAD NAME" ToolTip="COMMERCIAL HEAD NAME" CssClass="form-control " TabIndex="22" AutoPostBack="true"></asp:TextBox>
                            </div>
                            
                                 </div>
                                  <div class="FormGroupContent4">

                            <div class="MGMT2">
                                <span>COMMERCIAL HEAD MAIL ID</span>
                                <asp:TextBox ID="txtmailcom" runat="server" placeholder="COMMERCIAL HEAD MAIL ID" ToolTip="COMMERCIAL HEAD MAIL ID" CssClass="form-control " TabIndex="23" AutoPostBack="true" OnTextChanged="txtmailcom_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                            <div class="FormGroupContent4">
                                 <div class="MRDropN1">
                                <asp:DropDownList ID="DropDownList2" runat="server" TabIndex="24" Width="100%" CssClass="chzn-select form-control">
                                    <asp:ListItem>Mr</asp:ListItem>
                                    <asp:ListItem>Ms</asp:ListItem>
                                    <asp:ListItem>Mrs</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="MGMT1">
                                <span>EXPORT HEAD NAME</span>
                                <asp:TextBox ID="txtexpptc" runat="server" placeholder="EXPORT HEAD NAME" ToolTip="EXPORT HEAD NAME" CssClass="form-control" AutoPostBack="true" TabIndex="25"></asp:TextBox>
                            </div>
                            </div>
                                 <div class="FormGroupContent4">
                            <div class="MGMT2">
                                <span>EXPORT HEAD MAIL ID</span>
                                <asp:TextBox ID="txtmailexport" runat="server" placeholder="EXPORT HEAD MAIL ID" ToolTip="EXPORT HEAD MAIL ID" CssClass="form-control" TabIndex="26" AutoPostBack="true" OnTextChanged="txtmailexport_TextChanged"></asp:TextBox>
                            </div>

                        </div> 
                             <div class="FormGroupContent4">

                            <div class="MRDropN1">
                                <asp:DropDownList ID="DropDownList3" runat="server" TabIndex="27" Width="100%" CssClass="chzn-select form-control">
                                    <asp:ListItem>Mr</asp:ListItem>
                                    <asp:ListItem>Ms</asp:ListItem>
                                    <asp:ListItem>Mrs</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="MGMT1">
                                <span>IMPORT HEAD NAME</span>
                                <asp:TextBox ID="txtimpptc" runat="server" placeholder="IMPORT HEAD NAME" ToolTip="IMPORT HEAD NAME" CssClass="form-control" AutoPostBack="true" TabIndex="28"></asp:TextBox>
                            </div>
                           </div>  
                             <div class="FormGroupContent4">
                             <div class="MGMT2">
                                <span>IMPORT HEAD MAIL ID</span>
                                <asp:TextBox ID="txtmailimp" runat="server" placeholder="IMPORT HEAD MAIL ID" ToolTip="IMPORT HEAD MAIL ID" CssClass="form-control" AutoPostBack="true" TabIndex="29" OnTextChanged="txtmailimp_TextChanged"></asp:TextBox>
                            </div>


                        </div>
                             <div class="FormGroupContent4">
                            <div class="MRDropN1">
                                <asp:DropDownList ID="DropDownList4" runat="server" TabIndex="30" Width="100%" CssClass="chzn-select form-control">
                                    <asp:ListItem>Mr</asp:ListItem>
                                    <asp:ListItem>Ms</asp:ListItem>
                                    <asp:ListItem>Mrs</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="MGMT1">
                                <span>FINANCIAL HEAD NAME</span>
                                <asp:TextBox ID="txtfinptc" runat="server" Width="100%" placeholder="FINANCIAL HEAD NAME" ToolTip="FINANCIAL HEAD NAME" CssClass="form-control" TabIndex="31" AutoPostBack="true"></asp:TextBox>
                            </div>
                                </div>
                             <div class="FormGroupContent4">
                             <div class="MGMT2">
                                <span>FINANCIAL HEAD MAIL ID</span>
                                <asp:TextBox ID="txtmailfin" runat="server" placeholder="FINANCIAL HEAD MAIL ID" Width="100%" ToolTip="FINANCIAL HEAD MAIL ID" CssClass="form-control" TabIndex="32" AutoPostBack="true" OnTextChanged="txtmailfin_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                        </div>

                        <div class="PDFRight boxmodal">
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
                                <asp:Image ID="Img_Emp" runat="server" Height="46px" Width="108px" BorderStyle="Solid" BorderWidth="1px" ImageUrl="~/images/visitingcard_img.jpg"/>
                            </div>
                            <div class="BrowseFileUpload" >
                                    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Always"  runat="server" >
                                        <ContentTemplate>
                                            <span style="display :block; color:#fff; background-color:#5ba701; color:black; width:121px; font-size:12px; padding:0px 0px 0px 0px;" ></span>
                                            <asp:FileUpload ID="FileUpd_logo"   CssClass="bt" runat="server" onchange="ShowpImagePreview(this);" />
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

                                 <asp:Image ID="Img_Emp1" runat="server" Height="46px" Width="108px" BorderStyle="Solid" BorderWidth="1px" ImageUrl="~/images/visitingcard_img.jpg"/>
                            </div>
                              <div class="BrowseFileUpload" >
                                    <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Always"  runat="server" >
                                        <ContentTemplate>
                                             <span style="display :block; color:#fff; background-color:#5ba701; color:black; width:121px; font-size:12px; padding:0px 0px 0px 0px;" ></span>
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

                                 <asp:Image ID="Img_Emp2" runat="server" Height="46px" Width="108px" BorderStyle="Solid" BorderWidth="1px" ImageUrl="~/images/visitingcard_img.jpg"/>
                            </div>
                            <div class="BrowseFileUpload" >
                                    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Always"  runat="server" >
                                        <ContentTemplate>
                                             <span style="display :block; color:#fff; background-color:#5ba701; color:black; width:121px; font-size:12px; padding:0px 0px 0px 0px;" ></span>
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
                                 <asp:Image ID="Img_Emp3" runat="server" Height="46px" Width="108px" BorderStyle="Solid" BorderWidth="1px" ImageUrl="~/images/visitingcard_img.jpg"/>
                            </div>

                             <div class="BrowseFileUpload" >
                                    <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Always"  runat="server" >
                                        <ContentTemplate>

                                               <span style="display :block; color:#fff; background-color:#5ba701; color:black; width:121px; font-size:12px; padding:0px 0px 0px 0px;" ></span>
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
                                  <asp:Image ID="Img_Emp4" runat="server" Height="46px" Width="108px" BorderStyle="Solid" BorderWidth="1px" ImageUrl="~/images/visitingcard_img.jpg"/>
                                 </div>
                            <div class="BrowseFileUpload" >
                                    <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Always"  runat="server" >
                                        <ContentTemplate>
                                             <span style="display :block; color:#fff; background-color:#5ba701; color:black; width:121px; font-size:12px; padding:0px 0px 0px 0px;" ></span>
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
                       </div>                          
                       
                        <div class="FormGroupContent4">
                            <div class="Request1" style="display:none">
                                <asp:LinkButton ID="lnk_RCL" runat="server" ForeColor="#FF3300" TabIndex="28" Style="text-decoration: none" OnClick="lnk_RCL_Click">Request Customer List</asp:LinkButton>
                            </div>
                            <div class="right_btn">
                                <div class="btn ico-send" id="btnSave1" runat="server">
                                    <asp:Button ID="btnSave" runat="server" ToolTip="Send Request" OnClick="btnSave_Click" TabIndex="33"  onclientclick="disableBtn(this.id, 'Loading...')" usesubmitbehavior="False"/>
                                </div>
                                <div class="btn btn-pending1" id="btndelete1" runat="server"  style="display:none">
                                    <asp:Button ID="btndelete" runat="server" ToolTip="Reject" TabIndex="34" OnClick="btndelete_Click" />
                                </div>
                                <div class="btn ico-view" style="display:none">
                                    <asp:Button ID="btnview" runat="server" ToolTip="Export Excel" TabIndex="35" OnClick="btnview_Click1" />

                                </div>
                                <div class="btn ico-cancel" id="btnBack1" runat="server">
                                    <asp:Button ID="btnBack" runat="server" ToolTip="Cancel" TabIndex="36" OnClick="btnBack_Click" />
                                </div>
                            </div>
                        </div>

                         <%-- KYC --%>
                             <div class="FormGroupContent4 hide">
                            <div class="KycCustomerHead">
                                <asp:Label Text="KYC Customer" ID="lbl_KYC" runat="server"></asp:Label>
                            </div>
                        </div>
                          <div class="FormGroupContent4 boxmodal">
                            <div class="BillDrop2">
                                <asp:DropDownList ID="ddlIDProof" runat="server" AppendDataBoundItems="True" TabIndex="2" CssClass="chzn-select form-control"
                                    ToolTip="IDProof" data-placeholder="IDProof" OnSelectedIndexChanged="ddlIDProof_SelectedIndexChanged">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="FileUpload2">
                                <asp:FileUpload ID="fuIDDoc" runat="server" TabIndex="3" Width="100%"></asp:FileUpload>
                            </div>
                                                            
                                 <div class="btn ico-upload" id="Div2" runat="server">
                                    <asp:Button ID="btnkyc" runat="server" ToolTip="KYC Update" OnClick="btnkyc_Click" TabIndex="33" />
                                </div>

                            <div class="BillDrop2" style="display:none;">
                                <asp:DropDownList ID="ddlAddProof" runat="server" AppendDataBoundItems="True" TabIndex="4" CssClass="chzn-select form-control"
                                    ToolTip="AddrProof" data-placeholder="AddrProof" OnSelectedIndexChanged="ddlAddProof_SelectedIndexChanged">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                           
                            <div class="FileUpload2" style="display:none;">
                                <asp:FileUpload ID="fuAddrProof" runat="server" TabIndex="5"></asp:FileUpload>
                            </div>
                            <div class="BillDrop2" style="display:none;">
                                <asp:DropDownList ID="ddlkycproof" runat="server" AppendDataBoundItems="True" TabIndex="4" CssClass="chzn-select form-control"
                                    ToolTip="GST Proof" data-placeholder="GST Proof" OnSelectedIndexChanged="ddlkycproof_SelectedIndexChanged">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="FileUpload4n" style="display:none;">
                                <asp:FileUpload ID="filegstupd" runat="server" TabIndex="5"></asp:FileUpload>
                            </div>
                        
                         
                              <div class="FormGroupContent4">
                            <%--DataKeyNames="districtid,stateid,countryid,portid,locationid,customerid"--%>
                            <asp:GridView ID="GrdProof" runat="server" AutoGenerateColumns="False" Width="99%" CssClass="Grid FixedHeader"  ShowHeaderWhenEmpty="True" 
                                EmptyDataText="No Record Found" OnSelectedIndexChanged="GrdProof_SelectedIndexChanged" OnRowDataBound="GrdProof_RowDataBound"
                                onrowcommand="GrdProof_RowCommand" onrowdeleting="GrdProof_RowDeleting">
                                <Columns>
                                    <asp:BoundField DataField="proof" HeaderText="Proof" />
                                    <asp:BoundField DataField="filename" HeaderText="Filename" />
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                        <asp:ImageButton ID="Img_Delete" runat="server" CommandName="Delete" ImageUrl="~/images/delete.jpg" />
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" HorizontalAlign="right" Width="20px"  />
                                        <ItemStyle Font-Bold="false" Width="20px" HorizontalAlign="Justify"/>                   
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="path" HeaderText="Path" ControlStyle-CssClass="hide">
                                        <HeaderStyle CssClass="hide" />
                                        <ItemStyle CssClass="hide" />
                                    </asp:BoundField>--%>                               
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle CssClass="GrdRow" />
                            </asp:GridView>
                        </div> 

                        </div>

                            <%-- KYC --%>



                        <div class="FormGroupContent4">
                            <asp:ListBox ID="lstlocation" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstlocation_SelectedIndexChanged"></asp:ListBox>
                        </div>
                        <div class="FormGroupContent4">
                            <%--DataKeyNames="districtid,stateid,countryid,portid,locationid,customerid"--%>
                            <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" Width="99%" CssClass="Grid FixedHeader"  ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found" EnableTheming="False" AllowPaging="false" PageSize="3" OnPageIndexChanging="carggrid_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="sno" HeaderText="S.No" />
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
                                    <asp:BoundField DataField="custtype" HeaderText="Customer Type" />
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle CssClass="GrdRow" />
                            </asp:GridView>
                        </div>
                        <div class="FormGroupContent4">

                            <asp:Panel ID="pln_popup" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                <div class="divRoated">
                                    <div class="DivSecPanel">
                                        <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                    </div>

                                    <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">


                                        <asp:GridView ID="Grd_Job" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="false" ShowHeaderWhenEmpty="true"
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
   

                </div>
            </div>


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
         <asp:HiddenField ID="hf_employeeid" runat="server" />
    </div>

</asp:Content>
