using System;
using SplashKitSDK;

namespace Custom_Program
{
	public class Score
	{
        private int TableWidth = 300;
        private int TableHeight = 300;
        private int CellWidth = 100;
        private int CellHeight = 100;
        private int _point1, _point2;
        private int _games1, _games2;

        public Score()
        {
            _point1 = 0;
            _games1 = 0;
            _point2 = 0;
            _games2 = 0;
        }

        public void WinPoint1()
        {
            Point1++;
            if (Point1 > 4 && Point1 - Point2 >= 2)
            {
                // Player 1 wins the game
                Games1++;
                ResetPoint1();
            }
        }

        public void ResetPoint1()
        {
            Point1 = 0;
        }

        public void WinPoint2()
        {
            Point2++;
            if (Point2 > 4 && Point2 - Point1 >= 2)
            {
                // Player 2 wins the game
                Games2++;
                ResetPoint2();
            }
        }

        public void ResetPoint2()
        {
            Point2 = 0;
        }

        public int Point1
        {
            get
            {
                return _point1;
            }
            set
            {
                _point1 = value;
            }
        } // Player1 score

        public int Games1
        {
            get
            {
                return _games1;
            }
            set
            {
                _games1 = value;
            }
        } // Player1 games

        public int Point2
        {
            get
            {
                return _point2;
            }
            set
            {
                _point2 = value;
            }
        }
        // Player2 score

        public int Games2
        {
            get
            {
                return _games2;
            }
            set
            {
                _games2 = value;
            }
        }
        // Player2 games

        public void Draw()
        {
            // Draw the table border
            SplashKit.DrawRectangle(Color.BlueViolet, 0, 0, TableWidth, TableHeight);

            // Draw horizontal lines
            for (int row = 1; row < 3; row++)
            {
                int y = row * CellHeight;
                SplashKit.DrawLine(Color.White, 0, y, TableWidth, y);
            }

            // Draw vertical lines
            for (int col = 1; col < 3; col++)
            {
                int x = col * CellWidth;
                SplashKit.DrawLine(Color.White, x, 0, x, TableHeight);
            }

            // Write points on table
            SplashKit.DrawText("Player", Color.White, "Arial", 14, 20, 20);
            SplashKit.DrawText("Game", Color.White, "Arial", 14, CellWidth + 20, 20);
            SplashKit.DrawText("Point", Color.White, "Arial", 14, 2 * CellWidth + 20, 20);

            SplashKit.DrawText("Player 1", Color.White, "Arial", 14, 20, CellHeight + 20);
            SplashKit.DrawText(Games1.ToString(), Color.White, "Arial", 14, CellWidth + 20, CellHeight + 20);
            SplashKit.DrawText(Point1.ToString(), Color.White, "Arial", 14, 2 * CellWidth + 20, CellHeight + 20);

            SplashKit.DrawText("Player 2", Color.White, "Arial", 14, 20, 2 * CellHeight + 20);
            SplashKit.DrawText(Games2.ToString(), Color.White, "Arial", 14, CellWidth + 20, 2 * CellHeight + 20);
            SplashKit.DrawText(Point2.ToString(), Color.White, "Arial", 14, 2 * CellWidth + 20, 2 * CellHeight + 20);
        }
    }
}

