using System;
using System.Linq;
using System.Text;

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
            Console.WriteLine("Guess a letter or a word, and press enter.");
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
            //Console.WriteLine(getRandomWord);
            Console.WriteLine(HiddenRandomWord(getRandomWord));
            var hiddenPlayWord = HiddenRandomWord(getRandomWord);
            
            var lives = 10;
            var counter = 0;
            StringBuilder builder = new StringBuilder();
            var guess = AskUserForLetter();
            builder.Append(guess);
            Console.WriteLine("Your guesses: {0}", builder);
            var previousGuesses = " ";
            String[] guessStringArray = new String[10];
            char[] delimiter1 = new char[] { ',', ' ' };

            
           
            bool keepLooping = true;
            while(keepLooping)
            {   
                if(lives == 0)
                    {
                        Console.WriteLine("You are out of lives.");
                        keepLooping = false;
                        break;
                      
                    } 

                bool keepLooping2 = true;
                while(keepLooping2 && counter >= 1)
                {
                    var newGuess = AskUserForLetter();
                    
                    previousGuesses = builder.ToString();
                    
                    String newGuessToString = new String(newGuess);

                    String[] array1 = previousGuesses.Split(delimiter1, StringSplitOptions.None);

                    if(newGuessToString.Length <= 1)
                    {
                        for(var i = 0; i < array1.Length; i++)
                        {
                            if(array1[i] != newGuessToString)
                            {
                                
                                guess = newGuess;
                                keepLooping2 = false;
                                continue;
                            } else
                            {
                                Console.WriteLine("You have already guessed this letter.");
                                keepLooping2 = true;
                                
                            }
                        }
                        builder.Append(", ");
                        builder.Append(newGuess);
                        Console.WriteLine("Your guesses: {0}", builder);

                    } else if(!getRandomWord.SequenceEqual(guess) && guess.Length > 1)
                    {
                        for(var i = 0; i < array1.Length; i++)
                        {
                            if(array1[i] == newGuessToString)
                            {
                                Console.WriteLine("You have already guessed this word.");
                                continue;
                            }
                        }
                    } else
                    {
                        builder.Append(", ");
                        builder.Append(newGuess);
                        Console.WriteLine("Your guesses: {0}", builder);
                        guess = newGuess;
                        keepLooping2 = false;
                    }
                }
                counter++;
                lives--;
                Console.WriteLine("Your lives: {0}", lives);

                if(getRandomWord.SequenceEqual(guess))
                {
                    Console.WriteLine("You got it!");
                    keepLooping = false;
                    break;
                   
                } 

                if(!getRandomWord.SequenceEqual(guess) && guess.Length > 1)
                {
                    Console.WriteLine("Wrong word");
                    keepLooping = true;
                    continue;
                }


            
                for(int i = 0; i < getRandomWord.Length; i++)
                {
                    
                    for(int j = 0; j <guess.Length; j++)
                    {
                      
                    if(guess[j] == getRandomWord[i])
                    {
                        hiddenPlayWord[i] = guess[j];
                        
                        keepLooping = true;
                        
                        if(getRandomWord.SequenceEqual(hiddenPlayWord))
                        {
                            Console.WriteLine("You made it!");
                            keepLooping = false;
                            break;
                        }

                    } else if(guess[j] != getRandomWord[i])
                    {
                        keepLooping = true;
                        
                    } else 
                    {
                        keepLooping = true;
                    }
                    }
                } Console.WriteLine(hiddenPlayWord);
                    
                    
            } 

        }
    }
}
