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
        HttpResponseMessage? response = null;

        try
        {
            response = await _client.GetAsync($"{_baseAddress}{HttpNavigation.GetNavigationState}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get GameState from HTTP API Statuscode:{response.StatusCode} - {ex.Message}");
            return state;
        }

        using (response)
        {
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var gameStateResponse = JsonSerializer.Deserialize<GameStateResponse>(content);
                state = gameStateResponse?.state ?? new State();
            }
            else
            {
                Debug.WriteLine($"HTTP response returned non-success: {(int)response.StatusCode}");
            }
        }
        return state;
    }

    public Task<HttpProfileInfo> GetHttpProfileInfoAsync()
    {
        throw new NotImplementedException();
    }
}