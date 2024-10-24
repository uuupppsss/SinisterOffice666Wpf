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
using System.Windows;

namespace SinisterOffice666Wpf.Model
{
    public class SinisterService
    {
        private readonly HttpClient httpClient;

        public static  Devil SelectedDevil { get; set; }
        public static Rack SelectedRack { get; set; }

        public SinisterService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5148/api/");
        }

        public async Task<List<Devil>> GetDevilsAsync()
        {
            var responce = await httpClient.GetAsync($"Devils/GetDevils");

            if (responce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await responce.Content.ReadFromJsonAsync<List<Devil>>();
            }
            return null;
        }

        public async Task CreateDevilAsync(Devil devil)
        {
            string arg = JsonSerializer.Serialize(devil);
            var responce = await httpClient.PostAsync($"Devils/CreateDevil",
                new StringContent(arg, Encoding.UTF8, "application/json"));
            responce.EnsureSuccessStatusCode();

        }

        public async Task UpdateDevilAsync(Devil devil)
        {
            string arg = JsonSerializer.Serialize(devil);
            var responce = await httpClient.PostAsync($"Devils/UpdateDevil",
                new StringContent(arg, Encoding.UTF8, "application/json"));
            responce.EnsureSuccessStatusCode();
        }

        public async Task DeleteDevilAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"Devils/DeleteDevil?id={id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Rack>> GetRacksAsync()
        {
            var responce = await httpClient.GetAsync($"Racks/GetRacks");

            if (responce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await responce.Content.ReadFromJsonAsync<List<Rack>>();
            }
            return null;
        }

        public async Task CreateNewRackAsync(Rack rack)
        {
            string arg = JsonSerializer.Serialize(rack);
            var responce = await httpClient.PostAsync($"Racks/CreateRack",
                new StringContent(arg, Encoding.UTF8, "application/json"));
            responce.EnsureSuccessStatusCode();
        }

        public async Task UpdateRackAsync(Rack rack)
        {
            string arg = JsonSerializer.Serialize(rack);
            var responce = await httpClient.PostAsync($"Racks/UpdateRack",
                new StringContent(arg, Encoding.UTF8, "application/json"));
            responce.EnsureSuccessStatusCode();
        }

        public async Task DisposeRackAsync(Rack rack)
        {
            string arg = JsonSerializer.Serialize(rack);
            var responce = await httpClient.PostAsync($"Dispose/DisposeRack",
                new StringContent(arg, Encoding.UTF8, "application/json"));
            responce.EnsureSuccessStatusCode();

            var responce1 = await httpClient.DeleteAsync($"Devils/DeleteDevil?id={rack.Id}");
            responce1.EnsureSuccessStatusCode();
        }
    }
}
