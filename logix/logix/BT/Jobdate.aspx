<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Jobdate.aspx.cs" Inherits="logix.BT.Jobdate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/jobdate.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <div class="div_total">
        <div class="Header"><asp:Label ID="lbl_head" runat="server" Text="Jobdate" CssClass="lbl_Header"></asp:Label></div>
        <div class="div_Break"></div>
        <div class="div_from"> <asp:Label ID="lbl_from" runat="server" Text="From" CssClass="LabelValue"></asp:Label></div>
        <div class="txt_from"> <asp:TextBox ID="txt_from" runat="server"  CssClass="Text" ToolTip="From" placeholder="From"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_from"
            Format="dd/MM/yyyy">
        </asp:CalendarExtender>
        </div>
        <div class="div_from"> <asp:Label ID="Label1" runat="server" Text="To" CssClass="LabelValue"></asp:Label></div>
        <div class="txt_from"> <asp:TextBox ID="txt_to" runat="server"  CssClass="Text" ToolTip="To" placeholder="To"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_to"
            Format="dd/MM/yyyy">
        </asp:CalendarExtender>
        </div>
        <div class="div_button"><asp:Button ID="btn_get" runat="server" Text="Get" CssClass="Button" OnClick="btn_get_Click" /></div>
        <div class="div_button"><asp:Button ID="btn_print" runat="server" Text="Print" CssClass="Button" OnClick="btn_print_Click" /></div>
        <div class="div_button"><asp:Button ID="btn_cancel" runat="server" Text="Back" CssClass="Button" OnClick="btn_cancel_Click" /></div>
        <div class="div_Break"></div>
         <asp:Panel ID="Pln_MIS" runat="server" >
            <asp:Label ID="lbl_MISA" runat="server" Text="Job Opened And Sailed/Arrived during the given date range"
                ForeColor="Red" CssClass="LabelValue"></asp:Label>
            <br />
            <asp:Panel ID="pnl_MISA" runat="server" Height="120px" ScrollBars="Vertical">
                 <asp:GridView ID="Grd_MISA" runat="server" CssClass="div_GridNew3" Width="100%" ForeColor="Black"
                     ShowHeaderWhenEmpty="true" ShowHeader="true"  AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="jobno" HeaderText="Job #" />
                    <asp:BoundField DataField="jobdate" HeaderText="Opened On" />
                    <asp:BoundField DataField="vessel" HeaderText="Vessel/Flight" />
                    <asp:BoundField DataField="vesseldate" HeaderText="Sailed/Arrived" />
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridviewScrollHeader" /> 
                    <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
            </asp:Panel>
           
            <br />
            <asp:Label ID="lbl_MISB" runat="server" Text="Job Opened but not Sailed/ Arrived during the given date range"
                ForeColor="Red" CssClass="LabelValue"></asp:Label>
            <br />
            <asp:Panel ID="pnl_MISB" runat="server" ScrollBars="Vertical" Height="120px">
            <asp:GridView ID="Grd_MISB" runat="server" CssClass="Grid GrdRow" Width="100%" ShowHeaderWhenEmpty="true" ShowHeader="true" ForeColor="Black" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="jobno" HeaderText="Job #" />
                    <asp:BoundField DataField="jobdate" HeaderText="Opened On" />
                    <asp:BoundField DataField="vessel" HeaderText="Vessel/Flight" />
                    <asp:BoundField DataField="vesseldate" HeaderText="Sailed/Arrived" />
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridviewScrollHeader" /> 
                    <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
                </asp:Panel>
            <br />
            <asp:Label ID="lbl_MISC" runat="server" Text="Job Opened  Sailed/ Arrived and Closed during the given date Range"
                ForeColor="Red" CssClass="LabelValue" ></asp:Label>
            <br />
            <asp:Panel ID="Panel_MISC" runat="server" ScrollBars="Vertical" Height="120px">
                <asp:GridView ID="Grd_MISC" runat="server" CssClass="Grid GrdRow" Width="100%" ShowHeaderWhenEmpty="true" ShowHeader="true" ForeColor="Black" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="jobno" HeaderText="Job #" />
                    <asp:BoundField DataField="jobdate" HeaderText="Opened On" />
                    <asp:BoundField DataField="vessel" HeaderText="Vessel/Flight" />
                    <asp:BoundField DataField="vesseldate" HeaderText="Sailed/Arrived" />
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="GridviewScrollHeader" /> 
                    <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
            </asp:Panel>
            
            
            
            <br />
             <div class="div_Break"></div>
        </asp:Panel>
        <div class="div_Break"></div>
    </div>
</asp:Content>
