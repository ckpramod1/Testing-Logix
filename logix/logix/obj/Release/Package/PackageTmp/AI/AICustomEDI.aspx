<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AICustomEDI.aspx.cs" Inherits="logix.AI.AICustomEDI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css">
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
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
    
    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
    
    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
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

    <link href="../Styles/AICustomEDI.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <style type="text/css">
        a img {
            border: none;
        }

        ol li {
            list-style: decimal outside;
        }

        div#container {
            width: 780px;
            margin: 0 auto;
            padding: 1em 0;
        }

        div.side-by-side {
            width: 100%;
            margin-bottom: 1em;
        }

            div.side-by-side > div {
                float: left;
                width: 50%;
            }

                div.side-by-side > div > em {
                    margin-bottom: 10px;
                    display: block;
                }

        .clearfix:after {
            content: "\0020";
            display: block;
            height: 0;
            clear: both;
            overflow: hidden;
            visibility: hidden;
        }

        

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

     

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .JobInput {
            float: left;
            width: 8%;
            font-size: 11px;
        }

        .Flight1 {
            width: 25%;
            float: left;
            margin: 0px 0.5% 0.5% 0px;
        }

         {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
        }
  
        .div_Grid {
    width: 100%;
    margin-left: 0%;
    margin-top: 0%;
    margin-bottom: 0%;
    margin-right: 0%;
    height: 264px;
    Border: 1px solid #b1b1b1;
    float: left;
}
             /*thead {
                position: relative;
                display: block;
                width: 100%;
                overflow: visible;
            }

             tbody {
                position: relative;
                display: block;
                width: 100%;
                height: 260px;
                overflow: auto;
            }

             th:nth-child(9) {
                min-width: 260px;
            }

             td:nth-child(9) {
                min-width: 260px;
            }

             th:nth-child(10) {
                min-width: 215px;
            }

             td:nth-child(10) {
                min-width: 215px;
            }

             th:nth-child(11) {
                min-width: 120px;
            }

             td:nth-child(11) {
                min-width: 120px;
            }

             th:nth-child(12) {
                min-width: 120px;
            }

             td:nth-child(12) {
                min-width: 120px;
            }

             th:nth-child(13) {
                min-width: 105px;
            }

             td:nth-child(13) {
                min-width: 105px;
            }

             th:nth-child(14) {
                min-width: 130px;
            }

             td:nth-child(14) {
                min-width: 130px;
            }

             th:nth-child(15) {
                min-width: 215px;
            }

             td:nth-child(15) {
                min-width: 215px;
            }

             th:nth-child(16) {
                min-width: 120px;
            }

             td:nth-child(16) {
                min-width: 120px;
            }*/
            .modalPopup {
  background-color: rgba(0, 0, 0, 0.75);
  width: 100%;
  height: 90%;
  margin-left: 0%;
  margin-top: -1%;
  border: 1px solid #b1b1b1;
  display: flex;
  justify-content: center;
  align-items: center;
}
            .DivSecPanel {
  width: 20px;
  height: 20px;
  border: 2px solid white;
  margin-left: 98.3%;
  margin-top: 0%;
  border-radius: 90px 90px 90px 90px;
}
.divRoated {
  width: 90%;
  height: 75vh;
  overflow: hidden;
  background: #fff;
  border-radius: 3px;
}

.Gridpnl {
  width: 99% !important;
  height: 91%;
  border: 1px solid #b1b1b1;
  margin: 0 auto !important;
  overflow-y: scroll;
  overflow-x: auto;

}
.widget.box {
    position: relative;
    top: -8px;
}
 
.Flight3 {
    width: 25%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.Flight4 {
    width: 23.5%;
    float: left;
    margin: 0px 0px 0px 0px;

}
a#logix_CPH_lnkjob {
    background: #dedcdc;
    padding: 3px 10px;
    border-radius: 3px;
    margin: 13px 0 0 0px;
    display: inline-block;
}
.Filename1 {
    width: 25%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
 
    </style>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {

                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            });
        }
    </script>
    <style type="text/css">
        #programmaticModalPopupBehavior1_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }
        .gridpnl {
    height: calc(100vh - 355px);
}
        div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 45px !important;
}
        .widget.box .widget-content {
    top: 0px !important;
    padding-top: 45px !important;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <asp:Panel ID="Panel1" runat="server">

        <!-- /Breadcrumbs line -->

        <div >
            <div class="col-md-12">

                <div class="widget box" runat="server">

                    <div class="widget-header">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lbl_Header" runat="server" Text="Custom EDI"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
        <div class="crumbs">
            <ul id="breadcrumbs" class="breadcrumb">
                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                <li><a href="#" title="">Customer Support</a> </li>
                <li><a href="#" id="HeaderLabel1" runat="server"></a></li>
                <li class="current"><a href="#" title="">Custom EDI</a> </li>
            </ul>
        </div>
                    </div>
                    <div class="widget-content">
                        <div class="FormGroupContent4 FixedButtons">
                               <div class="right_btn">
                                <div class="btn ico-igm-1-5">
                                    <asp:Button ID="btnedi" runat="server" Text="EDI 1.5" ToolTip="EDI 1.5" TabIndex="5" OnClick="btnedi_Click" />
                                </div>
                                <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                    <asp:Button ID="btncancel" runat="server" Text="Cancel" ToolTip="Cancel" TabIndex="14" OnClick="btncancel_Click" />
                                </div>
                            </div>
                        </div>
                     
                        <div class="FormGroupContent4 ">

                            <div class="JobInput">
                                <span>Job #</span>
                                
                                <asp:TextBox ID="txtjobno" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="1" onkeypress="return isNumberKey(event,'Job #');" OnTextChanged="txtjobno_TextChanged"></asp:TextBox>
                            </div>
                                <asp:LinkButton ID="lnkjob" runat="server" CssClass="anc ico-find-sm" ForeColor="#FF3300" Text="" OnClick="lnkjob_Click"></asp:LinkButton>
                        </div>
                    
                        <div class="FormGroupContent4 boxmodal">
                            <div class="Mawbl1">
                                <asp:Label ID="Label1" runat="server" Text="MAWBL #"> </asp:Label>
                                <asp:TextBox ID="txtMAWBLno" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="2" placeholder="" ToolTip="MAWBL #"></asp:TextBox>
                            </div>
                            <div class="Mawbl2">
                                <asp:Label ID="Label2" runat="server" Text="Date (ddMMyyyy)"> </asp:Label>
                                <asp:TextBox ID="txtmawbldate" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="2" placeholder="" ToolTip="Date (ddMMyyyy)"></asp:TextBox>
                            </div>
                            <div class="Mawbl3">
                                <asp:Label ID="Label3" runat="server" Text="Mode"> </asp:Label>
                                <asp:DropDownList data-placeholder="Mode" ID="ddlmode" runat="server" ToolTip="Mode" AutoPostBack="True" Width="100%" TabIndex="3" CssClass="chzn-select" OnSelectedIndexChanged="ddlmode_SelectedIndexChanged">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    <asp:ListItem>PART SHIPMENT</asp:ListItem>
                                    <asp:ListItem>TOTAL SHIPMENT</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="Flight1">
                                <asp:Label ID="Label4" runat="server" Text="Flight #"> </asp:Label>
                                <asp:TextBox ID="txtflight" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="2" placeholder="" ToolTip="Flight #"></asp:TextBox>
                            </div>
                            <div class="Flight2">
                                <asp:Label ID="Label5" runat="server" Text="Date (ddMMyyyy)"> </asp:Label>
                                <asp:TextBox ID="txtflightdate" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="2" placeholder="" ToolTip="Date (ddMMyyyy)"></asp:TextBox>
                            </div>
                            <div class="Flight3">
                                <asp:Label ID="Label6" runat="server" Text="IGM #"> </asp:Label>
                                <asp:TextBox ID="txtigm" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="2" placeholder="" ToolTip="IGM #"></asp:TextBox>
                            </div>
                            <div class="Flight4">
                                <asp:Label ID="Label7" runat="server" Text="Date (ddMMyyyy)"> </asp:Label>
                                <asp:TextBox ID="txtigmdate" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="2" placeholder="" ToolTip="Date (ddMMyyyy)"></asp:TextBox>
                            </div>
                        </div>

                        <div class="FormGroupContent4 boxmodal">
                            <asp:Panel ID="pnlCharge" runat="server" CssClass="gridpnl MT0 MB0" ScrollBars="Auto">
                                <asp:GridView ID="grd" TabIndex="13" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="Black" PageSize="3" AllowPaging="false" CssClass="Grid FixedHeader" OnRowDataBound="grd_RowDataBound" OnPreRender="grd_PreRender">
                                    <Columns>
                                        <asp:BoundField DataField="carrno" HeaderText="AgentCode" ControlStyle-CssClass="hide">
                                            <HeaderStyle CssClass="hide" />
                                            <ItemStyle CssClass="hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="branchcode" HeaderText="CustomCode" ControlStyle-CssClass="hide">
                                            <HeaderStyle CssClass="hide" />
                                            <ItemStyle CssClass="hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="flightno" HeaderText="Flight #" ControlStyle-CssClass="hide">
                                            <HeaderStyle CssClass="hide" />
                                            <ItemStyle CssClass="hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="flightdate" HeaderText="Flightdate" ControlStyle-CssClass="hide">
                                            <HeaderStyle CssClass="hide" />
                                            <ItemStyle CssClass="hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="manifestno" HeaderText="IGM NO" ControlStyle-CssClass="hide">
                                            <HeaderStyle CssClass="hide" />
                                            <ItemStyle CssClass="hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="manifestdate" HeaderText="IGMDATE" ControlStyle-CssClass="hide">
                                            <HeaderStyle CssClass="hide" />
                                            <ItemStyle CssClass="hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="mawblno" HeaderText="mawblno" ControlStyle-CssClass="hide">
                                            <HeaderStyle CssClass="hide" />
                                            <ItemStyle CssClass="hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="mawbldate" HeaderText="mawbldate" ControlStyle-CssClass="hide">
                                            <HeaderStyle CssClass="hide" />
                                            <ItemStyle CssClass="hide" />
                                        </asp:BoundField>

                                        <%--Text='<%# Bind("issuedon") %>'--%>
                                        <asp:BoundField DataField="hawblno" HeaderText="HAWBL #">
                                            <ControlStyle Width="700px" />
                                            <HeaderStyle Width="150px" />
                                            <ItemStyle HorizontalAlign="Left" Width="150px"  />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="H.Date">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                                    <asp:Label ID="lbldate" runat="server" HtmlEncode="false" Text='<%# Eval("issuedon", "{0:ddMMyyyy}") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" Width="50px" />
                                            <ItemStyle HorizontalAlign="Right" Width="30px" Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="polcode" HeaderText="From Code">
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="podcode" HeaderText="To Code">
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="noofpkgs" HeaderText="No. Pkgs" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Width="55px" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="grwt" HeaderText="Gr.Weight" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <%--   <asp:BoundField DataField="descn" HeaderText="Descn.">
           <HeaderStyle HorizontalAlign="Center" Width="150px" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>--%>
                                        <asp:TemplateField HeaderText="Descn.">
                                            <ItemTemplate>
                                                <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                                    <asp:Label ID="lbldesc" runat="server" Text='<%# Bind("descn") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" Width="200px" />
                                            <ItemStyle HorizontalAlign="Right" Width="200px" Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Select">
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Chk_select" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <RowStyle Font-Italic="False" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                        <div class="FormGroupContent4 boxmodal">
                            <div class="Filename1">
                                <asp:Label ID="Label8" runat="server" Text="File Name"> </asp:Label>
                                <asp:TextBox ID="txtfile" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="1" placeholder="" ToolTip="File Name"></asp:TextBox>
                            </div>
                         
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </asp:Panel>

    <asp:Label ID="lblAI" runat="server"></asp:Label>

    <ajaxtoolkit:ModalPopupExtender ID="popmodelJobAI" runat="server" TargetControlID="lblAI" BehaviorID="programmaticModalPopupBehavior1"
        PopupControlID="pnlJobAE" OkControlID="imgfgok" DropShadow="false">
    </ajaxtoolkit:ModalPopupExtender>

    <asp:Panel ID="pnlJobAE" runat="server" CssClass="modalPopup"   Style="display: none;">
        <div class="divRoated">
        <div class="DivSecPanel">
            <asp:Image ID="imgfgok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
        </div>

        <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">
            <%--   <div id="controlHead">PopupDragHandleControlID="GrdCreditAmt" </div>--%>
            <asp:GridView ID="grdAIE" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False" BackColor="White" ForeColor="Black" AllowPaging="false" PageSize="15"
                Width="100%" CssClass="Grid FixedHeader"  OnRowDataBound="grdAIE_RowDataBound" OnSelectedIndexChanged="grdAIE_SelectedIndexChanged" OnPageIndexChanging="grdAIE_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="jobno" HeaderText="Job #">
                        <ControlStyle Width="700px" />
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                    </asp:BoundField>
                    <%-- <asp:BoundField DataField="flightdate" HeaderText="Flight# / Date">
    <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="30px"/>
    <ItemStyle HorizontalAlign="Left" Width="100px"/>
    </asp:BoundField>--%>
                    <asp:TemplateField HeaderText="Flight# / Date" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                <asp:Label ID="Customer" runat="server" Text='<%# Bind("flightdate") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center" />
                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>

                    </asp:TemplateField>

                    <asp:BoundField DataField="mawblno" HeaderText="MAWBL#">
                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                        <ItemStyle HorizontalAlign="Left" Width="90px" />
                    </asp:BoundField>
                    <%-- <asp:BoundField DataField="agentname" HeaderText="Agent" >
        <HeaderStyle HorizontalAlign="Center" Width="200px" />
        <ItemStyle HorizontalAlign="Left" Width="200px" />
        </asp:BoundField>--%>

                    <asp:TemplateField HeaderText="Agent" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <div style="overflow: hidden; text-overflow: ellipsis; width: 200px">
                                <asp:Label ID="Customer" runat="server" Text='<%# Bind("agentname") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle Wrap="false" Width="203px" HorizontalAlign="Center" />
                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>

                    </asp:TemplateField>
                    <%-- <asp:BoundField DataField="airline" HeaderText="AirLine">
        <HeaderStyle Width="200px" />
        <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>--%>
                    <asp:TemplateField HeaderText="AirLine" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <div style="overflow: hidden; text-overflow: ellipsis; width: 190px">
                                <asp:Label ID="Customer" runat="server" Text='<%# Bind("airline") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle Wrap="false" Width="193px" HorizontalAlign="Center" />
                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>

                    </asp:TemplateField>

                    <asp:BoundField DataField="FROMport" HeaderText="PoL">
                        <HeaderStyle Width="130px" />
                        <ItemStyle HorizontalAlign="Left" Width="130px" />
                    </asp:BoundField>

                    <asp:BoundField DataField="toport" HeaderText="PoD">
                        <HeaderStyle Width="130px" />
                        <ItemStyle HorizontalAlign="Left" Width="130px" />
                    </asp:BoundField>

                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <PagerStyle CssClass="GridviewScrollPager" />
            </asp:GridView>

        </asp:Panel>
            </div>
        <div class="Break"></div>

        <%--    </div>--%>
    </asp:Panel>
    <asp:HiddenField ID="hid_date" runat="server" />
    <asp:HiddenField ID="hdncustomcode" runat="server" />
    <asp:HiddenField ID="hdnagentcode" runat="server" />
</asp:Content>
