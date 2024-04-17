<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consolmanifest.aspx.cs" Inherits="logix.Reportasp.consolmanifest" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Report</title>
    <%--<link href="style.css" rel="stylesheet" type="text/css" />--%>
    <style>
        * {
            box-sizing: border-box;
            margin: 0;
            padding: 0;
        }

        .details thead th {
            font-size: 14px;
            font-family: sans-serif;
        }

        .details tbody td {
            font-size: 14px;
            font-family: sans-serif;
        }

        .report {
            width: 98%;
            margin: 20px auto;
            border: 1px solid #000;
            border-bottom: none !important;
        }

        .airline {
            width: 100%;
            /*margin: 20px auto;*/
        }

        .header {
            border-bottom: 1px solid #000;
        }

            .header h2 {
                text-align: center;
                line-height: 1.5;
                /*margin-top: 10px !important;*/
            }

            .header p {
                text-align: center;
                line-height: 1.5;
                /*margin-bottom: 10px !important;*/
            }

        .tablehead {
            text-align: center;
            padding: 10px 0 10px 0;
            font-weight: bold;
            border-bottom: 1px solid #000;
            float: left;
            width: 100%;
        }

        .tablecontent {
            float: left;
            width: 100%;
            border-bottom: 1px solid #000;
        }

        .maincontent {
            float: left;
            width: 100%;
        }

        .tbleft {
            float: left;
            width: 35%;
            border-right: 1px solid #000;
        }

        .tbcenter {
            float: left;
            width: 35%;
            border-right: 1px solid #000;
        }

        .tbright {
            float: left;
            width: 30%;
        }

        .tlhead {
            border-bottom: 1px solid #000;
            padding: 10px 0 10px 0;
        }

            .tlhead h4 {
                padding-left: 10px;
            }

        .tlc p {
            line-height: 1.5;
            padding: 5px 10px 0 10px;
            font-size: 9px;
        }

        .mainleft {
            float: left;
            width: 39%;
        }

        .mainright {
            float: left;
            width: 27%;
        }

        .maincenter {
            float: left;
            width: 34%;
        }



        .maincontent p {
            padding: 10px 0 0 10px;
            font-weight: bold;
        }

        .mainleft p, .maincenter p, .mainright p {
            float: left;
            width: 35% !important;
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
            width: 5%;
            height: 50px;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details thead th:nth-child(3) {
            padding: 0 !important;
            width: 7%;
            height: 50px;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details thead th:nth-child(4) {
            padding: 0 !important;
            width: 8%;
            height: 50px;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details thead th:nth-child(5) {
            padding: 0 !important;
            width: 8%;
            height: 50px;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details thead th:nth-child(6) {
            padding: 0 !important;
            width: 11%;
            height: 50px;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details thead th:nth-child(7) {
            padding: 0 !important;
            width: 5%;
            height: 50px;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details thead th:nth-child(8) {
            padding: 0 !important;
            width: 11%;
            height: 50px;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details thead th:nth-child(9) {
            padding: 0 !important;
            width: 7%;
            height: 50px;
            border-bottom: 1px solid #000;
        }

        table {
            border-collapse: collapse;
            border-top: 1px solid #000;
        }

        .details tbody tr td:nth-child(1) {
            padding: 0 !important;
            width: 2%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details tbody tr td:nth-child(2) {
            padding: 0 !important;
            width: 7%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details tbody tr td:nth-child(3) {
            padding: 0 !important;
            width: 5%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details tbody tr td:nth-child(4) {
            padding: 0 !important;
            width: 8%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
            text-align: right;
            padding-right: 5px !important;
        }

        .details tbody tr td:nth-child(5) {
            padding: 0 !important;
            width: 8%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
            text-align: right;
            padding-right: 5px !important;
        }

        .details tbody tr td:nth-child(6) {
            padding: 0 !important;
            width: 11%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details tbody tr td:nth-child(7) {
            padding: 0 !important;
            width: 10%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details tbody tr td:nth-child(8) {
            padding: 0 !important;
            width: 11%;
            height: auto;
            border-bottom: 1px solid #000;
            border-right: 1px solid #000;
        }

        .details tbody tr td:nth-child(9) {
            padding: 0 !important;
            width: 7%;
            height: auto;
            border-bottom: 1px solid #000;
        }

        .details tbody tr td {
            text-align: center;
        }

        .total {
            float: left;
            width: 73%;
            margin-left: 14px;
        }

            .total p {
                float: left;
                font-weight: bold;
                width: 28% !important;
            }

        span#lblprepareaddress {
            overflow-wrap: break-word;
            word-wrap: normal;
            word-break: break-all;
        }

        span#lblpreparename {
            overflow-wrap: break-word;
            word-wrap: normal;
            word-break: break-all;
        }

        span#lblconsignname {
            overflow-wrap: break-word;
            word-wrap: normal;
            word-break: break-all;
        }

        span#lblconsignaddress {
            overflow-wrap: break-word;
            word-wrap: normal;
            word-break: break-all;
        }

        span#lblnotifedname {
            overflow-wrap: break-word;
            word-wrap: normal;
            word-break: break-all;
        }

        span#lblnotifiedaddress {
            overflow-wrap: break-word;
            word-wrap: normal;
            word-break: break-all;
        }

        .graycolor {
            background: #c0c0c0;
        }

        .header {
            width: 100%;
            float: left;
        }

        img#lbl_img {
            width: auto;
        }

        img#lbl_img {
            width: auto;
            height: 44px;
        }

        body span {
            font-size: 12px !important;
        }
/*  td.tdrow label {
    -webkit-line-clamp: 0;
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: initial;
    -webkit-line-clamp: 10;
    -webkit-box-orient: vertical;
    display: block;
    width: 99px;
    margin-left: 28px;
}*/
        table.details tbody tr td label {
    font-size: 12px !important;
}

    </style>
    <head>
        <%--<body>
<div style="width:100%;">
    <div class="airline">
<div class="report">
    <div class="header">
        <h2><asp:label ID="lblbrname" runat="server"></asp:label></h2>
        <p><asp:label ID="lbladdress" runat="server"></asp:label></p><p>Phone # :<span><asp:label ID="lblphone" runat="server" style="margin-left:5px;"></asp:label><span style="display: inline;padding-left: 13px;">Fax # :</span><asp:label ID="lblfax" runat="server" style="margin-left:5px;"></asp:label></span></p>
    </div>
    <div class="tablehead">
       <h4><asp:label ID="thead" runat="server" >BOOKING</asp:label></h4>
    </div>
    <div class="tablecontent">
        <div class="tbleft">
            <div class="tlhead"><h4>PREPARED BY</h4></div>
            <div class="tlc"><p><asp:label ID="lblpreparename" runat="server"></asp:label></p><p><asp:label ID="lblprepareaddress" runat="server"></asp:label></p></div>
        </div>
        <div class="tbcenter">
            <div class="tlhead"><h4>CONSIGNED TO</h4></div>
            <div class="tlc"><p><asp:label ID="lblconsignname" runat="server"></asp:label></p><p><asp:label ID="lblconsignaddress" runat="server"></asp:label></p></div>
        </div>
        <div class="tbright">
            <div class="tlhead"><h4>NOTIFIED TO</h4></div>
            <div class="tlc"><p><asp:label ID="lblnotifedname" runat="server"></asp:label></p><p><asp:label ID="lblnotifiedaddress" runat="server"></asp:label></p></div>
        </div>
    </div>
    <div class="maincontent">
        <div class="mainleft">
            <p>MAWB NO. & DATE</p>
            <span style="">:<asp:label ID="lblblno" runat="server" style="margin-left: 20px;"></asp:label>&<asp:label ID="lblbldate" runat="server"></asp:label></span>
            <p>CARRIER</p>
            <span>:<asp:label ID="lblcarrier" runat="server" style="margin-left:20px;"></asp:label></span>
            <p>PORT OF LOADING</p>
            <span>:<asp:label ID="lblloading" runat="server" style="margin-left:20px;"></asp:label></span>
            <p>NO OF PACKAGES</p>
            <span>:<asp:label ID="lblpackage" runat="server" style="margin-left:20px;"></asp:label><asp:label ID="lbldesc" runat="server"></asp:label></span>
            <p>GROSS WEIGHT</p>
            <span>:<asp:label ID="lblgross" runat="server" style="margin-left:20px;"> KGS</asp:label>
            </span>
            <p>CHARGE WEIGHT</p><span>:<asp:label ID="lblcharge" runat="server" style="margin-left:20px;"> KGS</asp:label> </span>
        </div>
        <div class="maincenter">
            <p>CONSOL REF #</p><span>:<asp:label ID="lblconsol" runat="server" style="margin-left:20px;"></asp:label>
            </span>
            <p>PORT OF DESTINATION</p><span>:<asp:label ID="lbldestination" runat="server" style="margin-left:20px;"></asp:label></span>
        </div>
        <div class="mainright">
            <p>FLIGHT #</p><span>:<asp:label ID="lblflightno" runat="server" style="margin-left:20px;"></asp:label>&<asp:label ID="lblflightdate" runat="server"></asp:label></span>
        </div>
    </div>
    <div class="table">
        <table class="details">
            <thead>
                <tr>
                    <th>S #</th>
                    <th>HAWB NO.</th>
                    <th>NO OF PKGS</th>
                    <th>GR. WT
                        (KGS)</th>
                    <th>VOL. WT
                        (KGS)</th>
                    <th>COMMODITY</th>
                    <th>SHIPPER</th>
                    <th>CONSIGNEE</th>
                    <th>DIMENSIONS</th>

                
                </tr>
            </thead>
            <tbody>
                
                    <asp:Label ID="lbldetails" runat="server"></asp:Label>
                
            </tbody>
        </table>
    </div>
    </div>
<div class="total">
        <p style="font-size:14px;font-family:sans-serif;color:#000;">TOTAL CHARGEABLE WEIGHT</p>
        <span style="font-size:14px;font-family:sans-serif;    color: #2c2b2b;">:<asp:label ID="lblnoofpkg" runat="server" style="margin-left:20px;"><asp:Label ID="lbldesc2" runat="server"></asp:Label></asp:label><asp:Label ID="lbltotalgr" runat="server" ></asp:Label><asp:Label ID="lbltotalvol" runat="server" ></asp:Label></span>
        </div>
        
    </div>
    </div>
</body>--%>


        <%---------------NEW---------------------%>
    </head>
    <body>
        <div style="width: 100%;">
            <div class="airline">
                <div class="report">
                    <div class="header">

                        <div style="width: 225px; float: left; margin-top: 14px; margin-left: 6px; height: 50px;">
                            <asp:Image ID="lbl_img" runat="server" />
                        </div>
                        <div style="width: 55%; float: left; margin-left: 100px;">
                            <h2 style="font-family: Segoe UI; font-size: 21px; font-weight: bold; color: #000;">
                                <asp:Label ID="lblbrname" runat="server"></asp:Label></h2>
                            <p style="font-family: Segoe UI; font-size: 17px; font-weight: normal; color: #000;">
                                <asp:Label ID="lbladdress" runat="server"></asp:Label>
                            </p>
                            <p style="font-family: Segoe UI; font-size: 12px; font-weight: normal; color: #000;">
                                Phone # :<span><asp:Label ID="lblphone" runat="server" Style="margin-left: 5px;"></asp:Label><span style="display: inline; padding-left: 13px;">Fax # :</span><asp:Label ID="lblfax" runat="server" Style="margin-left: 5px;"></asp:Label></span>
                            </p>
                        </div>
                    </div>
                    <div class="tablehead">
                        <h4 style="font-size: 14px; font-family: sans-serif; color: #000;">
                            <asp:Label ID="thead" runat="server"></asp:Label></h4>
                    </div>
                    <div class="tablecontent">
                        <div class="tbleft">
                            <div class="tlhead">
                                <h4 style="font-size: 14px; font-family: sans-serif; color: #000;">PREPARED BY</h4>
                            </div>
                            <div class="tlc" style="min-height: 85px;">
                                <p style="font-size: 14px; font-family: sans-serif; height: 19px; color: #2c2b2b; width: 100% !important;">
                                    <asp:Label ID="lblpreparename" runat="server"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lblprepareaddress" runat="server"></asp:Label>
                                </p>
                                <p  style="padding-top:0px !important">
                                    <asp:Label ID="lbl_cunname" runat="server"></asp:Label>
                                </p>

                            </div>
                        </div>
                        <div class="tbcenter">
                            <div class="tlhead">
                                <h4 style="font-size: 14px; font-family: sans-serif; color: #000;">CONSIGNED TO</h4>
                            </div>
                            <div class="tlc" style="min-height: 85px;">
                                <p style="font-size: 14px; font-family: sans-serif; height: 19px; color: #2c2b2b; width: 100% !important;">
                                    <asp:Label ID="lblconsignname" runat="server"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lblconsignaddress" runat="server"></asp:Label>
                                </p>
                                <p style="padding-top:0px !important">
                                    <asp:Label ID="lbl_counname" runat="server"></asp:Label>
                                </p>

                            </div>
                        </div>
                        <div class="tbright">
                            <div class="tlhead">
                                <h4 style="font-size: 14px; font-family: sans-serif; color: #000; width: 100% !important;">NOTIFIED TO</h4>
                            </div>
                            <div class="tlc">
                                <p style="font-size: 14px; font-family: sans-serif; height: 19px; color: #2c2b2b;">
                                    <asp:Label ID="lblnotifedname" runat="server"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lblnotifiedaddress" runat="server"></asp:Label>
                                </p>
                                <p style="padding-top:0px !important">
                                    <asp:Label ID="Label3" runat="server"></asp:Label>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="maincontent">
                        <div class="mainleft">
                            <p style="font-size: 14px; font-family: sans-serif; color: #000;">MAWB NO. & DATE</p>
                            <div style="float: left; padding-top: 10px;">:</div>
                            <div id="bl_visi" runat="server" style="font-size: 14px; font-family: sans-serif; color: #2c2b2b; display: block; white-space: nowrap; padding-top: 1px !important; padding-top: 10px;">
                                <asp:Label ID="lblblno" runat="server" Style="margin-left: 20px;"></asp:Label> & <asp:Label ID="lblbldate" runat="server"></asp:Label>
                            </div>
                            <div style="clear: both;"></div>
                        </div>
                        <div class="maincenter">
                            <div style="clear: both;"></div>
                            <p style="font-size: 14px; font-family: sans-serif; color: #000; width: 49% !important;">CONSOL REF #</p>
                            <div style="font-size: 14px; font-family: sans-serif; color: #2c2b2b; padding-top: 10px;">
                                :<asp:Label ID="lblconsol" runat="server" Style="margin-left: 20px;"></asp:Label>
                            </div>
                            <div style="clear: both;"></div>
                        </div>
                        <div class="mainright">
                            <p style="font-size: 14px; font-family: sans-serif; color: #000; width: 35% !important;">FLIGHT #</p>
                            <div style="font-size: 14px; font-family: sans-serif; color: #2c2b2b; padding-top: 10px;">:<asp:Label ID="lblflightno" runat="server" Style="margin-left: 20px;"></asp:Label> & <asp:Label ID="lblflightdate" runat="server"></asp:Label></div>
                        </div>
                    </div>
                    <div style="float: left; width: 100%">
                        <p style="font-size: 14px; font-family: sans-serif; color: #000; float: left; font-weight: bold; padding-left: 10px; padding-top: 10px; width: 13.7%; padding-bottom: 7px;">CARRIER</p>
                        <div style="font-size: 14px; font-family: sans-serif; color: #2c2b2b; float: left; font-weight: normal; padding-top: 10px;">:<asp:Label ID="lblcarrier" runat="server" Style="margin-left: 20px;"></asp:Label></div>
                    </div>

                    <div class="maincontent" style="padding-bottom: 10px;">
                        <div class="mainleft">
                            <div style="clear: both;"></div>
                            <p style="font-size: 14px; font-family: sans-serif; color: #000; padding-top: 0px !important;">PORT OF LOADING</p>
                            <div style="font-size: 14px; font-family: sans-serif; color: #2c2b2b;">:<asp:Label ID="lblloading" CssClass="graycolor" runat="server" Style="margin-left: 20px;"></asp:Label></div>
                            <div style="clear: both;"></div>
                            <p style="font-size: 14px; font-family: sans-serif; color: #000;">NO OF PACKAGES</p>
                            <div style="font-size: 14px; font-family: sans-serif; color: #2c2b2b; padding-top: 10px;">:<asp:Label ID="lblpackage" runat="server" Style="margin-left: 20px;"></asp:Label><asp:Label ID="lbldesc" runat="server"></asp:Label></div>
                            <div style="clear: both;"></div>
                            <p style="font-size: 14px; font-family: sans-serif; color: #000;">GROSS WEIGHT</p>
                            <div style="font-size: 14px; font-family: sans-serif; color: #2c2b2b; padding-top: 10px;">
                                :<asp:Label ID="lblgross" runat="server" Style="margin-left: 20px;"></asp:Label>
                                KGS
                            </div>
                            <div style="clear: both;"></div>
                            <p style="font-size: 14px; font-family: sans-serif; color: #000;">CHARGE WEIGHT</p>
                            <div style="font-size: 14px; font-family: sans-serif; color: #2c2b2b; padding-top: 10px;">
                                :<asp:Label ID="lblcharge" runat="server" Style="margin-left: 20px;"></asp:Label>
                                KGS
                            </div>
                        </div>
                        <div class="maincenter">

                            <div style="clear: both;"></div>
                            <p style="font-size: 14px; font-family: sans-serif; color: #000; padding-top: 0px !important; width: 49% !important">PORT OF DESTINATION</p>
                            <div style="font-size: 14px; font-family: sans-serif; color: #2c2b2b;">:<asp:Label ID="lbldestination" CssClass="graycolor" runat="server" Style="margin-left: 20px;"></asp:Label></div>
                        </div>


                    </div>

                    <div class="table">
                        <table class="details">
                            <thead>
                                <tr>
                                    <th>S #</th>
                                    <th>HAWB NO.</th>
                                    <th>NO OF PKGS</th>
                                    <th>GR. WT
                        (KGS)</th>
                                    <th>VOL. WT
                        (KGS)</th>
                                    <th>COMMODITY</th>
                                    <th>SHIPPER</th>
                                    <th>CONSIGNEE</th>
                                    <th>DIMENSIONS in cms
                                        <br />
                                        (L x B x W x P)</th>


                                </tr>
                            </thead>
                            <tbody>
                                <%--<tr>
                    <td>1</td>
                    <td>1123022297</td>
                    <td>1 Boxes</td>
                    <td>26.000</td>
                    <td>13.00</td>
                    <td>PART OF
                        NON-STERILE
                        SURGICAL
                        NEEDLED SUTURE</td>
                    <td>KRS ENTERPRISES
                        INDIA</td>
                    <td>POLYTECHMED M LTD
                        RUSSIAN FEDERATION</td>
                    <td><p style="font-size:14px;font-family:sans-serif;font-weight:bold; margin-bottom:10px;" >Dimension in cms Length / Breadth / Width / Pieces</p>61.00 X 41.00 X 31.00 X 1</td>
                </tr>--%>
                                <asp:Label ID="lbldetails" runat="server"></asp:Label>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="total">
                    <p style="font-size: 14px; font-family: sans-serif; color: #000;">TOTAL CHARGEABLE WEIGHT</p>
                    <span>:</span>
                    <span style="font-size: 14px; font-family: sans-serif; color: #2c2b2b; background: #c0c0c0;">
                        <asp:Label ID="lbltotalcharge" CssClass="" runat="server" Style="margin-left: 5px;"></asp:Label>
                        KGS</span>
                </div>

            </div>
        </div>
    </body>
</html>
