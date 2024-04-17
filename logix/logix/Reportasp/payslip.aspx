<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payslip.aspx.cs" Inherits="logix.Reportasp.payslip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HRPaySlip</title>
</head>
<body style="padding:0px; margin:0px; background-color:#fff; font-family:sans-serif, Geneva, sans-serif; font-size:14px; color:#2c2b2b;">
<div style="width:100%; margin:auto;">
    <form id="form1" runat="server" style="width:100%;height:100%;">
  <div style="width:745px; margin:auto;" id="div1" runat="server"  >
    <table width= "100%" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #000000; background-color:#878788;">
      <tr>
        <td><div style="float:left; width:103px; border-right:1px solid #000000; min-height:147px; padding:5px 0px 5px 0px; text-align:center; background-color:#878788;">
            <asp:Image ID="lbl_img" runat="server" />  <%-- ImageUrl="../images/mr_Logo.jpg"--%>
            </div>
        <div style="float:left; width:527px; background-color:#878788;">
          <div style="float:left; width:527px; min-height:30px; border-bottom:1px solid #000;">
             
              <div style="float:left; width:90%; margin:0px 0px 0px 5px; color:#ffffff;">
           <asp:Label ID="lbl_title" runat="server"></asp:Label>
                  </div>
              <div style="float:left; width:35%; margin:4px 0px 0px 0px;">
          <p style="margin:0px 4px 4px 5px; color:#ffffff;">Salary slip for the month of</p></div>
              <div style="float:left; width:25%; margin:4px 0px 0px 0px;">
                  <p style="margin:0px 4px 0px 0px; color:#ffffff;">
              <asp:Label ID="lbl_month" runat="server"></asp:Label> 
                      </p>
                  </div>
          
          </div>
          <div style="clear:both;"></div>
          <div style="float:left; width:263px; margin:0px 0px 0px 0px;">
          <div style="float:left; width:100px; margin:0px 5px 2px 5px; color:#ffffff;">Name</div>
        <div style="float:left; width:150px; margin:0px 0px 2px 0px; color:#ffffff;"><asp:Label ID="lbl_name" runat="server"></asp:Label></div>
        <div style="clear:both;"></div>
        <div style="float:left; width:100px;  margin:0px 0px 2px 5px; color:#ffffff;">Emp #</div>
        <div style="float:left; width:150px; margin:0px 0px 2px 0px; color:#ffffff;"><asp:Label ID="lbl_emp" runat="server"></asp:Label></div>
        <div style="float:left; width:100px;  margin:0px 0px 2px 5px; color:#ffffff;">Grade</div>
        <div style="float:left; width:50px; margin:0px 0px 2px 5px; color:#ffffff;"><asp:Label ID="lbl_grade" runat="server"></asp:Label></div>
        <div style="clear:both;"></div>
        <div style="float:left; width:100px; margin:0px 0px 2px 5px; color:#ffffff;">Designation</div>
        <div style="float:left; width:150px; margin:0px 0px 2px 0px; color:#ffffff;"><asp:Label ID="lbl_desgination" runat="server"></asp:Label></div>
         <div style="clear:both;"></div>
        <div style="float:left; width:100px; margin:0px 0px 2px 5px; color:#ffffff;">DOJ</div>
        <div style="float:left; width:150px; margin:0px 0px 2px 0px; color:#ffffff;"><asp:Label ID="lbl_doj" runat="server"></asp:Label></div>
           <div style="clear:both;"></div>
        <div style="float:left; width:100px; margin:0px 0px 2px 5px; color:#ffffff;">PAN #</div>
        <div style="float:left; width:150px; margin:0px 0px 2px 0px; color:#ffffff;"><asp:Label ID="lbl_pan" runat="server"></asp:Label></div>
          </div>
          <div style="float:left; width:252px; margin:0px 0px 0px 0px;">
          <div style="float:left; width:100px; margin:0px 0px 2px 5px; color:#ffffff;">Location</div>
           <div style="float:left; width:150px; margin:0px 0px 2px -9px; color:#ffffff;"><asp:Label ID="lbl_location" runat="server"></asp:Label></div>
        <div style="clear:both;"></div>
        <div style="float:left; width:100px; margin:0px 0px 2px 5px; color:#ffffff;">Department</div>
        <div style="float:left; width:150px; margin:0px 0px 2px -10px; color:#ffffff;"><asp:Label ID="lbl_department" runat="server"></asp:Label></div>
        <div style="clear:both;"></div>
        <div style="float:left; width:100px; margin:0px 0px 2px 3px; color:#ffffff;">Bank Name</div>
        <div style="float:left; width:150px; margin:0px 0px 2px -5px; color:#ffffff;"><asp:Label ID="lbl_bankname" runat="server"></asp:Label></div>
         <div style="clear:both;"></div>
        <div style="float:left; width:100px; margin:0px 0px 2px 5px; color:#ffffff;">Bank A/C #</div>
        <div style="float:left; width:150px; margin:0px 0px 2px -8px; color:#ffffff;"><asp:Label ID="lbl_bankAC" runat="server"></asp:Label></div>
          </div>
          </div>
          
            <div style="float:left; width:98px; border-left:1px solid #000000; min-height:147px; padding:5px 0px 5px 5px; color:#ffffff; background-color:#878788;">
              <asp:Image ID="img_emp" runat="server" Height="100%" Width="100%"  ImageUrl="~/images/CImage.png"  />
          </div>
          
           <%-- style ="background-size:cover;" CssClass="round-box" data-toggle="dropdown"--%>
          
          </td>
      </tr>
      <tr>
        <td><div style="float:left; width:372px; border-top:1px solid #000000; border-right:1px solid #000000; min-height:26px;">
<p style="text-align:center; width:100%; color:#ffffff;">Earnings</p>
        </div>
          <div style="float:left; width:370px; border-top:1px solid #000000; border-right:0px solid #000000; min-height:26px;">
<p style="text-align:center; width:100%; color:#ffffff;">Deductions</p>
        </div>
          <div style="clear:both;"></div>
          <div style="float:left; width:372px; min-height:24px; border-top:1px solid #000000; 
     border-right:1px solid #000000;">
            <div style="float:left; width:225px; border-right:1px solid #000000; min-height:137px;">
            <div style="float:left; width:160px; margin:2px 0px 2px 8px; color:#ffffff;">Basic</div>
            <div style="clear:both;"></div>
             <div style="float:left; width:160px;  margin:2px 0px 2px 8px; color:#ffffff;">HRA</div>
            <div style="clear:both;"></div>
             <div style="float:left; width:160px;  margin:2px 0px 2px 8px; color:#ffffff;">Conveyance</div>
            <div style="clear:both;"></div>
             <div style="float:left; width:160px;  margin:2px 0px 2px 8px; color:#ffffff;">Special Allowances</div>
            <div style="clear:both;"></div>
                  <div style="float:left; width:160px;  margin:2px 0px 2px 8px; color:#ffffff;">Others</div>
            <div style="clear:both;"></div>
              <div style="float:left; width:160px;  margin:2px 0px 2px 8px; color:#ffffff;">Basic Arrears</div>
            <div style="clear:both;"></div>
                  <div style="float:left; width:160px;  margin:2px 0px 2px 8px; color:#ffffff;">Other Arrears</div>
            <div style="clear:both;"></div>
             <div style="float:left; width:160px;  margin:2px 0px 2px 8px; color:#ffffff;">Medical</div>
            <div style="clear:both;"></div>
            </div>
            <div style="float:left; width:140px; border-right:0px solid #000000; min-height:21px; color:#ffffff; margin:0px 0px 0px 5px;"><asp:Label ID="lbl_basic" runat="server"></asp:Label></div>
            <%--  <div style="clear:both;"></div>--%>
               <div style="float:left; width:140px; border-right:0px solid #000000; min-height:21px; color:#ffffff; margin:0px 0px 0px 5px;"><asp:Label ID="lbl_hra" runat="server"></asp:Label></div>
             <%-- <div style="clear:both;"></div>--%>
               <div style="float:left; width:140px; border-right:0px solid #000000; min-height:21px; color:#ffffff; margin:0px 0px 0px 5px;"><asp:Label ID="lbl_conveyance" runat="server"></asp:Label></div>
               <div style="float:left; width:140px; border-right:0px solid #000000; min-height:21px; color:#ffffff; margin:0px 0px 0px 5px;"><asp:Label ID="lbl_S_Allowances" runat="server"></asp:Label></div>
               <div style="float:left; width:140px; border-right:0px solid #000000; min-height:21px; color:#ffffff; margin:0px 0px 0px 5px;"><asp:Label ID="lbl_other" runat="server"></asp:Label></div>
              <div style="float:left; width:140px; border-right:0px solid #000000; min-height:21px; color:#ffffff; margin:0px 0px 0px 5px;"><asp:Label ID="lbl_basicarrear" runat="server"></asp:Label></div>
              <div style="float:left; width:140px; border-right:0px solid #000000; min-height:21px; color:#ffffff; margin:0px 0px 0px 5px;"><asp:Label ID="lbl_OtherArrears" runat="server"></asp:Label></div>
               <div style="float:left; width:140px; border-right:0px solid #000000; min-height:21px; color:#ffffff; margin:0px 0px 0px 5px;"><asp:Label ID="lbl_Medical" runat="server"></asp:Label></div>
             
          </div>
          <div style="float:left; width:370px; min-height:24px; border-top:1px solid #000000; 
    border-bottom:1px solid #000000; padding-bottom:0px;">
            <div style="float:left; width:222px; border-right:1px solid #000000; min-height:167px;">
            
              <div style="float:left; width:50px;  margin:2px 0px 2px 5px; color:#ffffff;">PF</div>
           
            <div style="clear:both;"></div>
            <div style="float:left; width:50px;  margin:2px 0px 2px 5px; color:#ffffff;">ESI</div> 
           
            <div style="clear:both;"></div>
             <div style="float:left; width:50px;  margin:2px 0px 2px 5px; color:#ffffff;">IT</div>
            
            
            <div style="clear:both;"></div>
              <div style="float:left; width:100px;  margin:2px 0px 2px 5px; color:#ffffff;">Professional Tax</div>
           
            <div style="clear:both;"></div>
             <div style="float:left; width:50px;  margin:2px 0px 2px 5px; color:#ffffff;">LWF</div>
           
            <div style="clear:both;"></div>
            <div style="float:left; width:50px;  margin:2px 0px 2px 5px; color:#ffffff;">Loan</div>
           
            <div style="clear:both;"></div>
            <div style="float:left; width:50px;  margin:2px 0px 2px 5px; color:#ffffff;">Others</div>
           
            </div>
            <div style="float:left; width:144px;  min-height:137px;">
                 <div style="float:left; width:150px; margin:2px 0px 2px 5px; color:#ffffff;"><asp:Label ID="lbl_PF" runat="server"></asp:Label></div>
                 <div style="float:left; width:150px; margin:2px 0px 2px 5px; color:#ffffff;"><asp:Label ID="lbl_esi" runat="server"></asp:Label> </div>
                <div style="float:left; width:150px; margin:2px 0px 2px 5px; color:#ffffff;"><asp:Label ID="lbl_it" runat="server"></asp:Label> </div>
                 <div style="float:left; width:150px; margin:2px 0px 2px 5px; color:#ffffff;"><asp:Label ID="lbl_professional" runat="server"></asp:Label> </div>
                 <div style="float:left; width:150px; margin:2px 0px 2px 5px; color:#ffffff;"><asp:Label ID="lbl_lwf" runat="server"></asp:Label> </div>
                 <div style="float:left; width:150px;margin:2px 0px 2px 5px; color:#ffffff;"><asp:Label ID="lbl_loan" runat="server"></asp:Label> </div>
                 <div style="float:left; width:150px;margin:2px 0px 2px 5px; color:#ffffff;"><asp:Label ID="lbl_othering" runat="server"></asp:Label> </div>

            </div>
          </div>
          <div style="float:left; width:372px; border-top:1px solid #000000; border-right:1px solid #000000; min-height:26px;">
          <div style="float:left; width:100%; margin:5px 5px 5px 10px; color:#ffffff;">Total Earnings</div>
           <div style="float:left; width:150px;margin:-21px 0px 0px 231px; color:#ffffff;"><asp:Label ID="lbl_total_earing" runat="server"></asp:Label> </div>
          </div>
          <div style="float:left; width:370px;  min-height:26px;  ">
           <div style="float:left; width:100%; margin:5px 5px 5px 10px; color:#ffffff;">Total Deductions</div>
            <div style="float:left; width:150px; margin:-22px 0px 0px 233px; color:#ffffff;"><asp:Label ID="lbl_totaldeduction" runat="server"></asp:Label> </div>
          </div></td>
      </tr>
      <tr>
        <td><div style="width:743px; float:left; min-height:26px; border-top:1px solid #000;">
        <div style="float:left; width:150px; margin:5px 5px 5px 10px; color:#ffffff;">Net Salary     </div>
            <div style="float:left; width:150px; margin:6px 0px 0px 65px; color:#ffffff;"><asp:Label ID="lbl_netsalary" runat="server"></asp:Label> </div>
        </div></td>
      </tr>
      <tr>
        <td><div style="width:741px; float:left; min-height:26px; border-bottom:1px solid #000;">
        <div style="float:left; width:150px; margin:5px 5px 5px 10px; color:#ffffff;">No. Of Working Days</div>
               <div style="float:left; width:150px;margin:0px 0px 0px 65px; color:#ffffff;"><asp:Label ID="lbl_noofworkingday" runat="server"></asp:Label> </div>
        </div></td>
      </tr>
      <tr>
        <td>
        <div style="width:741px; float:left; min-height:26px;  border-bottom:1px solid #000;">
        <div style="float:left; width:150px; margin:5px 5px 5px 10px; color:#ffffff;">LOP Days</div>
        <div style="float:left; width:70px; margin:5px 5px 5px 65px; color:#ffffff;"><asp:Label ID="lbl_lopdays" runat="server"></asp:Label></div>
        
        </div></td>
      </tr>
      <tr>
        <td><div style="width:741px; float:left;  min-height:26px;">
        <div style="float:left; width:450px; margin:5px 5px 5px 10px; color:#ffffff;">Computer generated Pay Slip, Signature not required</div>
        
        </div></td>
      </tr>
    </table>
    <div style="clear:both;"></div>
  </div>
     </form>
</div>
   
</body>
</html>
