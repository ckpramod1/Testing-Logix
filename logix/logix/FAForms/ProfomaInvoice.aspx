<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ProfomaInvoice.aspx.cs" Inherits="logix.FAForm.ProfomaInvoice" %>

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
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>


    <!-- App -->

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




    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <link href="../Styles/ProfomaInvoice.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>


    <script src="../Scripts/ScrollableGridPlugin.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
  

    <script type="text/javascript">
        function pageLoad(sender, args) {
            <%--$(document).ready(function () {

                $("#<%=txtblno.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdnblno.ClientID %>").val(0);
                        $.ajax({
                            url: "../Accounts/ProfomaInvoice.aspx/GetBLno",
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
                               // alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                             //   alertify.alert(response.responseText);
                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txtblno.ClientID %>").val(i.item.label);
                        $("#<%=txtblno.ClientID %>").change();

                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=txtblno.ClientID %>").val(i.item.val);
                        }
                    },
                    focus: function (event, i) {
                        $("#<%=txtblno.ClientID %>").val(i.item.label);

                    },
                 close: function (event, i) {
                        $("#<%=txtblno.ClientID %>").val(i.item.label);

                  },
                  minLength: 1
                   <%--select: function (e, i) {
                       $("#<%=hdnblno.ClientID %>").val(i.item.val);
                      $("#<%=txtblno.ClientID %>").change();
                  },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=hdnblno.ClientID %>").val(i.item.val);
                       }
                   },
                    focus: function (e, i) {
                        $("#<%=hdnblno.ClientID %>").val(i.item.val);
                   },
                   close: function (e, i) {
                       if (i.item) {
                           $("#<%=hdnblno.ClientID %>").val(i.item.val);
                      }
                  },
                    minLength: 1
                });
            });--%>

            $(document).ready(function () {

                $("#<%=txtto.ClientID %>").autocomplete({
                  source: function (request, response) {
                      $("#<%=hdncustid.ClientID %>").val(0);
                        $.ajax({
                            url: "../FAForms/ProfomaInvoice.aspx/GetToCust",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        address: item.split('~')[2],
                                        text: item.split('~')[3]

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

                    select: function (e, i) {
                        if (i.item) {
                            $("#<%=txtto.ClientID %>").val(i.item.label);
                            $("#<%=hdncustid.ClientID %>").val(i.item.val);
                            $("#<%=hdncityid.ClientID %>").val(i.item.text);
                            $("#<%=txtto.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=txtaddress.ClientID %>").val(i.item.address);
                            $("#<%=txtto.ClientID %>").change();
                        }
                    },
           
                    focus: function (e, i) {
                        if (i.item) {
                            $("#<%=txtto.ClientID %>").val(i.item.label);
                            $("#<%=hdncustid.ClientID %>").val(i.item.val);
                            $("#<%=hdncityid.ClientID %>").val(i.item.text);
                            $("#<%=txtto.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=txtaddress.ClientID %>").val(i.item.address);
                        }
                     
                    },
                  close: function (e, i) {
                      var result = $("#<%=txtto.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtto.ClientID %>").val($.trim(result));
                    },
                  minLength: 1
              });
            });


           <%-- $(document).ready(function () {

                $("#<%=txtshipto.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdncustid.ClientID %>").val(0);
                      $.ajax({
                          url: "../Accounts/ProfomaInvoice.aspx/GetToCust",
                          data: "{ 'prefix': '" + request.term + "'}",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          success: function (data) {

                              response($.map(data.d, function (item) {

                                  return {
                                      label: item.split('~')[0],
                                      val: item.split('~')[1],
                                      address: item.split('~')[2],
                                      text: item.split('~')[3]

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

                  select: function (e, i) {
                      if (i.item) {
                          $("#<%=txtshipto.ClientID %>").val(i.item.label);
                        
                            $("#<%=txtshipto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                          
                            $("#<%=txtshipto.ClientID %>").change();
                        }
                    },
           
                    focus: function (e, i) {
                        if (i.item) {
                            $("#<%=txtshipto.ClientID %>").val(i.item.label);
                          
                            $("#<%=txtshipto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            
                        }

                    },
                    close: function (e, i) {
                        var result = $("#<%=txtshipto.ClientID %>").val().toString().split(',')[0];
                      $("#<%=txtshipto.ClientID %>").val($.trim(result));
                  },
                    minLength: 1
                });
            });--%>

            <%-- $(document).ready(function () {
                $("#<%=txtsupplyto.ClientID %>").autocomplete({

                       source: function (request, response) {
                           $("#<%=hid_SupplyTo.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCustomer_List",
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
                        $("#<%=txtsupplyto.ClientID %>").val(i.item.label);
                         $("#<%=txtsupplyto.ClientID %>").change();
                         $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                     },
                    focus: function (event, i) {
                        $("#<%=txtsupplyto.ClientID %>").val(i.item.label);
                        $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txtsupplyto.ClientID %>").val(i.item.label);
                        $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);

                    },
                    close: function (event, i) {
                        $("#<%=txtsupplyto.ClientID %>").val(i.item.label);
                        $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                    });
               });--%>



            $(document).ready(function () {

                $("#<%=txtsupplyto.ClientID %>").autocomplete({
                     source: function (request, response) {
                         $("#<%=hid_SupplyTo.ClientID %>").val(0);
                      $.ajax({
                          url: "../FAForms/ProfomaInvoice.aspx/GetToCust",
                          data: "{ 'prefix': '" + request.term + "'}",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          success: function (data) {

                              response($.map(data.d, function (item) {

                                  return {
                                      label: item.split('~')[0],
                                      val: item.split('~')[1],
                                      address: item.split('~')[2],
                                      text: item.split('~')[3]

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

                  select: function (e, i) {
                      if (i.item) {
                          $("#<%=txtsupplyto.ClientID %>").val(i.item.label);
                            $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                            $("#<%=hid_SupplyToadd.ClientID %>").val(i.item.text);
                            $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=txtsupplytoAddress.ClientID %>").val(i.item.address);
                            $("#<%=txtsupplyto.ClientID %>").change();
                        }
                    },

                    focus: function (e, i) {
                        if (i.item) {
                            $("#<%=txtsupplyto.ClientID %>").val(i.item.label);
                            $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                            $("#<%=hid_SupplyToadd.ClientID %>").val(i.item.text);
                            $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=txtsupplytoAddress.ClientID %>").val(i.item.address);
                        }

                    },
                    close: function (e, i) {
                        var result = $("#<%=txtsupplyto.ClientID %>").val().toString().split(' ,')[0];
                      $("#<%=txtsupplyto.ClientID %>").val($.trim(result));
                  },
                    minLength: 1
                });
             });




            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });



            $(document).ready(function () {
                $("#<%=txtcharge.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdnChargid.ClientID %>").val(0);
                      $.ajax({
                          url: "../FAForms/ProfomaInvoice.aspx/GetCharges",
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
                      $("#<%=txtcharge.ClientID %>").val(i.item.label);
                       $("#<%=txtcharge.ClientID %>").change();
                       $("#<%=hdnChargid.ClientID %>").val(i.item.val);
                   },
                    focus: function (event, i) {
                        $("#<%=txtcharge.ClientID %>").val(i.item.label);
                      $("#<%=hdnChargid.ClientID %>").val(i.item.val);
                  },
                    Change: function (event, i) {
                        $("#<%=txtcharge.ClientID %>").val(i.item.label);
                      $("#<%=hdnChargid.ClientID %>").val(i.item.val);
                  },
                    close: function (event, i) {
                        $("#<%=txtcharge.ClientID %>").val(i.item.label);
                      $("#<%=hdnChargid.ClientID %>").val(i.item.val);
                  },
                    minLength: 1
                });
            });


          $(document).ready(function () {
              $("#<%=txtcurr.ClientID %>").autocomplete({
                   source: function (request, response) {
                       $.ajax({
                           url: "../FAForms/ProfomaInvoice.aspx/GetLikeCurrency",
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
                       $("#<%=txtcurr.ClientID %>").val(i.item.label);
                      $("#<%=txtcurr.ClientID %>").change();
                      $("#<%=hdncurrid.ClientID %>").val(i.item.val);

                  },
                   focus: function (event, i) {
                       $("#<%=txtcurr.ClientID %>").val(i.item.label);
                      $("#<%=hdncurrid.ClientID %>").val(i.item.val);

                  },
                   close: function (event, i) {
                       $("#<%=txtcurr.ClientID %>").val(i.item.label);
                      $("#<%=hdncurrid.ClientID %>").val(i.item.val);

                  },
                   minLength: 1
               });
           });
      }
    </script>


    <script type="text/javascript">


        function getConfirmationValue() {
            var sector = document.getElementById('<%=txtcharge.ClientID %>').value;

            if (sector == "") {
                alertify.alert("Charge Name can't be Empty...");
                return false;
            }
            else {
                if (confirm('Are you sure you want to delete the details?')) {
                    $('#<%=hfWasConfirmed.ClientID%>').val('true')
                }
                else {
                    $('#<%=hfWasConfirmed.ClientID%>').val('false')
                }
            }
            return true;
        }

    </script>

      <style type="text/css">


          /*.ChargeInput {
    width: 35.6% !important;
    float: left;
    margin: 0px 0.5% 0px 0px;
}


          .STGSTInput {
    width: 18%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}*/

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

        #logix_CPH_pnlConfirm {
            top:340px!important;
        }

        .popupconfirmnew
        {
            display:block;
            position: fixed;
    z-index: 100001;
    left: 390.5px;
        }
        .Pnl {
            height:15%!important;
            border:1px solid #b1b1b1!important;
        }
        .TotalInputosdn {
    float: right;
    margin: 0;
    width: 10%;
}


.TblGrid{ width:100%; font-size:12px;  border:1px solid #b1b1b1; border-collapse:collapse;}
.TblGrid th{background-color:#dfdfdf; border-bottom:1px solid #b1b1b1; border-right:1px solid #b1b1b1; text-align:center; font-family:"Segoe UI"; color:#242c28; font-size:12px; padding:3px 2px 3px 2px;}
.TblGrid td{border-bottom:1px solid #b1b1b1; border-right:1px solid #b1b1b1; text-align:left; font-family:"Segoe UI"; color:#242c28; font-size:12px; padding:0px 2px 0px 2px;}
.TblGrid tr.Bgcolor{ background-color:#fff8dc;}
.CreditDays {
    float: left;
    margin: 0 0 0 0;
    width: 15.5%;
}

.BLLeft {
    float: left;
    margin: 0 0 0 0;
    width: 100%;
}
          .MBLchk input {
              float:left; margin:0px 0.5% 0px 0px;
          }
          .MBLchk label {display:inline-block; float:left; width:60px!important;
          }

          .ChkTillDate span, label {width:45px!important;
          }

          /*.BLNo2 {
    float: left;
    margin: 0 0.5% 0 0;
    width: 43.5%;
}*/
          .VendorRef {
    width: 11.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
           .BLNo2 {
    float: left;
    margin: 0 0.5% 0 0;
    width: 49.5%;
}

        .BillType {
    width: 9%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .VendorRefN {
    width: 40.5%;
    float: left;
    margin: 0px;
}
.div_Grid {
    width: 100%;
    float: left;
    margin-left: 0%;
    margin-bottom: 1%;
    height: 172px;
    border: 1px solid gray;
}

    .VendorRef1 {
            width: 11.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .CreditDays {
            width: 16.5%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

                  /*.VendorRef1 {
    width: 8.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
   
          .CreditDays {
    width: 10.5%;
    float: left;
    margin: 0px 0% 0px 0px;
}*/

.row {
    clear: both;
    width: 100%;
    height: 580px!important;
    overflow-x: hidden;
    overflow-y: auto;
}


.DateCal1 {
    width: 6.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}


.PreparedTxt {
            width:7%;
            float:left;margin:0px 0.5% 0px 0px;
            font-size:13px;
            font-family:sans-serif;
            font-weight:bold;
            color:#4e4e4c;


        }
        .PrepareValue {
            width:12%;
            float:left;
            margin:0px 0.5% 0px 0px;
            font-size:13px;
            font-family:sans-serif;

        }
            .PrepareValue span {
                font-family:sans-serif;
            }
        .ApprovedByTxt {
            width:7%;
            float:left;
            margin:0px 0.5% 0px 0px;
            font-size:13px;
             font-family:sans-serif;
             font-weight:bold;
             color:#4e4e4c;
        }
        .ApprovedValue {
            width:15%;
            float:left;
            margin:0px 0px 0px 0px;
            font-size:13px;
             font-family:sans-serif;
        }
            .ApprovedValue span {
                font-size:13px;
                font-family:sans-serif;
            }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

     <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
             
             
              <li><a href="#" title="">Vouchers</a> </li>
              <li class="current"><a href="#" title="" id="headerlabel" runat="server">Proforma Invoice</a> </li>
             <li><asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
            </ul>
      </div>
          <!-- /Breadcrumbs line -->
    <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server" id="div_iframe">
   
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i><asp:Label ID="lbl_Header" runat="server" Text=""></asp:Label></h4>
                </div>
            <div class="widget-content" >
                <div class="FormGroupContent4">
                     <div class="FormGroupContent4">
                        <div class="REFInputpro"><asp:TextBox ID="txtref" ToolTip="Ref Number" placeholder="Ref #" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtref_TextChanged" onkeypress="return isNumberKey(event,'Ref #');"></asp:TextBox></div>
                        <div class="RefCal"> <asp:TextBox ID="txtvouyear" runat="server" ToolTip="Year" placeholder="Year" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
                           <!--<div class="Datelabel1"> <asp:Label ID="Label4" runat="server" Text="Date" CssClass="LabelValue"></asp:Label></div>-->
                            <div class="DateCal1"><asp:TextBox ID="dtdate" ToolTip="Date" placeholder="Date" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox><ajaxtoolkit:CalendarExtender Format="MM/dd/yyyy" ID="CalendarExtender2" TargetControlID="dtdate" runat="server" /></div>
                             </div>
                    <div class="BLLeft">
                       
                         <div class="FormGroupContent4">
                             <div class="BLNo2"><asp:TextBox ID="txtblno" runat="server" ToolTip="Bill of Lading Number" placeholder="BL #" CssClass="form-control" AutoPostBack="True" TabIndex="1"></asp:TextBox></div>
                             <div class="MBLchk" style="display:none;"> <asp:CheckBox ID="chkmbl" runat="server" Text="MB/L" AutoPostBack="true" Width="100%" OnCheckedChanged="chkmbl_CheckedChanged" TabIndex="2" /></div>
                             <div class="BillType"><asp:DropDownList ID="cmbbill" ToolTip="Bill Type" runat="server" AutoPostBack="True" CssClass="chzn-select" Width="100%" data-placeholder="Bill Type" TabIndex="3" OnSelectedIndexChanged="cmbbill_SelectedIndexChanged"></asp:DropDownList></div>
                              <div class="VendorRefN" id="txtcredit" runat="server"><asp:TextBox ID="txtcreditapp1" runat="server" Cssclass="form-control" AutoPostBack="True" placeholder="CreditApproval #" TabIndex="4" ToolTip="CreditApproval #"></asp:TextBox></div> 
                             <div class="VendorRef" id="txtVendorRef" runat="server"><asp:TextBox ID="txtVendorRefno" runat="server" ToolTip="Vendor Ref Number" placeholder="Vendor Ref #" CssClass="form-control" TabIndex="5"  AutoPostBack="True"></asp:TextBox></div>
                              <div class="VendorRef1" id="txtVendorRefnodate1" runat="server"><asp:TextBox ID="txtVendorRefnodate" runat="server" ToolTip="Vendor Ref Date" placeholder="Vendor Ref Date" CssClass="form-control" TabIndex="6"  AutoPostBack="True"></asp:TextBox>
                                 <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txtVendorRefnodate" TodaysDateFormat="dd/MM/yyyy">
                                  </ajaxtoolkit:CalendarExtender>
                             </div>
                            <div class="CreditDays" id="txtCreditDays1" runat="server"> <asp:TextBox ID="txtCreditDays" runat="server" CssClass="form-control" ToolTip="CreditDays" placeholder="CreditDays" AutoPostBack="True"  TabIndex="6" onkeypress="return isNumberKey(event,'Credit Days');"></asp:TextBox></div>
                             </div>
                          <div class="FormGroupContent4">
                             <div class="JobDetailsInput"> <asp:TextBox ID="txtto" runat="server" ToolTip="Bill From" placeholder="Bill From" CssClass="form-control" AutoPostBack="True" TabIndex="7" OnTextChanged="txtto_TextChanged"></asp:TextBox>
                                 </div>
                               <div class="DesiInput"><asp:TextBox ID="txtsupplyto" runat="server" ToolTip="Supply From" placeholder="Supply From" CssClass="form-control" AutoPostBack="True" TabIndex="8" OnTextChanged="txtsupplyto_TextChanged" ></asp:TextBox>
                                   </div>
                              </div>
                        <div class="FormGroupContent4">
                             <div class="JobDetailsInput"><asp:TextBox ID="txtaddress" Style="resize: none;" Rows="2" runat="server" ToolTip="Address" placeholder="Address" CssClass="form-control" AutoPostBack="True" TextMode="MultiLine"></asp:TextBox>
                                 </div>
                             <div class="DesiInput"><asp:TextBox ID="txtsupplytoAddress" Style="resize: none;" Rows="2" runat="server" ToolTip="Address" placeholder="Address" CssClass="form-control" AutoPostBack="True" TextMode="MultiLine"></asp:TextBox>
                                 </div>
                              </div>
                        <div class="FormGroupContent4" style="display:none;">
                            <div class="JobDetailsInput"> <asp:TextBox ID="txtvessel" runat="server" ToolTip="Job Details" placeholder="Job Details" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox></div>
                            <div class="DesiInput"><asp:TextBox ID="txtdes" runat="server" ToolTip="Destination" placeholder="Destination" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox></div>
                              </div>
                          <div class="FormGroupContent4" style="display:none;">
                            <div class="JobDetailsInput"> <asp:TextBox ID="txtshipper" runat="server" ToolTip="Shipper" placeholder="Shipper" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox></div>
                            <div class="DesiInput"><asp:TextBox ID="txtagent" runat="server" ToolTip="Agent" placeholder="Agent" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox></div>
                              </div>
                          <div class="FormGroupContent4" style="display:none;">
                            <div class="JobDetailsInput"><asp:TextBox ID="txtconsignee" runat="server" ToolTip="Consignee" placeholder="Consignee" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox></div>
                            <div class="DesiInput"> <asp:TextBox ID="txtmlo" runat="server" ToolTip="Main-Line Operator" placeholder="MLO" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox></div>
                              </div>
                          <div class="FormGroupContent4" style="display:none;">
                            <div class="JobDetailsInput"> <asp:TextBox ID="txtnotify" ToolTip="Notify Party" placeholder="Notify Party" runat="server" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox></div>
                            <div class="DesiInput"><asp:TextBox ID="txtcnf" runat="server" ToolTip="CNF" placeholder="CNF" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox></div>
                              </div>
                          <div class="FormGroupContent4">
                               <asp:TextBox ID="txtremarks" runat="server" Style="resize: none;" Rows="2" ToolTip="Remarks" placeholder="Remarks" CssClass="form-control" AutoPostBack="True" TabIndex="9" TextMode="MultiLine" Width="100%" onKeyUp="CheckTextLength(this,150)"></asp:TextBox>
                              </div>

                    </div>
                    <div class="BLRight">
                        
                    
                         <div class="FormGroupContent" style="display:none;">
                              <asp:Panel ID="pnlContlist" runat="server" CssClass="lst_cont" ScrollBars="Auto">
                    <asp:ListBox ID="lstcon" runat="server" Width="100%" Height="100%"></asp:ListBox>
                </asp:Panel>
                             </div>
                         <div class="FormGroupContent" style="display:none;">
                               <asp:Panel ID="pnlVolList" runat="server" CssClass="lst_vol" ScrollBars="Auto">
                    <asp:ListBox ID="lstvol" runat="server" Width="100%" Height="100%"></asp:ListBox>
                </asp:Panel>
                             </div>
                    </div>
                    <div class="bordertopNew"></div>
                    <div class="FormGroupContent">
                         
                        <div class="right_btn">
                            <div class="btn ico-save" id="btn_save1" runat="server"> <asp:Button ID="btnsave" runat="server" ToolTip="Save" TabIndex="10"  OnClick="btnsave_Click" /></div>
                            <div class="btn ico-view"><asp:Button ID="btnview" runat="server" ToolTip="View"  Enabled="false" TabIndex="18" OnClick="btnview_Click" /></div>
                            <div class="btn ico-delete"> <asp:Button ID="btndelete" runat="server" Visible="true" TabIndex="19" ToolTip="Delete" OnClick="btndelete_Click" /></div>
                            <div class="btn ico-cancel" id="btn_cancel1" runat="server"><asp:Button ID="btncancel" runat="server" ToolTip="Cancel"  OnClick="btncancel_Click" TabIndex="20" /></div>
                        </div>

                    </div>
                                        <div class="bordertopNew"></div>
                                        <div class="FormGroupContent4">
                                            <div class="ChargeInput"> <asp:TextBox ID="txtcharge" runat="server" ToolTip="Charge Description" placeholder="Charge Description" CssClass="form-control" AutoPostBack="True" TabIndex="11" OnTextChanged="txtcharge_TextChanged"></asp:TextBox></div>
                                           <%--  <div class="STGSTInput"><asp:TextBox ID="txt_stgst" runat="server" ToolTip="ST/GST" placeholder="ST/GST" CssClass="form-control" AutoPostBack="True" TabIndex="11" ></asp:TextBox></div>--%>
                                             <div class="CurrInput"><asp:TextBox ID="txtcurr" runat="server" ToolTip="Curr" placeholder="Curr" CssClass="form-control" AutoPostBack="True" TabIndex="12" OnTextChanged="txtcurr_TextChanged"></asp:TextBox></div>
                                            <div class="RateInput"> <asp:TextBox ID="txtrate" runat="server" ToolTip="Rate" placeholder="Rate" CssClass="form-control" AutoPostBack="True" TabIndex="13" OnTextChanged="txtrate_TextChanged"></asp:TextBox></div>
                                            <div class="EXRate"><asp:TextBox ID="txtex" runat="server" ToolTip="Ex Rate" placeholder="Ex Rate"  CssClass="form-control" AutoPostBack="True" TabIndex="14" OnTextChanged="txtex_TextChanged"></asp:TextBox></div>
                                            <div class="BLDropN2"> <asp:DropDownList ID="cmbbase" runat="server" ToolTip="Select Base" placeholder="Base / Units" AutoPostBack="True" TabIndex="15" data-placeholder="Base / Units" CssClass="chzn-select" OnSelectedIndexChanged="cmbbase_SelectedIndexChanged"></asp:DropDownList></div>
                                            <div class="AmoutnInputN2"> <asp:TextBox ID="txtamount" runat="server" ToolTip="Amount" placeholder="Amount" CssClass="form-control" AutoPostBack="True" TabIndex="16" ReadOnly="true"></asp:TextBox></div>
                                            <div class="btn ico-add" id="btn_add1" runat="server"><asp:Button ID="btnadd" runat="server" ToolTip="Add" TabIndex="17" OnClick="btnadd_Click" /></div>
                                            </div>
                    <div class="FormGroupContent4">
                        <asp:Panel ID="pnlCharge" runat="server" CssClass=" panel_10" ScrollBars="Auto">
            <asp:GridView ID="grd" TabIndex="13" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False" PageSize="3" Width="100%" ForeColor="Black" OnPageIndexChanging="grd_PageIndexChanged" AllowPaging="false" CssClass="Grid FixedHeader"  OnRowDataBound="grd_RowDataBound" OnSelectedIndexChanged="grd_SelectedIndexChanged">
                <Columns>

                    <asp:BoundField DataField="CHARge" HeaderText="Charges">   
                        <HeaderStyle Width="400" />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="curr" HeaderText="Curr">
                        <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="130" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                        <HeaderStyle HorizontalAlign="Center" Width="130" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="exrate" HeaderText="Exrate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                        <HeaderStyle HorizontalAlign="Center" Width="130" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="bASe" HeaderText="Base / Units">
                        <HeaderStyle HorizontalAlign="Center" Width="130" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:BoundField DataField="withoutgstAmt" HeaderText="Amount" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                        <HeaderStyle HorizontalAlign="Center" Width="130" CssClass="TxtAlign1" />
                        <ItemStyle HorizontalAlign="Left" CssClass="TxtAlign1" />
                    </asp:BoundField>
                     <asp:BoundField DataField="stgst" HeaderText="GST" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                        <HeaderStyle HorizontalAlign="Center" Width="130" CssClass="TxtAlign1" />
                        <ItemStyle HorizontalAlign="Left" CssClass="TxtAlign1" />
                    </asp:BoundField>
                    <asp:BoundField DataField="amount" HeaderText="Total Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                        <HeaderStyle HorizontalAlign="Center" Width="130" />
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundField>


                     <%--<asp:TemplateField HeaderText="Delete">
            <ItemTemplate>
            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" CommandName="Delete"  Visible="false"  ImageUrl="~/images/delete.jpg" Width="15px" Height="15px" OnClick="ImageButton2_Click"/>
            </ItemTemplate> <ItemStyle Width="40px" HorizontalAlign="Center" /></asp:TemplateField>--%>


                    <asp:BoundField DataField="chargeid" HeaderText="chargeid">
                        <HeaderStyle CssClass="hide" />
                        <ItemStyle CssClass="hide" />
                    </asp:BoundField>

                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <RowStyle Font-Italic="False" />
            </asp:GridView>
            <div class="div_Break"></div>
        </asp:Panel>
                        </div>

                     <div class="FormGroupContent">
                          <%--<div class="Amouttotal">--%>

                           <div id="lbl_txt" runat="server" visible="false"> 
                        <div class="PreparedTxt">Prepared By:</div>
                        <div class="PrepareValue"><asp:Label ID="lbl_prepare" runat="server" Text="Prepare Value"></asp:Label></div>
                        <div class="ApprovedByTxt" >Approved By:</div>
                        <div class="ApprovedValue" runat="server" visible="false" id="lbl_appr"> <asp:Label ID="lbl_Approve" runat="server" Text="Approved Value"></asp:Label></div>
                        </div>

                              <div class="TotalInputosdn MB10">
                          <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" ToolTip="Total" placeholder="Total" ReadOnly="true"></asp:TextBox>
                              </div>
                         </div>

                    <%--<div class="FormGroupContent">
                       

                    </div>--%>



                    </div>
                </div>
         </div>
            </div>
        </div>


     <asp:Panel runat="Server" ID="pnlConfirm" CssClass="Pnl" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Do You Want Add One more Invoice </b></div>
        <br />
        <div class="div_confirm">

            <asp:Button ID="btnok" runat="server" Text="Yes" CssClass="Button" OnClick="btnok_Click" />
            <asp:Button ID="btnno" runat="server" Text="No" CssClass="Button" OnClick="btnno_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>

 <div class="div_Break"></div>
    <div class="div_Break"></div>
    <ajaxtoolkit:ModalPopupExtender ID="popupconfirmnew" runat="server" PopupControlID="pnlConfirm" TargetControlID="lbl">
    </ajaxtoolkit:ModalPopupExtender>
    <asp:Label ID="lbl" runat="server" Text="Label" Style="display: none;"></asp:Label>

    <div class="div_Break"></div>


    
    <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Do You Want GST For This Charge? </b></div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btn_yes" runat="server" Text="Yes" CssClass="Button" OnClick="btn_yes_Click" />
            <asp:Button ID="btn_no" runat="server" Text="No" CssClass="Button" OnClick="btn_no_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>
    <div class="div_Break"></div>
    <div class="div_Break"></div>
    <ajaxtoolkit:ModalPopupExtender ID="PopUpService" runat="server" PopupControlID="Panel_Service" TargetControlID="Label1">
    </ajaxtoolkit:ModalPopupExtender>
    <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>

   <%--Hidden Fields--%>
    <asp:HiddenField ID="txtjobno" runat="server" />
    <asp:HiddenField ID="hdnblno" runat="server" />
    <asp:HiddenField ID="hdncustid" runat="server" />
    <asp:HiddenField ID="hdncityid" runat="server" />
    <asp:HiddenField ID="hdnChargid" runat="server" />
    <asp:HiddenField ID="hdncurrid" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnfatransfer" runat="server" />
    <asp:HiddenField ID="hfWasConfirmed" runat="server" />
    <asp:HiddenField ID="hid_cmbase" runat="server" />

    <asp:HiddenField ID="hf_custid" runat="server" />
    <asp:HiddenField ID="hf_strtype" runat="server" />  
    <asp:HiddenField ID="cstid" runat="server" />
     <asp:HiddenField ID="hd_exrate" runat="server" />
<asp:HiddenField ID="hid_gstdate" runat="server" />

    <asp:HiddenField ID="hid_getdate" runat="server" />
    
    <asp:HiddenField ID="hid_SupplyTo" runat="server" />
      <asp:HiddenField ID="hid_SupplyToadd" runat="server" />
     <asp:HiddenField ID="hid_SupplyTonew" runat="server" />

    <asp:HiddenField ID="hid_cosigneeid" runat="server" />

        <asp:HiddenField ID="hid_mloid" runat="server" />
    
</asp:Content>
