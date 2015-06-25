using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeaKit.Geometry2D.Hex {
	public struct HexPoint {
		public int X, Y;
		public HexPoint(int x, int y) {
			this.X = x;
			this.Y = y;
		}

		public List<HexPoint> GetNeighbours(int maxx, int maxy) {
			List<HexPoint> result = new List<HexPoint>();
			if (X + 1 < maxx)
				result.Add(new HexPoint(X + 1, Y));
			if ( (X + 1 < maxx) && (Y + 1 < maxy) )
				result.Add(new HexPoint(X + 1, Y + 1));
			if (Y + 1 < maxy)
				result.Add(new HexPoint(X, Y + 1));
			if (X - 1 >= 0)
				result.Add(new HexPoint(X - 1, Y));
			if ((X - 1 >= 0) && (Y - 1 >= 0))
				result.Add(new HexPoint(X - 1, Y - 1));
			if (Y - 1 >= 0)
				result.Add(new HexPoint(X, Y - 1));
			return result;
		}

		public List<HexPoint> GetPointsInRange(int N, int maxx, int maxy) {
			List<HexPoint> result = new List<HexPoint>();

			for (int a = -N; a <= N; a++) {
				for (int b = a < 0 ? -N : a - N; b <= (a < 0 ? a + N : N); b++) {
					HexPoint p = new HexPoint(X + b, Y + a);
					if (p.X >= 0 && p.X < maxx && p.Y >= 0 && p.Y < maxy) {
						result.Add(p);
					}
				}
			}
			return result;
		}

		public bool IsOnBorder(int maxx, int maxy) {
			if (X == 0 || X + 1 == maxx || Y == 0 || Y + 1 == maxy)
				return true;
			return false;
		}
	}
}
