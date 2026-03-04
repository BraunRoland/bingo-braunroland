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
			var sr = new StreamReader($"programozás/{fajlnev}");
			int x = 0;
			string[,] tabla = new string[5, 5];
			while (!sr.EndOfStream)
			{
				var sor = sr.ReadLine();
				var adatok = sor.Split(';');
				for (int i = 0; i < adatok.Length; i++)
				{
					if (adatok[i] != "")
					{
						tabla[x, i] = adatok[i];
					}
				}
				x++;
			}
			Console.WriteLine($"{fajlnev} beolvasása kész.");
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
				Console.WriteLine($"{sor}");
				index++;
			}
			return tomb;

		}
		static void Main(string[] args)
		{
			string[] nevek = Nevek();
			BingoJatekos[] tablak = new BingoJatekos[nevek.Length];
			for (int i = 0; i < nevek.Length; i++)
			{
				tablak[i] = FajlBeolvasas(nevek[i]);
			}
		}
	}
}
