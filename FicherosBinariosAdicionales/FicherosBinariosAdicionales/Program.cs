using System;
using System.Collections.Generic;
using System.IO;

namespace FicherosBinariosAdicionales
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            Console.WriteLine("FicherosBinariosAdicionales");
            Console.WriteLine("1.- ImprimeJornada");
            Console.WriteLine("2.- LeeColorinesConsola");
            Console.WriteLine("3.- LeeJuegoEnRaya");
            Console.WriteLine("4.- ASCIIart");
            Console.WriteLine("5.- PintaBandera");
            Console.WriteLine("6.- EstadisticasNBA");
            Console.WriteLine("7.- NuevoFormatoBanco");
            
            Console.WriteLine("--------------------------");
            opcion = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcion)
            {
                case 1:
                    {
                        ImprimeJornada("jornada3");
                    }
                    break;
                case 2:
                    {
                        LeeColorinesConsola("colorines4.color");
                    }
                    break;
                case 3:
                    {
                        LeeJuegoEnRaya("4x4.ttt");
                    }
                    break;
                case 4:
                    {
                        ASCIIart("eiffel.bin");
                    }
                    break;
                case 5:
                    {
                        PintaBandera("deuverybig.flag");
                    }
                    break;
                case 6:
                    {
                        EstadisticasNBA();
                    }
                    break;
                case 7:
                    {
                        NuevoFormatoBanco("datosantiguos.txt", "datosnuevos2.bin");
                    }
                    break;
               
            }
        }
        static void ImprimeJornada(string fichero)
        {
            string equipo1, equipo2;
            int goles1, goles2;
            FileStream f = new FileStream(fichero,FileMode.Open);
            BinaryReader br = new BinaryReader(f);
            while (f.Position < f.Length)
            {
                equipo1 = br.ReadString();
                equipo2 = br.ReadString();
                goles1 = br.ReadInt32();
                goles2 = br.ReadInt32();
                Console.WriteLine(equipo1 + " " + goles1 + " - " + goles2 + " " + equipo2);
            }
            br.Close();
            f.Close();
        }
        
        static void LeeColorinesConsola(string fichero)
        {
            FileStream f = new FileStream(fichero,FileMode.Open);
            BinaryReader br = new BinaryReader(f);
            int color;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    color = br.ReadInt32();
                    Console.BackgroundColor = (ConsoleColor)color;
                    Console.Write("  ");

                }
                Console.BackgroundColor = default;
                Console.WriteLine();
            }
            


            br.Close();
            f.Close();
        }

        static void LeeJuegoEnRaya(string fichero)
        {
            FileStream fs = new FileStream(fichero, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            int i;
            int size = br.ReadInt32();
            int marc;
            string[] raya = new string[size*size];
            for (i = 0; i < raya.Length; i++)
            {
                marc = br.ReadInt32();
                if(marc == 0)
                {
                    raya[i] = ". ";
                }
                else
                {
                    if(marc == 1)
                    {
                        raya[i] = "X ";
                    }
                    else
                    {
                        raya[i] = "O ";
                    }
                }
            }
            br.Close();
            fs.Close();
            for (i = 0; i < raya.Length; i++)
            {
                if ((i+1) % size == 0)
                {
                    Console.Write(raya[i]);
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(raya[i]);
                }
            }
        }

        static void PintaBandera(string fichero)
        {
            int filas;
            int columnas;
            int i, color;
            int[] bandera;
            FileStream fs = new FileStream(fichero, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            filas = br.ReadInt32();
            columnas = br.ReadInt32();
            bandera = new int [filas * columnas];
            for(i=0;i<bandera.Length;i++)
            {
                color = br.ReadInt32();
                switch (color)
                {
                    case 1:
                        Console.BackgroundColor = (ConsoleColor)ConsoleColor.Red;

                        break;
                    case 2:

                        Console.BackgroundColor = (ConsoleColor)ConsoleColor.Yellow;

                        break;
                    case 3:

                        Console.BackgroundColor = (ConsoleColor)ConsoleColor.Blue;

                        break;
                    case 4:

                        Console.BackgroundColor = (ConsoleColor)ConsoleColor.Green;

                        break;
                    case 5:

                        Console.BackgroundColor = (ConsoleColor)ConsoleColor.White;

                        break;
                    case 6:

                        Console.BackgroundColor = (ConsoleColor)ConsoleColor.Black;

                        break;
                }
                Console.Write(" ");
                if ((i+1) % columnas == 0)
                {
                    Console.WriteLine();
                }
                Console.BackgroundColor = default;
            }
            br.Close();
            fs.Close();
        }

        static void ASCIIart(string fichero)
        {
            FileStream fs = new FileStream(fichero, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            while (fs.Position < fs.Length)
            {
                Console.SetCursorPosition(br.ReadInt32(), br.ReadInt32());
                Console.Write(br.ReadChar());
            }
            
        }

        static void EstadisticasNBA()
        {
            int i;
            string[] directorios = Directory.GetFiles(Directory.GetCurrentDirectory());
            List<string> stat = new List<string>();
            string result = "";
            
            for (i = 0; i < directorios.Length; i++)
            {
                if (Path.GetExtension(directorios[i])==".stat")
                {
                    stat.Add(directorios[i]);
                }
            }
            
            for (i = 0; i < stat.Count; i++)
            {
                result = result + LeeEstadisticaNBA(stat[i]); 
            }
            string[] puntos = result.Split('_');
            List<double> ordenar = new List<double>();
            for (i = 1; i < puntos.Length; i=i+2)
            {
                ordenar.Add(double.Parse(puntos[i]));
            }
            ordenar.Sort();
            ordenar.Reverse();
            result = "";
            int j=1;
            for (i = 0; i < ordenar.Count; i++)
            {
                for (j = 1; j < puntos.Length; j++)
                {
                    if (ordenar[i].ToString() == puntos[j])
                    {
                        string puntofinal = PuntuacionBonita(ordenar[i]);
                        Console.WriteLine(puntos[j - 1].PadRight(30) + puntofinal.PadLeft(10));
                    }
                }
            }

            
           
            
            
        }
        static string PuntuacionBonita(double nota)
        {
            string resultado = nota.ToString();

            if (resultado.Length == 1 || resultado.Length == 2)
            {
                resultado = resultado + ",00";
            }
            else
            {
                
                if (resultado.Length == 4 || resultado.Length==3)
                {
                    resultado = resultado + "0";
                }
                else
                {
                    if (resultado.Length > 4)
                    {
                        resultado = Math.Round(nota, 2).ToString();
                    }
                }
            }

            return resultado;
        }
        static void EscribeListaString(List<string> l)
        {
            int i;
            for (i = 0; i < l.Count; i++)
            {
                Console.WriteLine(l[i]);
            }
        }

        static string LeeEstadisticaNBA(string fichero)
        {
            FileStream fs = new FileStream(fichero, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            int tam=0;
            double media = 0;
            string result = Path.GetFileNameWithoutExtension(fichero);
            while (fs.Position < fs.Length)
            {
                media = media + br.ReadInt32();
                tam++;
            }
            br.Close();
            fs.Close();
            media = media / tam;
            result = result +"_"+ media+"_";
            return result;
        }

        static void NuevoFormatoBanco(string fichero1,string fichero2)
        {
            StreamReader sr = new StreamReader(fichero1);
            string linea;
            string[] campos;
            FileStream fs = new FileStream(fichero2,FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            sr.ReadLine();
            sr.ReadLine();
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                linea = sr.ReadLine();
                if (linea.Contains("|"))
                {
                    campos = linea.Split('|');
                    string cuenta1 = campos[1].Trim().Replace("-", "");
                    string cuenta2 = campos[2].Trim().Replace("-", "");
                    
                    string[] fecha = campos[3].Split("/");
                    int dia = int.Parse(fecha[0]);
                    int mes = int.Parse(fecha[1]);
                    int anno = int.Parse(fecha[2]);
                    decimal pesetas = decimal.Parse(campos[4]);
                    decimal euros = pesetas / 166.386m;
                    //(decimal)166.386

                    bw.Write(cuenta1);
                    bw.Write(cuenta2);
                    bw.Write(dia);
                    bw.Write(mes);
                    bw.Write(anno);
                    bw.Write(euros);
                }
            }

            sr.Close();
        }

        
        static void DesordenaLista(List<string> l)
        {
            Random r = new Random();
            List<string>l2  = new List<string>();

            while (l.Count > 0)
            {
                int pos = r.Next(0,l.Count);
                l2.Add(l[pos]);
                l.RemoveAt(pos);
            }
            l.AddRange(l2);
        }

        
    }
}
