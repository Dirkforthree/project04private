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

namespace Effektive_Präsentation.ViewModel
{
    public partial class MainWindowViewModel : ObservableRecipient
    {

        [ObservableProperty]
        private Model.Chapters chapters;

        public MainWindowViewModel()
        {
            this.chapters = new Model.Chapters();
        }

        //public ICommand SetDatabasePath { get; set; }
        //public ICommand AddChapter { get; set; }
        //public ICommand RemoveChapter { get; set; }
        //public ICommand EditChapter { get; set; }
        //public ICommand SaveChapter { get; set; }

        //private void ChaptersSaveChapter()
        //{
        //    throw new NotImplementedException();
        //}

        //private void ChaptersEditChapter()
        //{
        //    throw new NotImplementedException();
        //}

        //private void ChaptersRemoveChapter()
        //{
        //    throw new NotImplementedException();
        //}

        //private void ChaptersAddChapter()
        //{
        //    throw new NotImplementedException();
        //}

        [RelayCommand]
        public void ChaptersSetDefaultChapter(string path)
        {
            // TODO: Make sure path is correct
            Chapters.DefaultChapter = path;
        }
    }
}
