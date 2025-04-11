using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using avaloniaAppGroen;

public class Dealer
{
    
    public List<string> Kaarten { get; private set; } = new List<string>();

    public int GetTotaalPunten() 
    {
        return totaalPunten;
    }
    public int totaalPunten = 0;
    
    public int stringGetal;
   
    public void PuntKaarten()
    {
        totaalPunten = 0;

        for (int i = 0; i < Kaarten.Count; i++)
        {
            string waarde = Kaarten[i].Split(' ')[1];

            if (!int.TryParse(waarde, out stringGetal))
            {
                stringGetal = 10;
            }

            totaalPunten += stringGetal;

            if (totaalPunten == 21)
            {
                Console.WriteLine("BINGO!");
            }
        }

        Console.WriteLine(totaalPunten);
    }
    


    public void VoegKaartToe(string kaart)
    {
        Kaarten.Add(kaart);
    }
}