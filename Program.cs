using System.Text.Json;

namespace PokemonConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");

            while (true)
            {
                Console.WriteLine("What pokemon would you like to know about? Type 0 to exit.");
                string pokemonChoice = Console.ReadLine().ToLower();
                if (pokemonChoice == "0")
                {
                    return;
                }

                HttpResponseMessage responseMessage = await client.GetAsync($"pokemon/{pokemonChoice}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    Stream responseStream = await responseMessage.Content.ReadAsStreamAsync();
                    Pokemon resultantPokemon = await JsonSerializer.DeserializeAsync<Pokemon>(responseStream, new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true,
                    });

                    Console.WriteLine(JsonSerializer.Serialize(resultantPokemon));
                }
                else
                {
                    Console.WriteLine("Sorry, we couldn't find that Pokemon.");
                }

            }
        }
    }
}