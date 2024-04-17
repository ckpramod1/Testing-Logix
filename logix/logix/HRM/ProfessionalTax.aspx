<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="ProfessionalTax.aspx.cs" Inherits="logix.HRM.ProfessionalTax" %>

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





    <link href="../Styles/ProfessionalTax.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <style type="text/css">
        .hide
        {
            display:none;
        }
        .ProDate {
    float: left;
    margin: 0 0.5% 0 0;
    width: 6%;
}
        .Protax {
    float: left;
    margin: 0 0.5% 0 0;
    width: 25%;
}
        .ProAll {
    float: left;
    margin: 0 0 0 0;
    width: 4%;
}
        .div_Month label {display:inline-block; margin:0px 0px 0px 5px;
        }
        .ProAll label {display:inline-block; margin:0px 0px 0px 5px;
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
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txt_Branch.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_bid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetBranch",
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

                        $("#<%=hid_bid.ClientID %>").val(i.item.val);
                        $("#<%=txt_Branch.ClientID %>").change();

                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=hid_bid.ClientID %>").val(i.item.val);
                            $("#<%=txt_Branch.ClientID %>").val(i.item.label);
                        }
                        else {
                            $("#<%=hid_bid.ClientID %>").val(0);
                        }
                    },
                    focus: function (e, i) {
                        $("#<%=hid_bid.ClientID %>").val(i.item.val);
                        $("#<%=txt_Branch.ClientID %>").val(i.item.label);
                    },
                    close: function (e, i) {
                        if (i.item) {
                            $("#<%=hid_bid.ClientID %>").val(i.item.val);
                            $("#<%=txt_Branch.ClientID %>").val(i.item.label);
                        }
                    },
                    minLength: 1
                });
            });
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

       <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">IT Workings</a> </li>
              <li class="current">Professional Tax</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->

     
     <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/taxslab_ic.png" /><asp:Label ID="lbl_Header" runat="server" Text="ProfessionalTax"></asp:Label>
       
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">
             <div class="FormGroupContent4">
                 <div class="ProBranch">
                     
                     <div class="LabelWidth">Branch</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_Branch" TabIndex="1" runat="server" AutoPostBack="True" OnTextChanged="txt_Branch_TextChanged" CssClass="form-control" placeholder="" ToolTip="Branch"> </asp:TextBox></div>
                     </div>
                 <div class="ProDate">
                     <div class="LabelWidth">Valid From</div>
                     <div class="FieldInput"> <asp:TextBox ID="txt_ValidFrom" TabIndex="2" runat="server" CssClass="form-control" placeholder="" ToolTip="Valid From"></asp:TextBox></div>
                    </div>
                  <div class="ProDate">
                      <div class="LabelWidth">Valid To</div>
                      <div class="FieldInput"><asp:TextBox ID="txt_ValidTo" runat="server" TabIndex="3" CssClass="form-control" placeholder="" ToolTip="Valid To"></asp:TextBox></div>
                      </div>
                 <div class="Protax">
                     <div class="LabelWidth">Prof.Tax</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_Tax" runat="server" TabIndex="4" CssClass="form-control" placeholder="" ToolTip="Professional Tax"></asp:TextBox></div>
                     </div>
                 <div class="ProSlab">
                     <div class="LabelWidth">Slab From</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_Slabfrom" runat="server" TabIndex="5" CssClass="form-control" placeholder="" ToolTip="Slab From"></asp:TextBox></div>

                     </div>
                 <div class="ProTo">
                     <div class="LabelWidth">Slab To</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_SlabTo" runat="server" TabIndex="6" CssClass="form-control" placeholder="" ToolTip="Slab To"></asp:TextBox></div>
                     </div>
                 <div class="ProCategory">  
                     <div class="LabelWidth">Category</div>
                     <div class="FieldInput"> <asp:DropDownList ID="ddl_Category" TabIndex="7" runat="server" CssClass="chzn-select" Data-placeholder="Category" ToolTip="Category" onselectedindexchanged="ddl_Category_SelectedIndexChanged" 
            AutoPostBack="True">
            <asp:ListItem Value="0" Text=""></asp:ListItem>
            <asp:ListItem Value="M" Text="Male"></asp:ListItem>
            <asp:ListItem Value="F" Text="Female"></asp:ListItem>
             <asp:ListItem Value="B" Text="Both"></asp:ListItem>
        </asp:DropDownList></div>
                    </div>
                 <div class="ProAll MTCtrl6"><asp:CheckBox ID="Chk_All" TabIndex="8" runat="server" Text="ALL" AutoPostBack="True" OnCheckedChanged="Chk_All_CheckedChanged" /></div>
                 </div>
                <div class="FormGroupContent4">
                    <div class="div_Month">
                     <asp:CheckBoxList ID="Chk_Month" runat="server" RepeatColumns="3" TabIndex="9" RepeatDirection="Horizontal"
            Width="100%">
            <asp:ListItem Value="1">January</asp:ListItem>
            <asp:ListItem Value="2">February</asp:ListItem>
            <asp:ListItem Value="3">March</asp:ListItem>
            <asp:ListItem Value="4">April</asp:ListItem>
            <asp:ListItem Value="5">May</asp:ListItem>
            <asp:ListItem Value="6">June</asp:ListItem>
            <asp:ListItem Value="7">July</asp:ListItem>
            <asp:ListItem Value="8">August</asp:ListItem>
            <asp:ListItem Value="9">September</asp:ListItem>
            <asp:ListItem Value="10">October</asp:ListItem>
            <asp:ListItem Value="11">November</asp:ListItem>
            <asp:ListItem Value="12">December</asp:ListItem>
        </asp:CheckBoxList>
                    </div>
                    </div>
              <div class="bordertopNew"></div>
              <div class="FormGroupContent4">
                  <div class="right_btn MT0 MB05">
                      <div class="btn ico-save" id="btn_Save1" runat="server"> <asp:Button ID="btn_Save" TabIndex="10" runat="server" ToolTip="Save"  onclick="btn_Save_Click" /></div>
                      <div class="btn ico-view"><asp:Button ID="btn_view" TabIndex="11" runat="server" ToolTip="View" OnClick="btn_view_Click" /></div>
                      <div class="btn ico-cancel" id="btn_Clear1" runat="server"><asp:Button ID="btn_Clear" TabIndex="12" runat="server" ToolTip="Cancel" OnClick="btn_Clear_Click" /></div>
                  </div>
                  </div>
              <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                   <div class="div_Grid">
        <asp:GridView ID="Grd_Tax" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl" OnRowDataBound="Grd_Tax_RowDataBound"
            Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="True" DataKeyNames="tid" OnSelectedIndexChanged="Grd_Tax_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="validfrom" HeaderText="Valid From" />               
                <asp:BoundField DataField="validto" HeaderText="Valid To" />
                <asp:BoundField DataField="slabfrom" HeaderText="Slab From" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="slabto" HeaderText="Slab To" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="taxamount" HeaderText="TaxAmount" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                 <asp:BoundField DataField="category" HeaderText="category" ControlStyle-CssClass="hide" ItemStyle-CssClass="TxtAlign1">
                     <HeaderStyle Wrap="false" CssClass="hide" HorizontalAlign="Center"  />
                     <ItemStyle Font-Bold="false" HorizontalAlign="Justify" CssClass="hide"/>
                </asp:BoundField>
                <%-- <asp:BoundField DataField="tid" HeaderText="tid" ControlStyle-CssClass="hide">
                     <HeaderStyle Wrap="false" CssClass="hide" HorizontalAlign="Center"  />
                     <ItemStyle Font-Bold="false" HorizontalAlign="Justify" CssClass="hide"/>
                </asp:BoundField>--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="Img_Edudelete" runat="server" CommandName="select"
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
            </div>

         <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>ProfessionalTax #</label>

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







    <asp:HiddenField ID="hid_bid" runat="server" />
    <asp:HiddenField ID="hid_Taxid" runat="server" />
    <asp:HiddenField ID="hid_confirm" runat="server" />
    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_ValidFrom">
    </asp:CalendarExtender>
    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_ValidTo">
    </asp:CalendarExtender>
</asp:Content>
