<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MasterCharge.aspx.cs" Inherits="logix.Maintenance.MasterCharge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/ControlStyle2.css" rel="Stylesheet" type="text/css" />

    <link href="../Styles/MasterCharge.css" rel="Stylesheet" type ="text/css"/>
    <link href="../Styles/DropDownButton.css" rel="stylesheet" type="text/css"/>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
               <link href="../Styles/button1.css" rel="stylesheet" type="text/css" />
       <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
        <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
        <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
     <link href="../Styles/chosen.css" rel="stylesheet" />
<script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>
       <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
 <script type="text/javascript">
     function pageLoad(sender, args) {

         $(document).ready(function () {
             $('#<%=grd.ClientID%>').gridviewScroll({
                 width: 589,
                 height:220,
                   arrowsize: 30,

                   varrowtopimg: "../images/arrowvt.png",
                   varrowbottomimg: "../images/arrowvb.png",
                   harrowleftimg: "../images/arrowhl.png",
                   harrowrightimg: "../images/arrowhr.png"
               });
         });

         $(document).ready(function () {
             $("#<%=txtcharge.ClientID %>").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         url: "MasterCharge.aspx/GetChargename",
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
                     $("#<%=hdn_chargeid.ClientID %>").val(i.item.val);
                 },
                 focus: function (event, i) {
                     $("#<%=txtcharge.ClientID %>").val(i.item.label);
                     $("#<%=hdn_chargeid.ClientID %>").val(i.item.val);
                 },
                 close: function (event, i) {
                     $("#<%=txtcharge.ClientID %>").val(i.item.label);
                     $("#<%=hdn_chargeid.ClientID %>").val(i.item.val);
                 },
                 minLength: 1
             });
         });

         $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

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
         __doPostBack("txtcharge", "TextChanged");
     }


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
 
 



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
  <asp:UpdatePanel ID="updatePanelListboxes" runat="server" UpdateMode="Conditional">
  <ContentTemplate>

    <asp:HiddenField ID="hdn_chargeid" runat="server" />
    <asp:HiddenField ID="hfWasConfirmed" runat="server" />


  <asp:panel ID="Panel1" runat="server" class="panel_style">
           <div class="Header">  <asp:Label ID="lbl_Header" runat="server" Text="Charges"  CssClass="lbl_Header"></asp:Label> </div> 
            <div class="ddl_charge"><asp:DropDownList ID="ddl_chargetype" data-placeholder="Charge Type" ToolTip="Charge Type" runat="server" CssClass ="chzn-select">
                <asp:ListItem text="" Value="0"></asp:ListItem>                
           </asp:DropDownList> </div>
            <div class="charge_textboxes"><asp:TextBox ID="txtcharge" runat="server"  CssClass="Text" ToolTip="Charge" PlaceHolder="Charge" AutoPostBack="True" TabIndex="1" ontextchanged="txtcharge_TextChanged1" BorderColor="#999997" onKeyUp="CheckTextLength(this,100)"></asp:TextBox></div> 
            <div class="div_break"></div>
            
            <div class="ddl_service"> <asp:DropDownList ID="ddl_service" runat="server"  TabIndex="2" ToolTip="Service"  Data-PlaceHolder="Service"  AutoPostBack="True"  CssClass ="chzn-select" OnSelectedIndexChanged="ddl_service_SelectedIndexChanged">
                  <asp:ListItem Text="" Value="0"></asp:ListItem>
                                      </asp:DropDownList></div> 
            <div class="txt_st"><asp:TextBox ID="txtPercent" runat="server"  CssClass="Text" BorderColor="#999997" ToolTip="ST %" PlaceHolder="ST %"  onkeypress="return validateFloatKeyPress( this, event,'ST %');" TabIndex="3"   onKeyUp="CheckTextLength(this,10)" AutoPostBack="True"  ontextchanged="txtPercent_TextChanged" ></asp:TextBox></div> 
            <div class="div_break"></div>
            <div class="txt_cess"> <asp:TextBox ID="txtEduPer" runat="server" CssClass="Text" BorderColor="#999997" ToolTip="Edu.Cess%" PlaceHolder="Edu.Cess%"   onkeypress="return validateFloatKeyPress(this, event,'Edu Cess %');" TabIndex="4"   onKeyUp="CheckTextLength(this,10)"   AutoPostBack="True" ontextchanged="txtEduPer_TextChanged"></asp:TextBox></div> 
            <div class="txt_st_hr"><asp:TextBox ID="txtHighEduPer" runat="server" CssClass="Text" BorderColor="#999997" ToolTip="Hr Edu.Cess%" PlaceHolder="Hr Edu.Cess%"  onkeypress="return validateFloatKeyPress(this, event,'Hr Edu Cess %');"  TabIndex="5" onKeyUp="CheckTextLength(this,10)" AutoPostBack="True" ontextchanged="txtHighEduPer_TextChanged"></asp:TextBox></div> 
            <div class="div_break"></div>

             <div><hr style=" margin-top :1%;"/></div>
         <div class="div_Button">
            <asp:Button ID="btnsave" runat="server" Text="Save"  CssClass="Button" ToolTip="Save" TabIndex="6" onclick="btnsave_Click1" />
            <asp:Button ID="btnview" runat="server" Text="View" CssClass="Button" ToolTip="View"  TabIndex="7" onclick="btnview_Click"  />
            <asp:Button ID="btndelete" runat="server" Text="Delete" CssClass="Button" ToolTip="Delete" TabIndex="8" OnClientClick ="return confirm('Are you sure you want to delete this charge?')"  onclick="btndelete_Click" />
            <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="Button" ToolTip="Cancel"  TabIndex="9" onclick="btncancel_Click" />
            </div>
               

            <div class="div_break"></div>
         <div><hr/></div>
      <br />
        <%-- <div class="charge_textboxes1"><asp:TextBox ID="txtsearch" runat="server"  CssClass="Text" ToolTip="Search" PlaceHolder="Search" AutoPostBack="True" TabIndex="1" BorderColor="#999997" onKeyUp="CheckTextLength(this,100)" OnTextChanged="txtsearch_TextChanged"></asp:TextBox></div> 
       <div class="div_break"></div>--%>
              <div class="div_Grid">     
<asp:GridView ID="grd"  ShowHeaderWhenEmpty ="True" runat="server" AutoGenerateColumns="False" 
        Width="100%" ForeColor="Black"  CssClass ="GrdRow" OnPageIndexChanging="grdstate_PageIndexChanging">
    <Columns>
      <asp:BoundField DataField="sno" HeaderText="S#">
         <%--<ControlStyle Width="10px" />--%>
          <HeaderStyle HorizontalAlign="Center" />
          <ItemStyle Font-Bold="false" HorizontalAlign="Right"   />          
     </asp:BoundField>
        <asp:BoundField DataField="chargename" HeaderText="Charges">
        
           </asp:BoundField>
    <asp:BoundField DataField="percentage" HeaderText="ST %">
    <HeaderStyle HorizontalAlign="Center"/>
    <ItemStyle HorizontalAlign="Right" />
    </asp:BoundField>
        <asp:BoundField DataField="edcess" HeaderText="Edu. cess %" >
        <HeaderStyle HorizontalAlign="Center"  />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="hedcess" HeaderText="Hr Educess %" >
        <HeaderStyle HorizontalAlign="Center"  />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
    </Columns>
               
	<AlternatingRowStyle CssClass="GrdRowStyle" /> 
                <HeaderStyle CssClass="GridviewScrollHeader" /> 
            <RowStyle CssClass="GridviewScrollItem" /> 
            <PagerStyle CssClass="GridviewScrollPager" />
    
    </asp:GridView></div>

      <br />
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
     <div class="div_break"></div>
      <div class="div_break"></div>
        <div class="div_break"></div>
      <div class="div_break"></div>
    </asp:panel>
        
         </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btncancel"/>
            <asp:PostBackTrigger ControlID="btnsave"/>
      
        </Triggers>
    </asp:UpdatePanel>



</asp:Content>
