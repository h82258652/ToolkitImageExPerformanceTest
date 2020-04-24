using Windows.UI.Xaml;

namespace TestApp
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OriginalImageButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OriginalImagePage));
        }

        private void ToolkitImageExButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ToolkitImageExPage));
        }
    }
}