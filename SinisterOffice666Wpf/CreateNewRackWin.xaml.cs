using SinisterOffice666Wpf.ViewModel;
using System.Windows;

namespace SinisterOffice666Wpf
{
    /// <summary>
    /// Логика взаимодействия для CreateNewRackWin.xaml
    /// </summary>
    public partial class CreateNewRackWin : Window
    {
        public CreateNewRackWin()
        {
            InitializeComponent();
            DataContext=new CreateNewRackWinVM();
        }
    }
}
