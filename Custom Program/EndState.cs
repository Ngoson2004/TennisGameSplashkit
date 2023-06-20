using System;
using SplashKitSDK;

namespace Custom_Program
{
	public class EndState : IGameState
	{
		public EndState() : base()
		{
		}

        public void HandleInput()
        {
            if (SplashKit.KeyDown(KeyCode.QKey))
            {
                GameContext.GetInstance().SetState(new MenuState());
            }
        }

        public void Update()
        {

        }

        public void Draw()
        {
            if (GameContext.GetInstance().P1WinMatch)
            {
                SplashKit.DrawText("Congratulations! Player 1 win the match", Color.White, 20, 20);
            } else
            {
                SplashKit.DrawText("Congratulations! Player 2 win the match", Color.White, 20, 20);
            }
            SplashKit.DrawText("Press Q to return to the menu", Color.White, 20, 50);
        }
    }
}

