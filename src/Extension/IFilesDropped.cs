using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Effektive_Präsentation.Extension
{
    /// <summary>
    /// IFilesDropped Interface for the windows drag and drop behavior
    /// </summary>
    public interface IFilesDropped
    {
        void OnFilesDropped(string[] files);
    }
}
