using NoctHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EZDH.PixelColor;
using static EZDH.SearchPixel;

namespace EZDH
{
	public class SkillRunner
	{
		private Coordinate c;
		private string inputHexColorCode;
		private string boxSend;
		private int delay;
		private Thread t;
		private bool running;

		public SkillRunner(Skill s, int position)
		{
			running = true;
			if (s.GetSkillType() == SkillType.ColorTrigger)
            {
				c = new Coordinate(s.GetX(), s.GetY());
				inputHexColorCode = s.GetColor();
				boxSend = position.ToString();
				delay = 50;
				t = new Thread(RunColorTrigger);
			}
			else if (s.GetSkillType() == SkillType.TimeTrigger)
            {
				c = new Coordinate(s.GetX(), s.GetY());
				boxSend = position.ToString();
				delay = s.GetDelayTime();
				t = new Thread(RunTimeTrigger);
			}
			else if (s.GetSkillType() == SkillType.AuslaufTrigger)
            {

            }else
            {
				if (s.GetSkillName() == SkillName.HungeringArrow)
                {
					delay = 1;
					t = new Thread(RunMomentum);
					boxSend = position.ToString();
				}
            }

			if (position == 2)
            {
				c.SetX(c.GetX() + 66);
            }else if (position == 3)
            {
				c.SetX(c.GetX() + 133);
            }else if (position == 4)
            {
				c.SetX(c.GetX() + 200);
            }

		}

		private void RunColorTrigger()
		{
            while (running)
            {
				while (Form1.toggler && running) 
                {
					if (SearchPixelOne(inputHexColorCode, c))
					{
						SendKeys.SendWait(boxSend);
					}
					Thread.Sleep(delay);
				}
				Thread.Sleep(delay);
            }
		}

		private void RunTimeTrigger()
		{
			while (running)
			{
				while (Form1.toggler && running)
				{
                    try
                    {
						SendKeys.SendWait(boxSend);
					}
					catch(Exception e)
                    {
						Console.WriteLine(e.Message);
                    }

					
					Thread.Sleep(delay);
				}
				Thread.Sleep(delay);
			}
		}

		private void RunMomentum()
		{
			int y;
			Coordinate c = new Coordinate(0, 0);
			bool found;
			List<int> l = PixelCoordinatesBuff();

			while (running)
			{
				while (Form1.toggler && running)
				{
					found = false;
					//for (x = 660; x < 950; x++) //660   1300
					foreach (int x in l)
                    {
						c.SetX(x);
						c.SetY(909);

						if (SearchPixelOne("#773400", c))
                        {
							c.SetX(x + 22);
							c.SetY(914);
							if (SearchPixelOne("#53411C", c))//#D6B134
							{
								c.SetX(x + 18);
								c.SetY(923);
								if (SearchPixelOne("#B4BABC", c)) //#B4BBBB
								{
									c.SetX(x + 13);
									c.SetY(926);
									if (SearchPixelOne("#311839", c))
									{
										//wissen wo buff ist und da

										c.SetX(x + 30);
										c.SetY(950);
										if (SearchPixelOne("#FFFFFF", c))
										{
											found = true;										
										}

										c.SetX(x + 28);
										c.SetY(941);
										if (SearchPixelOne("#DBD6D3", c)) //#FEFEFE
										{
											c.SetX(x + 41);
											c.SetY(944);
											if (SearchPixelOne("#F8F8F8", c)) //#FFFFFF
											{
												found = true;
											}

											c.SetX(x + 38);
											c.SetY(944);
											if (SearchPixelOne("#FFFFFF", c))
											{
												c.SetX(x + 35);
												c.SetY(946);
												if (SearchPixelOne("#555444", c)) //#FFFFFF
												{
													found = true;
												}
											}
										}
									}
								}
							}
						}
                    }

					if (!found)
                    {
						SendKeys.SendWait(boxSend);
					}
					Thread.Sleep(delay);
				}
				Thread.Sleep(delay);
			}
		}

		public void Start()
        {
			t.Start();
        }

		public void Stop()
        {
			running = false;
        }

		private List<int> PixelCoordinatesBuff()
        {
			List<int> l = new List<int>();
			l.Add(663);
			l.Add(664);
			l.Add(665);
			l.Add(716);
			l.Add(717);
			l.Add(718);
			l.Add(719);
			l.Add(720);
			l.Add(767);
			l.Add(768);
			l.Add(769);
			l.Add(770);
			l.Add(771);
			l.Add(772);
			l.Add(773);
			l.Add(820);
			l.Add(821);
			l.Add(822);
			l.Add(823);
			l.Add(824);
			l.Add(825);
			l.Add(826);
			l.Add(872);
			l.Add(873);
			l.Add(874);
			l.Add(875);
			l.Add(876);
			l.Add(877);
			l.Add(878);
			l.Add(924);
			l.Add(925);
			l.Add(926);
			l.Add(927);
			l.Add(928);
			l.Add(929);
			l.Add(930);
			l.Add(977);
			l.Add(978);
			l.Add(979);
			l.Add(980);
			l.Add(981);
			l.Add(982);
			l.Add(983);
			l.Add(1028);
			l.Add(1029);
			l.Add(1030);
			l.Add(1031);
			l.Add(1032);
			l.Add(1033);
			l.Add(1034);
			l.Add(1081);
			l.Add(1082);
			l.Add(1083);
			l.Add(1084);
			l.Add(1085);
			l.Add(1086);
			l.Add(1087);
			l.Add(1133);
			l.Add(1134);
			l.Add(1135);
			l.Add(1136);
			l.Add(1137);
			l.Add(1138);
			l.Add(1139);
			return l;
		}
	}
}
