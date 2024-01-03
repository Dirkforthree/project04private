using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Effektive_Präsentation.Model;
using Effektive_Präsentation.Extension;
using System.Diagnostics;

namespace Effektive_Präsentation.ViewModel
{
    public partial class MainWindowViewModel : ObservableRecipient, IFilesDropped
    {

        [ObservableProperty]
        private Model.Chapters chapters;

        public MainWindowViewModel()
        {
            this.chapters = new Model.Chapters();
        }

        [RelayCommand]
        public void ChaptersSetDefaultChapter(string path)
        {
            // TODO: Make sure path is correct
            Chapters.DefaultChapter = path;
        }

        public void OnFilesDropped(string[] files)
        {
            ChaptersSetDefaultChapter(files[0]);
        }
    }
}
