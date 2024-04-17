<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AICANRpt.aspx.cs" Inherits="logix.Reportasp.AICANRpt" %>


<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Report</title>
    <style>
      * {
        margin: 0;
        padding: 0;
        font-size: 14px;
        box-sizing: border-box;
        font-family: sans-serif;
      }
      .heading {
        font-weight: bold;
        margin: 10px 0px 10px 10px;
      }
      .text {
        float: left;
        width: 133px;
      }
      .dot {
        float: left;
        margin: 9px 0px 0px 0px;
        width: 17px;
      }
      .bindvalue {
        float: left;
        margin: 10px 0px 0px 0px;
      }
    </style>
  </head>
  <body>
    <div style="width: 1024px; margin: 0 auto">
      <div style="width: 100%; border: 1px solid; float: left">
        <div
          style="
            width: 100%;
            display: flex;
            justify-content: center;
            align-items: center;
            border-bottom: 1px solid black;
          "
        >
          <div style="text-align: center">
            <p
              style="font-size: 20px; font-weight: 600; margin: 5px 0px 5px 0px"
            >
              <asp:label id="lbl_branch" runat="server"></asp:label>
            </p>
            <p style="text-align: center; margin: 5px 0px 5px 0px">
              <asp:label id="lbl_add" runat="server"></asp:label>
            </p>

            <p style="margin: 5px 0px 5px 0px">
              <span>Phone</span><span>:</span
              ><span
                ><asp:label id="lbl_ph" runat="server"
                  ></asp:label
                ></span
              >

              <span>-Fax</span><span>:</span
              ><span
                ><asp:label id="lbl_fax" runat="server"
                  ></asp:label
                ></span
              >
            </p>
          </div>
        </div>
        <div
          style="
            border-bottom: 1px solid black;
            text-align: center;
            font-size: 20px;
            font-weight: bold;
            padding: 8px;
          "
        >
          CARGO ARRIVAL NOTICE
        </div>
        <div style="width: 100%; float: left; border-bottom: 1px solid black">
          <div
            style="
              width: 60%;
              float: left;
              border-right: 1px solid black;
              height: 166px;
            "
          >
            <p class="heading">To</p>
            <p style="margin: 0px 0px 0px 9px; width: 90%">
              <asp:label id="lbl_conadd" runat="server"
                ></asp:label
              >
            </p>
          </div>

          <div style="width: 40%; float: left">
            <span
              ><p class="heading text">CAN Date</p>
              <p class="dot">:</p>
              <p class="bindvalue">
                <asp:label id="lbl_condate" runat="server"></asp:label>
              </p>
            </span>
            <div style="clear: both"></div>
            <span
              ><p class="heading text">Job #</p>
              <p class="dot">:</p>
              <p class="bindvalue">
                <asp:label id="lbl_job" runat="server"></asp:label>
              </p>
            </span>
            <div style="clear: both"></div>

            <span
              ><p class="heading text">Flight #</p>
              <p class="dot">:</p>
              <p class="bindvalue">
                <asp:label id="lbl_flno" runat="server"></asp:label>
              </p>
            </span>
            <div style="clear: both"></div>

            <span
              ><p class="heading text">Arrival Date</p>
              <p class="dot">:</p>
              <p class="bindvalue">
                <asp:label id="lbl_flar" runat="server"></asp:label>
              </p>
            </span>
            <div style="clear: both"></div>
          </div>
        </div>
        <div style="width: 100%; float: left; border-bottom: 1px solid black">
          <div
            style="
              width: 60%;
              float: left;
              border-right: 1px solid black;
              height: 216px;
            "
          >
            <span
              ><p class="heading text">MAWB # & Date</p>
              <p class="dot">:</p>
              <p class="bindvalue">
                <asp:label id="lbl_mbl" runat="server"
                  ></asp:label
                >
              </p>
            </span>
            <div style="clear: both"></div>

            <span
              ><p class="heading text">HAWB # & Date</p>
              <p class="dot">:</p>
              <p class="bindvalue">
                <asp:label id="lbl_hawb" runat="server"
                  ></asp:label
                >
              </p>
            </span>
            <div style="clear: both"></div>

            <span
              ><p class="heading text">Consignee</p>
              <p class="dot">:</p>
              <p class="bindvalue">
                <asp:label id="lbl_cons" runat="server"
                  ></asp:label
                >
              </p>
            </span>
            <div style="clear: both"></div>

            <span
              ><p class="heading text">Shipper</p>
              <p class="dot">:</p>
              <p class="bindvalue">
                <asp:label id="lbl_ship" runat="server"
                  ></asp:label
                >
              </p>
            </span>
            <div style="clear: both"></div>
          </div>

          <div style="width: 40%; float: left">
            <span
              ><p class="heading text">PoL</p>
              <p class="dot">:</p>
              <p class="bindvalue">
                <asp:label id="lbl_pol" runat="server"></asp:label>
              </p>
            </span>
            <div style="clear: both"></div>
            <span
              ><p class="heading text">PoD</p>
              <p class="dot">:</p>
              <p class="bindvalue">
                <asp:label id="lbl_pod" runat="server"></asp:label>
              </p>
            </span>
            <div style="clear: both"></div>
            <span
              ><p class="heading text">Packages</p>
              <p class="dot">:</p>
              <p class="bindvalue">
                <asp:label id="lbl_pak" runat="server"></asp:label>
              </p>
            </span>
            <div style="clear: both"></div>
            <span
              ><p class="heading text">Gross Wt.</p>
              <p class="dot">:</p>
              <p class="bindvalue">
                <asp:label id="lbl_gr" runat="server"></asp:label>
              </p>
            </span>
            <div style="clear: both"></div>
            <span id="hc_igm" runat="server"
              ><p class="heading text">IGM #</p>
              <p class="dot">:</p>
              <p class="bindvalue">
                <asp:label id="lbl_igm" runat="server"></asp:label>
              </p>
            </span>
            <div style="clear: both"></div>
            <span id="hc_date" runat="server"
              ><p class="heading text">IGM Date</p>
              <p class="dot">:</p>
              <p class="bindvalue">
                <asp:label id="lbl_igmdate" runat="server"></asp:label>
              </p>
            </span>
            <div style="clear: both"></div>
          </div>
        </div>
        <div style="width: 100%; float: left; border-bottom: 1px solid black">
          <span
            ><p class="heading text">CARGO</p>
            <p class="dot">:</p>
            <p class="bindvalue">
              <asp:label id="lbl_desc" runat="server"></asp:label>
            </p>
          </span>
        </div>
        <div style="width: 100%; float: left">
          <p class="heading" style="font-weight: normal; margin-top: 25px">
            You are kindly requested to collect the relative delivery order from
            us after settlement of charges as per attached
          </p>

          <p class="heading" style="margin-top: 80px">With Best Regards</p>

          <p style="margin-top: 50px">
            <span
              ><p class="heading text" style="width: 41px">For</p>

              <p class="bindvalue">
                <asp:label id="lbl_branch2" runat="server"></asp:label>
              </p>
            </span>
          </p>
          <div style="clear: both"></div>
          <p class="heading" style="margin-top: 150px">Authorised Signatory</p>
        </div>
      </div>
    </div>
  </body>
</html>

