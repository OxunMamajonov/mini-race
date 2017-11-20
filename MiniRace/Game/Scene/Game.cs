using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniRace.Resources;

namespace MiniRace.Game.Scene {
    public class Game : Scene {

        private ushort[,] map;
        private int size = 40;
        private int tileSize = 25;
        private Random rnd = new Random();
        private int time = 0;
        private int leftWall, rightWall;

        public Game(Main main) : base(main) {
            map = new ushort[size, size];
            
            for (int i = 0; i < size; i++)
                for(int j=0; j< size; j++)
                    map[j, i] = 1;

            for (int i = 0; i < 100; i++)
                map[rnd.Next(0, size), rnd.Next(0, size)] = (ushort)rnd.Next(2);

            leftWall = 0;
            rightWall = size - 1;
        }

        public override void paint(Graphics g) {
            //List<Point> pacmanCords = new List<Point>();

            int offsetCenter = -main.screen.Height / 2 + (main.screen.Width - size) / 2 + tileSize;

            //int offsetCenter = (Width/side)*8

            for (int j = 0; j < main.screen.Height / tileSize; j++) {
                for (int i = 0; i < main.screen.Height / tileSize; i++) {
                    double relX = i / (main.screen.Height / (double)tileSize);
                    double relY = j / (main.screen.Height / (double)tileSize);
                    int x = (int)(relX * size);
                    int y = (int)(relY * size);

                    //Layer 1
                    if (map[x, y] == 0)
                        g.DrawImage(Bundle.wall, offsetCenter + i * tileSize, j * tileSize, tileSize, tileSize);
                    else
                        g.DrawImage(Bundle.floor, offsetCenter + i * tileSize, j * tileSize, tileSize, tileSize);
                    ////Layer 2
                    if (map[x, y] == 2)
                        g.DrawImage(Bundle.car, offsetCenter + i * tileSize, j * tileSize, tileSize, tileSize);
                }
            }

            if(time < 30) {
                time++;
                roll();
            } else {
                time = 0;
            }
                
        }

        private void roll() {
            for (int i = size - 1; i > 0; i--) {
                for (int j = 0; j < size; j++) {
                    map[j, i] = map[j, i - 1];
                    map[j, i - 1] = 1;
                }
            }
            //If not near the left corner

            int a = rnd.Next(0, 10);

            if (a == 0)
                leftWall += 1;
            else if (a > 7)
                leftWall -= 1;


            rightWall += rnd.Next(-1, 1);

            for (int j = 0; j < leftWall; j++)
                map[j, 0] = 0;
            for (int j = size-1; j > rnd.Next(size - 12, size - 2); j--)
                map[j, 0] = 0;
        }
    }
}
