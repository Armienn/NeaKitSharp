using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeaKit.Geometry2D {
	public struct Vector {
		public double Angle {
			get {
				double length = Math.Sqrt(X * X + Y * Y);
				double angle = Math.Acos(X / length);
				if (X == 0)
					angle = Math.PI * 0.5;
				if (X < 0)
					angle = Math.PI - angle;
				if (Y < 0)
					angle = -angle;
				return angle;
			}
		}
		public double Magnitude {
			get {
				return Math.Sqrt(X * X + Y * Y);
			}
		}
		public float X, Y;
		public Vector(float x, float y) {
			this.X = x;
			this.Y = y;
		}

		public Vector Add(Vector b) {
			return new Vector(this.X + b.X, this.Y + b.Y);
		}

		public Vector Subtract(Vector b) {
			return new Vector(this.X - b.X, this.Y - b.Y);
		}

		public Vector Multiply(float k) {
			return new Vector(this.X * k, this.Y * k);
		}

		public Vector Translate(double anglemod, double lengthmod) {
			double length = Math.Sqrt(X * X + Y * Y);
			double angle = Math.Acos(X / length);
			if (X == 0)
				angle = Math.PI * 0.5;
			if (X < 0)
				angle = Math.PI - angle;
			if (Y < 0)
				angle = -angle;
			angle += anglemod;
			while (angle < Math.PI) {
				angle += 2 * Math.PI;
			}
			while (angle > Math.PI) {
				angle -= 2 * Math.PI;
			}
			return new Vector((float)(length * lengthmod * Math.Cos(angle)), (float)(length * lengthmod * Math.Sin(angle)));
		}
	}
}
