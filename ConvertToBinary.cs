using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManipulation
{
    class ConvertToBinary
    {

        static int bitCounter = 1;

        public void theMain(string[] args)
        {
            //First we create two files, Reader that will reamin the samae
            //adn teh writer that we will modify everytime we build something
            string line = string.Empty;
            int line_number = 1;
            //int line_to_edit = 1;
            int indexNum = 0;

            using StreamReader reader = new StreamReader("Sample.txt");
            int[][] arrNum = new int[300][];
            string[] arrStr = new string[300];
            int assigned = 0;
            int totalValues = 0;

            while ((line = reader.ReadLine()) != null)
            {

                //Console.Write(line_number.ToString() + ", ");
                int start = line.IndexOf("\t");
                string temp = line.Substring(start + 1);
                temp.Remove(temp.Length - 2, 1);
                int tempLen = 0;
                if (arrStr.Contains(temp) == false)
                {
                    totalValues++;
                    arrStr[indexNum] = temp;


                    arrNum[indexNum] = new int[1];
                    for (int i = 0; i < arrNum[indexNum].Length; i++)
                    {
                        arrNum[indexNum][i] = -1;
                    }

                    //Console.WriteLine("Appending: " + line_number.ToString() + " to array  of indexNum" + indexNum.ToString());
                    arrNum[indexNum][0] = line_number;



                    indexNum++;
                    line_number++;

                }
                else
                {
                    tempLen = Array.IndexOf(arrStr, temp);
                    //Console.WriteLine(tempLen.ToString());
                    int finalInd = 0;
                    while (arrNum[tempLen][finalInd] != -1 && finalInd < arrNum[tempLen].Length - 1)
                    {
                        finalInd++;
                    }
                    arrNum[tempLen][finalInd] = line_number;
                    //Console.WriteLine(finalInd);
                    line_number++;
                }

            }
            // Console.WriteLine();

            reader.Close();

            for (int i = 0; i < 300; i++)
            {

                if (arrStr[i] != null)
                {
                    Console.Write(arrStr[i] + ": ");

                    for (int j = 0; j < arrNum[i].Length; j++)
                    {
                        if (arrNum[i][j] != -1)
                        {

                            Console.Write(arrNum[i][j]);
                            assigned++;

                            if (j + 1 < arrNum[i].Length && arrNum[i][j + 1] != -1)
                            {
                                Console.Write(", ");
                            }
                        }
                    }
                    Console.WriteLine();
                }




            }

            Console.WriteLine("Total Assigned: " + assigned.ToString());
            Console.WriteLine("Total Values: " + totalValues.ToString());


            Console.WriteLine();

            writeToFile(arrStr, arrNum);
            Console.WriteLine("DONE1");
            writeToBinary(totalValues);
            Console.WriteLine("DONE2");
            //using StreamWriter writer = new StreamWriter("Wrote.txt");

            /*while ((line = reader.ReadLine()) != null)
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
            }*/














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
            string temp = line.Substring(start + 1);

            using StreamWriter writer = new StreamWriter("Wrote.txt");
            string tempLine = string.Empty;



        }

        public static double stringToFloat(string str)
        {
            return Convert.ToDouble(str);
        }

        public static void writeToFile(string[] strArr, int[][] numArr)
        {
            //using StreamWriter writer = new StreamWriter("Wrote.txt");
            using StreamReader reader = new StreamReader("Sample.txt");
            string line = string.Empty;

            int tempLen = 0;
            int line_num = 1;
            while ((line = reader.ReadLine()) != null)
            {
                int start = line.IndexOf("\t");
                string temp = line.Substring(start + 1);
                temp.Remove(temp.Length - 2, 1);

                tempLen = Array.IndexOf(strArr, temp);
                string replaceString = line.Substring(0, start + 1);
                replaceString += tempLen.ToString();
                lineChanger(replaceString, "Wrote.txt", line_num);
                line_num++;
            }
            reader.Close();
            createFinalFIle();
        }

        public static void createFinalFIle()
        {
            using StreamReader reader = new StreamReader("Wrote.txt");
            using StreamWriter writer = new StreamWriter("Final.txt");

            string line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                writer.WriteLine(line);
            }

            reader.Close();
            writer.Close();
        }

        public static void writeToBinary(int Max)
        {

            using StreamReader reader = new StreamReader("Wrote.txt");
            //using StreamWriter writer = new StreamWriter("Final.txt");

            string line = string.Empty;
            int line_num = 1;
            while ((line = reader.ReadLine()) != null)
            {

                int tempLen = 0;

                int start = line.IndexOf("\t");
                string temp = line.Substring(start + 1);
                //temp.Remove(temp.Length - 2, 1);

                string replaceString = line.Substring(0, start + 1);
                string binaryRepresentaion = Convert.ToString(Int32.Parse(temp), 2);
                string padding = string.Empty;
                if (binaryRepresentaion.Length < Math.Log2(Max))
                {
                    for (int i = 0; i < Math.Log2(Max) - binaryRepresentaion.Length; i++)
                    {
                        padding += "0";
                    }
                }
                replaceString += padding + binaryRepresentaion;

                lineChanger(replaceString, "Final.txt", line_num);
                line_num++;
            }
            reader.Close();

        }
    }
}
