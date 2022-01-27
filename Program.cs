using ExcelDataReader;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using static System.IO.StreamWriter;
using Excel = Microsoft.Office.Interop.Excel;  

namespace FileManipulation
{
    class Program
    {
        static int bitCounter = 1;
        static void Main(string[] args)
        {
            //First we create two files, Reader that will reamin the samae
            //adn teh writer that we will modify everytime we build something
            string line = string.Empty;
            int line_number = 1;
            int line_to_edit = 1;

            using StreamReader reader = new StreamReader("Sample.txt");
            //using StreamWriter writer = new StreamWriter("Wrote.txt");
            
            while ((line = reader.ReadLine()) != null)
            {
                if(line.Contains(".") == true)
                {
                    lineFinder(line, line_number);
                }
                else
                {
                    line_number += 1;
                    continue;
                }
                line_number += 1;
            }












        }

        public static string getBinaryString(double num)
        {
            string str = "";
            str = Convert.ToString(Convert.ToInt64(num), 2);
            return str;
        }

        public static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        public static void lineFinder(string line, int line_num)
        {
            int start = line.FirstOrDefault('\t'); 
            string temp = line.Substring(start+1);

            

        }

        public static double stringToFloat(string str)
        {
            return Convert.ToDouble(str);
        }

    }
}