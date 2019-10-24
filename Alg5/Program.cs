
//В файле содержится текст программы на языке С.
//Файл разделен на строки произвольной длины (но не более 256).
//Используя определение и описание, построить таблицу констант.
//Элемент таблицы содержит значение константы, имя константы, тип константы, размер памяти. Организовать таблицу как: а) неупорядоченную б) упорядоченную.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Alg5
{
    class Program
    {
        static public int If_Array(string element)
        {
            string[] ar_types = new string[] {"int[]","char[]", "double"
               , "float" };
        }
        static public int Check_Type(string element)
        {
            int memory = 0;
            string[] types = new string[] {"int","char", "double"
               , "float" };
            for(int i=0;i<types.Length;i++)
            {
                if(element==types[i])
                {
                    switch(i)
                    {
                        case 0:
                            memory = sizeof(int);
                            break;
                        case 1:
                            memory = sizeof(char);
                            break;
                        case 2:
                            memory = sizeof(double);
                            break;
                        case 3:
                            memory = sizeof(float);
                            break;
                    }
                }
            }
            return memory;
        }
        static public List<Element> Read_Program()
        {
            //string[] types = new string[] {"int","char", "double"
            //    , "float", };
            List < Element > Elements = new List<Element>();
            string path = "program.c";
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string temp_line;
                while ((temp_line = sr.ReadLine()) != null)
                {
                    string[] words = temp_line.Split(new char[] { ' ',';' });
                    for(int i=0;i<words.Length;i++)
                    {
                        if(words[i]=="static")
                        {
                            if(words.Length>3&& words[i + 3] == "=")
                            Elements.Add(new Element(words[i + 1], words[i + 2], words[i + 4], Check_Type(words[i+1])));
                            else
                            Elements.Add(new Element(words[i + 1], words[i + 2], "No Value",Check_Type(words[i + 1])));
                        }
                    }
                }
                //Console.WriteLine("Static elements: \n");
                //foreach(var item in Elements)
                //{
                //    Console.WriteLine(item.ToString());
                //}
                return Elements;
               // Console.WriteLine(temp_line);
            }
        }
        static void Main(string[] args)
        {
            Element[] a = Read_Program().ToArray();
            Table<Element> nt= new Table<Element>(a);
            Console.WriteLine(nt[1].ToString());
            Console.ReadKey();
        }
        
    }
}
