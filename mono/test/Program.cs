using System;

namespace test
{
	class Program
	{
		static void Main(string[] args)
		{
			Game.Data.LoadEeepsFromFolder("../../../../data", delegate(string txt) {
				Console.WriteLine("LOADER:" + txt);
			});
			Console.WriteLine("Loaded game version [" + Game.Data.Configuration.Version + "]");
		}
	}
}
