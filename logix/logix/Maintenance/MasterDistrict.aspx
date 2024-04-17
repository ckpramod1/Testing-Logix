<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="MasterDistrict.aspx.cs" Inherits="logix.Maintenance.MasterDistrict" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%-- <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>--%>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css"/>
     <link href="../Styles/MasterDistrict.css" rel="stylesheet" type="text/css" />
     <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
          <link href="../Styles/button1.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" language="javascript">
       function pageLoad(sender, args) {
           $(document).ready(function () {
               $("#<%=txtcountry.ClientID %>").autocomplete({
                   source: function (request, response) {

                       $.ajax({
                           url: "MasterDistrict.aspx/GetCountry",
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
                       $("#<%=txtcountry.ClientID %>").val(i.item.label);
                       $("#<%=txtcountry.ClientID %>").change();
                       $("#<%=hdf_country.ClientID %>").val(i.item.val);



                   },
                   focus: function (event, i) {
                       $("#<%=txtcountry.ClientID %>").val(i.item.label);
                       $("#<%=hdf_country.ClientID %>").val(i.item.val);

                   },
                   close: function (event, i) {
                       $("#<%=txtcountry.ClientID %>").val(i.item.label);
                       $("#<%=hdf_country.ClientID %>").val(i.item.val);

                   },
                   minLength: 1
               });
           });
           $(document).ready(function () {
               $("#<%=txtstate.ClientID %>").autocomplete({
                   source: function (request, response) {

                       $.ajax({
                           url: "MasterDistrict.aspx/GetState",
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
                       $("#<%=hdf_state.ClientID %>").val(i.item.val);
                       $("#<%=txtstate.ClientID %>").val(i.item.label);
                       $("#<%=txtstate.ClientID %>").change();



                   },
                   focus: function (event, i) {
                       $("#<%=txtstate.ClientID %>").val(i.item.label);
                       $("#<%=hdf_state.ClientID %>").val(i.item.val);

                   },
                   close: function (event, i) {
                       $("#<%=txtstate.ClientID %>").val(i.item.label);
                       $("#<%=hdf_state.ClientID %>").val(i.item.val);

                   },
                   minLength: 1
               });
           });
           $(document).ready(function () {
               $("#<%=txtdistrict.ClientID %>").autocomplete({
                   source: function (request, response) {

                       $.ajax({
                           url: "MasterDistrict.aspx/GetDistrict",
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
                       $("#<%=txtdistrict.ClientID %>").val(i.item.label);
                       $("#<%=txtdistrict.ClientID %>").change();
                       $("#<%=hdf_district.ClientID %>").val(i.item.val);

                   },
                   focus: function (event, i) {
                       $("#<%=txtdistrict.ClientID %>").val(i.item.label);
                       $("#<%=hdf_district.ClientID %>").val(i.item.val);
                   },
                   close: function (event, i) {
                       $("#<%=txtdistrict.ClientID %>").val(i.item.label);
                       $("#<%=hdf_district.ClientID %>").val(i.item.val);
                   },
                   minLength: 1
               });
           });
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


           $("#flagSwitcher").click(function () {
               $(".dropdown img.flag").toggleClass("flagvisibility");
           });
       }
       </script>
    <%-- <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js" type="text/javascript"></script>--%>
    
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
 <asp:HiddenField ID="hdf_district" runat="server" />
    <asp:HiddenField ID="hdf_state" runat="server" />
    <asp:HiddenField ID="hdf_country" runat="server" />
    <asp:Panel runat="server" class="div_total">
   
 <%--<div class="div_total">--%>
     <div class="Header"><asp:Label ID="Label1" runat="server" Text="District" CssClass="lbl_Header"></asp:Label></div>
     <div class="div_Break"></div>
     <%--<div class="div_label"><asp:Label ID="Label2" runat="server" Text="District" CssClass="LabelValue"></asp:Label></div>--%>
     <div class="div_text">
         <asp:TextBox ID="txtdistrict" runat="server" AutoPostBack="True" TabIndex="1" ontextchanged="txtdistrict_TextChanged" onkeypress="return ValidateAlpha (event,'District');" onkeyup="CheckTextLength(this,30);" CssClass="Text" placeholder="District" ToolTip="District"></asp:TextBox></div>
     <div class="div_Break"></div>
     <%--<div class="div_label"><asp:Label ID="Label3" runat="server" Text="State" CssClass="LabelValue"></asp:Label></div>--%>
     <div class="div_text"><asp:TextBox ID="txtstate" runat="server" AutoPostBack="True"  TabIndex="2" onkeypress="return ValidateAlpha (event,'State');" CssClass="Text" ontextchanged="txtstate_TextChanged" placeholder="State" ToolTip="State"></asp:TextBox></div>
     <div class="div_Break"></div>
     <%--<div class="div_label"><asp:Label ID="Label4" runat="server" Text="Country" CssClass="LabelValue"></asp:Label></div>--%>
     <div class="div_text">
         <asp:TextBox ID="txtcountry" runat="server" AutoPostBack="True" onkeypress="return ValidateAlpha (event,'Country');" CssClass="Text" ontextchanged="txtcountry_TextChanged" Enabled="False" placeholder="Country" ToolTip="Country"></asp:TextBox></div>
     <div class="div_Break"></div>
     <hr />
     <div class="div_Break"></div>
     <div class="div_button">
         <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="myButton" TabIndex="3" onclick="btnSave_Click"/>
         <asp:Button ID="btnView" runat="server" Text="View"  CssClass="myButton" TabIndex="4" onclick="btnView_Click" />
         <asp:Button ID="btnDelete" runat="server" Text="Delete"  CssClass="myButton" TabIndex="5" />
         <asp:Button ID="btnBack" runat="server" Text="Back"  CssClass="myButton" TabIndex="6" onclick="btnBack_Click" /></div>
         <div class="div_Break"></div> 
         <hr />
         <div class="div_Break"></div>
       <br />
     <div class="div_Grid">
        <asp:GridView ID="grd" runat="server"  AutoGenerateColumns="False" 
                DataKeyNames="districtid,stateid,countryid" Width="100%"
        ShowHeaderWhenEmpty="True"  AllowPaging="false" EmptyDataText="No Record Found" EnableTheming="False" onpageindexchanging="grd_PageIndexChanging" PageSize="10">
       <Columns>
                                    <asp:BoundField DataField="sno" HeaderText="S#" ItemStyle-Width="10px">
                                         <HeaderStyle Width ="30px"/>
                                         <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="30px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="districtname" HeaderText="District">                                      
                                         <HeaderStyle Width ="145px"/>
                                         <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="statename" HeaderText="State">
                                        <HeaderStyle Width ="190px"/>
                                         <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="countryname" HeaderText="Country">
                                        <HeaderStyle Width ="145px"/>
                                         <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="150px" />
                                    </asp:BoundField>
       </Columns>
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
             <HeaderStyle CssClass="GridHeader_my"/>
             <AlternatingRowStyle CssClass="GrdAltRow"/>
             <RowStyle CssClass="GrdRow " />
       </asp:GridView>
         </div>
         <div class="div_buttonExport">
            <%--<div style="width:25%;border:1px solid green; float:left;">
             <asp:Button ID="btnprint" runat="server" Text="Print"  CssClass="Button"/></div>--%>
             <div runat="server" id="signup" Visible="false" style="width:70%; margin-left:24%; margin-right:1%;">
              <dl id="sample" class="dropdown">
        <dt><a href="#"><span>Export To </span></a></dt>
        <dd>
         <ul>
           <li><asp:LinkButton ID="LinkButton1" runat="server" OnClick="Excelfunforserver_Click">Excel</asp:LinkButton></li>
           <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="pdffunforserver_Click">PDF</asp:LinkButton></li>
           
            </ul>
        </dd>
    </dl></div>
             </div>

             <div class="div_Break"></div>
             <div class="div_Break"></div>
   
  <%-- </div>--%>
    </asp:Panel>
</asp:Content>
