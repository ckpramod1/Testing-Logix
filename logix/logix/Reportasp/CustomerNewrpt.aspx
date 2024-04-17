<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerNewrpt.aspx.cs" Inherits="logix.Reportasp.CustomerNewrpt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Form</title>
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" />
        <style type="text/css" >
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

      /* container */
      .container {
        width: 1024px;
        margin: 0 auto;
        border: 1px solid #000;
      }
       .container-box {
        padding: 0 35px 35px;
      }
      header {
        padding: 5px 0 0 10px;
        font-weight: bold;
        height: 40px;
      }
      header span {
        padding-left: 5px;
      }
      .values {
        padding: 0 0 10px 10px;
        height: 70px;
        width: 100%;
      }

      .content {
        display: flex;
        height: 25px;
      }
      .content2 {
        height: 25px;
        display: flex;
      }
      .heading {
        display: flex;

        width: 25%;
      }
      .heading p {
        width: 100px;
        padding-left: 5px;
      }
      .heading div {
        font-weight: bold;
      }
      table {
        border: 1px solid #000;
        border-collapse: collapse;
        width: 100%;
        margin-bottom: 20px;
      }
      table:last-child {
        margin-bottom: 0;
      }
      table th {
        border-right: 1px solid #000;
      }
      table td {
        border-right: 1px solid #000;
        padding-left: 8px;
      }
      table tr {
        border-bottom: 1px solid #000;
      }
      span#LblRender {
    font-weight: normal;
}
      .heading span {
    font-weight: normal;
}
    </style>

</head>
<body>
    <form id="form1" runat="server">
      <div class="container">
          <h4 style="border-bottom:1px solid #000;padding-bottom:5px;text-align:center";>Customer Details</h4>
          <div class="container-box">
      <header>
        <label>Customer/Vendar:</label>
          <asp:Label ID="LblRender" runat="server" Text="Label"></asp:Label>
        <span></span>
      </header>

      <!-- values -->
      <div class="values">
        <div class="content">
          <div class="heading">
            <div>PAN:
                 <asp:Label ID="lblpan" runat="server" Text="Label"></asp:Label>
            </div>
           
          </div>

          <div class="heading">
            <div>TAN :
                 <asp:Label ID="lbltan" runat="server" Text="Label"></asp:Label>
            </div>
           
          </div>

          <div class="heading">
            <div>CIN :
                 <asp:Label ID="lblcin" runat="server" Text="Label"></asp:Label>
            </div>
            
          </div>

          <div class="heading">
            <div>UIN :
                 <asp:Label ID="lbluin" runat="server" Text="Label"></asp:Label>
            </div>
            
          </div>
        </div>
        <div class="content2">
          <div class="heading">
            <div>Type :
                 <asp:Label ID="lbltype" runat="server" Text="Label"></asp:Label>
            </div>
            
          </div>
          <div class="heading">
            <div></div>
            <p></p>
          </div>

          <div class="heading">
            <div>Category :
                 <asp:Label ID="lblcategory" runat="server" Text="Label"></asp:Label>
            </div>
            
          </div>

          <div class="heading">
            <div></div>
            <p></p>
          </div>
        </div>
      </div>

      <!-- table -->
      <table>
        <tbody>
          <thead>
            <tr>
              <th>GST #</th>
              <th>City</th>
              <th>Location</th>
              <th>Pin</th>
              <th>District</th>
              <th>State</th>
              <th>Country</th>
            </tr>
            <tr>
              <td> <asp:Label ID="lblGst" runat="server" Text="Label"></asp:Label></td>
              <td> <asp:Label ID="lblcity" runat="server" Text="Label"></asp:Label></td>
              <td>  <asp:Label ID="lbllocation" runat="server" Text="Label"></asp:Label></td>
              <td> <asp:Label ID="lblpin" runat="server" Text="Label"></asp:Label></td>
              <td> <asp:Label ID="lbldistrict" runat="server" Text="Label"></asp:Label></td>
              <td> <asp:Label ID="lblstate" runat="server" Text="Label"></asp:Label></td>
              <td> <asp:Label ID="lblcout" runat="server" Text="Label"></asp:Label></td>
            </tr>
          </thead>
        </tbody>
      </table>

      <!-- table 2-->

      <table>
        <tbody>
          <thead>
            <tr>
              <th>BANK NAME</th>
              <th>IFSC Code</th>
              <th>Account Type</th>
              <th>Account No</th>
              <th>GST</th>
            </tr>
            <tr>
              <td> <asp:Label ID="lblbank" runat="server" Text="Label"></asp:Label></td>
              <td> <asp:Label ID="lblifsc" runat="server" Text="Label"></asp:Label></td>
              <td> <asp:Label ID="lblacctype" runat="server" Text="Label"></asp:Label></td>
              <td> <asp:Label ID="lblno" runat="server" Text="Label"></asp:Label></td>
              <td> <asp:Label ID="lblgstno" runat="server" Text="Label"></asp:Label></td>
            </tr>
          </thead>
        </tbody>
      </table>

      <!-- table 3-->

      <table>
        <tbody>
          <thead>
            <tr>
              <th>TDS Desc</th>
              <th>Type</th>
              <th>Slab</th>
              <th>%</th>
              <th>By From</th>
              <th>By To</th>
              <th>Email</th>
            </tr>
            <tr>
              <td> <asp:Label ID="lbltds" runat="server" Text="Label"></asp:Label></td>
              <td> <asp:Label ID="lbltypes" runat="server" Text="Label"></asp:Label></td>
              <td> <asp:Label ID="lblsab" runat="server" Text="Label"></asp:Label></td>
              <td> <asp:Label ID="lblper" runat="server" Text="Label"></asp:Label></td>
              <td> <asp:Label ID="lblfrom" runat="server" Text="Label"></asp:Label></td>
              <td> <asp:Label ID="lblto" runat="server" Text="Label"></asp:Label></td>
              <td> <asp:Label ID="lblemail" runat="server" Text="Label"></asp:Label></td>
            </tr>
          </thead>
        </tbody>
      </table>
              </div>
    </div>
 
    </form>
</body>
</html>
