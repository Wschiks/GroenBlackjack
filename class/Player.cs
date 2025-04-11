using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using avaloniaAppGroen;

public class Player
{
    public string Name { get; set; }
    public List<string> Kaarten { get; private set; } = new List<string>();

    public int GetTotaalPunten() 
    {
        return totaalPunten;
    }
    public int totaalPunten = 0;
    
    public int stringGetal;
    //als kaart word toegevoegd aan de list laat hij de kaart zien.
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
        }

        Console.WriteLine(totaalPunten);
    }

    

    public Player(string name)
    {
        Name = name;
    }


    public void VoegKaartToe(string kaart)
    {
        Kaarten.Add(kaart);
    }
}