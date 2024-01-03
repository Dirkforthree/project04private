using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CommunityToolkit.Mvvm;
using Effektive_Präsentation.Model;
using Effektive_Präsentation.ViewModel;

namespace Effektive_Präsentation.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// on OpenFile Drop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImagePanel_Drop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) { return; }
            // Note that you can have more than one file.
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Assuming you have one file that you care about, pass it off to whatever
            // handling code you have defined.
            int indexPoint = files[0].LastIndexOf(".");
            string dataFormat = files[0].Substring(indexPoint + 1);
            if (dataFormat != "mp4" && dataFormat != "mkv" && dataFormat != "pdf"
                && dataFormat != "ppts" && dataFormat != "doc" && dataFormat != "docx")
            {
                return;
            }
            ChaptersSetDefaultChapter(files[0]);
        }

        /// <summary>
        /// On OpenFile Click, opens file dialogue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dropArea_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".mov"; // Default file extension
            dialog.Filter = "Videos (.mov)|*.mov"; // Filter files by extension

            bool? result = dialog.ShowDialog();

            if (result != true) { return; }
            string filename = dialog.FileName;
            ChaptersSetDefaultChapter(filename);
        }
    }
}