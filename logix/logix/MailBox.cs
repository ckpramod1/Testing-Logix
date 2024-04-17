using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace logix
{
    public class MailBox
    {

        public string strScript;
        public MailBox()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MailBox(Page p, TextBox txtBox)
        {
            p.RegisterClientScriptBlock("MailScript", GetScript());
            txtBox.Attributes.Add("OnKeyDown", "return isValidMail(this);");
        }

        public string GetScript()
        {
            strScript = "";
            strScript += "<script language=javascript>";
            strScript += "var validEndChars='abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ'; ";
            strScript += "var validNumChars='0123456789';";
            strScript += "function isValidMail(x)";
            strScript += "{";
            strScript += "var flag=0;";
            //when press @ key  
            strScript += "if(x.value.length==0)";
            strScript += "{";
            strScript += "if(event.keyCode>=65 && event.keyCode<=90)";
            strScript += "{";
            strScript += "flag=0;";
            strScript += "} ";
            strScript += "else";
            strScript += "{";
            strScript += "flag=flag+1;";
            strScript += "} ";
            strScript += "} ";
            strScript += "else if(event.shiftKey==1)  ";
            strScript += "{";
            strScript += "if(event.keyCode==50)";
            strScript += "{";
            strScript += "if(x.value.length==0)";
            strScript += "{";
            strScript += "flag=flag+1; ";
            strScript += "}";
            strScript += "else if(x.value.indexOf('@')!=-1)";
            strScript += "{ flag=flag+1;}      ";
            strScript += "else if(validEndChars.indexOf(x.value.charAt(x.value.length-1))==-1 )";
            strScript += "{";
            strScript += "flag=flag+1;";
            strScript += "}  ";
            strScript += "} ";
            strScript += "else if(event.keyCode==189)";
            strScript += "{";
            strScript += "if(x.value.length==0)";
            strScript += "{";
            strScript += "flag=flag+1; ";
            strScript += "}   ";
            strScript += "else if(validEndChars.indexOf(x.value.charAt(x.value.length-1))==-1 )";
            strScript += "{";
            strScript += "flag=flag+1;";
            strScript += "}";
            strScript += "}";
            strScript += "else ";
            strScript += "{";
            strScript += "flag=flag+1; ";
            strScript += "} ";
            strScript += "} ";
            //when press , /    =  ~ [ ] \ ; ' 
            strScript += "else if(event.keyCode==188 || event.keyCode==191 || event.keyCode==187  || event.keyCode==192  || event.keyCode==219  || event.keyCode==220  || event.keyCode==221  || event.keyCode==186  || event.keyCode==222  || event.keyCode==111  || event.keyCode==106  || event.keyCode==109  || event.keyCode==107)";
            strScript += "{ flag=flag+1;}   ";
            //when press _ key 
            strScript += "else if(event.keyCode==189)";
            strScript += "{  ";
            strScript += "if(event.shiftKey==1)";
            strScript += "{";
            strScript += "if(x.value.length==0)";
            strScript += "{";
            strScript += "flag=flag+1; ";
            strScript += "}";
            strScript += "else if(validEndChars.indexOf(x.value.charAt(x.value.length-1))==-1 )";
            strScript += "{";
            strScript += "flag=flag+1;";
            strScript += "} ";
            strScript += "}";
            strScript += "else";
            strScript += "{  flag=flag+1;  }     ";
            strScript += "} ";
            //when press . key  
            strScript += "else if(event.keyCode==190)";
            strScript += "{";
            strScript += "if(event.shiftKey==1)";
            strScript += "{";
            strScript += "flag=flag+1;";
            strScript += "}  ";
            strScript += "else ";
            strScript += "{";
            strScript += "if(x.value.length==0)";
            strScript += "{";
            strScript += "flag=flag+1; ";
            strScript += "}  ";
            strScript += "else if(validEndChars.indexOf(x.value.charAt(x.value.length-1))==-1  &&  validNumChars.indexOf(x.value.charAt(x.value.length-1))==-1)";
            strScript += "{";
            strScript += "flag=flag+1;";
            strScript += "}  ";
            strScript += "} ";
            strScript += "}   ";
            //when press . key  in Num Pad
            strScript += "else if(event.keyCode==110)";
            strScript += "{";
            strScript += "if(x.value.length==0)";
            strScript += "{";
            strScript += "flag=flag+1; ";
            strScript += "}   ";
            strScript += "else if(validEndChars.indexOf(x.value.charAt(x.value.length-1))==-1  &&  validNumChars.indexOf(x.value.charAt(x.value.length-1))==-1)";
            strScript += "{";
            strScript += "flag=flag+1;";
            strScript += "}  ";
            strScript += "} ";
            strScript += "else if(event.keyCode==9)";
            strScript += "{";
            strScript += "if(x.value.length==0)";
            strScript += "{ ";
            strScript += "alertify.alert('Emty Mail ID not Allowed'); ";
            strScript += "flag=flag+1; ";
            strScript += "}  ";
            strScript += "else if(x.value.indexOf('@')==-1)";
            strScript += "{";
            strScript += "alertify.alert('Invalid Mail ID');";
            strScript += "flag=flag+1;          ";
            strScript += "}   ";
            strScript += "else if(x.value.lastIndexOf('.')<x.value.indexOf('@'))";
            strScript += "{";
            strScript += "alertify.alert('Invalid Host Name');";
            strScript += "flag=flag+1;          ";
            strScript += "}  ";
            strScript += "else";
            strScript += "{";
            strScript += "var ar=new Array();";
            strScript += "ar=x.value.split(' ');";
            strScript += "if(ar.length!=1)";
            strScript += "{";
            strScript += "alertify.alert('Invalid Maild ID Space Not Allowed');";
            strScript += "flag=flag+1;";
            strScript += "}  ";
            strScript += "else";
            strScript += "{";
            strScript += "var temp=x.value.substr(x.value.lastIndexOf('.')+1,x.value.length-x.value.lastIndexOf('.')); ";
            strScript += "var count=0; ";
            strScript += "var ar1=new Array(); ";
            strScript += "ar1=temp.split('');  ";
            strScript += "if(ar1.length==0)";
            strScript += "{  count=count+1;   }";
            strScript += "else";
            strScript += "{  ";
            strScript += "for(var z=0;z<ar1.length;z++)  ";
            strScript += "{ ";
            strScript += "if(validEndChars.indexOf(ar1[z])==-1)    ";
            strScript += "{  count=count+1;   break;   } ";
            strScript += "}";
            strScript += "} ";
            strScript += "if(count>0)";
            strScript += "{ ";
            strScript += "alertify.alert('Invalid Host Name');  ";
            strScript += "flag=flag+1;  ";
            strScript += "} ";
            strScript += "} ";
            strScript += "}";
            strScript += "} ";
            strScript += "if(flag==0)";
            strScript += "{return true;}";
            strScript += "else {return false;}  ";
            strScript += "}";
            strScript += "</script>";
            return strScript;
        }
    }
}