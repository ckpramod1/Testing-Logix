<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="ProfTax.aspx.cs" Inherits="logix.HRM.ProfTax" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/ProfTax.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
<div class="div_Main">
        <asp:Label ID="lbl_Header" runat="server" Text="Professional Tax"></asp:Label>
    </div>
    <div class="div_break">
    </div>
    <div class="div_Rentlabel">
        <asp:Label ID="lbl_Month" runat="server" Text="Month"></asp:Label>
    </div>
    <div class="div_ddlmonth">
        <asp:DropDownList ID="ddl_Monrh" runat="server"  
            AutoPostBack="True" onselectedindexchanged="ddl_Monrh_SelectedIndexChanged">
            <asp:ListItem></asp:ListItem>
             <asp:ListItem Value="1">January</asp:ListItem>
            <asp:ListItem Value="2">February</asp:ListItem>
            <asp:ListItem Value="3">March</asp:ListItem>
            <asp:ListItem Value="4">April</asp:ListItem>
            <asp:ListItem Value="5">May</asp:ListItem>
            <asp:ListItem Value="6">June</asp:ListItem>
            <asp:ListItem Value="7">July</asp:ListItem>
            <asp:ListItem Value="8">August</asp:ListItem>
            <asp:ListItem Value="9">September</asp:ListItem>
            <asp:ListItem Value="10">October</asp:ListItem>
            <asp:ListItem Value="11">November</asp:ListItem>
            <asp:ListItem Value="12">December</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="div_Yearlabel">
        <asp:Label ID="lbl_Year" runat="server" Text="Year"></asp:Label>
    </div>
     <div class="div_Gradetxt">
        <asp:TextBox ID="txt_Year" runat="server" MaxLength="4" AutoPostBack="True" 
             ontextchanged="txt_Year_TextChanged"></asp:TextBox>
    </div>
    <div class="div_break">
    </div>
    <div class="div_lbl">
        <asp:LinkButton ID="lnk_empcode" runat="server" Style="text-decoration: none;" 
            onclick="lnk_empcode_Click" >EmpCode</asp:LinkButton>
    </div>
    <div class="div_Gradetxt">
        <asp:TextBox ID="txt_Empcode" runat="server" AutoPostBack="True" 
            ontextchanged="txt_Empcode_TextChanged" ></asp:TextBox>
    </div>
 <div class="div_label">
        <asp:Label ID="lbl_Name" runat="server" Text="Name"></asp:Label>
    </div>
    <div class="div_Emptxt">
        <asp:TextBox ID="txt_Name" runat="server" ReadOnly="True"></asp:TextBox>
    </div>
    <div class="div_label">
        <asp:Label ID="lbl_company" runat="server" Text="Company"></asp:Label>
    </div>
    <div class="div_Emptxt">
        <asp:TextBox ID="txt_Company" runat="server" ReadOnly="True"></asp:TextBox>
    </div>
    <div class="div_break">
    </div>
    <div class="div_lbl">
        <asp:Label ID="lbl_Grade" runat="server" Text="Grade"></asp:Label>
    </div>
    <div class="div_Gradetxt">
        <asp:TextBox ID="txt_Grade" runat="server"></asp:TextBox>
    </div>
    <div class="div_label">
        <asp:Label ID="lbl_Dept" runat="server" Text="Department"></asp:Label>
    </div>
    <div class="div_Emptxt">
        <asp:TextBox ID="txt_Dept" runat="server"></asp:TextBox>
    </div>
    <div class="div_label">
        <asp:Label ID="lbl_Desg" runat="server" Text="Designation"></asp:Label>
    </div>
    <div class="div_Emptxt">
        <asp:TextBox ID="txt_Desg" runat="server" ReadOnly="True"></asp:TextBox>
    </div>
    <div class="div_break">
    </div>
    <div class="div_lbl">
        <asp:Label ID="Label1" runat="server" Text="Professional Tax"></asp:Label>
    </div>
    <div class="div_Gradetxt">
        <asp:TextBox ID="txt_Tax" runat="server" style="text-align:right;"></asp:TextBox>
    </div>
    <div class="div_break">
    </div>
       <div class="div_btn">
        <asp:Button ID="btn_save" runat="server" Text="Save" CssClass="btn" 
               onclick="btn_save_Click"   />
         <asp:Button ID="btn_delete" runat="server" Text="Delete" CssClass="btn" 
               OnClientClick="javascript:return confirm('Do u want to delete the data');" 
               Enabled="False" onclick="btn_delete_Click" />
        <asp:Button ID="btn_View" runat="server" Text="View" CssClass="btn" 
               onclick="btn_View_Click"  />
        <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CssClass="btn" 
               onclick="btn_cancel_Click"  />
    </div>
    <div class="div_break">
    </div>
    <div class="div_Grid">
        <asp:GridView ID="Grd_Tax" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader" 
            Width="100%" ForeColor="Black" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="True" 
            DataKeyNames="proid,divsname,empid,empname,designame" 
            onselectedindexchanged="Grd_Tax_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField DataField="empcode" HeaderText="Code" />
                 <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <div class="div_Column">
                            <asp:Label ID="lbl" runat="server" Text='<%# Bind("empname")%>' ToolTip='<%# Bind("empname")%>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="grade" HeaderText="Grade"/>
                <asp:BoundField DataField="deptname" HeaderText="Department" />
                <asp:TemplateField HeaderText="Designation">
                    <ItemTemplate>
                        <div class="div_Column">
                            <asp:Label ID="lbl_designame" runat="server" Text='<%# Bind("designame")%>' ToolTip='<%# Bind("designame")%>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="paymonth" HeaderText="PayMonth"/>  
                <asp:BoundField DataField="payyear" HeaderText="PayYear" />
                <asp:BoundField DataField="amount" HeaderText="Professional Tax" DataFormatString="{0:0.00}">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="Img_Edudelete" runat="server" CommandName="select" CssClass="Grid_Edit_Img"
                            ImageUrl="~/images/delete.jpg" OnClientClick="javascript:IsConfirm('Do you want to Delete this record','hid_confirm');" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GrdAltRow" />
        </asp:GridView>
    </div>
    <div class="div_break">
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

    <asp:ModalPopupExtender ID="Popup_Emp" runat="server" PopupControlID="pln_Emp" BackgroundCssClass="modalBackgroundjob"
        CancelControlID="Close_Emp" TargetControlID="hid">
    </asp:ModalPopupExtender>
    
    <asp:HiddenField ID="hid" runat="server" />
    <asp:HiddenField ID="hid_confirm" runat="server" />
    <asp:HiddenField ID="hid_Empid" runat="server" />
    <asp:HiddenField ID="hid_Portid" runat="server" />
</asp:Content>