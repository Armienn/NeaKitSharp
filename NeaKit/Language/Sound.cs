using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeaKit
{
	/// <summary>
	/// A simple implementation of sound representation (compared to the Language/Sound one).
	/// Initiation is assumed to be pulmonic and airstream is assumed to be egressive.
	/// </summary>
	public struct Sound : IEquatable<Sound>
	{
		public ArticulationPoint Point;
		public ArticulationManner Manner;
		public TongueShape Shape;
		public bool Rounded;
		public bool Nasal;
		public Voice Voice;

		public Sound(
			ArticulationPoint point = ArticulationPoint.DorsalPalatal,
			ArticulationManner manner = ArticulationManner.Open,
			TongueShape shape = TongueShape.Central,
			bool rounded = false,
			bool nasal = false,
			Voice voice = Voice.Modal)
		{
			Point = point;
			Manner = manner;
			Shape = shape;
			Rounded = rounded;
			Nasal = nasal;
			Voice = voice;
		}

		public static Sound GetRandom()
		{
			Sound sound = new Sound();
			Random random = new Random();
			do
			{
				Array enums = Enum.GetValues(typeof(ArticulationPoint));
				sound.Point = (ArticulationPoint)enums.GetValue(random.Next(enums.Length));
				enums = Enum.GetValues(typeof(ArticulationManner));
				sound.Manner = (ArticulationManner)enums.GetValue(random.Next(enums.Length));
				enums = Enum.GetValues(typeof(TongueShape));
				sound.Shape = (TongueShape)enums.GetValue(random.Next(enums.Length));
				enums = Enum.GetValues(typeof(Voice));
				sound.Voice = (Voice)enums.GetValue(random.Next(enums.Length));
				sound.Rounded = random.Next(2) == 0;
				sound.Nasal = random.Next(2) == 0;
			}
			while (!sound.IsValid);
			sound.Standardise();
			return sound;
		}

		public bool IsValid
		{
			get
			{
				if (Rounded)
				{
					switch (Point)
					{
						case ArticulationPoint.LabialLabial:
						case ArticulationPoint.LabialDental:
						case ArticulationPoint.CoronalLabial:
							return false;
					}
				}

				if (Voice == Voice.Voiceless)
				{
					//this isn't really invalid, just very unusual
					switch (Manner)
					{
						case ArticulationManner.Close:
						case ArticulationManner.NearClose:
						case ArticulationManner.CloseMid:
						case ArticulationManner.Mid:
						case ArticulationManner.OpenMid:
						case ArticulationManner.NearOpen:
						case ArticulationManner.Open:
							return false;
					}
				}

				if (Voice == Voice.Aspirated)
				{
					switch (Manner)
					{
						case ArticulationManner.Stop:
							break;
						default:
							return false;
					}
				}

				if (Manner == ArticulationManner.Closed && !Nasal) return false;

				switch (Point)
				{
					case ArticulationPoint.LabialLabial:
						switch (Manner)
						{
							case ArticulationManner.Closed:
							case ArticulationManner.Stop:
							case ArticulationManner.Flap:
							case ArticulationManner.Trill:
							case ArticulationManner.Fricative:
							case ArticulationManner.Approximant:
								return true;
							default:
								return false;
						}
					case ArticulationPoint.LabialDental:
						switch (Manner)
						{
							case ArticulationManner.Closed:
							case ArticulationManner.Stop:
							case ArticulationManner.Flap:
							case ArticulationManner.Trill:
							case ArticulationManner.Fricative:
							case ArticulationManner.Approximant:
								return true;
							default:
								return false;
						}
					case ArticulationPoint.CoronalLabial:
						switch (Manner)
						{
							case ArticulationManner.Closed:
							case ArticulationManner.Stop:
							case ArticulationManner.Flap:
							case ArticulationManner.Trill:
							case ArticulationManner.Fricative:
							case ArticulationManner.Approximant:
								return true;
							default:
								return false;
						}
					case ArticulationPoint.CoronalDental:
						switch (Manner)
						{
							case ArticulationManner.Closed:
							case ArticulationManner.Stop:
							case ArticulationManner.Flap:
							case ArticulationManner.Trill:
							case ArticulationManner.Fricative:
							case ArticulationManner.Approximant:
								return true;
							default:
								return false;
						}
					case ArticulationPoint.CoronalAlveolar:
						switch (Manner)
						{
							case ArticulationManner.Closed:
							case ArticulationManner.Stop:
							case ArticulationManner.Flap:
							case ArticulationManner.Trill:
							case ArticulationManner.Fricative:
							case ArticulationManner.Approximant:
								return true;
							default:
								return false;
						}
					case ArticulationPoint.CoronalPostAlveolar:
						switch (Manner)
						{
							case ArticulationManner.Closed:
							case ArticulationManner.Stop:
							case ArticulationManner.Flap:
							case ArticulationManner.Trill:
							case ArticulationManner.Fricative:
							case ArticulationManner.Approximant:
								return true;
							default:
								return false;
						}
					case ArticulationPoint.CoronalRetroflex:
						switch (Manner)
						{
							case ArticulationManner.Closed:
							case ArticulationManner.Stop:
							case ArticulationManner.Flap:
							case ArticulationManner.Trill:
							case ArticulationManner.Fricative:
							case ArticulationManner.Approximant:
								return true;
							default:
								return false;
						}
					case ArticulationPoint.DorsalPostAlveolar:
						switch (Manner)
						{
							case ArticulationManner.Closed:
							case ArticulationManner.Stop:
							case ArticulationManner.Fricative:
							case ArticulationManner.Approximant:
								return true;
							default:
								return false;
						}
					case ArticulationPoint.DorsalPalatal:
						switch (Manner)
						{
							case ArticulationManner.Closed:
							case ArticulationManner.Stop:
							case ArticulationManner.Fricative:
							case ArticulationManner.Approximant:
							case ArticulationManner.Close:
							case ArticulationManner.NearClose:
							case ArticulationManner.CloseMid:
							case ArticulationManner.Mid:
							case ArticulationManner.OpenMid:
							case ArticulationManner.NearOpen:
							case ArticulationManner.Open:
								return true;
							default:
								return false;
						}
					case ArticulationPoint.DorsalPalVel:
						switch (Manner)
						{
							case ArticulationManner.Closed:
							case ArticulationManner.Stop:
							case ArticulationManner.Fricative:
							case ArticulationManner.Approximant:
							case ArticulationManner.Close:
							case ArticulationManner.NearClose:
							case ArticulationManner.CloseMid:
							case ArticulationManner.Mid:
							case ArticulationManner.OpenMid:
							case ArticulationManner.NearOpen:
							case ArticulationManner.Open:
								return true;
							default:
								return false;
						}
					case ArticulationPoint.DorsalVelar:
						switch (Manner)
						{
							case ArticulationManner.Closed:
							case ArticulationManner.Stop:
							case ArticulationManner.Fricative:
							case ArticulationManner.Approximant:
							case ArticulationManner.Close:
							case ArticulationManner.NearClose:
							case ArticulationManner.CloseMid:
							case ArticulationManner.Mid:
							case ArticulationManner.OpenMid:
							case ArticulationManner.NearOpen:
							case ArticulationManner.Open:
								return true;
							default:
								return false;
						}
					case ArticulationPoint.DorsalVelUlu:
						switch (Manner)
						{
							case ArticulationManner.Closed:
							case ArticulationManner.Stop:
							case ArticulationManner.Fricative:
							case ArticulationManner.Approximant:
							case ArticulationManner.Close:
							case ArticulationManner.NearClose:
							case ArticulationManner.CloseMid:
							case ArticulationManner.Mid:
							case ArticulationManner.OpenMid:
							case ArticulationManner.NearOpen:
							case ArticulationManner.Open:
								return true;
							default:
								return false;
						}
					case ArticulationPoint.DorsalUvular:
						switch (Manner)
						{
							case ArticulationManner.Closed:
							case ArticulationManner.Stop:
							case ArticulationManner.Flap:
							case ArticulationManner.Trill:
							case ArticulationManner.Fricative:
							case ArticulationManner.Approximant:
							case ArticulationManner.Close:
							case ArticulationManner.NearClose:
							case ArticulationManner.CloseMid:
							case ArticulationManner.Mid:
							case ArticulationManner.OpenMid:
							case ArticulationManner.NearOpen:
							case ArticulationManner.Open:
								return true;
							default:
								return false;
						}
					case ArticulationPoint.RadicalPharyngeal:
						switch (Manner)
						{
							case ArticulationManner.Stop:
							case ArticulationManner.Flap:
							case ArticulationManner.Trill:
							case ArticulationManner.Fricative:
							case ArticulationManner.Approximant:
								return true;
							default:
								return false;
						}
					case ArticulationPoint.RadicalEpiglottal:
						switch (Manner)
						{
							case ArticulationManner.Stop:
							case ArticulationManner.Flap:
							case ArticulationManner.Trill:
							case ArticulationManner.Fricative:
							case ArticulationManner.Approximant:
								return true;
							default:
								return false;
						}
					case ArticulationPoint.Glottal:
						switch (Manner)
						{
							case ArticulationManner.Stop:
							case ArticulationManner.Fricative:
								return true;
							default:
								return false;
						}
					default:
						throw new Exception("Weird");
				}
			}
		}

		public void Standardise()
		{
			if (Shape == TongueShape.Sibilant)
			{
				switch (Manner)
				{
					case ArticulationManner.Closed:
					case ArticulationManner.Stop:
					case ArticulationManner.Flap:
					case ArticulationManner.Trill:
					case ArticulationManner.Close:
					case ArticulationManner.NearClose:
					case ArticulationManner.CloseMid:
					case ArticulationManner.Mid:
					case ArticulationManner.OpenMid:
					case ArticulationManner.NearOpen:
					case ArticulationManner.Open:
						Shape = TongueShape.Central;
						break;
				}
				switch (Point)
				{
					case ArticulationPoint.LabialLabial:
					case ArticulationPoint.LabialDental:
					case ArticulationPoint.CoronalLabial:
					case ArticulationPoint.DorsalPalatal:
					case ArticulationPoint.DorsalPalVel:
					case ArticulationPoint.DorsalVelar:
					case ArticulationPoint.DorsalVelUlu:
					case ArticulationPoint.DorsalUvular:
					case ArticulationPoint.RadicalPharyngeal:
					case ArticulationPoint.RadicalEpiglottal:
					case ArticulationPoint.Glottal:
						Shape = TongueShape.Central;
						break;
				}
			}

			if (Shape == TongueShape.Lateral)
			{
				switch (Manner)
				{
					case ArticulationManner.Closed:
					case ArticulationManner.Stop:
					case ArticulationManner.Trill:
					case ArticulationManner.Close:
					case ArticulationManner.NearClose:
					case ArticulationManner.CloseMid:
					case ArticulationManner.Mid:
					case ArticulationManner.OpenMid:
					case ArticulationManner.NearOpen:
					case ArticulationManner.Open:
						Shape = TongueShape.Central;
						break;
				}
				switch (Point)
				{
					case ArticulationPoint.LabialLabial:
					case ArticulationPoint.LabialDental:
					case ArticulationPoint.RadicalPharyngeal:
					case ArticulationPoint.RadicalEpiglottal:
					case ArticulationPoint.Glottal:
						Shape = TongueShape.Central;
						break;
				}
			}

			if (Point == ArticulationPoint.DorsalPalVel)
			{
				switch (Manner)
				{
					case ArticulationManner.Closed:
					case ArticulationManner.Stop:
					case ArticulationManner.Flap:
					case ArticulationManner.Trill:
					case ArticulationManner.Fricative:
					case ArticulationManner.Approximant:
						Point = ArticulationPoint.DorsalPalatal;
						break;
				}
			}

			if (Point == ArticulationPoint.DorsalVelUlu)
			{
				switch (Manner)
				{
					case ArticulationManner.Closed:
					case ArticulationManner.Stop:
					case ArticulationManner.Flap:
					case ArticulationManner.Trill:
					case ArticulationManner.Fricative:
					case ArticulationManner.Approximant:
						Point = ArticulationPoint.DorsalUvular;
						break;
				}
			}
		}

		public int Encode()
		{
			int enc = (int)Point;
			enc += 16 * (int)Manner;
			enc += 16 * 13 * (int)Shape;
			enc += 16 * 13 * 3 * (int)Voice;
			enc += 16 * 13 * 3 * 5 * (Rounded ? 1 : 0);
			enc += 16 * 13 * 3 * 5 * 2 * (Nasal ? 1 : 0);
			return enc;
		}

		public static Sound Decode(int enc)
		{
			Sound sound = new Sound();
			int res = enc / (16 * 13 * 3 * 5 * 2);
			sound.Nasal = res == 1;
			enc -= res * (16 * 13 * 3 * 5 * 2);
			res = enc / (16 * 13 * 3 * 5);
			sound.Rounded = res == 1;
			enc -= res * (16 * 13 * 3 * 5);
			res = enc / (16 * 13 * 3);
			sound.Voice = (Voice)res;
			enc -= res * (16 * 13 * 3);
			res = enc / (16 * 13);
			sound.Shape = (TongueShape)res;
			enc -= res * (16 * 13);
			res = enc / 16;
			sound.Manner = (ArticulationManner)res;
			enc -= res * 16;
			sound.Point = (ArticulationPoint)enc;
			return sound;
		}

		public string Save()
		{
			return ToValueField().Save();
		}

		public ValueField ToValueField()
		{
			return new ValueField("Sound",
				new ValueField("Point", Point.ToString()),
				new ValueField("Manner", Manner.ToString()),
				new ValueField("Shape", Shape.ToString()),
				new ValueField("Rounded", Rounded.ToString()),
				new ValueField("Nasal", Nasal.ToString()),
				new ValueField("Voice", Voice.ToString()));
		}

		public void Load(string source)
		{
			Load(new ValueField(source));
		}

		public void Load(ValueField vf)
		{
			Point = NeaUtility.ParseEnum<ArticulationPoint>(vf["Point"].Value);
			Manner = NeaUtility.ParseEnum<ArticulationManner>(vf["Manner"].Value);
			Shape = NeaUtility.ParseEnum<TongueShape>(vf["Shape"].Value);
			Rounded = NeaReader.ParseBoolean(vf["Rounded"].Value);
			Nasal = NeaReader.ParseBoolean(vf["Nasal"].Value);
			Voice = NeaUtility.ParseEnum<Voice>(vf["Voice"].Value);
		}

		public bool Equals(Sound other)
		{
			return Point == other.Point && Manner == other.Manner && Shape == other.Shape && Rounded == other.Rounded && Nasal == other.Nasal && Voice == other.Voice;
		}
	}

	public enum ArticulationPoint
	{
		LabialLabial, LabialDental,
		CoronalLabial, CoronalDental, CoronalAlveolar, CoronalPostAlveolar, CoronalRetroflex,
		DorsalPostAlveolar, DorsalPalatal, DorsalPalVel, DorsalVelar, DorsalVelUlu, DorsalUvular, //Front, NearFront, Central, NearBack, Back
		RadicalPharyngeal, RadicalEpiglottal, Glottal
	}

	public enum ArticulationManner
	{
		Closed, Stop, Flap, Trill, Fricative, Approximant,
		Close, NearClose, CloseMid, Mid, OpenMid, NearOpen, Open
	}

	public enum TongueShape
	{
		Central, Lateral, Sibilant
	}

	public enum Voice
	{
		Aspirated, Voiceless, Breathy, Modal, Creaky //the first one is only for stops
	}
}
