using SinisterOffice666.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SinisterOffice666Wpf.ViewModel;

namespace SinisterOffice666Wpf
{
    /// <summary>
    /// Логика взаимодействия для CreateDevilWin.xaml
    /// </summary>
    public partial class CreateDevilWin : Window
    {

        public CreateDevilWin()
        {
            InitializeComponent();
            DataContext=new CreateDevilWinVM();
        }


    }
}
