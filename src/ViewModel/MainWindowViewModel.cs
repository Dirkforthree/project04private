﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Effektive_Praesentationen.Model;
using Effektive_Praesentationen.Extension;
using Effektive_Praesentationen.Core;
using System.Diagnostics;
using Effektive_Praesentationen.Service;

namespace Effektive_Praesentationen.ViewModel
{
    public partial class MainWindowViewModel : Core.ViewModel, IFilesDropped
    {

        [ObservableProperty]
        private Model.Chapters chapters;

        [ObservableProperty]
        private INavigationService _navigation;

       
        public MainWindowViewModel(INavigationService navService)
        {
            Navigation = navService;
            this.chapters = new Model.Chapters();
        }

        [RelayCommand]
        public void NavigateToPresentationLoop()
        {
            Navigation.NavigateTo<PresentationLoopViewModel>();
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