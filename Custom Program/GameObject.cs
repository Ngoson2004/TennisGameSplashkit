using System;
using SplashKitSDK;

namespace Custom_Program
{
	public abstract class GameObject
	{
		

		public GameObject() : base()
		{
				
		}

		public abstract void ExecuteMove();
		public abstract void Draw();
		public abstract Sprite GetSprite { get; }
		public abstract float X { get; set; }
		public abstract float Y { get; set; }

 	}
}

