Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms

Namespace DragControlDemo
	Friend Class DragControl
		Inherits Component

		Private handleControl As Control

		Public Property SelectControl() As Control
			Get
				Return Me.handleControl
			End Get
			Set(ByVal value As Control)
				Me.handleControl = value
				AddHandler handleControl.MouseDown, AddressOf DragForm_MouseDown
			End Set
		End Property
		<DllImport("user32.dll")>
		Public Shared Function SendMessage(ByVal a As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
		End Function
		<DllImport("user32.dll")>
		Public Shared Function ReleaseCapture() As Boolean
		End Function

		Private Sub DragForm_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim flag As Boolean = e.Button = MouseButtons.Left
			If flag Then
				DragControl.ReleaseCapture()
				DragControl.SendMessage(Me.SelectControl.FindForm().Handle,161,2,0)
			End If
		End Sub
	End Class
End Namespace
