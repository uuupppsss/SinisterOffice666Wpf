using System.Text;
using System.Windows;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using SinisterOffice666.DB;


namespace SinisterOffice666Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public List<Devil> Devils {  get; set; }
        public List<Rack> Racks { get; set; }

        HttpClient httpClient=new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
            httpClient.BaseAddress = new Uri("http://localhost:5148/api/");
            DataContext=this;
            GetDevilsList();
        }

        private async void GetDevilsList()
        {
            Devils = await httpClient.GetFromJsonAsync<List<Devil>>("Devils/GetDevils");
        }

        private async void GetRacksList()
        {
            Racks = await httpClient.GetFromJsonAsync<List<Rack>>("Racks/GetRacks");
        }

        private void CreateDevil_Click(object sender, RoutedEventArgs e)
        {
            Window win=new CreateDevilWin();
            win.ShowDialog();
        }

        private void CreateNewRack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}