<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master"  AutoEventWireup="true"  EnableEventValidation="false" CodeBehind="MasterState.aspx.cs" Inherits="logix.Maintenance.MasterState" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/MasterState.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="stylesheet" type="text/css" />
     <link href="../Styles/button1.css" rel="stylesheet" type="text/css" />
    
     <script type="text/javascript">

         function pageLoad(sender, args) {
             $(document).ready(function () {
                 $("#<%=txtcountry.ClientID %>").autocomplete({
                     source: function (request, response) {
                         $.ajax({
                             url: "MasterState.aspx/GetCountry",
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
                         $("#<%=hdn_countryid.ClientID %>").val(i.item.val);
                     },
                     focus: function (event, i) {
                         $("#<%=txtcountry.ClientID %>").val(i.item.label);
                         $("#<%=hdn_countryid.ClientID %>").val(i.item.val);
                     },
                     close: function (event, i) {
                         $("#<%=txtcountry.ClientID %>").val(i.item.label);
                         $("#<%=hdn_countryid.ClientID %>").val(i.item.val);
                     },
                     minLength: 1
                 });
             });


             $(document).ready(function () {
                 $("#<%=txtstate.ClientID %>").autocomplete({
                     source: function (request, response) {
                         $.ajax({
                             url: "MasterState.aspx/GetStates",
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
                         $("#<%=txtstate.ClientID %>").val(i.item.label);
                         $("#<%=txtstate.ClientID %>").change();
                         $("#<%=hdn_stateid.ClientID %>").val(i.item.val);
                     },
                     focus: function (event, i) {
                         $("#<%=txtstate.ClientID %>").val(i.item.label);
                         $("#<%=hdn_stateid.ClientID %>").val(i.item.val);
                     },
                     close: function (event, i) {
                         $("#<%=txtstate.ClientID %>").val(i.item.label);
                         $("#<%=hdn_stateid.ClientID %>").val(i.item.val);
                     },
                     minLength: 1
                 });
             });

             /***********************************/

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
           // alertify.alert("Hello Bhuvana");
              __doPostBack("txtstate", "TextChanged");
            
          }
       </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

 <asp:UpdatePanel ID="updatePanelListboxes" runat="server" UpdateMode="Conditional">
  <ContentTemplate>

            <asp:HiddenField ID="hdn_countryid" runat="server" />
            <asp:HiddenField ID="hdn_stateid" runat="server" />
            <asp:HiddenField ID="hdn_countryid_one" runat="server" />
    <asp:Panel ID="Panel1" runat="server" class="div_total">
           <%-- <div class="div_total">--%>
            <div class="div_Main"><asp:Label ID="lbl_Header" runat="server" Text="State" CssClass="lbl_Header"></asp:Label></div>
           <%-- <div  class="div_label"><asp:Label ID="lblstate" runat="server" Text="State" CssClass="LabelValue"></asp:Label></div>--%>
            <div class="div_TB"><asp:TextBox ID="txtstate" runat="server" Cssclass="Text" ToolTip="STATE" PlaceHolder="STATE"  AutoPostBack ="True" ontextchanged="txtstate_TextChanged" onKeyUp="CheckTextLength(this,30)" TabIndex="1"></asp:TextBox></div>
            <div class="div_Break"> </div>
            <%--<div class="div_label"> <asp:Label ID="lblcountry" runat="server" Text="Country" CssClass="LabelValue"></asp:Label></div>--%>
            <div class="div_TB"><asp:TextBox ID="txtcountry" runat="server" Cssclass="Text" ToolTip="COUNTRY" PlaceHolder="COUNTRY"  AutoPostBack="True" ontextchanged="txtcountry_TextChanged"  TabIndex="2"></asp:TextBox> </div>
            <div class="div_Break"> </div>
            <div><hr style=" margin-top :1%;"/></div>
            <div class="div_Button"> 
            <asp:Button ID="btnsave" runat="server" Text="Save"  CssClass="myButton" 
                    onclick="btnsave_Click" TabIndex="3" />
            <asp:Button ID="btnview" runat="server" Text="View" CssClass="myButton" 
                    onclick="btnview_Click" TabIndex="4" />
            <asp:Button ID="btndelete" runat="server" Text="Delete" CssClass="myButton"  
                     onclick="btndelete_Click" TabIndex="5"/>
            <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="myButton" 
                     onclick="btncancel_Click" TabIndex="6"/>
            </div>
            <div class="div_Break"> </div>
            <div><hr style=" margin-top :1%;"/></div>
        <br />
            <div class="div_Grid"> 

            
<asp:GridView ID="grdstate"  ShowHeaderWhenEmpty ="True" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black"  EmptyDataText="No Record Found" AllowPaging="false" PageSize="10"  OnPageIndexChanging="grdstate_PageIndexChanging" CssClass ="GrdRow">
    <Columns>
    <asp:BoundField DataField="sno" HeaderText="S#" ItemStyle-Width="10px">
    <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="45px"/>
    <ItemStyle HorizontalAlign="Justify" Width="30px" Wrap="false"/>
    </asp:BoundField>
    <asp:BoundField DataField="countryname" HeaderText="Country">
    <HeaderStyle HorizontalAlign="Justify" Wrap="true" Width="210px"/>
    <ItemStyle Width="160px" Wrap="false"/>
    </asp:BoundField>
        <asp:BoundField DataField="statename" HeaderText="State" >
        <HeaderStyle Width="260px" />
            <ItemStyle Width="160px" Wrap="false"/>
        </asp:BoundField>
    </Columns>
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
    <HeaderStyle CssClass="GridHeader_my"/>
    <AlternatingRowStyle CssClass="GrdAltRow"/>

    </asp:GridView></div>
    <div class="div_break"></div>
            <div class="div_DRopdown_btn" id="dropdown_box" runat ="server" visible ="false" >
    <dl id="sample" class="dropdown">
        <dt ><a href="#"><span class="span_excel_txt">Export To</span></a></dt>
        <dd>
            <ul>
           
           <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="fnExportToExcel_Click">Excel</asp:LinkButton></li>
            <li><asp:LinkButton ID="LinkButton1" runat="server" OnClick="fnExportGridToPDF_Click">PDF</asp:LinkButton></li>

            
          
            </ul>
        </dd>
    </dl>  
            </div>
            <div class="div_Break"></div>
   
        </asp:Panel>
      

           </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btncancel"/>
            <asp:PostBackTrigger ControlID="btnsave"/>
      
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
