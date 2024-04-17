<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AEBLOriginalText.aspx.cs" Inherits="logix.Reportasp.AEBLOriginalText" %>

<!DOCTYPE html>
<head>
        <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Report</title>
    <style>
        *{
    box-sizing: border-box;
    padding:0;
    margin:0;
}
body{
    font-size:12px !important;
    font-family: sans-serif;
}
.report{
    width: 1024px;
    margin:0 auto;
}
.rcontent{
    margin-top:40px !important
}
.rcontent h4{
    text-align: center;
    font-weight: bold;
    margin-bottom: 10px !important;
}
.main{
    margin-top:20px !important;
}
.main h4{
    text-align: center;
    font-weight: bold;
    margin-bottom: 10px !important;

}
.rleftcontent{
    float:left;
    width:50%;
    padding-left:25px !important
}
.rrightcontent {
    float: left;
    width: 50%;
    padding-left: 30px !important;
    padding-right:25px !important;
}
.one{
    float:left;
    width:100%;
    margin-bottom: 10px !important;
}
.serialno{
 float:left;
 width:10%;
 font-weight: bold;
}
.onec{
    padding-left:10%;
}

p {
    line-height: 1.5;
    text-align: justify;
}
.onec p span{
    padding-right: 15px;
}
.subc {
    padding-left: 33px !important;
}
.onesubc {
    padding-left: 75px !important;
}
.onesubc1{
    padding-left:46px !important;
}
    </style>
<%--<link href="style.css" rel="stylesheet" type="text/css" />--%>
</head>
 <body>
    <div style="width:100%;">
    <div class="report">
        <div class="rcontent">
           <h4>NOTICE CONCERNING CARRIER'S LIMITATION OF LIABILITY</h4>
           <p>IF THE CARRIAGE INVOLVES AN ULTIMATE DESTINATION OR STOP IN A COUNTRY OTHER THAN THE COUNTRY OF DEPARTURE, THE WARSAW CONVENTION OR THE MONTREAL CONVENTION MAY BE APPLICABLE AND IN MOST CASES LIMIT THE LIABILITY OF THE CARRIER IN RESPECT OF, DAMAGE OR DELAY TO CARGO.DEPENDING ON THE APPLICABLE REGIME,AND UNLESS A HIGHER VALUE IS DECLARED,LIABILITY OF THE CARRIER MAY BE LIMITED TO 17 SPECIAL DRAWING RIGHTS PER KILOGRAM,OR 250 FRENCH GOLD FRANCS PER KILOGRAM, CONVERTED INTO NATIONAL CURRENCY UNDER APPLICABLE LAW. CARRIER WILL TREAT 250 FRENCH GOLD FRANCS TO BE THE CONVERSION EQUIVALENT OF 17 SPECIAL DRAWING RIGHTS UNLESS A GREATER AMOUNT IS SPECIFIED IN THE CARRIER'S CONDITIONS OF CARRIAGE.</p>
        </div>
        <div class="main">
            <h4>CONDITIONS OF CONTRACT</h4>
        <div class="rleftcontent">
            <div class="one">
            <div class="serialno">
                <p>1.</p>
            </div>
            <div class="onec">
               <p>In this contract and the Notices appearing hereon:<br/>CARRIER includes the air carrier issuing this air waybill and all carriers that carry or undertake to carry the cargo or perform
                    any other services related to such carriage.<br/> SPECIAL DRAWING RIGHT (SDR) is a Special Drawing Right as
                    defined by the International Monetary Fund.<br/> WARSAW CONVENTION means whichever of the following
                    instruments is applicable to the contract of carriage:<br/> The Convention for the Unification of Certain Rules Relating to International Carriage by Air, signed at Warsaw, 12 October 1929; that Convention as amended at The Hague on 28 September 1955; that Convention as amended at The Hague 1955 and by Montreal Protocol No. 1, 2, or (1975) as the case may be.<br/> MONTREAL CONVENTION means the Convention for the
                    Unification of Certain Rules for International Carriage by Air, done at Montreal on 28 May 1999.</p>
            </div>
            </div>
            <div class="one">
                <div class="serialno">
                    <p>2.</p>
                </div>
                <div class="onec">
                   <p><span>2.1</span>Carriage is subject to the rules relating to liability established by the Warsaw Convention or the Montreal Convention unless such carriage is not “international carriage” as defined by the applicable Conventions.</p>
                   <p><span>2.2</span>To the extent not in conflict with the foregoing, carriage and other related services performed by each Carrier are
                    subject to:</p>
                    <div class="subc">
                   <p><span>2.2.1</span>applicable laws and government regulations;</p>
                   <p><span>2.2.2</span>provisions contained in the air waybill, Carrier’s conditions of carriage and related rules, regulations, and timetables (but not the times of departure and arrival stated therein) and applicable tariffs of such Carrier, which are made part hereof, and which may be inspected at any airports or othe cargo sales offices from which it operates regular
                    services. When carriage is to/from the USA, the
                    shipper and the consignee are entitled,upon
                    request, to receive a free copy of the Carrier’s conditions of carriage. The Carrier’s conditions of
                    carriage include, but are not limited to:</p>
                   </div>
                   <div class="onesubc">
                    <p><span>2.2.2.1</span>limits on the Carrier’s liability for loss,
                        damage or delay of goods, including fragile
                        or perishable goods;</p>
                    <p><span>2.2.2.2</span>claims restrictions, including time periods
                        within which shippers or consignees must
                        file a claim or bring an action against the
                        Carrier for its acts or omissions, or those of
                        its agents;</p>
                    <p><span>2.2.2.3</span>rights, if any, of the Carrier to change the
                        terms of the contract;</p>
                    <p><span>2.2.2.4</span>rules about Carrier’s right to refuse to
                        carry;</p>
                    <p><span>2.2.2.5</span>rights of the Carrier and limitations
                        concerning delay or failure to perform
                        service, including schedule changes,
                        substitution of alternate Carrier or aircraft
                        and rerouting.</p>
                   </div>
                </div>
                </div>
                <div class="one">
                    <div class="serialno">
                        <p>3.</p>
                    </div>
                    <div class="onec">
                     <p>The agreed stopping places (which may be altered by Carrier in case of necessity) are those places, except the place of
                        departure and place of destination, set forth on the face here of or shown in Carrier’s timetables as scheduled stopping places
                        for the route. Carriage to be performed hereunder by several
                        successive Carriers is regarded as a single operation.</p>
                    </div>
                </div>
                <div class="one">
                    <div class="serialno">
                        <p>4.</p>
                    </div>
                    <div class="onec">
                        <p>For carriage to which neither the Warsaw Convention or the Montreal Convention applies, Carrier’s liability limitation shall not be less than the per kilogram monetary limit set out in Carrier's tariffs or general conditions of carriage for cargo lost, damaged or delayed, provided that any such limitations of
                            liability in an amount less than 17 SDR per kilogram will not
                            apply for carriage to of from the United States.</p>
                    </div>
                </div>
                <div class="one">
                    <div class="serialno">
                        <p>5.</p>
                    </div>
                    <div class="onec">
                        <p><span>5.1</span> Except when the Carrier has extended credit to the
                            consignee without the written consent of the shipper, the shipper guarantees payment of all charges for the
                            carriage due in accordance with Carrier’s tariff, conditions of carriage and related regulations, applicable laws
                            (including national laws implementing the Warsaw Convention and the Montreal Convention), government
                            regulations, orders and requirements.</p>
                        <p><span>5.2</span>When no part of the consignment is delivered, a claim with respect to such consignment will be considered
                            even though transportation charges thereon are unpaid.</p>
                    </div>
                </div>
                <div class="one">
                    <div class="serialno">
                        <p>6.</p>
                    </div>
                    <div class="onec">
                        <p><span>6.1</span>For cargo accepted for carriage,the Warsaw Convention and the Montreal Convention permit shipper to increase the limitation of liability by declaring a higher value for
                            carriage and paying a supplemental charge if required.
                           
                           </p>
                           <p><span>6.2</span>In carriage to which neither the Warsaw Convention nor the Montreal Convention applies Carrier shall, </p>
                    </div>
                </div>
            
        </div>
        <div class="rrightcontent">
            <div class="one">
                <div class="serialno">
                    <p>6.</p>
                </div>
                <div class="onec">
                    
                       <p>in accordance with the procedures set forth in its general
                        conditions of carriage and applicable tariffs, permit
                       shipper to increase the limitation of liability by declaring a higher value for carriage and paying a
                       supplemental charge if so required.</p>
                </div>
            </div>
            <div class="one">
                <div class="serialno">
                    <p>7.</p>
                </div>
                <div class="onec">
                    <p><span>7.1</span>In cases of loss of, damage or delay to part of the cargo, the weight to be taken into account in
                        determining Carrier’s limit of liability shall be only the
                        weight of the package or packages .</p>
                    <p><span>7.2</span>Notwithstanding any other provisions, for “foreign air transportation” as defined by the U.S. Transportation Code:</p>
                    <div class="subc">
                        <p><span>7.2.1</span>in the case of loss of, damage or delay to a
                            shipment, the weight to be used in determining
                            Carrier’s limit of liability shall be the weight which
                            is used to determine the charge for carriage of
                            such shipment; and</p>
                        <p><span>7.2.2</span> in the case of loss of, damage or delay to a part
                            of a shipment, the shipment weight in 7.2.1 shall be prorated to the packages covered by the same air waybill whose value is affected by the loss, damage or delay. The weight applicable in the case of loss or damage to one or more articles in a package shall be the weight of the entire
                            package.</p>
                    </div>
                </div>
            </div>
            <div class="one">
                <div class="serialno">
                    <p>8.</p>
                </div>
                <div class="onec">
                    <p>Any exclusion or limitation of liability applicable to Carrier shall
                        apply to Carrier’s agents, employees, and representatives and to any person whose aircraft or equipment is used by Carrier
                        for carriage and such person’s agents, employees and
                        representatives.</p>
                </div>
            </div>
            <div class="one">
                <div class="serialno">
                    <p>9.</p>
                </div>
                <div class="onec">
                    <p>Carrier undertakes to complete the carriage with reasonable
                        dispatch. Where permitted by applicable laws, tariffs and
                        government, Carrier may use alternative carriers, aircraft or modes of transport without notice but with due regard to the
                        interests of the shipper. Carrier is authorized by the shipper to select the routing and all intermediate stopping places that it deems appropriate or to change or deviate from the routing
                        shown on the face hereof.</p>
                </div>
            </div>
            <div class="one">
                <div class="serialno">
                    <p>10.</p>
                </div>
                <div class="onec">
                    <p>Receipt by the person entitled to delivery of the cargo without
complaint shall be prima facie evidence that the cargo has been delivered in good condition and in accordance with the
contract of carriage.</p>
                 <div class="subc">
                    <p><span>10.1</span> In the case of loss of, damage or delay to cargo a written complaint must be made to Carrier by the person entitled to delivery. Such complaint must be made:</p>
                    <div class="onesubc1">
                        <p><span>10.1.1</span>in the case of damage to the cargo, immediately
                            after discovery of the damage and at the latest
                            within 14 days from the date of receipt of the
                            cargo;</p>
                        <p><span>10.1.2</span> in the case of delay, within 21 days from the date on which the cargo was placed at the disposal of the person entitled to delivery.</p>
                        <p><span>10.1.3</span>in the case of non-delivery of the cargo, within
                            120 days from the date of issue of the air
                            waybill, or if an air waybill has not been issued,
                            within 120 days from the date of receipt of the
                            cargo for transportation by the Carrier.</p>
                    </div>
                    <p><span>10.2</span>Such complaint may be made to the Carrier whose air
                        waybill was used, or to the first Carrier or to the last Carrier or to the Carrier, which performed the carriage
                        during which the loss, damage or delay took place.</p>
                    <p><span>10.3</span>Unless a written complaint is made within the time limits
                        specified in 10.1 no action may be brought against Carrier.</p>
                    <p><span>10.4</span>Any rights to damages against Carrier shall be
                        extinguished unless an action is brought within two years from the date of arrival at the destination, or from the date on which the aircraft ought to have arrived, or from the date on which the carriage stopped.</p>
                 </div>
                </div>
            </div>
            <div class="one">
                <div class="serialno">
                    <p>11.</p>
                </div>
                <div class="onec">
                    <p>Shipper shall comply with all applicable laws and government
                        regulations of any from which the cargo may be carried,
                        including those relating to the packing, carriage or delivery of the cargo, and shall furnish such information and attach such documents to the air waybill as may be necessary to comply with such laws and regulations. Carrier is not liable to shipper and shipper shall indemnify Carrier for loss or expense due to
                        shipper’s failure to comply with this provision.</p>
                </div>
            </div>
            <div class="one">
                <div class="serialno">
                    <p>12.</p>
                </div>
                <div class="onec">
                    <p>No agent, employee or representative of Carrier has authority.</p>
                </div>
            </div>
        </div>
        </div>
    </div>
    </div>
</body>
</html>
