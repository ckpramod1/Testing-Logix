<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="TransferFromFIBL.aspx.cs" Inherits="logix.ShipmentDetails.TransferFromFIBL" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

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

    <link href="../Styles/TransferFromFIBL.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <%-- <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>--%>
    <style type="text/css">
        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .DivSecPanel {
            width: 20px;
            Height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: -0.85%;
            border-radius: 90px 90px 90px 90px;
        }

        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        #logix_CPH_mdl_FIJob_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        #logix_CPH_mdl_BTJob_foregroundElement {
            left: 0px !important;
            top: 50px !important;
        }

        .modalPopupss {
            background-color: #FFFFFF;
            /*border-width: 1px;
    border-style: solid;
    border-color: #CCCCCC;
    width: 1062px;*/
            width: 97.5%;
            height: 535px;
            margin-left: 1%;
            margin-top: -0.9%;
            /*padding: 1px;
    display: none;*/
        }
        .JboLabel1 {
    width: 7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        /*New Design - Buttons*/


div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
       .gridpnl {
    height: calc(100vh - 180px);
}


   
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- /Breadcrumbs line -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <h4 class="hide"><i class="icon-umbrella"></i>
                        <asp:label id="lbl_Header" runat="server" text=""></asp:label>
                    </h4>
                    <!-- Breadcrumbs line -->
                    <div class="crumbs">
                        <ul id="breadcrumbs" class="breadcrumb">
                            <li><i class="icon-home"></i><a href="#"></a>Home </li>
                            <li id="opslbli" runat="server"><a href="#" title="" id="opslbl" runat="server">Documentation</a></li>
                            <li><a href="#" title="" id="HeaderLabel1" runat="server">Ocean Imports</a> </li>
                            <li><a href="#" title="" id="menu" runat="server">Shipment Details</a> </li>
                            <li class="current"><a href="#" title="" id="header" runat="server">Transfer From FIBL</a> </li>
                        </ul>
                    </div>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4 FixedButtons">
                         <div class="right_btn">
                            <div class="btn ico-transfer-to-bt">
                                <asp:button id="btn_trans" runat="server" Text="Transfer" tooltip="Transfer" onclick="btn_trans_Click" />
                            </div>
                            <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                <asp:button id="btn_cancel" runat="server"  text="Cancel" tooltip="Cancel" onclick="btn_cancel_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="JboLabel1">
                            <span>Job #</span>
                            
                            <asp:TextBox id="txt_job" runat="server" cssclass="form-control" autopostback="True" ontextchanged="txt_job_TextChanged" placeholder="" tooltip="Job Number"></asp:TextBox>
                        </div>
                         <div class=" boxmodalLink_box">

                    <asp:LinkButton id="lnk_job" runat="server" CssClass="anc ico-find-sm" forecolor="#FF3300" style="text-decoration: none;" onclick="lnk_job_Click"></asp:LinkButton>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <div class="gridpnl">
                            <asp:gridview id="grd_fibl" cssclass="Grid FixedHeader" runat="server" autogeneratecolumns="False" onrowdatabound="grd_fibl_RowDataBound"
                                width="100%" forecolor="Black" emptydatatext="No Record Found" showheaderwhenempty="true" onprerender="grd_fibl_PreRender">
                <Columns>
                <asp:BoundField DataField="blno" HeaderText="SB/BL #" />
                <asp:BoundField DataField="bldate" HeaderText="SB/BL Date" />
                <asp:BoundField DataField="consignee" HeaderText="Consignee" />
                <asp:BoundField DataField="noofpkgs" HeaderText="No.Of.Pkgs" />
                <asp:BoundField DataField="descn" HeaderText="PkgType" />
                <asp:BoundField DataField="weight" HeaderText="Weight" />
                <asp:BoundField DataField="cbm" HeaderText="CBM" />
                <asp:BoundField DataField="fd" HeaderText="Place of Delivery" />
                <%--<asp:CheckBoxField DataField="sel" />--%>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:CheckBox ID="chk_select" runat="server"/>
                         <%--Checked=' <%# (Boolean.Parse(Eval("sel").ToString()))%> '--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
           <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
                     <PagerStyle CssClass="GridviewScrollPager" />
            </asp:gridview>
                            <%-- </asp:Panel>--%>
                        </div>
                    </div>
                 
                </div>
            </div>
        </div>
    </div>
    <div class="div_Break"></div>

    <asp:panel id="pnl_FIJob" runat="server" cssclass="modalPopup" style="display: none;">
        <div class="divRoated">
        <div class="DivSecPanel"> <asp:Image ID="img_grd_FIJob" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%"/>  </div>
             
     <asp:Panel ID="Panel2" runat="server"   CssClass="Gridpnl">

       <asp:GridView ID="grd_FIJob" runat="server" CssClass="Grid FixedHeader"  AutoGenerateColumns="False" Width="100%" ForeColor="Black" OnRowDataBound="grd_FIJob_RowDataBound"
            EmptyDataText="No Record Found" PageSize="20" BackColor="White" 
           AllowPaging="false" OnPageIndexChanging="grd_FIJob_PageIndexChanging" onselectedindexchanged="grd_FIJob_SelectedIndexChanged" >
           <Columns>
                                      
                    <asp:BoundField DataField="jobno" HeaderText="Job #" HeaderStyle-Width="45px">
                     <ItemStyle HorizontalAlign="Left" width="45px"/>
                    </asp:BoundField>
                
                    <asp:TemplateField HeaderText ="Vessel" HeaderStyle-ForeColor="White">
                     <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:80px">
                       <asp:Label ID="vesselname" runat="server" Text='<%# Bind("vesselname") %>'></asp:Label>
                    </div>
                    </ItemTemplate>
                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center"  />
                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>                      
                     </asp:TemplateField>
                  
                    <asp:TemplateField HeaderText ="Voyage" HeaderStyle-ForeColor="White">
                     <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:80px">
                       <asp:Label ID="voyage" runat="server" Text='<%# Bind("voyage") %>'></asp:Label>
                    </div>
                    </ItemTemplate>
                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center"  />
                    <ItemStyle Wrap="false" HorizontalAlign="Left" ></ItemStyle>                      
                     </asp:TemplateField>
                   <asp:TemplateField HeaderText ="MBL #" HeaderStyle-ForeColor="White">
                     <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:80px">
                       <asp:Label ID="mblno" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                    </div>
                    </ItemTemplate>
                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center"  />
                    <ItemStyle Wrap="false" HorizontalAlign="Left" ></ItemStyle>                      
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText ="ETA" HeaderStyle-ForeColor="White">
                     <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:80px">
                       <asp:Label ID="eta" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                    </div>
                    </ItemTemplate>
                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center"  />
                    <ItemStyle Wrap="false" HorizontalAlign="Left" ></ItemStyle>                      
                     </asp:TemplateField>
                    <asp:TemplateField HeaderText ="ETB" HeaderStyle-ForeColor="White">
                     <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:80px">
                       <asp:Label ID="etd" runat="server" Text='<%# Bind("etd") %>'></asp:Label>
                    </div>
                    </ItemTemplate>
                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center"  />
                    <ItemStyle Wrap="false" HorizontalAlign="Left" ></ItemStyle>                      
                     </asp:TemplateField>
                       <asp:TemplateField HeaderText ="POL" HeaderStyle-ForeColor="White">
                     <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:80px">
                       <asp:Label ID="POL" runat="server" Text='<%# Bind("POL") %>'></asp:Label>
                    </div>
                    </ItemTemplate>
                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center"  />
                    <ItemStyle Wrap="false" HorizontalAlign="Left" ></ItemStyle>                      
                     </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Agent" HeaderStyle-ForeColor="White">
                     <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:80px">
                       <asp:Label ID="agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                    </div>
                    </ItemTemplate>
                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center"  />
                    <ItemStyle Wrap="false" HorizontalAlign="Left" ></ItemStyle>                      
                     </asp:TemplateField>
                      <asp:TemplateField HeaderText ="MLO / FFR" HeaderStyle-ForeColor="White">
                     <ItemTemplate>   
                    <div style="overflow:hidden;text-overflow:ellipsis;width:80px">
                       <asp:Label ID="MLO" runat="server" Text='<%# Bind("MLO") %>'></asp:Label>
                    </div>
                    </ItemTemplate>
                        <HeaderStyle Wrap="false" Width="80px" HorizontalAlign="Center"  />
                    <ItemStyle Wrap="false" HorizontalAlign="Left" ></ItemStyle>                      
                     </asp:TemplateField>
                  
                   </Columns>
                  
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
            <PagerStyle CssClass="GridviewScrollPager" />
          </asp:GridView></asp:Panel>
        <div class="div_Break"></div>
     </div>
        </asp:panel>

    <div class="div_Break"></div>
    <div>
        <asp:modalpopupextender id="mdl_FIJob" runat="server" cancelcontrolid="img_grd_FIJob"
            popupcontrolid="pnl_FIJob" targetcontrolid="Label1" dropshadow="false">
            </asp:modalpopupextender>
    </div>
    <asp:hiddenfield id="hf_FIJob" runat="server" />
    <div class="div_Break"></div>

    <%-- <div class="div_BTJob">--%>
    <asp:panel id="pnl_BTJob" runat="server" cssclass="modalPopup" style="display: none;">
        <div class="divRoated">
        <div class="DivSecPanel"> <asp:Image ID="img_grd_BTJob" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%"/>  </div>
             
     <asp:Panel ID="Panel1" runat="server"   CssClass="Gridpnl">

          <asp:GridView ID="grd_BTJob" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid FixedHeader"  
              ForeColor="Black" EmptyDataText="No Record Found" PageSize="20" BackColor="White" AllowPaging="false" OnPageIndexChanging="grd_BTJob_PageIndexChanging"
              OnRowDataBound="grd_BTJob_RowDataBound" OnSelectedIndexChanged ="grd_BTJob_SelectedIndexChanged" >
        
                   <Columns>
                       <asp:BoundField DataField="jobno" HeaderText="Job #" />
                       <asp:BoundField DataField="truckno" HeaderText="Truck #" />
                       <asp:BoundField DataField="fromport" HeaderText="From" />
                       <asp:BoundField DataField="etd" HeaderText="ETD" />
                       <asp:BoundField DataField="toport" HeaderText="To" />
                       <asp:BoundField DataField="eta" HeaderText="ETA" />
                   </Columns>
                   <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
               <PagerStyle CssClass="GridviewScrollPager" />
      </asp:GridView>
      </asp:Panel>
      </div>
      </asp:panel>
    <%-- </div>--%>
    <div class="div_Break"></div>
    <div>
        <asp:modalpopupextender id="mdl_BTJob" runat="server" cancelcontrolid="img_grd_BTJob"
            popupcontrolid="pnl_BTJob" targetcontrolid="Label2" dropshadow="false">
          </asp:modalpopupextender>
    </div>
    <asp:hiddenfield id="hf_BTJob" runat="server" />
    <asp:label id="Label1" runat="server"></asp:label>
    <asp:label id="Label2" runat="server"></asp:label>

</asp:Content>
