<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobinfoRpt.aspx.cs" Inherits="logix.Reportasp.JobinfoRpt" %>


<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Report</title>
    <style>
      * {
        margin: 0;
        padding: 0;
        font-size: 14px;
        box-sizing: border-box;
        font-family: sans-serif;
      }
      .heading {
        font-weight: bold;
      }
      table {
        width: 100%;
        border-collapse: collapse;
      }
      .table thead th {
        padding: 16px;
      }
      tbody td {
        padding: 10px;
      }
    </style>
  </head>
  <body>
    <div style="width: 1024px; margin: 0 auto">

        <p style="margin-bottom:30px">
            <asp:Label ID="lbl_date" runat="server"></asp:Label>

        </p>
      <h1 style="text-align: center">
          <asp:Label ID="lbl_head" runat="server"></asp:Label></h1>

      <div class="table">
        <table>
          <thead
            style="border-top: 1px solid black; border-bottom: 1px solid black"
          >
            <tr>
              <th>Jobn#</th>
              <th>MAWBL#</th>
              <th>Date</th>
              <th>Flight#</th>
              <th>Date</th>
              <th>From</th>
              <th>To</th>
              <th>status</th>
            </tr>
          </thead>
            <asp:Label ID="lbl_tr" runat="server"></asp:Label>
        </table>
      </div>
    </div>
  </body>
</html>

