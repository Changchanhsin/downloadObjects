Public Class frmSet
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        frmDownloadObjects.sPattern = txtPattern.Text
        Me.Close()
    End Sub
End Class