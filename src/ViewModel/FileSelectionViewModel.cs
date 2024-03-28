using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Effektive_Praesentationen.Extension;
using Effektive_Praesentationen.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Effektive_Praesentationen.Model;
using System.Runtime.InteropServices;
using System.Management;
using System.Collections.ObjectModel;
using System.Windows;

namespace Effektive_Praesentationen.ViewModel
{
    public partial class FileSelectionViewModel : Core.ViewModel, IFilesDropped, IOpenFileDialog
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FileValid))]
        [NotifyCanExecuteChangedFor(nameof(NavigateToInactiveLoopCommand))]
        private Chapters _chapters;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FileValid))]
        [NotifyCanExecuteChangedFor(nameof(NavigateToInactiveLoopCommand))]
        private string? test;
        //should we working without the "Test" variable, because it should reevalaute the FileValid property and CanExecute when changing the
        //value of Chapters.DefaultChapter
        //--> [NotifyPropertyChangedFor(nameof(FileValid))] and [NotifyCanExecuteChangedFor(nameof(NavigateToInactiveLoopCommand))]
        //but it only works if i add a other variable and change the value there

        [ObservableProperty]
        private INavigationService _navigation;

        private ManagementEventWatcher? _insertionWatcher;
        private ManagementEventWatcher? _removalWatcher;

        public ObservableCollection<UsbDrive> UsbDrives { get; set; } = new ObservableCollection<UsbDrive>();

        public FileSelectionViewModel(INavigationService navService)
        {
            Chapters = new Model.Chapters();
            Navigation = navService;
            viewName = "FileSelection";
            InitializeWatcher();
            GetUsbInfo();
        }

        [RelayCommand(CanExecute = nameof(FileValid))]
        public void NavigateToInactiveLoop()
        {
            Navigation.PathNavigateTo<InactiveLoopViewModel>(Chapters.DefaultChapter);

            if (Navigation.CurrentViewModel is InactiveLoopViewModel inactiveLoopViewModel)
            {
                inactiveLoopViewModel.FilePath = Chapters.DefaultChapter;
            }
        }

        public bool FileValid
        {
            get
            {
                if (String.IsNullOrEmpty(Chapters.DefaultChapter))
                {
                    return false;
                }
                string fileExtension = Path.GetExtension(Chapters.DefaultChapter);
                if (!(fileExtension == ".mp4" || fileExtension == ".mkv" || fileExtension == ".mov"))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        public void OnFilesDropped(string[] files)
        {
            Chapters.DefaultChapter = files[0];
            Test = files[0];
        }

        public void OnFileSelected(string[] files)
        {
            Chapters.DefaultChapter = files[0];
            Test = files[0];
        }

        private async Task InitializeWatcher()  //watcher for usb stick
        {
            _insertionWatcher = new ManagementEventWatcher();
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2");
            _insertionWatcher.EventArrived += Watcher_EventArrived;
            _insertionWatcher.Query = query;
            _insertionWatcher.Start();

            await Task.Run(() => _insertionWatcher.WaitForNextEvent());

            _removalWatcher = new ManagementEventWatcher();
            WqlEventQuery query2 = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 3");
            _removalWatcher.EventArrived += Watcher_EventArrived;
            _removalWatcher.Query = query2;
            _removalWatcher.Start();

            await Task.Run(() => _removalWatcher.WaitForNextEvent());
        }

        private void Watcher_EventArrived(object sender, EventArrivedEventArgs e) 
        {
            GetUsbInfo();
        }

        private void GetUsbInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            Application.Current.Dispatcher.Invoke(() => UsbDrives.Clear());
            foreach (DriveInfo drive in drives)
            {
                if (drive.DriveType == DriveType.Removable)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        UsbDrives.Add(new UsbDrive
                        {
                            Name = drive.Name,
                            VolumeLabel = drive.VolumeLabel,
                            DriveFormat = drive.DriveFormat,
                            TotalSize = drive.TotalSize / 1000000,
                            TotalFreeSpace = drive.AvailableFreeSpace / 1000000
                        });
                    });
                } 
            }
        }
    }
}
