using System;
using System.Collections.Generic;
using System.IO;

namespace FicherosBinarios
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            Console.WriteLine("----FicherosBinarios----");
            Console.WriteLine("1.- EscribeFichero1_100");
            Console.WriteLine("2.- LeeFicheroInt100");
            Console.WriteLine("3.- EscribeFicheroIntAleatorio");
            Console.WriteLine("4.- EscribeFicheroIntAleatorioPro");
            Console.WriteLine("5.- LeeFicheroInt");
            Console.WriteLine("6.- SumaFicheroInt");
            Console.WriteLine("7.- LeeFicheroIntLista");
            Console.WriteLine("8.- EscribeFicheroIntLista");
            Console.WriteLine("9.- OrdenaFicheroInt");
            Console.WriteLine("------------------------");
            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    {
                        EscribeFichero1_100("1_100.bin");
                    }
                    break;
                case 2:
                    {
                        LeeFicheroInt100("1_100.bin");
                    }
                    break;
                case 3:
                    {
                        EscribeFicheroIntAleatorio("Aleatorio.bin", 10);
                    }
                    break;
                case 4:
                    {
                        EscribeFicheroIntAleatorioPro("AleatorioPro.bin", 10, 10, 20);
                    }
                    break;
                case 5:
                    {
                        LeeFicheroInt("AleatorioPro.bin");
                    }
                    break;
                case 6:
                    {
                        Console.WriteLine(SumaFicheroInt("1_100.bin"));
                    }
                    break;
                case 7:
                    {
                        List<int> l = LeeFicheroIntLista("1_100.bin");
                        for(int i = 0; i < l.Count; i++)
                        {
                            Console.WriteLine(l[i]);
                        }
                    }
                    break;
                case 8:
                    {
                        List<int> l = LeeFicheroIntLista("1_100.bin");
                        EscribeFicheroIntLista("ej8.bin",l);
                    }
                    break;
                case 9:
                    {
                        LeeFicheroInt("AleatorioPro.bin");
                        OrdenaFicheroInt("AleatorioPro.bin");
                        LeeFicheroInt("AleatorioPro.bin");
                    }
                    break;
                case 10:
                    {
                        EscribeFicheroIntAleatorioPro("ej10.bin", 10, -10, 10);
                        LeeFicheroInt("ej10.bin");
                        SeparaFicheroInt("ej10.bin");
                        LeeFicheroInt("ej10.binnegativo");
                        LeeFicheroInt("ej10.binpositivo");
                    }
                    break;
                case 11:
                    {
                        EscribeFicheroIntAleatorio("ej11.bin",10);
                        LeeFicheroInt("ej11.bin");
                        InvierteFicheroInt("ej11.bin");
                        LeeFicheroInt("ej11.bin");
                    }
                    break;
            }

        }
        
        static void EscribeFichero1_100(string fichero)
        {
            int i;
            FileStream fs = new FileStream(fichero, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            for (i = 1; i <= 100; i++)
            {
                bw.Write(i);
            }
            bw.Close();
            fs.Close();
        }

        static void LeeFicheroInt100(string fichero)
        {
            int i, n;
            FileStream fs = new FileStream(fichero, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            for (i = 0; i < 100; i++)
            {
                n = br.ReadInt32();
                Console.WriteLine(n);
            }
        }

        static void EscribeFicheroIntAleatorio(string fichero,int n)
        {
            Random r = new Random();
            int i;
            FileStream fs = new FileStream(fichero, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            for (i = 1; i <= n; i++)
            {
                bw.Write(r.Next(0,101));
            }
            bw.Close();
            fs.Close();

        }

        static void EscribeFicheroIntAleatorioPro(string fichero,int num,int min,int max)
        {
            Random r = new Random();
            int i;
            FileStream fs = new FileStream(fichero, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            for (i = 1; i <= num; i++)
            {
                bw.Write(r.Next(min, max+1));
            }
            bw.Close();
            fs.Close();
        }

        static void LeeFicheroInt(string fichero)
        {
            int i, n;
            FileStream fs = new FileStream(fichero, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            while (fs.Position < fs.Length)
            {
                n = br.ReadInt32();
                Console.Write(n+" ");
            }
            Console.WriteLine();
            br.Close();
            fs.Close();
        }

        static int SumaFicheroInt(string fichero)
        {
            int i, n, suma=0;
            FileStream fs = new FileStream(fichero, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            while (fs.Position < fs.Length)
            {
                n = br.ReadInt32();
                suma = suma + n;
            }
            br.Close();
            fs.Close();
            return suma;
        }

        static List<int> LeeFicheroIntLista(string fichero)
        {
            List<int> l = new List<int>();
            int n;
            FileStream fs = new FileStream(fichero, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            while (fs.Position < fs.Length)
            {
                n = br.ReadInt32();
                l.Add(n);
            }
            br.Close();
            fs.Close();
            return l;
        }

        static void EscribeFicheroIntLista(string fichero, List<int> l)
        {
            int i;
            FileStream fs = new FileStream(fichero, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            for (i = 0; i < l.Count; i++)
            {
                bw.Write(l[i]);
            }
            bw.Close();
            fs.Close();

        }

        static void OrdenaFicheroInt(string fichero)
        {
            int i;
            List<int> l = LeeFicheroIntLista(fichero);
            l.Sort();
            FileStream fs = new FileStream(fichero, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            
            
            for (i = 0; i < l.Count; i++)
            {
                bw.Write(l[i]);
            }
            bw.Close();
            fs.Close();
        }

        static void SeparaFicheroInt(string fichero)
        {
            int n;
            FileStream fs = new FileStream(fichero, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            FileStream fsp = new FileStream(fichero+"positivo", FileMode.Create);
            BinaryWriter bwp = new BinaryWriter(fsp);
            FileStream fsn = new FileStream(fichero+"negativo", FileMode.Create);
            BinaryWriter bwn = new BinaryWriter(fsn);

            while (fs.Position < fs.Length)
            {
                n = br.ReadInt32();
                if (n < 0)
                {
                    bwn.Write(n);
                }
                else
                {
                    bwp.Write(n);
                }
            }
            br.Close();
            fs.Close();
            bwp.Close();
            fsp.Close();
            bwn.Close();
            fsn.Close();

        }

        static void InvierteFicheroInt(string fichero)
        {
            List<int> l = LeeFicheroIntLista(fichero);
            l.Reverse();
            FileStream fs = new FileStream(fichero, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            for(int i = 0; i < l.Count; i++)
            {
                bw.Write(l[i]);
            }
            bw.Close();
            fs.Close();

        }
        
    }
}
