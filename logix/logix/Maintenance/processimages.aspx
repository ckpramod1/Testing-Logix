<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="processimages.aspx.cs" Inherits="logix.Maintenance.processimages" %>
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
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

    <%-- <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>


    <!-- App -->

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
     <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
       <link href="../Styles/custom.css" rel="stylesheet" />
      <script src="../Scripts/Validation.js" type="text/javascript"></script>
        <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
        <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
        <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <style type="text/css">
        .EmpLbltxtboxN {
            width: 51%;
            float: left;
            margin: 0% 0.5% 0px 0px;
        }
         .btnsave {
            width: 20%;
            float: left;
            margin: 0px 0.5% 0px 14px;
        }
          .btncancel {
            width: 20%;
            float: left;
            margin: 0px 0.5% 0px 14px;
        }
        .form-control {
    height: 23px;
    font-size: 11px;
    -webkit-border-radius: 0;
    -moz-border-radius: 0;
    border-radius: 0;
	 text-transform:uppercase;
    padding:1px 6px 1px 6px!important;
}

        .EmpRight {
    width: 20%;
    float: left;
    margin: 5px 0% 0px 0px;
}
    </style>
     <script type="text/javascript">

         function ShowpImagePreview(input) {
             if (input.files && input.files[0]) {
                 var reader = new FileReader();
                 reader.onload = function (e) {
                     $('#<%= Img_Emp.ClientID %>').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
                }
         }
         <%--function pageLoad(sender, args) {

             $(document).ready(function () {
                 $('input:text:first').focus();
             });
             $(document).ready(function () {
                 $("#<%=txt_processname.ClientID %>").autocomplete({

                     source: function (request, response) {
                         $("#<%=hd_processid.ClientID %>").val(0);
                         $.ajax({
                             url: "../Maintenance/processimages.aspx/getempname",
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
                         $("#<%=txt_processname.ClientID %>").val(i.item.label);
                         $("#<%=txt_processname.ClientID %>").change();
                         $("#<%=hd_processid.ClientID %>").val(i.item.val);
                     },
                     focus: function (event, i) {
                         $("#<%=txt_processname.ClientID %>").val(i.item.label);
                         $("#<%=hd_processid.ClientID %>").val(i.item.val);
                     },
                     change: function (event, i) {
                         $("#<%=txt_processname.ClientID %>").val(i.item.label);
                         $("#<%=hd_processid.ClientID %>").val(i.item.val);

                     },
                     close: function (event, i) {
                         $("#<%=txt_processname.ClientID %>").val(i.item.label);
                         $("#<%=hd_processid.ClientID %>").val(i.item.val);
                     },
                     minLength: 1
                 });
             });

         }--%>

    </script>

     <script type="text/javascript">

         function pageLoad(sender, args) {

 


            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

        }
    </script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
      <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
            <li><a href="#" title="">System</a> </li>
            <li class="current">Process Images</li>
        </ul>
    </div>
    <!-- Breadcrumbs line End -->
     <!-- Breadcrumbs line End -->
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">
                <div class="widget-header">
                    <h4><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_header" runat="server" Text="Process Images"></asp:Label></h4>
                </div>
                <div class="widget-content">





    <div class="EmpLbltxtboxN">
        <%--<asp:TextBox ID="txt_processname" runat="server"  CssClass="form-control" ToolTip="Processname" placeholder="Processname" ></asp:TextBox>--%>
       <asp:DropDownList ID="ddl_processname1" runat="server" AppendDataBoundItems="True" CssClass="chzn-select"
                                            ForeColor="Black" ToolTip="Processname"
                                            data-placeholder="Processname" AutoPostBack="True" OnSelectedIndexChanged="ddl_processname_SelectedIndexChanged1">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        </asp:DropDownList>
    </div>
    <div class="div_Break"></div>
     <div class="EmpRight">
                                <asp:Image ID="Img_Emp" runat="server" Height="116px" Width="108px" BorderStyle="Solid" BorderWidth="1px" ImageUrl="~/images/UT.jpg"/>
                                <div class="BrowseFileUpload" >
                                    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always"  runat="server" >
                                        <ContentTemplate>
                                            <span style="display :block; color:#fff; background-color:#5ba701; color:black; width:121px; font-size:12px; padding:0px 0px 0px 0px;" ></span>
                                            <asp:FileUpload ID="img_upload" CssClass="bt" runat="server" onchange="ShowpImagePreview(this);" />
                                            <div class="div_btn">
                                                <asp:Button ID="Button1" runat="server" Text="Upload" Width="100%" CssClass="Button" Visible="false" />
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btn_save" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>

                            </div>
    <div class="div_Break"></div>
    <div class="btn btn-save">
        <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" />
    </div>
     <div class="btn ico-cancel">
        <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" />
    </div>

                    </div>
                </div>
            </div>
        </div>

    <asp:HiddenField ID="hd_processid" runat="server" />
</asp:Content>
