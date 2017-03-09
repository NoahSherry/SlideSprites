using System;
using System.Threading;
using System.Windows.Forms;

namespace assignment03
{
	public partial class ChaosEngine : Form
	{
		public static Form form;
		public static Thread thread;
		public static Thread thread2;
		public static int fps = 30;
		public static double running_fps = 30.0;
		public static Sprite parent = new Sprite();
		public static SlidingSprite rupee = new SlidingSprite(assignment03.Properties.Resources.rupee);

		public ChaosEngine()
		{
			InitializeComponent();
			DoubleBuffered = true;
			form = this;
			rupee.X = 50;
			rupee.Y = 50;
			thread = new Thread(new ThreadStart(Update));
			thread.Start();
			thread2 = new Thread(new ThreadStart(Render));
			thread2.Start();
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			thread.Abort();
			thread2.Abort();
		}

		public static void Update()
		{
			DateTime last = DateTime.Now;
			DateTime now = last;
			TimeSpan frameTime = new TimeSpan(10000000 / fps);
			while (true)
			{
				DateTime temp = DateTime.Now;
				running_fps = .9 * running_fps + .1 * 1000.0 / (temp - now).TotalMilliseconds;
				Console.WriteLine(running_fps);
				now = temp;
				TimeSpan diff = now - last;
				if (diff.TotalMilliseconds < frameTime.TotalMilliseconds)
					Thread.Sleep((frameTime - diff).Milliseconds);
				last = DateTime.Now;
				form.Invoke(new MethodInvoker(form.Refresh));
			}
		}

		public static void Render()
		{
			DateTime last = DateTime.Now;
			DateTime now = last;
			TimeSpan frameTime = new TimeSpan(10000000 / fps);
			while (true)
			{
				DateTime temp = DateTime.Now;
				running_fps = .9 * running_fps + .1 * 1000.0 / (temp - now).TotalMilliseconds;
				Console.WriteLine(running_fps);
				now = temp;
				TimeSpan diff = now - last;
				if (diff.TotalMilliseconds < frameTime.TotalMilliseconds)
					Thread.Sleep((frameTime - diff).Milliseconds);
				last = DateTime.Now;
				rupee.Act();
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			rupee.Render(e.Graphics);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}
	}
}
