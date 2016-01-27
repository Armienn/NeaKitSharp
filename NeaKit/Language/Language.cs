using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeaKit
{
	public class Language
	{
		//list of sounds and rules and shizzle
		public List<SoundInformation> Sounds = new List<SoundInformation>();
		public List<SyllablePattern> Patterns = new List<SyllablePattern>();

		public string GetRepresentation(Word word)
		{
			string result = "";
			foreach (Syllable syl in word.Syllables)
			{
				foreach (Sound s in syl.OnsetCluster)
				{
					foreach (SoundInformation info in Sounds)
					{
						if (info.Sound.Equals(s))
						{
							result += info.Representation;
							break;
						}
					}
				}
				foreach (Sound s in syl.NucleusCluster)
				{
					foreach (SoundInformation info in Sounds)
					{
						if (info.Sound.Equals(s))
						{
							result += info.Representation;
							break;
						}
					}
				}
				foreach (Sound s in syl.CodaCluster)
				{
					foreach (SoundInformation info in Sounds)
					{
						if (info.Sound.Equals(s))
						{
							result += info.Representation;
							break;
						}
					}
				}
			}
			return result;
		}

		public Word RandomWord(int syllables = 0)
		{
			return Word.Random(this, syllables, new Random());
		}

		public static Language GetDansk()
		{
			Language language = new Language();
			SoundInformation info;
			Sound sound = new Sound();
			//M
			sound.Manner = ArticulationManner.Closed;
			sound.Point = ArticulationPoint.LabialLabial;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Modal;
			sound.Nasal = true;
			sound.Rounded = false;
			info = new SoundInformation();
			info.Sound = sound;
			info.Representation = "m";
			language.Sounds.Add(info);
			//N
			sound.Manner = ArticulationManner.Closed;
			sound.Point = ArticulationPoint.CoronalAlveolar;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Modal;
			sound.Nasal = true;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "n";
			language.Sounds.Add(info);
			//NG
			sound.Manner = ArticulationManner.Closed;
			sound.Point = ArticulationPoint.DorsalVelar;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Modal;
			sound.Nasal = true;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "ŋ";
			language.Sounds.Add(info);
			//P
			sound.Manner = ArticulationManner.Stop;
			sound.Point = ArticulationPoint.LabialLabial;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Aspirated;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "p";
			language.Sounds.Add(info);
			//B
			sound.Manner = ArticulationManner.Stop;
			sound.Point = ArticulationPoint.LabialLabial;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Voiceless;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "b";
			language.Sounds.Add(info);
			//T
			sound.Manner = ArticulationManner.Stop;
			sound.Point = ArticulationPoint.CoronalAlveolar;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Aspirated;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "t";
			language.Sounds.Add(info);
			//D
			sound.Manner = ArticulationManner.Stop;
			sound.Point = ArticulationPoint.CoronalAlveolar;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Voiceless;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "d";
			language.Sounds.Add(info);
			//K
			sound.Manner = ArticulationManner.Stop;
			sound.Point = ArticulationPoint.DorsalVelar;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Aspirated;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "k";
			language.Sounds.Add(info);
			//G
			sound.Manner = ArticulationManner.Stop;
			sound.Point = ArticulationPoint.DorsalVelar;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Voiceless;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "g";
			language.Sounds.Add(info);
			//F
			sound.Manner = ArticulationManner.Fricative;
			sound.Point = ArticulationPoint.LabialDental;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Voiceless;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "f";
			language.Sounds.Add(info);
			//V
			sound.Manner = ArticulationManner.Approximant;
			sound.Point = ArticulationPoint.LabialDental;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Modal;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "v";
			language.Sounds.Add(info);
			//S
			sound.Manner = ArticulationManner.Fricative;
			sound.Point = ArticulationPoint.CoronalAlveolar;
			sound.Shape = TongueShape.Sibilant;
			sound.Voice = Voice.Voiceless;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "s";
			language.Sounds.Add(info);
			//DH
			sound.Manner = ArticulationManner.Approximant;
			sound.Point = ArticulationPoint.CoronalAlveolar;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Modal;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "ð";
			language.Sounds.Add(info);
			//J
			sound.Manner = ArticulationManner.Approximant;
			sound.Point = ArticulationPoint.DorsalPalatal;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Modal;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "j";
			language.Sounds.Add(info);
			//L
			sound.Manner = ArticulationManner.Approximant;
			sound.Point = ArticulationPoint.CoronalAlveolar;
			sound.Shape = TongueShape.Lateral;
			sound.Voice = Voice.Voiceless;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "l";
			language.Sounds.Add(info);
			//R
			sound.Manner = ArticulationManner.Approximant;
			sound.Point = ArticulationPoint.DorsalUvular;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Modal;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "r";
			language.Sounds.Add(info);
			//H
			sound.Manner = ArticulationManner.Fricative;
			sound.Point = ArticulationPoint.Glottal;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Voiceless;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "h";
			language.Sounds.Add(info);

			//I
			sound.Manner = ArticulationManner.Close;
			sound.Point = ArticulationPoint.DorsalPalatal;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Modal;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "i";
			language.Sounds.Add(info);
			//Y
			sound.Manner = ArticulationManner.Close;
			sound.Point = ArticulationPoint.DorsalPalVel;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Modal;
			sound.Nasal = false;
			sound.Rounded = true;
			info.Sound = sound;
			info.Representation = "y";
			language.Sounds.Add(info);
			//E
			sound.Manner = ArticulationManner.CloseMid;
			sound.Point = ArticulationPoint.DorsalPalatal;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Modal;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "e";
			language.Sounds.Add(info);
			//Ø
			sound.Manner = ArticulationManner.CloseMid;
			sound.Point = ArticulationPoint.DorsalPalVel;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Modal;
			sound.Nasal = false;
			sound.Rounded = true;
			info.Sound = sound;
			info.Representation = "ø";
			language.Sounds.Add(info);
			//Æ
			sound.Manner = ArticulationManner.OpenMid;
			sound.Point = ArticulationPoint.DorsalPalatal;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Modal;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "æ";
			language.Sounds.Add(info);
			//schwa
			sound.Manner = ArticulationManner.Mid;
			sound.Point = ArticulationPoint.DorsalVelar;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Modal;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "ə";
			language.Sounds.Add(info);
			//U
			sound.Manner = ArticulationManner.Close;
			sound.Point = ArticulationPoint.DorsalUvular;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Modal;
			sound.Nasal = false;
			sound.Rounded = true;
			info.Sound = sound;
			info.Representation = "u";
			language.Sounds.Add(info);
			//O
			sound.Manner = ArticulationManner.CloseMid;
			sound.Point = ArticulationPoint.DorsalUvular;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Modal;
			sound.Nasal = false;
			sound.Rounded = true;
			info.Sound = sound;
			info.Representation = "o";
			language.Sounds.Add(info);
			//Å
			sound.Manner = ArticulationManner.CloseMid;
			sound.Point = ArticulationPoint.DorsalVelUlu;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Modal;
			sound.Nasal = false;
			sound.Rounded = true;
			info.Sound = sound;
			info.Representation = "å";
			language.Sounds.Add(info);
			//A abe
			sound.Manner = ArticulationManner.NearOpen;
			sound.Point = ArticulationPoint.DorsalPalatal;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Modal;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "a";
			language.Sounds.Add(info);
			//A haj
			sound.Manner = ArticulationManner.NearOpen;
			sound.Point = ArticulationPoint.DorsalVelUlu;
			sound.Shape = TongueShape.Central;
			sound.Voice = Voice.Modal;
			sound.Nasal = false;
			sound.Rounded = false;
			info.Sound = sound;
			info.Representation = "ɒ";
			language.Sounds.Add(info);

			// rules
			SyllablePattern pattern;
			// all vowels can be nucleus, regardless of onset or coda
			pattern = new SyllablePattern();
			pattern.NucleusPatterns = new List<SoundPattern>();
			pattern.NucleusPatterns.Add(new SoundPattern(
				manners: new ArticulationManner[]{
					ArticulationManner.Close,
					ArticulationManner.NearClose,
					ArticulationManner.CloseMid,
					ArticulationManner.Mid,
					ArticulationManner.OpenMid,
					ArticulationManner.NearOpen,
					ArticulationManner.Open
				}));
			language.Patterns.Add(pattern);
			/*/ all consonants can be onset, regardless of nucleus or coda //no, dh and ng can't...
			pattern = new SyllablePattern();
			pattern.OnsetPatterns = new List<SoundPattern>();
			pattern.OnsetPatterns.Add(new SoundPattern(
				manners: new ArticulationManner[]{
					ArticulationManner.Closed,
					ArticulationManner.Stop,
					ArticulationManner.Fricative,
					ArticulationManner.Approximant
				}));
			language.Patterns.Add(pattern);*/
			// all stops and fricatives can be onset
			pattern = new SyllablePattern();
			pattern.OnsetPatterns = new List<SoundPattern>();
			pattern.OnsetPatterns.Add(new SoundPattern(
				manners: new ArticulationManner[]{
					ArticulationManner.Stop,
					ArticulationManner.Fricative
				}));
			language.Patterns.Add(pattern);
			// n and m can be onset
			pattern = new SyllablePattern();
			pattern.OnsetPatterns = new List<SoundPattern>();
			pattern.OnsetPatterns.Add(new SoundPattern(
				manners: new ArticulationManner[]{
					ArticulationManner.Closed
				},
				points: new ArticulationPoint[]{
					ArticulationPoint.LabialLabial,
					ArticulationPoint.CoronalAlveolar
				}));
			// v, j and r can be onset
			pattern = new SyllablePattern();
			pattern.OnsetPatterns = new List<SoundPattern>();
			pattern.OnsetPatterns.Add(new SoundPattern(
				manners: new ArticulationManner[]{
					ArticulationManner.Approximant
				},
				points: new ArticulationPoint[]{
					ArticulationPoint.LabialDental,
					ArticulationPoint.DorsalPalatal,
					ArticulationPoint.DorsalUvular
				}));
			language.Patterns.Add(pattern);
			// v, j and r can be onset
			pattern = new SyllablePattern();
			pattern.OnsetPatterns = new List<SoundPattern>();
			pattern.OnsetPatterns.Add(new SoundPattern(
				manners: new ArticulationManner[]{
					ArticulationManner.Approximant
				},
				points: new ArticulationPoint[]{
					ArticulationPoint.LabialDental,
					ArticulationPoint.DorsalPalatal,
					ArticulationPoint.DorsalUvular
				}));
			language.Patterns.Add(pattern);
			// l can be onset
			pattern = new SyllablePattern();
			pattern.OnsetPatterns = new List<SoundPattern>();
			pattern.OnsetPatterns.Add(new SoundPattern(
				manners: new ArticulationManner[]{
					ArticulationManner.Approximant
				},
				points: new ArticulationPoint[]{
					ArticulationPoint.CoronalAlveolar
				},
				shapes: new TongueShape[]{
					TongueShape.Lateral
				}));
			language.Patterns.Add(pattern);
			// all consonants can be coda, regardless of nucleus or onset
			pattern = new SyllablePattern();
			pattern.CodaPatterns = new List<SoundPattern>();
			pattern.CodaPatterns.Add(new SoundPattern(
				manners: new ArticulationManner[]{
					ArticulationManner.Closed,
					ArticulationManner.Stop,
					ArticulationManner.Fricative,
					ArticulationManner.Approximant
				}));
			language.Patterns.Add(pattern);
			// onset can have clusters of s+(unaspirated)stops, regardless of nucleus or coda
			pattern = new SyllablePattern();
			pattern.OnsetPatterns = new List<SoundPattern>();
			pattern.OnsetPatterns.Add(new SoundPattern(
				manners: new ArticulationManner[]{
					ArticulationManner.Fricative
				},
				shapes: new TongueShape[]{
					TongueShape.Sibilant
				}));
			pattern.OnsetPatterns.Add(new SoundPattern(
				manners: new ArticulationManner[]{
					ArticulationManner.Stop,
				},
				voices: new Voice[]{
					Voice.Voiceless
				}));
			language.Patterns.Add(pattern);
			// onset can have clusters of s+(unaspirated)stops+r, regardless of nucleus or coda
			pattern = new SyllablePattern();
			pattern.OnsetPatterns = new List<SoundPattern>();
			pattern.OnsetPatterns.Add(new SoundPattern(
				manners: new ArticulationManner[]{
					ArticulationManner.Fricative
				},
				shapes: new TongueShape[]{
					TongueShape.Sibilant
				}));
			pattern.OnsetPatterns.Add(new SoundPattern(
				manners: new ArticulationManner[]{
					ArticulationManner.Stop,
				},
				voices: new Voice[]{
					Voice.Voiceless
				}));
			pattern.OnsetPatterns.Add(new SoundPattern(
				manners: new ArticulationManner[]{
					ArticulationManner.Approximant
				},
				points: new ArticulationPoint[]{
					ArticulationPoint.DorsalUvular
				}));
			language.Patterns.Add(pattern);

			return language;
		}
	}

	public struct SoundInformation
	{
		public Sound Sound;
		public String Representation;
	}
}
