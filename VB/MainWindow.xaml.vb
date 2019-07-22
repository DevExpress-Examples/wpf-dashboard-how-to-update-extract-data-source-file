Imports DevExpress.DashboardCommon
Imports System.IO
Imports System.Windows

Namespace UpdateExtractDataSourceExample
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits DevExpress.Xpf.Core.ThemedWindow

		Public Sub New()
			InitializeComponent()
			dashboardControl1.LoadDashboard("update_data_extract_dashboard.xml")
		End Sub

		Private Sub dashboardControl1_ConfigureDataConnection(ByVal sender As Object, ByVal e As DashboardConfigureDataConnectionEventArgs)
			Dim parameters As ExtractDataSourceConnectionParameters = TryCast(e.ConnectionParameters, ExtractDataSourceConnectionParameters)
			If parameters IsNot Nothing Then
				Dim current As String = parameters.FileName
				Dim updated As String = parameters.FileName & "_updated"
				If File.Exists(updated) Then
					File.Delete(current)
					File.Copy(updated, current)
					File.Delete(updated)
				End If
			End If
		End Sub

		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim dashboard As New Dashboard()
			dashboard.LoadFromXDocument(dashboardControl1.Dashboard.SaveToXDocument())
			Dim extract As DashboardExtractDataSource = TryCast(dashboard.DataSources.FindFirst(Function(d) TypeOf d Is DashboardExtractDataSource), DashboardExtractDataSource)
			extract.FileName &= "_updated"
			extract.UpdateExtractFile()
			dashboard.Dispose()
			dashboardControl1.ReloadData()
		End Sub
	End Class
End Namespace