using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Example_JC
{
    class Program
    {
 
        static void Main(string[] args)
        {
            string name = "Batman";
            int[] Num;

           
            Console.Title = "Math Example";
            if (args.Length > 0)
            {
                Num = new int[args.Length];
                for (int i=0; i<args.Length ; i++) {
                    if (int.TryParse(args[i], out Num[i])==false) {
                        Console.WriteLine("{0}, is not a valid number.", args[i]);
                        Console.WriteLine("Let's try this from the beginning.");
                        goto PROMPTUSER;
                    }
                }

                goto OPTIONS;
            }

        PROMPTUSER:
        #region Prompt the user for information

            Console.WriteLine("What is your name?");
            name = Console.ReadLine();

            PROMPTCOMPUTE:
                Console.WriteLine("{0}, how many numbers would you like to compute?", name);
                int cnum;
                if (int.TryParse(Console.ReadLine(), out cnum))
                {
                    Num = new int[cnum];
                    for (int i = 0; i < cnum; i++)
                    {
                    PROMPTCURRENTNUM:
                        Console.WriteLine("Enter value for number {0}:", i + 1);
                        if (int.TryParse(Console.ReadLine(), out Num[i]) == false)
                        {
                            Console.WriteLine("That is not a valid number. Try again.");
                            goto PROMPTCURRENTNUM;
                        }
                    }
                }
                else {
                    goto PROMPTCOMPUTE;
                }
        #endregion

        OPTIONS:
            {
                #region Display to user all functions 
                Console.WriteLine("Please select the following options:");
                
                Console.WriteLine("   ? | F1 | H        : Help");
                Console.WriteLine("   X | ESC           : Exit");
                Console.WriteLine("   HOME | BackSpace  : Change array size and values");

                Console.WriteLine("   =                 : Displays all numbers in current array");
                Console.WriteLine("   P | +             : Add all numbers");
                Console.WriteLine("   M | -             : Subtract all numbers");
                Console.WriteLine("   D | /             : Divide all numbers");
                Console.WriteLine("   U | *             : Multiply all numbers");
                Console.WriteLine("   S | 2             : Square every number in the array.");
                #endregion
            READKEY:
                ConsoleKeyInfo key = Console.ReadKey();
                int left = (Console.CursorLeft > 0) ? Console.CursorLeft - 1 : 0 ;
                Console.SetCursorPosition(left, Console.CursorTop);

                #region This section deals with key presses
                switch (key.Key)
                {
                    case ConsoleKey.Backspace:
                    case ConsoleKey.Home:
                    {
                            Console.Clear();
                            goto PROMPTCOMPUTE;
                    }
                    case ConsoleKey.H:
                    case ConsoleKey.Help:
                    case ConsoleKey.F1:
                        {
                            Help();
                            goto OPTIONS;
                        }
                    case ConsoleKey.X:
                    case ConsoleKey.Escape:
                        {
                            goto EXIT;
                        }
                    case ConsoleKey.P:
                    case ConsoleKey.Add:
                        {
                            Console.WriteLine("Add = {0}",Add(Num));
                            goto READKEY;
                        }
                    case ConsoleKey.M:
                    case ConsoleKey.Subtract:
                        {
                            Console.WriteLine("Subtract = {0}", Substract(Num));
                            goto READKEY;
                        }
                    case ConsoleKey.D:
                    case ConsoleKey.Divide:
                        {
                            Console.WriteLine("Divide = {0}", Divide(Num));
                            goto READKEY;
                        }
                    case ConsoleKey.U:
                    case ConsoleKey.Multiply:
                        {
                            Console.WriteLine("Multiply = {0}", Multiply(Num));
                            goto READKEY;
                        }
                    case ConsoleKey.S:
                        {
                            Console.WriteLine("Square = {0}", Square(Num));
                            goto READKEY;
                        }
                    case ConsoleKey.Enter:
                        {
                            Console.WriteLine();
                            goto READKEY;
                        }
                    default:
                        {
                            #region This Section deals with special characters
                            switch (key.KeyChar) {
                                case '?':
                                {
                                        Help();
                                        goto OPTIONS;
                                }
                                case '=':
                                {
                                        Console.WriteLine("Numbers = {0}",PrintNum(Num));
                                    goto READKEY;
                                }
                                case '+' :
                                {
                                        Console.WriteLine("Add = {0}", Add(Num));
                                        goto READKEY;
                                }
                                case '-':
                                {
                                        Console.WriteLine("Subtract = {0}", Substract(Num));
                                        goto READKEY;
                                }
                                case '/':
                                {
                                        Console.WriteLine("Divide = {0}", Divide(Num));
                                        goto READKEY;
                                }
                                case '*':
                                case '.':
                                {
                                        Console.WriteLine("Multiply = {0}", Multiply(Num));
                                    goto READKEY;
                                }
                                case '2':
                                    {
                                        Console.WriteLine("Square = {0}", Square(Num));
                                        goto READKEY;
                                    }
                                default:
                                {
                                    Console.WriteLine("Invalid option");
                                    goto READKEY;
                                }

                            }
                            #endregion


                        }
                }
                #endregion

            }

        EXIT: {

        }


        }

        private static string PrintNum(int[] numbers)
        {
            string res="";
            for (int i=0; i < numbers.Length ; i++) {
                res = (i < (numbers.Length-1)) ? res + numbers[i] + "," : res + numbers[i];
            }

            return res;
        }

        static long Square(int[] numbers)
        {
            long res=1;
            for (int i = 0; i < numbers.Length; i ++)
            {
                res *= numbers[i] * numbers[i];
            }
            return res;
        }

        static int Multiply(int[] numbers)
        {
            int res=1;
            int n1,n2;
            for (int i=0 , j=1; i< numbers.Length; i+=2 , j += 2)
            {
                n1 = (i < numbers.Length) ? numbers[i] : 1;
                n2 = (j < numbers.Length) ? numbers[j] : 1;
                res *= n1* n2;
            }
            return res;
        }

        static double Divide(int[] numbers)
        {
            double res = 0;
            if (numbers.Length > 0)
            {
                res = 1;
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == 0)
                    {
                        res = 0;
                        break;
                    }

                    res /= numbers[i];
                }
            }

            return res;
        }

        static int Substract(int[] numbers)
        {
            int res = 0;
            foreach (int val in numbers)
            {
                res = (val < res) ?  res - val : val - res; 
            }
            return res;
        }

        static int Add(int[] numbers)
        {
            int res= 0;
            foreach (int val in numbers) {
                res += val;
            }
            return res;
        }

        private static void Help() {
            Console.Clear();
        }
    }
}
