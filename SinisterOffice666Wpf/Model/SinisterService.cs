using SinisterOffice666.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SinisterOffice666Wpf.Model
{
    public class SinisterService
    {
        private readonly HttpClient httpClient;
        private JsonSerializerOptions _jsOptions = new JsonSerializerOptions();

        public  Devil SelectedDevil { get; set; }
        public  Rack SelectedRack { get; set; }

        private ObservableCollection<Devil> _devils;
        public ObservableCollection<Devil> Devils
        {
            get => _devils;
            set
            {
                _devils = value;
            }
        }

        public SinisterService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5148/api/");
        }

        public async Task<List<Devil>> GetDevilsAsync()
        {
            var responce = await httpClient.GetAsync($"Devils/GetDevils");

            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            else
            {
                return await responce.Content.ReadFromJsonAsync<List<Devil>>();
                
            }
        }

        public async Task CreateDevilAsync(Devil devil)
        {
            var response = await httpClient.PostAsJsonAsync("api/devils/CreateDevil", devil);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateDevilAsync(int id, Devil devil)
        {
            var response = await httpClient.PutAsJsonAsync($"api/devils/UpdateDevil?id={id}", devil);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteDevilAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"api/devils/DeleteDevil?id={id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
