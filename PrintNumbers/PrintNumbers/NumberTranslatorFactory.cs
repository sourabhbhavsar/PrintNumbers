using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintNumbers
{
    // Factory class to get the number translator for different languages
    class NumberTranslatorFactory
    {

        // factory method that returns the language translator for the corresponding input language
        public static NumberTranslator GetNumberTranslator(string lang)
        {
            NumberTranslator numTranslator = null;

            if (lang.Equals("english", StringComparison.InvariantCultureIgnoreCase))
            {
                numTranslator = new EnglishTranslator();
            }
            // need to write more if else when new languages added.

            return numTranslator;
        }
    }
}
