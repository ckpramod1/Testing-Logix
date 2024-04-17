\
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="MasterCustomerProspective.aspx.cs" Inherits="logix.Maintenance.MasterCustomerProspective" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../Styles/MasterCustomer.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/MasterCustomerProspective.css" rel="Stylesheet" type="text/css" />
<script src="../Scripts/jquery.min.js" type="text/javascript"></script>
<script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
<link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
<script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
<link href="../Styles/ControlStyle2.css" rel="Stylesheet" type="text/css" />
<link href ="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
           <link href="../Styles/button1.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    function pageLoad(sender, args) {
        $(document).ready(function () {
            $("#<%=txtlocation.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "MasterCustomerProspective.aspx/GetLocation",
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
            $("#<%=txtpin.ClientID %>").autocomplete({
                source: function (request, response) {

                    $.ajax({
                        url: "MasterCustomerProspective.aspx/GetPincode",
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
                    $("#<%=txtpin .ClientID %>").val(i.item.value);
                     $("#<%=txtpin.ClientID %>").change();

                 },
                change: function (event, i) {
                    $("#<%=txtpin.ClientID %>").val(i.item.value);
                    },
                    focus: function (event, i) {
                        $("#<%=txtpin.ClientID %>").val(i.item.value);
                    },
                    close: function (event, i) {
                        $("#<%=txtpin .ClientID %>").val(i.item.value);
                    },
                minLength: 1
            });
        });
      

        $(document).ready(function () {
            $("#<%=txtcustomer.ClientID %>").autocomplete({
                source: function (request, response) {

                    $.ajax({
                        url: "MasterCustomerProspective.aspx/GetCustomer",
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
                    $("#<%=txtcustomer.ClientID %>").val(i.item.label);
                    $("#<%=txtcustomer.ClientID %>").change();
                    $("#<%=hf_customerid.ClientID %>").val(i.item.val);


                },
                focus: function (event, i) {
                    $("#<%=txtcustomer.ClientID %>").val(i.item.label);
                    $("#<%=hf_customerid.ClientID %>").val(i.item.val);

                },
                close: function (event, i) {
                    $("#<%=txtcustomer.ClientID %>").val(i.item.label);
                    $("#<%=hf_customerid.ClientID %>").val(i.item.val);

                },
                minLength: 1
            });
        });


        $(document).ready(function () {
            $("#<%=txtcity .ClientID %>").autocomplete({
                source: function (request, response) {

                    $.ajax({
                        url: "MasterCustomerProspective.aspx/GetPortName",
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


<%--        $(document).ready(function () {
            $("#<%=txtpincode.ClientID %>").autocomplete({
                 source: function (request, response) {

                     $.ajax({
                         url: "MasterCustomerProspective.aspx/Getpincodelotaion",
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
                     $("#<%=txtlocation .ClientID %>").val(i.item.label);
                     $("#<%=txtlocation.ClientID %>").change();
                     $("#<%=hf_locationid  .ClientID %>").val(i.item.val);


                 },
                focus: function (event, i) {
                    $("#<%=txtlocation.ClientID %>").val(i.item.label);
                    $("#<%=hf_locationid.ClientID %>").val(i.item.val);

                },
                close: function (event, i) {
                    $("#<%=txtlocation.ClientID %>").val(i.item.label);
                    $("#<%=hf_locationid.ClientID %>").val(i.item.val);

                },
                    minLength: 1
            });
         });
--%>


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
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
 <asp:Panel runat="server" class="div_form">
  
<div class="header"> <asp:Label ID="Label1" runat="server" Text="Prospective Customer"></asp:Label></div>
<div class="div_break"></div>
<div style="width:69%; float:left;">
 <div class="labels"><asp:Label ID="Label2" runat="server" Text="Customer" CssClass="LabelValue"></asp:Label></div>
 <div class="WH_labelstart"><asp:TextBox ID="txtcustomer" runat="server" 
         TabIndex="1" AutoPostBack="True" CssClass="Text" 
         ontextchanged="txtcustomer_TextChanged" onkeyup="CheckTextLength(this,100);"></asp:TextBox></div>
 <div class="div_Break"></div>
 <div class="labels"><asp:Label ID="Label3" runat="server" Text="Unit#" CssClass="LabelValue"></asp:Label></div>
 <div class="txtDoor"><asp:TextBox ID="txtunit" runat="server" TabIndex="2" CssClass="Text" onkeyup="CheckTextLength(this,10);"></asp:TextBox></div>
 <div class="labels_bname"><asp:Label ID="Label4" runat="server" Text="BuildingName" CssClass="LabelValue"></asp:Label></div>
 <div class="txtBuilding"><asp:TextBox ID="txtbuildingname" runat="server" AutoPostBack="True"  CssClass="Text" TabIndex="3" onkeyup="CheckTextLength(this,50);"></asp:TextBox></div>
 <div class="div_Break"></div>
 <div class="labels"><asp:Label ID="Label5" runat="server" Text="Door#" CssClass="LabelValue"></asp:Label></div>
 <div class="txtDoor"><asp:TextBox ID="txtdoor" runat="server" AutoPostBack="True" TabIndex="4" CssClass="Text" onkeyup="CheckTextLength(this,10);"></asp:TextBox></div>
 <div class="labels_bname"><asp:Label ID="Label6" runat="server" Text="Street" CssClass="LabelValue"></asp:Label></div>
 <div class="txtBuilding"><asp:TextBox ID="txtstreet" runat="server" AutoPostBack="True"  TabIndex="5" CssClass="Text" onkeyup="CheckTextLength(this,100);"></asp:TextBox></div>
 <div class="div_break"></div>
 <div class="labels"><asp:Label ID="Label7" runat="server" Text="Location" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"><asp:TextBox ID="txtlocation" runat="server" CssClass="Text" 
        AutoPostBack="True" TabIndex="6" ontextchanged="txtlocation_TextChanged1" onkeyup="CheckTextLength(this,60);"></asp:TextBox></div>
<div class="labels_bname"><asp:Label ID="Label8" runat="server" Text="Pincode" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"><%--<asp:TextBox ID="txtpincode" runat="server" AutoPostBack="True"  ></asp:TextBox>--%>
    <asp:TextBox ID="txtpin" runat="server" AutoPostBack="true" OnTextChanged="txtpin_TextChanged" TabIndex="7" ></asp:TextBox>
</div>
 <div class="div_break"></div>
 <div class="labels"><asp:Label ID="Label9" runat="server" Text="City" CssClass="LabelValue"></asp:Label></div>
 <div class="txtUnit"><asp:TextBox ID="txtcity" runat="server" AutoPostBack="True" CssClass="Text" TabIndex="8" OnTextChanged="txtcity_TextChanged"></asp:TextBox></div>
 <div class="labels_bname"><asp:Label ID="Label10" runat="server" Text="District" CssClass="LabelValue"></asp:Label></div>
 <div class="txtUnit"><asp:TextBox ID="txtdistrict" runat="server" AutoPostBack="True" Enabled="False" CssClass="Text"></asp:TextBox></div>
  <div class="div_break"></div>
 <div class="labels"><asp:Label ID="Label11" runat="server" Text="State" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"><asp:TextBox ID="txtstate" runat="server" AutoPostBack="True" Enabled="False" CssClass="Text"></asp:TextBox></div>
<div class="labels_bname"><asp:Label ID="Label12" runat="server" Text="Country" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"><asp:TextBox ID="txtcountry" runat="server" CssClass="Text" AutoPostBack="True" Enabled="False"></asp:TextBox></div>
<div class="div_break"></div>
<div class="labels"><asp:Label ID="Label13" runat="server" Text="Landline" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"><asp:TextBox ID="txtllisd" runat="server" AutoPostBack="True" Width="17%" Enabled="False"></asp:TextBox>
                            <asp:TextBox ID="txtllstd" runat="server" Width="29%" AutoPostBack="True" Enabled="False"></asp:TextBox>
                             <asp:TextBox ID="txtlandline" runat="server" Width="48.7%" AutoPostBack="True" TabIndex="9" onkeypress="return isNumberKey (event)"></asp:TextBox></div>
<div class="labels_bname"><asp:Label ID="Label14" runat="server" Text="Fax" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"><asp:TextBox ID="txtfaxisd" runat="server" Width="18%" AutoPostBack="True" Enabled="False"></asp:TextBox>
                           <asp:TextBox ID="txtfaxstd" runat="server" Width="30%" AutoPostBack="True" Enabled="False"></asp:TextBox>
                            <asp:TextBox ID="txtfax" runat="server" Width="46.5%" AutoPostBack="True" TabIndex="10" onkeypress="return isNumberKey (event)"></asp:TextBox></div>
<div class="div_break"></div>
<div class="labels"><asp:Label ID="Label16" runat="server" Text="Mobile" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"><asp:TextBox ID="txtmblisd" runat="server" Width="17%" Enabled="False"></asp:TextBox>
                           <asp:TextBox ID="txtMobile" runat="server" Width="79.7%" TabIndex="11" onkeypress="return isNumberKey (event)"></asp:TextBox></div>
<div class="labels_bname"><asp:Label ID="Label15" runat="server" Text="eMail" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"> <asp:TextBox ID="txtemail" runat="server" AutoPostBack="True" TabIndex="12" onblur="javascript:ValidateEmail(this)" ></asp:TextBox></div>
<div class="div_break"></div>
<div class="labels"><asp:Label ID="Label18" runat="server" Text="PAN #" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"> <asp:TextBox ID="txtPanNo" runat="server" AutoPostBack="True" TabIndex="13" CssClass="Text" onkeyup="CheckTextLength(this,25);" ></asp:TextBox></div>
<div class="labels_bname"><asp:Label ID="Label19" runat="server" Text="Service Tax#" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"> <asp:TextBox ID="txtServiceTaxNo" runat="server" AutoPostBack="True" TabIndex="14" CssClass="Text" onkeyup="CheckTextLength(this,25);"></asp:TextBox></div>
<div class="div_break"></div>
 </div>
 <div style="width:30%; margin-right:0.2%; float:right;">
 <div class="labels"><asp:Label ID="Label17" runat="server" Text="Type" CssClass="LabelValue"></asp:Label></div>
 <div class="div_break"></div>
 <div class="divCkeckbox"><%--<asp:CheckBoxList ID="chkType" runat="server">
     </asp:CheckBoxList>--%>
     <asp:CheckBox ID="Check1" runat="server" 
         oncheckedchanged="Check1_CheckedChanged " AutoPostBack="true"/><asp:Label ID="Label20" runat="server" Text="Shipper"></asp:Label><br />
     <asp:CheckBox ID="Check2" runat="server" AutoPostBack="true" 
         oncheckedchanged="Check2_CheckedChanged" /><asp:Label ID="Label21" runat="server" Text="Consignee"></asp:Label><br />
     <asp:CheckBox ID="Check3" runat="server" AutoPostBack="true" 
         oncheckedchanged="Check3_CheckedChanged" /><asp:Label ID="Label22" runat="server" Text="Notify Party"></asp:Label><br />
     <asp:CheckBox ID="Check4" runat="server" oncheckedchanged="Check4_CheckedChanged" AutoPostBack="true" /><asp:Label ID="Label23" runat="server" Text="Agent / Principal/CounterPart"></asp:Label><br />
     <asp:CheckBox ID="Check5" runat="server" AutoPostBack="true" 
         oncheckedchanged="Check5_CheckedChanged" /><asp:Label ID="Label24" runat="server" Text="CHA / CNF"></asp:Label><br />
     <asp:CheckBox ID="Check6" runat="server" AutoPostBack="true" 
         oncheckedchanged="Check6_CheckedChanged"  /><asp:Label ID="Label25" runat="server" Text="Carrier / Airliner/ MLO /Freight Forwarder"></asp:Label><br />
     <asp:CheckBox ID="Check7" runat="server" AutoPostBack="true" 
         oncheckedchanged="Check7_CheckedChanged" /><asp:Label ID="Label26" runat="server" Text="Transporter"></asp:Label><br />
     <asp:CheckBox ID="Check8" runat="server" AutoPostBack="true" 
         oncheckedchanged="Check8_CheckedChanged" /><asp:Label ID="Label27" runat="server" Text="Counter Part"></asp:Label><br />
     <asp:CheckBox ID="Check9" runat="server" AutoPostBack="true" 
         oncheckedchanged="Check9_CheckedChanged" /><asp:Label ID="Label28" runat="server" Text="Others"></asp:Label><br />
     <asp:CheckBox ID="Check10" runat="server" AutoPostBack="true" 
         oncheckedchanged="Check10_CheckedChanged" /><asp:Label ID="Label29" runat="server" Text="CFS"></asp:Label><br />
     <asp:CheckBox ID="Check11" runat="server" AutoPostBack="true" /><asp:Label ID="Label30" runat="server" Text="Warehouse"></asp:Label><br />
      </div>
     <%-- <asp:CustomValidator ID="CustomValidatorSkillsYouHave" runat="server"ErrorMessage="You must select at least one skill" ForeColor="Red" OnServerValidate="CustomValidatorSkillsYouHave_ServerValidate" />--%>
 </div>
 <div class="div_break"></div>
 <hr />
 <div class="div_break"></div>
      <div style="width:70%; height:100%; float:left;">
 <div class="labels_mail"><asp:Label ID="Label41" runat="server" Text="E-Mail ID's" ></asp:Label></div>
 <div class="div_break"></div>
 <%--<div class="labels"><asp:Label ID="Label31" runat="server" Text="Management" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"><asp:TextBox ID="txtManagMailid" runat="server" CssClass="Text" AutoPostBack="True" TabIndex="7" ></asp:TextBox></div>
<div class="labels_bname"><asp:Label ID="Label32" runat="server" Text="PTC" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"><asp:TextBox ID="txtManagPTC" runat="server" AutoPostBack="True" ></asp:TextBox></div>
 <div class="div_break"></div>--%>
  <div class="labels"><asp:Label ID="Label33" runat="server" Text="Commercial" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"><asp:TextBox ID="txtComMail" runat="server" CssClass="Text" AutoPostBack="True" TabIndex="15" ></asp:TextBox></div>
<div class="labels_bname"><asp:Label ID="Label34" runat="server" Text="PTC" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"><asp:TextBox ID="txtComPTC" runat="server" AutoPostBack="True" TabIndex="16"></asp:TextBox></div>
 <div class="div_break"></div>
  <div class="labels"><asp:Label ID="Label35" runat="server" Text="Export" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"><asp:TextBox ID="txtExpMail" runat="server" CssClass="Text" AutoPostBack="True" TabIndex="17" ></asp:TextBox></div>
<div class="labels_bname"><asp:Label ID="Label36" runat="server" Text="PTC" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"><asp:TextBox ID="txtExpPTC" runat="server" AutoPostBack="True" TabIndex="18"></asp:TextBox></div>
 <div class="div_break"></div>
  <div class="labels"><asp:Label ID="Label37" runat="server" Text="Import" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"><asp:TextBox ID="txtImpMail" runat="server" CssClass="Text" AutoPostBack="True" TabIndex="19" ></asp:TextBox></div>
<div class="labels_bname"><asp:Label ID="Label38" runat="server" Text="PTC" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"><asp:TextBox ID="txtImpPTC" runat="server" AutoPostBack="True" TabIndex="20"></asp:TextBox></div> <div class="div_break"></div>
     
<div class="labels"><asp:Label ID="Label39" runat="server" Text="Finance" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"><asp:TextBox ID="txtFinMail" runat="server" CssClass="Text" AutoPostBack="True" TabIndex="21" ></asp:TextBox></div>
<div class="labels_bname"><asp:Label ID="Label40" runat="server" Text="PTC" CssClass="LabelValue"></asp:Label></div>
<div class="txtUnit"><asp:TextBox ID="txtFinPTC" runat="server" AutoPostBack="True" TabIndex="22" ></asp:TextBox></div>
<div class="div_break"></div>
</div>
<div style ="width :29%; height:100%; float:right; margin-top:3%;">
<div style="width:50%; margin-left:2%; margin-top:2%;">
    <asp:RadioButton ID="rdbNewCustomer" runat="server" Text="New Customer" 
        AutoPostBack="True" oncheckedchanged="rdbNewCustomer_CheckedChanged" /></div>
<div style="width:50%; margin-left:2%; margin-top:2%;">
    <asp:RadioButton ID="rdbFollowUp" runat="server" Text="Follow Up" 
        AutoPostBack="True" oncheckedchanged="rdbFollowUp_CheckedChanged" /></div>
<div style="width:50%; margin-left:2%; margin-top:2%;">
    <asp:RadioButton ID="rdbExisting" runat="server" Text="Existing Customer" 
        AutoPostBack="True" oncheckedchanged="rdbExisting_CheckedChanged" /></div>
</div>
      <div class="div_break"></div>
 <hr />
 <div class="div_break"></div>
     <div class="div_lst" ><asp:ListBox ID="lstlocation" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="lstlocation_SelectedIndexChanged"  ></asp:ListBox></div>
          <div class="button"><asp:Button ID="btnSave" runat="server" Text="Save" 
         CssClass="myButton" onclick="btnSave_Click" TabIndex="23" />
              <asp:Button ID="btnView" runat="server" Text="View" CssClass="myButton" TabIndex="24"
         onclick="btnView_Click"/>
               <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="myButton" TabIndex="25"/>
               <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="myButton"  TabIndex="26" onclick="btnBack_Click"/></div>
  <div class="div_break"></div>
  <div class="div_Grid">
    <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False"    
        DataKeyNames="districtid,stateid,countryid,portid,locationid,customerid" 
        Width="99%" ShowHeaderWhenEmpty="True"            
                EmptyDataText="No Record Found" EnableTheming="False" 
        AllowPaging="false" PageSize="3" 
        onpageindexchanging="carggrid_PageIndexChanging"  >
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
          <asp:BoundField DataField="custttype" HeaderText="Customer Type"/>
        </Columns>
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
             <HeaderStyle CssClass="GridHeader"/>
             <AlternatingRowStyle CssClass="GrdAltRow"/>
             <RowStyle CssClass="GrdRow" />
    </asp:GridView>
    </div>
    <div class="div_Break"></div>
    <div runat="server" id="signup" Visible="false" style="width:10%; float:right;  margin-right:1%; margin-top:0.1%;">
              <dl id="sample" class="dropdown">
        <dt><a href="#"><span>Export To </span></a></dt>
        <dd>
             <ul>
            <li><asp:LinkButton ID="LinkButton1" runat="server" OnClick="Excelfunforserver_Click">Excel</asp:LinkButton></li>
           <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="pdffunforserver_Click">PDF</asp:LinkButton></li>
               
            </ul>
        </dd>
    </dl></div>
    <div class="div_Break"></div>
   </asp:Panel>


     <asp:HiddenField ID="hdf_pinlocation" runat="server" />
    <asp:HiddenField ID="hf_locationid" runat="server" />
        <asp:HiddenField ID="hf_portid" runat="server" />
        <asp:HiddenField ID="hf_districtid" runat="server" />
        <asp:HiddenField ID="hf_stateid" runat="server" />
        <asp:HiddenField ID="hf_countryid" runat="server" />
        <asp:HiddenField ID="hf_customerid" runat="server" />
        <asp:HiddenField ID="hf_email" runat="server" />
         <asp:HiddenField ID="hfWasConfirmed" runat="server" />

</asp:Content>
