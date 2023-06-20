using System;
using SplashKitSDK;

namespace Custom_Program
{
    public class Program
    { 
        
        public static void Main()
        {
            GameContext.GetInstance().Run();       //Singleton pattern. This is a demonstration of abstraction. The program only needs to call a game context variable and tell it to run.              
        }
    }
}


