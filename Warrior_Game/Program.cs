namespace Warrior_Game
{
	internal class Program
	{
		public static int heroSecim = 0;
		public static int pcSecim = 0;
		public static string name;
		public static double pcCan;
		public static double heroCan;
		//Öncelikle Savaşçı Özelliklerimizi Tanımlayalım
		//1- Uzak Dövüşçü 2- Assassin 3-Tank 4-Büyücü
		public static double[,] dovusculer =
			{
				{80, 270, 15 },
				{90,250,10 },
				{65,300,13 },
				{100,260,17 }
			};
		public static string[] isimler = { "Uzak Dövüşçü", "Assasin", "Tank", "Büyücü" };

		public static Random rnd = new Random();

		public static void SavasciSecim()
		{
			Console.Write("Lütfen Adınızı Giriniz: ");
			name = Console.ReadLine();
			Console.WriteLine($"Hoşgeldiniz {name}");
			Console.Clear();
			Console.Write($"Lütfen bir karakter seçiniz\n1-Uzak Dövüşçü\t2-Assasin\t3-Tank\t4-Büyücü\n");
			heroSecim = int.Parse(Console.ReadLine())-1;
			pcSecim = rnd.Next(0, 4);
			//string karakter = pcSecim == 0 ? "Uzak Dövüşçü" : pcSecim == 1 ? "Assasin" : pcSecim == 2 ? "Tank" : "Büyücü";
			//Console.WriteLine($"PC {karakter} karakterini seçti.");
			Console.WriteLine($"{isimler[heroSecim]} karakterini seçtiniz.");
			Console.WriteLine($"Bilgisayar {isimler[pcSecim]} karakterini seçti.");
			pcCan = dovusculer[pcSecim, 1];
			heroCan = dovusculer[heroSecim, 1];

			
		}

		public static bool Iskala(int karakterNo)
		{
			int olasilik = rnd.Next(0, 101);
			if (olasilik > dovusculer[karakterNo,2] )
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public static bool OyunBittiMi(double can, double pcCan)
		{
			if (can < 0 || pcCan < 0 )
			{
				if (can <= 0)
				{
					Console.WriteLine("Kaybettiniz");
					
				}
				else
				{
					Console.WriteLine("Kazandınız");
				}
				return true;
				
			}
			else
			{
				return false;
			}
		}

		static void Main(string[] args)
		{

			SavasciSecim();

			while (pcCan > 0 && heroCan > 0)
			{
				
				
					Console.WriteLine("Saldırı sırası sizde. Saldırmak için bir tuşa basın");
					Console.ReadKey();
					Console.Clear();
					if (Iskala(heroSecim) == false)
					{
						pcCan = pcCan - dovusculer[heroSecim, 0];
					}
					else
					{
						Console.WriteLine("Iskaladınız. :(");
					}
					Console.WriteLine($"Bilgisayarın Kalan Canı: {pcCan}, Kalan Canınız: {heroCan}");
					Console.WriteLine("Saldırı sırası bilgisayarda. Devam etmek için bir tuşa basın");
					Console.ReadKey();
					Console.Clear();
					if (Iskala(pcSecim) == false)
					{
						heroCan = heroCan - dovusculer[pcSecim, 0];
					}
					else
					{
						Console.WriteLine("Pc Iskaladı. :)");
					}
					Console.WriteLine($"Bilgisayarın Kalan Canı: {pcCan}, Kalan Canınız: {heroCan}");
				
				
			}
			
		}
	}
}