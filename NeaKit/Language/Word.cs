using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeaKit
{
	public class Word
	{
		public List<Syllable> Syllables = new List<Syllable>();

		public Word(Language language, int syllables = 0, Random random = null)
		{
			if (random == null) random = new Random();
			if (syllables == 0)
				syllables = random.Next(3) + 1;
			for (int i = 0; i < syllables; i++)
			{
				Syllables.Add(new Syllable(language, random));
			}
		}

		public static Word Random(Language language, int syllables = 0, Random random = null)
		{
			return new Word(language, syllables, random);
		}
	}
}
