Imports System.Windows.Forms.DataVisualization.Charting

Public Class AreaEditor
    Private Sub AreaEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadChartAreas()
    End Sub

    Private Sub LoadChartAreas()
        For Each Area As ChartArea In Main.Chart.ChartAreas
            ListView.Items.Add(New ListViewItem({Area.Name, "None"}))
        Next
        For Each Series As Series In Main.Chart.Series
            For Each Item As ListViewItem In ListView.Items
                If Item.Text = Series.ChartArea Then
                    Item.SubItems(1).Text = Series.Name
                    Exit For
                End If
            Next
        Next
    End Sub
End Class