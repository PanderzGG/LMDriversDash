using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using LMDriversDash.Models.HttpModels.GameState;
using LMDriversDash.Models.HttpModels.InfoModels;
using LMDriversDash.Services.Interfaces.IClients;
using LMDriversDash.UsefulData.HttpNavigation;

namespace LMDriversDash.Services.Service.Clients;

public class HttpClientService : IHttpClientService
{
    private readonly HttpClient _client = new();
    private const string _baseAddress = "http://localhost:6397";
    
    public async Task<State> GetHttpGameStateAsync()
    {
        State state = new State();

        try
        {
           using HttpResponseMessage response = await _client.GetAsync($"{_baseAddress}{HttpNavigation.GetNavigationState}");

           if (response.IsSuccessStatusCode)
           {
               var gameStateResponse = JsonSerializer.Deserialize<GameStateResponse>(response.Content.ReadAsStringAsync().Result);
               state = gameStateResponse?.state ?? new State();
           }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"HttpClientService::GetHttpGamesStateAsync: Unable to get GameState from HTTP API Statuscode");
            return state;
        }
        return state;
    }

    public async Task<HttpProfileInfo?>? GetHttpProfileInfoAsync()
    {
        HttpProfileInfo profileInfo = new HttpProfileInfo();

        try
        {
            using HttpResponseMessage response = await _client.GetAsync($"{_baseAddress}{HttpNavigation.GetProfileInfo}");

            if (response.IsSuccessStatusCode)
            {
                profileInfo = JsonSerializer.Deserialize<HttpProfileInfo>(await response.Content.ReadAsStringAsync());
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"HttpClientService::GetHttpProfileInfoAsync:: Can't get response from HTTP API");
        }

        return profileInfo;
    }
}