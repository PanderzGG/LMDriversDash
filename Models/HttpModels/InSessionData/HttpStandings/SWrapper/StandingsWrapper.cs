using System.Collections.Generic;
using LMDriversDash.Models.HttpModels.InSessionData.HttpStandings.SData;

namespace LMDriversDash.Models.HttpModels.InSessionData.HttpStandings.SWrapper;

/// <summary>
/// Wrapper-Klasse für die Standings-Daten.
/// Die API gibt ein direktes Array zurück, daher wird diese Klasse
/// als List&lt;StandingsEntry&gt; deserialisiert.
/// </summary>
public class StandingsWrapper : List<StandingsEntry>
{
}