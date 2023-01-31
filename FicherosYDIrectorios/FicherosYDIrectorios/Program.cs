using System;
using System.Collections.Generic;
using System.IO;

namespace FicherosYDIrectorios
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            Console.WriteLine("FicherosyDirectorios");
            Console.WriteLine("1.- CuantosFicheros");
            Console.WriteLine("2.- CuantosFicherosPro");
            Console.WriteLine("3.- CreaBackup");
            Console.WriteLine("4.- RenombraMasivo");
            Console.WriteLine("5.- CuentaLineasFicheros");
            Console.WriteLine("6.- FicheroMasGrande");
            Console.WriteLine("7- ClasificaFicheros");
            Console.WriteLine("--------------------");
            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    {
                        Console.WriteLine(CuantosFicheros(".txt"));
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine(CuantosFicherosPro("C:\\Patata", ".txt")); 
                    }
                    break;
                case 3:
                    {
                        CreaBackup("C:\\Patata\\patata.txt");
                    }
                    break;
                case 4:
                    {
                        RenombraMasivo(".bak", ".txt");
                    }
                    break;
                case 5:
                    {
                        Console.WriteLine(CuentaLineasFicheros(".txt")); 
                    }
                    break;
                case 6:
                    {
                        Console.WriteLine(FicheroMasGrande());
                    }
                    break;
                case 7:
                    {
                        ClasificaFicheros();
                    }
                    break;
            }
        }

        static int CuantosFicheros(string extension)
        {
            int contador = 0;
            string miCarpeta = Directory.GetCurrentDirectory();
            string[] ficheros = Directory.GetFiles(miCarpeta);
            for(int i = 0; i < ficheros.Length; i++)
            {
                if (ficheros[i].Contains(extension))
                {
                    contador++;
                }
            }
            return contador;
        }

        static int CuantosFicherosPro(string directorio,string extension)
        {
            int contador=0;
            if (Directory.Exists(directorio))
            {
                string[] ficheros = Directory.GetFiles(directorio);
                for (int i = 0; i < ficheros.Length; i++)
                {
                    if (ficheros[i].Contains(extension))
                    {
                        contador++;
                    }
                }
                
            }
            else
            {
                Console.WriteLine("El directorio no existe");
            }
            return contador;
        }

        static void CreaBackup(string fichero)
        {
            string bak = fichero+".bak";
            if (File.Exists(fichero))
            {
                while (File.Exists(bak))
                {

                    bak = bak + ".bak";
                }
                File.Copy(fichero, bak);

            }
            else
            {
                Console.WriteLine("El fichero no existe");
            }
        }

        static void RenombraMasivo(string extensionactual,string extensionnueva)
        {
            string[] ficheros = Directory.GetFiles(Directory.GetCurrentDirectory());
            int i;
            string nombre;
            for (i = 0; i < ficheros.Length; i++)
            {
                if (ficheros[i].Contains(extensionactual))
                {
                    nombre = ficheros[i].Replace(extensionactual, extensionnueva);
                    File.Move(ficheros[i], nombre);
                }
            }
        }

        static int CuentaLineasFicheros(string extension)
        {
            string[] ficheros = Directory.GetFiles(Directory.GetCurrentDirectory());
            int i;
            int tam=0;
            for (i = 0; i < ficheros.Length; i++)
            {
                if (ficheros[i].Contains(extension))
                {
                    string[] lineas = File.ReadAllLines(ficheros[i]);
                    tam = tam + lineas.Length;
                }
            }
            return tam;
        }

        static string FicheroMasGrande()
        {
            string[] ficheros = Directory.GetFiles(Directory.GetCurrentDirectory());
            int i;
            long mayor;
            string name;
            FileInfo fa = new FileInfo(ficheros[0]);
            mayor = fa.Length;
            name = fa.Name;
            for (i = 0; i < ficheros.Length; i++)
            {
                fa = new FileInfo(ficheros[i]);
                if (fa.Length > mayor)
                {
                    mayor = fa.Length;
                    name = fa.Name;
                }
            }
            return name;
        }

        static void ClasificaFicheros()
        {
            
            
            int i, j;
            Dictionary<string, int> extensiones = new Dictionary<string, int>();
            string[] ficheros = Directory.GetFiles(Directory.GetCurrentDirectory());
            for (i = 0; i < ficheros.Length; i++)
            {
                if(extensiones.TryAdd(Path.GetExtension(ficheros[i]), 1) == false)
                {
                    extensiones[Path.GetExtension(ficheros[i])]++;
                }
                
            }
            foreach(KeyValuePair<string,int> pareja in extensiones)
            {
                Console.WriteLine(pareja.Key +"-->"+pareja.Value);
            }
        }
    }
}
