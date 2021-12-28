using System;

namespace singletone
{
    class Program
    {
        class Game
        {
            public Ball ball {get; set;}
            public void IsOnTheCourt()
            {
                ball = Ball.BallToTheCourt();
            }
        }
        class Ball
        {
            private static Ball ball;
            public static Ball BallToTheCourt()
            {
                if (ball == null)
                    ball = new Ball();
                else
                    Console.WriteLine("Мяч уже на площадке");
                return ball;
            }
        }
        static void Main(string[] args)
        {
            Game game = new Game();

            game.IsOnTheCourt(); //мяч вводится в игру на площадке
            game.IsOnTheCourt(); //выведет сообщение о том, что мяч уже на площадке
        }
    }
}
