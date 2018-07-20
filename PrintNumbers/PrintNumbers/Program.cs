using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.CommandLineUtils;

namespace PrintNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the command line app
            var app = new CommandLineApplication();
            
            app.Name = "PrintNumbers";
            app.Description = "Zephyr Coding Excercise";            

            // Set the arguments to display the description and help text
            app.HelpOption("-?|-h|--help");

           // Adding the command line options.
            var startNum = app.Option("-s|--startNum <Integer_value>",
                    "The start number of the range of the numbers program will print",
                    CommandOptionType.SingleValue);

            var endNum = app.Option("-e|--endNum <Integer_value>>",
                    "The end number of the range of the numbers program will print",
                    CommandOptionType.SingleValue);

            var divisbleBy = app.Option("-d|--divisbleBy <Positive_Integer_value>",
                    "The number that printed numbers should be multiple of. It should be greater than 0",
                    CommandOptionType.SingleValue);

            var language = app.Option("-l|--language <String_value>",
                    "Language to translate the numbers to",
                    CommandOptionType.SingleValue);


            // Print the numbers divisible by passed number in reverse from range [end - start] translated in the given language.
            app.OnExecute(() =>
            {
                int iStartNum = Int32.Parse(startNum.Value());
                int iEndNum = Int32.Parse(endNum.Value());
                int iDivisibleBy = Int32.Parse(divisbleBy.Value());                

                PrintMultiplesOfNinRange(iStartNum, iEndNum, iDivisibleBy, language.Value());

                return 0;
            });

            try
            {
                // Execute the application                
                app.Execute(args);
            }
            // if somthing goes wrong in the command line arg parsing
            catch (CommandParsingException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // if somthing goes wrong in executing the app.
            catch (Exception ex)
            {
                Console.WriteLine("Unable to execute application: {0}", ex.Message);
            }

        }

        // Utility function to print the numbers in the range [end - start] which are multiple of given num translated in given language
        static void PrintMultiplesOfNinRange(int startNum, int endNum, int divisibleBy, string language)
        {
            // get the number translator corresponding to the input language from the factory.
            NumberTranslator numTranslator = NumberTranslatorFactory.GetNumberTranslator(language);

            // iterate over the range in reverse.
            for (int iLoopCounter = endNum; iLoopCounter >= startNum; iLoopCounter--)
            {
                // if the number is a multiple of divisibleBy, then print it.
                if ((iLoopCounter % divisibleBy) == 0)
                {
                    // get the string that reprsents number worded in the given language.
                    string numStr = numTranslator.Translate(iLoopCounter);
                    Console.WriteLine(numStr);
                }
            }
        }
    }
}
