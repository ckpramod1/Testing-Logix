<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="BankStatement.aspx.cs" Inherits="logix.HRM.BankStatement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/BankStatement.css" rel="stylesheet" />
      <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
        <link href="../Styles/GridviewScroll.css" rel="stylesheet" />   
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" />
    <link href="../Styles/ControlStyle.css" rel="stylesheet" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>    
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script> 
       <link href="../Styles/GridviewScroll.css" rel="stylesheet" /> 
    <link href ="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" /> 
     <script type="text/javascript" language="javascript">

         function pageLoad(sender, args) {
             $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

         }
         </script>
   <style type="text/css">
       .TxtAlign1 {text-align:right!important;
}
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <div class="divTotal">
        <div class="div_Main">
            <asp:Label ID="lbl_Header" runat="server" CssClass="lbl_Header" Text="BankStatement"></asp:Label>
        </div>
        <div class="div_break">
        </div>
      <%--  <div class="div_label">
            <asp:Label ID="lbl_gradename" runat="server" Text="Grade Name"></asp:Label>
        </div>--%>
        <div class="div_txtmonth">
             <asp:DropDownList ID="ddl_Month" runat="server" Data-placeHolder="Month" ToolTip="Month" CssClass ="chzn-select"  >
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
             </asp:DropDownList> 
        </div>
   <%--     <div class="div_label">
            <asp:Label ID="lbl_from" runat="server" Text="Valid From"></asp:Label>
        </div>--%>
        <div class="div_txtyr">
            <asp:TextBox ID="txt_From" runat="server" placeholder="Year" ToolTip="Year" CssClass="Text" BorderColor="#999997"></asp:TextBox>
        </div>
<%--        <div class="div_lbl">
            <asp:Label ID="lbl_to" runat="server" Text="Valid To"></asp:Label>
        </div>--%>
        <div class="div_txtcom">
            <%--<asp:TextBox ID="txt_to" runat="server" placeholder="Valid To" ToolTip="Valid To" CssClass="chzn-select" BorderColor="#999997"></asp:TextBox>--%>
             <asp:DropDownList ID="DropDownList1" runat="server" Data-placeHolder="Company" ToolTip="Company" CssClass ="chzn-select"  >
            <asp:ListItem></asp:ListItem>
            <asp:ListItem Value="1">ALL</asp:ListItem>
            <asp:ListItem Value="2">SL</asp:ListItem>
            <%--<asp:ListItem Value="3">LEADTECH SOLUTIONS PRIVATE LIMITED</asp:ListItem>
            <asp:ListItem Value="4">OLS CLEARING AND FORWARDING PRIVATE LIMITED</asp:ListItem>--%>
                 </asp:DropDownList>
        </div>
        <div class="div_break">
        </div>
 <%--       <div class="div_label">
            <asp:Label ID="lbl_medical" runat="server" Text="Medical"></asp:Label>
        </div>--%>
        <div class="div_txt">
            <asp:TextBox ID="txt_medical" runat="server" placeholder="TotalEmployee" ToolTip="TotalEmployee" CssClass="Text" BorderColor="#999997"></asp:TextBox>
        </div>
  <%--      <div class="div_label">
            <asp:Label ID="lbl_driverwages" runat="server" Text="Driver Wages"></asp:Label>
        </div>--%>
        <div class="div_txt">
            <asp:TextBox ID="txt_driverwages" runat="server" placeholder="Joined" ToolTip="Joined" CssClass="Text" BorderColor="#999997"></asp:TextBox>
        </div>
     <%--   <div class="div_lbl">
            <asp:Label ID="lbl_entertain" runat="server" Text="Entertain Allowance"></asp:Label>
        </div>--%>
        <div class="div_txt">
            <asp:TextBox ID="txt_entertain" runat="server" placeholder="Relieved" ToolTip="Relieved" CssClass="Text" BorderColor="#999997"></asp:TextBox>
        </div>
        <div class="div_break">
        </div>
        <div class="div_lbl">
            <asp:Label ID="lbl_workday" runat="server" Text="worked days"></asp:Label>
        </div>
        <div class="div_btn">              

            <asp:Button ID="btn_save" runat="server" Text="Save" CssClass="Button" OnClick="btn_save_Click"  />
               
            <asp:Button ID="btn_view" runat="server" Text="View" CssClass="Button" OnClick="btn_view_Click"  />
             
            <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CssClass="Button" OnClick="btn_cancel_Click" />
              
        </div>
        <div class="div_break">
        </div>
        <div class="div_Grid">
            <asp:GridView ID="Grd_Grade" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader" 
                Width="100%" ForeColor="Black"  ShowHeaderWhenEmpty="True"
                DataKeyNames="gradeid" OnDataBound="Grd_Grade_DataBound"  >
           
                <Columns>
                    <asp:BoundField DataField="portname" HeaderText="Branch" />
                    <asp:BoundField DataField="netamt" HeaderText="Salary" DataFormatString="{0:F2}"  ItemStyle-CssClass="TxtAlign1" >                      
                    </asp:BoundField>                  
                    <asp:BoundField DataField="pf" HeaderText="PF" DataFormatString="{0:F2}"  ItemStyle-CssClass="TxtAlign1" >
                     
                    </asp:BoundField>
                    <asp:BoundField DataField="esi" HeaderText="ESI" DataFormatString="{0:F2}"  ItemStyle-CssClass="TxtAlign1" >
                     
                    </asp:BoundField>                  
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
        </div>
        <div class="div_break"> 
        </div>

       
    </div>
</asp:Content>
