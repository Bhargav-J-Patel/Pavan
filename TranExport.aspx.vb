Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports App_Code
Imports Microsoft.VisualBasic
Imports ExcelUtility
Partial Class TranExport
    Inherits System.Web.UI.Page
    Dim cn As New SqlPavanCourier
    Dim ds As New DataSet



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            If Request.QueryString("type") = "DRS" Then
                Lbltxt.Text = "DRS Export"
            End If
            If Request.QueryString("type") = "Manifest" Then
                Lbltxt.Text = "Manifest Export"
            End If
            If Request.QueryString("type") = "Cash" Then
                Lbltxt.Text = "Cash Booking Export"

            End If
            If Request.QueryString("type") = "Credit" Then
                Lbltxt.Text = "Credit Booking Export"
            End If
            Try

                If Request.QueryString("val") = "1" Then
                    ds = cn.RunSql("sp_exportdata '" & Request.QueryString("type") & "','" & txtfromdate.Text & "','" & txttodate.Text & "','','" & Request.Cookies("compid").Value & "','" & Request.Cookies("branchid").Value & "'", "select")
                    If ds.Tables(0).Rows.Count > 0 Then
                        ExcelUtility.DataSetToExcel.Convert(ds.Tables(0), "" & Request.QueryString("type") & "" & Format(Date.Now(), "dd_MM_yyyy_tt_mm") & "")
                    End If
                End If

               
            Catch ex As Exception

            End Try



        End If
    End Sub

    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        If Request.QueryString("type") = "DRS" Then
            ds = cn.RunSql("sp_exportdata '" & Request.QueryString("type") & "','" & txtfromdate.Text & "','" & txttodate.Text & "','','" & Request.Cookies("compid").Value & "','" & Request.Cookies("branchid").Value & "'", "select")

        ElseIf Request.QueryString("type") = "Manifest" Then
            ds = cn.RunSql("sp_exportdata '" & Request.QueryString("type") & "','" & txtfromdate.Text & "','" & txttodate.Text & "','','" & Request.Cookies("compid").Value & "','" & Request.Cookies("branchid").Value & "'", "select")

        ElseIf Request.QueryString("type") = "Cash" Then
            ds = cn.RunSql("sp_exportdata '" & Request.QueryString("type") & "','" & txtfromdate.Text & "','" & txttodate.Text & "','','" & Request.Cookies("compid").Value & "','" & Request.Cookies("branchid").Value & "'", "select")

        ElseIf Request.QueryString("type") = "Credit" Then
            ds = cn.RunSql("sp_exportdata '" & Request.QueryString("type") & "','" & txtfromdate.Text & "','" & txttodate.Text & "','','" & Request.Cookies("compid").Value & "','" & Request.Cookies("branchid").Value & "'", "select")
        ElseIf Request.QueryString("type") = "Destination" Then
            ds = cn.RunSql("sp_exportdata '" & Request.QueryString("type") & "','" & txtfromdate.Text & "','" & txttodate.Text & "','','" & Request.Cookies("compid").Value & "','" & Request.Cookies("branchid").Value & "'", "select")
        End If


        If ds.Tables(0).Rows.Count > 0 Then
            ExcelUtility.DataSetToExcel.Convert(ds.Tables(0), "DownLoadExcel_" & Request.QueryString("type") & "" & Format(Date.Now(), "dd_MM_yyyy_tt_mm") & "")
        End If

    End Sub
End Class
