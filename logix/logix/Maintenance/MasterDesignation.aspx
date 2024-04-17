<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MasterDesignation.aspx.cs" Inherits="logix.Maintenance.MasterDesignation" %>
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
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

   <%-- <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

  
    <!-- App -->
        <script type="text/javascript" src="../js/helper.js"></script>

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




<link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css"/>
<link href="../Styles/MasterDesignation.css" rel="stylesheet" type="text/css" />
<link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
<link href="../Styles/ControlStyle2.css" rel="Stylesheet" type ="text/css" />
<link href="../Styles/button1.css" rel="stylesheet" type="text/css" />


<link href="../Styles/GridviewScroll.css" rel="stylesheet" />
<script  src="../Scripts/gridviewScroll.min.js"  type="text/javascript"></script>
     


 <script type="text/javascript">

     function pageLoad(sender, args) {
         $(document).ready(function () {
             $("#<%=txtdesignation.ClientID %>").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         url: "../Maintenance/MasterDesignation.aspx/GetDesignationName",
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
                     $("#<%=txtdesignation.ClientID %>").val(i.item.label);
                     $("#<%=txtdesignation.ClientID %>").change();
                     $("#<%=hdf1_designame.ClientID %>").val(i.item.val);
                 },
                 focus: function (event, i) {
                     $("#<%=txtdesignation.ClientID %>").val(i.item.label);
                     $("#<%=hdf1_designame.ClientID %>").val(i.item.val);
                 },
                 close: function (event, i) {
                     $("#<%=txtdesignation.ClientID %>").val(i.item.label);
                     $("#<%=hdf1_designame.ClientID %>").val(i.item.val);
                 },
                 minLength: 1
             });




         });

         $(document).ready(function () {
            <%-- $('#<%=GridView1.ClientID%>').gridviewScroll({
                   width: 488,
                   height: 325,
                   arrowsize: 30,

                   varrowtopimg: "../images/arrowvt.png",
                   varrowbottomimg: "../images/arrowvb.png",
                   harrowleftimg: "../images/arrowhl.png",
                   harrowrightimg: "../images/arrowhr.png"
               });--%>
           });


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
             $(".dropdown img.flag").toggleClass("flag visibility");
         });
     }

     var msg;
     function ValidateAlpha(evt, msg) {
         var keyCode = (evt.which) ? evt.which : evt.keyCode
         if (keyCode > 46 && (keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32) {
             alertify.alert("Characters Only allowed " + msg);
             return false;

         }
         return true;
     }


     function getConfirmationValue() {
         var sector = document.getElementById('<%=txtdesignation.ClientID %>').value;

         if (sector == "") {
             alertify.alert("Enter designation Value");
             return false;
         }
         else {
             if (confirm(' Are you sure you want to delete the details?')) {
                 $('#<%=hfWasConfirmed.ClientID%>').val('true')
             }
             else {
                 $('#<%=hfWasConfirmed.ClientID%>').val('false')
             }
         }
         return true;
     }

     
             </script>

    <script type="text/javascript">
        function TxtFocus() {

            var el = $("#<%=txt_Search.ClientID %>").get(0);
            var elemLen = el.value.length;
            el.selectionStart = elemLen;
            el.selectionEnd = elemLen;
            el.focus();
        }

        function GetDetail() {
            $.ajax({
                type: "POST",
                url: "../Maintenance/MasterDesignation.aspx/GetEmpName",
                data: '{Prefix: "' + $("#<%=txt_Search.ClientID %>").val() + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    //alertify.alert(response.d);
                }
            });
        }

        function OnSuccess(response) {
            $("#<%=btn_search.ClientID %>").click();
        }

    </script>
    <style type="text/css">
        .hide {
            display: none;
        }

        /*LOG DETAILS CSS*/


        .btn-logic1 {
            z-index: 2;
            border-radius: 0px;
        }
        

div#logix_CPH_div_iframe {
    width: 30%;
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


        .modalPopupssLog {
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
             width:65%;
             float:left;
             margin:2px 0px 3px 4px;

         }

         .LogHeadLbl label
         {
             color:#af2b1a;
             font-weight:bold;
             font-size:12px;
         }



         .LogHeadJob {
             width:auto;
             float:left;
             margin:0px 0.5% 0px 0px;
         }

         .LogHeadJobInput label {
             font-size:12px;
             
            
         }


           .LogHeadJobInput {
             width:auto;
             white-space:nowrap;
             float:left;
             margin:1px 0.5% 0px 0px;
         }

             .LogHeadJobInput span {
                 color:#1a65af;
                 font-size:12px;
                 margin:4px 0px 0px 0px;
             }




             .LogHeadJobInput label {
                 font-size:12px;
                 font-family:sans-serif;
                 color:#4e4e4c;
             }

/*               logix_CPH_PanelLog
             {
                 top:155px!important;
             }
.widget.box{
    position: relative;
    top: -8px;
}
div#logix_CPH_GridView1Wrapper, div#logix_CPH_GridView1PanelHeader, div#logix_CPH_GridView1PanelHeaderContent, div#logix_CPH_GridView1PanelItem, div#logix_CPH_GridView1PanelItemContent {
    width: 100% !important;
}
div#logix_CPH_GridView1PanelItem, div#logix_CPH_GridView1HorizontalBar, div#logix_CPH_GridView1HorizontalRail {
    background: none !important;
}
img#logix_CPH_GridView1Horizontal_LIMG, img#logix_CPH_GridView1Horizontal_RIMG {
    display: none;
}*/
 
div#logix_CPH_div_iframe .widget-content {
    top: 0px !important;
    padding-top:65px !important;
}
.FixedButtonsss {
    width: calc(100vw - 908px) !important;
}
    </style>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server" id="div_iframe">
     <div class="widget-header">
         <div>
                  <div style="float: left; margin: 0px 0.5% 0px 0px;"> <h4 class="hide"><i class="icon-umbrella"></i> <asp:Label ID="lbl_Header" runat="server" Text="Designation"></asp:Label></h4>
                       <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
              <li><a href="#" title="">Maintenance</a> </li>
              <li class="current"><a href="#" title="">Designation</a> </li>
            </ul>
      </div>
                  </div>
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
             </div>
                   <div class="FixedButtons" >
<div class="right_btn">
    <div class="btn ico-save" id="savbtn1" runat="server">
        <asp:Button ID="savbtn" runat="server"   Text="Save" ToolTip="Save" onclick="savbtn_Click" TabIndex="2" /> 

    </div>
    <div class="btn ico-view"> 
        <asp:Button ID="viewbtn" runat="server" Text="View" ToolTip="View" onclick="viewbtn_Click" TabIndex="3" /> 

    </div>
    <div class="btn ico-cancel" id="canclbtn1" runat="server">
        <asp:Button ID="canclbtn" runat="server"   Text="Cancel" ToolTip="Cancel"  onclick="canclbtn_Click" TabIndex="5" /> 

    </div>
    <div class="btn ico-delete" id="deltbtn_id" runat="server"  >
        <asp:Button ID="deltbtn" runat="server"  Text="Delete" ToolTip="Delete" CssClass="Button" onclick="deltbtn_Click"  TabIndex="4" OnClientClick ="return confirm('Are you sure you want to delete this Designation?')" />
    </div>
        <asp:Button ID="btn_search" runat="server" Text="" Style="display: none;" OnClick="btn_search_Click" />
</div>
</div>

                </div>
          <div class="widget-content">
              
             <div class="FormGroupContent4 boxmodal">
               <div class="FormGroupContent4">

                 <asp:TextBox ID="txtdesignation" runat="server" CssClass="form-control" ToolTip="DESIGNATION NAME" PlaceHolder="Designation Name" onKeyUp="CheckTextLength(this,30);" AutoPostBack="True" ontextchanged="txtdesignation_TextChanged" TabIndex="1"></asp:TextBox> 
                   </div>
                 </div>
              
       

              <div class="FormGroupContent4 boxmodal">

               <div class="FormGroupContent4">
                   <asp:TextBox ID="txt_Search" runat="server" placeholder="Search" ToolTip="Search" CssClass="form-control" MaxLength="100" AutoPostBack="true" onkeyup="GetDetail();"  TabIndex="6"></asp:TextBox>
                   </div>
              <div class="FormGroupContent4">
                  <div class="gridpnl">
                      <asp:GridView ID="GridView1" runat="server"  Width="100%" ForeColor="Black" AutoGenerateColumns="False" CssClass="Grid FixedHeader"  ShowHeaderWhenEmpty="true" OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="false" PageSize="12">
            <Columns>
              
                <asp:BoundField DataField="designame" HeaderText="Designation Name">
                    <HeaderStyle HorizontalAlign="Justify"/>
                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  />
                </asp:BoundField>   

             
            </Columns>
              <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridviewScrollHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
           
        </asp:GridView>
                  </div>
                  </div>
                  </div>
              <div class="FormGroupContent4">
                  <div style="width:25%; float:right; margin-right:1%;" id="divExport" runat="server" visible="false">
        <dl id="sample" class="dropdown">
        <dt><a ><span>Export TO</span></a></dt>
       <dd><ul>
             <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="ExportExcel_Click">Excel</asp:LinkButton></li>
            <li><asp:LinkButton ID="LinkButton1" runat="server" OnClick="ExportPDF_Click">PDF</asp:LinkButton></li>
                       </ul></dd>
        </dl>
        <span id="result"></span>
        </div>
              </div>
              <asp:HiddenField ID="hdf1_designame" runat="server" 
        onvaluechanged="hdf1_designame_ValueChanged" />

        <asp:HiddenField ID="hfWasConfirmed" runat="server" />
              </div>
         </div>
            </div>
           </div>

     <div id="PanelLog1" runat="server">
                    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label id="lbl" runat="server">Designation :</label>

                                </div>
                                <div class="LogHeadJobInput">

                                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                                </div>

                            </div>
                            <div class="DivSecPanel">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>

                            <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">

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
     <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:modalpopupextender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image3" BehaviorID="Test1">
    </asp:modalpopupextender>

</asp:Content>
