<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="DownloadDoc.aspx.cs" Inherits="logix.Corporate.DownloadDoc" %>

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
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <%--<a href="DownloadDoc.aspx">DownloadDoc.aspx</a>--%>
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript" src="../Theme/Content/assets/js/custom.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/demo/form_components.js"></script>










    <link href="../Styles/DownloadDoc.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            });
        }
    </script>
    <style type="text/css">
        .hide {
            display: none;
        }

        #logix_CPH_ddl_branch_chzn {
            width: 100% !important;
        }

        #logix_CPH_ddl_product_chzn {
            width: 100% !important;
        }

        .div_panel {
            width: 100%;
            max-height: 223px;
            overflow: auto;
        }

        .div_Grid1 {
            width: 100%;
            margin-top: 0.1%;
            margin-left: 0%;
            max-height: 200px;
            border: 1px solid gray;
            margin-bottom: 1%;
            overflow: auto;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        .FormGroupContent4 span {
            color: #000080;
            font-size: 11px;
        }

        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        .JobInput11 {
           width: 6%;
    float: left;
    margin: 0px 0.5% 0px 0px;
        }

      .bordertopNew {
    margin: 5px 0 5px 0 !important;
}
      
  .widget.box .widget-content {
    top: 0;
}
  table#logix_CPH_grdjobno td:nth-child(8) {
    max-width: 175px;
    overflow: hidden;
    text-overflow: ellipsis;
}
  .jobNumber {
    float: left;
        margin-right: 10px;
}
  .BranchDrop1 {
    width: 11%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
  .ForwardExport {
    width: 15%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
  .gridpnl {
    height: calc(100vh - 185px);
}
    </style>
    <script type="text/javascript">
        function ConfirmationBox() {
            var result = confirm('Do you Want to delete this Details?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    
    <!-- /Breadcrumbs line -->


    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:Label ID="lbl_Header" runat="server" Text=" Document DownLoad"></asp:Label></h4>
                    <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Shipment Details</a> </li>
            <li class="current"><a href="#" title="">Document Repository</a> </li>
        </ul>
    </div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4 hide">
                        <asp:Label ID="Label1" runat="server" Text="Division"> </asp:Label>
                        <asp:DropDownList ID="ddl_division" runat="server" AppendDataBoundItems="True" CssClass="chzn-select" data-placeholder="Division" ToolTip="Division"></asp:DropDownList>
                        </div>
                    </div>

                  

                    <div class="FormGroupContent4 boxmodal">
                        <div class="JobInput11 LinkButton">
                            <span>Job #</span>                  

                            <asp:TextBox ID="txt_job" TabIndex="1" runat="server" AutoPostBack="True" CssClass="form-control" placeholder="" ToolTip="JOB NUMBER" OnTextChanged="txt_job_TextChanged"></asp:TextBox>
                        </div>
                             <asp:LinkButton ID="lnk_job" runat="server" CssClass="anc ico-find-sm" ForeColor="#FF3300" TabIndex="2" Style="text-decoration: none" OnClick="lnk_job_Click"></asp:LinkButton>

                        <div class="BranchDrop1">
                            <asp:Label ID="Label2" runat="server" Text="Branch"> </asp:Label>
                            <asp:DropDownList ID="ddl_branch" AutoPostBack="true" runat="server" AppendDataBoundItems="True" TabIndex="3" CssClass="chzn-select" data-placeholder="Branch" ToolTip="Branch" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged">
                                <%--<asp:ListItem Text="" Value="0"></asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                        <div class="ForwardExport">
                            <asp:Label ID="Label3" runat="server" Text="Product"> </asp:Label>
                            <asp:DropDownList ID="ddl_product" runat="server" AppendDataBoundItems="True" CssClass="chzn-select" TabIndex="4"
                                AutoPostBack="True" data-placeholder="Product" ToolTip="Product" OnSelectedIndexChanged="ddl_product_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>
                                <%--<asp:ListItem Text="ALL" Value="0"></asp:ListItem>--%>
                                <asp:ListItem Text="Air Exports"></asp:ListItem>
                                <asp:ListItem Text="Air Imports"></asp:ListItem>
                                <asp:ListItem Text="Custom House Agent"></asp:ListItem>
                                <asp:ListItem Text="Ocean Exports"></asp:ListItem>
                                <asp:ListItem Text="Ocean Imports"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        
                    </div>

                    <div class="FormGroupContent4 boxmodal">


                    <div class="gridpnl">
                        <asp:Panel ID="Panel1" runat="server" >
                        
                                <asp:GridView ID="grdbudget" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader" ForeColor="Black" OnRowDataBound="grdbudget_RowDataBound" OnSelectedIndexChanged="grdbudget_SelectedIndexChanged" ShowHeaderWhenEmpty="true" Width="100%" OnRowCommand="grdbudget_RowCommand" OnRowDeleting="grdbudget_RowDeleting" OnPreRender="grdbudget_PreRender">
                                    <Columns>
                                        <asp:BoundField DataField="docname" HeaderText="Document">
                                            <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="remarks" HeaderText="Remarks">
                                            <HeaderStyle HorizontalAlign="Left" Wrap="true" Width="370px" />
                                            <ItemStyle HorizontalAlign="Left" Width="370px" />
                                        </asp:BoundField>
                                        <asp:BoundField ControlStyle-CssClass="hide" DataField="doctype" HeaderText="docid">
                                            <HeaderStyle CssClass="hide" HorizontalAlign="Left" Wrap="true" />
                                            <ItemStyle CssClass="hide" HorizontalAlign="Left" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="docid" HeaderText="dcmtid">
                                            <HeaderStyle CssClass="hide" HorizontalAlign="Left" Wrap="true" Width="350px" />
                                            <ItemStyle CssClass="hide" HorizontalAlign="Left" Width="350px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="fileloc" HeaderText="Filename Details">
                                            <HeaderStyle HorizontalAlign="Left" Wrap="true" Width="350px" />
                                            <%-- CssClass="hide"--%>
                                            <ItemStyle HorizontalAlign="Left" Width="350px" />
                                            <%--  CssClass="hide"--%>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="Img_Delete" runat="server" CommandName="Delete"
                                                    ImageUrl="~/images/delete.jpg" />
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" HorizontalAlign="right" Width="20px" />
                                            <ItemStyle Font-Bold="false" Width="20px" HorizontalAlign="Justify" />

                                        </asp:TemplateField>
                                        <asp:BoundField DataField="docupdon" HeaderText="Uploaded On">
                                            <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="empname" HeaderText="Uploaded By">
                                            <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        </asp:BoundField>

                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>

                              <asp:Panel ID="Panel2" runat="server" >
                            <asp:GridView CssClass="Grid FixedHeader" ID="GrdAEI" runat="server" AutoGenerateColumns="False" Width="100%"
                                ForeColor="Black" EmptyDataText="No Record Found" OnRowDataBound="GrdAEI_RowDataBound" OnSelectedIndexChanged="GrdAEI_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="jobno" HeaderText="Job #">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="airline" HeaderText="AirLine">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="300px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="mawblno" HeaderText="MAWBL #">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="flightdate" HeaderText="Flight">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="agentname" HeaderText="Agent">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="300px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="status" HeaderText="Status">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="120px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FromPort" HeaderText="FromPort">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="toport" HeaderText="To Port">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="150px" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                            <div class="div_Break"></div>

                        </asp:Panel>

                            
                 
                        <asp:Panel ID="Panel3" runat="server">
                            <asp:GridView CssClass="Grid FixedHeader" ID="grdCH" runat="server" AutoGenerateColumns="False" Width="100%"
                                ForeColor="Black" EmptyDataText="No Record Found" OnRowDataBound="grdCH_RowDataBound" OnSelectedIndexChanged="grdCH_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="jobno" HeaderText="Job #">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="jobtype" HeaderText="Job Type">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="docno" HeaderText="Doc #">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="docdate" HeaderText="Doc Date">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="mode" HeaderText="Mode">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                            <div class="div_Break"></div>

                        </asp:Panel>
          
                        <asp:Panel ID="Panel4" runat="server" >
                            <asp:GridView CssClass="Grid FixedHeader" ID="grdview" runat="server" AutoGenerateColumns="False" Width="100%"
                                ForeColor="Black" EmptyDataText="No Record Found" OnRowDataBound="grdview_RowDataBound" OnSelectedIndexChanged="grdview_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="jobno" HeaderText="Job #">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vessel" HeaderText="VesselName">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="voyage" HeaderText="Voyage">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="mblno" HeaderText="MBL #">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="etd" HeaderText="ETD">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="sd" HeaderText="Destination">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="eta" HeaderText="ETA">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="mlo" HeaderText="MLO">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" Wrap="false" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                            <div class="div_Break"></div>

                        </asp:Panel>

                        <asp:Panel ID="Panel5" runat="server" CssClass="" >
                            <asp:GridView CssClass="Grid FixedHeader" ID="grdjobno" runat="server" AutoGenerateColumns="False" Width="100%"
                                ForeColor="Black" EmptyDataText="No Record Found" OnRowDataBound="grdjobno_RowDataBound" OnSelectedIndexChanged="grdjobno_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="jobno" HeaderText="Job #">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vesselname" HeaderText="VesselName">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="voyage" HeaderText="Voyage">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="mblno" HeaderText="MBL #">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="eta" HeaderText="ETA">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="etd" HeaderText="ETB">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pol" HeaderText="POL">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="agent" HeaderText="Agent">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="mlo" HeaderText="MLO/FFR">
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                            <div class="div_Break"></div>

                        </asp:Panel>
                        </asp:Panel>

                  
                      
             
                    </div>
                        </div>

                   
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hid_poddownload" runat="server" />








</asp:Content>
