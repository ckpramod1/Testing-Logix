<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="SOP.aspx.cs" Inherits="logix.Maintenance.SOP" %>
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






    <link href="../Styles/ControlStyle2.css" rel="stylesheet" />
    <link href="../Styles/SOP.css" rel="stylesheet" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/Gridviewscroll.js"></script>
    <script src="../Scripts/ScrollableGridPlugin.js"></script>
    <script src="../Scripts/gridviewScroll.min.js"></script>
   <script src="../Scripts/Validation.js" type="text/javascript"></script>
 <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>

<link href ="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
         a img{border: none;}
		ol li{list-style: decimal outside;}
		div#container{width: 780px;margin: 0 auto;padding: 1em 0;}
		div.side-by-side{width: 100%;margin-bottom: 1em;}
		div.side-by-side > div{float: left;width: 50%;}
		div.side-by-side > div > em{margin-bottom: 10px;display: block;}
		.clearfix:after{content: "\0020";display: block;height: 0;clear: both;overflow: hidden;visibility: hidden;}

            .btn-UpdateAdd2 {
   
    z-index: 2;
    border-radius: 0px;
}

    .btn-UpdateAdd2 input {
       
        border: medium none;
        line-height: normal;
        color: #4e4e4c!important;
        padding: 5px 0px 6px 28px;
        background:url(../Theme/assets/img/buttonIcon/updateadd_ic.png ) no-repeat left top;
    }

    </style>
    <script type="text/javascript">

        function pageLoad(sender, args) {


            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

       <%--     $(document).ready(function () {
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
                $('#<%=grdcustomer.ClientID%>').gridviewScroll({
                    width: 586,
                    height: 200,
                    arrowsize: 30,

                    varrowtopimg: "../images/arrowvt.png",
                    varrowbottomimg: "../images/arrowvb.png",
                    harrowleftimg: "../images/arrowhl.png",
                    harrowrightimg: "../images/arrowhr.png"
                });
            });--%>

            //$(document).ready(function () {
                <%--      $('#<%=grd.ClientID%>').gridviewScroll({
                      width: 586,
                      height: 200,
                      arrowsize: 30,

                      varrowtopimg: "../images/arrowvt.png",
                      varrowbottomimg: "../images/arrowvb.png",
                      harrowleftimg: "../images/arrowhl.png",
                      harrowrightimg: "../images/arrowhr.png"
                  });
              });--%>
                      
                //}
                <%-- function TxtFocus() {
            //$("#<%=txt_Customer.ClientID %>").blur().focus().val($("#<%=txt_Customer.ClientID %>").val());
             var el = $("#<%=txt_Customer.ClientID %>").get(0);
             var elemLen = el.value.length;
             el.selectionStart = elemLen;
             el.selectionEnd = elemLen;
             el.focus();
         }

         function GetDetail() {
             $.ajax({
                 type: "POST",
                 url: "SOP.aspx/GetCustomer",
                 data: '{Prefix: "' + $("#<%=txt_Customer.ClientID %>").val() + '" }',
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
           --%>
                $(document).ready(function () {
                    $("#<%=txt_Customer.ClientID %>").autocomplete({

                        source: function (request, response) {
                            $("#<%=HdnCusId.ClientID %>").val(0);
                            $.ajax({
                                url: "../Maintenance/SOP.aspx/Getbillname",
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
                        select: function (event, i) {
                            $("#<%=HdnCusId.ClientID %>").val(i.item.val);
                            $("#<%=txt_Customer.ClientID %>").change();
                        },
                        change: function (event, i) {

                            $("#<%=HdnCusId.ClientID %>").val(i.item.val);
                            $("#<%=txt_Customer.ClientID %>").val(i.item.value);
                        },
                        focus: function (event, i) {
                            $("#<%=txt_Customer.ClientID %>").val(i.item.value);
                        },

                        minLength: 1
                    });
                });
                
        }
       
            </script>
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

.grid_1Cus {
    
    border: 1px solid #999997;
    height: 86px;    
    width: 100%;
    margin-left: 0%;
    margin-top: 0%;
    overflow-y: scroll;
    overflow: auto;
}
.FormGroupContent4 textarea {
    height: 117px !important;
}

.grid_1
{
    /*height:30px;*/
    border:1px solid #999997 ;
    height:170px;
    /*border:1px solid red ;*/
    width: 100%;
    margin-left:0%;
    margin-top:0%;
   overflow-y :scroll ;
   overflow:auto;
}


    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

      <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
              <li><a href="#" title="">Maintenance</a> </li>
              <li class="current"><a href="#" title="">Standard Operating Procedure </a> </li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                   <div style="float: left; margin: 0px 0.5% 0px 0px;"> <h4><i class="icon-umbrella"></i><asp:Label ID="lblheader" runat="server" Text="Standard Operating Procedure"></asp:Label></h4></div>
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
          <div class="widget-content">
             <div class="FormGroupContent4">
                 <asp:TextBox ID="txt_Customer" runat="server" CssClass="form-control" placeholder=" Customer Name" ToolTip="Customer Name"  AutoPostBack="True"  OnTextChanged="txt_Customer_TextChanged" TabIndex="1" ></asp:TextBox>

                 </div>
               <div class="FormGroupContent4">
                        <asp:Panel ID="pnlcust1" runat="server" cssclass="grid_1Cus">
            <asp:GridView ID="grdcustomer" runat="server" AutoGenerateColumns="False" style="margin-left:0%;"
         width="100%" ForeColor="Black" CssClass="Grid FixedHeader"  ShowHeaderWhenEmpty ="true" >
                    <Columns>                    
                   <asp:BoundField DataField="customerid" HeaderText="id">
                       <HeaderStyle HorizontalAlign="Center" CssClass="hide" />             
                           
                       <ItemStyle Font-Bold="false" HorizontalAlign="Justify" CssClass="hide"  />
                   </asp:BoundField>
                    <asp:BoundField DataField="customername" HeaderText="Customer" ItemStyle-HorizontalAlign="Right">
                        <HeaderStyle HorizontalAlign="Center" Width="900px" />
                        <ItemStyle Font-Bold="false" HorizontalAlign="left"   />
                  
                    </asp:BoundField>
                    <asp:BoundField DataField="city" HeaderText="city">
                         <HeaderStyle HorizontalAlign="Center" Wrap="true" Width="300px" />
                        <ItemStyle Font-Bold="false" HorizontalAlign="Left"   />

                    </asp:BoundField>
                          <asp:TemplateField HeaderText="" >
                        <ItemTemplate>
                            <asp:CheckBox ID="grdblselect" runat="server" />
                             
                        </ItemTemplate >
                    </asp:TemplateField>
                </Columns>
             <AlternatingRowStyle CssClass="GrdRowStyle" /> 
                <HeaderStyle CssClass="GridviewScrollHeader" /> 
            <RowStyle CssClass="GridviewScrollItem" /> 
            <PagerStyle CssClass="GridviewScrollPager" />
    
            </asp:GridView>   

  </asp:Panel>

                   </div>
              <div class="FormGroupContent4">
                  <asp:TextBox ID="txtsop" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" placeholder="Standard operating Procedure" ToolTip="Standard operating Procedure"  Style="resize: none;" TabIndex="2"></asp:TextBox>
                  </div>
              <div class="FormGroupContent4">
                  <div class="Drop1"><asp:DropDownList ID="ddlStatus" Data-Placeholder="Status" runat="server" CssClass ="chzn-select" TabIndex="3" Width="100%" Tooltip="Status" >
               <asp:ListItem Text="" Value="0"></asp:ListItem>
              <asp:ListItem>Important</asp:ListItem>
               <asp:ListItem>Mandatory</asp:ListItem>
              <asp:ListItem>Normal</asp:ListItem>
              </asp:DropDownList></div>
                  <div class="right_btn MT0">
                      <div class="btn ico-add" id="btn_add1" runat="server">
                          <asp:Button ID="btn_add" runat="server" ToolTip="Add" OnClick="btn_add_Click" TabIndex="4"  />

                      </div>
                  </div>
                  </div>
              <div class="FormGroupContent4">
                      <asp:Panel ID="pnlsop1" runat="server" cssclass="grid_1">
            <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" onrowdatabound="grd_RowDataBound" OnRowCommand="grd_RowCommand" OnRowDeleting="grd_RowDeleting"
                Width="100%" ForeColor="Black" CssClass="Grid FixedHeader"  ShowHeaderWhenEmpty="true" OnSelectedIndexChanged="grd_SelectedIndexChanged" >
                    <Columns>                    
                   <asp:BoundField DataField="sop" HeaderText="Standard Operating Procedure">
                       <HeaderStyle HorizontalAlign="Center"  Width="900px"/>            
                           
                        <ItemStyle Font-Bold="false" HorizontalAlign="Justify"  Width="900px" />
                   </asp:BoundField>
                   
                         <asp:BoundField DataField="status" HeaderText="Status" ItemStyle-HorizontalAlign="Right">
                        <HeaderStyle HorizontalAlign="Center"  Width="70px"/>
                        <ItemStyle Font-Bold="false" HorizontalAlign="Center"  Width="70px"  /> 
                               </asp:BoundField>            
                  <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:ImageButton ID="Img_Delete" runat="server" CommandName="Delete" 
                            ImageUrl="~/images/delete.jpg" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                </Columns>
             <AlternatingRowStyle CssClass="GrdRowStyle" /> 
                <HeaderStyle CssClass="GridviewScrollHeader" /> 
            <RowStyle CssClass="GridviewScrollItem" /> 
            <PagerStyle CssClass="GridviewScrollPager" />
    
            </asp:GridView>  
             <div class="div_Break"></div>     
        </asp:Panel>

                  </div>
              <div class="FormGroupContent4">
                  <div class="right_btn MT0">
                      <div class="btn ico-cancel" id="btn_back1" runat="server">
                          <asp:Button ID="btn_back" runat="server" ToolTip="Back" OnClick="btn_back_Click" TabIndex="5" />
                      </div>
                  </div>
              </div>
              <div class="FormGroupContent4">
                  <asp:Button ID="btn_search" runat="server" Text="" Style="display: none;" OnClick="btn_search_Click" />
     <asp:Panel runat="Server" ID="Panel_Service" CssClass="Pnl1" Style="display: none;">
        <br />
        <div style="font-size: 10pt"><b>Do You Want to Delete the this SOP</b></div>
        <br />
        <div class="div_confirm">
            <asp:Button ID="btnyes" runat="server" Text="Yes" CssClass="Button" OnClick="btnyes_Click"/>
            <asp:Button ID="btnno" runat="server" Text="No" CssClass="Button" />
        </div>
        <br />
    </asp:Panel>
              </div>
              <script src="../Scripts/Validation.js" type="text/javascript"></script>
 <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>
    <script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>    
<link href ="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
              </div>
         </div>
            </div>
           </div>

    <asp:ModalPopupExtender  ID="PopUpService" runat="server" BackgroundCssClass=""
        PopupControlID="Panel_Service" TargetControlID="Label1" ></asp:ModalPopupExtender>
       <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>
        <div class="div_Break"></div>
    <asp:HiddenField ID="HdnCusId" runat="server" />
     <asp:HiddenField ID="hdncussourid" runat="server" />

     <div id="PanelLog1" runat="server">
                    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label id="lbl" runat="server">Customer Name:</label>

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
       </asp:Content>
