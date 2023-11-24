using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    using System;

    class Program
    {
        static char[,] calculatorSetup = new char[4, 5] { { '1', '2', '3', '*', 'S' }, { '4', '5', '6','/' , 'N' }, { '7', '8', '9','-','L' }, { 'B', '0', '^', '+','R' } }; //This is a multiple dimensional array of 4 rows, 4 columns, containing numbers 0-9 and 6 operators, + - * / B ^

        /// <summary>
        /// Handles all the calculation logic. The calculator will run for as long as the user hasnt told the calculator to exit.
        /// </summary>
        static void Main()
        {
            string input;
            const int naturalLog = 10;

            do
            {
                Console.Clear(); //Clears the calculations and inputs from previous interactions if they occur.
                CalculatorIllustration(); //Illustrates the digital calculator, showcasing the options for the user. 
                input = Console.ReadLine().ToLower(); //This input takes the exit command or the first number from the user, if they are initiation calculation process.
                if (input == "exit") //Will end the program if the user desires.
                    break;
                CalculatorLogic(input, naturalLog); //The Calculator logic is prepared, and the input is parsed onto this method to prevent double input requirement.
            }

            while (true); //Will continue until user desires to hit the break condition
        }
        /// <summary>
        /// This method will illustrate a digital calculator
        /// </summary>
        private static void CalculatorIllustration()
        {

            int v = 5, h = 2; //X and y values for the placement of the calculator elements which is built by numbers and symbols
            Console.SetCursorPosition(v, h);
            Console.Write("┌─────┬─────┬─────┬─────┐");  // lin 1
            Console.SetCursorPosition(v, h + 1);
            Console.Write("│     │     │     │     │");  // lin 2 mellem
            Console.SetCursorPosition(v, h + 2);
            Console.Write($"│  {calculatorSetup[0, 0]}  │  {calculatorSetup[1, 0]}  │  {calculatorSetup[2, 0]}  │  {calculatorSetup[3, 0]}  │");  // lin 2 mellem
            Console.SetCursorPosition(v, h + 3);
            Console.Write("│     │     │     │     │");  // lin 2 mellem
            Console.SetCursorPosition(v, h + 4);
            Console.Write("├─────┼─────┼─────┼─────┤");  // lin
            Console.SetCursorPosition(v, h + 5);
            Console.Write("│     │     │     │     │");  // lin 2 mellem
            Console.SetCursorPosition(v, h + 6);
            Console.Write($"│  {calculatorSetup[0, 1]}  │  {calculatorSetup[1, 1]}  │  {calculatorSetup[2, 1]}  │  {calculatorSetup[3, 1]}  │");  // lin 2 mellem
            Console.SetCursorPosition(v, h + 7);
            Console.Write("│     │     │     │     │");  // lin 2 mellem
            Console.SetCursorPosition(v, h + 8);
            Console.Write("├─────┼─────┼─────┼─────┤");  // lin
            Console.SetCursorPosition(v, h + 9);
            Console.Write("│     │     │     │     │");  // lin 2 mellem
            Console.SetCursorPosition(v, h + 10);
            Console.Write($"│  {calculatorSetup[0, 2]}  │  {calculatorSetup[1, 2]}  │  {calculatorSetup[2, 2]}  │  {calculatorSetup[3, 2]}  │");  // lin 2 mellem
            Console.SetCursorPosition(v, h + 11);
            Console.Write("│     │     │     │     │");  // lin 2 mellem
            Console.SetCursorPosition(v, h + 12);
            Console.Write("├─────┼─────┼─────┼─────┤");  // lin
            Console.SetCursorPosition(v, h + 13);
            Console.Write("│     │     │     │     │");  // lin 2 mellem
            Console.SetCursorPosition(v, h + 14);
            Console.Write($"│  {calculatorSetup[0, 3]}  │  {calculatorSetup[1, 3]}  │  {calculatorSetup[2, 3]}  │  {calculatorSetup[3, 3]}  │");  // lin 2 mellem
            Console.SetCursorPosition(v, h + 15);
            Console.Write("│     │     │     │     │");  // lin 2 mellem
            Console.SetCursorPosition(v, h + 16);
            Console.Write("├─────┼─────┼─────┼─────┤");  // lin
            Console.SetCursorPosition(v, h + 17);
            Console.Write("│     │     │     │     │");  // lin 2 mellem
            Console.SetCursorPosition(v, h + 18);
            Console.Write($"│  {calculatorSetup[0, 4]}  │  {calculatorSetup[1, 4]}  │  {calculatorSetup[2, 4]}  │  {calculatorSetup[3, 4]}  │");  // lin 2 mellem
            Console.SetCursorPosition(v, h + 19);
            Console.Write("│     │     │     │     │");  // lin 2 mellem
            Console.SetCursorPosition(v, h + 20);
            Console.Write("└─────┴─────┴─────┴─────┘");

            Console.SetCursorPosition(v, h + 22);
            Console.Write("Enter a number. For exiting the calculator, write exit");

            Console.WriteLine(); //Gives room for the input so that the text isnt packed together.
            

        }
        /// <summary>
        /// This method contains the logic for the calculator. It will require either 2 or 3 inputs depending on choice of operator. First number, operator, and second number. When choosing the banana operator, there is no need for a third number, as the first number is the number of bananas, and banana size is static. 
        /// </summary>
        /// <param name="input">Required here to allow for the first input to either initiate the calculation process (entering a number) or ending the program (writing exit)</param>
        private static void CalculatorLogic(string input, int naturalLog)
        {
            if (double.TryParse(input, out double num1)) //Condition that checks if the input can be interpreted as a double, if yes, the logic will begin, else nothing will happen. This will help prevent invalid inputs. If valid, num1 will be gathered and passed on inside the if statement for further calculations.
            {


                Console.Write("Enter the operation (+, -, *, /, B (Banana calc), ^ (squared), \nN (factorial), R (Restart), L (Log), S (SquareRoot): "); //Shows the user what types of operators they can use to do calculations, including the infamous banana calculation that tells the user the size of their bananas in centimeters. 
                string operation = Console.ReadLine().ToLower(); //Reads the operator choice from the user, could also have been a readkey but I initially wanted to have other buttons that werent necessarily chars. 

   
                double result = 0; //result is set to 0 as default to prevent null results. 
                switch (operation) //The user choice will hit one of these cases. If not, the calculation process will just restart via the default condition.
                {
                    case "+": //Handles the result in case of addition choice
                        Console.Write("Enter the second number: "); //Asks the user to give the last input (the number they want to add to the first number)
                        if (double.TryParse(Console.ReadLine(), out double addition)) //Condition that checks if the input can be interpreted as a double, if yes, the logic will begin, else nothing will happen. This will help prevent invalid inputs. If valid, result will be calculated.
                        {
                            result = num1 + addition; //Calculates end result
                        }
                        break; //Exits the switch
                    case "-": //Handles the result in case of subtraction choice
                        Console.Write("Enter the second number: "); //Asks the user to give the last input (the number they want to subtract from the first number)
                        if (double.TryParse(Console.ReadLine(), out double substraction)) //Condition that checks if the input can be interpreted as a double, if yes, the logic will begin, else nothing will happen. This will help prevent invalid inputs. If valid, result will be calculated.
                        {
                            result = num1 - substraction; //Calculates end result
                        }
                        break; //Exits the switch
                    case "*": //Handles the result in case of multiplication choice
                        Console.Write("Enter the second number: "); //Asks the user to give the last input (the number they want to multiply the first number with)
                        if (double.TryParse(Console.ReadLine(), out double multiplicator)) //Condition that checks if the input can be interpreted as a double, if yes, the logic will begin, else nothing will happen. This will help prevent invalid inputs. If valid, result will be calculated.
                        {
                            result = num1 * multiplicator; //Calculates end result
                        }
                        break; //Exits the switch
                    case "/": //Handles the result in case of division choice

                        Console.Write("Enter the second number: "); //Asks the user to give the last input (the number they want to divide the the first number with)
                        if ((double.TryParse(Console.ReadLine(), out double divider) && divider != 0)) //Condition that checks if the input can be interpreted as a double and if the number isnt 0, if yes, the logic will begin, else nothing will happen. This will help prevent invalid inputs (dividing by 0 scary). If valid, result will be calculated.
                        {
                            result = num1 / divider; //Calculates end result
                        }
                        break; //Exits the switch

                    case "^": //Handles the result in case of squaring choice

                        Console.Write("Enter the second number: "); //Asks the user to give the last input (the number they want to square the first number with)
                        if (double.TryParse(Console.ReadLine(), out double square))
                        {
                            result = Math.Pow(num1, square); //Calculates end result
                        }
                        break; //Exits the switch

                    case "b": //Handles the result in case of Banana size choice

                        result = num1 * 16.5; //Bananas are big yo
                       
                        break; //Exits the switch

                    case "n": //Handles the result in case wanting the factorial

                        result = Factorial((int)num1);

                        break; //Exits the switch

                    case "r": //Just restarts

                        return;

                    case "l": //Handles the result in case of logarithm calculation

                        result = Math.Log(num1, naturalLog);

                        break; //Exits the switch

                    case "s": //Handles the result in case of logarithm calculation

                        result = Math.Sqrt(num1);

                        break; //Exits the switch

                    default: //Will restart the calculation process if an invalid choice is called.
                        Console.WriteLine("Invalid operation. Press any key to restart the calculation process"); //Tells the user that their input is not covered by the limited amount of operators. Even though banana calculations should be sufficient
                        Console.ReadKey(); //Prevents the return from happening, so the user can see that they gave invalid input.
                        return; //Restart calculation process.

                }
                Console.WriteLine($"Result: {result} \n\n Press any key to restart calculator"); //Shows the end result to the user depending on their choice of operator and numbers. 

                Console.ReadKey();

            }

        }
        /// <summary>
        /// Calculates the factorial for a number
        /// </summary>
        /// <param name="n"></param>
        /// <returns>n!</returns>
        private static double Factorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

    }

}
