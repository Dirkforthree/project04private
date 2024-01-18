using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Effektive_Praesentationen.Extension
{
    /// <summary>
    /// IOpenFileDialog Interface for the open file windows dialog
    /// </summary>
    internal interface IOpenFileDialog
    {
        void OnFileSelected(string[] files);
    }
}
