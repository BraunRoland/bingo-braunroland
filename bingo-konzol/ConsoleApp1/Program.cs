using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	internal class Program
	{

		static BingoJatekos FajlBeolvasas(string fajlnev)
		{
			Console.WriteLine($"{fajlnev}:");
			Console.WriteLine("------------------------------");
			var sr = new StreamReader($"programozás/{fajlnev}");
			int x = 0;
			string[,] tabla = new string[5, 5];
			while (!sr.EndOfStream)
			{
				var sor = sr.ReadLine();
				var adatok = sor.Split(';');
				Console.WriteLine($"{adatok[0]} {adatok[1]} {adatok[2]} {adatok[3]} {adatok[4]}");
				for (int i = 0; i < adatok.Length; i++)
				{
					if (adatok[i] != "")
					{
						tabla[x, i] = adatok[i];
					}
				}
				x++;
			}
			Console.WriteLine($"\n{fajlnev} beolvasása kész.");
			Console.WriteLine("------------------------------");
			string nev = fajlnev.Split('.')[0];
			return new BingoJatekos(nev, tabla);
		}

		static string[] Nevek()
		{ 
			var sr = new StreamReader("programozás/nevek.text");
			var file = new StreamReader("programozás/nevek.text").ReadToEnd();
			var line = file.Split('\n');	
			string[] tomb = new string[line.Length];
			int index = 0;
			while (!sr.EndOfStream)
			{
				var sor = sr.ReadLine();
				tomb[index] = sor;
				//Console.WriteLine($"{sor}");
				index++;
			}
			return tomb;

		}

		static bool BingoEll(BingoJatekos jatekos)
		{
			string[] atlo1 = {jatekos.Tabla[0, 0], jatekos.Tabla[1,1], jatekos.Tabla[2, 2], jatekos.Tabla[3, 3], jatekos.Tabla[4, 4] };
			string[] atlo2 = { jatekos.Tabla[0, 4], jatekos.Tabla[1, 3], jatekos.Tabla[2, 2], jatekos.Tabla[3, 1], jatekos.Tabla[4, 0] };
			string[] rendezettAtlo1 = atlo1.Distinct().ToArray();
			string[] rendezettAtlo2 = atlo2.Distinct().ToArray();

			for (int i = 0; i < jatekos.Tabla.GetLength(0); i++)
			{
				string[] sor = Sor(jatekos, i);
				string[] oszlop = Oszlop(jatekos, i);
				string[] rendezettSor = sor.Distinct().ToArray();
				string[] rendezettOszlop = oszlop.Distinct().ToArray();
				//https://stackoverflow.com/questions/9673/how-do-i-remove-duplicates-from-a-c-sharp-array
				
				if (rendezettOszlop[0] == "X" && rendezettOszlop.Length == 1)
				{
					return true;
				}
				else if (rendezettSor[0] == "X" && rendezettSor.Length == 1)
				{
					return true;
				}
				else if (rendezettAtlo1[0] == "X" && rendezettAtlo1.Length == 1)
				{
					return true;
				}
				else if (rendezettAtlo2[0] == "X" && rendezettAtlo2.Length == 1)
				 {
					 return true;
				}
			}
				return false;
		}


		static string[] Sor(BingoJatekos jatekos, int x)
		{
			string[] sor = new string[5];
			for( int i = 0; i < jatekos.Tabla.GetLength(1); i++)
			{
				sor[i] = jatekos.Tabla[x, i];
			}
			return sor;
		}

		static string[] Oszlop(BingoJatekos jatekos, int y)
		{
			string[] oszlop = new string[5];
			for (int i = 0; i < jatekos.Tabla.GetLength(0); i++)
			{
				oszlop[i] = jatekos.Tabla[i, y];
			}
			return oszlop;
		}

		static void Main(string[] args)
		{
			string[] nevek = Nevek();
			BingoJatekos[] tablak = new BingoJatekos[nevek.Length];
			for (int i = 0; i < nevek.Length; i++)
			{
				tablak[i] = FajlBeolvasas(nevek[i]);
			}
			Console.WriteLine($"Játékosok száma: {tablak.Length}");
		}
	}
}
