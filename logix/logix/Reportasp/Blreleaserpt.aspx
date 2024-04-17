<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Blreleaserpt.aspx.cs" Inherits="logix.Reportasp.Blreleaserpt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
  <head>
    <%--<meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />--%>
       <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Document</title>
     <style type="text/css">
      * {
        margin: 0;
        padding: 0;
        box-sizing: border-box;
      }
      body {
        font-size: 14px;
        font-family: Arial;
        line-height: 18px;
      }
      .top_title {
        text-align: right;
      }
      .container {
        width: 1024px;
        margin: 57px auto;
        /* border: 1px solid #000; */
        /*margin-bottom: 2rem;*/
      }
      .left_content {
        border-right: 1px solid #000;
        width: 50%;
      }
      .modes p {
            height: 30px;
        }
       .vessel.w-50.border-right {
            width: 48%;
        }
      .main_banner {
        display: flex;
      }
      .main_banner p {
        text-transform: uppercase;
        padding: 10px 0px 2px 0px;
      }
      .left_content .title {
        text-transform: uppercase;
        padding: 10px 0 10px 10px;
        border-bottom: 1px solid #000;
      }
      .shipper,
      .consignee,
      .vessel,
      .bl_no,
      .qr_code,
      .notify_add,
      .modes,
      .details,
      .details_descr,
      .num_original,
      .issue,
      .agent,
      .descrr_content p,
      .company,
      .carrier {
        padding: 10px 0px 10px 10px;
      }
      .shipper,
      .consignee,
      .vessel {
        border-bottom: 1px solid #000;
      }
      .shipper p {
        width: 90%;
        height: 90px;
      }
      .consignee p {
        width: 90%;
        height: 100px;
      }
      .vessel_content,
      .port_content,
      .types_content,
      .company {
        display: flex;
      }
      .w-50 {
        width: 50%;
      }
      .border-right {
        border-right: 1px solid #000;
      }
      .border-top {
        border-top: 1px solid #000;
      }
      .border-left {
        border-left: 1px solid #000;
      }
      .border-bottom {
        border-bottom: 1px solid #000;
      }
      .bl_no .no {
        height: 18px;
        margin-right: 100px;
        text-transform: uppercase;
      }
      .vessel_content p,
      .port_content p {
        height: 30px;
      }
      .bl_no {
        display: flex;
        justify-content: space-between;
        border-bottom: 1px solid #000;
      }
      .qr_code {
        height: 90px;
        border-bottom: 1px solid #000;
      }
      .qr_code img {
        position: relative;
        right: 10px;
        margin: 10px 0px 0px 0px;
      }
      .vessel.w-50 {
    width: 52%;
}
     .notify_add p {
    width: 90%;
    height: 110px;
}
      .notify_add {
        padding-bottom: 8px;
        border-bottom: 1px solid #000;
      }
      .shipper_title,
      .seal_title,
      .above {
        text-align: center;
        text-transform: uppercase;
        padding: 3px;
      }
      table {
        width: 100%;
        border-collapse: collapse;
        border-bottom: 1px solid #000 !important;
        border-top: 1px solid #000 !important;
        border-right: 1px solid #000;
        border-left: 1px solid #000;
        height: 300px;
      }
      table th {
        font-size: 11px;
        text-align: center;
        padding: 0px 8px 0 10px;
        border-right: 1px solid #000;
        border-bottom: 1px solid #000;
      }
      table th:last-child {
        border-right: 0;
      }
      table td {
        padding: 10px 10px 0 10px;
        border-right: 1px solid #000;
        height: 20px;
        font-size: 12px;
        text-align: center;
        vertical-align: top;
      }
      table td:last-child {
        border-right: 0;
      }
      .footer-content {
        display: flex;
      }
      .details p {
        text-align: center;
      }
      .details_descr {
        font-weight: bold;
        font-size: 12px;
      }
      .freight {
        display: flex;
        justify-content: space-between;
        width: 310px;
      }
      .area_details {
        display: flex;
      }
      .issue p,
      .num_original p {
        height: 20px;
        text-transform: uppercase;
        text-align: center;
        padding: 10px 0 0 0;
      }
      .num_original p {
        margin-top: 20px;
        height: 30px;
      }
      .agent p {
        text-transform: uppercase;
        padding: 10px 0 0 0;
        width: 90%;
       
      }
      .descrr_content p {
        /* height: 130px; */
        font-size: 12px;
        word-spacing: 5px;
      }
      .company h4 {
        text-transform: uppercase;
      }
      .company b {
        width: 35px;
      }
      .carrier {
        text-align: center;
        margin-top: 65px;
      }
      table td strong {
        height: 25px;
        display: inline-block;
      }
      table td:nth-child(4) span {
        padding: 0px 0px 5px 0;
        display: inline-block;
      }
      table td:nth-child(1),
      table td:nth-child(2),
      table td:nth-child(3) {
        text-align: left;
      }
      table th:nth-child(3) {
        white-space: nowrap;
      }
      table td:nth-child(4) {
        width: 130px;
      }
      /*.load_title{
          width:400px;
      }*/
      .right_content {
    width: 50%;
}

      span#lblDescription {
    white-space: pre-line;
    text-align: left;
    float: left;
    display: inline-block;
    vertical-align: top;
}

      span#lbl_conshipaddress {
    white-space: pre-wrap;
}
      span#lbl_conaddress {
    white-space: pre-wrap;
}
      span#lbl_notifyaddress {
    white-space: pre-wrap;
}

      span#lbl_delicontact {
    white-space: pre-wrap;
}
    </style>
  </head>
  <body>
    <div class="container">
      <div class="top_title">
        <h3><asp:Label ID="lbl_blrreltype" runat="server"></asp:Label></h3>
      </div>
      <div class="main_banner border-top border-right border-left">
        <!-- left_content -->
        <div class="left_content">
          <div class="title">
            <h4>bill of lading for transport or multimodal transport</h4>
          </div>

          <div class="shipper">
            <h4>Shipper</h4>
            <p>
             <asp:Label ID="lbl_conshipaddress" runat="server"></asp:Label>
            </p>
          </div>

          <div class="consignee" style="
    padding-bottom: 18px;
">
            <h4>Consignee (or Order)</h4>
            <p>
             <asp:Label ID="lbl_conaddress" runat="server"></asp:Label>
            </p>
          </div>

          <div class="vessel_voyage_content">
            <div class="vessel_content">
              <div class="vessel w-50 border-right">
                <h4>Vessel & Voyage No:</h4>
                <p><asp:Label ID="lbl_vessel" runat="server"></asp:Label> <b>V.</b><asp:Label ID="lbl_voy" runat="server"></asp:Label></p>
              </div>

              <div class="vessel w-50">
                <h4>Route / Place of Transhipment(if any)</h4>
                <p><asp:Label ID="lbl_transhipplace" runat="server"></asp:Label>
              </div>
            </div>

            <div class="port_content">
              <div class="vessel w-50 border-right">
                <h4>Place of Acceptance</h4>
                <p><asp:Label ID="lbl_POAccept" runat="server"></asp:Label>
              </div>

              <div class="vessel w-50">
                <h4>Port of Loading</h4>
                <p><asp:Label ID="lbl_POL" runat="server"></asp:Label></p>
              </div>
            </div>
          </div>
        </div>
        <!-- right_content -->
        <div class="right_content">
          <div class="bl_no">
            <h3>Bill of Lading No:</h3>
            <div class="no"> <asp:Label ID="lbl_blno" runat="server"></asp:Label></div>
          </div>

          <div class="bl_no">
            <h3>Shipment Reference No :</h3>
            <div class="no"><asp:Label ID="lblshprefno" runat="server"></asp:Label></div>
          </div>

          <div class="qr_code">
            <img src="" alt="" />
          </div>

          <div class="notify_add">
            <h4>Notify address</h4>
            <p>
              <asp:Label ID="lbl_notifyaddress" runat="server"></asp:Label>
            </p>
          </div>
          <div class="types_content border-bottom">
            <div class="type1 w-50 border-right">
              <div class="modes border-bottom">
                <h4>Modes / means of transport</h4>
                <p> <asp:Label ID="lbl_transmode" runat="server"></asp:Label></p>
              </div>
              <div class="modes">
                <h4>Port of Discharge</h4>
                <p><asp:Label ID="lbl_POD" runat="server"></asp:Label></p>
              </div>
            </div>
            <div class="type2 w-50">
              <div class="modes border-bottom">
                <h4>Move Type</h4>
                <p><asp:Label ID="lbl_movetype" runat="server"></asp:Label></p>
              </div>
              <div class="modes">
                <h4>Place of Delivery</h4>
                <p><asp:Label ID="lbl_PODel" runat="server"></asp:Label></p>
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- title -->
      <div class="shipper_title">
        <h3>particulars furnished by shipper</h3>
      </div>

      <!-- table -->
           <div style="width: 1024px;">
            <table width="1024" border="0" cellspacing="0" cellpadding="0" style="padding: 0px; font-size: 14px; border-top: 0px solid #000; border-bottom: 0px solid #000;">
                <tr>
                    <th style="font-weight: bold; padding: 5px; font-size: 11px; text-align: left;" class="auto-style1">Container No(s).</th>
                    <th style="font-weight: bold; padding: 5px; font-size: 11px;">Marks and Numbers</th>
                    <th style="font-weight: bold; padding: 5px; font-size: 11px;">SAID TO CONTAIN <br/> Number of packages, kinds of Packages, general description of goods</th>
                    <th style="font-weight: bold; padding: 5px; font-size: 11px;">Gross Weight</th>
                    <th style="font-weight: bold; padding: 5px; font-size: 11px;">Measurement</th>
                </tr>
                <tr>
                    <td  style="font-weight: bold; padding: 5px; text-align: left; font-size: 11px;" class="load_title"><asp:Label ID="lblshiploadcount" runat="server" Visible="false">SHIPPER'S LOAD STOW & COUNT</asp:Label> </td>
                   
                     <td  style="font-weight: bold; padding: 5px; text-align: center; padding-right: 25px; font-size: 11px;"></td>
                    
                     <td  style="font-weight: bold; padding: 5px; text-align: center; padding-right: 25px; font-size: 11px;"></td>
                    <td nowrap="nowrap" style="font-weight: bold; padding: 5px; text-align: center; font-size: 11px;" colspan="2">SAID TO WEIGHT / MEASURE</td>
                </tr>
                <tr style="height: 250px;">
                    <td class="auto-style1" style="vertical-align: top;">
                        <p style="font-weight: normal; padding: 5px; line-height: 18px; text-align: left; margin: 0px;">
                            Container #/Size/Seal # 
                            <br />
                            <asp:Label ID="lbl_container" runat="server"></asp:Label>
                        </p>


                    </td>
                    <td style="width: 200px; vertical-align: top;">
                        <p style="font-weight: normal; padding: 5px; text-align: left; line-height: 18px; margin: 0px 0px 0px -8px;">
                            <asp:Label ID="lbl_marks" runat="server"></asp:Label>
                        </p>


                    </td>
                    <td style="vertical-align: top;">
                        <div style="min-height: 445px; vertical-align: top;margin-top:-28px;">
                            <p style="font-weight: normal; margin: 0px; padding: 5px; text-align: left; line-height: 18px; vertical-align: top;">
                                <asp:Label style="display:none;" ID="lbl_pkg" runat="server"></asp:Label>
                            </p>
                            <br />
                            <asp:Label ID="lblDescription" runat="server" >

                            </asp:Label>
                        </div>

                    </td>
                    <td rowspan="11" valign="top" style="font-weight: normal; padding: 0px; text-align: center; vertical-align: top;">
                        <p style="font-weight: normal; line-height: 20px; padding: 5px 5px 5px 29px; margin: 0px; text-align: center; white-space: nowrap;">
                            Gross Weight<br />
                            <asp:Label ID="lbl_grwt" runat="server"></asp:Label>
                        </p>



                        <p style="font-weight: normal; text-align: center; white-space: nowrap; line-height: 20px; padding: 5px 5px 5px 29px; margin: 0px;">
                            Net Weight
               <br />
                            <asp:Label ID="lbl_netwt" runat="server"></asp:Label>
                        </p>
                        <br />
                       <%-- <p style="font-weight: bold; padding: 5px; text-align: left; white-space: pre; margin-top: 45px;">
                            <asp:Label ID="lbl_type" runat="server"></asp:Label><br />
                            <asp:Label ID="lbl_freitype" runat="server"></asp:Label><br />
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </p>--%>
                    </td>
                    <td style="font-weight: normal; padding: 5px; text-align: left; vertical-align: top;">

                        <p style="font-weight: normal; line-height: 20px; padding: 5px 5px 5px 29px; margin: 0px; text-align: center; white-space: nowrap;">

                            <asp:Label ID="lbl_cbm" runat="server"></asp:Label>
                        </p>

                    </td>
                </tr>
              
                <tr>
                    <td style="font-weight: bold; padding: 5px 5px 10px 5px; text-align: left;">
                        <p style="font-weight: bold; font-size: 14px; padding: 5px; text-align: left; margin: -150px 0px 0px 0px;">
                            <asp:Label ID="lblAnnexcontainer" runat="server" Visible="false">AS PER ATTACHED LIST</asp:Label>
                        </p>
                    </td>
                    <td style="font-weight: bold; padding: 5px; text-align: center;">
                        <p style="font-weight: bold; padding: 5px; font-size: 14px; text-align: left; margin: -150px 0px 0px 0px;">
                            <asp:Label ID="lblAnnexMarks" runat="server" Visible="false">AS PER ATTACHED LIST</asp:Label>
                        </p>
                    </td>
                    <td style="font-weight: bold; padding: 5px; text-align: center;">
                        <p style="font-weight: bold; padding: 5px; font-size: 14px; text-align: left; margin: -150px 0px 0px 0px;">
                            <asp:Label ID="lblAnnexDesc" runat="server" Visible="false">AS PER ATTACHED LIST</asp:Label>
                        </p>
                    </td>
                    <%--<td style="font-weight: bold; padding: 5px; text-align: center;">&nbsp;</td>
                    <td style="font-weight: bold; padding: 5px; text-align: center;">&nbsp;</td>--%>

                </tr>

              
            </table>
        </div>
      <%--<table>
        <thead>
          <th>Container No(s)./SizeType/seal #</th>
          <th>Marks and Numbers</th>
          <th>
            <strong>SAID TO CONTAIN</strong> <br />
            Number of packages, kinds of Packages, general description of goods
          </th>
          <th>Gross Weight</th>
          <th>Measurement</th>
        </thead>
        <tbody>
          <tr>
            <td></td>
            <td></td>
            <td></td>
            <td>
              <strong>Gross Weight</strong>
              <span><asp:Label ID="lbl_grwt" runat="server"></asp:Label></span>
              <strong>Net Weight</strong>
              <span><asp:Label ID="lbl_netwt" runat="server"></asp:Label></span>
            </td>
            <td><asp:Label ID="lbl_cbm" runat="server"></asp:Label></td>
          </tr>
        </tbody>
      </table>--%>
      <div class="seal_title border-bottom border-right border-left">
        <strong>shipper's own load .stow.count and seal</strong>
      </div>

      <div class="above">
        <h5>
          Above particulars as declared by Shipper, but without responsibility
          by Carrier (see caluse 14)
        </h5>
      </div>

      <!-- footer -->
      <div class="footer-content border-right border-left border-bottom">
        <!-- footer_left -->
        <div class="footer_left w-50 border-right border-top">
          <div class="details border-bottom">
            <div class="freight">
              <h4>Freight Details</h4>
              <p> <asp:Label ID="lbl_freitype" runat="server"></asp:Label></p>
            </div>
          </div>

          <div class="details_descr border-bottom">
            <p>
              Carrier's Receipt(see clause & 14) Total number of containers of
              packages received by Carrier.
            </p>
          </div>

          <div class="area_details border-bottom">
            <div class="num_original w-50 border-right">
              <h4>Number or Original B/L (s)</h4>
              <p><asp:Label ID="lbl_nooforigi" runat="server"></asp:Label></p>
            </div>
            <div class="date_area w-50">
              <div class="issue border-bottom">
                <h4>Place of Issue of B/L</h4>
                <p><asp:Label ID="lbl_place" runat="server"></asp:Label></p>
              </div>
              <div class="issue">
                <h4>Date of Issue of B/L</h4>
                <p><asp:Label ID="lbl_bldate" runat="server"></asp:Label></p>
              </div>
            </div>
          </div>
          <div class="agent">
            <h4>Delivery Agent</h4>
            <p>
            <asp:Label ID="lbl_delicontact" runat="server"></asp:Label>
            </p>
          </div>
        </div>
        <!-- footer_right -->
        <div class="footer_right w-50 border-top">
          <div class="descrr_content">
            <p style="font-size: 10px;
    font-family: arial;
    line-height: 9px;">
              SHIPPED as far as ascertained by reasonable by means of checking. In apparent good order and condition unless otherwise stated herein, the total number quantity of Containers or other packages or units indicated in the box entitled “Carrier’s Receipt” for carriage from the Port of Loading(or the Place or Receipt, if mentioned above) the Port of Discharge (or the Place of Delivery, if mentioned above),such carriage being always subject to the term, rights, defenses, provision, exception,limitations and liberties hereof (INCLUDING ALL THOSE TERMS AND CONDITION ON THE REVERSE HEREOFNUMBERED 12-26 AND THISE TERMS AND CONDITIONS CONTAINED IN THE CARRIERS APPLICABLE TARIFF ) and the merchant’s attention in drawn in particular to the Carrier’s liberties in respect of on deck stowage(see clause 18) and the carrying vessel(see clause 19). Where the bill of lading is non-negotiable the Carrier may give delivery of on deck stowage to the named consignee upon reasonable proof of identity and without requiring surrender of an original bill of lading. where the bill of lading is negotiable , the Merchant is obliged to surrender one original, duly endorsed, in exchange for the Goods. The Carrier accepts a duty of reasonable care to check that any such document which the Merchant surrenders as a bill of lading is genuine and original bill of lading, such delivery discharging the Carrier’s delivery obligations. In accepting this bill of lading, any local customer or privileges to the contrary notwithstanding, the Merchant agrees to be bound by all Terms and Conditions stated herein whether written, printed, stamped stamped or incorporated on the fasce or reverse side hereof , as fully as if they were all signed by the Merchant.
IN WITNESS WHEREOF the number of original Bill of Lading Stated on this side have been signed and whatever one original Bill of Lading has been surrendered any others shall be void.
            </p>
          </div>
          <div class="company">
            <b>for </b>
            <h4><asp:Label ID="lblBranchname" runat="server"></asp:Label></h4>
          </div>
          <div class="carrier">
            <h4><asp:Label ID="lblSigntype" runat="server"></asp:Label></h4>
          </div>
        </div>
      </div>
    </div>
       <form id="test" runat="server">
            <asp:HiddenField ID="hid_marks" runat="server" />
        <asp:HiddenField ID="hid_desc" runat="server" />
        </form>
  </body>
    
</html>

