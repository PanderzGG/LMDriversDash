using System;
using LMDriversDash.Models.HttpModels.GameState;

namespace LMDriversDash.Services.Events;

public class HttpGameStateChangedEvent : EventArgs
{
    public State? OldState { get; set; }
    public State? NewState { get; set; }

    public HttpGameStateChangedEvent(State? oldState, State? newState)
    {
        OldState = oldState;
        NewState = newState;
    }
}