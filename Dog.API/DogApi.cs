using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dog.API
{
    public class DogApi
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<string> GetAllBreeds()
        {
            var responseBody = string.Empty;
            try
            {
                var response = await client.GetAsync("https://dog.ceo/api/breeds/list/all");
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Exception Message : {e.Message}");
            }

            return responseBody;
        }

        public async Task<string> GetByBreed(string breed)
        {
            var responseBody = string.Empty;
            try
            {
                var response = await client.GetAsync($"https://dog.ceo/api/breed/{breed}/list");
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Exception Message : {e.Message}");
            }

            return responseBody;
        }

        public async Task<string> GetSingleRandomImage(string breed, string subBreed)
        {
            var responseBody = string.Empty;
            try
            {
                var response = await client.GetAsync($"https://dog.ceo/api/breed/{breed}/{subBreed}/images/random");
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Exception Message : {e.Message}");
            }

            return responseBody;
        }
    }
}
