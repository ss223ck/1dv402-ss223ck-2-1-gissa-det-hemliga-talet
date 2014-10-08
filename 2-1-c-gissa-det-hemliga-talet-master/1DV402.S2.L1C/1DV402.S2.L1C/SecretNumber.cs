using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1C
{
    public enum Outcome { Indefinite, Low, High, Right, NoMoreGuesses, OldGuess }
    public class SecretNumber
    {
        private Random randomInstance = new Random();
        private GuessedNumber[] _guessedNumbers;
        private int? _number;
        public const int MaxNumberOfGuesses = 7;

        public SecretNumber()
        {
            _guessedNumbers = new GuessedNumber[MaxNumberOfGuesses];
            Initialize();
        }
        public bool CanMakeGuess
        {
            get { return Count < MaxNumberOfGuesses && Outcome != Outcome.Right; }
        }
        public int Count { get; private set; }
        public int? Guess { get; private set; }
        public GuessedNumber[] GuessedNumbers
        {
            //refererar till en kopia av _guessedNumbers field
            get
            {
                GuessedNumber[] copyGuessedArray = new GuessedNumber[_guessedNumbers.Length];
                Array.Copy(_guessedNumbers, copyGuessedArray, _guessedNumbers.Length);
                return copyGuessedArray;
            }
        }
        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                else
                {
                    return _number;
                }
            }
            private set { _number = value; }
        }
        public Outcome Outcome { get; private set; }
        public void Initialize()
        {
            Array.Clear(_guessedNumbers, 0, MaxNumberOfGuesses);
            Number = randomInstance.Next(1, 101);
            Count = 0;
            Guess = null;
            Outcome = Outcome.Indefinite;
        }
        public Outcome MakeGuess(int guess)
        {
            if (!CanMakeGuess)
            {
                return Outcome = Outcome.NoMoreGuesses;
            }

            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            Guess = guess;

            if (_guessedNumbers.Any(n => n.Number == guess))
            {
                Outcome = Outcome.OldGuess;
            }
            else
            {
                if (guess < _number)
                {
                    Outcome = Outcome.Low;
                }
                else if (guess > _number)
                {
                    Outcome = Outcome.High;
                }
                else
                {
                    Outcome = Outcome.Right;
                }

                _guessedNumbers[Count].Number = guess;
                _guessedNumbers[Count].Outcome = Outcome;
                Count++;
            }

            return Outcome;
        }
    }
}
