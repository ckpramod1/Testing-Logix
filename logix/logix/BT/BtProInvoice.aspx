<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="BtProInvoice.aspx.cs" Inherits="logix.BT.BtProInvoice" %>

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
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css" />
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

  
    <!-- App -->


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









    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>    
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>


    <script src="../Scripts/ScrollableGridPlugin.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
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
        .Pnl1 {
    background-color: #fff;
    border: 1px solid #b1b1b1;
    padding: 10px;
    text-align: center;
}
        
        .ToInputN11 {
  width: 50.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

    .ToInputN11new {
  width: 49%;
    float: left;
    margin: 0px 0% 0px 0px;
}

.Pnl {
    border-color: #5D7B9D;
    border-style: solid;
    border-width: 1px;
    padding: 10px;
    background-color: #fff;
}

.div_confirm {
    text-align: center;
}
        #logix_CPH_Panel1 {
            top:240px!important;
        }

        .TotalRight {width:10%; float:right; margin:0px;
        }

            .TotalRight input {text-align:right;
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

               logix_CPH_PanelLog
             {
                 top:155px!important;
             }
    </style>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {

                $("#<%=txttruck.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdnblno.ClientID %>").val(0);
                        $.ajax({
                            url: "../BT/BtProInvoice.aspx/Gettruck",
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
                        $("#<%=txttruck.ClientID %>").val(i.item.label);
                        $("#<%=txttruck.ClientID %>").change();

                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=txttruck.ClientID %>").val(i.item.val);
                        }
                    },
                    focus: function (event, i) {
                        $("#<%=txttruck.ClientID %>").val(i.item.label);
                    },
                    close: function (event, i) {
                        $("#<%=txttruck.ClientID %>").val(i.item.label);
                    },
                    minLength: 1
                });
            });

                $(document).ready(function () {

                    $("#<%=txtto.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdncustid.ClientID %>").val(0);
                      $.ajax({
                          url: "../BT/BtProInvoice.aspx/GetToCust",
                          data: "{ 'prefix': '" + request.term + "'}",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          success: function (data) {

                              response($.map(data.d, function (item) {

                                  return {
                                      label: item.split('~')[0],
                                      val: item.split('~')[1],
                                      city: item.split('~')[2],
                                      text: item.split('~')[3]
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
                      $("#<%=hdncustid.ClientID %>").val(i.item.val);
                        $("#<%=hdncityid.ClientID %>").val(i.item.city);
                        $("#<%=txtto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtto.ClientID %>").change();
                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=hdncustid.ClientID %>").val(i.item.val);
                          $("#<%=hdncityid.ClientID %>").val(i.item.city);
                          $("#<%=txtto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                      }
                  },
                    focus: function (e, i) {
                        $("#<%=hdncustid.ClientID %>").val(i.item.val);
                      $("#<%=hdncityid.ClientID %>").val(i.item.city);
                      $("#<%=txtto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                  },
                    close: function (e, i) {
                        var result = $("#<%=txtto.ClientID %>").val().toString().split(',')[0];
                      $("#<%=txtto.ClientID %>").val($.trim(result));
                  },
                    minLength: 1
                });
                });


            $(document).ready(function () {

                $("#<%=txtsupplyto.ClientID %>").autocomplete({
                      source: function (request, response) {
                          $("#<%=hid_SupplyTo.ClientID %>").val(0);
                        $.ajax({
                            url: "../BT/BtProInvoice.aspx/GetToCust",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        city: item.split('~')[2],
                                        text: item.split('~')[3]
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
                        $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                      $("#<%=hid_SupplyTocity.ClientID %>").val(i.item.city);
                      $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                      $("#<%=txtsupplyto.ClientID %>").change();
                  },
                        change: function (e, i) {
                            if (i.item) {
                                $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                            $("#<%=hid_SupplyTocity.ClientID %>").val(i.item.city);
                            $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        }
                    },
                        focus: function (e, i) {
                            $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                        $("#<%=hid_SupplyTocity.ClientID %>").val(i.item.city);
                        $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                    },
                        close: function (e, i) {
                            var result = $("#<%=txtsupplyto.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtsupplyto.ClientID %>").val($.trim(result));
                    },
                        minLength: 1
                    });
              })


          $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });


          $(document).ready(function () {
              $("#<%=txtcharge.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdnChargid.ClientID %>").val(0);
                        $.ajax({
                            url: "../BT/BtProInvoice.aspx/GetCharges",
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
                          url: "../BT/BtProInvoice.aspx/GetLikeCurrency",
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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


        <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home" ></i><a href="#"></a>Home </li>
              <li><a href="#" title="" >Bonded Trucking</a> </li>
            <li><a href="#"></a>Accounts </li>
              <li class="current"><a href="#" title="" id="header" runat="server">Profoma Invoice</a> </li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                 <div style="float: left; margin: 0px 0.5% 0px 0px;"> <h4><i class="icon-umbrella"></i><asp:Label ID="lbl_Header" runat="server" Text=""></asp:Label></h4></div>

         <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
          <div class="widget-content">
             <div class="FormGroupContent4">
                 <div class="ShipBill1"><asp:TextBox ID="txttruck" runat="server" ToolTip="Ship. Bill #" placeholder="Ship. Bill #" CssClass="form-control" AutoPostBack="True" OnTextChanged="txttruck_TextChanged"></asp:TextBox></div>
                 <div class="JobNo6"><asp:TextBox ID="txtblno" ReadOnly="true" runat="server" ToolTip="Job #" placeholder="Job #" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
                 <div class="CashDrop"> <asp:DropDownList ID="cmbbill" ToolTip="Bill Type" runat="server" AutoPostBack="True" CssClass="chzn-select" Width="100%" data-placeholder="Bill Type" OnSelectedIndexChanged="cmbbill_SelectedIndexChanged"></asp:DropDownList></div>
                 <div class="RefNo6"><asp:TextBox ID="txtinv" ToolTip="Ref Number" placeholder="Ref #" runat="server" CssClass="form-control" AutoPostBack="True" onkeypress="return isNumberKey(event,'Ref #');" OnTextChanged="txtinv_TextChanged"></asp:TextBox> </div>
                <div class="DateCalNo1"><asp:TextBox ID="txtdate" ToolTip="Date" Enabled="false" placeholder="Date" runat="server" CssClass="form-control"></asp:TextBox><ajaxtoolkit:CalendarExtender Format="MM/dd/yyyy" ID="CalendarExtender2" TargetControlID="txtdate" runat="server" /></div>
                  <div class="Refyear"><asp:TextBox ID="txtvouyear" runat="server" ToolTip="Year" placeholder="Year" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
                 </div>
                <div class="FormGroupContent4">
                    <div class="ToInputN11"><asp:TextBox ID="txtto" runat="server" ToolTip="To" placeholder="To" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtto_TextChanged" ></asp:TextBox></div>
                   <div class="ToInputN11new"><asp:TextBox ID="txtsupplyto" runat="server" ToolTip="SupplyTo" placeholder="SupplyTo" CssClass="form-control"  AutoPostBack="true" TabIndex="8" OnTextChanged="txtsupplyto_TextChanged" ></asp:TextBox></div>
                     <div class="DateLbl" style="display:none"> <asp:Label ID="Label4" runat="server" Text="Date"></asp:Label></div>
                    
                    </div>
               <div class="FormGroupContent4">
                   <div class="FromPort"><asp:TextBox ID="txtfromport" runat="server" ToolTip="From Port" placeholder="From Port" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox></div>
                   <div class="ToPort1"><asp:TextBox ID="txttoport" runat="server" ToolTip="To Port" placeholder="To Port" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox></div>
                   <div class="CreditApproval"><asp:TextBox ID="txtcreditapp" runat="server" ToolTip="Credit Approval Number" placeholder="Credit Approval #" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
                   </div>
                   <div class="ETDLeft">
                      <div class="FormGroupContent4">
                       <div class="ETDInput5"> <asp:TextBox ID="txtetd" runat="server" ToolTip="ETD" placeholder="ETD" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox></div>
                       <div class="ETAInput5"><asp:TextBox ID="txteta" runat="server" ToolTip="ETA" placeholder="ETA" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox></div>
                         </div>
                        <div class="FormGroupContent4">
                            <asp:TextBox ID="txtremarks" runat="server" Style="resize: none;" Rows="2" ToolTip="Remarks" placeholder="Remarks" CssClass="form-control" AutoPostBack="True" TextMode="MultiLine" Width="100%" onKeyUp="CheckTextLength(this,50)"></asp:TextBox>
                            </div>
                   </div>
                   <div class="ETDRight">
                        <asp:Panel ID="pnlContlist" runat="server" ScrollBars="Auto">
                    <asp:ListBox ID="lstcon" runat="server" Width="100%" Height="100%"></asp:ListBox>
                </asp:Panel> 
                         <div class="FormGroupContent4">
                         <div class="VendorRefNo"><asp:TextBox ID="txtVendorref" runat="server" CssClass="form-control"  ToolTip="Vendor Ref Number" placeholder="Vendor Ref #" AutoPostBack="True" onkeypress="return isNumberKey(event,'Credit Days');" Visible="false"></asp:TextBox></div>
                             </div>
                   </div>
                
               <div class="FormGroupContent4">
                 
                   <div class="right_btn MT0 MB05">
                       
                       <div class="btn ico-save" id="btn_save1" runat="server"> <asp:Button ID="btnsave" runat="server" ToolTip="Save/Update" OnClick="btnsave_Click" /></div>
                       <div class="btn ico-view"> <asp:Button ID="btnview" runat="server" ToolTip="View"  Enabled="false" OnClick="btnview_Click" /></div>
                       <div class="btn ico-delete"> <asp:Button ID="btndelete" runat="server" ToolTip="Delete" OnClick="btndelete_Click" /> </div>
                       <div class="btn ico-back" id="btn_back1" runat="server"><asp:Button ID="btncancel" runat="server" ToolTip="Cancel"  OnClick="btncancel_Click" /></div>
                   </div>

                   </div>
              <div class="bordertopNew"></div>
                <div class="FormGroupContent4">
                    <div class="ChargeInput2"><asp:TextBox ID="txtcharge" runat="server" ToolTip="Charge Description" placeholder="Charge Description" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtcharge_TextChanged"></asp:TextBox></div>
                    <div class="Curr2"><asp:TextBox ID="txtcurr" runat="server" ToolTip="Curr" placeholder="Curr" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtcurr_TextChanged"></asp:TextBox></div>
                    <div class="Rate4"><asp:TextBox ID="txtrate" runat="server" ToolTip="Rate" placeholder="Rate" CssClass="form-control" AutoPostBack="True" onkeypress="return isNumberKey(event,'Rate');" OnTextChanged="txtrate_TextChanged"></asp:TextBox></div>
                    <div class="EXRate3"><asp:TextBox ID="txtex" runat="server" ToolTip="Ex Rate" placeholder="Ex Rate" CssClass="form-control" AutoPostBack="True" onkeypress="return isNumberKey(event,'Ex Rate');"></asp:TextBox></div>
                    <div class="CBM2"><asp:DropDownList ID="cmbbase" runat="server" ToolTip="Base/Unit" AutoPostBack="True" data-placeholder="Base / Unit" CssClass="chzn-select" OnSelectedIndexChanged="cmbbase_SelectedIndexChanged">
                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                        </asp:DropDownList></div>
                    <div class="Amount8"><asp:TextBox ID="txtamount" runat="server" ToolTip="Amount" placeholder="Amount" CssClass="form-control" style="text-align:right;" AutoPostBack="True" ReadOnly="true"></asp:TextBox></div>
                    <div class="btn ico-add" id="btn_add1" runat="server"> <asp:Button ID="btnadd" runat="server" ToolTip="Add" OnClick="btnadd_Click" /></div>

                    </div>
              <div class="FormGroupContent4">
                  <asp:Panel ID="pnlCharge" runat="server" CssClass="div_Grid" ScrollBars="Auto">
            <asp:GridView ID="grd" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False" PageSize="3" Width="100%" ForeColor="Black" 
                OnPageIndexChanging="grd_PageIndexChanged" AllowPaging="false" CssClass="Grid FixedHeader"  OnRowDataBound="grd_RowDataBound" 
                OnSelectedIndexChanged="grd_SelectedIndexChanged" ShowHeader="true" >
                <Columns>

                    <asp:BoundField DataField="CHARge" HeaderText="Charges">                                                
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="curr" HeaderText="Curr">
                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:F2}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="exrate" HeaderText="Exrate" DataFormatString="{0:F2}" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="bASe" HeaderText="Base">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:BoundField DataField="withoutgstAmt" HeaderText="Amount" DataFormatString="{0:F2}">
                        <HeaderStyle HorizontalAlign="Center" Width="130" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:BoundField DataField="stgst" HeaderText="GST" DataFormatString="{0:F2}">
                        <HeaderStyle HorizontalAlign="Center" Width="130" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="amount" HeaderText="Total Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                        <HeaderStyle HorizontalAlign="Center" Width="130" />
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundField>
                  <%--  <asp:BoundField DataField="amount" HeaderText="Amount" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>--%>


                    <%-- <asp:TemplateField HeaderText="Delete">
            <ItemTemplate>
            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" CommandName="Delete"  Visible="false"  ImageUrl="~/images/delete.jpg" Width="15px" Height="15px" OnClick="ImageButton2_Click"/>
            </ItemTemplate> <ItemStyle Width="40px" HorizontalAlign="Center" /></asp:TemplateField>--%>


                    <%--<asp:BoundField DataField="chargeid" HeaderText="chargeid">
                        <HeaderStyle CssClass="hide" />
                        <ItemStyle CssClass="hide" />
                    </asp:BoundField>--%>

                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <RowStyle Font-Italic="False" />
            </asp:GridView>
            <div class="div_Break"></div>
        </asp:Panel>
                  <div class="TotalRight">
                  <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" ToolTip="Total" placeholder="Total" AutoPostBack="True"></asp:TextBox>
                      </div>
              </div>
                <div class="FormGroupContent4">
                    
    <asp:Panel runat="Server" ID="pnlConfirm" CssClass="Pnl" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Do You Want Add One more Payment Advise </b></div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btnok" runat="server" Text="Yes" CssClass="Button" OnClick="btnok_Click" />
            <asp:Button ID="btncncl" runat="server" Text="No" CssClass="Button" OnClick="btncncl_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>
   
    <div class="div_Break"></div>
    <ajaxtoolkit:ModalPopupExtender ID="popupconfirm" runat="server" BackgroundCssClass=""
        CancelControlID="btncncl" PopupControlID="pnlConfirm" TargetControlID="lbl">
    </ajaxtoolkit:ModalPopupExtender>
    <asp:Label ID="lbl" runat="server" Text="Label" Style="display: none;"></asp:Label>

    <div class="div_Break"></div>


    <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Do You Want Service Tax Applicable For This Charge </b></div>
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
    <ajaxtoolkit:ModalPopupExtender ID="PopUpService" runat="server" BackgroundCssClass=""
        PopupControlID="Panel_Service" TargetControlID="Label1">
    </ajaxtoolkit:ModalPopupExtender>
    <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>

    <div class="div_Break"></div>

    <asp:Panel runat="Server" ID="Panel1" CssClass="Pnl1" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Do you want to Delete ?</b></div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btn_yes_1" runat="server" Text="Yes" CssClass="Button" OnClick="btn_yes_1_Click" />
            <asp:Button ID="btn_no_1" runat="server" Text="No" CssClass="Button" OnClick="btn_no_1_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>
    <div class="div_Break"></div>
    <div class="div_Break"></div>
    <ajaxtoolkit:ModalPopupExtender ID="Popupdelete" runat="server" BackgroundCssClass=""
        PopupControlID="Panel1" TargetControlID="Label2">
    </ajaxtoolkit:ModalPopupExtender>
    <asp:Label ID="Label2" runat="server" Text="Label" Style="display: none;"></asp:Label>
                    </div>
              </div>

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

        
      <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="Image1" BehaviorID="Test1">
    </ajaxtoolkit:ModalPopupExtender>
     <asp:HiddenField ID="txtjobno" runat="server" />
    <asp:HiddenField ID="hdnblno" runat="server" />
    <asp:HiddenField ID="hdncustid" runat="server" />
    <asp:HiddenField ID="hdncityid" runat="server" />
    <asp:HiddenField ID="hdnChargid" runat="server" />
    <asp:HiddenField ID="hdncurrid" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnfatransfer" runat="server" />
    <asp:HiddenField ID="hfWasConfirmed" runat="server" />
    <asp:HiddenField ID="hid_Exrate" runat="server" />
    <asp:HiddenField ID="hf_custid" runat="server" />
    <asp:HiddenField ID="hf_strtype" runat="server" />
    <asp:HiddenField ID="cstid" runat="server" />
    <asp:HiddenField ID="hid_oldbase" runat="server" />   
   <%-- GST--%>
    <asp:HiddenField ID="hid_SupplyTo" runat="server" /> 
     <asp:HiddenField ID="hid_SupplyTocity" runat="server" /> 
    
      <asp:HiddenField ID="hid_SupplyTonew" runat="server" /> 
    
</asp:Content>

