﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Effektive_Praesentationen.Interface
{
    internal interface IMediaPlayer
    {
        void Play();
        bool AutoPlay();
    }
}
