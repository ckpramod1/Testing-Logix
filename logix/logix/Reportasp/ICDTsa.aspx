<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ICDTsa.aspx.cs" Inherits="logix.Reportasp.ICDTsa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Transhipment Application</title>

    <%--  <script type="text/javascript">
          function Designing() {
            
              $("th").css({ "position": "sticky", "top": "-1px" });
              $("td").css({ "border-bottom": "1px solid #AAA", "border-right": "1px solid #AAA" });
              $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
          }
    </script>--%>
      <style type="text/css">
      * {
        margin: 0;
        padding: 0;
        box-sizing: border-box;
            font-size: 16px;
      }
    .row {
    display: flex;
    margin-top: 5px;
    justify-content: space-between;
}
    
      table th:first-child, table td:first-child{
    border-left: 0!important;

      } 
      table th:last-child, table td:last-child {
    border-right: 0!important;
}
    </style>
</head>
    <body style="font-size:19px;font-family:sans-serif;">
     <asp:Label ID="tdRow_CanDtls" runat="server"></asp:Label>
</body>
</html>
