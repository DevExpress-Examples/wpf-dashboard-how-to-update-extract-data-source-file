using DevExpress.DashboardCommon;
using System.IO;
using System.Windows;

namespace UpdateExtractDataSourceExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DevExpress.Xpf.Core.ThemedWindow
    {
        public MainWindow() {
            InitializeComponent();
            dashboardControl1.LoadDashboard(@"update_data_extract_dashboard.xml");
        }

        private void dashboardControl1_ConfigureDataConnection(object sender, DashboardConfigureDataConnectionEventArgs e) {
            ExtractDataSourceConnectionParameters parameters = e.ConnectionParameters as ExtractDataSourceConnectionParameters;
            if(parameters != null) {
                string current = parameters.FileName;
                string updated = parameters.FileName + "_updated";
                if(File.Exists(updated)) {
                    File.Delete(current);
                    File.Copy(updated, current);
                    File.Delete(updated);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Dashboard dashboard = new Dashboard();
            dashboard.LoadFromXDocument(dashboardControl1.Dashboard.SaveToXDocument());
            DashboardExtractDataSource extract = dashboard.DataSources.FindFirst(d => d is DashboardExtractDataSource) as DashboardExtractDataSource;
            extract.FileName += "_updated";
            extract.UpdateExtractFile();
            dashboard.Dispose();
            dashboardControl1.ReloadData();
        }
    }
}