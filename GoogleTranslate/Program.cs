using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslaterLibr;

namespace GoogleTranslate
{
    class Program
    {
        static void Main(string[] args)
        {
            Translater tr = new Translater();
            string otv = tr.Translate("кошка");
            Console.WriteLine(otv);
            Console.ReadLine();
        }
    }
}
