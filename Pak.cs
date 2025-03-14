using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

public class Pak
{
    Random random = new Random();


    List<string> pak = new List<string>
    {
        "harten 2", "harten 3", "harten 4", "harten 5", "harten 6", "harten 7", "harten 8", "harten 9", "harten 10",
        "harten Boer", "harten Vrouw", "harten Koning", "harten As",
        "schoppen 2", "schoppen 3", "schoppen 4", "schoppen 5", "schoppen 6", "schoppen 7", "schoppen 8", "schoppen 9",
        "schoppen 10", "schoppen Boer", "schoppen Vrouw", "schoppen Koning", "schoppen As",
        "klaveren 2", "klaveren 3", "klaveren 4", "klaveren 5", "klaveren 6", "klaveren 7", "klaveren 8", "klaveren 9",
        "klaveren 10", "klaveren Boer", "klaveren Vrouw", "klaveren Koning", "klaveren As",
        "ruiten 2", "ruiten 3", "ruiten 4", "ruiten 5", "ruiten 6", "ruiten 7", "ruiten 8", "ruiten 9", "ruiten 10",
        "ruiten Boer", "ruiten Vrouw", "ruiten Koning", "ruiten As"
    };


    public void RandKaart()
    {
        int kaart = random.Next(pak.Count);

        pak.Remove(pak[kaart]);

      
        
    }
}