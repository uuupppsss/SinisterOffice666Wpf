using SinisterOffice666.DB;
using SinisterOffice666Wpf.Model;
using System.Collections.ObjectModel;
using System.Windows;


namespace SinisterOffice666Wpf.ViewModel
{
    public class MainWindowVM:BaseVM
    {
        private readonly SinisterService sinisterServise;
        private ObservableCollection<Devil> _devils;

        public ObservableCollection<Devil> Devils
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


        public MyCommand CreateDevilCommand { get; set; }
        public MyCommand UpdateDevilCommand { get; set; }
        public MyCommand RemoveDevilCommand {  get; set; }

        public MainWindowVM()
        {
            sinisterServise = new SinisterService();
            Devils = new ObservableCollection<Devil>();
           // LoadDevils();

            CreateDevilCommand = new MyCommand(() =>
            {
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

                sinisterServise.SelectedDevil = SelectedDevil;
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
                //RemoveDevil(SelectedDevil);
            });
        }

        private async void LoadDevils()
        {
            var devils = await sinisterServise.GetDevilsAsync();
            foreach (var devil in devils)
            {
                Devils.Add(devil);
            }
        }

        public async void RemoveDevil(Devil devil)
        {
            await sinisterServise.DeleteDevilAsync(devil.Id);
            Devils.Remove(devil);
        }

    }
}
