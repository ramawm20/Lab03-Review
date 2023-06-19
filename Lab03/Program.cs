using System.Diagnostics;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab03
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../words.txt";

            Console.WriteLine("Find product method :");
            int product = FindProduct();
            Console.WriteLine($"The product for the 3 numbers = {product}");

            Console.WriteLine();
            Console.WriteLine("Calculate average method :");
            CalculateAverage();

            Console.WriteLine();
            Console.WriteLine("Print Stars method :");
            PrintStars();

            Console.WriteLine();
            Console.WriteLine("The most repeted number in the array");
            int[] array1 = new int[]{1, 1, 2, 2, 3, 3, 3, 1, 1, 5, 5, 6, 7, 8, 2, 1, 1};
            Console.WriteLine(MostRepetedNumber(array1));
            
            Console.WriteLine();
            Console.WriteLine("The maximum number at the array :");
            int[] array2 = new int[] { 5, 25, 99, 123, 78, 96, 555, 108, 4 };
            int max=MaxNumber(array2);
            Console.WriteLine($"The max number ={max}");

            Console.WriteLine();
            Console.WriteLine("Write to file method");
            WriteToFile(path);

            Console.WriteLine();
            Console.WriteLine("Read from file");
            ReadFromFile(path);

            Console.WriteLine();
            Console.WriteLine("Edit from file");
            Editword(path);

            string[] array3 = NumberofChars();
            for (int i = 0; i < array3.Length; i++)
            {
                Console.WriteLine(array3[i]);
            }


        }


        public static int FindProduct()
        {
            Console.WriteLine("Please enter 3 numbers seperated by space : ");
            string numbers=Console.ReadLine();
            string[] array = numbers.Split(' ');

            if (array.Length < 3)
            {
                return 0;
            }
            int product = 1;
            for (int i = 0; i < 3; i++)
            {
                if (int.TryParse(array[i], out int number))
                {
                    product*= number;
                }
                else
                {
                    product*= 1;
                }
               
            }
            return product;
        }

        public static void CalculateAverage()
        {
            int number;
            bool isValid = false;

            while (!isValid)
            {
                try
                {
                    Console.Write("Please enter a number between 2 and 10: ");
                    number = Convert.ToInt32(Console.ReadLine());

                    if (number >= 2 && number <= 10)
                    {
                        isValid = true;
                        double sum = 0;

                        for (int i = 0; i < number; i++)
                        {
                            bool isNumberValid = false;

                            while (!isNumberValid)
                            {
                                try
                                {
                                    Console.Write($"Enter number {i + 1} of {number}: ");
                                    double num = double.Parse(Console.ReadLine());

                                    sum += num;
                                    isNumberValid = true;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid number.");
                                }
                            }
                        }

                        double average = sum / number;
                        Console.WriteLine($"The average of the entered numbers = {average}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 2 and 10.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        public static void PrintStars()
        {
            int size = 5; 

            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size - i; j++)
                {
                    Console.Write(" ");
                }

                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }

            for (int i = size - 1; i >= 1; i--)
            {
                for (int j = 1; j <= size - i; j++)
                {
                    Console.Write(" ");
                }

                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }

        public static int MostRepetedNumber(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Input array cannot be null or empty.");
            }

            int maxFrequency = 0;
            int mostFrequentNumber = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                int frequency = 1;

                if (array[i] == int.MinValue)
                {
                    continue; // Skip if number is already marked as visited
                }

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] == array[i])
                    {
                        frequency++;
                        array[j] = int.MinValue; // Mark visited number
                    }
                }

                if (frequency > maxFrequency)
                {
                    maxFrequency = frequency;
                    mostFrequentNumber = array[i];
                }
            }

            return mostFrequentNumber;
        }

        public static int MaxNumber(int[] array)
        {
            
            int max = array[0];
            for (int i = 0;i< array.Length;i++)
            {
                if (array[i] >= max)
                {
                    max = array[i];
                }
            }
            return max;
        }

        public static void WriteToFile(string path)
        {
            Console.WriteLine("Enter text to add to the file  : ");
            string word = Console.ReadLine();
            try
            {
                using (StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine(word);
                }

                Console.WriteLine("Word saved successfully.");
            }
            catch (Exception ex)

            {
                Console.WriteLine("Word not saved something went wrong " + ex.Message);
            }


        }

        public static void ReadFromFile(string path)
        {
            string wordscontent = File.ReadAllText(path);
            Console.WriteLine(wordscontent);
        }

        public static void Editword(string path)
        {
            try
            {

                string content = File.ReadAllText(path);

    
                string word = Console.ReadLine();
                content = content.Replace(word, string.Empty);

                

                Console.WriteLine("Word removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while removing the word: " + ex.Message);
            }
        }

        public static string[]  NumberofChars()
        {
            Console.WriteLine("Please enter text");
            string text= Console.ReadLine();

            string[] array = text.Split(" ");
            string[] result = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                string word = array[i];
                int characterCount = word.Length;
                result[i] = $"{word}: {characterCount}";
            }

            return result;
        }


    }
}