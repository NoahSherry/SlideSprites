using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment03
{
	public class SlidingSprite : Sprite
	{
		private float velocity = 0;

		public int TargetX { get; internal set; }
		public int TargetY { get; internal set; }
		public int Velocity { get; internal set; }

		float k = .2f;
		public float K
		{
			get { return k; }
			set { k = value; }
		}

		float c = .2f;
		public float C
		{
			get { return c; }
			set { c = value; }
		}

		public SlidingSprite(Bitmap image) : base(image)
		{

		}

		public override void Paint(Graphics g)
		{
			g.DrawImage(Image, 0, 0);
		}

		public override void Act()
		{

			#region Check Horizontal Movement
			if (X + Velocity < TargetX)
			{
				X += Velocity;
			}
			else if(X - Velocity > TargetX)
			{
				X -= Velocity;
			}
			else if(Math.Abs(X - TargetX) <= Velocity)
			{
				X = TargetX;
			}
			#endregion

			#region Check Vertical Movement
			if (Y + Velocity < TargetY)
			{
				Y += Velocity;
			}
			else if (Y - Velocity > TargetY)
			{
				Y -= Velocity;
			}
			else if(Math.Abs(Y - TargetY) <= Velocity)
			{
				Y = TargetY;
			}
			#endregion
		}

	}
}
