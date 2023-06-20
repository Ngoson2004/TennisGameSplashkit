using System;
using SplashKitSDK;

namespace Custom_Program
{

	public class Player : GameObject
	{
        private Bitmap _playerpic;
		private Bitmap _swingpic;
        private Sprite _playersprite;
		public enum movestrategy
		{
			Up,
			Down,
			Left,
			Right
		}

        public Player(float x, float y, string filename1, string filename2)		//Initialise the positions and GUI for the the players
		{
			Random _seed1 = new();
			int i = _seed1.Next();
			string playername = "Player image no. " + i.ToString();
			string swingname = "Swing image no." + i.ToString();
			_playerpic = new Bitmap(playername, filename1);
			_swingpic = new Bitmap(swingname, filename2);
			_playersprite = new Sprite(_playerpic);						//Create sprites for players
			_playersprite.AddLayer(_swingpic, "player swing racket");	//Create a layer to use when the player hits ball
			//Initialise the positions of the sprites
            _playersprite.X = x;
			_playersprite.Y = y;
		}

		public movestrategy MoveProperty		//this is property of the enumeration movestrategy. It will be set in MainState
		{
			get;
			set;
		}

		public override void ExecuteMove()		//This function is to execute the movements of player	
		{
			 switch (MoveProperty)
			{
				case movestrategy.Up:
					SplashKit.MoveSpriteTo(_playersprite, X, Y - 5);
                    break;
				case movestrategy.Down:
                    SplashKit.MoveSpriteTo(_playersprite, X, Y + 5);
                    break;
				case movestrategy.Left:
                    SplashKit.MoveSpriteTo(_playersprite, X - 5, Y);
                    break;
				case movestrategy.Right:
                    SplashKit.MoveSpriteTo(_playersprite, X + 5, Y);
                    break;
			}
        }

		public void Hit(Ball ball)									//When the player call Hit(), it's Sprite layer (swing racket) shows up
		{
			SplashKit.SpriteHideLayer(_playersprite, 0);
			SplashKit.SpriteShowLayer(_playersprite, 1);
			ball.ChangeDir();
        }

		public void NotHit()								//Return to normal image when player does not hit
		{
			SplashKit.SpriteHideLayer(_playersprite, 1);
			SplashKit.SpriteShowLayer(_playersprite, 0);
		}

        public override void Draw()
        {
            _playersprite.Draw();
        }

        //Properties to return or set coordinators for the sprite
        public override float X
		{
			get
			{
				return _playersprite.X;
			}
			set
			{
				_playersprite.X = value;
			}
		}

        public override float Y
        {
			get
			{
				return _playersprite.Y;
			}
			set
			{
				_playersprite.Y = value;
			}
        }

        public override Sprite GetSprite		//This is used when sprite colllision detection is needed
		{
			get
			{
				return _playersprite;
			}
		}
    }
}

