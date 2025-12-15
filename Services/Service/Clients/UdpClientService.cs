using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LMDriversDash.Models.UdpModels;
using LMDriversDash.Services.Interfaces.IClients;

namespace LMDriversDash.Services.Service.Clients;

public class UdpClientService : IUdpClientService
{
    private const int Port = 5000;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };
    
    private bool _isRunning = false;
    private UdpClient? _uClient;
    private CancellationTokenSource? _cts;
    
    private int _telemetryIntervalMs = 7;
    private int _scoringIntervalMs = 250;
    
    public int TelemetryIntervalMs 
    { 
        get => _telemetryIntervalMs;
        set => _telemetryIntervalMs = Math.Max(1, value);
    }
    
    public int ScoringIntervalMs 
    { 
        get => _scoringIntervalMs;
        set => _scoringIntervalMs = Math.Max(1, value);
    }
    
    public event EventHandler<ScoringInfo>? ScoringDataReceived;
    public event EventHandler<TelemetryInfo>? TelemetryDataReceived;
    
    public async Task StartUpAsync()
    {
        if (_isRunning) return;
        
        await StopAsync();

        _cts = new CancellationTokenSource();
        _isRunning = true;

        _ = Task.Run(ListenAsync);
    }

    private async Task ListenAsync()
    {
        try
        {
            _uClient = new UdpClient();
            _uClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            _uClient.Client.Bind(new IPEndPoint(IPAddress.Any, Port));

            var lastTelemetry = DateTime.MinValue;
            var lastScoring = DateTime.MinValue;

            while (_cts is { Token.IsCancellationRequested: false })
            {
                var result = await _uClient.ReceiveAsync(_cts.Token);
                var message = Encoding.ASCII.GetString(result.Buffer);

                ProcessMessage(message, ref lastTelemetry, ref lastScoring);
            }
        }
        catch (OperationCanceledException) { }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"UDP Fehler: {ex.Message}");
        }
        finally
        {
            Cleanup();
        }
    }

    private void ProcessMessage(string message, ref DateTime lastTelemetry, ref DateTime lastScoring)
    {
        try
        {
            using var doc = JsonDocument.Parse(message);
            var type = doc.RootElement.GetProperty("Type").GetString();
            var now = DateTime.Now;

            switch (type)
            {
                case "TelemInfoV01" when (now - lastTelemetry).TotalMilliseconds >= TelemetryIntervalMs:
                    if (JsonSerializer.Deserialize<TelemetryInfo>(message) is { } telemInfo)
                    {
                        TelemetryDataReceived?.Invoke(this, telemInfo);
                        lastTelemetry = now;
                    }
                    break;

                case "ScoringInfoV01" when (now - lastScoring).TotalMilliseconds >= ScoringIntervalMs:
                    if (JsonSerializer.Deserialize<ScoringInfo>(message, JsonOptions) is { } scoringInfo)
                    {
                        ScoringDataReceived?.Invoke(this, scoringInfo);
                        lastScoring = now;
                    }
                    break;
                default:
                    Debug.WriteLine($"SystemDataReceived: {type}");
                    break;
            }
        }
        catch (JsonException) { }
    }
    
    public void Stop() => _ = StopAsync();

    private async Task StopAsync()
    {
        if (_cts != null)
        {
            await _cts.CancelAsync();
            _cts.Dispose();
            _cts = null;
        }

        Cleanup();
        await Task.Delay(100); // Wait on port release
    }
    
    private void Cleanup()
    {
        _uClient?.Dispose();
        _uClient = null;
        _isRunning = false;
    }

    public bool getIsRunning() => _isRunning;
}