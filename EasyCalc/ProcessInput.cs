using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCalc
{
    internal class ProcessInput
    {

        History history = History.Instance(); // Gets the History instance.


        // Gets user input and decides how to intepret it. If its given a matimatical expresion that is valid it will pass it
        // to the "Eval" method witch returns a doubel that is added to the List objekt inside of the History class then
        // writes what the user inputed and the result to the console.
        public void Calc() 
        {

            string calcInput = "";
            double answer = 0;

            // Loop to let the user input however meny inputs it wants. 
            while (true)
            {

                while (true)
                {
                    Console.Clear();

                    Console.Write("Please enter a mathematical expression.You can also type help for more information: ");

                    try // Validates user input
                    {
                        calcInput = Console.ReadLine().ToLower();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        continue;
                    }


                    if (calcInput == "back" || calcInput == "exit") // If user inputs "back" or "exit" returns to meny
                    {
                        Console.Clear();
                        return;
                    }

                    else if (calcInput == "help") // If user inputs "help" writes helpful information in the console. 
                    {
                        Console.Clear();
                        Console.WriteLine("This is a simpel calculator that can use the operators\naddition'+' subtraction'-' multiplication'*' division'/' and parentheses()\n\nExit/Back - Takes you back to the meny.\n\nHelp - brings up this page.\n\nPress any key to continue.");
                        Console.ReadKey(true);
                        continue;
                    }

                    else
                    {
                        break;
                    }
                }

                try
                {

                    answer = Eval(calcInput); // Gives user input to the "Eval" method which return a double.

                    if (answer.ToString() == "∞" || answer.ToString() == "NaN") // If the variable "answer" is a value that is
                                                                                // associated with dividing with zero throws a
                                                                                // devided by zero exception.
                    {
                        throw new DivideByZeroException("You can't divide by zero!");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.ReadKey();
                    continue;
                }


                /* The code below tries to filter user input before displaying it. */
                

                calcInput = calcInput.Replace(" ",""); // Removes any spaces.

                bool minusCheck = false; // Creates veribol to check if first index in "calcInput" is a minus.
                                         // This is to put a minus back in that position as it will get removed later on.


                if (calcInput[0] == '-') // Checks if the firts index in "calcInput" is a minus. if it is sets "minusCheck" to true.
                {
                    minusCheck = true;
                }

                while (calcInput.IndexOfAny(new[] { '+', '-',}) == 0) // Removes any pluses or minuses at index 0. 
                {
                    
                    calcInput = calcInput.Remove(0, 1);

                }


                foreach (char x in calcInput) // Removes pluses and minuses next to eachother.  
                {

                    if (new[] { '+', '-',}.Contains(x))
                    {
                        if (calcInput[calcInput.IndexOf(x)] == calcInput[calcInput.IndexOfAny(new[] {'+','-'}) + 1]) // Check for the first occurrence of a plus or minus sign
                                                                                                                     // and if the character to the right of it is also a plus or minus sign.
                        {
                            calcInput = calcInput.Remove(calcInput.IndexOf(x), 1); // Removes the first ocurenc if the statement above is true
                        }
                    }
                }

                if (minusCheck) // Puts back a minus at index 0 if there where one there originally.
                {
                    calcInput = calcInput.Insert(0, "-"); 
                }


                /* OBS The code above is not perfect and problems still exist whit it.
                 * 
                 * Example1: 12----+++12 becomes 12-12 when it should become 12+12.
                 * 
                 * Example2: +-12 becomes 12 when it should become -12.
                 * 
                 * Potential Fix: Interpret the plus and minus signs that are next to
                 * each other by for exsampel putting them in the "Eval" with a 1 and 
                 * check if it returns positive or negative number.
                 */


                string strAnswer = $"{calcInput} = {answer}"; // Creates a string with what the user inputted and the result.

                history.HistoryList.Add(strAnswer); // Adds the string above to the List objekt in the History class.

                Console.WriteLine(strAnswer);

                while (true) // Asks the user if it wants to go back to the meny.
                {
                    Console.Write("Do you want to go back to the meny? (Yes/No) : ");

                    string yesNo = Console.ReadLine().ToLower();

                    if (yesNo == "yes")
                    {
                        Console.Clear();
                        return;
                    }
                    else if (yesNo == "no")
                    {
                        break;
                    }

                }

            }

        }

        Double Eval(String expression) // Creates a "DataTabel" object callde tabel. Then it calls the "DataTabel" method "Compute" and givs it a string
                                       //  and a empty string. The "Compute" method then returns a object whith the result which then is converted to a double and returned.  
        {
            DataTable table = new DataTable();
            return Convert.ToDouble(table.Compute(expression, String.Empty)); // The first value given to the "Compute"
                                                                              // method is the value geting compted whiles the second
                                                                              // is what value shuld be filterd.
        }

    }
}
