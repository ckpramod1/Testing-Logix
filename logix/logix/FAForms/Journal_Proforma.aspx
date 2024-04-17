<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Journal_Proforma.aspx.cs" 
    Inherits="logix.FAForm.Journal_Proforma" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../Styles/MasterSubGroup.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

          <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
        <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- App -->
    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
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

      <link href="../Styles/csfa.css" rel="stylesheet" />

    <style type="text/css">

        .Grid3 {
    border: 1px solid #b1b1b1;
    height: 450px;
    margin: 0;  
    overflow-x: hidden !important;
    overflow-y: auto !important;
    width: 100%;
}
        .row {
    height: 562px!important;
    margin: 0px 5px 0px -15px;
    clear: both;
    overflow-x: hidden !important;
    overflow-y: auto !important;
    width: 100%;
}

                  /*CSS*/

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

        .modalPopupssLog {
    background-color: #FFFFFF;
    border: 1px solid #b1b1b1;
    width: 48.5%;
    height: 232px;
    margin-left: 0% !important;
    margin-top: -16.9% !important;
    overflow: auto;
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
             white-space:nowrap;
         }

         .LogHeadJobInput label {
             font-size:12px;

         }

           .LogHeadJobInput {
             width:15%;
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

/* FixedHeader */

 .widget.box{
    position: relative;
    top: -8px;
}
 
 .widget.box .widget-content {
    top: 68px !important;
}
    </style>

    <link href="../Styles/Journal_Proforma..css" rel="Stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
     
        <div >
        <div class="col-md-12  maindiv">    
        <div class="widget box" runat ="server">   
        <div class="widget-header">
            <div>
            <h4>
                <i class="icon-umbrella"></i><asp:Label ID="lbl_Header" runat="server" Text=""></asp:Label>
            </h4>
            <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">Approval</a> </li>
              <li><a href="#" title="">  Journal Proforma to Commercial  </a> </li>
               <li><asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
            </ul>
      </div>
              <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

                </div>


            <div class="FixedButtons">
     <div class="right_btn">  
            <div class="btn ico-approve">
                <asp:Button ID="btn_Approve" runat="server" ToolTip="Approve" Text="Approve" OnClick="btn_Approve_Click"  onclientclick="disableBtn(this.id, 'Loading...')" usesubmitbehavior="False"  />

            </div>  
    <div class="btn ico-cancel" id="btn_cancel1" runat="server"><asp:Button ID="btn_cancel" Text="Cancel"  runat="server" ToolTip="Cancel"   OnClick="btn_cancel_Click" /> </div>

</div>
</div>

        </div>
        <div class="widget-content" >
        
        <div class="FormGroupContent4 boxmodal">
        <div class="Jurnal_grd">
            <asp:Panel ID="grd_panel" runat="server" ScrollBars="Auto" CssClass="gridpnl MB0">
        <asp:GridView  ID="Grd_Approval" runat="server" AutoGenerateColumns="false" CssClass="Grid FixedHeader" Width="100%" ForeColor="Black" DataKeyNames="vouyear,vouid"
             ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found" OnSelectedIndexChanged="Grd_Approval_SelectedIndexChanged" OnPreRender="Grd_Approval_PreRender" >

            <Columns>
                <asp:BoundField DataField="vouno" HeaderText="Ref #" />
                <asp:BoundField DataField="voudate" HeaderText="Vou Date"/>
                <asp:BoundField DataField="refno" HeaderText="Ref #" />
                <asp:BoundField DataField="customer" HeaderText="Customer" />
                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="preparedby" HeaderText="Prepared By" />
                <asp:TemplateField HeaderText="Approve">
                    <ItemTemplate>
                        <asp:CheckBox ID="Chk_Approval" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Lnk_job" runat="server" CommandName="select" Font-Underline="false"
                                                    CssClass="Arrow">=></asp:LinkButton>
                                                <br />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>      
                      <asp:BoundField DataField="vouid" HeaderText="vouid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"/>                  
            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
        </asp:GridView>
                </asp:Panel>
        </div>
        </div>
       
        </div>
        </div>
        </div>
        </div>
      
    <asp:HiddenField ID="hid_type" runat="server" />

     <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>Journal Proforma #</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel1" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="10"
                    BackColor="White" OnPreRender="GridViewlog_PreRender">
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

    <asp:Label ID="Label6" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label6" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

</asp:Content>
