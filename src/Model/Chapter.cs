using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Effektive_Praesentationen.Model
{
    public partial class Chapter : ObservableObject
    {
        [ObservableProperty]
        private string? title;

        [ObservableProperty]
        private string? description;

        [ObservableProperty]
        private bool loop;
    }
}
