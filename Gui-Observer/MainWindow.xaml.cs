using System.Diagnostics;
using System.IO;
using System.Windows;

namespace Gui_Observer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileSystemWatcher _watcher;
        string _filePath = @"C:\Project_SE\Observer_With_GUI_Work\Gui-Observer\Sample.txt";


        public MainWindow()
        {
            InitializeComponent();

            StartWatching();

        }

        private void StartWatching()
        {
            _watcher = new FileSystemWatcher();
            _watcher.Path = Path.GetDirectoryName(_filePath);
            _watcher.Filter = Path.GetFileName(_filePath);
            
            _watcher.Changed += OnFileChanged;

            _watcher.EnableRaisingEvents = true;
        }

        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            string Content;
            try
            {
                using (FileStream FileRead = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(FileRead))
                    {
                        Content = reader.ReadToEnd();
                    }
                }

                Dispatcher.Invoke(() =>
                {
                    OutputTextBox.Text = Content;
                });
                  
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }
        }
    }
}