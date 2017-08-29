namespace BowlingGame
{
    public class Game
    {
        public int Score { get; set; }

        public Game()
        {
            Score = 0;
        }
        public void Roll(int pins)
        {
            Score += pins;
        }

    }
}