using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //StringBuilder stroking = new StringBuilder();
            //stroking.AppendLine("С#");
            //stroking.Insert(2, " Programming");
            //Console.WriteLine(stroking.ToString());
            //for (int i = 0, j = stroking.Length - 1; i < stroking.Length / 2; i++, j--)
            //{
            //    char temp = stroking[i];
            //    stroking[i] = stroking[j];
            //    stroking[j] = temp;
            //}
            //Console.WriteLine(stroking.ToString());

            //.//______

            //StringBuilder stroking1 = new StringBuilder();
            //stroking1.AppendLine("C# is cool and fun!");
            //stroking1.Remove(10, 8);
            //Console.WriteLine(stroking1.ToString());

            //stroking1.Insert(5, " C#");
            //Console.WriteLine(stroking1.ToString());

            //stroking1.Replace("cool", "best");
            //Console.WriteLine(stroking1.ToString());

            //string stroking2 = "Крутокруто круто некруто";
            //Console.WriteLine(stroking2.ToString());
            //stroking2 = stroking2.Substring(3, 7);
            //Console.WriteLine(stroking2.ToString());

            //_____________________________________________________________________________________________________________________
            StringBuilder stroka = new StringBuilder("Привет меня зовут Вова");
            int newstr = stroka.Length;


            ////&
            char[] newchar = new char[67];
            int index = 0;

            for (char i = 'А'; i <= 'я'; i++)
            {
                newchar[index] = i;
                index++;
            }
            newchar[64] = 'a';
            newchar[65] = 'б';
            newchar[66] = 'в';
            ////&

            ////for (int j = 0; j < newchar.Length; j++)
            ////{
            ////    Console.WriteLine(newchar[j]);
            ////}



            //for (int j = 0; j < stroka.Length; j++)
            //{

            //    char bukva = stroka[j];
            //    if (Convert.ToString(stroka[j]) != " " && Convert.ToString(stroka[j]) != ",")
            //    {
            //        int indbukvivalfavite = Array.IndexOf(newchar, bukva);
            //        bukva = newchar[indbukvivalfavite + 3];
            //        Console.Write(bukva);
            //    }
            //    else
            //    {
            //        Console.Write(" ");
            //    }
            //}






            //&
            Console.WriteLine("Введите зашифрованную строку:");
            StringBuilder vstr = new StringBuilder(Console.ReadLine());

            for (int k = 0; k < vstr.Length; k++)
            {

                char vbukva = vstr[k];
                if (Convert.ToString(vstr[k]) != " " && Convert.ToString(vstr[k]) != ",")
                {
                    int indvbukvi = Array.IndexOf(newchar, vbukva);
                    vbukva = newchar[indvbukvi - 3];
                    Console.Write(vbukva);
                }
                else
                {
                    Console.Write(" ");
                }


            }
            //&





        }
    }
}
