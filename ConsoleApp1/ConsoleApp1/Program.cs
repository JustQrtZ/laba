using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace CalculateAge
{
    public class Program
    {
        static void Main(string[] args)
        {
            DateTime date;
            string text = "";
            using (StreamReader fs = new StreamReader(@"project_date.txt"))
            {
                while (true)
                {
                    string temp = fs.ReadLine();
                    if (temp == null) break;
                    text += temp;
                }

            }
            string res = null;
            try
            {
                res = Convert.ToString(Regex.Match(text, @"(\d\d).(\d\d).(\d\d\d\d)", RegexOptions.IgnoreCase));
                res = Regex.Replace(res, @"(\d\d).(\d\d).(\d\d\d\d)", "$1-$2-$3", RegexOptions.IgnoreCase);
            }
            catch (ArgumentException ex)
            {
                // Syntax error in the regular expression
            }
            try
            {
                date = Convert.ToDateTime(res);
                Console.WriteLine(date);
                string writePatch = @"C:\Users\Vlad\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\sdatami.txt";
                using (StreamWriter sw = new StreamWriter(writePatch, true, System.Text.Encoding.Default))
                    sw.Write(date);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("нету даты");
            }
            Console.ReadKey();
        }
    }
}