<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ProApprove4KYC.aspx.cs" Inherits="logix.Maintenance.ProApprove4KYC" %>

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
        <script type="text/javascript" src="../js/helper.js"></script>

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






    <link href="../Styles/ProApprove4KYC.css" rel="stylesheet" />

    <script type="text/javascript">
        var TotalChkBx;
        var Counter;

        window.onload = function () {
            //Get total no. of CheckBoxes in side the GridView.
            TotalChkBx = parseInt('<%= this.grd.Rows.Count %>');

            //Get total no. of checked CheckBoxes in side the GridView.
            Counter = 0;
        }

        function HeaderClick(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
                document.getElementById('<%= this.grd.ClientID %>');
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
    <style>
        .widget.box{
    position: relative;
    top: -8px;
}
  
        .widget.box .widget-content {
   
    top: 0px !important;
    padding-top:65px !important;
    
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
         <div>
                  <h4 class="hide"><i class="icon-umbrella"></i><asp:Label ID="lbl_Header" runat="server" Text="Approval for KYC"></asp:Label></h4>
          <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
              <li><a href="#" title="">Maintenance</a> </li>
              <li class="current"><a href="#" title="">Approval for KYC</a> </li>
            </ul>
      </div>
             </div>


                         <div class="FixedButtons ">
      <div class="right_btn">
          <div class="btn ico-transfer"> <asp:Button ID="btnapprove" runat="server"  Text="Transfer" ToolTip="Transfer" OnClick="btnapprove_Click" />
</div>
          <div class="btn ico-back"> <asp:Button ID="btnback" runat="server"  Text="Back" ToolTip="Back" OnClick="btnback_Click" /> </div>
      </div>
      </div>


                </div>
          <div class="widget-content">
             
             <div class="FormGroupContent4 boxmodal">
                 <div class="gridpnl">
                 <asp:panel id="pnlCharge" runat="server" scrollbars="Auto">

            <asp:GridView ID="grd" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False" 
                Width="100%" ForeColor="Black" PageSize="3" AllowPaging="false" CssClass ="Grid FixedHeader" OnRowDataBound="grd_RowDataBound" OnRowCommand="grd_RowCommand" OnRowCreated="grd_RowCreated" >                
            
            <Columns>
                         
                        <asp:TemplateField HeaderText ="Customer">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis; width:150px">
                       <asp:Label ID="Customer" runat="server" Text='<%# Bind("customer") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" HorizontalAlign="Center" width="130px" />
                <ItemStyle Wrap="false" HorizontalAlign="Left" width="130px"></ItemStyle>
                </asp:TemplateField>                        

                         <asp:TemplateField HeaderText ="IDProof">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis; width:60px">
                       <asp:Label ID="IDProof" runat="server" Text='<%# Bind("idproof") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" HorizontalAlign="Center" width="60px"/>
                <ItemStyle Wrap="false" HorizontalAlign="Left" width="60px"></ItemStyle>
                </asp:TemplateField>                        

                        <asp:TemplateField HeaderText ="AddProof">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis; width:60px">
                       <asp:Label ID="AddProof" runat="server" Text='<%# Bind("addproof") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" HorizontalAlign="Center" width="60px" />
                <ItemStyle Wrap="false" HorizontalAlign="Left" width="60px"></ItemStyle>
                </asp:TemplateField>                        

                        <asp:TemplateField HeaderText ="IECCode">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis; width:100px">
                       <asp:Label ID="IECCode" runat="server" Text='<%# Bind("ieccode") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" HorizontalAlign="Center"  width="70px" />
                <ItemStyle Wrap="false" HorizontalAlign="Left"  width="70px"></ItemStyle>
                </asp:TemplateField>                        

                        <asp:TemplateField HeaderText ="PreparedBy">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;">
                       <asp:Label ID="PreparedBy" runat="server" Text='<%# Bind("preparedby") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" HorizontalAlign="Center" width="73px" />
                <ItemStyle Wrap="false" HorizontalAlign="Left" width="73px"></ItemStyle>
                </asp:TemplateField>                        

                        <%--<asp:TemplateField HeaderText ="selectt">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;">
                       <asp:CheckBox ID="selectt" runat="server" />
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>--%>
                
                <asp:TemplateField HeaderText="Transfer">
                    <ItemTemplate>
                        <asp:CheckBox ID="selectt" runat="server" />
                    </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" width="70px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderTemplate>
                <asp:CheckBox ID="chkBxHeader" Text="Transfer" runat="server" onclick="javascript:HeaderClick(this);" />
                </HeaderTemplate>
                </asp:TemplateField>                        

                        <asp:TemplateField HeaderText ="cid" >
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;">
                       <asp:Label ID="cid" runat="server" Text='<%# Bind("cid") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" HorizontalAlign="Center" CssClass="Hide" />
                <ItemStyle Wrap="false" HorizontalAlign="Left" CssClass="Hide"></ItemStyle>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText ="AddFileName" Visible="false">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;">
                       <asp:Label ID="AddFileName" runat="server" Text='<%# Bind("addfilename") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText ="IDPFileName" Visible="false">
                <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;">
                       <asp:Label ID="IDPFileName" runat="server" Text='<%# Bind("idpfilename") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle Wrap="true" HorizontalAlign="Center"  />
                <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
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
               
              </div>
         </div>
            </div>
           </div>

        <asp:HiddenField ID="hdnbox" runat="server" /> 
        <br />
        <asp:Label ID="lblResult" runat="server"></asp:Label><br />
    
</asp:Content>
