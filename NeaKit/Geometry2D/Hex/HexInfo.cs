using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeaKit.Geometry2D.Hex {
	public abstract class HexInfo {
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
			throw new NotImplementedException();
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
			throw new NotImplementedException();
		}

		public static String VerDirectionToString(VerHexDirection d, bool simple = false) {
			throw new NotImplementedException();
		}
	}

	public enum HorHexDirection { East, NorthEast, NorthWest, West, SouthWest, SouthEast }
	public enum VerHexDirection { NorthEast, North, NorthWest, SouthWest, South, SouthEast }
}
