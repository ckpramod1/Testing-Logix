<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CooEmpList.aspx.cs" Inherits="logix.Home.CooEmpList" %>

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
    <style type="text/css">
        .div_grd {
            width: 100%;
            margin-top: 0%;
            margin-bottom: 1%;
            height: 200px;
            margin-left: 0%;
            border: 1px solid gray;
        }

            .div_grd input {
                width: 98%;
            }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopupss {
            background-color: #B3E5FC;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 140px;
        }

        .FormGroupContent4 textarea {
            height: 48px !important;
        }

        .brdernone {
            border: 0px solid #f00 !important;
        }

        .LabelValue {
            font-family: sans-serif;
            font-size: 11px;
            color: #4e4c4c;
            font-weight: normal;
            text-align: right;
            font-weight: bold;
        }

        .row {
            height: 563px !important;
            margin: 0px 5px 0px -15px;
            clear: both;
            overflow-x: hidden !important;
            overflow-y: auto !important;
            /* width: 100%; */
        }

          .right{
            text-align:right!important;
        }
        .AppraisalHead {
            float:left;
            width:18%;
            margin:0px 0.5% 5px 0px;
        }
            .AppraisalHead a {
                text-decoration:none;
                color:#e83904;
                

            }
        .AppraisalCombobox {
            float:left;
            width:25%;
            margin:0px 0px 5px 0px;
        }
        .chzn-drop {
    height: 150px !important;
    overflow: auto;
}

        .div_grdNew {
    width: 100%;
    margin-top: 3.6%;
    margin-bottom: 1%;
    
    margin-left: 0%;
    border: 1px solid gray;
}





    </style>
    
    <link href="../Styles_Date/jquery1-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Script_Date/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script_Date/jquery-ui.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

    <script type="text/javascript">

        function pageLoad(sender, args) {

            $(document).ready(function () {
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            });





        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <div >
        <div class="col-md-12  maindiv">
            <div class="widget box brdernone" runat="server">
                <div class="widget-content">


                    <div class="FormGroupContent4 bgclrNew">
                         <div style="float:left; width:40%">
                        <asp:Label ID="lblapp2" runat="server" Text="To be Approved" CssClass="LabelValue"></asp:Label>
                             </div>
                        <div style="float:right;width:60%;text-align:right;">
                            <asp:LinkButton ID="lnkempapplist" runat="server" Font-Underline="true" OnClick="lnkempapplist_Click" Text="Appraised List" style ="text-transform: capitalize;color:#f00;font-weight:bold;text-underline-position:below"></asp:LinkButton>
                        </div>

                    </div>
                    <div style="float: left; width: 40%;">
                        <div class="FormGroupContent4">
                             <div class="AppraisalHead"><asp:linkbutton ID="appraisalyr" runat="server">Appraisal Year</asp:linkbutton></div>
                                <div class="AppraisalCombobox"> <asp:DropDownList ID="ddl_AYear"  CssClass="chzn-select" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddl_AYear_SelectedIndexChanged" >
                                        <asp:ListItem Value="0">2016-2017</asp:ListItem>
                                        <asp:ListItem Value="1">2017-2018</asp:ListItem>
                                    </asp:DropDownList></div>
                            <asp:Panel ID="Panel2" runat="server" Width="100%" CssClass="div_grd" Height="121px"
                                ScrollBars="Vertical">
                               
                                <asp:GridView ID="gvdivision" runat="server" AutoGenerateColumns="False" Height="100%" Width="100%" CssClass="Grid FixedHeader" 
                                    DataKeyNames="divisionid" ShowHeaderWhenEmpty="true" OnSelectedIndexChanged="gvdivision_SelectedIndexChanged" OnRowDataBound="gvdivision_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsno" runat="server" Text='<%# Eval("sno")  %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="5%" Font-Size="small" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Division">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("divisionName")  %>' ToolTip='<%# Eval("divisionName")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="25%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tot Employee">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("totemployee")  %>' ToolTip='<%# Eval("totemployee")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="8%" />

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Self">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails1" runat="server" Text='<%# Eval("self")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="false" Font-Size="Small" Width="8%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Appraiser">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldept" runat="server" Text='<%# Eval("Appraiser")  %>' ToolTip='<%# Eval("Appraiser")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="10%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Review">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("Reviewer")  %>' ToolTip='<%# Eval("Reviewer")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="10%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="COO">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("COO")  %>' ToolTip='<%# Eval("COO")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="7%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Increment">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsalary3" runat="server" Text='<%# String.IsNullOrEmpty(Eval("Salary").ToString()) ?  "" :  string.Format("{0:0.00}",Convert.ToDouble(Eval("Salary").ToString())) %>' ToolTip='<%# Eval("Salary")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="7%" HorizontalAlign="right" />

                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>



                            <asp:Panel ID="Panel3" runat="server" Width="100%" Visible="false" CssClass="div_grd" Height="160px"
                                ScrollBars="Vertical">
                                <asp:GridView ID="gvbranch" runat="server" AutoGenerateColumns="False" Height="100%" Width="100%" CssClass="Grid FixedHeader" 
                                    DataKeyNames="branchid" ShowHeaderWhenEmpty="true" OnSelectedIndexChanged="gvbranch_SelectedIndexChanged" OnRowDataBound="gvbranch_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsno" runat="server" Text='<%# Eval("sno")  %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="5%" Font-Size="small" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Branch">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("branch")  %>' ToolTip='<%# Eval("branch")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="25%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Employee">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("totemployee")  %>' ToolTip='<%# Eval("totemployee")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="10%" />

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Self">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails1" runat="server" Text='<%# Eval("self")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="false" Font-Size="Small" Width="8%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Appraiser">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldept" runat="server" Text='<%# Eval("Appraiser")  %>' ToolTip='<%# Eval("Appraiser")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="10%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Review">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("Reviewer")  %>' ToolTip='<%# Eval("Reviewer")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="10%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="COO">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("COO")  %>' ToolTip='<%# Eval("COO")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="7%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Increment">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsalary1" runat="server" Text='<%# String.IsNullOrEmpty(Eval("Increment").ToString()) ?  "" :  string.Format("{0:0.00}",Convert.ToDouble(Eval("Increment").ToString())) %>' ToolTip='<%# Eval("Increment")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="7%" HorizontalAlign="right" />

                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>

                            <asp:Panel ID="Panel4" runat="server" Width="100%" Visible="false" CssClass="div_grd" Height="159px"
                                ScrollBars="Vertical">
                                <asp:GridView ID="gvdept" runat="server" AutoGenerateColumns="False" Height="100%" Width="100%" CssClass="Grid FixedHeader" 
                                    DataKeyNames="deptid" ShowHeaderWhenEmpty="true" OnSelectedIndexChanged="gvdept_SelectedIndexChanged" OnRowDataBound="gvdept_RowDataBound">
                                    <Columns>
                                         <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsno" runat="server" Text='<%# Eval("sno")  %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="5%" Font-Size="small" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Department">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("department")  %>' ToolTip='<%# Eval("department")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="25%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Employee">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("totemployee")  %>' ToolTip='<%# Eval("totemployee")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="10%" />

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Self">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails1" runat="server" Text='<%# Eval("self")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="false" Font-Size="Small" Width="8%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Appraiser">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldept" runat="server" Text='<%# Eval("Appraiser")  %>' ToolTip='<%# Eval("Appraiser")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="10%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Review">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("Reviewer")  %>' ToolTip='<%# Eval("Reviewer")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="10%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="COO">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("COO")  %>' ToolTip='<%# Eval("COO")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="7%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Increment">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsalary2" runat="server" Text='<%# String.IsNullOrEmpty(Eval("Increment").ToString()) ?  "" :  string.Format("{0:0.00}",Convert.ToDouble(Eval("Increment").ToString())) %>' ToolTip='<%# Eval("Increment")  %>'  ></asp:Label>
                                            </ItemTemplate>
                                            
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="7%" HorizontalAlign="right"  />

                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>

                        </div>

                    </div>
                    <div style="float: left; width: 59%; margin: 0px 0px 0px 10px;">
                        <div class="FormGroupContent4">
                            <asp:Panel ID="Panel1" runat="server" Visible="false" Width="100%" Height="452px" CssClass="div_grdNew"
                                ScrollBars="Vertical">
                                <asp:GridView ID="gvcomp" runat="server" AutoGenerateColumns="False" Height="100%" Width="100%" CssClass="Grid FixedHeader" 
                                    DataKeyNames="empid" ShowHeaderWhenEmpty="true" OnSelectedIndexChanged="gvcomp_SelectedIndexChanged" OnRowDataBound="gvcomp_RowDataBound">
                                    <Columns>
                                       <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsno" runat="server" Text='<%# Eval("sno")  %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="5%" Font-Size="small" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Employee Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("empname")  %>' ToolTip='<%# Eval("empname")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="20%" />

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Emp Submit On">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails1" runat="server" Text='<%# Eval("empsubon")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="false" Font-Size="Small" Width="10%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Appraised On">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldept" runat="server" Text='<%# Eval("appsubon")  %>' ToolTip='<%# Eval("appsubon")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="12%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Confirmed On">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("empconfirmedon")  %>' ToolTip='<%# Eval("empconfirmedon")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="12%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reviewed By">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("Reviewedby")  %>' ToolTip='<%# Eval("Reviewedby")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="21%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reviewed On">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("Reviewedon")  %>' ToolTip='<%# Eval("Reviewedon")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="10%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Increment">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsalary4" runat="server" Text='<%# String.IsNullOrEmpty(Eval("Increment").ToString()) ?  "" :  string.Format("{0:0.00}",Convert.ToDouble(Eval("Increment").ToString())) %>' ToolTip='<%# Eval("Increment")  %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="7%" HorizontalAlign="right" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                    </div>

                     <div>
                         <div class="FormGroupContent4">
                            <asp:Panel ID="Panel5" runat="server" Visible="false" Width="100%" Height="440px" CssClass="div_grd"
                                ScrollBars="Vertical">
                                <asp:GridView ID="grdsal" runat="server" AutoGenerateColumns="false" Height="100%" Width="100%" CssClass="Grid FixedHeader" 
                                    ShowHeaderWhenEmpty="true" >
                                   <Columns>
                                       <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsno1" runat="server" Text='<%# Eval("S#")  %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="4%" Font-Size="small" />
                                        </asp:TemplateField>

                                       <asp:TemplateField HeaderText="EmpCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblempcode" runat="server" Text='<%# Eval("empcode")  %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="4%" Font-Size="small" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Employee Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblename" runat="server" Text='<%# Eval("empname")  %>' ToolTip='<%# Eval("empname")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="25%" />

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Branch">
                                            <ItemTemplate>
                                                <asp:Label ID="lblbrancg1" runat="server" Text='<%# Eval("branch")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="false" Font-Size="Small" Width="10%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Department">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldep" runat="server" Text='<%# Eval("department")  %>' ToolTip='<%# Eval("department")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="23%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Designation">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldes" runat="server" Text='<%# Eval("designation")  %>' ToolTip='<%# Eval("designation")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="10%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgrd1" runat="server" Text='<%# Eval("grade")  %>' ToolTip='<%# Eval("grade")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="5%" />

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gross">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgross" runat="server" Text='<%# String.IsNullOrEmpty(Eval("gross").ToString()) ?  "" :  string.Format("{0:0.00}",Convert.ToDouble(Eval("gross").ToString())) %>' ToolTip='<%# Eval("gross")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="10%" HorizontalAlign="Right" CssClass="right" />

                                        </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Increment">
                                            <ItemTemplate>
                                                <asp:Label ID="lblincre" runat="server" Text='<%# String.IsNullOrEmpty(Eval("incrementamt").ToString()) ?  "" :  string.Format("{0:0.00}",Convert.ToDouble(Eval("incrementamt").ToString())) %>' ToolTip='<%# Eval("incrementamt")  %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="10%" HorizontalAlign="Right" CssClass="right" />

                                        </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Revised Gross">
                                            <ItemTemplate>
                                                <asp:Label ID="lblrgross" runat="server" Text='<%# String.IsNullOrEmpty(Eval("revisedgross").ToString()) ?  "" :  string.Format("{0:0.00}",Convert.ToDouble(Eval("revisedgross").ToString())) %>' ToolTip='<%# Eval("revisedgross")  %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="10%" HorizontalAlign="Right" CssClass="right" />
                                        </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Revised Desig">
                                            <ItemTemplate>
                                                <asp:Label ID="lblrdesig" runat="server" Text='<%# Eval("reviseddesignation")  %>' ToolTip='<%# Eval("reviseddesignation")  %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width="20%"  />
                                        </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Revised Grade">
                                            <ItemTemplate>
                                                <asp:Label ID="lblrgrade" runat="server" Text='<%# Eval("revisedgrade")  %>' ToolTip='<%# Eval("revisedgrade")  %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Wrap="true" Font-Size="Small" Width= "5%"  />
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>


                             <div class="right_btn">
                     <div class="btn ico-view"><asp:Button ID="btn_view" runat="server" OnClick="btn_view_Click" Visible="false" Enabled="true" Text="Export Excel"  TabIndex="27"  /></div>
                   
                      <div class="btn ico-cancel"><asp:Button ID="btnCancel" OnClick="btnCancel_Click" Visible="false" runat="server" Text="Back"  TabIndex="28" /></div>
                             </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>







</asp:Content>
