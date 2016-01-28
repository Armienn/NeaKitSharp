using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeaKit
{
	public class SoundPattern
	{
		public ArticulationPoint[] Points;
		public ArticulationManner[] Manners;
		public TongueShape[] Shapes;
		public bool? Rounded;
		public bool? Nasal;
		public Voice[] Voices;

		public SoundPattern(
			ArticulationPoint[] points = null,
			ArticulationManner[] manners = null,
			TongueShape[] shapes = null,
			bool? rounded = null,
			bool? nasal = null,
			Voice[] voices = null)
		{
			Points = points;
			Manners = manners;
			Shapes = shapes;
			Rounded = rounded;
			Nasal = nasal;
			Voices = voices;
		}

		public SoundPattern(ValueField valuefield)
			: this()
		{
			Load(valuefield);
		}

		public bool Fits(Sound sound)
		{
			if (Points != null)
				if (!Points.Contains(sound.Point))
					return false;

			if (Manners != null)
				if (!Manners.Contains(sound.Manner))
					return false;

			if (Shapes != null)
				if (!Shapes.Contains(sound.Shape))
					return false;

			if (Voices != null)
				if (!Voices.Contains(sound.Voice))
					return false;

			if (Rounded != null)
				if (Rounded != sound.Rounded)
					return false;

			if (Nasal != null)
				if (Nasal != sound.Nasal)
					return false;

			return true;
		}

		public void Load(String source)
		{
			Load(new ValueField(source));
		}

		public void Load(ValueField source)
		{
			if (source.Contains("Points"))
			{
				List<ArticulationPoint> points = new List<ArticulationPoint>();
				foreach (ValueField vf in source["Points"])
				{
					points.Add(NeaUtility.ParseEnum<ArticulationPoint>(vf.Value));
				}
				Points = points.ToArray();
			}

			if (source.Contains("Manners"))
			{
				List<ArticulationManner> manners = new List<ArticulationManner>();
				foreach (ValueField vf in source["Manners"])
				{
					manners.Add(NeaUtility.ParseEnum<ArticulationManner>(vf.Value));
				}
				Manners = manners.ToArray();
			}

			if (source.Contains("Shapes"))
			{
				List<TongueShape> shapes = new List<TongueShape>();
				foreach (ValueField vf in source["Shapes"])
				{
					shapes.Add(NeaUtility.ParseEnum<TongueShape>(vf.Value));
				}
				Shapes = shapes.ToArray();
			}

			if (source.Contains("Rounded"))
				Rounded = source["Rounded"].AsBoolean;

			if (source.Contains("Nasal"))
				Nasal = source["Nasal"].AsBoolean;

			if (source.Contains("Voices"))
			{
				List<Voice> voices = new List<Voice>();
				foreach (ValueField vf in source["Voices"])
				{
					voices.Add(NeaUtility.ParseEnum<Voice>(vf.Value));
				}
				Voices = voices.ToArray();
			}
		}

		public ValueField ToValueField()
		{
			ValueField result = new ValueField("SoundPattern", null);

			ValueField vf;
			if (Points != null)
			{
				vf = new ValueField("Points", null);
				foreach (ArticulationPoint si in Points)
					vf.Add(new ValueField("Point", si.ToString()));
				result.Add(vf);
			}

			if (Manners != null)
			{
				vf = new ValueField("Manners", null);
				foreach (ArticulationManner si in Manners)
					vf.Add(new ValueField("Manner", si.ToString()));
				result.Add(vf);
			}

			if (Shapes != null)
			{
				vf = new ValueField("Shapes", null);
				foreach (TongueShape si in Shapes)
					vf.Add(new ValueField("Shape", si.ToString()));
				result.Add(vf);
			}

			if (Rounded != null)
			{
				vf = new ValueField("Rounded", Rounded);
				result.Add(vf);
			}

			if (Nasal != null)
			{
				vf = new ValueField("Nasal", Nasal);
				result.Add(vf);
			}

			if (Voices != null)
			{
				vf = new ValueField("Voices", null);
				foreach (Voice si in Voices)
					vf.Add(new ValueField("Voice", si.ToString()));
				result.Add(vf);
			}

			return result;
		}
	}
}
