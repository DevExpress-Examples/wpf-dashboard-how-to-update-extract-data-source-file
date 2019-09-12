using System.Windows;

namespace UpdateExtractDataSourceExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DevExpress.Xpf.Core.ThemedWindow
    {
        delegate void SafeUpdate(string file);
        public MainWindow() {
            InitializeComponent();
            dashboardControl1.LoadDashboard("update_data_extract_dashboard.xml");
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            dashboardControl1.UpdateExtractDataSourcesAsync((a, b) => { OnDataReady(a); }, (a, __) => { MessageBox.Show($"File {a} updated "); });
        }

        void OnDataReady(string fileName)
        {
            dashboardControl1.Dispatcher.Invoke(new SafeUpdate(UpdateViewer), new object[] { fileName });
        }
        void UpdateViewer(string fileName)
        {
            MessageBox.Show($"Data for the file {fileName} is ready ");
            dashboardControl1.ReloadData();
        }
    }
}