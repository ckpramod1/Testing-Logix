<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="Permission.aspx.cs" Inherits="logix.HRM.Permission" %>

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
    <link href="../Theme/newTheme/css/systemnewdeign.css" rel="stylesheet" />
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
    <link href="../Styles/Permission.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txt_EmpName.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_empcode.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetEmployeeName",
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
                        $("#<%=hid_empcode.ClientID %>").val(i.item.val);
                        $("#<%=txt_EmpName.ClientID %>").change();
                    },
                    change: function (e, i) {
                        $("#<%=hid_empcode.ClientID %>").val(i.item.val);
                        $("#<%=txt_EmpName.ClientID %>").val(i.item.label);
                    },
                    focus: function (e, i) {
                        $("#<%=hid_empcode.ClientID %>").val(i.item.val);
                        $("#<%=txt_EmpName.ClientID %>").val(i.item.label);
                    },
                    close: function (e, i) {
                        $("#<%=hid_empcode.ClientID %>").val(i.item.val);
                        $("#<%=txt_EmpName.ClientID %>").val(i.item.label);
                    },
                    minLength: 1
                });
            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

        }

    </script>
    <style>
         .Pnl1 {
            padding: 15px 15px 15px 15px;
            background-color: #dbdbdb;
            border: 1px solid #b1b1b1;
        }

        #logix_CPH_Panel_Service1 {
            left: 303px !important;
            top: 268px !important;
            text-align: center;
        }
        .div_ddl {
    float: left;
    width: 100%;
    margin-left: 0% !important;
    margin-top: 0% !important;
    margin-bottom: 0% !important;
}
        .ForeNoon {
    width: 39%;
    float: right;
    margin: 0px 0% 0px 0px;
}
        .div_Minlbl {
    float: left;
    width: 10%;
    margin-left: 1%;
    margin-top: 0%;
}
        .PerMCal {
    float: right;
    margin: 0;
    width: 7%;
}

        .div_Gird {
    width: 100%;
    float: left;
    height: 190px;
    border: 1px solid #b1b1b1;
}

        .PerEmpNameNew {
            width:24.5%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
        .PerEmpcodeNew {
            width:5%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
        .PerEmpNameDiv {
            width:25%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
        .PerEmpcodeBr {
            width:8%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
        .PerEmpNameDep {
            width:15.5%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
        .PerEmpcodeDes {
            width:19.5%;
            float:left;
            margin:0px 0px 0px 0px;
        }
        .PerEmpName {
            width: 80%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        .PerEmpcode {
    width: 19.5%;
    float: left;
    margin: 0px 0% 0px 0px;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">



       <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">HRM</a> </li>
              <li class="current">Permission</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->

     <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/permision_ic.png" /> <asp:Label ID="lbl_Header" runat="server" Text="Permission"></asp:Label>
        
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">  

           <div class="FormGroupContent4">
                 <div class="PerMCal">
                     <div class="LabelWidth">Permission Date</div>
                     <div class="FieldInput"><asp:TextBox ID="txt_date" runat="server" placeholder="" ToolTip="Permission Date" CssClass="form-control"></asp:TextBox></div>
                     </div>


                 </div>
               <div class="FormGroupContent4">
                   <div class="PerEmpcodeNew">
                       <div class="LabelWidth">Emp Code</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Empcode" runat="server" placeholder="" ToolTip="EmpCode" CssClass="form-control" ReadOnly="True" TabIndex="2"></asp:TextBox></div>
                       
                       </div>
                   <div class="PerEmpNameNew"> 
                       
                       <div class="LabelWidth">Emp Name</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_EmpName" runat="server" AutoPostBack="True" placeholder="" ToolTip="EmpName" CssClass="form-control" OnTextChanged="txt_EmpName_TextChanged" TabIndex="1"></asp:TextBox></div>
                       </div>
                   
                      <div class="PerEmpNameDiv"> 
                         <div class="LabelWidth">Division</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_division" runat="server" placeholder="" ToolTip="Division" CssClass="form-control" ReadOnly="True" TabIndex="3"></asp:TextBox></div>
                         </div>
                   <div class="PerEmpcodeBr">
                       
                       <div class="LabelWidth">Branch</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_location" runat="server" placeholder="" ToolTip="Branch" CssClass="form-control" ReadOnly="True" TabIndex="4"></asp:TextBox></div>
                        </div>
                   <div class="PerEmpNameDep"> 
                         <div class="LabelWidth">Department</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_dept" runat="server" placeholder="" ToolTip="Department" CssClass="form-control" ReadOnly="True" TabIndex="5"></asp:TextBox></div>
                         
                         </div>
                   <div class="PerEmpcodeDes">
                       <div class="LabelWidth">Designation</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_designation" runat="server" placeholder="" ToolTip="Designation" CssClass="form-control" ReadOnly="True" TabIndex="6"></asp:TextBox></div>
                       
                       </div>
                   </div>
              
               
              <div class="FormGroupContent4">
                     <div class="PerEmpName">
                         <div class="div_Gird">
                    <asp:GridView ID="Grd_Permission" runat="server" AutoGenerateColumns="False" Width="100%"
                        ShowHeaderWhenEmpty="True" class="Grid"
                        OnSelectedIndexChanged="Grd_Permission_SelectedIndexChanged" OnRowDataBound="Grd_Permission_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="permissiondate" HeaderText="Permission Date">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="minutes" HeaderText="Minutes">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fnan" HeaderText="Session">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                           <%-- <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Lnk_Select" runat="server" CommandName="select" Font-Underline="false"
                                        CssClass="Arrow">⇛</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:TemplateField>--%>
                        </Columns>
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
                    </asp:GridView>
                </div></div>
                   <div class="PerEmpcode"> 
                       <div class="Permissionctrl">
                       <div class="LabelWidth">Permission</div>
                       <div class="FieldInput"><div class="div_ddl">

                    <asp:DropDownList ID="ddl_permission" runat="server" data-placeholder="Permission" ToolTip="Permission" CssClass="chzn-select" TabIndex="7">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="1">10</asp:ListItem>
                        <asp:ListItem Value="2">20</asp:ListItem>
                        <asp:ListItem Value="3">30</asp:ListItem>
                        <asp:ListItem  Value="4">40</asp:ListItem>
                        <asp:ListItem  Value="5">50</asp:ListItem>
                        <asp:ListItem  Value="6">60</asp:ListItem>
                        <asp:ListItem  Value="7">70</asp:ListItem>
                        <asp:ListItem  Value="8">80</asp:ListItem>
                        <asp:ListItem  Value="9">90</asp:ListItem>
                    </asp:DropDownList>
                </div></div>
                       </div>
                        <div class="div_Minlbl MTCtrl6">

                    <asp:Label ID="lbl_minutes" runat="server" Text="Min"></asp:Label>
                </div>
                       <div class="ForeNoon">
                           <div class="LabelWidth">Session</div>
                           <div class="FieldInput">

                               <asp:DropDownList ID="ddl_session" runat="server" data-placeholder="Session" ToolTip="Session" CssClass="chzn-select"
                        AppendDataBoundItems="True" TabIndex="8">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="A">AfterNoon</asp:ListItem>
                        <asp:ListItem Value="F">ForeNoon</asp:ListItem>
                    </asp:DropDownList>
                           </div>
                        
                    
               
                   </div>
                   </div>
                   </div>
              
               <div class="FormGroupContent4">
                   <div class="right_btn MT0 MB05">
                       <div class="btn btn-Ok1" id="btn_save1" runat="server"> <asp:Button ID="btn_save" runat="server" ToolTip="Ok" OnClick="btn_save_Click" TabIndex="9"  /></div>
                       <div class="btn ico-cancel" id="btn_cancel1" runat="server">  <asp:Button ID="btn_cancel" runat="server" ToolTip="Cancel" OnClick="btn_cancel_Click" TabIndex="10" /></div>
                   </div>
                   </div>
            </div>
         </div>










    


        <div class="FormGroupContent4">

        <asp:Panel runat="Server" ID="Panel_Service1" CssClass="Pnl1" Style="display: none;">
            <br />
            <div style="font-size: 10pt"><b>Do you want to Delete?</b></div>
            <br />
            <div class="div_confirm">
                <asp:Button ID="btnkpiyes" runat="server" Text="Yes" CssClass="Button" OnClick="btnkpiyes_Click" />
                <asp:Button ID="btnkpino" runat="server" Text="No" CssClass="Button" OnClick="btnkpino_Click" />
            </div>
            <br />
            <div class="div_Break"></div>
        </asp:Panel>


    </div>
    <asp:ModalPopupExtender ID="PopUpService1" runat="server" BackgroundCssClass=""
        PopupControlID="Panel_Service1" TargetControlID="Label8">
    </asp:ModalPopupExtender>
    <asp:Label ID="Label8" runat="server" Text="Label" Style="display: none;"></asp:Label>



    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>Permission #</label>

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
 
    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_date"></asp:CalendarExtender>
    <asp:HiddenField ID="hid_empcode" runat="server" />
    <asp:HiddenField ID="hid_Empid" runat="server" />
    <asp:HiddenField ID="hid_date" runat="server" />
     <asp:HiddenField ID="hiddelpermission" runat="server" />
      <asp:HiddenField ID="hiddelcar" runat="server" />

</asp:Content>
