<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Exemption.aspx.cs" Inherits="logix.HRM.Exemption" %>

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
         <link href="../Theme/newTheme/css/systemnewdeign.css" rel="stylesheet" />

    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

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









    <link href="../Styles/Exemption.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>

     <style type="text/css">
        

         modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .DivSecPanel
        {
            width:20px; 
            Height:20px; 
            border:2px solid white;
            margin-left:98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        .modalPopupss { 
            background-color:#FFFFFF; 
            /*border-width:1px;*/ 
            border-style:solid; 
            border-color:#CCCCCC;             
            width: 1042px;
            Height:555px; 
            margin-left:-2%;
            margin-top:-2.5%;
          /*padding:1px;            
            display:none;*/
        }

       .Gridpnl   
         {            
            width: 1024px;
            Height:560px;      
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

             logix_CPH_PanelLog {
             border-width: 2px;
             border-style: solid;
             position: fixed;
             z-index: 100001;
             left: 352px;
             top: 187px !important;
         }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


      <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">IT Workings</a> </li>
              <li class="current">Exemption</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->

    <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/exemption_ic.png" /> <asp:Label ID="lblExemption" runat="server" Text="Exemption"></asp:Label>
       
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">
            <div class="FormGroupContent4">
                 <div class="ExemInput">
                     <div class="LabelWidth">Exemption</div>
                     <div class="FieldInput"><asp:TextBox ID="txtExemption" runat="server" TabIndex="1" placeholder="" ToolTip="Exemption" CssClass="form-control"></asp:TextBox></div>
                     </div>
                 <div class="ExemDrop"> 
                     
                     <div class="LabelWidth">Type</div>
                     <div class="FieldInput"><asp:DropDownList ID="ddltype" runat="server" TabIndex="2" data-placeholder="Type" CssClass="chzn-select" ToolTip="Type">
                <asp:ListItem Value="0">Select</asp:ListItem>
                <asp:ListItem Value="1">Monthly</asp:ListItem>
                <asp:ListItem Value="2">Yearly</asp:ListItem>

            </asp:DropDownList></div>
                     </div>
                 <div class="ExemYear">
                     <div class="LabelWidth">Year</div>
                     <div class="FieldInput"><asp:TextBox ID="txtyear" runat="server" placeholder="" TabIndex="3" ToolTip="Year" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtyear_TextChanged"></asp:TextBox></div>
                     </div>
                 <div class="ExemAccount"> 
                     <div class="LabelWidth">Amount</div>
                     <div class="FieldInput"><asp:TextBox ID="txtAmount" runat="server" style="text-align:right" TabIndex="4" placeholder="" ToolTip="Amount" CssClass="form-control"></asp:TextBox></div>
                     
                     </div>
                 <div class="right_btn MTCtrl6 MB05">
                     <div class="btn ico-save" id="btn_save1" runat="server"><asp:Button ID="btnSave" runat="server" TabIndex="5" ToolTip="Save" OnClick="btnSave_Click" /></div>
                     <div class="btn ico-delete"><asp:Button ID="btnDelete" runat="server" TabIndex="6" ToolTip="Delete" OnClick="btnDelete_Click" /></div>
                     <div class="btn ico-view"><asp:Button ID="btnView" runat="server" TabIndex="7" ToolTip="View" OnClick="btnView_Click" /></div>
                     <div class="btn ico-cancel" id="btn_cancel1" runat="server"><asp:Button ID="btnback" runat="server" TabIndex="8" ToolTip="Cancel"  OnClick="btnback_Click" /></div>
                 </div>
                 </div>

            </div>
        </div>





       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i></h4>
                </div>
          <div class="widget-content">
             
              </div>
         </div>
            </div>
           </div>








    
   
    <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl1" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Do you sure want to delete ?</b></div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btn_yes" runat="server" Text="OK" CssClass="Button" OnClick="btn_yes_Click" />
            <asp:Button ID="btn_no" runat="server" Text="Cancel" CssClass="Button" OnClick="btn_no_Click" />
        </div>
        <br />
        <div class="div_Break"></div>
    </asp:Panel>
    <div class="div_Break"></div>
    <asp:ModalPopupExtender ID="PopUpService" runat="server" BackgroundCssClass=""
        PopupControlID="Panel_Service" TargetControlID="Label1">
    </asp:ModalPopupExtender>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Exemption #</label>

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
                   


     <asp:Label ID="Label3" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label3" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>

    <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>
    <div class="div_Break"></div>
    <asp:HiddenField ID="hid_confirm" runat="server" />
</asp:Content>
