using System;
using System.Linq;

namespace assignment_two_hangman
{
    class Program
    {
        static Char[] RandomWord()
        {
            string[] arrayOfWords = new string[10] {"cow", "ball", "hope", "slim", "jeans", "memory", "helicopter", "paint", "dog", "flower"};
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, 10);
            String randomWord = arrayOfWords[randomIndex];
            var newWord = randomWord.ToCharArray();
            return newWord;
        }

        static Char[] AskUserForLetter()
        {
            Console.WriteLine("Guess a letter or word, and press enter.");
            Console.Write("Your choice: ");
            String word = new String(Console.ReadLine());
            Char[] guess = word.ToCharArray();
            return guess;
        }

        static Char[] HiddenRandomWord(Char[] value)
        {
            Char[] hiddenLetters = new Char[value.Length];
            
            for(int i = 0; i < value.Length; i++)
            {
                hiddenLetters[i] = '_';
                Char[] result = new Char[hiddenLetters[i]];
                result = hiddenLetters;
            }
                return hiddenLetters;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("The Hangman Game!");
            var getRandomWord = RandomWord();
            Console.WriteLine(getRandomWord);
            Console.WriteLine(HiddenRandomWord(getRandomWord));
            var hiddenPlayWord = HiddenRandomWord(getRandomWord);
            
            //var letter = AskUserForLetter();
            var lives = 0;
        
            bool keepLooping = true;
            while(keepLooping)
            {   
                lives++;
                Console.WriteLine(lives);
                var guess = AskUserForLetter();
                if(hiddenPlayWord.SequenceEqual(guess))
                {
                    Console.WriteLine("You got it!");
                    keepLooping = false;
                }
                
                
                keepLooping = false;
                for(int i = 0; i < getRandomWord.Length; i++)
                {
                    
                    for(int j = 0; j <guess.Length; j++)
                    {
                        
                    
                    if(lives == 10)
                    {
                        Console.WriteLine("You are out of lives.");
                        keepLooping = false;

                    } else if(hiddenPlayWord.SequenceEqual(guess))
                    {
                            Console.WriteLine("You made it!");
                            keepLooping = false;

                    } else if(guess[j] == getRandomWord[i])
                    {
                        hiddenPlayWord[i] = guess[j];
                        
                        
                        keepLooping = true;
            
                    } else if(guess[j] != getRandomWord[i])
                    {
                        
                        
                        keepLooping = true;
                    }
                    }
                } Console.WriteLine(hiddenPlayWord);
            }

           
            

        

        }
    }
}
