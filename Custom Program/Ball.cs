using System;
using System.Reflection.Metadata;
using SplashKitSDK;
namespace Custom_Program
{
	public class Ball : GameObject
	{
		private Bitmap _image;
		private Sprite _ballimg;
        private double _time;
        private double _velocity;

        public Ball(string filename)
		{
            //set the image for ball
            _image = new Bitmap("tennis ball", filename);
            _ballimg = new Sprite(_image);
            _time = 0;
            _velocity = 5;
        }

        public override void ExecuteMove()
        {
            // Define the parabolic motion equation (example equation: y = a*x^2 + b*x + c)
            double a = -0.002; // adjust the values of a, b, and c to control the shape of the parabola
            double b = 0.3;
            double c = 800;

            // Update the position of the ball based on the parabolic motion equation
            double x = _time;
            double y = a * x * x + b * x + c;

            X = 350 + (float)x;
            Y = 900 - (float)y; 

            _time += _velocity; // adjust the increment value to control the speed of the ball
        }

        public override void Draw()
        {
            _ballimg.Draw();
        }

        public void ChangeDir()
        {
            _velocity *= -1;        //Reverse ball's direction
        }

        public override Sprite GetSprite    //This is used when sprite colllision detection is needed
        {
            get
            {
                return _ballimg;
            }
        }

        //Properties to return or set coordinators for the sprite
        public override float X
        {
            get
            {
                return _ballimg.X;
            }
            set
            {
                _ballimg.X = value;
            }
        }

        public override float Y
        {
            get
            {
                return _ballimg.Y;
            }
            set
            {
                _ballimg.Y = value;
            }
        }
    }
}

