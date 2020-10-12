using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;

using LogViewer.DomainLayer.FileList;
using LogViewer.DomainLayer.LogEntry;

namespace LogViewer.UILayer
{
    public interface ILogEntriesDependencies
    {
        public ILogEntriesUseCase LogEntriesUseCase { get; }
        public IFileListUseCase FileListUseCase { get; }
    }
    
    public partial class LogEntriesView : Window
    {
        public ObservableCollection<FileData> FileNames { get; set; } = null;
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
            LogEntries = logEntries.LogData;
        }

        private void GetLogEntriesButton_Click(object sender, RoutedEventArgs e)
        {
            var logFileData = LogFileNamesComboBox.SelectedItem as FileData;
            logEntries.SetLogEntries(logFileData.FilePath);
        }
    }

    class LogEntries
    {
        private readonly ILogEntriesDependencies dependencies;
        private readonly ObservableCollection<LogEntry> _logEntries = new ObservableCollection<LogEntry>();

        public ObservableCollection<LogEntry> LogData { get => _logEntries; }

        public LogEntries(ILogEntriesDependencies dependencies)
        {
            this.dependencies = dependencies;
        }

        public void SetLogEntries(string logFilePath)
        {
            _logEntries.Clear();
            foreach (var logEntry in dependencies.LogEntriesUseCase.FetchLogEntries(logFilePath))
            {
                _logEntries.Add(logEntry);
            }
        }
    }

    class FileList
    {
        private readonly ILogEntriesDependencies dependencies;
        private readonly ObservableCollection<FileData> _fileNames = new ObservableCollection<FileData>();

        public ObservableCollection<FileData> FileNames { 
            get => _fileNames;
        }

        public FileList(ILogEntriesDependencies dependencies)
        {
            this.dependencies = dependencies;
            InitTimer();
        }

        private void InitTimer()
        {
            _ = new Timer((e) =>
            {
                SetFileNames();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
        }

        private void SetFileNames()
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _fileNames.Clear();
                foreach (var item in dependencies.FileListUseCase.FetchFileList(null))
                {
                    _fileNames.Add(item);
                }
            });
        }
    }
}
