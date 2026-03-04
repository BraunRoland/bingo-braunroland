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
		private string[,] tabla;
		private List<string> jeloltSzamok;

		public BingoJatekos(string nev, string[,] tabla)
		{
			this.nev = nev;
			this.tabla = tabla;
			this.jeloltSzamok = new List<string>();
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

		public void SorsoltSzamotJelol(int szam)
		{
			for (int i = 0; i < tabla.GetLength(0); i++)
			{
				for (int j = 0; j < tabla.GetLength(1); j++)
				{
					if (tabla[i, j] == szam.ToString())
					{
						jeloltSzamok.Add();
					}
				}
			}
		}

		public string Nev { get => nev; set => nev = value; }
		public string[,] Tabla { get => tabla; set => tabla = value; }

		public List<string> JeloltSzamok { get => jeloltSzamok; set => jeloltSzamok = value; }
	}
}
