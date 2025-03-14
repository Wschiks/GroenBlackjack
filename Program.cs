using Avalonia;
using System;

namespace avaloniaAppGroen;

class Program
{
    
    [STAThread]
    public static void Main(string[] args)
    {

        Pak pak = new Pak();
        
        pak.RandKaart();

        
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

   
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}