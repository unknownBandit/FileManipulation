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
        public static void Main(string[] args)
        {
            int n = 2;
            string nameTemp = "Compare" + n.ToString() + ".txt";
            BestSegment prg1 = new BestSegment(nameTemp,200);
            prg1.PerFormTask(@"C:\Users\Rex\Documents\SHSU\work\Rasheed\FileManipulation\bin\Debug\net6.0\TrainingData.txt");
        }

    }
}