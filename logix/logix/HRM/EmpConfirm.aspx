<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="EmpConfirm.aspx.cs" Inherits="logix.HRM.EmpConfirm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
       .div_total
     {    
    width:700px;
     background-color:#F8F8F8;
   -webkit-box-shadow: 8px 8px 8px rgba(0,0,0,.15);
   -moz-box-shadow   : 8px 8px 8px rgba(0,0,0,.15);
   box-shadow        : 8px 8px 8px rgba(0,0,0,.15);

    }
      .panel{
          float:left;
          width:97%;
          height:200px;
          margin-left:1%; 
           overflow:auto;
           
        }
      .EmptyRowStyle
{
    text-align:center;
}
.GridHeader
{
    background-color:Navy;
    color:White;
    font-family:sans-serif;
    font-size:10pt;
    margin-left: 4px;
    margin-bottom: 0px;
     padding:2px;
  text-align:center;
}
.GrdAltRow
{
    background-color:#FFF8DC;
   font-family:sans-serif;
    font-size:10pt;
     color:Black;
    margin-left: 4px;
    margin-bottom: 0px;
    
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
     <div class="div_total">
          <div class="div_Break"></div>
        <div class="Header"><asp:Label ID="lbl_head" runat="server" Text="Pending Confirmation " CssClass="lbl_Header"></asp:Label></div>
        <div class="div_Break"></div>
        <div class="div_Break"></div>
         <br />
        <asp:Panel ID="panel" runat="server" CssClass="panel" >
            <asp:GridView ID="grd" runat="server" CssClass="Grid FixedHeader"  width="100%" AutoGenerateColumns="true">
                <Columns>
                   

                </Columns>
              <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>           
        </asp:Panel>
             <div class="div_Break"></div>
       
       
    </div>
</asp:Content>
