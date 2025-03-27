using System;
using System.Collections.Generic;

namespace avaloniaAppGroen;


public class Player
{
    public class Speler
    {
        public string Naam { get; set; }
        public int Kaarten { get; set; }

        // Constructor om een speler te initialiseren
        public Speler(string naam, int aantalKaarten)
        {
            Naam = naam;
            Kaarten = aantalKaarten;
        }
    }

    public class Game
    {
        public int NumberOfPlayers { get; } 

        private Speler[] spelers;

        
        public Game(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;
            spelers = new Speler[NumberOfPlayers]; 
        }
        private List<string> naam = new List<string>
        {
            "Emma", "Daan", "Sophie", "Pim"
        };
       
        public void NaamSpeler()
        {
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                spelers[i] = new Speler(naam[i],1); 
            }
        }
    }

    







   
}
