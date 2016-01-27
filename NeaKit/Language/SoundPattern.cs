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
	}
}
