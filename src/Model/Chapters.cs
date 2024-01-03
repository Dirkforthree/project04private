using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effektive_Präsentation.Model;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Effektive_Präsentation.Model
{
    public partial class Chapters : ObservableObject
    {
        [ObservableProperty]
        private string? defaultChapter;

        [ObservableProperty]
        private Chapter[]? chapterList;

        [ObservableProperty]
        private string? databasePath;
    }
}