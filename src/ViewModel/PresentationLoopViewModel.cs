using System;
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
using System.Windows.Navigation;
using System.Dynamic;
using Effektive_Praesentationen.Interface;
using System.Windows.Media;
using System.Windows;

namespace Effektive_Praesentationen.ViewModel
{
    public class PresentationLoopViewModel: Core.ViewModel
    {
        private string? _filePath;

        public string? FilePath
        {
            get { return _filePath; }
            set
            {
                if (SetProperty(ref _filePath, value))
                {
                    // Wandele den Pfad in eine URI um und aktualisiere die URI-Eigenschaft
                    UpdateUri();
                }
            }
        }

        //URI, damit in View als Source angenommen
        private Uri? _fileUri;

        public Uri? FileUri
        {
            get { return _fileUri; }
            private set { SetProperty(ref _fileUri, value); }
        }

        private void UpdateUri()
        {
            try
            {
                FileUri = new Uri(FilePath, UriKind.RelativeOrAbsolute);
            }
            catch (UriFormatException)
            {
                // Behandle eine ungültige URI-Formatausnahme hier, wenn nötig
                FileUri = null;
            }
        }

    }
}
