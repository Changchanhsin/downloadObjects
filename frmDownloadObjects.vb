Imports System.Net

Public Class frmDownloadObjects

    Public sPattern As String
    Private WithEvents myWebclient As New WebClient
    Private iProcess As Integer
    Private a

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub SetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetToolStripMenuItem.Click
        frmSet.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click
        'Try
        a = Split(sPattern, vbCrLf)
            Me.Text = "Download Objects - " & UBound(a) + 1 & " files"
            iProcess = LBound(a)

            'For i = LBound(a) To UBound(a)
            'webMain.Navigate(a(i))
            Me.Text = "Download Objects - [" & iProcess + 1 & "] " & a(iProcess)
            'Do Until webMain.ReadyState = WebBrowserReadyState.Complete
            'Application.DoEvents()
            'Loop
            myWebclient = New WebClient()
            myWebclient.DownloadFileAsync(New Uri(a(iProcess)), iProcess)
            'Next
        'Catch

        'End Try
    End Sub

    Private Sub StopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopToolStripMenuItem.Click
        myWebclient.CancelAsync()
    End Sub

    Private Sub myWebclient_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles myWebclient.DownloadFileCompleted
        iProcess = iProcess + 1
        If (iProcess <= UBound(a)) Then
            Me.Text = "Download Objects - [" & iProcess + 1 & "] " & a(iProcess)
            myWebclient = New WebClient()
            myWebclient.DownloadFileAsync(New Uri(a(iProcess)), iProcess)
        End If
    End Sub

    Private Sub myWebclient_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles myWebclient.DownloadProgressChanged
        Me.Text = CStr(e.UserState) & "    downloaded " & e.BytesReceived & " of " & e.TotalBytesToReceive & " bytes. " & e.ProgressPercentage & " % complete..."
    End Sub
End Class
