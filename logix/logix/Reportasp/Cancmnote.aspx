<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cancmnote.aspx.cs" Inherits="logix.Reportasp.Cancmnote" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>CONTAINER MOVEMENT FACILITATION CELL</title>
</head>
<%--<body style="font-family:Georgia;">

     <asp:Label ID="tdRow_CanDtls" runat="server"></asp:Label>
      <form runat="server">
            <div style="width:1024px; margin:0px; padding:0px; border-bottom:1px solid #000;">
<div style="float:left; width:100px; margin:5px 0px 5px 25px;"> <img src="../images/MR.png" width="150px" height="auto"  /></div>
<div style="width:877px; float:left;">
<h3 style="text-align:center; padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; font-size:24px; font-weight:bold; "><asp:Label ID="lbl_branch" runat="server"></asp:Label></h3>
<p style="font-weight:normal; padding:5px 0px 0px 0px; margin:0px 0px 0px 0px; text-align:center;"><asp:Label ID="lbl_address" runat="server"></asp:Label></p>
<p  style="font-weight:normal; padding:0px 0px 5px 0px; margin:0px 0px 0px 0px; text-align:center;"><strong>Tel</strong> : <asp:Label ID="lbl_ph" runat="server"></asp:Label> - <strong>Fax</strong> :<asp:Label ID="lbl_fax" runat="server"></asp:Label></p>

</div>
<div style="clear:both;"></div>
</div>
      <asp:HiddenField ID="hid_divsname" runat="server"  Value="N" />
        <asp:Label ID="lblcmpnyname" Text="FORWARDING PRIVATE LIMITED" runat="server"></asp:Label>
      
          </form>
    
</body>--%>
    <body style="font-family:sans-serif;">
  
<%--<div style="float:left; width:100px; margin:5px auto;"> <img src="../images/MR.png" width="150px" height="auto"  /></div>
<div style="width:877px; float:left;">
<h3 style="text-align:center; padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; font-size:24px; font-weight:bold; "><asp:Label ID="lbl_branch" runat="server"></asp:Label></h3>
<p style="font-weight:normal; padding:5px 0px 0px 0px; margin:0px 0px 0px 0px; text-align:center;"><asp:Label ID="lbl_address" runat="server"></asp:Label></p>
<p  style="font-weight:normal; padding:0px 0px 5px 0px; margin:0px 0px 0px 0px; text-align:center;"><strong>Tel</strong> : <asp:Label ID="lbl_ph" runat="server"></asp:Label> - <strong>Fax</strong> :<asp:Label ID="lbl_fax" runat="server"></asp:Label></p>

</div>--%>
<div style="clear:both;"></div>
<%--</div>--%>
          <form runat="server">
    <asp:Label ID="tdRow_CanDtls" runat="server"></asp:Label>
        <asp:HiddenField ID="hid_divsname" runat="server"  Value="N" />
              <asp:Label ID="lbl_branch" runat="server"></asp:Label>
        <asp:Label ID="lblcmpnyname" runat="server"></asp:Label>
              <asp:Label ID="lbl_address" runat="server"></asp:Label>
              <asp:Label ID="lbl_ph" runat="server"></asp:Label> 
              <asp:Label ID="lbl_fax" runat="server"></asp:Label>
               </form>
</body>
</html>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>CONTAINER MOVEMENT FACILITATION CELL</title>
</head>

<body style="font-family:sans-serif, Geneva, sans-serif; font-size:16px; line-height:24px;">
<div style="margin:0px auto; width:1024px;">
<div style="width:1024px; float:left;">

<h1 style="padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; text-align:center; font-size:21px;">CONTAINER MOVEMENT FACILITATION CELL</h1>
<h2 style="padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; text-align:center; font-size:21px;">NOTE</h2>
<p style="padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; text-align:center; font-size:21px;">Sub : Movement of LCL cargo by Road-Reg</p>
</div>
<div style="margin:0px 0px 0px 0px; width:1024px; float:left;">

<div style="float:left; width:492px; padding:5px; margin:0px;">TSA No. & date</div>
<div style="float:left; width:1px; padding:5px; margin:0px;">:</div>
<div style="float:left; width:492px; padding:5px; margin:0px;"><asp:Label ID="lbl_tsa" runat="server" ></asp:Label></div>
<div style="clear:both;"></div>
<div style="float:left; width:492px; padding:5px; margin:0px;">IGM No & Line No. / Subline No.</div>
<div style="float:left; width:1px; padding:5px; margin:0px;">:</div>
<div style="float:left; width:492px; padding:5px; margin:0px;"><asp:Label ID="lbl_igm" runat="server" ></asp:Label></div>

<div style="clear:both;"></div>
<div style="float:left; width:492px; padding:5px; margin:0px;">Vessel / Voy</div>
<div style="float:left; width:1px; padding:5px; margin:0px;">:</div>
<div style="float:left; width:492px; padding:5px; margin:0px;"><asp:Label ID="lbl_vsvoy" runat="server" ></asp:Label></div>

<div style="clear:both;"></div>
<div style="float:left; width:492px; padding:5px; margin:0px;">Streamer Agent</div>
<div style="float:left; width:1px; padding:5px; margin:0px;">:</div>
<div style="float:left; width:492px; padding:5px; margin:0px;"><asp:Label ID="lbl_agent" runat="server" ></asp:Label></div>

<div style="clear:both;"></div>
<div style="float:left; width:492px; padding:5px; margin:0px;">Master MB/L No & Date</div>
<div style="float:left; width:1px; padding:5px; margin:0px;">:</div>
<div style="float:left; width:492px; padding:5px; margin:0px;"><asp:Label ID="lbl_mbl" runat="server" ></asp:Label></div>

<div style="clear:both;"></div>
<div style="float:left; width:492px; padding:5px; margin:0px;">House B/L No & Date</div>
<div style="float:left; width:1px; padding:5px; margin:0px;">:</div>
<div style="float:left; width:492px; padding:5px; margin:0px;"><asp:Label ID="lbl_bl" runat="server" ></asp:Label></div>

<div style="clear:both;"></div>
<div style="float:left; width:492px; padding:5px; margin:0px;">Place of Delivery</div>
<div style="float:left; width:1px; padding:5px; margin:0px;">:</div>
<div style="float:left; width:492px; padding:5px; margin:0px;"><asp:Label ID="lbl_pod" runat="server" ></asp:Label></div>

<div style="clear:both;"></div>
<div style="float:left; width:492px; padding:5px; margin:0px;">No.of Packages</div>
<div style="float:left; width:1px; padding:5px; margin:0px;">:</div>
<div style="float:left; width:492px; padding:5px; margin:0px;"><asp:Label ID="lbl_pkg" runat="server" ></asp:Label></div>

<div style="clear:both;"></div>
<div style="float:left; width:492px; padding:5px; margin:0px;">Gross Weight</div>
<div style="float:left; width:1px; padding:5px; margin:0px;">:</div>
<div style="float:left; width:492px; padding:5px; margin:0px;"><asp:Label ID="lbl_grwt" runat="server" ></asp:Label></div>

<div style="clear:both;"></div>
<div style="float:left; width:492px; padding:5px; margin:0px;">Value + Duty amount(INR)</div>
<div style="float:left; width:1px; padding:5px; margin:0px;">:</div>
<div style="float:left; width:492px; padding:5px; margin:0px;"><asp:Label ID="lbl_amt" runat="server" ></asp:Label></div>

<div style="clear:both;"></div>
<div style="float:left; width:492px; padding:5px; margin:0px;">Description of Cargo</div>
<div style="float:left; width:1px; padding:5px; margin:0px;">:</div>
<div style="float:left; width:492px; padding:5px; margin:0px;"><asp:Label ID="lbl_descn" runat="server" ></asp:Label></div>

<div style="clear:both;"></div>
<div style="float:left; width:492px; padding:5px; margin:0px;">Name & Address of Consignee</div>
<div style="float:left; width:1px; padding:5px; margin:0px;">:</div>
<div style="float:left; width:492px; padding:5px; margin:0px; white-space:pre-line;"><asp:Label ID="lbl_caddre" runat="server" ></asp:Label></div>


<div style="clear:both;"></div>
<div style="float:left; width:492px; padding:5px; margin:0px;">Mode of Transport</div>
<div style="float:left; width:1px; padding:5px; margin:0px;">:</div>
<div style="float:left; width:492px; padding:5px; margin:0px; white-space:pre-line;">BY ROAD</div>

<div style="clear:both;"></div>
<div style="float:left; width:492px; padding:5px; margin:0px;">From</div>
<div style="float:left; width:1px; padding:5px; margin:0px;">:</div>
<div style="float:left; width:492px; padding:5px; margin:0px; white-space:pre-line;"><asp:Label ID="lbl_from" runat="server" ></asp:Label></div>

<div style="clear:both;"></div>
<div style="float:left; width:492px; padding:5px; margin:0px;">To</div>
<div style="float:left; width:1px; padding:5px; margin:0px;">:</div>
<div style="float:left; width:492px; padding:5px; margin:0px; white-space:pre-line;"><asp:Label ID="lbl_to" runat="server" ></asp:Label></div>
</div>

<div style="width:1024px; float:left;">
<p style="padding:5px; margin:0px 0px 0px 0px;">
The transshipment aplication has been filled by the Consol / Steamer Agent viz: <asp:Label ID="lbl_div" runat="server" ></asp:Label> for the movement of above mentioned LCL Cargo From
<asp:Label ID="lbl_fromcust" runat="server" ></asp:Label> to <asp:Label ID="lbl_toport" runat="server" ></asp:Label> ICD by Road. Goods
are currently lying at <asp:Label ID="lbl_custname" runat="server" ></asp:Label> CFS-Chennai who
has executed running bond for Rs. 150 crores .
</p>
<p style="padding:5px; margin:0px 0px 0px 0px;">
The Agents have submitted letter from CFS in Original requesting transfer of goods and also submitted
photo copies of sub manifested B.L.,Invoice and Packing List along with Cargo declaration form.
</p>
<p style="padding:5px; margin:0px 0px 0px 0px;">
TSA fee of Rs.20/- collected vide Challan No:  <asp:Label ID="lbl_chno" runat="server" ></asp:Label> dated: <asp:Label ID="lbl_chdate" runat="server" ></asp:Label> Neccessary debiting has also
been done from the Bond executed by the CFS to cover the safety & security of Cargo during transit.
</p>

<p style="padding:5px; margin:0px 0px 0px 0px;">
Request of the Consol / Streamer Agent may be considered and transshipment may be permitted
please.
</p>

<p style="padding:5px; margin:0px 0px 0px 0px; font-size:18px; font-weight:bold; text-align:right;">
Supdt.(CMFC)
</p>
</div>
</div>

</body>
</html>--%>
