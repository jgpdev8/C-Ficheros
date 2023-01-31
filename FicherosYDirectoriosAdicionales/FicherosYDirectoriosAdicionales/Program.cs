using System;
using System.Collections.Generic;
using System.IO;

namespace FicherosYDirectoriosAdicionales
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            Console.WriteLine("FicherosYDirectoriosAdicionales");
            Console.WriteLine("1.- MP3Shuffle");
            Console.WriteLine("2.- OrdenaFicherosPorLineas");
            Console.WriteLine("3.- AutoBackup");
            Console.WriteLine("--------------------------");
            opcion = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcion)
            {
                case 1:
                    {
                        MP3Shuffle();
                    }
                    break;
                case 2:
                    {
                        OrdenaFicherosPorLineas();
                    }
                    break;
                case 3:
                    {
                        AutoBackup();
                    }
                    break;
            }
        }

        static void MP3Shuffle()
        {
            string[] ficheros = Directory.GetFiles(".", "*.mp3");
            List<string> lista = new List<string>();

            for (int i = 0; i < ficheros.Length; i++)
            {
                if (Path.GetExtension(ficheros[i]) == ".mp3")
                {
                    lista.Add(Path.GetFileName(ficheros[i]));
                }
            }

            DesordenaLista(lista);

            int n = 1;
            string f2;
            foreach (string f in lista)
            {
                if (char.IsDigit(f[0]) && char.IsDigit(f[1]) && f[2] == '.' && f[3] == ' ')
                {
                    f2 = n.ToString().PadLeft(2, '0') + ". " + f.Substring(4);
                    File.Move(f, f2);
                    n++;
                }
                else
                {
                    f2 = n.ToString().PadLeft(2, '0') + ". " + f;
                    File.Move(f, f2);
                    n++;
                }

            }

        }

        static void DesordenaLista(List<string> l)
        {
            Random r = new Random();
            List<string> l2 = new List<string>();

            while (l.Count > 0)
            {
                int pos = r.Next(0, l.Count);
                l2.Add(l[pos]);
                l.RemoveAt(pos);
            }
            l.AddRange(l2);
        }

        static void OrdenaFicherosPorLineas()
        {
            int i;
            int mayor = -1;
            int indice = 0;
            string[] lineas;
            string[] directorios = Directory.GetFiles(".", "*.txt");
            List<string> l = new List<string>();
            for (i = 0; i < directorios.Length; i++)
            {
                l.Add(Path.GetFileNameWithoutExtension(directorios[i]));
            }
            while (l.Count > 0)
            {
                for (i = 1; i < l.Count; i++)
                {
                    lineas = File.ReadAllLines(l[0]);
                    mayor = lineas.Length;
                    lineas = File.ReadAllLines(l[i]);
                    if (lineas.Length >= mayor)
                    {
                        mayor = lineas.Length;
                        indice = i;
                    }


                }
                Console.WriteLine(Path.GetFileNameWithoutExtension(l[indice]).PadRight(20) + mayor.ToString().PadLeft(10));
                l.RemoveAt(indice);
            }


        }

        static void AutoBackup()
        {
            int i;

            int ultnum;
            string[] directorios = Directory.GetFiles(".");
            List<string> l = new List<string>();
            for (i = 0; i < directorios.Length; i++)
            {
                if (directorios[i].Contains("survival") || directorios[i].Contains("backup_"))
                {
                    l.Add(directorios[i]);
                }
            }
            if (l.Count < 1)
            {
                Console.WriteLine("No existe ningun arhivo");
            }
            else
            {


                if (l.Contains("survival_1") && l.Count > 1)
                {
                    ultnum = int.Parse(l[l.Count - 1][l[l.Count - 1].Length - 1].ToString());
                    ultnum++;
                    if (ultnum < 9)
                    {
                        File.Copy(l[0], "backup_000" + ultnum);
                    }
                    else
                    {
                        if (ultnum < 99)
                        {
                            File.Copy(l[0], "backup_00" + ultnum);
                        }
                        else
                        {
                            if (ultnum < 999)
                            {
                                File.Copy(l[0], "backup_0" + ultnum);
                            }
                            else
                            {
                                if (ultnum < 9999)
                                {
                                    File.Copy(l[0], "backup_" + ultnum);
                                }
                                else
                                {
                                    if (ultnum == 9999)
                                    {
                                        File.Move(l[0], "backup_" + ultnum);
                                    }
                                }
                            }
                        }
                    }

                }
                else
                {
                    if (l.Contains("survival_1") && l.Count == 1)
                    {
                        File.Copy(l[0], "backup_0001");
                    }
                    else
                    {
                        ultnum = int.Parse(l[l.Count - 1][l[l.Count - 1].Length - 1].ToString());
                        ultnum++;
                        if (ultnum < 9)
                        {
                            ultnum = int.Parse(l[l.Count - 1][l[l.Count - 1].Length - 1].ToString());
                            File.Copy(l[0], "backup_000" + ultnum);
                        }
                        else
                        {
                            if (ultnum < 99)
                            {
                                ultnum = int.Parse(l[l.Count - 1][l[l.Count - 1].Length - 1].ToString() + l[l.Count - 1][l[l.Count - 1].Length - 2].ToString());
                                File.Copy(l[0], "backup_00" + ultnum);
                            }
                            else
                            {
                                if (ultnum < 999)
                                {
                                    File.Copy(l[0], "backup_0" + ultnum);
                                }
                                else
                                {
                                    if (ultnum < 9999)
                                    {
                                        File.Copy(l[0], "backup_" + ultnum);
                                    }
                                    else
                                    {
                                        if (ultnum == 9999)
                                        {
                                            File.Move(l[0], "backup_" + ultnum);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
