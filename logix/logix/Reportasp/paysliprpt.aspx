<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paysliprpt.aspx.cs" Inherits="logix.Reportasp.paysliprpt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .div_Menu
        {
     
           /*float:left; */ 
            margin-top :3%; 
            /*width :79%;*/ 
            /*width :99%;*/ 
              width:100%!important;;
            background-color:White;
            margin-left:auto;
            margin-right :auto;
            /*height:100%;*/
         height: 100%;
        
        }

        .total
        {
           width:100%;
           height :100%;
           margin:0px auto;
           float:left;
        }

        iframe {
    width: 1300px;
    height: 1058px;
    overflow: hidden;
    
    border: none;
}


    </style>

</head>
<body>
   <form id="form1" runat="server">
    <div class="">
      <div class="total">
    <%--<iframe id="ifrmaster" name="centerfrm" class="div_Menu" frameborder="0" src="" style="width:100%;height:100%;" scrolling="yes" runat="server"></iframe>--%>
    </div>
    </div>
    </form>
</body>
</html>
