using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace avaloniaAppGroen
{
    public partial class StartWindow : Window
    {
        public int PlayersCount { get; set; } = 1;

        public StartWindow()
        {
            InitializeComponent();
            
            PlayersSlider.PropertyChanged += (s, e) =>
            {
                if (e.Property.Name == "Value")
                {
                    PlayersCount = (int)PlayersSlider.Value;
                    PlayersText.Text = $"Players: {PlayersCount}";
                }
            };
        }
        
        private void StartGame_Click(object? sender, RoutedEventArgs e)
        {
            
            Console.WriteLine($"Aantal spelers: {PlayersCount}");

            var mainWindow = new MainWindow();
            mainWindow.PlayersCount = PlayersCount; 

            mainWindow.Show();

            
            this.Close();
        }
    }
}