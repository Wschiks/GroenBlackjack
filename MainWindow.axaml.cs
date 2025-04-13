using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using Avalonia;


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

        private List<int> _randomStop = new List<int>
        {
            16, 17, 17, 17, 17, 18, 18, 19, 20
        };

        Random _random = new Random();


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




        private String WaarZijnWeNU = "p1MoetNu";
        private String HierZijnWE ;

        private List<String> ListWZWN = new List<String> //List Waar Zijn We Nu
        {
            "p1MoetNu", "p2MoetNu", "p3MoetNu", "p4MoetNu", "DealerMoetNu"
        };
        
        private bool itemVerwijderd = false;
        int getalWaarZijnWeNU = 1;

        private void WaarZijnWeNUOpHogen()
        {
           
            if (getalWaarZijnWeNU >= ListWZWN.Count)
            {
                getalWaarZijnWeNU = 0;
            }

            WaarZijnWeNU = ListWZWN[getalWaarZijnWeNU];

            
            if (!itemVerwijderd)
            {
                getalWaarZijnWeNU++;
            }
            else
            {
                
                itemVerwijderd = false;
            }

            Console.WriteLine("WaarZijnWeNU: " + WaarZijnWeNU + " HierZijnWE: " + HierZijnWE);
        }


        
         
        private int spelerIndex;

        private bool IsBeurtCorrect()
        {
            if (WaarZijnWeNU != HierZijnWE)
            {
                ShowFoutPopup();
                return false;
            }

            return true;
        }


        private async void ShowFoutPopup()
        {
            var foutWindow = new Window
            {
                Title = "Foute Beurt!",
                Width = 300,
                Height = 150,
                Content = new TextBlock
                {
                    Text = "Je bent niet aan de beurt!",
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    TextAlignment = Avalonia.Media.TextAlignment.Center,
                    FontSize = 16,
                    Margin = new Thickness(20)
                }
            };
            await foutWindow.ShowDialog(this);
        }

        

        //Knoppen kaart geven aan Speler

        private void GeefKaartPlayer1(object? sender, RoutedEventArgs e)
        {
            HierZijnWE = "p1MoetNu";
            if (IsBeurtCorrect() == true)
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
                int index = _random.Next(_randomStop.Count);
                int randomNumber = _randomStop[index];
                if (_players[0].totaalPunten >= randomNumber)
                {
                    ShowPlayer1.IsEnabled = false;
                    ListWZWN.Remove("p1MoetNu");
                    itemVerwijderd = true;
                }
                WaarZijnWeNUOpHogen();
                
            }
        }

        private void GeefKaartPlayer2(object? sender, RoutedEventArgs e)
        {
            HierZijnWE = "p2MoetNu";
            if (IsBeurtCorrect() == true)
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
                int index = _random.Next(_randomStop.Count);
                int randomNumber = _randomStop[index];
                if (_players[1].totaalPunten >= randomNumber)
                {
                    ShowPlayer2.IsEnabled = false;
                    ListWZWN.Remove("p2MoetNu");
                    itemVerwijderd = true;
                }
                WaarZijnWeNUOpHogen();
            }
        }

        private void GeefKaartPlayer3(object? sender, RoutedEventArgs e)
        {
            HierZijnWE = "p3MoetNu";
            if (IsBeurtCorrect() == true)
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
                int index = _random.Next(_randomStop.Count);
                int randomNumber = _randomStop[index];
                if (_players[2].totaalPunten >= randomNumber)
                {
                    ShowPlayer3.IsEnabled = false;
                    ListWZWN.Remove("p3MoetNu");
                    itemVerwijderd = true;
                }
                WaarZijnWeNUOpHogen();
            }
        }

        private void GeefKaartPlayer4(object? sender, RoutedEventArgs e)
        {
            HierZijnWE = "p4MoetNu";
            if (IsBeurtCorrect() == true)
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
                int index = _random.Next(_randomStop.Count);
                int randomNumber = _randomStop[index];
                if (_players[3].totaalPunten >= randomNumber)
                {
                    ShowPlayer4.IsEnabled = false;
                    ListWZWN.Remove("p4MoetNu");
                    itemVerwijderd = true;
                }   
                WaarZijnWeNUOpHogen();
            }
        }

        private void GeefKaartDealer(object? sender, RoutedEventArgs e)
        {
            HierZijnWE = "DealerMoetNu";
            if (IsBeurtCorrect() == true)
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
                    ListWZWN.Remove("dealerMoetNu");
                    itemVerwijderd = true;
                }
                WaarZijnWeNUOpHogen();
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