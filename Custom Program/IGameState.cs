using System;
using SplashKitSDK;

namespace Custom_Program
{
	public interface IGameState			//We have state pattern here
	{
		public void HandleInput();
		public void Update();
		public void Draw();
	}
}

