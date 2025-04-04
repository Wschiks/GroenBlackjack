using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace avaloniaAppGroen
{
    public partial class MainWindow : Window
    {
        
        public int PlayersCount { get; set; }

        

        Pak _pak = new Pak();
        private bool Is_Pak_Geschud = false;

        Program _program = new Program();

        private int _playersCount;

        
        
        public MainWindow(int playersCount)
        {
            InitializeComponent();
            _playersCount = playersCount;
            ShowPlayerImages();
            CreatePlayerinList();
            for (int i = 0; i < _players.Length; i++)
            {
                Console.WriteLine(_players[i].Name);
            }
        }

        

        private Player[] _players;

        public void CreatePlayerinList()
        {
            _players = new Player[_playersCount];

            for (int i = 0; i < _playersCount; i++)
            {
                _players[i] = new Player(name: $"Player{i}");
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