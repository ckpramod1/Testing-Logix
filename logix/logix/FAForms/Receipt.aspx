<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="Receipt.aspx.cs" Inherits="logix.FAForm.Receipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Receipt.css" rel="stylesheet" type="text/css" />
    <!-- Bootstrap -->
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css">
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css">
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" /> <link href="../Theme/assets/css/system.css" rel="stylesheet" />
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

    <link href="../Styles/menu_style.css" rel="Stylesheet" type="text/css" />
     <link href="../CSS/Finance.css" rel="stylesheet" />


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

    <style type="text/css">
        .VoucherTXT {
            width:25%;
            float:left;
            margin:0px 0px 0px 0px;
        }
        .DateInput {
            width:15%;
            float:right;
            margin:0px 0px 0px 0px;
        }
        .ToDemo {
            width:91.5%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
        .ChequeDate1 {
            width:8%;
            float:left;
            margin:0px 0px 0px 0px;
        }
        .chequeDD1 {
            width:20%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
        .Bank1 {
            float:left;
            margin:0px 0.5% 0px 0px;
            width:15%;
        }
        .Branch1 {
            float:left;
            margin:0px 0.5% 0px 0px;
            width:15%;
        }
        .ClearDate {
            float:right;
            margin:0px 0px 0px 0px;
            width:8%;
        }
        .Narration {
            width:99%;
            float:left;
            margin:0px 0px 0px 0px;
        }
        .AgainstRefer {
            width:99%;
            float:left;
            margin:0px 0px 0px 0px;
        }
        .div_Grid {
    height: 223px;
    margin: 5px 20px 0 0;
    overflow: auto;
}
    </style>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

         <div >
        <div class="col-md-12  maindiv">     
        <div class="widget box" runat ="server">
        <div class="widget-header">
        <h4><i class="icon-umbrella"></i>
            <asp:Label ID="lbl_Header" runat="server" Text="">BPJV</asp:Label>


        </h4>

        </div> 




   <div class="widget-content">
       <div class="FormGroupContent">
           <div class="VoucherTXT">
               <div style="display:none;"><asp:Label ID="lbl_Voucher" runat="server" Text="Voucher #"></asp:Label></div>
                <asp:TextBox ID="txt_Voucher" runat="server" AutoPostBack="True" class="form-control" ontextchanged="txt_Voucher_TextChanged"></asp:TextBox>

           </div>
           <div class="DateInput">
               <div style="display:none;"><asp:Label ID="lbl_Date" runat="server" Text="Date"></asp:Label></div>
               <asp:TextBox ID="txt_Date" runat="server" class="form-control"></asp:TextBox>

           </div>

           </div>
       <div class="FormGroupContent">
           <div class="ToDemo">
               <div style="display:none;"><asp:Label ID="lbl_To" runat="server" Text="To"></asp:Label></div>
                <asp:TextBox ID="txt_To" runat="server" class="form-control"></asp:TextBox>
           </div>
           <div class="ChequeDate1">
               <div style="display:none;"><asp:Label ID="lbl_ChequeDate" runat="server" Text="Cheque Date"></asp:Label></div>
               <asp:TextBox ID="txt_ChequeDate" runat="server" class="form-control"></asp:TextBox>
           </div>
       </div>
        <div class="FormGroupContent">
            
            <div class="chequeDD1">
                <div style="display:none;"><asp:Label ID="lbl_Cheque" runat="server" Text="Cheque/DD #"></asp:Label></div>
                <asp:TextBox ID="txt_Cheque" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="Bank1">

                <div style="display:none;"><asp:Label ID="lbl_Bank" runat="server" Text="Bank"></asp:Label></div>
                <asp:TextBox ID="txt_Bank" runat="server" class="form-control"></asp:TextBox>

            </div>
            <div class="Branch1">
               <div style="display:none;"><asp:Label ID="lbl_Branch" runat="server" Text="Branch"></asp:Label></div> 
                 <asp:TextBox ID="txt_Branch" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="ClearDate">
                <div style="display:none;"><asp:Label ID="lbl_ClearedDate" runat="server" Text="Cleared Date"></asp:Label></div>
                 <asp:TextBox ID="txt_ClearedDate" runat="server" class="form-control"></asp:TextBox>

            </div>
            </div>
       <div class="FormGroupContent4">
             <div class="Narration">
                <div style="display:none;"><asp:Label ID="lbl_Narration" runat="server" Text="Narration"></asp:Label></div>
                <asp:TextBox ID="txt_Narration" runat="server" class="form-control"></asp:TextBox>
            </div>
       </div>
          <div class="FormGroupContent4">
            <div class="AgainstRefer">
                <div style="display:none;"><asp:Label ID="lbl_AgainstReference" runat="server" Text="Against Reference"></asp:Label></div>
                <asp:TextBox ID="txt_AgainstReference" runat="server" class="form-control"></asp:TextBox>
            </div>
              </div>

       <div class="FormGroupContent4">
           <div class="div_Grid">
        <asp:GridView ID="Grd_Receipt" runat="server" AutoGenerateColumns="False" Width="100%"
            ShowHeaderWhenEmpty="True" EmptyDataText="No Record Found" class="Grid FixedHeader">
            <Columns>
                <asp:BoundField DataField="ledgername" HeaderText="Particulars">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ledgeramount" HeaderText="Debit" DataFormatString="{0:#,##0.00}">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="ledgeramount" HeaderText="Credit" DataFormatString="{0:#,##0.00}">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
        </asp:GridView>
    </div>

           </div>
       <div class="right_btn">
           <div class="btn ico-back">
               <asp:Button ID="btn_Previous" runat="server" ToolTip="Previous" onclick="btn_Previous_Click" />


           </div>
           <div class="btn ico-view">
               <asp:Button ID="btn_View" runat="server" ToolTip="View" onclick="btn_View_Click" />

           </div>
           <div class="btn btn-nextB1"><asp:Button ID="btn_Next" runat="server" ToolTip="Next" onclick="btn_Next_Click" /></div>
           <div class="btn ico-cancel" id="btn_Cancel1" runat="server"><asp:Button ID="btn_Cancel" runat="server" ToolTip="Cancel" onclick="btn_Cancel_Click" /></div>
       </div>


            </div>
       </div>
            </div>
            </div>
            










    <div class="div_Main">
       
    </div>
    <div class="div_Break">
    </div>
    <div class="div_label">
        
    </div>
    <div class="div_txt">
       
    </div>
    <div class="div_Date_lbl">
        
    </div>
    <div class="div_txt_AgainstReference">
        
    </div>
    <div class="div_Break">
    </div>
    <div class="div_label">
        
    </div>
    <div class="div_txt_To">
       
    </div>
    <div class="div_label">
        
    </div>
    <div class="div_txt">
        
    </div>
    <div class="div_Break">
    </div>
    <div class="div_label">
        
    </div>
    <div class="div_txt">
        
    </div>
    <div class="div_lbl">
        
    </div>
    <div class="div_txt_Bank">
        
    </div>
    <div class="div_lbl">
        
    </div>
    <div class="div_txt">
       
    </div>
    <div class="div_label">
        
    </div>
    <div class="div_txt_ClearedDate">
       
    </div>
    <div class="div_Break">
    </div>
    <div class="div_label">
        
    </div>
    <div class="div_txt_Narration">
        
    </div>
    <div class="div_lbl_Against">
        
    </div>
    <div class="div_txt_AgainstReference">
        
    </div>
    <div class="div_Break">
    </div>
    
    <div class="div_Break">
    </div>
    <div class="div_btn">
        
        
        
        
    </div>
    <div class="div_Break">
    </div>

    <asp:HiddenField ID="hid_vou" runat="server" />

</asp:Content>
