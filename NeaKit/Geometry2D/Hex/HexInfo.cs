using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeaKit.Geometry2D.Hex {
	public abstract class HexInfo {

		#region Directions
		public static readonly Vector UnitHorE = new Vector(1, 0);
		public static readonly Vector UnitHorNE = new Vector((float)0.5, (float)0.86602540378);
		public static readonly Vector UnitHorNW = new Vector((float)-0.5, (float)0.86602540378);
		public static readonly Vector UnitHorW = new Vector(-1, 0);
		public static readonly Vector UnitHorSW = new Vector((float)-0.5, -(float)0.86602540378);
		public static readonly Vector UnitHorSE = new Vector((float)0.5, -(float)0.86602540378);

		public static readonly Vector UnitVerNE = new Vector((float)0.86602540378, (float)0.5);
		public static readonly Vector UnitVerN = new Vector(0, 1);
		public static readonly Vector UnitVerNW = new Vector(-(float)0.86602540378, (float)0.5);
		public static readonly Vector UnitVerSW = new Vector(-(float)0.86602540378, (float)-0.5);
		public static readonly Vector UnitVerS = new Vector(0, -1);
		public static readonly Vector UnitVerSE = new Vector((float)0.86602540378, (float)-0.5);

		public static Vector GetUnityVector(HorHexDirection dir) {
			switch (dir) {
				case HorHexDirection.East:
					return UnitHorE;
				case HorHexDirection.NorthEast:
					return UnitHorNE;
				case HorHexDirection.NorthWest:
					return UnitHorNW;
				case HorHexDirection.West:
					return UnitHorW;
				case HorHexDirection.SouthWest:
					return UnitHorSW;
				case HorHexDirection.SouthEast:
					return UnitHorSE;
				default:
					throw new ArgumentException("Wrong enum");
			}
		}

		public static Vector GetUnityVector(VerHexDirection dir) {
			switch (dir) {
				case VerHexDirection.NorthEast:
					return UnitVerNE;
				case VerHexDirection.North:
					return UnitVerN;
				case VerHexDirection.NorthWest:
					return UnitVerNW;
				case VerHexDirection.SouthWest:
					return UnitVerSW;
				case VerHexDirection.South:
					return UnitVerS;
				case VerHexDirection.SouthEast:
					return UnitVerSE;
				default:
					throw new ArgumentException("Wrong enum");
			}
		}

		public static HorHexDirection HorDirectionFromAngle(double angle) {
			while (angle > Math.PI)
				angle -= Math.PI * 2;
			while (angle <= -Math.PI)
				angle += Math.PI * 2;
			if (angle > Math.PI * (5.0 / 6.0))
				return HorHexDirection.West;
			if (angle > Math.PI * (3.0 / 6.0))
				return HorHexDirection.NorthWest;
			if (angle > Math.PI * (1.0 / 6.0))
				return HorHexDirection.NorthEast;
			if (angle > -Math.PI * (1.0 / 6.0))
				return HorHexDirection.East;
			if (angle > -Math.PI * (3.0 / 6.0))
				return HorHexDirection.SouthEast;
			if (angle > -Math.PI * (5.0 / 6.0))
				return HorHexDirection.SouthWest;
			return HorHexDirection.West;
		}

		public static VerHexDirection VerDirectionFromAngle(double angle) {
			while (angle > Math.PI)
				angle -= Math.PI * 2;
			while (angle <= -Math.PI)
				angle += Math.PI * 2;
			if (angle > Math.PI * (2.0 / 3.0))
				return VerHexDirection.NorthWest;
			if (angle > Math.PI * (1.0 / 3.0))
				return VerHexDirection.North;
			if (angle > 0 )
				return VerHexDirection.NorthEast;
			if (angle > -Math.PI * (1.0 / 3.0))
				return VerHexDirection.SouthEast;
			if (angle > -Math.PI * (2.0 / 3.0))
				return VerHexDirection.South;
			if (angle > -Math.PI )
				return VerHexDirection.SouthWest;
			return VerHexDirection.NorthWest;
		}

		public static void AdjacentPosition(HorHexDirection dir, ref HexPoint position) {
			switch (dir) {
				case HorHexDirection.East:
					position.X++;
					break;
				case HorHexDirection.NorthEast:
					position.X++;
					position.Y++;
					break;
				case HorHexDirection.NorthWest:
					position.Y++;
					break;
				case HorHexDirection.West:
					position.X--;
					break;
				case HorHexDirection.SouthWest:
					position.X--;
					position.Y--;
					break;
				case HorHexDirection.SouthEast:
					position.Y--;
					break;
			}
		}

		public static void AdjacentPosition(HorHexDirection dir, ref int x, ref int y) {
			switch (dir) {
				case HorHexDirection.East:
					x++;
					break;
				case HorHexDirection.NorthEast:
					x++;
					y++;
					break;
				case HorHexDirection.NorthWest:
					y++;
					break;
				case HorHexDirection.West:
					x--;
					break;
				case HorHexDirection.SouthWest:
					x--;
					y--;
					break;
				case HorHexDirection.SouthEast:
					y--;
					break;
			}
		}

		public static void AdjacentPosition(VerHexDirection dir, ref HexPoint position) {
			switch (dir) {
				case VerHexDirection.NorthEast:
					position.X++;
					position.Y++;
					break;
				case VerHexDirection.North:
					position.Y++;
					break;
				case VerHexDirection.NorthWest:
					position.X--;
					break;
				case VerHexDirection.SouthWest:
					position.X--;
					position.Y--;
					break;
				case VerHexDirection.South:
					position.Y--;
					break;
				case VerHexDirection.SouthEast:
					position.X++;
					break;
			}
		}

		public static void AdjacentPosition(VerHexDirection dir, ref int x, ref int y) {
			switch (dir) {
				case VerHexDirection.NorthEast:
					x++;
					y++;
					break;
				case VerHexDirection.North:
					y++;
					break;
				case VerHexDirection.NorthWest:
					x--;
					break;
				case VerHexDirection.SouthWest:
					x--;
					y--;
					break;
				case VerHexDirection.South:
					y--;
					break;
				case VerHexDirection.SouthEast:
					x++;
					break;
			}
		}

		public static HorHexDirection HorDirectionFromString(String d) {
			switch (d.ToUpper()) {
				case "E":
				case "EAST":
					return HorHexDirection.East;
				case "NE":
				case "NORTHEAST":
					return HorHexDirection.NorthEast;
				case "NW":
				case "NORTHWEST":
					return HorHexDirection.NorthWest;
				case "W":
				case "WEST":
					return HorHexDirection.West;
				case "SW":
				case "SOUTHWEST":
					return HorHexDirection.SouthWest;
				case "SE":
				case "SOUTHEAST":
					return HorHexDirection.SouthEast;
				default:
					throw new FormatException("No such direction.");
			}
		}

		public static String HorDirectionToString(HorHexDirection d, bool simple = false) {
			switch (d) {
				case HorHexDirection.East:
					return simple ? "E" : "East";
				case HorHexDirection.NorthEast:
					return simple ? "NE" : "NorthEast";
				case HorHexDirection.NorthWest:
					return simple ? "NW" : "NorthWest";
				case HorHexDirection.West:
					return simple ? "W" : "West";
				case HorHexDirection.SouthWest:
					return simple ? "SW" : "SouthWest";
				case HorHexDirection.SouthEast:
					return simple ? "SE" : "SouthEast";
				default:
					throw new FormatException("No such direction.");
			}
		}

		public static VerHexDirection VerDirectionFromString(String d) {
			switch (d.ToUpper()) {
				case "NE":
				case "NORTHEAST":
					return VerHexDirection.NorthEast;
				case "N":
				case "NORTH":
					return VerHexDirection.North;
				case "NW":
				case "NORTHWEST":
					return VerHexDirection.NorthWest;
				case "SW":
				case "SOUTHWEST":
					return VerHexDirection.SouthWest;
				case "S":
				case "SOUTH":
					return VerHexDirection.South;
				case "SE":
				case "SOUTHEAST":
					return VerHexDirection.SouthEast;
				default:
					throw new FormatException("No such direction.");
			}
		}

		public static String VerDirectionToString(VerHexDirection d, bool simple = false) {
			switch (d) {
				case VerHexDirection.NorthEast:
					return simple ? "N" : "NorthEast";
				case VerHexDirection.North:
					return simple ? "N" : "North";
				case VerHexDirection.NorthWest:
					return simple ? "NW" : "NorthWest";
				case VerHexDirection.SouthWest:
					return simple ? "SW" : "SouthWest";
				case VerHexDirection.South:
					return simple ? "S" : "South";
				case VerHexDirection.SouthEast:
					return simple ? "SE" : "SouthEast";
				default:
					throw new FormatException("No such direction.");
			}
		}

		#endregion Directions

		private static readonly double sqrt3 = Math.Sqrt(3);

		/// <summary>
		/// Calculates the HexPoint that an x,y position corresponds to. Assumes that the
		/// coordinate system starts in the upper left corner of the rectangle that can be
		/// drawn around the upper left hexagon in the grid. The x position increases to the
		/// right, and the y position increases downwards.
		/// </summary>
		/// <param name="sidelength">The length of each side of the hexagons</param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static HexPoint HorHexPointFromCoordinates(double sidelength, double x, double y) {
			HexPoint point = new HexPoint(0, 0);
			//first move y within the bounds of the first line of hexagons
			while (y < 0) {
				y += 1.5 * sidelength;
				x += sqrt3 / 2.0 * sidelength;
				point.Y--;
			}
			while (y > 1.5 * sidelength) {
				y -= 1.5 * sidelength;
				x -= sqrt3 / 2.0 * sidelength;
				point.Y++;
			}
			//move x within the bounds of the first hexagon
			while (x < 0) {
				x += sqrt3 * sidelength;
				point.X--;
			}
			while (x > sqrt3 * sidelength) {
				x -= sqrt3 * sidelength;
				point.X++;
			}
			//check whether it belongs to one of the hexagons above
			if (y < 0.5 * sidelength) {
				if ( y > (1.0 / sqrt3) * (x > sqrt3 / 2.0 * sidelength ? -(x - sqrt3 * sidelength) : x ) ) {
					point.Y--;
					if(x > sqrt3 / 2.0 * sidelength)
						point.X++;
				}
			}
			return point;
		}
	}

	public enum HorHexDirection { East, NorthEast, NorthWest, West, SouthWest, SouthEast }
	public enum VerHexDirection { NorthEast, North, NorthWest, SouthWest, South, SouthEast }
}
