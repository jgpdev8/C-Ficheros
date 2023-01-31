using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace FicherosTextoAdicionales
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            Console.WriteLine("----FicherosTextoAdicionales-----");
            Console.WriteLine("1.- CuentaVocalesFichero");
            Console.WriteLine("2.- EscribeSumasCSV");
            Console.WriteLine("3.- LeeSopaLetras");
            Console.WriteLine("4.- CuatroVocales");
            Console.WriteLine("5.- EscribeArrayBi Y LeeArrayBi");
            Console.WriteLine("6.- PalabrasDistintas");
            Console.WriteLine("7.- LeeDiasDeLLuvia");
            Console.WriteLine("8.- ProcesaLogs");
            Console.WriteLine("9.- L33T SP34K");
            Console.WriteLine("10.- PalabrasDelFichero");
            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    {
                        EscribeArray(CuentaVocalesFichero("lazarillo.txt"));

                    }
                    break;
                case 2:
                    {
                        EscribeSumasCSV("notas.csv", "resultado.csv");
                    }
                    break;
                case 3:
                    {

                        EscribeArrayBiChar(LeeSopaLetras("sopa1.txt"));
                    }
                    break;
                case 4:
                    {
                        CuatroVocales("lazarillo.txt");
                    }
                    break;
                case 5:
                    {
                        int[,] array = { { 1, 2, 3 }, { 4, 5, 6 } };
                        EscribeArrayBi("ej5.txt", array);
                        ImprimeArrayBi(LeeArrayBi("ej5.txt"));

                    }
                    break;
                case 6:
                    {
                        Console.WriteLine(PalabrasDistintas("lazarillo.txt"));
                    }
                    break;
                case 7:
                    {
                        LeeLluviaCsv("dias_de_lluvia.csv");
                    }
                    break;
                case 8:
                    {
                        ProcesaLogs("NASA_access_log_Jul95.txt");
                    }
                    break;
                case 9:
                    {
                        LeetSpeak();
                    }
                    break;
                case 10:
                    {
                        PalabrasdelFichero();
                    }
                    break;
                case 11:
                    {
                        PalabraMasRepetida("quijote2.txt");
                    }
                    break;
            }
        }
        static void EscribeArray(int[] array)
        {
            int i;
            Console.Write("[");
            for (i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    Console.Write(array[i]);
                }
                else
                {
                    Console.Write(array[i] + ",");
                }

            }
            Console.Write("]");
            Console.WriteLine();
        }
        static void EscribeArrayString(string[] array)
        {
            int i;
            Console.Write("[");
            for (i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    Console.Write(array[i]);
                }
                else
                {
                    Console.Write(array[i] + ",");
                }

            }
            Console.Write("]");
            Console.WriteLine();
        }
        static void ImprimeArrayBi(int[,] array)
        {
            int i, j;
            for (i = 0; i < array.GetLength(0); i++)
            {
                for (j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static int[] CuentaVocalesFichero(string fichero)
        {
            int[] vocales = new int[5];
            string linea;
            StreamReader sr = new StreamReader(fichero);
            string a = "AÁaáÄä", e = "EÉeéËë", i = "IiÍíïÏ", o = "OoÓóöÖ", u = "UuÚúüÜ";
            while (!sr.EndOfStream)
            {
                linea = sr.ReadLine();
                for (int j = 0; j < linea.Length; j++)
                {
                    if (a.Contains(linea[j]))
                    {
                        vocales[0]++;
                    }
                    else
                    {
                        if (e.Contains(linea[j]))
                        {
                            vocales[1]++;
                        }
                        else
                        {
                            if (i.Contains(linea[j]))
                            {
                                vocales[2]++;
                            }
                            else
                            {
                                if (o.Contains(linea[j]))
                                {
                                    vocales[3]++;
                                }
                                else
                                {
                                    if (u.Contains(linea[j]))
                                    {
                                        vocales[4]++;
                                    }
                                }
                            }
                        }
                    }
                }

            }
            sr.Close();
            return vocales;
        }

        static void EscribeSumasCSV(string fichero, string resultado)
        {
            string[] notas;
            string linea;
            double media;
            StreamReader sr = new StreamReader(fichero);
            StreamWriter sw = new StreamWriter(resultado);
            while (!sr.EndOfStream)
            {
                linea = sr.ReadLine();
                linea = linea.Replace('.', ',');

                notas = linea.Split(';');
                media = (double.Parse(notas[1]) + double.Parse(notas[2]) + double.Parse(notas[3])) / 3;
                media = Math.Round(media, 2);
                if (media >= 5)
                {
                    linea = linea + ";" + media + ";" + "Aprobado";
                }
                else
                {
                    linea = linea + ";" + media + ";" + "Suspenso";
                }
                sw.WriteLine(linea);
            }
            sr.Close();
            sw.Close();
        }

        static char[,] LeeSopaLetras(string fichero)
        {
            StreamReader sr = new StreamReader(fichero);
            char[,] sopa;
            int j = 1;

            string linea = sr.ReadLine();
            int tam = linea.Length;
            string total = linea;
            bool error = false;
            int cont = 0;
            while (!sr.EndOfStream)
            {
                linea = sr.ReadLine();
                if (linea.Length != tam)
                {
                    error = true;
                }
                total = total + linea;
                j++;
            }
            sr.Close();
            if (error == false)
            {
                sopa = new char[j, tam];
                for (int i = 0; i < sopa.GetLength(0); i++)
                {
                    for (int x = 0; x < sopa.GetLength(1); x++)
                    {
                        sopa[i, x] = total[cont];
                        cont++;
                    }
                }
            }
            else
            {
                sopa = new char[0, 0];

            }

            return sopa;
        }

        static void EscribeArrayBiChar(char[,] array)
        {
            int i, j;
            for (i = 0; i < array.GetLength(0); i++)
            {
                for (j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void CuatroVocales(string fichero)
        {
            string vocales = "AaÁáÄäEeÉéËëIiÏïÍíOoöÖÓóUuÚúÜü";
            string[] palabras;
            int contador = 0;
            StreamReader sr = new StreamReader(fichero);
            StreamWriter sw = new StreamWriter("4vocales.txt");
            while (!sr.EndOfStream)
            {
                palabras = sr.ReadLine().Split(' ');
                contador = 0;
                for (int i = 0; i < palabras.Length; i++)
                {
                    contador = 0;
                    for (int j = 0; j < palabras[i].Length; j++)
                    {
                        if (vocales.Contains(palabras[i][j]))
                        {
                            contador++;
                        }
                    }
                    if (contador >= 4)
                    {
                        sw.WriteLine(palabras[i]);
                    }
                }
            }
            sr.Close();
            sw.Close();
        }

        static void EscribeArrayBi(string fichero, int[,] array)
        {
            int i, j;
            StreamWriter sw = new StreamWriter(fichero);
            sw.WriteLine(array.GetLength(0) + "," + array.GetLength(1));
            for (i = 0; i < array.GetLength(0); i++)
            {
                for (j = 0; j < array.GetLength(1); j++)
                {
                    sw.WriteLine(array[i, j]);
                }
            }
            sw.Close();
        }

        static int[,] LeeArrayBi(string fichero)
        {
            StreamReader sr = new StreamReader(fichero);
            string[] tam = sr.ReadLine().Split(',');
            int tam1, tam2, i, j;
            tam1 = int.Parse(tam[0]);
            tam2 = int.Parse(tam[1]);
            int[,] array = new int[tam1, tam2];
            for (i = 0; i < tam1; i++)
            {
                for (j = 0; j < tam2; j++)
                {
                    array[i, j] = int.Parse(sr.ReadLine());
                }
            }
            sr.Close();
            return array;
        }

        static int PalabrasDistintas(string fichero)
        {
            int i;
            string texto = "";
            string[] palabras;
            List<string> l = new List<string>();
            StreamReader sr = new StreamReader(fichero);
            while (!sr.EndOfStream)
            {
                texto = texto + sr.ReadLine() + " ";
            }
            sr.Close();
            texto = texto.ToLower();
            texto = SoloCaracter(texto);
            palabras = texto.Split(' ');

            for (i = 0; i < palabras.Length; i++)
            {
                if (!l.Contains(palabras[i]) && palabras[i].Length > 0)
                {
                    l.Add(palabras[i]);
                }
            }
            l.Sort();
            EscribeArrayString(l.ToArray());
            return l.Count;
        }
        static string SoloCaracter(string texto)
        {
            int i;
            StringBuilder resultado = new StringBuilder();
            for (i = 0; i < texto.Length; i++)
            {
                if (char.IsLetter(texto[i]) || texto[i] == ' ')
                {
                    resultado.Append(texto[i]);

                }

            }
            return resultado.ToString();
        }

        static void LeeLluviaCsv(string fichero)
        {
            int min = 0, max = 0, i, suma = 0;
            string ciudadmin, ciudadmax;
            string[] valores;
            StreamReader sr = new StreamReader(fichero);
            sr.ReadLine();//nos saltamos la primera linea
            valores = sr.ReadLine().Split(';');
            ciudadmin = valores[0];
            ciudadmax = valores[0];
            for (i = 1; i < valores.Length; i++)
            {
                min = min + int.Parse(valores[i]);
                max = max + int.Parse(valores[i]);
            }
            while (!sr.EndOfStream)
            {
                valores = sr.ReadLine().Split(';');
                suma = 0;
                for (i = 1; i < valores.Length; i++)
                {

                    suma = suma + int.Parse(valores[i]);

                }
                if (suma > max)
                {
                    max = suma;
                    ciudadmax = valores[0];
                }
                else
                {
                    if (suma < min)
                    {
                        min = suma;
                        ciudadmin = valores[0];
                    }
                }

            }
            sr.Close();
            Console.WriteLine("La ciudad menos lluviosa es " + ciudadmin + ": " + min);
            Console.WriteLine("La ciudad mas lluviosa es " + ciudadmax + ": " + max);

        }

        static void ProcesaLogs(string fichero)
        {
            Dictionary<string, int> url = new Dictionary<string, int>();
            int i = 0;
            string linea;
            string[] urls;
            int max = 0;
            string indice = "";
            string numero = "0123456789";
            StreamReader sr = new StreamReader(fichero);
            while (!sr.EndOfStream)
            {
                linea = Console.ReadLine();
                if (linea.Contains(' '))
                {
                    urls = linea.Split(' ');
                    if (urls[0].Length > 0 && numero.Contains(urls[0][0]) == false)
                    {
                        //Console.WriteLine("Leída:" + web);
                        if (url.TryAdd(urls[0], 1) == false)
                        {
                            url[urls[0]]++;
                            //Console.WriteLine("+1");
                        }
                    }
                }



            }

            for (i = 0; i < 20; i++)
            {
                max = -1;
                foreach (KeyValuePair<string, int> pareja in url)
                {
                    if (pareja.Value > max)
                    {
                        max = pareja.Value;
                        indice = pareja.Key;
                    }

                    //if (pareja.Value >= max)
                    //{
                    //    indice = pareja.Key;
                    //}

                }
                Console.WriteLine(indice + "-->" + url[indice]);
                url.Remove(indice);
            }
        }

        static void LeetSpeak()
        {
            string[] rules = { "ABEGILOSTZabegilostz", "4836!105724836!10572" };
            string fichero;
            string fichero2;
            string linea;
            string resultado;
            int i;
            Random r = new Random();
            Console.WriteLine("Dime el nombre del fichero a modificar");
            fichero = Console.ReadLine();
            Console.WriteLine("Dime el nombre del fichero nuevo");
            fichero2 = Console.ReadLine();
            StreamReader sr = new StreamReader(fichero);
            StreamWriter sw = new StreamWriter(fichero2);
            while (!sr.EndOfStream)
            {
                linea = sr.ReadLine();
                resultado = "";
                for (i = 0; i < linea.Length; i++)
                {
                    if (rules[0].Contains(linea[i]))
                    {
                        resultado = resultado + rules[1][rules[0].IndexOf(linea[i])];
                    }
                    else
                    {
                        if (char.IsLetter(linea[i]))
                        {
                            resultado = resultado + MayusMinus(linea[i]);
                        }
                        else
                        {
                            resultado = resultado + linea[i];
                        }

                    }
                }
                sw.WriteLine(resultado);
            }
            sr.Close();
            sw.Close();

        }


        static char MayusMinus(char c)
        {
            string mayus = "QWERTYUIOPASDFGHJKLÑZXCVBNM";
            string minus = "qwertyuiopasdfghjklñzxcvbnm";
            Random r = new Random();
            if (minus.Contains(c))
            {
                if (r.Next(0, 101) > 50)
                {
                    c = mayus[minus.IndexOf(c)];
                }

            }
            else
            {
                if (mayus.Contains(c))
                {
                    if (r.Next(0, 101) > 50)
                    {
                        c = minus[mayus.IndexOf(c)];
                    }
                }
            }

            return c;
        }
        static void PalabrasdelFichero()
        {
            string fichero, linea, texto = "";
            string[] palabras;
            double totales, mayusculas = 0;
            double porcentaje = 0;
            Console.WriteLine("Introduce el nombre del fichero");
            fichero = Console.ReadLine();
            StreamReader sr = new StreamReader(fichero);

            List<string> l = new List<string>();
            while (!sr.EndOfStream)
            {
                linea = sr.ReadLine();
                if (linea != "")
                {
                    for (int i = 0; i < linea.Length; i++)
                    {
                        if (!char.IsLetter(linea[i]))
                        {
                            texto = texto + " ";
                        }
                        else
                        {
                            texto = texto + linea[i];
                        }
                    }

                }
                texto = texto + " ";
            }

            sr.Close();
            palabras = texto.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            totales = palabras.Length;
            for (int i = 0; i < palabras.Length; i++)
            {
                if (EsMayuscula(palabras[i][0]))
                {
                    if (!l.Contains(palabras[i]))
                    {
                        l.Add(palabras[i]);
                    }
                    mayusculas++;
                }
            }
            EscribeListaCad(l);
            Console.WriteLine("El numero total de palabras es: " + totales);
            Console.WriteLine("El numero de palabras mayusculas es: " + mayusculas);
            porcentaje = (mayusculas / totales) * 100;
            Console.WriteLine("El porcentaje de palabras mayusculas es: " + porcentaje);
        }
        static bool EsMayuscula(char c)
        {
            string mayusculas = "QWERTYUIOPASDFGHJKLÑZXCVBNM";
            if (mayusculas.Contains(c))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void EscribeListaCad(List<string> l)
        {
            Console.Write("<");
            for (int i = 0; i < l.Count; i++)
            {
                Console.Write(l[i]);
                if (i != l.Count - 1)
                {
                    Console.Write(",");
                }
            }
            Console.WriteLine(">");
        }
        static void PalabraMasRepetida(string fichero)
        {
            Dictionary<string, int> P = new Dictionary<string, int>();
            StreamReader sr = new StreamReader(fichero);
            string linea, texto = "";
            string[] palabras;
            int i, max;
            string indice = "";
            while (!sr.EndOfStream)
            {
                linea = sr.ReadLine();
                if (linea != " ")
                {
                    for (i = 0; i < linea.Length; i++)
                    {
                        if (char.IsLetter(linea[i]) == false)
                        {
                            texto = texto + " ";
                        }
                        else
                        {
                            texto = texto + linea[i];
                        }
                    }
                }
                texto = texto + " ";

            }
            sr.Close();
            palabras = texto.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (i = 0; i < palabras.Length; i++)
            {
                if (P.TryAdd(palabras[i], 1) == false)
                {
                    P[palabras[i]]++;
                }
            }
            for (i = 0; i < 10; i++)
            {
                max = -1;
                foreach (KeyValuePair<string, int> pareja in P)
                {
                    if (pareja.Value > max)
                    {
                        max = pareja.Value;
                        indice = pareja.Key;
                    }

                    //if (pareja.Value >= max)
                    //{
                    //    indice = pareja.Key;
                    //}

                }
                Console.WriteLine(indice + "-->" + P[indice]);
                P.Remove(indice);
            }
        }
    }
}
