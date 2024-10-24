using SinisterOffice666.DB;
using SinisterOffice666Wpf.Model;
using System.Collections.ObjectModel;
using System.Windows;


namespace SinisterOffice666Wpf.ViewModel
{
    public class MainWindowVM:BaseVM
    {
        private readonly SinisterService sinisterServise;
        private List<Devil> _devils;

        public List<Devil> Devils
        {
            get => _devils; 
            set 
            { 
                _devils = value;
                Signal();
            }
        }

        private Devil _selectedDevil;

        public Devil SelectedDevil
        {
            get => _selectedDevil; 
            set 
            {
                _selectedDevil = value;
                Signal();
            }
        }

        private Rack _selectedRack;

        public Rack SelectedRack
        {
            get =>_selectedRack; 
            set 
            { 
                _selectedRack = value; 
                Signal();
            }
        }

        private List<Rack> _racks;

        public List<Rack> Racks
        {
            get => _racks; 
            set 
            {
                _racks = value; 
                Signal() ;
            }
        }

        public MyCommand CreateDevilCommand { get; set; }
        public MyCommand UpdateDevilCommand { get; set; }
        public MyCommand RemoveDevilCommand {  get; set; }

        public MyCommand CreateRackCommand { get; set; }
        public MyCommand UpdateRackCommand { get; set; }
        public MyCommand RemoveRackCommand { get; set; }

        public MyCommand UpdateData {  get; set; }

        public MainWindowVM()
        {
            sinisterServise = new SinisterService();
            Devils = new List<Devil>();
            
            LoadData();

            CreateDevilCommand = new MyCommand(() =>
            {
                SinisterService.SelectedDevil = null;
                var win = new CreateDevilWin();
                win.ShowDialog();
                
            });

            UpdateDevilCommand = new MyCommand(() =>
            {
                if(SelectedDevil == null) 
                {
                    MessageBox.Show("Выберите сотрудника для изменения");
                    return;
                }

                SinisterService.SelectedDevil = SelectedDevil;
                var win = new CreateDevilWin();
                win.ShowDialog();
            });

            RemoveDevilCommand = new MyCommand(() =>
            {
                if (SelectedDevil == null)
                {
                    MessageBox.Show("Выберите сотрудника для удаления");
                    return;
                }
                RemoveDevil(SelectedDevil);
            });

            CreateRackCommand = new MyCommand(() =>
            {
                SinisterService.SelectedRack = null;
                var win = new CreateDevilWin();
                win.ShowDialog();
                
            });

            UpdateRackCommand = new MyCommand(() =>
            {
                if (SelectedRack == null)
                {
                    MessageBox.Show("Выберите стеллаж для изменения");
                    return;
                }

                SinisterService.SelectedRack = SelectedRack;
                var win = new CreateNewRackWin();
                win.ShowDialog();
            });

            RemoveRackCommand = new MyCommand(() =>
            {
                if (SelectedRack == null)
                {
                    MessageBox.Show("Выберите стеллаж для удаления");
                    return;
                }
                RemoveRack(SelectedRack);
            });

            UpdateData = new MyCommand(() =>
            {
                LoadData();
            });
        }

        private async void LoadData()
        {
            var devils = await sinisterServise.GetDevilsAsync();
            Devils = devils;
            var racks = await sinisterServise.GetRacksAsync();
            Racks = racks;
        }



        private async void RemoveDevil(Devil devil)
        {
            await sinisterServise.DeleteDevilAsync(devil.Id);
        }

        private async void RemoveRack(Rack rack)
        {
            await sinisterServise.DisposeRackAsync(rack);
        }

    }
}
