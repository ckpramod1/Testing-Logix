<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IgmfinalRpt.aspx.cs" Inherits="logix.Reportasp.IgmfinalRpt" %>

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
            width: 25%;
            height: 50px;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details thead th:nth-child(2) {
            padding: 0 !important;
            width: 10%;
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
            width: 10%;
            height: 50px;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details thead th:nth-child(5) {
            padding: 0 !important;
            width: 10%;
            height: 50px;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details thead th:nth-child(6) {
            padding: 0 !important;
            width: 10%;
            height: 50px;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details thead th:nth-child(7) {
            padding: 0 !important;
            width: 10%;
            height: 50px;
            border-bottom: 1px solid #000;
        }


        table {
            border-collapse: collapse;
        }

        .details tbody tr td:nth-child(1) {
            padding: 0px 0px 0px 10px !important;
            width: 25%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details tbody tr td:nth-child(2) {
            padding: 0px 0px 0px 10px !important;
            width: 10%;
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
            width: 10%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
            padding-right: 5px !important;
        }

        .details tbody tr td:nth-child(5) {
            padding: 0px 0px 0px 10px !important;
            width: 10%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
            padding-right: 5px !important;
        }

        .details tbody tr td:nth-child(6) {
            padding: 0px 0px 0px 10px !important;
            width: 10%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details tbody tr td:nth-child(7) {
            padding: 0px 0px 0px 10px !important;
            width: 10%;
            height: auto;
            border-bottom: 1px solid #000;
        }

        div#div_cnopshead {
            text-align: center !important;
        }
        table.details thead {
    border-top: 1px solid black;
}
        .tbl {
    padding-top: 10px;
}
        .border {
    border: 1.5px solid black;
    margin-top: 18px;
}

    </style>
</head>
<body>
    <div style="width: 1024px; margin: 0 auto;">
        <div style="width: 100%; margin: 0px auto; border: 1px solid #000; float: left; border-bottom: none;">
            <div style="float: left;">
                <div style="float: left; width: 150px; margin: 9px 10px 5px 15px;">
                    <asp:Image ID="lbl_img" runat="server" Width="80" Height="89" />
                </div>
                <div style="float: left; width: 735px; margin: 7px 0px 4px 9px;">
                    <h3 style="font-family: Segoe UI; font-size: 24px; font-weight: bold; color: #000; text-align: center; padding: 0px 0px 10px 0px; margin: 0px 0px 0px 22px;">
                        <asp:Label ID="lbl_branch" runat="server">  </asp:Label></h3>

                    <div style="text-align: center; color: #000;">
                        <asp:Label ID="lbl_add" runat="server"></asp:Label><br />
                    </div>
                    <div style="text-align: center; color: #000; font-weight: bold;">
                        Phone :
                   <asp:Label ID="lbl_ph" runat="server" Style="font-weight: normal !important;"></asp:Label>
                        Fax :<asp:Label ID="lbl_fax" runat="server" Style="font-weight: normal !important;"></asp:Label>
                    </div>
                    <div id="div_cnopshead" runat="server" style="font-weight: bold;">
                        Service Tax # :
                   <asp:Label ID="lbl_staxhead" runat="server" Style="font-weight: normal !important;"></asp:Label>
                        PAN # :
                   <asp:Label ID="lbl_panno" runat="server" Style="font-weight: normal !important;"></asp:Label>
                    </div>

                </div>
            </div>
            <div style="float: left; width: 100%; border-top: 1px solid #000;">
                <h4 style="float: left; font-size: 14px; font-family: sans-serif; color: #000; font-weight: bold; text-align: center; width: 100%; margin: 5px;">FINAL IGM</h4>

            </div>
            <div style="float: left; width: 100%; border-bottom: 1px solid #000; min-height: 100px; border-top: 1px solid #000;">
                <div style="float: left; width: 30%;">



                    <div style="width: 18%; float: left; padding: 7px 0px 5px 10px; font-weight: bold; font-size: 14px; color: #000; font-family: sans-serif;">
                        <label id="label_igmno" style="color: #000000;" runat="server">IGM No:</label>
                    </div>


                    <div style="width: 77%; float: left; padding: 7px 0px 5px 3px; font-size: 14px; color: #000; font-family: sans-serif;">
                        <asp:Label ID="lbl_ourigm" runat="server"></asp:Label>
                    </div>
                        <div style="clear:both;"></div>
                    <div style="width: 25%; float: left; padding: 7px 0px 5px 10px; font-weight: bold; font-size: 14px; color: #000; font-family: sans-serif;">
                        <label id="label_voyage" style="color: #000000;" runat="server">Voyage No:</label>
                    </div>
                    <div style="width: 70%; float: left; padding: 7px 0px 5px 3px; font-size: 14px; color: #000; font-family: sans-serif;">
                        <asp:Label ID="lbl_ourvoyage" runat="server"></asp:Label>
                    </div>
                    <div style="clear:both;"></div>
                    <div style="width: 32%; float: left; padding: 7px 0px 5px 10px; font-weight: bold; font-size: 14px; color: #000; font-family: sans-serif;">
                        <label id="label_mastern" style="color: #000000;" runat="server">Master Name :</label>
                    </div>
                    <div style="width: 62%; float: left; padding: 7px 0px 5px 3px; font-size: 14px; color: #000; font-family: sans-serif;">
                        <asp:Label ID="lbl_ourmastern" runat="server"></asp:Label>
                    </div>
                        
                    <div style="clear:both;"></div>




                    <div style="width: 33%; float: left; padding: 7px 0px 5px 10px; font-weight: bold; font-size: 14px; color: #000; font-family: sans-serif;">
                        <label id="label_shipline" style="color: #000000;" runat="server">Shipping Line :</label>
                    </div>
                    <div style="width: 61%; float: left; padding: 7px 0px 5px 3px; font-size: 14px; color: #000; font-family: sans-serif;">
                        <asp:Label ID="lbl_ourshipline" runat="server"></asp:Label>
                    </div>
                    <div style="clear:both;"></div>
                    <div style="width: 31%; float: left; padding: 7px 0px 5px 10px; font-weight: bold; font-size: 14px; color: #000; font-family: sans-serif;">
                        <label id="label_vesselna" style="color: #000000;" runat="server">Vessel Name :</label>
                    </div>
                    <div style="width: 64%; float: left; padding: 7px 0px 5px 3px; font-size: 14px; color: #000; font-family: sans-serif;">
                        <asp:Label ID="lbl_vesselna" runat="server"></asp:Label>
                    </div>
                    <div style="clear:both;"></div>
                    <div style="width: 26%; float: left; padding: 7px 0px 5px 10px; font-weight: bold; font-size: 14px; color: #000; font-family: sans-serif;">
                        <label id="label_lastport" style="color: #000000;" runat="server">Last Port 1:</label>
                    </div>
                    <div style="width: 69%; float: left; padding: 7px 0px 5px 3px; font-size: 14px; color: #000; font-family: sans-serif;">
                        <asp:Label ID="lbl_lastport" runat="server"></asp:Label>
                    </div>



                </div>
                <div style="float: left; width: 35%;">
                    <div style="width: 20%; float: left; padding: 7px 0px 5px 3px; font-weight: bold; font-size: 14px; color: #000; font-family: sans-serif;">
                        <label id="label_igmdate" style="color: #000000;" runat="server">IGM Date :</label>
                    </div>
                    <div style="width: 77%; float: left; padding: 7px 0px 5px 3px; font-size: 14px; color: #000; font-family: sans-serif;">
                        <asp:Label ID="lbl_ourigmdate" runat="server"></asp:Label>
                    </div>
                    <div style="clear:both;"></div>
                    <div style="width: 27%; float: left; padding: 7px 0px 5px 3px; font-weight: bold; font-size: 14px; color: #000; font-family: sans-serif;">
                        <label id="label_vesselcode" style="color: #000000;" runat="server">Vessel_Code :</label>
                    </div>
                    <div style="width: 71%; float: left; padding: 7px 0px 5px 3px; font-size: 14px; color: #000; font-family: sans-serif;">
                        <asp:Label ID="lbl_ourvesselcode" runat="server"></asp:Label>
                    </div>
                    <div style="clear:both;"></div>
                    <div style="width: 30%; float: left; padding: 7px 0px 5px 3px; font-weight: bold; font-size: 14px; color: #000; font-family: sans-serif;">
                        <label id="label_steameragent" style="color: #000000;" runat="server">Steamer Agent :</label>
                    </div>
                    <div style="width: 67%; float: left; padding: 7px 0px 5px 3px; font-size: 14px; color: #000; font-family: sans-serif;">
                        <asp:Label ID="lbl_oursteameragent" runat="server"></asp:Label>
                    </div>
                    <div style="clear:both;"></div>
                    <div style="width: 23%; float: left; padding: 7px 0px 5px 3px; font-weight: bold; font-size: 14px; color: #000; font-family: sans-serif;">
                        <label id="label_port2" style="color: #000000;" runat="server">Last Port 2 :</label>
                    </div>
                    <div style="width: 75%; float: left; padding: 7px 0px 5px 3px; font-size: 14px; color: #000; font-family: sans-serif;">
                        <asp:Label ID="lbl_ourport2" runat="server"></asp:Label>
                    </div>
                    <div style="clear:both;"></div>

                </div>
                <div style="float: left; width: 35%;">
                    <div style="width: 20%; float: left; padding: 7px 0px 5px 3px; font-weight: bold; font-size: 14px; color: #000; font-family: sans-serif;">
                        <label id="label_igmyear" style="color: #000000;" runat="server">IGM Year :</label>
                    </div>
                    <div style="width: 78%; float: left; padding: 7px 0px 5px 3px; font-size: 14px; color: #000; font-family: sans-serif;">
                        <asp:Label ID="lbl_ourigmyear" runat="server"></asp:Label>
                    </div>
                    <div style="clear:both;"></div>
                    <div style="width: 25%; float: left; padding: 7px 0px 5px 3px; font-weight: bold; font-size: 14px; color: #000; font-family: sans-serif;">
                        <label id="label_arrivaldate" style="color: #000000;" runat="server">Arrival Date :</label>
                    </div>
                    <div style="width: 73%; float: left; padding: 7px 0px 5px 3px; font-size: 14px; color: #000; font-family: sans-serif;">
                        <asp:Label ID="lbl_ourarriv" runat="server"></asp:Label>
                    </div>
                    <div style="clear:both;"></div>
                    <div style="width: 28%; float: left; padding: 7px 0px 5px 3px; font-weight: bold; font-size: 14px; color: #000; font-family: sans-serif;">
                        <label id="label_vesselnation" style="color: #000000;" runat="server">Vessel Nation :</label>
                    </div>
                    <div style="width: 69%; float: left; padding: 7px 0px 5px 3px; font-size: 14px; color: #000; font-family: sans-serif;">
                        <asp:Label ID="lbl_ourvesselnation" runat="server"></asp:Label>
                    </div>
                    <div style="clear:both;"></div>
                    <div style="width: 23%; float: left; padding: 7px 0px 5px 3px; font-weight: bold; font-size: 14px; color: #000; font-family: sans-serif;">
                        <label id="label_lastport3" style="color: #000000;" runat="server">Last Port 3 :</label>
                    </div>
                    <div style="width: 75%; float: left; padding: 7px 0px 5px 3px; font-size: 14px; color: #000; font-family: sans-serif;">
                        <asp:Label ID="lbl_ourlastport3" runat="server"></asp:Label>
                    </div>


                </div>
            </div>

                <asp:Label ID="lbl_bind" runat="server"></asp:Label>
            

        </div>
        </div>
</body>
</html>
