<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptFIAnnx1.aspx.cs" Inherits="logix.Reportasp.rptFIAnnx1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Annexure 1</title>
<style type="text/css">
.TableHeader thead {display: table-header-group;}

</style>
</head>
	


<body style="font-family:sans-serif, Geneva, sans-serif; font-size:15px; line-height:18px;">
<div style="width:1024px; margin:0px auto;">

    <div style="width:1024px; margin:0px; padding:0px; border-bottom:1px solid #000;">
<div style="float:left; width:100px; margin:5px 0px 5px 25px;"> <asp:Image   ID="lbl_img" runat="server"  width="150px"  /></div>
<div style="width:877px; float:left;">
<h3 style="text-align:center; padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; font-size:24px; font-weight:bold; "><asp:Label ID="lbl_branch" runat="server"></asp:Label></h3>
<p style="font-weight:normal; padding:5px 0px 0px 0px; margin:0px 0px 0px 0px; text-align:center;"><asp:Label ID="lbl_address" runat="server"></asp:Label></p>
<p  style="font-weight:normal; padding:0px 0px 5px 0px; margin:0px 0px 0px 0px; text-align:center;"><strong>Tel</strong> : <asp:Label ID="lbl_ph" runat="server"></asp:Label> - <strong>Fax</strong> :<asp:Label ID="lbl_fax" runat="server"></asp:Label></p>

</div>
<div style="clear:both;"></div>
</div>

<div style="width:1024px; margin:0px; padding:0px;">
<table width="1024" border="0" cellspacing="0" cellpadding="0" class="TableHeader">
<thead>
<tr><th colspan="18"><div style="width:1024px; margin:0px; padding:10px 0px 5px 0px;">
<p style=" text-align:center; padding:0px; margin:0px;">ANNEXURE -1<br />

DECLARATION FOR FILING IMPORT GENERAL MANIFEST<br />

PART-III :CONTAINER DECLARATION<br />
(Details of Container if any relating to the Bill of Lading/House Bill of Lading )</p>
</div></th></tr>

 <tr>
    <th colspan="18"><div style="width:1024px; float:left;">
    	<div style=" text-align:center; padding:0px; margin:20px;">Indicate Whether Prior IGM or Final IGM : (final)</div>
    	
    </div>
    </th></tr>

    <tr>
    <th style="width: 90px; border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000;  padding:2px; margin:0px;">LINE NO</th>
    <th style="width: 110px; border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px;">SUB LINE NO</th>
    <th style="width: 125px; border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px;">CONTAINER NO</th>
    <th style="width: 106px; border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:8px; margin:0px;">CONTAINER SEAL NO</th>
    <th style="width: 80px; border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px;">ISO CODE</th>
    <th style="width: 117px; border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:7px; margin:0px;">CONTAINER AGENT CODE</th>
    <th style="width: 95px; border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px;">CONTAINER STATUS</th>
    <th style="width: 81px; border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:8px; margin:0px;">TOTAL NO OF PKGS</th>
    <th style="width: 115px; border-top:1px solid #000; border-left:1px solid #000; border-right: 1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px;">CONTAINER WEIGHT</th>

  </tr>
  </thead>

      <asp:Label ID="tdRow_CanDtls" runat="server"></asp:Label>

 <%--<tbody>

<tr>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">610</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">1
    </td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOCU7443980</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOLFUE5131</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">4400</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">AAACO5679E</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">LCL/LCL</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;text-align: right;">1</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;border-right: 1px solid #000;text-align: right; ">154.77</td>
	</tr>
<tr>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">610</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">1</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOCU7443980</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOLFUE5131</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">4400</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">AAACO5679E</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">LCL/LCL</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;text-align: right;">1</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;border-right: 1px solid #000;text-align: right; ">154.77</td>
	</tr>



<tr>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">610</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">1
    </td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOCU7443980</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOLFUE5131</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">4400</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">AAACO5679E</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">LCL/LCL</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;text-align: right;">1</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;border-right: 1px solid #000;text-align: right; ">154.77</td>
	</tr>

 

<tr>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">610</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">1
    </td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOCU7443980</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOLFUE5131</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">4400</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">AAACO5679E</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">LCL/LCL</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;text-align: right;">1</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;border-right: 1px solid #000;text-align: right; ">154.77</td>
	</tr>
<tr>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">610</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">1
    </td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOCU7443980</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOLFUE5131</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">4400</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">AAACO5679E</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">LCL/LCL</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;text-align: right;">1</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;border-right: 1px solid #000; text-align: right;">154.77</td>
	</tr>
<tr>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">610</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">1
    </td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOCU7443980</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOLFUE5131</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">4400</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">AAACO5679E</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">LCL/LCL</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;text-align: right;">1</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;border-right: 1px solid #000; text-align: right;">154.77</td>
	</tr>
<tr>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">610</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">1
    </td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOCU7443980</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOLFUE5131</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">4400</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">AAACO5679E</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">LCL/LCL</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;text-align: right;">1</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;border-right: 1px solid #000; text-align: right; ">154.77</td>
	</tr>
<tr>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">610</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">1
    </td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOCU7443980</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOLFUE5131</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">4400</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">AAACO5679E</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">LCL/LCL</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;text-align: right;">1</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;border-right: 1px solid #000;text-align: right; ">154.77</td>
	</tr>
<tr>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">610</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">1
    </td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOCU7443980</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOLFUE5131</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">4400</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">AAACO5679E</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">LCL/LCL</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;text-align: right;">1</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;border-right: 1px solid #000; text-align: right;">154.77</td>
	</tr>
<tr>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">610</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">1
    </td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOCU7443980</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOLFUE5131</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">4400</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">AAACO5679E</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">LCL/LCL</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;text-align: right;">1</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;border-right: 1px solid #000;text-align: right; ">154.77</td>
	</tr>
<tr>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">610</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">1
    </td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOCU7443980</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">OOLFUE5131</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">4400</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">AAACO5679E</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;">LCL/LCL</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;text-align: right;">1</td>
    <td  style="border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;border-right: 1px solid #000; text-align: right;">154.77</td>
	</tr>
 <tr>
    <td  style="border-left:1px solid #000; border-bottom:1px solid #000; padding:5px; margin:0px; vertical-align:top;">610</td>
    <td  style="border-left:1px solid #000; border-bottom:1px solid #000; padding:5px; margin:0px; vertical-align:top;">1</td>
    <td  style="border-left:1px solid #000; border-bottom:1px solid #000; padding:5px; margin:0px; vertical-align:top;">OOCU7443980</td>
    <td  style="border-left:1px solid #000; border-bottom:1px solid #000; padding:5px; margin:0px; vertical-align:top;">OOLFUE5131</td>
    <td  style="border-left:1px solid #000; border-bottom:1px solid #000; padding:5px; margin:0px; vertical-align:top;">4400</td>
    <td  style="border-left:1px solid #000; border-bottom:1px solid #000; padding:5px; margin:0px; vertical-align:top;">AAACO5679E</td>
    <td  style="border-left:1px solid #000; border-bottom:1px solid #000; padding:5px; margin:0px; vertical-align:top;">LCL/LCL</td>
    <td  style="border-left:1px solid #000; border-bottom:1px solid #000; padding:5px; margin:0px; vertical-align:top;text-align: right;">1</td>
    <td  style="border-left:1px solid #000; border-bottom:1px solid #000; padding:5px; margin:0px; vertical-align:top;border-right: 1px solid #000;text-align: right; ">154.77</td>

</tbody>--%>

</table>
<div style="width:1024px; float: left; margin: 35px 0px 10px 0px; padding:0px;">

	<div style="width:420px; float: left;">
		
		<div style="width:510px; float:left; padding:5px 5px 5px 5px; font-weight:bold;">I/We declare that the particular given here in are true and correct</div>
		<div style="clear:both;"></div>
		<div style="width:35px; float:left; padding:5px 5px 5px 5px; font-weight:bold;">PLACE
		</div>
		<div style="width:1px; float:left; padding:5px 5px 5px 5px; font-weight:bold;">:</div>
		<div style="width:85px; float:left; padding:5px 5px 5px 5px; font-weight:bold;">CHENNAI</div>
		<div style="clear:both;"></div>
		<div style="width:35px; float:left; padding:5px 5px 5px 5px; font-weight:bold;">DATE
		</div>
		<div style="width:1px; float:left; padding:5px 5px 5px 5px; font-weight:bold;"> :
		</div>
		<div style="width:85px; float:left; padding:5px 5px 5px 5px; font-weight:bold;"><asp:Label ID="lbl_date" runat="server"></asp:Label></div>

	</div>

	<div style="width:350px;margin: 35px 0px 0px 0px;float: right;">

		<div style="width:65px; float:left; padding:5px 5px 5px 5px; font-weight:bold;">Signature
		</div>	
		<div style="clear:both;"></div>
		<div style="width:182px; float:left; padding:5px 5px 5px 5px; font-weight:bold;">Name of the Signatory
		</div>
		<div style="clear:both;"></div>
		<div style="width:345px; float:left; padding:5px 5px 5px 5px; font-weight:bold;">Name of the Steamer Agent / Shipping Line
		</div>
		<div style="clear:both;"></div>
		<div style="width:315px; float:left; padding:5px 5px 5px 5px; font-weight:bold;">Steamer Agent / Shipping Line Code :PLS
		</div>

	</div>
	
</div>

</div>

</div>
</body>




</html>
