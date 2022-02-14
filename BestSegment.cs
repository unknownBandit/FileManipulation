using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManipulation
{
    class BestSegment
    {
        private double[] doubleArray;
        private int initialization;
        private string fileToSave = string.Empty;
        private int totalValue = 349734;


        public BestSegment(string filename, int a)
        {
            initialization = a;
            fileToSave = filename;
            doubleArray = new double[initialization];
            string temp = @"C:\Users\Rex\Documents\SHSU\work\Rasheed\FileManipulation\bin\Debug\net6.0\TrainingData.txt";
            doubleArray = getDoubleSegmentFromString(getSegment(temp));
        }

        public BestSegment(int a)
        {
            initialization = a;
            doubleArray = new double[initialization];
            string temp = @"C:\Users\Rex\Documents\SHSU\work\Rasheed\FileManipulation\bin\Debug\net6.0\TrainingData.txt";
            doubleArray = getDoubleSegmentFromString(getSegment(temp));
        }
        public void PerFormTask(string filename)
        {
            double minimum = double.MaxValue;
            
            //int limit = 349734;
            int limit = 5;
            double[] writeArray = new double[limit];
            for (int i=0; i<limit; i++)
            {
                double tempValue = compareAndGetValue(getComparisionSegment(filename, i));
                writeArray[i] = tempValue;
                if(tempValue < minimum)
                    minimum = tempValue;

            }

            writeToFile(writeArray);
            
        }
        public void writeToFile(double[] numArr)
        { 
            using StreamWriter writer = new StreamWriter(fileToSave);
            //using StreamReader reader = new StreamReader("ComparisonFile.txt");
            writer.WriteLine("MAx value: " + double.MaxValue);
            double minimum = double.MaxValue;
            double minIndex = -1;
            for(int i=0; i<numArr.Length; i++)
            {
                writer.WriteLine(numArr[i]);
                if (numArr[i] < minimum)
                {
                    minimum = numArr[i];
                    minIndex = i;
                }
            }
            writer.WriteLine("\n\nMinimum is: " +  minimum + " at index: " + minIndex);
            //Console.WriteLine("Minimum is: " + minimum);
            writer.Close(); 
           
        }

        public string[] getSegment(string filename)
        {
            string path = @"C:\Users\Rex\Documents\SHSU\work\Rasheed\FileManipulation\bin\Debug\net6.0\ValidationData.txt";
            /*if (filename == String.Empty)
                filename = path;*/
            using StreamReader reader = new StreamReader(path);
            string line = string.Empty;
            string[] newSegment = new string[initialization];
            // int limit = 116678;
            int limit = 5;
            for(int i=0; i<116678;i++)
            {
                line = reader.ReadLine().ToString();
            }
            for(int i=0; i<initialization; i++)
            {
                line = reader.ReadLine().ToString();
                newSegment[i] = line;
            }
            reader.Close();
            return newSegment;
        }
        
        

        public string[] getComparisionSegment(string filename, int startPosition)
        {
            using StreamReader reader = new StreamReader(filename);
            string line = string.Empty;
            string[] newSegment = new string[initialization];
            for (int i = 0; i < startPosition; i++)
            {
                line = reader.ReadLine().ToString();
                
            }
            for (int i = 0; i < initialization; i++)
            {
                line = reader.ReadLine().ToString();
                //if (line != String.Empty)
                //  Console.WriteLine(line);
                newSegment[i] = line;
            }
            reader.Close();
            return newSegment;
        }

        public double compareAndGetValue(string[] comparisionSegment)
        {
            double value = 0;
            double[] doubleCompareSegmet = new double[initialization];
            doubleCompareSegmet = getDoubleSegmentFromString(comparisionSegment);
            for(int i=0; i<initialization; i++)
            {
                double temp = Math.Abs(doubleArray[i] - doubleCompareSegmet[i]);
                value += temp;
            }
           
            
            return value;
        }

        public double[] getDoubleSegmentFromString(string[] givenSegment)
        {
            double[] newDouble = new double[givenSegment.Length];
            double tDouble = double.MaxValue;
            for(int i=0; i<givenSegment.Length;i++)
            {
               
                   Console.WriteLine(givenSegment[i]);
                   int start = givenSegment[i].IndexOf('\t');
                   string temp = givenSegment[i].Substring(start + 1);
                    tDouble = stringToDouble(temp);
                
                newDouble[i] = tDouble;
            }
            return newDouble;
        }

        public static double stringToDouble(string str)
        {
            return Convert.ToDouble(str);
        }


        
    }

   
}
