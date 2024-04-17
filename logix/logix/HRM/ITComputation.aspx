<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="ITComputation.aspx.cs" Inherits="logix.HRM.ITComputation" %>

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
    <link href="../Styles/VoucherRegister.css" rel="stylesheet" />
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
     <link href="../Theme/newTheme/css/systemnewdeign.css" rel="stylesheet" />
    <!--=== JavaScript ===-->

  <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

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







    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>    
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>    
    <link href ="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />  
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />

    <style type="text/css" > 
        a img{border: none;}
		ol li{list-style: decimal outside;}
		div#container{width: 780px;margin: 0 auto;padding: 1em 0;}
		div.side-by-side{width: 100%;margin-bottom: 1em;}
		div.side-by-side > div{float: left;width: 50%;}
		div.side-by-side > div > em{margin-bottom: 10px;display: block;}
		.clearfix:after{content: "\0020";display: block;height: 0;clear: both;overflow: hidden;visibility: hidden;}

    </style>
       
    <style type ="text/css" >

         .modalBackground {
             background-color: #333333;
             filter: alpha(opacity=70);
             opacity: 0.7;
         }        

         .modalPopupss {
             background-color: #FFFFFF;            
             border-style: solid;
             border-color: #CCCCCC;
             width: 868px;
             Height: 427px;
             margin-left: 0%;
             margin-top: -1%;
         }                 

         .DivSecPanel
        {
            width:20px; 
            Height:20px; 
            border:2px solid white;
            margin-left:98.3%;
            margin-top: -1.3%;
            border-radius: 90px 90px 90px 90px;
        }
        
         .Gridpnl   
         {
             width: 854px;
            Height:555px;            
         }

         .GridHeader1 
        {
            background-color: navy;
            color: White;
            font-family: sans-serif;
            font-size: 11px;
            margin-left: -0.17%;
            margin-top: -1.7%;
            position: absolute;
            width: 1026px;
        }

         .Break
         {
             clear:both;
         }

         .grd-mt
         {
              display :none;
         }
         .hide
         {
             display:none;
         }
         #Test_foregroundElement 
         {
             left:0px!important; 
             top:66px!important;
         }
         #logix_CPH_pln_popup {
    left: 133px !important;
    top: 70px !important;
}
         .div_MenuNew {
    background-color: White;
    height: 580px;
    margin-left: auto;
    margin-right: auto;
    margin-top: 4%;
    width: 100% !important;
}

        .empcodelinkl {
             width:6%; float:left; margin:0px 0.5% 0px 0px;
        } 
.empcodelinkl a {
    color: #000 !important;
    font-size: 11px;
   

}
.FloatLeft {
    width: 40%;
    float: left;
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
   
    <link href="../Styles/ITComputation.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script type="text/javascript">

        function pageLoad(sender, args)
        {
            $(document).ready(function () {
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            });
        }



        function CheckFinYear() {
            if ((document.getElementById('ddl_Year').value == "0") || (document.getElementById('ddl_Year').value == "")) {
                alertify.alert('Select Financial Year');
                return false;
            }
            else {
                return true;
            }
        }

        function CheckEmpCode()
        {
            if((document.getElementById('txt_Empcode').value=="") ||(document.getElementById('txt_Empcode').value=="0"))
            {
                alertify.alert('Employee Code Cannot Be Blank');
                return false;
            }
            else
            {
                return true;
            }
        }

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <!-- Breadcrumbs line -->
          <div class="crumbs" id="crumbslabel" runat="server">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">IT Workings</a> </li>
              <li class="current"> ITComputation</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->

       <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/itcomputation_ic.png" /><asp:Label ID="lbl_Header" runat="server" Text="ITComputation"></asp:Label>
       
          <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>

      </h3>
    </div>
        <div class="Form-ControlBg">
                <div class="FormGroupContent4">
                  <div class="right_btn MT0">
                      <div class="ITCDrop">
                          <div class="LabelWidth">
                              Financial Year
                          </div>
                          <div class="FieldInput"> <asp:DropDownList ID="ddl_Year" runat="server" CssClass="chzn-select" AutoPostBack="true" data-placeholder="Financial Year" ToolTip="Financial Year" Visible="true" OnSelectedIndexChanged="ddl_Year_SelectedIndexChanged">
                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                </asp:DropDownList></div>
                           
                      </div>
                  </div>



                  </div>
               <div class="FormGroupContent4">
                   <div class="ITCEmp MTCtrl6" id="lnk_empcode1" runat="server">
                       <asp:LinkButton ID="lnk_empcode" runat="server" style="text-decoration:none;"  onclick="lnk_empcode_Click">EmpCode</asp:LinkButton>
                       <%--<asp:Label ID="lnk_empcode"  runat="server" CssClass="LabelValue"  Text="EmpCode"></asp:Label>--%>
                   </div>
                   <div class="ITCEmpCode">
                       <div class="LabelWidth">Emp Code</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Empcode" runat="server" TabIndex="1" AutoPostBack="True" ontextchanged="txt_Empcode_TextChanged" CssClass="form-control"  placeholder="" ToolTip="Empcode" MaxLength="4"></asp:TextBox></div>
                       </div>
                   <div class="ITCEmpname">
                       <div class="LabelWidth">Emp Name</div>
                       <div class="FieldInput"> <asp:TextBox ID="txt_Name" runat="server" ReadOnly="True" TabIndex="2" CssClass="form-control"  placeholder="" ToolTip="EmpName"></asp:TextBox></div>
                      </div>
                   <div class="ITCDepart">
                       <div class="LabelWidth">Department</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Dept" runat="server" ReadOnly="True" TabIndex="3" CssClass="form-control"  placeholder="" ToolTip="Department"></asp:TextBox></div>
                       </div>
                   <div class="ITCDesi">
                       <div class="LabelWidth">Designation</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Desg" runat="server" ReadOnly="True" TabIndex="4" CssClass="form-control" placeholder="" ToolTip="Designation"></asp:TextBox></div>
                       </div>
                   <div class="ITCCom">
                       <div class="LabelWidth">Company</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Company" runat="server" ReadOnly="True" TabIndex="5" CssClass="form-control" placeholder="" ToolTip="Company"></asp:TextBox></div>
                       </div>
                   <div class="ITCGrade">
                       <div class="LabelWidth">Grade</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_Grade" runat="server" ReadOnly="True" TabIndex="6" CssClass="form-control" placeholder="" ToolTip="Grade"></asp:TextBox></div>
                       
                       </div>
                   <div class="ITCDOJ">
                       <div class="LabelWidth">DOJ</div>
                       <div class="FieldInput"><asp:TextBox ID="txt_DOJ" runat="server" ReadOnly="True" TabIndex="7" CssClass="form-control" placeholder="" ToolTip="Date Of Joining"></asp:TextBox></div>
                       
                       </div>
                   </div>
              <div class="bordertopNew"></div>
              <div class="FormGroupContent4">
                  <div class="FloatLeft">
                      <div class="btn btn-compare1"> <asp:Button ID="BtnCompare" runat="server" TabIndex="8" ToolTip="Compare" OnClick="BtnCompare_Click"/></div>

                      </div>
                    <div class="FloatLeft">
                     <asp:Label ID="lblMsg" runat="server" Width="200px"></asp:Label>
            <asp:Label ID="lblMsg1" runat="server" Width="180px"></asp:Label>
                        </div>
                  <div class="right_btn MT0 MB05">
                      <div class="btn ico-get" id="btn_get1" runat="server"> <asp:Button ID="btn_Get" runat="server" TabIndex="9" ToolTip="Get" onclick="btn_Get_Click"/></div>
                      <div class="btn ico-cancel" id="btn_cancel1" runat="server"><asp:Button ID="btn_Clear" runat="server" TabIndex="10" ToolTip="Cancel" onclick="btn_Clear_Click" /></div>
                  </div>
              </div>
               <div class="bordertopNew"></div>
               <div class="FormGroupContent4">
                   <div class="div_Grid">
        <asp:GridView ID="Grd_IT" runat="server"  CssClass="NewThemeTbl"  ForeColor="Black" AutoGenerateColumns="False"  Width="100%" ShowHeaderWhenEmpty="True" OnRowDataBound="Grd_IT_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Particulars" HeaderText="Particulars" >
                <ItemStyle  Width="650px" />
            </asp:BoundField>
            <asp:BoundField DataField="Monthly" HeaderText="Monthly" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" >
                <ItemStyle HorizontalAlign="Right" Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="Yearly" HeaderText="Yearly" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1" >
                <ItemStyle HorizontalAlign="Right" Width="50px" />
            </asp:BoundField>
        </Columns>
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
        </asp:GridView>
        </div>

                   </div>
                <div class="FormGroupContent4">
                    <div class="right_btn MT0 MB05">
                         
            
                        <div class="btn ico-update"><asp:Button ID="btn_Save" runat="server" ToolTip="Update" onclick="btn_Save_Click" /></div>
                        <div class="btn ico-view"><asp:Button ID="btn_View" runat="server" ToolTip="View" onclick="btn_View_Click" /></div>
                    </div>

                   </div>

          </div>
           </div>








    <%----------------------------- COMPARE ------------------------------%>

    <asp:Label ID="Label2" runat="server"></asp:Label>
    <div class="div_Break"></div>
 
    <asp:ModalPopupExtender ID="programmaticModalCancelCredit" runat="server" PopupControlID="pln_popup" TargetControlID="Label2" CancelControlID="Close" BehaviorID="Test" DropShadow="false">
    </asp:ModalPopupExtender>

    <asp:Panel ID="pln_popup" runat="server"  CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" style="display:none;" >
       
    <div class="DivSecPanel"> 
        <asp:Image ID="Close" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%"/>  
    </div>
             
    <asp:Panel ID="Panel3" runat="server"  CssClass="Gridpnl">
        <asp:TextBox ID="txtTest" runat="server" Visible="false"></asp:TextBox>
        <asp:GridView ID="GVCmpre" runat="server" AutoGenerateColumns="false" AllowPaging="false" PageSize="15" Width="100%" CssClass="Grid FixedHeader"  ForeColor="Black" EmptyDataText="No Records Found" Visible="true" ShowHeaderWhenEmpty="true" OnPageIndexChanging="GVCmpre_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="Particulars" HeaderText="Particulars" />
                <asp:BoundField DataField="CurMonth" HeaderText="Cur Month" DataFormatString="{0:0.00}">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>                     
                <asp:BoundField DataField="Parti" HeaderText="Particulars" />
                <asp:BoundField DataField="PreMonth" HeaderText="Pre Month" DataFormatString="{0:0.00}" > 
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
                             
            <PagerStyle CssClass="GridviewScrollPager" />                            
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <AlternatingRowStyle CssClass="GrdAltRow" />

        </asp:GridView>

    </asp:Panel>         
        </asp:Panel>
        <div class="div_Break"></div>

        <%-- <asp:Panel ID="pln_Emp" runat="server" class="div_frame" Style="display: none;">
    <div class="div_close">
    <asp:Image ID="Close_Emp" runat="server" ImageAlign="Baseline" ImageUrl="~/images/GrdClose.gif" />
    </div>
    <div class="div_Break"></div>
    <div class="div_frame">
    <iframe id="iframecost" runat="server" src="" frameborder="0" class="frames" style="background-color: #FFFFFF"></iframe>
    </div>
    </asp:Panel>
    <div class="div_break"></div>
    <asp:ModalPopupExtender ID="Popup_Emp" runat="server" PopupControlID="pln_Emp" CancelControlID="Close_Emp" TargetControlID="hid" DropShadow="false"></asp:ModalPopupExtender> --%>
          
     <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label>ITComputation #</label>

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

    <asp:HiddenField ID="hid" runat="server" />
    <asp:HiddenField ID="hid_Title" runat="server" />    

</asp:Content>
