using SinisterOffice666.DB;
using System;
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
using System.Windows.Shapes;

namespace SinisterOffice666Wpf
{
    /// <summary>
    /// Логика взаимодействия для CreateDevilWin.xaml
    /// </summary>
    public partial class CreateDevilWin : Window
    {
        public string Nick { get; set; }
        public int Rank { get; set; }
        public int Year { get; set; }
        public CreateDevilWin()
        {
            InitializeComponent();
            DataContext=this;
        }

        private void CreateDevil_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Nick) || Rank == 0 || Year == 0)
                return;
            Devil devil = new Devil() { Nick=Nick,Rank=Rank,Year=Year};
        }
    }
}
