using System;
using SplashKitSDK;
namespace Custom_Program
{
	public class Court : Equipment
	{
		private Bitmap _image;
		private Vector2D _imageposition;

		public Court(float x, float y)
		{
			_image = new Bitmap("court image", "/Users/ngoson/Desktop/Custom Program/image/TennisCourt.png");
			_imageposition.X = x;
			_imageposition.Y = y;
		}

		public override double X
		{
			get
			{
				return _imageposition.X;
			}

			set
			{
				_imageposition.X = value;
			}
		}

		public override double Y
		{
			get
			{
				return _imageposition.Y;
			}

			set
			{
				_imageposition.Y = value;
			}
		}

        public override void Draw()
        {
			SplashKit.DrawBitmap(_image, X, Y);
        }
    }
}

