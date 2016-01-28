using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeaKit
{
	public class SyllablePattern
	{
		public List<SoundPattern> OnsetPatterns;
		public List<SoundPattern> NucleusPatterns;
		public List<SoundPattern> CodaPatterns;

		public void Load(String source)
		{
			Load(new ValueField(source));
		}

		public void Load(ValueField source)
		{
			List<SoundPattern> patterns;
			if (source.Contains("OnsetPatterns"))
			{
				patterns = new List<SoundPattern>();
				foreach (ValueField vf in source["OnsetPatterns"])
				{

					patterns.Add(new SoundPattern(vf));
				}
				OnsetPatterns = patterns;
			}

			if (source.Contains("NucleusPatterns"))
			{
				patterns = new List<SoundPattern>();
				foreach (ValueField vf in source["NucleusPatterns"])
				{

					patterns.Add(new SoundPattern(vf));
				}
				NucleusPatterns = patterns;
			}

			if (source.Contains("CodaPatterns"))
			{
				patterns = new List<SoundPattern>();
				foreach (ValueField vf in source["CodaPatterns"])
				{

					patterns.Add(new SoundPattern(vf));
				}
				CodaPatterns = patterns;
			}
		}

		public ValueField ToValueField()
		{
			ValueField result = new ValueField("SyllablePattern", null);

			ValueField vf;
			if (OnsetPatterns != null)
			{
				vf = new ValueField("OnsetPatterns", null);
				foreach (SoundPattern sp in OnsetPatterns)
					vf.Add(sp.ToValueField());
				result.Add(vf);
			}

			if (NucleusPatterns != null)
			{
				vf = new ValueField("NucleusPatterns", null);
				foreach (SoundPattern sp in NucleusPatterns)
					vf.Add(sp.ToValueField());
				result.Add(vf);
			}

			if (CodaPatterns != null)
			{
				vf = new ValueField("CodaPatterns", null);
				foreach (SoundPattern sp in CodaPatterns)
					vf.Add(sp.ToValueField());
				result.Add(vf);
			}

			return result;
		}
	}
}
