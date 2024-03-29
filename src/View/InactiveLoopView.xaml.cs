﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Effektive_Praesentationen.Extension;
using Effektive_Praesentationen.Model;

namespace Effektive_Praesentationen.View
{
    /// <summary>
    /// Interaktionslogik für InactiveLoopView.xaml
    /// </summary>
    public partial class InactiveLoopView : UserControl
    {
        public InactiveLoopView()
        {
            InitializeComponent();
        }

        public bool AutoPlay()
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            this.MediaPlayer.Play();
        }
    }
}
