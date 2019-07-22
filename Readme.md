# WPF Dashboard - How to Update the Extract Data File

This example demonstrates how to update the extract data file at runtime.

![screenshot](/images/screenshot.png)

The application creates a copy of the dashboard, calls the [ashboardExtractDataSource.UpdateExtractFile](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardExtractDataSource.UpdateExtractFile) method to update the Extract data and saves the updated file with a different name because the original data file is locked. Subsequently the [DashboardViewer.ReloadData](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.ReloadData) method is called. The [DashboardViewer.ConfigureDataConnection](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.ConfigureDataConnection) event occurs before a dashboard binds to the data source, and the event handler copies the updated extract data file over the working data file.
