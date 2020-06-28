using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleTest
{
    static class Program
    {
        static int maxCHARS = 256;

        static string[] unitsMap = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        static string[] tensMap = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        static string[] specialNames = { "", " thousand", " million", " billion", " trillion", " quadrillion", " quadrillion" };
        static string[] tensNames = { "", " ten", " twenty", " thirty", " forty", " fifty", " sixty", " seventy", " eighty", " ninety" };
        static string[] numNames = { "", " one", " two", " three", " four", " five", " six", " seven", " eight", " nine", " ten", " eleven", " twelve", " thirteen", " fourteen", " fifteen", " sixteen", " seventeen", " eighteen", " nineteen" };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // To get the sum of min and max from givne array...
            //int[] data = { 98, 21, 22, 3, 45, 203, 183 };
            //Console.WriteLine("The value of Min Max sum from Array is == {0}", SumMinMaxFromArray(7, data));

            // C _c = new C();
            //_c.Print();

            // Hashing Example
            //string plainData = "Mahesh";
            //Console.WriteLine("Raw data: {0}", plainData);
            //string hashedData = DoHashing(plainData);
            //Console.WriteLine("Hash {0}", hashedData);
            //Console.WriteLine(DoHashing("Mahesh"));

            //Console.WriteLine("Please enter the number to convert into Word");
            //foreach (String arg in Environment.GetCommandLineArgs())
            //{
            //    Console.Write(arg);
            //}
            //Console.Write("Waiting for User response...");
            //Console.ReadKey();
            //var number = Console.Read();

            //Console.WriteLine(rupees(110));
            CountTheLetters("mynameistomhanks");
            Console.ReadLine();
        }

        /// <summary>
        /// Sum the min and max from given array
        /// </summary>
        /// <param name="n">Number of data in array</param>
        /// <param name="input">Array with integer number</param>
        /// <returns>Returns the sum</returns>
        private static int SumMinMaxFromArray(int n, int[] input)
        {
            int result = 0;
            try
            {
                if (n == input.Length)
                {
                    int i, min, max;
                    min = input[0];
                    max = input[0];
                    for (i = 1; i < n; i++)
                    {
                        if (input[i] < min)
                        {
                            min = input[i];
                        }
                        if (input[i] > max)
                        {
                            max = input[i];
                        }
                    }
                    result = min + max;
                }
                else
                {
                    result = -1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// HashAlgorithm computes a hash
        /// </summary>
        /// <param name="rawData">string rawData</param>
        /// <returns></returns>
        static string DoHashing(string rawData)
        {
            StringBuilder stringBuilder = new StringBuilder();

            try
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash - returns byte array  
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                    for (int i = 0; i < bytes.Length; i++)
                    {
                        stringBuilder.Append(bytes[i].ToString("x2"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return stringBuilder.ToString();
        }

        //private static string convertLessThanOneThousand(int number)
        //{
        //    String current;
        //    NumberToWord numberToWord = new NumberToWord();

        //    if (number % 100 < 20)
        //    {
        //        current = numberToWord.numNames[number % 100];
        //        number /= 100;
        //    }
        //    else
        //    {
        //        current = numNames[number % 10];
        //        number /= 10;

        //        current = tensNames[number % 10] + current;
        //        number /= 10;
        //    }
        //    if (number == 0) return current;
        //    return numNames[number] + " hundred" + current;
        //}

        private static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000000) > 0)
            {
                words += NumberToWords(number / 1000000000) + " billion ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        private static String convertLessThanOneThousand(int number)
        {
            String current;

            if (number % 100 < 20)
            {
                current = numNames[number % 100];
                number /= 100;
            }
            else
            {
                current = numNames[number % 10];
                number /= 10;

                current = tensNames[number % 10] + current;
                number /= 10;
            }
            if (number == 0) return current;
            return numNames[number] + " hundred" + current;
        }

        public static String Convert(int number)
        {

            if (number == 0) { return "zero"; }

            String prefix = "";

            if (number < 0)
            {
                number = -number;
                prefix = "negative";
            }

            String current = "";
            int place = 0;

            do
            {
                int n = number % 1000;
                if (n != 0)
                {
                    String s = convertLessThanOneThousand(n);
                    current = s + specialNames[place] + current;
                }
                place++;
                number /= 1000;
            } while (number > 0);

            return (prefix + current).Trim();
        }

        public static string rupees(Int64 rupees)
        {
            string result = "";
            Int64 res;
            if ((rupees / 10000000) > 0)
            {
                res = rupees / 10000000;
                rupees = rupees % 10000000;
                result = result + ' ' + rupeestowords(res) + " Crore";
            }
            if ((rupees / 100000) > 0)
            {
                res = rupees / 100000;
                rupees = rupees % 100000;
                result = result + ' ' + rupeestowords(res) + " Lakh";
            }
            if ((rupees / 1000) > 0)
            {
                res = rupees / 1000;
                rupees = rupees % 1000;
                result = result + ' ' + rupeestowords(res) + " Thousand";
            }
            if ((rupees / 100) > 0)
            {
                res = rupees / 100;
                rupees = rupees % 100;
                result = result + ' ' + rupeestowords(res) + " Hundred";
            }
            if ((rupees % 10) >= 0)
            {
                res = rupees % 100;
                result = result + " " + rupeestowords(res);
            }
            result = result + ' ' + " Rupees only";
            return result;
        }

        public static string rupeestowords(Int64 rupees)
        {
            string result = "";
            if ((rupees >= 1) && (rupees <= 10))
            {
                if ((rupees % 10) == 1) result = "One";
                if ((rupees % 10) == 2) result = "Two";
                if ((rupees % 10) == 3) result = "Three";
                if ((rupees % 10) == 4) result = "Four";
                if ((rupees % 10) == 5) result = "Five";
                if ((rupees % 10) == 6) result = "Six";
                if ((rupees % 10) == 7) result = "Seven";
                if ((rupees % 10) == 8) result = "Eight";
                if ((rupees % 10) == 9) result = "Nine";
                if ((rupees % 10) == 0) result = "Ten";
            }
            if (rupees > 9 && rupees < 20)
            {
                if (rupees == 11) result = "Eleven";
                if (rupees == 12) result = "Twelve";
                if (rupees == 13) result = "Thirteen";
                if (rupees == 14) result = "Forteen";
                if (rupees == 15) result = "Fifteen";
                if (rupees == 16) result = "Sixteen";
                if (rupees == 17) result = "Seventeen";
                if (rupees == 18) result = "Eighteen";
                if (rupees == 19) result = "Nineteen";
            }
            if (rupees > 20 && (rupees / 10) == 2 && (rupees % 10) == 0) result = "Twenty";
            if (rupees > 20 && (rupees / 10) == 3 && (rupees % 10) == 0) result = "Thirty";
            if (rupees > 20 && (rupees / 10) == 4 && (rupees % 10) == 0) result = "Forty";
            if (rupees > 20 && (rupees / 10) == 5 && (rupees % 10) == 0) result = "Fifty";
            if (rupees > 20 && (rupees / 10) == 6 && (rupees % 10) == 0) result = "Sixty";
            if (rupees > 20 && (rupees / 10) == 7 && (rupees % 10) == 0) result = "Seventy";
            if (rupees > 20 && (rupees / 10) == 8 && (rupees % 10) == 0) result = "Eighty";
            if (rupees > 20 && (rupees / 10) == 9 && (rupees % 10) == 0) result = "Ninty";

            if (rupees > 20 && (rupees / 10) == 2 && (rupees % 10) != 0)
            {
                if ((rupees % 10) == 1) result = "Twenty One";
                if ((rupees % 10) == 2) result = "Twenty Two";
                if ((rupees % 10) == 3) result = "Twenty Three";
                if ((rupees % 10) == 4) result = "Twenty Four";
                if ((rupees % 10) == 5) result = "Twenty Five";
                if ((rupees % 10) == 6) result = "Twenty Six";
                if ((rupees % 10) == 7) result = "Twenty Seven";
                if ((rupees % 10) == 8) result = "Twenty Eight";
                if ((rupees % 10) == 9) result = "Twenty Nine";
            }
            if (rupees > 20 && (rupees / 10) == 3 && (rupees % 10) != 0)
            {
                if ((rupees % 10) == 1) result = "Thirty One";
                if ((rupees % 10) == 2) result = "Thirty Two";
                if ((rupees % 10) == 3) result = "Thirty Three";
                if ((rupees % 10) == 4) result = "Thirty Four";
                if ((rupees % 10) == 5) result = "Thirty Five";
                if ((rupees % 10) == 6) result = "Thirty Six";
                if ((rupees % 10) == 7) result = "Thirty Seven";
                if ((rupees % 10) == 8) result = "Thirty Eight";
                if ((rupees % 10) == 9) result = "Thirty Nine";
            }
            if (rupees > 20 && (rupees / 10) == 4 && (rupees % 10) != 0)
            {
                if ((rupees % 10) == 1) result = "Forty One";
                if ((rupees % 10) == 2) result = "Forty Two";
                if ((rupees % 10) == 3) result = "Forty Three";
                if ((rupees % 10) == 4) result = "Forty Four";
                if ((rupees % 10) == 5) result = "Forty Five";
                if ((rupees % 10) == 6) result = "Forty Six";
                if ((rupees % 10) == 7) result = "Forty Seven";
                if ((rupees % 10) == 8) result = "Forty Eight";
                if ((rupees % 10) == 9) result = "Forty Nine";
            }
            if (rupees > 20 && (rupees / 10) == 5 && (rupees % 10) != 0)
            {
                if ((rupees % 10) == 1) result = "Fifty One";
                if ((rupees % 10) == 2) result = "Fifty Two";
                if ((rupees % 10) == 3) result = "Fifty Three";
                if ((rupees % 10) == 4) result = "Fifty Four";
                if ((rupees % 10) == 5) result = "Fifty Five";
                if ((rupees % 10) == 6) result = "Fifty Six";
                if ((rupees % 10) == 7) result = "Fifty Seven";
                if ((rupees % 10) == 8) result = "Fifty Eight";
                if ((rupees % 10) == 9) result = "Fifty Nine";
            }
            if (rupees > 20 && (rupees / 10) == 6 && (rupees % 10) != 0)
            {
                if ((rupees % 10) == 1) result = "Sixty One";
                if ((rupees % 10) == 2) result = "Sixty Two";
                if ((rupees % 10) == 3) result = "Sixty Three";
                if ((rupees % 10) == 4) result = "Sixty Four";
                if ((rupees % 10) == 5) result = "Sixty Five";
                if ((rupees % 10) == 6) result = "Sixty Six";
                if ((rupees % 10) == 7) result = "Sixty Seven";
                if ((rupees % 10) == 8) result = "Sixty Eight";
                if ((rupees % 10) == 9) result = "Sixty Nine";
            }
            if (rupees > 20 && (rupees / 10) == 7 && (rupees % 10) != 0)
            {
                if ((rupees % 10) == 1) result = "Seventy One";
                if ((rupees % 10) == 2) result = "Seventy Two";
                if ((rupees % 10) == 3) result = "Seventy Three";
                if ((rupees % 10) == 4) result = "Seventy Four";
                if ((rupees % 10) == 5) result = "Seventy Five";
                if ((rupees % 10) == 6) result = "Seventy Six";
                if ((rupees % 10) == 7) result = "Seventy Seven";
                if ((rupees % 10) == 8) result = "Seventy Eight";
                if ((rupees % 10) == 9) result = "Seventy Nine";
            }
            if (rupees > 20 && (rupees / 10) == 8 && (rupees % 10) != 0)
            {
                if ((rupees % 10) == 1) result = "Eighty One";
                if ((rupees % 10) == 2) result = "Eighty Two";
                if ((rupees % 10) == 3) result = "Eighty Three";
                if ((rupees % 10) == 4) result = "Eighty Four";
                if ((rupees % 10) == 5) result = "Eighty Five";
                if ((rupees % 10) == 6) result = "Eighty Six";
                if ((rupees % 10) == 7) result = "Eighty Seven";
                if ((rupees % 10) == 8) result = "Eighty Eight";
                if ((rupees % 10) == 9) result = "Eighty Nine";
            }
            if (rupees > 20 && (rupees / 10) == 9 && (rupees % 10) != 0)
            {
                if ((rupees % 10) == 1) result = "Ninty One";
                if ((rupees % 10) == 2) result = "Ninty Two";
                if ((rupees % 10) == 3) result = "Ninty Three";
                if ((rupees % 10) == 4) result = "Ninty Four";
                if ((rupees % 10) == 5) result = "Ninty Five";
                if ((rupees % 10) == 6) result = "Ninty Six";
                if ((rupees % 10) == 7) result = "Ninty Seven";
                if ((rupees % 10) == 8) result = "Ninty Eight";
                if ((rupees % 10) == 9) result = "Ninty Nine";
            }
            return result;
        }

        public static string ToUnderscoreCase(this string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }

        static void CountTheLetters(String s )
        {
            int[] cal = new int[maxCHARS];
            for (int i = 0; i < s.Length; i++)
                cal[s[i]]++;

            for (int i = 0; i < maxCHARS; i++)
            {
                if (cal[i] > 1)
                {
                    Console.WriteLine("Character " + (char)i);
                    Console.WriteLine("Occurrence = " + cal[i] + " times");
                }
                if (cal[i] == 1)
                {
                    Console.WriteLine("Character " + (char)i);
                    Console.WriteLine("Occurrence = " + cal[i] + " time");
                }
            }
        }

        static void PrintTheCountOfOccurance()
        {
            String s = "mynameistomhanks";
            int[] cal = new int[maxCHARS];
            CountTheLetters(s);
            
        }
    }

    public class A
    {
        public void Print()
        {
            Console.WriteLine("I am from class A.");
        }
    }

    public class B : A
    {
        public void Print()
        {
            Console.WriteLine("I am from class B.");
        }
    }

    public class C : B
    {
        public void Print()
        {
            Console.WriteLine("I am from class C.");
        }
    }
}