
Public Class Form1
    Dim myalien, myalien2 As Alien
    Dim alienArmy(9) As Alien
    Dim spacegun As Gun
    Dim touchedRWall As Boolean = False
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        myalien = New Alien(50, 50)
        myalien2 = New Alien(50, 150)

        For i = 0 To 9
            alienArmy(i) = New Alien(90, 50 * i + 20)
        Next
        spacegun = New Gun(100, 100)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        myalien.MoveLeft(10)
        myalien2.MoveLeft(10)
        For i = 0 To 9
            alienArmy(i).MoveLeft(5)
        Next
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'check if touching either edge
        If alienArmy(9).Left > 640 And touchedRWall = False Then
            touchedRWall = True
            'shift down by 10 when touching wall
            For i = 0 To 9
                alienArmy(i).Top = alienArmy(i).Top + 30
            Next
        ElseIf alienArmy(0).Left < 0 And touchedRWall = True Then
            touchedRWall = False
            'shift down by 10 when touching wall
            For i = 0 To 9
                alienArmy(i).Top = alienArmy(i).Top + 30
            Next
        End If
        If touchedRWall = True Then
            myalien.MoveRight(10)
            myalien2.MoveRight(10)
            For i = 0 To 9
                alienArmy(i).MoveRight(5)
            Next
        Else
            myalien.MoveLeft(10)
            myalien2.MoveLeft(10)
            For i = 0 To 9
                alienArmy(i).MoveLeft(5)
            Next
        End If
    End Sub
End Class
Class Alien
    Inherits PictureBox
    Dim speed As Integer

    Sub New(ByVal Top As Integer, ByVal Left As Integer)
        Me.Image = Image.FromFile("Space Invader.png")
        Me.Visible = True
        Me.Top = Top
        Me.Left = Left
        Me.Width = 40
        Me.Height = 38
        Form1.Controls.Add(Me) 'don't forget to add it to the form!!!
    End Sub
    Sub MoveLeft(ByVal amount)
        Me.Left = Me.Left + amount
    End Sub
    Sub MoveRight(ByVal amount)
        Me.Left = Me.Left - amount
    End Sub

End Class

Class Gun
    Inherits PictureBox
    Dim speed As Integer

    Sub New(ByVal Top As Integer, ByVal Left As Integer)
        Me.Image = Image.FromFile("Gun.jpg")
        Me.Visible = True
        Me.Top = Top
        Me.Left = Left
        Me.Width = 50
        Me.Height = 50
        Form1.Controls.Add(Me) 'don't forget to add it to the form!!!
    End Sub
    

End Class