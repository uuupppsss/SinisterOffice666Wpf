
using SinisterOffice666.DB;
using SinisterOffice666Wpf.Model;
using System.Windows;


namespace SinisterOffice666Wpf.ViewModel
{
    public class CreateDevilWinVM:BaseVM
    {
		private SinisterService sinisterService;
		private string? _nick;

		public string? Nick
		{
			get =>_nick; 
			set 
			{ 
				_nick = value;
				Signal();
			}
		}
		private int _rank;

		public int Rank
        {
			get => _rank; 
			set 
			{
				_rank = value;
				Signal();
			}
		}

		private int _year;

		public int Year
        {
			get => _year; 
			set 
			{
				_year = value;
				Signal();
			}
		}

		public MyCommand Save {  get; set; }

        public CreateDevilWinVM()
        {
			sinisterService = new SinisterService();

			if (SinisterService.SelectedDevil != null)
			{
				Nick=SinisterService.SelectedDevil.Nick;
				Rank=SinisterService.SelectedDevil.Rank;
				Year=SinisterService.SelectedDevil.Year;

				Save = new MyCommand(() =>
				{
                    if (Rank == 0 || Nick == null || Year == 0)
					{
                        MessageBox.Show("Заполните все поля плиз");
						return;
                    }
                        
                    Devil devil_to_update = new Devil()
                    {
						Id=SinisterService.SelectedDevil.Id,
                        Nick = Nick,
                        Rank = Rank,
                        Year = Year
                    };
					UpdateDevil(devil_to_update);
                });
			}
			else
			{
                Save = new MyCommand(() =>
                {
                    if (Rank == 0 || Nick == null || Year == 0)
                    {
                        MessageBox.Show("Заполните все поля плиз");
                        return;
                    }

                    Devil devil_to_create = new Devil()
					{
						Nick = Nick,
						Rank=Rank,
						Year=Year
					};
					CreateDevil(devil_to_create);
				});
            }
        }

		private async void UpdateDevil(Devil devil)
		{
			await sinisterService.UpdateDevilAsync(devil);
        }

        private async void CreateDevil(Devil devil)
        {
            await sinisterService.CreateDevilAsync(devil);
        }
    }
}
