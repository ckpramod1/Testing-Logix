<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="HRAppraisalDetails.aspx.cs" EnableEventValidation="false" Inherits="logix.Home.HRAppraisalDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />

     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>


    <style type="text/css">
        .hide {
            display: none;
        }

        .btnback a {
            display: inline-block;
            padding: 5px 5px 5px 5px;
            text-align: center;
            color: #fff;
            text-decoration: none;
            background-color: #bb2609;
        }

        .Grid tr:last-child {
            color: #e22d0a !important;
        }
        .Gridpnlex {
    height: 350px;
    width: 100%;
    overflow: auto;
}
         .Hide
     {
         display:none;
     }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div class="row PaDtopCtrl">
        <div class="col-md-12  maindiv">
            <!-- Tabs-->
            <div class="widget box">
                <div class="widget-header">
                    <h4><i class="icon-umbrella"></i>HR Appraisal Details</h4>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4"></div>

                    <div class="FormGroupContent4">
                        <div class="EmployeeDetails">


                            <span>Branch Wise Appraisal Details</span>
                            <%-- <asp:LinkButton ID="lnkbtn" runat="server" Style="text-transform: capitalize; color: black; text-decoration: none;"></asp:LinkButton>--%>
                        </div>



                        <div class="PanelBranchWise">

                            <asp:Panel ID="PanelBranchWise" runat="server"  CssClass="Gridpnlex" Visible="true">
                                <asp:GridView ID="GridBranchWise" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="GridBranchWise_RowDataBound" OnSelectedIndexChanged="GridBranchWise_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="Branch" HeaderText="Branch">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                            <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="totemployee" HeaderText="Total Employee" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                            <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="self" HeaderText="Self" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                            <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Appraiser" HeaderText="Appraised" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                            <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Reviewer" HeaderText="Reviewed" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                            <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="COO" HeaderText="Approved" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                            <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="branchid" HeaderText="branchid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                            <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                        </asp:BoundField>
                                          <asp:BoundField DataField="year" HeaderText="year" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                            <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                        </asp:BoundField>

                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                </asp:GridView>
                            </asp:Panel>


                            <div class="Clear"></div>


                        </div>

                    </div>
                    <div class="FormGroupContent4">





                        <span>Deparment Wise Appraisal Details</span>




                        <asp:Panel ID="PaneldepartWise" runat="server"  CssClass="Gridpnlex" Visible="false">
                            <asp:GridView ID="GrddepartWise" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true" OnRowDataBound="GrddepartWise_RowDataBound" OnSelectedIndexChanged="GrddepartWise_SelectedIndexChanged">
                                <Columns>

                                    <asp:BoundField DataField="Department" HeaderText="Department">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="totemployee" HeaderText="Total Employee" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Self" HeaderText="Self" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Appraiser" HeaderText="Appraised" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Reviewer" HeaderText="Reviewed" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                    </asp:BoundField>



                                    <asp:BoundField DataField="COO" HeaderText="Approved" ItemStyle-CssClass="TxtAlign1" HeaderStyle-CssClass="TxtAlign1">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="branchid" HeaderText="branchid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                    </asp:BoundField>


                                    <asp:BoundField DataField="deptid" HeaderText="deptid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                    </asp:BoundField>

                                     <asp:BoundField DataField="year" HeaderText="year" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                    </asp:BoundField>

                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>


                        <div class="Clear"></div>




                    </div>
                    <div class="FormGroupContent4">


                        <span>Employee Wise Appraisal Details</span>


                        <asp:Panel ID="panelemployeewise" runat="server"  CssClass="Gridpnlex" Visible="false">
                            <asp:GridView ID="Grdemployeewise" CssClass="Grid FixedHeader"  runat="server" AutoGenerateColumns="false" Width="100%" ForeColor="Black" EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" Visible="true" OnSelectedIndexChanged="Grdemployeewise_SelectedIndexChanged" OnRowDataBound="Grdemployeewise_RowDataBound">
                                <Columns>

                                    <asp:BoundField DataField="empname" HeaderText="Employee Name">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="empsubon" HeaderText="Submitted On">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="appsubon" HeaderText="Appraised On">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="empconfirmedon" HeaderText="Employee Confirmed On">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="reviewedbyemp" HeaderText="Reviewed By">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                    </asp:BoundField>



                                    <asp:BoundField DataField="ReviewerSubon" HeaderText="Reviewed On">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="CoApprovalOn" HeaderText="CoApprovalOn">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                    </asp:BoundField>

                                     <asp:BoundField DataField="employeeid" HeaderText="employeeid" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="year" HeaderText="year" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="325px" />
                                        <ItemStyle Font-Bold="false" Wrap="true" Width="325px" HorizontalAlign="Justify" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                            </asp:GridView>
                        </asp:Panel>


                        <div class="Clear"></div>





                    </div>

                    <div class="FormGroupContent4">

                        <div class="right_btn MB05">
                            <div class="btnback">
                                <asp:LinkButton ID="lnk_back" runat="server" OnClick="lnk_back_Click">Back to Previous</asp:LinkButton></div>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>















</asp:Content>
