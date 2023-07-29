using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Animation;
using WeatherApp.MVVM.ViewModels;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WeatherViewModel viewModel;
        private bool isDragging = false;
        private Point startPoint;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new WeatherViewModel();
            DataContext = viewModel;
        }

        private async Task LoadWeatherAsync()
        {
            await ((WeatherViewModel)DataContext).GetWeatherAsync();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await LoadWeatherAsync();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadWeatherAsync();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpenSettings_Click(object sender, RoutedEventArgs e)
        {
            if (!settingsPopup.IsOpen)
            {
                Storyboard openAnimation = (Storyboard)FindResource("OpenAnimation");
                openAnimation.Begin(settingsPopup);

                settingsPopup.IsOpen = true;
            }
            else
            {
                Storyboard closeAnimation = (Storyboard)FindResource("CloseAnimation");
                closeAnimation.Begin(settingsPopup);

                settingsPopup.IsOpen = false;
            }
        }

        private void DraggingPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            startPoint = e.GetPosition(this);
        }

        private void DraggingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentPoint = e.GetPosition(this);
                double diffX = currentPoint.X - startPoint.X;
                double diffY = currentPoint.Y - startPoint.Y;

                this.Left += diffX;
                this.Top += diffY;
            }
        }

        private void DraggingPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
        }

        private void SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            if (settingsPopup.IsOpen)
            {
                settingsPopup.IsOpen = false;
            }
        }
    }
}
