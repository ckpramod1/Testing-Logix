<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="UploadDocument.aspx.cs" EnableEventValidation="false" Inherits="logix.ShipmentDetails.UploadDocument" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
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
    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
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

    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>
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

    <!-- Demo JS -->
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>

    <link href="../Styles/UploadDocument.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/DropDownButton.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/button1.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <style type="text/css">
        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        #programmaticModalPopupBehavior_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        #logix_CPH_ddlDoc_chzn {
            width: 100% !important;
        }



        logix_CPH_PanelLog {
            top: 155px !important;
        }

        .modalPopup {
            background-color: #FFFFFF;
            /*border-width: 1px;
    border-style: solid;
    border-color: #CCCCCC;
    width: 1062px;*/
            width: 98%;
            height: 523px;
            margin-left: 1%;
            margin-top: -0.9%;
            /*padding: 1px;
    display: none;*/
        }
    </style>

    <script type="text/javascript">

        function previewPDF(input) {
            var file = input.files[0];
            var reader = new FileReader();

            reader.onload = function (e) {
                // Display PDF preview
                document.getElementById('pdfPreview').src = e.target.result;
            };

            reader.readAsDataURL(file);
        }
        function pageLoad(sender, args) {

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    <script type="text/javascript">
        function ConfirmationBox() {
            var result = confirm('Do You Want to Print?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>

    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>

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

        .modalPopupLog {
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
            width: 65%;
            float: left;
            margin: 2px 0px 3px 4px;
        }

            .LogHeadLbl label {
                color: #af2b1a;
                font-weight: bold;
                font-size: 11px;
            }

        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LogHeadJobInput label {
            font-size: 11px;
        }

        .LogHeadJobInput {
            width: 15%;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 11px;
                margin: 4px 0px 0px 0px;
            }

            .LogHeadJobInput label {
                font-size: 11px;
                font-family: sans-serif;
                color: #4e4e4c;
            }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            /*color: #000080;*/
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        div#logix_CPH_div_iframe {
            height: 85vh;
        }

        .JOBInput7 {
            width: 18%;
            float: left;
            margin: 0px 0.5% 0px 0px;
            font-size: 11px;
        }

        .FileUpload1 {
            width: 39%;
            float: left;
            margin: 0 0.5% 0 0;
        }

        input#logix_CPH_upd_document {
            height: 36px;
            padding: 8px;
            border: none !important;
        }
        iframe#pdfPreview {
    width: 100%;
    border: 1px solid var(--inputborder);
    height:660px;
}

        a#logix_CPH_linkjob {
            background: #dedcdc;
            padding: 3px 10px;
            border-radius: 3px;
            margin: 5px 0 0;
            display: inline-block;
        }

      .VSLInput1 {
    width: 76.9%;
    float: left;
    margin: 0px 0px 0px 0px;
}

        .div_ddl_doc {
            width: 27%;
            float: left;
            margin-top: 0.7%;
            margin-left: 0.5%;
        }

        .Remarks {
            width: 55.3%;
            float: left;
        }

        .FileUpload {
            width: 38.3%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .InvoiceDrop.div_ddl_doc {
            margin: 0 0.5% 0 0 !important;
        }

        .div_ddl_Quotation {
            width: 33.5%;
            float: left;
            margin-top: 0.7%;
            margin-left: 1%;
        }

        span#logix_CPH_lbl_DispMsg {
            margin: 12px 0 0 4px;
            display: inline-block;
        }

        .boxmodalLink_box {
            float: left;
            margin-top: 9px;
        }

        .gridpnl {
            height: calc(100vh - 325px);
        }



       /* .FixedButtons {
            position: fixed;
            top: 30px;
            left: 0;
            background: #fff;
            z-index: 10;
            box-shadow: 0px 0px 20px rgb(0 0 0 / 10%);
            width: calc(100vw - 5px);
            border-bottom: 0.5px solid #00000010;
            padding: 1px 0 5px 10px;
        }*/

        div#logix_CPH_div_iframe .widget-content {
            top: 0 !important;
            padding-top: 50px !important;
        }

        .btn.ico-upload {
            margin: 8px 0px 0px 14px;
        }
        .divleft{
            width:40%;
            float:left;
            margin:0px 0.5% 0px 0px

        }
         .divright{
     width:59%;
     float:left;
     margin:0px 0.5% 0px 0px

 }
    </style>

    <script type="text/javascript">
        function disableBtn(btnID, newText) {
            //initialize to avoid 'Page_IsValid is undefined' JavaScript error
            Page_IsValid = null;
            //check if the page request any validation
            // if yes, check if the page was valid
            if (typeof (Page_ClientValidate) == 'function') {
                Page_ClientValidate();
                //you can pass in the validation group name also
            }
            //variables
            var btn = document.getElementById(btnID);
            var isValidationOk = Page_IsValid;
            /********NEW UPDATE************************************/
            //if not IE then enable the button on unload before redirecting/ rendering
            if (navigator.appName !== 'Microsoft Internet Explorer') {
                EnableOnUnload(btnID, btn.value);
            }
            /***********END UPDATE ****************************/
            // isValidationOk is not null
            if (isValidationOk !== null) {
                //page was valid
                if (isValidationOk) {
                    btn.disabled = true;
                    btn.value = newText;
                    btn.style.background = 'url(~/images/ajax-loader.gif)';
                }
                else {//page was not valid
                    btn.disabled = false;
                }
            }
            else {//the page don't have any validation request
                setTimeout("setImage('" + btnID + "')", 10);
                btn.disabled = true;
                btn.value = newText;
            }
        }

        //set the background image of the button
        function setImage(btnID) {
            var btn = document.getElementById(btnID);
            btn.style.background = 'url(images/Loading.gif)';
        }

        //enable the button and restore the original text value
        function EnableOnUnload(btnID, btnText) {
            window.onunload = function () {
                var btn = document.getElementById(btnID);
                btn.disabled = false;
                btn.value = btnText;
            }
        }
    </script>
    <script type="text/javascript">
        function ConfirmationBox() {
            var result = confirm('Do you Want to delete this Details?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- /Breadcrumbs line -->
    <div>
        <div class="col-md-12 maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <div>
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lblHeader" runat="server" Text="Upload/Download Document "></asp:Label></h4>
                        <!-- Breadcrumbs line -->
                        <div class="crumbs" id="up_doc" runat="server">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <li><a href="#" title="" id="A1" runat="server"></a></li>
                                <li><a href="#" title="" id="headerlable1" runat="server">Ocean Exports</a> </li>
                                <li class="current"><a href="#" title="">Upload/Download Document</a> </li>
                            </ul>
                        </div>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm">
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>

                     <div class="FixedButtons">
     <div class="right_btn">
         <%--<div class="btn ico-save">--%>

         <%--onclientclick="disableBtn(this.id, 'Loading...')" usesubmitbehavior="False"--%>
         <div class="btn ico-view hide">
             <asp:Button ID="btnView" runat="server" Text="View" ToolTip="View" TabIndex="17" OnClick="btnView_Click" />
         </div>
         <div class="btn ico-upload" style="display: none;">
             <asp:Button ID="btndown" runat="server" Text="Download" ToolTip="Download" TabIndex="17" OnClick="btndown_Click" />
         </div>
         <div class="btn ico-cancel" id="btn_close1" runat="server">
             <asp:Button ID="btnclose" runat="server" Text="Cancel" ToolTip="Cancel" TabIndex="19" OnClick="btnclose_Click" />
         </div>
     </div>
 </div>


                </div>
                <div class="widget-content">

                   

                    <div class="divleft">
                                      <div class="FormGroupContent4 boxmodal">
                  <div class="JOBInput7">
                      <span>Job #</span>

                      <asp:TextBox ID="txtjob" runat="server" placeholder="" ToolTip="Job Number" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtjob_TextChanged"></asp:TextBox>
                  </div>
                  <div class=" boxmodalLink_box">

                      <asp:LinkButton ID="linkjob" CssClass="anc ico-find-sm" runat="server" Style="text-decoration: none; color: Red;" OnClick="linkjob_Click"></asp:LinkButton>
                  </div>
                  <div class="VSLInput1">
                      <asp:Label ID="Label1" runat="server" Text="Vsl & Voy"> </asp:Label>
                      <asp:TextBox ID="txtVsl" runat="server" CssClass="form-control" TabIndex="2" AutoPostBack="True" placeholder="" ToolTip="Vsl & Voy"></asp:TextBox>
                  </div>
                  




              </div>

              <div class="FormGroupContent4">

                  <div class="InvoiceDrop div_ddl_doc">
                      <asp:Label ID="Label2" runat="server" Text="DOC Type"> </asp:Label>
                      <asp:DropDownList ID="ddlDoc" runat="server" data-placeholder="DOC Type" ToolTip="DOC Type" OnSelectedIndexChanged="ddlDoc_SelectedIndexChanged" CssClass="chzn-select" AutoPostBack="true">
                          <asp:ListItem Text="" Value="0"></asp:ListItem>
                      </asp:DropDownList>

                  </div>
                  <div class="DocumentDrop div_ddl_Quotation hide">
                      <asp:Label ID="Label3" runat="server" Text="Document #"> </asp:Label>
                      <asp:TextBox ID="ddlDocNum" runat="server" CssClass="form-control" TabIndex="2" ToolTip="Document #" placeholder="" Enabled="false"></asp:TextBox>
                      <%--      <asp:DropDownList ID="ddlDocNum" runat="server" CssClass="chzn-select" data-placeholder="Document #" ToolTip="Document Number" OnSelectedIndexChanged="ddlDocNum_SelectedIndexChanged" AutoPostBack="true">
    <asp:ListItem Text="" Value="0"></asp:ListItem>
</asp:DropDownList>--%>
                  </div>
                 
                                        <div class="FileUpload">
    <asp:Label ID="Label4" runat="server" Text="Document #"> </asp:Label>
    <asp:TextBox ID="txtDoc" runat="server" CssClass="form-control" TabIndex="2" ToolTip="Document #" placeholder=""></asp:TextBox>
</div>
              </div>
              <div class="FormGroupContent4">
                  <div class="Remarks">
                      <asp:Label ID="Label5" runat="server" Text="Remarks"> </asp:Label>
                      <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TabIndex="2" placeholder="" ToolTip="Remarks"></asp:TextBox>

                  </div>
                   <div class="btn ico-upload">
     <asp:Button ID="btnSave" runat="server" Text="Upload" ToolTip="Upload" TabIndex="16" OnClick="btnSave_Click" />
 </div>
                                          <div style="color: maroon; float: left; margin-top: 10px; margin-left: 4px;">
    <asp:Label ID="lbl_DispMsg" runat="server" Text="Upload status : "></asp:Label>
</div>

                 

              </div>
              <div class="FormGroupContent4 boxmodal">
                  <div class="gridpnl MB0">
                      <%--<asp:GridView ID="Grd_Doc" runat="server" AllowPaging="false" AutoGenerateColumns="False" CssClass="Grid FixedHeader"  ShowHeaderWhenEmpty="true" OnRowCommand="Grd_Doc_RowCommand" OnRowDataBound="Grd_Doc_RowDataBound" ForeColor="Black" PageSize="11" 
      BackColor="White">
      <Columns>
          <asp:BoundField DataField="docname" HeaderText="Doc Type">
              <HeaderStyle Width="370px" />
              <ItemStyle HorizontalAlign="Left" Width="35%" />
          </asp:BoundField>
          <asp:BoundField DataField="remarks" HeaderText="Remarks">
               <HeaderStyle Width="460px" />
              <ItemStyle HorizontalAlign="Left" Width="60%" />
          </asp:BoundField>               
           <asp:BoundField DataField="doctype" HeaderText="doctype" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
               <HeaderStyle Width="460px" />
              <ItemStyle HorizontalAlign="Left" Width="60%" />
          </asp:BoundField>
           <asp:BoundField DataField="docid" HeaderText="docid" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
               <HeaderStyle Width="460px" />
              <ItemStyle HorizontalAlign="Left" Width="60%" />
          </asp:BoundField>
           <asp:BoundField DataField="fileloc" HeaderText="file" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
               <HeaderStyle Width="460px" />
              <ItemStyle HorizontalAlign="Left" Width="60%" />
          </asp:BoundField>
           <asp:TemplateField>
                  <ItemTemplate>
                      <asp:LinkButton ID="Lnk_Print" runat="server" CommandName="print" Font-Underline="false"
                          CssClass="Arrow">⇛</asp:LinkButton>
                  </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" Width="5%" />
           </asp:TemplateField>
      </Columns>
      <EmptyDataRowStyle CssClass="EmptyRowStyle" />
      <HeaderStyle CssClass="" />
      <AlternatingRowStyle CssClass="GrdAltRow" />
  </asp:GridView>--%>

                      <asp:GridView ID="grdbudget" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader" ForeColor="Black" OnRowDataBound="grdbudget_RowDataBound" OnSelectedIndexChanged="grdbudget_SelectedIndexChanged" ShowHeaderWhenEmpty="true" Width="100%"  OnRowDeleting="grdbudget_RowDeleting" OnPreRender="grdbudget_PreRender">
                          <Columns>
                              <asp:BoundField DataField="docname" HeaderText="Doc Type">
                                  <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                  <ItemStyle HorizontalAlign="Left" />
                              </asp:BoundField>
                              <asp:BoundField DataField="remarks" HeaderText="Remarks">
                                  <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                  <ItemStyle HorizontalAlign="Left" />
                              </asp:BoundField>
                              <asp:BoundField ControlStyle-CssClass="hide" DataField="doctype" HeaderText="docid">
                                  <HeaderStyle CssClass="hide" HorizontalAlign="Left" Wrap="true" />
                                  <ItemStyle CssClass="hide" HorizontalAlign="Left" Width="15%" />
                              </asp:BoundField>
                              <asp:BoundField DataField="docid" HeaderText="dcmtid">
                                  <HeaderStyle CssClass="hide" HorizontalAlign="Left" Wrap="true" Width="350px" />
                                  <ItemStyle CssClass="hide" HorizontalAlign="Left" Width="350px" />
                              </asp:BoundField>
                              <asp:BoundField DataField="fileloc" HeaderText="Filename Details">
                                  <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                  <%-- CssClass="hide"--%>
                                  <ItemStyle HorizontalAlign="Left" />
                                  <%--  CssClass="hide"--%>
                              </asp:BoundField>
                              <asp:TemplateField HeaderText=""><%--ItemStyle-CssClass="hide" ControlStyle-CssClass="hide"--%>
                                  <ItemTemplate>
                                      <asp:ImageButton ID="Img_Delete" runat="server" CommandName="Delete"
                                          ImageUrl="~/images/delete.jpg" OnClick="Img_Delete_Click" />

                                  </ItemTemplate>

                                  <HeaderStyle Wrap="false" HorizontalAlign="right" />
                                  <ItemStyle Font-Bold="false" HorizontalAlign="Justify" />

                              </asp:TemplateField>
                              <asp:BoundField DataField="docupdon" HeaderText="Uploaded On">
                                  <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                  <ItemStyle HorizontalAlign="Left" />
                              </asp:BoundField>
                              <asp:BoundField DataField="empname" HeaderText="Uploaded By">
                                  <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                  <ItemStyle HorizontalAlign="Left" />
                              </asp:BoundField>

                          </Columns>
                          <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                          <HeaderStyle CssClass="" />
                          <AlternatingRowStyle CssClass="GrdAltRow" />
                      </asp:GridView>
                  </div>

              </div>

              <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                  <div class="divRoated">
                      <div class="LogHeadLbl">
                          <div class="LogHeadJob">
                              <label id="lbl_no" runat="server">Job #</label>

                          </div>
                          <div class="LogHeadJobInput">

                              <asp:Label ID="JobInput" runat="server"></asp:Label>

                          </div>

                      </div>
                      <div class="DivSecPanel">
                          <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                      </div>

                      <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl">

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
                    <div class="divright">
                        <div class="FormGroupContent4">
                        <div class="FileUpload1">
    <asp:FileUpload ID="upd_document" runat="server" ToolTip="Doc Path" onchange="previewPDF(this)" accept=".pdf" />
</div>
                            </div>

                        <div class="FormGroupContent4">
                            <div class="iframeset">
                          <iframe id="pdfPreview" width="600" height="400"></iframe>
                                </div>
                            </div>
  
                    </div>
                    

                </div>
            </div>
        </div>
    </div>

    <%-- POPUP --%>
    <ajaxtoolkit:ModalPopupExtender runat="server" ID="ModalPopup" BehaviorID="programmaticModalPopupBehavior"
        PopupControlID="pln_popup" CancelControlID="bclose" TargetControlID="lbl" DropShadow="false">
    </ajaxtoolkit:ModalPopupExtender>
    <asp:Label ID="lbl" runat="server" Text="" Style="display: none;"></asp:Label>
    <%--      <asp:Panel ID="pln_popup" runat="server" CssClass="modalPopup" style="display:none;">
        <div class="div_close">
              <div style="margin-right:1%; margin-left:97%; margin-bottom:0.5%;"> <asp:Button ID="bclose" runat="server" Text="X"  BackColor="#0033cc" ForeColor="#ffffff" /></div>
           
        </div>
        <div class="div_Break">
        </div>--%>
    <asp:Panel ID="pln_popup" runat="server" CssClass="modalPopup" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="bclose" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="Grd_FE" runat="server" AutoGenerateColumns="False" Width="100%" Visible="false" OnRowDataBound="Grd_FE_RowDataBound"
                    ForeColor="Black" EmptyDataText="No Record Found" AllowPaging="false" OnPageIndexChanging="Grd_FE_PageIndexChanging" PageSize="20" CssClass="Grid FixedHeader"
                    OnSelectedIndexChanged="Grd_FE_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="jobno" HeaderText="Job #" HeaderStyle-Width="50px">
                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="VesselName">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                    <asp:Label ID="vessel" runat="server" Text='<%# Bind("vessel") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="165px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Voyage">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 45px">
                                    <asp:Label ID="voyage" runat="server" Text='<%# Bind("voyage") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="77px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MBL #">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 85px">
                                    <asp:Label ID="mblno" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="142px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ETD">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 75px">
                                    <asp:Label ID="etd" runat="server" Text='<%# Bind("etd") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="125px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Destination">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 75px">
                                    <asp:Label ID="sd" runat="server" Text='<%# Bind("sd") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="128px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ETA">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 75px">
                                    <asp:Label ID="eta" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="125px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MLO">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                    <asp:Label ID="mlo" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="125px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Agent">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                    <asp:Label ID="agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="110px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <%--<asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_FE" runat="server" CommandName="select" Font-Underline="false"
                                CssClass="Arrow">⇛</asp:LinkButton>
                        </ItemTemplate>
                       <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="15px"/>
                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>--%>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>

                <div class="div_Break">
                </div>

                <asp:GridView ID="Grd_FI" runat="server" AutoGenerateColumns="False" Width="100%" Visible="false" OnRowDataBound="Grd_FI_RowDataBound" CssClass="Grid FixedHeader"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="18" AllowPaging="false" OnPageIndexChanging="Grd_FI_PageIndexChanging" OnSelectedIndexChanged="Grd_FI_SelectedIndexChanged">
                    <Columns>

                        <asp:BoundField DataField="jobno" HeaderText="Job #" HeaderStyle-Width="45px">
                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="VesselName">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                    <asp:Label ID="vesselname" runat="server" Text='<%# Bind("vesselname") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="155px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" Width="155px" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Voyage">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                    <asp:Label ID="voyage" runat="server" Text='<%# Bind("voyage") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="110px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MBL #">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                    <asp:Label ID="mblno" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="155px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" Width="155px" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ETD">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                    <asp:Label ID="etd" runat="server" Text='<%# Bind("etd") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="110px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ETA">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                    <asp:Label ID="eta" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="110px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="POL">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                    <asp:Label ID="POL" runat="server" Text='<%# Bind("POL") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="110px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Agent">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                    <asp:Label ID="agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="110px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MLO / FFR">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                    <asp:Label ID="MLO" runat="server" Text='<%# Bind("MLO") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="110px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <%--<asp:TemplateField>

                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_FI" runat="server" CommandName="select" Font-Underline="false"
                                CssClass="Arrow">⇛</asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="15px"/>
                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>                        
                    </asp:TemplateField>--%>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>

                <div class="div_Break">
                </div>

                <asp:GridView ID="Grd_AE" runat="server" AutoGenerateColumns="False" Width="100%" Visible="false" OnRowDataBound="Grd_AE_RowDataBound" CssClass="Grid FixedHeader"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="18" AllowPaging="false" OnPageIndexChanging="Grd_AE_PageIndexChanging" OnSelectedIndexChanged="Grd_AE_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="jobno" HeaderText="Job #">
                            <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <%-- <asp:BoundField DataField="airline" HeaderText="AirLine">
                     <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center"  />
                    <ItemStyle Wrap="false"  Width="50px" HorizontalAlign="Left" ></ItemStyle>  
                    </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="AirLine">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                    <asp:Label ID="airline" runat="server" Text='<%# Bind("airline") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="mawblno" HeaderText="MAWBL #">
                            <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="flightdate" HeaderText="Flight">
                            <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <%--  <asp:BoundField DataField="agentname" HeaderText="Agent">
                     <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center"  />
                    <ItemStyle Wrap="false"  Width="50px" HorizontalAlign="Left" ></ItemStyle>  
                    </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Agent">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                    <asp:Label ID="agentname" runat="server" Text='<%# Bind("agentname") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="status" HeaderText="Status">
                            <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="fromport" HeaderText="From Port">
                            <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="toport" HeaderText="To Port">
                            <HeaderStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_AE" runat="server" CommandName="select" Font-Underline="false"
                                CssClass="Arrow">⇛</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>

                <div class="div_Break">
                </div>

                <asp:GridView ID="Grd_CHA" runat="server" AutoGenerateColumns="False" Width="100%" Visible="false" OnRowDataBound="Grd_CHA_RowDataBound" CssClass="Grid FixedHeader"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="18" AllowPaging="false" OnPageIndexChanging="Grd_CHA_PageIndexChanging" OnSelectedIndexChanged="Grd_CHA_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="jobno" HeaderText="Job #">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <%-- <asp:BoundField DataField="jobtype" HeaderText="JobType">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="JobType">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                    <asp:Label ID="jobtype" runat="server" Text='<%# Bind("jobtype") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <%--   <asp:BoundField DataField="docno" HeaderText="Doc #">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Doc #">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                    <asp:Label ID="docno" runat="server" Text='<%# Bind("docno") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="docdate" HeaderText="Doc Date">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="mode" HeaderText="Mode">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <%--<asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_CHA" runat="server" CommandName="select" Font-Underline="false"
                                CssClass="Arrow">⇛</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>
            </asp:Panel>
    </asp:Panel>

    <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="Image1" BehaviorID="Test3">
    </ajaxtoolkit:ModalPopupExtender>

    <asp:HiddenField ID="hid_doc" runat="server" />
    <asp:HiddenField ID="hid" runat="server" />
    <asp:HiddenField ID="hid_docid" runat="server" />
    <asp:HiddenField ID="hid_type" runat="server" />
    <asp:HiddenField ID="hid_date" runat="server" />
    <asp:HiddenField ID="hid_job" runat="server" />
    <asp:HiddenField ID="hid_str_alltype" runat="server" />
    <asp:HiddenField ID="hid_poddownload" runat="server" />

</asp:Content>
