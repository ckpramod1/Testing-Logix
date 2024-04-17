// JScript File

//function FocusNextControl()
//{
//var flag=0;
//var temp='';
//if(event.keyCode == 13)
// {
// for(i=0;i<document.forms[0].elements.length;i++)
//  {
//    if(event.srcElement.tabIndex+1 == document.forms[0].elements[i].tabIndex)
//      {
//        document.forms[0].elements[i].focus();
//        flag=1;
//        break;  
//      }    
//  } 
//  if(flag==0)
//     {
//        FocusFirstControl();
//     }     
//     return false;
// }
// else
//   {
//    return true;
//   } 
//}
function FocusNextControl()
{
var flag=0;
var temp='';
if(event.keyCode == 13)
 {
    return false;
 } 
}

function FocusFirstControl()
{
for(i=0;i<document.forms[0].elements.length;i++)
  {
  if(document.forms[0].elements[i].tabIndex == 1)
    {
        document.forms[0].elements[i].focus();        
        break;  
    }  
  } 
}
//==========================================================================================================

function FocusEnter()
{
var flag=0;
var cntCtrlName=event.srcElement.name;
var ctrlPosition=ControlValid(cntCtrlName);
if(event.keyCode == 13)
 {
  var flag=0;
  for(var k=ctrlPosition+1;k<document.forms[0].elements.length;k++)
  {   
if(document.forms[0].elements[k] !=null)
       {
       switch(document.forms[0].elements[k].type)
           {
                case "checkbox":
                case "select-one":
                case "radio":
                case "text":
                case "submit":
                case "textarea":
                case "password":
                    if(document.forms[0].elements[k].disabled == false)
                        {flag=k;}
                    break;
           }
       }
    if(flag != 0)
    {
      document.forms[0].elements[flag].focus();
      break;
    }
  }  
   if(flag == 0)
    {      
      FirstCtrlFocus();
    }
  return false;  
 }
 else
 { return true; } 
}


function FirstCtrlFocus()
{
  for(var i=0;i<document.forms[0].elements.length;i++)
  {
  var flag=0;
        switch(document.forms[0].elements[i].type)
           {
                case "checkbox":
                case "select-one":
                case "radio":
                case "text":
                case "submit":
                case "textarea":
                    if(document.forms[0].elements[i].disabled == false)
                    {flag=i;}
                    break;
           }
      if(flag!=0)
       {
        document.forms[0].elements[flag].focus();
        break;
       }
  }
}


function LockEnter(event)
{      
   if(event.keyCode == 13)
        {return false;}
    else
        {return true;}   
}
function UCase()
{
  if(event.srcElement.type=='text');
      {
            event.srcElement.value=event.srcElement.value.toUpperCase();
      } 
}

function DeleteConfirm(strSrc)
{
    var ctrlPtn=ControlValid(strSrc);
    var ctrlValue=document.forms[0].elements[ctrlPtn].value;
    return confirm("Do you want to Delete "+ ctrlValue);
}