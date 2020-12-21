Public Class Class_Controls
    Public Sub SetComboboxSource(ByRef Combo As ComboBox, ByRef Source As DataTable, ByVal Field As String)
        Dim StrSplit() As String = Field.Split("|")

        Combo.DataSource = Source

        Select Case StrSplit.Count
            Case 1
                Combo.DisplayMember = StrSplit(0)
                Combo.ValueMember = StrSplit(0)
            Case 2
                Combo.DisplayMember = StrSplit(1)
                Combo.ValueMember = StrSplit(0)
        End Select

        Combo.Items.Insert(0, String.Empty)

    End Sub
End Class
