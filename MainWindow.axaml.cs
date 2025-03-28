using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace avaloniaAppGroen
{
    public partial class MainWindow : Window
    {
        // Voeg hier een publieke eigenschap toe voor het aantal spelers
        public int PlayersCount { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        Pak _pak = new Pak();
        private bool Is_Pak_Geschud = false;

        Player _player = new Player();
        
     
  
        

        // Originele pak printen
        private void Show_Pak(object? sender, RoutedEventArgs e)
        {
            _pak.PrintPak();
            
            
        }

        // Geschud pak printen
        private void Show_Schudden_Pak(object? sender, RoutedEventArgs e)
        {
            if (Is_Pak_Geschud == true)
            {
                _pak.PrintSchuddenPak();
            }
            else
            {
                Console.WriteLine("FOUT!! je hebt nog niet het pak geschud");
            }
        }

        // Pak schudden
        private void Schudden(object? sender, RoutedEventArgs e)
        {
            _pak.SchudPak();
            Is_Pak_Geschud = true;
            Console.WriteLine("Pak Schudden");
        }
        
        // eerste kaart van geschudden stabel pakken
        private void PickKaart(object? sender, RoutedEventArgs e)
        {
            _pak.PickKaart();
        }
        
        
    }
}