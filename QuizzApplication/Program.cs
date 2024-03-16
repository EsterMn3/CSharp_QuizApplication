using System;

namespace QuizApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Quiz Application!\nYou have two hints available, make sure to use them wisely!!\n");

            // Define quiz questions and answers
            string[] questions = {
                "What is the capital of France?",
                "Who wrote 'Romeo and Juliet'?",
                "What is the chemical symbol for water?",
                "Which planet is known as the Red Planet?",
                "Which of the following is the largest planet in our solar system?",
                "What is the primary component of the Earth's atmosphere?",
                "Who is credited with the discovery of penicillin?",
                "Which is the only mammal capable of flight?"
            };

            string[][] options = {
                new string[] { "A. Paris", "B. London", "C. Rome", "D. Berlin" },
                new string[] { "A. Mark Twain", "B. Charles Dickens", "C. Jane Austen", "D. William Shakespeare" },
                new string[] { "A. CO2", "B. H2O", "C. NaCl", "D. CH4" },
                new string[] { "A. Venus", "B. Jupiter", "C. Mars", "D. Saturn" },
                new string[] { "A. Earth", "B. Jupiter", "C. Mars", "D. Saturn" },
                new string[] { "A. Oxygen", "B. Nitrogen", "C. Carbon dioxide", "D. Argon" },
                new string[] { "A. Alexander Fleming", "B. Marie Curie", "C. Isaac Newton", "D. Albert Einstein" },
                new string[] { "A. Bird", "B. Eagle", "C. Dolphin", "D. Bat" }
            };

            string[] answers = { "A", "D", "B", "C", "B", "B", "A", "D" };

            int correctAnswers = 0; // Counter for correct answers

            int hintCount = 0; // Counter for the number of hints used

            // Loop through each question
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}: {questions[i]}");

                // Display options for multiple-choice questions
                if (i < options.Length)
                {
                    foreach (string option in options[i])
                    {
                        Console.WriteLine(option);
                    }
                }

                // Check if hints are available and not already used for this question
                if (hintCount < 2)
                {
                    Console.Write("Would you like a hint? (yes/no): ");
                    string input = Console.ReadLine()?.ToLower(); // Convert input to lowercase for case-insensitive comparison

                    if (input == "yes" || input == "y" || input == "ye") // Check if input is affirmative
                    {
                        // Provide hint
                        ProvideHint(i);
                        hintCount++;
                    }
                    else if (input == "no" || input == "n")
                    {
                        // Do nothing
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                        i--; // Repeat the current question
                        continue;
                    }
                }

                // Get user input
                Console.Write("Your answer: ");
                string? userAnswer = Console.ReadLine()?.ToUpper();

                // Check the answer
                if (userAnswer == answers[i])
                {
                    Console.WriteLine("Correct!\n");
                    correctAnswers++;
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is: {answers[i]}\n");
                }
            }

            // Calculate the score as a percentage
            double score = (double)correctAnswers / questions.Length * 100;

            // Check if the user wins
            if (score >= 70)
            {
                Console.WriteLine($"Congratulations! You win with a score of {score:F1}%.");
            }
            else
            {
                Console.WriteLine($"Sorry, you did not win. Your score is {score:F1}%.");
            }

            Console.WriteLine("Thank you for participating in the quiz!");
        }

        static void ProvideHint(int questionIndex)
        {
            // Provide hints for specific questions
            switch (questionIndex)
            {
                case 0:
                    Console.WriteLine("Hint: The capital of France is a major European city known for its landmarks like the Eiffel Tower.");
                    break;
                case 1:
                    Console.WriteLine("Hint: The author of 'Romeo and Juliet' is one of the most famous playwrights in history.");
                    break;
                case 2:
                    Console.WriteLine("Hint: The chemical symbol for water is composed of two elements, one of which is hydrogen.");
                    break;
                case 3:
                    Console.WriteLine("Hint: The Red Planet is known for its distinctive reddish appearance in the night sky.");
                    break;
                case 4:
                    Console.WriteLine("Hint: This planet is the largest in our solar system and is known for its giant storm known as the Great Red Spot.");
                    break;
                case 5:
                    Console.WriteLine("Hint: The Earth's atmosphere consists primarily of this gas, which is essential for life.");
                    break;
                case 6:
                    Console.WriteLine("Hint: This scientist discovered penicillin, a breakthrough in the field of medicine.");
                    break;
                case 7:
                    Console.WriteLine("Hint: This mammal is known for its ability to fly, despite being the only mammal with this capability.");
                    break;
                default:
                    Console.WriteLine("Sorry, no hint available for this question.");
                    break;
            }
        }
    }
}
