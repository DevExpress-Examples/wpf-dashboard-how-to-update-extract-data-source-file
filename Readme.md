<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/197230858/19.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T828605)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# WPF Dashboard - How to Update the Extract Data File

This example demonstrates how to update the extract data file at runtime.

![screenshot](/images/screenshot.png)

The application creates a copy of the dashboard, calls the [DashboardExtractDataSource.UpdateExtractFile](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardExtractDataSource.UpdateExtractFile) method to update the Extract data and saves the updated file with a different name because the original data file is locked. Subsequently the [DashboardViewer.ReloadData](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.ReloadData) method call triggers the [DashboardViewer.ConfigureDataConnection](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.ConfigureDataConnection) event. The event occurs before a dashboard binds to the data source, and the event handler copies the updated extract data file over the working data file.
