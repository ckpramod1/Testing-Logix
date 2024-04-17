<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MasterTDSType.aspx.cs" Inherits="logix.Maintenance.MasterTDSType" %>
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

   <%-- <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

  
    <!-- App -->
       <script type="text/javascript" src="../js/helper.js"></script>

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







    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css"/>
<link href="../Styles/ControlStyle2.css" rel="Stylesheet" type="text/css" />
<link href="../Styles/Region.css" rel="Stylesheet" type="text/css" />
<script src="../Scripts/Validation.js" type="text/javascript"></script>
<link href="../Styles/button1.css" rel="stylesheet" type="text/css" />
<link href="../Styles/MITDS.css" rel="Stylesheet" type="text/css" />
<link href="../Styles/chosen.css" rel="stylesheet" />
<script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
<script src="../Scripts/gridviewScroll.min.js" type="text/javascript" ></script>
<style type="text/css">
        a img {
            border: none;
        }

        ol li {
            list-style: decimal outside;
        }
        .widget.box {
    width: 55%;
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
              
               .widget.box{
    position: relative;
    top: -8px;
}
               .TextField {
    position: relative;
    margin: 0px 0.5% 0px 0px;
}


  
.widget.box .widget-content {
    top: 0px !important;
    padding-top:65px !important;
}
.FixedButtonsss {
    width: calc(100vw - 581px) !important;
}
    </style>

<script type="text/javascript">
    function pageLoad(sender, args) {
        $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
     <%--$(document).ready(function () {
            $('#<%=grd.ClientID%>').gridviewScroll({
                width: 740,
                 height: 325,
                 arrowsize: 30,

                 varrowtopimg: "../images/arrowvt.png",
                 varrowbottomimg: "../images/arrowvb.png",
                 harrowleftimg: "../images/arrowhl.png",
                 harrowrightimg: "../images/arrowhr.png"
             });
         });--%>
    }
    function TxtFocus() {
        var el = $("#<%=txt_desc.ClientID %>").get(0);
        var elemLen = el.value.length;
        el.selectionStart = elemLen;
        el.selectionEnd = elemLen;
        el.focus();
    }

    function GetDetail() {
        $.ajax({
            type: "POST",
            url: "MasterTDSType.aspx/GetdeptName1",

            data: '{Prefix: "' + $("#<%=txt_desc.ClientID %>").val() + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            failure: function (response) {
                //alertify.alert(response.d);
            }
        });
    }

    function OnSuccess(response) {
        $("#<%=btn_search.ClientID %>").click();
    }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
   
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
         <div>
                  <div style="float: left; margin: 0px 0.5% 0px 0px;">  <h4 class="hide"><i class="icon-umbrella"></i> <asp:Label ID="lbl_Header" runat="server" Text="TDSType"></asp:Label></h4>
                       <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
              <li><a href="#" title="">Maintenance</a> </li>
              <li class="current"><a href="#" title="">TDS Type</a> </li>
            </ul>
      </div>
                  </div>
           <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
             </div>


                               <div class="FixedButtons ">
            <div class="right_btn">
                <div class="btn ico-save" id="btn_save1" runat="server"> 
                    <asp:Button ID="btn_save" runat="server"  Text="Save" ToolTip="Save"  OnClick="btn_save_Click" />
</div>
                <div class="btn ico-excel" style="display:none;">
                                      <asp:Button ID="btnoutExcel" runat="server" Text="Export To Excel" ToolTip="Export To Excel" OnClick="btnoutExcel_Click" Visible="false"  />
                                  </div>
                <div class="btn ico-cancel" id="btn_back1" runat="server">
                      <asp:Button ID="btn_back" runat="server" Text="Cancel"  ToolTip="Cancel"  OnClick="btn_back_Click"  />
                </div>
            </div>
  <asp:Button ID="btn_search" runat="server" Text=""  Style="display: none;" OnClick="btn_search_Click" />
        </div>

                </div>
          <div class="widget-content">
                     
              <div class="FormGroupContent4 custom-d-flex">
             <div class="custom-col-20">
                 <asp:TextBox ID="txt_Section" runat="server" CssClass="form-control" placeholder="Section" ToolTip="Section" OnTextChanged="txt_Section_TextChanged"
            onKeyUp="CheckTextLength(this,10);"></asp:TextBox>

                 </div>
              <div class="custom-col">
                   <asp:TextBox ID="txt_desc" runat="server" CssClass="form-control" placeholder="Description" ToolTip="Description" 
            onkeyup="GetDetail();" MaxLength="50"></asp:TextBox>
                  </div>
               <div class="custom-w-15 custom-mr-05">
                     <asp:DropDownList ID="ddl_cmbType" runat="server" placeholder="TDS Type"  ToolTip="TDS Type" AutoPostBack="True" CssClass="chzn-select" data-placeholder="TDS Type"
            OnSelectedIndexChanged="ddl_cmbType_SelectedIndexChanged"  >
            <asp:ListItem Text="" Value=""></asp:ListItem>
            <asp:ListItem Value="C">Company</asp:ListItem>
            <asp:ListItem Value="I">Individual</asp:ListItem>
        </asp:DropDownList>
                   </div>
                 <div class="custom-w-30 custom-mr-05 ">
                      <asp:DropDownList ID="ddl_cmbSlab" runat="server" placeholder="TDS SLAB" ToolTip="TDS SLAB" CssClass="chzn-select" data-placeholder="TDS SLAB" >
            <asp:ListItem Value="" Text=""></asp:ListItem>
        </asp:DropDownList>
                     </div>
              <div class="custom-w-10">
                    <asp:TextBox ID="txt_Percent" runat="server" CssClass="form-control" MaxLength="10" placeholder="Percentage" ToolTip="Percentage" onkeypress="return validateFloatKeyPress(this, event,'Percentage');"></asp:TextBox>
              </div>
              </div>
             

              <div class="FormGroupContent4">
                  <div class="gridpnl">
                  <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" Width="100%" OnSelectedIndexChanged="grd_SelectedIndexChanged"  OnRowDataBound="grd_RowDataBound"
            ShowHeaderWhenEmpty="true" CssClass="Grid FixedHeader"  > <%--onpageindexchanging="grd_PageIndexChanging" AllowPaging="false" PageSize="10"--%>
            <Columns>
                <asp:BoundField DataField="sno" HeaderText="S#" ItemStyle-HorizontalAlign="Justify" ItemStyle-Width="10px">
                    <HeaderStyle Width ="40px" Wrap="true"/>
                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="32px" Wrap="false"/>
                </asp:BoundField>
                <asp:BoundField DataField="tdsid" HeaderText="tdsid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" >
                    <HeaderStyle Width ="20px"/>
                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="15px" />
                </asp:BoundField>
                <asp:BoundField DataField="tdsdesc" HeaderText="Description" >
                    <HeaderStyle Width ="300px" Wrap="true"/>
                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="155px" Wrap="false"/>
                </asp:BoundField>
                <asp:BoundField DataField="tdstype" HeaderText="Type" ItemStyle-HorizontalAlign="center">
                    <HeaderStyle Width ="70px" Wrap="true"/>
                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="100px" Wrap="false"/>
                </asp:BoundField>
                <asp:BoundField DataField="tdsslab" HeaderText="Slab">
                    <HeaderStyle Width ="550px"/>
                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="300px" />
                </asp:BoundField>
                <asp:BoundField DataField="tdspercentage" HeaderText="%">
                    <HeaderStyle Width ="50px"/>
                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="25px" />
                </asp:BoundField>
                <asp:BoundField DataField="tdssection" HeaderText="section">
                    <HeaderStyle Width ="40px"/>
                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="25px" />
                </asp:BoundField>
               <%-- <asp:TemplateField>
                      <HeaderStyle Width ="18px"/>
                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="20px" />
                    <ItemTemplate>
                        <asp:LinkButton ID="link_select" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
            <%--<EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
            <PagerSettings Mode="NextPreviousFirstLast" />--%>

            <AlternatingRowStyle CssClass="GrdRowStyle" /> 
                <HeaderStyle CssClass="GridviewScrollHeader" /> 
            <RowStyle CssClass="GridviewScrollItem" /> 
      
        </asp:GridView>
                      </div>

                  </div>

                <div class="FormGroupContent4">
                  <div class="panel_10" id="cust" runat="server" visible="false">
                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"   Visible="false"  CssClass="Grid FixedHeader" >
            <Columns>
                <asp:BoundField DataField="sno" HeaderText="S#" ItemStyle-HorizontalAlign="Justify" ItemStyle-Width="10px">
                    <HeaderStyle Width ="40px" Wrap="true"/>
                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="32px" Wrap="false"/>
                </asp:BoundField>
                <asp:BoundField DataField="tdsid" HeaderText="tdsid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" >
                    <HeaderStyle Width ="20px"/>
                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="15px" />
                </asp:BoundField>
                <asp:BoundField DataField="tdsdesc" HeaderText="Description" >
                    <HeaderStyle Width ="300px" Wrap="true"/>
                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="155px" Wrap="false"/>
                </asp:BoundField>
                <asp:BoundField DataField="tdstype" HeaderText="Type" ItemStyle-HorizontalAlign="center">
                    <HeaderStyle Width ="70px" Wrap="true"/>
                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="100px" Wrap="false"/>
                </asp:BoundField>
                <asp:BoundField DataField="tdsslab" HeaderText="Slab">
                    <HeaderStyle Width ="550px"/>
                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="300px" />
                </asp:BoundField>
                <asp:BoundField DataField="tdspercentage" HeaderText="%">
                    <HeaderStyle Width ="50px"/>
                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="25px" />
                </asp:BoundField>
             
               <%-- <asp:TemplateField>
                      <HeaderStyle Width ="18px"/>
                    <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width ="20px" />
                    <ItemTemplate>
                        <asp:LinkButton ID="link_select" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
            <%--<EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
            <PagerSettings Mode="NextPreviousFirstLast" />--%>

            <AlternatingRowStyle CssClass="GrdRowStyle" /> 
                <HeaderStyle CssClass="GridviewScrollHeader" /> 
            <RowStyle CssClass="GridviewScrollItem" /> 
      
        </asp:GridView>
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
                                    <label id="lbl" runat="server">TDS :</label>

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

    <asp:modalpopupextender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image3" BehaviorID="Test1">
    </asp:modalpopupextender>

<asp:HiddenField ID="hf_tdsid" runat="server" />
        <asp:HiddenField ID="hf_tdsType" runat="server"  />
</asp:Content>
