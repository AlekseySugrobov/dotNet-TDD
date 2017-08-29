﻿using System.Collections.Generic;

namespace BowlingGame
{
    public class Game
    {
        private List<int> _rolls = new List<int>(21);
        private int _currentRoll = 0;
        public Game()
        {
            for (var i = 0; i < 22; i++)
            {
                _rolls.Add(0);
            }
        }
        public void Roll(int pinsHit)
        {
            _rolls[_currentRoll++] = pinsHit;
        }

        public int Score
        {
            get
            {
                var score = 0;
                var frameIndex = 0;
                for (var frame = 0; frame < 10; frame++)
                {
                    if (isStrike(frameIndex))
                    {
                        score += 10 + StrikeBonus(frameIndex);
                        frameIndex += 1;
                    }
                    else if (isSpare(frameIndex))
                    {
                        score += 10 + SpareBonus(frameIndex);
                        frameIndex += 2;
                    }
                    else
                    {
                        score += NormalFrameBonus(frameIndex);
                        frameIndex += 2;
                    }
                }
                return score;
            }
        }

        private int NormalFrameBonus(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1];
        }

        private int StrikeBonus(int frameIndex)
        {
            return _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
        }

        private int SpareBonus(int frameIndex)
        {
            return _rolls[frameIndex + 2];
        }

        private bool isSpare(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
        }

        private bool isStrike(int frameIndex)
        {
            return _rolls[frameIndex] == 10;
        }
    }
}