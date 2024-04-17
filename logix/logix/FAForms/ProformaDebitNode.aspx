<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="ProformaDebitNode.aspx.cs" EnableEventValidation="false" Inherits="logix.FAForms.ProformaDebitNode" %>
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
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

  <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

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


    <link href="../Styles/ProDebitNote.css" rel="stylesheet" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js"></script>


    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
     <style type="text/css">

         a img{border: none;}
		ol li{list-style: decimal outside;}
		div#container{width: 780px;margin: 0 auto;padding: 1em 0;}
		div.side-by-side{width: 100%;margin-bottom: 1em;}
		div.side-by-side > div{float: left;width: 50%;}
		div.side-by-side > div > em{margin-bottom: 10px;display: block;}
		.clearfix:after{content: "\0020";display: block;height: 0;clear: both;overflow: hidden;visibility: hidden;}
         #logix_CPH_pnldebit {left:330px!important; top:190px!important;
                             
         }
          #logix_CPH_Panel2
          {
               top:10px!important;
          }
          .ToInput6 {
    width:49.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}


.ToInputOther7 {
    float: left;
    margin: 0 0.5% 0 0;
    width: 41.6%;
}

.ToCal8 {
    width: 7.9%;
    float: left;
    margin: 0px 0% 0px 0px;
}
.TotalTxt2 {
    float: right;
    margin: 0;
    width: 84%;
}




        </style>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txt_charge.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_chargeid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCharge",
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
                        $("#<%=txt_charge.ClientID %>").val(i.item.label);
                        $("#<%=txt_charge.ClientID %>").change();
                        $("#<%=hid_chargeid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_charge.ClientID %>").val(i.item.label);
                        $("#<%=hid_chargeid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        $("#<%=txt_charge.ClientID %>").val(i.item.label);
                        $("#<%=hid_chargeid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_charge.ClientID %>").val(i.item.label);
                        $("#<%=hid_chargeid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_curr.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCurrency",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item,
                                        val: item

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
                    select: function (e, i) {
                        $("#<%=txt_curr.ClientID %>").change();
                    },
                    change: function (e, i) {
                        $("#<%=txt_curr.ClientID %>").val(i.item.val);
                    },
                    focus: function (e, i) {
                        $("#<%=txt_curr.ClientID %>").val(i.item.val);
                    },
                    close: function (e, i) {
                        $("#<%=txt_curr.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_bl.ClientID %>").autocomplete({
                    source: function (request, response) {
                        var Chk = "";
                        var lblhead = "";
                        if ($("#<%=Chk_Mbl.ClientID %>").is(':checked')) {
                            Chk = 'True';
                        }
                        else {
                            Chk = 'False';
                        }



                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetBL_DNCNnew",
                            data: "{ 'prefix': '" + request.term + "','ChkType':'" + Chk + "','Tran':'" + $("#<%=ddl_module.ClientID %>").val() + "','head':'" + $("#<%=lbl_Header.ClientID %>").val() + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item,
                                        val: item

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
                        $("#<%=txt_bl.ClientID %>").change();
                        <%--$("#<%=hid_Blnum.ClientID %>").val(i.item.val);--%>
                    },
                   focus: function (event, i) {
                        $("#<%=txt_bl.ClientID %>").val(i.item.val);                        
                    },
                    change: function (event, i) {
                        $("#<%=txt_bl.ClientID %>").val(i.item.val);                        
                    },
                    close: function (event, i) {
                        $("#<%=txt_bl.ClientID %>").val(i.item.val);                        
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txt_to.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_customerid.ClientID %>").val(0);
                        var chk = "";
                        if ($("#<%=rbt_customer.ClientID %>").is(':checked')) {
                            chk = 'C';
                        } else if ($("#<%=rbt_agent.ClientID %>").is(':checked')) {
                            chk = 'P';
                        }
                        else {
                            alertify.alert('Select Party type as Customer or Agent');
                            $("#<%=rbt_customer.ClientID %>").focus();
                            return false;
                        }
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCustomer_DNCN",
                            data: "{ 'prefix': '" + request.term + "','ChkType':'" + chk + "'}",
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
                        $("#<%=txt_to.ClientID %>").val($.trim(i.item.label.split(',')[0]));                     
                        $("#<%=txt_to.ClientID %>").change();
                        $("#<%=hid_customerid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_to.ClientID %>").val($.trim(i.item.label.split(',')[0]));                       
                        $("#<%=hid_customerid.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_to.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_customerid.ClientID %>").val(i.item.val);
                        }
                    },
                    close: function (event, i) {
                        var result = $("#<%=txt_to.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_to.ClientID %>").val($.trim(result));
                    },
                   
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtsupplyto.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hid_SupplyTo.ClientID %>").val(0);
                        var chk = "";
                        if ($("#<%=rbt_customer.ClientID %>").is(':checked')) {
                            chk = 'C';
                        } else if ($("#<%=rbt_agent.ClientID %>").is(':checked')) {
                            chk = 'P';
                        }
                        else {
                            alertify.alert('Select Party type as Customer or Agent');
                            $("#<%=rbt_customer.ClientID %>").focus();
                            return false;
                        }
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetCustomer_DNCN",
                            data: "{ 'prefix': '" + request.term + "','ChkType':'" + chk + "'}",
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
                        $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtsupplyto.ClientID %>").change();
                        $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                        }
                    },
                    close: function (event, i) {
                        var result = $("#<%=txtsupplyto.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtsupplyto.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });


            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

<%--            $(document).ready(function () {
                $("#<%=txtsupplyto.ClientID %>").autocomplete({

                              source: function (request, response) {
                                  $("#<%=hid_SupplyTo.ClientID %>").val(0);
                           $.ajax({
                               url: "../Accounts/OtherProDCN.aspx/GetToCust",
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

                    
                    <%-- select: function (event, i) {
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
                    select: function (e, i) {
                        if (i.item) {
                            $("#<%=txtsupplyto.ClientID %>").val(i.item.label);
                          $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                        $("#<%=hid_SupplyToadd.ClientID %>").val(i.item.text);
                          $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                         <%-- $("#<%=txtsupplytoAddress.ClientID %>").val(i.item.address);
                          $("#<%=txtsupplyto.ClientID %>").change();
                      }
                     },

                    focus: function (e, i) {
                        if (i.item) {
                            $("#<%=txtsupplyto.ClientID %>").val(i.item.label);
                            $("#<%=hid_SupplyTo.ClientID %>").val(i.item.val);
                          <%--  $("#<%=hid_SupplyToadd.ClientID %>").val(i.item.text);
                            $("#<%=txtsupplyto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            <%--$("#<%=txtsupplytoAddress.ClientID %>").val(i.item.address);
                        }

                    },
                    close: function (e, i) {
                        var result = $("#<%=txtsupplyto.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtsupplyto.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
                      });--%>



        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


     <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
           <li><a href="#">Operating Accounts</a></li>
              <li><a href="#" title="">Voucher</a> </li>
              <li class="current"><a href="#" title="" id="HeaderLabel" runat="server">Profoma Debit Note</a> </li>
              <li><asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
            </ul>
      </div>
          <!-- /Breadcrumbs line -->
    <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
   
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i> <asp:Label ID="lbl_Header" runat="server" Text=""></asp:Label></h4>
                </div>
            <div class="widget-content" >
                <div class="FormGroupContent4">
                    <div class="ModuleDrop"><asp:DropDownList ID="ddl_module" runat="server" AutoPostBack="True" CssClass="chzn-select" TabIndex="1"
            ToolTip="Product" data-placeholder="Product" OnSelectedIndexChanged="ddl_module_SelectedIndexChanged">
            <asp:ListItem Text="" Value="0"></asp:ListItem>
            <asp:ListItem Value="AE">Air Exports</asp:ListItem>
            <asp:ListItem Value="AI">Air Imports</asp:ListItem>
           <%-- <asp:ListItem Value="CH">Custom House Agent</asp:ListItem>--%>
            <asp:ListItem Value="FE">Ocean Exports</asp:ListItem>
            <asp:ListItem Value="FI">Ocean Imports</asp:ListItem>
        </asp:DropDownList></div>
                    <div class="CustomerRad">  <asp:RadioButton ID="rbt_customer" runat="server" Text="Customer" GroupName="rbt" AutoPostBack="true"  TabIndex="2" /></div>
                    <div class="AgentRad"><asp:RadioButton ID="rbt_agent" runat="server" Text="Agent" GroupName="rbt" AutoPostBack="true"  TabIndex="3" /></div>
                    <div class="Year3"> <asp:TextBox ID="txt_year" runat="server" placeholder="Year" ToolTip="Year" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_year_TextChanged"></asp:TextBox></div>
                    <div class="RefInput1"> <asp:TextBox ID="txt_Refno" runat="server" AutoPostBack="True" placeholder="Ref #" ToolTip="Ref #" OnTextChanged="txt_Refno_TextChanged" CssClass="form-control"></asp:TextBox></div>
                    

                    </div>
                 <div class="FormGroupContent4">
                     <div class="BLInput2"> <asp:TextBox ID="txt_bl" runat="server" AutoPostBack="True" CssClass="form-control"   placeholder="BL #" ToolTip="BL Number" TabIndex="4" OnTextChanged="txt_bl_TextChanged"></asp:TextBox></div>
                     <div class="MBLChk1"> <asp:CheckBox ID="Chk_Mbl" runat="server" Text="MB/L" /></div>
                       <div class="MBLChk1"><asp:Label ID="lblbill" runat="server" Text="" CssClass="div_label"></asp:Label></div>
                       <div class="DNInput"><asp:TextBox ID="txt_DN" runat="server" placeholder="DN #" ToolTip="DN Number" CssClass="form-control"></asp:TextBox></div>
                     <div class="BillDrop3"><asp:DropDownList ID="ddl_bill" runat="server" AutoPostBack="true" CssClass="chzn-select" ToolTip="Bill Type" data-placeholder="Bill Type" TabIndex="5" >
           <%-- <asp:ListItem></asp:ListItem>
            <asp:ListItem Value="Cash/Cheque">Cash/Cheque</asp:ListItem>
            <asp:ListItem Value="Credit">Credit</asp:ListItem>
            <asp:ListItem Value="Internal">Internal</asp:ListItem>
            <asp:ListItem Value="Service Tax Exemption">ST/GST Exemption</asp:ListItem>--%>
        </asp:DropDownList></div>
                   

                     </div>
                 <div class="FormGroupContent4">
                     <div class="ToInput6"> <asp:TextBox ID="txt_to" runat="server" placeholder="Bill From" ToolTip="Bill From" CssClass="form-control" AutoPostBack="true" TabIndex="6" OnTextChanged="txt_to_TextChanged" ></asp:TextBox></div>
                       <div class="ToInputOther7"><asp:TextBox ID="txtsupplyto" runat="server" ToolTip="Supply From" placeholder="Supply From" CssClass="form-control" AutoPostBack="True" TabIndex="7" OnTextChanged="txtsupplyto_TextChanged" ></asp:TextBox></div>
                     <div class="ToCal8"> <asp:TextBox ID="txt_date" runat="server" placeholder="Date" ToolTip="Date"  CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                     </div>
                <div class="FormGroupContent4">
                             <div class="JobDetailsInput"><asp:TextBox ID="txtaddress" Style="resize: none;" Rows="2" runat="server" ToolTip="Address" placeholder="Address" CssClass="form-control" AutoPostBack="True" TextMode="MultiLine"></asp:TextBox>
                                 </div>
                             <div class="DesiInput"><asp:TextBox ID="txtsupplytoAddress" Style="resize: none;" Rows="2" runat="server" ToolTip="SupplyTo Address" placeholder="SupplyTo Address" CssClass="form-control" AutoPostBack="True" TextMode="MultiLine"></asp:TextBox>
                                 </div>
                              </div>
                <div class="FormGroupContent4">
                    <div class="ProfomaLeft">
                           <div class="FormGroupContent4">


                        <div class="JobDetails4"> 
                            <asp:TextBox ID="txt_job" runat="server" placeholder="Job" CssClass="form-control" Visible="false" ReadOnly="True"></asp:TextBox>

                             <asp:TextBox ID="txt_vessel" runat="server" placeholder="Job Details" ToolTip="Job Details" CssClass="form-control"  ReadOnly="True"></asp:TextBox>
                        </div>
                        <div class="Desi2"><asp:TextBox ID="txt_destination" runat="server" placeholder="Destination" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                               </div>
                         <div class="FormGroupContent4">


                        <div class="JobDetails4"> <asp:TextBox ID="txt_shipper" runat="server" placeholder="Shipper" CssClass="form-control" ToolTip="Shipper" ReadOnly="True"></asp:TextBox></div>
                        <div class="Desi2"> <asp:TextBox ID="txt_agent" runat="server" placeholder="Agent" ToolTip="Agent" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                               </div>
                         <div class="FormGroupContent4">


                        <div class="JobDetails4"> <asp:TextBox ID="txt_consignee" runat="server" placeholder="Consignee" CssClass="form-control" ToolTip="Consignee" ReadOnly="True"></asp:TextBox></div>
                        <div class="Desi2"><asp:TextBox ID="txt_mlo" runat="server" placeholder="MLO" ToolTip="MLO" CssClass="form-control"  ReadOnly="True"></asp:TextBox></div>
                               </div>
                         <div class="FormGroupContent4">


                        <div class="JobDetails4"><asp:TextBox ID="txt_notify" runat="server" placeholder="Notify party" CssClass="form-control" ToolTip="Notify party" ReadOnly="True"></asp:TextBox></div>
                        <div class="Desi2">
                             <asp:TextBox ID="txt_cnf" runat="server" placeholder="CNF" ToolTip="CNF" CssClass="form-control"  ReadOnly="True"></asp:TextBox>
                 <asp:TextBox ID="txtEta" runat="server" placeholder="Eta" ToolTip="Eta" CssClass="form-control" Visible="false" ReadOnly="True"></asp:TextBox>

                        </div>
                               </div>
                         <div class="FormGroupContent4">

                             <asp:TextBox ID="txt_remark" runat="server" placeholder="Remarks" AutoPostBack="true" CssClass="form-control"  TabIndex="7"  ToolTip="Remarks" TextMode="MultiLine" Style="resize:none" Width="100%" Height="42px"></asp:TextBox>
                        
                               </div>
                    </div>
                    <div class="ProfomaRight">
                        <div class="FormGroupContent4" runat="server" BorderColor="#b1b1b1">
                          
                <asp:ListBox ID="lst_container" runat="server" Width="100%" Height="100%" CssClass="form-control">
                </asp:ListBox>
                            </div>
                         <div class="FormGroupContent4" id="div_volumelist" runat="server" BorderColor="#b1b1b1">
                              
                <asp:ListBox ID="lst_volume" runat="server" Width="100%" Height="100%"  CssClass="form-control">
                </asp:ListBox>
                            </div>
                         <div class="FormGroupContent4" id="txt_vendor_DN" runat="server" BorderColor="#b1b1b1">
                             
                <asp:TextBox ID="txt_vendor" runat="server" placeholder="vendor Ref #" CssClass="form-control" ToolTip="vendor Ref #"></asp:TextBox>
                            </div>
                        <div class="FormGroupContent4">
                            <asp:TextBox ID="txt_credit" runat="server" placeholder="Credit Days" CssClass="form-control" ToolTip="Credit Days"></asp:TextBox>
                        </div>

                    </div>

                    </div>
                <div class="bordertopNew"></div>
                <div class="FormGroupContent4">
                    <div class="right_btn MT0">
                        <div class="btn ico-save" id="btn_save1" runat="server"> <asp:Button ID="btn_save" runat="server" ToolTip="Save" OnClick="btn_save_Click" TabIndex="8"  /></div>
                        <div class="btn ico-view"> <asp:Button ID="btn_view" runat="server" ToolTip="View" OnClick="btn_view_Click" TabIndex="17"/></div>
                        <div class="btn ico-delete"><asp:Button ID="btn_delete" runat="server" ToolTip="Delete" OnClick="btn_delete_Click" TabIndex="18" /></div>
                        <div class="btn ico-cancel" id="btn_cancel1" runat="server"> <asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click" TabIndex="16" /></div>
                       
       
        
       
                    </div>
                </div>
                <div class="bordertopNew"></div>
                <div class="FormGroupContent4">
                    <div class="ChargeDes"><asp:TextBox ID="txt_charge" runat="server" placeholder="Charge Description" AutoPostBack="True" CssClass="form-control" ToolTip="Charge Description" TabIndex="9" OnTextChanged="txt_charge_TextChanged" ></asp:TextBox></div>
                    <div class="Curr4"><asp:TextBox ID="txt_curr" runat="server" AutoPostBack="True" placeholder="Curr" ToolTip="Curr" CssClass="form-control" TabIndex="10" OnTextChanged="txt_curr_TextChanged"></asp:TextBox></div>
                    <div class="Rate6"><asp:TextBox ID="txt_rate" runat="server" placeholder="Rate" ToolTip="Rate" AutoPostBack="True"  CssClass="form-control"  TabIndex="11" OnTextChanged="txt_rate_TextChanged" ></asp:TextBox></div>
                    <div class="ExRate7"> <asp:TextBox ID="txt_exrate" runat="server" AutoPostBack="True" placeholder="Ex.Rate" CssClass="form-control" ToolTip="Ex.Rate" TabIndex="12"  OnTextChanged="txt_exrate_TextChanged"></asp:TextBox></div>
                    <div class="Base1">  <asp:DropDownList ID="ddl_base" runat="server" AppendDataBoundItems="True" CssClass="chzn-select" AutoPostBack="True" BorderColor="#999997"  ToolTip="Base/Unit" TabIndex="13" data-placeholder="Base/Unit" OnSelectedIndexChanged="ddl_base_SelectedIndexChanged">
       <asp:ListItem Value="0" Text=""></asp:ListItem>
             </asp:DropDownList></div>
                    <div class="Amount11"> 
                        <asp:TextBox ID="txt_amount" runat="server" ReadOnly="True"  placeholder="Amount" CssClass="form-control" Style="text-align: right" ToolTip="Amount" TabIndex="14"></asp:TextBox>
   



                    </div>
                    <div class="btn btn-add ADDPad"> <asp:Button ID="btn_add" runat="server" Text="Add"  OnClick="btn_add_Click" TabIndex="15"/></div>

                    </div>
                 <div class="bordertopNew"></div>
                 <div class="FormGroupContent4">
                     <asp:Panel id="Panel1" runat="server" ScrollBars="Auto" >
    <div class="div_Grid">
        <asp:GridView ID="Grd_Charge" runat="server" AutoGenerateColumns="False" Width="100%"
            ShowHeaderWhenEmpty="True"  class="Grid" DataKeyNames="chargeid" OnRowDataBound="Grd_Charge_RowDataBound"
            OnSelectedIndexChanged="Grd_Charge_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="charge" HeaderText="Charges" />
                <asp:BoundField DataField="curr" HeaderText="Curr" />
                <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:#,##0.00}" HeaderStyle-CssClass="TxtAlign1" ItemStyle-CssClass="TxtAlign1">
                </asp:BoundField>
                <asp:BoundField DataField="exrate" HeaderText="ExRate" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                </asp:BoundField>
                <asp:BoundField DataField="base" HeaderText="Base/Unit" />
               <%-- <asp:BoundField DataField="stgst" HeaderText="ST/GST">
                        <HeaderStyle HorizontalAlign="Center" Width="130" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">                    
                </asp:BoundField>--%>
                
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
              <%--  <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="select" ImageUrl="~/images/edit.gif" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
        </asp:GridView>
    </div>
             </asp:Panel>

                     </div>
                 <div class="FormGroupContent4">
                     <div class="right_btn MB05">
                         <div class="TotalTxt2">
                     <asp:TextBox ID="txt_total" runat="server" CssClass="form-control" PlaceHolder="Total" ToolTip="Total"  Style="text-align: right" ReadOnly="True"></asp:TextBox>
                  </div>
                              </div>
                           </div>
                </div>
         </div>
            </div>
        </div>



     <asp:Panel runat="Server" ID="pnldebit" CssClass="Pnl" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Do You Want Service Tax Applicable For This Charge </b></div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="Button" OnClick="btnYes_Click" />
            <asp:Button ID="btnNo" runat="server" Text="No" CssClass="Button" OnClick="btnNo_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>
    <div class="div_Break"></div>
    <asp:ModalPopupExtender ID="Confirmdialog" runat="server" TargetControlID="hid" PopupControlID="pnldebit" />   

    <asp:Panel runat="Server" ID="Panel2" CssClass="Pnl" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b><asp:Label ID="lbl_msg" runat="server" /></b></div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btnYes1" runat="server" Text="Yes" CssClass="Button" OnClick="btnYes1_Click" />
            <asp:Button ID="btnNo2" runat="server" Text="No" CssClass="Button" OnClick="btnNo2_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>
    <div class="div_Break"></div>
    <asp:ModalPopupExtender ID="Confirmdialog1" runat="server" TargetControlID="hid1" PopupControlID="Panel2" />
        
     <asp:Label ID="hid" runat="server" />
    <asp:Label ID="hid1" runat="server" />
    <%--<asp:HiddenField ID="hid" runat="server" />--%>
          <asp:HiddenField ID="txtjobno" runat="server" />
    <asp:HiddenField ID="hid_chargeid" runat="server" />
    <asp:HiddenField ID="hid_customerid" runat="server" />
    <asp:HiddenField ID="hid_type" runat="server" />
    <asp:HiddenField ID="hid_date" runat="server" />
    <asp:HiddenField ID="hid_base" runat="server" />
           <asp:HiddenField ID="hdnUnit" runat="server" />
         <asp:HiddenField ID="hf_strtype" runat="server" />
         <asp:HiddenField ID="hid_Blnum" runat="server" />
     <asp:HiddenField ID="hid_SupplyTo" runat="server" />
    <asp:HiddenField ID="hid_gstdate" runat="server" />

    <asp:HiddenField ID="hid_getdate" runat="server" />

        <asp:HiddenField ID="hid_SupplyToadd" runat="server" />
     <asp:HiddenField ID="hid_SupplyTonew" runat="server" />

    <asp:HiddenField ID="hid_cosigneeid" runat="server" />
           <asp:HiddenField ID="hid_mloid" runat="server" />
</asp:Content>







    
        
    
    
    