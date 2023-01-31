using System;
using System.Collections.Generic;
using System.IO;

namespace FicherosTexto
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            Console.WriteLine("------FicherosTexto---------");
            Console.WriteLine("1.- EscribeFicheroNumRandom10");
            Console.WriteLine("2.- SumaFicheroInt10");
            Console.WriteLine("3.- EscribeFicheroNumRandom");
            Console.WriteLine("4.- SumaFicheroInt");
            Console.WriteLine("5.- EscribeFicheroTexto");
            Console.WriteLine("6.- LeeFicheroTexto");
            Console.WriteLine("7.- CopiaFicheroTexto");
            Console.WriteLine("8.- InvierteLineasFichero");
            Console.WriteLine("9.- InvierteFicheroTexto");
            Console.WriteLine("10.- SeparaPalabrasFichero");
            Console.WriteLine("--------------------------");
            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    {
                        EscribeFicheroNumRandom10("random10.txt");
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine(SumaFicheroInt10("random10.txt")); 
                    }
                    break;
                case 3:
                    {
                        EscribeFicheroNumRandom("random.txt",5);
                    }
                    break;
                case 4:
                    {
                        Console.WriteLine(SumaFicheroInt("random.txt")); 
                    }
                    break;
                case 5:
                    {
                        EscribeFicheroTexto("texto.txt");
                    }
                    break;
                case 6:
                    {
                        LeeFicheroTexto("texto.txt");
                    }
                    break;
                case 7:
                    {
                        CopiaFicheroTexto("texto.txt", "copia.txt");
                    }
                    break;
                case 8:
                    {
                        InvierteLineasFichero("texto.txt", "invertido.txt");
                    }
                    break;
                case 9:
                    {
                        InvierteFicheroTexto("copia.txt");
                    }
                    break;
                case 10:
                    {
                        SeparaPalabrasFichero("texto.txt", "separado.txt");
                    }
                    break;
            }
        }
        static void EscribeFicheroNumRandom10(string fichero)
        {
            int i;
            StreamWriter sw = new StreamWriter(fichero);
            Random r = new Random();
            for(i=0;i<10; i++)
            {
                sw.WriteLine(r.Next(0, 11));
            }
            sw.Close();
        }

        static int SumaFicheroInt10(string fichero)
        {
            int suma = 0, i;
            StreamReader sr = new StreamReader(fichero);
            for (i = 0; i < 10; i++)
            {
                suma = suma + int.Parse(sr.ReadLine());
            }
            sr.Close();
            return suma;
        }

        static void EscribeFicheroNumRandom(string fichero,int n)
        {
            int i;
            StreamWriter sw = new StreamWriter(fichero);
            Random r = new Random();
            for (i = 0; i < n; i++)
            {
                sw.WriteLine(r.Next(0, 101));
            }
            sw.Close();
        }

        static int SumaFicheroInt(string fichero)
        {
            int suma=0;
            StreamReader sr = new StreamReader(fichero);
            while (!sr.EndOfStream)
            {
                suma = suma + int.Parse(sr.ReadLine());
            }
            sr.Close();
            return suma;
        }

        static void EscribeFicheroTexto(string fichero)
        {
            string linea=" ";
            StreamWriter sw = new StreamWriter(fichero);
            while (linea != "")
            {
                linea = Console.ReadLine();
                sw.WriteLine(linea);
            }
            sw.Close();
        }

        static void LeeFicheroTexto(string fichero)
        {
            string linea;
            StreamReader sr = new StreamReader(fichero);
            while (!sr.EndOfStream)
            {
                linea = sr.ReadLine();
                Console.WriteLine(linea);
            }
        }

        static void CopiaFicheroTexto(string fichero, string copia)
        {
            string linea;
            StreamReader sr = new StreamReader(fichero);
            StreamWriter sw = new StreamWriter(copia);
            while (!sr.EndOfStream)
            {
                linea = sr.ReadLine();
                sw.WriteLine(linea);
            }
            sr.Close();
            sw.Close();
        }

        static void InvierteFicheroTexto(string fichero)
        {
            string linea;
            int i;
            List<string> l = new List<string>();
            StreamReader sr = new StreamReader(fichero);
            while (!sr.EndOfStream)
            {
                linea = sr.ReadLine();
                l.Add(linea);
            }
            sr.Close();
            StreamWriter sw = new StreamWriter(fichero);
            for (i = l.Count-1; i >= 0; i--)
            {
                if (l[i] != "")
                {
                    sw.WriteLine(l[i]);
                }
                
            }
            sw.Close();
        }

        static void InvierteLineasFichero(string fichero, string invertido)
        {
            string linea;
            StreamReader sr = new StreamReader(fichero);
            StreamWriter sw = new StreamWriter(invertido);
            while (!sr.EndOfStream)
            {
                linea = sr.ReadLine();
                sw.WriteLine(InvierteCadena(linea));
            }
            sr.Close();
            sw.Close();
        }

        static string InvierteCadena(string a)
        {
            string b = "";
            int i;
            for (i = a.Length - 1; i >= 0; i--)
            {
                b = b + a[i];
            }
            return b;
        }

        static void SeparaPalabrasFichero(string fichero, string separado)
        {
            string linea;
            string[] palabras;
            StreamReader sr = new StreamReader(fichero);
            StreamWriter sw = new StreamWriter(separado);
            while (!sr.EndOfStream)
            {
                linea = sr.ReadLine();
                palabras = linea.Split(' ');
                for(int i = 0; i < palabras.Length; i++)
                {
                    sw.WriteLine(palabras[i]);
                }


            }
            sr.Close();
            sw.Close();
        }
    }
}
