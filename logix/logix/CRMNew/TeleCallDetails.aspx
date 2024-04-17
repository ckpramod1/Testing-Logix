<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="TeleCallDetails.aspx.cs" Inherits="logix.CRM.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/TeleCallDetails.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
     <div class="div_total">
        <div class="lbl_Header1">
            <asp:Label ID="lblTeleCalls" runat="server" Text="Details of Calls"  ></asp:Label>
        </div>
        <div class="div_Break"></div>
        <div class="div_txtCustName">
             <asp:TextBox id="txtCustName" runat="server" placeholder="CustomerName" ToolTip="CustomerName"  CssClass="form-control" AutoPostBack="true"></asp:TextBox>
        </div>
         <div class="div_Break"></div>
               <div class="div_txtPresptName">
             <asp:TextBox id="txtPretext"  runat="server" placeholder="Freetext" ToolTip="Freetext" TextMode="MultiLine"  AutoPostBack="true"></asp:TextBox>
        </div>
        <div class="div_Break"></div>
        <div class="div_btn">
            <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click"  />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"  />
        </div>
        <div class="div_Break"></div>

    </div>
</asp:Content>
