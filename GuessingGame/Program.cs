using System;
using System.Collections.Generic;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 101);

            int userGuess;
            List<Guess> previousGuesses = new List<Guess>();
            bool guessedCorrectly = false;

            Console.WriteLine("Welcome to the Number Guessing Game!");
            Console.WriteLine("Guess a number between 1 and 100.");

            do
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out userGuess))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                int previousIndex = previousGuesses.FindIndex(g => g.UserGuess == userGuess);
                if (previousIndex >= 0)
                {
                    Console.WriteLine($"You guessed this number {previousGuesses.Count - previousIndex} turns ago!");
                    continue;
                }

                previousGuesses.Add(new Guess(userGuess));

                if (userGuess > randomNumber)
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else if (userGuess < randomNumber)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else
                {
                    guessedCorrectly = true;
                    Console.WriteLine($"You Won! The answer was {randomNumber}.");
                }

            } while (!guessedCorrectly);
        }
    }
}
