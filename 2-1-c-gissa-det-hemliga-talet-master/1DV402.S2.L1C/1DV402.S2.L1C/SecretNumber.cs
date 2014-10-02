using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1C
{
    enum Outcome { Indefinite, Low, High, Right, NoMoreGuesses, OldGuess}
    class SecretNumber
    {
        private GuessedNumber[] _guessedNumbers;
        private int? _number;
        public const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess
        {
            get {
                // lägg till om man gissat rätt
                    if ((Count < MaxNumberOfGuesses) || )
                    {
                        //return false eller true // om den är sant
                        return true;
                    }
                    else
                    {
                        //return true eller false
                        return false;
                    }
                }
            private set { }
        }
        public int Count
        {
            get { return ;}
            private set {}
        }
        public int? Guess
        {
            get {
                if (Count == 0)
                {
                    return null;
                }
                else
                {
                    return;
                }
                }
            private set { }
        }
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
                    if (Count < 7)
                    {
                        return null;
                    }
                    else
                    {
                        return _number;
                    }
                }
            set { }
        }
        public Outcome Outcome
        {
            get {
                if(Count == 0)
                {
                    return Outcome.Indefinite;
                }
                else
                {
                    return 
                }
                }
            private set {}
        }

        public void Initialize()
        {

        }
        public Outcome MakeGuess(int guess)
        {
            try
            {
                if (guess < 0 || guess > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }

            }
            catch (ArgumentOutOfRangeException)
            {

            }

            return Outcome;
        }
        public SecretNumber()
        {
            
        }
    }
}
