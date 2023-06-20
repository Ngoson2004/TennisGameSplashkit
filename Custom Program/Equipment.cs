using System;
using SplashKitSDK;
namespace Custom_Program
{
	public abstract class Equipment
	{
		public Equipment() : base()
		{
		}

		public abstract double X { get; set; }
		public abstract double Y { get; set; }
		public abstract void Draw();
	}
}

