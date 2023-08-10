using School.API.Entities;

namespace School_Manager.Services
{
    public class SchoolManager : ISchoolManager
    {
        private readonly string url = "https://localhost:7240";
        public HttpClient getClient()
        {
            HttpClientHandler clientHandler = new();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new(clientHandler);
            httpClient.BaseAddress = new Uri(url);
            return httpClient;
        }
        public async Task<List<Schools>> GetSchools(int skip, int take)
        {
            //HttpClient httpClient = new();
            var httpClient = getClient();
            var response = await httpClient.GetAsync($"/returnt-school-list/{skip}/{take}");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return (List<Schools>)Enumerable.Empty<Schools>();
                }
                return await response.Content.ReadFromJsonAsync<List<Schools>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        }
        public async Task<Schools> GetSchool(int id)
        {
            var httpClient = getClient();
            var response = await httpClient.GetAsync($"/School/{id}");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return (Schools)Enumerable.Empty<Schools>();
                }
                return await response.Content.ReadFromJsonAsync<Schools>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        }

        public async Task<Schools> AddSchool(Schools school)
        {
            var httpClient = getClient();
            var response = await httpClient.PostAsJsonAsync<Schools>("/School/AddSchool", school);
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return (Schools)Enumerable.Empty<Schools>();
                }
                return await response.Content.ReadFromJsonAsync<Schools>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        }

        public async Task<bool> DeleteSchool(int id)
        {
            var httpClient = getClient();
            var response = await httpClient.DeleteAsync($"/School/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Schools> UpdateSchool(Schools school)
        {
            var httpClient = getClient();
            var response = await httpClient.PutAsJsonAsync("/School", school);
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return (Schools)Enumerable.Empty<Schools>();
                }
                return await response.Content.ReadFromJsonAsync<Schools>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }

        }
    }
}
