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
        Dealer _dealer = new Dealer();

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
                ShowPlayer1.IsVisible = true;
            }

            if (_playersCount >= 2)
            {
                ShowPlayer2.IsVisible = true;
            }

            if (_playersCount >= 3)
            {
                ShowPlayer3.IsVisible = true;
            }

            if (_playersCount >= 4)
            {
                ShowPlayer4.IsVisible = true;
            }
        }
        
        //Knoppen kaart geven aan Speler
        
        private void GeefKaartPlayer1(object? sender, RoutedEventArgs e)
        {
            _players[0].VoegKaartToe(_pak._schuddenPak[0]);
            String Kaart = _pak._schuddenPak[0];
            TextBlock kaartTextBlock = new TextBlock();
            kaartTextBlock.Text = Kaart;
            Toonkartenspeler1.Children.Add(kaartTextBlock);
            _pak.PickKaart();
            Console.WriteLine(string.Join(", ", _players[0].Kaarten));
            _players[0].PuntKaarten();
            ShowPunt1.Text = $"Totaal punten: {_players[0].totaalPunten}";
            if (_players[0].totaalPunten >= 21)
            {
                ShowPlayer1.IsEnabled = false;
            }
            

        }
        private void GeefKaartPlayer2(object? sender, RoutedEventArgs e)
        {
            _players[1].VoegKaartToe(_pak._schuddenPak[0]);
            String Kaart = _pak._schuddenPak[0];
            TextBlock kaartTextBlock = new TextBlock();
            kaartTextBlock.Text = Kaart;
            Toonkartenspeler2.Children.Add(kaartTextBlock);
            _pak.PickKaart();
            Console.WriteLine(string.Join(", ", _players[1].Kaarten));
            _players[1].PuntKaarten();
            ShowPunt2.Text = $"Totaal punten: {_players[1].totaalPunten}";
            if (_players[1].totaalPunten >= 21)
            {
                ShowPlayer2.IsEnabled = false;
            }
            

        }
        
        private void GeefKaartPlayer3(object? sender, RoutedEventArgs e)
        {
            _players[2].VoegKaartToe(_pak._schuddenPak[0]);
            String Kaart = _pak._schuddenPak[0];
            TextBlock kaartTextBlock = new TextBlock();
            kaartTextBlock.Text = Kaart;
            Toonkartenspeler3.Children.Add(kaartTextBlock);
            _pak.PickKaart();
            Console.WriteLine(string.Join(", ", _players[2].Kaarten));
            _players[2].PuntKaarten();
            ShowPunt3.Text = $"Totaal punten: {_players[2].totaalPunten}";
            if (_players[2].totaalPunten >= 21)
            {
                ShowPlayer3.IsEnabled = false;
            }
            

        }
        private void GeefKaartPlayer4(object? sender, RoutedEventArgs e)
        {
            _players[3].VoegKaartToe(_pak._schuddenPak[0]);
            String Kaart = _pak._schuddenPak[0];
            TextBlock kaartTextBlock = new TextBlock();
            kaartTextBlock.Text = Kaart;
            Toonkartenspeler4.Children.Add(kaartTextBlock);
            _pak.PickKaart();
            Console.WriteLine(string.Join(", ", _players[3].Kaarten));
            _players[3].PuntKaarten();
            ShowPunt4.Text = $"Totaal punten: {_players[3].totaalPunten}";
            if (_players[3].totaalPunten >= 21)
            {
                ShowPlayer4.IsEnabled = false;
            }
            

        }
        private void GeefKaartDealer(object? sender, RoutedEventArgs e)
        {
            _dealer.VoegKaartToe(_pak._schuddenPak[0]);
            String Kaart = _pak._schuddenPak[0];
            TextBlock kaartTextBlock = new TextBlock();
            kaartTextBlock.Text = Kaart;
            ToonkartenDealer.Children.Add(kaartTextBlock);
            _pak.PickKaart();
            Console.WriteLine(string.Join(", ", _dealer.Kaarten));
            _dealer.PuntKaarten();
            ShowPuntDealer.Text = $"Totaal punten: {_dealer.totaalPunten}";
            if (_dealer.totaalPunten >= 17)
            {
                ShowDealer.IsEnabled = false;
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