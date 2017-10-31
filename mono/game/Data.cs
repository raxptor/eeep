using System;
using System.Collections.Generic;
using System.IO;
using Putki;

namespace Game
{
	public static class Data
	{
		public static Outki.GameConfiguration Configuration = null;
		public static bool Loaded = false;

		static Mixki.SourceLoader m_loader;

		public static void LoadEeepsFromFolder(string path, Mixki.SourceLoader.LogFn logFn)
		{
			m_loader = new Mixki.SourceLoader(null, Mixki.Game.ParsersWithDeps);
			m_loader.Logger = logFn;
			string[] files = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
			foreach (string fn in files)
			{
				Dictionary<string, object> res = Eeep.Parse(File.ReadAllBytes(fn));
				if (res != null)
				{
					foreach (var kv in res)
					{
						m_loader.InsertRawObj(kv.Key, kv.Value as Dictionary<string, object>);
					}
				}
				else
				{
					logFn("Parse error on [" + fn + "]");
				}
			}
			Configuration = m_loader.Resolve<Outki.GameConfiguration>("game");
			Loaded = true;
		}
	}
}
