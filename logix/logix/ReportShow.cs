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
    public class ReportShow
    {
        public string strScript = "", strTemp = "";
        public ReportShow(string strReport, string strSF, string strPM, string strCondition, Page p, string intBranchID)
        {
            strTemp = SetReport(intBranchID);
            strTemp += "<script type=text/javascript> ShowReport('" + strReport + "','" + strSF + "','" + strPM + "','" + strCondition + "');</script>";
            p.Page.RegisterClientScriptBlock("ReportScript", strTemp);
        }
        public ReportShow(string strReport, string strSF, string strPM, string strCondition, Button btnView, Page p, string intBranchID)
        {
            strTemp = SetReport(intBranchID);
            //p.Page.RegisterClientScriptBlock("ReportScript", strTemp);
            p.Page.RegisterStartupScript("ReportScript", strTemp);
            btnView.Attributes.Add("OnClick", "return ShowReport('" + strReport + "','" + strSF + "','" + strPM + "','" + strCondition + "')");
        }
        public ReportShow(string strReport, string strSF, string strPM, string strCondition, TextBox btnView, Page p, string intBranchID)
        {
            strTemp = SetReport(intBranchID);
            p.Page.RegisterClientScriptBlock("ReportScript", strTemp);
            btnView.Attributes.Add("OnClick", "return ShowReport('" + strReport + "','" + strSF + "','" + strPM + "','" + strCondition + "')");
        }
        public ReportShow(string strReport, string strSF, string strPM, string strCondition, ListBox btnView, Page p, string intBranchID)
        {
            strTemp = SetReport(intBranchID);
            p.Page.RegisterClientScriptBlock("ReportScript", strTemp);
            btnView.Attributes.Add("OnClick", "return ShowReport('" + strReport + "','" + strSF + "','" + strPM + "','" + strCondition + "')");
        }
        public string SetReport(string intTempBranchID)
        {
            strScript = "";
            strScript += "<script type=text/javascript>";

            strScript += "function ShowReport(strRptNames,strSFs,strPMs,strConditon)";
            strScript += "{";
            strScript += "var tempRptArray=new Array();";
            strScript += "var tempSFArray=new Array();";
            strScript += "var tempPMArray=new Array();";

            strScript += "tempRptArray = strRptNames.split('/');";

            strScript += "tempSFArray = strSFs.split('_');";
            strScript += "tempPMArray= strPMs.split('/');";

            strScript += "var condArray=new Array();";
            strScript += "condArray=strConditon.split('/');";
            //No Condition
            //strScript += "if(strConditon=='')";
            //strScript += "{";        
            //strScript += "for(var z=0;z<tempRptArray.length;z++)";
            //    strScript += "{";
            //    strScript += "OpenWindow(tempRptArray[z],tempSFArray[z],tempPMArray[z]);";
            //    strScript += "}";
            //strScript += "}";

            ////When Give condition
            //strScript += "else";
            //strScript += "{";
            strScript += "for(var z=0;z<tempRptArray.length;z++)";
            strScript += "{";
            strScript += "if(condArray[z]!=null && condArray[z] !='')";
            strScript += "{";
            strScript += "";
            strScript += "var tempArray=condArray[z].split('=');";
            strScript += "var tempCtrlValue= GetControlValue(tempArray[0]);";
            strScript += "var tempCond3= GetControlValue(tempArray[1]);";

            strScript += "var RptArray = tempRptArray[z].split('^');";

            strScript += "var SFArray = tempSFArray[z].split('^');";
            strScript += "var PMArray= tempPMArray[z].split('^');";

            //Condition Start    
            strScript += "var Condflag=0;";

            strScript += "if(tempArray.length==3)";
            strScript += "{";
            strScript += "switch(tempArray[2])";
            strScript += "{";
            strScript += "case '0':";
            strScript += "if(tempCtrlValue.toString() == tempCond3.toString())";
            strScript += "{Condflag=1;}";
            strScript += "break;";
            strScript += "case '1':";
            strScript += "if(tempCtrlValue.toString() != tempCond3.toString())";
            strScript += "{Condflag=1;}";
            strScript += "break;";
            strScript += "case '2':";
            strScript += "if(tempCtrlValue < tempCond3)";
            strScript += "{Condflag=1;}";
            strScript += "break;";
            strScript += "case '3':";
            strScript += "if(tempCtrlValue > tempCond3)";
            strScript += "{Condflag=1;}";
            strScript += "break;";
            strScript += "case '4':";
            strScript += "if(tempCtrlValue <= tempCond3)";
            strScript += "{Condflag=1;}";
            strScript += "break;";
            strScript += "case '5':";
            strScript += "if(tempCtrlValue >= tempCond3)";
            strScript += "{Condflag=1;}";
            strScript += "break;";
            strScript += "}";
            strScript += "if(Condflag==1)";
            strScript += "{";
            strScript += "OpenWindow(RptArray[0],SFArray[0],PMArray[0]);";
            strScript += "}";
            strScript += "else";
            strScript += "{";
            strScript += "OpenWindow(RptArray[1],SFArray[1],PMArray[1]);";
            strScript += "}";
            strScript += "}";


            strScript += "else if(tempCtrlValue.toString() == tempCond3.toString())";
            strScript += "{";
            strScript += "if(RptArray[0]!=''){";
            strScript += "OpenWindow(RptArray[0],SFArray[0],PMArray[0]);";
            strScript += "}break;";
            strScript += "}";

            strScript += "else";
            strScript += "{";
            strScript += "if(RptArray.length>1)";
            strScript += "{";
            strScript += "OpenWindow(RptArray[1],SFArray[1],PMArray[1]);";
            strScript += "break;";
            strScript += "}";
            strScript += "}";

            strScript += "}";

            strScript += "else{OpenWindow(tempRptArray[z],tempSFArray[z],tempPMArray[z]);}";
            //Condition End
            strScript += "}";//For Loop End
            //strScript += "}"; //When Give condition end
            strScript += "return true;";
            strScript += "}";

            strScript += "function OpenWindow(rptName,sf,pmtr)";
            strScript += "{";
            // strScript += "document.cookie='SFormula=' + CreateSF(sf);";
            // strScript += "document.cookie='Parameter=' +CreatePM(pmtr);";
            // strScript += "document.cookie='RFName=' + rptName;";

            strScript += "window.open('ReportView.aspx?SFormula='+CreateSF(sf)+'&Parameter='+CreatePM(pmtr)+'&RFName=' + rptName+'&bid=" + intTempBranchID + "');";
            strScript += "}";


            strScript += "function CreateSF(formula)";
            strScript += "{";
            strScript += "var temp='';";
            strScript += "if(formula==''){strTemp='';}";
            strScript += "else{";
            strScript += "var tempArray=new Array();";
            strScript += "tempArray=formula.split(',');";
            strScript += "var strTemp='';";
            strScript += "for(var i=0;i<tempArray.length;i++)";
            strScript += "{";
            strScript += "temp=GetValue(tempArray[i]);";
            strScript += "if(strTemp!='' && temp!='')";
            strScript += "{strTemp +=' and '}";
            strScript += "strTemp +=temp;";
            strScript += "}";
            strScript += "}";
            strScript += "return strTemp;";
            strScript += "}";

            strScript += "function GetValue(ctrl)";
            strScript += "{";
            strScript += "var temp='';";
            strScript += "var temparray=new Array();";
            strScript += "temparray=ctrl.split('~');";
            strScript += "var cntrlPosition;";
            strScript += "cntrlPosition = ControlPosition(temparray[1]); ";
            strScript += "var tempValue;";
            strScript += "if(cntrlPosition == -1)";
            strScript += "{";
            strScript += "tempValue = temparray[1];";
            strScript += "}";
            strScript += "else";
            strScript += "{ ";
            strScript += "var tempCtrl= document.forms[0].elements[cntrlPosition];";
            strScript += "tempValue = tempCtrl.value; ";
            strScript += "}";
            strScript += "if(tempValue!='')";
            strScript += "{";
            strScript += "temp +='{';";
            strScript += "temp +=temparray[0];";
            strScript += "temp +='}';";
            strScript += "temp +=temparray[3];";
            strScript += "if(temparray[2]=='Text')";
            strScript += "{";
            strScript += "temp+=String.fromCharCode(39)+tempValue+String.fromCharCode(39);";
            strScript += "}";
            strScript += "else if(temparray[2]=='Date')";
            strScript += "{if(tempValue=='isnull'){temp='IsNull(({'+temparray[0]+'}))';} else{ temp+='Date('+GetDate(tempValue)+')';   }}";
            strScript += "else ";
            strScript += "{temp+=tempValue;}";
            strScript += "}";
            strScript += "return temp;";
            strScript += "}";


            strScript += "function ControlPosition(ctrlName)";
            strScript += "{";
            strScript += "var intResult=-1;";
            strScript += "for(var i=0;i<document.forms[0].elements.length;i++)";
            strScript += "{";
            strScript += "var ctrlNameWotDoll;";
            strScript += "var temp=new Array();";
            strScript += "temp=document.forms[0].elements[i].name.split('$');";
            strScript += "if(temp.length>3) ";
            strScript += "{ctrlNameWotDoll = temp[temp.length-2];}";
            strScript += "else";
            strScript += "{ctrlNameWotDoll = temp[temp.length-1];}";
            //strScript += "alertify.alert(ctrlNameWotDoll +'='+i);";
            strScript += "if(ctrlNameWotDoll== ctrlName)";
            strScript += "{";
            strScript += "intResult = i;";
            strScript += "break; ";
            strScript += "} ";
            strScript += "}";
            strScript += "return intResult;  ";
            strScript += "}";


            strScript += "function GetControlValue(strCtrlName)";
            strScript += "{";
            strScript += "var tempValue;";
            strScript += "var tempCtrl,ctrlPosition;";
            strScript += "if(isNaN(strCtrlName))";
            strScript += "{";
            strScript += "ctrlPosition=ControlPosition(strCtrlName);";
            strScript += "}";
            strScript += "else";
            strScript += "{ctrlPosition = strCtrlName;}";
            strScript += "if(ctrlPosition!='' && ctrlPosition!=-1)";
            strScript += "{";
            strScript += "tempCtrl = document.forms[0].elements[ctrlPosition];";
            strScript += "switch(tempCtrl.type)";
            strScript += "{";
            strScript += "case 'radio':";
            strScript += "tempValue=tempCtrl.checked;";
            strScript += "break;";
            strScript += "case 'checkbox':";
            strScript += "tempValue=tempCtrl.checked;";
            strScript += "break;";
            strScript += "case 'select-one':";
            strScript += "tempValue=tempCtrl.options[tempCtrl.selectedIndex];";
            strScript += "break;";
            strScript += "default:";
            strScript += "tempValue=tempCtrl.value;";
            strScript += "break;";
            strScript += "}";
            strScript += "if(tempCtrl==null){tempValue=strCtrlName;}";
            strScript += "}";
            strScript += "else {tempValue=strCtrlName;}";
            strScript += "return tempValue;";
            strScript += "}";

            strScript += "function GetDate(dat)";
            strScript += "{";
            strScript += "var temp='';";
            strScript += "if(dat!='')";
            strScript += "{";
            strScript += "var tmpArray=new Array();";
            strScript += "tmpArray=dat.split('/');";
            strScript += "if(tmpArray.length>2)";
            strScript += "{";
            strScript += "temp+=tmpArray[2]+','+tmpArray[1]+','+tmpArray[0];";
            strScript += "}";
            strScript += "else";
            strScript += "{";
            strScript += "temp=dat;";
            strScript += "}";

            strScript += "}";
            strScript += "return temp;";
            strScript += "}";


            strScript += "function CreatePM(formula)";
            strScript += "{";
            strScript += "var temp='';";
            strScript += "if(formula==''){strTemp='';}";
            strScript += "else{";
            strScript += "var tempArray=new Array();";
            strScript += "tempArray=formula.split('~');";
            strScript += "var strTemp='';";
            strScript += "for(var i=0;i<tempArray.length;i++)";
            strScript += "{";
            strScript += "temp=GetPMValue(tempArray[i]);";
            strScript += "if(strTemp!='' && temp!='')";
            strScript += "{strTemp +='~'}";
            strScript += "strTemp +=temp;";
            strScript += "}";
            strScript += "}";

            strScript += "return strTemp;";
            strScript += "}";


            strScript += "function GetPMValue(ctrl)";
            strScript += "{";
            strScript += "var temp='';";
            strScript += "var mpmArray=new Array();";
            strScript += "mpmArray=ctrl.split('+');";
            strScript += "for(var i=0;i<mpmArray.length;i++)";
            strScript += "{";
            strScript += "var temparray=new Array();";
            strScript += "temparray=mpmArray[i].split('=');";
            strScript += "var cntrlPosition;";
            strScript += "cntrlPosition = ControlPosition(temparray[1]); ";
            strScript += "var tempValue;";
            strScript += "if(cntrlPosition == -1)";
            strScript += "{";
            strScript += "tempValue = temparray[1];";
            strScript += "}";
            strScript += "else";
            strScript += "{ ";
            strScript += "var tempCtrl= document.forms[0].elements[cntrlPosition];";
            strScript += "tempValue = tempCtrl.value;";
            strScript += "}";
            strScript += "if(tempValue!='')";
            strScript += "{";
            strScript += "if(i==0)";
            strScript += "{";
            strScript += "temp +=temparray[0];";
            strScript += "temp +='=';";
            strScript += "}";
            strScript += " if(temparray.length>2)";
            strScript += "{";
            strScript += "if(temparray[2]=='Date')";
            strScript += "{temp+=GetPMDate(tempValue);}";
            strScript += "else ";
            strScript += "{temp+=tempValue;}";
            strScript += "}";
            strScript += "else";
            strScript += "{";
            strScript += "temp+=tempValue;";
            strScript += "}";
            strScript += "}";
            //strScript += "alertify.alert(temp);";
            strScript += "}";//for loop end

            strScript += "return temp;";
            strScript += "}";


            strScript += "function GetPMDate(dat)";
            strScript += "{";
            strScript += "var temp='';";
            strScript += "if(dat!='')";
            strScript += "{";
            strScript += "var tmpArray=new Array();";
            strScript += "tmpArray=dat.split('/');";
            strScript += "temp+=tmpArray[1]+','+tmpArray[0]+','+tmpArray[2];";
            strScript += "}";
            strScript += "return temp;";
            strScript += "}";

            strScript += "</script>";
            return strScript;
        }
    }
}