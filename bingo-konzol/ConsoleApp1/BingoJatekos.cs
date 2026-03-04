using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	internal class BingoJatekos
	{

		private string nev;
		private int[,] tabla;

		public BingoJatekos(string nev, int[,] tabla)
		{
			this.nev = nev;
			this.tabla = tabla;
		}

		override public string ToString()
		{
			string str = nev + "\n";
			for (int i = 0; i < tabla.GetLength(0); i++)
			{
				for (int j = 0; j < tabla.GetLength(1); j++)
				{
					str += tabla[i, j] + " ";
				}
				str += "\n";
			}
			return str;
		}

		public string Nev { get => nev; set => nev = value; }
		public int[,] Tabla { get => tabla; set => tabla = value; }
	}
}
