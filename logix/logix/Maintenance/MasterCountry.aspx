<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation="false"  AutoEventWireup="true" CodeBehind="MasterCountry.aspx.cs" Inherits="logix.Maintenance.MasterCountry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Country.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css"/>
    <link href="../Styles/ControlStyle2.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/DropDownButton.css" rel="stylesheet" type="text/css" />
               <link href="../Styles/button1.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/Validation.js" type="text/javascript"></script>
  <%--  <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>--%>
    <%--<script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>--%>
     
    <script type="text/javascript">
         function pageLoad(sender, args) {
             $(document).ready(function () {
                 $("#<%=txt_Country.ClientID %>").autocomplete({
                     source: function (request, response) {
                         $.ajax({
                             url: "MasterCountry.aspx/GetCountry",
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
                         $("#<%=txt_Country.ClientID %>").val(i.item.label);
                         $("#<%=txt_Country.ClientID %>").change();
                     },
                     focus: function (event, i) {
                         $("#<%=txt_Country.ClientID %>").val(i.item.label);
                         $("#<%=hdncountry_id.ClientID %>").val(i.item.val);
                     },
                     close: function (event, i) {
                         $("#<%=txt_Country.ClientID %>").val(i.item.label);
                         $("#<%=hdncountry_id.ClientID %>").val(i.item.val);
                     },
                     minLength: 1
                 });
             });



        $(document).ready(function () {
                 $("#<%=TextBox_Sector.ClientID %>").autocomplete({
                     source: function (request, response) {
                         $.ajax({
                             url: "MasterCountry.aspx/GetSector",
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
                         $("#<%=TextBox_Sector.ClientID %>").val(i.item.label);
                         $("#<%=TextBox_Sector.ClientID %>").change();
                     },
                     focus: function (event, i) {
                         $("#<%=TextBox_Sector.ClientID %>").val(i.item.label);
                         $("#<%=hdf_sectorid.ClientID %>").val(i.item.val);
                     },
                     close: function (event, i) {
                         $("#<%=TextBox_Sector.ClientID %>").val(i.item.label);
                         $("#<%=hdf_sectorid.ClientID %>").val(i.item.val);
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
                 $(".dropdown img.flag").toggleClass("flag visibility");
             });
         }
        </script>     
          <script type="text/javascript">
              function ShowpImagePreview(input) {
                  if (input.files && input.files[0]) {
                      var reader = new FileReader();
                      reader.onload = function (e) {
                          // $('#img_flag').attr('src', e.target.result);
                          $('#<%= img_flag.ClientID %>').attr('src', e.target.result);
                      }
                      reader.readAsDataURL(input.files[0]);
                  }
              }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <asp:HiddenField ID="hdf_sectorid" runat="server" />
    <asp:HiddenField ID="hdncountry_id" runat="server" />
    <asp:HiddenField ID="hdn_flag" runat="server" />
    <div class="div_total">
   
  
 
    <div class="div_Main"><asp:Label ID="lbl_Header" runat="server" Text="Country" CssClass="lbl_Header"></asp:Label> </div> 
    <div class="div_Break"> </div>  
          <div style="width:74%; float:left; margin-top:0.5%; height:100%;">
    <%--<div class="div_label"> <asp:Label ID="lbl_Country" runat="server" Text="Country" CssClass="LabelValue"> </asp:Label> </div>--%>
    <div class="div_TB"> <asp:TextBox ID="txt_Country" runat="server" CssClass="Text" onkeyup="CheckTextLength(this,50);" onkeypress="return ValidateAlpha (event,'Country');" TabIndex="1" AutoPostBack="true" ontextchanged="txt_Country_TextChanged" placeholder="Country" ToolTip="Country"> </asp:TextBox></div> 
    <div class="div_Break"> </div>    
   

    <%--<div class="div_label">  <asp:Label ID="Label_Currency" runat="server" Text="Currency"  CssClass="LabelValue"></asp:Label></div>--%>
    <div class="div_txtcurrency"><asp:TextBox ID="TextBox_currency" runat="server"  CssClass="Text" AutoPostBack="true"  onkeyup="CheckTextLength(this,10);" onkeypress="return ValidateAlpha (event,'Currency');" TabIndex="2" placeholder="Currency" ToolTip="Currency"></asp:TextBox></div> 
    
    <%--<div class="div_cents"> <asp:Label ID="Label_Cents" runat="server" Text="Cents" CssClass="LabelValue"></asp:Label></div>--%>
    <div class="div_txtcurrency1"><asp:TextBox ID="TextBox_cents" runat="server" TabIndex="3" onkeyup="CheckTextLength(this,5);" onkeypress="return isAlplaNumeric(event,'Cents');" CssClass="Text"  placeholder="Cents" ToolTip="Cents"></asp:TextBox></div> 
        
   <%-- </div div_lblCents   div_leftlabel >--%>
   
   
   <%--<div class="div_leftlabel"> <asp:Label ID="Label_ISD" runat="server" Text="ISDCode" CssClass="LabelValue"></asp:Label></div>--%>
    <div class="div_lefttxtbx">
        <asp:TextBox ID="TextBox_ISD" runat="server" CssClass="Text" onkeypress="return isNumberKey(event,'ISD');" TabIndex="4"  placeholder="ISD Code" ToolTip="ISD Code" ></asp:TextBox></div> 
   
       <div class="div_Break"> </div> 
    <%--<div class="div_mrcode"> <asp:Label ID="Label_Mrcode" runat="server" Text="MRCode" CssClass="LabelValue"></asp:Label></div>--%>
    <div class="div_mrtextbox">
        <asp:TextBox ID="TextBox_MRcode" runat="server" onkeyup="CheckTextLength(this,2);" CssClass="Text" TabIndex="5"  AutoPostBack="true" MaxLength="1" placeholder="MR Code" ToolTip="MR Code"></asp:TextBox></div>
      
    
    
          
    <%--<div class="div_cents">  <asp:Label ID="lbl_Sector" runat="server" Text="Sector" CssClass="LabelValue"></asp:Label></div>--%>
    <div class="div_TBSector">
        <asp:TextBox ID="TextBox_Sector" runat="server" CssClass="Text"
             onkeyup="CheckTextLength(this,30);" 
            onkeypress="return ValidateAlpha (event,'Sector');" TabIndex="6" 
            AutoPostBack="true" ontextchanged="TextBox_Sector_TextChanged" placeholder="Sector" ToolTip="Sector"></asp:TextBox></div>
            </div>

           <div style="width:25%; float:left; margin-top:0.5%;  margin-left:0.1%;">          
     <div class="div_imgnew"> <asp:Image ID="img_flag" runat="server" Height="73px" Width="97.5%"/></div>     
               </div>
                 <div class="fileUpload">
    <span style =" margin-top :5%; display :block;">Choose flag</span>
      <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="7" class="upload" onchange="ShowpImagePreview(this);" /></div>

   <%--<div class="div_logobut"> --%>         
    <%-- <div class="fileUpload">
    <span style ="margin-left :25%; margin-top :3%; display :block; color:darkBlue; text-decoration :none;">Choose Flag</span>
      <asp:FileUpload ID="FileUpload1" runat="server" Class="upload" onchange="ShowpImagePreview(this);" /></div>      
   --%>  <%--  </div>     --%>     


<%--<div class="div_Break"> </div>
<div> <hr/> </div>
        <div class="div_Button">
<asp:Button ID="Button1" runat="server" Text="Save" CssClass="fileUpload" />
            </div>--%>
      
<div class="div_Break"> </div>
<div> <hr/> </div>

    <div class="div_Button">
          <asp:Button ID="Button_save" runat="server" Text="Save" CssClass="myButton" 
              onclick="Button_save_Click" Enabled="False" TabIndex="8"/> 
               
              <asp:Button ID="Button_view" runat="server" Text="View" CssClass="myButton" 
              onclick="Button_view_Click" TabIndex="9"/>   
              
                          
          <asp:Button ID="Button_delete" runat="server" Text="Delete" CssClass="myButton" 
              TabIndex="10"/>
           
             
          <asp:Button ID="Button_cancel" runat="server" Text="Back" CssClass="myButton" 
              onclick="Button_cancel_Click" TabIndex="11"/> 
            
             
            
    </div>  
<div class="div_Break"></div>
<div> <hr/> </div>
        <br />
    <div class="grid_align" id="grid">
            <asp:GridView ID="GridCountry" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="Countryid" Width="100%" 
                EmptyDataText="No Records Found" AllowPaging="false" PageSize="10" 
                onpageindexchanging="GridCountry_PageIndexChanging"  >
            
    <Columns>
        <asp:BoundField DataField="sno" HeaderText="S#" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10px">
            <HeaderStyle Width ="25px" Wrap="true"/>
            <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="35px" Wrap="false"/>
        </asp:BoundField>
                
        <asp:BoundField DataField="CountryName" HeaderText="CountryName" HeaderStyle-Height="10%">
          <HeaderStyle Width ="185px" Wrap="true"/>
           <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="250px" Wrap="false"/>
         </asp:BoundField>
                
       <asp:BoundField DataField="Currency" HeaderText="Currency" HeaderStyle-Height="10%">
              <HeaderStyle Width ="50px" Wrap="true"/>
              <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="120px" Wrap="false"/>
        </asp:BoundField>
                
       <asp:BoundField DataField="Cents" HeaderText="Cents" HeaderStyle-Height="10%">
              <HeaderStyle Width ="45px" Wrap="true"/>
              <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="100px" Wrap="false"/>
        </asp:BoundField>
                
       <asp:BoundField DataField="sectorname" HeaderText=" Sector" HeaderStyle-Height="10%">
            <HeaderStyle Width ="190px" Wrap="true"/>
            <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="250px" Wrap="false" />
        </asp:BoundField>
                
   </Columns>
             <EmptyDataRowStyle CssClass="EmptyRowStyle" />
             <HeaderStyle CssClass="GridHeader_my"/>
             <AlternatingRowStyle CssClass="GrdAltRow"/>
              <RowStyle CssClass="GrdRow" />         
            </asp:GridView>               
  
   </div> 


   <div class="div_Break"></div>
 <div runat="server" id="signup" Visible="false" class="dldesign">
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
    
</asp:Content>

