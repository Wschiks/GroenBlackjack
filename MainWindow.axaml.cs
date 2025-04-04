using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

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
        private Player _player1,_player2,_player3,_player4;
        
        
        Program _program = new Program();

        
        private int _playersCount;

        
        
        public MainWindow(int playersCount)
        {
            InitializeComponent();
            _playersCount = playersCount;
            
            ShowPlayerImages();
        }
        public List<string> _PlayerList = new List<string>();


        public void CreatePlayerinList()
        {
            for (int i = 0; i < _playersCount; i++)
            {
                _player{i}= new Player(name: $"Player{i}");
            }
        }
        
        
        
        //toont de juiste aantal spelers als moet
        private void ShowPlayerImages()
        {
            if (_playersCount >= 1)
            {
                Image10.IsVisible = true;
                Image11.IsVisible = true;
            }
            if (_playersCount >= 2)
            {
                Image20.IsVisible = true;
                Image21.IsVisible = true;
            }
            if (_playersCount >= 3)
            {
                Image30.IsVisible = true;
                Image31.IsVisible = true;
            }
            if (_playersCount >= 4)
            {
                Image40.IsVisible = true;
                Image41.IsVisible = true;
            }
        }
        
     
  
        

        // niet geschudden pak printen
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