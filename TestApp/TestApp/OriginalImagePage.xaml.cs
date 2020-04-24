using Microsoft.Toolkit;
using System;
using System.Diagnostics;
using System.Linq;
using Windows.System;
using Windows.UI.Xaml;

namespace TestApp
{
    public sealed partial class OriginalImagePage
    {
        private readonly Stopwatch _stopwatch;
        private readonly DispatcherTimer _timer;

        public OriginalImagePage()
        {
            InitializeComponent();

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(200)
            };
            _timer.Tick += Timer_Tick;

            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            const string imageUrl = "https://www.bing.com/sa/simg/hpc27_2x.png";
            // Simulate load lots of different images.
            GridView.ItemsSource = Enumerable.Range(0, 500).Select(temp => imageUrl + "?rand=" + Guid.NewGuid()).ToList();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void OriginalImagePage_Loaded(object sender, RoutedEventArgs e)
        {
            _stopwatch.Stop();
            LoadCostTextBlock.Text = $"Load cost: {_stopwatch.ElapsedMilliseconds}ms";

            _timer.Start();

            RefreshMemoryUsage();
        }

        private void OriginalImagePage_Unloaded(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }

        private void RefreshMemoryUsage()
        {
            var memoryUsage = MemoryManager.AppMemoryUsage;
            MemoryUsageTextBlock.Text = "Memory usage: " + Converters.ToFileSizeString((long)memoryUsage);
        }

        private void Timer_Tick(object sender, object e)
        {
            RefreshMemoryUsage();
        }
    }
}