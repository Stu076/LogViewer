using LogViewer.DomainLayer.FileList;
using LogViewer.DomainLayer.LogEntry;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LogViewer.UILayer
{
    public interface ILogEntriesDependencies
    {
        public ILogEntriesUseCase LogEntriesUseCase { get; }
        public IFileListUseCase FileListUseCase { get; }
    }
    
    public partial class LogEntriesView : Window
    {
        public ObservableCollection<string> FileNames { get; set; } = null;
        public ObservableCollection<LogEntry> LogEntries { get; set; } = null;

        private readonly LogEntries logEntries;
        private readonly FileList fileList;

        public LogEntriesView(ILogEntriesDependencies dependencies) 
        {
            InitializeComponent();
            DataContext = this;
            logEntries = new LogEntries(dependencies);
            fileList = new FileList(dependencies);
            FileNames = fileList.FileNames;
        }

        private void GetLogEntriesButton_Click(object sender, RoutedEventArgs e)
        {
            string logFileName = LogFileNamesComboBox.SelectedItem as string;
            LogEntries = new ObservableCollection<LogEntry>(logEntries.GetLogEntries(logFileName));
        }
    }

    class LogEntries
    {
        private readonly ILogEntriesDependencies dependencies;

        public LogEntries(ILogEntriesDependencies dependencies)
        {
            this.dependencies = dependencies;
        }

        public List<LogEntry> GetLogEntries(string logFileName)
        {
            return dependencies.LogEntriesUseCase.FetchLogEntries(logFileName);
        }
    }

    class FileList
    {
        private readonly ILogEntriesDependencies dependencies;
        private ObservableCollection<string> fileNames;
        private Timer fetchTimer;

        public ObservableCollection<string> FileNames { get => fileNames; }

        public FileList(ILogEntriesDependencies dependencies)
        {
            this.dependencies = dependencies;
            InitTimer();
        }

        private void InitTimer()
        {
            fetchTimer = new Timer((e) =>
            {
                SetFileNames();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
        }

        private void SetFileNames()
        {
            fileNames = new ObservableCollection<string>(dependencies.FileListUseCase.FetchFileList(null));
        }
    }
}
