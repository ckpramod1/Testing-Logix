<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="MasterCustomerContact.aspx.cs" Inherits="logix.Maintenance.MasterCustomerContact"  enableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />--%>
    <!-- Bootstrap -->
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <link href="../Styles/slotRateMaster.css" rel="stylesheet" />
    <link href="../Theme/assets/css/systemhomedesign.css" rel="stylesheet" />
    <link href="../Styles/MRG.css" rel="stylesheet" />
    <link href="../Theme/assets/css/systemhomedesign.css" rel="stylesheet" />
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
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../Theme/Content/assets/js/canvasjs.min.js"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <link href="../Styles/button1.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/ContainerTracking.css" rel="stylesheet" />
    <script src="../js/helper.js" type="text/javascript"></script>
    <script src="../js/TextField.js" type="text/javascript"></script>
    <%--TEST--%>
    <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../Theme/assets/css/jquery-ui.css" rel="stylesheet" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" />

    <%--     <script type="text/javascript">
         function dropdownButton() {
             $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
         }

    </script>--%>


     <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>
    <%--   <script type="text/javascript">
         $(function () {
             $("Grd_MAsterCredit. > tbody > tr:not(:has(table, th))")
                 .css("cursor", "pointer")
                 .click(function (e) {
                     $(".Grd_MAsterCredit td").removeClass("highlite");
                     var $cell = $(e.target).closest("td");
                     $cell.addClass('highlite');
                     var $currentCellText = $cell.text();
                     var $leftCellText = $cell.prev().text();
                     var $rightCellText = $cell.next().text();
                     var $colIndex = $cell.parent().children().index($cell);
                     var $colName = $cell.closest("table")
                         .find('th:eq(' + $colIndex + ')').text();
                     $("#para").empty()
                     .append("<b>Current Cell Text: </b>"
                         + $currentCellText + "<br/>")
                     .append("<b>Text to Left of Clicked Cell: </b>"
                         + $leftCellText + "<br/>")
                     .append("<b>Text to Right of Clicked Cell: </b>"
                         + $rightCellText + "<br/>")
                     .append("<b>Column Name of Clicked Cell: </b>"
                         + $colName)
                 });
         });

    </script>--%>
    <style>
        input[type="file"] {
    height: 36px;
    padding: 8px;
}
        .name_inputs {
    float: left;
    width: 100%;
}
        div#logix_CPH_ddlposition_chzn {
    width: 100%;
}
        .ddlposition {
    width: 42%;
}
        div#logix_CPH_ddlTitle_chzn {
    width: 100%;
}
        .ddl_title_input {
    width: 35%;
}.title{
     width:5%;
     float:left;
     margin:0 0.5% 0 0;
 }
 .Department{
   width:12%;
     float:left;
     margin:0 0.5% 0 0.5%;
 }
 div#logix_CPH_UpdatePanel1 {
    margin: 10px 0 0;
}
 .right_btn {
    display: flex;
}
 .Gridpnl {
    width: 99% !important;
    height: auto;
    border: 1px solid var(--lightgrey) !important;
    margin: 0 auto !important;
    /* overflow-y: scroll !important; */
    overflow-x: auto !important;
}
 .panel_19 {
    margin: 5px 5px 0 5px !important;
    width: 99%;
}
 .CardLbl {
    padding: 5px 0 0 5px;
    margin: 0px 0.5% 0px 0px;
}
 div#logix_CPH_plblan {
    margin: 0px 0px 0px 7px;
}
       span.headingName {
    font-weight: bold !important;
}
       .CustomerName12 {
    padding: 0 0.5% 0 5px;
    float: left;
}
       span#logix_CPH_Label46 {
    font-weight: bold !important;
}
       span#logix_CPH_Label46 {
    font-size: 20px !important;
}
       .PageHeight{
           padding-top:0px !important;
       }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


    <div class="FormGroupContent4 ">
        <div class="CardLbl">
            <asp:Label ID="Label46" runat="server">Contact Details </asp:Label>
            <%--<asp:Label ID="card" runat="server"></asp:Label>--%>
        </div>
        <div class="CustomerName12">
            <span class="headingName">CUSTOMER NAME</span>
            <asp:Label ID="lblcustomername" runat="server"> </asp:Label>
        </div>
        <div  class="panno12" id="plblan" runat="server">
            <span class="headingName">PAN#   :</span>
            <asp:Label ID="lblpanno" runat="server"></asp:Label>
        </div>
    </div>

    <div class="bordertopNew" style=" float: right;min-height: 1px;width: 100%;box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;" ></div>
    <div class="FormGroupContent4 custom-d-flex">


         <div class="title">
     <asp:Label ID="Label37" runat="server" CssClass="hide" Text="Title"> </asp:Label>

         <asp:DropDownList ID="ddlTitle" runat="server" data-placeholder="Title" TabIndex="30" Width="100%" CssClass="chzn-select form-control">
             <asp:ListItem>Mr</asp:ListItem>
             <asp:ListItem>Ms</asp:ListItem>
             <asp:ListItem>Mrs</asp:ListItem>
         </asp:DropDownList>

 </div>
        
        <div class="Name custom-col custom-mr-05">
            <asp:Label ID="Label32" runat="server" CssClass="hide" Text="Name"> </asp:Label>
    
                <asp:TextBox ID="txtName" placeholder="Name" ToolTip="Name" runat="server" TabIndex="31" CssClass="form-control"></asp:TextBox>
    
        </div>


        <div class="Department">
            <asp:Label ID="Label45" runat="server" CssClass="hide" Text="Department"> </asp:Label>

      
                <asp:DropDownList ID="ddlposition" data-placeholder="Department" runat="server" TabIndex="29" Width="100%" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlposition_SelectedIndexChanged">
                    <asp:ListItem Value="">Department</asp:ListItem>
                    <asp:ListItem Value="MH">MANAGEMENT</asp:ListItem>
                    <asp:ListItem Value="CH">COMMERCIAL</asp:ListItem>
                    <asp:ListItem Value="EH">EXPORT</asp:ListItem>
                    <asp:ListItem Value="IH">IMPORT</asp:ListItem>
                    <asp:ListItem Value="FH">FINANCE</asp:ListItem>
                </asp:DropDownList>
           
        </div>



         <div class="FieldInput">
     <asp:DropDownList ID="ddl_designation" ToolTip="DESIGNATION"  CssClass="chzn-select" data-placeholder="Designation" Width="100%" runat="server" >
         <asp:ListItem Value="0" Text="Designation"></asp:ListItem>
     </asp:DropDownList>
 </div>


                 <div class=" custom-col custom-mr-05">
    <asp:TextBox ID="txt_Phone" placeholder="PhoneNo" ToolTip="PhoneNo" runat="server" TabIndex="31" CssClass="form-control"></asp:TextBox>
</div>



          <div class=" custom-col custom-mr-05">
            <asp:TextBox ID="txt_email" placeholder="Email" ToolTip="Email" runat="server" TabIndex="31" CssClass="form-control"></asp:TextBox>
        </div>




    


        <div class=" custom-col  custom-mr-05 custom-mt-05">
            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
                <ContentTemplate>
                    <span style="display: block; color: #fff; background-color: #5ba701; color: black; width: 121px; font-size: 11px; padding: 0px 0px 0px 0px;"></span>
                    <asp:FileUpload ID="FileUpd_logo5" CssClass="bt" runat="server" onchange="ShowpImagePreview(this);" ToolTip="Upload Business Card" />
                    <div class="div_btn">
                        <asp:Button ID="Button6" runat="server" Text="Upload" Width="100%" CssClass="Button" Visible="false" />
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btn_Upload" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div class="right_btn custom-mt-3">
            <div class="btn ico-add">
                <asp:Button ID="btn_Upload" runat="server" ToolTip="Add" TabIndex="32" OnClick="btn_Upload_Click" />
            </div>
            <div class="btn-cancel" >
                <asp:Button ID="btn_Cancel" runat="server" ToolTip="Cancel" OnClick="btn_Cancel_Click" TabIndex="33" />
            </div>

        </div>
    </div>

    <div class="FormGroupContent4 hide">
        <asp:Label ID="lbl_email" runat="server" CssClass="hide" Text="Email"> </asp:Label>      

    </div>


    <div class="FormGroupContent4">
        <div class="panel_19 MB0">
            
            <asp:GridView ID="grdBusinesscard" runat="server" Width="100%" ShowHeaderWhenEmpty="True" CssClass="Grid FixedHeader"
                OnRowDataBound="grdBusinesscard_RowDataBound" OnSelectedIndexChanged="grdBusinesscard_SelectedIndexChanged"
              OnRowDeleting="grdBusinesscard_RowDeleting" AutoGenerateColumns="false" OnPreRender="grdBusinesscard_PreRender" OnRowCommand="grdBusinesscard_RowCommand">

<%--            <asp:GridView ID="grdBusinesscard" runat="server" Width="100%" ShowHeaderWhenEmpty="True" CssClass="Grid FixedHeader" AutoGenerateColumns="false"
                OnRowDataBound="grdBusinesscard_RowDataBound" OnSelectedIndexChanged="grdBusinesscard_SelectedIndexChanged" EmptyDataText="No Record Found"
                OnRowCommand="grdBusinesscard_RowCommand" OnRowDeleting="grdBusinesscard_RowDeleting" OnPreRender="grdBusinesscard_PreRender">--%>
                <Columns>
                    <asp:BoundField DataField="MCUploadinfo" HeaderText="MCUploadinfo" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                        <HeaderStyle Wrap="false" />
                        <ItemStyle Wrap="false" />
                    </asp:BoundField>
                    <%-- 0 --%>
                    <asp:BoundField DataField="CustomerId" HeaderText="CustomerId" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                        <HeaderStyle Wrap="false" />
                        <ItemStyle Wrap="false" />
                    </asp:BoundField>
                    <%-- 1 --%>

                    
                     <asp:BoundField DataField="Title" HeaderText="TITLE">
     <HeaderStyle Wrap="false" />
     <ItemStyle Wrap="false" />
 </asp:BoundField>

                     <asp:BoundField DataField="Name" HeaderText="NAME">
     <HeaderStyle Wrap="false" />
     <ItemStyle Wrap="false" />
 </asp:BoundField>


                    <asp:BoundField DataField="Role" HeaderText="DEPARTMENT">
                        <HeaderStyle Wrap="false" />
                        <ItemStyle Wrap="false" />
                    </asp:BoundField>



                       <asp:BoundField DataField="designame" HeaderText="DESIGNATION">
       <HeaderStyle Wrap="false" />
       <ItemStyle Wrap="false" />
   </asp:BoundField>



                       <asp:BoundField DataField="PhoneNo" HeaderText="PhoneNo">
       <HeaderStyle Wrap="false" />
       <ItemStyle Wrap="false" />
   </asp:BoundField>


                    <%-- 2 --%>
                   
                    <asp:BoundField DataField="email" HeaderText="E-mail">
                        <HeaderStyle Wrap="false" />
                        <ItemStyle Wrap="false" />
                    </asp:BoundField>
                    <%-- 3 --%>
                    <asp:BoundField DataField="CardFileName" HeaderText="BUSINESSCARD">
                        <HeaderStyle Wrap="false" />
                        <ItemStyle Wrap="false" />
                    </asp:BoundField>
                    <%-- 4 --%>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:ImageButton ID="Img_Delete" runat="server" CommandName="Delete" ImageUrl="~/images/delete.jpg" OnClientClick="return confirm('Are you sure you want delete');" />
                        </ItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="right" Width="20px" />
                        <ItemStyle Font-Bold="false" Width="20px" HorizontalAlign="Justify" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="" Wrap="false" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <RowStyle Font-Italic="False" />
            </asp:GridView>
        </div>

    </div>
    <asp:HiddenField ID="Hid_ServerUsername" runat="server" Value="ifrtAdmin" />
    <asp:HiddenField ID="Hid_ServerPWD" runat="server" Value="05Jun!(&%" />

    <asp:HiddenField ID="hf_customerid" runat="server" />
      <asp:HiddenField ID="hidpaninput" runat="server" />

</asp:Content>
