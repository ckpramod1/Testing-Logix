<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="TaxSlab.aspx.cs" Inherits="logix.HRM.TaxSlab" %>

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







    <link href="../Styles/TaxSlab.css" rel="stylesheet" type="text/css" />
      <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
     <script type="text/javascript">
         function pageLoad(sender, args) {
             $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
         }
    </script>
    <style type="text/css">
        .TaxDate {
    float: left;
    margin: 0 0.5% 0 0;
    width: 6%;
}
        .TaxSur {
    float: left;
    margin: 0 0.5% 0 0;
    width: 17.5%;
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
              <li class="current">Tax Slab</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->

    
     <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/taxslab_ic.png" /><asp:Label ID="lbl_Header" runat="server" Text="Tax Slab"></asp:Label>
       
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">
            <div class="FormGroupContent4">
                 <div class="TaxDrop"> 
                     <div class="LabelWidth">Category</div>
                     <div class="FieldInput"><asp:DropDownList ID="ddl_Category" TabIndex="1" runat="server" CssClass="chzn-select" Data-placeholder="Category" ToolTip="Category" onselectedindexchanged="ddl_Category_SelectedIndexChanged" 
            AutoPostBack="True">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem Value="M">Male</asp:ListItem>
            <asp:ListItem Value="F">Female</asp:ListItem>
        </asp:DropDownList></div>
                     </div>
                 <div class="TaxDate">
                     <div class="LabelWidth">From</div>
                     <div class="FieldInput"> <asp:TextBox ID="txt_ValidFrom" TabIndex="2" runat="server" CssClass="form-control"></asp:TextBox></div>
                    </div>
                 <div class="TaxDate">
                     <div class="LabelWidth">To</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_ValidTo" runat="server" TabIndex="3" CssClass="form-control" placeholder="Valid To" ToolTip="Valid To"></asp:TextBox></div>
                     </div>
                 <div class="TaxIn">
                     <div class="LabelWidth">Tax (in %)</div>
                     <div class="FieldInput"> <asp:TextBox ID="txt_Tax" runat="server" TabIndex="4" style="text-align:right;" CssClass="form-control" placeholder="" ToolTip="Tax (in Percentage)"></asp:TextBox></div>
                    </div>
                 <div class="TaxSlab">
                     <div class="LabelWidth">Slab From</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_SlabFrom" runat="server" TabIndex="5" style="text-align:right;" CssClass="form-control" ToolTip="Slab From" placeholder=""></asp:TextBox></div>
                     </div>
                 <div class="TaxSlabTo">
                     <div class="LabelWidth">Slab To</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_SlabTo" runat="server" TabIndex="6" style="text-align:right;" CssClass="form-control"  placeholder="" ToolTip="Slab To"></asp:TextBox></div>
                     </div>
                 <div class="TaxSur">
                     <div class="LabelWidth">Sur Charges</div>
                     <div class="FieldInput"> <asp:TextBox ID="txt_charge" runat="server" TabIndex="7" style="text-align:right;" CssClass="form-control"  placeholder="" ToolTip="Sur Charges"></asp:TextBox></div>
                    </div>
                 <div class="TaxEdu">
                     <div class="LabelWidth">Edu.Chess</div>
                     <div class="FieldInput"> <asp:TextBox ID="txt_chess" runat="server" TabIndex="8" style="text-align:right;" CssClass="form-control" placeholder="" ToolTip="Edu.Chess"></asp:TextBox></div>
                    </div>
                 </div>
              <div class="bordertopNew"></div>
            <div class="FormGroupContent4">
                  <div class="right_btn MT0 MB05">
                      
         
                      <div class="btn ico-save" id="btn_Save1" runat="server"> <asp:Button ID="btn_Save" runat="server" TabIndex="9" ToolTip="Save"  onclick="btn_Save_Click"  /></div>
                      <div class="btn ico-cancel" id="btn_Clear1" runat="server"><asp:Button ID="btn_Clear" runat="server" TabIndex="10" ToolTip="Cancel" onclick="btn_Clear_Click"  /></div>

                  </div>
                  </div>
               <div class="bordertopNew"></div>
              <div class="FormGroupContent4">
                  <div class="div_Grid">
        <asp:GridView ID="Grd_Tax" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl" Width="100%" ForeColor="Black"
            ShowHeaderWhenEmpty="True" DataKeyNames="taxid,Category" 
            onselectedindexchanged="Grd_Tax_SelectedIndexChanged" OnRowDataBound="Grd_Tax_RowDataBound">
            <Columns>
                <asp:BoundField DataField="validfrom" HeaderText="Valid From" />
                <asp:BoundField DataField="validto" HeaderText="Valid To" />
                <asp:BoundField DataField="slabfrom" HeaderText="Slab From" 
                    DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="slabto" HeaderText="Slab To" 
                    DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="taxpercent" HeaderText="Tax %" ItemStyle-CssClass="TxtAlign1" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="surcharges" HeaderText="Sur Charges" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                 <asp:BoundField DataField="educhess" HeaderText="Edu Chess" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="Img_Edudelete" runat="server" CommandName="select" CssClass="Grid_Edit_Img"
                            ImageUrl="~/images/delete.jpg" OnClientClick="javascript:IsConfirm('Do you want to Delete this record','hid_confirm');" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
        </asp:GridView>
    </div>
                  </div>
                <div class="FormGroupContent4">
                    <div class="right_btn MT0 MB05">
                        <div class="btn ico-view">
                        <asp:Button ID="btn_View" runat="server" ToolTip="View" onclick="btn_View_Click"  />
                            </div>
                        </div>
                  </div>
            </div>
         </div>


    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Tax Slab #</label>

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





   
    <asp:HiddenField ID="hid_Taxid" runat="server" />
    <asp:HiddenField ID="hid_confirm" runat="server" />
    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_ValidFrom">
    </asp:CalendarExtender>
    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_ValidTo">
    </asp:CalendarExtender>
</asp:Content>
