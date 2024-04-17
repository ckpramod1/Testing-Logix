<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quotmultiportrpt.aspx.cs" Inherits="logix.Reportasp.Quotmultiportrpt" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Document</title>
  </head>
  <style>
    * {
      margin: 0;
      padding: 0;
      box-sizing: border-box;
    }
    body {
      font-size: 14px;
      font-family: Arial;
      line-height: 18px;
    }
    .container {
      width: 1024px;
      margin: 0px auto;
      /* border: 1px solid #000; */
      margin-bottom: 2rem;
      padding: 20px;
    }
    header {
      text-align: center;
      line-height: 25px;
      margin-bottom: 25px;
    }
    header h1 {
      font-family: auto;
      font-weight: 100;
    }
    header span {
      font-weight: bold;
    }
    .title {
      margin-bottom: 1rem;
    }
    .title h4 {
      margin-bottom: 5px;
    }
    .object {
      font-weight: bold;
      line-height: 28px;
      margin-bottom: 1rem;
    }
    .mt-1 {
      margin-top: 1rem;
    }

    .mb-1 {
      margin-bottom: 1rem;
    }
    .main_section {
      display: flex;
      justify-content: flex-end;
      border-bottom: 1px solid #000;
      padding: 5px 0;
    }
    .main_section div:first-child {
      margin-right: 6rem;
      font-weight: bold;
    }
    .main_section div:last-child {
      margin-right: 1rem;
    }
    /* .main_section div p:last-child {
      font-weight: bold;
    } */
    .discreption {
      height: 20px;
    }

    .area_title {
      display: flex;
      justify-content: space-between;
      padding: 10px 0px 10px 0px;
    }
    .area_title > div {
      font-weight: bold;
    }
    .area_title span {
      font-weight: normal;
      margin-left: 15px;
      height: 18px;
      display: inline-block;
    }
    .area_title ~ div {
      font-weight: bold;
      margin-bottom: 1rem;
    }
    .area_title ~ div span {
      font-weight: normal;
      height: 18px;
    }
    .Collect_Shipment p {
      font-weight: bold;
      margin-bottom: 1rem;
    }
    .ref_no span {
      height: 20px;
      display: inline-block;
    }
    .inco_no {
      display: flex;
      position: relative;
    }
    .inco {
      width: 414px;
      display: flex;
      justify-content: space-between;
    }
    .inco_no div {
      font-weight: bold;
    }
    .inco_no div span {
      font-weight: normal;
      height: 18px;
    }
    .incoNum {
      display: inline-block;
      margin-left: 0.5rem;
    }
    .scope {
      position: absolute;
      right: 15px;
    }
    table {
      width: 100%;
      border-collapse: collapse;
      margin-top: 1rem;
      height: 200px;
    }
    table th {
      padding: 10px 0;
    }
    table th:not(:last-child) {
     text-align: left;
    padding: 0px 0px 0px 7px;
    }
    table td {
      vertical-align: top;
      height: 20px;
    }
    table td:first-child {
      width: 430px;
    }
    table th {
    border: 1px solid black;
}

table tr td {
    border: 1px solid black;
        padding: 0px 0px 0px 7px;
}
  </style>
  <body>
    <div class="container">
      <!-- header -->
      <header>
        <h1> <asp:Label ID="lblDivName" runat="server"></asp:Label></h1>
        <p><asp:Label ID="lblAddress" runat="server"></asp:Label><br/>
                                       </p>
        <p><span> Phone : </span>  <asp:Label ID="lblphone" runat="server"></asp:Label> <span> Fax :  <asp:Label ID="lblfax" runat="server"></asp:Label></span></p>
        <p><span>Service Tax #  <asp:Label ID="lbl_stno" runat="server"></asp:Label></span><span> PAN # </span> <asp:Label ID="lbl_pan" runat="server"></asp:Label></p>
      </header>

      <!-- aside -->
      <aside>
        <div class="title">
          <h4><asp:Label ID="lbl_cust" runat="server"></asp:Label></h4>
          <p>
            <asp:Label ID="lbl_custaddress" runat="server"></asp:Label>
          </p>
        </div>
        <div class="object">
          <p><span>K/A : <asp:Label ID="lblptc" runat="server"></asp:Label> </span></p>
          <p>Dear Sir / Madam</p>
        </div>
        <div class="discreption mb-1">
          <p>
            With reference to the telecon / personal meeting had with you,
            please find our competetive rate(s)
          </p>
        </div>
      </aside>

      <!-- section -->
     <%-- <div class="main_section">
        <div class="ref_no">
          <p>Our Ref #: <span><asp:Label ID="lbl_quotno" runat="server"></asp:Label></span></p>
        </div>
        <div class="ref_no">
          <p>Valid Till : <span><asp:Label ID="lbl_valid" runat="server"></asp:Label></span></p>
        </div>
      </div>--%>

<asp:Label ID="lbl_rows" runat="server"></asp:Label>

     <%-- <!-- area_content -->
      <div class="area_content">
        <div class="area_title">
          <div>PoR: <span><asp:Label ID="lbl_por" runat="server"></asp:Label></span></div>
          <div>PoL: <span><asp:Label ID="lbl_pol" runat="server"></asp:Label></span></div>
          <div>PoD: <span><asp:Label ID="lbl_pod" runat="server"></asp:Label></span></div>
          <div>FD: <span><asp:Label ID="lbl_fd" runat="server"></asp:Label></span></div>
        </div>
        <div>Liner : <span><asp:Label ID="lbl_liner" runat="server"></asp:Label></span></div>
      </div>
      <!-- Collect_Shipment -->
      <div class="Collect_Shipment">
        <p><asp:Label ID="lbl_stypeshipment" runat="server"></asp:Label> Shipment</p>
        <div class="inco_no">
          <div class="inco">
            <div>Inco<span class="incoNum"><asp:Label ID="lbl_inco" runat="server"></asp:Label></span></div>
            <div>Cargo<span class="incoNum"><asp:Label ID="lbl_cargo" runat="server"></asp:Label></span></div>
          </div>
          <div class="scope">
            <div>Scope<span class="incoNum">lbl_scope</span></div>
          </div>
        </div>
      </div>
      <!-- table -->
      <table>
        <thead>
          <tr>
            <th>Charge</th>
            <th>Rate</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td><span></span></td>
            <td><span></span></td>
            <td><span></span></td>
            <td><span></span></td>
            <td><span></span></td>
          </tr>
        </tbody>
      </table>--%>
    </div>
  </body>
</html>

