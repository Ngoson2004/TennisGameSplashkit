using System;
using SplashKitSDK;

namespace Custom_Program
{
	public class MainState : IGameState
	{
        private Court _court;
        private Net _net;
        private Player _player1;
        private Player _player2;
        private Ball _tennisball;
        private Score _score;

        public MainState() : base()
		{
            // Initialise the equipments of the game and where to draw them
            _court = new Court(0, 500);
            _net = new Net(550, 450);
            // Initialise players' positions and sprites
            _player1 = new Player(200, 500, "/Users/ngoson/Desktop/Custom Program/image/player1.png", "/Users/ngoson/Desktop/Custom Program/image/player1swing.png");
            _player2 = new Player(900, 500, "/Users/ngoson/Desktop/Custom Program/image/player2.png", "/Users/ngoson/Desktop/Custom Program/image/player2swing.png");
            _tennisball = new Ball("/Users/ngoson/Desktop/Custom Program/image/tennisball.png");
            _score = new Score();
		}

        public void HandleInput()
        {
            //These are the button instructions for player 1
            if (SplashKit.KeyDown(KeyCode.AKey))
            {
                _player1.MoveProperty = Player.movestrategy.Left;
                _player1.ExecuteMove();
            }

            if (SplashKit.KeyDown(KeyCode.DKey))
            {
                _player1.MoveProperty = Player.movestrategy.Right;
                _player1.ExecuteMove();
            }

            if (SplashKit.KeyDown(KeyCode.WKey))
            {
                _player1.MoveProperty = Player.movestrategy.Up;
                _player1.ExecuteMove();
            }

            if (SplashKit.KeyDown(KeyCode.SKey))
            {
                _player1.MoveProperty = Player.movestrategy.Down;
                _player1.ExecuteMove();
            }

            if (SplashKit.KeyDown(KeyCode.SpaceKey) && SplashKit.SpriteCollision(_player1.GetSprite, _tennisball.GetSprite))
            {
                _player1.Hit(_tennisball);
            } else if (SplashKit.KeyReleased(KeyCode.SpaceKey))
            {
                _player1.NotHit();
            }

            //These are the button instructions for player 2
            if (SplashKit.KeyDown(KeyCode.LeftKey))
            {
                _player2.MoveProperty = Player.movestrategy.Left;
                _player2.ExecuteMove();
            }

            if (SplashKit.KeyDown(KeyCode.RightKey))
            {
                _player2.MoveProperty = Player.movestrategy.Right;
                _player2.ExecuteMove();
            }

            if (SplashKit.KeyDown(KeyCode.UpKey))
            {
                _player2.MoveProperty = Player.movestrategy.Up;
                _player2.ExecuteMove();
            }

            if (SplashKit.KeyDown(KeyCode.DownKey))
            {
                _player2.MoveProperty = Player.movestrategy.Down;
                _player2.ExecuteMove();
            }

            if (SplashKit.KeyDown(KeyCode.ReturnKey) && SplashKit.SpriteCollision(_player2.GetSprite, _tennisball.GetSprite))
            {
                _player2.Hit(_tennisball);
            } else if (SplashKit.KeyReleased(KeyCode.ReturnKey))
            {
                _player2.NotHit();
            }

            //Press Esc to return to main menu
            if (SplashKit.KeyDown(KeyCode.EscapeKey))
            {
                GameContext.GetInstance().SetState(new MenuState());
            } 
        }

        //Implement score updating logic
        private void UpdateScoring()
        {
            if (_tennisball != null)
            {
                if (_tennisball.X == 0 || (_tennisball.X < 600 && _tennisball.Y >= 800))
                {
                    _score.WinPoint2();         //One point for player 2

                }
                else if (_tennisball.X == 1200 || (_tennisball.X > 600 && _tennisball.Y >= 800))
                {
                    _score.WinPoint1();         //One point for player 1
                }
            }
            
        }

        public void Update()
        {

            //Update the ball to mov
            _tennisball.ExecuteMove();
            UpdateScoring();

            //Remove old ball and generate new ball when it falls out the screen
            if (_tennisball.X < 0 || _tennisball.X > 1200 || _tennisball.Y < 0 || _tennisball.Y > 800)
            {
                _tennisball = null;
                _tennisball = new Ball("/Users/ngoson/Desktop/Custom Program/image/tennisball.png");
            }

            if (_score.Games1 > 6 && (_score.Games1 - _score.Games2 >= 2))
            {
                GameContext.GetInstance().P1WinMatch = true;
                GameContext.GetInstance().SetState(new EndState());
            } else if (_score.Games2 > 6 && (_score.Games2 - _score.Games1 >= 2))
            {
                GameContext.GetInstance().SetState(new EndState());
            }
        }

        public void Draw()
        {
            //Draw the equipments of the game
            _court.Draw();
            _net.Draw();
            //Draw the game objects
            _player1.Draw();
            _player2.Draw();
            _tennisball.Draw();
            //Draw score table
            _score.Draw();
        }
    }
}

