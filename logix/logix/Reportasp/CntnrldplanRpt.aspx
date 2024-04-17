<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CntnrldplanRpt.aspx.cs" Inherits="logix.Reportasp.CntnrldplanRpt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        .details thead th {
            font-size: 14px;
            font-family: sans-serif;
        }

        .details tbody td {
            font-size: 14px;
            font-family: sans-serif;
        }

        .details thead th:nth-child(1) {
            padding: 0 !important;
            width: 3%;
            height: 50px;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details thead th:nth-child(2) {
            padding: 0 !important;
            width: 6%;
            height: 50px;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details thead th:nth-child(3) {
            padding: 0 !important;
            width: 10%;
            height: 50px;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details thead th:nth-child(4) {
            padding: 0 !important;
            width: 9%;
            height: 50px;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details thead th:nth-child(5) {
            padding: 0 !important;
            width: 5%;
            height: 50px;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details thead th:nth-child(6) {
            padding: 0 !important;
            width: 20%;
            height: 50px;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details thead th:nth-child(7) {
            padding: 0 !important;
            width: 12%;
            height: 50px;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details thead th:nth-child(8) {
            padding: 0 !important;
            width: 20%;
            height: 50px;
            border-bottom: 1px solid #000;
        }

        table {
            border-collapse: collapse;
        }

        .details tbody tr td:nth-child(1) {
            padding: 0px 0px 0px 10px !important;
            width: 3%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details tbody tr td:nth-child(2) {
            padding: 0px 0px 0px 10px !important;
            width: 6%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details tbody tr td:nth-child(3) {
            padding: 0px 0px 0px 10px !important;
            width: 10%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details tbody tr td:nth-child(4) {
            padding: 0px 0px 0px 10px !important;
            width: 9%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
            padding-right: 5px !important;
        }

        .details tbody tr td:nth-child(5) {
            padding: 0px 0px 0px 10px !important;
            width: 5%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
            padding-right: 5px !important;
        }

        .details tbody tr td:nth-child(6) {
            padding: 0px 0px 0px 10px !important;
            width: 20%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details tbody tr td:nth-child(7) {
            padding: 0px 0px 0px 10px !important;
            width: 12%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details tbody tr td:nth-child(8) {
            padding: 0px 0px 0px 10px !important;
            width: 20%;
            height: auto;
            border-bottom: 1px solid #000;
        }

        .tbl {
            padding-top: 35px;
        }
        table.details thead {
    border-top: 1px solid black;
}
    </style>
</head>
<body>
    <div style="width: 1024px; margin: 0 auto;">
        <div style="width: 100%; margin: 0px auto; border: 1px solid #000; float: left; border-bottom: none;">
            <div style="float: left; width: 99%; padding: 7px 0px 4px 9px; border-bottom: 1px solid #000;">
             <%--   <h3 style="font-family: Segoe UI; font-size: 24px; font-weight: bold; color: #000; text-align: center; padding: 0px 0px 0px 0px; margin: 0px 0px 0px 22px;">Container Load Plan</h3>
                <h3 style="font-family: Segoe UI; font-size: 24px; font-weight: normal; color: #000; text-align: center; padding: 0px 0px 0px 0px; margin: 0px 0px 0px 22px;">
                    <asp:Label ID="lbl_head" runat="server">Header</asp:Label></h3>--%>


                <div style="width: 50%; float: left">
                    <div style="width: 30%; margin: 0px 0px 5px 0px;">
                        <asp:label id="lbl_branch" runat="server">DEMO Company</asp:label>
                    </div>

                    <div style="width: 100%; margin: 0px 0px 5px 0px;">
                        <asp:label id="lbl_add" runat="server">DEMO Address</asp:label>
                    </div>
                    <div style="width: 100%; float: left   ; margin: 0px 0px 5px 0px;">
                        <p style="float: left; margin: 0px; width: 75px;">Phone No:</p>
                        <p style="float: left; width: auto; margin: 0px 8px 0px 0px;">
                            <asp:label id="lbl_ph" runat="server"></asp:label>
                        </p>


                        <p style="float: left; margin: 0px; width: 40px;">FAX:</p>
                        <p style="float: left; width: auto; margin: 0px 8px 0px 0px;">
                            <asp:label id="lbl_fax" runat="server"></asp:label>
                        </p>

                        <p style="float: left; margin: 0px; width: 75px;">eMail</p>
                        <p style="float: left; margin: 0px 8px 0px 0px;">
                            <asp:label id="lbl_email" runat="server"></asp:label>
                        </p>
                    </div>







                    <div style="width: 100%; float: left;    margin: 0px 0px 5px 0px;">
                        <p style="float: left; margin: 0px; width: 44px;">Pan #:</p>
                        <p style="float: left; width: auto; margin: 0px 8px 0px 0px;">
                            <asp:label  id="lbl_pan" runat="server"></asp:label>
                        </p>


                        <p style="float: left; margin: 0px; width: 100px;">Service Tax:</p>
                        <p style="float: left; width: auto; margin: 0px 8px 0px 0px;">
                            <asp:label id="lbl_stax" runat="server"></asp:label>
                        </p>

                        
                    </div>
                </div>
            </div>


            <asp:Label ID="lbl_tdrows" runat="server"></asp:Label>

        </div>
    </div>
</body>
</html>
