Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO


Public Class Class1
    Dim dtCustomEDI As New DataTable
    Dim dtCustomEDI1 As New DataTable
    Dim dtCustomEDI2 As New DataTable
    Dim strtrantype As String = ""
    Dim i As Integer
    Dim strVesInfo As String = ""
    Dim strCargoInfo As String = ""
    Dim strContainerInfo As String = ""
    Dim index As Integer
    Dim intjobno As Integer
    Public submenuname As String
    Dim strCVslcode As String = ""
    Dim strVoyage As String = ""
    Dim jobtype As String = ""
    Dim linecode As String = ""
    Dim Lineno As String = ""
    Dim sublineno As String = ""
    Dim strmblno As String = ""
    Dim mbldate As Date
    Dim strimno As String = ""
    Dim imdate As Date
    Dim intpol As Integer
    Dim strpol As String = ""
    Dim intfd As Integer
    Dim strfd As String = ""
    Dim intpod As Integer
    Dim blno As String = ""
    Dim bldate As Date
    Dim consigneeid As Integer
    Dim consignee As String = ""
    Dim consigneeadd1 As String = ""
    Dim consigneeadd2 As String = ""
    Dim consigneeadd3 As String = ""
    Dim cargo As String = ""
    Dim itemtype As String = ""
    Dim cfscode As String = ""
    Dim noofpkgs As Integer
    Dim intpkg As Integer
    Dim pkgtype As String = ""
    Dim weight As Double
    Dim marks As String = ""
    Dim desc As String = ""
    Dim unicode As String = ""
    Dim imocode As String = ""
    Dim type As String = ""
    Dim imdateyear As Integer
    Dim notifyid As Integer
    Dim notify As String = ""
    Dim cardno As String = ""
    Dim TW As System.IO.TextWriter
    Dim callsign As String = ""
    Dim polcode As String = ""
    Dim strvesselname As String = ""
    Dim strpod As String = ""
    Dim podcode As String = ""
    Dim grt As String = ""
    Dim nrt As String = ""
    Dim clinecode As String = ""
    Dim strCallSign As String = ""
    Dim strimocode As String
    Dim strdesc As String = ""


    Dim customcode As String = ""

    'Dim cmobj As New DataAccess.ForwardingImports.CargoManifest
    Dim dtpan As New DataTable
    Dim panno As String = ""
    Dim loginpcode As String = ""
    Dim igmjob As String
    Dim intjobtype As String
    Dim ediuser As String = ""


    Dim cfspanno As String = ""
    Dim cfsstno As String = ""
    Dim mlopanno As String = ""
    Dim mlostno As String = ""

    Public intbranch As Integer
    Public intdivid As Integer
    Public strbranch As String

    Dim Objfso

    Public Function GetIGM1point5VesselInfo(str_ediuser As String, str_loginpcode As String, str_igmjob As String) As String
        'new changes
        strVesInfo = ""
        strVesInfo = strVesInfo & "HREC"
        strVesInfo = strVesInfo & Chr(29)
        strVesInfo = strVesInfo & "ZZ"
        strVesInfo = strVesInfo & Chr(29)
        strVesInfo = strVesInfo & str_ediuser.Trim()
        strVesInfo = strVesInfo & Chr(29)
        strVesInfo = strVesInfo & "ZZ"
        strVesInfo = strVesInfo & Chr(29)
        strVesInfo = strVesInfo & str_loginpcode.Trim()
        strVesInfo = strVesInfo & Chr(29)
        strVesInfo = strVesInfo & "ICES1_5"
        strVesInfo = strVesInfo & Chr(29)
        strVesInfo = strVesInfo & "P"
        strVesInfo = strVesInfo & Chr(29)
        strVesInfo = strVesInfo & Chr(29)
        strVesInfo = strVesInfo & "CMCHI21"
        strVesInfo = strVesInfo & Chr(29)
        strVesInfo = strVesInfo & str_igmjob.Trim()
        strVesInfo = strVesInfo & Chr(29)
        strVesInfo = strVesInfo & Format(Today, "yyyyMMdd")
        strVesInfo = strVesInfo & Chr(29)
        strVesInfo = strVesInfo & Format(TimeOfDay(), "HHmm")
        strVesInfo = strVesInfo & vbCrLf
        strVesInfo = strVesInfo & "<consoligm>"
        strVesInfo = strVesInfo & vbCrLf
        strVesInfo = strVesInfo & "<conscargo>"
        Return strVesInfo
        'TW.WriteLine(strVesInfo)
        'TW.Flush()
    End Function

    Public Function GetIGMDesc(desc As String) As String
        strdesc = desc.ToString().Replace(vbCrLf, "") '30 CHRS
        strdesc = Mid(Trim(desc), 1, 30)
        Return strdesc
    End Function

    Public Function GetIGM1point5CargoInfoCons(intcons As Integer, consignee As String, caddress As String) As String

        strCargoInfo = ""
        consigneeid = intcons.ToString()
        'consignee = ""
        consignee = Trim(consignee)
        consignee = Trim(caddress.Replace(vbCrLf, ""))
        Dim cons As String = ""
        cons = Replace(consignee, Chr(13), " ")
        cons = Replace(cons, Chr(10), " ")
        If Len(cons) > 105 Then
            strCargoInfo = Trim(cons.Substring(0, 35)).Replace(vbCrLf, "")
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(cons, 36, 35)).Replace(vbCrLf, "")
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(cons, 71, 35)).Replace(vbCrLf, "")
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(cons, 106, 35)).Replace(vbCrLf, "")
        ElseIf Len(cons) > 70 And Len(cons) <= 105 Then
            strCargoInfo = Trim(cons.Substring(0, 20)).Replace(vbCrLf, "")
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(cons, 21, 20)).Replace(vbCrLf, "")
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(cons, 41, 30)).Replace(vbCrLf, "")
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(cons, 71, 35)).Replace(vbCrLf, "")
        ElseIf Len(cons) > 35 And Len(cons) <= 70 Then
            strCargoInfo = Trim(cons.Substring(0, 10)).Replace(vbCrLf, "")
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(cons, 11, 10)).Replace(vbCrLf, "")
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(cons, 21, 15)).Replace(vbCrLf, "")
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(cons, 36, 35)).Replace(vbCrLf, "")
        ElseIf Len(cons) <= 35 Then
            If Len(cons) > 10 Then
                strCargoInfo = Trim(cons.Substring(0, 10)).Replace(vbCrLf, "")
                strCargoInfo = strCargoInfo & Chr(29)
                strCargoInfo = strCargoInfo & Trim(Mid(cons, 11, 10)).Replace(vbCrLf, "")
                strCargoInfo = strCargoInfo & Chr(29)
                strCargoInfo = strCargoInfo & Trim(Mid(cons, 21, 10)).Replace(vbCrLf, "")
                strCargoInfo = strCargoInfo & Chr(29)
                strCargoInfo = strCargoInfo & Trim(Mid(cons, 31, 5)).Replace(vbCrLf, "")
            Else
                strCargoInfo = Trim(cons).Replace(vbCrLf, "")
                strCargoInfo = strCargoInfo & Chr(29)
                strCargoInfo = strCargoInfo & "."
                strCargoInfo = strCargoInfo & Chr(29)
                strCargoInfo = strCargoInfo & "."
                strCargoInfo = strCargoInfo & Chr(29)
                strCargoInfo = strCargoInfo & "."
            End If
        End If



        'strCargoInfo = strCargoInfo & Chr(29)
        Return strCargoInfo
        'TW.WriteLine(strCargoInfo)
        'TW.Flush()

        'strCargoInfo = ""
        'strCargoInfo = strCargoInfo & "<END-conscargo>"
        'TW.WriteLine(strCargoInfo)
        'TW.Flush()
    End Function

    'added on 17Feb2023 'nambi
    Public Function GetIGM1point5CargoInfoConsName(intcons As Integer, consignee As String, caddress As String) As String

        strCargoInfo = ""
        consigneeid = intcons.ToString()

        'consignee = ""
        consignee = Trim(consignee)
        consignee = Replace(consignee, Chr(13), " ")

        'consignee = Trim(caddress.Replace(vbCrLf, ""))
        Dim cons As String = ""
        cons = Replace(caddress, Chr(13), " ")
        cons = Trim(cons.Replace(vbCrLf, ""))
        cons = Replace(cons, Chr(10), " ")

        cons = Replace(cons, consignee, "") ' 4 remove the cong name frm address


        '4 consignee name 1st set
        If Len(consignee) > 35 Then
            strCargoInfo = Trim(consignee.Substring(0, 35)).Replace(vbCrLf, "")
            cons = Trim(Mid(consignee, 36, Len(consignee))).Replace(vbCrLf, "") & " " & cons 'above 35 char consigne and appaned in address column
        Else
            strCargoInfo = Trim(consignee.Substring(0, Len(consignee))).Replace(vbCrLf, "")
        End If
        strCargoInfo = strCargoInfo & Chr(29)

        '4 consignee address
        If Len(cons) > 105 Then
            strCargoInfo = strCargoInfo & Trim(cons.Substring(0, 35)).Replace(vbCrLf, "")
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(cons, 36, 35)).Replace(vbCrLf, "")
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(cons, 71, 35)).Replace(vbCrLf, "")
            strCargoInfo = strCargoInfo & Chr(29)
            'strCargoInfo = strCargoInfo & Trim(Mid(cons, 106, 35)).Replace(vbCrLf, "")
        ElseIf Len(cons) > 70 And Len(cons) <= 105 Then
            strCargoInfo = strCargoInfo & Trim(cons.Substring(0, 35)).Replace(vbCrLf, "")
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(cons, 36, 35)).Replace(vbCrLf, "")
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(cons, 71, Len(cons) - 70)).Replace(vbCrLf, "")
            strCargoInfo = strCargoInfo & Chr(29)
            'strCargoInfo = strCargoInfo & Trim(Mid(cons, 71, 35)).Replace(vbCrLf, "")
        ElseIf Len(cons) > 35 And Len(cons) <= 70 Then
            strCargoInfo = strCargoInfo & Trim(cons.Substring(0, 35)).Replace(vbCrLf, "")
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(cons, 36, Len(cons) - 35)).Replace(vbCrLf, "")
            strCargoInfo = strCargoInfo & Chr(29)
            'strCargoInfo = strCargoInfo & Trim(Mid(cons, 21, 15)).Replace(vbCrLf, "")
            strCargoInfo = strCargoInfo & Chr(29)
            'strCargoInfo = strCargoInfo & Trim(Mid(cons, 36, 35)).Replace(vbCrLf, "")
        ElseIf Len(cons) <= 35 Then
            If Len(cons) = 35 Then
                strCargoInfo = Trim(cons.Substring(0, 35)).Replace(vbCrLf, "")
            Else
                strCargoInfo = Trim(cons.Substring(0, Len(cons))).Replace(vbCrLf, "")
            End If

            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Chr(29)

            If Len(cons) > 10 Then
                strCargoInfo = strCargoInfo & Trim(cons.Substring(0, 10))
                strCargoInfo = strCargoInfo & Chr(29)
                strCargoInfo = strCargoInfo & Trim(Mid(cons, 11, 10))
                strCargoInfo = strCargoInfo & Chr(29)
                strCargoInfo = strCargoInfo & Trim(Mid(cons, 21, 10))
                strCargoInfo = strCargoInfo & Chr(29)
                strCargoInfo = strCargoInfo & Trim(Mid(cons, 31, 5))
            Else
                strCargoInfo = strCargoInfo & Trim(cons)
                strCargoInfo = strCargoInfo & Chr(29)
                strCargoInfo = strCargoInfo & "."
                strCargoInfo = strCargoInfo & Chr(29)
                strCargoInfo = strCargoInfo & "."
                strCargoInfo = strCargoInfo & Chr(29)
                strCargoInfo = strCargoInfo & "."
            End If

        End If



        'strCargoInfo = strCargoInfo & Chr(29)
        Return strCargoInfo
        'TW.WriteLine(strCargoInfo)
        'TW.Flush()

        'strCargoInfo = ""
        'strCargoInfo = strCargoInfo & "<END-conscargo>"
        'TW.WriteLine(strCargoInfo)
        'TW.Flush()

        'strCargoInfo = ""
        'consigneeid = intcons.ToString()

        ''consignee = ""
        'consignee = Trim(consignee)
        'consignee = Replace(consignee, Chr(13), " ")

        ''consignee = Trim(caddress.Replace(vbCrLf, ""))
        'Dim cons As String = ""
        'cons = Replace(caddress, Chr(13), " ")
        'cons = Trim(cons.Replace(vbCrLf, ""))
        'cons = Replace(cons, Chr(10), " ")

        'cons = Replace(cons, consignee, "") ' 4 remove the cong name frm address

        ''4 consignee name 1st set
        'If Len(consignee) > 35 Then
        '    strCargoInfo = Trim(consignee.Substring(0, 35)).Replace(vbCrLf, "")
        'Else
        '    strCargoInfo = Trim(consignee.Substring(0, Len(consignee))).Replace(vbCrLf, "")
        'End If
        'strCargoInfo = strCargoInfo & Chr(29)

        ''4 consignee address
        'If Len(cons) > 105 Then
        '    strCargoInfo = strCargoInfo & Trim(cons.Substring(0, 35)).Replace(vbCrLf, "")
        '    strCargoInfo = strCargoInfo & Chr(29)
        '    strCargoInfo = strCargoInfo & Trim(Mid(cons, 36, 35)).Replace(vbCrLf, "")
        '    strCargoInfo = strCargoInfo & Chr(29)
        '    strCargoInfo = strCargoInfo & Trim(Mid(cons, 71, 35)).Replace(vbCrLf, "")
        '    strCargoInfo = strCargoInfo & Chr(29)
        '    'strCargoInfo = strCargoInfo & Trim(Mid(cons, 106, 35)).Replace(vbCrLf, "")
        'ElseIf Len(cons) > 70 And Len(cons) <= 105 Then
        '    strCargoInfo = strCargoInfo & Trim(cons.Substring(0, 35)).Replace(vbCrLf, "")
        '    strCargoInfo = strCargoInfo & Chr(29)
        '    strCargoInfo = strCargoInfo & Trim(Mid(cons, 36, 35)).Replace(vbCrLf, "")
        '    strCargoInfo = strCargoInfo & Chr(29)
        '    strCargoInfo = strCargoInfo & Trim(Mid(cons, 71, Len(cons) - 70)).Replace(vbCrLf, "")
        '    strCargoInfo = strCargoInfo & Chr(29)
        '    'strCargoInfo = strCargoInfo & Trim(Mid(cons, 71, 35)).Replace(vbCrLf, "")
        'ElseIf Len(cons) > 35 And Len(cons) <= 70 Then
        '    strCargoInfo = strCargoInfo & Trim(cons.Substring(0, 35)).Replace(vbCrLf, "")
        '    strCargoInfo = strCargoInfo & Chr(29)
        '    strCargoInfo = strCargoInfo & Trim(Mid(cons, 36, Len(cons) - 35)).Replace(vbCrLf, "")
        '    strCargoInfo = strCargoInfo & Chr(29)
        '    'strCargoInfo = strCargoInfo & Trim(Mid(cons, 21, 15)).Replace(vbCrLf, "")
        '    strCargoInfo = strCargoInfo & Chr(29)
        '    'strCargoInfo = strCargoInfo & Trim(Mid(cons, 36, 35)).Replace(vbCrLf, "")
        'ElseIf Len(cons) <= 35 Then
        '    If Len(cons) = 35 Then
        '        strCargoInfo = Trim(cons.Substring(0, 35)).Replace(vbCrLf, "")
        '    Else
        '        strCargoInfo = Trim(cons.Substring(0, Len(cons))).Replace(vbCrLf, "")
        '    End If

        '    strCargoInfo = strCargoInfo & Chr(29)
        '    strCargoInfo = strCargoInfo & Chr(29)
        '    strCargoInfo = strCargoInfo & Chr(29)

        'End If



        ''strCargoInfo = strCargoInfo & Chr(29)
        'Return strCargoInfo
        ''TW.WriteLine(strCargoInfo)
        ''TW.Flush()

        ''strCargoInfo = ""
        ''strCargoInfo = strCargoInfo & "<END-conscargo>"
        ''TW.WriteLine(strCargoInfo)
        ''TW.Flush()
    End Function
    Public Function GetIGM1point5CargoInfonotify(int_notifyid As Integer, notifyparty As String, naddress As String, caddress As String) As String

        strCargoInfo = ""
        'consigneeid = int_notifyid.ToString()
        consignee = Trim(caddress.Replace(vbCrLf, ""))
        Dim cons As String = ""
        cons = Replace(consignee, Chr(13), " ")
        cons = Replace(cons, Chr(10), " ")
        ' notifyparty = ""
        notifyparty = Trim(notifyparty)
        notifyparty = Trim(naddress.Replace(vbCrLf, ""))
        Dim nparty As String = ""
        nparty = Replace(notifyparty, Chr(13), " ")
        nparty = Replace(nparty, Chr(10), " ")
        If Len(nparty) > 105 Then
            strCargoInfo = strCargoInfo & Trim(nparty.Substring(0, 35))
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(nparty, 36, 35))
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(nparty, 71, 35))
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(nparty, 106, 35))
        ElseIf Len(nparty) > 70 And Len(cons) <= 105 Then
            strCargoInfo = strCargoInfo & Trim(nparty.Substring(0, 20))
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(nparty, 21, 20))
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(nparty, 41, 30))
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(nparty, 71, 35))
        ElseIf Len(nparty) > 35 And Len(cons) <= 70 Then
            strCargoInfo = strCargoInfo & Trim(nparty.Substring(0, 10))
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(nparty, 11, 10))
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(nparty, 21, 15))
            strCargoInfo = strCargoInfo & Chr(29)
            strCargoInfo = strCargoInfo & Trim(Mid(nparty, 36, 35))
        ElseIf Len(nparty) <= 35 Then
            If Len(nparty) > 10 Then
                strCargoInfo = strCargoInfo & Trim(nparty.Substring(0, 10))
                strCargoInfo = strCargoInfo & Chr(29)
                strCargoInfo = strCargoInfo & Trim(Mid(nparty, 11, 10))
                strCargoInfo = strCargoInfo & Chr(29)
                strCargoInfo = strCargoInfo & Trim(Mid(nparty, 21, 10))
                strCargoInfo = strCargoInfo & Chr(29)
                strCargoInfo = strCargoInfo & Trim(Mid(nparty, 31, 5))
            Else
                strCargoInfo = strCargoInfo & Trim(nparty)
                strCargoInfo = strCargoInfo & Chr(29)
                strCargoInfo = strCargoInfo & "."
                strCargoInfo = strCargoInfo & Chr(29)
                strCargoInfo = strCargoInfo & "."
                strCargoInfo = strCargoInfo & Chr(29)
                strCargoInfo = strCargoInfo & "."
            End If
        End If



        'strCargoInfo = strCargoInfo & Chr(29)
        Return strCargoInfo
        'TW.WriteLine(strCargoInfo)
        'TW.Flush()

        'strCargoInfo = ""
        'strCargoInfo = strCargoInfo & "<END-conscargo>"
        'TW.WriteLine(strCargoInfo)
        'TW.Flush()
    End Function
End Class
