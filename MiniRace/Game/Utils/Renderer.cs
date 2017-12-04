using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniRace.Game.Utils {
    public class Renderer {

        public static void drawString(Graphics g, Bitmap[] font, string str, int x, int y) {

            int cordX = x,
                cordY = y;

            for (int i=0; i<str.Length; i++) {
                Bitmap ch = null;
                switch(str[i]) {
                    case 'a':
                        ch = font[0];
                        break;
                    case 'b':
                        ch = font[1];
                        break;
                    case 'c':
                        ch = font[2];
                        break;
                    case 'd':
                        ch = font[3];
                        break;
                    case 'e':
                        ch = font[4];
                        break;
                    case 'f':
                        ch = font[5];
                        break;
                    case 'g':
                        ch = font[6];
                        break;
                    case 'h':
                        ch = font[7];
                        break;
                    case 'i':
                        ch = font[8];
                        break;
                    case 'j':
                        ch = font[9];
                        break;
                    case 'k':
                        ch = font[10];
                        break;
                    case 'l':
                        ch = font[11];
                        break;
                    case 'm':
                        ch = font[12];
                        break;
                    case 'n':
                        ch = font[13];
                        break;
                    case 'o':
                        ch = font[14];
                        break;
                    case 'p':
                        ch = font[15];
                        break;
                    case 'q':
                        ch = font[16];
                        break;
                    case 'r':
                        ch = font[17];
                        break;
                    case 's':
                        ch = font[18];
                        break;
                    case 't':
                        ch = font[19];
                        break;
                    case 'u':
                        ch = font[20];
                        break;
                    case 'v':
                        ch = font[21];
                        break;
                    case 'w':
                        ch = font[22];
                        break;
                    case 'x':
                        ch = font[23];
                        break;
                    case 'y':
                        ch = font[24];
                        break;
                    case 'z':
                        ch = font[25];
                        break;
                    case '.':
                        ch = font[26];
                        break;
                    case ',':
                        ch = font[27];
                        break;
                    case '!':
                        ch = font[28];
                        break;
                    case '?':
                        ch = font[29];
                        break;
                    case '+':
                        ch = font[30];
                        break;
                    case '-':
                        ch = font[31];
                        break;
                    case '=':
                        ch = font[32];
                        break;
                    case '/':
                        ch = font[33];
                        break;
                    case ':':
                        ch = font[34];
                        break;
                    case '\\':
                        ch = font[35];
                        break;
                    case '\'':
                        ch = font[36];
                        break;
                    case '@':
                        ch = font[37];
                        break;
                    case '#':
                        ch = font[38];
                        break;
                    case '$':
                        ch = font[39];
                        break;
                    case '%':
                        ch = font[40];
                        break;
                    case '^':
                        ch = font[41];
                        break;
                    case '&':
                        ch = font[42];
                        break;
                    case '*':
                        ch = font[43];
                        break;
                    case '(':
                        ch = font[44];
                        break;
                    case ')':
                        ch = font[45];
                        break;
                    case '[':
                        ch = font[46];
                        break;
                    case ']':
                        ch = font[47];
                        break;
                    case '|':
                        ch = font[48];
                        break;
                    case '{':
                        ch = font[49];
                        break;
                    case '}':
                        ch = font[50];
                        break;
                    case '<':
                        ch = font[51];
                        break;
                    case '>':
                        ch = font[52];
                        break;
                    case '"':
                        ch = font[53];
                        break;
                    case '0':
                        ch = font[54];
                        break;
                    case '1':
                        ch = font[55];
                        break;
                    case '2':
                        ch = font[56];
                        break;
                    case '3':
                        ch = font[57];
                        break;
                    case '4':
                        ch = font[58];
                        break;
                    case '5':
                        ch = font[59];
                        break;
                    case '6':
                        ch = font[60];
                        break;
                    case '7':
                        ch = font[61];
                        break;
                    case '8':
                        ch = font[62];
                        break;
                    case '9':
                        ch = font[63];
                        break;
                    case ' ':
                        cordX += 21;
                        break;
                    case '\n':
                        cordX = x;
                        cordY += 21+2;
                        break;
                }

                if(ch != null)
                    g.DrawImage(ch, cordX, cordY);

                cordX += 21 + 2;

            }
        }

    }
}
