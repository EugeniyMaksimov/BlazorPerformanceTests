using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using Microsoft.JSInterop;

namespace BlazorWebAssemblyJSPerformanceTest_Net7.Client.Pages {
    [SupportedOSPlatform("browser")]
    public partial class Index {
        double resultForMeasuringByDateTime = 0;
        double resultForMeasuringByStopwatch = 0;
        TimeSpan timeMeasuredByDateTime = new TimeSpan();
        TimeSpan timeMeasuredByStopwatch = new TimeSpan();
        void OnTestMeasuredByDateTimeClick() {
            DateTime start = DateTime.UtcNow;
            resultForMeasuringByDateTime = Calculate();
            DateTime end = DateTime.UtcNow;
            timeMeasuredByDateTime = end - start;
            StateHasChanged();
        }

        void OnTestMeasuredByStopwatchClick() {
            Stopwatch stopwatch = Stopwatch.StartNew();
            resultForMeasuringByStopwatch = Calculate();
            stopwatch.Stop();
            timeMeasuredByStopwatch = stopwatch.Elapsed;
            StateHasChanged();
        }

        void OnClearClick() {
            resultForMeasuringByDateTime = 0;
            resultForMeasuringByStopwatch = 0;
            timeMeasuredByDateTime = new TimeSpan();
            timeMeasuredByStopwatch = new TimeSpan();
        }

        protected override async Task OnInitializedAsync() {
            await JSHost.ImportAsync("Index", "../Pages/Index.razor.js");
        }

        [JSImport("calculate", "Index")]
        internal static partial double Calculate();
    }
}