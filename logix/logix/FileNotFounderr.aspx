<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileNotFounderr.aspx.cs" Inherits="logix.FileNotFounderr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 338px 0px 0px 0px;height: 200px;display: flex;justify-content: center;align-items: center;width: 100%;">
        <img src="images/404.jpg" style="width: 82%;scale: 0.9;" />
    </div>
    </form>
</body>
</html>--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileNotFounderr.aspx.cs" Inherits="logix.FileNotFounderr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style>
    @import url('https://fonts.googleapis.com/css2?family=Noto+Sans:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;1,100;1,200;1,300;1,400;1,500;1,600;1,700&family=Nunito+Sans:ital,wght@0,200;0,300;0,400;0,500;0,600;0,700;0,800;1,200;1,300;1,400;1,500;1,600;1,700&family=Open+Sans:ital,wght@0,300;0,400;0,500;0,600;0,700;0,800;1,300;1,400;1,500;1,600;1,700;1,800&family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&family=Public+Sans:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;1,100;1,200;1,300;1,400;1,500;1,600&family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap');
@import url('system.css');


    :root {
           --base_font: 'roboto', 'Poppins', sans-serif;
    }

    .errortext{
        font-family:var(--base_font);
            margin-bottom: 4px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
            
        <div style="display: flex;
    align-items: center;
    justify-content: center;font-size: 25px;"  >  

        <p class="errortext">The requested page could not be found.</p>

        </div>
        <div style="display: flex;
    align-items: center;
    justify-content: center;font-size: 25px;" >
             <a href="/Login.aspx" style="font-family:var(--base_font)" >Login</a>
        </div>
    <div style="display: flex;justify-content: center;align-items: center;width: 100%;position: relative;top: -35px;z-index: -9999;">
        <img src="images/404_new.jpg" style="width: 100%;scale: 1;" />
        

    </div>
    </form>
</body>
</html>

