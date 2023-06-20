using System;
using SplashKitSDK;

namespace Custom_Program
{
    
	public class MenuState : IGameState
	{

        public MenuState() : base()
		{

		}

        public void HandleInput()
        {
            if (SplashKit.KeyDown(KeyCode.Num1Key))
            {
                GameContext.GetInstance().SetState(new MainState());
            }

            if (SplashKit.KeyDown(KeyCode.Num2Key))
            {
                GameContext.GetInstance().SetState(new InstructionState());
            }
        }

        public void Update()
        {

        }

        public void Draw()
        {
            SplashKit.DrawText("1 Start Game", Color.Beige, "Arial", 24, 550, 400);
            SplashKit.DrawText("2 Instruction", Color.Beige, "Arial", 24, 550, 420);
        }

    }
}

