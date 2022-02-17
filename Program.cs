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
           
            
            for(int i=0; i<100 ; i++)
            {
                string nameTemp = "Compare__" + i.ToString() + ".txt";
                BestSegment prg1 = new BestSegment(nameTemp, 200+i);
                prg1.PerFormTask(@"C:\Users\Rex\Documents\SHSU\work\Rasheed\FileManipulation\bin\Debug\net6.0\TrainingData.txt");

            }
        }

    }
}