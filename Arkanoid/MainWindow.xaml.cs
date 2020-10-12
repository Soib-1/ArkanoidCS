using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Arkanoid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        private int windowWidth = 600;
        private double score;
        private int speedX = 6;
        private int speedY = 6;
        private bool gameOver;
        private Rect ballHitBox;
        private Rect platformHitBox;
        
        public MainWindow()
        {
            InitializeComponent();

            gameTimer.Tick += MainEventTimer;
            gameTimer.Interval = TimeSpan.FromMilliseconds(1);
            StartGame();
        }

        private bool checkColission()
        {
            return true;
        }

        private void MainEventTimer(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Left) && Canvas.GetLeft(Platform) > 0)
            {
                Canvas.SetLeft(Platform, Canvas.GetLeft(Platform) - 10);
            }
            if (Keyboard.IsKeyDown(Key.Right) && Canvas.GetLeft(Platform) < windowWidth - 220)
            {
                Canvas.SetLeft(Platform, Canvas.GetLeft(Platform) + 10);
            }
            
            
            ballHitBox = new Rect(Canvas.GetLeft(Ball), Canvas.GetTop(Ball), Ball.Width, Ball.Height);
            platformHitBox = new Rect(Canvas.GetLeft(Platform), Canvas.GetTop(Platform), Platform.Width, Platform.Height);
            TxtScore.Content = ballHitBox.Y + " < " + platformHitBox.Y;
            
            if ((ballHitBox.X > 0) && (ballHitBox.Y > 0) && (ballHitBox.Y + ballHitBox.Height < platformHitBox.Y) && ballHitBox.X + ballHitBox.Width < windowWidth-ballHitBox.Width && ballHitBox.Y + ballHitBox.Height < 800-ballHitBox.Height)
            {
                Canvas.SetTop(Ball, Canvas.GetTop(Ball) + speedY);
                Canvas.SetLeft(Ball, Canvas.GetLeft(Ball) + speedX);   
            } else if (!(ballHitBox.X + ballHitBox.Width < windowWidth - ballHitBox.Width) || !(ballHitBox.X > 0))
            {
                speedX = -speedX;
                Canvas.SetTop(Ball, Canvas.GetTop(Ball) + speedY);
                Canvas.SetLeft(Ball, Canvas.GetLeft(Ball) + speedX); 
            } else if (!(ballHitBox.Y + ballHitBox.Height < 800 - ballHitBox.Height) || !(ballHitBox.Y > 0))
            {
                speedY = -speedY;
                Canvas.SetTop(Ball, Canvas.GetTop(Ball) + speedY);
                Canvas.SetLeft(Ball, Canvas.GetLeft(Ball) + speedX); 
            } else if (!(ballHitBox.Y + ballHitBox.Height < platformHitBox.Y))
            {
                if (ballHitBox.X > platformHitBox.X && ballHitBox.X < platformHitBox.X + platformHitBox.Width)
                {
                    speedY = -speedY;
                    Canvas.SetTop(Ball, Canvas.GetTop(Ball) + speedY);
                    Canvas.SetLeft(Ball, Canvas.GetLeft(Ball) + speedX); 
                }
                else
                {
                    Canvas.SetTop(Ball, Canvas.GetTop(Ball) + speedY);
                    Canvas.SetLeft(Ball, Canvas.GetLeft(Ball) + speedX);  
                }

            }
            
        }

        private void GameCanvas_OnKeyDown(object sender, KeyEventArgs e)
        {


            if (e.Key == Key.R)
            {
                StartGame();
            }
        }

        private void GameCanvas_OnKeyUp(object sender, KeyEventArgs e)
        {

        }

        private void StartGame()
        {
            GameCanvas.Focus();

            score = 0;

            gameOver = false;
            Canvas.SetTop(Ball, 190);
            Block obstacle;
            for (int i = 0; i < 10; i++)
            {
                obstacle = new Block();
                GameCanvas.Children.Add(obstacle.blockImage);
                obstacle.SetPos(50 + 50 * i, 10);
                
            }
            
            for (int i = 0; i < 5; i++)
            {
                obstacle = new Block();
                GameCanvas.Children.Add(obstacle.blockImage);
                obstacle.SetPos(75 + 100 * i, 110);
                
            }
            
            for (int i = 0; i < 10; i++)
            {
                obstacle = new Block();
                GameCanvas.Children.Add(obstacle.blockImage);
                obstacle.SetPos(50 + 50 * i, 220);
                
            }
            
            for (int i = 0; i < 10; i++)
            {
                obstacle = new Block();
                GameCanvas.Children.Add(obstacle.blockImage);
                obstacle.SetPos(50 + 50 * i, 330);
                
            }

            gameTimer.Start();
        }

        private void EndGame()
        {
            
        }
    }
}