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
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInf);

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        public static bool toggler;

        public List<Skill> Skillliste;

        private SkillRunner sr1;
        private SkillRunner sr2;
        private SkillRunner sr3;
        private SkillRunner sr4;

        private bool mainToggler;

        //Farben  wenn buff nach ablaufzeit gucken und drücken
        //string rache = "#6C6C54";
        //string dolchfaecher = "#6D6B54";
        //string gefaerte = "#6B6958";
        //string vorbereitung = "#6E6855";
        //string landtotsimu = "#6D6C54";
        //string ip = "#6D6C53";
        //string shout = "#6C6C53";
        //string warcry = "#6C6B54";
        //string battlerage = "#6C6C54";
        //string sprint = "#6D6C54";
        //string berserk = "#666D54";
        //string sanc = "#71694C";
        //string serenity = "#6D6C54";
        //string epiphany = "#6B6952";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Skillliste = Skill.AllSkills();
            FillComboboxes();
            mainToggler = false;
            toggler = false;
            CheckForIllegalCrossThreadCalls = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void FillComboboxes()
        {
            foreach (Skill skill in Skillliste)
            {
                comboBox1.Items.Add(skill);
                comboBox2.Items.Add(skill);
                comboBox3.Items.Add(skill);
                comboBox4.Items.Add(skill);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked)
                {

                    Keys k;
                    Enum.TryParse<Keys>(comboBox5.Text, out k);
                    if (k == null)
                    {
                        MessageBox.Show("NÖ");
                        continue;
                    }

                    if (GetAsyncKeyState(k) < 0)
                    {
                        //threads = true;
                        toggler = !toggler;
                        checkBox5.Checked = toggler;
                        Thread.Sleep(500);
                        //MessageBox.Show("rip");
                    }
                    else if (GetAsyncKeyState(Keys.Escape) < 0)
                    {
                        toggler = false;
                    }
                    else if (GetAsyncKeyState(Keys.T) < 0)
                    {
                        toggler = false;
                    }

                    checkBox5.Checked = toggler;

                    Thread.Sleep(1);
                }
                else
                {
                    Keys k;
                    Enum.TryParse<Keys>(comboBox5.Text, out k);
                    if (k == null)
                    {
                        MessageBox.Show("NÖ");
                        continue;
                    }

                    if (GetAsyncKeyState(k) < 0)
                    {

                        MessageBox.Show("Kein Skill Gewählt");
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!mainToggler)
            {
                button1.Text = "Stop";
                if (checkBox1.Checked)
                {
                    sr1 = new SkillRunner((Skill)comboBox1.SelectedItem, 1);
                    sr1.Start();
                }
                if (checkBox2.Checked)
                {
                    sr2 = new SkillRunner((Skill)comboBox2.SelectedItem, 2);
                    sr2.Start();
                }
                if (checkBox3.Checked)
                {
                    sr3 = new SkillRunner((Skill)comboBox3.SelectedItem, 3);
                    sr3.Start();
                }
                if (checkBox4.Checked)
                {
                    sr4 = new SkillRunner((Skill)comboBox4.SelectedItem, 4);
                    sr4.Start();
                }
                mainToggler = true;
            }
            else
            {
                button1.Text = "Start";
                if (sr1 != null)
                {
                    sr1.Stop();
                }
                if (sr2 != null)
                {
                    sr2.Stop();
                }
                if (sr3 != null)
                {
                    sr3.Stop();
                }
                if (sr4 != null)
                {
                    sr4.Stop();
                }
                mainToggler = false;
            }
        }
    }
}
