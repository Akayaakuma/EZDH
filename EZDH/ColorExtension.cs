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

namespace EZDH
{
    public static class ColorExtension
    {
        public static string ToHexString(this Color color)
        {
            string s = "";
            int i = color.R;
            int back = i % 16;
            int front = i / 16;
            s += HexFormat(front);
            s += HexFormat(back);
            i = color.G;
            back = i % 16;
            front = i / 16;
            s += HexFormat(front);
            s += HexFormat(back);
            i = color.B;
            back = i % 16;
            front = i / 16;
            s += HexFormat(front);
            s += HexFormat(back);
            s += " ";
            i = color.A;
            back = i % 16;
            front = i / 16;
            s += HexFormat(front);
            s += HexFormat(back);
            return s;
        }

        public static string ToHexStringFormat(this Color color)
        {
            string s = "#";
            int i = color.R;
            int back = i % 16;
            int front = i / 16;
            s += HexFormat(front);
            s += HexFormat(back);
            i = color.G;
            back = i % 16;
            front = i / 16;
            s += HexFormat(front);
            s += HexFormat(back);
            i = color.B;
            back = i % 16;
            front = i / 16;
            s += HexFormat(front);
            s += HexFormat(back);
            return s;
        }

        private static char HexFormat(int i)
        {
            switch (i)
            {
                case 0:
                    return '0';
                case 1:
                    return '1';
                case 2:
                    return '2';
                case 3:
                    return '3';
                case 4:
                    return '4';
                case 5:
                    return '5';
                case 6:
                    return '6';
                case 7:
                    return '7';
                case 8:
                    return '8';
                case 9:
                    return '9';
                case 10:
                    return 'A';
                case 11:
                    return 'B';
                case 12:
                    return 'C';
                case 13:
                    return 'D';
                case 14:
                    return 'E';
                case 15:
                    return 'F';
                default:
                    return 'X';
            }
        }
    }
}
