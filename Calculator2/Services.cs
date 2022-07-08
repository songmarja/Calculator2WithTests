using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator2
{
    public class Services
    {

        decimal[] theUsersNumbers = new decimal[50];
        public static int i = 0;
        decimal validNum;
        Calculator theCalc = new Calculator();
        char chosenOperator;
        /// <summary>
        /// Gets the header for the game/app
        /// </summary>
        public static void GetHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***********************************************************************************************************************");
            Console.WriteLine("\n                                                    Welcome to My Calculator!\n");
            Console.WriteLine("***********************************************************************************************************************");
            Console.ResetColor();

            string s = "I have tried to build a calculator that should remind you of how you do in a real one. You add a number, choose" +
                        "an operator and press equal sign. That's why I choosed to take number by number, " +
                        "not as a string, and then split it in numbers and operators. There's a lot to improve, but that's my starting point. " +
                        "Also, the requirements we had for the task, had impact on how I've done the app.\n";

            Console.WriteLine(s);
        }

        public void Run()
        {
            GetHeader();
            //Console.Write("Add your number: ");
            //string stringNumber = Console.ReadLine();
            decimal[] enteredNumbers = new decimal[25];
            char[] enteredOperators = new char[25];
            int index;
            decimal result = 0;

            do
            {
                // Have to have something to compare with if this is the first operator. 
                enteredOperators[0] = '!';
                index = 0;
                do
                {
                    // User add number/string
                    validNum = GetNumber();
                    enteredNumbers[index] = validNum;

                    // Reads the operator
                    chosenOperator = ChooseOperator(enteredOperators[0]);
                    enteredOperators[index] = chosenOperator;
                    index += 1;

                }

                while (chosenOperator != '=');

                // TODO********* Create calculate method for the code below
                // User only wrote one number => Just show the number
                if (index < 2)
                {
                    Console.WriteLine($"Result: {enteredNumbers[0]}");
                }
                else
                //If index = 2 => it's just two values entered
                if (index == 2)
                {

                    if (enteredOperators[0] == '+')
                    {
                        result = theCalc.Add(enteredNumbers[0], enteredNumbers[1]);
                    }
                    if (enteredOperators[0] == '-')
                    {
                        result = theCalc.Subtract(enteredNumbers[0], enteredNumbers[1]);
                    }
                    if (enteredOperators[0] == '*')
                    {
                        result = theCalc.Multiply(enteredNumbers[0], enteredNumbers[1]);
                    }
                    if (enteredOperators[0] == '/')
                    {
                        result = theCalc.Divide(enteredNumbers[0], enteredNumbers[1]);
                    }

                    Console.WriteLine($"Result: {result}");
                }
                // Severel numbers as input (only for addition and subtraction
                else
                {
                    if (enteredOperators[0] == '+')
                    {
                        result = theCalc.Add(enteredNumbers);
                    }
                    else if (enteredOperators[0] == '-')
                    {
                        result = theCalc.Subtract(enteredNumbers);
                    }
                    else
                    {
                        Console.WriteLine(" You can only add or subtract multiple numbers.");
                    }

                    Console.WriteLine($"Result: {result}");
                }
                //foreach(char c in enteredOperators)
                //{
                //    Console.WriteLine(c);
                //}
                //foreach (decimal c in enteredNumbers)
                //{
                //    Console.WriteLine(c);
                //}

            } while (CalculateAgain());// Call a method, ask if wants to calculate another one

        }

        private decimal GetNumber()
        {
            bool validNumber = false;
            //Regex regEx = new Regex(@"^")
            decimal decimalNum = 0M;
            string invalidMessage = "";
            do
            {
                //Console.SetCursorPosition(0, 10);
                //Console.Write("                                                                                 ");
                //Console.SetCursorPosition(0, 10);
                Console.Write($"{invalidMessage} Please enter your number: ");
                string? numberAsString = Console.ReadLine();
                //while(String.IsNullOrEmpty(numberAsString) || numberAsString != regEx)
                if (numberAsString == null)
                {
                    throw new Exception(invalidMessage);
                }

                if (decimal.TryParse(numberAsString, out decimalNum))
                {
                    if (numberAsString.EndsWith('+') || numberAsString.EndsWith('-'))
                    {
                        invalidMessage = "That's not a valid number.";
                    }
                    else
                    {
                        validNumber = true;
                    }

                }
                else
                {
                    //Continue
                    invalidMessage = "That's not a valid number.";
                }
            } while (!validNumber);

            return decimalNum;
        }

        /// <summary>
        /// User adds an operator, and then it is valuated
        /// </summary>
        /// <returns> valid decimal number</returns>
        private char ChooseOperator(char firstOperator)
        {
            string invalidMessage = "";
            string? operatorAsString;
            char[] validMathOperators = { '+', '-', '*', '/', '=' };
            char mathOperator ='q';
            bool validOperator = true;
            do
            {
                //Console.SetCursorPosition(0, 10);
                //Console.Write("                                                                     ");
                //Console.SetCursorPosition(0, 10);
                validOperator = true;
                Console.Write($"{invalidMessage} Choose operator (+, -, *, /, = ): ");
                operatorAsString = Console.ReadLine();
                if (String.IsNullOrEmpty(operatorAsString) || operatorAsString.Length >= 2)
                {
                    validOperator = false;
                }
                else
                {
                    mathOperator = operatorAsString[0];
                    // Any operator is allowed the 1st time. Only same operator is allowed the second time.
                    if (mathOperator != firstOperator && firstOperator != '!' && mathOperator != '=')
                    {
                        validOperator = false;
                    }
                    else
                        if (!validMathOperators.Contains(mathOperator))
                    {
                        validOperator = false;
                    }
                }
                if(validOperator == false)
                {
                    invalidMessage = "Not valid operator.";
                }
            }
            while (!validOperator);

            return mathOperator;
        }

        public void AddNumbersToArray(decimal numberToAdd)
        {

            theUsersNumbers[i] = numberToAdd;

            i += 1;
        }

        public bool CalculateAgain()
        {
            Console.Write("Do you want to calculate something more? y (yes)/ n (no): ");
            //Console.ReadLine() ? "y" :  true : "n" : false;
            if (Console.ReadLine() == "y")
            {
                Console.Clear();
                GetHeader();
                return true;
            }
            else
            {
                return false;
            }
            //return true;
        }


        //*************** Saved if I need it in future
        //switch (enteredOperators[0])
        //{
        //    case '+':
        //        {
        //            result = theCalc.Add(enteredNumbers[0], enteredNumbers[1]);
        //            break;
        //        }
        //    case '-':
        //        {
        //            result = theCalc.Subtract(enteredNumbers[0], enteredNumbers[1]);
        //            break;
        //        }
        //    case '*':
        //        {
        //            result = theCalc.Multiply(enteredNumbers[0], enteredNumbers[1]);
        //            break;
        //        }
        //    case '/':
        //        {
        //            result = theCalc.Divide(enteredNumbers[0], enteredNumbers[1]);  
        //            break;
        //        }
        //}


        //Choose operator by using enum, set to  char value (Addition = '+')
        //private Operator ChooseOperator2()
        //   {
        //       // User adds an operator
        //       Console.Write("Choose operator (+, -, *, /, = ): ");
        //       string s = Console.ReadLine();
        //       Console.WriteLine(s);       

        //       foreach (string name in Enum.GetNames(typeof(Operator)))
        //       {
        //           Console.WriteLine(name);
        //       }
        //       //Console.WriteLine((char)(int)Enum.Parse(typeof(Operator), "Addition"));
        //       foreach (string name in Enum.GetNames(typeof(Operator)))
        //       {
        //           Console.WriteLine((char)(int)Enum.Parse(typeof (Operator), name));
        //       }

        //           //TryParse(Console.ReadLine(), out Operator chosenOperator);
        //           //Console.WriteLine(((char)chosenOperator).ToString());
        //           return chosenOperator;
        //   }

    }
}
