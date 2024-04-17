
var cmonth,cdate,cday,cyear,dayInNo,cmonthInNo;
   var pnlTbl,pnlTr,pnlTd,pnlTblBody;
   //var days="Sun,Mon,Tue,Wed,Thu,Fri,Sat";
   var days="S,M,T,W,T,F,S";
   var temp;
   var ddlMonth=document.createElement("select");
   ddlMonth.onchange=function(){OnYearMonthChanging();};
   var ddlYear=document.createElement("select");
   ddlYear.onchange=function(){OnYearMonthChanging();};
   var months="JAN,FEB,MAR,APR,MAY,JUN,JUL,AUG,SEP,OCT,NOV,DEC";
   var monthsinArray=months.split(',');
   var GlobalctrlName;
   var Tempdate=new Date();
   var stYr=2008;
   var endYr=Tempdate.getFullYear()+1;   
   var flag=0;
    //load months in dropdown list
   for(var z=0;z<monthsinArray.length;z++)
   {
    ddlMonth.options[z] = new Option(monthsinArray[z],monthsinArray[z],false,false);   
   }
    
   ddlMonth.selectedIndex=Tempdate.getMonth();
   
   var count=0;
   //load years in dropdown list
   for(var z=endYr;z>=stYr;z--)
   {
       ddlYear.options[count]=new Option(z,z,false,false);
       count++;
   }
   ddlYear.selectedIndex = 1;
   ddlYear.style.fontSize=11;
   ddlYear.style.fontFamily='sans-serif';
   ddlMonth.style.fontSize=11;
   ddlMonth.style.fontFamily='sans-serif';   
      
  cyear=Tempdate.getFullYear();   
   cmonth=ddlMonth.options[ddlMonth.selectedIndex].value;
   cdate= Tempdate.getDate();
   cmonthInNo =Tempdate.getMonth();
   cday= Tempdate.getDay();  
 
 
   //To create calendar table
   function CreateCalendar(ctrlCal)
    {   
   var varCtrlValue=GetDateFromCBox(ctrlCal); 
   
   if(flag==0)
   {
   if(varCtrlValue!='')
     {
        var varTempArray=varCtrlValue.split('/');
        cmonth= MonthinWord(varTempArray[1]);        
        cdate= varTempArray[0];
        cyear = varTempArray[2];   
       ddlYear.selectedIndex = GetSelYearIndex(cyear); 
       ddlMonth.selectedIndex =varTempArray[1]-1;
     }       
   }  
   
   var stDay=GetStaringDay(cyear,cmonthInNo,1);       
      if(pnlTbl!=null)
          pnlTbl.style.visibility='hidden';  
      GlobalctrlName=ctrlCal; 
      cmonthInNo = MonthinNo();
      stDay = GetStaringDay(cyear,cmonthInNo-1,1);
      var k=1;
      pnlTbl=document.createElement("table");
      pnlTbl.border=0+'px';
      pnlTbl.height=210+'px';
      pnlTbl.style.backgroundColor='#C4D0D4';
     pnlTblBody=document.createElement('tbody');      
      pnlTblBody.align='center';
     pnlTr=document.createElement("tr"); 
      pnlTd =document.createElement('td');
      pnlTd.colSpan=4;
          temp=document.createTextNode('Month'); 
          pnlTd.appendChild(temp);
      pnlTd.appendChild(ddlMonth);
      pnlTr.appendChild(pnlTd);
     
      pnlTd =document.createElement('td');
      pnlTd.colSpan=3;
          temp=document.createTextNode('Year'); 
          pnlTd.appendChild(temp);
      pnlTd.appendChild(ddlYear);
      pnlTr.appendChild(pnlTd);          
      pnlTblBody.appendChild(pnlTr);       
      
      for(var i=0;i<7;i++)
            {
              if(i==0)
              {
                    pnlTr=document.createElement("tr");                     
                     var daysArray=days.split(',');             
                            for(var j=0;j<7;j++)
                            {
                                  pnlTd=document.createElement('td'); 
                                  temp=document.createTextNode(daysArray[j]);                                    
                                  pnlTd.appendChild(temp);                                                    
                                  pnlTr.appendChild(pnlTd);
                           }   
                    pnlTblBody.appendChild(pnlTr); 
              }     
              
              else
              { 
                  pnlTr=document.createElement('tr');             
                   for(var j=0;j<7;j++)
                   {
                    pnlTd=document.createElement("td"); 
                    pnlTd.style.cursor='Pointer';
                    pnlTd.onclick=function(){setDate(this,ctrlCal);};
                      if(k<=NoofDaysInMonth())
                     { 
                       if(k==1)
                      { 
                          if(stDay == j)
                            { 
                            temp=document.createTextNode(k);  
                            k++;                      
                            pnlTd.appendChild(temp);               
                            }
                        } 
                        else
                        {
                            temp=document.createTextNode(k);  
                            k++;                      
                            pnlTd.appendChild(temp);               
                        }
                     }
                      pnlTr.appendChild(pnlTd);
                   }   
                    pnlTblBody.appendChild(pnlTr); 
              }
            }
          
      pnlTr=document.createElement('tr'); 
      pnlTd =document.createElement('td');
      pnlTd.colSpan=5;
      
      if(cdate.length==2)
          temp=document.createTextNode('Date : ' +cdate+"/"+MonthinNo()+"/"+cyear); 
         else
            temp=document.createTextNode('Date : ' +'0'+cdate+"/"+MonthinNo()+"/"+cyear); 
          pnlTd.appendChild(temp);          
      pnlTr.appendChild(pnlTd);        
      pnlTr.appendChild(pnlTd);          
      
      
       pnlTd =document.createElement('td');
       pnlTd.colSpan=2;
          temp=document.createElement("div");
          temp.onclick=function(){ flag=0;CalendarHide();};
          temp.style.cursor = 'Pointer';
          var temp1=document.createTextNode("Hide");
          temp.appendChild(temp1);          
          temp.style.color="Red";
          pnlTd.appendChild(temp);       
          
   
      pnlTr.appendChild(pnlTd);          
      
      pnlTblBody.appendChild(pnlTr);     
          
          
            
           pnlTbl.appendChild(pnlTblBody);           
           pnlTbl.setAttribute('border',2);        
          
        //ctrlP = Control(GlobalctrlName);
        //ctrl=document.forms[0].elements[ctrlP];
       ctrl=document.getElementById(GlobalctrlName);
        pnlTbl.style.position = 'absolute'; 
        pnlTbl.style.left = findPosX(ctrl)+'px';
        
         if(findPosY(ctrl)>window.screen.height/2)
            pnlTbl.style.top=findPosY(ctrl)-200+'px';
         else
            pnlTbl.style.top=findPosY(ctrl)+25+'px';
            
        
        pnlTbl.style.fontSize=11;
        pnlTbl.style.fontFamily='sans-serif';
        pnlTbl.style.visibility='visible'; 
        document.forms[0].appendChild(pnlTbl);          
        return false;   
       }       
   function setDate(dat,ctrlName)
   {
      flag=0;
   if(dat.childNodes[0] !=null)
        cdate = dat.childNodes[0].nodeValue;
//   var ctlPon=Control(ctrlName);   
//   var ctrl= document.forms[0].elements[ctlPon];
var ctrl = document.getElementById(GlobalctrlName);
   if(cdate.length==2)   
   ctrl.value =cdate+ '/' + MonthinNo()+'/'+cyear;
   else
   ctrl.value ="0"+cdate+ '/' + MonthinNo()+'/'+cyear;   

   CalendarHide();   
   }
       
       //Hide the calendar table
       function CalendarHide()
       {       
        if(pnlTbl !=null)
            pnlTbl.style.visibility='hidden';
        return false;         
       }
       
       function HideCal()
       {
            if(event.srcElement.name==null)
                 CalendarHide();
            if(event.srcElement.name!=null)
                { 
                    if(event.srcElement.name.length>0)
                      CalendarHide();                    
                }
       }
       
       
       function OnYearMonthChanging()
       {
        cyear=ddlYear.options[ddlYear.selectedIndex].value;
        cmonth = ddlMonth.options[ddlMonth.selectedIndex].value;       
        CalendarHide();
        flag=1; 
        CreateCalendar(GlobalctrlName);          
       }
       
       //To get the no of months in a month
       function NoofDaysInMonth()
       {
        var noofdays=0;
         switch(cmonth)
        {
            case 'JAN':
                noofdays = 31;
                break;
            case 'FEB':
                    if(cyear%4==0)
                        {noofdays = 29;}
                    else
                        {noofdays=28;}
                break;
            case 'MAR':
                noofdays = 31;
                break;
            case 'APR':
                noofdays = 30;
                break;
            case 'MAY':
                noofdays = 31;
                break;
            case 'JUN':
                noofdays = 30;
                break;               
            case 'JUL':
                noofdays = 31;
                break;
            case 'AUG':
                noofdays = 31;
                break;
            case 'SEP':
                noofdays = 30;
                break;
            case 'OCT':
                noofdays = 31;
                break;
            case 'NOV':
                noofdays = 30;
                break;
            case 'DEC':
                noofdays = 31;
                break;                                          
        }  
       return noofdays; 
       }
       
       
       //To get the month in Number based on 3 character of a month
       function MonthinNo()
       {
        var mthinNo='';
          switch(cmonth)
        {
            case 'JAN':
                mthinNo = '01';
                break;
            case 'FEB':
                mthinNo = '02';
                break;
            case 'MAR':
                mthinNo = '03';
                break;
            case 'APR':
                mthinNo = '04';
                break;
            case 'MAY':
                mthinNo = '05';
                break;
            case 'JUN':
                mthinNo = '06';
                break;               
            case 'JUL':
                mthinNo = '07';
                break;
            case 'AUG':
                mthinNo = '08';
                break;
            case 'SEP':
                mthinNo = '09';
                break;
            case 'OCT':
                mthinNo = '10';
                break;
            case 'NOV':
                mthinNo = '11';
                break;
            case 'DEC':
                mthinNo = '12';
                break;                             
        }  
       return mthinNo; 
       }
       
        function MonthinWord(xxx)
       {
        var mthinWord='';
          switch(xxx)
        {
            case '01': 
                mthinWord = 'JAN';
                break;
            case '02': 
                mthinWord =  'FEB';                
                break;
           case '03': 
                mthinWord =  'MAR';
                break;
           case '04': 
                mthinWord =  'APR';
                break;
           case '05': 
                mthinWord =  'MAY';
                break;
           case '06': 
                mthinWord =  'JUN';
                break;               
           case '07': 
                mthinWord =  'JUL';
                break;
           case '08': 
                mthinWord =  'AUG';
                break;
           case '09': 
                mthinWord =  'SEP';
                break;
           case '10': 
                mthinWord =  'OCT';
                break;
           case '11': 
                mthinWord =  'NOV';
                break;
           case '12':
                mthinWord =  'DEC';
                break;                             
        }  
       return mthinWord; 
       }
       
       //To get the date from TextBox
       function GetDateFromCBox(tempCtrlName)
       {
           //  var tempPosn=Control(tempCtrlName);
            // return document.forms[0].elements[tempPosn].value;
            return document.getElementById(tempCtrlName).value;
       }
       
       
       //To get the day of a date
       function GetStaringDay(varYr,varMth,varDate)
       {
       var tempDay=0; 
       var tmpDate=new Date();      
       tmpDate.setFullYear(varYr,varMth,varDate);                 
       tempDay=tmpDate.getDay();       
        return tempDay; 
       } 
       
       //Get the day in Number
       function dayInNumber()
       {
       var dayinNo;
        switch(cday)
          {
            case 'Sunday':
                    dayinNo=0;
                    break; 
            case 'Monday':
                    dayinNo=1;
                    break; 
            case 'Tuesday':
                    dayinNo=2;
                    break; 
            case 'Wednesday':
                    dayinNo=3;
                    break; 
            case 'Thursday':
                    dayinNo=4;
                    break; 
            case 'Friday':
                    dayinNo=5;
                    break; 
            case 'Saturday':
                    dayinNo=6;
                    break; 
         } 
        return dayinNo; 
       }
       
    
   
       
        //------Function findPosX() code Start----------
        function findPosX(obj)
        {
        var curleft = 0;
        if(obj.offsetParent)
        while(1) 
        {
        curleft += obj.offsetLeft;
        if(!obj.offsetParent)
        break;
        obj = obj.offsetParent;
        }
        else if(obj.x)
        curleft += obj.x;
        return curleft;
        }
        //---------Function findPosX() code End-----------
        //--------Function findPosY() code start-----
        function findPosY(obj)
        {
        var curtop = 0;
        if(obj.offsetParent)
        while(1)
        {
        curtop += obj.offsetTop;
        if(!obj.offsetParent)
        break;
        obj = obj.offsetParent;
        }
        else if(obj.y)
        curtop += obj.y;
        return curtop;
        }
       //---Function findPosY() code End-------
      
      
       //---Function Control() code start
       //used to get the control by name/id
        function Control(ctrlName)
        {
        var intResult=1;
        for(var i=0;i<document.forms[0].elements.length;i++)
        {
           if(RemoveDollarSign(document.forms[0].elements[i].name)== ctrlName)
           {
            intResult = i;
           break; 
           }           
        }
         return intResult;  
        }

        function RemoveDollarSign(strValue)
        {
         var temp=new Array();
            temp=strValue.split('$')
           return temp[2];  
        }   
 
   function GetSelYearIndex(yrValue)
   {
   var tempYear;
   var count=0;
       for(var z=endYr;z>=stYr;z--)
       {
           if(yrValue== ddlYear.options[count].value)
           {
             tempYear=count;
             break; 
           }
           count++;
       }
    return tempYear;
   }  