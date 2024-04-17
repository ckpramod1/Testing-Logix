<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BL4CANrpt.aspx.cs" Inherits="logix.Reportasp.BL4CANrpt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>CAN</title>
    <style type="text/css">
        span#lbl_TO {
            display: inline-block;
            white-space: pre-line;
        }
    </style>
</head>

<body style="font-size: 14px; font-family: sans-serif, Geneva, sans-serif; line-height: 18px; color: #000;">

    <div style="width: 1024px; margin: 0px auto; border-top: 0px solid #000;">
        <div style="float: left; width: 132px; margin: 5px 5px 5px 5px;">
            <asp:Image ID="img_Logo" runat="server" width="132"  />
        </div>

        <div style="width: 845px; float: left;">
            <h3 style="text-align: center; padding: 10px 0px 10px 0px; margin: 0px 0px 0px 0px; font-size: 24px; font-weight: bold;">
                <asp:Label ID="lbl_branch" runat="server"></asp:Label></h3>
            <p style="font-weight: normal; padding: 5px 0px 0px 0px; margin: 0px 0px 0px 0px; text-align: center;">
                <asp:Label ID="lbl_addre" runat="server"></asp:Label><br />
                <asp:Label ID="lblphfax" runat="server"></asp:Label>
            </p>
            <p style="font-weight: normal; padding: 0px 0px 5px 0px; margin: 0px 0px 0px 0px; text-align: center;">
                <asp:Label ID="lbltaxpan" runat="server"></asp:Label>
            </p>

        </div>
    </div>
    <div style="clear: both;"></div>
    <div style="width: 1024px; margin: 0px auto; border: 1px solid #000; min-height: 1200px;">
        <div style="width: 1024px; text-align: center; padding: 12px 0px 12px 0px; margin: 0px 0px 0px 0px; font-size: 18px; font-weight: bold; border-bottom: 1px solid #000;">
            CARGO ARRIVAL  NOTICE
        </div>

        <div style="width: 600px; float: left; margin: 0px 0px 0px 0px; border-bottom: 1px solid #000; min-height: 145px;">
            <p style="padding: 5px 0px 5px 15px; margin: 0px 0px 0px 0px; font-weight: bold;">To</p>
            <p style="padding: 5px 0px 5px 5px; margin: 0px 168px 0px 10px;">
                <asp:Label ID="lbl_TO" runat="server"></asp:Label>
            </p>
        </div>

        <div style="width: 423px; float: left; margin: 0px 0px 0px 0px; min-height: 145px; border-bottom: 1px solid #000;">
            <div style="float: right; width: 100px; padding: 5px; margin: 0px 0px 5px 0px;">
                <asp:Label ID="lbl_candt" runat="server"></asp:Label>
            </div>
            <div style="float: right;  padding: 5px; margin: 0px 0px 5px 0px;">:</div>
             <div style="float: right; width: 6%; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px; font-weight: bold;">Date</div>
            
            <div style="width: 420px; float: left;" id="lblYourBl" runat="server" visible="false">

                <div style="float: left; width: 120px; padding: 5px 5px 5px 15px; margin: 0px 0px 0px 0px; font-weight: bold;">Your BL # </div>
                <div style="float: left; width: 1px; padding: 5px 5px 5px; margin: 0px 15px 0px 0px;">:</div>
                <div style="float: left; width: 240px; padding: 5px 5px 5px; margin: 0px 0px 0px 0px;">
                    <asp:Label ID="lblYourblno" runat="server"></asp:Label>
                </div>
            </div>



        </div>
        <div style="clear: both;"></div>
        <div style="width: 510px; float: left; margin: 0px 0px 0px 0px; min-height: 135px;">
             
        <div style="float: left; width: 20%; font-weight: bold; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px;">HBL # & Date</div>
            <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;">:</div>
            <div style="float: left; width: 245px; padding: 5px; margin: 0px 0px 5px 0px;">
                <asp:Label ID="lbl_hblanddate" runat="server"></asp:Label>
            </div>

             <div style="float: left; width: 20%; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px; font-weight: bold;">Line # </div>
            <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;">:</div>
            <div style="float: left; width: 240px; padding: 5px; margin: 0px 0px 5px 0px;">
                <asp:Label ID="lbl_line" runat="server"></asp:Label>
            </div>   

            <div style="float: left; width: 20%; font-weight: bold; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px;">PoR & PoL</div>
            <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;">:</div>
            <div style="float: left; width: 241px; padding: 5px; margin: 0px 0px 5px 0px;">
                <asp:Label ID="lblporpol" runat="server"></asp:Label>
            </div>

               <div style="float: left; width: 20%; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px; font-weight: bold;">FD </div>
            <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;">:</div>
            <div style="float: left; width: 240px; padding: 5px; margin: 0px 0px 5px 0px;">
                <asp:Label ID="lbl_fd" runat="server"></asp:Label>
            </div>

              <div style="float: left; width: 20%; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px; font-weight: bold;">Packages</div>
            <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;">:</div>
            <div style="float: left; width: 240px; padding: 5px; margin: 0px 0px 5px 0px;">
                <asp:Label ID="lbl_pkgs" runat="server"></asp:Label>
            </div>
                
            
            <div style="float: left; width: 20%; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px; font-weight: bold;">Gr . Wt </div>
            <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;">:</div>
            <div style="float: left; width: 240px; padding: 5px; margin: 0px 0px 5px 0px;">
                <asp:Label ID="lbl_grwt" runat="server"></asp:Label>
            </div>
                

            <div style="float: left; width: 20%; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px; font-weight: bold;">M3 </div>
            <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;">:</div>
            <div style="float: left; width: 240px; padding: 5px; margin: 0px 0px 5px 0px;">
                <asp:Label ID="lbl_m3" runat="server"></asp:Label>
            </div>
             
            <div style="float: left; width: 20%; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px; font-weight: bold;">Status  </div>
            <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;">:</div>
            <div style="float: left; width: 240px; padding: 5px; margin: 0px 0px 5px 0px;">
                <asp:Label ID="lbl_status" runat="server"></asp:Label>
            </div>
              

            <div style="float: left; width: 20%; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px; font-weight: bold;">Freight   </div>
            <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;">:</div>
            <div style="float: left; width: 240px; padding: 5px; margin: 0px 0px 5px 0px;">
                <asp:Label ID="lbl_freight" runat="server"></asp:Label>
            </div>
           

            <div style="float: left; width: 20%; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px; font-weight: bold;">Marks     </div>
            <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;">:</div>
            <div style="float: left; width: 240px; padding: 5px; margin: 0px 0px 5px 0px;">
                <asp:Label ID="lbl_marks" runat="server"></asp:Label>
            </div>
            
            <div style="float: left; width: 20%; font-weight: bold; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px;">Description</div>
            <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;">:</div>
            <div style="float: left; width: 260px; padding: 5px; margin: 0px 0px 5px 0px;">
                <asp:Label ID="lbl_descn" runat="server"></asp:Label>
            </div>
        </div>
        <div style="width: 514px; float: left; margin: 0px 0px 0px 0px; min-height: 135px;">
           
            <div style="float: left; width: 22%; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px; font-weight: bold;">Job # </div>
            <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;">:</div>
            <div style="float: left; width: 290px; padding: 5px; margin: 0px 0px 5px 0px;">
                <asp:Label ID="lbl_jobno" runat="server"></asp:Label>
            </div>
              

            <div style="float: left; width: 22%; font-weight: bold; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px;">Mother Vsl/Voy</div>
            <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;">:</div>
            <div style="float: left; width: 295px; padding: 5px; margin: 0px 0px 5px 0px;">
                <asp:Label ID="lbl_motvslvoy" runat="server"></asp:Label>
            </div>
                

            <div style="float: left; width: 22%; font-weight: bold; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px;">PoD</div>
            <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;">:</div>
            <div style="float: left; width: 300px; padding: 5px; margin: 0px 0px 5px 0px;">
                <asp:Label ID="lbl_pod" runat="server"></asp:Label>
            </div>
             

            <div style="float: left; width: 22%; font-weight: bold; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px;">ETA </div>
            <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;">:</div>
            <div style="float: left; width: 300px; padding: 5px; margin: 0px 0px 5px 0px;">
                <asp:Label ID="lbl_eta" runat="server"></asp:Label>
            </div>
                <div style="float: left; width: 22%; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px; font-weight: bold; display:none;">IM # & Date </div>
            <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;">:</div>
            <div style="float: left; width: 300px; padding: 5px; margin: 0px 0px 5px 0px;display:none;">
                <asp:Label ID="lbl_IMandDT" runat="server"></asp:Label>
            </div>
              <div style="float: left; width: 22%; font-weight: bold; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px;">MBL # & Date</div>
            <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;display:none;">:</div>
            <div style="float: left; width: 295px; padding: 5px; margin: 0px 0px 5px 0px;">
                <asp:Label ID="lbl_mblanddate" runat="server"></asp:Label>
            </div>

            <div style="float: left; width: 22%; font-weight: bold; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px;display:none;">Feeder Vsl/Voy</div>
            <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;display:none;">:</div>
            <div style="float: left; width: 290px; padding: 5px; margin: 0px 0px 5px 0px;display:none;">
                <asp:Label ID="lbl_feedvslvoy" runat="server"></asp:Label>
            </div>
             <div style=" margin: 0px auto; ">
            <p style="font-weight: bold; padding: 0px 5px 5px 15px; margin: 0px 0px 0px 0px;float:left;">Container Details</p>
                            <div style="float: left; margin: 0px 15px 5px 4px;">:</div>

            <p style="font-weight: normal; padding: 0px 5px 5px 15px; margin: 0px 0px 5px 0px;">
                <asp:Label ID="lbl_contdtls" runat="server"></asp:Label>
            </p>
            <div style="clear: both;"></div>
        </div>
        </div>
        <div style="clear: both;"></div>
        <div style=" margin: 0px auto; border-bottom: 1px solid #000;">
            <div style="width: 510px; float: left; margin: 0px 0px 0px 0px;">
                <div style="float: left; width: 20%; font-weight: bold; padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px;">CFS</div>
                <div style="float: left;  padding: 5px; margin: 0px 15px 5px 0px;">:</div>
                <div style="float: left; width: 300px; padding: 5px; margin: 0px 0px 5px 0px;    white-space: nowrap;">
                    <asp:Label ID="lbl_cfs" runat="server"></asp:Label>
                </div>
            </div>
            <div style="clear: both;"></div>
        </div>
        <div style="clear: both;"></div>



        <div style="width: 1024px; margin: 0px auto;">
              
            <p style="font-weight: bold; margin: 0px 0px 0px 0px; padding: 5px 5px 5px 15px;">Dear Sir/ Madam</p>
            <p style="font-weight: normal; margin: 0px 0px 5px 0px; padding: 5px 5px 5px 15px;">
                Please be advised that the above mentioned vessel is scheduled to arrive <span style="font-weight: bold;">
                    <asp:Label ID="lblpod" runat="server"></asp:Label></span> on <span style="font-weight: bold;">
                        <asp:Label ID="lbleta" runat="server"></asp:Label></span>
            </p>
            <p style="font-weight: normal; margin: 0px 0px 5px 0px; padding: 5px 5px 5px 15px;">Kindly arrange to present the original Bill of Lading & Freight Certificate (if it is Collect Shipment) and obtain a delivery order against payment of necessary charges by DEMAND DRAFT. </p>

            <p style="font-weight: normal; margin: 0px 0px 5px 0px; padding: 5px 5px 5px 15px;">Please note we will not hold the FCL Container(s)  in the Terminal beyond 3 days or as specified by the Terminal and or  Carrier from the day of vessel arrival.  We will move the container to off-Dock CFS after completion of free-days under your cost and risk.</p>
            <p style="font-weight: normal; margin: 0px 0px 5px 0px; padding: 5px 5px 5px 15px;">If you are not cleared within the stipulated time same will be abandoned and we will not be responsible for any consequences.</p>


            <p style="font-weight: normal; margin: 0px 0px 5px 0px; padding: 5px 5px 5px 15px;">Looking forward to your speedy clearance of cargo.</p>
            <p style="font-weight: normal; margin: 0px 0px 5px 0px; padding: 5px 5px 5px 15px;">We can accept cash upto Rs. 5000 only, if it exceeds please pay through Demand Draft</p>
            <p style="font-weight: normal; margin: 0px 0px 5px 0px; padding: 5px 5px 5px 15px;">PENALTY SLABS FOR LATE COLLECTION OF DELIVERY ORDER</p>
            <div style="clear: both;"></div>
        </div>
        <div style="width: 1024px; margin: 0px auto;">
            <div style="float: left; width: 170px; margin: 0px 0px 5px 0px; padding: 5px 5px 5px 15px; font-weight: bold;">Upto15 days</div>
            <div style="float: left; width: 1px; margin: 0px 15px 5px 0px; padding: 5px;">:</div>
            <div style="float: left; width: 400px; margin: 0px 0px 5px 0px; padding: 5px 5px 5px 5px; font-weight: normal;">No fine (starting from the devanning date).</div>
            <div style="clear: both;"></div>
            <div style="float: left; width: 170px; margin: 0px 0px 5px 0px; padding: 5px 5px 5px 15px; font-weight: bold;">Between 15-30 days</div>
            <div style="float: left; width: 1px; margin: 0px 15px 5px 0px; padding: 5px;">:</div>
            <div style="float: left; width: 400px; margin: 0px 0px 5px 0px; padding: 5px; font-weight: normal;">Rs.1500/BL</div>
            <div style="clear: both;"></div>

            <div style="float: left; width: 170px; margin: 0px 0px 5px 0px; padding: 5px 5px 5px 15px; font-weight: bold;">Between 30-60 days</div>
            <div style="float: left; width: 1px; margin: 0px 15px 5px 0px; padding: 5px;">:</div>
            <div style="float: left; width: 400px; margin: 0px 0px 5px 0px; padding: 5px; font-weight: normal;">Rs.2500/BL</div>
            <div style="clear: both;"></div>
            <div style="float: left; width: 170px; margin: 0px 0px 5px 0px; padding: 5px 5px 5px 15px; font-weight: bold;">Above 60 days</div>
            <div style="float: left; width: 1px; margin: 0px 15px 5px 0px; padding: 5px;">:</div>
            <div style="float: left; width: 400px; margin: 0px 0px 5px 0px; padding: 5px; font-weight: normal;">Rs.5000/BL</div>
            <div style="clear: both;"></div>
        </div>
        

        <div style="width: 1024px; margin: 0px auto;">
            <p style="padding: 5px 5px 5px 15px; margin: 0px 0px 5px 0px;">Thanking You</p>
       
            <p style="padding: 5px 5px 5px 15px; margin: 225px 0px 0px 0px; font-weight: bold;    border-top: 1px solid #000;">
                THIS IS A COMPUTER GENERATED DOCUMENT HENCE REQUIRES NO SIGNATURE
            </p>
          
        </div>
       
        <div style="clear: both;"></div>
    </div>
</body>
</html>
