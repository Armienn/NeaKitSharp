using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeaKit
{
	public class Syllable
	{
		public List<Sound> OnsetCluster;
		public List<Sound> NucleusCluster;
		public List<Sound> CodaCluster;

		public bool IsValid
		{
			get
			{
				return IsOnsetValid & IsNucleusValid & IsCodaValid;
			}
		}

		public bool IsOnsetValid
		{
			get
			{
				return true;
			}
		}

		public bool IsNucleusValid
		{
			get
			{
				return true;
			}
		}

		public bool IsCodaValid
		{
			get
			{
				return true;
			}
		}
	}
}
