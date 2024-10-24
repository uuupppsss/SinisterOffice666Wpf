using SinisterOffice666.DB;
using SinisterOffice666Wpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinisterOffice666Wpf.ViewModel
{
    public class CreateNewRackWinVM:BaseVM
    {
		private SinisterService sinisterServise;
		private int _yearBuy;

		public int YearBuy
		{
			get => _yearBuy; 
			set 
			{ 
				_yearBuy = value;
				Signal();
			}
		}

		private int _currentCount;

		public int CurrentCount
		{
			get => _currentCount;
			set 
			{
				_currentCount = value; 
			Signal() ;
			}
		}
		private int _useCount;

		public int UseCount
		{
			get => _useCount;
			set 
			{
				_useCount = value;
				Signal();
			}
		}

		private string _title;

		public string Title
		{
			get => _title;
			set 
			{
				_title = value; 
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
			}
		}

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
		public MyCommand Save {  get; set; }

        public CreateNewRackWinVM()
        {
			sinisterServise = new SinisterService();
			LoadDevils();
			if (SinisterService.SelectedRack == null)
			{
				Save = new MyCommand(() =>
				{
                    Rack rack_to_create = new Rack()
                {
                    Title = Title,
                    YearBuy = YearBuy,
                    UseCount = UseCount,
                    CurrentCount = CurrentCount,
                    IdDevil = SelectedDevil.Id
                };
                CreateRack(rack_to_create);
            });
			}
			else
			{
				Save = new MyCommand(() =>
				{
                    Rack rack_to_update = new Rack()
					{
						Id = SinisterService.SelectedRack.Id,
						Title=Title,
						YearBuy = YearBuy,
						UseCount = UseCount,
						CurrentCount = CurrentCount,
						IdDevil=SelectedDevil.Id
					};
					UpdateRack(rack_to_update);
				});
			}
        }

        private async void LoadDevils()
        {
            var devils = await sinisterServise.GetDevilsAsync();
            Devils = devils;
        }

        private async void UpdateRack(Rack rack)
        {
            await sinisterServise.UpdateRackAsync(rack);
        }

        private async void CreateRack(Rack rack)
        {
            await sinisterServise.CreateNewRackAsync(rack);
        }
    }
}
