using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static string Generate()
        {
            byte Passlen = 0;
            bool? UseCases = null;
            bool? UseDigits = null;
            bool? UseSymbols = null;
            string password ="";
            Random random = new Random();

            char[] Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] Digits = "0123456789".ToCharArray();
            char[] Symbols = "!@#$%&*".ToCharArray();
            List<char[]> Arrays = new List<char[]>() { Letters, Digits, Symbols };
            while (true)
            {
                try
                {
                    Console.Write("Enter password length (1-255): ");
                    Passlen = Convert.ToByte(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The password length is over than 255 or is not a number");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            while (UseCases == null)
            {
                try
                {
                    Console.WriteLine("Use different cases? (y/n)");
                    char i = Convert.ToChar(Console.ReadLine());
                    switch (i)
                    {
                        case 'y':
                            UseCases = true;
                            break;
                        case 'n':
                            UseCases = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not correct response");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not correct response, error");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            while (UseDigits == null)
            {
                try
                {
                    Console.WriteLine("Use digits? (y/n)");
                    char i = Convert.ToChar(Console.ReadLine());
                    switch (i)
                    {
                        case 'y':
                            UseDigits = true;
                            break;
                        case 'n':
                            UseDigits = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not correct response");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not correct response, error");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            while (UseSymbols == null)
            {
                try
                {
                    Console.WriteLine("Use special symbols? (y/n)");
                    char i = Convert.ToChar(Console.ReadLine().ToLower());
                    switch (i)
                    {
                        case 'y':
                            UseSymbols = true;
                            break;
                        case 'n':
                            UseSymbols = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not correct response");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not correct response, error");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine("Generating password...");
            for (int i = 0; i < Passlen; i++)
            {
                int TargetArray = random.Next(0, 4);
                switch (TargetArray)
                {
                    case 0:
                        if (UseCases==true)
                        {
                            password += Convert.ToString(Letters[random.Next(0, 25)]);
                        }
                        else
                        {
                            goto case 3;
                        }
                        break;
                    case 1:
                        if (UseDigits == true)
                        {
                            password += Convert.ToString(Digits[random.Next(0, 9)]);
                        }
                        else
                        {
                            goto case 3;
                        }
                        break;
                    case 2:
                        if (UseSymbols == true)
                        {
                            password += Convert.ToString(Symbols[random.Next(0, 5)]);
                        }
                        else
                        {
                            goto case 3;
                        }
                        break;
                    case 3:
                        password += Convert.ToString(Letters[random.Next(0, 25)]).ToLower();
                        break;
                }
            }
            return password;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("generate - generates a new password");
            while (true)
            {
                string z = Console.ReadLine().ToLower();
                try
                {
                    if (z=="generate")
                    {
                        Console.WriteLine(Generate());
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
