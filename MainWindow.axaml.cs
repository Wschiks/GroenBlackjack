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

        
        // list van de random getallen. als de speler zo veel punten heeft is hij klaar
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

        private int puntenDealer = 0;

        // als de dealer een fout maakt +1
        private void UpFoutenDealer()
        {
            puntenDealer++;
            PuntenDealerText.Text = $"Fouten: {puntenDealer}";
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



    
        public String WaarZijnWeNU = "p1MoetNu";
        private String HierZijnWE ;

        //List met alle spelers om te weten we er aan de beurt is
        private List<String> ListWZWN = new List<String> 
        {
            "p1MoetNu", "p2MoetNu", "p3MoetNu", "p4MoetNu", "DealerMoetNu"
        };

        //print list
        private void PrintListWZWN()
        {
            for (int i = 0; i < ListWZWN.Count; i++)
            {
                Console.WriteLine(ListWZWN[i]);
            }
        }
        
        private bool itemVerwijderd = false;
        int getalWaarZijnWeNU = 1;
        private int save;
        private Boolean dealerIsWeg = false;
        
        
        //1 verder gaan in de list met alle spelers
        
        private void WaarZijnWeNUOpHogen()
        {
           
            if (_dealer.Kaarten.Count >= 2)
            {
                
            }
            if (getalWaarZijnWeNU >= ListWZWN.Count)
            {
                getalWaarZijnWeNU = 0;
            }

            if (itemVerwijderd)
            {
                itemVerwijderd = false;
                if (!ListWZWN.Contains("DealerMoetNu"))
                {
                    getalWaarZijnWeNU = 0;
                }
            }

            WaarZijnWeNU = ListWZWN[getalWaarZijnWeNU];

            if (!itemVerwijderd)
            {
                getalWaarZijnWeNU++;
                Console.WriteLine("alles gaat goed");
            }

            Console.WriteLine("WaarZijnWeNU: " + WaarZijnWeNU + " HierZijnWE: " + HierZijnWE);
        }



        
         
        private int spelerIndex;

        private bool IsBeurtCorrect()
        {
            if (WaarZijnWeNU != HierZijnWE)
            {
                ShowFoutPopup();
                UpFoutenDealer();
                return false;
            }
            return true;
        }

//laat de pop up zien
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
                WaarZijnWeNUOpHogen();
                if (_players[0].totaalPunten >= randomNumber)
                {
                    ShowPlayer1.IsEnabled = false;
                    ListWZWN.Remove("1MoetNu");
                    itemVerwijderd = true;
                }

                PrintListWZWN();
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
                WaarZijnWeNUOpHogen();

                
                if (_players[1].totaalPunten >= randomNumber)
                {
                    ShowPlayer2.IsEnabled = false;
                    ListWZWN.Remove("p2MoetNu");
                    itemVerwijderd = true;
                }
             
                PrintListWZWN();
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
                WaarZijnWeNUOpHogen();
                if (_players[2].totaalPunten >= randomNumber)
                {
                    ShowPlayer3.IsEnabled = false;
                    ListWZWN.Remove("3MoetNu");
                    itemVerwijderd = true;
                }
                PrintListWZWN();
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
                WaarZijnWeNUOpHogen();
                if (_players[3].totaalPunten >= randomNumber)
                {
                    ShowPlayer4.IsEnabled = false;
                    itemVerwijderd = true;
                    ListWZWN.Remove("p4MoetNu");
                }   
                PrintListWZWN();
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
                WaarZijnWeNUOpHogen();
                if (_dealer.totaalPunten >= 17)
                {
                    ShowDealer.IsEnabled = false;
                    itemVerwijderd = true;
                    ListWZWN.Remove("DealerMoetNu");
                }
               
                PrintListWZWN();
            }
        }

Boolean pakIsGepakt = false;
        // niet geschudden pak printen
        private void Show_Pak(object? sender, RoutedEventArgs e)
        {
            _pak.PrintPak();
            pakIsGepakt = true;
            showPak.IsVisible = false;    

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
            if (pakIsGepakt == true)
            {
                _pak.SchudPak();
                Is_Pak_Geschud = true;
                shudden.IsVisible = false;  
                Console.WriteLine("Pak Schudden");
            }
            else
            {
                ShowPopup();
                UpFoutenDealer();
            }
           
        }
        private async void ShowPopup()
        {
            var foutWindow = new Window
            {
                Title = "Foute Beurt!",
                Width = 300,
                Height = 150,
                Content = new TextBlock
                {
                    Text = "Je moet eerst iets anders doen!!",
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    TextAlignment = Avalonia.Media.TextAlignment.Center,
                    FontSize = 16,
                    Margin = new Thickness(20)
                }
            };
            await foutWindow.ShowDialog(this);
        }

        // eerste kaart van geschudden stabel pakken
        private void PickKaart(object? sender, RoutedEventArgs e)
        {
            _pak.PickKaart();
        }
    }
}