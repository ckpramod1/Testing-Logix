<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CHCosting.aspx.cs" Inherits="logix.CHA.CHCosting" %>

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










    <link href="../Styles/CHCosting.css" rel="stylesheet" />
    <link href="../Styles/Costing.css" rel="stylesheet" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>

    <script type="text/javascript">

        function pageLoad(sender, args) {
           $(document).ready(function () {
                $('#<%=Grdcost.ClientID%>').gridviewScroll({
                    width: 882,
                    height: 300,
                    arrowsize: 30,

                    varrowtopimg: "../images/arrowvt.png",
                    varrowbottomimg: "../images/arrowvb.png",
                    harrowleftimg: "../images/arrowhl.png",
                    harrowrightimg: "../images/arrowhr.png"
                });
            });
        }

    </script>

    <style type="text/css">
        .modalBackground {
            background-color: #FFFFFF;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }

        

        .Hide {
            display: none;
        }
        #logix_CPH_popup_Grd_foregroundElement {left:0px!important; top:50px!important;
        }
        #logix_CPH_pln_popup {
    left: 12px !important;
    top: 42px !important;
}
        .modalPopupss {
    background-color: #FFFFFF;
    /*border-width: 1px;
    border-style: solid;
    border-color: #CCCCCC;
    width: 1062px;*/
    width: 97.8%;
    height: 520px;
    margin-left: 1%;
    margin-top: -0.9%;
    /*padding: 1px;
    display: none;*/
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

      <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">Custom Home Agent</a> </li>
              <li><a href="#" title="">Approval</a> </li>
              <li class="current"><a href="#" title="">Costing</a> </li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i><asp:Label ID="lbl_Header" runat="server" Text="Costing" CssClass=""></asp:Label></h4>
                </div>
          <div class="widget-content">
             <div class="FormGroupContent">
                 <div class="JobLabel1N"> <asp:LinkButton ID="lnk_job" runat="server" Style="text-decoration: none;" ForeColor="Red" OnClick="lnk_job_Click">Job #</asp:LinkButton>
</div>
                 <div class="JobNoInput"><asp:TextBox ID="txt_job" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txt_job_TextChanged" placeholder="Job #" ToolTip="JOB NUMBER"></asp:TextBox></div>
                 <div class="DateRightInput"> <asp:TextBox ID="txt_date" runat="server" CssClass="form-control" placeholder="Doc Date" ToolTip="Doc Date"></asp:TextBox></div>
                  <div class="VesselInput3"><asp:TextBox ID="txt_vsl" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                   <div class="MBLInputN13"><asp:TextBox ID="txt_mbl" runat="server" CssClass="form-control" placeholder="MBL" ToolTip="MBL" ReadOnly="True" OnTextChanged="txt_mbl_TextChanged"></asp:TextBox></div>
                     <div class="POLInput3"><asp:TextBox ID="txt_pol" runat="server" CssClass="form-control" placeholder="PoL" ToolTip="PoL" ReadOnly="True"></asp:TextBox></div>
                 </div>
             
              <div class="FormGroupContent">
                  <div class="AgentInput2"><asp:TextBox ID="txt_agent" runat="server" CssClass="form-control" placeholder="Agent" ToolTip="Agent" ReadOnly="True"></asp:TextBox></div>
                  <div class="PODInput4"><asp:TextBox ID="txt_pod" runat="server" CssClass="form-control" placeholder="PoD" ToolTip="PoD" ReadOnly="True" Width="220px"></asp:TextBox></div>
                   <div class="Mode1"><asp:TextBox ID="txt_mode" runat="server" CssClass="form-control" placeholder="Mode" ToolTip="Mode" ReadOnly="True"></asp:TextBox></div>
                  <div class="Mlo2"><asp:TextBox ID="txt_mlo" runat="server" CssClass="form-control" ReadOnly="True" placeholder="MLO" ToolTip="MLO"></asp:TextBox></div>
                  </div>
           
               <div class="FormGroupContent" id="divtxtremark" runat="server">
                    <asp:TextBox ID="txt_remark" runat="server" CssClass="form-control" placeholder="Remarks" ToolTip="Remarks"></asp:TextBox>
                   </div>
              <div class="FormGroupContent MT10">
                  <div  id="div_prealert" runat="server" class="panel_15">
                      <asp:Panel ID="pnlCharge" runat="server" CssClass="Grid FixedHeader"   BorderColor="#999997">
                <asp:GridView CssClass="Grid FixedHeader" ID="Grdcost"  runat="server" AutoGenerateColumns="False"
                    Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="true"  DataKeyNames="vyear" 
                    OnSelectedIndexChanged="Grdcost_SelectedIndexChanged"
                    OnRowDataBound="Grdcost_RowDataBound" >
                    <Columns>
                        <asp:BoundField DataField="vtype" HeaderText="Voucher" />
                        <asp:BoundField DataField="vno" HeaderText="Vou #">
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="vdate" HeaderText="Date" />
                        <asp:BoundField DataField="status" HeaderText="Status" />
                        <asp:BoundField DataField="blno" HeaderText="BL #" />
                        <asp:BoundField DataField="cname" HeaderText="Customer Name" />
                        <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:#,##0.00}" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Custid" HeaderText="Custid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                        <%--<asp:BoundField DataField="vyear" HeaderText="Vouyear" Visible="false"/>--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="Lnk_job" runat="server" CommandName="select" Font-Underline="false"
                                    CssClass="Arrow">⇛</asp:LinkButton>
                                <br />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                    </Columns>

                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>
            </asp:Panel>
                  </div>
                  </div>
              <div class="FormGroupContent">
                     <asp:RadioButtonList ID="rbtcosting" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>With BL</asp:ListItem>
                    <asp:ListItem>Without BL</asp:ListItem>
                </asp:RadioButtonList>
              </div>
               <div class="FormGroupContent">
                   <div class="right_btn MT0 MB05">
                       <div class="btn ico-excel"> <asp:Button ID="btn_Export" runat="server" ToolTip="Export To Excel" OnClick="btn_Export_Click" Visible="False" />



              </div>
                       <div class="btn ico-print">  <asp:Button ID="btn_print" runat="server" ToolTip="Print" OnClick="btn_print_Click" />

             </div>
                       <div class="btn ico-cancel" id="btn_cancel1" runat="server">   <asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click" /></div>
                   </div>
                   </div>
              </div>
         </div>
            </div>
           </div>


      <asp:Panel ID="pln_popup" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
            <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel5" runat="server" CssClass="Gridpnl">

                <asp:GridView ID="Grd_FE" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="Grd_FE_RowDataBound"
                    ForeColor="Black" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" AllowPaging="false" PageSize="20"
                    BackColor="White" OnSelectedIndexChanged="Grd_FE_SelectedIndexChanged" CssClass="Grid FixedHeader"  OnPageIndexChanging="Grd_FE_PageIndexChanging">
                    <Columns>

                        <asp:TemplateField HeaderText="Job #">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                    <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>' ToolTip='<%# Bind("jobno") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="66px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Vessel">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                    <asp:Label ID="Vessel" runat="server" Text='<%# Bind("vslvoy") %>' ToolTip='<%# Bind("vslvoy") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="161px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ETA">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                    <asp:Label ID="ETA" runat="server" Text='<%# Bind("eta") %>' ToolTip='<%# Bind("eta") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="86px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MBL">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                    <asp:Label ID="MBL" runat="server" Text='<%# Bind("mblno") %>' ToolTip='<%# Bind("mblno") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="107px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Agent">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                    <asp:Label ID="Agent" runat="server" Text='<%# Bind("agent") %>' ToolTip='<%# Bind("agent") %>' ></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="161px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MLO">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                    <asp:Label ID="MLO" runat="server" Text='<%# Bind("mlo") %>' ToolTip='<%# Bind("mlo") %>' ></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="161px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="POL">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                    <asp:Label ID="POL" runat="server" Text='<%# Bind("pol") %>' ToolTip='<%# Bind("pol") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="130px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="POD">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                    <asp:Label ID="POD" runat="server" Text='<%# Bind("pod") %>' ToolTip='<%# Bind("pod") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="129px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MODE">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                    <asp:Label ID="mode" runat="server" Text='<%# Bind("mode") %>' ToolTip='<%# Bind("mode") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="66px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <%--<asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_FE" runat="server" CommandName="select" Font-Underline="false"
                                CssClass="Arrow">⇛</asp:LinkButton>
                            <br />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>
                <div class="div_Break"></div>
                <asp:GridView ID="CHGrd" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="CHGrd_RowDataBound"
                    ForeColor="Black" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" AllowPaging="false" PageSize="20" OnPageIndexChanging="CHGrd_PageIndexChanging"
                    BackColor="White" CssClass="Grid FixedHeader"  OnSelectedIndexChanged="CHGrd_SelectedIndexChanged">
                    <Columns>

                        <asp:TemplateField HeaderText="Job #">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 40px">
                                    <asp:Label ID="jobno" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="40px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Doc #">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 90px">
                                    <asp:Label ID="docno" runat="server" Text='<%# Bind("docno") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="90px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                    <asp:Label ID="docdate" runat="server" Text='<%# Bind("docdate") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="80px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MDoc #">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 90px">
                                    <asp:Label ID="mdocno" runat="server" Text='<%# Bind("mdocno") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="90px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Shipper">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 120px">
                                    <asp:Label ID="shipper" runat="server" Text='<%# Bind("shipper") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="120px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Consignee">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 110px">
                                    <asp:Label ID="consignee" runat="server" Text='<%# Bind("consignee") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="110px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="POL">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 90px">
                                    <asp:Label ID="pol" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="90px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="POD">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 90px">
                                    <asp:Label ID="pod" runat="server" Text='<%# Bind("pod") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="90px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MODE">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                    <asp:Label ID="mode" runat="server" Text='<%# Bind("mode") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="60px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <%--<asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_FE" runat="server" CommandName="select" Font-Underline="false"
                                CssClass="Arrow">⇛</asp:LinkButton>
                            <br />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>
                <div class="div_Break"></div>
                <asp:GridView ID="Grd_AE" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="Grd_AE_RowDataBound"
                    ForeColor="Black" EmptyDataText="No Record Found" AllowPaging="false" PageSize="20" CssClass="Grid FixedHeader" 
                    BackColor="White" OnSelectedIndexChanged="Grd_AE_SelectedIndexChanged" OnPageIndexChanging="Grd_AE_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Job #">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 60px">
                                    <asp:Label ID="Job" runat="server" Text='<%# Bind("jobno") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="66px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="flight#" HeaderText="Flight # / Date">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>

                        <asp:BoundField DataField="mawblno" HeaderText="MAWBL">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="mawbldate" HeaderText="BL Date">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Agent">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 190px">
                                    <asp:Label ID="Agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="161px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Air Liner">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 150px">
                                    <asp:Label ID="airline" runat="server" Text='<%# Bind("airline") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="true" Width="161px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="pol" HeaderText="POL">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="pod" HeaderText="POD">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <%--<asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_AE" runat="server" CommandName="select" Font-Underline="false"
                                CssClass="Arrow">⇛</asp:LinkButton>
                            <br />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>
                <asp:GridView ID="Grd_BT" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="Grd_BT_RowDataBound"
                    ForeColor="Black" EmptyDataText="No Record Found" AllowPaging="false" PageSize="20" CssClass="Grid FixedHeader" 
                    BackColor="White" OnSelectedIndexChanged="Grd_BT_SelectedIndexChanged" OnPageIndexChanging="Grd_BT_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="jobno" HeaderText="Job #">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Truck#" HeaderText="truckno">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="From" HeaderText="fromport">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="To" HeaderText="toport">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="etd" HeaderText="etd">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="eta" HeaderText="eta">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <%--<asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_BT" runat="server" CommandName="select" Font-Underline="false"
                                CssClass="Arrow">⇛</asp:LinkButton>
                            <br />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>
            </asp:Panel>
            </div>
        </asp:Panel>
        <asp:ModalPopupExtender ID="popup_Grd" runat="server" PopupControlID="pln_popup"
            TargetControlID="Label1" DropShadow="false" CancelControlID="close">
        </asp:ModalPopupExtender>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:HiddenField ID="hid" runat="server" />
        <asp:HiddenField ID="hid_etd" runat="server" />





</asp:Content>
