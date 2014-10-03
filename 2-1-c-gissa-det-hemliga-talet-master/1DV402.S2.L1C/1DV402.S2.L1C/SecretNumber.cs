using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1C
{
    public enum Outcome { Indefinite, Low, High, Right, NoMoreGuesses, OldGuess}
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
            get {
                    if ((Count < MaxNumberOfGuesses) || Guess != _number)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            private set { }
        }
        public int Count{get; private set;}
        public int? Guess {get; private set;}
        public GuessedNumber[] GuessedNumbers
        {
            //refererar till en kopia av _guessedNumbers field
            get {
                GuessedNumber[] copyGuessedArray = new GuessedNumber[_guessedNumbers.Length];
                Array.Copy(_guessedNumbers, copyGuessedArray, _guessedNumbers.Length);
                return copyGuessedArray; 
                }
        }
        public int? Number
        {
            get {
                    if (CanMakeGuess)
                    {
                        return null;
                    }
                    else
                    {
                        return _number;
                    }
                }
            set { _number = value; }
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
            if (guess < 0 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (guess < _number)
            {
                Outcome = Outcome.Low;
            }
            else if (guess > _number)
            {
                Outcome = Outcome.High;
            }
            else if (guess == _number)
            {
                Outcome = Outcome.Right;
            }
            int counting = 0;
            do
            {
                if (guess == _guessedNumbers[counting].Number)
                {
                    Outcome = Outcome.OldGuess;
                }
                counting++;
            } while (counting < Count);
            if (Outcome != Outcome.OldGuess)
            {
                Count++;
            }
            return Outcome;
        }
        
    }
}
