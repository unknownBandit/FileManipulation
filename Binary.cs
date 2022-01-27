using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;

using System.Runtime.InteropServices;
using static System.IO.StreamWriter;
using Excel = Microsoft.Office.Interop.Excel;  //Right Click on your project name in solution exploror
                                               //Then add COM on the referencees
                                               //Serach for Excel 14.0 or + object and add it. 

namespace FileManipulation
{
    class Binary
    {
        public void copyFromCSVtoTXTFile()
        {
            //Create a file stream object that opens the given file, 
            //in our case the file anme is FileTest.csv
            //It opens it only to read
            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\Rex\Documents\work\Rasheed\FileManipulation\bin\Debug\net6.0\FileTest.csv");
                Excel._Worksheet xlWorkSheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorkSheet.UsedRange;



                using (StreamWriter file = new("temp.txt", append: true))
                {
                    //700070 is the last line of i
                    //change the value according to number of lines in your file. 
                    for (int i = 1; i <= 70; i++)
                    {
                        for (int j = 1; j <= 2; j++)
                        {

                            //Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");
                            string tempString = xlRange.Cells[i, j].Value2.ToString() + "\t";
                            //Console.Write(tempString);

                            file.Write(tempString);
                            // Console.Write(tempString);

                        }
                        //Console.Write("\n");
                        file.Write("\n");

                    }
                }
                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //rule of thumb for releasing com objects:
                //  never use two dots, all COM objects must be referenced and released individually
                //  ex: [somthing].[something].[something] is bad

                //release com objects to fully kill excel process from running in the background
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorkSheet);

                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            //install the iexcelldatareader package
            //create a excellReader2 which reads the excell files. 
            //Make the instance be able to read the csv file and then pass our stream file variable: F as the argument. 

            /*
                        using (StreamWriter writeStream = new("temp.txt"))
                        {
                            for (int i = 1; i <= 5; i++)
                            {
                                writeStream.WriteLine(" : Current Replaced as [11111]");
                                //Console.WriteLine(": Current Replaced as [11111]");
                            }
                        }
                        string readText = File.ReadAllText("temp.txt");
                        Console.WriteLine(readText);
            */

            Console.WriteLine("\nDONE");
            Console.ReadKey();
        }

    }
}
