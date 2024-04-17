<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Transfer From ICD.aspx.cs" Inherits="logix.ShipmentDetails.Transfer_From_ICD" %>

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
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->





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




    <link href="../Styles/jquery-ui.css" rel="stylesheet" />
    <link href="../Styles/TransferFromICD.css" rel="stylesheet" />
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <%--<script src="../Scripts/gridviewScroll.min.js"></script>--%>
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />

    <style type="text/css">
        .modalBackground {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .DivSecPanel {
            width: 20px;
            height: 20px;
            border: 2px solid white;
            margin-left: 98.3%;
            margin-top: 0%;
            border-radius: 90px 90px 90px 90px;
        }

        .Break {
            clear: both;
        }

        .grd-mt {
            display: none;
        }

        .Hide {
            display: none;
        }

        .Gridfi {
            /*cursor:hand;
    margin-top:-1;
     font-family:sans-serif;*/
            width: 550px;
            font-family: sans-serif;
            font-size: 10pt;
            color: Black;
            margin-top: 0px;
        }

        .GridCellDiv {
            width: 70px !important;
        }

        #programmaticModalPopupBehavior1_foregroundElement {
            left: 0px !important;
            top: 50px !important;
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
            width: 65%;
            float: left;
            margin: 2px 0px 3px 4px;
        }

            .LogHeadLbl label {
                color: #af2b1a;
                font-weight: bold;
                font-size: 12px;
            }



        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LogHeadJobInput label {
            font-size: 12px;
        }


        .LogHeadJobInput {
            width: 15%;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 12px;
                margin: 4px 0px 0px 0px;
            }




            .LogHeadJobInput label {
                font-size: 12px;
                font-family: sans-serif;
                color: #4e4e4c;
            }

        .JOBInput7 {
            width: 10%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .modalPopupss {
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


        .JOBInput7 {
            font-size: 12px;
        }




        .Gridpnl {
            width: 99% !important;
            height: 91%;
            border: 1px solid #b1b1b1;
            margin: 0 auto !important;
            overflow-y: scroll;
            overflow-x: auto;
        }

        .divRoated {
            width: 90%;
            height: 75vh;
            overflow: hidden;
            background: #fff;
            border-radius: 3px;
        }
      
        .widget.box .widget-content {
    top: 0;
}
        a#logix_CPH_joblink {
    display: inline-block;
}
       .gridpnl {
    height: calc(100vh - 127px);
}
        

/*New Design - Buttons*/



 
div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 65px !important;
}
table#logix_CPH_GrdToPol tbody td:nth-child(2) {
    max-width: 250px !important;
}
table#logix_CPH_GrdToPol tbody td:nth-child(3) {
            max-width: 187px !important;
        }
table#logix_CPH_GrdToPol tbody td:nth-child(8) {
    width: 6% !important;
}
    </style>




    <script type="text/javascript">
        function pageLoad(sender, args) {
        <%--        
        $('#<%=GrdToPol.ClientID%>').gridviewScroll({
            width: 1000,
            height: 400

    
        });--%>
       <%-- $(document).ready(function () {
            $('#<%=GrdToPol.ClientID%>').gridviewScroll({
                width: 845,
                height: 376,
                arrowsize: 30,

                varrowtopimg: "../images/arrowvt.png",
                varrowbottomimg: "../images/arrowvb.png",
                harrowleftimg: "../images/arrowhl.png",
                harrowrightimg: "../images/arrowhr.png"
            });
        });--%>

    }
    </script>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">



    <!-- /Breadcrumbs line -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">

                <div class="widget-header">
                    <div>
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lblMeText" runat="server" Text="Copy From Other Office"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
                        <div class="crumbs">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <li><a href="#" title="">Documentation</a> </li>
                                <li><a href="#" title="" id="headerlable1" runat="server">Ocean Exports</a> </li>
                                <li class="current"><a href="#" title="" id="menu" runat="server">Copy TO Other Office</a> </li>
                            </ul>
                        </div>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                    </div>
                    <div class="FixedButtons">
     <div class="right_btn">
        <div class="btn ico-transfer-from-icd">
            <asp:Button ID="btntranfer" runat="server"  Text="Copy From" ToolTip="Transfer" OnClick="btntranfer_Click" />
        </div>
        <div class="btn ico-back" id="btnback1" runat="server">
            <asp:Button ID="btnback" runat="server" ToolTip="Cancel" Text="Cancel" OnClick="btnback_Click" />
        </div>
    </div>
</div>


                </div>
                <div class="widget-content">
                    
                    <div class="FormGroupContent4 boxmodal hide">
                        <div class="JOBInput7">
                            <span>Job #</span>
                            <asp:TextBox ID="txtJob" placeholder="" ToolTip="Job Number" runat="server" CssClass="form-control" Width="100%" OnTextChanged="txtJob_TextChanged" AutoPostBack="True"></asp:TextBox>
                        </div>
                        <div class="boxmodalLink_box">
                    <asp:LinkButton ID="joblink" CssClass="anc ico-find-sm" runat="server" Style="color: red; text-decoration: none;" OnClick="joblink_Click">J</asp:LinkButton>
                        </div>
                    </div>
                    <div class="FormGroupContent4 boxmodal">
                        <asp:Panel ID="panel" runat="server" CssClass="gridpnl MB0">

                            <asp:GridView ID="GrdToPol" runat="server" CssClass="Grid FixedHeader" AutoGenerateColumns="False" PageSize="20" AllowPaging="false" OnRowDataBound="Grd_RowDataBound" ShowHeaderWhenEmpty="true" OnPageIndexChanging="grd_PageIndexChanging" OnPreRender="GrdToPol_PreRender">
                                <Columns>
                                    <asp:TemplateField HeaderText="BL #">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                <asp:Label ID="blno" runat="server" Text='<%# Bind("blno") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Shipper">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 252px">
                                                <asp:Label ID="shipper" runat="server" Text='<%# Bind("shipper") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Consignee">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 200px">
                                                <asp:Label ID="consignee" runat="server" Text='<%# Bind("consignee") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="POR">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 106px">
                                                <asp:Label ID="por" runat="server" Text='<%# Bind("por") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="75px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="75px"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="POL">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                                <asp:Label ID="pol" runat="server" Text='<%# Bind("pol") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="POD">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 115px">
                                                <asp:Label ID="pod" runat="server" Text='<%# Bind("pod") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="72px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="72px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PLD">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 115px">
                                                <asp:Label ID="fd" runat="server" Text='<%# Bind("fd") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="65px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="65px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch">
                                        <ItemTemplate>
                                            <div style="overflow: hidden; text-overflow: ellipsis; width: 62px">
                                                <asp:Label ID="shortname" runat="server" Text='<%# Bind("shortname") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="true" Width="100px" HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" Width="100px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Branchid" DataField="branchid">

                                        <HeaderStyle CssClass="Hide" />
                                        <ItemStyle CssClass="Hide" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkStatus" runat="server" AutoPostBack="true" />
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="20px" />
                                        <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>

                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <PagerStyle CssClass="GridviewScrollPager" />
                                <RowStyle CssClass="GrdRow" />
                            </asp:GridView>
                        </asp:Panel>

                    </div>

                 

                    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label id="lbl_no" runat="server">Job #:</label>

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
                </div>
            </div>
        </div>
    </div>


    <%---------------------------------------popup-------------------------------------------------------------%>
    <asp:Label ID="lblpopup" runat="server"></asp:Label>
    <ajaxtoolkit:ModalPopupExtender ID="ProgrammaticModalJobICD" runat="server" TargetControlID="lblpopup" BehaviorID="programmaticModalPopupBehavior1"
        PopupControlID="POpupJob" CancelControlID="Close_voucher" DropShadow="false"
        PopupDragHandleControlID="GrdCreditAmt" RepositionMode="RepositionOnWindowScroll">
    </ajaxtoolkit:ModalPopupExtender>

    <asp:Panel ID="POpupJob" runat="server" CssClass="modalPopup" Style="display: none;">
        <div class="divRoated">
            <div class="DivSecPanel">
                <asp:Image ID="Close_voucher" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
            </div>


            <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">
                <asp:GridView ID="GrdJobICD" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="False" Width="100%"
                    AllowPaging="false" PageSize="20" OnPageIndexChanging="GrdJobICD_PageIndexChanging"
                    ForeColor="Black" OnRowDataBound="GrdJobICD_RowDataBound" OnSelectedIndexChanged="GrdJobICD_SelectedIndexChanged">

                    <Columns>
                        <asp:BoundField DataField="jobno" HeaderText="Job#">
                            <ControlStyle Width="600px" />
                            <HeaderStyle Width="50px" />
                            <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="52px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Vessel">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                    <asp:Label ID="vessel" runat="server" Text='<%# Bind("vessel") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Voyage" DataField="voyage">
                            <HeaderStyle HorizontalAlign="Center" Width="76px" />
                            <ItemStyle HorizontalAlign="Left" Width="76px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="MBL #" DataField="mblno">
                            <HeaderStyle HorizontalAlign="Center" Width="90px" />
                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ETD" DataField="etd">
                            <HeaderStyle HorizontalAlign="Center" Width="97px" />
                            <ItemStyle HorizontalAlign="Left" Width="97px" />

                        </asp:BoundField>
                        <asp:BoundField HeaderText="Destination" DataField="sd">
                            <HeaderStyle HorizontalAlign="Center" Width="90px" />
                            <ItemStyle HorizontalAlign="Left" Width="90px" />

                        </asp:BoundField>
                        <asp:BoundField HeaderText="ETA" DataField="eta">
                            <HeaderStyle HorizontalAlign="Center" Width="90px" />
                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="MLO">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 90px">
                                    <asp:Label ID="mlo" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="90px" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="90px"></ItemStyle>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText ="MLO" HeaderStyle-ForeColor="White">
               <ItemTemplate>   
             <div style="overflow:hidden;text-overflow:ellipsis;width:150px">
                    <asp:Label ID="mlo" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                    </div>
                    </ItemTemplate>
                    <HeaderStyle Wrap="false" Width="150px"  HorizontalAlign="Center"  />
                    <ItemStyle Wrap="false" HorizontalAlign="Left"></ItemStyle>                      
                    </asp:TemplateField>--%>
                    </Columns>

                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <RowStyle CssClass="GrdRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>


                <asp:GridView ID="GrdFIJob" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="20" OnPageIndexChanging="GrdFIJob_PageIndexChanging"
                    Width="100%" ForeColor="Black" OnRowDataBound="GrdFIJob_RowDataBound" OnSelectedIndexChanged="GrdFIJob_SelectedIndexChanged">

                    <Columns>

                        <asp:BoundField DataField="jobno" HeaderText="Job #">
                            <HeaderStyle Width="42px" />
                            <ItemStyle Font-Bold="false" HorizontalAlign="Justify" Width="52px" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Vessel">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                    <asp:Label ID="vesselname" runat="server" Text='<%# Bind("vesselname") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="10pt" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="10pt"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Voyage">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                    <asp:Label ID="voyage" runat="server" Text='<%# Bind("voyage") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="10pt" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="10pt"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MBL #">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 80px">
                                    <asp:Label ID="mblno" runat="server" Text='<%# Bind("mblno") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="10pt" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="10pt"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ETA">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                    <asp:Label ID="eta" runat="server" Text='<%# Bind("eta") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="10pt" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="10pt"></ItemStyle>
                        </asp:TemplateField>



                        <asp:TemplateField HeaderText="ETB">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                    <asp:Label ID="etd" runat="server" Text='<%# Bind("etd") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="10pt" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="10pt"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="POL">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                    <asp:Label ID="POL" runat="server" Text='<%# Bind("POL") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="10pt" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="10pt"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Agent">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 100px">
                                    <asp:Label ID="agent" runat="server" Text='<%# Bind("agent") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="10pt" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="10pt"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MLO / FFR">
                            <ItemTemplate>
                                <div style="overflow: hidden; text-overflow: ellipsis; width: 70px">
                                    <asp:Label ID="mlo" runat="server" Text='<%# Bind("mlo") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle Wrap="false" Width="10pt" HorizontalAlign="Center" />
                            <ItemStyle Wrap="false" HorizontalAlign="Left" Width="10pt"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>


                <asp:GridView ID="grd_airline" runat="server" AutoGenerateColumns="False" Width="100%"
                    OnRowDataBound="grd_airline_RowDataBound" AllowPaging="false" PageSize="20" OnPageIndexChanging="grd_airline_PageIndexChanging"
                    HorizontalAlign="Left" CssClass="Grid FixedHeader" OnSelectedIndexChanged="grd_airline_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="jobno" HeaderText="Job #">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="airline" HeaderText="AirLine">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="mawblno" HeaderText="MAWBL #">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="flightdate" HeaderText="Flight">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="agentname" HeaderText="Agent" Visible="false">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>

                    </Columns>
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="" />
                    <AlternatingRowStyle CssClass="GrdAltRow" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>

            </asp:Panel>
        </div>

    </asp:Panel>

    <asp:Label ID="lbllog1" runat="server"></asp:Label>

    <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="lbllog1" CancelControlID="imglog" BehaviorID="Test1">
    </ajaxtoolkit:ModalPopupExtender>

</asp:Content>
