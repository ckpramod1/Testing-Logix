<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="FAReceipt.aspx.cs" Inherits="logix.FAForm.FAReceipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Styles/MasterSubGroup.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" />
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
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
    <link href="../Styles/FAReceipt.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        $(document).keydown(function (e) {
            if (e.keyCode == 27) {
                $("#<%=btn_back.ClientID%>").click();
            }
        });

    </script>
    <style type="text/css">
        body {
            overflow: hidden;
        }

        .row {
            width: 99% !important;
        }

        .VoucherInput1 {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FABank {
            width: 2.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FABank1 {
            width: 20%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FAClearLBL {
            width: 3.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FAClearLBL1 {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FADDInput1 {
            width: 20.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FAClearInput {
            width: 22%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FAChequeInput {
            width: 20.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FADDInput {
            width: 7%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FAChequeInput1 {
            width: 7.5%;
            float: left;
            margin: 0px;
        }

        .FACheque {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FAAgainist {
            width: 8%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .VoucherRecepit {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FAFromLBL {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FAChequeDD {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FANarration {
            width: 6%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .FAAgainistInput {
            width: 47.5%;
            float: left;
            margin: 0px;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }
        .DateInput2 {
    width: 100%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .FANInput {
    width: 49%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .FAAgainistInput {
    width: 50.5%;
    float: left;
    margin: 0px;
}
        .btn-ctrl1 {
    float: left;
    margin: 0px 0px 0px 0%;
}
   
        form {
    width: 100%;
}
        .widget-header h4 {
    display: block !important;
}
        span#logix_CPH_lbl_header {
    font-size: 14px;
    font-weight: 500;
    display: inline-block;
    margin: -4px 0px 0px -12px;
}


    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div>
        <div class="col-md-12  maindiv">
            <div class="widget box" runat="server">
                <div class="widget-header">
                    <h4><i class="icon-umbrella hide"></i>
                        <asp:Label ID="lbl_header" runat="server" Text="Receipt"></asp:Label></h4>
                </div>


                <div class="widget-content">

                    <div class="FormGroupContent4">
                    <div class="FormGroupContent4 boxmodal">
                      
                        <div class="VoucherInput1">
                            <asp:Label ID="lbl_vchr" runat="server" Text="Voucher #"></asp:Label>
                            <asp:TextBox ID="txt_vchr" runat="server" CssClass="form-control" OnTextChanged="txt_vchr_TextChanged"
                                AutoPostBack="True"></asp:TextBox>
                        </div>

                        <div class="btn-ctrl1">                           
                            <div class="DateInput2">
                                <asp:Label ID="lbl_date" runat="server" Text="Date"></asp:Label>
                                <asp:TextBox ID="txt_date" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                       
                        <div class="FAChequeInput">
                            <asp:Label ID="lbl_to" runat="server" Text="To"></asp:Label>
                            <asp:TextBox ID="txt_to" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                       
                        <div class="FADDInput">
                            <asp:Label ID="lbl_chqdate" runat="server" Text="Cheque Date"></asp:Label>
                            <asp:TextBox ID="txt_chqdate" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="FADDInput1">
                            <asp:Label ID="lbl_chqdd" runat="server" Text="Cheque/DD #"></asp:Label>
                            <asp:TextBox ID="txt_chqdd" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                  
                        <div class="FABank1">
                            <asp:Label ID="lbl_bank" runat="server" Text="Bank"></asp:Label>
                            <asp:TextBox ID="txt_bank" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                     
                        <div class="FAClearInput">
                            <asp:Label ID="lbl_branch" runat="server" Text="Branch"></asp:Label>
                            <asp:TextBox ID="txt_branch" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        
                        <div class="FAChequeInput1 DateR">
                            <asp:Label ID="lbl_clrddate" runat="server" Text="Cleared Date"></asp:Label>
                            <asp:TextBox ID="txt_clrddate" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    
                        <div class="FANInput">
                            <asp:Label ID="lbl_narration" runat="server" Text="Narration"></asp:Label>
                            <asp:TextBox ID="txt_narration" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    
                        <div class="FAAgainistInput">
                            <asp:Label ID="lbl_agnstref" runat="server" Text="Against Reference"></asp:Label>
                            <asp:TextBox ID="txt_agnstref" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="FormGroupContent4 boxmodal">
                        <div class="panel_05 MB0">
                            <asp:GridView ID="grd_receipt" runat="server" Width="100%" AutoGenerateColumns="False"
                                DataKeyNames="ledgertype" CssClass="Grid FixedHeader" OnRowDataBound="grd_receipt_RowDataBound" OnSelectedIndexChanged="grd_receipt_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="ledgername" HeaderText="Particulars" />
                                    <asp:BoundField DataField="ledgeramount" HeaderText="Debit" DataFormatString="{0:0.00}">
                                <HeaderStyle Width="150px" />
                                        <ItemStyle HorizontalAlign="Right" CssClass="Textalign1" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ledgeramount" HeaderText="Credit" DataFormatString="{0:0.00}">
                                <HeaderStyle Width="150px" />
                                        <ItemStyle HorizontalAlign="Right" CssClass="Textalign1" Width="150px" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </div>

                    </div>
                    <div class="FormGroupContent4">
                        <div class="right_btn ">
                            <div class="btn ico-back">
                                <asp:Button ID="btn_Previous" Text="Previous" runat="server" ToolTip="Previous" OnClick="btn_Previous_Click" />
                            </div>
                            <div class="btn ico-next">
                                <asp:Button ID="btn_next" Text="Next" runat="server" ToolTip="Next" OnClick="btn_next_Click" />
                            </div>
                            <div class="btn ico-view">
                                <asp:Button ID="btn_view" Text="View" runat="server" ToolTip="View" OnClick="btn_view_Click" />
                            </div>
                            <div class="btn ico-back" id="btn_back1" runat="server">
                                <asp:Button ID="btn_back" runat="server" Text="Back" ToolTip="Back" OnClick="btn_back_Click" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>



    <div class="div_lbl_header">
    </div>
    <div class="div_lbl_vchr">
    </div>
    <div class="div_txt_vchr">
    </div>
    <div class="div_lbl_date">
    </div>
    <div class="div_txt_date">
    </div>
    <div class="div_break">
    </div>
    <div class="div_lbl_to">
    </div>
    <div class="div_txt_to">
    </div>
    <div class="div_lbl_chqdate">
    </div>
    <div class="div_txt_chqdate">
    </div>
    <div class="div_break">
    </div>
    <div class="div_lbl_chqdd">
    </div>
    <div class="div_txt_chqdd">
    </div>
    <div class="div_lbl_bank">
    </div>
    <div class="div_txt_bank">
    </div>
    <div class="div_lbl_branch">
    </div>
    <div class="div_txt_branch">
    </div>
    <div class="div_lbl_clrddate">
    </div>
    <div class="div_txt_clrddate">
    </div>
    <div class="div_break">
    </div>
    <div class="div_lbl_narration">
    </div>
    <div class="div_txt_narration">
    </div>
    <div class="div_lbl_agnstref">
    </div>
    <div class="div_txt_agnstref">
    </div>
    <div class="div_break">
    </div>

    <div class="div_break">
    </div>
    <div class="div_btn_Previous">
    </div>
    <div class="div_btn_View">
    </div>
    <div class="div_btn_next">
    </div>
    <div class="div_btn_back">
    </div>
    <div class="div_break"></div>
    <div>
        <asp:HiddenField ID="hf_chqdate" runat="server" />
        <asp:HiddenField ID="hf_gblvname" runat="server" />
        <asp:HiddenField ID="hf_LogBr_ID" runat="server" />


        <asp:HiddenField ID="hf_flag" runat="server" />
        <asp:HiddenField ID="hf_vid" runat="server" />
        <asp:HiddenField ID="hidfdate" runat="server" />

        <asp:HiddenField ID="hidvoutype" runat="server" />
        <asp:HiddenField ID="hidtdate" runat="server" />

        <asp:HiddenField ID="hid_vou" runat="server" />
        <asp:HiddenField ID="hid_rid" runat="server" />
        <asp:HiddenField ID="NewaspxRpt" runat="server" Value="Y" />
    </div>
</asp:Content>
