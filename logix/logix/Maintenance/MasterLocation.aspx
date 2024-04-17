 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MasterLocation.aspx.cs" Inherits="logix.Maintenance.MasterLocation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
   <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
     <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" /> 
    <link href="../Styles/MasterLocation.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/DropDownButton.css" rel="stylesheet" type="text/css" />
       <link href="../Styles/button1.css" rel="stylesheet" type="text/css" />


     <script type="text/javascript">
         function pageLoad(sender, args) {
             $(document).ready(function () {
                 $("#<%=txt_Location.ClientID %>").autocomplete({
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
                         $("#<%=txt_Location.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                         $("#<%=txt_city.ClientID %>").val(i.item.address);
                         $("#<%=hdn_locationid.ClientID %>").val(i.item.val);
                         $("#<%=txt_Location.ClientID %>").change();
                     },
                     focus: function (event, i) {
                         $("#<%=txt_Location.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                         $("#<%=txt_city.ClientID %>").val(i.item.address);
                         $("#<%=hdn_locationid.ClientID %>").val(i.item.val);
                         $("#<%=txt_Location.ClientID %>").val($.trim(result));
                         $("#<%=txt_Location.ClientID %>").change();

                     },
                     change: function (event, i) {
                         if (i.item) {
                             $("#<%=txt_Location.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                             $("#<%=txt_city.ClientID %>").val(i.item.address);
                             $("#<%=hdn_locationid.ClientID %>").val(i.item.val);
                             $("#<%=txt_Location.ClientID %>").change();
                         }
                     },

                     close: function (event, i) {
                         var result = $("#<%=txt_Location.ClientID %>").val().toString().split(',')[0];
                         $("#<%=txt_Location.ClientID %>").val($.trim(result));
                     },
                     minLength: 1
                             
                 });
             });


             $(document).ready(function () {
                 $("#<%=txt_city.ClientID %>").autocomplete({
                     source: function (request, response) {
                         $.ajax({
                             url: "MasterLocation.aspx/GetCity",
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
                         $("#<%=txt_city.ClientID %>").val(i.item.label);
                         $("#<%=txt_city.ClientID %>").change();
                         $("#<%=hdn_cityid.ClientID %>").val(i.item.val);
                     },
                     focus: function (event, i) {
                         $("#<%=txt_city.ClientID %>").val(i.item.label);
                         $("#<%=hdn_cityid.ClientID %>").val(i.item.val);
                     },
                     close: function (event, i) {
                         $("#<%=txt_city.ClientID %>").val(i.item.label);
                         $("#<%=hdn_cityid.ClientID %>").val(i.item.val);
                     },
                     minLength: 1
                 });
             });



             /**************************************/

             $(".dropdown img.flag").addClass("flagvisibility");

             $(".dropdown dt a").click(function () {
                 $(".dropdown dd ul").toggle();
             });

             $(".dropdown dd ul li a").click(function () {
                 var text = $(this).html();
                 $(".dropdown dt a span").html(text);
                 $(".dropdown dd ul").hide();
                 //                $("#result").html("Selected value is: " + getSelectedValue("sample"));
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

  <script type  ="text/javascript" >
      function onChangeTest() {
          __doPostBack("txt_Location", "TextChanged");
      }


        function getConfirmationValue() {
            var sector = document.getElementById('<%=txt_Location.ClientID %>').value;

            if (sector == "") {
                alertify.alert("Location Name can't be Empty...");
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
 


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

 <asp:UpdatePanel ID="updatePanelListboxes" runat="server" UpdateMode="Conditional">
  <ContentTemplate>

  <div class="div_total">
<%--    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
    </asp:UpdatePanel>--%>
       <asp:HiddenField ID="hdn_locationid" runat="server" />
       <asp:HiddenField ID="hdn_cityid" runat="server" />
       <asp:HiddenField ID="hdn_countryname" runat="server" />
       <asp:HiddenField ID="hfWasConfirmed" runat="server" />

      <asp:panel ID="Panel1" runat="server" class="panel_style">
            <div class="Header">&nbsp;&nbsp;<asp:Label ID="lbl_plnmaster" runat="server" Text="Location" CssClass="lbl_Header"> </asp:Label></div>
          
           <%-- <div class="plan_labels"><asp:Label ID="lbl_Location" runat="server" Text="Location" CssClass="LabelValue"></asp:Label></div>--%>
            <div class="plan_textboxes"><asp:TextBox ID="txt_Location" runat="server" ToolTip="LOCATION" PlaceHolder="LOCATION" CssClass="Text" ontextchanged="txt_Location_TextChanged" AutoPostBack="True"  
                    onKeyUp="CheckTextLength(this,60)"  TabIndex="1"></asp:TextBox></div> 
           <%-- <div class="plan_labels"><asp:Label ID="lbl_City" runat="server" Text="City" CssClass="LabelValue"></asp:Label></div>--%>
            <div class="plan_textboxes"><asp:TextBox ID="txt_city" runat="server" AutoPostBack="True" CssClass="Text" ToolTip="CITY" PlaceHolder="CITY" ontextchanged="txt_city_TextChanged" 
                    onKeyUp="CheckTextLength(this,50)" TabIndex="2"></asp:TextBox></div>
            <div class="div_break"></div>
            <%--<div class="plan_labels"><asp:Label ID="lbl_district" runat="server" Text="District" CssClass="LabelValue"></asp:Label></div>--%>
            <div class="plan_textboxes"><asp:TextBox ID="txt_District" runat="server"   CssClass="Text" ToolTip="DISTRICT" PlaceHolder="DISTRICT" AutoCompleteType="Disabled" ReadOnly="True" Enabled="False"></asp:TextBox></div>
           <%-- <div class="plan_labels"><asp:Label ID="lbl_State" runat="server" Text="State" CssClass="LabelValue"></asp:Label></div>--%>
            <div class="plan_textboxes"><asp:TextBox ID="txt_State" runat="server" CssClass="Text" ToolTip="STATE" PlaceHolder="STATE" AutoCompleteType="Disabled" ReadOnly="True" Enabled="False"></asp:TextBox></div>
            <div class="div_break"></div>
           <%-- <div class="plan_labels"><asp:Label ID="lbl_Country" runat="server" Text="Country" CssClass="LabelValue"></asp:Label></div>--%>
            <div class="plan_textboxes"><asp:TextBox ID="txt_Country" runat="server"  CssClass="Text" ToolTip="COUNTRY" PlaceHolder="COUNTRY" AutoCompleteType="Disabled" ReadOnly="True" Enabled="False"></asp:TextBox></div>
         <%--   <div class="lbl_pincode"><asp:Label ID="lbl_pincode" runat="server" Text="Pincode" CssClass="LabelValue"></asp:Label></div>--%>
            <div class="txt_pincode"><asp:TextBox ID="txt_pincode" runat="server" CssClass="Text" ToolTip="PINCODE" PlaceHolder="PINCODE" AutoPostBack="True" onKeyUp="CheckTextLength(this,6)"  
                    onkeypress="return isNumberKey(event,'pincode');" 
                    ontextchanged="txt_pincode_TextChanged" TabIndex="3"></asp:TextBox></div>
           
            <div class="div_break"></div>
             <div><hr style=" margin-top :1%;"/></div>
         <div class="div_Button">
            <asp:Button ID="btnsave" runat="server" Text="Save"  CssClass="myButton" 
                  onclick="btnsave_Click" TabIndex="4" />
            <asp:Button ID="btnview" runat="server" Text="View" CssClass="myButton"  
                 onclick="btnview_Click1" TabIndex="5"  />
            <asp:Button ID="btndelete" runat="server" Text="Delete" CssClass="myButton"  OnClientClick ="return confirm('Are you sure you want to delete this Location?')" onclick="btndelete_Click" TabIndex="6"/>
            <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="myButton" 
                onclick="btncancel_Click" TabIndex="7" />
            </div>
               

            <div class="div_break"></div>
         <div><hr/></div>
          <br />
              <div class="div_Grid"> 

            
<asp:GridView ID="grdlocation"  ShowHeaderWhenEmpty ="True" runat="server" AutoGenerateColumns="False"  Width="100%" ForeColor="Black"  EmptyDataText="No Record Found" AllowPaging="false"  CssClass ="GrdRow" OnPageIndexChanging="grdstate_PageIndexChanging">
    <Columns>
    <asp:BoundField DataField="sno" HeaderText="S#" ItemStyle-Height="10px">
    <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="22px"/>
    <ItemStyle HorizontalAlign="Right" Width="18px"/>
    </asp:BoundField>
    <asp:BoundField DataField="Locationname" HeaderText="Location">
    <HeaderStyle HorizontalAlign="Left" Wrap="true" Width="170px"/>
    <ItemStyle/>
    </asp:BoundField>
    <asp:BoundField DataField="portname" HeaderText="City">
    <HeaderStyle HorizontalAlign="Left" Wrap="true" Width="100px"/>
    <ItemStyle/>
    </asp:BoundField>
    
     <asp:BoundField DataField="districtname" HeaderText="District">
      <HeaderStyle HorizontalAlign="Left" Wrap="true" Width="103px"/>
      <ItemStyle/>
     </asp:BoundField>
    
     <asp:BoundField DataField="statename" HeaderText="State">
     <HeaderStyle HorizontalAlign="Left" Wrap="true" Width="118px"/>
     <ItemStyle/>
     </asp:BoundField>
    
        <asp:BoundField DataField="pincode" HeaderText="PinCode" >
        <HeaderStyle Width="60px" />
        <ItemStyle HorizontalAlign="Right" Width="60px"/>
        </asp:BoundField>
    </Columns>
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
    <HeaderStyle CssClass="GridHeader_my"/>
    <AlternatingRowStyle CssClass="GrdAltRow"/>

    </asp:GridView></div>
            <div class="div_break"></div>
            <div class="div_break"></div>
    
    <div class="div_DRopdown_btn" id="dropdown_box" runat ="server" visible ="false" >
    <dl id="sample" class="dropdown">
        <dt ><a href="#"><span class="span_excel_txt">Export To</span></a></dt>
        <dd>
            <ul>
              <%--  <li ><a href="#" runat="server" id="excel" class="spn_txt_first">Excel</a></li>
                <li><a  href="#" runat="server" id="pdf">PDF</a></li>--%>

           <li><asp:LinkButton ID="LinkButton1" runat="server" OnClick="fnExportGridToPDF_Click">Excel</asp:LinkButton></li>
           <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="fnExportToExcel_Click">PDF</asp:LinkButton></li>

            
            </ul>
        </dd>
    </dl>  
            </div>

                <div class="div_break"></div>
            <div class="div_break"></div>

    </asp:panel>
        
   
    </div>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btncancel"/>
           
            
      
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
