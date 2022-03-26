namespace App;

public static class PrometheusMetrics
{
    public static readonly string[] Labels = {
        "foo",
        "bar",
        "qwerty"
    };

    public static Dictionary<string, int> StatisticCounter = new Dictionary<string, int>();

    public static Prometheus.Histogram? DebugHistogramLinear { get; private set; }
    public static Prometheus.Histogram? DebugHistogramExponential { get; private set; }

    public static Prometheus.Counter? DebugCounter { get; private set; }
    public static void InitDebugCounter()
    {
        DebugCounter = Prometheus.Metrics.CreateCounter(
            "debug_counter",
            "DEBUG",
            new Prometheus.CounterConfiguration { LabelNames = new[] { "reason" } }
        );
    }
}
