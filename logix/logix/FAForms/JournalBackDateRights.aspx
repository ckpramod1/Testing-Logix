<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="JournalBackDateRights.aspx.cs" Inherits="logix.FAForm.JournalBackDateRights" %>

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
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />

    <!--=== JavaScript ===-->

  <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

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
    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Styles/journalbackdate.css" rel="stylesheet" />
    
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

        <script type="text/javascript" src="Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>


    <script type="text/javascript">


        function pageLoad(sender, args) {
            $(document).ready(function () {

               
            });
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            }
    </script>
    
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {

                $("#<%=txt_empname.ClientID %>").autocomplete({

                    source: function (request, response) {
                        $("#<%=Str_empCode.ClientID %>").val(0);
                        $.ajax({
                            url: "../FAForms/JournalBackDateRights.aspx/GetEmp",
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
                                alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                alertify.alert(response.responseText);
                            }


                        });
                    },
                    select: function (e, i) {
                        $("#<%=Str_empCode.ClientID %>").val(i.item.val);
                        $("#<%=txt_empname.ClientID %>").change();
                    },
                    change: function (e, i) {
                        if (i.item) {
                            $("#<%=Str_empCode.ClientID %>").val(i.item.val);
                            var result = i.item.label.toString().split(',')[0];
                            $("#<%=txt_empname.ClientID %>").val($.trim(result));
                        }
                    },
                    focus: function (e, i) {
                        $("#<%=Str_empCode.ClientID %>").val(i.item.val);
                        var result = i.item.label.toString().split(',')[0];
                        $("#<%=txt_empname.ClientID %>").val($.trim(result));
                    },
                    close: function (e, i) {
                        var result = $("#<%=txt_empname.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_empname.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            })
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>


    <style type="text/css">
        .row {
    height: 350px !important;
    margin: 0px 5px 0px -15px;
    clear: both;
    overflow-x: hidden !important;
    overflow-y: auto !important;
    width: 100%;
}

        #logix_CPH_drop_division_chzn {
            width:100%!important;
        }
        #logix_CPH_drop_branch_chzn {
            width:100%!important;
        }

        .JournalBranch {
    float: left;
    width: 10.5%;
    margin: 0px 0.5% 0px 0px;
}
        #logix_CPH_txt_noofmonth_chzn {
            width:100%!important;
        }
        .JournalMonths {
    float: left;
    width: 11%;
    margin: 0px 0% 0px 0px;
}
        .JournalDivision {
    float: left;
    width: 26.5%;
    margin: 0px 0.5% 0px 0px;
}
        .chzn-container .chzn-results {
    margin: 0 4px 4px 0;
    max-height: 490px;
    padding: 0 0 0 4px;
    position: relative;
    overflow-x: hidden;
    overflow-y: auto;
    -webkit-overflow-scrolling: touch;
}
         .Days {
    float: left;
    width: 10%;
    margin: 0px 0.5% 0px 0px;
}

                   /*CSS*/

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
    margin-left: 0% !important;
    margin-top: -16.9% !important;
    overflow: auto;
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
             white-space:nowrap;
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


    </style>

   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
   
     <div >
                <div class="col-md-12  maindiv"> 
    
                <div class="widget box" runat ="server">
   
                <div class="widget-header">
                    <div>
                <h4 class="hide"><i class="icon-umbrella"></i><asp:Label ID="lbl_title" runat="server" Text="Journal Back Date"></asp:Label></h4>
                  <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs1" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">Utility</a> </li>
              <li><a href="#" title=""> Journal Back Date </a> </li>
              <li><asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
            </ul>
      </div>
                 <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

                  </div>
                </div>
                <div class="widget-content" >
                <div class="FormGroupContent4 MB10">
                    <div class="JournalEmpName"> 
                     
                        <asp:Label ID="lbl_empname" runat="server" Text="EmpName"></asp:Label>
                        <asp:TextBox ID="txt_empname" runat="server" AutoPostBack="true" CssClass="form-control" placeholder="" ToolTip="Employee Name" OnTextChanged="txt_empname_TextChanged"></asp:TextBox>

                    </div>
                    <div class="JournalEmpBranch"> 
                        
                        <asp:Label ID="lbl_branch" runat="server" Text="EmpBranch"></asp:Label>
                         <asp:TextBox ID="txt_branch" runat="server" CssClass="form-control" placeholder=" " ToolTip="Employee Branch"></asp:TextBox>

                    </div>
                    <div class="JournalDivision">
                       
                        <asp:Label ID="lbl_division" runat="server" Text="Division"></asp:Label>
                        <asp:DropDownList ID="drop_division" runat="server" Height="23px" CssClass="chzn-select" data-placeholder="Division" AutoPostBack="true" OnSelectedIndexChanged="drop_division_SelectedIndexChanged">
               <asp:ListItem Value="0">Division</asp:ListItem>
           </asp:DropDownList>
                    </div>
                    <div class="JournalBranch">
                  
                        <asp:Label ID="lbl_bran" runat="server" Text="Branch"></asp:Label>
                        <asp:DropDownList ID="drop_branch" runat="server" Height="23px" AutoPostBack="true" CssClass="chzn-select" data-placeholder="Branch" OnSelectedIndexChanged="drop_branch_SelectedIndexChanged" AppendDataBoundItems="true" >
             <asp:ListItem Value="0">Branch</asp:ListItem>
        </asp:DropDownList>
                    </div>
                    <div class="JournalMonths" style="display:none;">
                    
                        <asp:Label ID="Label1" runat="server" Text="No Of Months"></asp:Label>
                        <asp:DropDownList ID="txt_noofmonth" Height="23px" runat="server" AutoPostBack="true" CssClass="chzn-select" data-placeholder="No Of Months" ToolTip="No Of Months" >
             <asp:ListItem Value="0">Month</asp:ListItem>
             <asp:ListItem Value="1"></asp:ListItem>
             <asp:ListItem Value="2"></asp:ListItem>
             <asp:ListItem Value="3"></asp:ListItem>
             <asp:ListItem Value="4"></asp:ListItem>
             <asp:ListItem Value="5"></asp:ListItem>
             <asp:ListItem Value="6"></asp:ListItem>
             <asp:ListItem Value="7"></asp:ListItem>
             <asp:ListItem Value="8"></asp:ListItem>
             <asp:ListItem Value="9"></asp:ListItem>
             <asp:ListItem Value="10"></asp:ListItem>
             <asp:ListItem Value="11"></asp:ListItem>
             <asp:ListItem Value="12"></asp:ListItem>

        </asp:DropDownList>

                    </div>
                    <div class="Days">
                        <span>No of Days</span>
                        <asp:TextBox ID="txt_noofdays" runat="server" ToolTip="No of Days" CssClass="form-control" placeholder="" />
                    </div>
                    <div class="right_btn custom-mt-3">
                        <div class="btn ico-save" id="btn_save1" runat="server">
                            <asp:Button ID="btn_save" runat="server" ToolTip="Save"  OnClick="btn_save_Click"/></div>
                        <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                            <asp:Button ID="btn_view" runat="server" ToolTip="Cancel" OnClick="btn_view_Click" /></div>
                    
                        </div>

                    </div>
                    
               
                
                
                </div>
                    </div>
                    </div>
         </div>












    <asp:HiddenField ID="Str_empCode" runat="server" />


      <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
        <div class="divRoated">
            <div class="LogHeadLbl">
                <div class="LogHeadJob">
                    <label>JournalBackDateRights #</label>

                </div>
                <div class="LogHeadJobInput">

                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                </div>

            </div>
            <div class="DivSecPanel">
                <asp:Image ID="imglog" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>

            <asp:Panel ID="Panel3" runat="server" CssClass="Gridpnl">

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


    <asp:Label ID="Label6" runat="server"></asp:Label>

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label6" CancelControlID="imglog" BehaviorID="Test1">
    </asp:ModalPopupExtender>
</asp:Content>
