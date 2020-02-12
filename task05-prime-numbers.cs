using System;
using System.Collections.Generic;
using System.Linq;

// Задача: реализовать метод GetPrimeNumbers, который должен возвращать массив простых чисел, находящихся в исследуемой последовательности чисел.
//   * Массив должен содержать значения в возрастающем порядке.
//   * Параметры start и end задают граничные значения исследуемой последовательности чисел (включительно).
//   * Выбрасывать исключение ArgumentException в случае, если значения параметров не являются корректными.
//   * В решении разрешается использовать только конструкции языка и стандартные структуры данных BCL. Использовать LINQ запрещено.

namespace Task5
{
    public class Program
    {
        public static int[] GetPrimeNumbers(int start, int end)
        {
            if(start > end)
            {
                throw new ArgumentException("Значения параметров не являются корректными. Начальное граничное значения должно быть меньше или равно конечному");
            }
            if(start <= 1 || end <= 1) //ряд простых чисел начинаются с 2-ки (0 и 1 не являются простыми)
            {
                throw new ArgumentException("Значения параметров не являются корректными. Начальное и конечное граничные значения должны принадлежать натуриальному ряду чисел поэтому не могут рвняться нулю или быть отрицательными!");
            }
            List<int> list = new List<int>();
            for(int i = start; i <= end; ++i)
            {
                if (IsPrime(i))
                {
                    list.Add(i);
                }
            }
            return list.ToArray();
        }

        public static bool IsPrime(int value)
        {
            bool flag = false;
            for(int i = 2; i < value; ++i)
            {
                if(value % i == 0)
                {
                    flag = true;
                    break;
                }
            }
            if (value > 1 && flag == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Main()
        {
            Console.WriteLine("Task is done when all test cases are correct:");

            int testCaseNumber = 1;

            TestReturnValues(testCaseNumber++, 2, 2, new int[] { 2 });
            TestReturnValues(testCaseNumber++, 2, 3, new int[] { 2, 3 });
            TestReturnValues(testCaseNumber++, 2, 10, new int[] { 2, 3, 5, 7 });
            TestReturnValues(testCaseNumber++, 30, 48, new int[] { 31, 37, 41, 43, 47 });
            TestReturnValues(testCaseNumber++, 11, 97, new int[] { 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 });
            TestReturnValues(testCaseNumber++, 180, 190, new int[] { 181 });
            TestException<ArgumentException>(testCaseNumber++, -1, -1);
            TestException<ArgumentException>(testCaseNumber++, -1, 100);
            TestException<ArgumentException>(testCaseNumber++, 0, 0);
            TestException<ArgumentException>(testCaseNumber++, 0, 100);
            TestException<ArgumentException>(testCaseNumber++, 1, 1);//
            TestException<ArgumentException>(testCaseNumber++, 1, 100);//
            TestException<ArgumentException>(testCaseNumber++, 2, -1);
            TestException<ArgumentException>(testCaseNumber++, 2, 0);
            TestException<ArgumentException>(testCaseNumber++, 2, 1);

            if (correctTestCaseAmount == testCaseNumber - 1)
            {
                Console.WriteLine("Task is done.");
            }
            else
            {
                Console.WriteLine("TASK IS NOT DONE.");
            }
        }

        private static void TestReturnValues(int testCaseNumber, int start, int end, int[] expectedResult)
        {
            int[] primeNumbers;
            try
            {
                primeNumbers = GetPrimeNumbers(start, end);
                if (primeNumbers.SequenceEqual(expectedResult))
                {
                    Console.WriteLine(correctCaseTemplate, testCaseNumber);
                    correctTestCaseAmount++;
                }
                else
                {
                    Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
            }
        }

        private static void TestException<T>(int testCaseNumber, int startValue, int endValue) where T : Exception
        {
            try
            {
                GetPrimeNumbers(startValue, endValue);
                Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
            }
            catch (T)
            {
                Console.WriteLine(correctCaseTemplate, testCaseNumber);
                correctTestCaseAmount++;
            }
            catch (Exception)
            {
                Console.WriteLine("#{0} - case is not correct!", testCaseNumber);
            }
        }

        private static string correctCaseTemplate = "Case #{0} is correct.";
        private static string incorrectCaseTemplate = "Case #{0} IS NOT CORRECT";
        private static int correctTestCaseAmount = 0;
    } 
}
