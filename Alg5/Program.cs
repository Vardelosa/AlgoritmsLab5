
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
            char[] elements = element.ToCharArray();
            for(int i=0; i<elements.Length;i++)
            {
                if(elements[i]=='[')
                {
                    return elements[i + 1]-48;
                }
            }
            return 1;
        }
        static public int Check_Type(string element)
        {
            int memory = 0;
            string[] types = new string[] {"int","char", "double"
               , "float", "void"};
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
                        case 4:
                            memory = 0;
                            break;
                    }
                }
            }
            return memory;
        }

        static public List<Element> Read_Program()
        {
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
                            Elements.Add(new Element(words[i + 1], words[i + 2], words[i + 4], Check_Type(words[i+1]) * If_Array(words[i + 2])));
                            else
                            Elements.Add(new Element(words[i + 1], words[i + 2], "No Value",Check_Type(words[i + 1]) * If_Array(words[i + 2])));
                        }
                    }
                }
                return Elements;
            }
        }
        static Element[] BubbleSort(Element[] mas)
        {
            Element temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i].Memory > mas[j].Memory)
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
        static void Main(string[] args)
        {
            Element[] a = Read_Program().ToArray();
            Table<Element> unsorted= new Table<Element>(a);          
            Element[] b = Read_Program().ToArray(); BubbleSort(b);
            Table<Element> sorted = new Table<Element>(b);
            Console.WriteLine("Unsorted Table: \n");
            foreach (var item in unsorted)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Sorted Table: \n");
            foreach (var item in sorted)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
        
    }
}
