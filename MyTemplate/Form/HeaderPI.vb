﻿Public Class HeaderPI 
    Private Sub FormTemplate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSetSPPK.PIHeader_Select' table. You can move, or remove it, as needed.
        Me.PIHeader_SelectTableAdapter.Fill(Me.DataSetSPPK.PIHeader_Select)
        SetFormAttribute()

        'CanClose = True
        'LoadData()

    End Sub
    Sub SaveData()
        Me.Validate()
        Me.PIHeader_SelectBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DataSetSPPK)
    End Sub
    Sub LoadData()
        Me.PIHeader_SelectTableAdapter.Fill(Me.DataSetSPPK.PIHeader_Select)
        GridView1.Columns(0).Visible = False
    End Sub
    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        If XtraMessageBox.Show("Apakah anda yakin akan menghapus data ini", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim row() As Integer = GridView1.GetSelectedRows
            If row.Count > 0 Then
                PIHeader_SelectBindingSource.RemoveCurrent()
                SaveData()
                LoadData()
            End If
        End If
    End Sub
    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        SaveData()
        SetMessage("Data Has Been Saved")
    End Sub

    Private Sub ButtonDetail_Click(sender As Object, e As EventArgs) Handles ButtonDetail.Click
        DetailPI.ShowDialog()
    End Sub
End Class