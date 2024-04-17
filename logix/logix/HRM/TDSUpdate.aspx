<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true"
    CodeBehind="TDSUpdate.aspx.cs" Inherits="logix.HRM.TDSUpdate" %>

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



    <link href="../Styles/TDSUpdate.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
        <link href="../Styles/GridviewScroll.css" rel="stylesheet" />   
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" /> 
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>    
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script> 
       <link href="../Styles/GridviewScroll.css" rel="stylesheet" /> 
    <link href ="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" /> 
  
          
     
    <script type="text/javascript" language="javascript">

        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            $(document).ready(function () {
                $("#<%=txt_Tds.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        alertify.alert("Please Enter Numeric Values");
                        var strval = $(this).val();
                        var strText = strval.substr(0, strval.length - 1)
                        $(this).val(strText);
                        return false;
                    }
                });
                $("#<%=txt_surcharge.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        alertify.alert("Please Enter Numeric Values");
                        var strval = $(this).val();
                        var strText = strval.substr(0, strval.length - 1)
                        $(this).val(strText);
                        return false;
                    }
                });
                $("#<%=txt_Edu.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        alertify.alert("Please Enter Numeric Values");
                        var strval = $(this).val();
                        var strText = strval.substr(0, strval.length - 1)
                        $(this).val(strText);
                        return false;
                    }
                });

                
            });
        }
        function GetDetail() {
            SValue = new Array();
            SValue[0] = $("#<%=txt_Tds.ClientID %>").val();
            SValue[1] = $("#<%=txt_surcharge.ClientID %>").val();
            SValue[2] = $("#<%=txt_Edu.ClientID %>").val();
            $.ajax({
                type: "POST",
                url: "../HRM/TDSUpdate.aspx/GetTotal",
                data: '{Prefix: "' + SValue + '" }',
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    $("#<%=txt_Total.ClientID %>").val(response.d);
                },
                failure: function (response) {
                    alertify.alert(response.d);
                }

            });
          
        }
    </script>
    <style type="text/css">
     
       
        .UpCompany {
    float: left;
    margin: 0 0.5% 0 0;
    width: 41%;
}
        .UpYear {
    float: left;
    margin: 0 0.5% 0 0;
    width: 4.5%;
}
        .UpMonthDrop {
    float: left;
    margin: 0 0.5% 0 0;
    width: 7.5%;
}
        .UpempCode {
    width: 4%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .UpEmbinput {
    width: 7.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .UpCompany {
    float: left;
    margin: 0 0.5% 0 0;
    width: 29%;
}
        .UpEmpname {
    width: 17%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .UpCompany {
    float: left;
    margin: 0 0.5% 0 0;
    width: 21.5%;
}
        .UpGrade {
    width: 4%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .UpDepart {
    width: 16%;
    float: left;
    margin: 0px 0% 0px 0px;
}
        .UpLocation {
    width: 12%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .Updesi {
    width: 14%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .UpSur {
    width: 6.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .UpEDU {
    width: 7%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .UpTotal {
    width: 14%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .UpChk {
    width: 12.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .UpBSR {
    width: 6%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
        .UpCal {
    width: 6%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}

        .UpChellan {
    width: 22%;
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
              <li><a href="#" title="">Payroll</a> </li>
              <li class="current"><a href="#" title="" id="HeaderLabel" runat="server">Update TDS Details</a> </li>
            </ul>
      </div>
          <!-- /Breadcrumbs line -->

    <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/tdsupdate_ic.png" /> <asp:Label ID="lbl_Header" runat="server"  Text="Update TDS Details"></asp:Label>
        
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">
             <div class="FormGroupContent4">
                    <div class="UpempCode MTCtrl6"> <asp:LinkButton ID="lnk_empcode" runat="server" style="text-decoration:none;" ForeColor="Red"
            onclick="lnk_empcode_Click">EmpCode</asp:LinkButton></div>
                    <div class="UpEmbinput">
                        <div class="LabelWidth">Employee Code</div>
                        <div class="FieldInput"><asp:TextBox ID="txt_Empcode" runat="server" TabIndex="1" AutoPostBack="True" CssClass="form-control" PlaceHolder="" ToolTip="Empcode"  OnTextChanged="txt_Empcode_TextChanged"></asp:TextBox></div>
                        </div>
                    <div class="UpEmpname">
                        <div class="LabelWidth">Employee Name</div>
                        <div class="FieldInput"><asp:TextBox ID="txt_Name" runat="server" CssClass="form-control"  TabIndex="2" PlaceHolder="" ToolTip="EmpName" ReadOnly="True"></asp:TextBox></div>
                        </div>
                    <div class="UpCompany">
                        <div class="LabelWidth">Company</div>
                        <div class="FieldInput"><asp:TextBox ID="txt_company" runat="server" CssClass="form-control" TabIndex="3" PlaceHolder="" ToolTip="Company"  ReadOnly="True"></asp:TextBox></div>
                        </div>
                    <div class="UpYear"> 
                        <div class="LabelWidth">Pay Year</div>
                        <div class="FieldInput"><asp:TextBox ID="txt_Payyear" runat="server" MaxLength="4" TabIndex="4" AutoPostBack="True" CssClass="form-control" PlaceHolder="" ToolTip="Payyear"  BorderColor="#999997" 
            ontextchanged="txt_Payyear_TextChanged"></asp:TextBox></div>
                        </div>
                    <div class="UpMonthDrop">  
                        <div class="LabelWidth">Month</div>
                        <div class="FieldInput">  <asp:DropDownList ID="ddl_Month" runat="server" TabIndex="5" Data-placeHolder="Month" CssClass ="chzn-select" ToolTip="Month" AutoPostBack="true" OnSelectedIndexChanged="ddl_Month_SelectedIndexChanged" >
            <asp:ListItem></asp:ListItem>
            <asp:ListItem Value="1">JANUARY</asp:ListItem>
            <asp:ListItem Value="2">FEBRUARY</asp:ListItem>
            <asp:ListItem Value="3">MARCH</asp:ListItem>
            <asp:ListItem Value="4">APRIL</asp:ListItem>
            <asp:ListItem Value="5">MAY</asp:ListItem>
            <asp:ListItem Value="6">JUNE</asp:ListItem>
            <asp:ListItem Value="7">JULY</asp:ListItem>
            <asp:ListItem Value="8">AUGUST</asp:ListItem>
            <asp:ListItem Value="9">SEPTEMBER</asp:ListItem>
            <asp:ListItem Value="10">OCTOBER</asp:ListItem>
            <asp:ListItem Value="11">NOVEMBER</asp:ListItem>
            <asp:ListItem Value="12">DECEMBER</asp:ListItem>
        </asp:DropDownList></div>
                        
                       </div>
                      <div class="UpGrade">
                         <div class="LabelWidth">
                             Grade</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_Grade" TabIndex="6" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Grade"></asp:TextBox></div>
                         </div>
                  <div class="Updesi"> 
                         <div class="LabelWidth">Designation</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_Desg" TabIndex="7"  runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Designation"></asp:TextBox></div>
                         
                         </div>
                 <div class="UpDepart"> 
                         <div class="LabelWidth">Department</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_Dept" TabIndex="8" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Department" ></asp:TextBox></div>
                         </div>
                    </div>
                 <div class="FormGroupContent4">
                
                    
                     
                     <div class="UpLocation">
                         <div class="LabelWidth">Location</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_Location" TabIndex="9" runat="server" CssClass="form-control" PlaceHolder="" ToolTip="Location"></asp:TextBox></div>
                         
                         </div>
                     <div class="UpTDS"> 
                         <div class="LabelWidth">Tds</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_Tds" runat="server" TabIndex="10" CssClass="form-control" PlaceHolder="" ToolTip="Tds"  style="text-align:right;"></asp:TextBox></div>
                         </div>
                     <div class="UpSur">
                         <div class="LabelWidth">Sur.Charge</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_surcharge" runat="server" TabIndex="11" CssClass="form-control" PlaceHolder="" ToolTip="Sur.Charge" style="text-align:right;"></asp:TextBox></div>
                         </div>
                      <div class="UpEDU">
                         <div class="LabelWidth">Edu.Chess</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_Edu" runat="server" TabIndex="12" CssClass="form-control" PlaceHolder="" ToolTip="Edu.Chess"  style="text-align:right;"></asp:TextBox></div>
                         
                         </div>
                       <div class="UpTotal">
                         <div class="LabelWidth">Total</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_Total" runat="server" TabIndex="13" ReadOnly="true" CssClass="form-control" PlaceHolder="" ToolTip="Total" style="text-align:right;"></asp:TextBox></div>
                         
                         </div>
                      <div class="UpChk">
                         <div class="LabelWidth">Cheque #</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_Cheque" runat="server" TabIndex="14" CssClass="form-control" PlaceHolder="" ToolTip="Cheque #"></asp:TextBox></div>
                         </div>
                      <div class="UpBSR"> 
                         <div class="LabelWidth">
                             BSR Code
                             </div>
                         <div class="FieldInput"><asp:TextBox ID="txt_BSR" runat="server" TabIndex="15" CssClass="form-control" PlaceHolder="" ToolTip="BSR Code"></asp:TextBox></div>
                             
                         </div>
                       <div class="UpCal">
                         <div class="LabelWidth">Deposited On</div>
                         <div class="FieldInput"><asp:TextBox ID="txt_Deposite" runat="server" TabIndex="16" CssClass="form-control" PlaceHolder="" ToolTip="DepositedOn"></asp:TextBox></div>
                         </div>
                     <div class="UpChellan">
                         <div class="LabelWidth">Chellan #</div>
                         <div class="FieldInput"> <asp:TextBox ID="txt_Chellan" runat="server" TabIndex="17" CssClass="form-control" PlaceHolder="" ToolTip="Chellan#"></asp:TextBox></div>
                        </div>
                     </div>
                
                <div class="bordertopNew"></div>
                <div class="FormGroupContent4">
                    <div class="btn ico-get"><asp:Button ID="btn_Get" runat="server" TabIndex="18" ToolTip="Get from Payroll" onclick="btn_Get_Click" /></div>
                    <div class="right_btn MT0 MB05">
                        <div class="btn ico-update"><asp:Button ID="btn_update" TabIndex="19" runat="server" ToolTip="Update" onclick="btn_update_Click" /></div>
                        <div class="btn ico-cancel" id="btn_cancel1" runat="server"> <asp:Button ID="btn_cancel" runat="server" TabIndex="20" ToolTip="Cancel" OnClick="btn_cancel_Click" /></div>
                    </div>

                </div>
                 <div class="bordertopNew"></div>
                <div class="FormGroupContent4">
                    <div class="div_Grid">
        <asp:GridView ID="Grd_TDS" runat="server" AutoGenerateColumns="False" CssClass="NewThemeTbl"
            Width="100%" ForeColor="Black"  ShowHeaderWhenEmpty="True" OnRowDataBound="Grd_TDS_RowDataBound">
            <Columns>
                <asp:BoundField DataField="username" HeaderText="Emp Code" />
                <%--<asp:BoundField DataField="empname" HeaderText="Name" />--%>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <div class="div_Column">
                            <asp:Label ID="lbl_Emp" runat="server" Text='<%#Eval("empname")%>' ToolTip='<%#Eval("empname")%>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="tds" HeaderText="TDS" DataFormatString="{0:##,#0.00}" ItemStyle-CssClass="TxtAlign1">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="surcharge" HeaderText="Sur Charges" DataFormatString="{0:##,#0.00}" ItemStyle-CssClass="TxtAlign1">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="educess" HeaderText="Edu.Chess" DataFormatString="{0:##,#0.00}" ItemStyle-CssClass="TxtAlign1">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="total" HeaderText="Total" DataFormatString="{0:##,#0.00}" ItemStyle-CssClass="TxtAlign1">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="cheque" HeaderText="Cheque #" />
                <asp:BoundField DataField="bsrcode" HeaderText="BSR Code" />
                <asp:BoundField DataField="depdate" HeaderText="Deposited On" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="chellan" HeaderText="Chellan #" />
            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
        </asp:GridView>
    </div>

                    </div>
            </div>
        </div>




   


    <asp:Panel ID="pln_Emp" runat="server" class="div_frame" Style="display: none;">
        <div class="div_close">
            <asp:Image ID="Close_Emp" runat="server" ImageAlign="Baseline" ImageUrl="~/images/GrdClose.gif" />
        </div>
        <div class="div_Break">
        </div>
        <div class="div_frame">
            <iframe id="iframecost" runat="server" src="" frameborder="0" class="frames" style="background-color: #FFFFFF">
            </iframe>
        </div>
    </asp:Panel>
    <div class="div_break">
    </div>
    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_Deposite"
        Format="dd/MM/yyyy">
    </asp:CalendarExtender>
   <asp:ModalPopupExtender ID="Popup_Emp" runat="server" PopupControlID="pln_Emp" BackgroundCssClass="modalBackgroundjob"
        CancelControlID="Close_Emp" TargetControlID="hid1">
    </asp:ModalPopupExtender>

    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>TDSUpdate #</label>

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

    <asp:Label ID="hid1" runat="server"></asp:Label>
    <asp:HiddenField ID="hid" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hid_Empid" runat="server" />
    <asp:HiddenField ID="hid_Incentiveid" runat="server" />
</asp:Content>
