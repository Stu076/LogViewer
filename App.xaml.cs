using LogViewer.UILayer;
using System;
using System.Windows;

namespace LogViewer
{
    public partial class App : Application
    {
        private DependencyContainer dependencies = new DependencyContainer();

        public App()
        {
            var logEntriesView = new LogEntriesView(dependencies);
            logEntriesView.Show();
        }
    }
}
