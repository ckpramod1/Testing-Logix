<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="ServiceTaxUpdate.aspx.cs" Inherits="logix.Maintenance.ServiceTaxUpdate" %>
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









    <link href="../Styles/ServiceTaxUpdate.css" rel="stylesheet" />

    <script type="text/javascript">
        var TotalChkBx;
        var Counter;

        window.onload = function () {
            //Get total no. of CheckBoxes in side the GridView.
            TotalChkBx = parseInt('<%= this.grdTaxslab.Rows.Count %>');

    //Get total no. of checked CheckBoxes in side the GridView.
    Counter = 0;
}

function HeaderClick(CheckBox) {
    //Get target base & child control.
    var TargetBaseControl =
        document.getElementById('<%= this.grdTaxslab.ClientID %>');
    var TargetChildControl = "selectt";

    //Get all the control of the type INPUT in the base control.
    var Inputs = TargetBaseControl.getElementsByTagName("input");

    //Checked/Unchecked all the checkBoxes in side the GridView.
    for (var n = 0; n < Inputs.length; ++n)
        if (Inputs[n].type == 'checkbox' &&
                  Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
            Inputs[n].checked = CheckBox.checked;

    //Reset Counter
    Counter = CheckBox.checked ? TotalChkBx : 0;
}

function ChildClick(CheckBox, HCheckBox) {
    //get target control.
    var HeaderCheckBox = document.getElementById(HCheckBox);

    //Modifiy Counter; 
    if (CheckBox.checked && Counter < TotalChkBx)
        Counter++;
    else if (Counter > 0)
        Counter--;

    //Change state of the header CheckBox.
    if (Counter < TotalChkBx)
        HeaderCheckBox.checked = false;
    else if (Counter == TotalChkBx)
        HeaderCheckBox.checked = false;
}
</script>
    <style type="text/css">
        .hide{
            display:none;
        }
    </style>

    <style type="text/css">
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

               logix_CPH_PanelLog
             {
                 top:155px!important;
             }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


      <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
              <li><a href="#" title="">Maintenance</a> </li>
              <li class="current"><a href="#" title=""> Service Tax</a> </li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                   <div style="float: left; margin: 0px 0.5% 0px 0px;"><h4><i class="icon-umbrella"></i><asp:Label ID="lbl_Header" runat="server" Text="ServiceTax"></asp:Label></h4></div>
           <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
          <div class="widget-content">
             <div class="FormGroupContent4">
                 <div class="Label1cs"><asp:Label ID="Label1" runat="server" Text="Current" CssClass="LabelValue" ForeColor="#FF3300" ></asp:Label></div>
                 </div>
               <div class="FormGroupContent4">
                   <div class="ServiceTax1"><asp:TextBox ID="txtcurper" runat="server" Cssclass="form-control" AutoPostBack="True" placeholder="Service Tax %" ToolTip="Service Tax %" 
             TabIndex="1"  OnTextChanged="txtcurper_TextChanged"></asp:TextBox></div>
                   <div class="ServiceTax2"><asp:TextBox ID="txtcureducess" runat="server" Cssclass="form-control" AutoPostBack="True" placeholder="SB.CESS %" ToolTip="SB.CESS %"
             TabIndex="2" OnTextChanged="txtcureducess_TextChanged"></asp:TextBox></div>
                   <div class="ServiceTax3"><asp:TextBox ID="txtcurhighereduper" runat="server" Cssclass="form-control" AutoPostBack="True" placeholder="KK.CESS %" 
            ToolTip="KK.CESS %" TabIndex="3" OnTextChanged="txtcurhighereduper_TextChanged"></asp:TextBox></div>
                   </div>
              <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                    <div class="Label2cs"><asp:Label ID="Label2" runat="server" Text="Proposal" CssClass="LabelValue" ForeColor="#FF3300" ></asp:Label></div>
                   </div>
              <div class="FormGroupContent4">
                  <div class="ServiceTax1"><asp:TextBox ID="txtPercent" runat="server" Cssclass="form-control" placeholder="Service Tax %" ToolTip="Service Tax %"
             TabIndex="4"></asp:TextBox></div>
                   <div class="ServiceTax2"><asp:TextBox ID="txtEduPer" runat="server" Cssclass="form-control" placeholder="SB.CESS %" ToolTip="SB.CESS %"
             TabIndex="5"></asp:TextBox></div>
                   <div class="ServiceTax3"><asp:TextBox ID="txtHighEduPer" runat="server" Cssclass="form-control" placeholder="KK.CESS %" 
            ToolTip="KK.CESS %" TabIndex="6"></asp:TextBox></div>
                  </div>
              <div class="FormGroupContent4">
                  <div class="div_border">
                      <asp:panel id="pnlCharge" runat="server" scrollbars="Auto">

            <asp:GridView ID="grdTaxslab" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False" 
                Width="100%" ForeColor="Black" PageSize="3" CssClass ="Grid" OnRowCreated="grdTaxslab_RowCreated" OnRowDataBound="grdTaxslab_RowDataBound" >                
            
            <Columns>
                         
                        <%--<asp:TemplateField HeaderText ="selectt">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;">
                       <asp:CheckBox ID="selectt" runat="server" />
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>--%>
                         
                        <asp:TemplateField HeaderText ="Charges">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis; width:175px">
                       <asp:Label ID="Charges" runat="server" Text='<%# Bind("chargename") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" HorizontalAlign="Center" width="221px" />
                <ItemStyle Wrap="false" HorizontalAlign="Left" width="200px"></ItemStyle>
                </asp:TemplateField>                        

                         <asp:TemplateField HeaderText ="Cur">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis; width:25px">
                       <asp:Label ID="Cur" runat="server" Text='<%# Bind("currency") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" HorizontalAlign="Center" width="40px"/>
                <ItemStyle Wrap="false" HorizontalAlign="Left" width="35px"></ItemStyle>
                </asp:TemplateField>                        

                        <asp:TemplateField HeaderText ="S.Tax(%)">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis; width:30px">
                       <asp:Label ID="STax" runat="server" Text='<%# Bind("percentage") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" HorizontalAlign="Center" width="63px" />
                <ItemStyle Wrap="false" HorizontalAlign="Left" width="57px"></ItemStyle>
                </asp:TemplateField>                        

                        <asp:TemplateField HeaderText ="SB.Ces(%)">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;">
                       <asp:Label ID="EduCes" runat="server" Text='<%# Bind("sbcess") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" HorizontalAlign="Center"  width="80px" />
                <ItemStyle Wrap="false" HorizontalAlign="Left"  width="72px"></ItemStyle>
                </asp:TemplateField>                        

                        <asp:TemplateField HeaderText ="KK.Ces(%)">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;">
                       <asp:Label ID="HEdCes" runat="server" Text='<%# Bind("kkcess") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" HorizontalAlign="Center" width="80px" />
                <ItemStyle Wrap="false" HorizontalAlign="Left" width="73px"></ItemStyle>
                </asp:TemplateField>                        

                        <asp:TemplateField HeaderStyle-CssClass="hide" HeaderText="chargeid" ItemStyle-CssClass="hide" Visible="False">
                            <ItemTemplate>
                                <div style="overflow:hidden;text-overflow:ellipsis;">
                                    <asp:Label ID="chargeid" runat="server" Text='<%# Bind("chargeid") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                            <ItemStyle HorizontalAlign="Left" Wrap="false" />
                        </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="selectt" runat="server" />
                    </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" width="85px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" width="57px"/>
                <HeaderTemplate>
                <asp:CheckBox ID="chkBxHeader" Text="Select" runat="server" onclick="javascript:HeaderClick(this);" />
                </HeaderTemplate>
                </asp:TemplateField>                        

                        </Columns>
                           
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
    <HeaderStyle CssClass=""/>
    <AlternatingRowStyle CssClass="GrdAltRow"/>
    <RowStyle Font-Italic="False" />
    </asp:GridView>
    
 </asp:panel>
                  </div>
              </div>
              <div class="FormGroupContent4">
                  <div class="right_btn MB10 MT0">
                      <div class="btn ico-update" id="btnSave1" runat="server"><asp:Button ID="btnSave" runat="server" ToolTip="Update"   OnClick="btnSave_Click" TabIndex="7" /></div>
                      <div class="btn ico-cancel" id="btnCancel1" runat="server"><asp:Button ID="btnCancel" runat="server" ToolTip="Cancel" OnClick="btnCancel_Click" TabIndex="8" />   </div>
            
                  </div>
              </div>
              </div>
         </div>
            </div>
           </div>

     
     <div id="PanelLog1" runat="server">
                    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label id="lbl" runat="server">Charge id :</label>

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

        <asp:HiddenField ID="hid_chargeid" runat="server" />

    <asp:modalpopupextender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image3" BehaviorID="Test1">
    </asp:modalpopupextender>





  
</asp:Content>
