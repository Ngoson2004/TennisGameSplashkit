using System;
using SplashKitSDK;
namespace Custom_Program
{
	public class InstructionState : IGameState
	{
		private Bitmap _instruction;

		public InstructionState() : base()
		{
			_instruction = new Bitmap("Instruction", "/Users/ngoson/Desktop/Custom Program/image/Instruction.png");
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
            SplashKit.DrawBitmap(_instruction, 30, 10);
        }
    }
}

