Imports System.Windows

Namespace UpdateExtractDataSourceExample
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits DevExpress.Xpf.Core.ThemedWindow

		Private Delegate Sub SafeUpdate(ByVal file As String)
		Public Sub New()
			InitializeComponent()
			dashboardControl1.LoadDashboard("update_data_extract_dashboard.xml")
		End Sub

		Private Async Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Await dashboardControl1.UpdateExtractDataSourcesAsync(
				Sub(fileName, result)
					OnDataReady(fileName)
				End Sub,
				Sub(fileName, result)
					MessageBox.Show($"File {fileName} updated ")
				End Sub)
		End Sub

		Private Sub OnDataReady(ByVal fileName As String)
			dashboardControl1.Dispatcher.Invoke(New SafeUpdate(AddressOf UpdateViewer), New Object() {fileName})
		End Sub
		Private Sub UpdateViewer(ByVal fileName As String)
			MessageBox.Show($"Data for the file {fileName} is ready ")
			dashboardControl1.ReloadData()
		End Sub
	End Class
End Namespace