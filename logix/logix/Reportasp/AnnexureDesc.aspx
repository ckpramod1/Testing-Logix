<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnexureDesc.aspx.cs" Inherits="logix.Reportasp.AnnexureDesc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Annexure</title>
    <style type="text/css">
        span#lblDescription {
            float: left;
            white-space: pre-wrap;
            word-break:break-word;
            display: inline-block;
        }

        span#lblMarksandnumbers {
            white-space: pre-wrap;
            word-break:break-word;
            display: inline-block;
            float: left;
        }

        span#lblContainerno {
            float: left;
             white-space: pre-wrap;
            word-break:break-word;
            display: inline-block;
        }
    </style>
</head>
<body style="font-family: sans-serif; font-size: 12px; color: #000;">
    <form id="form1" runat="server">
        <div style="width: 1024px; margin: 0px auto;">

            <div style="width: 1024px; float: left;">

                <p style="padding: 5px; margin: 0px; font-weight: bold;">
                    ATTACHED LIST‎
                </p>

            </div>
            <div style="width: 1024px; float: left;">
                <div style="width: 90px; margin: 0px 5px 0px 0px; padding: 5px; font-weight: bold; float: left;">BL NUMBER &nbsp;&nbsp;:</div>
                <div style="width: 250px; margin: 0px 0px 0px 0px; padding: 5px; float: left;">‎<asp:Label ID="lblBlno" runat="server"></asp:Label>‎</div>
            </div>
            <div style="width: 1024px; float: left; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 5px 0px 5px 0px; margin: 0px 0px 0px 0px;">

                <div style="float: left; width: 1024px; border-bottom: 1px solid #000;">
                    <div style="width: 341px; padding: 5px 0px 5px 0px; margin: 0px 0px 0px 0px; float: left; font-weight: bold;" id="Div_H_Marks" runat="server" visible="false">MARKS & NUMBERS</div>
                    <div style="width: 341px; padding: 5px 0px 5px 0px; margin: 0px 0px 0px 0px; float: left; font-weight: bold;" id="Div_H_Containerno" runat="server" visible="false">CONTAINER DETAILS</div>
                    <div style="width: 341px; padding: 5px 0px 5px 0px; margin: 0px 0px 0px 0px; float: left; font-weight: bold;" id="Div_H_Desc" runat="server" visible="false">DESCRIPTION</div>
                </div>
                <div style="width: 341px; padding: 5px 0px 5px 0px; margin: 0px 0px 0px 0px; float: left;" id="DivMarks" runat="server" visible="false">
                    <span style="width: auto; float: left; display: inline-block; line-height: 18px; text-align: left; padding: 0px; margin: 0px; white-space: pre">
                        <asp:Label ID="lblMarksandnumbers" runat="server">

                        </asp:Label>
                    </span>
                </div>
                <div style="width: 341px; padding: 5px 0px 5px 0px; margin: 0px 0px 0px 0px; float: left;" id="DivContainerno" runat="server" visible="false">
                    <span style="width: auto; float: left; display: inline-block; line-height: 18px; text-align: left; padding: 0px; margin: 0px; white-space: pre">
                        <asp:Label ID="lblContainerno" runat="server">
                        </asp:Label>
                    </span>
                </div>
                <div style="width: 341px; padding: 5px 0px 5px 0px; margin: 0px 0px 0px 0px; float: left;" id="DivDesc" runat="server" visible="false">

                    <span style="width: auto; float: left; display: inline-block; line-height: 18px; text-align: left; padding: 0px; margin: 0px; white-space: pre">
                        <asp:Label ID="lblDescription" runat="server">
                        </asp:Label>
                    </span>
                </div>

            </div>


        </div>
    </form>
</body>
</html>
