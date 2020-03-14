Public Class Report

    Private Slack As New SlackClient("https://hooks.slack.com/services/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")

    Private Sub SendBugReport()
        For Each Ctrl As Object In GroupBox_BugReport.Controls
            If Ctrl.GetType() Is GetType(TextBox) Then
                If Ctrl.Text = "" Or Ctrl.Text = Ctrl.AccessibleDescription Then
                    MsgBox("Please fill all the fields", MsgBoxStyle.Exclamation, "Warning")
                    Exit Sub
                End If
            End If
        Next
        Dim _Payload As New Payload
        _Payload.Channel = "general"
        _Payload.Username = "ekampourakis"

        _Payload.Text = "New bug report from " & TextBox_BugName.Text & " for version "
        With My.Application.Info.Version
            _Payload.Text &= "V" & .Major & "." & .Minor & "." & .Build & "." & .Revision & vbNewLine & vbNewLine
        End With
        _Payload.Text &= "Bug Summary: " & TextBox_BugSummary.Text & vbNewLine & vbNewLine
        _Payload.Text &= "Bug Description: " & TextBox_BugDescription.Text
        Slack.PostMessage(_Payload)
        MsgBox("Bug reported", MsgBoxStyle.Information, "Success")
    End Sub

    Private Sub SendSuggestion()
        For Each Ctrl As Object In GroupBox_FeatureSuggest.Controls
            If Ctrl.GetType() Is GetType(TextBox) Then
                If Ctrl.Text = "" Or Ctrl.Text = Ctrl.AccessibleDescription Then
                    MsgBox("Please fill all the fields", MsgBoxStyle.Exclamation, "Warning")
                    Exit Sub
                End If
            End If
        Next
        Dim _Payload As New Payload
        _Payload.Channel = "general"
        _Payload.Username = "ekampourakis"
        _Payload.Text = "New feature suggestion from " & TextBox_FeatureName.Text & " for version "
        With My.Application.Info.Version
            _Payload.Text &= "V" & .Major & "." & .Minor & "." & .Build & "." & .Revision & vbNewLine & vbNewLine
        End With
        _Payload.Text &= "Feature Summary: " & TextBox_FeatureSummary.Text & vbNewLine & vbNewLine
        _Payload.Text &= "Feature Description: " & TextBox_FeatureDescription.Text
        Slack.PostMessage(_Payload)
        MsgBox("Feature suggested", MsgBoxStyle.Information, "Success")
    End Sub

    Private Sub Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each Ctrl As Object In GroupBox_BugReport.Controls
            If Ctrl.GetType() Is GetType(TextBox) Then
                Ctrl.AccessibleDescription = Ctrl.Text
            End If
        Next
        For Each Ctrl As Object In GroupBox_FeatureSuggest.Controls
            If Ctrl.GetType() Is GetType(TextBox) Then
                Ctrl.AccessibleDescription = Ctrl.Text
            End If
        Next
    End Sub

    Private Sub TextBox_Leave(sender As Object, e As EventArgs) Handles TextBox_FeatureSummary.Leave, TextBox_FeatureName.Leave, TextBox_FeatureDescription.Leave,
        TextBox_BugSummary.Leave, TextBox_BugName.Leave, TextBox_BugDescription.Leave

        If sender.Text = "" Then
            sender.Text = sender.AccessibleDescription
            sender.ForeColor = SystemColors.ControlDark
        End If
    End Sub

    Private Sub TextBox_Enter(sender As Object, e As EventArgs) Handles TextBox_FeatureSummary.Enter, TextBox_FeatureName.Enter, TextBox_FeatureDescription.Enter,
        TextBox_BugSummary.Enter, TextBox_BugName.Enter, TextBox_BugDescription.Enter

        If sender.Text = sender.AccessibleDescription Then
            sender.Text = ""
            sender.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub Button_ReportBug_Click(sender As Object, e As EventArgs) Handles Button_ReportBug.Click
        SendBugReport()
    End Sub

    Private Sub Button_SuggestFeature_Click(sender As Object, e As EventArgs) Handles Button_SuggestFeature.Click
        SendSuggestion()
    End Sub
End Class