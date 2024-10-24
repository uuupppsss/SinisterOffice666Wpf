﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SinisterOffice666Wpf.ViewModel
{
    public class BaseVM : INotifyPropertyChanged
    {
        protected void Signal([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
