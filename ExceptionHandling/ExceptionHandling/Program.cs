using System;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my game! Let's do some math!");
            StartSequence();
        }

        /// <summary>
        /// Takes in a series of numbers from a user and calls various methods on them to perform calculations, and print output to the console.
        /// </summary>
        static void StartSequence()
        {
            Console.WriteLine("Please enter a number greater than zero:");
            int number = Convert.ToInt32(Console.ReadLine());
            int[] userArray = new int[number];
            Populate(userArray);
            int sum = GetSum(userArray);
            int product = GetProduct(userArray, sum);
            decimal quotient = GetQuotient(product);
            Console.WriteLine($"Your array size is: {userArray.Length}");
            string arrNums = "The numbers in your array are ";
            for (int i = 0; i < userArray.Length - 1; i++)
            {
                arrNums += userArray[i] + ", ";
            }
            arrNums += userArray[userArray.Length - 1] + ".";
            Console.WriteLine(arrNums);
            Console.WriteLine($"The sum of the array is {sum}.");
            int factor = product / sum;
            Console.WriteLine($"{sum} * {factor} = {product}.");
            decimal divisor = product / quotient;
            Console.WriteLine($"{product} / {divisor} = {quotient}.");

        }

        /// <summary>
        /// Asks the user to enter a number for each element of the userArray.
        /// </summary>
        /// <param name="intArr">The userArray is passed in as an argument in order to have its elements populated by the user.</param>
        /// <returns>The newly populated userArray.</returns>
        static int[] Populate(int[] intArr)
        {
            for (int i = 0; i < intArr.Length; i++)
            {
                Console.WriteLine($"{i + 1} of {intArr.Length}: Please enter a number.");
                int temp = Convert.ToInt32(Console.ReadLine());
                intArr[i] = temp;
            }
            return intArr;

        }

        /// <summary>
        /// Adds up all of the values entered in the userArray.
        /// </summary>
        /// <param name="intArr">The userArray that has previously been populated.</param>
        /// <returns>The sum of all numbers in the userArray.</returns>
        static int GetSum(int[] intArr)
        {
            int sum = 0;
            foreach (int number in intArr)
            {
                sum += number;
            }
            if (sum < 20)
            {
                throw new Exception($"The value of {sum} is too low.");
            }
            return sum;
        }

        /// <summary>
        /// Multiplies the returned sum from the GetSum method by a factor chosen by the user from the userArray.
        /// </summary>
        /// <param name="intArr">The populated userArray.</param>
        /// <param name="sum">The returned sum from the GetSum method.</param>
        /// <returns>The product of sum multiplied by the factor chosen by the user from the userArray.</returns>
        static int GetProduct(int[] intArr, int sum)
        {
            Console.WriteLine($"Please enter a number between 1 and {intArr.Length}.");
            int factor = Convert.ToInt32(Console.ReadLine());
            int product = sum * intArr[factor - 1];
            return product;
        }

        /// <summary>
        /// Divides the product from the GetProduct method by a number chosen by the user.
        /// </summary>
        /// <param name="product">The product returned by the GetProduct method.</param>
        /// <returns>The quotient of dividing the product by a number chosen by the user.</returns>
        static decimal GetQuotient(int product)
        {
            Console.WriteLine($"Please enter a number to divide your product {product} by.");
            int divisor = Convert.ToInt32(Console.ReadLine());
            decimal quotient = decimal.Divide(product, divisor);
            return quotient;
        }
    }
}
