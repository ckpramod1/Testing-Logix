<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomEDIrpt.aspx.cs" Inherits="logix.Reportasp.CustomEDIrpt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        table{
            width:100% !important
        }
    </style>
</head>
<body>
    <div style="width: 1024px; margin: 0 auto;">
        <div style="width: 100%; margin: 0px auto; border: 1px solid #000; float: left;margin-bottom: 20px;">
            <div class="mbl" style="float: left; width: 100%; min-height: 36px !important;border-bottom:1px solid black;">
                <div style="width: 5%; float: left; padding: 7px 0px 5px 3px; font-weight: bold; font-size: 14px; color: #000; font-family: sans-serif;">
                    <label id="lbl_mbl" runat="server">MBL # :</label>
                </div>
                <div style="width: 40%; float: left; padding: 8px 0px 5px 3px; font-size: 14px; color: #000; font-family: sans-serif;">
                    <asp:Label ID="lbl_ourmbl" runat="server"></asp:Label>
                    |
                    <asp:Label ID="lbl_mbldate" runat="server"></asp:Label>
                </div>

                <div style="width: 10%; float: right; padding: 7px 0px 5px 3px; font-size: 14px; color: #000; font-family: sans-serif;">
                    <asp:Label ID="lbl_ourjob" runat="server"></asp:Label>
                </div>
                <div style="width: 5%; float: right; padding: 7px 0px 5px 3px; font-weight: bold; font-size: 14px; color: #000; font-family: sans-serif;">
                    <label id="lbl_job" runat="server">JOB # :</label>
                </div>

            </div>

            <%-- ------------------------------------------------------------------------------------------------------------------------ --%>



            <%--<table style="float: left; width: 100%; border-top: 1px solid #000; border-bottom: 1px solid #000; min-height: 100px;">--%>

                <asp:Label ID="tr_hblDtls" runat="server"></asp:Label>

            <%--</table>--%>


            <%--  --%>
        </div>

    </div>

</body>
</html>
