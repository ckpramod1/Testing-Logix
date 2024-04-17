<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ledger.aspx.cs" Inherits="logix.Ledger" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtool" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>logix</title>
    <script type="text/javascript" src="Scripts/Calendar.js"></script> 
    <script type="text/javascript" src="Scripts/Validation.js"></script>
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="Style/jquery-ui.css" rel="Stylesheet" type="text/css" />
     <!-- Bootstrap -->
    <link href="Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Theme/bootstrap/css/bootstrap-select.css">
    <link rel="icon" type="image/png" sizes="36x21" href="Theme/assets/img/favicon.png">
    <link href="Theme/assets/css/new_style.css" rel="stylesheet" />
    <!-- Theme -->

    <link href="Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="Theme/assets/css/fontawesome/font-awesome.min.css">
    
    <link href="Theme/assets/css/cscss.css" rel="stylesheet" />

    <!--=== JavaScript ===-->

    <script type="text/javascript" src="Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/libs/lodash.compat.min.js"></script>

    <!-- Smartphone Touch Events -->
    <script type="text/javascript" src="Theme/Content/plugins/touchpunch/jquery.ui.touch-punch.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/event.swipe/jquery.event.move.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/event.swipe/jquery.event.swipe.js"></script>

    <!-- General -->
    <script type="text/javascript" src="Theme/Content/assets/js/libs/breakpoints.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/respond/respond.min.js"></script>
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="Theme/Content/plugins/cookie/jquery.cookie.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- Page specific plugins -->
    <!-- Charts -->
    <script type="text/javascript" src="Theme/Content/plugins/sparkline/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/blockui/jquery.blockUI.min.js"></script>

    <!-- Forms -->
    <script type="text/javascript" src="Theme/Content/plugins/typeahead/typeahead.min.js"></script>
    <!-- AutoComplete -->
    <script type="text/javascript" src="Theme/Content/plugins/autosize/jquery.autosize.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/inputlimiter/jquery.inputlimiter.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/uniform/jquery.uniform.min.js"></script>
    <!-- Styled radio and checkboxes -->
    <script type="text/javascript" src="Theme/Content/plugins/tagsinput/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/select2/select2.min.js"></script>
    <!-- Styled select boxes -->
    <script type="text/javascript" src="Theme/Content/plugins/fileinput/fileinput.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/duallistbox/jquery.duallistbox.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-inputmask/jquery.inputmask.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-wysihtml5/wysihtml5.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.min.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/bootstrap-multiselect/bootstrap-multiselect.min.js"></script>

    <!-- Globalize -->
    <script type="text/javascript" src="Theme/Content/plugins/globalize/globalize.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/globalize/cultures/globalize.culture.de-DE.js"></script>
    <script type="text/javascript" src="Theme/Content/plugins/globalize/cultures/globalize.culture.ja-JP.js"></script>

    <!-- App -->
    <script type="text/javascript" src="Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/plugins.form-components.js"></script>
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
    <script type="text/javascript" src="Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="Theme/Content/assets/js/demo/form_components.js"></script>
      
 <%-- <script type="text/javascript">
      function pageLoad(sender, args) {
          $(document).ready(function () {

              $("#<%=txtLedgerName.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=hidId.ClientID %>").val(0);
                        $.ajax({
                            url: "Ledger.aspx/GetLikeLedgerName",
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


                    select: function (e, i) {
                        $("#<%=hidId.ClientID %>").val(i.item.val);

                    },
                    minLength: 1
                });
            });
            }
            function Set_id() {
                document.getElementById('logix_CPH_hidId').value = 0;
            }
    </script>--%>
    <style type="text/css">
      
       
        #PnlGrd{
            width:1003px;
            overflow:auto;
            height:290px;
            margin-bottom:5px;
        }

        
       body {
            background-color:transparent!important;
            color:#000!important;
        }
        .breadcrumb {
            padding:0px 15px 0px 0px;
        }
        .crumbs{
            background-color:transparent!important;
             border-top:0px solid #d9d9d9;
            border-bottom:0px solid #fff;
            height:20px;
        }
        .row {
            background-color:transparent!important;
            height:429px!important;
            overflow:hidden!important;
        }
        .breadcrumb > li + li::before {
            color:#000;
        }

        .crumbs li {
            list-style:none;
        }



        .crumbs .breadcrumb li i {
            color:#000;
        }
        .widget.box .widget-content {
            background-color:transparent;
        }








        .widget.box {
            height:384px;
        }

        div#Panel_outstd {
    WIDTH: 100%;
    HEIGHT: 417PX;
    left:1.5px!important;
    top:-7.5px!important;
}
        .row {
            height:421px!important;
        }
        .widget.box {
            height:415px!important;
        }

        .TblGridS1 {
            width:995px!important;
            height:284px!important;
        }

        #iframe_outstd {
            height:397px!important;
        }

        .DivSecPanel {
            margin:5px 0px 5px 0px;
        }
        .div_frame_out {
    height: 398px;
    overflow: hidden;
}
    </style>
</head>
<body style="margin-left:10px;margin-top:10px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <asp:UpdateProgress id="UpdateProgress2" runat="server">
        <progresstemplate>
<asp:Image id="Image1" runat="server" ImageUrl="~/Images/green_indicator.gif"></asp:Image>Loading.... Please wait... 
</progresstemplate>
    </asp:UpdateProgress>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

      <!-- Breadcrumbs line -->
          <div class="crumbs">
<%--        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i>Home</li>
           
              <li>Accounts</li>--%>
              <li class="current">Ledger </li>
            </ul>
      </div>

<div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box">
     
     <div class="widget-header" style="display:none;">
                  <h4><i class="icon-umbrella"></i> <asp:Label ID="LBLTitle" runat="server" Text="Ledger"></asp:Label></h4>
                </div>
          <div class="widget-content">
             
              <div class="FormGroupContent4">
                  <div class="FromTxt"><asp:Label id="Label1" runat="server"  Text="From"></asp:Label></div>
                  <div class="FromTxtbox"><asp:TextBox id="dtFrom" runat="server" CssClass="form-control"></asp:TextBox>
                      <ajaxtool:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtFrom"
                                Format="dd/MM/yyyy"></ajaxtool:CalendarExtender>
                  </div>
              <%--    <div class="CalImg"> <asp:Image ID="ImgFrom" runat="server" Height="18px" ImageUrl="~/Images/Calender.jpg" Width="18px" ImageAlign="AbsMiddle" /></div>--%>
                  <div class="ToTxt"><asp:Label id="Label2" runat="server"  Text="To"></asp:Label></div>
                  <div class="ToTxtBox"> <asp:TextBox ID="dtTo" runat="server" CssClass="form-control"></asp:TextBox>
                      <ajaxtool:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtTo"
                                Format="dd/MM/yyyy"></ajaxtool:CalendarExtender>
                  </div>
             <%--     <div class="CalImg"><asp:Image ID="imgTo" runat="server" Height="18px" ImageUrl="~/Images/Calender.jpg" Width="18px" ImageAlign="AbsMiddle" /></div>--%>
                  <div class="right_btn MT0">
                      <div class="btn btn-find"><asp:Button ID="btnView" runat="server" OnClick="btnView_Click" ToolTip="Find"  /></div>                    
                      <div class="btn btn-excel1"><asp:Button id="btnToExcel" runat="server" OnClick="btnToExcel_Click" ToolTip="Export To Excel" /></div>
                      <div class="btn ico-cancel"><asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" ToolTip="Cancel" Visible="false"/></div>

                  </div>
                  </div>
              <div class="FormGroupContent4"> 
                  <asp:Label id="lblError" runat="server" CssClass="Error"></asp:Label>
    <asp:Panel ID="PnlGrd" runat="server">
        <asp:GridView ID="grd" runat="server" CssClass="Grid FixedHeader"  AutoGenerateColumns="False" ForeColor="Black" 
            DataKeyNames="vouno" Width ="100%"><%--OnRowDataBound="grd_RowDataBound"--%>
            <Columns>
                <asp:BoundField DataField="voudate" HeaderText="Date">
                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                    <ItemStyle  Width ="2.5%" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="VNDet" HeaderText="VouNo" ItemStyle-Wrap="False">
                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                    <ItemStyle Wrap="False" Width ="3%" />
                </asp:BoundField>
                
                <asp:BoundField DataField="voutype" HeaderText="Vou Type">
                    <HeaderStyle HorizontalAlign="Left" Width ="5%" Wrap="false" />
                    <ItemStyle width="3%" Wrap="false" />
                </asp:BoundField>
                  <asp:BoundField DataField="vouno" HeaderText="Vou #" ItemStyle-Wrap="False">
                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                    <ItemStyle Wrap="False" Width ="3%" />
                </asp:BoundField>
                <asp:BoundField DataField="prti" HeaderText="Particulars">
                    <HeaderStyle Wrap="false" />
                    <ItemStyle Width ="8%" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="Debit" HeaderText="Debit" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Center"  Wrap="false"   />
                    <ItemStyle HorizontalAlign="Right" Width ="4%"  Wrap="false" CssClass="TxtAlign1" />
                </asp:BoundField>
                <asp:BoundField DataField="Credit" HeaderText="Credit" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Center"  Wrap="false" />
                    <ItemStyle HorizontalAlign="Right" Width ="4%"  Wrap="false" CssClass="TxtAlign1"  />
                </asp:BoundField>
                <asp:BoundField DataField="Balance" HeaderText="Balance" ItemStyle-Wrap="False" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Center"  Wrap="false"/>
                    <ItemStyle  HorizontalAlign ="Right"  Wrap="false"   Width ="5%" CssClass="TxtAlign1" />
                </asp:BoundField>
                <asp:BoundField DataField="narration" HeaderText="Narration">
                    <HeaderStyle HorizontalAlign="Left"  Wrap="false" />
                    <ItemStyle Width ="6%"   Wrap="false"  />
                </asp:BoundField>
                <asp:BoundField DataField="containerno" HeaderText="Container #">
                    <HeaderStyle HorizontalAlign="Left" Wrap="False"  />
                    <ItemStyle width="5%"  Wrap="false" />
                </asp:BoundField>
                
            </Columns>
            <RowStyle BackColor="#EFF3FB" Font-Names="sans-serif" Font-Size="Small" />
                                                <EditRowStyle BackColor="#2461BF" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
                                                <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </asp:Panel></div>


              <div class="FormGroupContent4">

                  <div class="btn btn-acd1" id="div_outstd" runat="server">
                            <asp:Button ID="btn_outstd" runat="server" Text="Outstanding" OnClick="btn_outstd_Click" Visible="false" /> <%--OnClick="btn_outstd_Click"--%>
                        </div>
              </div>



                 <div class="FormGroupContent4">

        <asp:Panel ID="Panel_outstd" runat="server" class="div_frame" BackColor="White" Style="display: none;">


            <div class="DivSecPanel">
                <asp:Image ID="Close_outstd" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <div class="div_frame_out">
                <iframe id="iframe_outstd" runat="server" src="" frameborder="0" style="width: 100%; height: 450px;"></iframe>
            </div>
        </asp:Panel>
                <asp:Label ID="lblcrm" runat="server"></asp:Label>
                                      <ajaxtool:ModalPopupExtender ID="MOdal_popup_outstd" runat="server" TargetControlID="lblcrm" BehaviorID="programmaticModalPopupBehavior3"
                                        PopupControlID="Panel_outstd" Drag="true" CancelControlID="Close_outstd"
                                        BackgroundCssClass="modalBackground" > <%-- CancelControlID="imgcrok"--%>
                                    </ajaxtool:ModalPopupExtender>
   

    </div>

  
              
              </div>
         </div>
            </div>
    </div>


   
            &nbsp;
        <%-- <asp:BoundField DataField="vendorrefno" HeaderText="Vender Ref #">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle width="5%" />
                </asp:BoundField>
                <asp:BoundField DataField="jobno" HeaderText="Job #">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle width="2.5%" />
                </asp:BoundField>
                <asp:BoundField DataField="refno" HeaderText="Ref #">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle width="4%" Wrap="true"  />
                </asp:BoundField>
                <asp:BoundField DataField="fcur" HeaderText="Cur">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle width="2%" />
                </asp:BoundField>
                <asp:BoundField DataField="famt" HeaderText="Debit" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle  HorizontalAlign="Right" width="4%" />
                </asp:BoundField>
                <asp:BoundField DataField="famt" HeaderText="Credit" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Right" width="4%"  />
                </asp:BoundField>
                <asp:BoundField DataField="fexrate" HeaderText="Ex-Rate"  DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle width="4%" HorizontalAlign="Right" />
                </asp:BoundField>--%>
    <asp:HiddenField ID="hidId" runat="server" />
    <asp:HiddenField ID="hid_bid" runat="server" />
</ContentTemplate>
</asp:UpdatePanel>
</form>
</body>
</html>