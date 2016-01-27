using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeaKit
{
	public class Syllable
	{
		public List<Sound> OnsetCluster = new List<Sound>();
		public List<Sound> NucleusCluster = new List<Sound>();
		public List<Sound> CodaCluster = new List<Sound>();

		public Syllable(Language language, Random random = null)
		{
			if (random == null) random = new Random();
			int iterations = 0; //for checking that we don't end up in an eternal loop
			//first choose a random pattern concerning nucleus
			SyllablePattern pattern = language.Patterns[random.Next(language.Patterns.Count)];
			while (pattern.NucleusPatterns == null)
			{
				pattern = language.Patterns[random.Next(language.Patterns.Count)];
			}
			//choose sounds that fit the pattern
			SoundInformation info;
			foreach (SoundPattern sp in pattern.NucleusPatterns)
			{
				info = language.Sounds[random.Next(language.Sounds.Count)];
				iterations = 0;
				while (!sp.Fits(info.Sound))
				{
					iterations++;
					if (iterations > 1000)
						throw new Exception("Too many loops! Check your patterns.");
					info = language.Sounds[random.Next(language.Sounds.Count)];
				}
				NucleusCluster.Add(info.Sound);
			}

			//now the onset
			if (pattern.OnsetPatterns == null)
			{
				for (iterations = 0; iterations < 4 && pattern.OnsetPatterns == null; iterations++)
				{
					pattern = language.Patterns[random.Next(language.Patterns.Count)];
				}
			}
			if (pattern.OnsetPatterns != null)
			{
				//choose sounds that fit the pattern
				foreach (SoundPattern sp in pattern.OnsetPatterns)
				{
					info = language.Sounds[random.Next(language.Sounds.Count)];
					iterations = 0;
					while (!sp.Fits(info.Sound))
					{
						iterations++;
						if (iterations > 1000)
							throw new Exception("Too many loops! Check your patterns.");
						info = language.Sounds[random.Next(language.Sounds.Count)];
					}
					OnsetCluster.Add(info.Sound);
				}
			}

			//and finally the coda
			if (pattern.CodaPatterns == null)
			{
				for (iterations = 0; iterations < 4 && pattern.CodaPatterns == null; iterations++)
				{
					pattern = language.Patterns[random.Next(language.Patterns.Count)];
				}
			}
			if (pattern.CodaPatterns != null)
			{
				//choose sounds that fit the pattern
				foreach (SoundPattern sp in pattern.CodaPatterns)
				{
					info = language.Sounds[random.Next(language.Sounds.Count)];
					iterations = 0;
					while (!sp.Fits(info.Sound))
					{
						iterations++;
						if (iterations > 1000)
							throw new Exception("Too many loops! Check your patterns.");
						info = language.Sounds[random.Next(language.Sounds.Count)];
					}
					CodaCluster.Add(info.Sound);
				}
			}
		}

		public static Syllable Random(Language language, Random random = null)
		{
			return new Syllable(language, random);
		}

		public bool IsValid(Language language)
		{
			return IsOnsetValid(language) && IsNucleusValid(language) && IsCodaValid(language);
		}

		public bool IsOnsetValid(Language language)
		{
			return true;
		}

		public bool IsNucleusValid(Language language)
		{
			return true;
		}

		public bool IsCodaValid(Language language)
		{
			return true;
		}
	}
}
