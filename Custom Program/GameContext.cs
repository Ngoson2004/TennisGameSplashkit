using System;
using System.Reflection.Metadata;
using SplashKitSDK;


namespace Custom_Program
{

    public class GameContext        //GameContext is a singleton class
    {
        private IGameState _currentState; // This is polymorphism. This variable track which game state are we in
        private Bitmap _background;      // Create background variable
        private bool _p1win;    // Track who win the game
        private static GameContext instance;

        public static GameContext GetInstance()
        {
            if (instance == null)
            {
                instance = new GameContext();
            }

            return instance;
        }

        public void Run()               // The function to run the whole game
        {
            Initialize();               

            while (!SplashKit.QuitRequested())
            {

                HandleInput();
                Update();
                Draw();

                SplashKit.RefreshScreen(60);
            }
        }

        public void SetState(IGameState state)      //This method is used for states transition
        {
            _currentState = state;
        }

        public bool P1WinMatch      //Property tracking who win the match
        {
            get
            {
                return _p1win;
            }

            set
            {
                _p1win = value;
            }
        }

        // To ensure encapsulation, all of the functions below are private
        private void Initialize()       //Initialise the game
        {
            SplashKit.OpenWindow("Tennis Master", 1200, 800);
            _background = new Bitmap("background image", "/Users/ngoson/Desktop/Custom Program/image/background2.png");     //Initilise the background
            _currentState =  new MenuState();       //First, enter the menu state
            _p1win = false;
        }

        private void HandleInput()
        {
            _currentState.HandleInput();        //Call the HandleInput function of the current state
        }


        private void Update()                   //Call the update function of the current state
        {
            _currentState.Update();
        }

        private void Draw()                     //Draw any objects of the current state to create GUI
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen();

            SplashKit.DrawBitmap(_background, 0, 0);        //Draw background
            _currentState.Draw();

            SplashKit.RefreshScreen();
        }
        
    }
}


