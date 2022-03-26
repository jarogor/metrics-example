using Microsoft.AspNetCore.Mvc;

namespace app.Controllers;

[ApiController]
[Route("debug")]
public class DebugController : ControllerBase
{
    [HttpGet(Name = "GetDebug")]
    public Dictionary<string, int> Get()
    {
        var random = new Random();
        var randomIndex = random.Next(App.PrometheusMetrics.Labels.Length);
        string randomLabel = App.PrometheusMetrics.Labels[randomIndex];

        // sending metrics to prometheus
        App.PrometheusMetrics.DebugCounter?.WithLabels(randomLabel).Inc();

        // add to statistic counter
        if (App.PrometheusMetrics.StatisticCounter.ContainsKey(randomLabel))
        { App.PrometheusMetrics.StatisticCounter[randomLabel]++; }
        else
        { App.PrometheusMetrics.StatisticCounter.Add(randomLabel, 1); }

        // response to client
        return App.PrometheusMetrics.StatisticCounter;
    }
}
