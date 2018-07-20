using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintNumbers
{
    // Abstract class that represents the base class for
    // NumberTranslators for different languages.
    abstract class NumberTranslator
    {
        // method that the concrete translators should implement.
        public abstract string Translate(int number);
    }
}
