using System;
using LMDriversDash.Models.HttpModels.InfoModels;

namespace LMDriversDash.Services.Events;

public class HttpProfileInfoReceivedEvent : EventArgs
{
    public HttpProfileInfo HttpProfileInfo { get; set; }

    public HttpProfileInfoReceivedEvent(HttpProfileInfo httpProfileInfo)
    {
        HttpProfileInfo = httpProfileInfo;
    }
}