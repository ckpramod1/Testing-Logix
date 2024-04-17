<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Annex3RPT.aspx.cs" Inherits="logix.Reportasp.Annex3RPT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>ANNXURE-B</title>
    <style type="text/css">
        
        .PageNumber
        {
     padding: 10px 0px 10px 0px;
    margin: 500px 0px 0px 0px;
    width: 1024px;
    text-align: center;
    color: #b1b1b1;
    font-size: 18px;
        }
       table {
    page-break-after: always !important;
}

       body {
    FONT-SIZE: 19PX;
}
    </style>
</head>

<body style="content: counter(page);">
      
   <asp:Label ID="tdRow_CanDtls" runat="server"></asp:Label>
</body>
</html>
